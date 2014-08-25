using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace MyThreadingTest
{
    public class Line
    {
        public Point startPoint;
        private Point endPoint;
        private const int optimizationFactor = 200;
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

        public bool isNear(Line tmpLine)
        {
            bool isNear = false;

            if (Math.Abs(tmpLine.startPoint.X - this.startPoint.X) < optimizationFactor)
            {
                isNear = true;
            }


            return isNear;
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
            int x = 0;
            int y = 0;
            if (this.startPoint.X == this.endPoint.X)
            {
                x = this.startPoint.X;
                y = (int)((otherLine.getSlope() * x) + otherLine.getBase());
            }
            else if (otherLine.startPoint.X == otherLine.endPoint.X)
            {
                x = otherLine.startPoint.X;
                y = (int)((this.getSlope() * x) + this.getBase());
            }
            else if (this.startPoint.Y == this.endPoint.Y)
            {
                y = this.startPoint.Y;
                x = (int)((y - otherLine.getBase()) / otherLine.getSlope());
            }
            else if(otherLine.startPoint.Y == otherLine.endPoint.Y)
            {
                y = otherLine.startPoint.Y;
                x = (int)((y - this.getBase()) / this.getSlope());
            }
            else
            {
                x = (int)((otherLine.getBase() - this.getBase()) / (this.getSlope() - otherLine.getSlope()));
                y = (int)((this.getSlope() * x) + this.getBase());
            }
            return new Point(x, y);
        }

        public bool hasPoint(Point tmpPoint)
        {
            bool isInX = false;
            bool isInY = false;
            bool isIn = false;
            if (run >= 0)
            {
                if (tmpPoint.X >= this.startPoint.X && tmpPoint.X <= this.endPoint.X)
                {
                    isInX = true;
                }
            }
            else
            {
                if (tmpPoint.X >= this.endPoint.X && tmpPoint.X <= this.startPoint.X)
                {
                    isInX = true;
                }
            }

            if (rise >= 0)
            {
                if (tmpPoint.Y >= this.startPoint.Y && tmpPoint.Y <= this.endPoint.Y)
                {
                    isInY = true;
                }
            }
            else
            {
                if (tmpPoint.Y >= this.endPoint.Y && tmpPoint.Y <= this.startPoint.Y)
                {
                    isInY = true;
                }
            }

            if (isInY && isInX)
            {
                isIn = true;
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
}
