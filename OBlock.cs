namespace Tetris_AI
{
    public class OBlock : Block  // Определение O-блока тетрамино
    {
        private readonly Position[][] tiles = new Position[][]  // Все положения поворота O-блока
        {
            new Position[] { new(0, 0), new(0, 1), new(1, 1), new(1, 0)},
            new Position[] { new(0, 1), new(1, 1), new(1, 0), new(0, 0)},
            new Position[] { new(1, 1), new(1, 0), new(0, 0), new(0, 1)},
            new Position[] { new(1, 0), new(0, 0), new(0, 1), new(1, 1)}
        };

        public override int ID => 4;  // Идентификатор O-блока
        protected override Position StartOffset => new Position(0, 4);  // Начальная позиция O-блока
        protected override Position[][] Tiles => tiles; // Начальное положение поворота O-блока
    }
}
