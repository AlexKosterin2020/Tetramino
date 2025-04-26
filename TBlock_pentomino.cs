namespace Tetris_AI
{
    public class TBlock_pentomino : Block  // Определение T-блока пентомино
    {
        private readonly Position[][] tiles = new Position[][]  // Все положения поворота T-блока
        {
            new Position[] { new(0, 0), new(0, 1), new(0, 2), new(1, 1), new(2, 1)},
            new Position[] { new(0, 2), new(1, 2), new(2, 2), new(1, 1), new(1, 0)},
            new Position[] { new(2, 2), new(2, 1), new(2, 0), new(1, 1), new(0, 1)},
            new Position[] { new(2, 0), new(1, 0), new(0, 0), new(1, 1), new(1, 2)}
        };

        public override int ID => 11;  // Идентификатор T-блока
        protected override Position StartOffset => new Position(0, 5);  // Начальная позиция T-блока
        protected override Position[][] Tiles => tiles; // Начальное положение поворота T-блока
    }
}
