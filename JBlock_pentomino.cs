namespace Tetris_AI
{
    public class JBlock_pentomino : Block  // Определение J-блока пентомино
    {
        private readonly Position[][] tiles = new Position[][]  // Все положения поворота J-блока
        {
            new Position[] { new(1, 0), new(2, 0), new(2, 1), new(2, 2), new(2, 3)},
            new Position[] { new(0, 2), new(0, 1), new(1, 1), new(2, 1), new(3, 1)},
            new Position[] { new(2, 3), new(1, 3), new(1, 2), new(1, 1), new(1, 0)},
            new Position[] { new(3, 1), new(3, 2), new(2, 2), new(1, 2), new(0, 2)}
        };

        public override int ID => 6;  // Идентификатор J-блока
        protected override Position StartOffset => new Position(-1, 5);  // Начальная позиция J-блока
        protected override Position[][] Tiles => tiles; // Начальное положение поворота J-блока
    }
}
