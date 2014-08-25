using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MyThreadingTest
{
    public partial class NewLevelSettings : Form
    {
        private string imagePath = string.Empty;
        private Bitmap bground;
             
        public NewLevelSettings()
        {
            InitializeComponent();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (imagePath == string.Empty || txtLevelName.Text == string.Empty)
            {
                MessageBox.Show("You must select a file and fill out a Level Name");
            }
            else if (bground.Width != this.nudWidth.Value || bground.Height != this.nudHeight.Height)
            {

            }else{
                
            }

            
        }

        private void btnFile_Click(object sender, EventArgs e)
        {
            DialogResult ofdResult = ofdBackground.ShowDialog();


            if (ofdResult == DialogResult.OK)
            {
                try
                {
                    this.bground = new Bitmap(ofdBackground.OpenFile());
                    this.lblFileName.Text = ofdBackground.FileName;
                    this.imagePath = ofdBackground.FileName;
                }
                catch
                {
                    MessageBox.Show("Invalid file");
                }
            }

        }

        private void lblFileName_MouseHover(object sender, EventArgs e)
        {
            this.lblFileName.AutoSize = true;
            
        }

        private void lblFileName_MouseLeave(object sender, EventArgs e)
        {
            this.lblFileName.AutoSize = false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
