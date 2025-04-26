using System;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Tetris_AI
{
    public class Settings
    {
        public int BestPentominoClassicScore { get; set; }              // Хранит рекорд режима Пентомино Классика
        public int BestPentominoWithBoostersScore { get; set; }         // Хранит рекорд режима Пентомино с Бустерами
        public int BestTetrominoClassicScore { get; set; }              // Хранит рекорд режима Тетромино Классика
        public int BestTetrominoWithBoostersScore { get; set; }         // Хранит рекорд режима Тетромино с Бустерами
        public int BestTriminoClassicScore { get; set; }                // Хранит рекорд режима Тримино Классика
        public int BestTriminoWithBoostersScore { get; set; }           // Хранит рекорд режима Тримино с Бустерами
        public int BestOnlyTetrisScore { get; set; }                    // Хранит рекорд режима ОнлиТетрис
        public int BestSurvivalScore { get; set; }                      // Хранит рекорд режима Выживание
        //public int BestArcadeScore { get; set; }                      // Хранит рекорд режима Аркада
        public TimeSpan BestSprintPentominoTime { get; set; }           // Хранит рекорд режима Спринт Пентомино
        public TimeSpan BestSprintTetrominoTime { get; set; }           // Хранит рекорд режима Спринт Тетромино
        public TimeSpan BestSprintTriminoTime { get; set; }             // Хранит рекорд режима Спринт Тримино
        public TimeSpan BestSprintLineTime { get; set; }                // Хранит рекорд режима Спринт Тетромино
        public TimeSpan BestSprintPointTime { get; set; }               // Хранит рекорд режима Спринт Тетромино
        public int BestTampingScore { get; set; }                       // Хранит рекорд режима Утрамбовка
        public int QuantityGetStick { get; set; }                       // Хранит количество бустеров Палка
        public int QuantityCloseHoles { get; set; }                     // Хранит количество бустеров КлоусХолс
        public int QuantityDownwardShift { get; set; }                  // Хранит количество бустеров ДаунШифт
        public int QuantityEmptyGlass { get; set; }                     // Хранит количество бустеров Пустой стакан
        public bool GhostBlockFlag { get; set; }                        // Хранит состояние Призрака: ВКЛ/ВЫКЛ
        public bool HoldBlockFlag { get; set; }                         // Хранит cостояние Удержания блока: ВКЛ/ВЫКЛ
        public int Language { get; set; }                               // Хранит Язык:
                                                                        // 1 - Русский
                                                                        // 2 - English

        // Загружает настройки из файла Settings.dat
        public static Settings Load()
        {
            Settings settings = new Settings();

            try
            {
                using (StreamReader reader = new StreamReader("settings.dat"))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] parts = line.Split('=');
                        if (parts.Length == 2)
                        {
                            string key = parts[0].Trim();
                            string value = parts[1].Trim();

                            // Определяет какой рекорд нужно обновить
                            switch (key)
                            {
                                case "BestPentominoClassicScore":
                                    settings.BestPentominoClassicScore = int.Parse(value);
                                    break;
                                case "BestPentominoWithBoostersScore":
                                    settings.BestPentominoWithBoostersScore = int.Parse(value);
                                    break;
                                case "BestTetrominoClassicScore":
                                    settings.BestTetrominoClassicScore = int.Parse(value); // Преобразует строковое значение в целое число
                                    break;
                                case "BestTetrominoWithBoostersScore":
                                    settings.BestTetrominoWithBoostersScore = int.Parse(value);
                                    break;
                                case "BestTriminoClassicScore":
                                    settings.BestTriminoClassicScore = int.Parse(value);
                                    break;
                                case "BestTriminoWithBoostersScore":
                                    settings.BestTriminoWithBoostersScore = int.Parse(value);
                                    break;
                                case "BestOnlyTetrisScore":
                                    settings.BestOnlyTetrisScore = int.Parse(value);
                                    break;
                                case "BestSurvivalScore":
                                    settings.BestSurvivalScore = int.Parse(value);
                                    break;
                                /*case "BestArcadeScore":
                                    settings.BestArcadeScore = int.Parse(value);
                                    break;*/
                                case "BestSprintPentominoTime":
                                    settings.BestSprintPentominoTime = TimeSpan.Parse(value);
                                    break;
                                case "BestSprintTetrominoTime":
                                    settings.BestSprintTetrominoTime = TimeSpan.Parse(value);
                                    break;
                                case "BestSprintTriminoTime":
                                    settings.BestSprintTriminoTime = TimeSpan.Parse(value);
                                    break;
                                case "BestSprintLineTime":
                                    settings.BestSprintLineTime = TimeSpan.Parse(value);
                                    break;
                                case "BestSprintPointTime":
                                    settings.BestSprintPointTime = TimeSpan.Parse(value);
                                    break;
                                case "BestTampingScore":
                                    settings.BestTampingScore = int.Parse(value);
                                    break;
                                case "QuantityGetStick":
                                    settings.QuantityGetStick = int.Parse(value);
                                    break;
                                case "QuantityCloseHoles":
                                    settings.QuantityCloseHoles = int.Parse(value);
                                    break;
                                case "QuantityDownwardShift":
                                    settings.QuantityDownwardShift = int.Parse(value);
                                    break;
                                case "QuantityEmptyGlass":
                                    settings.QuantityEmptyGlass = int.Parse(value);
                                    break;
                                case "GhostBlockFlag":
                                    settings.GhostBlockFlag = bool.Parse(value);
                                    break;
                                case "HoldBlockFlag":
                                    settings.HoldBlockFlag = bool.Parse(value);
                                    break;
                                case "Language":
                                    settings.Language = int.Parse(value);
                                    break;
                            }
                        }
                    }
                }
            }

            // Если файл не существует или возникла ошибка, используем значения по умолчанию
            catch (Exception)
            {
                settings.BestPentominoClassicScore = 0;
                settings.BestPentominoWithBoostersScore = 0;
                settings.BestTetrominoClassicScore = 0;
                settings.BestTetrominoWithBoostersScore = 0;
                settings.BestTriminoClassicScore = 0;
                settings.BestTriminoWithBoostersScore = 0;
                settings.BestOnlyTetrisScore = 0;
                settings.BestSurvivalScore = 0;
                //settings.BestArcadeScore = 0;
                settings.BestSprintPentominoTime = TimeSpan.Zero;
                settings.BestSprintTetrominoTime = TimeSpan.Zero;
                settings.BestSprintTriminoTime = TimeSpan.Zero;
                settings.BestSprintLineTime = TimeSpan.Zero;
                settings.BestSprintPointTime = TimeSpan.Zero;
                settings.BestTampingScore = 0;
                settings.QuantityGetStick = 0;
                settings.QuantityCloseHoles = 0;
                settings.QuantityDownwardShift = 0;
                settings.QuantityEmptyGlass = 0;
                settings.GhostBlockFlag = true;
                settings.HoldBlockFlag = true;
                settings.Language = 1;
            }

            return settings;
        }

        // Сохраняет текущие настройки в файл Settings.dat
        // Обновляет новый рекорд
        public static void Save(Settings settings)
        {
            using (StreamWriter writer = new StreamWriter("settings.dat"))
            {
                writer.WriteLine($"BestPentominoClassicScore={settings.BestPentominoClassicScore}");
                writer.WriteLine($"BestPentominoWithBoostersScore={settings.BestPentominoWithBoostersScore}");
                writer.WriteLine($"BestTetrominoClassicScore={settings.BestTetrominoClassicScore}");
                writer.WriteLine($"BestTetrominoWithBoostersScore={settings.BestTetrominoWithBoostersScore}");
                writer.WriteLine($"BestTriminoClassicScore={settings.BestTriminoClassicScore}");
                writer.WriteLine($"BestTriminoWithBoostersScore={settings.BestTriminoWithBoostersScore}");
                writer.WriteLine($"BestOnlyTetrisScore={settings.BestOnlyTetrisScore}");
                writer.WriteLine($"BestSurvivalScore={settings.BestSurvivalScore}");
                //writer.WriteLine($"BestArcadeScore={settings.BestArcadeScore}");
                writer.WriteLine($"BestSprintPentominoTime={settings.BestSprintPentominoTime}");
                writer.WriteLine($"BestSprintTetrominoTime={settings.BestSprintTetrominoTime}");
                writer.WriteLine($"BestSprintTriminoTime={settings.BestSprintTriminoTime}");
                writer.WriteLine($"BestSprintLineTime={settings.BestSprintLineTime}");
                writer.WriteLine($"BestSprintPointTime={settings.BestSprintPointTime}");
                writer.WriteLine($"BestTampingScore={settings.BestTampingScore}");
                writer.WriteLine($"QuantityGetStick={settings.QuantityGetStick}");
                writer.WriteLine($"QuantityCloseHoles={settings.QuantityCloseHoles}");
                writer.WriteLine($"QuantityDownwardShift={settings.QuantityDownwardShift}");
                writer.WriteLine($"QuantityEmptyGlass={settings.QuantityEmptyGlass}");
                writer.WriteLine($"GhostBlockFlag={settings.GhostBlockFlag}");
                writer.WriteLine($"HoldBlockFlag={settings.HoldBlockFlag}");
                writer.WriteLine($"Language={settings.Language}");
            }
        }
    }
}