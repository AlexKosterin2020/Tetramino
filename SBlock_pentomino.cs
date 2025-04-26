namespace Tetris_AI
{
    public class ZBlock_pentomino : Block  // Определение Z-блока пентомино
    {
        private readonly Position[][] tiles = new Position[][]  // Все положения поворота Z-блока
        {
            new Position[] { new(0, 0), new(0, 1), new(1, 1), new(2, 1), new(2, 2)},
            new Position[] { new(0, 2), new(1, 2), new(1, 1), new(1, 0), new(2, 0)}
        };

        public override int ID => 7;  // Идентификатор Z-блока
        protected override Position StartOffset => new Position(0, 5);  // Начальная позиция Z-блока
        protected override Position[][] Tiles => tiles; // Начальное положение поворота Z-блока
    }
}
