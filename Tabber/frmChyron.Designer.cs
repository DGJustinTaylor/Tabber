namespace Tabber
{
    partial class frmChyron
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
            this.lblChyronText = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblChyronText
            // 
            this.lblChyronText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblChyronText.AutoSize = true;
            this.lblChyronText.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChyronText.ForeColor = System.Drawing.Color.White;
            this.lblChyronText.Location = new System.Drawing.Point(636, 386);
            this.lblChyronText.Name = "lblChyronText";
            this.lblChyronText.Size = new System.Drawing.Size(152, 55);
            this.lblChyronText.TabIndex = 0;
            this.lblChyronText.Text = "label1";
            this.lblChyronText.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // frmChyron
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.ControlBox = false;
            this.Controls.Add(this.lblChyronText);
            this.Name = "frmChyron";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Chyron";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Activated += new System.EventHandler(this.frmChyron_Activated);
            this.Load += new System.EventHandler(this.frmChyron_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblChyronText;
    }
}