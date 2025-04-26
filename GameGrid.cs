namespace Tetris_AI
{
    public class GameGrid // Моделирование игрового поля
    {
        private readonly int[,] grid;   // Двумерный массив, который хранит состояние каждого элемента на игровом поле
        public int Rows { get; }        // Свойство, которые предоставляют доступ к количеству строк
        public int Columns { get; }     // Свойство, которые предоставляют доступ к количеству столбцов
        public GameState GameState { get; set; }

        // Индексатор: Позволяет обращаться к элементам массива grid напрямую через экземпляр класса GameGrid
        public int this[int r, int c] 
        {
            get => grid[r, c];
            set => grid[r, c] = value;
        }

        // Инициализация свойств и двумерного массива
        public GameGrid(int rows, int columns, GameState gameState)  
        {
            Rows = rows;
            Columns = columns;
            grid = new int[Rows, Columns];
            GameState = gameState;          // По другому не придумал как инициализировать gameState здесь
        }

        // Проверяет, находятся ли координаты (r, c) внутри границ игрового поля
        public bool IsInside(int r, int c) 
        {
            return r >= 0 && r < Rows && c >= 0 && c < Columns;
        }

        // Проверяет, является ли ячейка с координатами (r, c) пустой 
        public bool IsEmpty(int r, int c)  
        {
            return IsInside(r, c) && grid[r, c] == 0;
        }

        // Проверяет, полностью ли заполнена строка блоками
        public bool IsRowFull(int r)  
        {
            for (int c = 0; c < Columns; c++)
            {
                if (grid[r, c] == 0) return false;
            }

            return true;
        }

        // Проверяет, полностью ли строка пустая
        public bool IsRowEmpty(int r) 
        {
            for (int c = 0; c < Columns; c++)
            {
                if (grid[r, c] != 0) return false;
            }

            return true;
        }

        // Сжагание заполненой линии
        public void ClearRow(int r)  
        {
            for (int c = 0; c < Columns; c++)
            {
                grid[r, c] = 0;
            }
        }

        // Сдвигает линии вниз
        public void MoveRowDown(int r, int numRows)  
        {
            for (int c = 0; c < Columns; c++)
            {
                grid[r + numRows, c] = grid[r, c];
                grid[r, c] = 0;
            }
        }

        // Общая функция сжагания линий со сдвигом не заполненных линий
        public int ClearFullRows()  
        {
            int cleared = 0;

            for(int r = Rows - 1; r >= 0; r--)
            {
                if(IsRowFull(r))
                {
                    ClearRow(r);
                    cleared++;
                }
                else if(cleared > 0)
                {
                    MoveRowDown(r, cleared);
                }
            }

            return cleared;
        }

        // Проверяет, является ли ячейка с координатами (r, c) дыркой для закрытия в режиме с Бустерами (Аркада)
        public bool IsHoleCanClose(int r, int c)  
        {
            if (GameState.gameOptions.TriminoModeFlag)
            {
                if (r == 16 && c == 7) return IsInside(r, c) && grid[r, c] == 0 && grid[r - 1, c] != 0 && grid[r, c - 1] != 0;
                else if (r == 16 && c == 0) return IsInside(r, c) && grid[r, c] == 0 && grid[r - 1, c] != 0 && grid[r, c + 1] != 0;
                else if (r == 16) return IsInside(r, c) && grid[r, c] == 0 && grid[r - 1, c] != 0 && grid[r, c - 1] != 0 && grid[r, c + 1] != 0;
                else if (c == 0) return IsInside(r, c) && grid[r, c] == 0 && grid[r - 1, c] != 0 && grid[r + 1, c] != 0 && grid[r, c + 1] != 0;
                else if (c == 7) return IsInside(r, c) && grid[r, c] == 0 && grid[r - 1, c] != 0 && grid[r + 1, c] != 0 && grid[r, c - 1] != 0;
                else return IsInside(r, c) && grid[r, c] == 0 && grid[r - 1, c] != 0 && grid[r + 1, c] != 0 && grid[r, c - 1] != 0 && grid[r, c + 1] != 0;
            }
            else if (GameState.gameOptions.TetrominoModeFlag)
            {
                if (r == 21 && c == 9) return IsInside(r, c) && grid[r, c] == 0 && grid[r - 1, c] != 0 && grid[r, c - 1] != 0;
                else if (r == 21 && c == 0) return IsInside(r, c) && grid[r, c] == 0 && grid[r - 1, c] != 0 && grid[r, c + 1] != 0;
                else if (r == 21) return IsInside(r, c) && grid[r, c] == 0 && grid[r - 1, c] != 0 && grid[r, c - 1] != 0 && grid[r, c + 1] != 0;
                else if (c == 0) return IsInside(r, c) && grid[r, c] == 0 && grid[r - 1, c] != 0 && grid[r + 1, c] != 0 && grid[r, c + 1] != 0;
                else if (c == 9) return IsInside(r, c) && grid[r, c] == 0 && grid[r - 1, c] != 0 && grid[r + 1, c] != 0 && grid[r, c - 1] != 0;
                else return IsInside(r, c) && grid[r, c] == 0 && grid[r - 1, c] != 0 && grid[r + 1, c] != 0 && grid[r, c - 1] != 0 && grid[r, c + 1] != 0;
            }
            else if (GameState.gameOptions.PentominoModeFlag)
            {
                if (r == 23 && c == 13) return IsInside(r, c) && grid[r, c] == 0 && grid[r - 1, c] != 0 && grid[r, c - 1] != 0;
                else if (r == 23 && c == 0) return IsInside(r, c) && grid[r, c] == 0 && grid[r - 1, c] != 0 && grid[r, c + 1] != 0;
                else if (r == 23) return IsInside(r, c) && grid[r, c] == 0 && grid[r - 1, c] != 0 && grid[r, c - 1] != 0 && grid[r, c + 1] != 0;
                else if (c == 0) return IsInside(r, c) && grid[r, c] == 0 && grid[r - 1, c] != 0 && grid[r + 1, c] != 0 && grid[r, c + 1] != 0;
                else if (c == 13) return IsInside(r, c) && grid[r, c] == 0 && grid[r - 1, c] != 0 && grid[r + 1, c] != 0 && grid[r, c - 1] != 0;
                else return IsInside(r, c) && grid[r, c] == 0 && grid[r - 1, c] != 0 && grid[r + 1, c] != 0 && grid[r, c - 1] != 0 && grid[r, c + 1] != 0;
            }
            else return false;
        }
    }
}
