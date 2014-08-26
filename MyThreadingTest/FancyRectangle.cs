using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace MyThreadingTest
{
    /*
     * Author: Joshua Allison
     * Last Revision Date: 8/26/2014 - Added Comments
     * Fancy Rectangle class is used for vision restriction boxes 
     *  -These are areas that the players cannot see through.
     *  -They are used by overlaying them ontop of the background image in the NewLevel editor
     */
    public class FancyRectangle
    {
        private Rectangle _Rect = new Rectangle();
        private List<Line> _Lines = new List<Line>();

        //###Constructors
        //Generic constructor
        public FancyRectangle()
        {

        }

        //Constructor being passed a Rectangle.
        //The lines are then derived from the rectangle edges
        public FancyRectangle(Rectangle tmpRect)
        {
            this._Rect = tmpRect;
            this._Lines = convertRectToLines(tmpRect);
        }

        //###########Other Methods

        /// <summary>
        /// Returns list of Line objects from the rectangle
        /// Derives the lines from the rectangle Edges
        /// </summary>
        /// <param name="tmpRect"></param>
        /// <returns></returns>
        private List<Line> convertRectToLines(Rectangle tmpRect)
        {
            List<Line> tmpList = new List<Line>();
            //Top
            tmpList.Add(new Line(new Point(tmpRect.X, tmpRect.Y), new Point(tmpRect.X + tmpRect.Width, tmpRect.Y)));
            //Right
            tmpList.Add(new Line(new Point(tmpRect.X + tmpRect.Width, tmpRect.Y), new Point(tmpRect.X + tmpRect.Width, tmpRect.Y + tmpRect.Height)));
            //Bottom
            tmpList.Add(new Line(new Point(tmpRect.X + tmpRect.Width, tmpRect.Y + tmpRect.Height), new Point(tmpRect.X, tmpRect.Y + tmpRect.Height)));
            //Left
            tmpList.Add(new Line(new Point(tmpRect.X, tmpRect.Y + tmpRect.Height), new Point(tmpRect.X, tmpRect.Y)));
            return tmpList;
        }


        //Getters
        public Rectangle getRect()
        {
            return this._Rect;
        }

        public List<Line> getLines()
        {
            return this._Lines;
        }

    }
}
