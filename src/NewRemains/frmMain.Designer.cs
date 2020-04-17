namespace NewRemains
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.btExit = new System.Windows.Forms.Button();
            this.cbDeps = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbTU = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbInv = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbUl = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tbEAN = new System.Windows.Forms.TextBox();
            this.tbName = new System.Windows.Forms.TextBox();
            this.dgvMain = new System.Windows.Forms.DataGridView();
            this.cname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ul = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ean = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameTovar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.netto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.zcena = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rcena = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sumZ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sumR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id_otdel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id_tovar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sgn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id_grp1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id_grp2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.zcenaStab = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.editing = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id_post = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nTypeOrg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btPrint = new System.Windows.Forms.Button();
            this.btExcel = new System.Windows.Forms.Button();
            this.btGet = new System.Windows.Forms.Button();
            this.btSave1 = new System.Windows.Forms.Button();
            this.btSave2 = new System.Windows.Forms.Button();
            this.btSettings = new System.Windows.Forms.Button();
            this.tbSellSum = new System.Windows.Forms.TextBox();
            this.tbAllSumEdit = new System.Windows.Forms.TextBox();
            this.tbAllSum = new System.Windows.Forms.TextBox();
            this.tbZSumInv = new System.Windows.Forms.TextBox();
            this.tbPSumInv = new System.Windows.Forms.TextBox();
            this.chbOutInvSpis = new System.Windows.Forms.CheckBox();
            this.panEdit = new System.Windows.Forms.Panel();
            this.panSave = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.bw = new System.ComponentModel.BackgroundWorker();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.bwSave = new System.ComponentModel.BackgroundWorker();
            this.bwSave1 = new System.ComponentModel.BackgroundWorker();
            this.bwPrint1 = new System.ComponentModel.BackgroundWorker();
            this.bwPrint2 = new System.ComponentModel.BackgroundWorker();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripProgressBar1});
            this.statusStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.statusStrip1.Location = new System.Drawing.Point(0, 711);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1024, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(118, 17);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(100, 16);
            this.toolStripProgressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.toolStripProgressBar1.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 26);
            this.label1.TabIndex = 1;
            this.label1.Text = "Остаток\r\nна утро";
            // 
            // dtpDate
            // 
            this.dtpDate.Location = new System.Drawing.Point(62, 13);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(129, 20);
            this.dtpDate.TabIndex = 2;
            this.dtpDate.Leave += new System.EventHandler(this.dtpDate_Leave);
            // 
            // btExit
            // 
            this.btExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btExit.Image = ((System.Drawing.Image)(resources.GetObject("btExit.Image")));
            this.btExit.Location = new System.Drawing.Point(980, 676);
            this.btExit.Name = "btExit";
            this.btExit.Size = new System.Drawing.Size(32, 32);
            this.btExit.TabIndex = 3;
            this.toolTip1.SetToolTip(this.btExit, "Выход");
            this.btExit.UseVisualStyleBackColor = true;
            this.btExit.Click += new System.EventHandler(this.btExit_Click);
            // 
            // cbDeps
            // 
            this.cbDeps.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDeps.FormattingEnabled = true;
            this.cbDeps.Location = new System.Drawing.Point(242, 13);
            this.cbDeps.Name = "cbDeps";
            this.cbDeps.Size = new System.Drawing.Size(161, 21);
            this.cbDeps.TabIndex = 4;
            this.cbDeps.SelectionChangeCommitted += new System.EventHandler(this.cbDeps_SelectionChangeCommitted);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(198, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Отдел";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(409, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "ТУ группа";
            // 
            // cbTU
            // 
            this.cbTU.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTU.FormattingEnabled = true;
            this.cbTU.Location = new System.Drawing.Point(471, 13);
            this.cbTU.Name = "cbTU";
            this.cbTU.Size = new System.Drawing.Size(121, 21);
            this.cbTU.TabIndex = 4;
            this.cbTU.SelectionChangeCommitted += new System.EventHandler(this.cbTU_SelectionChangeCommitted);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(610, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Инв. группа";
            // 
            // cbInv
            // 
            this.cbInv.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbInv.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbInv.FormattingEnabled = true;
            this.cbInv.Location = new System.Drawing.Point(683, 13);
            this.cbInv.Name = "cbInv";
            this.cbInv.Size = new System.Drawing.Size(121, 21);
            this.cbInv.TabIndex = 4;
            this.cbInv.SelectionChangeCommitted += new System.EventHandler(this.cbInv_SelectionChangeCommitted);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(897, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(24, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "ЮЛ";
            // 
            // cbUl
            // 
            this.cbUl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbUl.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbUl.FormattingEnabled = true;
            this.cbUl.Location = new System.Drawing.Point(923, 13);
            this.cbUl.Name = "cbUl";
            this.cbUl.Size = new System.Drawing.Size(83, 21);
            this.cbUl.TabIndex = 4;
            this.cbUl.SelectionChangeCommitted += new System.EventHandler(this.cbUl_SelectionChangeCommitted);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(21, 43);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "EAN";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(585, 43);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(83, 13);
            this.label7.TabIndex = 1;
            this.label7.Text = "Наименование";
            // 
            // tbEAN
            // 
            this.tbEAN.Location = new System.Drawing.Point(62, 39);
            this.tbEAN.Name = "tbEAN";
            this.tbEAN.Size = new System.Drawing.Size(135, 20);
            this.tbEAN.TabIndex = 5;
            this.tbEAN.TextChanged += new System.EventHandler(this.tbEAN_TextChanged);
            this.tbEAN.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbEAN_KeyPress);
            // 
            // tbName
            // 
            this.tbName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbName.Location = new System.Drawing.Point(674, 39);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(332, 20);
            this.tbName.TabIndex = 5;
            this.tbName.TextChanged += new System.EventHandler(this.tbName_TextChanged);
            // 
            // dgvMain
            // 
            this.dgvMain.AllowUserToAddRows = false;
            this.dgvMain.AllowUserToDeleteRows = false;
            this.dgvMain.AllowUserToResizeRows = false;
            this.dgvMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvMain.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMain.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMain.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cname,
            this.ul,
            this.ean,
            this.nameTovar,
            this.netto,
            this.zcena,
            this.rcena,
            this.sumZ,
            this.sumR,
            this.id_otdel,
            this.id_tovar,
            this.Sgn,
            this.id_grp1,
            this.id_grp2,
            this.zcenaStab,
            this.editing,
            this.id_post,
            this.nTypeOrg});
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvMain.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgvMain.Location = new System.Drawing.Point(12, 65);
            this.dgvMain.MultiSelect = false;
            this.dgvMain.Name = "dgvMain";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMain.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dgvMain.RowHeadersVisible = false;
            this.dgvMain.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMain.Size = new System.Drawing.Size(1000, 553);
            this.dgvMain.TabIndex = 6;
            this.dgvMain.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvMain_CellBeginEdit);
            this.dgvMain.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMain_CellEndEdit);
            this.dgvMain.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgvMain_CellValidating);
            this.dgvMain.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMain_CellValueChanged);
            this.dgvMain.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvMain_DataError);
            this.dgvMain.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvMain_RowPostPaint);
            this.dgvMain.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dgvMain_RowPrePaint);
            // 
            // cname
            // 
            this.cname.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.cname.DataPropertyName = "cname";
            this.cname.HeaderText = "Поставщик";
            this.cname.MinimumWidth = 110;
            this.cname.Name = "cname";
            this.cname.ReadOnly = true;
            this.cname.Width = 110;
            // 
            // ul
            // 
            this.ul.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ul.DataPropertyName = "ul";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ul.DefaultCellStyle = dataGridViewCellStyle2;
            this.ul.HeaderText = "ЮЛ";
            this.ul.MinimumWidth = 30;
            this.ul.Name = "ul";
            this.ul.ReadOnly = true;
            this.ul.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ul.Width = 30;
            // 
            // ean
            // 
            this.ean.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ean.DataPropertyName = "ean";
            this.ean.HeaderText = "EAN";
            this.ean.MinimumWidth = 90;
            this.ean.Name = "ean";
            this.ean.ReadOnly = true;
            this.ean.Width = 90;
            // 
            // nameTovar
            // 
            this.nameTovar.DataPropertyName = "nameTovar";
            this.nameTovar.HeaderText = "Наименование";
            this.nameTovar.Name = "nameTovar";
            this.nameTovar.ReadOnly = true;
            // 
            // netto
            // 
            this.netto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.netto.DataPropertyName = "netto";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N3";
            dataGridViewCellStyle3.NullValue = null;
            this.netto.DefaultCellStyle = dataGridViewCellStyle3;
            this.netto.HeaderText = "Количество";
            this.netto.MinimumWidth = 75;
            this.netto.Name = "netto";
            this.netto.ReadOnly = true;
            this.netto.Width = 75;
            // 
            // zcena
            // 
            this.zcena.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.zcena.DataPropertyName = "zcena";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N3";
            dataGridViewCellStyle4.NullValue = null;
            this.zcena.DefaultCellStyle = dataGridViewCellStyle4;
            this.zcena.HeaderText = "Цена закупки";
            this.zcena.MinimumWidth = 80;
            this.zcena.Name = "zcena";
            this.zcena.ReadOnly = true;
            this.zcena.Width = 80;
            // 
            // rcena
            // 
            this.rcena.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.rcena.DataPropertyName = "rcena";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N2";
            dataGridViewCellStyle5.NullValue = null;
            this.rcena.DefaultCellStyle = dataGridViewCellStyle5;
            this.rcena.HeaderText = "Цена продажи";
            this.rcena.MinimumWidth = 80;
            this.rcena.Name = "rcena";
            this.rcena.ReadOnly = true;
            this.rcena.Width = 80;
            // 
            // sumZ
            // 
            this.sumZ.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.sumZ.DataPropertyName = "sumZ";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N2";
            dataGridViewCellStyle6.NullValue = null;
            this.sumZ.DefaultCellStyle = dataGridViewCellStyle6;
            this.sumZ.HeaderText = "Сумма закупки";
            this.sumZ.MinimumWidth = 80;
            this.sumZ.Name = "sumZ";
            this.sumZ.ReadOnly = true;
            this.sumZ.Width = 80;
            // 
            // sumR
            // 
            this.sumR.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.sumR.DataPropertyName = "sumR";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "N2";
            dataGridViewCellStyle7.NullValue = null;
            this.sumR.DefaultCellStyle = dataGridViewCellStyle7;
            this.sumR.HeaderText = "Сумма продажи";
            this.sumR.MinimumWidth = 80;
            this.sumR.Name = "sumR";
            this.sumR.ReadOnly = true;
            this.sumR.Width = 80;
            // 
            // id_otdel
            // 
            this.id_otdel.DataPropertyName = "id_otdel";
            this.id_otdel.HeaderText = "id_otdel";
            this.id_otdel.Name = "id_otdel";
            this.id_otdel.ReadOnly = true;
            this.id_otdel.Visible = false;
            // 
            // id_tovar
            // 
            this.id_tovar.DataPropertyName = "id_tovar";
            this.id_tovar.HeaderText = "id_tovar";
            this.id_tovar.Name = "id_tovar";
            this.id_tovar.ReadOnly = true;
            this.id_tovar.Visible = false;
            // 
            // Sgn
            // 
            this.Sgn.DataPropertyName = "Sgn";
            this.Sgn.HeaderText = "Sgn";
            this.Sgn.Name = "Sgn";
            this.Sgn.ReadOnly = true;
            this.Sgn.Visible = false;
            // 
            // id_grp1
            // 
            this.id_grp1.DataPropertyName = "id_grp1";
            this.id_grp1.HeaderText = "id_grp1";
            this.id_grp1.Name = "id_grp1";
            this.id_grp1.ReadOnly = true;
            this.id_grp1.Visible = false;
            // 
            // id_grp2
            // 
            this.id_grp2.DataPropertyName = "id_grp2";
            this.id_grp2.HeaderText = "id_grp2";
            this.id_grp2.Name = "id_grp2";
            this.id_grp2.ReadOnly = true;
            this.id_grp2.Visible = false;
            // 
            // zcenaStab
            // 
            this.zcenaStab.DataPropertyName = "zcenaStab";
            this.zcenaStab.HeaderText = "zcenaStab";
            this.zcenaStab.Name = "zcenaStab";
            this.zcenaStab.ReadOnly = true;
            this.zcenaStab.Visible = false;
            // 
            // editing
            // 
            this.editing.DataPropertyName = "editing";
            this.editing.HeaderText = "editing";
            this.editing.Name = "editing";
            this.editing.ReadOnly = true;
            this.editing.Visible = false;
            // 
            // id_post
            // 
            this.id_post.DataPropertyName = "id_post";
            this.id_post.HeaderText = "id_post";
            this.id_post.Name = "id_post";
            this.id_post.ReadOnly = true;
            this.id_post.Visible = false;
            // 
            // nTypeOrg
            // 
            this.nTypeOrg.DataPropertyName = "nTypeOrg";
            this.nTypeOrg.HeaderText = "nTypeOrg";
            this.nTypeOrg.Name = "nTypeOrg";
            this.nTypeOrg.ReadOnly = true;
            this.nTypeOrg.Visible = false;
            // 
            // btPrint
            // 
            this.btPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btPrint.Enabled = false;
            this.btPrint.Image = ((System.Drawing.Image)(resources.GetObject("btPrint.Image")));
            this.btPrint.Location = new System.Drawing.Point(942, 676);
            this.btPrint.Name = "btPrint";
            this.btPrint.Size = new System.Drawing.Size(32, 32);
            this.btPrint.TabIndex = 3;
            this.toolTip1.SetToolTip(this.btPrint, "Печать отчёта по отделам и поставщикам");
            this.btPrint.UseVisualStyleBackColor = true;
            this.btPrint.Click += new System.EventHandler(this.btPrint_Click);
            // 
            // btExcel
            // 
            this.btExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btExcel.Enabled = false;
            this.btExcel.Image = ((System.Drawing.Image)(resources.GetObject("btExcel.Image")));
            this.btExcel.Location = new System.Drawing.Point(904, 676);
            this.btExcel.Name = "btExcel";
            this.btExcel.Size = new System.Drawing.Size(32, 32);
            this.btExcel.TabIndex = 3;
            this.toolTip1.SetToolTip(this.btExcel, "Выгрузка в Excel");
            this.btExcel.UseVisualStyleBackColor = true;
            this.btExcel.Click += new System.EventHandler(this.btExcel_Click);
            // 
            // btGet
            // 
            this.btGet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btGet.Image = ((System.Drawing.Image)(resources.GetObject("btGet.Image")));
            this.btGet.Location = new System.Drawing.Point(867, 676);
            this.btGet.Name = "btGet";
            this.btGet.Size = new System.Drawing.Size(32, 32);
            this.btGet.TabIndex = 3;
            this.toolTip1.SetToolTip(this.btGet, "Расчёт остатка");
            this.btGet.UseVisualStyleBackColor = true;
            this.btGet.Click += new System.EventHandler(this.btGet_Click);
            // 
            // btSave1
            // 
            this.btSave1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btSave1.Enabled = false;
            this.btSave1.Image = ((System.Drawing.Image)(resources.GetObject("btSave1.Image")));
            this.btSave1.Location = new System.Drawing.Point(791, 676);
            this.btSave1.Name = "btSave1";
            this.btSave1.Size = new System.Drawing.Size(32, 32);
            this.btSave1.TabIndex = 3;
            this.toolTip1.SetToolTip(this.btSave1, "Сохранить закупочные цены");
            this.btSave1.UseVisualStyleBackColor = true;
            this.btSave1.Click += new System.EventHandler(this.btSave1_Click);
            // 
            // btSave2
            // 
            this.btSave2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btSave2.Enabled = false;
            this.btSave2.Image = ((System.Drawing.Image)(resources.GetObject("btSave2.Image")));
            this.btSave2.Location = new System.Drawing.Point(753, 676);
            this.btSave2.Name = "btSave2";
            this.btSave2.Size = new System.Drawing.Size(32, 32);
            this.btSave2.TabIndex = 3;
            this.toolTip1.SetToolTip(this.btSave2, "Сохранить инвентаризацонные остатки");
            this.btSave2.UseVisualStyleBackColor = true;
            this.btSave2.Click += new System.EventHandler(this.btSave2_Click);
            // 
            // btSettings
            // 
            this.btSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btSettings.Image = ((System.Drawing.Image)(resources.GetObject("btSettings.Image")));
            this.btSettings.Location = new System.Drawing.Point(829, 676);
            this.btSettings.Name = "btSettings";
            this.btSettings.Size = new System.Drawing.Size(32, 32);
            this.btSettings.TabIndex = 3;
            this.toolTip1.SetToolTip(this.btSettings, "Настройка");
            this.btSettings.UseVisualStyleBackColor = true;
            this.btSettings.Click += new System.EventHandler(this.btSettings_Click);
            // 
            // tbSellSum
            // 
            this.tbSellSum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.tbSellSum.BackColor = System.Drawing.Color.White;
            this.tbSellSum.Location = new System.Drawing.Point(904, 650);
            this.tbSellSum.Name = "tbSellSum";
            this.tbSellSum.ReadOnly = true;
            this.tbSellSum.Size = new System.Drawing.Size(100, 20);
            this.tbSellSum.TabIndex = 5;
            this.tbSellSum.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.toolTip1.SetToolTip(this.tbSellSum, "Общая сумма продажи");
            // 
            // tbAllSumEdit
            // 
            this.tbAllSumEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.tbAllSumEdit.BackColor = System.Drawing.Color.White;
            this.tbAllSumEdit.Location = new System.Drawing.Point(753, 650);
            this.tbAllSumEdit.Name = "tbAllSumEdit";
            this.tbAllSumEdit.ReadOnly = true;
            this.tbAllSumEdit.Size = new System.Drawing.Size(100, 20);
            this.tbAllSumEdit.TabIndex = 5;
            this.tbAllSumEdit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.toolTip1.SetToolTip(this.tbAllSumEdit, "Общая сумма закупки с изменениями");
            // 
            // tbAllSum
            // 
            this.tbAllSum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.tbAllSum.BackColor = System.Drawing.Color.White;
            this.tbAllSum.Location = new System.Drawing.Point(753, 627);
            this.tbAllSum.Name = "tbAllSum";
            this.tbAllSum.ReadOnly = true;
            this.tbAllSum.Size = new System.Drawing.Size(100, 20);
            this.tbAllSum.TabIndex = 5;
            this.tbAllSum.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.toolTip1.SetToolTip(this.tbAllSum, "Общая сумма закупки без изменений");
            // 
            // tbZSumInv
            // 
            this.tbZSumInv.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbZSumInv.BackColor = System.Drawing.Color.White;
            this.tbZSumInv.Location = new System.Drawing.Point(543, 683);
            this.tbZSumInv.Name = "tbZSumInv";
            this.tbZSumInv.ReadOnly = true;
            this.tbZSumInv.Size = new System.Drawing.Size(202, 20);
            this.tbZSumInv.TabIndex = 5;
            this.tbZSumInv.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.toolTip1.SetToolTip(this.tbZSumInv, "Итого сумма продажи без учёта инвентаризацонного списания");
            this.tbZSumInv.Visible = false;
            // 
            // tbPSumInv
            // 
            this.tbPSumInv.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbPSumInv.BackColor = System.Drawing.Color.White;
            this.tbPSumInv.Location = new System.Drawing.Point(316, 683);
            this.tbPSumInv.Name = "tbPSumInv";
            this.tbPSumInv.ReadOnly = true;
            this.tbPSumInv.Size = new System.Drawing.Size(221, 20);
            this.tbPSumInv.TabIndex = 5;
            this.tbPSumInv.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.toolTip1.SetToolTip(this.tbPSumInv, "Итого сумма закупки без учёта инвентаризацинного списания");
            this.tbPSumInv.Visible = false;
            // 
            // chbOutInvSpis
            // 
            this.chbOutInvSpis.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chbOutInvSpis.AutoSize = true;
            this.chbOutInvSpis.Location = new System.Drawing.Point(12, 685);
            this.chbOutInvSpis.Name = "chbOutInvSpis";
            this.chbOutInvSpis.Size = new System.Drawing.Size(240, 17);
            this.chbOutInvSpis.TabIndex = 7;
            this.chbOutInvSpis.Text = "без учёта инвентаризационного списания";
            this.chbOutInvSpis.UseVisualStyleBackColor = true;
            this.chbOutInvSpis.Visible = false;
            this.chbOutInvSpis.MouseClick += new System.Windows.Forms.MouseEventHandler(this.chbOutInvSpis_MouseClick);
            // 
            // panEdit
            // 
            this.panEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(169)))), ((int)(((byte)(255)))));
            this.panEdit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panEdit.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.panEdit.Location = new System.Drawing.Point(12, 653);
            this.panEdit.Name = "panEdit";
            this.panEdit.Size = new System.Drawing.Size(18, 21);
            this.panEdit.TabIndex = 8;
            // 
            // panSave
            // 
            this.panSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.panSave.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panSave.Location = new System.Drawing.Point(12, 624);
            this.panSave.Name = "panSave";
            this.panSave.Size = new System.Drawing.Size(18, 21);
            this.panSave.TabIndex = 8;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(36, 628);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(238, 13);
            this.label8.TabIndex = 9;
            this.label8.Text = "Цена закупки взята из сохраненной таблицы";
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(36, 657);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(174, 13);
            this.label9.TabIndex = 10;
            this.label9.Text = "Цена закупки откорректирована";
            // 
            // bw
            // 
            this.bw.WorkerReportsProgress = true;
            this.bw.WorkerSupportsCancellation = true;
            this.bw.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bw_DoWork);
            this.bw.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bw_RunWorkerCompleted);
            // 
            // bwSave
            // 
            this.bwSave.WorkerReportsProgress = true;
            this.bwSave.WorkerSupportsCancellation = true;
            this.bwSave.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwSave_DoWork);
            this.bwSave.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwSave_RunWorkerCompleted);
            // 
            // bwSave1
            // 
            this.bwSave1.WorkerReportsProgress = true;
            this.bwSave1.WorkerSupportsCancellation = true;
            this.bwSave1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwSave1_DoWork);
            this.bwSave1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwSave1_RunWorkerCompleted);
            // 
            // bwPrint1
            // 
            this.bwPrint1.WorkerReportsProgress = true;
            this.bwPrint1.WorkerSupportsCancellation = true;
            this.bwPrint1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwPrint1_DoWork);
            this.bwPrint1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwPrint1_RunWorkerCompleted);
            // 
            // bwPrint2
            // 
            this.bwPrint2.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwPrint2_DoWork);
            this.bwPrint2.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwPrint2_RunWorkerCompleted);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 733);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.panSave);
            this.Controls.Add(this.panEdit);
            this.Controls.Add(this.chbOutInvSpis);
            this.Controls.Add(this.dgvMain);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.tbPSumInv);
            this.Controls.Add(this.tbZSumInv);
            this.Controls.Add(this.tbAllSum);
            this.Controls.Add(this.tbAllSumEdit);
            this.Controls.Add(this.tbSellSum);
            this.Controls.Add(this.tbEAN);
            this.Controls.Add(this.cbUl);
            this.Controls.Add(this.cbInv);
            this.Controls.Add(this.cbTU);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cbDeps);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btSettings);
            this.Controls.Add(this.btSave2);
            this.Controls.Add(this.btSave1);
            this.Controls.Add(this.btGet);
            this.Controls.Add(this.btExcel);
            this.Controls.Add(this.btPrint);
            this.Controls.Add(this.btExit);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.statusStrip1);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Button btExit;
        private System.Windows.Forms.ComboBox cbDeps;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbTU;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbInv;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbUl;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbEAN;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Button btPrint;
        private System.Windows.Forms.Button btExcel;
        private System.Windows.Forms.Button btGet;
        private System.Windows.Forms.Button btSave1;
        private System.Windows.Forms.Button btSave2;
        private System.Windows.Forms.Button btSettings;
        private System.Windows.Forms.TextBox tbSellSum;
        private System.Windows.Forms.TextBox tbAllSumEdit;
        private System.Windows.Forms.TextBox tbAllSum;
        private System.Windows.Forms.TextBox tbZSumInv;
        private System.Windows.Forms.TextBox tbPSumInv;
        private System.Windows.Forms.CheckBox chbOutInvSpis;
        private System.Windows.Forms.Panel panEdit;
        private System.Windows.Forms.Panel panSave;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.ComponentModel.BackgroundWorker bw;
        private System.Windows.Forms.DataGridView dgvMain;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.ComponentModel.BackgroundWorker bwSave;
        private System.ComponentModel.BackgroundWorker bwSave1;
        private System.ComponentModel.BackgroundWorker bwPrint1;
        private System.ComponentModel.BackgroundWorker bwPrint2;
        private System.Windows.Forms.DataGridViewTextBoxColumn cname;
        private System.Windows.Forms.DataGridViewTextBoxColumn ul;
        private System.Windows.Forms.DataGridViewTextBoxColumn ean;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameTovar;
        private System.Windows.Forms.DataGridViewTextBoxColumn netto;
        private System.Windows.Forms.DataGridViewTextBoxColumn zcena;
        private System.Windows.Forms.DataGridViewTextBoxColumn rcena;
        private System.Windows.Forms.DataGridViewTextBoxColumn sumZ;
        private System.Windows.Forms.DataGridViewTextBoxColumn sumR;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_otdel;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_tovar;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sgn;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_grp1;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_grp2;
        private System.Windows.Forms.DataGridViewTextBoxColumn zcenaStab;
        private System.Windows.Forms.DataGridViewTextBoxColumn editing;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_post;
        private System.Windows.Forms.DataGridViewTextBoxColumn nTypeOrg;
    }
}

