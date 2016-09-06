namespace Olivetti
{
    partial class frmKasalar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmKasalar));
            this.lstKasalar = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // lstKasalar
            // 
            this.lstKasalar.FormattingEnabled = true;
            this.lstKasalar.Location = new System.Drawing.Point(12, 12);
            this.lstKasalar.Name = "lstKasalar";
            this.lstKasalar.Size = new System.Drawing.Size(260, 238);
            this.lstKasalar.TabIndex = 0;
            this.lstKasalar.SelectedIndexChanged += new System.EventHandler(this.lstKasalar_SelectedIndexChanged);
            // 
            // frmKasalar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.lstKasalar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmKasalar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kasalar";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmKasalar_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lstKasalar;
    }
}