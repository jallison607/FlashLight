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
    public partial class NewLevel : Form
    {
        GameArea myGameArea;
        List<Rectangle> colBoxes = new List<Rectangle>();
        List<FancyRectangle> obstructBoxes = new List<FancyRectangle>();
        List<Line> obstructLine = new List<Line>();
        Rectangle tmpDrawnRectangle = new Rectangle();
        bool Drawing = false;
        bool DrawingCol = true;
        bool DrawingBoth = false;

        public NewLevel(GameLevel tmpLevel)
        {
            InitializeComponent();
            Bitmap back = tmpLevel.getBackground();
            this.pScene.Width = back.Width;
            this.pScene.Height = back.Height;
            pScene.BackgroundImage = back;
            this.colBoxes = tmpLevel.getColboxes();
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
