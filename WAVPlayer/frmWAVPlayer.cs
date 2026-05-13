using System;
using System.Drawing;
using System.IO;
using System.Media;
using System.Windows.Forms;

namespace WAVPlayer
{
    public partial class frmWAVPlayer : Form
    {
        // 用來跨按鈕共用同一個播放器（停止功能才有效）
        private SoundPlayer _sharedPlayer = null;

        public frmWAVPlayer()
        {
            InitializeComponent();
            ApplyDarkTheme();

            // 啟用拖曳
            this.AllowDrop = true;
            this.DragEnter += new DragEventHandler(frmWAVPlayer_DragEnter);
            this.DragDrop  += new DragEventHandler(frmWAVPlayer_DragDrop);
        }

        // ──────────────────────────────────────────
        // 深色主題套用
        // ──────────────────────────────────────────
        private readonly Color _bg       = Color.FromArgb(30,  30,  46);
        private readonly Color _surface  = Color.FromArgb(49,  50,  68);
        private readonly Color _accent   = Color.FromArgb(137, 180, 250);
        private readonly Color _textMain = Color.FromArgb(205, 214, 244);
        private readonly Color _btnFg    = Color.FromArgb(30,  30,  46);

        private void ApplyDarkTheme()
        {
            this.BackColor = _bg;
            this.ForeColor = _textMain;

            grpPath.BackColor   = _bg;
            grpPath.ForeColor   = _accent;
            grpButton.BackColor = _bg;
            grpButton.ForeColor = _accent;
            grpInfo.BackColor   = _bg;
            grpInfo.ForeColor   = _accent;

            txtPath.BackColor = _surface;
            txtPath.ForeColor = _textMain;
            txtPath.BorderStyle = BorderStyle.FixedSingle;

            StyleButton(btnBrowse, _accent,   _btnFg);
            StyleButton(btnPlay,   Color.FromArgb(166, 227, 161), _btnFg);
            StyleButton(btnLoop,   Color.FromArgb(250, 179, 135), _btnFg);
            StyleButton(btnStop,   Color.FromArgb(243, 139, 168), _btnFg);
            StyleButton(btnEnd,    Color.FromArgb(180, 190, 254), _btnFg);

            lblFileInfo.ForeColor = _textMain;
            lblStatus.ForeColor   = Color.FromArgb(148, 226, 213);

            statusStrip1.BackColor = _surface;
            toolStripStatusLabel1.ForeColor = _textMain;
            toolStripStatusDot.ForeColor    = Color.FromArgb(108, 112, 134);
        }

        private void StyleButton(Button btn, Color back, Color fore)
        {
            btn.BackColor   = back;
            btn.ForeColor   = fore;
            btn.FlatStyle   = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize  = 0;
            btn.FlatAppearance.MouseOverBackColor =
                ControlPaint.Light(back, 0.3f);
            btn.Font        = new Font("微軟正黑體", 12F, FontStyle.Bold);
            btn.Cursor      = Cursors.Hand;
        }

        // ──────────────────────────────────────────
        // 拖曳事件
        // ──────────────────────────────────────────
        private void frmWAVPlayer_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
        }

        private void frmWAVPlayer_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (files.Length > 0 && files[0].ToLower().EndsWith(".wav"))
            {
                LoadFile(files[0]);
            }
            else
            {
                MessageBox.Show("請拖入 WAV 格式的音效檔案。", "格式錯誤",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // ──────────────────────────────────────────
        // 載入檔案（瀏覽 / 拖曳共用）
        // ──────────────────────────────────────────
        private void LoadFile(string path)
        {
            txtPath.Text = path;
            btnPlay.Enabled = true;
            btnLoop.Enabled = true;
            btnStop.Enabled = true;

            ShowWavInfo(path);
            UpdateStatus("已載入", Color.FromArgb(148, 226, 213), "●");
        }

        // ──────────────────────────────────────────
        // 顯示 WAV 檔案資訊（不需要外部套件）
        // ──────────────────────────────────────────
        private void ShowWavInfo(string path)
        {
            try
            {
                using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
                using (BinaryReader br = new BinaryReader(fs))
                {
                    // 讀取 WAV header
                    br.ReadBytes(22);                          // RIFF + size + WAVE + fmt  + chunkSize + audioFormat
                    int    channels   = br.ReadInt16();
                    int    sampleRate = br.ReadInt32();
                    br.ReadInt32();                            // byteRate
                    br.ReadInt16();                            // blockAlign
                    int    bitDepth   = br.ReadInt16();

                    // 跳到 data chunk 取得大小
                    fs.Seek(40, SeekOrigin.Begin);
                    int dataSize = br.ReadInt32();

                    double seconds   = (double)dataSize / (sampleRate * channels * bitDepth / 8);
                    string duration  = TimeSpan.FromSeconds(seconds).ToString(@"mm\:ss");
                    string chStr     = channels == 1 ? "單聲道" : "立體聲";
                    long   fileSizeKB = new FileInfo(path).Length / 1024;

                    lblFileInfo.Text =
                        $"取樣率：{sampleRate} Hz　｜　位元深度：{bitDepth} bit　｜　{chStr}　｜　" +
                        $"時長：{duration}　｜　檔案大小：{fileSizeKB} KB";
                }
            }
            catch
            {
                lblFileInfo.Text = "無法讀取音效資訊";
            }
        }

        // ──────────────────────────────────────────
        // 狀態列更新
        // ──────────────────────────────────────────
        private void UpdateStatus(string text, Color dotColor, string dot)
        {
            toolStripStatusLabel1.Text    = text;
            toolStripStatusDot.Text       = dot;
            toolStripStatusDot.ForeColor  = dotColor;
        }

        // ──────────────────────────────────────────
        // 按鈕事件
        // ──────────────────────────────────────────
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            ofdWAVFile.Filter = "WAV Files(*.wav)|*.wav";
            if (ofdWAVFile.ShowDialog() == DialogResult.OK)
                LoadFile(ofdWAVFile.FileName);
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            StopCurrent();
            _sharedPlayer = new SoundPlayer(txtPath.Text);
            _sharedPlayer.Load();
            _sharedPlayer.Play();
            UpdateStatus("播放中 ▶", Color.FromArgb(166, 227, 161), "●");
        }

        private void btnLoop_Click(object sender, EventArgs e)
        {
            StopCurrent();
            _sharedPlayer = new SoundPlayer(txtPath.Text);
            _sharedPlayer.PlayLooping();
            UpdateStatus("重複播放中 🔁", Color.FromArgb(250, 179, 135), "●");
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            StopCurrent();
            UpdateStatus("已停止 ⏹", Color.FromArgb(243, 139, 168), "■");
        }

        private void StopCurrent()
        {
            _sharedPlayer?.Stop();
        }

        private void btnEnd_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // ──────────────────────────────────────────
        // Form 事件
        // ──────────────────────────────────────────
        private void frmWAVPlayer_Load(object sender, EventArgs e)
        {
            UpdateStatus("請選擇或拖曳一個 WAV 檔案", Color.FromArgb(108, 112, 134), "○");
            MessageBox.Show(
                "歡迎使用 WAV 播放器！\n\n" +
                "• 點擊「瀏覽」選擇檔案\n" +
                "• 或直接將 WAV 檔案拖曳到視窗中",
                "歡迎", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void frmWAVPlayer_FormClosing(object sender, FormClosingEventArgs e)
        {
            var result = MessageBox.Show("確定要關閉應用程式嗎？", "關閉確認",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
                e.Cancel = true;
        }
    }
}
