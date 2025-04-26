using System;
using System.Windows.Shapes;

namespace Tetris_AI
{
    public class BlockQueue  // Управление очередью блоков
    {
        // Блоки Тетромино - 7 шт.
        private readonly Block[] blocks = new Block[]
        {
            new IBlock(),
            new JBlock(),
            new LBlock(),
            new OBlock(),
            new SBlock(),
            new TBlock(),
            new ZBlock(),
        };

        // Блоки Тримино - 7 шт.
        private readonly Block[] blocks_three = new Block[]
        {
            new IBlock_three(),
            new JBlock_three(),
            new LBlock_three(),
            new OBlock_three(),
            new XBlock_three(),
            new VBlock_three(),
            new GBlock_three(),
        };

        // Блоки Пентомино - 14 шт.
        private readonly Block[] blocks_pentomino = new Block[]
        {
            new IBlock_pentomino(),
            new PBlock_pentomino(),
            new BBlock_pentomino(),
            new FBlock_pentomino(),
            new EBlock_pentomino(),
            new JBlock_pentomino(),
            new LBlock_pentomino(),
            new NBlock_pentomino(),
            new MBlock_pentomino(),
            new VBlock_pentomino(),
            //new UBlock_pentomino(), - неудобная фигура, скорее мешает
            new TBlock_pentomino(),
            new WBlock_pentomino(),
            //new XBlock_pentomino(), - неудобная фигура, скорее мешает
            new YBlock_pentomino(),
            new KBlock_pentomino(),
            //new ZBlock_pentomino(), - неудобная фигура, скорее мешает
            //new SBlock_pentomino(), - неудобная фигура, скорее мешает
        };

        // Блоки Мозаика
        public readonly Block[] mosaicBlocksOne = new Block[]
        {
            new OBlock(),
            new TBlock(), new IBlock(), new ZBlock(), new JBlock(), new OBlock(), new LBlock(), new SBlock(), new SBlock(),
            new LBlock(), new ZBlock(), new TBlock(), new ZBlock(), new JBlock(), new OBlock(), new TBlock(), new ZBlock(),
            new OBlock(), new LBlock(), new SBlock(), new SBlock(), new SBlock(), new IBlock(), new TBlock(), new SBlock(),
            new JBlock(), new OBlock(), new TBlock(), new LBlock(), new SBlock(), new LBlock(), new IBlock(), new TBlock(),
            new TBlock(), new JBlock(), new JBlock(), new ZBlock(), new OBlock(), new LBlock(), new IBlock(), new TBlock(),
            new OBlock(), new OBlock(), new OBlock(),
        };

        public readonly Block[] mosaicBlocksTwo = new Block[]
        {
            new OBlock(),
            new OBlock(), new OBlock(), new JBlock(), new LBlock(), new JBlock(), new SBlock(), new LBlock(), new TBlock(),
            new IBlock(), new JBlock(), new TBlock(), new LBlock(), new TBlock(), new ZBlock(), new JBlock(), new TBlock(),
            new TBlock(), new TBlock(), new IBlock(), new JBlock(), new OBlock(), new JBlock(), new SBlock(), new TBlock(),
            new LBlock(), new ZBlock(), new SBlock(), new OBlock(), new TBlock(), new ZBlock(), new LBlock(), new TBlock(),
            new JBlock(), new ZBlock(), new SBlock(), new TBlock(), new ZBlock(), new IBlock(), new LBlock(), new OBlock(),
            new OBlock(), new OBlock(), new OBlock(),
        };

        public readonly Block[] mosaicBlocksThree = new Block[]
        {
            new OBlock(),
            new TBlock(), new IBlock(), new JBlock(), new JBlock(), new OBlock(), new JBlock(), new ZBlock(), new TBlock(),
            new SBlock(), new TBlock(), new LBlock(), new ZBlock(), new OBlock(), new JBlock(), new IBlock(), new TBlock(),
            new JBlock(), new ZBlock(), new ZBlock(), new OBlock(), new SBlock(), new LBlock(), new SBlock(), new LBlock(),
            new JBlock(), new OBlock(), new TBlock(), new IBlock(), new JBlock(), new LBlock(), new SBlock(), new TBlock(),
            new TBlock(), new JBlock(), new OBlock(), new OBlock(), new JBlock(), new TBlock(), new ZBlock(), new IBlock(),
            new OBlock(), new OBlock(), new OBlock(),
        };

        public readonly Block[] mosaicBlocksFour = new Block[]
        {
            new OBlock(),
            new LBlock(), new TBlock(), new SBlock(), new OBlock(), new SBlock(), new JBlock(), new SBlock(), new LBlock(),
            new SBlock(), new OBlock(), new SBlock(), new JBlock(), new JBlock(), new SBlock(), new IBlock(), new LBlock(),
            new TBlock(), new LBlock(), new ZBlock(), new SBlock(), new TBlock(), new OBlock(), new JBlock(), new TBlock(),
            new IBlock(), new OBlock(), new LBlock(), new OBlock(), new SBlock(), new JBlock(), new SBlock(), new LBlock(),
            new SBlock(), new ZBlock(), new TBlock(), new LBlock(), new SBlock(), new TBlock(), new LBlock(), new IBlock(),
            new OBlock(), new OBlock(), new OBlock(),
        };

        public readonly Block[] mosaicBlocksFive = new Block[]
        {
            new OBlock(),
            new LBlock(), new IBlock(), new TBlock(), new LBlock(), new JBlock(), new SBlock(), new IBlock(), new TBlock(),
            new OBlock(), new LBlock(), new ZBlock(), new IBlock(), new LBlock(), new TBlock(), new JBlock(), new ZBlock(),
            new JBlock(), new OBlock(), new IBlock(), new OBlock(), new OBlock(), new TBlock(), new SBlock(), new LBlock(),
            new ZBlock(), new IBlock(), new LBlock(), new OBlock(), new IBlock(), new LBlock(), new TBlock(), new TBlock(),
            new LBlock(), new SBlock(), new ZBlock(), new TBlock(), new SBlock(), new TBlock(), new IBlock(), new JBlock(),
            new OBlock(), new OBlock(), new OBlock(),
        };

        public readonly Block[] mosaicBlocksSix = new Block[]
        {
            new OBlock(),
            new JBlock(), new OBlock(), new TBlock(), new OBlock(), new TBlock(), new JBlock(), new IBlock(), new TBlock(),
            new OBlock(), new ZBlock(), new LBlock(), new ZBlock(), new JBlock(), new TBlock(), new OBlock(), new LBlock(),
            new ZBlock(), new LBlock(), new IBlock(), new JBlock(), new SBlock(), new JBlock(), new SBlock(), new SBlock(),
            new TBlock(), new OBlock(), new SBlock(), new ZBlock(), new JBlock(), new TBlock(), new LBlock(), new TBlock(),
            new OBlock(), new LBlock(), new LBlock(), new TBlock(), new ZBlock(), new OBlock(), new ZBlock(), new IBlock(),
            new OBlock(), new OBlock(), new OBlock(),
        };

        public readonly Block[] mosaicBlocksSeven = new Block[]
        {
            new OBlock(),
            new JBlock(), new LBlock(), new IBlock(), new OBlock(), new ZBlock(), new LBlock(), new LBlock(), new TBlock(),
            new TBlock(), new SBlock(), new TBlock(), new ZBlock(), new IBlock(), new ZBlock(), new TBlock(), new ZBlock(),
            new SBlock(), new LBlock(), new SBlock(), new IBlock(), new TBlock(), new TBlock(), new JBlock(), new OBlock(),
            new LBlock(), new OBlock(), new ZBlock(), new TBlock(), new IBlock(), new IBlock(), new LBlock(), new TBlock(),
            new LBlock(), new OBlock(), new LBlock(), new LBlock(), new LBlock(), new JBlock(), new JBlock(), new IBlock(),
            new OBlock(), new OBlock(), new OBlock(),
        };

        public readonly Block[] mosaicBlocksEight = new Block[]
        {
            new OBlock(),
            new IBlock(), new JBlock(), new SBlock(), new JBlock(), new ZBlock(), new SBlock(), new JBlock(), new JBlock(),
            new OBlock(), new LBlock(), new JBlock(), new ZBlock(), new SBlock(), new JBlock(), new OBlock(), new ZBlock(),
            new TBlock(), new LBlock(), new IBlock(), new LBlock(), new ZBlock(), new SBlock(), new OBlock(), new LBlock(),
            new OBlock(), new TBlock(), new SBlock(), new IBlock(), new TBlock(), new SBlock(), new TBlock(), new JBlock(),
            new ZBlock(), new JBlock(), new SBlock(), new IBlock(), new OBlock(), new SBlock(), new OBlock(), new LBlock(),
            new OBlock(), new OBlock(), new OBlock(),
        };

        public readonly Block[] mosaicBlocksNine = new Block[]
        {
            new OBlock(),
            new OBlock(), new TBlock(), new IBlock(), new TBlock(), new SBlock(), new SBlock(), new TBlock(), new TBlock(),
            new JBlock(), new TBlock(), new OBlock(), new ZBlock(), new SBlock(), new OBlock(), new IBlock(), new TBlock(),
            new SBlock(), new TBlock(), new OBlock(), new ZBlock(), new TBlock(), new SBlock(), new TBlock(), new JBlock(),
            new SBlock(), new OBlock(), new TBlock(), new JBlock(), new TBlock(), new TBlock(), new OBlock(), new TBlock(),
            new OBlock(), new ZBlock(), new OBlock(), new TBlock(), new IBlock(), new OBlock(), new LBlock(), new IBlock(),
            new OBlock(), new OBlock(), new OBlock(),
        };

        public readonly Block[] mosaicBlocksTen = new Block[]
        {
            new OBlock(),
            new IBlock(), new JBlock(), new TBlock(), new LBlock(), new SBlock(), new OBlock(), new SBlock(), new LBlock(),
            new LBlock(), new ZBlock(), new SBlock(), new TBlock(), new TBlock(), new OBlock(), new ZBlock(), new ZBlock(),
            new SBlock(), new LBlock(), new OBlock(), new TBlock(), new JBlock(), new JBlock(), new IBlock(), new ZBlock(),
            new JBlock(), new IBlock(), new ZBlock(), new TBlock(), new TBlock(), new LBlock(), new TBlock(), new OBlock(),
            new LBlock(), new JBlock(), new OBlock(), new JBlock(), new ZBlock(), new ZBlock(), new JBlock(), new TBlock(),
            new OBlock(), new OBlock(), new OBlock(),
        };

        public readonly Block[] mosaicBlocksEleven = new Block[]
        {
            new OBlock(),
            new IBlock(), new JBlock(), new ZBlock(), new SBlock(), new TBlock(), new OBlock(), new LBlock(), new IBlock(),
            new SBlock(), new JBlock(), new LBlock(), new ZBlock(), new TBlock(), new ZBlock(), new LBlock(), new OBlock(),
            new JBlock(), new SBlock(), new ZBlock(), new LBlock(), new TBlock(), new OBlock(), new TBlock(), new SBlock(),
            new ZBlock(), new IBlock(), new ZBlock(), new LBlock(), new JBlock(), new LBlock(), new TBlock(), new TBlock(),
            new IBlock(), new OBlock(), new OBlock(), new SBlock(), new LBlock(), new JBlock(), new ZBlock(), new JBlock(),
            new OBlock(), new OBlock(), new OBlock(),
        };

        public readonly Block[] mosaicBlocksTwelve = new Block[]
        {
            new OBlock(),
            new OBlock(), new JBlock(), new JBlock(), new SBlock(), new TBlock(), new SBlock(), new IBlock(), new JBlock(),
            new ZBlock(), new TBlock(), new LBlock(), new OBlock(), new ZBlock(), new TBlock(), new IBlock(), new SBlock(),
            new JBlock(), new LBlock(), new LBlock(), new TBlock(), new OBlock(), new ZBlock(), new LBlock(), new SBlock(),
            new ZBlock(), new TBlock(), new LBlock(), new TBlock(), new OBlock(), new TBlock(), new LBlock(), new SBlock(),
            new IBlock(), new LBlock(), new JBlock(), new TBlock(), new ZBlock(), new JBlock(), new LBlock(), new JBlock(),
            new OBlock(), new OBlock(), new OBlock(),
        };

        private int mosaicBlockIndex = 1;
        private int startBlockCheck = 0;

        private readonly Block[] blocks_mosaic = new Block[]
        {
            new OBlock_three(),
        };

        private readonly Random random = new Random();  // Используется для генерации случайных чисел
        public GameState types { get; set; }            // Хранит текущее состояние игры

        public Block NextBlock { get; private set; }    // Хранит информацию о следующем блоке

        public BlockQueue(GameState gameLines)          // Конструктор класса BlockQueue инициализирует свойство NextBlock первым блоком
        {
            types = gameLines;
            NextBlock = RandomBlock();
        }

        // Выбирает случайный блок
        private Block RandomBlock()  
        {
            if (types.gameOptions.TypeBlocks == 1) return blocks[random.Next(blocks.Length)];
            else if (types.gameOptions.TypeBlocks == 2) return blocks_three[random.Next(blocks_three.Length)];
            else if (types.gameOptions.TypeBlocks == 3) return blocks_pentomino[random.Next(blocks_pentomino.Length)];
            else if (types.gameOptions.GenerateMosaicType == 1) return mosaicBlocksOne[mosaicBlockIndex++];
            else if (types.gameOptions.GenerateMosaicType == 2) return mosaicBlocksTwo[mosaicBlockIndex++];
            else if (types.gameOptions.GenerateMosaicType == 3) return mosaicBlocksThree[mosaicBlockIndex++];
            else if (types.gameOptions.GenerateMosaicType == 4) return mosaicBlocksFour[mosaicBlockIndex++];
            else if (types.gameOptions.GenerateMosaicType == 5) return mosaicBlocksFive[mosaicBlockIndex++];
            else if (types.gameOptions.GenerateMosaicType == 6) return mosaicBlocksSix[mosaicBlockIndex++];
            else if (types.gameOptions.GenerateMosaicType == 7) return mosaicBlocksSeven[mosaicBlockIndex++];
            else if (types.gameOptions.GenerateMosaicType == 8) return mosaicBlocksEight[mosaicBlockIndex++];
            else if (types.gameOptions.GenerateMosaicType == 9) return mosaicBlocksNine[mosaicBlockIndex++];
            else if (types.gameOptions.GenerateMosaicType == 10) return mosaicBlocksTen[mosaicBlockIndex++];
            else if (types.gameOptions.GenerateMosaicType == 11) return mosaicBlocksEleven[mosaicBlockIndex++];
            else if (types.gameOptions.GenerateMosaicType == 12) return mosaicBlocksTwelve[mosaicBlockIndex++];
            else return blocks[random.Next(blocks.Length)];
        }

        // Возвращает текущий блок и обновляет его на следующий случайный блок, пока не будет выбран блок с другим ID
        public Block GetAndUpdate()  
        {
            Block block = NextBlock;
            
            if (types.gameOptions.MosaicModeFlag) NextBlock = RandomBlock();
            // Принудительный вызов Палки в режиме с Бустерами
            else if (types.gameOptions.TriminoModeFlag && types.gameOptions.GetSticklFlag)
            {
                NextBlock = new IBlock_three();
                types.gameOptions.GetSticklFlag = false;
            }
            else if (types.gameOptions.TetrominoModeFlag && types.gameOptions.GetSticklFlag)
            {
                NextBlock = new IBlock();
                types.gameOptions.GetSticklFlag = false;
            }
            else if (types.gameOptions.PentominoModeFlag && types.gameOptions.GetSticklFlag)
            {
                NextBlock = new IBlock_pentomino();
                types.gameOptions.GetSticklFlag = false;
            }
            // Ставит только устойчивые блоки первыми в режиме Спринт
            else if (types.gameOptions.IsMode == 3 || types.gameOptions.IsMode == 4 || types.gameOptions.IsMode == 5)
            {
                if (types.gameOptions.PentominoModeFlag)
                {
                    do
                    {
                        NextBlock = RandomBlock();
                    }
                    while (block.ID == NextBlock.ID || (startBlockCheck <= 1 && (NextBlock.ID == 4 || NextBlock.ID == 5 ||
                                                            NextBlock.ID == 8 || NextBlock.ID == 9 || NextBlock.ID == 12)));

                    startBlockCheck++;
                }
                else if (types.gameOptions.TetrominoModeFlag)
                {
                    do
                    {
                        NextBlock = RandomBlock();
                    }
                    while (block.ID == NextBlock.ID || (startBlockCheck <= 1 && (NextBlock.ID == 5 || NextBlock.ID == 7)));

                    startBlockCheck++;
                }
                else if (types.gameOptions.TriminoModeFlag)
                {
                    do
                    {
                        NextBlock = RandomBlock();
                    }
                    while (block.ID == NextBlock.ID || (startBlockCheck <= 1 && (NextBlock.ID == 2 || NextBlock.ID == 3 ||
                                                                                 NextBlock.ID == 5 || NextBlock.ID == 6)));

                    startBlockCheck++;
                }
            }
            else
            {
                do
                {
                    NextBlock = RandomBlock();
                }
                while (block.ID == NextBlock.ID);
            }

            return block;
        }
    }
}
