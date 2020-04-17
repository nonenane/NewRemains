using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using Nwuram.Framework.Data;
using Nwuram.Framework.Settings.Connection;
using System.Data;

namespace NewRemains
{
    class readSQL
    {
        static ArrayList ap = new ArrayList();
        static SqlProvider sql = new SqlProvider(ConnectionSettings.GetServer(), ConnectionSettings.GetDatabase(), ConnectionSettings.GetUsername(), ConnectionSettings.GetPassword(), ConnectionSettings.ProgramName);
        static SqlProvider sql_dop = new SqlProvider(ConnectionSettings.GetServer("2"), ConnectionSettings.GetDatabase("2"), ConnectionSettings.GetUsername(), ConnectionSettings.GetPassword(), ConnectionSettings.ProgramName);

        public static DataTable getDeps()
        {
            ap.Clear();
            return sql.executeProcedure("[NewRemains].[getDeps]", new string[0] { }, new DbType[0] { }, ap);
        }

        public static DataTable getTU()
        {
            ap.Clear();
            ap.Add(Config.id_otdel);
            ap.Add(Config.isManager);
            ap.Add(Nwuram.Framework.Settings.User.UserSettings.User.Id);
            if (Config.id_otdel != 6)
            {
                return sql.executeProcedure("[NewRemains].[getTU]",
                    new string[3] { "@id_otdel", "@isManager", "@id_users" },
                    new DbType[3] { DbType.Int32, DbType.Boolean, DbType.Int32 }, ap);
            }
            else
            {
                return sql_dop.executeProcedure("[NewRemains].[getTU]",
                   new string[3] { "@id_otdel", "@isManager", "@id_users" },
                   new DbType[3] { DbType.Int32, DbType.Boolean, DbType.Int32 }, ap);
            }
        }

        public static DataTable getInv()
        {
            ap.Clear();
            ap.Add(Config.id_otdel);
            ap.Add(Config.isManager);
            ap.Add(Nwuram.Framework.Settings.User.UserSettings.User.Id);
            if (Config.id_otdel != 6)
            {
                return sql.executeProcedure("[NewRemains].[getInv]",
                    new string[3] { "@id_otdel", "@isManager", "@id_users" },
                    new DbType[3] { DbType.Int32, DbType.Boolean, DbType.Int32 }, ap);
            }
            else
            {
                return sql_dop.executeProcedure("[NewRemains].[getInv]",
                    new string[3] { "@id_otdel", "@isManager", "@id_users" },
                    new DbType[3] { DbType.Int32, DbType.Boolean, DbType.Int32 }, ap);
            }
        }

        public static DataTable getTostResult(DateTime date,int id_otdel)
        {
            ap.Clear();
            ap.Add(date);
            if (id_otdel != 6)
            {
                return sql.executeProcedure("[NewRemains].[getTostResult]",
                    new string[1] { "@date" },
                    new DbType[1] { DbType.Date }, ap);
            }
            else
            {
                return sql_dop.executeProcedure("[NewRemains].[getTostResult]",
                    new string[1] { "@date" },
                    new DbType[1] { DbType.Date }, ap);
            }
        }

        public static DataTable getUL(DateTime date)
        {
            DataTable dtListUlt = new DataTable();
            DataTable SelectedMainOrg_1 = new DataTable();
            DataTable SelectedMainOrg_2 = new DataTable();
            ap.Clear();
            ap.Add(Config.id_otdel);
            ap.Add(date);
            if (Config.id_otdel != 6)
            {
                dtListUlt = sql.executeProcedure("[NewRemains].[getUL]",
                    new string[2] { "@id_otdel", "@date" },
                    new DbType[2] { DbType.Int32, DbType.Date }, ap);
            }
            else
            {
                dtListUlt = sql_dop.executeProcedure("[NewRemains].[getUL]",
                    new string[2] { "@id_otdel", "@date" },
                    new DbType[2] { DbType.Int32, DbType.Date }, ap);
            }
            SelectedMainOrg_1 = sql.executeProcedure("[NewRemains].[getSelMainOrg]",
                new string[0] { },
                new DbType[0] { }, ap);
            SelectedMainOrg_2 = sql_dop.executeProcedure("[NewRemains].[getSelMainOrg]",
                new string[0] { },
                new DbType[0] { }, ap);

            if (SelectedMainOrg_2 != null)
                SelectedMainOrg_1.Merge(SelectedMainOrg_2);

            SelectedMainOrg_1.DefaultView.Sort = "nTypeOrg asc";
            SelectedMainOrg_1 = SelectedMainOrg_1.DefaultView.ToTable(true);

            var query = (from t1 in dtListUlt.AsEnumerable()
                         join t2 in SelectedMainOrg_1.AsEnumerable() on t1.Field<int>("nTypeOrg") equals t2.Field<int>("nTypeOrg")
                         //select t1
                         select new { nTypeOrg = t1["nTypeOrg"], Abbriviation = t1["Abbriviation"] }
                                );
            DataTable newTable = new DataTable();
            newTable.Columns.Add("nTypeOrg", typeof(Int32));
            newTable.Columns.Add("Abbriviation", typeof(string));
            newTable.Rows.Add(0, "Все ЮЛ");
            foreach (var rowInfo in query)
            {
                newTable.Rows.Add(rowInfo.nTypeOrg, rowInfo.Abbriviation);
            }
            return newTable;
        }

        public static DataTable getMainList(int id_otdel,int @round,int @roundGlob)
        {
            ap.Clear();
            ap.Add(id_otdel);
            ap.Add(Config.globalDate);
            ap.Add(@round);
            ap.Add(@roundGlob);
            ap.Add(Nwuram.Framework.Settings.User.UserSettings.User.Id);
            ap.Add(Nwuram.Framework.Settings.Connection.ConnectionSettings.GetIdProgram());
            ap.Add(Config.isManager);
            if (id_otdel != 6)
            {
                return sql.executeProcedure("[NewRemains].[getMainList]",
                    new string[7] { "@id_otdel", "@date", "@round", "@roundGlob", "@id_user", "@id_prog", "@isManager" },
                    new DbType[7] { DbType.Int32, DbType.Date, DbType.Int32, DbType.Int32, DbType.Int32, DbType.Int32, DbType.Int32 }, ap);
            }
            else
            {
                return sql_dop.executeProcedure("[NewRemains].[getMainList]",
                    new string[7] { "@id_otdel", "@date", "@round", "@roundGlob", "@id_user", "@id_prog", "@isManager" },
                    new DbType[7] { DbType.Int32, DbType.Date, DbType.Int32, DbType.Int32, DbType.Int32, DbType.Int32, DbType.Int32 }, ap);
            }
        }

        public static DataTable GetInnList(string str)
        {
            ap.Clear();
            ap.Add(str);
            return sql.executeProcedure("[NewRemains].[GetInnList]",
                new string[1] { "@str" },
                new DbType[1] { DbType.String }, ap);
        }

        //public static DataTable GetInnList(string str)
        //{
        //    ap.Clear();
        //    ap.Add(str);
        //    return sql.executeProcedure("[NewRemains].[GetInnList]",
        //        new string[1] { "@str" },
        //        new DbType[1] { DbType.String }, ap);
        //}


        public static DataTable getConfigList(int type)
        {
            ap.Clear();
            ap.Add(Nwuram.Framework.Settings.Connection.ConnectionSettings.GetIdProgram());
            ap.Add(Nwuram.Framework.Settings.User.UserSettings.User.Id);
            if (type == 1)
                return sql.executeProcedure("[NewRemains].[getConfigList]",
                    new string[2] { "@id_Prog", "@idUser" },
                    new DbType[2] { DbType.Int32, DbType.Int32 }, ap);
            if (type == 2)
                return sql.executeProcedure("[NewRemains].[getConfigNODP]",
                    new string[2] { "@id_Prog", "@idUser" },
                    new DbType[2] { DbType.Int32, DbType.Int32 }, ap);
            if (type == 3)
                return sql.executeProcedure("[NewRemains].[getConfigPSUM]",
                    new string[2] { "@id_Prog", "@idUser" },
                    new DbType[2] { DbType.Int32, DbType.Int32 }, ap);
            return null;
        }

        public static DataTable setConfigList(int type,int value)
        {
            ap.Clear();
            ap.Add(Nwuram.Framework.Settings.Connection.ConnectionSettings.GetIdProgram());
            ap.Add(Nwuram.Framework.Settings.User.UserSettings.User.Id);
            ap.Add(value);
            if (type == 1)
                return sql.executeProcedure("[NewRemains].[setConfigList]",
                    new string[3] { "@id_Prog", "@idUser", "@idPost" },
                    new DbType[3] { DbType.Int32, DbType.Int32, DbType.Int32 }, ap);
            if (type == 2)
                return sql.executeProcedure("[NewRemains].[setConfigNODP]",
                    new string[3] { "@id_Prog", "@idUser","@val" },
                    new DbType[3] { DbType.Int32, DbType.Int32, DbType.Int32 }, ap);
            if (type == 3)
                return sql.executeProcedure("[NewRemains].[setConfigPSUM]",
                    new string[3] { "@id_Prog", "@idUser","@val" },
                    new DbType[3] { DbType.Int32, DbType.Int32, DbType.Int32 }, ap);
            return null;
        }

        public static void deleteConfigList()
        {
            ap.Clear();
            ap.Add(Nwuram.Framework.Settings.Connection.ConnectionSettings.GetIdProgram());
            ap.Add(Nwuram.Framework.Settings.User.UserSettings.User.Id);
            sql.executeProcedure("[NewRemains].[deleteConfigList]",
                    new string[2] { "@id_Prog", "@idUser" },
                    new DbType[2] { DbType.Int32, DbType.Int32 }, ap);
        }

        public static DataTable getConfigRN()
        {
            ap.Clear();          
            return sql.executeProcedure("[NewRemains].[getConfigRN]",
                    new string[0] {  },
                    new DbType[0] { }, ap);
        }

        public static void deleteConfigList(int id_inv,int id_otdel)
        {
            ap.Clear();
            ap.Add(id_inv);
            if (id_otdel != 6)
            {
                sql.executeProcedure("[NewRemains].[deleteInvOst]",
                        new string[1] { "@id_inv" },
                        new DbType[1] { DbType.Int32 }, ap);
            }
            else
            {
                sql_dop.executeProcedure("[NewRemains].[deleteInvOst]",
                        new string[1] { "@id_inv" },
                        new DbType[1] { DbType.Int32 }, ap);
            }
        }

        public static void setInvOst(int id_inv, int id_otdel,int id_tovar,double netto,double price,int ntypeorg)
        {
            ap.Clear();
            ap.Add(id_inv);
            ap.Add(id_tovar);
            ap.Add(netto.ToString("#0.##0"));
            ap.Add(price.ToString("#0.##0"));
            ap.Add(ntypeorg);
            if (id_otdel != 6)
            {
                sql.executeProcedure("[NewRemains].[setInvOst]",
                        new string[5] { "@id_ttost", "@id_tovar", "@netto", "@price", "@ntypeorg" },
                        new DbType[5] { DbType.Int32, DbType.Int32, DbType.Double, DbType.Double, DbType.Int32 }, ap);
            }
            else
            {
                sql_dop.executeProcedure("[NewRemains].[setInvOst]",
                        new string[5] { "@id_ttost", "@id_tovar", "@netto", "@price", "@ntypeorg" },
                        new DbType[5] { DbType.Int32, DbType.Int32, DbType.Double, DbType.Double, DbType.Int32 }, ap);
            }
        }

        public static void setInvPrice(int id_otdel,int id_tovar, DateTime date, double price, int ntypeorg)
        {
            ap.Clear();            
            ap.Add(id_tovar);
            ap.Add(date);
            ap.Add(price);
            ap.Add(ntypeorg);
            if (id_otdel != 6)
            {
                sql.executeProcedure("[NewRemains].[setInvPrice]",
                        new string[4] { "@id_tovar", "@date", "@price", "@ntypeorg" },
                        new DbType[4] { DbType.Int32, DbType.Date, DbType.Double, DbType.Int32 }, ap);
            }
            else
            {
                sql_dop.executeProcedure("[NewRemains].[setInvPrice]",
                        new string[4] { "@id_tovar", "@date", "@price", "@ntypeorg" },
                        new DbType[4] { DbType.Int32, DbType.Date, DbType.Double, DbType.Int32 }, ap);
            }
        }


        public static DataTable getMainListInvSpis(int id_otdel, int @round, int @roundGlob)
        {
            ap.Clear();
            ap.Add(id_otdel);
            ap.Add(Config.globalDate);
            ap.Add(@round);
            ap.Add(@roundGlob);
            ap.Add(Nwuram.Framework.Settings.User.UserSettings.User.Id);
            ap.Add(Nwuram.Framework.Settings.Connection.ConnectionSettings.GetIdProgram());
            ap.Add(Config.isManager);
            if (id_otdel != 6)
            {
                return sql.executeProcedure("[NewRemains].[getMainListInvSpis]",
                    new string[7] { "@id_otdel", "@date", "@round", "@roundGlob", "@id_user", "@id_prog", "@isManager" },
                    new DbType[7] { DbType.Int32, DbType.Date, DbType.Int32, DbType.Int32, DbType.Int32, DbType.Int32, DbType.Int32 }, ap);
            }
            else
            {
                return sql_dop.executeProcedure("[NewRemains].[getMainListInvSpis]",
                    new string[7] { "@id_otdel", "@date", "@round", "@roundGlob", "@id_user", "@id_prog", "@isManager" },
                    new DbType[7] { DbType.Int32, DbType.Date, DbType.Int32, DbType.Int32, DbType.Int32, DbType.Int32, DbType.Int32 }, ap);
            }
        }


        public static DataTable GetOstTovarExpDate(DateTime dateIn, int id_tovar)
        {
            ap.Clear();
            ap.Add(dateIn);
            ap.Add(id_tovar);
            //if (id_otdel != 6)
            //{
                return sql.executeProcedure("[NewRemains].[GetOstTovarExpDate]",
                    new string[2] { "@dateIn", "@id_tovar" },
                    new DbType[2] {  DbType.Date, DbType.Int32 }, ap);
            //}
            //else
            //{
            //    return sql_dop.executeProcedure("[NewRemains].[GetOstTovarExpDate]",
            //        new string[7] { "@id_otdel", "@date", "@round", "@roundGlob", "@id_user", "@id_prog", "@isManager" },
            //        new DbType[7] { DbType.Int32, DbType.Date, DbType.Int32, DbType.Int32, DbType.Int32, DbType.Int32, DbType.Int32 }, ap);
            //}
        }

        public static DataTable SetOstTovarExpDate( int id_tovar,int id_ttost,object expDate,decimal netto,bool isDel)
        {
            ap.Clear();            
            ap.Add(id_tovar);
            ap.Add(id_ttost);
            ap.Add(expDate);
            ap.Add(netto);
            ap.Add(Nwuram.Framework.Settings.User.UserSettings.User.Id);
            ap.Add(isDel);
            //if (id_otdel != 6)
            //{
            return sql.executeProcedure("[NewRemains].[SetOstTovarExpDate]",
                new string[6] { "@id_tovar", "@id_ttost", "@expDate", "@netto", "@id_user","@isDel" },
                new DbType[6] {  DbType.Int32,DbType.Int32,DbType.Date,DbType.Decimal,DbType.Int32,DbType.Boolean }, ap);
            //}
            //else
            //{
            //    return sql_dop.executeProcedure("[NewRemains].[GetOstTovarExpDate]",
            //        new string[7] { "@id_otdel", "@date", "@round", "@roundGlob", "@id_user", "@id_prog", "@isManager" },
            //        new DbType[7] { DbType.Int32, DbType.Date, DbType.Int32, DbType.Int32, DbType.Int32, DbType.Int32, DbType.Int32 }, ap);
            //}
        }
    }
}
