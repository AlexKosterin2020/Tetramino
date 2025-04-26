namespace Tetris_AI
{
    public class IBlock_pentomino : Block  // Определение I-блока пентомино
    {
        private readonly Position[][] tiles = new Position[][]  // Все положения поворота I-блока
        {
            new Position[] { new(2, 0), new(2, 1), new(2, 2), new(2, 3), new(2, 4)},
            new Position[] { new(0, 2), new(1, 2), new(2, 2), new(3, 2), new(4, 2)}
        };

        public override int ID => 1;  // Идентификатор I-блока
        protected override Position StartOffset => new Position(-2, 4);  // Начальная позиция I-блока
        protected override Position[][] Tiles => tiles; // Начальное положение поворота I-блока
    }
}
