namespace StringSim
{
    partial class MainForm
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
            this.Scene = new StringSim.Controls.Scene();
            this.AppMenu = new System.Windows.Forms.MenuStrip();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PosLabel = new System.Windows.Forms.Label();
            this.AppMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // Scene
            // 
            this.Scene.BackColor = System.Drawing.Color.MintCream;
            this.Scene.Context = null;
            this.Scene.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Scene.Location = new System.Drawing.Point(0, 24);
            this.Scene.Name = "Scene";
            this.Scene.ScrollX = 0;
            this.Scene.ScrollY = 0;
            this.Scene.Size = new System.Drawing.Size(800, 426);
            this.Scene.TabIndex = 0;
            this.Scene.Zoom = 100;
            this.Scene.ScrollChanged += new StringSim.Controls.Scene.OnScrollChanged(this.Scene_ScrollChanged);
            // 
            // AppMenu
            // 
            this.AppMenu.BackColor = System.Drawing.Color.White;
            this.AppMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpToolStripMenuItem});
            this.AppMenu.Location = new System.Drawing.Point(0, 0);
            this.AppMenu.Name = "AppMenu";
            this.AppMenu.Size = new System.Drawing.Size(800, 24);
            this.AppMenu.TabIndex = 1;
            this.AppMenu.Text = "menuStrip1";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // PosLabel
            // 
            this.PosLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.PosLabel.AutoSize = true;
            this.PosLabel.BackColor = System.Drawing.Color.Transparent;
            this.PosLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PosLabel.Location = new System.Drawing.Point(12, 428);
            this.PosLabel.Name = "PosLabel";
            this.PosLabel.Size = new System.Drawing.Size(22, 13);
            this.PosLabel.TabIndex = 2;
            this.PosLabel.Text = "0,0";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.PosLabel);
            this.Controls.Add(this.Scene);
            this.Controls.Add(this.AppMenu);
            this.MainMenuStrip = this.AppMenu;
            this.Name = "MainForm";
            this.Text = "Form1";
            this.AppMenu.ResumeLayout(false);
            this.AppMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controls.Scene Scene;
        private System.Windows.Forms.MenuStrip AppMenu;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.Label PosLabel;
    }
}

