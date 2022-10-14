#include "frmAbout"
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
    public partial class Form1 : Form
    {
        public  Form1()
        {
            InitializeComponent();
        }
        string path;
        private void newToolStripMenuItem_Click (object sender, EventArgs e)
        {
               path = string.Empty;
               textBox.Clear();
        }

        private void openToolStripMenuItem_Click (object sender, EventArgs e)
        {
            using (OpenFileDialog old = new OpenFileDialog () { Filter = "Text Documents *.txt", ValidateNames = true, Multiselect = False})
            {
                if (old.ShowDialog() == DialogResult.OK)
                {
                    try 
                    {
                    using(StreamReader sr = new StreamReader (old.FileName))
                    {
                        path = old.FileName;
                        Task<string> text = sr.ReadToEndAsync();
                        textBox.Text = text.Result;
                    }
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show (ex.Message,"Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private async void saveToolStripMenuItem_Click (object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(path))
            {
            using(SaveFileDialog sfd=new SaveFileDialog(){filter= "text documents| *.txt", ValidateNames = true})
            {
                if(sfd.ShowDialg() == DialogResult.OK)
                {
                    try
                    {
                        path = sfd.FileName;
                    using (StreamWritee sw = new StreamWriter(sfd.FileName))
                    {
                        await sw.WriteLineAsync(textBox.Text);
                    }
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show (ex.Message,"Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            
            }
            }
            else
            {
                try 
                {
                using(StreamWriter sw = new StreamWriter(path))
                {
                    await sw.WriteLineAsync(textBox.Text);
                }
                }
                catch(Exception ex)
                    {
                        MessageBox.Show (ex.Message,"Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
            }
        }

        private async void saveAsToolStripMenuItem_Click (object sender, EventArgs e)
        {
              using(SaveFileDialog sfd=new SaveFileDialog(){filter= "text documents| *.txt", ValidateNames = true})
            {
                if(sfd.ShowDialg() == DialogResult.OK)
                {
                    try
                    {
                    using (StreamWritee sw = new StreamWriter(sfd.FileName))
                    {
                        await sw.WriteLineAsync(textBox.Text);
                    }
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show (ex.Message,"Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
        }
    }
}