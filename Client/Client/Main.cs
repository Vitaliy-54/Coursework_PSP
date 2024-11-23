using System;
using System.Net.Http;
using System.Windows.Forms;
using System.Threading.Tasks;
using NAudio.Wave;
using Newtonsoft.Json.Linq;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Client
{
    public partial class Main : Form
    {
        private IWavePlayer outputDevice;
        private MediaFoundationReader audioFile;
        private bool isPlaying = false;
        private Button currentPlayPauseButton;
        private string currentSongPath;
        private static readonly HttpClient client = new HttpClient();

        public Main()
        {
            InitializeComponent();
        }

        private async void ConnectButton_Click(object sender, EventArgs e)
        {
            using (Settings settingsForm = new Settings())
            {
                if (settingsForm.ShowDialog() == DialogResult.OK)
                {
                    string serverIP = settingsForm.ServerIP;

                    if (string.IsNullOrWhiteSpace(serverIP))
                    {
                        MessageBox.Show("Введите IP-адрес сервера.");
                        return;
                    }

                    try
                    {
                        int serverPort = settingsForm.ServerPort;

                        if (serverPort <= 0 || serverPort > 65535)
                        {
                            MessageBox.Show("Введите корректный порт сервера (от 1 до 65535).");
                            return;
                        }

                        if (outputDevice != null && (outputDevice.PlaybackState == PlaybackState.Playing || outputDevice.PlaybackState == PlaybackState.Paused))
                    {
                        outputDevice.Stop();
                        isPlaying = false;
                        currentPlayPauseButton.Image = Image.FromFile("ico/playIcon.png");
                        StopPlayButton.Image = Image.FromFile("ico/playIcon.png");
                        currentPlayPauseButton.ImageAlign = ContentAlignment.MiddleCenter;
                        playbackTimer.Stop();        
                        seekBar.Value = 0;
                        currentSongPath = null;
                        currentTimeLabel.Text = "Время воспроизведения: 00:00 / 00:00";
                        }
                        if (audioFile != null)
                        {
                            audioFile.Position = 0; // Сброс позиции трека на начало при переподключении
                        }

                        // Сброс состояния кнопки StopPlayButton
                        StopPlayButton.Image = Image.FromFile("ico/playIcon.png");
                        isPlaying = false;
                        seekBar.Value = 0;
                        currentSongPath = null; // Сброс текущего трека

                        // Очистка меток названия и исполнителя
                        NameLabel.Text = string.Empty;
                        ArtistLabel.Text = string.Empty;

                        songsPanel.Controls.Clear();

                    try
                    {
                        var requestUri = $"http://{serverIP}:{serverPort}/index.php?action=list";
                        var response = await client.GetStringAsync(requestUri);
                        Console.WriteLine("Запрос отправлен серверу");

                        var responseObject = JObject.Parse(response);
                        var songs = responseObject["songs"];

                        foreach (var song in songs)
                        {
                            string songName = song["name"].ToString();
                            string songArtist = song["artist"].ToString();
                            string songPath = song["path"].ToString();

                            var playPauseButton = new Button
                            {
                                Name = "playPauseButton",
                                Image = Image.FromFile("ico/playIcon.png"),
                                Tag = new { Path = songPath, Name = songName, Artist = songArtist },
                                Width = 38,
                                Height = 38,
                                FlatStyle = FlatStyle.Flat,
                                BackColor = Color.LightGray,
                                FlatAppearance =
                        {
                            BorderSize = 0,
                            BorderColor = Color.LightGray
                        },
                                BackgroundImageLayout = ImageLayout.Stretch
                            };
                            playPauseButton.Click += PlayPauseButton_Click;

                                GraphicsPath path = new GraphicsPath();
                            path.AddEllipse(0, 0, playPauseButton.Width, playPauseButton.Height);
                            playPauseButton.Region = new Region(path);

                                GraphicsPath path_btn = new GraphicsPath();
                                path_btn.AddEllipse(0, 0, StopPlayButton.Width, StopPlayButton.Height);
                                StopPlayButton.Region = new Region(path_btn);

                                GraphicsPath path_prev = new GraphicsPath();
                                path_prev.AddEllipse(0, 0, PrevButton.Width, PrevButton.Height);
                                PrevButton.Region = new Region(path_prev);

                                GraphicsPath path_next = new GraphicsPath();
                                path_next.AddEllipse(0, 0, NextButton.Width, NextButton.Height);
                                NextButton.Region = new Region(path_next);

                                var songNameLabel = new Label
                            {
                                Text = songName,
                                Font = new Font("Arial", 11, FontStyle.Bold),
                                Width = 450,
                                Height = 17,
                                Margin = new Padding(0, 6, 0, 0)
                            };

                            var songArtistLabel = new Label
                            {
                                Text = songArtist,
                                Font = new Font("Arial", 9, FontStyle.Regular),
                                Width = 450,
                                Margin = new Padding(0, 0, 0, 0)
                            };

                            var songPanel = new FlowLayoutPanel
                            {
                                AutoSize = true,
                                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                                Margin = new Padding(0, 4, 0, 0)
                            };

                            var songInfoPanel = new FlowLayoutPanel
                            {
                                AutoSize = true,
                                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                                FlowDirection = FlowDirection.TopDown,
                                Margin = new Padding(0, 0, 0, 0)
                            };

                            songInfoPanel.Controls.Add(songNameLabel);
                            songInfoPanel.Controls.Add(songArtistLabel);
                            songPanel.Controls.Add(playPauseButton);
                            songPanel.Controls.Add(songInfoPanel);
                            songsPanel.Controls.Add(songPanel);
                            seekBar.Visible = true;
                            currentTimeLabel.Visible = true;
                            audio_listLabel.Visible = true;
                            Settings.Visible = true;
                            StopPlayButton.Visible = true;
                            info.Visible = false;
                            NameLabel.Visible = true;
                            ArtistLabel.Visible = true;
                            PrevButton.Visible = true;
                            NextButton.Visible = true;
                            volumeTrackBar.Visible = true;
                            vol_label.Visible = true;
                            volumeLabel.Visible = true;
                            volumeTrackBar.Value = 50;
                                volumeLabel.Text = "50";
                            }
                    }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Ошибка подключения к серверу: {ex.Message}");
                        }
                    }
                    catch (FormatException ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        private void PlayPauseButton_Click(object sender, EventArgs e)
        {
            var button = sender as Button;
            var songInfo = (dynamic)button.Tag;
            string songUrl = songInfo.Path;
            string songName = songInfo.Name;
            string songArtist = songInfo.Artist;

            if (currentPlayPauseButton != null && currentPlayPauseButton != button)
            {
                currentPlayPauseButton.Image = Image.FromFile("ico/playIcon.png");
                outputDevice?.Stop();
                isPlaying = false;
            }

            try
            {
                if (currentSongPath != songUrl)
                {
                    Console.WriteLine($"Начало потокового воспроизведения аудиофайла с сервера: {songUrl}");

                    audioFile = new MediaFoundationReader(songUrl);
                    outputDevice = new WaveOutEvent();
                    outputDevice.Init(audioFile);
                    outputDevice.Volume = volumeTrackBar.Value / 100f; // Установка начального значения громкости
                    currentSongPath = songUrl;

                    seekBar.Maximum = (int)audioFile.TotalTime.TotalSeconds;
                    playbackTimer.Start();

                    // Обновление названия и исполнителя текущего трека
                    NameLabel.Text = songName;
                    ArtistLabel.Text = songArtist;
                }

                if (isPlaying)
                {
                    Console.WriteLine("Пауза воспроизведения");
                    outputDevice.Pause();
                    button.Image = Image.FromFile("ico/playIcon.png");
                    StopPlayButton.Image = Image.FromFile("ico/playIcon.png");
                }
                else
                {
                    Console.WriteLine("Начало воспроизведения");
                    outputDevice.Play();
                    button.Image = Image.FromFile("ico/stopIcon.png");
                    StopPlayButton.Image = Image.FromFile("ico/stopIcon.png");
                }

                isPlaying = !isPlaying;
                currentPlayPauseButton = button;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка воспроизведения: {ex.Message}");
            }
        }


        private void StopPlayButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (outputDevice != null && currentSongPath != null)
                {
                    if (isPlaying)
                    {
                        outputDevice.Stop();
                        currentPlayPauseButton.Image = Image.FromFile("ico/playIcon.png");
                        StopPlayButton.Image = Image.FromFile("ico/playIcon.png");
                        isPlaying = false;

                    }
                    else
                    {
                        outputDevice.Play();
                        currentPlayPauseButton.Image = Image.FromFile("ico/stopIcon.png");
                        StopPlayButton.Image = Image.FromFile("ico/stopIcon.png");
                        isPlaying = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка управления воспроизведением: {ex.Message}");
            }
        }

        private async void PlaybackTimer_Tick(object sender, EventArgs e)
        {
            if (audioFile != null && outputDevice != null)
            {
                var currentTime = audioFile.CurrentTime;
                var totalTime = audioFile.TotalTime;

                await Task.Run(() =>
                {
                    currentTimeLabel.Invoke(new Action(() =>
                    {
                        currentTimeLabel.Text = $"Время воспроизведения: {currentTime:mm\\:ss} / {totalTime:mm\\:ss}";
                        seekBar.Value = (int)currentTime.TotalSeconds;
                    }));
                });
            }
        }

        private void PrevButton_Click(object sender, EventArgs e)
        {
            // Логика для переключения на предыдущий трек
            SwitchTrack(-1);
        }

        private void NextButton_Click(object sender, EventArgs e)
        {
            // Логика для переключения на следующий трек
            SwitchTrack(1);
        }

        private void Button_Enter(object sender, EventArgs e)
        {
            this.ActiveControl = null;
        }

        private void SwitchTrack(int direction)
        {
            if (songsPanel.Controls.Count == 0) return;

            int currentIndex = -1;
            for (int i = 0; i < songsPanel.Controls.Count; i++)
            {
                var songPanel = songsPanel.Controls[i] as FlowLayoutPanel;
                var playPauseButton = songPanel.Controls[0] as Button;
                if (playPauseButton == currentPlayPauseButton)
                {
                    currentIndex = i;
                    break;
                }
            }

            if (currentIndex == -1) return;

            int newIndex = currentIndex + direction;
            if (newIndex < 0) newIndex = songsPanel.Controls.Count - 1;
            if (newIndex >= songsPanel.Controls.Count) newIndex = 0;

            var newSongPanel = songsPanel.Controls[newIndex] as FlowLayoutPanel;
            var newPlayPauseButton = newSongPanel.Controls[0] as Button;
            PlayPauseButton_Click(newPlayPauseButton, EventArgs.Empty);
        }

        private void VolumeTrackBar_Scroll(object sender, EventArgs e)
        {
            if (outputDevice != null)
            {
                float volume = volumeTrackBar.Value / 100f; // Преобразование значения ползунка в диапазон от 0.0 до 1.0
                outputDevice.Volume = volume;
            }
            volumeLabel.Text = volumeTrackBar.Value.ToString();
        }

        private void SeekBar_Scroll(object sender, EventArgs e)
        {
            if (audioFile != null)
            {
                outputDevice.Pause();
                audioFile.CurrentTime = TimeSpan.FromSeconds(seekBar.Value);
                outputDevice.Play();
            }
        }

        private void LightThemeButton_Click(object sender, EventArgs e)
        {
            Theme.ApplyTheme(this, false);
        }

        private void DarkThemeButton_Click(object sender, EventArgs e)
        {
            Theme.ApplyTheme(this, true);
        }

        private void SiteInfo_Click(object sender, EventArgs e)
        {
            Info info = new Info();
            info.Show();
        }


        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            outputDevice?.Stop();
            outputDevice?.Dispose();
            audioFile?.Dispose();
        }
    }
}