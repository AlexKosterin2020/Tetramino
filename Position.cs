namespace Tetris_AI
{
    public class Position // Хранит информацию о позиции на игровом поле
    {
        public int Row {  get; set; }           // Координата x позиции на игровом поле
        public int Column { get; set; }         // Координата y позиции на игровом поле
        public Position(int row, int column)    // Создание нового экземпляра и установка начальных координат блока
        {
            Row = row;
            Column = column;
        }
    }
}
