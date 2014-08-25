namespace MyThreadingTest
{
    partial class NewLevelSettings
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtLevelName = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.nudWidth = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.nudHeight = new System.Windows.Forms.NumericUpDown();
            this.btnCreate = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnFile = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.lblFileName = new System.Windows.Forms.Label();
            this.ofdBackground = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHeight)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(66, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name:";
            // 
            // txtLevelName
            // 
            this.txtLevelName.Location = new System.Drawing.Point(122, 29);
            this.txtLevelName.Name = "txtLevelName";
            this.txtLevelName.Size = new System.Drawing.Size(100, 20);
            this.txtLevelName.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.nudHeight);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.nudWidth);
            this.groupBox1.Location = new System.Drawing.Point(39, 55);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 100);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Size";
            // 
            // nudWidth
            // 
            this.nudWidth.Location = new System.Drawing.Point(83, 29);
            this.nudWidth.Maximum = new decimal(new int[] {
            2048,
            0,
            0,
            0});
            this.nudWidth.Name = "nudWidth";
            this.nudWidth.Size = new System.Drawing.Size(66, 20);
            this.nudWidth.TabIndex = 0;
            this.nudWidth.Value = new decimal(new int[] {
            256,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(37, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Width:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(36, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Height:";
            // 
            // nudHeight
            // 
            this.nudHeight.Location = new System.Drawing.Point(83, 55);
            this.nudHeight.Maximum = new decimal(new int[] {
            2048,
            0,
            0,
            0});
            this.nudHeight.Name = "nudHeight";
            this.nudHeight.Size = new System.Drawing.Size(66, 20);
            this.nudHeight.TabIndex = 3;
            this.nudHeight.Value = new decimal(new int[] {
            256,
            0,
            0,
            0});
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(39, 210);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(75, 23);
            this.btnCreate.TabIndex = 3;
            this.btnCreate.Text = "Create";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(164, 210);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnFile
            // 
            this.btnFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.25F);
            this.btnFile.Location = new System.Drawing.Point(164, 175);
            this.btnFile.Name = "btnFile";
            this.btnFile.Size = new System.Drawing.Size(58, 18);
            this.btnFile.TabIndex = 5;
            this.btnFile.Text = "Browse...";
            this.btnFile.UseVisualStyleBackColor = true;
            this.btnFile.Click += new System.EventHandler(this.btnFile_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(107, 159);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Background:";
            // 
            // lblFileName
            // 
            this.lblFileName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblFileName.Location = new System.Drawing.Point(29, 175);
            this.lblFileName.Name = "lblFileName";
            this.lblFileName.Size = new System.Drawing.Size(120, 18);
            this.lblFileName.TabIndex = 7;
            this.lblFileName.MouseLeave += new System.EventHandler(this.lblFileName_MouseLeave);
            this.lblFileName.MouseHover += new System.EventHandler(this.lblFileName_MouseHover);
            // 
            // ofdBackground
            // 
            this.ofdBackground.FileName = "openFileDialog1";
            this.ofdBackground.Filter = "Image Files (*.bmp, *.jpg,*.jpeg)|*.bmp;*.jpg;*.jpeg";
            // 
            // NewLevelSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.lblFileName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnFile);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtLevelName);
            this.Controls.Add(this.label1);
            this.Name = "NewLevelSettings";
            this.Text = "NewLevelSettings";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHeight)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtLevelName;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown nudHeight;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nudWidth;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnFile;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblFileName;
        private System.Windows.Forms.OpenFileDialog ofdBackground;
    }
}