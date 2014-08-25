using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MyThreadingTest
{
    class GameArea : Panel
    {
        public GameArea()
        {
            //MessageBox.Show("In panel constructor");
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint, true);
            this.Dock = DockStyle.Fill;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
        }

    }
}
