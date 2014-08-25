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
        private GameArea myGameArea;
        private SavableLevel saveMe;
        private Rectangle lastCol = new Rectangle();
        private FancyRectangle lastObs = new FancyRectangle();
        private Rectangle tmpDrawnRectangle = new Rectangle();
        private int lastType = -1;
        private bool Drawing = false;
        private bool DrawingCol = true;
        private bool DrawingBoth = false;

        public NewLevel()
        {
            InitializeComponent();

            myGameArea = new GameArea();
            this.Controls.Add(myGameArea);

            myGameArea.Visible = true;
            myGameArea.Paint += new System.Windows.Forms.PaintEventHandler(this.PaintGameArea);
            myGameArea.MouseDown += new System.Windows.Forms.MouseEventHandler(this.StartDrawCustomRectangle);
            myGameArea.MouseMove += new System.Windows.Forms.MouseEventHandler(this.DrawCustomRectangle);
            myGameArea.MouseUp += new System.Windows.Forms.MouseEventHandler(this.StopDrawingRectangle);
            
            this.Width = 700;
            this.Height = 700;
            Thread t = new Thread(update);
            t.IsBackground = true;
            t.Start();
        }

        //##########Update Method
        private void update()
        {
            while (true)
            {
                lock (myGameArea)
                {
                    myGameArea.Invalidate();
                }

                Thread.Sleep(50);

            }
        }


        //#######Events
        private void PaintGameArea(object sender, System.Windows.Forms.PaintEventArgs e)
        {

            foreach (Rectangle tmpCol in this.saveMe.colBoxes)
            {
                e.Graphics.FillRectangle(Brushes.Black, tmpCol);
            }

            foreach (FancyRectangle tmpObs in this.saveMe.obstructBoxes)
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(90, 255, 0, 0)), tmpObs.getRect());
            }

            if (tmpDrawnRectangle.Width > 0)
            {
                Brush tmpBrush;

                if (DrawingCol)
                {
                    tmpBrush = new SolidBrush(Color.FromArgb(50, 192, 192, 192));
                }
                else
                {
                    tmpBrush = new SolidBrush(Color.FromArgb(50, 255, 0, 0));
                }

                e.Graphics.FillRectangle(tmpBrush, tmpDrawnRectangle);
            }
                
        }

        private void StartDrawCustomRectangle(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (!Drawing)
            {
                Drawing = true;
                tmpDrawnRectangle.Location = e.Location;
            }
        }

        private void DrawCustomRectangle(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (Drawing)
            {
                tmpDrawnRectangle.Width = e.X - tmpDrawnRectangle.X;
                tmpDrawnRectangle.Height = e.Y - tmpDrawnRectangle.Y;
            }
        }

        private void StopDrawingRectangle(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            Drawing = false;

            if (DrawingBoth)
            {
                this.saveMe.colBoxes.Add(tmpDrawnRectangle);
                FancyRectangle tmpFancy = new FancyRectangle(tmpDrawnRectangle);
                this.saveMe.obstructBoxes.Add(tmpFancy);
                List<Line> tmpLines = tmpFancy.getLines();
                foreach (Line tmpLn in tmpLines)
                {
                    this.saveMe.obstructLine.Add(tmpLn);
                }
                this.lastObs = tmpFancy;
                this.lastCol = tmpDrawnRectangle;
                lastType = 3;
            }
            else if (DrawingCol)
            {
                this.saveMe.colBoxes.Add(tmpDrawnRectangle);
                this.lastCol = tmpDrawnRectangle;
                lastType = 1;
            }
            else
            {
                FancyRectangle tmpFancy = new FancyRectangle(tmpDrawnRectangle);
                this.saveMe.obstructBoxes.Add(tmpFancy);
                List<Line> tmpLines = tmpFancy.getLines();
                foreach (Line tmpLn in tmpLines)
                {
                    this.saveMe.obstructLine.Add(tmpLn);
                }
                this.lastObs = tmpFancy;
                lastType = 2;
            }
            tmpDrawnRectangle = new Rectangle();

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            String keyPressed = e.KeyCode.ToString();

            if (keyPressed == "C")
            {
                this.DrawingCol = !this.DrawingCol;
            }
            else if (keyPressed == "B")
            {
                this.DrawingBoth = !this.DrawingBoth;
            }
            else if (keyPressed == "Z")
            {
                if (this.lastType != -1)
                {
                    if (lastType == 1)
                    {
                        this.saveMe.colBoxes.Remove(lastCol);
                        lastType = -1;
                    }
                    else if (lastType == 2)
                    {
                        foreach (Line tmpObsLine in lastObs.getLines())
                        {
                            this.saveMe.obstructLine.Remove(tmpObsLine);
                        }
                        this.saveMe.obstructBoxes.Remove(lastObs);
                        lastType = -1;
                    }
                    else if (lastType == 3)
                    {
                        this.saveMe.colBoxes.Remove(lastCol);
                        foreach (Line tmpObsLine in lastObs.getLines())
                        {
                            this.saveMe.obstructLine.Remove(tmpObsLine);
                        }
                        this.saveMe.obstructBoxes.Remove(lastObs);
                        lastType = -1;
                    }
                    this.myGameArea.Invalidate();
                }
            }

        }

    }
}
