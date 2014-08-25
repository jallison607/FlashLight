using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using GameTools.Encryption;
using System.IO;

namespace MyThreadingTest
{
    [Serializable]
    class SavableLevel
    {
        public List<Rectangle> colBoxes = new List<Rectangle>();
        public List<FancyRectangle> obstructBoxes = new List<FancyRectangle>();
        public List<Line> obstructLine = new List<Line>();
        public EncrypterDecrypter levelEncrypter = new EncrypterDecrypter();
        
        public SavableLevel()
        {
            this.colBoxes = new List<Rectangle>();
            this.obstructBoxes = new List<FancyRectangle>();
            this.obstructLine = new List<Line>();
        }

        public SavableLevel(List<Rectangle> tmpCol, List<FancyRectangle> tmpObst, List<Line> tmpObstline)
        {
            
        }

        public bool saveLevel(string LevelName)
        {
            bool saved = false;
            LevelName += ".jlv";

            return saved;
        }

        private string ToEString()
        {
            return "filler";
        }
    }
}
