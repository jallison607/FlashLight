using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace MyThreadingTest
{
    class PlayerCharacter
    {
        private Rectangle playerRect;
        private List<Point> viewPolyPie = new List<Point>();
        private List<Point> falloutPie = new List<Point>();
        private int viewDistance = 75;
        private int viewDetail = 16;
        private double radRotation; //2Pi(right),pi/2(down),pi(left),3pi/2(up)
        private Color playerColor;

        private object movementBaton = new object();
        private object rectBaton = new object();
        private object viewBaton = new object();
        private int xAxisMoving;
        private int yAxisMoving;
        private int speed = 4;

        public PlayerCharacter(List<Line> tmpObstructions)
        {
            playerRect = new Rectangle(new Point(0,0),new Size(25,25));
            playerColor = Color.Blue;
            xAxisMoving = 0;
            yAxisMoving = 0;
            radRotation = Math.PI * 2;
            updateViewPolyPie(tmpObstructions);

        }
        /*
         *updates view poly pie on player location
         *                 x
         *              xxxxx
         *           xxxxxxxxx
         * [Player]xxxxxxxxxxxx
         *           xxxxxxxxx
         *              xxxxx
         *                 x
         */
        private void updateViewPolyPie(List<Line> tmpObstructions)
        {
            //Main Pie
            Point currentPos = new Point();
            Point largePos = new Point();
            Point smallPos = new Point();
            double viewRadians = Math.PI / 6;
            int width;
            int height;
            lock (rectBaton){
                width = playerRect.Width;
                height = playerRect.Height;
                currentPos.X = playerRect.Location.X + (width/2);
                currentPos.Y = playerRect.Location.Y + (height/2);
            }

            if (radRotation == Math.PI * 2)
            {
                largePos = new Point(currentPos.X - (width / 2), currentPos.Y);
                smallPos = new Point(currentPos.X + (width / 2), currentPos.Y);
            }
            else if (radRotation == Math.PI / 2)
            {
                largePos = new Point(currentPos.X, currentPos.Y - (height / 2));
                smallPos = new Point(currentPos.X, currentPos.Y + (height / 2));
            }
            else if (radRotation == Math.PI)
            {
                largePos = new Point(currentPos.X + (width / 2), currentPos.Y);
                smallPos = new Point(currentPos.X - (width / 2), currentPos.Y);
            }
            else if (radRotation == (Math.PI * 3) / 2)
            {
                largePos = new Point(currentPos.X, currentPos.Y + (height / 2));
                smallPos = new Point(currentPos.X, currentPos.Y - (height / 2));
            }

            double tmpDeg = radRotation - viewRadians;
            double incrementor = (Math.PI/3) / viewDetail;
            int tmpViewFalloffDistance = this.viewDistance + 35;

            this.viewPolyPie.Clear();
            this.viewPolyPie.Add(largePos);
            for (int i = 0; i < viewDetail; i++)
            {
                bool checkAgain = true;
                Point newPoint = new Point();
                int viewTries = 0;
                while (checkAgain)
                {
                    newPoint.X = (int)(largePos.X + ((tmpViewFalloffDistance - viewTries) * Math.Cos(tmpDeg)));
                    newPoint.Y = (int)(largePos.Y + ((tmpViewFalloffDistance - viewTries) * Math.Sin(tmpDeg)));


                    //### WORK HERE ### NEED MAGIC to find out if ray is blocked by obstruction line in tmpObstructions and if it is then shorten ray
                    Line tmpRay = new Line(largePos, newPoint);
                    bool intersects = false;
                    List<Line> intersections = new List<Line>();
                    foreach (Line tmpLine in tmpObstructions)
                    {
                        if(tmpLine.isNear(tmpRay)){
                            if (tmpRay.intersectsWith(tmpLine))
                            {
                                Point iPoint = tmpRay.getIntersection(tmpLine);
                                if (tmpRay.hasPoint(iPoint) && tmpLine.hasPoint(iPoint))
                                {
                                    intersects = true;
                                }
                            }
                        }
                    }
                    if (intersects && viewTries != tmpViewFalloffDistance)
                    {
                        viewTries++;
                    }else
                    {
                        checkAgain = false;
                    }
                    
                }
                this.viewPolyPie.Add(newPoint);
                tmpDeg += incrementor;
            }
            this.viewPolyPie.Add(largePos);

            //Fallout Pie //For shadowing ////2Pi(right),pi/2(down),pi(left),3pi/2(up)

            tmpDeg = radRotation - viewRadians;
            this.falloutPie.Clear();
            this.falloutPie.Add(smallPos);
            for (int i = 0; i < viewDetail; i++)
            {
                Point newPoint = new Point();
                newPoint.X = (int)(smallPos.X + (this.viewDistance * Math.Cos(tmpDeg)));
                newPoint.Y = (int)(smallPos.Y + (this.viewDistance * Math.Sin(tmpDeg)));
                this.falloutPie.Add(newPoint);
                tmpDeg += incrementor;
            }
            this.falloutPie.Add(smallPos);
            foreach (Point tmpViewPoint in this.viewPolyPie)
            {
                this.falloutPie.Add(tmpViewPoint);
            }
            this.falloutPie.Add(smallPos);
        }

        public int getSpeed()
        {
            lock (movementBaton)
                return this.speed;
            
        }

        public int getXVelocityAxis()
        {
            lock(movementBaton)
                return this.xAxisMoving;
        }

        public int getYVelocityAxis()
        {
            lock (movementBaton)
                return this.yAxisMoving;
        }

        public int getXAxis()
        {
            lock (rectBaton)
                return this.playerRect.X;
        }

        public int getYAxis()
        {
            lock (rectBaton)
                return this.playerRect.Y;
        }

        public void updateMovementDirection(Point tmpPoint)
        {
            lock (movementBaton)
            {
                this.xAxisMoving = tmpPoint.X;
                this.yAxisMoving = tmpPoint.Y;
            }
            updateRotation();
        }

        public void updatePlayerLocation(Point tmpPoint, List<Line> tmpObstructions)
        {
            lock (rectBaton)
            {
                this.playerRect.X = tmpPoint.X;
                this.playerRect.Y = tmpPoint.Y;
            }
            updateViewPolyPie(tmpObstructions);
        }

        public bool updatePlayerLocation(Point tmpPoint, Rectangle[] colBox, int canvasWidth, int canvasHeight, List<Line> tmpObstructions)
        {
            Rectangle tmpPlayerRect = new Rectangle();
            bool validMovement = true;
            lock (rectBaton)
            {
                tmpPlayerRect.X = tmpPoint.X;
                tmpPlayerRect.Y = tmpPoint.Y;
                tmpPlayerRect.Width = playerRect.Width;
                tmpPlayerRect.Height = playerRect.Height;
            }

            foreach (Rectangle tmpRect in colBox)
            {
                bool tmpColides = tmpRect.IntersectsWith(tmpPlayerRect);
                if(tmpColides)
                {
                    validMovement = false;
                }
            }

            if (isOutOfBounds(tmpPoint, canvasWidth, canvasHeight))
            {
                validMovement = false;
            }
            
            if (validMovement)
            {
                lock (rectBaton)
                {
                    playerRect.X = tmpPlayerRect.X;
                    playerRect.Y = tmpPlayerRect.Y;
                }
            }

            updateViewPolyPie(tmpObstructions);
            return validMovement;
        }

        private bool isOutOfBounds(Point newPoint, int width, int height)
        {
            bool outOfBounds = false;
            if(newPoint.X < 0 || newPoint.Y < 0){
                outOfBounds = true;
            }
            
            lock(rectBaton){
                if((newPoint.X + this.playerRect.Width) > width || (newPoint.Y + this.playerRect.Height) > height){
                    outOfBounds = true;
                }
            }
            
            return outOfBounds;
        }

        private void updateRotation()
        {
            lock(this.movementBaton){
                if (this.xAxisMoving == 1)
                {
                    //Right
                    this.radRotation = Math.PI * 2;
                }
                else if (this.xAxisMoving == -1)
                {
                    //Left
                    this.radRotation = Math.PI;
                }
                else if (this.yAxisMoving == 1)
                {
                    //Down
                    this.radRotation = Math.PI / 2;
                }
                else if (this.yAxisMoving == -1)
                {
                    //Up
                    this.radRotation = (Math.PI * 3)/2;
                }
            }
        }

        public Rectangle getPlayerRect()
        {
            lock (rectBaton)
                return this.playerRect;
        }

        public Color getFillColor()
        {
            return this.playerColor;
        }

        public Point[] getViewPolyPie()
        {
            return this.viewPolyPie.ToArray();
        }

        public Point[] getFalloutPie()
        {
            return this.falloutPie.ToArray();
        }

        public bool playerIntersectsWith(Rectangle tmpRect)
        {
            bool intersects = false;
            lock (rectBaton)
            {
                intersects = playerRect.IntersectsWith(tmpRect);
            }


            return intersects;
        }

        public Point getPlayerCenter()
        {
            Point tmpPoint = new Point();
            lock (rectBaton)
            {
                tmpPoint.X = this.playerRect.X + (this.playerRect.Width / 2);
                tmpPoint.Y = this.playerRect.Y + (this.playerRect.Height / 2);
            }
            return tmpPoint;
        }

        public double getPlayerRotation()
        {
            double rotation;
            lock (viewBaton)
            {
                rotation = this.radRotation;
            }
            return rotation;
        }
        

    }
}
