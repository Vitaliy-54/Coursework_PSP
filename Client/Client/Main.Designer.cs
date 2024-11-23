using System.Drawing.Drawing2D;
using System.Drawing;
using System.Windows.Forms;

namespace Client
{
    partial class Main
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.songsPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.currentTimeLabel = new System.Windows.Forms.Label();
            this.seekBar = new System.Windows.Forms.TrackBar();
            this.playbackTimer = new System.Windows.Forms.Timer(this.components);
            this.audio_listLabel = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.Settings = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.DarkThemeButton = new System.Windows.Forms.ToolStripMenuItem();
            this.LightThemeButton = new System.Windows.Forms.ToolStripMenuItem();
            this.SiteInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.info = new System.Windows.Forms.ToolStripLabel();
            this.ConnectButton = new System.Windows.Forms.ToolStripButton();
            this.StopPlayButton = new System.Windows.Forms.Button();
            this.NameLabel = new System.Windows.Forms.Label();
            this.ArtistLabel = new System.Windows.Forms.Label();
            this.PrevButton = new System.Windows.Forms.Button();
            this.NextButton = new System.Windows.Forms.Button();
            this.volumeTrackBar = new System.Windows.Forms.TrackBar();
            this.vol_label = new System.Windows.Forms.Label();
            this.volumeLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.seekBar)).BeginInit();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.volumeTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // songsPanel
            // 
            this.songsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.songsPanel.AutoScroll = true;
            this.songsPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.songsPanel.Location = new System.Drawing.Point(21, 68);
            this.songsPanel.Name = "songsPanel";
            this.songsPanel.Size = new System.Drawing.Size(1014, 456);
            this.songsPanel.TabIndex = 0;
            // 
            // currentTimeLabel
            // 
            this.currentTimeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.currentTimeLabel.AutoSize = true;
            this.currentTimeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.currentTimeLabel.Location = new System.Drawing.Point(20, 535);
            this.currentTimeLabel.Name = "currentTimeLabel";
            this.currentTimeLabel.Size = new System.Drawing.Size(228, 15);
            this.currentTimeLabel.TabIndex = 3;
            this.currentTimeLabel.Text = "Время воспроизведения: 00:00 / 00:00";
            this.currentTimeLabel.Visible = false;
            // 
            // seekBar
            // 
            this.seekBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.seekBar.BackColor = System.Drawing.SystemColors.MenuBar;
            this.seekBar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.seekBar.LargeChange = 1;
            this.seekBar.Location = new System.Drawing.Point(23, 561);
            this.seekBar.Maximum = 300;
            this.seekBar.Name = "seekBar";
            this.seekBar.Size = new System.Drawing.Size(940, 45);
            this.seekBar.TabIndex = 4;
            this.seekBar.TabStop = false;
            this.seekBar.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.seekBar.Visible = false;
            this.seekBar.Scroll += new System.EventHandler(this.SeekBar_Scroll);
            // 
            // playbackTimer
            // 
            this.playbackTimer.Interval = 1000;
            this.playbackTimer.Tick += new System.EventHandler(this.PlaybackTimer_Tick);
            // 
            // audio_listLabel
            // 
            this.audio_listLabel.AutoSize = true;
            this.audio_listLabel.Font = new System.Drawing.Font("Calisto MT", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.audio_listLabel.Location = new System.Drawing.Point(18, 34);
            this.audio_listLabel.Name = "audio_listLabel";
            this.audio_listLabel.Size = new System.Drawing.Size(188, 20);
            this.audio_listLabel.TabIndex = 5;
            this.audio_listLabel.Text = "Список аудиотреков:";
            this.audio_listLabel.Visible = false;
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.Menu;
            this.toolStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Settings,
            this.info,
            this.ConnectButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1060, 25);
            this.toolStrip1.TabIndex = 7;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // Settings
            // 
            this.Settings.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Settings.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.SiteInfo});
            this.Settings.Image = ((System.Drawing.Image)(resources.GetObject("Settings.Image")));
            this.Settings.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Settings.Name = "Settings";
            this.Settings.Size = new System.Drawing.Size(29, 22);
            this.Settings.Text = "Настройки";
            this.Settings.Visible = false;
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DarkThemeButton,
            this.LightThemeButton});
            this.toolStripMenuItem1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(105, 22);
            this.toolStripMenuItem1.Text = "Тема";
            // 
            // DarkThemeButton
            // 
            this.DarkThemeButton.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F);
            this.DarkThemeButton.Name = "DarkThemeButton";
            this.DarkThemeButton.Size = new System.Drawing.Size(159, 22);
            this.DarkThemeButton.Text = "Темная тема";
            this.DarkThemeButton.Click += new System.EventHandler(this.DarkThemeButton_Click);
            // 
            // LightThemeButton
            // 
            this.LightThemeButton.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F);
            this.LightThemeButton.Name = "LightThemeButton";
            this.LightThemeButton.Size = new System.Drawing.Size(159, 22);
            this.LightThemeButton.Text = "Светлая тема";
            this.LightThemeButton.Click += new System.EventHandler(this.LightThemeButton_Click);
            // 
            // SiteInfo
            // 
            this.SiteInfo.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.SiteInfo.Name = "SiteInfo";
            this.SiteInfo.Size = new System.Drawing.Size(105, 22);
            this.SiteInfo.Text = "Сайт";
            this.SiteInfo.Click += new System.EventHandler(this.SiteInfo_Click);
            // 
            // info
            // 
            this.info.Font = new System.Drawing.Font("Calisto MT", 11.25F, System.Drawing.FontStyle.Bold);
            this.info.Name = "info";
            this.info.Size = new System.Drawing.Size(429, 22);
            this.info.Text = "Для прослушивания треков, подключитесь к серверу:";
            // 
            // ConnectButton
            // 
            this.ConnectButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ConnectButton.Image = ((System.Drawing.Image)(resources.GetObject("ConnectButton.Image")));
            this.ConnectButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ConnectButton.Name = "ConnectButton";
            this.ConnectButton.Size = new System.Drawing.Size(23, 22);
            this.ConnectButton.Text = "Сервер";
            this.ConnectButton.Click += new System.EventHandler(this.ConnectButton_Click);
            // 
            // StopPlayButton
            // 
            this.StopPlayButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.StopPlayButton.BackColor = System.Drawing.Color.LightGray;
            this.StopPlayButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.StopPlayButton.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.StopPlayButton.FlatAppearance.BorderSize = 0;
            this.StopPlayButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.StopPlayButton.Image = ((System.Drawing.Image)(resources.GetObject("StopPlayButton.Image")));
            this.StopPlayButton.Location = new System.Drawing.Point(85, 618);
            this.StopPlayButton.Name = "StopPlayButton";
            this.StopPlayButton.Size = new System.Drawing.Size(38, 38);
            this.StopPlayButton.TabIndex = 8;
            this.StopPlayButton.UseVisualStyleBackColor = false;
            this.StopPlayButton.Visible = false;
            this.StopPlayButton.Click += new System.EventHandler(this.StopPlayButton_Click);
            // 
            // NameLabel
            // 
            this.NameLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.NameLabel.AutoSize = true;
            this.NameLabel.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NameLabel.Location = new System.Drawing.Point(192, 618);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(93, 18);
            this.NameLabel.TabIndex = 9;
            this.NameLabel.Text = "NameSongs";
            this.NameLabel.Visible = false;
            // 
            // ArtistLabel
            // 
            this.ArtistLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ArtistLabel.AutoSize = true;
            this.ArtistLabel.Font = new System.Drawing.Font("Arial", 9F);
            this.ArtistLabel.Location = new System.Drawing.Point(192, 636);
            this.ArtistLabel.Name = "ArtistLabel";
            this.ArtistLabel.Size = new System.Drawing.Size(68, 15);
            this.ArtistLabel.TabIndex = 10;
            this.ArtistLabel.Text = "NameArtist";
            this.ArtistLabel.Visible = false;
            // 
            // PrevButton
            // 
            this.PrevButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.PrevButton.BackColor = System.Drawing.Color.LightGray;
            this.PrevButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PrevButton.FlatAppearance.BorderSize = 0;
            this.PrevButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PrevButton.Image = ((System.Drawing.Image)(resources.GetObject("PrevButton.Image")));
            this.PrevButton.Location = new System.Drawing.Point(32, 618);
            this.PrevButton.Name = "PrevButton";
            this.PrevButton.Size = new System.Drawing.Size(38, 38);
            this.PrevButton.TabIndex = 11;
            this.PrevButton.TabStop = false;
            this.PrevButton.UseVisualStyleBackColor = false;
            this.PrevButton.Visible = false;
            this.PrevButton.Click += new System.EventHandler(this.PrevButton_Click);
            this.PrevButton.Enter += new System.EventHandler(this.Button_Enter);
            // 
            // NextButton
            // 
            this.NextButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.NextButton.BackColor = System.Drawing.Color.LightGray;
            this.NextButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.NextButton.FlatAppearance.BorderSize = 0;
            this.NextButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.NextButton.Image = ((System.Drawing.Image)(resources.GetObject("NextButton.Image")));
            this.NextButton.Location = new System.Drawing.Point(138, 618);
            this.NextButton.Name = "NextButton";
            this.NextButton.Size = new System.Drawing.Size(38, 38);
            this.NextButton.TabIndex = 12;
            this.NextButton.TabStop = false;
            this.NextButton.UseVisualStyleBackColor = false;
            this.NextButton.Visible = false;
            this.NextButton.Click += new System.EventHandler(this.NextButton_Click);
            this.NextButton.Enter += new System.EventHandler(this.Button_Enter);
            // 
            // volumeTrackBar
            // 
            this.volumeTrackBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.volumeTrackBar.BackColor = System.Drawing.SystemColors.Menu;
            this.volumeTrackBar.LargeChange = 10;
            this.volumeTrackBar.Location = new System.Drawing.Point(837, 612);
            this.volumeTrackBar.Maximum = 100;
            this.volumeTrackBar.Name = "volumeTrackBar";
            this.volumeTrackBar.Size = new System.Drawing.Size(125, 45);
            this.volumeTrackBar.TabIndex = 14;
            this.volumeTrackBar.TickFrequency = 10;
            this.volumeTrackBar.Value = 50;
            this.volumeTrackBar.Visible = false;
            this.volumeTrackBar.Scroll += new System.EventHandler(this.VolumeTrackBar_Scroll);
            // 
            // vol_label
            // 
            this.vol_label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.vol_label.AutoSize = true;
            this.vol_label.Location = new System.Drawing.Point(838, 644);
            this.vol_label.Name = "vol_label";
            this.vol_label.Size = new System.Drawing.Size(65, 13);
            this.vol_label.TabIndex = 15;
            this.vol_label.Text = "Громкость:";
            this.vol_label.Visible = false;
            // 
            // volumeLabel
            // 
            this.volumeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.volumeLabel.AutoSize = true;
            this.volumeLabel.Location = new System.Drawing.Point(900, 644);
            this.volumeLabel.Name = "volumeLabel";
            this.volumeLabel.Size = new System.Drawing.Size(33, 13);
            this.volumeLabel.TabIndex = 16;
            this.volumeLabel.Text = "value";
            this.volumeLabel.Visible = false;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Menu;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(1060, 681);
            this.Controls.Add(this.volumeLabel);
            this.Controls.Add(this.vol_label);
            this.Controls.Add(this.NextButton);
            this.Controls.Add(this.PrevButton);
            this.Controls.Add(this.ArtistLabel);
            this.Controls.Add(this.NameLabel);
            this.Controls.Add(this.StopPlayButton);
            this.Controls.Add(this.audio_listLabel);
            this.Controls.Add(this.seekBar);
            this.Controls.Add(this.currentTimeLabel);
            this.Controls.Add(this.songsPanel);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.volumeTrackBar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main";
            this.Text = "Музыка";
            ((System.ComponentModel.ISupportInitialize)(this.seekBar)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.volumeTrackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.FlowLayoutPanel songsPanel;
        private System.Windows.Forms.Label currentTimeLabel;
        private System.Windows.Forms.TrackBar seekBar;
        private System.Windows.Forms.Timer playbackTimer;
        private System.Windows.Forms.Label audio_listLabel;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel info;
        private System.Windows.Forms.ToolStripButton ConnectButton;
        private System.Windows.Forms.ToolStripDropDownButton Settings;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem DarkThemeButton;
        private System.Windows.Forms.ToolStripMenuItem LightThemeButton;
        private System.Windows.Forms.ToolStripMenuItem SiteInfo;
        private System.Windows.Forms.Button StopPlayButton;
        private Label NameLabel;
        private Label ArtistLabel;
        private Button PrevButton;
        private Button NextButton;
        private TrackBar volumeTrackBar;
        private Label vol_label;
        private Label volumeLabel;
    }
}

