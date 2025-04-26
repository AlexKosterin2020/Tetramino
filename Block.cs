using System.Collections.Generic;

namespace Tetris_AI
{
    public abstract class Block
    {
        protected abstract Position[][] Tiles { get; }      // Определяет форму блока в различных состояниях поворота
        protected abstract Position StartOffset { get; }    // Определяет начальную позицию блока при появлении на игровом поле
        public abstract int ID { get; }                     // Идентификатор типа блока
        //public abstract int Ids { get; }

        private int rotationState;                          // Хранит текущее состояние поворота блока
        private Position offset;                            // Хранит текущую позицию блока относительно его начальной позиции

        // Установка начальной позиции блока при его создании
        public Block()  
        {
            offset = new Position(StartOffset.Row, StartOffset.Column);
        }

        // Получения текущих позиций всех плиток блока на игровом поле
        public IEnumerable<Position> TilePositions()  
        {
            foreach(Position p in Tiles[rotationState])
            {
                yield return new Position(p.Row + offset.Row, p.Column + offset.Column);
            }
        }

        // Поворот блока по часовой стрелке
        public void RotateCW()   
        {
            rotationState = (rotationState + 1) % Tiles.Length;
        }

        // Поворот блока против часовой стрелки
        public void RotateCCW()  
        {
            if (rotationState == 0) rotationState = Tiles.Length - 1;
            else rotationState--;
        }

        // Перемещение блока по горизонтали и вертикали на заданное количество строк и столбцов
        public void Move(int rows, int columns) 
        {
            offset.Row += rows;
            offset.Column += columns;
        }

        // Сброс параметров положения блока в начальное положение для установки нового блока
        public void Reset()  
        {
            rotationState = 0;
            offset.Row = StartOffset.Row;
            offset.Column = StartOffset.Column;
        }
    }
}
