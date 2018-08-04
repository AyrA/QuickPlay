namespace quickPlay
{
    partial class frmMain
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
            this.components = new System.ComponentModel.Container();
            this.tPlayerUpdate = new System.Windows.Forms.Timer(this.components);
            this.pbTime = new System.Windows.Forms.ProgressBar();
            this.pDrop = new System.Windows.Forms.Panel();
            this.lblInfo = new System.Windows.Forms.Label();
            this.btnPause = new System.Windows.Forms.Button();
            this.btnRest = new System.Windows.Forms.Button();
            this.btnSeekBack = new System.Windows.Forms.Button();
            this.btnSeekFwd = new System.Windows.Forms.Button();
            this.tbVolume = new System.Windows.Forms.TrackBar();
            this.pDrop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbVolume)).BeginInit();
            this.SuspendLayout();
            // 
            // tPlayerUpdate
            // 
            this.tPlayerUpdate.Tick += new System.EventHandler(this.tPlayerUpdate_Tick);
            // 
            // pbTime
            // 
            this.pbTime.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbTime.BackColor = System.Drawing.Color.Black;
            this.pbTime.ForeColor = System.Drawing.Color.Red;
            this.pbTime.Location = new System.Drawing.Point(12, 127);
            this.pbTime.Name = "pbTime";
            this.pbTime.Size = new System.Drawing.Size(224, 23);
            this.pbTime.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.pbTime.TabIndex = 5;
            this.pbTime.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pbTime_MouseClick);
            // 
            // pDrop
            // 
            this.pDrop.AllowDrop = true;
            this.pDrop.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pDrop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pDrop.Controls.Add(this.lblInfo);
            this.pDrop.Location = new System.Drawing.Point(12, 12);
            this.pDrop.Name = "pDrop";
            this.pDrop.Size = new System.Drawing.Size(225, 47);
            this.pDrop.TabIndex = 1;
            this.pDrop.DragDrop += new System.Windows.Forms.DragEventHandler(this.pDrop_DragDrop);
            this.pDrop.DragEnter += new System.Windows.Forms.DragEventHandler(this.pDrop_DragEnter);
            // 
            // lblInfo
            // 
            this.lblInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblInfo.Location = new System.Drawing.Point(0, 0);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(223, 45);
            this.lblInfo.TabIndex = 0;
            this.lblInfo.Text = "Drag a File to play over here";
            this.lblInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblInfo.DragLeave += new System.EventHandler(this.lblInfo_DragLeave);
            this.lblInfo.DoubleClick += new System.EventHandler(this.lblInfo_DoubleClick);
            // 
            // btnPause
            // 
            this.btnPause.Location = new System.Drawing.Point(12, 65);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(61, 23);
            this.btnPause.TabIndex = 0;
            this.btnPause.Text = "Pause";
            this.btnPause.UseVisualStyleBackColor = true;
            this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
            // 
            // btnRest
            // 
            this.btnRest.Location = new System.Drawing.Point(81, 65);
            this.btnRest.Name = "btnRest";
            this.btnRest.Size = new System.Drawing.Size(61, 23);
            this.btnRest.TabIndex = 1;
            this.btnRest.Text = "Restart";
            this.btnRest.UseVisualStyleBackColor = true;
            this.btnRest.Click += new System.EventHandler(this.btnRest_Click);
            // 
            // btnSeekBack
            // 
            this.btnSeekBack.Location = new System.Drawing.Point(150, 65);
            this.btnSeekBack.Name = "btnSeekBack";
            this.btnSeekBack.Size = new System.Drawing.Size(38, 23);
            this.btnSeekBack.TabIndex = 2;
            this.btnSeekBack.Text = "<<";
            this.btnSeekBack.UseVisualStyleBackColor = true;
            this.btnSeekBack.Click += new System.EventHandler(this.btnSeekBack_Click);
            // 
            // btnSeekFwd
            // 
            this.btnSeekFwd.Location = new System.Drawing.Point(199, 65);
            this.btnSeekFwd.Name = "btnSeekFwd";
            this.btnSeekFwd.Size = new System.Drawing.Size(38, 23);
            this.btnSeekFwd.TabIndex = 3;
            this.btnSeekFwd.Text = ">>";
            this.btnSeekFwd.UseVisualStyleBackColor = true;
            this.btnSeekFwd.Click += new System.EventHandler(this.btnSeekFwd_Click);
            // 
            // tbVolume
            // 
            this.tbVolume.LargeChange = 10;
            this.tbVolume.Location = new System.Drawing.Point(12, 94);
            this.tbVolume.Maximum = 100;
            this.tbVolume.Name = "tbVolume";
            this.tbVolume.Size = new System.Drawing.Size(224, 42);
            this.tbVolume.SmallChange = 5;
            this.tbVolume.TabIndex = 4;
            this.tbVolume.TickFrequency = 10;
            this.tbVolume.Value = 100;
            this.tbVolume.ValueChanged += new System.EventHandler(this.tbVolume_ValueChanged);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(249, 161);
            this.Controls.Add(this.pbTime);
            this.Controls.Add(this.tbVolume);
            this.Controls.Add(this.btnSeekFwd);
            this.Controls.Add(this.btnSeekBack);
            this.Controls.Add(this.btnRest);
            this.Controls.Add(this.btnPause);
            this.Controls.Add(this.pDrop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMain";
            this.Text = "Quick Play";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmMain_KeyDown);
            this.pDrop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tbVolume)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer tPlayerUpdate;
        private System.Windows.Forms.ProgressBar pbTime;
        private System.Windows.Forms.Panel pDrop;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.Button btnRest;
        private System.Windows.Forms.Button btnSeekBack;
        private System.Windows.Forms.Button btnSeekFwd;
        private System.Windows.Forms.TrackBar tbVolume;
    }
}

