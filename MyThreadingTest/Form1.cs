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
    public partial class Form1 : Form
    {
        GameArea myGameArea;
        PlayerCharacter thePlayer;
        List<Rectangle> colBoxes = new List<Rectangle>();
        List<FancyRectangle> obstructBoxes = new List<FancyRectangle>();
        List<Line> obstructLine = new List<Line>();
        Rectangle tmpDrawnRectangle = new Rectangle();
        bool Drawing = false;
        bool DrawingCol = true;
        bool DrawingBoth = false;
        bool allVisable = false;
        List<Point> maskPoly = new List<Point>();


        //######Constructor
        public Form1()
        {
            InitializeComponent();

            this.Controls.Remove(pGameArea);
            foreach (Control tmpControl in pGameArea.Controls)
            {
                if (tmpControl.Name.ToString().Substring(0, 4) == "col_")
                {
                    colBoxes.Add(new Rectangle(tmpControl.Location, new Size(tmpControl.Width, tmpControl.Height)));
                }
            }

            thePlayer = new PlayerCharacter(this.obstructLine);
            myGameArea = new GameArea();
            this.Controls.Add(myGameArea);

            myGameArea.Visible = true;
            myGameArea.Paint += new System.Windows.Forms.PaintEventHandler(this.PaintGameArea);
            myGameArea.MouseDown += new System.Windows.Forms.MouseEventHandler(this.StartDrawCustomRectangle);
            myGameArea.MouseMove += new System.Windows.Forms.MouseEventHandler(this.DrawCustomRectangle);
            myGameArea.MouseUp += new System.Windows.Forms.MouseEventHandler(this.StopDrawingRectangle);
            this.LostFocus += new System.EventHandler(stopMovement);
            //someRandomColisionRectangles();
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
                Point newPoint = new Point(this.thePlayer.getXAxis(), thePlayer.getYAxis());
                int xVel = thePlayer.getXVelocityAxis();
                int yVel = thePlayer.getYVelocityAxis();
                int speed = thePlayer.getSpeed();
                if (xVel != 0)
                {
                    newPoint.X += xVel * speed;
                }

                if (yVel != 0)
                {
                    newPoint.Y += yVel * speed;
                }

                Point pointTry = newPoint;
                int tmpSpeed = speed;
                while (!this.thePlayer.updatePlayerLocation(pointTry, colBoxes.ToArray(), myGameArea.Width, myGameArea.Height, obstructLine) && tmpSpeed > 1)
                {

                    tmpSpeed--;
                    pointTry.X = pointTry.X - (xVel * speed) + (xVel * tmpSpeed);
                    pointTry.Y = pointTry.Y - (yVel * speed) + (yVel * tmpSpeed);

                }


                lock (myGameArea)
                {
                    myGameArea.Invalidate();
                }

                Thread.Sleep(50);

            }
        }

        //###########Events
        //GameArea Events
        private void PaintGameArea(object sender, System.Windows.Forms.PaintEventArgs e)
        {

            e.Graphics.FillRectangle(Brushes.Blue, thePlayer.getPlayerRect());
            foreach (Rectangle tmpCol in colBoxes)
            {
                e.Graphics.FillRectangle(Brushes.Black, tmpCol);
            }

            //e.Graphics.FillPolygon(Brushes.BlueViolet, this.thePlayer.getViewPolyPie());

            if (allVisable)
            {
                foreach (FancyRectangle tmpObs in obstructBoxes)
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
                e.Graphics.FillPolygon(Brushes.Red, this.thePlayer.getViewPolyPie());
            }
            else
            {
                CreateMaskPoly();
                //e.Graphics.FillPolygon(Brushes.Red, this.thePlayer.getViewPolyPie());
                e.Graphics.FillPolygon(Brushes.Black, this.maskPoly.ToArray());
                //e.Graphics.FillPolygon(Brushes.Black, this.maskPoly.ToArray());
                e.Graphics.FillPolygon(new SolidBrush(Color.FromArgb(50, 0, 0, 0)), this.thePlayer.getFalloutPie());
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

        private void stopMovement(object sender, EventArgs e)
        {
            this.thePlayer.updateMovementDirection(new Point(0, 0));
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
            if(!thePlayer.playerIntersectsWith(tmpDrawnRectangle)){
                if (DrawingBoth)
                {
                    colBoxes.Add(tmpDrawnRectangle);
                    FancyRectangle tmpFancy = new FancyRectangle(tmpDrawnRectangle);
                    obstructBoxes.Add(tmpFancy);
                    List<Line> tmpLines = tmpFancy.getLines();
                    foreach (Line tmpLn in tmpLines)
                    {
                        this.obstructLine.Add(tmpLn);
                    }
                }
                else if (DrawingCol)
                {
                    colBoxes.Add(tmpDrawnRectangle);
                }
                else
                {
                    FancyRectangle tmpFancy = new FancyRectangle(tmpDrawnRectangle);
                    obstructBoxes.Add(tmpFancy);
                    List<Line> tmpLines = tmpFancy.getLines();
                    foreach (Line tmpLn in tmpLines)
                    {
                        this.obstructLine.Add(tmpLn);
                    }
                }
            }
            tmpDrawnRectangle = new Rectangle();
            
        }
        
        //KeyBoard Events        
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            String keyReleased = e.KeyCode.ToString();
            Point tmpNewDirection = new Point(this.thePlayer.getXVelocityAxis(), this.thePlayer.getYVelocityAxis());

            if ((keyReleased == "W" || keyReleased == "Up") && tmpNewDirection.Y < 0)
            {
                tmpNewDirection.Y = 0;
            }
            else if ((keyReleased == "S" || keyReleased == "Down") && tmpNewDirection.Y > 0)
            {
                tmpNewDirection.Y = 0;
            }
            else if ((keyReleased == "A" || keyReleased == "Left") && tmpNewDirection.X < 0)
            {
                tmpNewDirection.X = 0;
            }
            else if ((keyReleased == "D" || keyReleased == "Right") && tmpNewDirection.X > 0)
            {
                tmpNewDirection.X = 0;
            }

            thePlayer.updateMovementDirection(tmpNewDirection);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            String keyPressed = e.KeyCode.ToString();
            Point tmpNewDirection = new Point(this.thePlayer.getXVelocityAxis(), this.thePlayer.getYVelocityAxis());

            if (keyPressed == "W" || keyPressed == "Up")
            {
                tmpNewDirection.Y = -1;
                tmpNewDirection.X = 0;
            }
            else if (keyPressed == "S" || keyPressed == "Down")
            {
                tmpNewDirection.Y = 1;
                tmpNewDirection.X = 0;
            }
            else if (keyPressed == "A" || keyPressed == "Left")
            {
                tmpNewDirection.X = -1;
                tmpNewDirection.Y = 0;
            }
            else if (keyPressed == "D" || keyPressed == "Right")
            {
                tmpNewDirection.X = 1;
                tmpNewDirection.Y = 0;
            }
            else if (keyPressed == "C")
            {
                this.DrawingCol = !this.DrawingCol;
            }
            else if (keyPressed == "B")
            {
                this.DrawingBoth = !this.DrawingBoth;
            }
            else if (keyPressed == "P")
            {
                Point[] tmpPoints = this.thePlayer.getViewPolyPie();
                string points = string.Empty;
                foreach (Point tmpPoint in tmpPoints)
                {
                    points += tmpPoint.ToString() + "\r\n";
                }
                MessageBox.Show(points);
            }
            else if (keyPressed == "V")
            {
                this.allVisable = !this.allVisable;
            }
            else if (keyPressed == "L")
            {
                new LineTest().Show();
            }
            else if (keyPressed == "N")
            {
                new NewLevel().Show();
            }

            thePlayer.updateMovementDirection(tmpNewDirection);
        }

        //########## Misc Methods
        private void CreateMaskPoly()
        {
            lock (this.maskPoly)
            {
                this.maskPoly = new List<Point>();
                double playerRotation = this.thePlayer.getPlayerRotation();
                Point playerLocation = this.thePlayer.getPlayerCenter();
                Point[] ViewPie = this.thePlayer.getViewPolyPie();
                //2Pi(right),pi/2(down),pi(left),3pi/2(up)
                //this.polyTest.Add(new Point(this.myGameArea.Width, 0));
                if (playerRotation == Math.PI * 2)
                {
                    this.maskPoly.Add(new Point(0, this.myGameArea.Height));
                    this.maskPoly.Add(new Point(0, playerLocation.Y));
                    foreach (Point tmpPoint in ViewPie)
                    {
                        this.maskPoly.Add(tmpPoint);
                    }
                    this.maskPoly.Add(new Point(0, playerLocation.Y));
                    this.maskPoly.Add(new Point(0, 0));
                    this.maskPoly.Add(new Point(this.myGameArea.Width, 0));
                    this.maskPoly.Add(new Point(this.myGameArea.Width, this.myGameArea.Height));
                    this.maskPoly.Add(new Point(0, this.myGameArea.Height));
                }
                else if (playerRotation == Math.PI/2)
                {
                    this.maskPoly.Add(new Point(0, 0));
                    this.maskPoly.Add(new Point(playerLocation.X,0));
                    foreach (Point tmpPoint in ViewPie)
                    {
                        this.maskPoly.Add(tmpPoint);
                    }
                    this.maskPoly.Add(new Point(playerLocation.X, 0));
                    this.maskPoly.Add(new Point(this.myGameArea.Width, 0));
                    this.maskPoly.Add(new Point(this.myGameArea.Width, this.myGameArea.Height));
                    this.maskPoly.Add(new Point(0, this.myGameArea.Height));
                    this.maskPoly.Add(new Point(0, 0));
                }
                else if (playerRotation == Math.PI)
                {
                    this.maskPoly.Add(new Point(this.myGameArea.Width, 0));
                    this.maskPoly.Add(new Point(this.myGameArea.Width, playerLocation.Y));
                    foreach (Point tmpPoint in ViewPie)
                    {
                        this.maskPoly.Add(tmpPoint);
                    }
                    this.maskPoly.Add(new Point(this.myGameArea.Width, playerLocation.Y));
                    this.maskPoly.Add(new Point(this.myGameArea.Width, this.myGameArea.Height));
                    this.maskPoly.Add(new Point(0, this.myGameArea.Height));
                    this.maskPoly.Add(new Point(0, 0));
                    this.maskPoly.Add(new Point(this.myGameArea.Width, 0));
                }
                else if (playerRotation == (Math.PI*3)/2)
                {
                    this.maskPoly.Add(new Point(this.myGameArea.Width, this.myGameArea.Height));
                    this.maskPoly.Add(new Point(playerLocation.X,this.myGameArea.Height));
                    foreach (Point tmpPoint in ViewPie)
                    {
                        this.maskPoly.Add(tmpPoint);
                    }
                    this.maskPoly.Add(new Point(playerLocation.X, this.myGameArea.Height));
                    this.maskPoly.Add(new Point(0, this.myGameArea.Height));
                    this.maskPoly.Add(new Point(0, 0));
                    this.maskPoly.Add(new Point(this.myGameArea.Width, 0));
                    this.maskPoly.Add(new Point(this.myGameArea.Width, this.myGameArea.Height));
                }
            }

        }

        private void someRandomColisionRectangles()
        {
            Random r = new Random();
            for (int i = 0; i < 10; i++)
            {
                int width = r.Next(0, myGameArea.Width / 3);
                int height = r.Next(0, myGameArea.Height / 3);
                int x = r.Next(0, myGameArea.Width - width);
                int y = r.Next(0, myGameArea.Height - height);
                this.colBoxes.Add(new Rectangle(x, y, width, height));
            }

        }

    }
}



