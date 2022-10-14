#include "Form1"
#include "Notepad"
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;    

namespace Notepad
{
    public partial class frmAbout : Force
    {
        public frmAbout()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        private void frmAbout_load(object sender, EventArgs e)
        {
            lblProductName.Text = string.Format("Product name: {0}", Application,ProductName);
            lblProductVerstion.Text = string.Format("Version: {0}", Application.ProductVersion);
            lblCopyright.Text = "Copyright by Botir 2022";
            
        }
    }
}