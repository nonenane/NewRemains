USE [dbase1]
GO
/****** Object:  StoredProcedure [NewRemains].[getMainList]    Script Date: 17.04.2020 14:10:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		SPG
-- Create date: 2014-05-29
-- Description:	ﾏ鸙褊韃 ⅲ濵粹鵫 硴頽・
-- exec [NewRemains].[getMainList] 6, '2014-06-04',4,4
-- =============================================
ALTER PROCEDURE [NewRemains].[getMainList]
 @id_otdel int
,@date datetime
,@round int
,@roundGlob int
,@id_user int
,@id_prog int
,@isManager int
,@ntypeorg int=16
AS
BEGIN
SET NOCOUNT ON;
SET XACT_ABORT ON;

declare @DateInv datetime
declare @IdInv datetime
declare @dateRN datetime

declare @ul varchar(2)
set @ul=(select Abbriviation from [ISI_SERVER].[dbase1].[dbo].[s_MainOrg] where nTypeOrg=@ntypeorg)

--select TOP(1) @DateInv = dttost, @IdInv=id from j_ttost where dttost<@date and promeg=0 order by dttost desc
declare @N int=2
	
	if exists (select  value from ISI_SERVER.dbase1.dbo.prog_config where id_prog=17 and id_value='Dinv')
	begin
		select @N = value from ISI_SERVER.dbase1.dbo.prog_config where id_prog=17 and id_value='Dinv'
	end


select TOP(1) @DateInv = dttost, @IdInv=id from j_ttost 
where dttost<@date and promeg=0  and datediff(day,dttost,getdate())>=@N
order by dttost desc


select SUM(netto) as netto ,id_tovar into #dtOst  from j_ost 
where id_tost in (select id from j_tost where id_ttost= @IdInv)
and (0=@ntypeorg or ntypeorg=@ntypeorg)
group by id_tovar
order by id_tovar asc


select 
	sum(p.netto) as netto, p.id_tovar 
into #dtPrihod
from 
	j_allprihod a
	inner join j_prihod p on p.id_allprihod=a.id
where 
	a.dprihod<@date and a.dprihod>@DateInv and a.id_operand in (1,3) and (0=@ntypeorg or a.ntypeorg=@ntypeorg)
group by p.id_tovar
order by p.id_tovar asc


select 
	sum(p.netto) as netto, p.id_tovar 
into #dtVozvkass
from 
	j_allprihod a
	inner join j_vozvkass p on p.id_allprihod=a.id
where 
	a.dprihod<@date and a.dprihod>@DateInv  and a.id_operand in (7) and (0=@ntypeorg or a.ntypeorg=@ntypeorg)
group by p.id_tovar
order by p.id_tovar asc

select 
	sum(p.netto) as netto, p.id_tovar
into #dtOtgruz
from 
	j_allprihod a
	inner join j_otgruz p on p.id_allprihod=a.id
where 
	a.dprihod<@date and a.dprihod>@DateInv  and a.id_operand in (8) and (0=@ntypeorg or a.ntypeorg=@ntypeorg)
group by p.id_tovar
order by p.id_tovar asc


select 
	sum(p.netto) as netto, p.id_tovar
into #dtVozvr 
from 
	j_allprihod a
	inner join j_vozvr p on p.id_allprihod=a.id
where 
	a.dprihod<@date and a.dprihod>@DateInv  and a.id_operand in (2) and (0=@ntypeorg or a.ntypeorg=@ntypeorg)
group by p.id_tovar
order by p.id_tovar asc


select 
	sum(p.netto) as netto, p.id_tovar
into #dtSpis  
from 
	j_allprihod a
	inner join j_spis p on p.id_allprihod=a.id
where 
	a.dprihod<@date and a.dprihod>@DateInv  and a.id_operand in (5) and (0=@ntypeorg or a.ntypeorg=@ntypeorg)
group by p.id_tovar
order by p.id_tovar asc

select 
	sum(p.netto) as netto, p.id_tovar
into #dtRealiz  
from 
	j_realiz p
where 
	p.drealiz<@date and p.drealiz>@DateInv and (0=@ntypeorg or p.ntypeorg=@ntypeorg)
group by p.id_tovar
order by p.id_tovar asc


--select *from #dtOst
--#dtPrihod
--#dtVozvkass
--#dtOtgruz
--#dtVozvr
--#dtSpis
--#dtRealiz  

select 
	* into #glg
	--,select * from [dbo].[ost_of_remains_tovar] (2204,300,'2014-05-21','2014-04-28') 
from (
		select 
			t.*	
			--,ISNULL(ost.netto,0) as ostN 
			--,ISNULL(pri.netto,0) as priN
			--,ISNULL(vozk.netto,0) as vozkN
			--,ISNULL(otg.netto,0) as otgN
			--,ISNULL(voz.netto,0) as vozN
			--,ISNULL(spis.netto,0) as spisN
			--,ISNULL(rea.netto,0) as reaN 
			
			,(ISNULL(ost.netto,0) + 
			(ISNULL(pri.netto,0)-ISNULL(vozk.netto,0)) -
			(ISNULL(otg.netto,0)+ISNULL(voz.netto,0) + ISNULL(spis.netto,0) +ISNULL(rea.netto,0))) as ost
		from 
			s_tovar t
			left join #dtOst ost on ost.id_tovar = t.id
			left join #dtPrihod pri on pri.id_tovar = t.id
			left join #dtVozvkass vozk on vozk.id_tovar = t.id
			left join #dtOtgruz otg on otg.id_tovar = t.id
			left join #dtVozvr voz on voz.id_tovar = t.id
			left join #dtSpis spis on spis.id_tovar = t.id
			left join #dtRealiz rea on rea.id_tovar = t.id
		where 
		t.id_otdel=@id_otdel		
		
) t where t.ost<>0 --or t.ost=0
order by t.id asc
--select * from #glg

IF EXISTS ( select * from  #glg where ost<>0) 
begin

		declare @table table(
		 id_tovar int,
		 id_post int,
		 netto numeric(11,3),
		 zcena numeric(11,4),
		 Sgn int
		 )

		--select * from #glg
		declare @id_tovar int
		declare @ost numeric(11,3)
		DECLARE SysCur CURSOR READ_ONLY FOR select id,ost from #glg
		OPEN SysCur
		FETCH NEXT FROM SysCur INTO @id_tovar,@ost--, @id_post,@netto,@zcena
		WHILE @@FETCH_STATUS=0 BEGIN
			
			--select * from [dbo].[ost_of_remains_tovar] (@id_tovar,@ost,'2014-05-21','2014-04-28') 
			insert into @table(id_tovar,id_post,netto,zcena,Sgn)
			select * from [dbo].[ost_of_remains_tovar] (@id_tovar,@ost,@date,@DateInv,@ntypeorg) 

		FETCH NEXT FROM SysCur  INTO @id_tovar,@ost--, @id_post,@netto,@zcena
		END
		CLOSE SysCur
		DEALLOCATE SysCur



		--select * from #glg

		select 
			st.id_grp1,
			st.id_grp2,
			isnull(ltrim(rtrim(p.cname)),'') as cname,
			/*(select abb from [dbo].[getULTovarRemains](t.id_tovar,@date,@id_otdel))*/@ul as ul,
			ltrim(rtrim(st.ean)) as ean,
			((select top(1) isnull((select rtrim(ltrim(cName)) from s_TypeTovar where id=ntypetovar)+' ','') 
			+  rtrim(ltrim(n.cname)) from s_ntovar n where n.id_tovar=t.id_tovar and n.tdate_n<=@date order by n.tdate_n desc)) as nameTovar,
			t.netto,
			ROUND(round(t.zcena,@round),@roundGlob) as zcena,
			case when r.rcena is not null then r.rcena
			else (select top(1) rcena from s_rcena where id_tovar=t.id_tovar order by tdate_n asc)
			end as rcena,
			round(round(t.zcena,@round)*t.netto,2) as sumZ,
			round(round(r.rcena,@round)*t.netto,2) as sumR,
			@id_otdel as id_otdel,
			t.id_tovar,
			t.Sgn,
			round(round(t.zcena,@round)*t.netto,2) as zcenaStab,
			0 as editing,
			t.id_post
		into #FinishTable  
		from 
			@table t
			left join s_tovar st on st.id=t.id_tovar
			left join s_post p on p.id=t.id_post
			left join s_rcena r on r.id_tovar=t.id_tovar and r.id = (select top(1) id from s_rcena where id_tovar=t.id_tovar and tdate_n<@date order by tdate_n desc)
		where
			(@isManager=0 or (st.id_grp1 in (select id_grp1 from users_vs_grp1 where id_users =@id_user)))
		and (@isManager=0 or ( st.id_grp2 in (select id_grp2 from grp1_vs_grp2 where id_grp1 in (select id_grp1 from users_vs_grp1 where id_users =@id_user))))
		--where t.id_post in (select val from property_list where id_prog=261 and id_user=427 and id_val='IDPS')

		
	DECLARE @prnc numeric(16,2) = 1
	select @prnc = CAST(LEFT(value, CHARINDEX(',', value) - 1) + '.' + SUBSTRING(value,(CHARINDEX(',',value)+1),2) AS numeric(16,2)) 
	from dbo.prog_config where id_prog = 106 and id_value='prnc'

		if exists (select val from ISI_SERVER.dbase1.[dbo].[property_list] where id_prog=@id_prog and id_user=@id_user and id_val='PSUM' and val=1)
		begin
		select 
					id_grp1,
					id_grp2,
					cname,
					ul,
					ean,
					nameTovar,
					sum(netto) as netto,
					zcena,
					rcena,
					--round(zcena*sum(netto),2) as sumZ,
					--round(rcena*sum(netto),2) as sumR,
					sum(round(zcena*netto,2)) as sumZ,
					sum(round(rcena*netto,2)) as sumR,
					id_otdel,
					id_tovar,
					Sgn,
					--round(zcena*sum(netto),2) as zcenaStab,
					sum(round(zcena*netto,2)) as zcenaStab,
					editing,
					id_post,
					/*(select nTypeOrg from [dbo].[getULTovarRemains](t.id_tovar,@date,@id_otdel))*/@ntypeorg as nTypeOrg
						,t.rcena as realRcena
					,t.rcena * (100 - @prnc)/100 as minPrice 
					,t.rcena * (100 + @prnc)/100 as maxPrice
					,@prnc as prnc
					from #FinishTable t 
					group by id_grp1,id_grp2,cname,ul,ean,nameTovar,zcena,rcena,id_otdel,id_tovar,Sgn,editing,id_post
					order by t.cname asc
		
		end
		else
		begin		

			if  exists (select val from ISI_SERVER.[dbase1].[dbo].[property_list] where id_prog=@id_prog and id_user=@id_user and id_val='IDPS')
				begin				
						select 
						id_grp1,
						id_grp2,
						cname,
						ul,
						ean,
						nameTovar,
						sum(netto) as netto,
						zcena,
						rcena,
						--round(zcena*sum(netto),2) as sumZ,
						--round(rcena*sum(netto),2) as sumR,
						sum(round(zcena*netto,2)) as sumZ,
						sum(round(rcena*netto,2)) as sumR,
						id_otdel,
						id_tovar,
						Sgn,
						--round(zcena*sum(netto),2) as zcenaStab,
						sum(round(zcena*netto,2)) as zcenaStab,
						editing,
						id_post,
						/*(select nTypeOrg from [dbo].[getULTovarRemains](t.id_tovar,@date,@id_otdel))*/@ntypeorg as nTypeOrg
							,t.rcena as realRcena
					,t.rcena * (100 - @prnc)/100 as minPrice 
					,t.rcena * (100 + @prnc)/100 as maxPrice
					,@prnc as prnc
						from #FinishTable t where t.id_post in (select val from ISI_SERVER.dbase1.[dbo].[property_list] where id_prog=@id_prog and id_user=@id_user and id_val='IDPS')
						group by id_grp1,id_grp2,cname,ul,ean,nameTovar,zcena,rcena,id_otdel,id_tovar,Sgn,editing,id_post
						--order by t.cname asc
						
						union all
						
						select 
						id_grp1,
						id_grp2,
						cname,
						ul,
						ean,
						nameTovar,
						netto as netto,
						zcena,
						rcena,
						round(zcena*netto,2) as sumZ,
						round(rcena*netto,2) as sumR,
						id_otdel,
						id_tovar,
						Sgn,
						round(zcena*netto,2) as zcenaStab,
						editing,
						id_post,
						/*(select nTypeOrg from [dbo].[getULTovarRemains](t.id_tovar,@date,@id_otdel))*/@ntypeorg as nTypeOrg 
							,t.rcena as realRcena
					,t.rcena * (100 - @prnc)/100 as minPrice 
					,t.rcena * (100 + @prnc)/100 as maxPrice
					,@prnc as prnc
						from #FinishTable t where t.id_post not in (select val from ISI_SERVER.dbase1.[dbo].[property_list] where id_prog=@id_prog and id_user=@id_user and id_val='IDPS')
						order by t.cname asc
						--print '1'
				end
			else			
				begin
				--print '2'
						select 
						
						id_grp1,
						id_grp2,
						cname,
						ul,
						ean,
						nameTovar,
						netto as netto,
						zcena,
						rcena,
						round(zcena*netto,2) as sumZ,
						round(rcena*netto,2) as sumR,
						id_otdel,
						id_tovar,
						Sgn,
						round(zcena*netto,2) as zcenaStab,
						editing,
						id_post, 
						/*(select nTypeOrg from [dbo].[getULTovarRemains](t.id_tovar,@date,@id_otdel))*/@ntypeorg as nTypeOrg
							,t.rcena as realRcena
					,t.rcena * (100 - @prnc)/100 as minPrice 
					,t.rcena * (100 + @prnc)/100 as maxPrice
					,@prnc as prnc
						from #FinishTable t 
						order by t.cname asc
				end
		end

end



--select * from #FinishTable
--select * from [dbo].[ost_of_remains_tovar] (160579,21.478,'2014-05-21','2014-04-28') 
drop table #dtOst
drop table #dtPrihod
drop table #dtVozvkass
drop table #dtOtgruz
drop table #dtVozvr
drop table #dtSpis
drop table #dtRealiz 
drop table #glg

END
