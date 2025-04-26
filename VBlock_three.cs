namespace Tetris_AI
{
    public class VBlock_three : Block  // Определение V-блока тримино
    {
        private readonly Position[][] tiles = new Position[][]  // Все положения поворота V-блока
        {
            new Position[] { new(1, 0), new(0, 1), new(1, 2)},
            new Position[] { new(0, 1), new(1, 2), new(2, 1)},
            new Position[] { new(1, 2), new(2, 1), new(1, 0)},
            new Position[] { new(0, 1), new(1, 0), new(2, 1)}
        };

        public override int ID => 6;  // Идентификатор V-блока
        protected override Position StartOffset => new Position(0, 3);  // Начальная позиция V-блока
        protected override Position[][] Tiles => tiles; // Начальное положение поворота V-блока
    }
}
