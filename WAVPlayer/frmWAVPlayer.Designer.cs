namespace WAVPlayer
{
    partial class frmWAVPlayer
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        private void InitializeComponent()
        {
            this.grpPath      = new System.Windows.Forms.GroupBox();
            this.btnBrowse    = new System.Windows.Forms.Button();
            this.txtPath      = new System.Windows.Forms.TextBox();
            this.grpButton    = new System.Windows.Forms.GroupBox();
            this.btnEnd       = new System.Windows.Forms.Button();
            this.btnStop      = new System.Windows.Forms.Button();
            this.btnLoop      = new System.Windows.Forms.Button();
            this.btnPlay      = new System.Windows.Forms.Button();
            this.grpInfo      = new System.Windows.Forms.GroupBox();
            this.lblFileInfo  = new System.Windows.Forms.Label();
            this.lblStatus    = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusDot   = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.ofdWAVFile   = new System.Windows.Forms.OpenFileDialog();

            this.grpPath.SuspendLayout();
            this.grpButton.SuspendLayout();
            this.grpInfo.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();

            // ── grpPath ──────────────────────────────
            this.grpPath.Controls.Add(this.btnBrowse);
            this.grpPath.Controls.Add(this.txtPath);
            this.grpPath.Font     = new System.Drawing.Font("微軟正黑體", 11F);
            this.grpPath.Location = new System.Drawing.Point(20, 20);
            this.grpPath.Name     = "grpPath";
            this.grpPath.Size     = new System.Drawing.Size(960, 110);
            this.grpPath.TabIndex = 0;
            this.grpPath.TabStop  = false;
            this.grpPath.Text     = "  音效位置";

            // txtPath
            this.txtPath.Location  = new System.Drawing.Point(20, 48);
            this.txtPath.Name      = "txtPath";
            this.txtPath.Size      = new System.Drawing.Size(740, 36);
            this.txtPath.TabIndex  = 0;
            this.txtPath.Font      = new System.Drawing.Font("微軟正黑體", 10F);
            this.txtPath.ReadOnly  = true;

            // btnBrowse
            this.btnBrowse.Location = new System.Drawing.Point(780, 42);
            this.btnBrowse.Name     = "btnBrowse";
            this.btnBrowse.Size     = new System.Drawing.Size(150, 48);
            this.btnBrowse.TabIndex = 1;
            this.btnBrowse.Text     = "📂  瀏覽";
            this.btnBrowse.UseVisualStyleBackColor = false;
            this.btnBrowse.Click   += new System.EventHandler(this.btnBrowse_Click);

            // ── grpInfo ──────────────────────────────
            this.grpInfo.Controls.Add(this.lblFileInfo);
            this.grpInfo.Font     = new System.Drawing.Font("微軟正黑體", 11F);
            this.grpInfo.Location = new System.Drawing.Point(20, 148);
            this.grpInfo.Name     = "grpInfo";
            this.grpInfo.Size     = new System.Drawing.Size(960, 80);
            this.grpInfo.TabIndex = 2;
            this.grpInfo.TabStop  = false;
            this.grpInfo.Text     = "  音效資訊";

            // lblFileInfo
            this.lblFileInfo.Location  = new System.Drawing.Point(20, 38);
            this.lblFileInfo.Name      = "lblFileInfo";
            this.lblFileInfo.Size      = new System.Drawing.Size(920, 30);
            this.lblFileInfo.Font      = new System.Drawing.Font("微軟正黑體", 9.5F);
            this.lblFileInfo.Text      = "尚未載入檔案";
            this.lblFileInfo.AutoSize  = false;

            // ── grpButton ────────────────────────────
            this.grpButton.Controls.Add(this.btnPlay);
            this.grpButton.Controls.Add(this.btnLoop);
            this.grpButton.Controls.Add(this.btnStop);
            this.grpButton.Controls.Add(this.btnEnd);
            this.grpButton.Font     = new System.Drawing.Font("微軟正黑體", 11F);
            this.grpButton.Location = new System.Drawing.Point(20, 246);
            this.grpButton.Name     = "grpButton";
            this.grpButton.Size     = new System.Drawing.Size(960, 120);
            this.grpButton.TabIndex = 1;
            this.grpButton.TabStop  = false;
            this.grpButton.Text     = "  播放控制";

            // btnPlay
            this.btnPlay.Enabled  = false;
            this.btnPlay.Location = new System.Drawing.Point(20, 46);
            this.btnPlay.Name     = "btnPlay";
            this.btnPlay.Size     = new System.Drawing.Size(200, 54);
            this.btnPlay.TabIndex = 2;
            this.btnPlay.Text     = "▶  播放一次";
            this.btnPlay.UseVisualStyleBackColor = false;
            this.btnPlay.Click   += new System.EventHandler(this.btnPlay_Click);

            // btnLoop
            this.btnLoop.Enabled  = false;
            this.btnLoop.Location = new System.Drawing.Point(240, 46);
            this.btnLoop.Name     = "btnLoop";
            this.btnLoop.Size     = new System.Drawing.Size(200, 54);
            this.btnLoop.TabIndex = 3;
            this.btnLoop.Text     = "🔁  重複播放";
            this.btnLoop.UseVisualStyleBackColor = false;
            this.btnLoop.Click   += new System.EventHandler(this.btnLoop_Click);

            // btnStop
            this.btnStop.Enabled  = false;
            this.btnStop.Location = new System.Drawing.Point(460, 46);
            this.btnStop.Name     = "btnStop";
            this.btnStop.Size     = new System.Drawing.Size(200, 54);
            this.btnStop.TabIndex = 4;
            this.btnStop.Text     = "⏹  停止播放";
            this.btnStop.UseVisualStyleBackColor = false;
            this.btnStop.Click   += new System.EventHandler(this.btnStop_Click);

            // btnEnd
            this.btnEnd.Location = new System.Drawing.Point(700, 46);
            this.btnEnd.Name     = "btnEnd";
            this.btnEnd.Size     = new System.Drawing.Size(220, 54);
            this.btnEnd.TabIndex = 5;
            this.btnEnd.Text     = "✕  結束程式";
            this.btnEnd.UseVisualStyleBackColor = false;
            this.btnEnd.Click   += new System.EventHandler(this.btnEnd_Click);

            // ── statusStrip1 ─────────────────────────
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.toolStripStatusDot,
                this.toolStripStatusLabel1
            });
            this.statusStrip1.Location = new System.Drawing.Point(0, 388);
            this.statusStrip1.Name     = "statusStrip1";
            this.statusStrip1.Size     = new System.Drawing.Size(1000, 28);
            this.statusStrip1.SizingGrip = false;

            this.toolStripStatusDot.Name    = "toolStripStatusDot";
            this.toolStripStatusDot.Text    = "○";
            this.toolStripStatusDot.Font    = new System.Drawing.Font("Segoe UI", 10F);

            this.toolStripStatusLabel1.Name    = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Text    = "就緒";
            this.toolStripStatusLabel1.Font    = new System.Drawing.Font("微軟正黑體", 9F);

            // ── lblStatus (隱藏備用) ──────────────────
            this.lblStatus.Location  = new System.Drawing.Point(0, 0);
            this.lblStatus.Name      = "lblStatus";
            this.lblStatus.Size      = new System.Drawing.Size(0, 0);
            this.lblStatus.Text      = "";

            // ── ofdWAVFile ────────────────────────────
            this.ofdWAVFile.DefaultExt = "wav";

            // ── frmWAVPlayer ──────────────────────────
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode  = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize     = new System.Drawing.Size(1000, 416);
            this.Controls.Add(this.grpPath);
            this.Controls.Add(this.grpInfo);
            this.Controls.Add(this.grpButton);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.lblStatus);
            this.MinimumSize    = new System.Drawing.Size(1000, 460);
            this.Name           = "frmWAVPlayer";
            this.StartPosition  = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text           = "🎵 WAV 播放器";
            this.FormClosing   += new System.Windows.Forms.FormClosingEventHandler(this.frmWAVPlayer_FormClosing);
            this.Load          += new System.EventHandler(this.frmWAVPlayer_Load);

            this.grpPath.ResumeLayout(false);
            this.grpPath.PerformLayout();
            this.grpInfo.ResumeLayout(false);
            this.grpButton.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.GroupBox  grpPath;
        private System.Windows.Forms.GroupBox  grpButton;
        private System.Windows.Forms.GroupBox  grpInfo;
        private System.Windows.Forms.Button    btnBrowse;
        private System.Windows.Forms.TextBox   txtPath;
        private System.Windows.Forms.Button    btnPlay;
        private System.Windows.Forms.Button    btnLoop;
        private System.Windows.Forms.Button    btnStop;
        private System.Windows.Forms.Button    btnEnd;
        private System.Windows.Forms.Label     lblFileInfo;
        private System.Windows.Forms.Label     lblStatus;
        private System.Windows.Forms.StatusStrip          statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusDot;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.OpenFileDialog       ofdWAVFile;
    }
}
