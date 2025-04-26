namespace Tetris_AI
{
    public class JBlock : Block  // Определение J-блока тетрамино
    {
        private readonly Position[][] tiles = new Position[][]  // Все положения поворота J-блока
        {
            new Position[] { new(0, 0), new(1, 0), new(1, 1), new(1, 2)},
            new Position[] { new(0, 2), new(0, 1), new(1, 1), new(2, 1)},
            new Position[] { new(2, 2), new(1, 2), new(1, 1), new(1, 0)},
            new Position[] { new(2, 0), new(2, 1), new(1, 1), new(0, 1)}
        };

        public override int ID => 2;  // Идентификатор J-блока
        protected override Position StartOffset => new Position(0, 3);  // Начальная позиция J-блока
        protected override Position[][] Tiles => tiles; // Начальное положение поворота J-блока
    }
}
