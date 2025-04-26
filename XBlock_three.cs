namespace Tetris_AI
{
    public class XBlock_three : Block  // Определение X-блока тримино
    {
        private readonly Position[][] tiles = new Position[][]  // Все положения поворота X-блока
        {
            new Position[] { new(0, 0), new(1, 1)},
            new Position[] { new(0, 1), new(1, 0)}
        };

        public override int ID => 5;  // Идентификатор X-блока
        protected override Position StartOffset => new Position(0, 4);  // Начальная позиция X-блока
        protected override Position[][] Tiles => tiles; // Начальное положение поворота X-блока
    }
}
