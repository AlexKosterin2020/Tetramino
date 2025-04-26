namespace Tetris_AI
{
    public class IBlock_three : Block  // Определение I-блока тримино
    {
        private readonly Position[][] tiles = new Position[][]  // Все положения поворота I-блока
        {
            new Position[] { new(1, 0), new(1, 1), new(1, 2)},
            new Position[] { new(0, 1), new(1, 1), new(2, 1)}
        };

        public override int ID => 1;  // Идентификатор I-блока
        protected override Position StartOffset => new Position(-1, 3);  // Начальная позиция I-блока
        protected override Position[][] Tiles => tiles; // Начальное положение поворота I-блока
    }
}
