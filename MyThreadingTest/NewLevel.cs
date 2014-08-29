using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using GameTools.Encryption;

namespace MyThreadingTest
{
    public partial class NewLevel : Form
    {
        private int fallOff = 5;
        private GameLevel currentLevel;
        private GameArea myGameArea;
        private Portal firstPortal;
        private List<int> portalIDs = new List<int>();
        private EncrypterDecrypter levelEncrypter = new EncrypterDecrypter("25-207-242-8-43-32-145-72-129-93-151-84-124-233-180-220-248-116-69-14-52-251-155-175-77-7-230-233-241-154-129-40-17-175-221-79-208-249-116-31-137-148-218-86-37-24-128-26-221-165-232-169-230-236-211-30-53-67-187-37-58-167-86-231-219-112-68-204-12-101-13-254-255-39-132-160-34-70-139-53-134-205-13-77-178-216-65-36-219-192-27-142-63-80-228-226-63-242-122-181-212-179-14-120-153-233-169-191-105-52-251-238-184-134-158-108-155-9-53-4-47-32-241-76-75-127-192-176-66-162-97-47-203-213-97-210-191-148-179-201-48-129-187-168-196-44-213-184-177-121-72-54-190-119-134-180-194-193-46-27-41-248-125-199-210-204-36-226-38-204-172-7-86-108-212-173-101-74-135-31-169-8-255-201-90-44-113-85-80-172-16-254-103-153-160-55-4-244-213-247-9-243-147-228-204-65-224-82-162-216-80-121-59-15-114-33-248-179-109-167-92-206-147-121-189-174-160-189-203-157-169-112-116-143-23-182-117-27-253-26-76-31-178-119-93-151-195-88-39-128-62-80-135-47-156-58");
        //Drawing
        private Line tmpDiagLine = new Line();
        private bool Drawing = false;
        private bool Deleting = false;
        private bool DrawingDeleteBox = false;
        private bool DrawingAnotherPortal = false;
        private bool ColnVisVisable = true;
        private bool eventsVisable = true;
        private int typeOfDrawing; //0: Col & vision, 1: Col only, 2: vision only, 3: Hunter Spawn, 4: Supernatural Spawn, 5: Item Spawn, 6: Portal
        private Thread t;

        public NewLevel(GameLevel tmpLevel)
        {
            InitializeComponent();
            this.fdOpen.InitialDirectory = Application.StartupPath + "\\data\\";
            this.currentLevel = tmpLevel;
            initializeGameArea();
            initializeBoxes();
            t = new Thread(update);
            startThreading();
        }

        public NewLevel()
        {
            InitializeComponent();
            this.fdOpen.InitialDirectory = Application.StartupPath + "\\data\\";
            t = new Thread(update);
        }

        private void initializeBoxes()
        {
            /*this.colBoxes = currentLevel.getColboxes();
            this.obstructBoxes = currentLevel.getObstructionBoxes();
            this.hunterSpawns = currentLevel.getHunterSpawns();
            this.supernaturalSpawns = currentLevel.getSupernaturalSpawns();
            this.ItemSpawns = currentLevel.getItemSpawns();
            this.portals = currentLevel.getPortals();
            */

            foreach (Portal tmpPort in this.currentLevel.getPortals())
            {
                this.portalIDs.Add(tmpPort.portalID);
            }

        }

        private void initializeGameArea()
        {
            Bitmap back = currentLevel.getBackground();
            myGameArea = new GameArea();
            myGameArea.Width = back.Width;
            myGameArea.Height = back.Height;
            myGameArea.Visible = true;
            myGameArea.updateSize(back.Size);
            myGameArea.BackgroundImage = back;
            myGameArea.Name = "myGameArea";
            myGameArea.Paint += new System.Windows.Forms.PaintEventHandler(this.myGameArea_Paint);
            myGameArea.MouseDown += new System.Windows.Forms.MouseEventHandler(this.myGameArea_MouseDown);
            myGameArea.MouseMove += new System.Windows.Forms.MouseEventHandler(this.myGameArea_MouseMove);
            myGameArea.MouseUp += new System.Windows.Forms.MouseEventHandler(this.myGameArea_MouseUp);
            this.pEditor.Controls.Add(myGameArea);
        }

        private void startThreading()
        {
            if (t != null)
            {
                if (t.IsAlive)
                {
                    t.Abort();
                }
            }
            t.IsBackground = true;
            t.Start();
        }

        private void newLevelDialog()
        {
            NewLevelSettings settingsWindow = new NewLevelSettings();
            DialogResult result = settingsWindow.ShowDialog();
            if (result == DialogResult.OK)
            {
                this.currentLevel = settingsWindow.getGameLevel();
                initializeGameArea();
                initializeBoxes();
                startThreading();
            }
            else
            {

            }
        }

        private void update()
        {
            while (true)
            {
                if (!Deleting)
                {
                    pEditor.Controls[0].Invalidate();
                }
                Thread.Sleep(15);
            }
        }

        private void btnColAndObs_Click(object sender, EventArgs e)
        {
            if (!this.btnColAndObs.Checked)
            {
                this.typeOfDrawing = 0;
                uncheckAll();
                this.btnColAndObs.Checked = true;
            }
        }

        private void btnCol_Click(object sender, EventArgs e)
        {
            if (!this.btnCol.Checked)
            {
                this.typeOfDrawing = 1;
                uncheckAll();
                this.btnCol.Checked = true;
            }
        }

        private void btnObs_Click(object sender, EventArgs e)
        {
            if (!this.btnObs.Checked)
            {
                this.typeOfDrawing = 2;
                uncheckAll();
                this.btnObs.Checked = true;
            }
        }

        private void btnHSpawn_Click(object sender, EventArgs e)
        {
            if (!this.btnHSpawn.Checked)
            {
                this.typeOfDrawing = 3;
                uncheckAll();
                this.btnHSpawn.Checked = true;
            }
        }

        private void btnSSpawn_Click(object sender, EventArgs e)
        {
            if (!this.btnSSpawn.Checked)
            {
                this.typeOfDrawing = 4;
                uncheckAll();
                this.btnSSpawn.Checked = true;
            }
        }

        private void btnISpawn_Click(object sender, EventArgs e)
        {
            if (!this.btnISpawn.Checked)
            {
                this.typeOfDrawing = 5;
                uncheckAll();
                this.btnISpawn.Checked = true;
            }
        }

        private void btnPortal_Click(object sender, EventArgs e)
        {
            if (!this.btnPortal.Checked)
            {
                this.typeOfDrawing = 6;
                uncheckAll();
                this.btnPortal.Checked = true;
            }
        }

        private void uncheckAll()
        {
            this.btnColAndObs.Checked = false;
            this.btnCol.Checked = false;
            this.btnObs.Checked = false;
            this.btnHSpawn.Checked = false;
            this.btnSSpawn.Checked = false;
            this.btnISpawn.Checked = false;
            this.btnPortal.Checked = false;

        }

        private void disableAll()
        {
            btnColAndObs.Enabled = false;
            btnCol.Enabled = false;
            btnHSpawn.Enabled = false;
            btnSSpawn.Enabled = false;
            btnISpawn.Enabled = false;
            btnPortal.Enabled = false;
            btnObs.Enabled = false;
        }

        private void enableAll()
        {
            btnColAndObs.Enabled = true;
            btnCol.Enabled = true;
            btnHSpawn.Enabled = true;
            btnSSpawn.Enabled = true;
            btnISpawn.Enabled = true;
            btnPortal.Enabled = true;
            btnObs.Enabled = true;
        }

        private void NewLevel_FormClosing(object sender, FormClosingEventArgs e)
        {
            t.Abort();
        }


        private void btnViewAll_Click(object sender, EventArgs e)
        {
            if (!this.btnViewAll.Checked)
            {
                this.btnViewAll.Checked = true;
                this.btnViewColObs.Checked = false;
                this.btnViewEvents.Checked = false;
                this.eventsVisable = true;
                this.ColnVisVisable = true;
            }
        }

        private void btnViewColObs_Click(object sender, EventArgs e)
        {
            if (!this.btnViewColObs.Checked)
            {
                this.btnViewAll.Checked = false;
                this.btnViewColObs.Checked = true;
                this.btnViewEvents.Checked = false;
                this.ColnVisVisable = true;
                this.eventsVisable = false;
                
            }
        }

        private void btnViewEvents_Click(object sender, EventArgs e)
        {
            if (!this.btnViewEvents.Checked)
            {
                this.btnViewAll.Checked = false;
                this.btnViewColObs.Checked = false;
                this.btnViewEvents.Checked = true;
                this.ColnVisVisable = false;
                this.eventsVisable = true;
            }
        }

        private void myGameArea_Paint(object sender, PaintEventArgs e)
        {
            if (Drawing)
            {
                Brush tmpBrush = new SolidBrush(Color.FromArgb(50, 192, 192, 192));
                e.Graphics.FillRectangle(tmpBrush, currentDrawingRect());
            }

            if (DrawingDeleteBox)
            {
                Brush tmpBrush = new SolidBrush(Color.Red);
                e.Graphics.FillRectangle(tmpBrush, currentDrawingRect());
            }
            /*
             * 
             * List<Rectangle> colBoxes = new List<Rectangle>();
             * List<Rectangle> hunterSpawns = new List<Rectangle>();
             * List<Rectangle> supernaturalSpawns = new List<Rectangle>();
             * List<Rectangle> ItemSpawns = new List<Rectangle>();
             * List<Rectangle> portals = new List<Rectangle>();
             * List<FancyRectangle> obstructBoxes = new List<FancyRectangle>();
             * 
             */

            Font overlay = new Font("Arial", 10, FontStyle.Italic, GraphicsUnit.Point);
            Pen rectBorder = Pens.DarkOrange;
            Brush textColor = Brushes.Gold;

            if (ColnVisVisable)
            {
                //Display the Collision Boxes
                foreach (Rectangle tmpRect in this.currentLevel.getColboxes())
                {
                    e.Graphics.DrawString("C ", overlay, textColor, tmpRect);
                    e.Graphics.DrawRectangle(rectBorder, Rectangle.Round(tmpRect));
                }

                //Display the Vision Obstruction Boxes
                foreach (FancyRectangle tmpRect in this.currentLevel.getObstructionBoxes())
                {
                    e.Graphics.DrawString("V", overlay, textColor, tmpRect.getRect());
                    e.Graphics.DrawRectangle(rectBorder, Rectangle.Round(tmpRect.getRect()));
                }
            }

            if (eventsVisable)
            {
                //Display the Hunter Spawns
                foreach (Rectangle tmpRect in this.currentLevel.getHunterSpawns())
                {
                    e.Graphics.DrawString("H", overlay, textColor, tmpRect);
                    e.Graphics.DrawRectangle(rectBorder, Rectangle.Round(tmpRect));
                }

                //Display the Supernatural Spawns
                foreach (Rectangle tmpRect in this.currentLevel.getSupernaturalSpawns())
                {
                    e.Graphics.DrawString("S", overlay, textColor, tmpRect);
                    e.Graphics.DrawRectangle(rectBorder, Rectangle.Round(tmpRect));
                }

                //Display the Item Spawns
                foreach (Rectangle tmpRect in this.currentLevel.getItemSpawns())
                {
                    e.Graphics.DrawString("I", overlay, textColor, tmpRect);
                    e.Graphics.DrawRectangle(rectBorder, Rectangle.Round(tmpRect));
                }

                //Display the Portals
                foreach (Portal tmpPortal in this.currentLevel.getPortals())
                {
                    e.Graphics.DrawString("P\r\n"+tmpPortal.portalID+"->"+tmpPortal.linkedPortalID, overlay, textColor, tmpPortal.portalRect);
                    e.Graphics.DrawRectangle(rectBorder, Rectangle.Round(tmpPortal.portalRect));
                }
            }

            if (DrawingAnotherPortal)
            {
                e.Graphics.DrawString("P\r\n" + firstPortal.portalID + "-> ?", overlay, textColor, firstPortal.portalRect);
                e.Graphics.DrawRectangle(Pens.GreenYellow, firstPortal.portalRect);
            }

            pControls.Refresh();
            pViewOptions.Refresh();
            pMenu.Refresh();
        }

        private void myGameArea_MouseDown(object sender, MouseEventArgs e)
        {
            if (rCreate.Checked)
            {
                if (!Drawing)
                {
                    Drawing = true;
                    tmpDiagLine.startPoint = e.Location;
                    tmpDiagLine.endPoint = e.Location;
                }
            }
            else if (rRemove.Checked)
            {
                if (!DrawingDeleteBox)
                {
                    DrawingDeleteBox = true;
                    tmpDiagLine.startPoint = e.Location;
                    tmpDiagLine.endPoint = e.Location;
                }
            }
        }

        private void myGameArea_MouseMove(object sender, MouseEventArgs e)
        {
            if (Drawing || DrawingDeleteBox)
            {
                tmpDiagLine.endPoint = e.Location;
            }
        }

        private void myGameArea_MouseUp(object sender, MouseEventArgs e)
        {
            if (Drawing)
            {
                Drawing = false;
                Rectangle tmpRect = currentDrawingRect();
                
                switch (this.typeOfDrawing)
                {
                    case 0://save rectangle as both collision & vision
                        FancyRectangle tmpFRect = new FancyRectangle(this.shrinkRectangle(tmpRect));
                        this.currentLevel.addColBox(tmpRect);
                        this.currentLevel.addObsBox(tmpFRect);
                        break;
                    case 1://save rectangle as collision only
                        this.currentLevel.addColBox(tmpRect);
                        break;
                    case 2://save rectangle as vision only
                        FancyRectangle tmpFRect2 = new FancyRectangle(tmpRect);
                        this.currentLevel.addObsBox(tmpFRect2);
                        break;
                    case 3://save rectangle as hunter spawn
                        this.currentLevel.addHunterSpawn(tmpRect);
                        break;
                    case 4://save rectangle as Supernatural spawn
                        this.currentLevel.addSupernaturalSpawn(tmpRect);
                        break;
                    case 5://save rectangle as item spawn
                        this.currentLevel.addItemSpawn(tmpRect);
                        break;
                    case 6://save rectangle as Portal
                        if (DrawingAnotherPortal)
                        {
                            Portal linkedPortal = new Portal(getNextPortalID(), firstPortal.portalID, tmpRect);
                            firstPortal.linkedPortalID = linkedPortal.portalID;
                            this.currentLevel.addPortal(firstPortal);
                            this.currentLevel.addPortal(linkedPortal);
                            DrawingAnotherPortal = false;
                            enableAll();
                        }
                        else
                        {
                            firstPortal = new Portal(getNextPortalID(), -1, tmpRect);
                            this.portalIDs.Add(firstPortal.portalID);
                            DrawingAnotherPortal = true;
                            disableAll();
                        }
                        break;
                }
                tmpDiagLine = new Line();
            }
            else if (DrawingDeleteBox)
            {
                Deleting = true;
                removeRect();
                Deleting = false;
                DrawingDeleteBox = false;
                tmpDiagLine = new Line();
            }
        }

        private void removeRect()
        {
            Rectangle tmpRect = currentDrawingRect();
            List<Rectangle> toRemoveRect = new List<Rectangle>();
            List<FancyRectangle> toRemoveFRect = new List<FancyRectangle>();
            List<Portal> toRemovePortal = new List<Portal>();
            switch (this.typeOfDrawing)
            {
                case 0://remove collision & vision boxes in area
                    foreach (Rectangle tmpCRect in this.currentLevel.getColboxes())
                    {
                        if (tmpRect.IntersectsWith(tmpCRect))
                        {
                            toRemoveRect.Add(tmpCRect);
                        }
                    }
                    foreach (FancyRectangle tmpVRect in this.currentLevel.getObstructionBoxes())
                    {
                        if (tmpVRect.getRect().IntersectsWith(tmpRect))
                        {
                            toRemoveFRect.Add(tmpVRect);
                        }
                    }

                    foreach (Rectangle tmpCRect in toRemoveRect)
                    {
                        this.currentLevel.removeColBox(tmpCRect);
                    }

                    foreach (FancyRectangle tmpFRect in toRemoveFRect)
                    {
                        this.currentLevel.removeObsBox(tmpFRect);
                    }
                    break;
                case 1://remove collision boxes in area
                    foreach (Rectangle tmpCRect in this.currentLevel.getColboxes())
                    {
                        if (tmpRect.IntersectsWith(tmpCRect))
                        {
                            toRemoveRect.Add(tmpCRect);
                        }
                    }

                    foreach (Rectangle tmpCRect in toRemoveRect)
                    {
                        this.currentLevel.removeColBox(tmpCRect);
                    }
                    break;
                case 2://remove vision boxes in area
                    foreach (FancyRectangle tmpVRect in this.currentLevel.getObstructionBoxes())
                    {
                        if (tmpVRect.getRect().IntersectsWith(tmpRect))
                        {
                            toRemoveFRect.Add(tmpVRect);
                        }
                    }

                    foreach (FancyRectangle tmpFRect in toRemoveFRect)
                    {
                        this.currentLevel.removeObsBox(tmpFRect);
                    }
                    break;
                case 3://remove hunter spawns in area
                    foreach (Rectangle tmpHRect in this.currentLevel.getHunterSpawns())
                    {
                        if (tmpRect.IntersectsWith(tmpHRect))
                        {
                            toRemoveRect.Add(tmpHRect);
                        }
                    }

                    foreach (Rectangle tmpHRect in toRemoveRect)
                    {
                        this.currentLevel.removeHunterSpawn(tmpHRect);
                    }
                    break;
                case 4://remove supernatural spawns in area
                    foreach (Rectangle tmpSRect in this.currentLevel.getSupernaturalSpawns())
                    {
                        if (tmpRect.IntersectsWith(tmpSRect))
                        {
                            toRemoveRect.Add(tmpSRect);
                        }
                    }

                    foreach (Rectangle tmpSRect in toRemoveRect)
                    {
                        this.currentLevel.removeSupernaturalSpawn(tmpSRect);
                    }
                    break;
                case 5://remove items in area
                    foreach (Rectangle tmpIRect in this.currentLevel.getItemSpawns())
                    {
                        if (tmpRect.IntersectsWith(tmpIRect))
                        {
                            toRemoveRect.Add(tmpIRect);
                        }
                    }

                    foreach (Rectangle tmpIRect in toRemoveRect)
                    {
                        this.currentLevel.removeItemSpawn(tmpIRect);
                    }
                    break;
                case 6://remove portals in area && any linked portals
                    foreach (Portal tmpPort in this.currentLevel.getPortals())
                    {
                        if (tmpRect.IntersectsWith(tmpPort.portalRect))
                        {
                            if (!toRemovePortal.Contains(tmpPort))
                            {
                                toRemovePortal.Add(tmpPort);
                            }
                        }
                    }

                    foreach (Portal tmpPort in toRemovePortal)
                    {
                        this.currentLevel.removePortal(tmpPort);
                    }
                    break;
            }
        }


        private int getNextPortalID()
        {
            int NextID = 0;
            bool found = false;
            while (!found)
            {
                if (!portalIDs.Contains(NextID))
                {
                    found = true;
                }
                else
                {
                    NextID++;
                }
            }
            return NextID;
        }

        private Rectangle shrinkRectangle(Rectangle tmpOrig)
        {
            Rectangle tmpResult = tmpOrig;

            if (tmpResult.Width > (2 * fallOff) && tmpResult.Height > (2 * fallOff))
            {
                tmpResult.Width = tmpResult.Width - fallOff;
                tmpResult.Height = tmpResult.Height - fallOff;
                Point tmpNewPoint = tmpResult.Location;
                tmpNewPoint.X =(int) tmpNewPoint.X + (fallOff / 2);
                tmpNewPoint.Y =(int) tmpNewPoint.Y + (fallOff / 2);
                tmpResult.Location = tmpNewPoint;
            }
            
            return tmpResult;
        }

        /// <summary>
        /// Using the Diagnal Line this creates a rectangle
        /// </summary>
        /// <returns>Rectangle</returns>
        private Rectangle currentDrawingRect()
        {
            Rectangle tmpDrawnRectangle = new Rectangle();

            if (tmpDiagLine.startPoint.Y <= tmpDiagLine.endPoint.Y)
            {
                tmpDrawnRectangle.Y = tmpDiagLine.startPoint.Y;
            }
            else
            {
                tmpDrawnRectangle.Y = tmpDiagLine.endPoint.Y;
            }

            if (tmpDiagLine.startPoint.X <= tmpDiagLine.endPoint.X)
            {
                tmpDrawnRectangle.X = tmpDiagLine.startPoint.X;
            }
            else
            {
                tmpDrawnRectangle.X = tmpDiagLine.endPoint.X;
            }

            tmpDrawnRectangle.Width = (int)Math.Abs(tmpDiagLine.run);
            tmpDrawnRectangle.Height = (int)Math.Abs(tmpDiagLine.rise);

            return tmpDrawnRectangle;
        }

        private void tsmiNew_Click(object sender, EventArgs e)
        {
            newLevelDialog();
        }

        private void tsmiSave_Click(object sender, EventArgs e)
        {
            if (this.currentLevel != null)
            {
                this.levelEncrypter.encryptToFile(this.currentLevel.ToEString(), this.currentLevel.levelPath);
            }
        }

        private void tsmiOpen_Click(object sender, EventArgs e)
        {
            DialogResult tmpDialog = this.fdOpen.ShowDialog();

            if (tmpDialog == DialogResult.OK)
            {
                if (this.fdOpen.FileName.Substring(fdOpen.FileName.Length - 3) == "jlv")
                {
                    string eLevel = this.levelEncrypter.decryptFile(this.fdOpen.FileName);
                    this.currentLevel = new GameLevel(eLevel);
                    initializeGameArea();
                    initializeBoxes();
                    startThreading();
                }

            }

        }

    }

            
}
