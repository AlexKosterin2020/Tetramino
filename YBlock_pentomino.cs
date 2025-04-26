namespace Tetris_AI
{
    public class YBlock_pentomino : Block  // Определение Y-блока пентомино
    {
        private readonly Position[][] tiles = new Position[][]  // Все положения поворота Y-блока
        {
            new Position[] { new(2, 3), new(2, 2), new(2, 1), new(2, 0), new(1, 2)},
            new Position[] { new(3, 1), new(2, 1), new(1, 1), new(0, 1), new(2, 2)},
            new Position[] { new(1, 0), new(1, 1), new(1, 2), new(1, 3), new(2, 1)},
            new Position[] { new(0, 2), new(1, 2), new(2, 2), new(3, 2), new(1, 1)}
        };

        public override int ID => 13;  // Идентификатор Y-блока
        protected override Position StartOffset => new Position(-1, 5);  // Начальная позиция Y-блока
        protected override Position[][] Tiles => tiles; // Начальное положение поворота Y-блока
    }
}
