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
        private GameLevel aNewLevel; 
    
        public NewLevelSettings()
        {
            InitializeComponent();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            bool passed = false;
            if (imagePath == string.Empty || txtLevelName.Text == string.Empty)
            {
                MessageBox.Show("You must select a file and fill out a Level Name");
            }
            else if (bground.Width != this.nudWidth.Value || bground.Height != this.nudHeight.Value)
            {
                DialogResult dialogResult = MessageBox.Show("The resolution you specified is different then that of the image, Are you sure you want to resize?", "Confirm", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    this.bground = new Bitmap(this.bground, new Size((int)this.nudWidth.Value, (int)this.nudHeight.Value));
                    MessageBox.Show("New Width, Height : " + this.bground.Size);
                    passed = true;
                }
            
            }
            else
            {
                passed = true;
            }
            
            if(passed)
            {
                GameLevel tmpLevel = new GameLevel(this.bground, this.txtLevelName.Text);
                this.aNewLevel = tmpLevel;
                this.DialogResult = DialogResult.OK;
            }

            
        }

        private void btnFile_Click(object sender, EventArgs e)
        {
            DialogResult ofdResult = ofdBackground.ShowDialog();


            if (ofdResult == DialogResult.OK)
            {
                try
                {
                    this.bground = new Bitmap(ofdBackground.FileName);
                    this.lblFileName.Text = ofdBackground.FileName;
                    this.imagePath = ofdBackground.FileName;
                    this.nudHeight.Value = bground.Height;
                    this.nudWidth.Value = bground.Width;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Invalid file " + ofdBackground.FileName + " " + ex.Message);
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

        public GameLevel getGameLevel()
        {
            return this.aNewLevel;
        }
    }
}
