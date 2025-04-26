namespace Tetris_AI
{
    public class IBlock : Block  // Определение I-блока тетрамино
    {
        private readonly Position[][] tiles = new Position[][]  // Все положения поворота I-блока
        {
            new Position[] { new(1, 0), new(1, 1), new(1, 2), new(1, 3)},
            new Position[] { new(0, 2), new(1, 2), new(2, 2), new(3, 2)},
            new Position[] { new(2, 3), new(2, 2), new(2, 1), new(2, 0)},
            new Position[] { new(3, 1), new(2, 1), new(1, 1), new(0, 1)}
        };

        //public readonly int[] Ids = { 12, 4, 9, 1 };
        public override int ID => 1;  // Идентификатор I-блока
        protected override Position StartOffset => new Position(-1, 3);  // Начальная позиция I-блока
        protected override Position[][] Tiles => tiles; // Начальное положение поворота I-блока
    }
}
