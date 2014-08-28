using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using GameTools.Basic;

namespace MyThreadingTest
{
    public class Portal
    {
        private int _portalID;
        private int _linkedPortalID;
        private Rectangle _portalRect;

        public int portalID
        {
            get { return _portalID; }
            private set{_portalID = value;}
        }
        public int linkedPortalID
        {
            get { return _linkedPortalID; }
            set { _linkedPortalID = value; }
        }
        public Rectangle portalRect
        {
            get { return _portalRect; }
            private set { _portalRect = value; }
        }

        public Portal(int tmpPortalID, int tmpLinkedID,Rectangle tmpRect)
        {
            this.portalID = tmpPortalID;
            this.linkedPortalID = tmpLinkedID;
            this.portalRect = tmpRect;
        }

        public Portal(string EString)
        {
            this.portalID = ParseItems.parseIntFrom(EString, 3);
            EString = EString.Substring(3);

            this.linkedPortalID = ParseItems.parseIntFrom(EString, 3);
            EString = EString.Substring(3);

            Rectangle tmpRect = new Rectangle();
            tmpRect.X = ParseItems.parseIntFrom(EString, 5);
            EString = EString.Substring(5);

            tmpRect.Y = ParseItems.parseIntFrom(EString, 5);
            EString = EString.Substring(5);

            tmpRect.Width = ParseItems.parseIntFrom(EString, 5);
            EString = EString.Substring(5);

            tmpRect.Height = ParseItems.parseIntFrom(EString, 5);
            EString = EString.Substring(5);

            this.portalRect = tmpRect;

        }

        /// <summary>
        /// Creates 26 character long string of all Portal data, To reverse pass into Portal(EString) constructor
        /// </summary>
        /// <returns></returns>
        public string ToEString()
        {
            string result = string.Empty;

            result += ParseItems.convertToLength(_portalID, 3);
            result += ParseItems.convertToLength(_linkedPortalID, 3);

            result += ParseItems.convertToLength(_portalRect.X, 5);
            result += ParseItems.convertToLength(_portalRect.Y, 5);
            result += ParseItems.convertToLength(_portalRect.Width, 5);
            result += ParseItems.convertToLength(_portalRect.Height, 5);

            return result;
        }

    }
}
