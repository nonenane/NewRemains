namespace NewRemains
{
    partial class frmSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSettings));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btExit = new System.Windows.Forms.Button();
            this.btSave = new System.Windows.Forms.Button();
            this.btAdd = new System.Windows.Forms.Button();
            this.btDelete = new System.Windows.Forms.Button();
            this.dgvAll = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.inn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cNameLdeyst = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ltype = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.color = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chbAll = new System.Windows.Forms.CheckBox();
            this.chbGroupe = new System.Windows.Forms.CheckBox();
            this.rbDouble = new System.Windows.Forms.RadioButton();
            this.rbFour = new System.Windows.Forms.RadioButton();
            this.rbFirst = new System.Windows.Forms.RadioButton();
            this.rbSecond = new System.Windows.Forms.RadioButton();
            this.tbName = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvSave = new System.Windows.Forms.DataGridView();
            this.id1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cname1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.inn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cNameLdeyst1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ltype1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.color1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAll)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSave)).BeginInit();
            this.SuspendLayout();
            // 
            // btExit
            // 
            this.btExit.Image = ((System.Drawing.Image)(resources.GetObject("btExit.Image")));
            this.btExit.Location = new System.Drawing.Point(641, 454);
            this.btExit.Name = "btExit";
            this.btExit.Size = new System.Drawing.Size(32, 32);
            this.btExit.TabIndex = 0;
            this.toolTip1.SetToolTip(this.btExit, "Выход");
            this.btExit.UseVisualStyleBackColor = true;
            this.btExit.Click += new System.EventHandler(this.btExit_Click);
            // 
            // btSave
            // 
            this.btSave.Image = ((System.Drawing.Image)(resources.GetObject("btSave.Image")));
            this.btSave.Location = new System.Drawing.Point(602, 454);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(32, 32);
            this.btSave.TabIndex = 0;
            this.toolTip1.SetToolTip(this.btSave, "Сохранить");
            this.btSave.UseVisualStyleBackColor = true;
            this.btSave.Click += new System.EventHandler(this.btSave_Click);
            // 
            // btAdd
            // 
            this.btAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btAdd.Location = new System.Drawing.Point(328, 124);
            this.btAdd.Name = "btAdd";
            this.btAdd.Size = new System.Drawing.Size(32, 32);
            this.btAdd.TabIndex = 0;
            this.btAdd.Text = ">>";
            this.btAdd.UseVisualStyleBackColor = true;
            this.btAdd.Click += new System.EventHandler(this.btAdd_Click);
            // 
            // btDelete
            // 
            this.btDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btDelete.Location = new System.Drawing.Point(328, 235);
            this.btDelete.Name = "btDelete";
            this.btDelete.Size = new System.Drawing.Size(32, 32);
            this.btDelete.TabIndex = 0;
            this.btDelete.Text = "<<";
            this.btDelete.UseVisualStyleBackColor = true;
            this.btDelete.Click += new System.EventHandler(this.btDelete_Click);
            // 
            // dgvAll
            // 
            this.dgvAll.AllowUserToAddRows = false;
            this.dgvAll.AllowUserToDeleteRows = false;
            this.dgvAll.AllowUserToResizeRows = false;
            this.dgvAll.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAll.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvAll.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAll.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.cname,
            this.inn,
            this.cNameLdeyst,
            this.ltype,
            this.color});
            this.dgvAll.Location = new System.Drawing.Point(12, 40);
            this.dgvAll.MultiSelect = false;
            this.dgvAll.Name = "dgvAll";
            this.dgvAll.ReadOnly = true;
            this.dgvAll.RowHeadersVisible = false;
            this.dgvAll.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAll.Size = new System.Drawing.Size(310, 378);
            this.dgvAll.TabIndex = 1;
            this.dgvAll.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dgvAll_RowPrePaint);
            this.dgvAll.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvAll_CellMouseDoubleClick);
            this.dgvAll.SelectionChanged += new System.EventHandler(this.dgvAll_SelectionChanged);
            // 
            // id
            // 
            this.id.DataPropertyName = "id";
            this.id.HeaderText = "id";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            // 
            // cname
            // 
            this.cname.DataPropertyName = "cname";
            this.cname.HeaderText = "Наименование";
            this.cname.Name = "cname";
            this.cname.ReadOnly = true;
            // 
            // inn
            // 
            this.inn.DataPropertyName = "inn";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.inn.DefaultCellStyle = dataGridViewCellStyle7;
            this.inn.HeaderText = "ИНН";
            this.inn.Name = "inn";
            this.inn.ReadOnly = true;
            // 
            // cNameLdeyst
            // 
            this.cNameLdeyst.DataPropertyName = "cNameLdeyst";
            this.cNameLdeyst.HeaderText = "cNameLdeyst";
            this.cNameLdeyst.Name = "cNameLdeyst";
            this.cNameLdeyst.ReadOnly = true;
            this.cNameLdeyst.Visible = false;
            // 
            // ltype
            // 
            this.ltype.DataPropertyName = "ltype";
            this.ltype.HeaderText = "ltype";
            this.ltype.Name = "ltype";
            this.ltype.ReadOnly = true;
            this.ltype.Visible = false;
            // 
            // color
            // 
            this.color.DataPropertyName = "color";
            this.color.HeaderText = "color";
            this.color.Name = "color";
            this.color.ReadOnly = true;
            this.color.Visible = false;
            // 
            // chbAll
            // 
            this.chbAll.AutoSize = true;
            this.chbAll.Location = new System.Drawing.Point(13, 434);
            this.chbAll.Name = "chbAll";
            this.chbAll.Size = new System.Drawing.Size(45, 17);
            this.chbAll.TabIndex = 2;
            this.chbAll.Text = "Все";
            this.chbAll.UseVisualStyleBackColor = true;
            this.chbAll.MouseClick += new System.Windows.Forms.MouseEventHandler(this.rbFirst_MouseClick);
            // 
            // chbGroupe
            // 
            this.chbGroupe.AutoSize = true;
            this.chbGroupe.Checked = true;
            this.chbGroupe.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbGroupe.Location = new System.Drawing.Point(376, 434);
            this.chbGroupe.Name = "chbGroupe";
            this.chbGroupe.Size = new System.Drawing.Size(243, 17);
            this.chbGroupe.TabIndex = 2;
            this.chbGroupe.Text = "Суммировать остатки у всех поставщиков";
            this.chbGroupe.UseVisualStyleBackColor = true;
            // 
            // rbDouble
            // 
            this.rbDouble.AutoSize = true;
            this.rbDouble.Location = new System.Drawing.Point(178, 462);
            this.rbDouble.Name = "rbDouble";
            this.rbDouble.Size = new System.Drawing.Size(31, 17);
            this.rbDouble.TabIndex = 3;
            this.rbDouble.TabStop = true;
            this.rbDouble.Text = "2";
            this.rbDouble.UseVisualStyleBackColor = true;
            // 
            // rbFour
            // 
            this.rbFour.AutoSize = true;
            this.rbFour.Checked = true;
            this.rbFour.Location = new System.Drawing.Point(215, 462);
            this.rbFour.Name = "rbFour";
            this.rbFour.Size = new System.Drawing.Size(31, 17);
            this.rbFour.TabIndex = 3;
            this.rbFour.TabStop = true;
            this.rbFour.Text = "4";
            this.rbFour.UseVisualStyleBackColor = true;
            // 
            // rbFirst
            // 
            this.rbFirst.AutoSize = true;
            this.rbFirst.Checked = true;
            this.rbFirst.Location = new System.Drawing.Point(7, 13);
            this.rbFirst.Name = "rbFirst";
            this.rbFirst.Size = new System.Drawing.Size(37, 17);
            this.rbFirst.TabIndex = 3;
            this.rbFirst.TabStop = true;
            this.rbFirst.Text = "11";
            this.rbFirst.UseVisualStyleBackColor = true;
            this.rbFirst.MouseClick += new System.Windows.Forms.MouseEventHandler(this.rbFirst_MouseClick);
            // 
            // rbSecond
            // 
            this.rbSecond.AutoSize = true;
            this.rbSecond.Location = new System.Drawing.Point(50, 13);
            this.rbSecond.Name = "rbSecond";
            this.rbSecond.Size = new System.Drawing.Size(37, 17);
            this.rbSecond.TabIndex = 3;
            this.rbSecond.TabStop = true;
            this.rbSecond.Text = "22";
            this.rbSecond.UseVisualStyleBackColor = true;
            this.rbSecond.MouseClick += new System.Windows.Forms.MouseEventHandler(this.rbFirst_MouseClick);
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(12, 14);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(197, 20);
            this.tbName.TabIndex = 4;
            this.tbName.TextChanged += new System.EventHandler(this.tbName_TextChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(66, 434);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(16, 17);
            this.panel1.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(88, 436);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Недействующие";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 464);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(160, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Цена закупки с точностью до:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(411, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(220, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Поставщики с суммируемыми остатками";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(252, 464);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(120, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "знаков после запятой";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbFirst);
            this.groupBox1.Controls.Add(this.rbSecond);
            this.groupBox1.Location = new System.Drawing.Point(218, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(93, 35);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            // 
            // dgvSave
            // 
            this.dgvSave.AllowUserToAddRows = false;
            this.dgvSave.AllowUserToDeleteRows = false;
            this.dgvSave.AllowUserToResizeRows = false;
            this.dgvSave.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSave.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvSave.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSave.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id1,
            this.cname1,
            this.inn1,
            this.cNameLdeyst1,
            this.ltype1,
            this.color1});
            this.dgvSave.Location = new System.Drawing.Point(366, 40);
            this.dgvSave.MultiSelect = false;
            this.dgvSave.Name = "dgvSave";
            this.dgvSave.ReadOnly = true;
            this.dgvSave.RowHeadersVisible = false;
            this.dgvSave.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSave.Size = new System.Drawing.Size(310, 378);
            this.dgvSave.TabIndex = 8;
            this.dgvSave.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dgvSave_RowPrePaint);
            this.dgvSave.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvSave_CellMouseDoubleClick);
            // 
            // id1
            // 
            this.id1.DataPropertyName = "id";
            this.id1.HeaderText = "id";
            this.id1.Name = "id1";
            this.id1.ReadOnly = true;
            this.id1.Visible = false;
            // 
            // cname1
            // 
            this.cname1.DataPropertyName = "cname";
            this.cname1.HeaderText = "Наименование";
            this.cname1.Name = "cname1";
            this.cname1.ReadOnly = true;
            // 
            // inn1
            // 
            this.inn1.DataPropertyName = "inn";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.inn1.DefaultCellStyle = dataGridViewCellStyle9;
            this.inn1.HeaderText = "ИНН";
            this.inn1.Name = "inn1";
            this.inn1.ReadOnly = true;
            // 
            // cNameLdeyst1
            // 
            this.cNameLdeyst1.DataPropertyName = "cNameLdeyst";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.cNameLdeyst1.DefaultCellStyle = dataGridViewCellStyle10;
            this.cNameLdeyst1.HeaderText = "Тип";
            this.cNameLdeyst1.Name = "cNameLdeyst1";
            this.cNameLdeyst1.ReadOnly = true;
            // 
            // ltype1
            // 
            this.ltype1.DataPropertyName = "ltype";
            this.ltype1.HeaderText = "ltype";
            this.ltype1.Name = "ltype1";
            this.ltype1.ReadOnly = true;
            this.ltype1.Visible = false;
            // 
            // color1
            // 
            this.color1.DataPropertyName = "color";
            this.color1.HeaderText = "color";
            this.color1.Name = "color1";
            this.color1.ReadOnly = true;
            this.color1.Visible = false;
            // 
            // frmSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(685, 492);
            this.ControlBox = false;
            this.Controls.Add(this.dgvSave);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.rbFour);
            this.Controls.Add(this.rbDouble);
            this.Controls.Add(this.chbGroupe);
            this.Controls.Add(this.chbAll);
            this.Controls.Add(this.dgvAll);
            this.Controls.Add(this.btDelete);
            this.Controls.Add(this.btAdd);
            this.Controls.Add(this.btSave);
            this.Controls.Add(this.btExit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSettings";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Настройки";
            this.Load += new System.EventHandler(this.frmSettings_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmSettings_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAll)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSave)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btExit;
        private System.Windows.Forms.Button btSave;
        private System.Windows.Forms.Button btAdd;
        private System.Windows.Forms.Button btDelete;
        private System.Windows.Forms.DataGridView dgvAll;
        private System.Windows.Forms.CheckBox chbAll;
        private System.Windows.Forms.CheckBox chbGroupe;
        private System.Windows.Forms.RadioButton rbDouble;
        private System.Windows.Forms.RadioButton rbFour;
        private System.Windows.Forms.RadioButton rbFirst;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbSecond;
        private System.Windows.Forms.DataGridView dgvSave;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn cname;
        private System.Windows.Forms.DataGridViewTextBoxColumn inn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cNameLdeyst;
        private System.Windows.Forms.DataGridViewTextBoxColumn ltype;
        private System.Windows.Forms.DataGridViewTextBoxColumn color;
        private System.Windows.Forms.DataGridViewTextBoxColumn id1;
        private System.Windows.Forms.DataGridViewTextBoxColumn cname1;
        private System.Windows.Forms.DataGridViewTextBoxColumn inn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn cNameLdeyst1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ltype1;
        private System.Windows.Forms.DataGridViewTextBoxColumn color1;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}