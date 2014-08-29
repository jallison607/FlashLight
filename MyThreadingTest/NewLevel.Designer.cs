namespace MyThreadingTest
{
    partial class NewLevel
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewLevel));
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.pEditor = new System.Windows.Forms.Panel();
            this.pControls = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.btnColAndObs = new System.Windows.Forms.ToolStripButton();
            this.btnCol = new System.Windows.Forms.ToolStripButton();
            this.btnObs = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.btnHSpawn = new System.Windows.Forms.ToolStripButton();
            this.btnSSpawn = new System.Windows.Forms.ToolStripButton();
            this.btnISpawn = new System.Windows.Forms.ToolStripButton();
            this.btnPortal = new System.Windows.Forms.ToolStripButton();
            this.pMenu = new System.Windows.Forms.Panel();
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiNew = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSave = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiExit = new System.Windows.Forms.ToolStripMenuItem();
            this.pViewOptions = new System.Windows.Forms.Panel();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel4 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.btnViewAll = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnViewColObs = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnViewEvents = new System.Windows.Forms.ToolStripButton();
            this.fdOpen = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rCreate = new System.Windows.Forms.RadioButton();
            this.rRemove = new System.Windows.Forms.RadioButton();
            this.tlpMain.SuspendLayout();
            this.pControls.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.pMenu.SuspendLayout();
            this.mainMenu.SuspendLayout();
            this.pViewOptions.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpMain
            // 
            this.tlpMain.ColumnCount = 2;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpMain.Controls.Add(this.pEditor, 1, 1);
            this.tlpMain.Controls.Add(this.pControls, 0, 1);
            this.tlpMain.Controls.Add(this.pMenu, 0, 0);
            this.tlpMain.Controls.Add(this.pViewOptions, 1, 0);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 2;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpMain.Size = new System.Drawing.Size(654, 550);
            this.tlpMain.TabIndex = 0;
            // 
            // pEditor
            // 
            this.pEditor.AutoScroll = true;
            this.pEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pEditor.Location = new System.Drawing.Point(153, 33);
            this.pEditor.Name = "pEditor";
            this.pEditor.Size = new System.Drawing.Size(498, 514);
            this.pEditor.TabIndex = 0;
            // 
            // pControls
            // 
            this.pControls.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pControls.Controls.Add(this.groupBox1);
            this.pControls.Controls.Add(this.toolStrip1);
            this.pControls.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pControls.Location = new System.Drawing.Point(3, 33);
            this.pControls.Name = "pControls";
            this.pControls.Size = new System.Drawing.Size(144, 514);
            this.pControls.TabIndex = 1;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel3,
            this.toolStripSeparator4,
            this.toolStripLabel1,
            this.btnColAndObs,
            this.btnCol,
            this.btnObs,
            this.toolStripSeparator1,
            this.toolStripLabel2,
            this.btnHSpawn,
            this.btnSSpawn,
            this.btnISpawn,
            this.btnPortal});
            this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(140, 238);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(138, 15);
            this.toolStripLabel3.Text = "Drawing Tools";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(138, 6);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(138, 15);
            this.toolStripLabel1.Text = "Collision/Vision";
            // 
            // btnColAndObs
            // 
            this.btnColAndObs.Checked = true;
            this.btnColAndObs.CheckState = System.Windows.Forms.CheckState.Checked;
            this.btnColAndObs.Image = ((System.Drawing.Image)(resources.GetObject("btnColAndObs.Image")));
            this.btnColAndObs.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnColAndObs.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnColAndObs.Name = "btnColAndObs";
            this.btnColAndObs.Size = new System.Drawing.Size(138, 20);
            this.btnColAndObs.Text = "Both";
            this.btnColAndObs.Click += new System.EventHandler(this.btnColAndObs_Click);
            // 
            // btnCol
            // 
            this.btnCol.Image = ((System.Drawing.Image)(resources.GetObject("btnCol.Image")));
            this.btnCol.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCol.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCol.Name = "btnCol";
            this.btnCol.Size = new System.Drawing.Size(138, 20);
            this.btnCol.Text = "Collision";
            this.btnCol.Click += new System.EventHandler(this.btnCol_Click);
            // 
            // btnObs
            // 
            this.btnObs.Image = ((System.Drawing.Image)(resources.GetObject("btnObs.Image")));
            this.btnObs.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnObs.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnObs.Name = "btnObs";
            this.btnObs.Size = new System.Drawing.Size(138, 20);
            this.btnObs.Text = "Vision";
            this.btnObs.Click += new System.EventHandler(this.btnObs_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(138, 6);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(138, 15);
            this.toolStripLabel2.Text = "Events";
            // 
            // btnHSpawn
            // 
            this.btnHSpawn.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnHSpawn.Image = ((System.Drawing.Image)(resources.GetObject("btnHSpawn.Image")));
            this.btnHSpawn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHSpawn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnHSpawn.Name = "btnHSpawn";
            this.btnHSpawn.Size = new System.Drawing.Size(138, 20);
            this.btnHSpawn.Text = "Hunter Spawn";
            this.btnHSpawn.Click += new System.EventHandler(this.btnHSpawn_Click);
            // 
            // btnSSpawn
            // 
            this.btnSSpawn.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnSSpawn.Image = ((System.Drawing.Image)(resources.GetObject("btnSSpawn.Image")));
            this.btnSSpawn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSSpawn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSSpawn.Name = "btnSSpawn";
            this.btnSSpawn.Size = new System.Drawing.Size(138, 20);
            this.btnSSpawn.Text = "Supernatural Spawn";
            this.btnSSpawn.Click += new System.EventHandler(this.btnSSpawn_Click);
            // 
            // btnISpawn
            // 
            this.btnISpawn.Image = ((System.Drawing.Image)(resources.GetObject("btnISpawn.Image")));
            this.btnISpawn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnISpawn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnISpawn.Name = "btnISpawn";
            this.btnISpawn.Size = new System.Drawing.Size(138, 20);
            this.btnISpawn.Text = "Item Spawn";
            this.btnISpawn.Click += new System.EventHandler(this.btnISpawn_Click);
            // 
            // btnPortal
            // 
            this.btnPortal.Image = ((System.Drawing.Image)(resources.GetObject("btnPortal.Image")));
            this.btnPortal.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPortal.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPortal.Name = "btnPortal";
            this.btnPortal.Size = new System.Drawing.Size(138, 20);
            this.btnPortal.Text = "Portal";
            this.btnPortal.Click += new System.EventHandler(this.btnPortal_Click);
            // 
            // pMenu
            // 
            this.pMenu.Controls.Add(this.mainMenu);
            this.pMenu.Location = new System.Drawing.Point(3, 3);
            this.pMenu.Name = "pMenu";
            this.pMenu.Size = new System.Drawing.Size(144, 24);
            this.pMenu.TabIndex = 2;
            // 
            // mainMenu
            // 
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Size = new System.Drawing.Size(144, 24);
            this.mainMenu.TabIndex = 0;
            this.mainMenu.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiNew,
            this.tsmiOpen,
            this.tsmiSave,
            this.tsmiSaveAs,
            this.tsmiExit});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // tsmiNew
            // 
            this.tsmiNew.Name = "tsmiNew";
            this.tsmiNew.Size = new System.Drawing.Size(114, 22);
            this.tsmiNew.Text = "New";
            this.tsmiNew.Click += new System.EventHandler(this.tsmiNew_Click);
            // 
            // tsmiOpen
            // 
            this.tsmiOpen.Name = "tsmiOpen";
            this.tsmiOpen.Size = new System.Drawing.Size(114, 22);
            this.tsmiOpen.Text = "Open";
            this.tsmiOpen.Click += new System.EventHandler(this.tsmiOpen_Click);
            // 
            // tsmiSave
            // 
            this.tsmiSave.Name = "tsmiSave";
            this.tsmiSave.Size = new System.Drawing.Size(114, 22);
            this.tsmiSave.Text = "Save";
            this.tsmiSave.Click += new System.EventHandler(this.tsmiSave_Click);
            // 
            // tsmiSaveAs
            // 
            this.tsmiSaveAs.Name = "tsmiSaveAs";
            this.tsmiSaveAs.Size = new System.Drawing.Size(114, 22);
            this.tsmiSaveAs.Text = "Save As";
            // 
            // tsmiExit
            // 
            this.tsmiExit.Name = "tsmiExit";
            this.tsmiExit.Size = new System.Drawing.Size(114, 22);
            this.tsmiExit.Text = "Exit";
            // 
            // pViewOptions
            // 
            this.pViewOptions.Controls.Add(this.toolStrip2);
            this.pViewOptions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pViewOptions.Location = new System.Drawing.Point(153, 3);
            this.pViewOptions.Name = "pViewOptions";
            this.pViewOptions.Size = new System.Drawing.Size(498, 24);
            this.pViewOptions.TabIndex = 3;
            // 
            // toolStrip2
            // 
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel4,
            this.toolStripSeparator5,
            this.btnViewAll,
            this.toolStripSeparator2,
            this.btnViewColObs,
            this.toolStripSeparator3,
            this.btnViewEvents});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(498, 25);
            this.toolStrip2.TabIndex = 0;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // toolStripLabel4
            // 
            this.toolStripLabel4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel4.Name = "toolStripLabel4";
            this.toolStripLabel4.Size = new System.Drawing.Size(81, 22);
            this.toolStripLabel4.Text = "View Options";
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // btnViewAll
            // 
            this.btnViewAll.Checked = true;
            this.btnViewAll.CheckState = System.Windows.Forms.CheckState.Checked;
            this.btnViewAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnViewAll.Image = ((System.Drawing.Image)(resources.GetObject("btnViewAll.Image")));
            this.btnViewAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnViewAll.Name = "btnViewAll";
            this.btnViewAll.Size = new System.Drawing.Size(25, 22);
            this.btnViewAll.Text = "All";
            this.btnViewAll.Click += new System.EventHandler(this.btnViewAll_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // btnViewColObs
            // 
            this.btnViewColObs.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnViewColObs.Image = ((System.Drawing.Image)(resources.GetObject("btnViewColObs.Image")));
            this.btnViewColObs.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnViewColObs.Name = "btnViewColObs";
            this.btnViewColObs.Size = new System.Drawing.Size(94, 22);
            this.btnViewColObs.Text = "Collision/Vision";
            this.btnViewColObs.Click += new System.EventHandler(this.btnViewColObs_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // btnViewEvents
            // 
            this.btnViewEvents.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnViewEvents.Image = ((System.Drawing.Image)(resources.GetObject("btnViewEvents.Image")));
            this.btnViewEvents.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnViewEvents.Name = "btnViewEvents";
            this.btnViewEvents.Size = new System.Drawing.Size(45, 22);
            this.btnViewEvents.Text = "Events";
            this.btnViewEvents.Click += new System.EventHandler(this.btnViewEvents_Click);
            // 
            // fdOpen
            // 
            this.fdOpen.FileName = "openFileDialog1";
            this.fdOpen.Filter = "Level Files (*.jlv)|*.jlv";
            this.fdOpen.InitialDirectory = "data\\";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rRemove);
            this.groupBox1.Controls.Add(this.rCreate);
            this.groupBox1.Location = new System.Drawing.Point(7, 241);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(117, 70);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Mode";
            // 
            // rCreate
            // 
            this.rCreate.AutoSize = true;
            this.rCreate.Checked = true;
            this.rCreate.Location = new System.Drawing.Point(7, 20);
            this.rCreate.Name = "rCreate";
            this.rCreate.Size = new System.Drawing.Size(56, 17);
            this.rCreate.TabIndex = 0;
            this.rCreate.TabStop = true;
            this.rCreate.Text = "Create";
            this.rCreate.UseVisualStyleBackColor = true;

            // 
            // rRemove
            // 
            this.rRemove.AutoSize = true;
            this.rRemove.Location = new System.Drawing.Point(7, 40);
            this.rRemove.Name = "rRemove";
            this.rRemove.Size = new System.Drawing.Size(65, 17);
            this.rRemove.TabIndex = 1;
            this.rRemove.Text = "Remove";
            this.rRemove.UseVisualStyleBackColor = true;
            // 
            // NewLevel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(654, 550);
            this.Controls.Add(this.tlpMain);
            this.MainMenuStrip = this.mainMenu;
            this.Name = "NewLevel";
            this.Text = "NewLevel";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.NewLevel_FormClosing);
            this.tlpMain.ResumeLayout(false);
            this.pControls.ResumeLayout(false);
            this.pControls.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.pMenu.ResumeLayout(false);
            this.pMenu.PerformLayout();
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            this.pViewOptions.ResumeLayout(false);
            this.pViewOptions.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.Panel pEditor;
        private System.Windows.Forms.Panel pControls;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripButton btnColAndObs;
        private System.Windows.Forms.ToolStripButton btnCol;
        private System.Windows.Forms.ToolStripButton btnObs;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripButton btnHSpawn;
        private System.Windows.Forms.ToolStripButton btnSSpawn;
        private System.Windows.Forms.ToolStripButton btnISpawn;
        private System.Windows.Forms.ToolStripButton btnPortal;
        private System.Windows.Forms.Panel pMenu;
        private System.Windows.Forms.Panel pViewOptions;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton btnViewAll;
        private System.Windows.Forms.ToolStripButton btnViewColObs;
        private System.Windows.Forms.ToolStripButton btnViewEvents;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripLabel toolStripLabel3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripLabel toolStripLabel4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.MenuStrip mainMenu;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiNew;
        private System.Windows.Forms.ToolStripMenuItem tsmiSave;
        private System.Windows.Forms.ToolStripMenuItem tsmiSaveAs;
        private System.Windows.Forms.ToolStripMenuItem tsmiExit;
        private System.Windows.Forms.ToolStripMenuItem tsmiOpen;
        private System.Windows.Forms.OpenFileDialog fdOpen;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rRemove;
        private System.Windows.Forms.RadioButton rCreate;
    }
}