namespace ImageSort
{
    partial class SortForm
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.nextButton = new System.Windows.Forms.Button();
            this.moveButton = new System.Windows.Forms.Button();
            this.backButton = new System.Windows.Forms.Button();
            this.viewBox = new System.Windows.Forms.PictureBox();
            this.viewBoxMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openInExplorerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.jumpToToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resolutionLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.viewBox)).BeginInit();
            this.viewBoxMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // nextButton
            // 
            this.nextButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.nextButton.Location = new System.Drawing.Point(523, 513);
            this.nextButton.Name = "nextButton";
            this.nextButton.Size = new System.Drawing.Size(300, 34);
            this.nextButton.TabIndex = 7;
            this.nextButton.TabStop = false;
            this.nextButton.Text = Properties.Strings.NextImage;
            this.nextButton.UseVisualStyleBackColor = true;
            this.nextButton.Click += new System.EventHandler(this.nextButton_Click);
            // 
            // moveButton
            // 
            this.moveButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.moveButton.Location = new System.Drawing.Point(317, 513);
            this.moveButton.Name = "moveButton";
            this.moveButton.Size = new System.Drawing.Size(200, 34);
            this.moveButton.TabIndex = 6;
            this.moveButton.TabStop = false;
            this.moveButton.Text = Properties.Strings.Copy;
            this.moveButton.UseVisualStyleBackColor = true;
            this.moveButton.Click += new System.EventHandler(this.moveButton_Click);
            // 
            // backButton
            // 
            this.backButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.backButton.Location = new System.Drawing.Point(11, 513);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(300, 34);
            this.backButton.TabIndex = 5;
            this.backButton.TabStop = false;
            this.backButton.Text = Properties.Strings.PrevImage;
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // viewBox
            // 
            this.viewBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.viewBox.ContextMenuStrip = this.viewBoxMenu;
            this.viewBox.Location = new System.Drawing.Point(12, 12);
            this.viewBox.Name = "viewBox";
            this.viewBox.Size = new System.Drawing.Size(811, 495);
            this.viewBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.viewBox.TabIndex = 4;
            this.viewBox.TabStop = false;
            this.viewBox.Click += new System.EventHandler(this.viewBox_Click);
            // 
            // viewBoxMenu
            // 
            this.viewBoxMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openInExplorerToolStripMenuItem,
            this.jumpToToolStripMenuItem});
            this.viewBoxMenu.Name = "contextMenuStrip1";
            this.viewBoxMenu.Size = new System.Drawing.Size(162, 48);
            // 
            // openInExplorerToolStripMenuItem
            // 
            this.openInExplorerToolStripMenuItem.Name = "openInExplorerToolStripMenuItem";
            this.openInExplorerToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.openInExplorerToolStripMenuItem.Text = Properties.Strings.OpenExplorer;
            this.openInExplorerToolStripMenuItem.Click += new System.EventHandler(this.openInExplorerToolStripMenuItem_Click);
            // 
            // jumpToToolStripMenuItem
            // 
            this.jumpToToolStripMenuItem.Name = "jumpToToolStripMenuItem";
            this.jumpToToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.jumpToToolStripMenuItem.Text = Properties.Strings.JumpTo;
            this.jumpToToolStripMenuItem.Click += new System.EventHandler(this.jumpToToolStripMenuItem_Click);
            // 
            // resolutionLabel
            // 
            this.resolutionLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.resolutionLabel.AutoSize = true;
            this.resolutionLabel.Location = new System.Drawing.Point(12, 494);
            this.resolutionLabel.Name = "resolutionLabel";
            this.resolutionLabel.Size = new System.Drawing.Size(54, 13);
            this.resolutionLabel.TabIndex = 8;
            this.resolutionLabel.Text = Properties.Strings.Resolution;
            // 
            // SortForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(834, 559);
            this.Controls.Add(this.resolutionLabel);
            this.Controls.Add(this.nextButton);
            this.Controls.Add(this.moveButton);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.viewBox);
            this.KeyPreview = true;
            this.Name = "SortForm";
            this.Shown += new System.EventHandler(this.SortForm_Shown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.SortForm_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.viewBox)).EndInit();
            this.viewBoxMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Button nextButton;
        public System.Windows.Forms.Button moveButton;
        public System.Windows.Forms.Button backButton;
        public System.Windows.Forms.PictureBox viewBox;
        private System.Windows.Forms.Label resolutionLabel;
        private System.Windows.Forms.ContextMenuStrip viewBoxMenu;
        private System.Windows.Forms.ToolStripMenuItem openInExplorerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem jumpToToolStripMenuItem;
    }
}

