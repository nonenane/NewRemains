using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using Nwuram.Framework.Settings.Connection;
using Nwuram.Framework.Logging;

namespace NewRemains
{
    public partial class frmMain : Form
    {
        private DataTable tableA;
        frmWait formWait = new frmWait();
        DataTable dtGlobal = new DataTable();
        DataTable dtGlobalInvSpis = new DataTable();
        DataTable dtSpis = new DataTable();
        DateTime ras = new DateTime();
        int rasOtdel = 0;
        int roundRN = 4;
        int roundGlob = 2;
        bool ErrorMsg = false;

        public frmMain()
        {
            InitializeComponent();
        }           

        private void frmMain_Load(object sender, EventArgs e)
        {
            this.MinimumSize = new Size(1032, 767);
            this.Text = "Остатки в закупочных ценах - " + Nwuram.Framework.Settings.User.UserSettings.User.Status + " - " + Nwuram.Framework.Settings.User.UserSettings.User.FullUsername;
            this.toolStripStatusLabel1.Text = ConnectionSettings.GetServer() + " (" + ConnectionSettings.GetDatabase() + ")/" + ConnectionSettings.GetServer("2") + " (" + ConnectionSettings.GetDatabase("2") + ")";
            this.dtpDate.MaxDate = DateTime.Now.Date;
            dgvMain.AutoGenerateColumns = false;
            Config.statusUser = Nwuram.Framework.Settings.User.UserSettings.User.StatusCode;
            Config.isManager = Config.statusUser.ToUpper() == "МН" ? true : false;
            if (Config.statusUser.ToUpper() == "БГЛ")
            {
                dtSpis = readSQL.getTostResult(dtpDate.Value.Date.AddDays(-1),Config.id_otdel);
                if (dtSpis != null && dtSpis.Rows.Count > 0 && int.Parse(dtSpis.Rows[0]["result"].ToString()) > 0)
                {
                    chbOutInvSpis.Visible = true;
                }
                else
                {
                    chbOutInvSpis.Visible = false;
                }

                if (dgvMain.Rows.Count > 0 && Config.id_otdel == 0 && int.Parse(dtSpis.Rows[0]["res"].ToString()) > 0 &&
                         int.Parse(dtSpis.Rows[0]["resDay"].ToString()) == 0 &&
                         int.Parse(dtSpis.Rows[0]["result"].ToString()) > 0 && rasOtdel == 0)
                {
                    btSave2.Enabled = true;
                }
                else
                {
                    btSave2.Enabled = false;
                }
                btSave1.Visible = true;
                btSave2.Visible = true;

            }
            else
            {
                btSave1.Visible = false;
                btSave2.Visible = false;
            }
            
            DataTable dtRoundRN = readSQL.getConfigRN();
            if (dtRoundRN != null && dtRoundRN.Rows.Count > 0)
            {
                if (dtpDate.Value.Date < Convert.ToDateTime(dtRoundRN.Rows[0]["value"].ToString()))
                {
                    roundRN = 2;
                }
                else
                {
                    roundRN = 4;
                }
            }
            DataTable dtConfigNODP = readSQL.getConfigList(2);
            if (dtConfigNODP != null && dtConfigNODP.Rows.Count > 0)
            {
                roundGlob = int.Parse(dtConfigNODP.Rows[0]["val"].ToString());
            }
            if (Config.statusUser.ToUpper() == "БГЛ" || Config.statusUser.ToUpper() == "ПР")
            {
            }
            else
            {
                panEdit.Visible = panSave.Visible = label8.Visible = label9.Visible = false;
            }
            getDeps();
            getTU();
            getInv();
            getUL();
            //dgvMain.DefaultCellStyle.SelectionForeColor = dgvMain.ForeColor;
        }
        
        #region "BW"
        private void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            ErrorMsg = false;
            Console.WriteLine(DateTime.Now.ToShortTimeString());
            DataTable listDep = new DataTable();
            int id_otdel = 0;
            bool ShowingCheck = false;
            cbDeps.Invoke((Action)(() => id_otdel = int.Parse(cbDeps.SelectedValue.ToString())));
            cbDeps.Invoke((Action)(() => listDep =(cbDeps.DataSource as DataTable).Copy() ));
            chbOutInvSpis.Invoke((Action)(() => ShowingCheck = chbOutInvSpis.Visible));
            listDep.Rows.RemoveAt(0);
            if (Config.id_otdel == 0)
            {
                foreach (DataRow row in listDep.Rows)
                //for (int i = 1; i < 50; i++)
                {
                    formWait.Invoke((MethodInvoker)delegate
                    { formWait.TextWait = "Формирую данные: " + row["name"].ToString(); });
                    // Console.WriteLine(readSQL.getMainList(int.Parse(row["id"].ToString())).Rows.Count);
                    if (int.Parse(row["id"].ToString()) == 1)
                    {
                        dtGlobal = readSQL.getMainList(int.Parse(row["id"].ToString()), roundRN,roundGlob).Copy();
                        if (ShowingCheck)
                        {
                            dtGlobalInvSpis = readSQL.getMainListInvSpis(int.Parse(row["id"].ToString()), roundRN, roundGlob).Copy();
                        }
                    }
                    else
                    {
                        dtGlobal.Merge(readSQL.getMainList(int.Parse(row["id"].ToString()), roundRN, roundGlob).Copy());
                        if (ShowingCheck)
                        {
                            dtGlobalInvSpis.Merge(readSQL.getMainListInvSpis(int.Parse(row["id"].ToString()), roundRN, roundGlob).Copy());
                        }
                    }
                    //Thread.Sleep(1000);
                }
            }
            else
            {
                formWait.Invoke((MethodInvoker)delegate
                { formWait.TextWait = "Формирую данные: " + cbDeps.Text.ToString(); });
                dtGlobal = readSQL.getMainList(Config.id_otdel, roundRN, roundGlob).Copy();
                if (ShowingCheck)
                {
                    dtGlobalInvSpis = readSQL.getMainListInvSpis(Config.id_otdel, roundRN, roundGlob).Copy();
                }
            }
            Console.WriteLine(DateTime.Now.ToShortTimeString());
            if (dtGlobal.Rows.Count > 0)
            {
                dgvMain.Invoke((Action)(() => dgvMain.DataSource = dtGlobal));
            }
            else
            {
                ErrorMsg = true;
            }
        }

        private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.TopMost = true;
            if ((e.Cancelled == true))
            {
                this.toolStripProgressBar1.Visible = false;
                this.Enabled = true;
                //block(false);
            }

            else
                if (!(e.Error == null))
                {
                    this.toolStripProgressBar1.Visible = false;
                    this.Enabled = true;
                    //block(false);
                }

                else
                {
                    //block(false);
                    this.toolStripProgressBar1.Visible = false;
                    formWait.Dispose();
                    this.Enabled = true;
                    if (ErrorMsg)
                        MessageBox.Show("Нет данных для расчёта!", "Информирование", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                    {
                        if (roundGlob == 2)
                            zcena.DefaultCellStyle.Format = "N2";
                        else
                            zcena.DefaultCellStyle.Format = "N4";
                        object sumObject;
                        sumObject = (dgvMain.DataSource as DataTable).DefaultView.ToTable().Compute("Sum(zcenaStab)", "id_otdel>-1");
                        tbAllSum.Text = string.Format("{0:#,##0.00}", double.Parse(sumObject.ToString()));
                        //tbAllSum.Text = sumObject.ToString();
                        sumObject = (dgvMain.DataSource as DataTable).DefaultView.ToTable().Compute("Sum(sumZ)", "id_otdel>-1");
                        tbAllSumEdit.Text = string.Format("{0:#,##0.00}", double.Parse(sumObject.ToString()));
                        sumObject = (dgvMain.DataSource as DataTable).DefaultView.ToTable().Compute("Sum(sumR)", "id_otdel>-1");
                        tbSellSum.Text = string.Format("{0:#,##0.00}", double.Parse(sumObject.ToString()));
                        search();
                        btSave1.Enabled = false;
                        if (Config.statusUser.ToUpper() == "БГЛ")
                        {
                            if (dgvMain.Rows.Count > 0 && Config.id_otdel == 0 && int.Parse(dtSpis.Rows[0]["res"].ToString()) > 0 &&
                                int.Parse(dtSpis.Rows[0]["resDay"].ToString()) == 0 &&
                                int.Parse(dtSpis.Rows[0]["result"].ToString()) > 0 && rasOtdel == 0)
                            {
                                btSave2.Enabled = true;
                            }
                            else
                            {
                                btSave2.Enabled = false;
                            }
                        }
                        // .Text = sumObject.ToString();
                    }
                    this.Enabled = true;
                }
            this.TopMost = false;
        }

        #endregion

        private void getDeps()
        {
            DataTable deps = readSQL.getDeps();
            cbDeps.DataSource = deps;
            cbDeps.DisplayMember = "name";
            cbDeps.ValueMember = "id";
            if (Config.statusUser.ToUpper() == "РКВ" || Config.statusUser.ToUpper() == "МН")
            {
                cbDeps.SelectedValue = Nwuram.Framework.Settings.User.UserSettings.User.IdDepartment;
                cbDeps.Enabled = false;
                Config.id_otdel = int.Parse(cbDeps.SelectedValue.ToString());
            }
            if (Config.id_otdel != 0)
            {
                cbTU.Enabled = true;
                cbInv.Enabled = true;
                getTU();
            }
            else
            {
                cbTU.Enabled = false;
                cbInv.Enabled = false;
            }
        }

        private void getTU()
        {            
            DataTable tu = readSQL.getTU();
            cbTU.DataSource = tu;
            cbTU.DisplayMember = "cname";
            cbTU.ValueMember = "id";          
        }

        private void getInv()
        {
            DataTable inv = readSQL.getInv();
            cbInv.DataSource = inv;
            cbInv.DisplayMember = "cname";
            cbInv.ValueMember = "id";
        }

        private void getUL()
        {
            DataTable ul = readSQL.getUL(dtpDate.Value.Date);
            cbUl.DataSource = ul;
            cbUl.DisplayMember = "Abbriviation";
            cbUl.ValueMember = "nTypeOrg";
        }

        private void cbDeps_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Config.id_otdel = int.Parse(cbDeps.SelectedValue.ToString());
            SaveChange();
            if (Config.id_otdel != 0)
            {
                cbTU.Enabled = true;
                cbInv.Enabled = true;
                getTU();
                getInv();
            }
            else
            {
                cbInv.SelectedValue = 0;
                cbTU.SelectedValue = 0;
                cbTU.Enabled = false;
                cbInv.Enabled = false;
            }
            getUL();
            search();
            if (Config.statusUser.ToUpper() == "БГЛ")
            {
                if (dgvMain.Rows.Count > 0 && Config.id_otdel == 0 && int.Parse(dtSpis.Rows[0]["res"].ToString()) > 0 &&
                        int.Parse(dtSpis.Rows[0]["resDay"].ToString()) == 0 &&
                        int.Parse(dtSpis.Rows[0]["result"].ToString()) > 0 && rasOtdel == 0)
                {
                    btSave2.Enabled = true;
                }
                else
                {
                    btSave2.Enabled = false;
                }
            }
        }

        private void cbTU_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //SaveChange();
            cbInv.SelectedValue = 0;
            search();
        }

        private void cbInv_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //SaveChange();            
            cbTU.SelectedValue = 0;
            search();
        }

        private void dtpDate_Leave(object sender, EventArgs e)
        {
            SaveChange();
            if (ras != dtpDate.Value.Date)
            {                
                dtGlobal = null;
                dgvMain.DataSource = null;                
                tbAllSum.Text = "0";
                tbAllSumEdit.Text = "0";
                tbSellSum.Text = "0";
            }
            if (Config.statusUser.ToUpper() == "БГЛ")
            {
                dtSpis = readSQL.getTostResult(dtpDate.Value.Date.AddDays(-1),Config.id_otdel);
                if (dtSpis != null && dtSpis.Rows.Count > 0 && int.Parse(dtSpis.Rows[0]["result"].ToString()) > 0)
                {
                    chbOutInvSpis.Visible = true;
                    tbPSumInv.Visible = tbZSumInv.Visible = chbOutInvSpis.Checked;
                }
                else
                {
                    chbOutInvSpis.Visible = false;
                    tbPSumInv.Visible = tbZSumInv.Visible = false;
                }
            }
            Config.globalDate = dtpDate.Value.Date;
            DataTable dtRoundRN = readSQL.getConfigRN();
            if (dtRoundRN != null && dtRoundRN.Rows.Count > 0)
            {
                if (dtpDate.Value.Date < Convert.ToDateTime(dtRoundRN.Rows[0]["value"].ToString()))
                {
                    roundRN = 2;
                }
                else
                {
                    roundRN = 4;
                }
            }         
            getUL();
            buttonEnable();
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult.No == MessageBox.Show("Вы уверены, что хотите закрыть программу?", "Запрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
                e.Cancel = true;
        }

        private void btGet_Click(object sender, EventArgs e)
        {
            SaveChange();
            //DataTable tableA_1 = (dgvMain.DataSource as DataTable).DefaultView.ToTable();

            //IEnumerable<DataRow> contacts_S = tableA_1.AsEnumerable().Except(tableA.AsEnumerable(),
            //                                        DataRowComparer.Default);
            //if (contacts_S.Count() != 0)
            //{ 
            
            //}
            //if (DialogResult.Yes == MessageBox.Show(Config.centralText("Сохранить данные по\nинветаризацонным\nостаткам?\n"), "Запрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
            //{
            if (bw.IsBusy != true && bwSave1.IsBusy != true)
            {
                this.Enabled = false;
                ras = dtpDate.Value.Date;
                rasOtdel = Config.id_otdel;
                toolStripProgressBar1.Visible = true;
                this.toolStripProgressBar1.Visible = true;
                formWait = new frmWait();
                formWait.Show();
                //block(true);
                bw.RunWorkerAsync();
            }
            //}
        }

        private void btExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void search()
        {
            try
            {
                string GlSearch = "";
                BindingSource bs_npn = new BindingSource();
                bs_npn.DataSource = dgvMain.DataSource;
                if (dtGlobal != null && dtGlobal.Rows.Count > 0 && int.Parse(cbDeps.SelectedValue.ToString()) != 0)
                {
                    string searchString = "";
                    searchString = "id_otdel = " + cbDeps.SelectedValue.ToString();
                    if (int.Parse(cbTU.SelectedValue.ToString()) != 0)
                    {
                        searchString += " and id_grp1 = " + cbTU.SelectedValue.ToString();
                    }
                    if (int.Parse(cbInv.SelectedValue.ToString()) != 0)
                    {
                        searchString += " and id_grp2 = " + cbInv.SelectedValue.ToString();
                    }
                    if (int.Parse(cbUl.SelectedValue.ToString()) != 0)
                    {
                        searchString += " and ul like '%" + cbUl.Text.ToString() + "%'";
                    }
                    if (tbEAN.Text.Length > 0)
                    {
                        searchString += " and ean like '%" + tbEAN.Text.ToString() + "%'";
                    }
                    if (tbName.Text.Length > 0)
                    {
                        searchString += " and nameTovar like '%" + tbName.Text.ToString() + "%'";
                    }
                    bs_npn.Filter = searchString;
                    GlSearch = searchString;
                    //dtGlobal.DefaultView.RowFilter = string.Format(searchString);
                    //dtGlobal = dtGlobal.DefaultView.ToTable(true);
                }
                else
                {
                    if (int.Parse(cbUl.SelectedValue.ToString()) != 0 && dtGlobal != null && dtGlobal.Rows.Count > 0)
                    {
                        string searchString = "";
                        searchString += " ul like '%" + cbUl.Text.ToString() + "%'";
                        if (tbEAN.Text.Length > 0)
                        {
                            searchString += " and ean like '%" + tbEAN.Text.ToString() + "%'";
                        }
                        if (tbName.Text.Length > 0)
                        {
                            searchString += " and nameTovar like '%" + tbName.Text.ToString() + "%'";
                        }
                        bs_npn.Filter = searchString;
                        GlSearch = searchString;
                        //dtGlobal.DefaultView.RowFilter = string.Format(searchString);
                    }
                    else
                    {
                        string searchString = "";                        
                        if (tbEAN.Text.Length > 0)
                        {
                            searchString += "ean like '%" + tbEAN.Text.ToString() + "%'";
                        }
                        if (tbName.Text.Length > 0 && tbEAN.Text.Length > 0)
                        {
                            searchString += " and nameTovar like '%" + tbName.Text.ToString() + "%'";
                        }
                        else
                            if(tbName.Text.Length > 0 && tbEAN.Text.Length == 0)
                            {
                            searchString += "nameTovar like '%" + tbName.Text.ToString() + "%'";
                            }
                        bs_npn.Filter = searchString;
                        GlSearch = searchString;
                        //if (dtGlobal != null && dtGlobal.Rows.Count > 0 && int.Parse(cbDeps.SelectedValue.ToString()) == 0)
                        //    dtGlobal.DefaultView.RowFilter = "";
                    }
                }
                if (dtGlobal != null && dgvMain.Rows.Count > 0)
                {
                    object sumObject;
                    sumObject = (dgvMain.DataSource as DataTable).DefaultView.ToTable().Compute("Sum(zcenaStab)", "id_otdel>-1");
                    tbAllSum.Text = string.Format("{0:#,##0.00}", double.Parse(sumObject.ToString()));
                    //tbAllSum.Text = sumObject.ToString();
                    sumObject = (dgvMain.DataSource as DataTable).DefaultView.ToTable().Compute("Sum(sumZ)", "id_otdel>-1");
                    tbAllSumEdit.Text = string.Format("{0:#,##0.00}", double.Parse(sumObject.ToString()));
                    sumObject = (dgvMain.DataSource as DataTable).DefaultView.ToTable().Compute("Sum(sumR)", "id_otdel>-1");
                    tbSellSum.Text = string.Format("{0:#,##0.00}", double.Parse(sumObject.ToString()));
                    if (dtGlobalInvSpis != null && dtGlobalInvSpis.Rows.Count > 0)
                    {
                        object sumObjectSpis;
                        if (int.Parse(cbDeps.SelectedValue.ToString()) != 0)
                        {
                            sumObjectSpis = dtGlobalInvSpis.Compute("Sum(zcena)", GlSearch);
                            tbPSumInv.Text = string.Format("{0:#,##0.00}", double.Parse(sumObjectSpis.ToString())); //закупка
                            sumObjectSpis = dtGlobalInvSpis.Compute("Sum(rcena)", GlSearch);
                            tbZSumInv.Text = string.Format("{0:#,##0.00}", double.Parse(sumObjectSpis.ToString())); // продажа
                        }
                        else
                        {
                            sumObjectSpis = dtGlobalInvSpis.Compute("Sum(zcena)", GlSearch);
                            tbPSumInv.Text = string.Format("{0:#,##0.00}", double.Parse(sumObjectSpis.ToString())); //закупка
                            sumObjectSpis = dtGlobalInvSpis.Compute("Sum(rcena)", GlSearch);
                            tbZSumInv.Text = string.Format("{0:#,##0.00}", double.Parse(sumObjectSpis.ToString())); // продажа
                        }
                    }
                }
                else
                {
                    tbAllSum.Text = "0";
                    tbAllSumEdit.Text = "0";
                    tbSellSum.Text = "0";
                }
                buttonEnable();
            }
            catch { };
        }

        private void cbUl_SelectionChangeCommitted(object sender, EventArgs e)
        {
            SaveChange();
            search();
        }

        private void btSettings_Click(object sender, EventArgs e)
        {
            frmSettings frmStg = new frmSettings();
            frmStg.ShowDialog();
            DataTable dtConfigNODP = readSQL.getConfigList(2);
            if (dtConfigNODP != null && dtConfigNODP.Rows.Count > 0)
            {
                roundGlob = int.Parse(dtConfigNODP.Rows[0]["val"].ToString());
            }
            if (roundGlob == 2)
                zcena.DefaultCellStyle.Format = "N2";
            else
                zcena.DefaultCellStyle.Format = "N4";
        }

        private void dgvMain_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            Color rowColor = Color.White;
            if (Config.statusUser.ToUpper() == "БГЛ" || Config.statusUser.ToUpper() == "ПР")
            {
                //Color rowColor = Color.White;
                if (Convert.ToInt32(dgvMain.Rows[e.RowIndex].Cells["Sgn"].Value.ToString()) == 1)
                {
                    rowColor = panSave.BackColor;
                }
                if (Convert.ToInt32(dgvMain.Rows[e.RowIndex].Cells["editing"].Value.ToString()) == 1)
                {
                    rowColor = panEdit.BackColor;
                }                
            }
            dgvMain.Rows[e.RowIndex].DefaultCellStyle.BackColor = rowColor;
            if (Config.statusUser.ToUpper() == "БГЛ")
            {
                if (Convert.ToInt32(dgvMain.Rows[e.RowIndex].Cells["Sgn"].Value.ToString()) == 1 ||
                    Convert.ToDouble(dgvMain.Rows[e.RowIndex].Cells["zcenaStab"].Value.ToString()) == 0)
                {
                    dgvMain.Rows[e.RowIndex].Cells["zcena"].ReadOnly = false;
                }
                else
                {
                    dgvMain.Rows[e.RowIndex].Cells["zcena"].ReadOnly = true;
                }
            }
        }

        private void dgvMain_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            if (dgvMain.Rows[e.RowIndex].Selected)
            {
                var row = dgvMain.Rows[e.RowIndex];
                var bgColor = row.DefaultCellStyle.BackColor;
                row.DefaultCellStyle.SelectionBackColor = Color.FromArgb(bgColor.R, bgColor.G, bgColor.B);

                using (Pen pen = new Pen(Color.Firebrick))
                {                  
                    int penWidth =2;
                    pen.Width = penWidth;

                    int x = e.RowBounds.Left + (penWidth / 2);
                    int y = e.RowBounds.Top + (penWidth / 2);
                    int width = e.RowBounds.Width - penWidth;
                    int heigth = e.RowBounds.Height - penWidth;

                    e.Graphics.DrawRectangle(pen, x, y, width, heigth);

                }
            }
        }

        private void dgvMain_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1 && dgvMain.Columns["zcena"].Index == e.ColumnIndex)
            {
                dgvMain.Rows[e.RowIndex].Cells["editing"].Value = 1;
                if (Convert.ToInt32(dgvMain.Rows[e.RowIndex].Cells["Sgn"].Value.ToString()) == 1 ||
                       Convert.ToDouble(dgvMain.Rows[e.RowIndex].Cells["zcenaStab"].Value.ToString()) == 0)
                {
                    dgvMain.Rows[e.RowIndex].Cells["sumZ"].Value = Convert.ToDouble(dgvMain.Rows[e.RowIndex].Cells["zcena"].Value.ToString()) * Convert.ToDouble(dgvMain.Rows[e.RowIndex].Cells["netto"].Value.ToString());
                }            
                Console.WriteLine(dgvMain.Rows[e.RowIndex].Cells["zcena"].Value.ToString());
                Console.WriteLine(dgvMain.Rows[e.RowIndex].Cells["netto"].Value.ToString());

                object sumObject;
                sumObject = (dgvMain.DataSource as DataTable).DefaultView.ToTable().Compute("Sum(zcenaStab)", "id_otdel>-1");
                tbAllSum.Text = string.Format("{0:#,##0.00}", double.Parse(sumObject.ToString()));
                //tbAllSum.Text = sumObject.ToString();
                sumObject = (dgvMain.DataSource as DataTable).DefaultView.ToTable().Compute("Sum(sumZ)", "id_otdel>-1");
                tbAllSumEdit.Text = string.Format("{0:#,##0.00}", double.Parse(sumObject.ToString()));
                sumObject = (dgvMain.DataSource as DataTable).DefaultView.ToTable().Compute("Sum(sumR)", "id_otdel>-1");
                tbSellSum.Text = string.Format("{0:#,##0.00}", double.Parse(sumObject.ToString()));
                        
                //object sumObject;
                //sumObject = (dgvMain.DataSource as DataTable).DefaultView.ToTable().Compute("Sum(zcenaStab)", "id_otdel>-1");
                //tbAllSum.Text = sumObject.ToString();
                //sumObject = (dgvMain.DataSource as DataTable).DefaultView.ToTable().Compute("Sum(sumZ)", "id_otdel>-1");
                //tbAllSumEdit.Text = sumObject.ToString();
                //sumObject = (dgvMain.DataSource as DataTable).DefaultView.ToTable().Compute("Sum(sumR)", "id_otdel>-1");
                //tbSellSum.Text = sumObject.ToString();
                btSave1.Enabled = true;
            }
        }

        private void chbOutInvSpis_MouseClick(object sender, MouseEventArgs e)
        {
            tbPSumInv.Visible=tbZSumInv.Visible = chbOutInvSpis.Checked;
        }

        private void tbEAN_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar)))
            {
                if (e.KeyChar != (char)Keys.Back)
                {
                    e.Handled = true;
                }
            }
        }

        private void tbEAN_TextChanged(object sender, EventArgs e)
        {
            search();
        }

        private void tbName_TextChanged(object sender, EventArgs e)
        {
            search();
        }

        private void buttonEnable()
        {
            if (dtGlobal != null && dgvMain.Rows.Count > 0)
            {
                btPrint.Enabled = true;
                if (Config.id_otdel != 0)
                {
                    btExcel.Enabled = true;
                }
                else
                { btExcel.Enabled = false; }
            }
            else
            {
                btPrint.Enabled = false;
                btExcel.Enabled = false;
            }
            try
            {
                if (Config.statusUser.ToUpper() == "БГЛ")
                {
                    if (dgvMain.Rows.Count > 0 && Config.id_otdel == 0 && int.Parse(dtSpis.Rows[0]["res"].ToString()) > 0 &&
                        int.Parse(dtSpis.Rows[0]["resDay"].ToString()) == 0 &&
                        int.Parse(dtSpis.Rows[0]["result"].ToString()) > 0  && rasOtdel == 0)
                    {
                        btSave2.Enabled = true;
                    }
                    else
                    {
                        btSave2.Enabled = false;
                    }
                }
            }
            catch { };
        }

        #region "Save Inv Spis"       
        private void btSave2_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show(Config.centralText("Сохранить данные по\nинветаризационным\nостаткам?\n"), "Запрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
            {
                if (bwSave.IsBusy != true)
                {                    
                    this.Enabled = false;
                    ras = dtpDate.Value.Date;
                    rasOtdel = Config.id_otdel;
                    toolStripProgressBar1.Visible = true;
                    this.toolStripProgressBar1.Visible = true;
                    formWait = new frmWait();
                    formWait.Show();
                    //block(true);
                    bwSave.RunWorkerAsync();
                }
            }

        }

        private void bwSave_DoWork(object sender, DoWorkEventArgs e)
        {
            DataTable listDep = new DataTable();
            DataTable dtIdInv = new DataTable();
            int id_otdel = 0;
            cbDeps.Invoke((Action)(() => id_otdel = int.Parse(cbDeps.SelectedValue.ToString())));
            cbDeps.Invoke((Action)(() => listDep = (cbDeps.DataSource as DataTable).Copy()));
            listDep.Rows.RemoveAt(0);
            DataRow[] rowSave = dtGlobal.Select();            
            if (id_otdel == 0)
            {
                cbDeps.Invoke((Action)(() => dtIdInv = readSQL.getTostResult(dtpDate.Value.Date.AddDays(-1), 1)));
                readSQL.deleteConfigList(int.Parse(dtIdInv.Rows[0]["idInv"].ToString()), 1);
                cbDeps.Invoke((Action)(() => dtIdInv = readSQL.getTostResult(dtpDate.Value.Date.AddDays(-1), 6)));
                readSQL.deleteConfigList(int.Parse(dtIdInv.Rows[0]["idInv"].ToString()), 6);
                foreach (DataRow row in listDep.Rows)
                //for (int i = 1; i < 50; i++)
                {
                    

                    formWait.Invoke((MethodInvoker)delegate
                    { formWait.TextWait = "Сохраняю данные: " + row["name"].ToString(); });

                    //Logging.StartFirstLevel(177, int.Parse(row["id"].ToString()));                                   
                    Logging.StartFirstLevel(177);                                   
                    Object sumObject_Z = dtGlobal.Compute("Sum(sumZ)", "id_otdel = " + row["id"].ToString());
                    Object sumObject_R = dtGlobal.Compute("Sum(sumR)", "id_otdel = " + row["id"].ToString());                   
                    DateTime dateSave = new DateTime();
                    dtpDate.Invoke((Action)(() => dateSave = dtpDate.Value.Date));

                    Logging.Comment("Начало сохранение рассчитанных остатков, отдел :" + row["name"].ToString());
                    Logging.Comment("Остаток на утро :"+dateSave.ToShortDateString());
                    Logging.Comment("Общая сумма закупки: " + sumObject_Z.ToString());
                    Logging.Comment("Общая сумма продажи: " + sumObject_R.ToString());

                    rowSave = dtGlobal.Select("id_otdel = " + row["id"].ToString());
                    if (rowSave.Count() > 0)
                    {
                        cbDeps.Invoke((Action)(() => dtIdInv = readSQL.getTostResult(dtpDate.Value.Date.AddDays(-1), int.Parse(row["id"].ToString()))));
                        for (int i = 0; i < rowSave.Count(); i++)
                        {
                            //Console.WriteLine(dtIdInv.Rows[0]["idInv"].ToString()+" "+rowSave[i]["id_tovar"].ToString() + " " + rowSave[i]["netto"].ToString() + " " + rowSave[i]["zcena"].ToString() + " " + rowSave[i]["nTypeOrg"].ToString());
                            readSQL.setInvOst(int.Parse(dtIdInv.Rows[0]["idInv"].ToString()), int.Parse(row["id"].ToString()),
                                int.Parse(rowSave[i]["id_tovar"].ToString()), Convert.ToDouble(rowSave[i]["netto"].ToString()), Convert.ToDouble(rowSave[i]["zcena"].ToString()), int.Parse(rowSave[i]["nTypeOrg"].ToString()));
                        }
                    }
                    Logging.Comment("Операцию выполнил пользователь ID: " + Nwuram.Framework.Settings.User.UserSettings.User.Id.ToString());
                    Logging.Comment("Сохранение рассчитанных остатков заверщенно, отдел :" + row["name"].ToString());
                    // Console.WriteLine(readSQL.getMainList(int.Parse(row["id"].ToString())).Rows.Count);                   
                    Thread.Sleep(1000);
                }
            }
        }            

        private void bwSave_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.TopMost = true;
            if ((e.Cancelled == true))
            {
                this.toolStripProgressBar1.Visible = false;
                this.Enabled = true;
                formWait.Dispose();
                //block(false);
            }

            else
                if (!(e.Error == null))
                {
                    this.toolStripProgressBar1.Visible = false;
                    this.Enabled = true;
                    formWait.Dispose();
                    //block(false);
                }

                else
                {
                    //block(false);
                    this.toolStripProgressBar1.Visible = false;
                    formWait.Dispose();
                    this.Enabled = true;
                    MessageBox.Show("Инвентаризационные остатки, сохранены!","Информирование",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
            this.TopMost = false;
        }
        #endregion

        #region "save Price"
        private void btSave1_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show(Config.centralText("Сохранить данные по\nзакупочным ценам?\n"), "Запрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
            {
                if (bwSave1.IsBusy != true)
                {
                    this.Enabled = false;
                    ras = dtpDate.Value.Date;
                    rasOtdel = Config.id_otdel;
                    toolStripProgressBar1.Visible = true;
                    this.toolStripProgressBar1.Visible = true;
                    formWait = new frmWait();
                    formWait.Show();
                    //block(true);
                    bwSave1.RunWorkerAsync();
                }
            }
        }

        private void bwSave1_DoWork(object sender, DoWorkEventArgs e)
        {
            DataTable listDep = new DataTable();
            DataTable dtIdInv = new DataTable();
            DateTime date = new DateTime();
            int id_otdel = 0;
            cbDeps.Invoke((Action)(() => id_otdel = int.Parse(cbDeps.SelectedValue.ToString())));
            cbDeps.Invoke((Action)(() => listDep = (cbDeps.DataSource as DataTable).Copy()));
            dtpDate.Invoke((Action)(() =>date = dtpDate.Value.Date.AddDays(-1)));
            listDep.Rows.RemoveAt(0);
            DataRow[] rowSave = dtGlobal.Select();
            if (id_otdel == 0)
            {
                foreach (DataRow row in listDep.Rows)               
                {
                    formWait.Invoke((MethodInvoker)delegate
                    { formWait.TextWait = "Сохраняю данные: " + row["name"].ToString(); });
                    try
                    {
                        //Logging.StartFirstLevel(176, int.Parse(row["id"].ToString()));
                        Logging.StartFirstLevel(176);
                    }
                    catch 
                    {
                        Logging.StartFirstLevel(176);
                    };
                    Logging.Comment("Сохранение закупочных цен для отдела: "+row["name"].ToString());
                    DateTime dateSave = new DateTime();
                    dtpDate.Invoke((Action)(() => dateSave = dtpDate.Value.Date));                    
                    Logging.Comment("Остаток на утро :" + dateSave.ToShortDateString());

                    rowSave = dtGlobal.Select("id_otdel = " + row["id"].ToString() + " and editing=1");
                    if (rowSave.Count() > 0)
                    {                        
                        for (int i = 0; i < rowSave.Count(); i++)
                        {
                            readSQL.setInvPrice(int.Parse(row["id"].ToString()),
                                int.Parse(rowSave[i]["id_tovar"].ToString()), date, Convert.ToDouble(rowSave[i]["zcena"].ToString()), int.Parse(rowSave[i]["nTypeOrg"].ToString()));
                            Logging.Comment("ID:" + rowSave[i]["id_tovar"].ToString() + " zcena: " + rowSave[i]["zcenaStab"].ToString() + " zcenaNew" + rowSave[i]["zcena"].ToString());
                        }
                    }
                    Logging.Comment("Операцию выполнил пользователь ID: " + Nwuram.Framework.Settings.User.UserSettings.User.Id.ToString());
                    Logging.Comment("Сохранение закупочных цен завершенно, отдел :" + row["name"].ToString());
                                       
                }
            }
            else
            {
                formWait.Invoke((MethodInvoker)delegate
                { formWait.TextWait = "Сохраняю данные: " + cbDeps.Text.ToString(); });
                rowSave = dtGlobal.Select("id_otdel = " + id_otdel.ToString() + " and editing=1");
                if (rowSave.Count() > 0)
                {                    
                    for (int i = 0; i < rowSave.Count(); i++)
                    {                        
                        readSQL.setInvPrice(id_otdel,
                            int.Parse(rowSave[i]["id_tovar"].ToString()), date, Convert.ToDouble(rowSave[i]["zcena"].ToString()), int.Parse(rowSave[i]["nTypeOrg"].ToString()));
                    }
                }                               
            }
        }

        private void bwSave1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.TopMost = true;
            if ((e.Cancelled == true))
            {
                this.toolStripProgressBar1.Visible = false;
                this.Enabled = true;
                //block(false);
            }

            else
                if (!(e.Error == null))
                {
                    this.toolStripProgressBar1.Visible = false;
                    this.Enabled = true;
                    //block(false);
                }

                else
                {
                    //block(false);
                    this.toolStripProgressBar1.Visible = false;
                    this.Enabled = true;
                    formWait.Dispose();
                    btSave1.Enabled = false;
                    MessageBox.Show("Закупочные цены, сохранены!", "Информирование", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //if (bw.IsBusy != true)
                    //{
                    //    this.Enabled = false;
                    //    ras = dtpDate.Value.Date;
                    //    rasOtdel = Config.id_otdel;
                    //    toolStripProgressBar1.Visible = true;
                    //    this.toolStripProgressBar1.Visible = true;
                    //    formWait = new frmWait();
                    //    formWait.Show();
                    //    //block(true);
                    //    bw.RunWorkerAsync();
                    //}
                }
            this.TopMost = false;
        }
        #endregion
        
        private void button1_Click(object sender, EventArgs e)
        {
            if (bwPrint1.IsBusy != true)
            {
                //ras = dtpDate.Value.Date;
                //rasOtdel = Config.id_otdel;
                toolStripProgressBar1.Visible = true;
                this.toolStripProgressBar1.Visible = true;
                formWait = new frmWait();
                formWait.Show();
                //block(true);
                bwPrint1.RunWorkerAsync();
            }              
        }

        private void btExcel_Click(object sender, EventArgs e)
        {
            if (bwPrint2.IsBusy != true)
            {
                this.Enabled = false;
                //ras = dtpDate.Value.Date;
                //rasOtdel = Config.id_otdel;
                toolStripProgressBar1.Visible = true;
                this.toolStripProgressBar1.Visible = true;
                formWait = new frmWait();
                formWait.Show();
                //block(true);
                bwPrint2.RunWorkerAsync();
            }  
            //Nwuram.Framework.ToExcel.HandmadeReport report = new Nwuram.Framework.ToExcel.HandmadeReport();
            //report.AddSingleValue("Остатки на утро ", 1, 1);
            //report.AddSingleValue(dtpDate.Value.Date.ToShortDateString(), 1, 2);
            //report.AddSingleValue(" по отделу "+cbDeps.Text.ToString(), 1, 3);            

            //report.AddSingleValue("Поставщик", 3, 1);
            //report.AddSingleValue("EAN", 3, 2);
            //report.AddSingleValue("Наименование", 3, 3);
            //report.AddSingleValue("Количество", 3, 4);
            //report.AddSingleValue("Цена закуп.", 3, 5);
            //report.AddSingleValue("Цена прод.", 3, 6);
            //report.AddSingleValue("Сумма (закупки)", 3, 7);
            //report.AddSingleValue("Сумма (продажи)", 3, 8);
            //report.SetFontBold(1, 1, 3, 8);

            //double summaNGlob = 0;
            //double summaSGlob = 0;
            //double summaDGlob = 0;
            ////report.AddMultiValue(data, 4, 1);
            //DataTable data = (dgvMain.DataSource as DataTable).DefaultView.ToTable().Copy();
            //int numRow = 4;
            //report.SetFontBold(numRow, 1, numRow, 1);
            //numRow++;
            //string oldName = "";
            //int idOldPost = -1;
            //DataRow[] rowPostName = data.Select("", "id_post asc");
            //foreach (DataRow row in data.Rows)
            //{
            //    //if (oldName != row["cname"].ToString())
            //    if (idOldPost != int.Parse(row["id_post"].ToString()))
            //    {
            //        //if (oldName != "")
            //        if (idOldPost != -1)
            //        {
            //            //rowPostName = data.Select("id_post='" + oldName + "'");
            //            rowPostName = data.Select("id_post='" + idOldPost + "'");
            //            double summaN = 0;
            //            double summaS = 0;
            //            double summaD = 0;
            //            for (int il = 0; il < rowPostName.Length; il++)
            //            {                       
            //                summaN += Convert.ToDouble(rowPostName[il]["netto"].ToString());
            //                summaS += Convert.ToDouble(rowPostName[il]["sumZ"].ToString());
            //                summaD += Convert.ToDouble(rowPostName[il]["sumR"].ToString());
            //            }
            //            summaNGlob += summaN;
            //            summaSGlob += summaS;
            //            summaDGlob += summaD;
            //            report.AddSingleValue("Итог по поставщику", numRow, 3);
            //            report.AddSingleValue(summaN.ToString(), numRow, 4);
            //            report.AddSingleValue(summaS.ToString(), numRow, 7);
            //            report.AddSingleValue(summaD.ToString(), numRow, 8);
            //            report.SetFontBold(numRow, 1, numRow, 10);
            //            report.SetFontColor(numRow, 1, numRow, 10, 3);
            //            numRow++;
            //        }
            //        //oldName = row["cname"].ToString();
            //        idOldPost = int.Parse(row["id_post"].ToString());
            //        report.AddSingleValue(row["cname"].ToString(), numRow, 1);
            //        report.AddSingleValue(row["ean"].ToString(), numRow, 2);
            //        report.AddSingleValue(row["nameTovar"].ToString(), numRow, 3);
            //        report.AddSingleValue(row["netto"].ToString(), numRow, 4);
            //        report.AddSingleValue(row["zcena"].ToString(), numRow, 5);
            //        report.AddSingleValue(row["rcena"].ToString(), numRow, 6);
            //        report.AddSingleValue(row["sumZ"].ToString(), numRow, 7);
            //        report.AddSingleValue(row["sumR"].ToString(), numRow, 8);
            //        numRow++;
            //    }
            //    else
            //    {
            //        report.AddSingleValue(row["cname"].ToString(), numRow, 1);
            //        report.AddSingleValue(row["ean"].ToString(), numRow, 2);
            //        report.AddSingleValue(row["nameTovar"].ToString(), numRow, 3);
            //        report.AddSingleValue(row["netto"].ToString(), numRow, 4);
            //        report.AddSingleValue(row["zcena"].ToString(), numRow, 5);
            //        report.AddSingleValue(row["rcena"].ToString(), numRow, 6);
            //        report.AddSingleValue(row["sumZ"].ToString(), numRow, 7);
            //        report.AddSingleValue(row["sumR"].ToString(), numRow, 8);
            //        numRow++;
            //    }
            //}
            ////rowPostName = data.Select("postname='" + oldName + "'");
            //rowPostName = data.Select("id_post='" + idOldPost + "'");
            //double summaNL = 0;
            //double summaSL = 0;
            //double summaDL = 0;
            //for (int il = 0; il < rowPostName.Length; il++)
            //{
            //    summaNL += Convert.ToDouble(rowPostName[il]["netto"].ToString());
            //    summaSL += Convert.ToDouble(rowPostName[il]["sumZ"].ToString());
            //    summaDL += Convert.ToDouble(rowPostName[il]["sumR"].ToString());                
            //}
            //summaNGlob += summaNL;
            //summaSGlob += summaSL;
            //summaDGlob += summaDL;
            //report.AddSingleValue("Итог по поставщику", numRow, 3);
            //report.AddSingleValue(summaNL.ToString(), numRow, 4);
            //report.AddSingleValue(summaSL.ToString(), numRow, 7);
            //report.AddSingleValue(summaDL.ToString(), numRow, 8);
            //report.SetFontBold(numRow, 1, numRow, 8);
            //report.SetFontColor(numRow, 1, numRow, 8, 3);
            //numRow++;
            //// report.AddMultiValue(dep.DepartmentData, numRow, 1);
            ////numRow += dep.DepartmentData.Rows.Count + 1;
            //numRow++;
            
            ////
            //report.AddSingleValue("Итого:", numRow, 1);
            //report.AddSingleValue(summaNGlob.ToString(), numRow, 4);
            //report.AddSingleValue(summaSGlob.ToString(), numRow, 7);
            //report.AddSingleValue(summaDGlob.ToString(), numRow, 8);
            //report.SetFontBold(numRow, 1, numRow, 8);

            //report.SetFormat(3, 2, numRow, 2, "#############");
            //report.SetColumnWidth(3, 1, numRow, 1, 45);
            //report.SetColumnWidth(3, 2, numRow, 2, 15);
            //report.SetColumnWidth(3, 3, numRow, 3, 20);
            //report.SetColumnWidth(3, 4, numRow, 7, 15);
            //report.SetColumnWidth(3, 8, numRow, 8, 20);
            //report.SetCellAlignmentToLeft(3, 1, numRow, 1);
            //report.SetCellAlignmentToRight(3, 4, numRow, 6);
            //report.SetCellAlignmentToRight(3, 7, numRow, 7);
            //report.SetCellAlignmentToJustify(3, 3, numRow, 3);
            //report.Show();
        }


        #region "Print"
        private void btPrint_Click(object sender, EventArgs e)
        {
            if (bwPrint1.IsBusy != true)
            {
                this.Enabled = false;
                //ras = dtpDate.Value.Date;
                //rasOtdel = Config.id_otdel;
                toolStripProgressBar1.Visible = true;
                this.toolStripProgressBar1.Visible = true;
                formWait = new frmWait();
                formWait.Show();
                //block(true);
                bwPrint1.RunWorkerAsync();
            }   
            //DataTable data = (dgvMain.DataSource as DataTable).DefaultView.ToTable().Copy();
            //Nwuram.Framework.ToExcel.HandmadeReport report = new Nwuram.Framework.ToExcel.HandmadeReport();
            //report.AddSingleValue("Отдел", 1, 1);
            //report.AddSingleValue("Поставщик", 1, 2);
            //report.AddSingleValue("Сумма (закупки)", 1, 3);
            //report.AddSingleValue("Сумма (продажи)", 1, 4);

            //if (Config.id_otdel == 0)
            //{
            //    int numRow = 2;                                
            //    DataTable listDep = (cbDeps.DataSource as DataTable).Copy();
            //    listDep.Rows.RemoveAt(0);
            //    foreach (DataRow rowDep in listDep.Rows)
            //    {                    
            //        string oldName = "";
            //        int idOldPost = -1;
            //        DataRow[] rowPostName = data.Select("id_otdel = "+rowDep["id"].ToString(), "id_post asc");
            //        report.AddSingleValue(rowDep["name"].ToString(), numRow, 1);
            //        foreach (DataRow row in data.Select("id_otdel = " + rowDep["id"].ToString()))
            //        {
            //            if (row["id_post"].ToString().Length > 0)
            //            {
            //                if (idOldPost != int.Parse(row["id_post"].ToString()))
            //                {
            //                    if (idOldPost != -1)
            //                    {
            //                        rowPostName = data.Select("id_otdel = " + rowDep["id"].ToString() + " and id_post='" + idOldPost + "'");
            //                        double summaN = 0;
            //                        double summaS = 0;
            //                        double summaD = 0;
            //                        for (int il = 0; il < rowPostName.Length; il++)
            //                        {
            //                            try
            //                            {
            //                                summaN += Convert.ToDouble(rowPostName[il]["netto"].ToString());
            //                                summaS += Convert.ToDouble(rowPostName[il]["sumZ"].ToString());
            //                                summaD += Convert.ToDouble(rowPostName[il]["sumR"].ToString());
            //                            }
            //                            catch { };
            //                        }


            //                    }
            //                    idOldPost = int.Parse(row["id_post"].ToString());
            //                    numRow++;
            //                }
            //            }
            //        }
            //    }
            //}
            //else
            //{
            //    string oldName = "";
            //    int idOldPost = -1;
            //    int numRow = 2;   
            //    DataRow[] rowPostName = data.Select("id_otdel = " + Config.id_otdel.ToString(), "id_post asc");
            //    report.AddSingleValue(cbDeps.Text.ToString(), numRow, 1);
            //    foreach (DataRow row in data.Rows)
            //    {
            //        if (idOldPost != int.Parse(row["id_post"].ToString()))
            //        {
            //            if (idOldPost != -1)
            //            {
            //                rowPostName = data.Select("id_otdel = " + Config.id_otdel.ToString()+" and id_post='" + idOldPost + "'");
            //                double summaN = 0;
            //                double summaS = 0;
            //                double summaD = 0;
            //                for (int il = 0; il < rowPostName.Length; il++)
            //                {
            //                    try
            //                    {
            //                        summaN += Convert.ToDouble(rowPostName[il]["netto"].ToString());
            //                        summaS += Convert.ToDouble(rowPostName[il]["sumZ"].ToString());
            //                        summaD += Convert.ToDouble(rowPostName[il]["sumR"].ToString());
            //                    }
            //                    catch { };
            //                }
            //                report.AddSingleValue(row["cname"].ToString(), numRow, 2);
            //                report.AddSingleValue(summaS.ToString(), numRow, 3);
            //                report.AddSingleValue(summaD.ToString(), numRow, 4);
            //            }
            //            idOldPost = int.Parse(row["id_post"].ToString());
            //            numRow++;
            //        }
            //    }
            //    numRow++;
            //    rowPostName = data.Select("id_post='" + idOldPost + "'");
            //    double summaNL = 0;
            //    double summaSL = 0;
            //    double summaDL = 0;
            //    for (int il = 0; il < rowPostName.Length; il++)
            //    {
            //        summaNL += Convert.ToDouble(rowPostName[il]["netto"].ToString());
            //        summaSL += Convert.ToDouble(rowPostName[il]["sumZ"].ToString());
            //        summaDL += Convert.ToDouble(rowPostName[il]["sumR"].ToString());
            //    }
            //    report.AddSingleValue(rowPostName[0]["cname"].ToString(), numRow, 2);
            //    report.AddSingleValue(summaSL.ToString(), numRow, 3);
            //    report.AddSingleValue(summaDL.ToString(), numRow, 4);
            //}
            //report.Show();
        }
        
        Nwuram.Framework.ToExcel.HandmadeReport report;
        private void bwPrint1_DoWork(object sender, DoWorkEventArgs e)
        {
            formWait.Invoke((MethodInvoker)delegate
            { formWait.TextWait = "Выгрузка в Excel, ждите..."; });
            
            int id_otdel = 0;
            cbDeps.Invoke((Action)(() => id_otdel = int.Parse(cbDeps.SelectedValue.ToString())));
            
            DataTable listDep = new DataTable();                        
            cbDeps.Invoke((Action)(() => listDep = (cbDeps.DataSource as DataTable).Copy()));
            
            DataTable data = new DataTable();            
            dgvMain.Invoke((Action)(() => data = (dgvMain.DataSource as DataTable).DefaultView.ToTable().Copy()));                       
            DataRow[] rows = data.Select("cname is not null and id_Post is not null and sumR is not null and sumZ is not null");

            var hireQuery2 = from c in rows.AsEnumerable()
                             //where c.Field<string>("cname").
                             //group c by c.Field<int>("id_post") into grp
                             group c by new
                             {
                                 cname = c.Field<string>("cname"),
                                 id_Post = c.Field<int>("id_post"),
                                 id_otdel = c.Field<int>("id_otdel")
                                 //sumZ = c.Field<decimal>("sumZ"),
                                 //sumR = c.Field<decimal>("sumR")
                             } into g
                             orderby g.Key.id_otdel, g.Key.cname, g.Key.id_Post
                             select new
                             {
                                 cname = g.Key.cname,
                                 id_Post = g.Key.id_Post,
                                 id_otdel = g.Key.id_otdel,
                                 sumZ = g.Sum(x => x.Field<decimal>("sumZ")),
                                 sumR = g.Sum(x => x.Field<decimal>("sumR"))
                             };
            //orderby c.Field<string>("id_post") ascending
            //select new
            //{
            //    Name = grp.("cname")
            //}).Distinct();
            report = new Nwuram.Framework.ToExcel.HandmadeReport();
            report.AddSingleValue("Отдел", 1, 1);
            report.AddSingleValue("Поставщик", 1, 2);
            report.AddSingleValue("Сумма (закупки)", 1, 3);
            report.AddSingleValue("Сумма (продажи)", 1, 4);
            report.SetCellAlignmentToCenter(1, 1, 1, 4);
            report.SetFontBold(1, 1, 1, 4);

            int numRow = 2;
            int startRow =2;            
            int id_dep = 1;
            if (id_otdel != 0)
            { id_dep = id_otdel; }
            foreach (var t in hireQuery2)
            {
                //Console.WriteLine(t.id_otdel + " " + t.cname + " " + t.sumR + " " + t.id_Post);                             
                if (id_dep != t.id_otdel)
                {
                    report.AddSingleValue(listDep.Select("id = " + id_dep.ToString())[0]["name"].ToString(), startRow, 1);
                    id_dep = t.id_otdel;
                    report.Merge(startRow, 1, numRow, 1);
                    report.SetCellAlignmentToJustify(startRow, 1, numRow, 1);
                    report.SetCellAlignmentToCenter(startRow, 1, numRow, 1);
                    startRow = numRow + 1;
                }
                report.AddSingleValue(t.cname, numRow, 2);
                report.AddSingleValue(t.sumZ.ToString(), numRow, 3);
                report.AddSingleValue(t.sumR.ToString(), numRow, 4);   
                numRow++;
            }
            report.AddSingleValue(listDep.Select("id = " + id_dep.ToString())[0]["name"].ToString(), startRow, 1);
            report.Merge(startRow, 1, numRow-1, 1);
            report.SetCellAlignmentToJustify(startRow, 1, numRow-1, 1);
            report.SetCellAlignmentToCenter(startRow, 1, numRow-1, 1);
            report.SetColumnAutoSize(1, 1, numRow-1, 4);
            report.SetBorders(1, 1, numRow-1, 4);
            report.SetFontBold(1, 1, numRow-1, 1);
        }

        private void bwPrint1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.TopMost = true;
            if ((e.Cancelled == true))
            {
                this.toolStripProgressBar1.Visible = false;
                this.Enabled = true;
                //block(false);
            }

            else
                if (!(e.Error == null))
                {
                    this.toolStripProgressBar1.Visible = false;
                    this.Enabled = true;
                    //block(false);
                }

                else
                {
                    //block(false);
                    this.toolStripProgressBar1.Visible = false;
                    this.Enabled = true;
                    report.Show();
                    formWait.Dispose();
                }
            this.TopMost = false;
        }
        #endregion

        private void SaveChange()
        {
            if (btSave1.Enabled)
            {
                if (DialogResult.Yes == MessageBox.Show(Config.centralText("Сохранить откорректированные данные?\n"), "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
                {
                    //btSave1_Click(null, null);
                    if (bwSave1.IsBusy != true)
                    {
                        this.Enabled = false;
                        ras = dtpDate.Value.Date;
                        rasOtdel = Config.id_otdel;
                        toolStripProgressBar1.Visible = true;
                        this.toolStripProgressBar1.Visible = true;
                        formWait = new frmWait();
                        formWait.Show();
                        //block(true);
                        bwSave1.RunWorkerAsync();
                    }
                }
            }
        }



        private void bwPrint2_DoWork(object sender, DoWorkEventArgs e)
        {

            formWait.Invoke((MethodInvoker)delegate
            { formWait.TextWait = "Выгрузка в Excel, ждите..."; });

            int id_otdel = 0;
            string NameDep="";
            string RepDate = "";
            cbDeps.Invoke((Action)(() => id_otdel = int.Parse(cbDeps.SelectedValue.ToString())));
            cbDeps.Invoke((Action)(() => NameDep = cbDeps.Text.ToString()));
            dtpDate.Invoke((Action)(() => RepDate = dtpDate.Value.Date.ToShortDateString()));

            DataTable listDep = new DataTable();
            cbDeps.Invoke((Action)(() => listDep = (cbDeps.DataSource as DataTable).Copy()));

            DataTable data = new DataTable();
            dgvMain.Invoke((Action)(() => data = (dgvMain.DataSource as DataTable).DefaultView.ToTable().Copy()));
            DataRow[] rows = data.Select("cname is not null and id_Post is not null and sumR is not null and sumZ is not null");

            var hireQuery2 = from c in rows.AsEnumerable()
                             //where c.Field<string>("cname").
                             //group c by c.Field<int>("id_post") into grp
                             group c by new
                             {                                
                                 id_Post = c.Field<int>("id_post")                              
                             } into g
                             orderby g.Key.id_Post
                             select new
                             {                                
                                 id_Post = g.Key.id_Post,
                                 sumТ = g.Sum(x => x.Field<decimal>("netto")),
                                 sumZ = g.Sum(x => x.Field<decimal>("sumZ")),
                                 sumR = g.Sum(x => x.Field<decimal>("sumR"))
                             };
            //orderby c.Field<string>("id_post") ascending
            //select new
            //{
            //    Name = grp.("cname")
            //}).Distinct();
            report = new Nwuram.Framework.ToExcel.HandmadeReport();
            report.AddSingleValue("Остатки на утро " +RepDate+" по отделу " + NameDep, 1, 1);

            report.Merge(1, 1, 1, 3);

            report.AddSingleValue("Поставщик", 3, 1);
            report.AddSingleValue("EAN", 3, 2);
            report.AddSingleValue("Наименование", 3, 3);
            report.AddSingleValue("Количество", 3, 4);
            report.AddSingleValue("Цена закуп.", 3, 5);
            report.AddSingleValue("Цена прод.", 3, 6);
            report.AddSingleValue("Сумма (закупки)", 3, 7);
            report.AddSingleValue("Сумма (продажи)", 3, 8);
            report.SetFontBold(1, 1, 3, 8);

            int numRow = 4;
            int startRow = 4;
            int id_dep = 1;


            if (id_otdel != 0)
            { id_dep = id_otdel; }
            foreach (var t in hireQuery2)
            {
                DataRow[] rowsFind = data.Select("id_Post = " + t.id_Post.ToString(), "ean asc");
                for (int i = 0; i < rowsFind.Count(); i++)
                {
                    report.AddSingleValue(rowsFind[i]["cname"].ToString(), numRow, 1);
                    report.AddSingleValue(rowsFind[i]["ean"].ToString(), numRow, 2);
                    report.AddSingleValue(rowsFind[i]["nameTovar"].ToString(), numRow, 3);
                    report.AddSingleValue(rowsFind[i]["netto"].ToString(), numRow, 4);
                    report.AddSingleValue(rowsFind[i]["zcena"].ToString(), numRow, 5);
                    report.AddSingleValue(rowsFind[i]["rcena"].ToString(), numRow, 6);
                    report.AddSingleValue(rowsFind[i]["sumZ"].ToString(), numRow, 7);
                    report.AddSingleValue(rowsFind[i]["sumR"].ToString(), numRow, 8);
                    numRow++;
                }
                report.Merge(numRow, 1, numRow, 3);
                report.SetFontBold(numRow, 1, numRow , 8);
                report.AddSingleValue("Итого по поставщику:", numRow, 1);
                report.AddSingleValue(t.sumТ.ToString(), numRow, 4);
                report.AddSingleValue(t.sumZ.ToString(), numRow, 7);
                report.AddSingleValue(t.sumR.ToString(), numRow, 8);
                numRow++;
            }
            rows = data.Select("id_Post is null");
            for (int i = 0; i < rows.Count(); i++)
            {
                report.AddSingleValue(rows[i]["cname"].ToString(), numRow, 1);
                report.AddSingleValue(rows[i]["ean"].ToString(), numRow, 2);
                report.AddSingleValue(rows[i]["nameTovar"].ToString(), numRow, 3);
                report.AddSingleValue(rows[i]["netto"].ToString(), numRow, 4);
                report.AddSingleValue(rows[i]["zcena"].ToString(), numRow, 5);
                report.AddSingleValue(rows[i]["rcena"].ToString(), numRow, 6);
                report.AddSingleValue(rows[i]["sumZ"].ToString(), numRow, 7);
                report.AddSingleValue(rows[i]["sumR"].ToString(), numRow, 8);
                numRow++;
            }
            if (rows.Count() > 0)
            {
                report.Merge(numRow, 1, numRow, 3);
                report.SetFontBold(numRow, 1, numRow, 8);
                report.AddSingleValue("Итого по поставщику:", numRow, 1);
                object sumObject;
                sumObject = (dgvMain.DataSource as DataTable).DefaultView.ToTable().Compute("Sum(netto)", "id_Post is null");
                report.AddSingleValue(sumObject.ToString(), numRow, 4);
                sumObject = (dgvMain.DataSource as DataTable).DefaultView.ToTable().Compute("Sum(sumZ)", "id_Post is null");
                report.AddSingleValue(sumObject.ToString(), numRow, 7);
                sumObject = (dgvMain.DataSource as DataTable).DefaultView.ToTable().Compute("Sum(sumR)", "id_Post is null");
                report.AddSingleValue(sumObject.ToString(), numRow, 8);
                numRow++;
            }
            numRow++;
            report.Merge(numRow, 1, numRow, 3);
            report.SetFontBold(numRow, 1, numRow, 8);
            report.AddSingleValue("Итого по отделу:", numRow, 1);
            object sumObject1;
            sumObject1 = (dgvMain.DataSource as DataTable).DefaultView.ToTable().Compute("Sum(netto)", "");
            report.AddSingleValue(sumObject1.ToString(), numRow, 4);
            sumObject1 = (dgvMain.DataSource as DataTable).DefaultView.ToTable().Compute("Sum(sumZ)", "");
            report.AddSingleValue(sumObject1.ToString(), numRow, 7);
            sumObject1 = (dgvMain.DataSource as DataTable).DefaultView.ToTable().Compute("Sum(sumR)", "");
            report.AddSingleValue(sumObject1.ToString(), numRow, 8);
            numRow++;
            report.SetFormat(3, 2, numRow, 2, "#############");
            report.SetColumnAutoSize(1, 1, numRow - 1, 8);
            report.SetBorders(1, 1, numRow - 1, 8);
            //report.SetFontBold(1, 1, numRow - 1, 1);


        }          

        private void bwPrint2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.TopMost = true;
            if ((e.Cancelled == true))
            {
                this.toolStripProgressBar1.Visible = false;
                this.Enabled = true;
                //block(false);
            }

            else
                if (!(e.Error == null))
                {
                    this.toolStripProgressBar1.Visible = false;
                    this.Enabled = true;
                    //block(false);
                }

                else
                {
                    //block(false);
                    this.toolStripProgressBar1.Visible = false;
                    this.Enabled = true;
                    report.Show();
                    formWait.Dispose();
                }
            this.TopMost = false;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (bwPrint2.IsBusy != true)
            {
                //ras = dtpDate.Value.Date;
                //rasOtdel = Config.id_otdel;
                toolStripProgressBar1.Visible = true;
                this.toolStripProgressBar1.Visible = true;
                formWait = new frmWait();
                formWait.Show();
                //block(true);
                bwPrint2.RunWorkerAsync();
            }   
        }

        private void dgvMain_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (e.Exception != null )
                //&& e.Context == DataGridViewDataErrorContexts.Formatting)
            {
                MessageBox.Show("Неверный формат данных.");
            }
        }
    }

}
