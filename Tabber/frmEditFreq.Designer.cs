namespace Tabber
{
    partial class frmEditFreq
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
            this.lblEdit = new System.Windows.Forms.Label();
            this.txtEditFreq = new System.Windows.Forms.TextBox();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblEdit
            // 
            this.lblEdit.AutoSize = true;
            this.lblEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEdit.Location = new System.Drawing.Point(32, 9);
            this.lblEdit.Name = "lblEdit";
            this.lblEdit.Size = new System.Drawing.Size(101, 40);
            this.lblEdit.TabIndex = 0;
            this.lblEdit.Text = "Time to Wait:\r\n(minutes)";
            // 
            // txtEditFreq
            // 
            this.txtEditFreq.BackColor = System.Drawing.Color.White;
            this.txtEditFreq.ForeColor = System.Drawing.Color.Black;
            this.txtEditFreq.Location = new System.Drawing.Point(139, 11);
            this.txtEditFreq.Name = "txtEditFreq";
            this.txtEditFreq.Size = new System.Drawing.Size(133, 20);
            this.txtEditFreq.TabIndex = 1;
            // 
            // btnConfirm
            // 
            this.btnConfirm.Location = new System.Drawing.Point(139, 67);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(133, 23);
            this.btnConfirm.TabIndex = 2;
            this.btnConfirm.Text = "Confirm Change";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // frmEditFreq
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 102);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.txtEditFreq);
            this.Controls.Add(this.lblEdit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmEditFreq";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Edit Frequency";
            this.Load += new System.EventHandler(this.frmEditFreq_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblEdit;
        private System.Windows.Forms.TextBox txtEditFreq;
        private System.Windows.Forms.Button btnConfirm;
    }
}