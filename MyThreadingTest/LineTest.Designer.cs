namespace MyThreadingTest
{
    partial class LineTest
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Logger = new System.Windows.Forms.TextBox();
            this.lblUpdate = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rRect = new System.Windows.Forms.RadioButton();
            this.rLine = new System.Windows.Forms.RadioButton();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnTest = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(625, 565);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.Logger);
            this.panel1.Controls.Add(this.lblUpdate);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.lblStatus);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.btnExit);
            this.panel1.Controls.Add(this.btnClear);
            this.panel1.Controls.Add(this.btnTest);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(144, 559);
            this.panel1.TabIndex = 0;
            // 
            // Logger
            // 
            this.Logger.Location = new System.Drawing.Point(9, 388);
            this.Logger.Multiline = true;
            this.Logger.Name = "Logger";
            this.Logger.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Logger.Size = new System.Drawing.Size(132, 139);
            this.Logger.TabIndex = 8;
            // 
            // lblUpdate
            // 
            this.lblUpdate.AutoSize = true;
            this.lblUpdate.Location = new System.Drawing.Point(14, 342);
            this.lblUpdate.Name = "lblUpdate";
            this.lblUpdate.Size = new System.Drawing.Size(35, 13);
            this.lblUpdate.TabIndex = 7;
            this.lblUpdate.Text = "label3";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 329);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Status 2:";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(4, 283);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(85, 13);
            this.lblStatus.TabIndex = 5;
            this.lblStatus.Text = "Waiting for Input";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 266);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Status:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rRect);
            this.groupBox1.Controls.Add(this.rLine);
            this.groupBox1.Location = new System.Drawing.Point(10, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(74, 75);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // rRect
            // 
            this.rRect.AutoSize = true;
            this.rRect.Location = new System.Drawing.Point(7, 44);
            this.rRect.Name = "rRect";
            this.rRect.Size = new System.Drawing.Size(54, 17);
            this.rRect.TabIndex = 1;
            this.rRect.Text = "Boxes";
            this.rRect.UseVisualStyleBackColor = true;
            this.rRect.CheckedChanged += new System.EventHandler(this.rRect_CheckedChanged);
            // 
            // rLine
            // 
            this.rLine.AutoSize = true;
            this.rLine.Checked = true;
            this.rLine.Location = new System.Drawing.Point(7, 20);
            this.rLine.Name = "rLine";
            this.rLine.Size = new System.Drawing.Size(50, 17);
            this.rLine.TabIndex = 0;
            this.rLine.TabStop = true;
            this.rLine.Text = "Lines";
            this.rLine.UseVisualStyleBackColor = true;
            this.rLine.CheckedChanged += new System.EventHandler(this.rLine_CheckedChanged);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(9, 166);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 2;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(9, 137);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 1;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(9, 91);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(75, 40);
            this.btnTest.TabIndex = 0;
            this.btnTest.Text = "Test for intersections";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(153, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(519, 559);
            this.panel2.TabIndex = 1;
            // 
            // LineTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(625, 565);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "LineTest";
            this.Text = "LineTest";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rRect;
        private System.Windows.Forms.RadioButton rLine;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblUpdate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Logger;
    }
}