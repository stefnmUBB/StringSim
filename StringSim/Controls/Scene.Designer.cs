namespace StringSim.Controls
{
    partial class Scene
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.SimTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // SimTimer
            // 
            this.SimTimer.Interval = 50;
            this.SimTimer.Tick += new System.EventHandler(this.SimTimer_Tick);
            // 
            // Scene
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MintCream;
            this.Name = "Scene";
            this.Size = new System.Drawing.Size(567, 228);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer SimTimer;
    }
}
