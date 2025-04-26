using System.Runtime.CompilerServices;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using System.Diagnostics;

namespace Tetris_AI
{
    public class GameState  // Управление текущим состоянием игры
    {
        public struct GameFlag  // Флаги, определающие Режим игры, Тип блоков и Тип сетки
        {
            public bool TriminoModeFlag;
            public bool TetrominoModeFlag;
            public bool PentominoModeFlag;
            public bool SurvivalModeFlag;
            public bool ArcadeModeFlag;
            public bool MeditationModeFlag;
            public bool OnlyTetrisModeFlag;
            public bool TampingModeFlag;
            public bool MosaicModeFlag;
            //public bool GetPrizeFlag;
            public bool GetSticklFlag;
            public bool SurvivalFlag;
            public int TypeBlocks;
            public int TypeSizeGrid;
            public int GenerateMosaicType;
            public int IsMode;              // 1 - Классика
                                            // 2 - Бустеры
                                            // 3 - Спринт
                                            // 4 - Спринт Линии
                                            // 5 - Спринт Очки
        };

        public GameFlag gameOptions;  // Переменная для использования флагов в других файлах

        private Block currentBlock;  // Хранит текущий блок, который должен быть размещен на игровом поле

        public Block CurrentBlock  // Свойство позволяет получить текущий блок
                                   // и устанавливает его, автоматически сбрасывая его состояние
        {
            get => currentBlock;
            private set
            {
                currentBlock = value;
                currentBlock.Reset();

                for (int i = 0; i < 2; i++)  // Сдвиг начального положения блоков в видимую часть сетки, если ничего не мешает
                {
                    currentBlock.Move(1, 0);

                    if(!BlockFits())
                    {
                        currentBlock.Move(-1, 0);
                    }
                }

                // Ставит случайный поворот для блока в режиме Мозаика
                if(gameOptions.MosaicModeFlag)
                {
                    // Изначальные изображения не повернуты, поэтмоу сначала нужно повернуть блок в нужном направлениее, установить изображение
                    // и только потом менять его поворот вместе с изображениями. Это реализует метод RotateMosaicBlocks
                    MosaicChoice.RotateMosaicBlocks();

                    int randomRotate = random.Next(0, 4);
                    if (drawTileIndex != 1) for (int i = randomRotate; i < 4; i++) RotateBlockCW();         // Первая фигура разворачивается при установке без изображения.
                                                                                                            // Без понятия почему так. Заглушил через if
                }
            }
        }

        private readonly Random random = new Random();      // Используется для генерации случайных чисел
        public GameGrid GameGrid { get; set; }              // Игровое поле, на котором размещаются блоки
        public BlockQueue BlockQueue { get; }               // Управляет очередью блоков, из которой выбираются новые блоки для игры
        public MainWindow MainWindow { get; set; }          // Управляет визуальным отображением игры
        public MosaicChoice MosaicChoice { get; set; }      // Управляет выбором картинки и типом генерации для режима Мозаика
        public bool GameOver { get; private set; }          // Состояние Окончания игры: ВКЛ/ВЫКЛ
        public int Score { get; private set; }              // Количество очков
        public int Cells { get; private set; }              // Количество установленных ячеек 
        public int StartCells { get; private set; }         // Количество изначально установленных ячеек 
        public int DifCells { get; private set; }           // Количество установленных игроком ячеек 
        public int ClearedLines { get; set; }               // Количество соженных линий
        public int ArcadeClearedLines { get; set; }         // Количество соженных линий в режиме Аркада
        public int ScoreMultiplier { get; private set; }    // Множитель очков
        public Block HeldBlock { get; private set; }        // Управляет удерживаемым блоком
        public bool CanHold { get; private set; }           // Определяет есть ли блок на удержании: ДА/НЕТ
        public int Tetris {  get; set; }                    // Подсчет количества Тетрисов - соженных 4-х линий одновременно

        public int drawTileIndex = 1;                       // Счетчик для отображения последовательности изображений в Мозаике
        public int mosaicCheck = 1;                         // Счетчик для сравнения со значениями в стакане в режиме Мозаика для определения выигрыша
        private bool drawTileIndexFlag = false;             // Флаг пропускает 2 первых блока перед началом отсчета в Мозаике
        private bool canRotateImage = true;                 // Флаг не позволяет изображениям в Мозаике поворачиваться там, где не может развернуться блок

        public bool mosaicWin = false;                      // Флаг определяет победу/проигрыш в режиме Мозаика
        public bool sprintWin = false;                      // Флаг определяет победу/проигрыш в режиме Спринт

        // Конструктор
        public GameState(MainWindow mainWindow)
        {
            MainWindow = mainWindow;
            GameGrid = new GameGrid(24, 14, this);                // Инициализация игрового поля размером 24х14
            BlockQueue = new BlockQueue(this);              // Создание очереди блоков
            CurrentBlock = BlockQueue.GetAndUpdate();       // Устанавливает первый блок для игры
            MosaicChoice = new MosaicChoice(this);
            CanHold = true;
        }

        // Проверяет, помещается ли текущий блок на игровое поле без нарушения правил игры
        private bool BlockFits()  
        {
            foreach(Position p in CurrentBlock.TilePositions())
            {
                if(!GameGrid.IsEmpty(p.Row, p.Column)) return false;
            }

            return true;
        }

        // Реализация Удержания блока
        public void HoldBlock()  
        {
            if(!CanHold) return;

            if(HeldBlock == null)  // Если блок на удержании отсутствует, то удерживаем 1-й блок
            {
                HeldBlock = CurrentBlock;
                CurrentBlock = BlockQueue.GetAndUpdate();
            }
            else  // Если есть блок на удержании, то он обменивается с текущим блоком
            {
                Block tmp = CurrentBlock;
                CurrentBlock = HeldBlock;
                HeldBlock = tmp;
            }

            CanHold = false;  // Блокируем возможность повторно взять новый блок на удержание
        }

        // Вращение блока по часовой стрелке на 90 градусов
        public void RotateBlockCW()  
        {
            CurrentBlock.RotateCW();

            if (!BlockFits())
            {
                CurrentBlock.RotateCCW();
                canRotateImage = false;
            }

            // Поворот блока-картинки в режиме Мозаика
            if(gameOptions.MosaicModeFlag && canRotateImage)
            {
                int mosaicIndex = drawTileIndex;
                int j = 1;

                int i = 0;

                // Если изображения блока не переворачиваются, скорее всего проблема в том, что i не принимает изображение из-за if
                while (j < 5)
                {
                    if (gameOptions.GenerateMosaicType == 1) i = MosaicChoice.mosaicIndexsOne[mosaicIndex];
                    else if (gameOptions.GenerateMosaicType == 2) i = MosaicChoice.mosaicIndexsTwo[mosaicIndex];
                    else if (gameOptions.GenerateMosaicType == 3) i = MosaicChoice.mosaicIndexsThree[mosaicIndex];
                    else if (gameOptions.GenerateMosaicType == 4) i = MosaicChoice.mosaicIndexsFour[mosaicIndex];
                    else if (gameOptions.GenerateMosaicType == 5) i = MosaicChoice.mosaicIndexsFive[mosaicIndex];
                    else if (gameOptions.GenerateMosaicType == 6) i = MosaicChoice.mosaicIndexsSix[mosaicIndex];
                    else if (gameOptions.GenerateMosaicType == 7) i = MosaicChoice.mosaicIndexsSeven[mosaicIndex];
                    else if (gameOptions.GenerateMosaicType == 8) i = MosaicChoice.mosaicIndexsEight[mosaicIndex];
                    else if (gameOptions.GenerateMosaicType == 9) i = MosaicChoice.mosaicIndexsNine[mosaicIndex];
                    else if (gameOptions.GenerateMosaicType == 10) i = MosaicChoice.mosaicIndexsTen[mosaicIndex];
                    else if (gameOptions.GenerateMosaicType == 11) i = MosaicChoice.mosaicIndexsEleven[mosaicIndex];
                    else if (gameOptions.GenerateMosaicType == 12) i = MosaicChoice.mosaicIndexsTwelve[mosaicIndex];

                    var transformedBitmap = new TransformedBitmap();
                    transformedBitmap.BeginInit();

                    transformedBitmap.Source = MainWindow.MosaicTiles[i];
                    transformedBitmap.Transform = new RotateTransform(90);
                    MainWindow.MosaicTiles[i] = transformedBitmap;      // Передаем не Source, а сам Bitmap

                    transformedBitmap.EndInit();
                    transformedBitmap.Freeze();

                    j++;
                    mosaicIndex++;
                }
            }

            canRotateImage = true;
        }

        // Вращение блока против часовой стрелки на 90 градусов
        public void RotateBlockCCW()  
        {
            CurrentBlock.RotateCCW();

            if (!BlockFits())
            {
                CurrentBlock.RotateCW();
                canRotateImage = false;
            }

            // Поворот блока-картинки в режиме Мозаика
            if (gameOptions.MosaicModeFlag && canRotateImage)
            {
                int mosaicIndex = drawTileIndex;
                int j = 1;

                int i = 0;

                while (j < 5)
                {
                    if (gameOptions.GenerateMosaicType == 1) i = MosaicChoice.mosaicIndexsOne[mosaicIndex];
                    else if (gameOptions.GenerateMosaicType == 2) i = MosaicChoice.mosaicIndexsTwo[mosaicIndex];
                    else if (gameOptions.GenerateMosaicType == 3) i = MosaicChoice.mosaicIndexsThree[mosaicIndex];
                    else if (gameOptions.GenerateMosaicType == 4) i = MosaicChoice.mosaicIndexsFour[mosaicIndex];
                    else if (gameOptions.GenerateMosaicType == 5) i = MosaicChoice.mosaicIndexsFive[mosaicIndex];
                    else if (gameOptions.GenerateMosaicType == 6) i = MosaicChoice.mosaicIndexsSix[mosaicIndex];
                    else if (gameOptions.GenerateMosaicType == 7) i = MosaicChoice.mosaicIndexsSeven[mosaicIndex];
                    else if (gameOptions.GenerateMosaicType == 8) i = MosaicChoice.mosaicIndexsEight[mosaicIndex];
                    else if (gameOptions.GenerateMosaicType == 9) i = MosaicChoice.mosaicIndexsNine[mosaicIndex];
                    else if (gameOptions.GenerateMosaicType == 10) i = MosaicChoice.mosaicIndexsTen[mosaicIndex];
                    else if (gameOptions.GenerateMosaicType == 11) i = MosaicChoice.mosaicIndexsEleven[mosaicIndex];
                    else if (gameOptions.GenerateMosaicType == 12) i = MosaicChoice.mosaicIndexsTwelve[mosaicIndex];

                    var transformedBitmap = new TransformedBitmap();
                    transformedBitmap.BeginInit();

                    transformedBitmap.Source = MainWindow.MosaicTiles[i];
                    transformedBitmap.Transform = new RotateTransform(-90);
                    MainWindow.MosaicTiles[i] = transformedBitmap;      // Передаем не Source, а сам Bitmap

                    transformedBitmap.EndInit();
                    transformedBitmap.Freeze();

                    j++;
                    mosaicIndex++;
                }

                canRotateImage = true;
            }
        }

        // Перемещение блока влево на 1 клетку
        public void MoveBlockLeft()  
        {
            CurrentBlock.Move(0, -1);

            if(!BlockFits()) CurrentBlock.Move(0, 1);
        }

        // Перемещение блока вправо на 1 клетку
        public void MoveBlockRight()  
        {
            CurrentBlock.Move(0, 1);

            if(!BlockFits()) CurrentBlock.Move(0, -1);
        }

        // Перемещение блока вниз
        public void MoveBlockDown()
        {
            CurrentBlock.Move(1, 0);

            if (!BlockFits())
            {
                CurrentBlock.Move(-1, 0);
                PlaceBlock();
            }
        }

        // Проверяет, заполнены ли первые две строки игрового поля, что обычно считается условием окончания игры в Тетрис
        private bool IsGameOver()  
        {
            return !(GameGrid.IsRowEmpty(0) && GameGrid.IsRowEmpty(1));
        }

        // Реализаци установки блока на игровом поле
        private void PlaceBlock()
        {
            // Устанавливаем значения клеток поля равным индетификатору текущего блока
            foreach (Position p in CurrentBlock.TilePositions())
            {
                if (gameOptions.MosaicModeFlag && drawTileIndexFlag && !GameOver)
                {
                    if (gameOptions.GenerateMosaicType == 1) GameGrid[p.Row, p.Column] = MosaicChoice.mosaicIndexsOne[drawTileIndex++];
                    else if (gameOptions.GenerateMosaicType == 2) GameGrid[p.Row, p.Column] = MosaicChoice.mosaicIndexsTwo[drawTileIndex++];
                    else if (gameOptions.GenerateMosaicType == 3) GameGrid[p.Row, p.Column] = MosaicChoice.mosaicIndexsThree[drawTileIndex++];
                    else if (gameOptions.GenerateMosaicType == 4) GameGrid[p.Row, p.Column] = MosaicChoice.mosaicIndexsFour[drawTileIndex++];
                    else if (gameOptions.GenerateMosaicType == 5) GameGrid[p.Row, p.Column] = MosaicChoice.mosaicIndexsFive[drawTileIndex++];
                    else if (gameOptions.GenerateMosaicType == 6) GameGrid[p.Row, p.Column] = MosaicChoice.mosaicIndexsSix[drawTileIndex++];
                    else if (gameOptions.GenerateMosaicType == 7) GameGrid[p.Row, p.Column] = MosaicChoice.mosaicIndexsSeven[drawTileIndex++];
                    else if (gameOptions.GenerateMosaicType == 8) GameGrid[p.Row, p.Column] = MosaicChoice.mosaicIndexsEight[drawTileIndex++];
                    else if (gameOptions.GenerateMosaicType == 9) GameGrid[p.Row, p.Column] = MosaicChoice.mosaicIndexsNine[drawTileIndex++];
                    else if (gameOptions.GenerateMosaicType == 10) GameGrid[p.Row, p.Column] = MosaicChoice.mosaicIndexsTen[drawTileIndex++];
                    else if (gameOptions.GenerateMosaicType == 11) GameGrid[p.Row, p.Column] = MosaicChoice.mosaicIndexsEleven[drawTileIndex++];
                    else if (gameOptions.GenerateMosaicType == 12) GameGrid[p.Row, p.Column] = MosaicChoice.mosaicIndexsTwelve[drawTileIndex++];

                }
                else GameGrid[p.Row, p.Column] = CurrentBlock.ID;
            }

            // ОнлиТетрис
            if (gameOptions.OnlyTetrisModeFlag)
            {
                int lines = GameGrid.ClearFullRows();           // Переменная для хранения количества соженных линий за раз
                if (lines == 0 || lines == 4)
                {
                    if (lines == 4)
                    {
                        Tetris++;
                        ClearedLines += 4;
                    }
                }
                else GameOver = true;
            }
            // Пентомино Спринт
            else if (gameOptions.PentominoModeFlag && gameOptions.IsMode == 3)
            {
                // Меняем цвет установленных ячеек на серый
                for (int r = GameGrid.Rows - 1; r >= 8; r--)
                {
                    for (int c = 0; c < GameGrid.Columns; c++)
                    {
                        if (GameGrid[r, c] != 0)
                        {
                            GameGrid[r, c] = 15;
                        }
                    }
                }

                // Проверяем целиком ли заполнено поле
                int check = 0;
                for (int r = GameGrid.Rows - 1; r >= 8; r--)
                {
                    bool full = GameGrid.IsRowFull(r);
                    if (full) check++;
                    else break;
                }

                if (check == 16)
                {
                    sprintWin = true;
                    GameOver = true;
                }
            }
            // Тетромино Спринт
            else if (gameOptions.TetrominoModeFlag && gameOptions.IsMode == 3)
            {
                for (int r = GameGrid.Rows - 1; r >= 7; r--)
                {
                    for (int c = 0; c < GameGrid.Columns; c++)
                    {
                        if (GameGrid[r, c] != 0)
                        {
                            GameGrid[r, c] = 15;
                        }
                    }
                }

                int check = 0;
                for (int r = GameGrid.Rows - 1; r >= 7; r--)
                {
                    bool full = GameGrid.IsRowFull(r);
                    if (full) check++;
                    else break;
                }

                if (check == 15)
                {
                    sprintWin = true;
                    GameOver = true;
                }
            }
            // Тримино Спринт
            else if (gameOptions.TriminoModeFlag && gameOptions.IsMode == 3)
            {
                for (int r = GameGrid.Rows - 1; r >= 6; r--)
                {
                    for (int c = 0; c < GameGrid.Columns; c++)
                    {
                        if (GameGrid[r, c] != 0)
                        {
                            GameGrid[r, c] = 15;
                        }
                    }
                }

                int check = 0;
                for (int r = GameGrid.Rows - 1; r >= 6; r--)
                {
                    bool full = GameGrid.IsRowFull(r);
                    if (full) check++;
                    else break;
                }

                if (check == 11)
                {
                    sprintWin = true;
                    GameOver = true;
                }
            }
            // Спринт Линии
            else if (gameOptions.TetrominoModeFlag && gameOptions.IsMode == 4)
            {
                int lines = GameGrid.ClearFullRows();
                ClearedLines += lines;

                if (ClearedLines >= 100)
                {
                    sprintWin = true;
                    GameOver = true;
                }
            }
            // Спринт Очки
            else if (gameOptions.TetrominoModeFlag && gameOptions.IsMode == 5)
            {
                int lines = GameGrid.ClearFullRows();
                ClearedLines += lines;
                Score += Scoring(lines);
                ScoreMultiplier = ScoreMultipliers();

                if (Score >= 100000)
                {
                    sprintWin = true;
                    GameOver = true;
                }
            }
            // Утрамбовка
            else if (gameOptions.TampingModeFlag)
            {
                // Проигрыш, если найдет хоть один блок в зоне проигрыша
                GameOver = !GameGrid.IsRowEmpty(10);

                Cells = 0;

                // Меняем цвет установленных ячеек на серый
                for (int r = 21; r >= 11; r--)
                {
                    for (int c = 0; c < GameGrid.Columns; c++)
                    {
                        if (GameGrid[r, c] != 0)
                        {
                            GameGrid[r, c] = 15;
                            Cells++;
                        }
                    }
                }

                DifCells = Cells - StartCells;
            }
            // Мозаика
            else if (gameOptions.MosaicModeFlag && drawTileIndexFlag)  // drawTileIndexFlag - флаг, который не меняет drawTileIndex пока не начнутся нужные фигуры, т.е. с 3-й
            {
                if (drawTileIndex > 160)
                {
                    bool flag = false;
                    for (int r = 21; r >= 6; r--)
                    {
                        for (int c = 0; c < GameGrid.Columns; c++)
                        {
                            if (GameGrid[r, c] != mosaicCheck)
                            {
                                mosaicWin = false;
                                GameOver = true;
                                flag = true;
                                break;
                            }
                            else mosaicCheck++;
                        }
                        if (flag) break;
                    }

                    if (!flag)
                    {
                        mosaicWin = true;
                        GameOver = true;
                    }
                }

                //ShowMatrixValues(GameGrid);               // МЕТОД ВЫВОДИТ В ТЕРМИНАЛ ВСЕ ЗНАЧЕНИЯ СТАКАНА - ДЛЯ ТЕСТОВ
            }
            // Остальные режимы
            else
            {
                int lines = GameGrid.ClearFullRows();       // Переменная для хранения количества соженных линий за раз
                if (lines == 4) Tetris++;
                ClearedLines += lines;
                ArcadeClearedLines += lines;
                Score += Scoring(lines);
                ScoreMultiplier = ScoreMultipliers();
            }

            // Если игра не окончена, то устанавливаем следующий блок в очередь
            if (IsGameOver()) GameOver = true;
            else
            {
                CurrentBlock = BlockQueue.GetAndUpdate();
                CanHold = true;  // Даем возможность взять новый блок на удержание
            }
        }

        // Определяет минимальное количество клеток, которые нужно опустить вниз
        private int TileDropDistance(Position p)  
        {
            int drop = 0;

            while (GameGrid.IsEmpty(p.Row + drop + 1, p.Column))
            {
                drop++;
            }

            return drop;
        }

        // Вычисляет минимальное расстояние падения для всех плиток текущего блока CurrentBlock,
        // чтобы убедиться, что весь блок опускается на сетку
        public int BlockDropDistance()  
        {
            int drop = GameGrid.Rows;

            foreach(Position p in CurrentBlock.TilePositions())
            {
                drop = System.Math.Min(drop, TileDropDistance(p));
            }

            return drop;
        }

        // Опускает текущий блок до упора
        public void DropBlock()  
        {
            CurrentBlock.Move(BlockDropDistance(), 0);
            PlaceBlock();
        }

        // Закрывает три дырки, начиная с правого нижнего края сетки
        public int CloseHoles(GameGrid grid)
        {
            int flag = 0;  // Определяет сколько пустых ячеек должна найти программа
            for (int r = grid.Rows - 1; r >= 2; r--)
            {
                for (int c = grid.Columns - 1; c >= 0; c--)
                {
                    if (GameGrid.IsHoleCanClose(r, c))
                    {
                        grid[r, c] = 15;  //15 - значение, которое хранится в ячейке: серая плитка
                        flag++;
                    }
                    if (gameOptions.TriminoModeFlag && gameOptions.IsMode == 2 && flag == 3) return flag;
                    else if (gameOptions.TetrominoModeFlag && gameOptions.IsMode == 2 && flag == 4) return flag;
                    else if (gameOptions.PentominoModeFlag && gameOptions.IsMode == 2 && flag == 5) return flag;
                }
            }

            return flag;
        }

        // Опускает все ячейки до упора
        public bool DownwardShif(GameGrid grid)  
        {
            bool shift = false;
            for (int c = 0; c <= grid.Columns - 1; c++)
            {
                for (int r = grid.Rows - 2; r >= 1; r--)  // grid.Rows - 2, т.к. мы начинаем проверку со 2-й линии снизу
                {
                    if (grid[r, c] != 0 && grid[r + 1, c] == 0)
                    {
                        int droProba = 0;

                        while (GameGrid.IsEmpty(r + droProba + 1, c))
                        {
                            droProba++;
                        }

                        grid[r + droProba, c] = grid[r, c];
                        grid[r, c] = 0;
                        shift = true;
                    }
                }
            }
            return shift;
        }

        // Опустошает весь стакан
        public void EmptyGlass(GameGrid grid)
        {
            for (int r = grid.Rows - 1; r >= 2; r--)
            {
                if (GameGrid.IsRowEmpty(r)) return;  // Проверяет, пустая ли строка, чтобы не проходить всю сетку целиком

                for (int c = grid.Columns - 1; c >= 0; c--)
                {
                    grid[r, c] = 0;
                }
            }
        }

        // Сжигает все плитки одного цвета и опускает столбец на место сожженных ячеек
        public void Electro(GameGrid grid)  
        {
            int ID = random.Next(1, 8);

            for (int r = grid.Rows - 1; r >= 2; r--)
            {
                if (GameGrid.IsRowEmpty(r)) return;

                for (int c = grid.Columns - 1; c >= 0; c--)
                {
                    while(grid[r, c] == ID)
                    {
                        grid[r, c] = 0;
                        ElectroDownwardShif(grid, r, c);
                    }
                }
            }
        }

        // Опускает все ячейки на место сожженных
        public void ElectroDownwardShif(GameGrid grid, int r, int c)  
        {
            for(int tempR = r; tempR >= 2; tempR--)
            {
                grid[tempR, c] = grid[tempR - 1, c];
                if (GameGrid.IsRowEmpty(r)) return;
            }
        }

        // КОСТЫЛЬ - ОПУСКАЕТ ПЕРВЫЕ 2 БЛОКА ВНИЗ ДО УПОРА, СЖИГАЕТ ИХ И УСТАНАВЛИВАЕТ НОВУЮ СЕТКУ В ЗАВИСИМОСТИ ОТ РЕЖИМА
        // 1. ПРИ ЗАПУСКЕ ИГРЫ СОЗДАЕТСЯ ОЧЕРЕДЬ С ТЕКУЩИМ И СЛЕДУЮЩИМ БЛОКАМИ, ПО УМОЛЧАНИЮ БЛОКИ - ТЕТРОМИНО,
        // НО ПРИ ЗАПУСКЕ РЕЖИОВ С ДРУГИМИ БЛОКАМИ, НАПРИМЕР, ТРИМИНО, ДОЛЖНЫ БЫТЬ ДРУГИЕ БЛОКИ, НЕ ТЕТРОМИНО,
        // ПОЭТОМУ ПРИ ЗАПУСКЕ НОВОЙ ИГРЫ МЫ ОПУСКАЕМ ПЕРВЫЕ 2 БЛОКА ТЕТРОМИНО, СОЗДАННЫЕ ПРИ ЗАПУСКЕ ИГРЫ, И УНИЧТОЖАЕМ ИХ
        // 2. ПРИ ЗАПУСКЕ РЕЖИМОВ ВОЗНИКАЕТ ОШИБКА ИЗ-ЗА НЕКОРРЕКТНОЙ УСТАНОВКИ СЕТКИ, ПОЭТОМУ МЫ КАЖДЫЙ РАЗ ЕЕ ПЕРЕСОЗДАЕМ ЧЕРЕЗ GameGridReset.
        // В КОНСТРУКТОРЕ ИЗНАЧАЛЬНО СОЗДАЕТСЯ САМАЯ БОЛЬШАЯ СЕТКА ДЛЯ ПЕНТОМИНО, Т.К. ПЕРЕСОЗДАТЬ МОЖНО БУДЕТ ТОЛЬКО СЕТКУ С МЕНЬШИМИ РАЗМЕРАМИ.
        // ПРИ СОЗДАНИИ СЕТКИ С БОЛЬШИМИ РАЗМЕРАМИ, ЧЕМ ИЗНАЧАЛЬНЫЕ, ИГРА ВЫЛЕТАЕТ. ПОЧЕМУ? ХЗ!
        public void Crutch(GameGrid grid)
        {
            DropBlock();
            DropBlock();

            drawTileIndexFlag = true;

            for (int r = grid.Rows - 1; r >= 2; r--)
            {
                if (GameGrid.IsRowEmpty(r)) break;

                for (int c = grid.Columns - 1; c >= 0; c--)
                {
                    grid[r, c] = 0;
                }
            }

            GameGridReset();
        }

        // Обновление сетки в зависимости от режима
        public void GameGridReset()
        {
            if (gameOptions.TypeBlocks == 3) GameGrid = new GameGrid(24, 14, this);       // Пентомино
            else if (gameOptions.TypeBlocks == 2) GameGrid = new GameGrid(17, 8, this);   // Тримино
            else GameGrid = new GameGrid(22, 10, this);                                   // Тетромино - большинство режимов
        }

        // Устанавливает серые фиксированные блоки на поле в случайном порядке для режима Утрамбовка
        public void SetGrayCell(GameGrid grid)
        {
            var random = new Random();  // Создаем экземпляр генератора случайных чисел

            // Устанавливаем разные вероятности заполнения серыми блоками разные линии
            // Чем ниже колодец, тем выше вероятность серого блока
            // Это делается, чтобы игрок с меньшей вероятностью застревал в самом верху колодца

            // Вероятность поделена на 2 отрезка стакана
            for (int r = 21; r >= 16; r--)
            {
                for (int c = 0; c < grid.Columns; c++)
                {
                    if (random.NextDouble() <= 0.18)
                    {
                        grid[r, c] = 15;
                        StartCells++;
                    }
                }
            }

            for (int r = 15; r >= 11; r--)
            {
                for (int c = 0; c < grid.Columns; c++)
                {
                    if (random.NextDouble() <= 0.1)
                    {
                        grid[r, c] = 15;
                        StartCells++;
                    }
                }
            }
        }

        // Выводит в терминал все значения стакана
        public static void ShowMatrixValues(GameGrid grid)
        {
            // Проверяем наличие данных
            if (grid == null || grid.Rows <= 0 || grid.Columns <= 0)
            {
                Debug.WriteLine("Матрица пуста или недействительна");
                return;
            }

            // Выводим значения с форматированием
            for (int r = 0; r < grid.Rows; r++)
            {
                for (int c = 0; c < grid.Columns; c++)
                {
                    Debug.WriteLine($"[r={r},c={c}] = {grid[r, c]}");
                    Console.Write($"{grid[r, c],6}");
                }
                Debug.WriteLine("--- Новая строка ---");
                Console.WriteLine();
            }
        }

        // Система подсчета очков
        private int Scoring(int line)  
        {
            int score = 0;

            if(line == 1) score = 40 * (ScoreMultiplier + 1);            // Если сожжена одна линия = 40 очков
            else if(line == 2) score = 100 * (ScoreMultiplier + 1);      // Если сожжено две линии = 100 очков
            else if(line == 3) score = 300 * (ScoreMultiplier + 1);      // Если сожжено три линии = 300 очков
            else if(line == 4) score = 1200 * (ScoreMultiplier + 1);     // Если сожжено четыре линии = 1200 очков
            else if(line == 5) score = 2500 * (ScoreMultiplier + 1);     // Если сожжено пять линий = 2500 очков

            return score;
        }

        // Выбор множителя очков
        public int ScoreMultipliers()
        {
            int currentScoreMultiplier = 0;
            if (ClearedLines == 1) currentScoreMultiplier = 1;
            else if(ClearedLines == 2) currentScoreMultiplier = 2;
            else if(ClearedLines == 3) currentScoreMultiplier = 3;
            else if(ClearedLines == 4) currentScoreMultiplier = 4;
            else if(ClearedLines == 5) currentScoreMultiplier = 5;
            else if(ClearedLines == 6 || ClearedLines == 7) currentScoreMultiplier = 6;
            else if(ClearedLines == 8 || ClearedLines == 9) currentScoreMultiplier = 7;
            else if(ClearedLines == 10 || ClearedLines == 11) currentScoreMultiplier = 8;
            else if(ClearedLines == 12 || ClearedLines == 13) currentScoreMultiplier = 9;
            else if(ClearedLines >= 14 && ClearedLines <= 16) currentScoreMultiplier = 10;
            else if(ClearedLines >= 17 && ClearedLines <= 19) currentScoreMultiplier = 11;
            else if(ClearedLines >= 20 && ClearedLines <= 22) currentScoreMultiplier = 12;
            else if(ClearedLines >= 23 && ClearedLines <= 25) currentScoreMultiplier = 13;
            else if(ClearedLines >= 26 && ClearedLines <= 28) currentScoreMultiplier = 14;
            else if(ClearedLines >= 29 && ClearedLines <= 32) currentScoreMultiplier = 15;
            else if(ClearedLines >= 33 && ClearedLines <= 36) currentScoreMultiplier = 16;
            else if(ClearedLines >= 27 && ClearedLines <= 40) currentScoreMultiplier = 17;
            else if(ClearedLines >= 41 && ClearedLines <= 44) currentScoreMultiplier = 18;
            else if(ClearedLines >= 45 && ClearedLines <= 49) currentScoreMultiplier = 19;
            else if(ClearedLines >= 50 && ClearedLines <= 54) currentScoreMultiplier = 20;
            else if(ClearedLines >= 55 && ClearedLines <= 59) currentScoreMultiplier = 21;
            else if(ClearedLines >= 60 && ClearedLines <= 64) currentScoreMultiplier = 22;
            else if(ClearedLines >= 65 && ClearedLines <= 70) currentScoreMultiplier = 23;
            else if(ClearedLines >= 71 && ClearedLines <= 76) currentScoreMultiplier = 24;
            else if(ClearedLines >= 77 && ClearedLines <= 82) currentScoreMultiplier = 25;
            else if(ClearedLines >= 83 && ClearedLines <= 88) currentScoreMultiplier = 26;
            else if(ClearedLines >= 89 && ClearedLines <= 95) currentScoreMultiplier = 27;
            else if(ClearedLines >= 96 && ClearedLines <= 102) currentScoreMultiplier = 28;
            else if(ClearedLines >= 103 && ClearedLines <= 109) currentScoreMultiplier = 29;
            else if(ClearedLines >= 110 && ClearedLines <= 115) currentScoreMultiplier = 30;
            else if(ClearedLines >= 116 && ClearedLines <= 123) currentScoreMultiplier = 31;
            else if(ClearedLines >= 124 && ClearedLines <= 131) currentScoreMultiplier = 32;
            else if(ClearedLines >= 132 && ClearedLines <= 139) currentScoreMultiplier = 33;
            else if(ClearedLines >= 140 && ClearedLines <= 147) currentScoreMultiplier = 34;
            else if(ClearedLines >= 148 && ClearedLines <= 156) currentScoreMultiplier = 35;
            else if(ClearedLines >= 157 && ClearedLines <= 165) currentScoreMultiplier = 36;
            else if(ClearedLines >= 166 && ClearedLines <= 174) currentScoreMultiplier = 37;
            else if(ClearedLines >= 175 && ClearedLines <= 183) currentScoreMultiplier = 38;
            else if(ClearedLines >= 184) currentScoreMultiplier = 39;

            return currentScoreMultiplier;
        }

        // Альтернативная система повышения уровней
        /*public int BurnLines(int lines)  
        {
            LinesForNextLevel -= lines;

            if (LinesForNextLevel <= 0)
            {
                CurrentLevel++;
                LinesForNextLevel = UpLevel();
            }

            return CurrentLevel;
        }

        // Определяет количество линий, необходимых сжечь до следующего уровня
        private int UpLevel()  
        {
            if (CurrentLevel <= 5)
            {
                return 1;
            }
            else if (CurrentLevel >= 6 && CurrentLevel <= 9)
            {
                return 2;
            }
            else if (CurrentLevel >= 10 && CurrentLevel <= 14)
            {
                return 3;
            }
            else if (CurrentLevel >= 15 && CurrentLevel <= 18)
            {
                return 4;
            }
            else if (CurrentLevel >= 19 && CurrentLevel <= 22)
            {
                return 5;
            }
            else if (CurrentLevel >= 23 && CurrentLevel <= 26)
            {
                return 6;
            }
            else if (CurrentLevel >= 27 && CurrentLevel <= 30)
            {
                return 7;
            }
            else if (CurrentLevel >= 31 && CurrentLevel <= 34)
            {
                return 8;
            }
            else if (CurrentLevel >= 35 && CurrentLevel <= 38)
            {
                return 9;
            }
            else
            {
                // Предполагаем, что игра продолжается бесконечно
                return 10;
            }
        }*/
    }
}
