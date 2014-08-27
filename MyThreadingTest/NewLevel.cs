using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace MyThreadingTest
{
    public partial class NewLevel : Form
    {
        List<Rectangle> colBoxes = new List<Rectangle>();
        List<Rectangle> hunterSpawns = new List<Rectangle>();
        List<Rectangle> supernaturalSpawns = new List<Rectangle>();
        List<Rectangle> ItemSpawns = new List<Rectangle>();
        List<Rectangle> portals = new List<Rectangle>();
        List<FancyRectangle> obstructBoxes = new List<FancyRectangle>();
        List<Line> obstructLine = new List<Line>();
        Point sceneOffset = new Point();
        GameArea myGameArea;
        //Drawing
        Line tmpDiagLine = new Line();
        bool Drawing = false;
        int typeOfDrawing; //0: Col & vision, 1: Col only, 2: vision only, 3: Hunter Spawn, 4: Supernatural Spawn, 5: Item Spawn, 6: Portal
        

        public NewLevel(GameLevel tmpLevel)
        {
            InitializeComponent();
            Bitmap back = tmpLevel.getBackground();
            myGameArea = new GameArea();
            myGameArea.Width = back.Width;
            myGameArea.Height = back.Height;
            myGameArea.Visible = true;
            myGameArea.updateSize(back.Size);
            myGameArea.BackgroundImage = back;
            myGameArea.Paint += new System.Windows.Forms.PaintEventHandler(this.myGameArea_Paint);
            myGameArea.MouseDown += new System.Windows.Forms.MouseEventHandler(this.myGameArea_MouseDown);
            myGameArea.MouseMove += new System.Windows.Forms.MouseEventHandler(this.myGameArea_MouseMove);
            myGameArea.MouseUp += new System.Windows.Forms.MouseEventHandler(this.myGameArea_MouseUp);
            this.pEditor.Controls.Add(myGameArea);
            this.colBoxes = tmpLevel.getColboxes();
            Thread t = new Thread(update);
            t.IsBackground = true;
            t.Start();
        }

        private void update()
        {
            while (true)
            {
                myGameArea.Invalidate();
                Thread.Sleep(15);
            }
        }

        private void btnColAndObs_Click(object sender, EventArgs e)
        {
            if (!this.btnColAndObs.Checked)
            {
                this.typeOfDrawing = 0;
                uncheckAll();
                this.btnColAndObs.Checked = true;
            }
        }

        private void btnCol_Click(object sender, EventArgs e)
        {
            if (!this.btnCol.Checked)
            {
                this.typeOfDrawing = 1;
                uncheckAll();
                this.btnCol.Checked = true;
            }
        }

        private void btnObs_Click(object sender, EventArgs e)
        {
            if (!this.btnObs.Checked)
            {
                this.typeOfDrawing = 2;
                uncheckAll();
                this.btnObs.Checked = true;
            }
        }

        private void btnHSpawn_Click(object sender, EventArgs e)
        {
            if (!this.btnHSpawn.Checked)
            {
                this.typeOfDrawing = 3;
                uncheckAll();
                this.btnHSpawn.Checked = true;
            }
        }

        private void btnSSpawn_Click(object sender, EventArgs e)
        {
            if (!this.btnSSpawn.Checked)
            {
                this.typeOfDrawing = 4;
                uncheckAll();
                this.btnSSpawn.Checked = true;
            }
        }

        private void btnISpawn_Click(object sender, EventArgs e)
        {
            if (!this.btnISpawn.Checked)
            {
                this.typeOfDrawing = 5;
                uncheckAll();
                this.btnISpawn.Checked = true;
            }
        }

        private void btnPortal_Click(object sender, EventArgs e)
        {
            if (!this.btnPortal.Checked)
            {
                this.typeOfDrawing = 6;
                uncheckAll();
                this.btnPortal.Checked = true;
            }
        }

        private void uncheckAll()
        {
            this.btnColAndObs.Checked = false;
            this.btnCol.Checked = false;
            this.btnObs.Checked = false;
            this.btnHSpawn.Checked = false;
            this.btnSSpawn.Checked = false;
            this.btnISpawn.Checked = false;
            this.btnPortal.Checked = false;

        }

        private void btnViewAll_Click(object sender, EventArgs e)
        {
            if (!this.btnViewAll.Checked)
            {
                this.btnViewAll.Checked = true;
                this.btnViewColObs.Checked = false;
                this.btnViewEvents.Checked = false;
            }
        }

        private void btnViewColObs_Click(object sender, EventArgs e)
        {
            if (!this.btnViewColObs.Checked)
            {
                this.btnViewAll.Checked = false;
                this.btnViewColObs.Checked = true;
                this.btnViewEvents.Checked = false;
            }
        }

        private void btnViewEvents_Click(object sender, EventArgs e)
        {
            if (!this.btnViewEvents.Checked)
            {
                this.btnViewAll.Checked = false;
                this.btnViewColObs.Checked = false;
                this.btnViewEvents.Checked = true;
            }
        }

        private void myGameArea_Paint(object sender, PaintEventArgs e)
        {
            if (Drawing)
            {
                Brush tmpBrush = new SolidBrush(Color.FromArgb(50, 192, 192, 192));
                e.Graphics.FillRectangle(tmpBrush, currentDrawingRect());
            }
            /*
             * 
             * List<Rectangle> colBoxes = new List<Rectangle>();
             * List<Rectangle> hunterSpawns = new List<Rectangle>();
             * List<Rectangle> supernaturalSpawns = new List<Rectangle>();
             * List<Rectangle> ItemSpawns = new List<Rectangle>();
             * List<Rectangle> portals = new List<Rectangle>();
             * List<FancyRectangle> obstructBoxes = new List<FancyRectangle>();
             * 
             */

            Font overlay = new Font("Arial", 10, FontStyle.Italic, GraphicsUnit.Point);
            Pen rectBorder = Pens.DarkOrange;
            Brush textColor = Brushes.Gold;
            
            //Display the Collision Boxes
            foreach (Rectangle tmpRect in this.colBoxes)
            {
                e.Graphics.DrawString("C ", overlay, textColor, tmpRect);
                e.Graphics.DrawRectangle(rectBorder, Rectangle.Round(tmpRect));
            }

            //Display the Vision Obstruction Boxes
            foreach (FancyRectangle tmpRect in this.obstructBoxes)
            {
                e.Graphics.DrawString("V", overlay, textColor, tmpRect.getRect());
                e.Graphics.DrawRectangle(rectBorder, Rectangle.Round(tmpRect.getRect()));
            }

            //Display the Hunter Spawns
            foreach (Rectangle tmpRect in this.hunterSpawns)
            {
                e.Graphics.DrawString("H", overlay, textColor, tmpRect);
                e.Graphics.DrawRectangle(rectBorder, Rectangle.Round(tmpRect));
            }

            //Display the Supernatural Spawns
            foreach (Rectangle tmpRect in this.supernaturalSpawns)
            {
                e.Graphics.DrawString("S", overlay, textColor, tmpRect);
                e.Graphics.DrawRectangle(rectBorder, Rectangle.Round(tmpRect));
            }

            //Display the Item Spawns
            foreach (Rectangle tmpRect in this.ItemSpawns)
            {
                e.Graphics.DrawString("I", overlay, textColor, tmpRect);
                e.Graphics.DrawRectangle(rectBorder, Rectangle.Round(tmpRect));
            }

            //Display the Portals
            foreach (Rectangle tmpRect in this.portals)
            {
                e.Graphics.DrawString("P", overlay, textColor, tmpRect);
                e.Graphics.DrawRectangle(rectBorder, Rectangle.Round(tmpRect));
            }
        }

        private void myGameArea_MouseDown(object sender, MouseEventArgs e)
        {
            if (!Drawing)
            {
                Drawing = true;
                tmpDiagLine.startPoint = e.Location;
                tmpDiagLine.endPoint = e.Location;
            }
        }

        private void myGameArea_MouseMove(object sender, MouseEventArgs e)
        {
            if (Drawing)
            {
                tmpDiagLine.endPoint = e.Location;
            }
        }

        private void myGameArea_MouseUp(object sender, MouseEventArgs e)
        {
            if (Drawing)
            {
                Drawing = false;
                Rectangle tmpRect = currentDrawingRect();
                FancyRectangle tmpFRect = new FancyRectangle(tmpRect);
                switch (this.typeOfDrawing)
                {
                    case 0://save rectangle as both collision & vision
                        this.colBoxes.Add(offsetRectangle(tmpRect));
                        this.obstructBoxes.Add(tmpFRect);
                        this.obstructLine.AddRange(tmpFRect.getLines());
                        break;
                    case 1://save rectangle as collision only
                        this.colBoxes.Add(tmpRect);
                        break;
                    case 2://save rectangle as vision only
                        this.obstructBoxes.Add(tmpFRect);
                        this.obstructLine.AddRange(tmpFRect.getLines());
                        break;
                    case 3://save rectangle as hunter spawn
                        this.hunterSpawns.Add(tmpRect);
                        break;
                    case 4://save rectangle as Supernatural spawn
                        this.supernaturalSpawns.Add(tmpRect);
                        break;
                    case 5://save rectangle as item spawn
                        this.ItemSpawns.Add(tmpRect);
                        break;
                    case 6://save rectangle as Portal
                        this.portals.Add(tmpRect);
                        break;
                }

                tmpDiagLine = new Line();
            }
        }
        

        /// <summary>
        /// Using the Diagnal Line this creates a rectangle
        /// </summary>
        /// <returns>Rectangle</returns>
        private Rectangle currentDrawingRect()
        {
            Rectangle tmpDrawnRectangle = new Rectangle();

            if (tmpDiagLine.startPoint.Y <= tmpDiagLine.endPoint.Y)
            {
                tmpDrawnRectangle.Y = tmpDiagLine.startPoint.Y;
            }
            else
            {
                tmpDrawnRectangle.Y = tmpDiagLine.endPoint.Y;
            }

            if (tmpDiagLine.startPoint.X <= tmpDiagLine.endPoint.X)
            {
                tmpDrawnRectangle.X = tmpDiagLine.startPoint.X;
            }
            else
            {
                tmpDrawnRectangle.X = tmpDiagLine.endPoint.X;
            }

            tmpDrawnRectangle.Width = (int)Math.Abs(tmpDiagLine.run);
            tmpDrawnRectangle.Height = (int)Math.Abs(tmpDiagLine.rise);

            return tmpDrawnRectangle;
        }

        /// <summary>
        /// When saving rectangles they are passed to this to offset the x&y coords to account from scroll
        /// </summary>
        /// <param name="tmpOrig"></param>
        /// <returns>Rectangle</returns>
        private Rectangle offsetRectangle(Rectangle tmpOrig)
        {
            Rectangle tmpOffset = tmpOrig;

            tmpOffset.X = tmpOffset.X + sceneOffset.X;
            tmpOffset.Y = tmpOffset.Y + sceneOffset.Y;

            return tmpOffset;
        }

        /// <summary>
        /// When Painting a rectangle this strips out the offset to get the x&y position to draw at
        /// </summary>
        /// <param name="tmpOrig"></param>
        /// <returns>Rectangle</returns>
        private Rectangle unOffsetRectangle(Rectangle tmpOrig)
        {
            Rectangle tmpUnOffset = tmpOrig;

            tmpUnOffset.X = tmpUnOffset.X - sceneOffset.X;
            tmpUnOffset.Y = tmpUnOffset.Y - sceneOffset.Y;

            return tmpUnOffset;
        }
    }

            
}
