namespace Tabber
{
    partial class frmTab
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTab));
            this.cmbProcesses = new System.Windows.Forms.ComboBox();
            this.btnAddQueue = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.lstQueue = new System.Windows.Forms.ListBox();
            this.lblProcessCmb = new System.Windows.Forms.Label();
            this.btnRemoveQueue = new System.Windows.Forms.Button();
            this.lblQueueData = new System.Windows.Forms.Label();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnSwapper = new System.Windows.Forms.Button();
            this.lblAltText = new System.Windows.Forms.Label();
            this.btnEditFreq = new System.Windows.Forms.Button();
            this.chkChyron = new System.Windows.Forms.CheckBox();
            this.btnSentences = new System.Windows.Forms.Button();
            this.txtSentenceOne = new System.Windows.Forms.TextBox();
            this.txtSentenceTwo = new System.Windows.Forms.TextBox();
            this.txtSentenceThree = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbProcesses
            // 
            this.cmbProcesses.FormattingEnabled = true;
            this.cmbProcesses.Location = new System.Drawing.Point(128, 28);
            this.cmbProcesses.Name = "cmbProcesses";
            this.cmbProcesses.Size = new System.Drawing.Size(213, 21);
            this.cmbProcesses.TabIndex = 1;
            // 
            // btnAddQueue
            // 
            this.btnAddQueue.Location = new System.Drawing.Point(128, 55);
            this.btnAddQueue.Name = "btnAddQueue";
            this.btnAddQueue.Size = new System.Drawing.Size(121, 23);
            this.btnAddQueue.TabIndex = 4;
            this.btnAddQueue.Text = "Add";
            this.btnAddQueue.UseVisualStyleBackColor = true;
            this.btnAddQueue.Click += new System.EventHandler(this.btnAddQueue_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(255, 55);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(120, 23);
            this.btnRefresh.TabIndex = 5;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // lstQueue
            // 
            this.lstQueue.FormattingEnabled = true;
            this.lstQueue.Location = new System.Drawing.Point(128, 113);
            this.lstQueue.Name = "lstQueue";
            this.lstQueue.Size = new System.Drawing.Size(246, 95);
            this.lstQueue.TabIndex = 9;
            // 
            // lblProcessCmb
            // 
            this.lblProcessCmb.AutoSize = true;
            this.lblProcessCmb.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProcessCmb.Location = new System.Drawing.Point(3, 26);
            this.lblProcessCmb.Name = "lblProcessCmb";
            this.lblProcessCmb.Size = new System.Drawing.Size(119, 20);
            this.lblProcessCmb.TabIndex = 0;
            this.lblProcessCmb.Text = "Currently Open:";
            // 
            // btnRemoveQueue
            // 
            this.btnRemoveQueue.Location = new System.Drawing.Point(128, 214);
            this.btnRemoveQueue.Name = "btnRemoveQueue";
            this.btnRemoveQueue.Size = new System.Drawing.Size(121, 23);
            this.btnRemoveQueue.TabIndex = 10;
            this.btnRemoveQueue.Text = "Remove";
            this.btnRemoveQueue.UseVisualStyleBackColor = true;
            this.btnRemoveQueue.Click += new System.EventHandler(this.btnRemoveQueue_Click);
            // 
            // lblQueueData
            // 
            this.lblQueueData.AutoSize = true;
            this.lblQueueData.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQueueData.Location = new System.Drawing.Point(33, 113);
            this.lblQueueData.Name = "lblQueueData";
            this.lblQueueData.Size = new System.Drawing.Size(89, 20);
            this.lblQueueData.TabIndex = 8;
            this.lblQueueData.Text = "The queue:";
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(348, 27);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(27, 23);
            this.btnBrowse.TabIndex = 2;
            this.btnBrowse.Text = "...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(255, 84);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(120, 23);
            this.btnStop.TabIndex = 7;
            this.btnStop.Text = "Stop App";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnSwapper
            // 
            this.btnSwapper.Location = new System.Drawing.Point(255, 214);
            this.btnSwapper.Name = "btnSwapper";
            this.btnSwapper.Size = new System.Drawing.Size(119, 23);
            this.btnSwapper.TabIndex = 11;
            this.btnSwapper.Text = "Start Swapping";
            this.btnSwapper.UseVisualStyleBackColor = true;
            this.btnSwapper.Click += new System.EventHandler(this.btnSwapper_Click);
            // 
            // lblAltText
            // 
            this.lblAltText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAltText.Location = new System.Drawing.Point(4, 46);
            this.lblAltText.Name = "lblAltText";
            this.lblAltText.Size = new System.Drawing.Size(120, 50);
            this.lblAltText.TabIndex = 3;
            this.lblAltText.Text = "Alternatively, you may enter a web URL into the box.";
            // 
            // btnEditFreq
            // 
            this.btnEditFreq.Location = new System.Drawing.Point(128, 84);
            this.btnEditFreq.Name = "btnEditFreq";
            this.btnEditFreq.Size = new System.Drawing.Size(121, 23);
            this.btnEditFreq.TabIndex = 6;
            this.btnEditFreq.Text = "Edit Frequency";
            this.btnEditFreq.UseVisualStyleBackColor = true;
            this.btnEditFreq.Click += new System.EventHandler(this.btnEditFreq_Click);
            // 
            // chkChyron
            // 
            this.chkChyron.AutoSize = true;
            this.chkChyron.Location = new System.Drawing.Point(57, 218);
            this.chkChyron.Name = "chkChyron";
            this.chkChyron.Size = new System.Drawing.Size(65, 17);
            this.chkChyron.TabIndex = 12;
            this.chkChyron.Text = "Chyron?";
            this.chkChyron.UseVisualStyleBackColor = true;
            this.chkChyron.CheckedChanged += new System.EventHandler(this.chkChyron_CheckedChanged);
            // 
            // btnSentences
            // 
            this.btnSentences.Location = new System.Drawing.Point(254, 377);
            this.btnSentences.Name = "btnSentences";
            this.btnSentences.Size = new System.Drawing.Size(119, 23);
            this.btnSentences.TabIndex = 20;
            this.btnSentences.Text = "Start Chyron";
            this.btnSentences.UseVisualStyleBackColor = true;
            this.btnSentences.Click += new System.EventHandler(this.btnSentences_Click);
            // 
            // txtSentenceOne
            // 
            this.txtSentenceOne.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSentenceOne.Location = new System.Drawing.Point(126, 299);
            this.txtSentenceOne.Name = "txtSentenceOne";
            this.txtSentenceOne.Size = new System.Drawing.Size(247, 20);
            this.txtSentenceOne.TabIndex = 15;
            // 
            // txtSentenceTwo
            // 
            this.txtSentenceTwo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSentenceTwo.Location = new System.Drawing.Point(126, 325);
            this.txtSentenceTwo.Name = "txtSentenceTwo";
            this.txtSentenceTwo.Size = new System.Drawing.Size(247, 20);
            this.txtSentenceTwo.TabIndex = 17;
            // 
            // txtSentenceThree
            // 
            this.txtSentenceThree.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSentenceThree.Location = new System.Drawing.Point(126, 351);
            this.txtSentenceThree.Name = "txtSentenceThree";
            this.txtSentenceThree.Size = new System.Drawing.Size(246, 20);
            this.txtSentenceThree.TabIndex = 19;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(55, 301);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Sentence 1:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(52, 327);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Sentence  2:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(55, 353);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "Sentence 3:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(122, 276);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(140, 20);
            this.label4.TabIndex = 13;
            this.label4.Text = "Chyron Sentences";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(384, 24);
            this.menuStrip1.TabIndex = 21;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            this.helpToolStripMenuItem.Click += new System.EventHandler(this.helpToolStripMenuItem_Click);
            // 
            // frmTab
            // 
            this.AcceptButton = this.btnAddQueue;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 252);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSentenceThree);
            this.Controls.Add(this.txtSentenceTwo);
            this.Controls.Add(this.txtSentenceOne);
            this.Controls.Add(this.btnSentences);
            this.Controls.Add(this.chkChyron);
            this.Controls.Add(this.btnEditFreq);
            this.Controls.Add(this.lblAltText);
            this.Controls.Add(this.btnSwapper);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.lblQueueData);
            this.Controls.Add(this.btnRemoveQueue);
            this.Controls.Add(this.lblProcessCmb);
            this.Controls.Add(this.lstQueue);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnAddQueue);
            this.Controls.Add(this.cmbProcesses);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmTab";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tabber";
            this.Load += new System.EventHandler(this.frmTab_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbProcesses;
        private System.Windows.Forms.Button btnAddQueue;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.ListBox lstQueue;
        private System.Windows.Forms.Label lblProcessCmb;
        private System.Windows.Forms.Button btnRemoveQueue;
        private System.Windows.Forms.Label lblQueueData;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnSwapper;
        private System.Windows.Forms.Label lblAltText;
        private System.Windows.Forms.Button btnEditFreq;
        private System.Windows.Forms.CheckBox chkChyron;
        private System.Windows.Forms.Button btnSentences;
        private System.Windows.Forms.TextBox txtSentenceOne;
        private System.Windows.Forms.TextBox txtSentenceTwo;
        private System.Windows.Forms.TextBox txtSentenceThree;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
    }
}

