using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace MyThreadingTest
{
    public class FancyRectangle
    {
        private Rectangle _Rect = new Rectangle();
        private List<Line> _Lines = new List<Line>();

        public FancyRectangle()
        {

        }

        public FancyRectangle(Rectangle tmpRect)
        {
            this._Rect = tmpRect;
            this._Lines = convertRectToLines(tmpRect);
        }

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
