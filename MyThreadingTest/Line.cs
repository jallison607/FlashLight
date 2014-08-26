using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using GameTools.Basic;

namespace MyThreadingTest
{
    /*
     * Author: Joshua Allison
     * Last Revision Date: 8/26/2014 - Added comments
     * 
     * Line
     * This class is for a basic mathematical line
     *  - Primarly used for vision rays/intersections
     * 
     */ 

    /// <summary>
    /// This class is for a basic mathematical line 
    /// - Primarly used for vision rays/intersections
    /// </summary>
    public class Line
    {
        public Point startPoint;
        private Point endPoint;

        //OptimizationFactor is used to restrict checks for lines within x distance of eachothers start points
        //AKA avoid boxes larger then 200 pixles or increase optimization factor at cost of performance
        public const int optimizationFactor = 200;
        
        //Rise of the line DeltaY
        public double rise;

        //Run of the line DeltaX
        public double run;

        //Line value at x position of 0
        public double baseY;

        //####Constructors

        //Basic Constructor
        public Line()
        {

        }

        //Decrypted String Constructor
        //Used to create a Line from EString - String returned from decrypter/encrypter wrapper
        //
        public Line(String EString)
        {
            //Start Point
            this.startPoint.X = ParseItems.parseIntFrom(EString, 5);
            EString = EString.Substring(4);
            this.startPoint.Y = ParseItems.parseIntFrom(EString, 5);
            EString = EString.Substring(4);

            //End Point
            this.endPoint.X = ParseItems.parseIntFrom(EString, 5);
            EString = EString.Substring(4);
            this.endPoint.Y = ParseItems.parseIntFrom(EString, 5);
        }


        //Start & End Point Constructor
        //
        /// <summary>
        ///Create a line with start of (x1,y1) and end of (x2,y2) 
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        public Line(Point start, Point end)
        {
            //Set start & end points
            this.startPoint = start;
            this.endPoint = end;

            //Calculate Rise, Run & Base
            this.rise = endPoint.Y - startPoint.Y;
            this.run = endPoint.X - startPoint.X;
            this.baseY = startPoint.Y - ((rise / run) * startPoint.X);
        }


        //#######Other Methods
        //ToEString
        /// <summary>
        /// NOTE: Current configuration restricts any given level to 99999x99999 pixels thats a really big background image anyway
        /// If this needs to be changes you will need to update the Line.Line(string EString) and GameLevel.GameLevel(String, EString)
        /// Additionaly each pre-exsisting level will need to be converted - I know terrible flaw....So dont change it and keep your levels a reasonable size
        /// Creates an encryptable string of the Line in the following format
        ///   StartPoint.X    + StartPoint.Y  + EndPoint.X    + EndPoint.Y
        ///     xxxxx            + xxxxx          + xxxxx          + xxxxx
        /// </summary>
        /// <returns>string</returns>
        public string ToEString()
        {
            string result = string.Empty;
            //Start Point
            result += ParseItems.convertToLength(startPoint.X, 5);
            result += ParseItems.convertToLength(startPoint.Y, 5);
            //End Point
            result += ParseItems.convertToLength(endPoint.X, 5);
            result += ParseItems.convertToLength(endPoint.Y, 5);
            return result;
        }

        //UpdateEnd
        //
        /// <summary>
        /// Sets the end of the line to a new location and re-calculates the rise, run and baseY
        /// </summary>
        /// <param name="newEnd"></param>
        public void updateEnd(Point newEnd)
        {
            //Change End
            this.endPoint = newEnd;

            //Recalculate this stuff
            this.rise = endPoint.Y - startPoint.Y;
            this.run = endPoint.X - startPoint.X;
            this.baseY = startPoint.Y - ((rise / run) * startPoint.X);
        }

        /// <summary>
        /// isNear
        /// This is used for checking if the other line's start point is within in the optimization factor distance of this line
        /// </summary>
        /// <param name="tmpLine"></param>
        /// <returns>Bool</returns>
        public bool isNear(Line tmpLine)
        {
            bool isNear = false;

            if (Math.Abs(tmpLine.startPoint.X - this.startPoint.X) < optimizationFactor)
            {
                isNear = true;
            }


            return isNear;
        }

        /// <summary>
        /// Checks if this line intersects with passed line.
        /// Primarly used for vision block detection
        /// </summary>
        /// <param name="otherLine"></param>
        /// <returns>bool</returns>
        public bool intersectsWith(Line otherLine)
        {
            bool intersects = false;
            //Checks if this slope != the other line slope
            if (this.getSlope() != otherLine.getSlope())
            {
                //If the slopes are not == (Aka - parellel) then they would intersect IF they were infinante lines
                intersects = true;
            }

            return intersects;
        }

        /// <summary>
        /// Gets the intersecting point between two lines. Call this AFTER intersectsWith then call hasPoint to ensure it does intersect
        /// </summary>
        /// <param name="otherLine"></param>
        /// <returns>Point</returns>
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

        /// <summary>
        /// Used to check if a line has a particular point. Typically it is used after getIntersection to verify that the point is included
        /// in the limited line(Required because mathematically lines do not have start & end points like these lines do. These are really "Line Segments")
        /// </summary>
        /// <param name="tmpPoint"></param>
        /// <returns></returns>
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


        //##########Getters
        /// <summary>
        /// Calculates the slope of a line (Rise/Run) and returns it
        /// </summary>
        /// <returns>double</returns>
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
