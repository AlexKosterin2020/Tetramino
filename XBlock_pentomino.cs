namespace Tetris_AI
{
    public class XBlock_pentomino : Block  // Определение X-блока пентомино
    {
        private readonly Position[][] tiles = new Position[][]  // Все положения поворота X-блока
        {
            new Position[] { new(0, 1), new(1, 1), new(2, 1), new(1, 0), new(1, 2)}
        };

        public override int ID => 7;  // Идентификатор X-блока
        protected override Position StartOffset => new Position(0, 5);  // Начальная позиция X-блока
        protected override Position[][] Tiles => tiles; // Начальное положение поворота X-блока
    }
}
