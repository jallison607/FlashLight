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
     * Last Revision Date: 8/26/2014 - Added Comments
     * 
     * GameLevel
     * Object used to store/retreive level data
     * 
     */

    /// <summary>
    /// Object used to store/retreive level data
    /// </summary>
    public class GameLevel
    {
        //Path of background image
        private string imagePath = string.Empty;

        //List of collision boxes, Hunter Spawn points, Supernatural Spawn points, Obstruction boxes and obstruction lines
        private List<Rectangle> colBoxes = new List<Rectangle>();
        private List<Rectangle> hunterSpawns = new List<Rectangle>();
        private List<Rectangle> supernaturalSpawns = new List<Rectangle>();
        private List<FancyRectangle> obstructBoxes = new List<FancyRectangle>();
        private List<Line> obstructLines = new List<Line>();

        //Basic Constructor
        //New GameLevel, Bool pass is to provide a signature for this constructor instead of the Estring constructor
        public GameLevel(string tmpPath, bool newLevel)
        {
            //Sets the image Path
            this.imagePath = tmpPath;
        }

        /// <summary>
        /// Constructor used when a decrypted string of the level data exsists
        /// </summary>
        /// <param name="EString"></param>
        public GameLevel(string EString)
        {
            
            //Image Path
            int pathLength = ParseItems.parseIntFrom(EString, 3);
            EString = EString.Substring(3);
            this.imagePath = ParseItems.parseStringFrom(EString, pathLength);
            EString = EString.Substring(pathLength);

            //Col Boxes
            int numOfColBoxes = ParseItems.parseIntFrom(EString, 3);
            for (int i = 0; i < numOfColBoxes;  i++ )
            {
                colBoxes.Add(parseRect(EString.Substring(0, 20)));
                EString = EString.Substring(20);
            }

            //HunterSpawns Boxes
            int numOfHSpawnBoxes = ParseItems.parseIntFrom(EString, 3);
            for (int i = 0; i < numOfHSpawnBoxes; i++)
            {
                hunterSpawns.Add(parseRect(EString.Substring(0,20)));
                EString = EString.Substring(20);
            }

            //SupernaturalSpawns
            int numOfSSpawnBoxes = ParseItems.parseIntFrom(EString, 3);
            for (int i = 0; i < numOfSSpawnBoxes; i++)
            {
                supernaturalSpawns.Add(parseRect(EString.Substring(0, 20)));
                EString = EString.Substring(20);
            }

            //ObstructBoxes
            int numOfObstructBoxes = ParseItems.parseIntFrom(EString, 3);
            for (int i = 0; i < numOfObstructBoxes; i++)
            {
                obstructBoxes.Add(new FancyRectangle(parseRect(EString.Substring(0, 20))));
                EString = EString.Substring(20);
            }

            //Obstruct Lines
            int numOfObstructLines = ParseItems.parseIntFrom(EString, 3);
            for (int i = 0; i < numOfObstructLines; i++)
            {
                this.obstructLines.Add(new Line(EString.Substring(0,20)));
                EString = EString.Substring(20);
            }
        }


        //ParseRect
        //
        //

        //

        /// <summary>
        /// Used in decrypted string constructor
        /// parses a rectangle out of a string in the following formatt
        /// Location.X   + Location.Y    + Rectangle.Width   + Rectangle.Height
        ///   xxxxx      + xxxxx         + xxxxx             + xxxxx
        /// </summary>
        /// <param name="rectEString"></param>
        /// <returns></returns>
        private Rectangle parseRect(string rectEString)
        {
            Point tmpPoint = new Point();
            Size tmpSize = new Size();
            //X & Y position
            tmpPoint.X = ParseItems.parseIntFrom(rectEString, 5);
            rectEString = rectEString.Substring(5);
            tmpPoint.Y = ParseItems.parseIntFrom(rectEString, 5);
            rectEString = rectEString.Substring(5);

            //Width and Height
            tmpSize.Width = ParseItems.parseIntFrom(rectEString, 5);
            rectEString = rectEString.Substring(5);
            tmpSize.Height = ParseItems.parseIntFrom(rectEString, 5);

            //Create rectangle & return
            Rectangle tmpRect = new Rectangle(tmpPoint, tmpSize);
            return tmpRect;
        }

        //#########Encryption Methods
        /// <summary>
        ///Creates an encryptable string in the following format
        ///          EachSpawn + #OfSuperSpawns    + EachSpawn + #OfObstrucBoxes   + EachBox   + #OfObstructLines  + EachLine
        ///          xxx      + x20^n     + xxx           + x20^n     + xxx               + x20^n     + xxx               + x20^n     + xxx               + x16^n
        /// </summary>
        /// <returns></returns>
        public string ToEString()
        {
            string result = string.Empty;
            //Background image path
            result += ParseItems.convertToLength(imagePath.Length, 3);
            result += imagePath;

            //Col Boxes
            string colBoxesData = string.Empty;
            foreach (Rectangle tmpRect in colBoxes)
            {
                colBoxesData += ParseItems.convertToLength(tmpRect.X, 5);
                colBoxesData += ParseItems.convertToLength(tmpRect.Y, 5);
                colBoxesData += ParseItems.convertToLength(tmpRect.Width, 5);
                colBoxesData += ParseItems.convertToLength(tmpRect.Height, 5);
            }
            colBoxesData = ParseItems.convertToLength(colBoxes.Count, 3) + colBoxesData;
            result += colBoxesData;

            //HunterSpawns
            string hunterSpawnsData = string.Empty;
            foreach (Rectangle tmpRect in hunterSpawns)
            {
                hunterSpawnsData += ParseItems.convertToLength(tmpRect.X, 5);
                hunterSpawnsData += ParseItems.convertToLength(tmpRect.Y, 5);
                hunterSpawnsData += ParseItems.convertToLength(tmpRect.Width, 5);
                hunterSpawnsData += ParseItems.convertToLength(tmpRect.Height, 5);
            }
            hunterSpawnsData = ParseItems.convertToLength(hunterSpawns.Count, 3) + hunterSpawnsData;
            result += hunterSpawnsData;

            //supernaturalSpawns
            string supernaturalSpawnsData = string.Empty;
            foreach (Rectangle tmpRect in supernaturalSpawns)
            {
                supernaturalSpawnsData += ParseItems.convertToLength(tmpRect.X, 5);
                supernaturalSpawnsData += ParseItems.convertToLength(tmpRect.Y, 5);
                supernaturalSpawnsData += ParseItems.convertToLength(tmpRect.Width, 5);
                supernaturalSpawnsData += ParseItems.convertToLength(tmpRect.Height, 5);
            }
            supernaturalSpawnsData = ParseItems.convertToLength(supernaturalSpawns.Count, 3) + supernaturalSpawnsData;
            result += supernaturalSpawnsData;

            //obstructBoxes
            string obstructBoxesData = string.Empty;
            foreach (FancyRectangle tmpRect in obstructBoxes)
            {
                obstructBoxesData += ParseItems.convertToLength(tmpRect.getRect().X, 5);
                obstructBoxesData += ParseItems.convertToLength(tmpRect.getRect().Y, 5);
                obstructBoxesData += ParseItems.convertToLength(tmpRect.getRect().Width, 5);
                obstructBoxesData += ParseItems.convertToLength(tmpRect.getRect().Height, 5);
            }
            obstructBoxesData = ParseItems.convertToLength(obstructBoxes.Count, 3) + obstructBoxesData;
            result += obstructBoxesData;

            //obstructLines
            string obstructLinesData = string.Empty;
            foreach (Line tmpLine in obstructLines)
            {
                obstructLinesData += tmpLine.ToEString();
            }
            obstructLinesData = ParseItems.convertToLength(obstructLines.Count, 3) + obstructLinesData;
            result += obstructLinesData;

            return result;
        }


        //#########Getters
        public List<FancyRectangle> getObstructionBoxes()
        {
            return this.obstructBoxes;
        }

        public List<Rectangle> getColboxes()
        {
            return this.colBoxes;
        }

        public List<Line> getObstructionLines()
        {
            return this.obstructLines;
        }

        public Bitmap getBackground()
        {
            return new Bitmap(this.imagePath);
        }

        //####Add/Removers
        public void addColBox(Rectangle tmpCol)
        {
            colBoxes.Add(tmpCol);
        }

        public void removeColBox(Rectangle tmpCol)
        {
            colBoxes.Remove(tmpCol);
        }

        public void addHunterSpawn(Rectangle tmpSpawn)
        {
            this.hunterSpawns.Add(tmpSpawn);
        }

        public void removeHunterSpawn(Rectangle tmpSpawn)
        {
            this.hunterSpawns.Remove(tmpSpawn);
        }

        public void addSupernaturalSpawn(Rectangle tmpSpawn)
        {
            this.supernaturalSpawns.Add(tmpSpawn);
        }

        public void removeSupernaturalSpawn(Rectangle tmpSpawn)
        {
            this.supernaturalSpawns.Remove(tmpSpawn);
        }

        public void addObsBox(FancyRectangle tmpObstruction)
        {
            obstructBoxes.Add(tmpObstruction);
        }

        public void removeObsBox(FancyRectangle tmpObstruction)
        {
            obstructBoxes.Remove(tmpObstruction);
        }

    }
}
