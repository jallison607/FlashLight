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
    /*
     * Author: Joshua Allison
     * Last Revision: 8/26/2014 - Added Comments
     * 
     * Generic Testing Grounds 
     * This form is used to test out methods and features that will be implemented in other classes
     * Currently it spawns the player in an empty GameArea with a flashlight mask
     * Press WASD or up, down, right, left to move
     * Press V to toggle the flashlight mask
     * Press N to open New Level Settings gui
     * Pres B to toggle between Colision Drawing & Collision/Vision Block Drawing - In Implementation most Collision(Such as walls) should also have vision blocking
     * Press C to toggle between Colision Drawing & Vision Block Drawing - May be usefull for Windows/Grates. Things too small to pass through but large
     *  enough to see through (Possibly allow Ghosts to pass through where ever there is not vision blocking)
     * 
     * Click and drag to draw whatever is toggled on Only dragging down to the right has been implemented
     * 
     */
    public partial class Form1 : Form
    {
        //Game Area is a panel with Double buffering
        GameArea myGameArea;
        PlayerCharacter thePlayer;

        //Point used to offset the panel (Making it appear like the player is always in the center of the window
        Point _Offset = new Point(256,256);

        //List of Collision Boxes
        List<Rectangle> colBoxes = new List<Rectangle>();

        //List of Vision Obstruction Boxes
        List<FancyRectangle> obstructBoxes = new List<FancyRectangle>();

        //List of Vision Obstruction Lines
        List<Line> obstructLine = new List<Line>();

        //Currently Drawing Rectangle (The semi-transparent rectangle that appears on click & drag)
        Rectangle tmpDrawnRectangle = new Rectangle();

        //Flag used to indicate the user is drawing when the mouse moves - Thus allowing it to update the tmpDrawnRectangle
        //Enabled on mouse down - Disabled on mouse up
        bool Drawing = false;

        //Drawing Collison Boxes
        bool DrawingCol = true;

        //Drawing both collision & Vision block Boxes
        bool DrawingBoth = false;

        //Flag used to indicate if the flash light mask should be drawn. Typically it is disabled (with v) when drawing new collision/vision rectangles
        bool allVisable = false;

        //All the points that make up the full Mask polygon for the flashlight including falloff(shadowy areas)
        List<Point> maskPoly = new List<Point>();


        //######Constructor
        public Form1()
        {
            InitializeComponent();


            //This allows the user to place some components on pGameArea before compiling the program and as long as the name starts with _col
            //It adds them to the collision boxes list for later use - Likely going to be a depriciated method instead I will be saving the
            //colBoxes in the GameLevel object -> a file
            this.Controls.Remove(pGameArea);
            foreach (Control tmpControl in pGameArea.Controls)
            {
                if (tmpControl.Name.ToString().Substring(0, 4) == "col_")
                {
                    colBoxes.Add(new Rectangle(tmpControl.Location, new Size(tmpControl.Width, tmpControl.Height)));
                }
            }

            //Adds the player but also passes a list of current obstruction lines so that the player constructor can also
            //construct the visibility(for flashlight);
            thePlayer = new PlayerCharacter(this.obstructLine);

            //Instantiates, adds, configures and offesets the game area.
            myGameArea = new GameArea();
            this.Controls.Add(myGameArea);
            this._Offset.X = this._Offset.X - thePlayer.getPlayerRect().Width / 2;
            this._Offset.Y = this._Offset.Y - thePlayer.getPlayerRect().Height / 2;
            myGameArea.Visible = true;
            myGameArea.Paint += new System.Windows.Forms.PaintEventHandler(this.PaintGameArea);
            myGameArea.MouseDown += new System.Windows.Forms.MouseEventHandler(this.StartDrawCustomRectangle);
            myGameArea.MouseMove += new System.Windows.Forms.MouseEventHandler(this.DrawCustomRectangle);
            myGameArea.MouseUp += new System.Windows.Forms.MouseEventHandler(this.StopDrawingRectangle);
            this.LostFocus += new System.EventHandler(stopMovement);
            //someRandomColisionRectangles();

            //Instantiates & starts the thread used to continuously check for any gui changes(such as new col/vision boxes or player movement)
            Thread t = new Thread(update);
            t.IsBackground = true;
            t.Start();
            
        }

        //##########Update Method
        //This method runs at aproxmently 60 frames per second (rests of 15 miliseconds)
        //This method also updates the players location based on the direction they are heading & the speed of the player
        //This method will re-paint the gui displaying any new changes such as player movement & new boxes
        
        private void update()
        {
            while (true)
            {
                //Retreives player's currently location, velocity and movement speed
                Point newPoint = new Point(this.thePlayer.getXAxis(), thePlayer.getYAxis());
                Point oldPoint = newPoint;
                int xVel = thePlayer.getXVelocityAxis();
                int yVel = thePlayer.getYVelocityAxis();
                int speed = thePlayer.getSpeed();

                //If the x or y velocity is != 0 then the player is moving, calculate the new point based on the direction of the velocity & the 
                //player movement speed
                if (xVel != 0)
                {
                    newPoint.X += xVel * speed;
                    
                }

                if (yVel != 0)
                {
                    newPoint.Y += yVel * speed;
                    
                }


                //Attempt to move the player to the new location by passing the player a list of all the collision boxes.
                //The player then checks to see if the new location intersects with any collision boxes and if it does it tries again but with shorter
                //distance. This allows the player to avoid slowing down as it approches a wall and instead appar to "bounce" off the wall
                Point pointTry = newPoint;
                int tmpSpeed = speed;
                while (!this.thePlayer.updatePlayerLocation(pointTry, colBoxes.ToArray(), myGameArea.Width, myGameArea.Height, obstructLine) && tmpSpeed > 1)
                {

                    tmpSpeed--;
                    pointTry.X = pointTry.X - (xVel * speed) + (xVel * tmpSpeed);
                    pointTry.Y = pointTry.Y - (yVel * speed) + (yVel * tmpSpeed);

                }

                //If the player did succesfully move then adjust the offset values so that we can keep the player in the center of the whole window.
                //Then repaint the GameArea on the form;
                if (oldPoint != newPoint)
                {
                    _Offset.X = this.Size.Width/2 - newPoint.X;
                    _Offset.Y = this.Size.Height/2 - newPoint.Y;
                    this.Invalidate();
                }


                //Repaint the information in the GameArea (Such as the player & collision boxes)
                lock (myGameArea)
                {
                    myGameArea.Invalidate();
                }

                //Pause for aprox 1/60th of a second before restarting this method
                Thread.Sleep(15);

            }
        }

        //###########Events
        //GameArea Events
        
        //Form1 Paint - Called by Update
        // - Repositions the Game Area to the new offset point
        // - Resize the game area if nessary - This will be depriciated in implementation as the game area will remain the same size
        // for the entire match (The background will be painted onto the gameArea)
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            myGameArea.updateLocation(this._Offset);
            myGameArea.updateSize(this.Size);
        }

        //GameArea Paint - Called by Update
        // First paint the player - the player will still be painted here but the process will be diferent in implementation because the player
        //   Will be an animated sprite instead of a blue box
        // Then Paint all collision boxes - this will not be done in implementation since the collision boxes will be invisible
        // Then paint the vision block boxes - this will not be done in implementation since the vision block boxes will be invisible
        // Finally paint the flash light mask
        //
        private void PaintGameArea(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            //Paint the player
            e.Graphics.FillRectangle(Brushes.Blue, thePlayer.getPlayerRect());

            //Paint each collision box
            foreach (Rectangle tmpCol in colBoxes)
            {
                e.Graphics.FillRectangle(Brushes.Black, tmpCol);
            }

            //If the mask is not enabled
            if (allVisable)
            {
                //Paint all vision blocking boxes
                foreach (FancyRectangle tmpObs in obstructBoxes)
                {
                    e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(90, 255, 0, 0)), tmpObs.getRect());
                }

                //If the drawing rectangle's width is > 0 then the player is mid draw sooo....
                if (tmpDrawnRectangle.Width > 0)
                {

                    Brush tmpBrush;
                    if (DrawingCol)
                    {
                        //if the user is drawing a collison box then specify the color to a semi-transparent black
                        tmpBrush = new SolidBrush(Color.FromArgb(50, 192, 192, 192));
                    }
                    else
                    {
                        //if the user is drawing a vision box or both then specify the color to a semi-transparent red
                        tmpBrush = new SolidBrush(Color.FromArgb(50, 255, 0, 0));
                    }

                    //Draw the currently being drawn square with the specified color
                    e.Graphics.FillRectangle(tmpBrush, tmpDrawnRectangle);
                }

                //Draw the player mask as a solid red just so we can see how it interacts with various vision boxes
                e.Graphics.FillPolygon(Brushes.Red, this.thePlayer.getViewPolyPie());
            }
            else
            {
                //If the mask is enabled then create the new mask
                CreateMaskPoly();
                //Paint the main black Mask to cover anything that has no visability
                e.Graphics.FillPolygon(Brushes.Black, this.maskPoly.ToArray());
                //Paint the falloff mask of anything that has semi-transperent visibility (aka that shadowy effect at the edge of the light)
                e.Graphics.FillPolygon(new SolidBrush(Color.FromArgb(50, 0, 0, 0)), this.thePlayer.getFalloutPie());
            }

        }

        //Started Drawing a custom rectangle
        //- AKA Mouse Down event
        private void StartDrawCustomRectangle(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            //If the user is not already drawing something
            if (!Drawing)
            {
                //flag that the user is drawing something
                Drawing = true;
                //set the starting corner of the rectangle to the position of the mouse
                tmpDrawnRectangle.Location = e.Location;
            }
        }

        //Stop Movement
        // - AKA the game lost focus so stop moving the player
        //This zeros out the player velocity to avoid the player from moving while the game does not have focus in windows
        private void stopMovement(object sender, EventArgs e)
        {
            //Zero velocity out
            this.thePlayer.updateMovementDirection(new Point(0, 0));
        }

        //Draw Custom Rectangle
        // - AKA Mouse move
        //Updates the currently being drawn rectangle
        private void DrawCustomRectangle(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            //If the user is drawing something then
            if (Drawing)
            {
                //Adjust the width & height of the temporary rectangle
                tmpDrawnRectangle.Width = e.X - tmpDrawnRectangle.X;
                tmpDrawnRectangle.Height = e.Y - tmpDrawnRectangle.Y;
            }
        }

        //Stop Drawing Rectangle
        // - AKA Mouse Up
        // On mouse up try to save the rectangle
        private void StopDrawingRectangle(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            //Flag that we are done drawing
            Drawing = false;
            //Verify the rectangle did not overlap the player's current location
            if(!thePlayer.playerIntersectsWith(tmpDrawnRectangle)){
                //If user was drawing both
                if (DrawingBoth)
                {
                    //Add to collision block list
                    colBoxes.Add(tmpDrawnRectangle);

                    //create and add to vision block list
                    FancyRectangle tmpFancy = new FancyRectangle(tmpDrawnRectangle);
                    obstructBoxes.Add(tmpFancy);

                    //Add each line of new Vision block to Line block list
                    List<Line> tmpLines = tmpFancy.getLines();
                    foreach (Line tmpLn in tmpLines)
                    {
                        this.obstructLine.Add(tmpLn);
                    }
                }
                //If user was drawing just collision
                else if (DrawingCol)
                {
                    //Add to the collision block list
                    colBoxes.Add(tmpDrawnRectangle);
                }
                //If user was drawing just vision
                else
                {
                    //Create and add to vision block list
                    FancyRectangle tmpFancy = new FancyRectangle(tmpDrawnRectangle);
                    obstructBoxes.Add(tmpFancy);

                    //Add each line of vision block list to line block list
                    List<Line> tmpLines = tmpFancy.getLines();
                    foreach (Line tmpLn in tmpLines)
                    {
                        this.obstructLine.Add(tmpLn);
                    }
                }
            }

            //Clear the temp rectangle
            tmpDrawnRectangle = new Rectangle();
        }
        
        //KeyBoard Events        
        //Key up
        //Release a key (Such as a dirction
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            //Get key that was released
            String keyReleased = e.KeyCode.ToString();
            //Get current player velocity
            Point tmpNewDirection = new Point(this.thePlayer.getXVelocityAxis(), this.thePlayer.getYVelocityAxis());

            //If it was up/W and the y velocity was indicating the player was going up
            if ((keyReleased == "W" || keyReleased == "Up") && tmpNewDirection.Y < 0)
            {
                //Stop moving up
                tmpNewDirection.Y = 0;
            }
            //If it was S/Down and the player was moving down
            else if ((keyReleased == "S" || keyReleased == "Down") && tmpNewDirection.Y > 0)
            {
                //Stop moving down
                tmpNewDirection.Y = 0;
            }
            //If it was A/Left and the player was moving left
            else if ((keyReleased == "A" || keyReleased == "Left") && tmpNewDirection.X < 0)
            {
                //Stop moving left
                tmpNewDirection.X = 0;
            }
            //If it was D/Right and the player was moving right
            else if ((keyReleased == "D" || keyReleased == "Right") && tmpNewDirection.X > 0)
            {
                //Stop moving right
                tmpNewDirection.X = 0;
            }

            //Save the movement changes
            thePlayer.updateMovementDirection(tmpNewDirection);
        }

        //KeyDown
        //Receive and translate key commands
        //(such as movemnt or hotkeys)
        //
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            //save the key pressed to a string
            String keyPressed = e.KeyCode.ToString();
            //Get the player's current velocity x & y
            Point tmpNewDirection = new Point(this.thePlayer.getXVelocityAxis(), this.thePlayer.getYVelocityAxis());

            //If the player pressed Up/W
            if (keyPressed == "W" || keyPressed == "Up")
            {
                //Set the Y velocity to Up
                tmpNewDirection.Y = -1;
                //Stop moving left or right if the player was
                tmpNewDirection.X = 0;
            }
            //If the player pressed S/Down
            else if (keyPressed == "S" || keyPressed == "Down")
            {
                //Set the Y velocity to Down
                tmpNewDirection.Y = 1;
                //Stop moving left or right if the player was
                tmpNewDirection.X = 0;
            }
            //If the player pressed A/Left
            else if (keyPressed == "A" || keyPressed == "Left")
            {
                //Set the X Velocity to Left
                tmpNewDirection.X = -1;
                //Stop moving up or down if the player was
                tmpNewDirection.Y = 0;
            }
            //If the player pressed D.Right
            else if (keyPressed == "D" || keyPressed == "Right")
            {
                //Set the X Velocity to right
                tmpNewDirection.X = 1;
                //Stop moving up or down if the player was
                tmpNewDirection.Y = 0;
            }
            //If the player pressed C
            else if (keyPressed == "C")
            {
                //Toggle colision boxes on or off for drawing
                this.DrawingCol = !this.DrawingCol;
            }
            //If the player pressed B
            else if (keyPressed == "B")
            {
                //Toggle drawing both
                this.DrawingBoth = !this.DrawingBoth;
            }
            //If the player pressed P
            else if (keyPressed == "P")
            {
                //Get a list of all the points of the view poly and display them in a Message box
                Point[] tmpPoints = this.thePlayer.getViewPolyPie();
                string points = string.Empty;
                foreach (Point tmpPoint in tmpPoints)
                {
                    points += tmpPoint.ToString() + "\r\n";
                }
                MessageBox.Show(points);
            }
            //If the player pressed V
            else if (keyPressed == "V")
            {
                //Toggle the visibility mask
                this.allVisable = !this.allVisable;
            }
            //If the player pressed L
            else if (keyPressed == "L")
            {
                //Show a line test window - Used when developing vision line math
                new LineTest().Show();
            }
            //If the player pressed N
            else if (keyPressed == "N")
            {
                //Hide this window
                this.Hide();
                //Create a new level setting dialog and show it
                NewLevelSettings newLvlSet = new NewLevelSettings();
                DialogResult opResult = newLvlSet.ShowDialog();
                if (opResult == DialogResult.OK)
                {
                    
                }
                else if (opResult == DialogResult.Cancel || opResult == DialogResult.Abort)
                {
                    //If the Dialog had cancel press then re-show this
                    this.Show();
                }
                 
            }

            thePlayer.updateMovementDirection(tmpNewDirection);
        }

        //########## Misc Methods

        //Create Mask Poly
        //This method creates the local MaskPoly variable based on the players poly pie
        // - In implementation this will need to either communicate with a server to get the vision boxes or more likely retreive those boxes at the load
        //of the match and store them locally - Potental hack issue
        //
        //
        private void CreateMaskPoly()
        {
            //Lock the mask poly to avoid multi-threading race conditions
            lock (this.maskPoly)
            {
                //clear the mask poly list
                this.maskPoly = new List<Point>();
                //Get the player rotation in radians
                double playerRotation = this.thePlayer.getPlayerRotation();
                //Get the center of the player sprite
                Point playerLocation = this.thePlayer.getPlayerCenter();
                //Get the players view poly
                Point[] ViewPie = this.thePlayer.getViewPolyPie();
               
                //Pi values: 2Pi(right),pi/2(down),pi(left),3pi/2(up)
                if (playerRotation == Math.PI * 2)
                {
                    //player is looking right

                    //Add the bottom left corner of the whole game area
                    this.maskPoly.Add(new Point(0, this.myGameArea.Height));
                    //Add the point on the left that is directly behind the player
                    this.maskPoly.Add(new Point(0, playerLocation.Y));

                    //Add each point in the player view pie
                    foreach (Point tmpPoint in ViewPie)
                    {
                        this.maskPoly.Add(tmpPoint);
                    }

                    //Add the point on the left that is directly behind the player again
                    this.maskPoly.Add(new Point(0, playerLocation.Y));

                    //Add the top left corner
                    this.maskPoly.Add(new Point(0, 0));

                    //Add the top right corner
                    this.maskPoly.Add(new Point(this.myGameArea.Width, 0));

                    //Add the bottom right corner
                    this.maskPoly.Add(new Point(this.myGameArea.Width, this.myGameArea.Height));

                    //Add the bottom left corner again to complete the loop
                    this.maskPoly.Add(new Point(0, this.myGameArea.Height));
                }
                else if (playerRotation == Math.PI/2)
                {
                    //The player is looking down
                    //Add the top left corner of the game area
                    this.maskPoly.Add(new Point(0, 0));
                    //Add the point along the top that is directly behind the player
                    this.maskPoly.Add(new Point(playerLocation.X,0));
                    //Add each point in the player view pie
                    foreach (Point tmpPoint in ViewPie)
                    {
                        this.maskPoly.Add(tmpPoint);
                    }
                    //Add the point along the top that is directly behind the player again
                    this.maskPoly.Add(new Point(playerLocation.X, 0));
                    //Add the top right corner
                    this.maskPoly.Add(new Point(this.myGameArea.Width, 0));
                    //Add the bottom right corner
                    this.maskPoly.Add(new Point(this.myGameArea.Width, this.myGameArea.Height));
                    //Add the bottom left corner
                    this.maskPoly.Add(new Point(0, this.myGameArea.Height));
                    //Add the top left corner again to complete the loop
                    this.maskPoly.Add(new Point(0, 0));
                }
                else if (playerRotation == Math.PI)
                {
                    //The player is looking left
                    //Add the top right corner of the game area
                    this.maskPoly.Add(new Point(this.myGameArea.Width, 0));
                    //Add the point on the right that is directly behind the player
                    this.maskPoly.Add(new Point(this.myGameArea.Width, playerLocation.Y));
                    //Add each point in the player view pie
                    foreach (Point tmpPoint in ViewPie)
                    {
                        this.maskPoly.Add(tmpPoint);
                    }
                    //Add the point on the right that is directly behind the player again
                    this.maskPoly.Add(new Point(this.myGameArea.Width, playerLocation.Y));
                    //Add the bottom right corner
                    this.maskPoly.Add(new Point(this.myGameArea.Width, this.myGameArea.Height));
                    //Add the bottom left corner
                    this.maskPoly.Add(new Point(0, this.myGameArea.Height));
                    //Add the top left corner
                    this.maskPoly.Add(new Point(0, 0));
                    //Add the top right corner again to complete the loop
                    this.maskPoly.Add(new Point(this.myGameArea.Width, 0));
                }
                else if (playerRotation == (Math.PI*3)/2)
                {
                    //The player is looking up
                    //Add the bottom right corner of the game area
                    this.maskPoly.Add(new Point(this.myGameArea.Width, this.myGameArea.Height));
                    //Add the point along the bottom that is directly behind the player
                    this.maskPoly.Add(new Point(playerLocation.X,this.myGameArea.Height));
                    //Add each point in the player view pie
                    foreach (Point tmpPoint in ViewPie)
                    {
                        this.maskPoly.Add(tmpPoint);
                    }
                    //Add the point along the bottom that is directly behind the player again
                    this.maskPoly.Add(new Point(playerLocation.X, this.myGameArea.Height));
                    //Add the bottom left
                    this.maskPoly.Add(new Point(0, this.myGameArea.Height));
                    //Add the top left
                    this.maskPoly.Add(new Point(0, 0));
                    //Add the top right
                    this.maskPoly.Add(new Point(this.myGameArea.Width, 0));
                    //Add the bottom right again to complete the loop
                    this.maskPoly.Add(new Point(this.myGameArea.Width, this.myGameArea.Height));
                }
            }

        }

        //SomeRandomCollisionRectangles
        //Used to randomly generate a few collision boxes at the load of the level
        //-Primarly for testing out collision
        //-Not likely to be used in implementation
        private void someRandomColisionRectangles()
        {
            Random r = new Random();
            for (int i = 0; i < 10; i++)
            {
                int width = r.Next(0, myGameArea.Width / 3);
                int height = r.Next(0, myGameArea.Height / 3);
                int x = r.Next(0, myGameArea.Width - width);
                int y = r.Next(0, myGameArea.Height - height);
                this.colBoxes.Add(new Rectangle(x, y, width, height));
            }

        }



    }
}



