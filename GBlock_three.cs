namespace Tetris_AI
{
    public class GBlock_three : Block  // Определение G-блока тримино
    {
        private readonly Position[][] tiles = new Position[][]  // Все положения поворота G-блока
        {
            new Position[] { new(0, 0), new(1, 0), new(1, 1)},
            new Position[] { new(1, 0), new(0, 0), new(0, 1)},
            new Position[] { new(0, 0), new(0, 1), new(1, 1)},
            new Position[] { new(0, 1), new(1, 1), new(1, 0)},
        };

        public override int ID => 7;  // Идентификатор G-блока
        protected override Position StartOffset => new Position(0, 4);  // Начальная позиция G-блока
        protected override Position[][] Tiles => tiles; // Начальное положение поворота G-блока
    }
}
