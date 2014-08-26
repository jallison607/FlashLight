using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using GameTools.Basic;

namespace MyThreadingTest
{
    /// <summary>
    /// This class is just a double buffered panel
    /// </summary>
    public class GameArea : Panel
    {

        /*
         * Author: Joshua Allison
         * Last Revision Date: 8/26/2014 - Added Comments - Deleted old commented code
         *
         * GameArea
         * This class is just a double buffered panel
         * 
         * 
         */

        //Basic Constructor
        public GameArea()
        {
            //Enable Double Buffering
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint, true);
            //Set Background to white - will be depriciated in implementation as background will be set to an image instead
            this.BackColor = Color.White;
            
        }


        /// <summary>
        /// Updates the top left corner of the panel in the main form
        /// Used to offset the panel and cause the appearnce of the player being centered at all times
        /// </summary>
        /// <param name="tmpOffset"></param>
        public void updateLocation(Point tmpOffset)
        {
            this.Location = tmpOffset;
        }

        //Used to update the size of the GameArea Panel
        //Will be depriciated in implementation as the size will be set to the size of the background image and will not change mid-execution
        public void updateSize(Size tmpSize)
        {
            this.Width = tmpSize.Width;
            this.Height = tmpSize.Height;
        }
    }
}
