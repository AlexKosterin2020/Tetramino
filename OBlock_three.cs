namespace Tetris_AI
{
    public class OBlock_three : Block  // Определение O-блока тримино
    {
        private readonly Position[][] tiles = new Position[][]  // Все положения поворота O-блока
        {
            new Position[] { new(0, 0)}
        };

        public override int ID => 4;  // Идентификатор O-блока
        protected override Position StartOffset => new Position(0, 4);  // Начальная позиция O-блока
        protected override Position[][] Tiles => tiles; // Начальное положение поворота O-блока
    }
}
