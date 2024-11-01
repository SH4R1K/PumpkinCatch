using PumpkinCatch.Abstract;
using PumpkinCatch.Extensions;
using PumpkinCatch.Factory;
using PumpkinCatch.Interfaces;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;

namespace PumpkinCatch
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DispatcherTimer gameTimer = new DispatcherTimer(DispatcherPriority.Render);
        private DispatcherTimer spawnTimer = new DispatcherTimer(DispatcherPriority.Render);
        private Random random = new Random();
        List<ICollectableBase> collectables = new();
        private SpawnFactory spawnFactory = new SpawnFactory();
        private List<string> spawnList = new List<string> { "bomb", "pumpkin" };
        private List<string> musicList = new();
        public int IdMusic { get; set; }
        private MediaPlayer player = new();
        public MainWindow()
        {
            InitializeComponent();
            InitializeTimers();
            InitializePlayer();
        }

        private void InitializePlayer()
        {
            DirectoryInfo d = new DirectoryInfo($@"{Environment.CurrentDirectory}\Music");
            FileInfo[] Files = d.GetFiles("*.mp3"); 
            string str = "";
            foreach (FileInfo file in Files)
            {
                musicList.Add(file.Name);
            }
            if (musicList.Count == 0)
            {
                MessageBox.Show("Кто-то удалил всю музыку :(");
                return;
            }
            musicList.Shuffle();
            player.Volume = 0.1;
            player.IsMuted = false;
            player.MediaEnded += Player_MediaEnded;
            PlayMusic();
        }

        private void InitializeTimers()
        {
            spawnTimer.Interval = TimeSpan.FromMilliseconds(500);
            spawnTimer.Tick += (s, e) =>
            {
                var collectable = spawnFactory.SpawnCollectable(spawnList[random.Next(spawnList.Count())]);
                collectable.Y = ((UserControl)collectable).Height * -1;
                collectable.X = random.NextDouble() * (gameFieldCanvas.Width - 150);
                gameFieldCanvas.Children.Add(((UserControl)collectable));
                collectables.Add(collectable);
            };

            gameTimer.Interval = TimeSpan.FromMilliseconds(1);
            gameTimer.Tick += (s, e) =>
            {
                foreach (ICollectableBase collectable in collectables)
                {
                    if (!collectable.Disposed)
                    {
                        collectable.MoveDown();
                        if (CheckCollision(playerObject, collectable))
                        {
                            playerObject.Collect(collectable);
                        }
                    }

                }
                collectables.RemoveAll(c => c.Disposed);
                scoreTextBlock.Text = $"Scores: {playerObject.Score}";
            };

            gameTimer.Start();
            spawnTimer.Start();
        }

        private void Player_MediaEnded(object? sender, EventArgs e)
        {
            if (IdMusic < musicList.Count-1)
                IdMusic++;
            else
                IdMusic = 0;
            PlayMusic();
        }

        private void PlayMusic()
        {
            player.Open(new Uri(@$"Music\{musicList[IdMusic]}", UriKind.Relative));
            player.Play();
        }

        private bool CheckCollision(IPhysObject object1, IPhysObject object2)
        {
            Rect rect1 = new Rect(object1.X, object1.Y, object1.HitBox.Width, object1.HitBox.Height);
            Rect rect2 = new Rect(object2.X, object2.Y, object2.HitBox.Width, object2.HitBox.Height);
            return rect1.IntersectsWith(rect2);
        }
        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Left)
            {
                playerObject.X -= 15;
            }
            else if (e.Key == Key.Right)
            {
                playerObject.X += 15;
            }
        }
    }
}