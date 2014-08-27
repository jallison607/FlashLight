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

    public partial class LineTest : Form
    {
        private List<Rectangle> listOfRectangles = new List<Rectangle>();
        private List<Line> listOfLines = new List<Line>();
        private List<Point> intersections = new List<Point>();
        private Dictionary<Point, List<Line>> lineDictionary = new Dictionary<Point,List<Line>>();
        private Line activeLine = new Line();
        private Rectangle activeRect = new Rectangle();
        private GameArea myGameArea2;
        Label coords = new Label();
        private bool drawingLine = true;
        private bool drawingShape = false;

        public LineTest()
        {
            InitializeComponent();
            myGameArea2 = new GameArea();
            this.panel2.Controls.Add(myGameArea2);

            myGameArea2.Visible = true;
            myGameArea2.Paint += new System.Windows.Forms.PaintEventHandler(this.PaintGameArea);
            myGameArea2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.StartDrawShape);
            myGameArea2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.DrawShape);
            myGameArea2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.StopDrawShape);

            myGameArea2.Controls.Add(coords);
            coords.Visible = true;

            Thread t = new Thread(update);
            t.IsBackground = true;
            t.Start();
        }

        //########Update Method
        private void update()
        {
            while (true)
            {
                myGameArea2.Invalidate();
                Thread.Sleep(50);
            }
        }

        //########Events
        //***Game Area Events
        private void PaintGameArea(object sender, System.Windows.Forms.PaintEventArgs e)
        {

            //lblUpdate.Text = "Entered Paint";
            //Thread.Sleep(5);
            lblUpdate.Text = "Rects: " + this.listOfRectangles.Count
                + "\r\nLines: " + this.listOfLines.Count
                + "\r\nDrawing Shape: " + this.drawingShape
                + "\r\nDrawing Line: " + this.drawingLine;
            
            //Paint stuff
            foreach(Rectangle tmpRect in this.listOfRectangles){
                e.Graphics.DrawRectangle(Pens.Black, tmpRect);
                lblUpdate.Text = "Updating rects";
            }

            foreach (Line tmpLine in this.listOfLines)
            {

                e.Graphics.DrawLine(Pens.Black, tmpLine.startPoint, tmpLine.getEnd());
                lblUpdate.Text = "Updating lines";
            }

            foreach (Point tmpPoint in this.intersections)
            {
                Rectangle tmpRect = new Rectangle(tmpPoint.X -5, tmpPoint.Y -5,10,10);
                e.Graphics.DrawEllipse(Pens.Red, tmpRect);
            }

            if (this.drawingShape)
            {
                if (this.drawingLine)
                {
                    e.Graphics.DrawLine(Pens.Black, this.activeLine.startPoint, this.activeLine.getEnd());
                }
                else
                {
                    e.Graphics.DrawRectangle(Pens.Black, this.activeRect);
                }
            }

        }

        private void StartDrawShape(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            this.drawingShape = true;
            if (drawingLine)
            {
                this.activeLine.startPoint = e.Location;
            }
            else
            {
                
                this.activeRect.Location = e.Location;

            }
        }

        private void StopDrawShape(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            this.drawingShape = false;
            if (drawingLine)
            {
                this.listOfLines.Add(this.activeLine);
                //Depriciated for y=mx+b
                //this.addLineToIntersectionDictionary(this.activeLine);
                this.intersections = getIntersectionsOfLine(this.activeLine);
                this.lblStatus.Text = "Line saved \r\n Waiting for input";
            }
            else
            {
                this.listOfRectangles.Add(this.activeRect);
                this.lblStatus.Text = "Rect saved \r\n Waiting for input";
            }

            this.activeRect = new Rectangle();
            this.activeLine = new Line();
        }

        private void DrawShape(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (this.drawingShape)
            {
                if (this.drawingLine)
                {
                    this.activeLine.endPoint = (new Point(e.X, e.Y));
                    this.lblStatus.Text = "Drawing a line";
                }
                else
                {
                    this.activeRect.Width = e.X - activeRect.X;
                    this.activeRect.Height = e.Y - this.activeRect.Y;
                    this.lblStatus.Text = "Drawing a Rect";
                }
                this.coords.Text = e.Location.ToString();
                this.coords.Location = new Point(e.X + 5, e.Y + 5);
            }


        }

        //***Radial Checkbox Events
        private void rRect_CheckedChanged(object sender, EventArgs e)
        {
            if (rRect.Checked)
            {
                this.drawingLine = false;
            }
        }

        private void rLine_CheckedChanged(object sender, EventArgs e)
        {
            if (rLine.Checked)
            {
                this.drawingLine = true;
            }
        }

        //***Button Events
        private void btnTest_Click(object sender, EventArgs e)
        {

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.listOfLines.Clear();
            this.listOfRectangles.Clear();
            this.lineDictionary.Clear();
            this.intersections.Clear();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //##########Other Methods
        private List<Point> findPointsOfIntersection()
        {
            List<Point> intersections = new List<Point>();

            return intersections;
        }

       /*
        * Depriciated code. Replaced by checking for intersection with y=mx+b 
        * 
        * 
        * private void addLineToIntersectionDictionary(Line tmpLine)
        {
            //MessageBox.Show(tmpLine.occupiedPoints.Count.ToString());            
            foreach (Point tmpPoint in tmpLine.occupiedPoints)
            {
                lock (this.lineDictionary)
                {
                    List<Line> lineList = new List<Line>();
                    bool hasPoint = this.lineDictionary.ContainsKey(tmpPoint);
                    if (hasPoint)
                    {
                        this.lineDictionary[tmpPoint].Add(tmpLine);
                    }else if (!hasPoint)
                    {
                        lineList = new List<Line>();
                        lineList.Add(tmpLine);
                        this.lineDictionary.Add(tmpPoint, lineList);
                    }
                }
            }

        }*/

        private List<Point> getIntersections()
        {
            List<Point> tmpResults = new List<Point>();
            foreach (KeyValuePair<Point, List<Line>> tmpResult in this.lineDictionary)
            {
                if (tmpResult.Value.Count > 1)
                {
                    tmpResults.Add(tmpResult.Key);
                    Logger.Text += "\r\n" + tmpResult.Key;
                }
                else
                {
                    Logger.Text += "\r\n" + tmpResult.Key;
                }
            }


            return tmpResults;
        }
        private List<Point> getIntersectionsOfLine(Line tmpLine)
        {
            List<Point> tmpResults = new List<Point>();
            foreach (Line tmpLine2 in listOfLines)
            {
                if (tmpLine != tmpLine2)
                {
                    if (tmpLine.intersectsWith(tmpLine2))
                    {
                        Point tmpPoint = tmpLine.getIntersection(tmpLine2);
                        if(tmpLine.hasPoint(tmpPoint) && tmpLine2.hasPoint(tmpPoint)){
                            tmpResults.Add(tmpPoint);
                        }
                    }
                }
            }
            return tmpResults;


            //Old Broken way
            /*string logOfPoints = string.Empty;
            List<Point> tmpResults = new List<Point>();
            foreach (Point tmpPoint in tmpLine.occupiedPoints)
            {
                if (this.lineDictionary.ContainsKey(tmpPoint) && this.lineDictionary[tmpPoint].Count > 1)
                {
                    tmpResults.Add(tmpPoint);
                }
                logOfPoints += tmpPoint + "\r\n";
            }
            Logger.Text = logOfPoints;
            */
            
        }

    }
    /*
    public class Line
     {
         public Point startPoint;
         private Point endPoint;
         public double rise;
         public double run;
         public double baseY;
         public List<Point> occupiedPoints = new List<Point>();

         public Line()
         {

         }

         public Line(Point start, Point end)
         {
             this.startPoint = start;
             this.endPoint = end;
             this.rise = endPoint.Y - startPoint.Y;
             this.run = endPoint.X - startPoint.X;
             this.baseY = startPoint.Y - ((rise / run) * startPoint.X);
         }

         public void updateEnd(Point newEnd)
         {
             this.endPoint = newEnd;
             this.rise = endPoint.Y - startPoint.Y;
             this.run = endPoint.X - startPoint.X;
             this.baseY = startPoint.Y - ((rise / run) * startPoint.X);
         }

         public bool intersectsWith(Line otherLine)
         {
             bool intersects = false;
             if (this.getSlope() != otherLine.getSlope())
             {
                 intersects = true;
             }

             return intersects;
         }

         public Point getIntersection(Line otherLine)
         {
             int x = (int)((otherLine.getBase() - this.getBase())/(this.getSlope() - otherLine.getSlope()));
             int y = (int)((this.getSlope() * x) + this.getBase());

             return new Point(x, y);
         }

         public bool hasPoint(Point tmpPoint)
         {
             bool isIn = false;

             if (run >= 0)
             {
                 if (tmpPoint.X >= this.startPoint.X && tmpPoint.X <= this.endPoint.X)
                 {
                     isIn = true;
                 }
             }
             else
             {
                 if (tmpPoint.X <= this.startPoint.X && tmpPoint.X >= this.endPoint.X)
                 {
                     isIn = true;
                 }
             }

             return isIn;
         }

         private bool isEqualTo(Point variable, Point compare, int accuracy)
         {
             bool isEqual = false;
             if (variable.Y >= (compare.Y - accuracy) && variable.Y <= (compare.Y + accuracy))
             {
                 isEqual = true;
             }
             return isEqual;
         }

         public double getSlope()
         {
             return this.rise / this.run;
         }

         public double getBase()
         {
             return this.baseY;
         }

         public Point getEnd()
         {
             return this.endPoint;
         }

     }
    */
}
    
