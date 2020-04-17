using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Nwuram.Framework.Logging;

namespace NewRemains
{
    public partial class frmSettings : Form
    {
        private int index_block;
        DataTable dtListAll;
        DataTable dtSave = new DataTable();

        public frmSettings()
        {
            InitializeComponent();
        }

        private void btExit_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            Close();
        }       

        private void btAdd_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow r in dgvAll.SelectedRows)
            {
                int index = dgvSave.Rows.Add(r.Clone() as DataGridViewRow);
                foreach (DataGridViewCell o in r.Cells)
                {
                    if (Convert.ToString(o.Value) != "")
                    {
                        dgvSave.Rows[index].Cells[o.ColumnIndex].Value = o.Value;
                        //MessageBox.Show(Convert.ToString(o.Value));
                    }
                    else
                    {
                        dgvSave.Rows[index].Cells[o.ColumnIndex].Value = Convert.ToString(o.Value);
                    }
                }
            }
            block_button(index_block);            
        }

        private void block_button(int id)
        {

            foreach (DataGridViewRow r in dgvSave.Rows)
            {
                if (id == Convert.ToInt32(r.Cells[0].Value))
                {
                    btAdd.Enabled = false;
                    break;
                }
            }

            if (dgvSave.Rows.Count > 0)
            {
                btDelete.Enabled = true;
               // btSave.Enabled = true;
            }
            else
            {
                btDelete.Enabled = false;
               // btSave.Enabled = false;  
            }
        }

        private void dgvAll_SelectionChanged(object sender, EventArgs e)
        {
            btAdd.Enabled = true;
            foreach (DataGridViewRow r in dgvAll.SelectedRows)
            {
                index_block = Convert.ToInt32(r.Cells[0].Value);
                block_button(index_block);
                //MessageBox.Show(index_block.ToString());
            }
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow r in dgvSave.SelectedRows)
            {
                int index = r.Index;
                dgvSave.Rows.RemoveAt(index);
            }
            block_button(index_block);           
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            Logging.StartFirstLevel(93);
            Logging.Comment("Сохранение настроек");
            //rbFour
            //rbDouble
            //chbGroupe
            if (rbDouble.Checked)
            {
                readSQL.setConfigList(2,2);
                Logging.Comment("Количества знаков после запятой: 2");
            }
            if(rbFour.Checked)
            {
                readSQL.setConfigList(2,4);
                Logging.Comment("Количества знаков после запятой: 4");
            }
            if (chbGroupe.Checked)
            {
                readSQL.setConfigList(3, 1);
                Logging.Comment("Признак суммирования: Да");
            }
            else
            {
                readSQL.setConfigList(3, 0);
                Logging.Comment("Признак суммирования: Нет");
            }
            readSQL.deleteConfigList();
            foreach (DataGridViewRow row in dgvSave.Rows )
            {
                Console.WriteLine(row.Cells["id1"].Value.ToString());
                readSQL.setConfigList(1, Convert.ToInt32(row.Cells["id1"].Value.ToString()));
                Logging.Comment("ИНН: " + row.Cells["inn1"].Value.ToString() + " Наименование: " + row.Cells["cname1"].Value.ToString() +
                    " ID: " + row.Cells["id1"].Value.ToString() + " Тип: " + row.Cells["cNameLdeyst1"].Value.ToString());
            }           
            //rbFour
            //rbDouble
            //chbGroupe

            //cNameLdeyst1
            //id1
            //cname1
            //inn1
            Logging.Comment("Операцию выполнил пользователь ID: " + Nwuram.Framework.Settings.User.UserSettings.User.Id.ToString());
            Logging.StopFirstLevel();
            MessageBox.Show("Изменения данных сохранены!","Информирование",MessageBoxButtons.OK,MessageBoxIcon.Information);
            this.DialogResult = DialogResult.OK;
            Close();
        }

        private string getSendString()
        {
            string sendString = "";
            if (!chbAll.Checked)
            {
                sendString += "sp.ldeystv=1 and ";
            }
            if (rbFirst.Checked)
            {
                sendString += "(sp.ltype in(1,3))";
            }
            if (rbSecond.Checked)
            {
                sendString += "(sp.ltype = 2)";
            }
            return sendString;

        }

        private void frmSettings_Load(object sender, EventArgs e)
        {           
            getNewData();

            DataTable dtInnList = readSQL.GetInnList(" ltype in (1,2,3) ");
            DataTable dtConfigList = readSQL.getConfigList(1);
            DataTable dtConfigNODP = readSQL.getConfigList(2);
            DataTable dtConfigPSUM = readSQL.getConfigList(3);

            foreach (DataRow s in dtConfigList.Rows)
            {
                BindingSource bs = new BindingSource();
                bs.DataSource = dtInnList;
                bs.Filter = "id = " + s["val"] + "";
                DataTable dtTmp = ((DataTable)bs.DataSource).DefaultView.ToTable();
                DataRow[] rows = dtTmp.Select();
                if (rows.Count() > 0)
                {
                    int index =
                        dgvSave.Rows.Add(((DataGridViewRow)dgvAll.Rows[0]).Clone() as DataGridViewRow);

                    dgvSave.Rows[index].Cells["id1"].Value = rows[0]["id"];
                    dgvSave.Rows[index].Cells["cname1"].Value = rows[0]["cname"];
                    if (Convert.ToString(rows[0]["inn"]) != "")
                    {
                        dgvSave.Rows[index].Cells["inn1"].Value = rows[0]["inn"];
                    }
                    else
                    {
                        dgvSave.Rows[index].Cells["inn1"].Value = Convert.ToString(rows[0]["inn"]);
                    }
                    dgvSave.Rows[index].Cells["cNameLdeyst1"].Value = rows[0]["cNameLdeyst"];
                    dgvSave.Rows[index].Cells["ltype1"].Value = rows[0]["ltype"];
                    dgvSave.Rows[index].Cells["color1"].Value = rows[0]["color"];
                    //dgvSave.Rows[index].Cells[4].Value = s[1];
                    //grd1_to.Add(rows[0][0]);
                    //com1_to.Add(s[1]);
                }
            }
            dgvSave.Sort(this.cname1, ListSortDirection.Ascending);

            if (dtConfigNODP != null && dtConfigNODP.Rows.Count > 0)
            {
                if (int.Parse(dtConfigNODP.Rows[0]["val"].ToString()) == 2)
                {
                    rbDouble.Checked = true;
                }
                else
                {
                    rbFour.Checked = true;
                }
            }
            if (dtConfigPSUM != null && dtConfigPSUM.Rows.Count > 0)
            {
                if (int.Parse(dtConfigPSUM.Rows[0]["val"].ToString()) == 1)
                {
                    chbGroupe.Checked = true;
                }
                else
                {
                    chbGroupe.Checked = false;
                }
            }

            if (dgvSave.Rows.Count > 0)
            {
                btDelete.Enabled = true;
               // btSave.Enabled = true;
            }
            else
            {
                btDelete.Enabled = false;
                //btSave.Enabled = false;
            }
        }

        private void getNewData()
        {            
            //запрос к бд на получение данных            
            dtListAll = readSQL.GetInnList(getSendString());
            dgvAll.DataSource = dtListAll;
            dgvAll.ClearSelection();
            tbName_TextChanged(null, null);
            //dtSave = dtListAll.Clone();
            //dgvSave.DataSource = dtSave;            
        }

        private void rbFirst_MouseClick(object sender, MouseEventArgs e)
        {
            getNewData();
        }

        private void dgvAll_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            Color rowColor = Color.White;
            if (dgvAll.Rows[e.RowIndex].Cells["color"].Value.ToString().ToLower() == "false")
            {
                rowColor = panel1.BackColor;
            }
            dgvAll.Rows[e.RowIndex].DefaultCellStyle.BackColor = rowColor;
        }

        private void dgvSave_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            Color rowColor = Color.White;
            if (dgvSave.Rows[e.RowIndex].Cells["color1"].Value.ToString().ToLower() == "false")
            {
                rowColor = panel1.BackColor;
            }
            dgvSave.Rows[e.RowIndex].DefaultCellStyle.BackColor = rowColor;
        }

        private void tbName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                BindingSource bs_npn = new BindingSource();
                bs_npn.DataSource = dgvAll.DataSource;
                string Find_npn = "";

                string strFIO = tbName.Text;
                strFIO = strFIO.Replace("%", "[%]");
                strFIO = strFIO.Replace("*", "[*]");
                if (tbName.Text.Length > 0)
                {
                    //Find_npn += "cname like '%" + strFIO + "%'";
                    Find_npn = "cname like '%" + strFIO + "%' or inn like  '%" + strFIO + "%'";
                }
                else
                {
                    Find_npn = "";
                }
                bs_npn.Filter = Find_npn;
                bs_npn.Sort = ("cname ASC");
                if (dgvAll.Rows.Count > 0)
                {
                    btAdd.Enabled = true;                    
                    //btCancel.Enabled = true;
                }
                else
                {
                    btAdd.Enabled = false;                    
                    //btCancel.Enabled = false;
                }
            }
            catch { };
        }

        private void dgvAll_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            if (e.RowIndex != -1)
            {
                if (btAdd.Enabled)
                {
                    foreach (DataGridViewRow r in dgvAll.SelectedRows)
                    {
                        int index = dgvSave.Rows.Add(r.Clone() as DataGridViewRow);
                        foreach (DataGridViewCell o in r.Cells)
                        {
                            if (Convert.ToString(o.Value) != "")
                            {
                                dgvSave.Rows[index].Cells[o.ColumnIndex].Value = o.Value;
                                //MessageBox.Show(Convert.ToString(o.Value));
                            }
                            else
                            {
                                dgvSave.Rows[index].Cells[o.ColumnIndex].Value = Convert.ToString(o.Value);
                            }
                        }
                    }
                    block_button(index_block);
                }
            }
        }

        private void dgvSave_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                foreach (DataGridViewRow r in dgvSave.SelectedRows)
                {
                    int index = r.Index;
                    dgvSave.Rows.RemoveAt(index);
                }
                block_button(index_block);
            }
        }

        private void frmSettings_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult != DialogResult.OK)
            {
                if (DialogResult.No == MessageBox.Show("Закрыть форму, без сохранения данных?","Запрос",MessageBoxButtons.YesNo,MessageBoxIcon.Question,MessageBoxDefaultButton.Button2))
                {
                    e.Cancel = true;
                }
            }
        }
    }
}
