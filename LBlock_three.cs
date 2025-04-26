namespace Tetris_AI
{
    public class LBlock_three : Block  // Определение L-блока тримино
    {
        private readonly Position[][] tiles = new Position[][]  // Все положения поворота L-блока
        {
            new Position[] { new(0, 2), new(1, 1), new(1, 0)},
            new Position[] { new(2, 2), new(1, 1), new(0, 1)},
            new Position[] { new(2, 0), new(1, 1), new(1, 2)},
            new Position[] { new(0, 0), new(1, 1), new(2, 1)}
        };

        public override int ID => 3;  // Идентификатор L-блока
        protected override Position StartOffset => new Position(0, 3);  // Начальная позиция L-блока
        protected override Position[][] Tiles => tiles; // Начальное положение поворота L-блока
    }
}
