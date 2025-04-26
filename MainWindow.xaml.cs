using System.Diagnostics;
using System.Reflection;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Xml.Linq;
using WpfAnimatedGif;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

// System.Windows.Controls и System.Drawing юмеют одинаковые названия Image, Rectangle и др.
// из-за чего возникает ошибка, т.к. они не знают из какого пространства брать информацию,
// поэтому в коде я определяю их напрямую с System.Windows.Controls и System.Drawing

namespace Tetris_AI
{
    public partial class MainWindow : Window  // Класс MainWindow - точка входа в приложение,
                                              // содержит логику взаимодействия с пользовательским интерфейсом
    {
        // Хранит изображения плиток
        private readonly ImageSource[] tileImages = new ImageSource[]
        {
            new BitmapImage(new Uri("Assets/TileEmpty.png", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/TileCyan.png", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/TileBlue.png", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/TileOrange.png", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/TileYellow.png", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/TileGreen.png", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/TilePurple.png", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/TileRed.png", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/Tile8.jpg", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/Tile9.jpg", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/Tile10.jpg", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/Tile11.jpg", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/Tile12.jpg", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/Tile13.jpg", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/Tile14.jpg", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/TileGhost.png", UriKind.Relative))
        };

        // Хранит картинки для режима Мозаика
        private readonly ImageSource[] mosaicImages = new ImageSource[]
        {
            new BitmapImage(new Uri("Assets/Mosaic1.jpg", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/Mosaic2.jpg", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/Mosaic3.jpg", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/Mosaic4.jpg", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/Mosaic5.jpg", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/Mosaic6.jpg", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/Mosaic7.jpg", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/Mosaic8.jpg", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/Mosaic9.jpg", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/Mosaic10.jpg", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/Mosaic11.jpg", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/Mosaic12.jpg", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/Mosaic13.jpg", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/Mosaic14.jpg", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/Mosaic15.jpg", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/Mosaic16.jpg", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/Mosaic17.jpg", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/Mosaic18.jpg", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/Mosaic19.jpg", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/Mosaic20.jpg", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/Mosaic21.jpg", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/Mosaic22.jpg", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/Mosaic23.jpg", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/Mosaic24.jpg", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/Mosaic25.jpg", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/Mosaic26.jpg", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/Mosaic27.jpg", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/Mosaic28.jpg", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/Mosaic29.jpg", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/Mosaic30.jpg", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/Mosaic31.jpg", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/Mosaic32.jpg", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/Mosaic33.jpg", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/Mosaic34.jpg", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/Mosaic35.jpg", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/Mosaic36.jpg", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/Mosaic37.jpg", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/Mosaic38.jpg", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/Mosaic39.jpg", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/Mosaic40.jpg", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/Mosaic41.jpg", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/Mosaic42.jpg", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/Mosaic43.jpg", UriKind.Relative))
        };

        // Хранит изображения блоков Тетромино
        private readonly ImageSource[] blockImages = new ImageSource[]
        {
            new BitmapImage(new Uri("Assets/Block-Empty.png", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/Block-I.png", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/Block-J.png", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/Block-L.png", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/Block-O.png", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/Block-S.png", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/Block-T.png", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/Block-Z.png", UriKind.Relative))
        };

        // Хранит изображения блоков Тримино
        private readonly ImageSource[] blockTriminoImages = new ImageSource[]
        {
            new BitmapImage(new Uri("Assets/Block-Empty.png", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/Block-I-trimino.png", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/Block-J-trimino.png", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/Block-L-trimino.png", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/Block-O-trimino.png", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/Block-X-trimino.png", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/Block-V-trimino.png", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/Block-G-trimino.png", UriKind.Relative))
        };

        // Хранит изображения блоков Пентомино
        private readonly ImageSource[] blockPentominoImages = new ImageSource[]
        {
            new BitmapImage(new Uri("Assets/Block-Empty.png", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/Block-I-pentomino.png", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/Block-P-pentomino.png", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/Block-B-pentomino.png", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/Block-F-pentomino.png", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/Block-E-pentomino.png", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/Block-J-pentomino.png", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/Block-L-pentomino.png", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/Block-N-pentomino.png", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/Block-M-pentomino.png", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/Block-V-pentomino.png", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/Block-T-pentomino.png", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/Block-W-pentomino.png", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/Block-Y-pentomino.png", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/Block-K-pentomino.png", UriKind.Relative))
        };

        // Хранит изображения блоков Тетромино Серые для режима Мозаика
        private readonly ImageSource[] blockImagesGray = new ImageSource[]
        {
            new BitmapImage(new Uri("Assets/Block-Empty.png", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/Block-I-Gray.png", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/Block-J-Gray.png", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/Block-L-Gray.png", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/Block-O-Gray.png", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/Block-S-Gray.png", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/Block-T-Gray.png", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/Block-Z-Gray.png", UriKind.Relative))
        };

        // Хранит музыку для всех режимов, кроме Медитации
        private List<string> otherSongs = new List<string>
        {
            "BackgroundMusic1.mp3",
            "BackgroundMusic2.mp3",
            "BackgroundMusic3.mp3",
            "BackgroundMusic4.mp3",
            "BackgroundMusic5.mp3",
            "BackgroundMusic6.mp3",
            "BackgroundMusic7.mp3",
            "BackgroundMusic8.mp3",
            "BackgroundMusic9.mp3",
            "BackgroundMusic10.mp3"
        };

        // Хранит музыку для режима Медитация
        private List<string> meditationSongs = new List<string>
        {
            "MeditationBackgroundMusic1.mp3",
            "MeditationBackgroundMusic2.mp3",
            "MeditationBackgroundMusic3.mp3",
            "MeditationBackgroundMusic4.mp3",
            "MeditationBackgroundMusic5.mp3",
            "MeditationBackgroundMusic6.mp3"
        };

        private System.Windows.Controls.Image[,] imageControls;             // Двумерный массив объектов Image, используемых для отображения элементов (ячеек) игрового поля
        private System.Windows.Controls.Image[,] imageControlsTrimino;      // Двумерный массив объектов Image Тримино
        private System.Windows.Controls.Image[,] imageControlsPentomino;    // Двумерный массив объектов Image Пентомино
        private readonly int maxDelay = 1000;               // Максимальная задержка сдвига блока на 1 ячейку вниз - минимальная скорость
        private readonly int minDelay = 75;                 // Минимальная задержка сдвига блока на 1 ячейку вниз - максимальная скорость
        private readonly int delayDicrease = 15;            // Шаг уменьшения задержки - ускорение падения блоков
        private int delayDicreaseSurvival = 0;              // Шаг уменьшения задержки - ускорение падения блоков в режиме Выживание
        private int SurvivalDelay = 0;                      // Переменная для увеличения задержки в режиме Выживание
        private int SprintLinesDelay = 0;                   // Переменная для уменьшения задержки в режиме Спринт Линии
        private bool isGameLoopRunning = false;             // Проверяет, запущен ли уже игровой цикл, не давая запуститься ему ассинхронно

        private int mosaicIndex = 0;                        // Считает номер необходимой части картинки в режиме Мозаика
        bool prize1, prize2, prize3, prize4 = false;        // Определяют тип полученного бустера
        int prize = 0;                                      // Выбирает тип полученного бустера

        int[] numbersPictures = new int[20];                // Картинка в режима Мозаика не будет повторяться 20 раз
        int[] numbers = new int[6];                         // Тип генерации блоков в режима Мозаика не будет повторяться 6 раз

        private readonly Stopwatch stopwatch;               // Секундомер
        private readonly DispatcherTimer timer;             // Вроде нужен для секундромера, но не уверен

        private BitmapSource[] mosaicTiles;                 // Хранит все части картинки в режиме Мозаика

        public BitmapSource[] MosaicTiles
        {
            get => mosaicTiles;
            set => mosaicTiles = value;
        }

        private bool Pause { get; set; }                    // Состояние Паузы: ВКЛ/ВЫКЛ
        private bool Help { get; set; }                     // Состояние Справки: ВКЛ/ВЫКЛ
        private int Delay { get; set; }                     // Задержка, используемая в качестве скорости падения блоков
        private bool MainMenuFlag { get; set; }             // Состояние Главного меню: ВКЛ/ВЫКЛ
        private bool MusicFlag { get; set; }                // Состояние Музыки: ВКЛ/ВЫКЛ
        private bool OptionMenuFlag { get; set; }           // Состояние меню Опции: ВКЛ/ВЫКЛ
        private int maxNumberLanguages = 2;                 // Количество языков

        private GameState gameState;                        // Хранит текущее состояние игры
        private Settings settings;                          // Хранит текущие рекорды в каждом режиме
        private MediaPlayer currentMusic = new MediaPlayer();
        private string currentSong;                         // Хранит текущую песню
        private string currentTypeSong;                     // Хранит текущий тип песню: для главного меню, режима медитации или остальных режимов
        private string currentVideoSource;                  // Хранит текущий фон

        private bool isFullscreen = false;                  // Состояние Полноэкранного режима: ВКЛ/ВЫКЛ

        public MainWindow()
        {
            MainMenuFlag = true;
            MusicFlag = true;
            OptionMenuFlag = false;
            settings = Settings.Load();
            InitializeComponent();
            if (!settings.GhostBlockFlag) GhostOptionButton.Opacity = 0.6;
            if (!settings.HoldBlockFlag) HoldOptionButton.Opacity = 0.6;

            stopwatch = new Stopwatch();
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(50);
            timer.Tick += UpdateDisplay;

            //currentVideoSource = "Assets/MainBackground.mp4";
            //BackgroundVideo.Source = new Uri(currentVideoSource, UriKind.Relative);
            //BackgroundVideo.Play();
            PlayBackgroundMusic("MainMenuBackgroundMusic.mp3");
            gameState = new GameState(this);
            imageControls = SetupGameCanvas(gameState.GameGrid);
            imageControlsTrimino = SetupGameCanvasTrimino(gameState.GameGrid);
            imageControlsPentomino = SetupGameCanvasPentomino(gameState.GameGrid);
            ToggleFullscreen();
            ApplyLanguage();
        }

        // Обновляет время секундромера на экране
        private void UpdateDisplay(object sender, EventArgs e)
        {
            StopwatchText.Text = stopwatch.Elapsed.ToString(@"mm\:ss\:ff");
        }

        // Вход в Полноэкранный режим и выход из него
        private void ToggleFullscreen()
        {
            if (isFullscreen)
            {
                WindowStyle = WindowStyle.SingleBorderWindow;
                ResizeMode = ResizeMode.CanResize;
                WindowState = WindowState.Normal;
            }
            else
            {
                WindowStyle = WindowStyle.None;
                ResizeMode = ResizeMode.NoResize;
                WindowState = WindowState.Maximized;
            }
            isFullscreen = !isFullscreen;
        }

        // Вход в Полноэкранный режим и выход из него через кнопку F11
        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            if (e.Key == Key.F11) ToggleFullscreen();
        }

        // Запускает новую музыку
        private void PlayBackgroundMusic(string musicFile)
        {
            currentTypeSong = musicFile;
            if (MusicFlag)
            {
                try
                {
                    if (musicFile == "BackgroundMusic.mp3")
                    {
                        currentSong = otherSongs[new Random().Next(otherSongs.Count)];
                        currentMusic.Open(new Uri($"Assets/{currentSong}", UriKind.Relative));
                    }
                    else if (musicFile == "MeditationBackgroundMusic.mp3")
                    {
                        currentSong = meditationSongs[new Random().Next(meditationSongs.Count)];
                        currentMusic.Open(new Uri($"Assets/{currentSong}", UriKind.Relative));
                    }
                    else if (musicFile == "MainMenuBackgroundMusic.mp3")
                    {
                        currentSong = musicFile;
                        currentMusic.Open(new Uri($"Assets/{currentSong}", UriKind.Relative));
                    }
                    currentMusic.MediaEnded += BackgroundMusic_MediaEnded;  // Позволяет запускать новую песню после окончания текущей
                    currentMusic.Play();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при воспроизведении музыки: {ex.Message}");
                }
            }
        }

        // Включает новую музыку после завершения предыдущей
        private void BackgroundMusic_MediaEnded(object sender, EventArgs e)
        {
            if (currentMusic != null)  // Проверяет, не завершилась ли текущая музыка
            {
                if (currentSong != null)  // Если музыка завершилась, метод выбирает новую песню для воспроизведения
                {
                    if (MainMenuFlag) currentMusic.Open(new Uri($"Assets/MainMenuBackgroundMusic.mp3", UriKind.Relative));
                    else if (gameState.gameOptions.MeditationModeFlag)
                    {
                        List<string> meditationSongsCopy = new List<string>(meditationSongs);  // Создает копию списка песен
                        meditationSongsCopy.Remove(currentSong);                     // Удаляет текущую песню из копии списка
                        if (meditationSongsCopy.Count > 0)       // Если в копии списка остались песни, выбирает случайную из них
                        {
                            currentSong = meditationSongsCopy[new Random().Next(meditationSongsCopy.Count)];
                            currentMusic.Open(new Uri($"Assets/{currentSong}", UriKind.Relative));
                        }
                        else                                     // Если все песни были использованы, выбирает случайную из оригинального списка
                        {
                            currentSong = meditationSongs[new Random().Next(meditationSongs.Count)];
                            currentMusic.Open(new Uri($"Assets/{currentSong}", UriKind.Relative));
                        }
                    }
                    else
                    {
                        List<string> otherSongsCopy = new List<string>(otherSongs);
                        string currentSong = currentMusic.Source.ToString().Split('/').Last();
                        otherSongsCopy.Remove(currentSong);
                        if (otherSongsCopy.Count > 0)
                        {
                            string randomSong = otherSongsCopy[new Random().Next(otherSongsCopy.Count)];
                            currentMusic.Open(new Uri($"Assets/{randomSong}", UriKind.Relative));
                        }
                        else
                        {
                            string randomSong = otherSongs[new Random().Next(otherSongs.Count)];
                            currentMusic.Open(new Uri($"Assets/{randomSong}", UriKind.Relative));
                        }
                    }
                }

                currentMusic.Play();
            }
        }

        /*// Останавливает музыку после выхода из программы
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            if (currentMusic != null) currentMusic.Stop();
        }

        // Останавливает музыку после включения Паузы
        private void PauseMusic()
        {
            if (currentMusic != null) currentMusic.Pause();
        }

        // Останавливает музыку после включения Справки
        private void ResumeMusic()
        {
            if (currentMusic != null) currentMusic.Play();
        }*/

        /*// Воспроизводит фоновое видео заново после его завершения
        private void BackgroundVideo_MediaEnded(object sender, RoutedEventArgs e)
        {
            BackgroundVideo.Position = TimeSpan.Zero;
            BackgroundVideo.Play();
        }

        // Устанавливает фоновое видео для режима Медитация
        private void SetMeditationBackground()
        {
            currentVideoSource = "Assets/MeditationBackgroundWall.mp4";
            BackgroundVideo.Source = new Uri(currentVideoSource, UriKind.Relative);
            BackgroundVideo.Play();
        }

        // Устанавливает фоновое видео при входе в Главное меню
        private void SetDefaultBackground()
        {
            currentVideoSource = "Assets/MainBackground.mp4";
            BackgroundVideo.Source = new Uri(currentVideoSource, UriKind.Relative);
            BackgroundVideo.Play();
        }*/

        // Закрывает программу
        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        // Инициализация игрового поля с фигурами Тетромино
        private System.Windows.Controls.Image[,] SetupGameCanvas(GameGrid grid)
        {
            System.Windows.Controls.Image[,] imageControls = new System.Windows.Controls.Image[grid.Rows, grid.Columns];
            int cellSize = 25;  // Размер в пискелях

            for (int r = 0; r < grid.Rows; r++)
            {
                for (int c = 0; c < grid.Columns; c++)
                {
                    System.Windows.Controls.Image imageControl = new System.Windows.Controls.Image  // Для каждой ячейки создается новый объект Image
                    {
                        Width = cellSize,
                        Height = cellSize,
                    };

                    Canvas.SetTop(imageControl, (r - 2) * cellSize + 10);  // Установка координат верхнего левого угла изображения на канвасе
                    Canvas.SetLeft(imageControl, c * cellSize);            // Установка координат верхнего левого угла изображения на канвасе
                    GameCanvas.Children.Add(imageControl);
                    imageControls[r, c] = imageControl;
                }
            }

            return imageControls;
        }

        // Инициализация игрового поля с фигурами Пентомино
        private System.Windows.Controls.Image[,] SetupGameCanvasPentomino(GameGrid grid)
        {
            System.Windows.Controls.Image[,] imageControlsPentomino = new System.Windows.Controls.Image[grid.Rows, grid.Columns];
            int cellSize = 20;  // Размер в пискелях

            for (int r = 0; r < grid.Rows; r++)
            {
                for (int c = 0; c < grid.Columns; c++)
                {
                    System.Windows.Controls.Image imageControl = new System.Windows.Controls.Image  // Для каждой ячейки создается новый объект Image
                    {
                        Width = cellSize,
                        Height = cellSize,
                    };

                    Canvas.SetTop(imageControl, (r - 2) * cellSize + 10);  // Установка координат верхнего левого угла изображения на канвасе
                    Canvas.SetLeft(imageControl, c * cellSize);            // Установка координат верхнего левого угла изображения на канвасе
                    GameCanvasBig.Children.Add(imageControl);
                    imageControlsPentomino[r, c] = imageControl;
                }
            }

            return imageControlsPentomino;
        }

        // Инициализация игрового поля с фигурами Тримино
        private System.Windows.Controls.Image[,] SetupGameCanvasTrimino(GameGrid grid)  // Инициализация игрового поля
        {
            System.Windows.Controls.Image[,] imageControlsTrimino = new System.Windows.Controls.Image[grid.Rows, grid.Columns];
            int cellSize = 20;  // Размер в пискелях

            for (int r = 0; r < grid.Rows; r++)
            {
                for (int c = 0; c < grid.Columns; c++)
                {
                    System.Windows.Controls.Image imageControl = new System.Windows.Controls.Image  // Для каждой ячейки создается новый объект Image
                    {
                        Width = cellSize,
                        Height = cellSize,
                    };

                    Canvas.SetTop(imageControl, (r - 2) * cellSize + 10);  // Установка координат верхнего левого угла изображения на канвасе
                    Canvas.SetLeft(imageControl, c * cellSize);            // Установка координат верхнего левого угла изображения на канвасе
                    GameCanvasSmall.Children.Add(imageControl);
                    imageControlsTrimino[r, c] = imageControl;
                }
            }

            return imageControlsTrimino;
        }

        // Делит картинку на квадрату для блоков в режиме Мозаика
        public BitmapSource[] SplitRandomImageIntoTiles()
        {
            // Выбираем случайное изображение
            var random = new Random();
            int randomImage;                                        // randomImage нужен, чтобы передавать индекс в метод MosaicImageOn и на порезку фото одновременно

            do
            {
                randomImage = random.Next(mosaicImages.Length);     // Случайно выбирает порядок генерации блоков
            }
            while (CheckPictures(randomImage));
            NewPictures(randomImage);

            //randomImage = 40 - 1; // ДЛЯ ТЕСТОВ

            var selectedImage = mosaicImages[randomImage] as BitmapSource;

            if (selectedImage == null)
            {
                throw new InvalidOperationException("Изображение не является типом BitmapSource");
            }

            MosaicImageOn(randomImage);

            // Создаем пустой массив для тайлов
            int tileCount = (int)(selectedImage.Width * selectedImage.Height) / (256 * 256) + 1;
            var tiles = new BitmapSource[tileCount];

            var croppedBitmapZero = new CroppedBitmap(selectedImage, new Int32Rect(0, 0, 256, 256));

            tiles[0] = croppedBitmapZero;

            // Разбиваем изображение на тайлы
            int tileIndex = 1;
            for (int y = (int)selectedImage.Height - 256; y >= 0; y -= 256)
            {
                for (int x = 0; x <= selectedImage.Width - 256; x += 256)
                {
                    // Обрезаем часть изображения размером 256x256
                    var croppedBitmap = new CroppedBitmap(selectedImage, new Int32Rect(x, y, 256, 256));

                    tiles[tileIndex++] = croppedBitmap;
                }
            }

            return tiles;
        }

        // Проверяет не была ли недавно использована выбранная картинка в режиме Мозаика
        private bool CheckPictures(int randomImage)
        {
            bool flag = false;

            for (int i = 0; i < numbersPictures.Length; i++)
            {
                if (numbersPictures[i] == randomImage) flag = true;
            }

            return flag;
        }

        // Отмечает выбранную картинку, чтобы она не использовалась еще какое-то время в режиме Мозаика
        private void NewPictures(int randomImage)
        {
            for (int i = numbersPictures.Length - 1; i > 0; i--)
            {
                numbersPictures[i] = numbersPictures[i - 1];
            }
            numbersPictures[0] = randomImage;
        }

        // Устанавливает картинку в режиме Мозаика
        private void MosaicImageOn(int randomImage)
        {
            MosaicImage.Source = mosaicImages[randomImage];
            MosaicImage.Visibility = Visibility.Visible;
        }

        // Убирает картинку в режиме Мозаика
        private void MosaicImageOff()
        {
            MosaicImage.Visibility = Visibility.Collapsed;
        }

        // Проверяет не была ли недавно использована выбранный тип генерации блоков в режиме Мозаика
        private bool CheckMosaicType()
        {
            bool flag = false;

            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] == gameState.gameOptions.GenerateMosaicType) flag = true;
            }

            return flag;
        }

        // Отмечает выбранный тип генерации блоков, чтобы он не использовался еще какое-то время в режиме Мозаика
        private void NewMosaicType()
        {
            for (int i = numbers.Length - 1; i > 0; i--)
            {
                numbers[i] = numbers[i - 1];
            }
            numbers[0] = gameState.gameOptions.GenerateMosaicType;
        }

        // Устанавливает изображение для каждой ячейки на основе её текущего состояния
        private void DrawGrid(GameGrid grid)
        {
            for (int r = 0; r < grid.Rows; r++)
            {
                for (int c = 0; c < grid.Columns; c++)
                {
                    if (gameState.gameOptions.TypeBlocks == 1)  // Тетромино
                    {
                        int id = grid[r, c];                          // Извлекается id каждой ячейки
                        imageControls[r, c].Opacity = 1;              // Возвращаем прозрачность в исходное состояние
                        imageControls[r, c].Source = tileImages[id];  // Используя id, устанавливается соответствующая плитка в каждую ячейку
                    }
                    else if (gameState.gameOptions.TypeBlocks == 2)  // Тримино
                    {
                        int id = grid[r, c];
                        imageControlsTrimino[r, c].Opacity = 1;
                        imageControlsTrimino[r, c].Source = tileImages[id];
                    }
                    else if (gameState.gameOptions.TypeBlocks == 3)  // Пентомино
                    {
                        int id = grid[r, c];
                        imageControlsPentomino[r, c].Opacity = 1;
                        imageControlsPentomino[r, c].Source = tileImages[id];
                    }
                    else if (gameState.gameOptions.TypeBlocks == 4)  // Мозаика
                    {
                        int id = grid[r, c];                          // Извлекается id каждой ячейки
                        imageControls[r, c].Opacity = 1;              // Возвращаем прозрачность в исходное состояние
                        if (id == 0) imageControls[r, c].Source = tileImages[id];
                        else if (gameState.drawTileIndex > 0 && gameState.drawTileIndex < 161) imageControls[r, c].Source = mosaicTiles[id];
                    }
                }
            }
        }

        // Отрисовывает летящий блок на игровом поле
        private void DrawBlock(Block block)
        {
            mosaicIndex = gameState.drawTileIndex;

            foreach (Position p in block.TilePositions())
            {
                if (gameState.gameOptions.TypeBlocks == 1)  // Тетромино
                {
                    imageControls[p.Row, p.Column].Opacity = 1;  // Возвращаем прозрачность в исходное состояние
                    imageControls[p.Row, p.Column].Source = tileImages[block.ID];
                }
                else if (gameState.gameOptions.TypeBlocks == 2)  // Тримино
                {
                    imageControlsTrimino[p.Row, p.Column].Opacity = 1;
                    imageControlsTrimino[p.Row, p.Column].Source = tileImages[block.ID];
                }
                else if (gameState.gameOptions.TypeBlocks == 3)  // Пентомино
                {
                    imageControlsPentomino[p.Row, p.Column].Opacity = 1;
                    imageControlsPentomino[p.Row, p.Column].Source = tileImages[block.ID];
                }
                else if (gameState.gameOptions.TypeBlocks == 4)  // Мозаика
                {
                    if (gameState.drawTileIndex < 161 )
                    {
                        imageControls[p.Row, p.Column].Opacity = 1;
                        if (gameState.gameOptions.GenerateMosaicType == 1) imageControls[p.Row, p.Column].Source = mosaicTiles[gameState.MosaicChoice.mosaicIndexsOne[mosaicIndex++]];
                        else if (gameState.gameOptions.GenerateMosaicType == 2) imageControls[p.Row, p.Column].Source = mosaicTiles[gameState.MosaicChoice.mosaicIndexsTwo[mosaicIndex++]];
                        else if (gameState.gameOptions.GenerateMosaicType == 3) imageControls[p.Row, p.Column].Source = mosaicTiles[gameState.MosaicChoice.mosaicIndexsThree[mosaicIndex++]];
                        else if (gameState.gameOptions.GenerateMosaicType == 4) imageControls[p.Row, p.Column].Source = mosaicTiles[gameState.MosaicChoice.mosaicIndexsFour[mosaicIndex++]];
                        else if (gameState.gameOptions.GenerateMosaicType == 5) imageControls[p.Row, p.Column].Source = mosaicTiles[gameState.MosaicChoice.mosaicIndexsFive[mosaicIndex++]];
                        else if (gameState.gameOptions.GenerateMosaicType == 6) imageControls[p.Row, p.Column].Source = mosaicTiles[gameState.MosaicChoice.mosaicIndexsSix[mosaicIndex++]];
                        else if (gameState.gameOptions.GenerateMosaicType == 7) imageControls[p.Row, p.Column].Source = mosaicTiles[gameState.MosaicChoice.mosaicIndexsSeven[mosaicIndex++]];
                        else if (gameState.gameOptions.GenerateMosaicType == 8) imageControls[p.Row, p.Column].Source = mosaicTiles[gameState.MosaicChoice.mosaicIndexsEight[mosaicIndex++]];
                        else if (gameState.gameOptions.GenerateMosaicType == 9) imageControls[p.Row, p.Column].Source = mosaicTiles[gameState.MosaicChoice.mosaicIndexsNine[mosaicIndex++]];
                        else if (gameState.gameOptions.GenerateMosaicType == 10) imageControls[p.Row, p.Column].Source = mosaicTiles[gameState.MosaicChoice.mosaicIndexsTen[mosaicIndex++]];
                        else if (gameState.gameOptions.GenerateMosaicType == 11) imageControls[p.Row, p.Column].Source = mosaicTiles[gameState.MosaicChoice.mosaicIndexsEleven[mosaicIndex++]];
                        else if (gameState.gameOptions.GenerateMosaicType == 12) imageControls[p.Row, p.Column].Source = mosaicTiles[gameState.MosaicChoice.mosaicIndexsTwelve[mosaicIndex++]];
                    }
                    else imageControls[p.Row, p.Column].Source = tileImages[0];
                }
            }
        }

        // Отображает следующий блок в очереди блоков
        private void DrawNextBlock(BlockQueue blockQueue)
        {
            Block next = blockQueue.NextBlock;

            // При быстром закрытии режима флаг может смениться, а картинка следующего блока еще не отобразиться
            // Почему вообще после закрытия игры отображается картинка следующего блока не пониманию
            // Но суть в том, что программа не поспевает, поэтому стоит "|| MainMenuFlag",
            // чтобы программа все равно вытягивала нужный ID и не выходила за рамки последнего массива blockImages[next.ID];
            if (gameState.gameOptions.PentominoModeFlag || MainMenuFlag) NextImage.Source = blockPentominoImages[next.ID];
            else if (gameState.gameOptions.TriminoModeFlag || MainMenuFlag) NextImage.Source = blockTriminoImages[next.ID];
            else if (gameState.gameOptions.MosaicModeFlag || MainMenuFlag)
            {
                if (gameState.drawTileIndex < 157) NextImage.Source = blockImagesGray[next.ID];
                else NextImage.Source = blockImagesGray[0];
            }
            else NextImage.Source = blockImages[next.ID];
        }

        // Отображает блок на удержании«»
        private void DrawHeldBlock(Block heldBlock)
        {
            if (gameState.gameOptions.TriminoModeFlag)  // Тримино
            {
                // Проверка, удерживавется ли уже какой-нибудь из блоков
                if (heldBlock == null) HoldImage.Source = blockTriminoImages[0];     // Устанавливаем изображение на удержании
                else HoldImage.Source = blockTriminoImages[heldBlock.ID];            // Замена изображения старого удержмиаего блока на новый
            }
            else if (gameState.gameOptions.PentominoModeFlag)  // Пентомино
            {
                if (heldBlock == null) HoldImage.Source = blockPentominoImages[0];
                else HoldImage.Source = blockPentominoImages[heldBlock.ID];
            }
            else // Все остальные режимы
            {
                if (heldBlock == null) HoldImage.Source = blockImages[0];
                else HoldImage.Source = blockImages[heldBlock.ID];
            }
        }

        // Отрисовка "Призрака"
        private void DrawGhostBlock(Block block)
        {
            int dropDistance = gameState.BlockDropDistance();

            foreach (Position p in block.TilePositions())
            {
                if (gameState.gameOptions.TypeBlocks == 1)  // Тетромино
                {
                    imageControls[p.Row + dropDistance, p.Column].Opacity = 0.25;  // Уменьшение прозрачности
                    imageControls[p.Row + dropDistance, p.Column].Source = tileImages[block.ID];
                }
                else if (gameState.gameOptions.TypeBlocks == 2)  // Тримино
                {
                    imageControlsTrimino[p.Row + dropDistance, p.Column].Opacity = 0.25;
                    imageControlsTrimino[p.Row + dropDistance, p.Column].Source = tileImages[block.ID];
                }
                else if (gameState.gameOptions.TypeBlocks == 3)  // Пентомино
                {
                    imageControlsPentomino[p.Row + dropDistance, p.Column].Opacity = 0.25;
                    imageControlsPentomino[p.Row + dropDistance, p.Column].Source = tileImages[block.ID];
                }
                else if (gameState.gameOptions.TypeBlocks == 4)  // Тетромино
                {
                    imageControls[p.Row + dropDistance, p.Column].Opacity = 0.25;  // Уменьшение прозрачности
                    imageControls[p.Row + dropDistance, p.Column].Source = tileImages[block.ID];
                }
            }
        }

        // Полная перерисовка игрового поля, включая сетку и текущий блок
        public void Draw(GameState gameState)
        {
            DrawGrid(gameState.GameGrid);
            if (!gameState.gameOptions.MeditationModeFlag && !gameState.gameOptions.TampingModeFlag &&
                !gameState.gameOptions.MosaicModeFlag && settings.GhostBlockFlag) DrawGhostBlock(gameState.CurrentBlock);
            DrawBlock(gameState.CurrentBlock);
            DrawNextBlock(gameState.BlockQueue);
            if (!gameState.gameOptions.MosaicModeFlag) DrawHeldBlock(gameState.HeldBlock);
            Statistics();
        }

        // Game loop - игровой цикл
        // Выполняется асинхронно и не блокирует основной поток выполнения программы во время своей работы
        private async Task GameLoop()
        {
            Draw(gameState);

            while (!gameState.GameOver && !Pause && !Help)
            {
                if (gameState.gameOptions.SurvivalFlag)  // Реализация "Сброса скорости" для режима Выживание
                {
                    SurvivalDelay += 400;
                    gameState.Tetris -= 1;
                    gameState.gameOptions.SurvivalFlag = false;
                }
                
                if (gameState.gameOptions.OnlyTetrisModeFlag) Delay = 1500;
                else if (gameState.gameOptions.IsMode == 3) Delay = 1500;
                else if (gameState.gameOptions.TampingModeFlag) Delay = 1750;
                else if (gameState.gameOptions.MosaicModeFlag)
                {
                    if (gameState.drawTileIndex <= 41) Delay = 2000;
                    else if (gameState.drawTileIndex <= 81) Delay = 3500;
                    else if (gameState.drawTileIndex <= 121) Delay = 5000;
                    else Delay = 8000;
                }
                else if (gameState.gameOptions.MeditationModeFlag) Delay = 2000;
                else Delay = Math.Max(minDelay, maxDelay - (gameState.ClearedLines * (delayDicrease + delayDicreaseSurvival - SprintLinesDelay)) + SurvivalDelay);  // При каждой сженной линии скорость увеличивается на delayDicrease
                await Task.Delay(Delay);               // await используется для асинхронного ожидания завершения задачи
                                                       // Delay используется для создания задачи, которая завершается через указанное количество милисекунд
                if (!Pause && !Help) gameState.MoveBlockDown();  // Не дает завершить цикл и сдвинуть блок на 1 ячейку вниз после нажатия паузы
                Draw(gameState);
            }

            GameOver();
        }

        // Управление
        private void Window_KeyDown(object sender, KeyEventArgs e)  // sender — объект, который вызвал событие. В данном случае, саме окно приложения
                                                                    // e — объект KeyEventArgs, содержащий информацию о событии нажатия клавиши
        {
            if (gameState.GameOver) return; // Если игра окончена, никакое действие не будет выполнено

            switch (e.Key)
            {
                case Key.Left:
                    if (!Pause && !Help)
                        gameState.MoveBlockLeft();                                          // Сдвиг влево
                    break;
                case Key.Right:
                    if (!Pause && !Help)
                        gameState.MoveBlockRight();                                         // Сдвиг вправо
                    break;
                case Key.Down:
                    if (!Pause && !Help)
                        gameState.MoveBlockDown();                                          // Сдвиг вниз
                    break;
                case Key.D:
                    if (!Pause && !Help)
                        gameState.RotateBlockCW();                                          // Поворот по часовой стрелке
                    break;
                case Key.A:
                    if (!Pause && !Help)
                        gameState.RotateBlockCCW();                                         // Поворот против часовой стрелки
                    break;
                case Key.Up:
                    if (!gameState.gameOptions.MeditationModeFlag && !Pause &&
                        //!gameState.gameOptions.ArcadeModeFlag && !Help &&
                        !gameState.gameOptions.TampingModeFlag &&
                        !gameState.gameOptions.MosaicModeFlag &&
                        gameState.gameOptions.IsMode != 3 &&
                        gameState.gameOptions.IsMode != 4 &&
                        gameState.gameOptions.IsMode != 5 &&
                        !Pause && !Help &&
                        settings.HoldBlockFlag) gameState.HoldBlock();                               // Удержать блок
                    break;
                case Key.Space:
                    if (!gameState.gameOptions.MeditationModeFlag &&
                        !gameState.gameOptions.TampingModeFlag && 
                        !gameState.gameOptions.MosaicModeFlag && 
                        !Pause && !Help) gameState.DropBlock();                             // Опустить блок до упора
                    break;
                case Key.LeftShift:
                    if (!Pause && !Help &&
                        !MainMenuFlag) PauseButton_Click(sender, e);                        // Пауза ВКЛ
                    else if (Pause) PlayButton_Click(sender, e);                            // Пауза ВЫКЛ
                    break;
                case Key.C:
                    if (!Pause && !Help &&
                        !MainMenuFlag) HelpButton_Click(sender, e);                         // Справка ВКЛ
                    else if (Help) CloseHelpButton_Click(sender, e);                        // Справка ВЫКЛ
                    break;
                case Key.F:
                    if (gameState.gameOptions.SurvivalModeFlag &&
                        !Pause && !Help) SurvivalButton_Click(sender, e);                   // Активировать кнопку "Сброс скорости" в режиме Выживание
                    break;
                /*case Key.Q:
                    if (gameState.gameOptions.ArcadeModeFlag &&
                        !Pause && !Help) Electro_Click(sender, e);                          // Активировать кнопку "Сжечь цвет" в режиме Аркада
                    break;*/
                case Key.Q:
                    if ((gameState.gameOptions.TriminoModeFlag ||
                        gameState.gameOptions.TetrominoModeFlag ||
                        gameState.gameOptions.PentominoModeFlag) &&
                        gameState.gameOptions.IsMode == 2 &&
                        !Pause && !Help) GetStickButton_Click(sender, e);                   // Активировать кнопку "Получить палку" в режиме Аркада
                    break;
                case Key.W:
                    if ((gameState.gameOptions.TriminoModeFlag ||
                        gameState.gameOptions.TetrominoModeFlag ||
                        gameState.gameOptions.PentominoModeFlag) &&
                        gameState.gameOptions.IsMode == 2 &&
                        !Pause && !Help) CloseHolesButton_Click(sender, e);                 // Активировать кнопку "Закрыть дырки" в режиме Аркада
                    break;
                case Key.E:
                    if ((gameState.gameOptions.TriminoModeFlag ||
                        gameState.gameOptions.TetrominoModeFlag ||
                        gameState.gameOptions.PentominoModeFlag) &&
                        gameState.gameOptions.IsMode == 2 &&
                        !Pause && !Help) DownwardShiftButton_Click(sender, e);              // Активировать кнопку "Сдвиг вниз" в режиме Аркада
                    break;
                case Key.R:
                    if ((((gameState.gameOptions.TriminoModeFlag ||
                        gameState.gameOptions.TetrominoModeFlag ||
                        gameState.gameOptions.PentominoModeFlag) &&
                        gameState.gameOptions.IsMode == 2) ||
                        gameState.gameOptions.MeditationModeFlag) &&
                        !Pause && !Help) EmptyGlass_Click(sender, e);                       // Активировать кнопку "Опустошить стакан" в режимах Аркада и Медитация
                    break;
                case Key.I:
                    ResetRecordsAndBoosters();                                              // Сброс рекордов и бустеров. ДЛЯ ТЕСТИРОВАНИЯ
                    break;
                default:
                    return;
            }

            Draw(gameState);  // Наличие функции в этом месте гарантирует, что поле отрисуется только когда игрок нажал игровую клавишу
        }

        // Сброс рекордов и бустеров
        private void ResetRecordsAndBoosters()
        {
            settings.BestPentominoClassicScore = 0;
            settings.BestPentominoWithBoostersScore = 0;
            settings.BestTetrominoClassicScore = 0;
            settings.BestTetrominoWithBoostersScore = 0;
            settings.BestTriminoClassicScore = 0;
            settings.BestTriminoWithBoostersScore = 0;
            settings.BestOnlyTetrisScore = 0;
            settings.BestSurvivalScore = 0;
            //settings.BestArcadeScore = 0;
            settings.BestSprintPentominoTime = TimeSpan.Zero;
            settings.BestSprintTetrominoTime = TimeSpan.Zero;
            settings.BestSprintTriminoTime = TimeSpan.Zero;
            settings.BestSprintLineTime = TimeSpan.Zero;
            settings.BestSprintPointTime = TimeSpan.Zero;
            settings.BestTampingScore = 0;
            settings.QuantityGetStick = 0;
            settings.QuantityCloseHoles = 0;
            settings.QuantityDownwardShift = 0;
            settings.QuantityEmptyGlass = 0;
            settings.GhostBlockFlag = true;
            settings.HoldBlockFlag = true;
            GhostOptionButton.Opacity = 1;
            HoldOptionButton.Opacity = 1;
            settings.Language = 1;
            ApplyLanguage();
            Settings.Save(settings);
        }

        // Окончание игры
        private void GameOver()
        {
            if (gameState.GameOver)
            {
                // Пентомино Классика
                if (gameState.gameOptions.PentominoModeFlag && gameState.gameOptions.IsMode == 1)
                {
                    GameOverMenu.Visibility = Visibility.Visible;
                    if (settings.Language == 1) FinalScoreText.Text = $"Очки: {gameState.Score}";
                    else if (settings.Language == 2) FinalScoreText.Text = $"Points: {gameState.Score}";

                    if (gameState.Score > settings.BestPentominoClassicScore)
                    {
                        settings.BestPentominoClassicScore = gameState.Score;
                        Settings.Save(settings);
                        //MessageBox.Show($"Новый лучший результат в режиме Тетромино: {gameState.Score} очков!");  // Отдельное окно с сообщением
                    }

                    BestScoreText.Visibility = Visibility.Visible;
                    if (settings.Language == 1)
                    {
                        BestScoreText.Text = $"Рекорд очков: {settings.BestPentominoClassicScore}";
                        FinalLinesText.Text = $"Линий: {gameState.ClearedLines}";
                    }
                    else if (settings.Language == 2)
                    {
                        BestScoreText.Text = $"Points Record: {settings.BestPentominoClassicScore}";
                        FinalLinesText.Text = $"Lines: {gameState.ClearedLines}";
                    }
                }
                // Пентомино с Бустерами
                else if (gameState.gameOptions.PentominoModeFlag && gameState.gameOptions.IsMode == 2)
                {
                    GameOverMenu.Visibility = Visibility.Visible;
                    if (settings.Language == 1) FinalScoreText.Text = $"Очки: {gameState.Score}";
                    else if (settings.Language == 2) FinalScoreText.Text = $"Points: {gameState.Score}";


                    if (gameState.Score > settings.BestPentominoWithBoostersScore)
                    {
                        settings.BestPentominoWithBoostersScore = gameState.Score;
                        Settings.Save(settings);
                    }

                    BestScoreText.Visibility = Visibility.Visible;
                    if (settings.Language == 1)
                    {
                        BestScoreText.Text = $"Рекорд очков: {settings.BestPentominoWithBoostersScore}";
                        FinalLinesText.Text = $"Линий: {gameState.ClearedLines}";
                    }
                    else if (settings.Language == 2)
                    {
                        BestScoreText.Text = $"Points Record: {settings.BestPentominoWithBoostersScore}";
                        FinalLinesText.Text = $"Lines: {gameState.ClearedLines}";
                    }
                }
                // Тетромино Классика
                else if (gameState.gameOptions.TetrominoModeFlag && gameState.gameOptions.IsMode == 1)
                {
                    GameOverMenu.Visibility = Visibility.Visible;
                    if (settings.Language == 1) FinalScoreText.Text = $"Очки: {gameState.Score}";
                    else if (settings.Language == 2) FinalScoreText.Text = $"Points: {gameState.Score}";

                    if (gameState.Score > settings.BestTetrominoClassicScore)
                    {
                        settings.BestTetrominoClassicScore = gameState.Score;
                        Settings.Save(settings);
                    }

                    BestScoreText.Visibility = Visibility.Visible;
                    if (settings.Language == 1)
                    {
                        BestScoreText.Text = $"Рекорд очков: {settings.BestTetrominoClassicScore}";
                        FinalLinesText.Text = $"Линий: {gameState.ClearedLines}";
                    }
                    else if (settings.Language == 2)
                    {
                        BestScoreText.Text = $"Points Record: {settings.BestTetrominoClassicScore}";
                        FinalLinesText.Text = $"Lines: {gameState.ClearedLines}";
                    }
                }
                // Тетромино с Бустерами
                else if (gameState.gameOptions.TetrominoModeFlag && gameState.gameOptions.IsMode == 2)
                {
                    GameOverMenu.Visibility = Visibility.Visible;
                    if (settings.Language == 1) FinalScoreText.Text = $"Очки: {gameState.Score}";
                    else if (settings.Language == 2) FinalScoreText.Text = $"Points: {gameState.Score}";

                    if (gameState.Score > settings.BestTetrominoWithBoostersScore)
                    {
                        settings.BestTetrominoWithBoostersScore = gameState.Score;
                        Settings.Save(settings);
                    }

                    BestScoreText.Visibility = Visibility.Visible;
                    if (settings.Language == 1)
                    {
                        BestScoreText.Text = $"Рекорд очков: {settings.BestTetrominoWithBoostersScore}";
                        FinalLinesText.Text = $"Линий: {gameState.ClearedLines}";
                    }
                    else if (settings.Language == 2)
                    {
                        BestScoreText.Text = $"Points Record: {settings.BestTetrominoWithBoostersScore}";
                        FinalLinesText.Text = $"Lines: {gameState.ClearedLines}";
                    }
                }
                // Тримино Классика
                else if (gameState.gameOptions.TriminoModeFlag && gameState.gameOptions.IsMode == 1)
                {
                    GameOverMenu.Visibility = Visibility.Visible;
                    if (settings.Language == 1) FinalScoreText.Text = $"Очки: {gameState.Score}";
                    else if (settings.Language == 2) FinalScoreText.Text = $"Points: {gameState.Score}";

                    if (gameState.Score > settings.BestTriminoClassicScore)
                    {
                        settings.BestTriminoClassicScore = gameState.Score;
                        Settings.Save(settings);
                    }

                    BestScoreText.Visibility = Visibility.Visible;
                    if (settings.Language == 1)
                    {
                        BestScoreText.Text = $"Рекорд очков: {settings.BestTriminoClassicScore}";
                        FinalLinesText.Text = $"Линий: {gameState.ClearedLines}";
                    }
                    else if (settings.Language == 2)
                    {
                        BestScoreText.Text = $"Points Record: {settings.BestTriminoClassicScore}";
                        FinalLinesText.Text = $"Lines: {gameState.ClearedLines}";
                    }
                }
                // Тримино с Бустерами
                else if (gameState.gameOptions.TriminoModeFlag && gameState.gameOptions.IsMode == 2)
                {
                    GameOverMenu.Visibility = Visibility.Visible;
                    if (settings.Language == 1) FinalScoreText.Text = $"Очки: {gameState.Score}";
                    else if (settings.Language == 2) FinalScoreText.Text = $"Points: {gameState.Score}";

                    if (gameState.Score > settings.BestTriminoWithBoostersScore)
                    {
                        settings.BestTriminoWithBoostersScore = gameState.Score;
                        Settings.Save(settings);
                    }

                    BestScoreText.Visibility = Visibility.Visible;
                    if (settings.Language == 1)
                    {
                        BestScoreText.Text = $"Рекорд очков: {settings.BestTriminoWithBoostersScore}";
                        FinalLinesText.Text = $"Линий: {gameState.ClearedLines}";
                    }
                    else if (settings.Language == 2)
                    {
                        BestScoreText.Text = $"Points Record: {settings.BestTriminoWithBoostersScore}";
                        FinalLinesText.Text = $"Lines: {gameState.ClearedLines}";
                    }
                }
                // ОнлиТетрис
                else if (gameState.gameOptions.OnlyTetrisModeFlag)
                {
                    GameOverMenu.Visibility = Visibility.Visible;

                    if (gameState.Tetris >= 4)                      // Меняю показатель для тестов. НОРМА - 4
                    {
                        GetPrize();
                        UIGetPrize();
                    }

                    if (settings.Language == 1) FinalScoreText.Text = $"Тетрисы: {gameState.Tetris}";
                    else if (settings.Language == 2) FinalScoreText.Text = $"Tetris: {gameState.Tetris}";

                    if (gameState.Tetris > settings.BestOnlyTetrisScore)
                    {
                        settings.BestOnlyTetrisScore = gameState.Tetris;
                        Settings.Save(settings);
                    }

                    BestScoreText.Visibility = Visibility.Visible;
                    if (settings.Language == 1) BestScoreText.Text = $"Рекорд Тетрисов: {settings.BestOnlyTetrisScore}";
                    else if (settings.Language == 2) BestScoreText.Text = $"Tetris Record: {settings.BestOnlyTetrisScore}";
                }
                // Выживание
                else if (gameState.gameOptions.SurvivalModeFlag)
                {
                    GameOverMenu.Visibility = Visibility.Visible;

                    if (gameState.ClearedLines >= 40)               // Меняю показатель для тестов. НОРМА - 40
                    {
                        GetPrize();
                        UIGetPrize();
                    }

                    if (settings.Language == 1) FinalScoreText.Text = $"Сбросов скорости: {gameState.Tetris}";
                    else if (settings.Language == 2) FinalScoreText.Text = $"Speed Resets: {gameState.Tetris}";

                    if (gameState.ClearedLines > settings.BestSurvivalScore)
                    {
                        settings.BestSurvivalScore = gameState.ClearedLines;
                        Settings.Save(settings);
                    }

                    BestScoreText.Visibility = Visibility.Visible;
                    if (settings.Language == 1)
                    {
                        BestScoreText.Text = $"Рекорд линий: {settings.BestSurvivalScore}";
                        FinalLinesText.Text = $"Линий: {gameState.ClearedLines}";
                    }
                    else if (settings.Language == 2)
                    {
                        BestScoreText.Text = $"Lines Record: {settings.BestSurvivalScore}";
                        FinalLinesText.Text = $"Lines: {gameState.ClearedLines}";
                    }
                }
                // Аркада
                /*else if (gameState.gameOptions.ArcadeModeFlag)
                {
                    GameOverMenu.Visibility = Visibility.Visible;
                    FinalScoreText.Text = $"Поинты: {gameState.ArcadeClearedLines}";
                    if (gameState.ArcadeClearedLines > settings.BestArcadeScore)
                    {
                        settings.BestArcadeScore = gameState.ClearedLines;
                        Settings.Save(settings);
                    }
                    BestScoreText.Visibility = Visibility.Visible;
                    BestScoreText.Text = $"Рекорд очков: {settings.BestArcadeScore}";
                    FinalLinesText.Text = $"Линий: {gameState.ClearedLines}";
                }*/
                // Спринт Пентомино
                else if (gameState.gameOptions.PentominoModeFlag && gameState.gameOptions.IsMode == 3)
                {
                    stopwatch.Stop();

                    GameOverMenu.Visibility = Visibility.Visible;
                    if (settings.Language == 1) FinalScoreText.Text = $"Время: {stopwatch.Elapsed.ToString(@"mm\:ss\:ff")}";
                    else if (settings.Language == 2) FinalScoreText.Text = $"Time: {stopwatch.Elapsed.ToString(@"mm\:ss\:ff")}";

                    if (gameState.sprintWin && (stopwatch.Elapsed < settings.BestSprintPentominoTime || settings.BestSprintPentominoTime == TimeSpan.Zero))
                    {
                        settings.BestSprintPentominoTime = stopwatch.Elapsed;
                        Settings.Save(settings);
                    }

                    if (settings.Language == 1)
                    {
                        if (gameState.sprintWin) EndGame.Text = $"Победа!";
                        else if (!gameState.sprintWin) EndGame.Text = $"Окончено";
                    }
                    else if (settings.Language == 2)
                    {
                        if (gameState.sprintWin) EndGame.Text = $"Victory!";
                        else if (!gameState.sprintWin) EndGame.Text = $"Finished";
                    }

                    BestScoreText.Visibility = Visibility.Visible;
                    if (settings.Language == 1) BestScoreText.Text = $"Рекордное время: {settings.BestSprintPentominoTime:mm\\:ss\\:ff}";
                    else if (settings.Language == 2) BestScoreText.Text = $"Time Record: {settings.BestSprintPentominoTime:mm\\:ss\\:ff}";
                }
                // Спринт Тетромино
                else if (gameState.gameOptions.TetrominoModeFlag && gameState.gameOptions.IsMode == 3)
                {
                    stopwatch.Stop();

                    GameOverMenu.Visibility = Visibility.Visible;
                    if (settings.Language == 1) FinalScoreText.Text = $"Время: {stopwatch.Elapsed.ToString(@"mm\:ss\:ff")}";
                    else if (settings.Language == 2) FinalScoreText.Text = $"Time: {stopwatch.Elapsed.ToString(@"mm\:ss\:ff")}";

                    if (gameState.sprintWin && (stopwatch.Elapsed < settings.BestSprintTetrominoTime || settings.BestSprintTetrominoTime == TimeSpan.Zero))
                    {
                        settings.BestSprintTetrominoTime = stopwatch.Elapsed;
                        Settings.Save(settings);
                    }

                    if (settings.Language == 1)
                    {
                        if (gameState.sprintWin) EndGame.Text = $"Победа!";
                        else if (!gameState.sprintWin) EndGame.Text = $"Окончено";
                    }
                    else if (settings.Language == 2)
                    {
                        if (gameState.sprintWin) EndGame.Text = $"Victory!";
                        else if (!gameState.sprintWin) EndGame.Text = $"Finished";
                    }

                    BestScoreText.Visibility = Visibility.Visible;
                    if (settings.Language == 1) BestScoreText.Text = $"Рекордное время: {settings.BestSprintTetrominoTime:mm\\:ss\\:ff}";
                    else if (settings.Language == 2) BestScoreText.Text = $"Time Record: {settings.BestSprintTetrominoTime:mm\\:ss\\:ff}";
                }
                // Спринт Тримино
                else if (gameState.gameOptions.TriminoModeFlag && gameState.gameOptions.IsMode == 3)
                {
                    stopwatch.Stop();

                    GameOverMenu.Visibility = Visibility.Visible;
                    if (settings.Language == 1) FinalScoreText.Text = $"Время: {stopwatch.Elapsed.ToString(@"mm\:ss\:ff")}";
                    else if (settings.Language == 2) FinalScoreText.Text = $"Time: {stopwatch.Elapsed.ToString(@"mm\:ss\:ff")}";


                    if (gameState.sprintWin && (stopwatch.Elapsed < settings.BestSprintTriminoTime || settings.BestSprintTriminoTime == TimeSpan.Zero))
                    {
                        settings.BestSprintTriminoTime = stopwatch.Elapsed;
                        Settings.Save(settings);
                    }

                    if (settings.Language == 1)
                    {
                        if (gameState.sprintWin) EndGame.Text = $"Победа!";
                        else if (!gameState.sprintWin) EndGame.Text = $"Окончено";
                    }
                    else if (settings.Language == 2)
                    {
                        if (gameState.sprintWin) EndGame.Text = $"Victory!";
                        else if (!gameState.sprintWin) EndGame.Text = $"Finished";
                    }

                    BestScoreText.Visibility = Visibility.Visible;
                    if (settings.Language == 1) BestScoreText.Text = $"Рекордное время: {settings.BestSprintTriminoTime:mm\\:ss\\:ff}";
                    else if (settings.Language == 2) BestScoreText.Text = $"Time Record: {settings.BestSprintTriminoTime:mm\\:ss\\:ff}";
                }
                // Спринт Линии
                else if (gameState.gameOptions.TetrominoModeFlag && gameState.gameOptions.IsMode == 4)
                {
                    stopwatch.Stop();

                    GameOverMenu.Visibility = Visibility.Visible;
                    if (settings.Language == 1) FinalScoreText.Text = $"Время: {stopwatch.Elapsed.ToString(@"mm\:ss\:ff")}";
                    else if (settings.Language == 2) FinalScoreText.Text = $"Время: {stopwatch.Elapsed.ToString(@"mm\:ss\:ff")}";

                    if (gameState.sprintWin && (stopwatch.Elapsed < settings.BestSprintLineTime || settings.BestSprintLineTime == TimeSpan.Zero))
                    {
                        settings.BestSprintLineTime = stopwatch.Elapsed;
                        Settings.Save(settings);
                    }

                    if (settings.Language == 1)
                    {
                        if (gameState.sprintWin) EndGame.Text = $"Победа!";
                        else if (!gameState.sprintWin) EndGame.Text = $"Окончено";
                    }
                    else if (settings.Language == 2)
                    {
                        if (gameState.sprintWin) EndGame.Text = $"Victory!";
                        else if (!gameState.sprintWin) EndGame.Text = $"Finished";
                    }

                    BestScoreText.Visibility = Visibility.Visible;
                    if (settings.Language == 1) BestScoreText.Text = $"Рекордное время: {settings.BestSprintLineTime:mm\\:ss\\:ff}";
                    else if (settings.Language == 2) BestScoreText.Text = $"Time Record: {settings.BestSprintLineTime:mm\\:ss\\:ff}";
                }
                // Спринт Очки
                else if (gameState.gameOptions.TetrominoModeFlag && gameState.gameOptions.IsMode == 5)
                {
                    stopwatch.Stop();

                    GameOverMenu.Visibility = Visibility.Visible;
                    if (settings.Language == 1) FinalScoreText.Text = $"Время: {stopwatch.Elapsed.ToString(@"mm\:ss\:ff")}";
                    else if (settings.Language == 2) FinalScoreText.Text = $"Time: {stopwatch.Elapsed.ToString(@"mm\:ss\:ff")}";

                    if (gameState.sprintWin && (stopwatch.Elapsed < settings.BestSprintPointTime || settings.BestSprintPointTime == TimeSpan.Zero))
                    {
                        settings.BestSprintPointTime = stopwatch.Elapsed;
                        Settings.Save(settings);
                    }

                    if (settings.Language == 1)
                    {
                        if (gameState.sprintWin) EndGame.Text = $"Победа!";
                        else if (!gameState.sprintWin) EndGame.Text = $"Окончено";
                    }
                    else if (settings.Language == 2)
                    {
                        if (gameState.sprintWin) EndGame.Text = $"Victory!";
                        else if (!gameState.sprintWin) EndGame.Text = $"Finished";
                    }

                    BestScoreText.Visibility = Visibility.Visible;
                    if (settings.Language == 1) BestScoreText.Text = $"Рекордное время: {settings.BestSprintPointTime:mm\\:ss\\:ff}";
                    else if (settings.Language == 2) BestScoreText.Text = $"Time Record: {settings.BestSprintPointTime:mm\\:ss\\:ff}";

                }
                // Утрамбовка
                else if (gameState.gameOptions.TampingModeFlag)
                {
                    GameOverMenu.Visibility = Visibility.Visible;

                    if (gameState.DifCells >= 50)                   // Меняю показатель для тестов. НОРМА - 50
                    {
                        GetPrize();
                        UIGetPrize();
                    }

                    if (settings.Language == 1) FinalScoreText.Text = $"{gameState.DifCells} ячеек заполнено";
                    else if (settings.Language == 2) FinalScoreText.Text = $"{gameState.DifCells} cells filled";

                    if (gameState.DifCells > settings.BestTampingScore)
                    {
                        settings.BestTampingScore = gameState.DifCells;
                        Settings.Save(settings);
                    }

                    BestScoreText.Visibility = Visibility.Visible;
                    if (settings.Language == 1) BestScoreText.Text = $"Рекордно заполнено {settings.BestTampingScore} ячеек";
                    else if (settings.Language == 2) BestScoreText.Text = $"A record {settings.BestTampingScore} cells have been filled";
                }
                // Мозаика
                else if (gameState.gameOptions.MosaicModeFlag)
                {
                    MosaicGameOverMenu.Visibility = Visibility.Visible;

                    if (gameState.mosaicWin)
                    {
                        WinResult.Visibility = Visibility.Visible;
                        LoseResult.Visibility = Visibility.Hidden;
                        MosaicPrizeText.Visibility = Visibility.Visible;

                        GetPrize();
                        MosaicUIGetPrize();
                    }
                    else if (!gameState.mosaicWin)
                    {
                        WinResult.Visibility = Visibility.Hidden;
                        LoseResult.Visibility = Visibility.Visible;
                        MosaicPrizeText.Visibility = Visibility.Hidden;
                    }

                    BestScoreText.Visibility = Visibility.Hidden;
                }
                // Медитация
                else if (gameState.gameOptions.MeditationModeFlag)
                {
                    MeditationGameOverMenu.Visibility = Visibility.Visible;
                    BestScoreText.Visibility = Visibility.Hidden;
                }

                SurvivalDelay = 0;
                Delay = 0;
            }
        }

        // Отображение на экране получение бустера во всех режимах кроме Мозаика
        private void UIGetPrize()
        {
            if (prize1 && prize2 && prize3 && prize4)
            {
                MaxPrizeText.Visibility = Visibility.Visible;
                PrizeText.Visibility = Visibility.Hidden;
            }
            else if (prize == 1)
            {
                PrizeText.Visibility = Visibility.Visible;
                if (settings.Language == 1) PrizeText.Text = $"Твой бустер: Палка";
                else if (settings.Language == 2) PrizeText.Text = $"You got a booster: Stick";
            }
            else if (prize == 2)
            {
                PrizeText.Visibility = Visibility.Visible;
                if (settings.Language == 1) PrizeText.Text = $"Твой бустер: Закрыть дырки";
                else if (settings.Language == 2) PrizeText.Text = $"You got a booster: Close Holes";
            }
            else if (prize == 3)
            {
                PrizeText.Visibility = Visibility.Visible;
                if (settings.Language == 1) PrizeText.Text = $"Твой бустер: Сдвиг Вниз";
                else if (settings.Language == 2) PrizeText.Text = $"You got a booster: Downward Shift";
            }
            else if (prize == 4)
            {
                PrizeText.Visibility = Visibility.Visible;
                if (settings.Language == 1) PrizeText.Text = $"Твой бустер: Пустой стакан";
                else if (settings.Language == 2) PrizeText.Text = $"You got a booster: Empty Glass";
            }
            else
            {
                MaxPrizeText.Visibility = Visibility.Hidden;
                PrizeText.Visibility = Visibility.Hidden;
            }
        }

        // Отображение на экране получение бустера только в режиме Мозаика
        private void MosaicUIGetPrize()
        {
            if (prize1 && prize2 && prize3 && prize4)
            {
                MosaicMaxPrizeText.Visibility = Visibility.Visible;
                MosaicPrizeText.Visibility = Visibility.Hidden;
            }
            else if (prize == 1)
            {
                MosaicPrizeText.Visibility = Visibility.Visible;
                if (settings.Language == 1) MosaicPrizeText.Text = $"Твой бустер: Палка";
                else if (settings.Language == 2) PrizeText.Text = $"You got a booster: Stick";
            }
            else if (prize == 2)
            {
                MosaicPrizeText.Visibility = Visibility.Visible;
                if (settings.Language == 1) MosaicPrizeText.Text = $"Твой бустер: Закрыть дирки";
                else if (settings.Language == 2) MosaicPrizeText.Text = $"You got a booster: Close Holes";
            }
            else if (prize == 3)
            {
                MosaicPrizeText.Visibility = Visibility.Visible;
                if (settings.Language == 1) MosaicPrizeText.Text = $"Твой бустер: Сдвиг вниз";
                else if (settings.Language == 2) MosaicPrizeText.Text = $"You got a booster: Downward Shift";
            }
            else if (prize == 4)
            {
                MosaicPrizeText.Visibility = Visibility.Visible;
                if (settings.Language == 1) MosaicPrizeText.Text = $"Твой бустер: Пустой стакан";
                else if (settings.Language == 2) MosaicPrizeText.Text = $"You got a booster: Empty Glass";
            }
            else
            {
                MosaicMaxPrizeText.Visibility = Visibility.Hidden;
                MosaicPrizeText.Visibility = Visibility.Hidden;
            }
        }

        // Отображает игровую статистику во время игры
        private void Statistics()
        {
            if (settings.Language == 1)
            {
                if (gameState.gameOptions.OnlyTetrisModeFlag) ScoreText.Text = $"Тетрисы: {gameState.Tetris}";
                else if (gameState.gameOptions.SurvivalModeFlag) ScoreText.Text = $"Сбросов скорости: {gameState.Tetris}";
                //else if (gameState.gameOptions.ArcadeModeFlag) ScoreText.Text = $"Поинты: {gameState.ArcadeClearedLines}";
                else if (gameState.gameOptions.TampingModeFlag) ScoreText.Text = $"{gameState.DifCells} ячеек заполнено";
                else if (!gameState.gameOptions.MosaicModeFlag) ScoreText.Text = $"Очки: {gameState.Score}";

                if (gameState.gameOptions.TetrominoModeFlag && gameState.gameOptions.IsMode == 4)
                {
                    ScoreMultiplierText.Text = $"Множитель очков-{gameState.ScoreMultiplier}";
                    ClearedLineText.Text = $"Линий-{gameState.ClearedLines}/100";
                }
                else if (gameState.gameOptions.TetrominoModeFlag && gameState.gameOptions.IsMode == 5)
                {
                    ScoreMultiplierText.Text = $"Множитель очков-{gameState.ScoreMultiplier}";
                    ClearedLineText.Text = $"Очки-{gameState.Score}/100000";
                }
                else if (!gameState.gameOptions.TampingModeFlag)
                {
                    ScoreMultiplierText.Text = $"Множитель очков-{gameState.ScoreMultiplier}";
                    ClearedLineText.Text = $"Линий-{gameState.ClearedLines}";
                }

                if ((gameState.gameOptions.TriminoModeFlag || gameState.gameOptions.TetrominoModeFlag || gameState.gameOptions.PentominoModeFlag) &&
                    gameState.gameOptions.IsMode == 2)
                {
                    GetStickText.Text = $"Палка - Q: {settings.QuantityGetStick}";
                    CloseHolesText.Text = $"Закрыть дырки - W: {settings.QuantityCloseHoles}";
                    DownwardShiftText.Text = $"Сдвиг вниз - E: {settings.QuantityDownwardShift}";
                    EmptyGlassText.Text = $"Пустой стакан - R: {settings.QuantityEmptyGlass}";
                }
            }
            else if (settings.Language == 2)
            {
                if (gameState.gameOptions.OnlyTetrisModeFlag) ScoreText.Text = $"Tetris: {gameState.Tetris}";
                else if (gameState.gameOptions.SurvivalModeFlag) ScoreText.Text = $"Speed Resets: {gameState.Tetris}";
                //else if (gameState.gameOptions.ArcadeModeFlag) ScoreText.Text = $"Points: {gameState.ArcadeClearedLines}";
                else if (gameState.gameOptions.TampingModeFlag) ScoreText.Text = $"{gameState.DifCells} cells filled";
                else if (!gameState.gameOptions.MosaicModeFlag) ScoreText.Text = $"Points: {gameState.Score}";

                if (gameState.gameOptions.TetrominoModeFlag && gameState.gameOptions.IsMode == 4)
                {
                    ScoreMultiplierText.Text = $"Point Multiplier-{gameState.ScoreMultiplier}";
                    ClearedLineText.Text = $"Lines-{gameState.ClearedLines}/100";
                }
                else if (gameState.gameOptions.TetrominoModeFlag && gameState.gameOptions.IsMode == 5)
                {
                    ScoreMultiplierText.Text = $"Point Multiplier-{gameState.ScoreMultiplier}";
                    ClearedLineText.Text = $"Points-{gameState.Score}/100000";
                }
                else if (!gameState.gameOptions.TampingModeFlag)
                {
                    ScoreMultiplierText.Text = $"Point Multiplier-{gameState.ScoreMultiplier}";
                    ClearedLineText.Text = $"Lines-{gameState.ClearedLines}";
                }

                if ((gameState.gameOptions.TriminoModeFlag || gameState.gameOptions.TetrominoModeFlag || gameState.gameOptions.PentominoModeFlag) &&
                    gameState.gameOptions.IsMode == 2)
                {
                    GetStickText.Text = $"Stick - Q: {settings.QuantityGetStick}";
                    CloseHolesText.Text = $"Close Holes - W: {settings.QuantityCloseHoles}";
                    DownwardShiftText.Text = $"Downward Shift - E: {settings.QuantityDownwardShift}";
                    EmptyGlassText.Text = $"Empty Glass - R: {settings.QuantityEmptyGlass}";
                }
            }

            //drawTileIndexText.Text = $"drawTileIndexText = {gameState.drawTileIndex}";  // ДЛЯ ТЕСТОВ - нужно включить видимость в MainWindow.xaml
            //DelayText.Text = $"Задержка: {Delay}";  // ДЛЯ ТЕСТОВ
        }

        // Увеличивает количество бустеров
        private void GetPrize()
        {
            // Флаги prize позволяют ограничить максимально возможное количество бустеров
            if (prize1 && prize2 && prize3 && prize4) return;

            var random = new Random();
            prize = random.Next(1, 5);

            if (prize == 1)
            {
                settings.QuantityGetStick++;

                if (settings.QuantityGetStick > 4)  
                {
                    prize1 = true;
                    settings.QuantityGetStick--;
                    GetPrize();
                }
                Settings.Save(settings);
            }
            else if (prize == 2)
            {
                settings.QuantityCloseHoles++;

                if (settings.QuantityCloseHoles > 3)
                {
                    prize2 = true;
                    settings.QuantityCloseHoles--;
                    GetPrize();
                }
                Settings.Save(settings);
            }
            else if (prize == 3)
            {
                settings.QuantityDownwardShift++;

                if (settings.QuantityDownwardShift > 2)
                {
                    prize3 = true;
                    settings.QuantityDownwardShift--;
                    GetPrize();
                }
                Settings.Save(settings);
            }
            else if (prize == 4)
            {
                settings.QuantityEmptyGlass++;

                if (settings.QuantityEmptyGlass > 1)
                {
                    prize4 = true;
                    settings.QuantityEmptyGlass--;
                    GetPrize();
                }
                Settings.Save(settings);
            }
        }

        // Проверяет, есть ли запущенный игровой цикл
        private async void CheckGameLoop()
        {
            if (isGameLoopRunning) return;

            isGameLoopRunning = true;       // Устанавливаем флаг, что игровой цикл запущен
            await GameLoop();               // Запускаем игровой цикл
            isGameLoopRunning = false;      // После завершения игрового цикла сбрасываем флаг
        }

        // Перезапуск игры
        private async void PlayAgain_Click(object sender, RoutedEventArgs e)  // sender — объект, который вызвал событие. В данном случае, это сам элемент управления кнопкой
                                                                              // e — объект RoutedEventArgs, содержащий информацию о событии клика
        {
            if (gameState.gameOptions.MeditationModeFlag) MeditationGameOverMenu.Visibility = Visibility.Hidden;  // Закрытие меню окончания игры
            else if (gameState.gameOptions.MosaicModeFlag)
            {
                MosaicGameOverMenu.Visibility = Visibility.Hidden;
                WinResult.Visibility = Visibility.Hidden;
                LoseResult.Visibility = Visibility.Hidden;
                MosaicPrizeText.Visibility = Visibility.Hidden;
                MosaicMaxPrizeText.Visibility = Visibility.Hidden;
            }
            else
            {
                GameOverMenu.Visibility = Visibility.Hidden;
                MaxPrizeText.Visibility = Visibility.Hidden;
                PrizeText.Visibility = Visibility.Hidden;
            }

            if (gameState.gameOptions.MeditationModeFlag) MeditationPauseMenu.Visibility = Visibility.Hidden;     // Закрытие меню паузы
            else PauseMenu.Visibility = Visibility.Hidden;

            Pause = false;
            SurvivalDelay = 0;

            prize1 = false;
            prize2 = false;
            prize3 = false;
            prize4 = false;

            if (currentMusic == null)
            {
                if (gameState.gameOptions.MeditationModeFlag) PlayBackgroundMusic("MeditationBackgroundMusic.mp3");
                else PlayBackgroundMusic("BackgroundMusic.mp3");
            }

            if (gameState.gameOptions.IsMode == 3 || gameState.gameOptions.IsMode == 4 || gameState.gameOptions.IsMode == 5)
            {
                gameState.sprintWin = false;
                stopwatch.Reset();
                timer.Stop();
            }

            // Определяет какой режим перезапустить
            if (gameState.gameOptions.TetrominoModeFlag && gameState.gameOptions.IsMode == 1) TetraminoClassicMode_Click(sender, e);
            else if (gameState.gameOptions.TetrominoModeFlag && gameState.gameOptions.IsMode == 2) TetraminoWithBoostersMode_Click(sender, e);
            else if (gameState.gameOptions.TriminoModeFlag && gameState.gameOptions.IsMode == 1) TriminoClassicMode_Click(sender, e);
            else if (gameState.gameOptions.TriminoModeFlag && gameState.gameOptions.IsMode == 2) TriminoWithBoostersMode_Click(sender, e);
            else if (gameState.gameOptions.PentominoModeFlag && gameState.gameOptions.IsMode == 1) PentominoClassicMode_Click(sender, e);
            else if (gameState.gameOptions.PentominoModeFlag && gameState.gameOptions.IsMode == 2) PentominoWithBoostersMode_Click(sender, e);
            else if (gameState.gameOptions.OnlyTetrisModeFlag) OnlyTetrisMode_Click(sender, e);
            else if (gameState.gameOptions.SurvivalModeFlag) SurvivalMode_Click(sender, e);
            //else if (gameState.gameOptions.ArcadeModeFlag) ArcadeMode_Click(sender, e);
            else if (gameState.gameOptions.PentominoModeFlag && gameState.gameOptions.IsMode == 3) SprintPentominoMode_Click(sender, e);
            else if (gameState.gameOptions.TetrominoModeFlag && gameState.gameOptions.IsMode == 3) SprintTetrominoMode_Click(sender, e);
            else if (gameState.gameOptions.TriminoModeFlag && gameState.gameOptions.IsMode == 3) SprintTriminoMode_Click(sender, e);
            else if (gameState.gameOptions.TetrominoModeFlag && gameState.gameOptions.IsMode == 4) SprintLinesMode_Click(sender, e);
            else if (gameState.gameOptions.TetrominoModeFlag && gameState.gameOptions.IsMode == 5) SprintPointsMode_Click(sender, e);
            else if (gameState.gameOptions.TampingModeFlag) TampingMode_Click(sender, e);
            else if (gameState.gameOptions.MosaicModeFlag) MosaicMode_Click(sender, e);
            else if (gameState.gameOptions.MeditationModeFlag) MeditationMode_Click(sender, e);
        }

        // Открывает Справку
        private void HelpButton_Click(object sender, RoutedEventArgs e)
        {
            Help = true;
            if (settings.Language == 1)
            {
                if (gameState.gameOptions.PentominoModeFlag && gameState.gameOptions.IsMode == 1) HelpPentominoClassicMenu.Visibility = Visibility.Visible;
                else if (gameState.gameOptions.PentominoModeFlag && gameState.gameOptions.IsMode == 2) HelpPentominoWithBoostersMenu.Visibility = Visibility.Visible;
                else if (gameState.gameOptions.TetrominoModeFlag && gameState.gameOptions.IsMode == 1) HelpTetrominoClassicMenu.Visibility = Visibility.Visible;
                else if (gameState.gameOptions.TetrominoModeFlag && gameState.gameOptions.IsMode == 2) HelpTetrominoWithBoostersMenu.Visibility = Visibility.Visible;
                else if (gameState.gameOptions.TriminoModeFlag && gameState.gameOptions.IsMode == 1) HelpTriminoClassicMenu.Visibility = Visibility.Visible;
                else if (gameState.gameOptions.TriminoModeFlag && gameState.gameOptions.IsMode == 2) HelpTriminoWithBoostersMenu.Visibility = Visibility.Visible;
                else if (gameState.gameOptions.OnlyTetrisModeFlag) HelpOnlyTetrisMenu.Visibility = Visibility.Visible;
                else if (gameState.gameOptions.SurvivalModeFlag) HelpSurvivalMenu.Visibility = Visibility.Visible;
                //else if (gameState.gameOptions.ArcadeModeFlag) HelpArcadeMenu.Visibility = Visibility.Visible;
                else if (gameState.gameOptions.PentominoModeFlag && gameState.gameOptions.IsMode == 3) HelpSprintPentominoMenu.Visibility = Visibility.Visible;
                else if (gameState.gameOptions.TetrominoModeFlag && gameState.gameOptions.IsMode == 3) HelpSprintTetrominoMenu.Visibility = Visibility.Visible;
                else if (gameState.gameOptions.TriminoModeFlag && gameState.gameOptions.IsMode == 3) HelpSprintTriminoMenu.Visibility = Visibility.Visible;
                else if (gameState.gameOptions.TetrominoModeFlag && gameState.gameOptions.IsMode == 4) HelpSprintLinesMenu.Visibility = Visibility.Visible;
                else if (gameState.gameOptions.TetrominoModeFlag && gameState.gameOptions.IsMode == 5) HelpSprintPointsMenu.Visibility = Visibility.Visible;
                else if (gameState.gameOptions.TampingModeFlag) HelpTampingMenu.Visibility = Visibility.Visible;
                else if (gameState.gameOptions.MosaicModeFlag) HelpMosaicMenu.Visibility = Visibility.Visible;
                else if (gameState.gameOptions.MeditationModeFlag) HelpMeditationMenu.Visibility = Visibility.Visible;
            }
            else if (settings.Language == 2)
            {
                if (gameState.gameOptions.PentominoModeFlag && gameState.gameOptions.IsMode == 1) HelpPentominoClassicMenuEnglish.Visibility = Visibility.Visible;
                else if (gameState.gameOptions.PentominoModeFlag && gameState.gameOptions.IsMode == 2) HelpPentominoWithBoostersMenuEnglish.Visibility = Visibility.Visible;
                else if (gameState.gameOptions.TetrominoModeFlag && gameState.gameOptions.IsMode == 1) HelpTetrominoClassicMenuEnglish.Visibility = Visibility.Visible;
                else if (gameState.gameOptions.TetrominoModeFlag && gameState.gameOptions.IsMode == 2) HelpTetrominoWithBoostersMenuEnglish.Visibility = Visibility.Visible;
                else if (gameState.gameOptions.TriminoModeFlag && gameState.gameOptions.IsMode == 1) HelpTriminoClassicMenuEnglish.Visibility = Visibility.Visible;
                else if (gameState.gameOptions.TriminoModeFlag && gameState.gameOptions.IsMode == 2) HelpTriminoWithBoostersMenuEnglish.Visibility = Visibility.Visible;
                else if (gameState.gameOptions.OnlyTetrisModeFlag) HelpOnlyTetrisMenuEnglish.Visibility = Visibility.Visible;
                else if (gameState.gameOptions.SurvivalModeFlag) HelpSurvivalMenuEnglish.Visibility = Visibility.Visible;
                //else if (gameState.gameOptions.ArcadeModeFlag) HelpArcadeMenu.Visibility = Visibility.Visible;
                else if (gameState.gameOptions.PentominoModeFlag && gameState.gameOptions.IsMode == 3) HelpSprintPentominoMenuEnglish.Visibility = Visibility.Visible;
                else if (gameState.gameOptions.TetrominoModeFlag && gameState.gameOptions.IsMode == 3) HelpSprintTetrominoMenuEnglish.Visibility = Visibility.Visible;
                else if (gameState.gameOptions.TriminoModeFlag && gameState.gameOptions.IsMode == 3) HelpSprintTriminoMenuEnglish.Visibility = Visibility.Visible;
                else if (gameState.gameOptions.TetrominoModeFlag && gameState.gameOptions.IsMode == 4) HelpSprintLinesMenuEnglish.Visibility = Visibility.Visible;
                else if (gameState.gameOptions.TetrominoModeFlag && gameState.gameOptions.IsMode == 5) HelpSprintPointsMenuEnglish.Visibility = Visibility.Visible;
                else if (gameState.gameOptions.TampingModeFlag) HelpTampingMenuEnglish.Visibility = Visibility.Visible;
                else if (gameState.gameOptions.MosaicModeFlag) HelpMosaicMenuEnglish.Visibility = Visibility.Visible;
                else if (gameState.gameOptions.MeditationModeFlag) HelpMeditationMenuEnglish.Visibility = Visibility.Visible;
            }
            CloseHelpButton.Visibility = Visibility.Visible;
            stopwatch.Stop();
            //PauseMusic();
        }

        // Закрывает Справку
        private void CloseHelpButton_Click(object sender, RoutedEventArgs e)
        {
            Help = false;
            if (settings.Language == 1)
            {
                if (gameState.gameOptions.PentominoModeFlag && gameState.gameOptions.IsMode == 1) HelpPentominoClassicMenu.Visibility = Visibility.Hidden;
                else if (gameState.gameOptions.PentominoModeFlag && gameState.gameOptions.IsMode == 2) HelpPentominoWithBoostersMenu.Visibility = Visibility.Hidden;
                else if (gameState.gameOptions.TetrominoModeFlag && gameState.gameOptions.IsMode == 1) HelpTetrominoClassicMenu.Visibility = Visibility.Hidden;
                else if (gameState.gameOptions.TetrominoModeFlag && gameState.gameOptions.IsMode == 2) HelpTetrominoWithBoostersMenu.Visibility = Visibility.Hidden;
                else if (gameState.gameOptions.TriminoModeFlag && gameState.gameOptions.IsMode == 1) HelpTriminoClassicMenu.Visibility = Visibility.Hidden;
                else if (gameState.gameOptions.TriminoModeFlag && gameState.gameOptions.IsMode == 2) HelpTriminoWithBoostersMenu.Visibility = Visibility.Hidden;
                else if (gameState.gameOptions.OnlyTetrisModeFlag) HelpOnlyTetrisMenu.Visibility = Visibility.Hidden;
                else if (gameState.gameOptions.SurvivalModeFlag) HelpSurvivalMenu.Visibility = Visibility.Hidden;
                //else if (gameState.gameOptions.ArcadeModeFlag) HelpArcadeMenu.Visibility = Visibility.Hidden;
                else if (gameState.gameOptions.PentominoModeFlag && gameState.gameOptions.IsMode == 3) HelpSprintPentominoMenu.Visibility = Visibility.Hidden;
                else if (gameState.gameOptions.TetrominoModeFlag && gameState.gameOptions.IsMode == 3) HelpSprintTetrominoMenu.Visibility = Visibility.Hidden;
                else if (gameState.gameOptions.TriminoModeFlag && gameState.gameOptions.IsMode == 3) HelpSprintTriminoMenu.Visibility = Visibility.Hidden;
                else if (gameState.gameOptions.TetrominoModeFlag && gameState.gameOptions.IsMode == 4) HelpSprintLinesMenu.Visibility = Visibility.Hidden;
                else if (gameState.gameOptions.TetrominoModeFlag && gameState.gameOptions.IsMode == 5) HelpSprintPointsMenu.Visibility = Visibility.Hidden;
                else if (gameState.gameOptions.TampingModeFlag) HelpTampingMenu.Visibility = Visibility.Hidden;
                else if (gameState.gameOptions.MosaicModeFlag) HelpMosaicMenu.Visibility = Visibility.Hidden;
                else if (gameState.gameOptions.MeditationModeFlag) HelpMeditationMenu.Visibility = Visibility.Hidden;
            }
            else if (settings.Language == 2)
            {
                if (gameState.gameOptions.PentominoModeFlag && gameState.gameOptions.IsMode == 1) HelpPentominoClassicMenuEnglish.Visibility = Visibility.Hidden;
                else if (gameState.gameOptions.PentominoModeFlag && gameState.gameOptions.IsMode == 2) HelpPentominoWithBoostersMenuEnglish.Visibility = Visibility.Hidden;
                else if (gameState.gameOptions.TetrominoModeFlag && gameState.gameOptions.IsMode == 1) HelpTetrominoClassicMenuEnglish.Visibility = Visibility.Hidden;
                else if (gameState.gameOptions.TetrominoModeFlag && gameState.gameOptions.IsMode == 2) HelpTetrominoWithBoostersMenuEnglish.Visibility = Visibility.Hidden;
                else if (gameState.gameOptions.TriminoModeFlag && gameState.gameOptions.IsMode == 1) HelpTriminoClassicMenuEnglish.Visibility = Visibility.Hidden;
                else if (gameState.gameOptions.TriminoModeFlag && gameState.gameOptions.IsMode == 2) HelpTriminoWithBoostersMenuEnglish.Visibility = Visibility.Hidden;
                else if (gameState.gameOptions.OnlyTetrisModeFlag) HelpOnlyTetrisMenuEnglish.Visibility = Visibility.Hidden;
                else if (gameState.gameOptions.SurvivalModeFlag) HelpSurvivalMenuEnglish.Visibility = Visibility.Hidden;
                //else if (gameState.gameOptions.ArcadeModeFlag) HelpArcadeMenu.Visibility = Visibility.Hidden;
                else if (gameState.gameOptions.PentominoModeFlag && gameState.gameOptions.IsMode == 3) HelpSprintPentominoMenuEnglish.Visibility = Visibility.Hidden;
                else if (gameState.gameOptions.TetrominoModeFlag && gameState.gameOptions.IsMode == 3) HelpSprintTetrominoMenuEnglish.Visibility = Visibility.Hidden;
                else if (gameState.gameOptions.TriminoModeFlag && gameState.gameOptions.IsMode == 3) HelpSprintTriminoMenuEnglish.Visibility = Visibility.Hidden;
                else if (gameState.gameOptions.TetrominoModeFlag && gameState.gameOptions.IsMode == 4) HelpSprintLinesMenuEnglish.Visibility = Visibility.Hidden;
                else if (gameState.gameOptions.TetrominoModeFlag && gameState.gameOptions.IsMode == 5) HelpSprintPointsMenuEnglish.Visibility = Visibility.Hidden;
                else if (gameState.gameOptions.TampingModeFlag) HelpTampingMenuEnglish.Visibility = Visibility.Hidden;
                else if (gameState.gameOptions.MosaicModeFlag) HelpMosaicMenuEnglish.Visibility = Visibility.Hidden;
                else if (gameState.gameOptions.MeditationModeFlag) HelpMeditationMenuEnglish.Visibility = Visibility.Hidden;
            }
            CloseHelpButton.Visibility = Visibility.Hidden;
            stopwatch.Start();
            //ResumeMusic();
            CheckGameLoop();
        }

        // Поставить игру на Паузу
        private void PauseButton_Click(object sender, RoutedEventArgs e)
        {
            Pause = true;
            if (gameState.gameOptions.MeditationModeFlag) MeditationPauseMenu.Visibility = Visibility.Visible;
            else PauseMenu.Visibility = Visibility.Visible;
            stopwatch.Stop();
        }

        // Выйти из Паузы в игру
        private async void PlayButton_Click(object sender, RoutedEventArgs e)
        {
            if (gameState.gameOptions.MeditationModeFlag) MeditationPauseMenu.Visibility = Visibility.Hidden;
            else PauseMenu.Visibility = Visibility.Hidden;
            Pause = false;
            stopwatch.Start();
            CheckGameLoop();
        }

        // Кнопка "Сброса скорости" в режиме Выживание
        private void SurvivalButton_Click(object sender, RoutedEventArgs e)
        {
            if (gameState.Tetris >= 1) gameState.gameOptions.SurvivalFlag = true;
        }

        // Кнопка "Получить палку" в режиме Аркада
        private void GetStickButton_Click(object sender, RoutedEventArgs e)
        {
            // Аркада
            /*if (gameState.ArcadeClearedLines >= 1)
            {
                gameState.gameOptions.ArcadeGetSticklFlag = true;
                gameState.ArcadeClearedLines -= 1;
            }*/

            // Доп бустер в Основную игру
            if (settings.QuantityGetStick > 0 && gameState.BlockQueue.NextBlock.ID != 1)
            {
                gameState.gameOptions.GetSticklFlag = true;
                gameState.BlockQueue.GetAndUpdate();
                settings.QuantityGetStick--;
            }
        }

        // Кнопка "Закрыть дырки" в режиме Аркада
        private void CloseHolesButton_Click(object sender, RoutedEventArgs e)
        {
            // Аркада
            /*if (gameState.ArcadeClearedLines >= 3)
            {
                int cell = gameState.CloseHoles(gameState.GameGrid);
                if (cell != 0) gameState.ArcadeClearedLines -= 3;  // Если нит дырок для закрытия, то поинты не убавляются
            }
            gameState.GameGrid.ClearFullRows();  // Сразу сжигает линии после закрытия дырок, не дожидаясь размещения блока*/

            // Доп бустер в Основную игру
            if (settings.QuantityCloseHoles > 0)
            {
                int cell = gameState.CloseHoles(gameState.GameGrid);
                if (cell != 0) settings.QuantityCloseHoles--;  // Если нит дырок для закрытия, то количество бустеров не убавляется
            }

            gameState.GameGrid.ClearFullRows();  // Сразу сжигает линии после закрытия дырок, не дожидаясь размещения блока
        }

        // Кнопка "Сдвиг вниз" в режиме Аркада
        private void DownwardShiftButton_Click(object sender, RoutedEventArgs e)
        {
            // Аркада
            /*if (gameState.ArcadeClearedLines >= 5)
            {
                bool shift = gameState.DownwardShif(gameState.GameGrid);
                if (shift) gameState.ArcadeClearedLines -= 5;  // Если нит сдвига вниз, то поинты не убавляются
            }
            gameState.GameGrid.ClearFullRows();  // Сразу сжигает линии сдвига всех блоков, не дожидаясь размещения блока*/

            // Доп бустер в Основную игру
            if (settings.QuantityDownwardShift > 0)
            {
                bool shift = gameState.DownwardShif(gameState.GameGrid);
                if (shift) settings.QuantityDownwardShift--;  // Если нит сдвига вниз, то количество бустеров не убавляется
            }

            gameState.GameGrid.ClearFullRows();  // Сразу сжигает линии сдвига всех блоков, не дожидаясь размещения блока
        }

        // Кнопка "Опустошить стакан" в режиме Аркада
        private void EmptyGlass_Click(object sender, RoutedEventArgs e)
        {
            // Аркада
            /*if (gameState.ArcadeClearedLines >= 7)
            {
                gameState.EmptyGlass(gameState.GameGrid);
                gameState.ArcadeClearedLines -= 7;
            }
            else if (gameState.gameOptions.MeditationModeFlag) gameState.EmptyGlass(gameState.GameGrid);*/

            // Доп бустер в Основную игру
            if (settings.QuantityEmptyGlass > 0 && !gameState.GameGrid.IsRowEmpty(21))
            {
                gameState.EmptyGlass(gameState.GameGrid);
                settings.QuantityEmptyGlass--;
            }
            else if (gameState.gameOptions.MeditationModeFlag) gameState.EmptyGlass(gameState.GameGrid);
        }

        // СПОРНАЯ МЕХАНИКА - БОЛЬШЕ ВРЕДА ОСТАВЛЯЕТ
        // Кнопка "Сжечь цвет" в режиме Аркада
        private void Electro_Click(object sender, RoutedEventArgs e)
        {
            if (gameState.ArcadeClearedLines >= 1) gameState.Electro(gameState.GameGrid);
        }

        // Старт режима Пентомино Классика
        private async void PentominoClassicMode_Click(object sender, RoutedEventArgs e)
        {
            CloseMenu();
            OpenGameInterface();
            if (MusicFlag) PlayBackgroundMusic("BackgroundMusic.mp3");
            PentominoMenu.Visibility = Visibility.Hidden;
            GameCanvasBig.Visibility = Visibility.Visible;
            gameState = new GameState(this);
            gameState.gameOptions.PentominoModeFlag = true;
            gameState.gameOptions.IsMode = 1;
            gameState.gameOptions.TypeBlocks = 3;
            gameState.gameOptions.TypeSizeGrid = 1;
            gameState.Crutch(gameState.GameGrid);
            Draw(gameState);                        // Сразу отрисовываем начальное положение, чтобы не было задержки после перезапуска 
            CheckGameLoop();
        }

        // Старт режима Пентомино с Бустерами
        private async void PentominoWithBoostersMode_Click(object sender, RoutedEventArgs e)
        {
            CloseMenu();
            OpenGameInterface();
            if (MusicFlag) PlayBackgroundMusic("BackgroundMusic.mp3");
            PentominoMenu.Visibility = Visibility.Hidden;
            GameCanvasBig.Visibility = Visibility.Visible;
            BoostersPocket.Visibility = Visibility.Visible;
            gameState = new GameState(this);
            gameState.gameOptions.PentominoModeFlag = true;
            gameState.gameOptions.IsMode = 2;
            gameState.gameOptions.TypeBlocks = 3;
            gameState.gameOptions.TypeSizeGrid = 1;
            gameState.Crutch(gameState.GameGrid);
            Draw(gameState);
            CheckGameLoop();
        }

        // Старт режима Тетромино Классика
        private async void TetraminoClassicMode_Click(object sender, RoutedEventArgs e)
        {
            CloseMenu();
            OpenGameInterface();
            if (MusicFlag) PlayBackgroundMusic("BackgroundMusic.mp3");
            TetraminoMenu.Visibility = Visibility.Hidden;
            GameCanvas.Visibility = Visibility.Visible;
            gameState = new GameState(this);
            gameState.gameOptions.TetrominoModeFlag = true;
            gameState.gameOptions.IsMode = 1;
            gameState.gameOptions.TypeBlocks = 1;
            gameState.gameOptions.TypeSizeGrid = 0;
            gameState.Crutch(gameState.GameGrid);
            Draw(gameState);
            CheckGameLoop();
        }

        // Старт режима Тетромино с Бустерами
        private async void TetraminoWithBoostersMode_Click(object sender, RoutedEventArgs e)
        {
            CloseMenu();
            OpenGameInterface();
            if (MusicFlag) PlayBackgroundMusic("BackgroundMusic.mp3");
            TetraminoMenu.Visibility = Visibility.Hidden;
            GameCanvas.Visibility = Visibility.Visible;
            BoostersPocket.Visibility = Visibility.Visible;
            gameState = new GameState(this);
            gameState.gameOptions.TetrominoModeFlag = true;
            gameState.gameOptions.IsMode = 2;
            gameState.gameOptions.TypeBlocks = 1;
            gameState.gameOptions.TypeSizeGrid = 0;
            gameState.Crutch(gameState.GameGrid);
            Draw(gameState);
            CheckGameLoop();
        }

        // Старт режима Тримино Классика
        private async void TriminoClassicMode_Click(object sender, RoutedEventArgs e)
        {
            CloseMenu();
            OpenGameInterface();
            if (MusicFlag) PlayBackgroundMusic("BackgroundMusic.mp3");
            TriminoMenu.Visibility = Visibility.Hidden;
            GameCanvasSmall.Visibility = Visibility.Visible;
            gameState = new GameState(this);
            gameState.gameOptions.TriminoModeFlag = true;
            gameState.gameOptions.IsMode = 1;
            gameState.gameOptions.TypeBlocks = 2;
            gameState.gameOptions.TypeSizeGrid = 0;
            gameState.Crutch(gameState.GameGrid);
            Draw(gameState);
            CheckGameLoop();
        }

        // Старт режима Тримино с Бустерами
        private async void TriminoWithBoostersMode_Click(object sender, RoutedEventArgs e)
        {
            CloseMenu();
            OpenGameInterface();
            if (MusicFlag) PlayBackgroundMusic("BackgroundMusic.mp3");
            TriminoMenu.Visibility = Visibility.Hidden;
            GameCanvasSmall.Visibility = Visibility.Visible;
            BoostersPocket.Visibility = Visibility.Visible;
            gameState = new GameState(this);
            gameState.gameOptions.TriminoModeFlag = true;
            gameState.gameOptions.IsMode = 2;
            gameState.gameOptions.TypeBlocks = 2;
            gameState.gameOptions.TypeSizeGrid = 0;
            gameState.Crutch(gameState.GameGrid);
            Draw(gameState);
            CheckGameLoop();
        }

        // Старт режима ОнлиТетрис
        private async void OnlyTetrisMode_Click(object sender, RoutedEventArgs e)
        {
            CloseMenu();
            OpenGameInterface();
            if (MusicFlag) PlayBackgroundMusic("BackgroundMusic.mp3");
            GameCanvas.Visibility = Visibility.Visible;
            ScoreMultiplierPocket.Visibility = Visibility.Hidden;
            ClearedLinePocket.Visibility = Visibility.Hidden;
            FinalLinesText.Visibility = Visibility.Hidden;
            gameState = new GameState(this);
            gameState.gameOptions.TypeBlocks = 1;
            gameState.gameOptions.TypeSizeGrid = 0;
            gameState.gameOptions.OnlyTetrisModeFlag = true;
            gameState.GameGridReset();
            Draw(gameState);
            CheckGameLoop();
        }

        // Старт режима Выживание
        private async void SurvivalMode_Click(object sender, RoutedEventArgs e)
        {
            CloseMenu();
            OpenGameInterface();
            if (MusicFlag) PlayBackgroundMusic("BackgroundMusic.mp3");
            GameCanvas.Visibility = Visibility.Visible;
            ScoreMultiplierPocket.Visibility = Visibility.Hidden;
            gameState = new GameState(this);
            gameState.gameOptions.TypeBlocks = 1;
            gameState.gameOptions.TypeSizeGrid = 0;
            gameState.gameOptions.SurvivalModeFlag = true;
            delayDicreaseSurvival = 40;
            gameState.GameGridReset();
            Draw(gameState);
            CheckGameLoop();
        }

        // Старт режима Аркада
        /*private async void ArcadeMode_Click(object sender, RoutedEventArgs e)
        {
            CloseMenu();
            OpenGameInterface();
            if (MusicFlag) PlayBackgroundMusic("BackgroundMusic.mp3");
            HoldPocket.Visibility = Visibility.Hidden;
            GameCanvas.Visibility = Visibility.Visible;
            LevelPocket.Visibility = Visibility.Hidden;
            gameState = new GameState(this);
            gameState.gameOptions.TypeBlocks = 1;
            gameState.gameOptions.TypeSizeGrid = 0;
            gameState.gameOptions.ArcadeModeFlag = true;
            gameState.GameGridReset();
            CheckGameLoop();
        }*/

        // Старт режима Спринт Пентомино
        private async void SprintPentominoMode_Click(object sender, RoutedEventArgs e)
        {
            CloseMenu();
            OpenGameInterface();
            if (MusicFlag) PlayBackgroundMusic("BackgroundMusic.mp3");
            SprintMenu.Visibility = Visibility.Hidden;
            GameCanvasBig.Visibility = Visibility.Visible;
            SprintPentominoMaxLine.Visibility = Visibility.Visible;
            StopwatchText.Visibility = Visibility.Visible;
            HoldPocket.Visibility = Visibility.Hidden;
            ScoreMultiplierPocket.Visibility = Visibility.Hidden;
            ClearedLinePocket.Visibility = Visibility.Hidden;
            FinalLinesText.Visibility = Visibility.Hidden;
            ScoreText.Visibility = Visibility.Hidden;
            gameState = new GameState(this);
            gameState.gameOptions.PentominoModeFlag = true;
            gameState.gameOptions.IsMode = 3;
            gameState.gameOptions.TypeBlocks = 3;
            gameState.gameOptions.TypeSizeGrid = 1;
            gameState.Crutch(gameState.GameGrid);
            Draw(gameState);
            stopwatch.Start();
            timer.Start();
            CheckGameLoop();
        }

        // Старт режима Спринт Тетрамино
        private async void SprintTetrominoMode_Click(object sender, RoutedEventArgs e)
        {
            CloseMenu();
            OpenGameInterface();
            if (MusicFlag) PlayBackgroundMusic("BackgroundMusic.mp3");
            SprintMenu.Visibility = Visibility.Hidden;
            GameCanvas.Visibility = Visibility.Visible;
            SprintTetrominoMaxLine.Visibility = Visibility.Visible;
            StopwatchText.Visibility = Visibility.Visible;
            HoldPocket.Visibility = Visibility.Hidden;
            ScoreMultiplierPocket.Visibility = Visibility.Hidden;
            ClearedLinePocket.Visibility = Visibility.Hidden;
            FinalLinesText.Visibility = Visibility.Hidden;
            ScoreText.Visibility = Visibility.Hidden;
            gameState = new GameState(this);
            gameState.gameOptions.TetrominoModeFlag = true;
            gameState.gameOptions.IsMode = 3;
            gameState.gameOptions.TypeBlocks = 1;
            gameState.gameOptions.TypeSizeGrid = 0;
            gameState.Crutch(gameState.GameGrid);
            Draw(gameState);
            stopwatch.Start();
            timer.Start();
            CheckGameLoop();
        }

        // Старт режима Спринт Тримино
        private async void SprintTriminoMode_Click(object sender, RoutedEventArgs e)
        {
            CloseMenu();
            OpenGameInterface();
            if (MusicFlag) PlayBackgroundMusic("BackgroundMusic.mp3");
            SprintMenu.Visibility = Visibility.Hidden;
            GameCanvasSmall.Visibility = Visibility.Visible;
            SprintTriminoMaxLine.Visibility = Visibility.Visible;
            StopwatchText.Visibility = Visibility.Visible;
            HoldPocket.Visibility = Visibility.Hidden;
            ScoreMultiplierPocket.Visibility = Visibility.Hidden;
            ClearedLinePocket.Visibility = Visibility.Hidden;
            FinalLinesText.Visibility = Visibility.Hidden;
            ScoreText.Visibility = Visibility.Hidden;
            gameState = new GameState(this);
            gameState.gameOptions.TriminoModeFlag = true;
            gameState.gameOptions.IsMode = 3;
            gameState.gameOptions.TypeBlocks = 2;
            gameState.gameOptions.TypeSizeGrid = 0;
            gameState.Crutch(gameState.GameGrid);
            Draw(gameState);
            stopwatch.Start();
            timer.Start();
            CheckGameLoop();
        }
        
        // Старт режима Спринт Линии
        private async void SprintLinesMode_Click(object sender, RoutedEventArgs e)
        {
            CloseMenu();
            OpenGameInterface();
            if (MusicFlag) PlayBackgroundMusic("BackgroundMusic.mp3");
            SprintMenu.Visibility = Visibility.Hidden;
            GameCanvas.Visibility = Visibility.Visible;
            StopwatchText.Visibility = Visibility.Visible;
            HoldPocket.Visibility = Visibility.Hidden;
            ScoreMultiplierPocket.Visibility = Visibility.Hidden;
            FinalLinesText.Visibility = Visibility.Hidden;
            ScoreText.Visibility = Visibility.Hidden;
            gameState = new GameState(this);
            gameState.gameOptions.TetrominoModeFlag = true;
            gameState.gameOptions.IsMode = 4;
            gameState.gameOptions.TypeBlocks = 1;
            gameState.gameOptions.TypeSizeGrid = 0;
            SprintLinesDelay = 7;
            gameState.Crutch(gameState.GameGrid);
            Draw(gameState);
            stopwatch.Start();
            timer.Start();
            CheckGameLoop();
        }

        // Старт режима Спринт Очки
        private async void SprintPointsMode_Click(object sender, RoutedEventArgs e)
        {
            CloseMenu();
            OpenGameInterface();
            if (MusicFlag) PlayBackgroundMusic("BackgroundMusic.mp3");
            SprintMenu.Visibility = Visibility.Hidden;
            GameCanvas.Visibility = Visibility.Visible;
            StopwatchText.Visibility = Visibility.Visible;
            HoldPocket.Visibility = Visibility.Hidden;
            FinalLinesText.Visibility = Visibility.Hidden;
            ScoreText.Visibility = Visibility.Hidden;
            gameState = new GameState(this);
            gameState.gameOptions.TetrominoModeFlag = true;
            gameState.gameOptions.IsMode = 5;
            gameState.gameOptions.TypeBlocks = 1;
            gameState.gameOptions.TypeSizeGrid = 0;
            gameState.Crutch(gameState.GameGrid);
            Draw(gameState);
            stopwatch.Start();
            timer.Start();
            CheckGameLoop();
        }

        // Старт режима Утрамбовка
        private async void TampingMode_Click(object sender, RoutedEventArgs e)
        {
            CloseMenu();
            OpenGameInterface();
            if (MusicFlag) PlayBackgroundMusic("BackgroundMusic.mp3");
            HoldPocket.Visibility = Visibility.Hidden;
            GameCanvas.Visibility = Visibility.Visible;
            ScoreMultiplierPocket.Visibility = Visibility.Hidden;
            ClearedLinePocket.Visibility = Visibility.Hidden;
            FinalLinesText.Visibility = Visibility.Hidden;
            TampingMaxLine.Visibility = Visibility.Visible;
            gameState = new GameState(this);
            gameState.gameOptions.TypeBlocks = 1;
            gameState.gameOptions.TypeSizeGrid = 0;
            gameState.gameOptions.TampingModeFlag = true;
            gameState.GameGridReset();
            gameState.SetGrayCell(gameState.GameGrid);
            Draw(gameState);
            CheckGameLoop();
        }

        // Старт режима Мозаика
        private async void MosaicMode_Click(object sender, RoutedEventArgs e)
        {
            CloseMenu();
            OpenGameInterface();
            if (MusicFlag) PlayBackgroundMusic("BackgroundMusic.mp3");
            HoldPocket.Visibility = Visibility.Hidden;
            GameCanvas.Visibility = Visibility.Visible;
            ScoreMultiplierPocket.Visibility = Visibility.Hidden;
            ClearedLinePocket.Visibility = Visibility.Hidden;
            FinalLinesText.Visibility = Visibility.Hidden;
            ScoreText.Visibility = Visibility.Hidden;
            mosaicTiles = SplitRandomImageIntoTiles();              // Индекс и разделение изображения на части нужно устанавливать ДО генерации поля,
                                                                    // иначе не сгенерируются рандомные повороты при установке первого блока
            gameState = new GameState(this);
            gameState.gameOptions.TypeBlocks = 4;
            gameState.gameOptions.TypeSizeGrid = 0;
            var random = new Random();

            do
            {
                gameState.gameOptions.GenerateMosaicType = random.Next(1, 13);      // Случайно выбирает порядок генерации блоков
            }
            while (CheckMosaicType());
            NewMosaicType();

            //gameState.gameOptions.GenerateMosaicType = 12;       // ДЛЯ ТЕСТОВ
            gameState.gameOptions.MosaicModeFlag = true;
            gameState.Crutch(gameState.GameGrid);
            Draw(gameState);
            CheckGameLoop();
        }

        // Старт режима Медитация
        private async void MeditationMode_Click(object sender, RoutedEventArgs e)
        {
            // Останавливаем текущую музыку
            if (currentMusic != null) currentMusic.Stop();

            // Запускаем новую музыку для медитации
            if (MusicFlag) PlayBackgroundMusic("MeditationBackgroundMusic.mp3");
            //SetMeditationBackground();

            CloseMenu();
            PauseButton.Visibility = Visibility.Visible;
            GameCanvas.Visibility = Visibility.Visible;
            //DelayText.Visibility = Visibility.Visible;  // ДЛЯ ТЕСТОВ
            gameState = new GameState(this);
            gameState.gameOptions.TypeBlocks = 1;
            gameState.gameOptions.TypeSizeGrid = 0;
            gameState.gameOptions.MeditationModeFlag = true;
            gameState.GameGridReset();
            Draw(gameState);
            CheckGameLoop();
        }

        // Отображает элементы Главного меню
        private void OpenMenu()
        {
            PentominoOptionButton.Visibility = Visibility.Visible;
            TetraminoOptionButton.Visibility = Visibility.Visible;
            TriminoOptionButton.Visibility = Visibility.Visible;
            OnlyTetrisModeButton.Visibility = Visibility.Visible;
            SurvivalModeButton.Visibility = Visibility.Visible;
            //ArcadeModeButton.Visibility = Visibility.Visible;
            SprintOptionButton.Visibility = Visibility.Visible;
            TampingModeButton.Visibility = Visibility.Visible;
            MosaicModeButton.Visibility = Visibility.Visible;
            MeditationModeButton.Visibility = Visibility.Visible;
            OptionsButton.Visibility = Visibility.Visible;
            ExitButton.Visibility = Visibility.Visible;
        }

        // Скрывает элементы Главного меню
        private void CloseMenu()
        {
            PentominoOptionButton.Visibility = Visibility.Hidden;
            TetraminoOptionButton.Visibility = Visibility.Hidden;
            TriminoOptionButton.Visibility = Visibility.Hidden;
            OnlyTetrisModeButton.Visibility = Visibility.Hidden;
            SurvivalModeButton.Visibility = Visibility.Hidden;
            //ArcadeModeButton.Visibility = Visibility.Hidden;
            SprintOptionButton.Visibility = Visibility.Hidden;
            TampingModeButton.Visibility = Visibility.Hidden;
            MosaicModeButton.Visibility = Visibility.Hidden;
            MeditationModeButton.Visibility = Visibility.Hidden;
            OptionsButton.Visibility = Visibility.Hidden;
            ExitButton.Visibility = Visibility.Hidden;
            MainMenuFlag = false;
        }

        // Отображает интерфейс Игры
        private void OpenGameInterface()
        {
            ScoreText.Visibility = Visibility.Visible;
            if (settings.HoldBlockFlag) HoldPocket.Visibility = Visibility.Visible;
            NextPocket.Visibility = Visibility.Visible;
            ScoreMultiplierPocket.Visibility = Visibility.Visible;
            ClearedLinePocket.Visibility = Visibility.Visible;
            PauseButton.Visibility = Visibility.Visible;
            //DelayText.Visibility = Visibility.Visible;    // ДЛЯ ТЕСТОВ
        }

        // Скрывает интерфейс Игры
        private void CloseGameInterface()
        {
            ScoreText.Visibility = Visibility.Hidden;
            if (settings.HoldBlockFlag) HoldPocket.Visibility = Visibility.Hidden;
            NextPocket.Visibility = Visibility.Hidden;
            ScoreMultiplierPocket.Visibility = Visibility.Hidden;
            ClearedLinePocket.Visibility = Visibility.Hidden;
            TampingMaxLine.Visibility = Visibility.Hidden;
            SprintPentominoMaxLine.Visibility = Visibility.Hidden;
            SprintTetrominoMaxLine.Visibility = Visibility.Hidden;
            SprintTriminoMaxLine.Visibility = Visibility.Hidden;
            PauseButton.Visibility = Visibility.Hidden;
            //DelayText.Visibility = Visibility.Hidden;      // ДЛЯ ТЕСТОВ
        }

        // Открывает Главного меню
        private void MainMenu_Click(object sender, RoutedEventArgs e)
        {
            //if (gameState.gameOptions.MeditationModeFlag) SetDefaultBackground();   // Устаналивает фоновое видео Главного меню
            if (currentMusic != null) currentMusic.Stop();                          // Заканчивает текующую музыку
            if (MusicFlag) PlayBackgroundMusic("MainMenuBackgroundMusic.mp3");      // Устанавливают фоновую музыку Главного меню
            if (gameState.gameOptions.MosaicModeFlag) MosaicImageOff();

            CloseGameInterface();
            OpenMenu();
            MainMenuFlag = true;
            OptionMenuFlag = false;
            OptionsMenu.Visibility = Visibility.Hidden;
            OptionText.Visibility = Visibility.Hidden;
            OptionTextEnglish.Visibility = Visibility.Hidden;
            GameCanvas.Visibility = Visibility.Hidden;
            GameCanvasBig.Visibility = Visibility.Hidden;
            GameCanvasSmall.Visibility = Visibility.Hidden;
            GameOverMenu.Visibility = Visibility.Hidden;
            MosaicGameOverMenu.Visibility = Visibility.Hidden;
            MeditationGameOverMenu.Visibility = Visibility.Hidden;
            StopwatchText.Visibility = Visibility.Hidden;
            WinResult.Visibility = Visibility.Hidden;
            LoseResult.Visibility = Visibility.Hidden;
            PrizeText.Visibility = Visibility.Hidden;
            MaxPrizeText.Visibility = Visibility.Hidden;
            MosaicPrizeText.Visibility = Visibility.Hidden;
            MosaicMaxPrizeText.Visibility = Visibility.Hidden;
            BoostersPocket.Visibility = Visibility.Hidden;
            PauseMenu.Visibility = Visibility.Hidden;
            MeditationPauseMenu.Visibility = Visibility.Hidden;
            PentominoMenu.Visibility = Visibility.Hidden;
            TetraminoMenu.Visibility = Visibility.Hidden;
            TriminoMenu.Visibility = Visibility.Hidden;
            Pause = false;
            gameState.gameOptions.TriminoModeFlag = false;
            gameState.gameOptions.TetrominoModeFlag = false;
            gameState.gameOptions.PentominoModeFlag = false;
            gameState.gameOptions.SurvivalModeFlag = false;
            //gameState.gameOptions.ArcadeModeFlag = false;
            gameState.gameOptions.TampingModeFlag = false;
            gameState.gameOptions.MosaicModeFlag = false;
            gameState.gameOptions.MeditationModeFlag = false;
            gameState.gameOptions.IsMode = 0;
            gameState.sprintWin = false;
            delayDicreaseSurvival = 0;
            SprintLinesDelay = 0;
            prize1 = false;
            prize2 = false;
            prize3 = false;
            prize4 = false;
            stopwatch.Reset();
            timer.Stop();
        }

        // Открывает Выбор режима Пентамино в Главном меню
        private void PentominoOption_Click(object sender, RoutedEventArgs e)
        {
            CloseMenu();
            MainMenuFlag = true;
            PentominoMenu.Visibility = Visibility.Visible;
        }

        // Закрывает Выбор режима Пентамино в Главном меню
        private void PentominoBackButton_Click(object sender, RoutedEventArgs e)
        {
            OpenMenu();
            PentominoMenu.Visibility = Visibility.Hidden;
        }

        // Открывает Выбор режима Тетрамино в Главном меню
        private void TetraminoOption_Click(object sender, RoutedEventArgs e)
        {
            CloseMenu();
            MainMenuFlag = true;
            TetraminoMenu.Visibility = Visibility.Visible;
        }

        // Закрывает Выбор режима Тетрамино в Главном меню
        private void TetraminoBackButton_Click(object sender, RoutedEventArgs e)
        {
            OpenMenu();
            TetraminoMenu.Visibility = Visibility.Hidden;
        }

        // Открывает Выбор режима Тримино в Главном меню
        private void TriminoOption_Click(object sender, RoutedEventArgs e)
        {
            CloseMenu();
            MainMenuFlag = true;
            TriminoMenu.Visibility = Visibility.Visible;
        }

        // Закрывает Выбор режима Тримино в Главном меню
        private void TriminoBackButton_Click(object sender, RoutedEventArgs e)
        {
            OpenMenu();
            TriminoMenu.Visibility = Visibility.Hidden;
        }

        // Открывает Выбор режима Спринт в Главном меню
        private void SprintOption_Click(object sender, RoutedEventArgs e)
        {
            CloseMenu();
            MainMenuFlag = true;
            SprintMenu.Visibility = Visibility.Visible;
        }

        // Закрывает Выбор режима Спринт в Главном меню
        private void SprintBackButton_Click(object sender, RoutedEventArgs e)
        {
            OpenMenu();
            SprintMenu.Visibility = Visibility.Hidden;
        }

        // Открывает Настройки в Главном меню
        private void Options_Click(object sender, RoutedEventArgs e)
        {
            CloseMenu();
            MainMenuFlag = true;
            OptionMenuFlag = true;
            OptionsMenu.Visibility = Visibility.Visible;
            if (settings.Language == 1) OptionText.Visibility = Visibility.Visible;
            else if (settings.Language == 2) OptionTextEnglish.Visibility = Visibility.Visible;
        }

        // Переключает состояние "Призрака": ВКЛ/ВЫКЛ
        private void GhostOptionButton_Click(object sender, RoutedEventArgs e)
        {
            if (settings.GhostBlockFlag)                    // ВЫКЛ
            {
                settings.GhostBlockFlag = false;
                Settings.Save(settings);
                GhostOptionButton.Opacity = 0.6;
            }
            else if (!settings.GhostBlockFlag)              // ВКЛ
            {
                settings.GhostBlockFlag = true;
                Settings.Save(settings);
                GhostOptionButton.Opacity = 1;
            }
        }

        // Переключает состояние "Удержания блока": ВКЛ/ВЫКЛ
        private void HoldOptionButton_Click(object sender, RoutedEventArgs e)
        {
            if (settings.HoldBlockFlag)                     // ВЫКЛ
            {
                settings.HoldBlockFlag = false;
                Settings.Save(settings);
                HoldOptionButton.Opacity = 0.6;
            }
            else if (!settings.HoldBlockFlag)               // ВКЛ
            {
                settings.HoldBlockFlag = true;
                Settings.Save(settings);
                HoldOptionButton.Opacity = 1;
            }
        }

        // Переключает состояние Музыки: ВКЛ/ВЫКЛ
        private void MusicOptionButton_Click(object sender, RoutedEventArgs e)
        {
            if (MusicFlag)      // ВЫКЛ
            {
                MusicFlag = false;
                MusicOptionButton.Opacity = 0.6;
                MusicPauseMenuText.Opacity = 0.6;
                MusicMeditationPauseMenuText.Opacity = 0.6;
                currentMusic.Pause();
            }
            else                // ВКЛ
            {
                MusicFlag = true;
                MusicOptionButton.Opacity = 1;
                MusicPauseMenuText.Opacity = 1;
                MusicMeditationPauseMenuText.Opacity = 1;

                // Запускает необходимую фоновую музыку в зависимости от режима игры
                if (MainMenuFlag)
                {
                    if (currentTypeSong == "MainMenuBackgroundMusic.mp3") currentMusic.Play();
                    else PlayBackgroundMusic("MainMenuBackgroundMusic.mp3");
                }
                else if (gameState.gameOptions.MeditationModeFlag)
                {
                    if (currentTypeSong == "MeditationBackgroundMusic.mp3") currentMusic.Play();
                    else PlayBackgroundMusic("MeditationBackgroundMusic.mp3");
                }
                else
                {
                    if (currentTypeSong == "BackgroundMusic.mp3") currentMusic.Play();
                    else PlayBackgroundMusic("BackgroundMusic.mp3");
                }
            }
        }

        private void LanguageOptionButton_Click(object sender, RoutedEventArgs e)
        {
            settings.Language++;
            if (settings.Language > maxNumberLanguages) settings.Language = 1;

            Settings.Save(settings);

            ApplyLanguage();
        }

        private void ApplyLanguage()
        {
            // Русский - Russia
            if (settings.Language == 1)
            {
                GhostOptionButton.Content = "Призрак";
                HoldOptionButton.Content = "Удержание";
                MusicOptionButton.Content = "Музыка";
                LanguageOptionButton.Content = "Русский";
                BackButton.Content = "Назад";
                PentominoOptionButton.Content = "Пентомино";
                TetraminoOptionButton.Content = "Тетромино";
                TriminoOptionButton.Content = "Тримино";
                SprintOptionButton.Content = "Спринт";
                OnlyTetrisModeButton.Content = "ОнлиТетрис";
                SurvivalModeButton.Content = "Выживание";
                //ArcadeModeButton.Content = "Аркада";
                TampingModeButton.Content = "Утрамбовка";
                MosaicModeButton.Content = "Мозаика";
                MeditationModeButton.Content = "Медитация";
                OptionsButton.Content = "Опции";
                ExitButton.Content = "Выход";
                PentominoClassicModeButton.Content = "Классика";
                PentominoWithBoostersModeButton.Content = "С бустерами";
                PentominoBackButton.Content = "Назад";
                TetraminoClassicModeButton.Content = "Классика";
                TetraminoWithBoostersModeButton.Content = "С бустерами";
                TetraminoBackButton.Content = "Назад";
                TriminoClassicModeButton.Content = "Классика";
                TriminoWithBoostersModeButton.Content = "С бустерами";
                TriminoBackButton.Content = "Назад";
                SprintPentominoModeButton.Content = "Пентомино";
                SprintTetrominoModeButton.Content = "Тетромино";
                SprintTriminoModeButton.Content = "Тримино";
                SprintLinesModeButton.Content = "Линии";
                SprintPointsModeButton.Content = "Очки";
                SprintBackButton.Content = "Назад";
                HelpeButtonText.Content = "Справка";
                CloseHelpButton.Content = "Закрыть";
                PauseButtonText.Content = "Пауза";
                NextPauseMenuText.Content = "Продолжить";
                RestartPauseMenuText.Content = "Заново";
                MusicPauseMenuText.Content = "Музыка";
                ExitMenuMenuText.Content = "Меню";
                NextMeditationPauseMenuText.Content = "Еще чуть-чуть";
                RestartMeditationPauseMenuText.Content = "Еще разок";
                MusicMeditationPauseMenuText.Content = "Музыка";
                ExitMenuMeditationPauseMenuText.Content = "Пока-пока";
                PlayAgainEndGame.Content = "Заново";
                ExitMenuEndGame.Content = "Меню";
                MosaicPlayAgainEndGame.Content = "Заново";
                MosaicExitMenuEndGame.Content = "Меню";
                MeditationPlayAgainEndGame.Content = "Отдохни еще немного";
                MeditationExitMenuEndGame.Content = "Как-нибудь позже";
                HoldPocketText.Text = "На удержании";
                NextPocketText.Text = "Следующий";
                EndGame.Text = "Окончено";
                PrizeText.Text = "Твой бустер: ";
                MaxPrizeText.Text = "Ты собрал максимальное количество бустеров";
                BestScoreText.Text = "Рекорд: ";
                FinalScoreText.Text = "Очки: ";
                FinalStopwatchText.Text = "Время: ";
                FinalLinesText.Text = "Линий: ";
                WinResult.Text = "Картина Собрана!";
                LoseResult.Text = "Не удалось";
                MosaicPrizeText.Text = "Твой бустер: ";
                MosaicMaxPrizeText.Text = "Ты собрал максимальное количество бустеров";
                RelaxMeditationPlayAgainEndGame.Text = "Расслабься";
                if (OptionMenuFlag)
                {
                    OptionText.Visibility = Visibility.Visible;
                    OptionTextEnglish.Visibility = Visibility.Hidden;
                }
            }
            // Английский - English
            else if (settings.Language == 2)
            {
                GhostOptionButton.Content = "Ghost";
                HoldOptionButton.Content = "Hold";
                MusicOptionButton.Content = "Music";
                LanguageOptionButton.Content = "English";
                BackButton.Content = "Back";
                PentominoOptionButton.Content = "Pentomino";
                TetraminoOptionButton.Content = "Tetromino";
                TriminoOptionButton.Content = "Trimino";
                SprintOptionButton.Content = "Sprint";
                OnlyTetrisModeButton.Content = "OnlyTetris";
                SurvivalModeButton.Content = "Survival";
                //ArcadeModeButton.Content = "Arcade";
                TampingModeButton.Content = "Tamping";
                MosaicModeButton.Content = "Mosaic";
                MeditationModeButton.Content = "Meditation";
                OptionsButton.Content = "Options";
                ExitButton.Content = "Exit";
                PentominoClassicModeButton.Content = "Classic";
                PentominoWithBoostersModeButton.Content = "With boosters";
                PentominoBackButton.Content = "Back";
                TetraminoClassicModeButton.Content = "Classic";
                TetraminoWithBoostersModeButton.Content = "With boosters";
                TetraminoBackButton.Content = "Back";
                TriminoClassicModeButton.Content = "Classic";
                TriminoWithBoostersModeButton.Content = "With boosters";
                TriminoBackButton.Content = "Back";
                SprintPentominoModeButton.Content = "Pentomino";
                SprintTetrominoModeButton.Content = "Tetromino";
                SprintTriminoModeButton.Content = "Trimino";
                SprintLinesModeButton.Content = "Lines";
                SprintPointsModeButton.Content = "Points";
                SprintBackButton.Content = "Back";
                HelpeButtonText.Content = "Help";
                CloseHelpButton.Content = "Close";
                PauseButtonText.Content = "Pause";
                NextPauseMenuText.Content = "Continue";
                RestartPauseMenuText.Content = "Restart";
                MusicPauseMenuText.Content = "Music";
                ExitMenuMenuText.Content = "Menu";
                NextMeditationPauseMenuText.Content = "A Little More";
                RestartMeditationPauseMenuText.Content = "One More Time";
                MusicMeditationPauseMenuText.Content = "Music";
                ExitMenuMeditationPauseMenuText.Content = "Bye-Bye";
                PlayAgainEndGame.Content = "Restart";
                ExitMenuEndGame.Content = "Menu";
                MosaicPlayAgainEndGame.Content = "Restart";
                MosaicExitMenuEndGame.Content = "Menu";
                MeditationPlayAgainEndGame.Content = "Get Some More Rest";
                MeditationExitMenuEndGame.Content = "Sometime Later";
                HoldPocketText.Text = "Hold";
                NextPocketText.Text = "Next";
                EndGame.Text = "Finished";
                PrizeText.Text = "You got a booster: ";
                MaxPrizeText.Text = "You've collected the maximum number of boosters";
                BestScoreText.Text = "Record: ";
                FinalScoreText.Text = "Points: ";
                FinalStopwatchText.Text = "Time: ";
                FinalLinesText.Text = "Lines: ";
                WinResult.Text = "The Picture is Complete!";
                LoseResult.Text = "Failed";
                MosaicPrizeText.Text = "You got a booster: ";
                MosaicMaxPrizeText.Text = "You've collected the maximum number of boosters";
                RelaxMeditationPlayAgainEndGame.Text = "Relax";
                if (OptionMenuFlag)
                {
                    OptionText.Visibility = Visibility.Hidden;
                    OptionTextEnglish.Visibility = Visibility.Visible;
                }
            }
        }

        // Закрывает Настройки и выходит в Главное меню
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            OpenMenu();
            OptionsMenu.Visibility = Visibility.Hidden;
            OptionText.Visibility = Visibility.Hidden;
            OptionTextEnglish.Visibility = Visibility.Hidden;
        }

        // Окончание игры - 1-й вариант
        /*private void GameOver()
        {
            if (gameState.GameOver)
            {
                if (!gameState.gameOptions.MeditationModeFlag)
                {
                    if (gameState.gameOptions.MosaicModeFlag)
                    {
                        MosaicGameOverMenu.Visibility = Visibility.Visible;

                        if (gameState.gameOptions.MosaicModeFlag && gameState.mosaicWin)
                        {
                            WinResult.Visibility = Visibility.Visible;
                            LoseResult.Visibility = Visibility.Hidden;
                            MosaicPrizeText.Visibility = Visibility.Visible;
                        }
                        else if (gameState.gameOptions.MosaicModeFlag && !gameState.mosaicWin)
                        {
                            WinResult.Visibility = Visibility.Hidden;
                            LoseResult.Visibility = Visibility.Visible;
                            MosaicPrizeText.Visibility = Visibility.Hidden;
                        }
                    }
                    else GameOverMenu.Visibility = Visibility.Visible;  // Открытие Меню Окончания игры

                    if ((gameState.gameOptions.OnlyTetrisModeFlag && gameState.Tetris >= 4) ||          // Меняю показатель для тестов. НОРМА - 4
                        (gameState.gameOptions.SurvivalModeFlag && gameState.ClearedLines >= 40) ||     // Меняю показатель для тестов. НОРМА - 40
                        (gameState.gameOptions.TampingModeFlag && gameState.DifCells >= 50))            // Меняю показатель для тестов. НОРМА - 50
                    {
                        GetPrize();

                        if (prize1 && prize2 && prize3 && prize4)
                        {
                            MaxPrizeText.Visibility = Visibility.Visible;
                            PrizeText.Visibility = Visibility.Hidden;
                        }
                        else if (prize == 1)
                        {
                            PrizeText.Visibility = Visibility.Visible;
                            PrizeText.Text = $"Твой бустер: Палка";
                        }
                        else if (prize == 2)
                        {
                            PrizeText.Visibility = Visibility.Visible;
                            PrizeText.Text = $"Твой бустер: КлоусХолс";
                        }
                        else if (prize == 3)
                        {
                            PrizeText.Visibility = Visibility.Visible;
                            PrizeText.Text = $"Твой бустер: ДаунШифт";
                        }
                        else if (prize == 4)
                        {
                            PrizeText.Visibility = Visibility.Visible;
                            PrizeText.Text = $"Твой бустер: Пустой стакан";
                        }
                        else
                        {
                            MaxPrizeText.Visibility = Visibility.Hidden;
                            PrizeText.Visibility = Visibility.Hidden;
                        }
                    }
                    else if (gameState.gameOptions.MosaicModeFlag && gameState.mosaicWin)
                    {
                        GetPrize();

                        if (prize1 && prize2 && prize3 && prize4)
                        {
                            MosaicMaxPrizeText.Visibility = Visibility.Visible;
                            MosaicPrizeText.Visibility = Visibility.Hidden;
                        }
                        else if (prize == 1)
                        {
                            MosaicPrizeText.Visibility = Visibility.Visible;
                            MosaicPrizeText.Text = $"Твой бустер: Палка";
                        }
                        else if (prize == 2)
                        {
                            MosaicPrizeText.Visibility = Visibility.Visible;
                            MosaicPrizeText.Text = $"Твой бустер: КлоусХолс";
                        }
                        else if (prize == 3)
                        {
                            MosaicPrizeText.Visibility = Visibility.Visible;
                            MosaicPrizeText.Text = $"Твой бустер: ДаунШифт";
                        }
                        else if (prize == 4)
                        {
                            MosaicPrizeText.Visibility = Visibility.Visible;
                            MosaicPrizeText.Text = $"Твой бустер: Пустой стакан";
                        }
                        else
                        {
                            MosaicMaxPrizeText.Visibility = Visibility.Hidden;
                            MosaicPrizeText.Visibility = Visibility.Hidden;
                        }
                    }

                    if (gameState.gameOptions.OnlyTetrisModeFlag) FinalScoreText.Text = $"Тетрисы: {gameState.Tetris}";
                    else if (gameState.gameOptions.SurvivalModeFlag) FinalScoreText.Text = $"Сбросов скорости: {gameState.Tetris}";
                    //else if (gameState.gameOptions.ArcadeModeFlag) FinalScoreText.Text = $"Поинты: {gameState.ArcadeClearedLines}";
                    else if (gameState.gameOptions.TampingModeFlag) FinalScoreText.Text = $"{gameState.DifCells} ячеек заполнено";
                    else if (!gameState.gameOptions.MosaicModeFlag) FinalScoreText.Text = $"Очки: {gameState.Score}";

                    // Определение нового рекорда для каждого режима
                    if (gameState.gameOptions.TetrominoModeFlag && !gameState.gameOptions.IsBoosters && gameState.Score > settings.BestTetrominoClassicScore)
                    {
                        settings.BestTetrominoClassicScore = gameState.Score;
                        Settings.Save(settings);
                        //MessageBox.Show($"Новый лучший результат в режиме Тетромино: {gameState.Score} очков!");  // Отдельное окно с сообщением
                    }
                    else if (gameState.gameOptions.TetrominoModeFlag && gameState.gameOptions.IsBoosters && gameState.Score > settings.BestTetrominoWithBoostersScore)
                    {
                        settings.BestTetrominoWithBoostersScore = gameState.Score;
                        Settings.Save(settings);
                    }
                    else if (gameState.gameOptions.TriminoModeFlag && !gameState.gameOptions.IsBoosters && gameState.Score > settings.BestTriminoClassicScore)
                    {
                        settings.BestTriminoClassicScore = gameState.Score;
                        Settings.Save(settings);
                    }
                    else if (gameState.gameOptions.TriminoModeFlag && gameState.gameOptions.IsBoosters && gameState.Score > settings.BestTriminoWithBoostersScore)
                    {
                        settings.BestTriminoWithBoostersScore = gameState.Score;
                        Settings.Save(settings);
                    }
                    else if (gameState.gameOptions.PentominoModeFlag && !gameState.gameOptions.IsBoosters && gameState.Score > settings.BestPentominoClassicScore)
                    {
                        settings.BestPentominoClassicScore = gameState.Score;
                        Settings.Save(settings);
                    }
                    else if (gameState.gameOptions.PentominoModeFlag && gameState.gameOptions.IsBoosters && gameState.Score > settings.BestPentominoWithBoostersScore)
                    {
                        settings.BestPentominoWithBoostersScore = gameState.Score;
                        Settings.Save(settings);
                    }
                    else if (gameState.gameOptions.OnlyTetrisModeFlag && gameState.Tetris > settings.BestOnlyTetrisScore)
                    {
                        settings.BestOnlyTetrisScore = gameState.Tetris;
                        Settings.Save(settings);
                    }
                    else if (gameState.gameOptions.SurvivalModeFlag && gameState.ClearedLines > settings.BestSurvivalScore)
                    {
                        settings.BestSurvivalScore = gameState.ClearedLines;
                        Settings.Save(settings);
                    }
                    //else if (gameState.gameOptions.ArcadeModeFlag && gameState.ArcadeClearedLines > settings.BestArcadeScore)
                    //{
                    //    settings.BestArcadeScore = gameState.ClearedLines;
                    //    Settings.Save(settings);
                    //}
                    else if (gameState.gameOptions.TampingModeFlag && gameState.DifCells > settings.BestTampingScore)
                    {
                        settings.BestTampingScore = gameState.DifCells;
                        Settings.Save(settings);
                    }

                    BestScoreText.Visibility = Visibility.Visible;
                    if (gameState.gameOptions.TetrominoModeFlag && !gameState.gameOptions.IsBoosters) BestScoreText.Text = $"Рекорд очков: {settings.BestTetrominoClassicScore}";
                    else if (gameState.gameOptions.TetrominoModeFlag && gameState.gameOptions.IsBoosters) BestScoreText.Text = $"Рекорд очков: {settings.BestTetrominoWithBoostersScore}";
                    else if (gameState.gameOptions.TriminoModeFlag && !gameState.gameOptions.IsBoosters) BestScoreText.Text = $"Рекорд очков: {settings.BestTriminoClassicScore}";
                    else if (gameState.gameOptions.TriminoModeFlag && gameState.gameOptions.IsBoosters) BestScoreText.Text = $"Рекорд очков: {settings.BestTriminoWithBoostersScore}";
                    else if (gameState.gameOptions.PentominoModeFlag && !gameState.gameOptions.IsBoosters) BestScoreText.Text = $"Рекорд очков: {settings.BestPentominoClassicScore}";
                    else if (gameState.gameOptions.PentominoModeFlag && gameState.gameOptions.IsBoosters) BestScoreText.Text = $"Рекорд очков: {settings.BestPentominoWithBoostersScore}";
                    else if (gameState.gameOptions.OnlyTetrisModeFlag) BestScoreText.Text = $"Рекорд Тетрисов: {settings.BestOnlyTetrisScore}";
                    else if (gameState.gameOptions.SurvivalModeFlag) BestScoreText.Text = $"Рекорд линий: {settings.BestSurvivalScore}";
                    //else if (gameState.gameOptions.ArcadeModeFlag) BestScoreText.Text = $"Рекорд очков: {settings.BestArcadeScore}";
                    else if (gameState.gameOptions.TampingModeFlag) BestScoreText.Text = $"Рекордно заполнено {settings.BestTampingScore} ячеек";
                    else BestScoreText.Visibility = Visibility.Hidden;

                    if (!gameState.gameOptions.TampingModeFlag) FinalLinesText.Text = $"Линий: {gameState.ClearedLines}";
                }
                else MeditationGameOverMenu.Visibility = Visibility.Visible;
                SurvivalDelay = 0;
                Delay = 0;
            }
        }*/
    }
}