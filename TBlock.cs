namespace Tetris_AI
{
    public class TBlock : Block  // Определение T-блока тетрамино
    {
        private readonly Position[][] tiles = new Position[][]  // Все положения поворота T-блока
        {
            new Position[] { new(1, 0), new(1, 1), new(1, 2), new(0, 1)},
            new Position[] { new(0, 1), new(1, 1), new(2, 1), new(1, 2)},
            new Position[] { new(1, 2), new(1, 1), new(1, 0), new(2, 1)},
            new Position[] { new(2, 1), new(1, 1), new(0, 1), new(1, 0)}
        };

        public override int ID => 6;  // Идентификатор T-блока
        protected override Position StartOffset => new Position(0, 3);  // Начальная позиция T-блока
        protected override Position[][] Tiles => tiles; // Начальное положение поворота T-блока
    }
}
