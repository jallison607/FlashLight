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
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.pEditor = new System.Windows.Forms.Panel();
            this.pControls = new System.Windows.Forms.Panel();
            this.pScene = new System.Windows.Forms.Panel();
            this.tlpMain.SuspendLayout();
            this.pEditor.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpMain
            // 
            this.tlpMain.ColumnCount = 2;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpMain.Controls.Add(this.pEditor, 1, 0);
            this.tlpMain.Controls.Add(this.pControls, 0, 0);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 1;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpMain.Size = new System.Drawing.Size(572, 509);
            this.tlpMain.TabIndex = 0;
            // 
            // pEditor
            // 
            this.pEditor.AutoScroll = true;
            this.pEditor.Controls.Add(this.pScene);
            this.pEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pEditor.Location = new System.Drawing.Point(103, 3);
            this.pEditor.Name = "pEditor";
            this.pEditor.Size = new System.Drawing.Size(466, 503);
            this.pEditor.TabIndex = 0;
            // 
            // pControls
            // 
            this.pControls.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pControls.Location = new System.Drawing.Point(3, 3);
            this.pControls.Name = "pControls";
            this.pControls.Size = new System.Drawing.Size(94, 503);
            this.pControls.TabIndex = 1;
            // 
            // pScene
            // 
            this.pScene.Location = new System.Drawing.Point(3, 3);
            this.pScene.Name = "pScene";
            this.pScene.Size = new System.Drawing.Size(200, 100);
            this.pScene.TabIndex = 0;
            // 
            // NewLevel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(572, 509);
            this.Controls.Add(this.tlpMain);
            this.Name = "NewLevel";
            this.Text = "NewLevel";
            this.tlpMain.ResumeLayout(false);
            this.pEditor.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.Panel pEditor;
        private System.Windows.Forms.Panel pScene;
        private System.Windows.Forms.Panel pControls;
    }
}