using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NewRemains
{
    public partial class frmWait : Form
    {
        public string TextWait
        {
            //get { return password; }
            set { label1.Text = value; }
        }
        public string setText = "";
        public frmWait()
        {
            InitializeComponent();
        }
    }
}
