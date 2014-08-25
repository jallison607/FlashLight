using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using GameTools.Basic;

namespace MyThreadingTest
{
    public class GameArea : Panel
    {
        public GameArea()
        {
            //MessageBox.Show("In panel constructor");
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint, true);
            //this.Dock = DockStyle.Fill;
            this.BackColor = Color.White;
            //this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
        }

        public void updateLocation(Point tmpOffset)
        {
            this.Location = tmpOffset;
        }

        public void updateSize(Size tmpSize)
        {
            this.Width = tmpSize.Width;
            this.Height = tmpSize.Height;
        }
    }
}
