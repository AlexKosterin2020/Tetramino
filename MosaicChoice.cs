using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Tetris_AI
{
    public class MosaicChoice
    {
        public GameState GameState { get; set; }

        public MosaicChoice(GameState gameMosaic)
        {
            GameState = gameMosaic;
        }

        public int[] mosaicIndexsOne = { 0,         // Блок-заглушка
                                        1, 2, 3, 12, 40, 30, 20, 10, 13, 14, 4, 5, 17, 7, 8, 9, 28, 29, 19, 18, 27, 37, 38, 39, 25, 15,
                                        16, 6, 35, 34, 24, 23, 45, 46, 36, 26, 11, 21, 22, 32, 44, 43, 42, 33, 56, 57, 47, 48, 52, 51,
                                        41, 31, 59, 60, 50, 49, 69, 68, 67, 58, 55, 65, 66, 76, 63, 64, 54, 53, 78, 77, 87, 97, 73, 72,
                                        62, 61, 89, 79, 80, 70, 109, 99, 100, 90, 118, 108, 98, 88, 91, 81, 71, 82, 86, 85, 75, 74, 83,
                                        84, 94, 104, 102, 103, 93, 92, 116, 106, 96, 107, 101, 111, 112, 113, 129, 119, 120, 110, 114, 115,
                                        105, 95, 121, 122, 123, 124, 130, 140, 150, 139, 131, 132, 133, 142, 117, 127, 126, 125, 149, 148, 138,
                                        128, 143, 144, 134, 135, 146, 147, 137, 136, 141, 151, 152, 153, 157, 158, 159, 160, 156, 155, 154, 145,
                                        156, 155, 154, 145, 0, 0, 0, 0, 0};   // Блоки-заглушки

        public int[] mosaicIndexsTwo = { 0,         // Блок-заглушка
                                        19, 20, 10, 9, 11, 12, 2, 1, 13, 3, 4, 5, 18, 8, 7, 6, 16, 17, 27, 37, 26, 25, 15, 14, 29, 28, 38,
                                        48, 30, 40, 50, 39, 21, 22, 23, 24, 41, 31, 32, 33, 60, 59, 58, 49, 80, 70, 69, 68, 34, 35, 36, 45,
                                        51, 52, 42, 43, 46, 47, 57, 67, 55, 54, 53, 44, 56, 66, 76, 65, 77, 78, 79, 88, 91, 81, 71, 61, 72,
                                        62, 63, 64, 84, 85, 75, 74, 89, 90, 100, 110, 92, 82, 83, 73, 86, 96, 106, 95, 87, 97, 98, 99, 109,
                                        119, 120, 130, 105, 104, 94, 93, 117, 118, 108, 107, 101, 102, 103, 112,  122, 123, 113, 114, 116,
                                        115, 125, 135, 126, 127, 128, 137, 132, 131, 121, 111, 129, 139, 140, 150, 143, 133, 134, 124, 149,
                                        148, 147, 138, 153, 154, 144, 145, 157, 158, 159, 160, 155, 156, 146, 136, 151, 152, 142, 141,
                                        151, 152, 142, 141, 0, 0, 0, 0, 0};   // Блоки-заглушки

        public int[] mosaicIndexsThree = { 0,         // Блок-заглушка
                                        8, 9, 10, 19, 4, 5, 6, 7, 11, 1, 2, 3, 26, 16, 17, 18, 24, 25, 15, 14, 20, 30, 29, 28, 21, 22, 12,
                                        13, 34, 33, 32, 23, 54, 44, 45, 35, 38, 37, 36, 27, 31, 41, 42, 43, 48, 49, 39, 40, 56, 57, 47, 46,
                                        50, 60, 59, 58, 100, 90, 80, 70, 51, 52, 53, 62, 55, 65, 64, 63, 61, 71, 72, 82, 75, 76, 66, 67, 83,
                                        84, 74, 73, 87, 77, 78, 68, 81, 91, 92, 93, 97, 96, 86, 85, 88, 89, 79, 69, 94, 95, 105, 115, 108, 109,
                                        99, 98, 110, 120, 130, 119, 101, 102, 103, 104, 121, 111, 112, 113, 107, 106, 116, 126, 129, 128, 118,
                                        117, 138, 139, 140, 149, 134, 124, 114, 125, 148, 147, 137, 127, 132, 133, 123, 122, 145, 146, 136, 135,
                                        150, 160, 159, 158, 151, 141, 131, 142, 152, 153, 143, 144, 154, 155, 156, 157,
                                        154, 155, 156, 157, 0, 0, 0, 0, 0};   // Блоки-заглушки

        public int[] mosaicIndexsFour = { 0,         // Блок-заглушка
                                        20, 10, 9, 8,  5, 6, 7, 16, 15, 14, 4, 3, 28, 29, 19, 18, 13, 12, 2, 1, 17, 27, 26, 25, 49, 39, 40,
                                        30, 11, 21, 22, 23, 43, 33, 34, 24, 41, 42, 32, 31, 54, 44, 45, 35, 46, 36, 37, 38, 61, 51, 52, 53,
                                        59, 58, 48, 47, 80, 70, 60, 50, 67, 57, 56, 55, 64, 65, 66, 75, 69, 68, 78, 88, 85, 86, 76, 77, 74,
                                        73, 63, 62, 99, 89, 79, 90, 81, 82, 72, 71, 83, 93, 92, 91, 107, 97, 87, 98, 130, 120, 110, 100, 105,
                                        106, 96, 95, 103, 104, 94, 84, 118, 119, 109, 108, 113, 112, 102, 101, 116, 117, 127, 137, 126, 125,
                                        115, 114, 111, 121, 122, 123, 140, 139, 129, 128, 124, 134, 135, 145, 131, 132, 133, 142, 138, 148,
                                        149, 150, 155, 154, 144, 143, 156, 146, 136, 147, 141, 151, 152, 153, 157, 158, 159, 160,
                                        157, 158, 159, 160, 0, 0, 0, 0, 0};   // Блоки-заглушки

        public int[] mosaicIndexsFive = { 0,         // Блок-заглушка
                                        20, 10, 9, 8, 1, 2, 3, 4, 5, 6, 7, 16, 25, 15, 14, 13, 27, 17, 18, 19, 23, 22, 12, 11, 51, 41, 31,
                                        21, 28, 29, 30, 39, 42, 43, 33, 32, 26, 36, 37, 38, 24, 34, 35, 45, 70, 60, 50, 40, 59, 49, 48, 47,
                                        57, 56, 55, 46, 65, 64, 54, 44, 58, 68, 69, 79, 52, 53, 63, 73, 76, 77, 67, 66, 110, 100, 90, 80, 71,
                                        72, 62, 61, 84, 85, 75, 74, 78, 88, 98, 87, 94, 93, 83, 82, 108, 109, 99, 89, 86, 96, 97, 107, 111,
                                        101, 91, 81, 92, 102, 103, 104, 129, 130, 120, 119, 125, 115, 105, 95, 106, 116, 117, 118, 112, 113,
                                        114, 123, 126, 127, 128, 137, 124, 134, 135, 136, 133, 132, 122, 121, 147, 148, 138, 139, 144, 145,
                                        146, 155, 154, 153, 143, 142, 140, 150, 160, 149, 156, 157, 158, 159, 152, 151, 141, 131,
                                        152, 151, 141, 131, 0, 0, 0, 0, 0};   // Блоки-заглушки

        public int[] mosaicIndexsSix = { 0,         // Блок-заглушка
                                        11, 1, 2, 3, 19, 20, 10, 9, 4, 5, 6, 15, 22, 23, 13, 12, 7, 17, 27, 16, 29, 28, 18, 8, 44, 34, 24,
                                        14, 30, 40, 50, 39, 35, 36, 26, 25, 46, 47, 37, 38, 21, 31, 32, 33, 57, 58, 48, 49, 51, 41, 42, 43,
                                        56, 55, 54, 45, 69, 70, 60, 59, 68, 78, 79, 80, 61, 62, 52, 53, 100, 90, 89, 88, 97, 87, 77, 67, 65,
                                        66, 76, 86, 75, 74, 64, 63, 81, 71, 72, 73, 110, 109, 99, 98, 101, 91, 92, 82, 83, 84, 85, 94, 105,
                                        106, 96, 95, 112, 102, 103, 93, 116, 117, 107, 108, 119, 120, 130, 140, 115, 114, 113, 104, 111, 121,
                                        122, 123, 129, 128, 127, 118, 134, 135, 125, 124, 126, 136, 137, 138, 143, 133, 132, 131, 150, 149,
                                        148, 139, 153, 154, 144, 145, 151, 152, 142, 141, 155, 156, 146, 147, 157, 158, 159, 160,
                                        157, 158, 159, 160, 0, 0, 0, 0, 0};   // Блоки-заглушки

        public int[] mosaicIndexsSeven = { 0,         // Блок-заглушка
                                        11, 1, 2, 3, 16, 6, 5, 4, 40, 30, 20, 10, 17, 18, 8, 7, 21, 22, 12, 13, 28, 29, 19, 9, 15, 14, 24,
                                        34, 25, 26, 27, 36, 37, 38, 39, 48, 54, 44, 45, 35, 23, 33, 43, 32, 55, 56, 46, 47, 61, 51, 41, 31,
                                        58, 59, 49, 50, 68, 67, 66, 57, 42, 52, 53, 63, 79, 69, 70, 60, 65, 64, 74, 84, 81, 71, 72, 62, 75,
                                        76, 77, 78, 73, 83, 93, 82, 80, 90, 100, 89, 85, 86, 96, 106, 101, 102, 92, 91, 88, 87, 97, 107, 108,
                                        109, 99, 98, 103, 104, 94, 95, 125, 115, 105, 116, 140, 130, 120, 110, 111, 112, 113, 114, 129, 119,
                                        118, 117, 126, 127, 128, 137, 124, 134, 135, 136, 148, 149, 139, 138, 133, 123, 122, 121, 132, 131,
                                        141, 151, 157, 147, 146, 145,  150, 160, 159, 158, 152, 142, 143, 144, 153, 154, 155, 156,
                                        153, 154, 155, 156, 0, 0, 0, 0, 0};   // Блоки-заглушки

        public int[] mosaicIndexsEight = { 0,         // Блок-заглушка
                                        40, 30, 20, 10, 8, 9, 19, 29, 18, 17, 7, 6, 11, 1, 2, 3, 5, 15, 16, 26, 39, 38, 28, 27, 25, 24, 14,
                                        4, 36, 37, 47, 57, 22, 23, 13, 12, 21, 31, 32, 33, 58, 48, 49, 50, 43, 44, 34, 35, 53, 52, 42, 41, 45,
                                        46, 56, 66, 64, 65, 55, 54, 68, 69, 59, 60, 71, 61, 51, 62, 67, 77, 78, 79, 100, 90, 80, 70, 63, 73,
                                        74, 75, 76, 86, 87, 97, 91, 81, 82, 72, 98, 99, 89, 88, 120, 110, 109, 108, 93, 94, 84, 83, 116, 106,
                                        96, 107, 130, 129, 119, 118, 115, 105, 95, 85, 103, 102, 101, 92, 123, 113, 114, 104, 137, 127, 117,
                                        128, 111, 112, 122, 132, 133, 134, 124, 125, 148, 138, 139, 140, 145, 135, 136, 126, 151, 141, 131,
                                        121, 152, 153, 143, 142, 158, 157, 147, 146, 159, 160, 150, 149, 144, 154, 155, 156,
                                        144, 154, 155, 156, 0, 0, 0, 0, 0};   // Блоки-заглушки

        public int[] mosaicIndexsNine = { 0,         // Блок-заглушка
                                        11, 12, 2, 1, 3, 4, 5, 14, 6, 7, 8, 9, 10, 20, 30, 19, 32, 22, 23, 13, 29, 28, 18, 17, 15, 25, 35, 24,
                                        36, 26, 16, 27, 42, 41, 31, 21, 38, 39, 40, 49, 43, 44, 34, 33, 37, 47, 48, 58, 57, 56, 46, 45, 61, 62,
                                        52, 51, 80, 70, 60, 50, 53, 54, 55, 64, 78, 68, 69, 59, 63, 73, 83, 72, 76, 77, 67, 66, 71, 81, 82, 92,
                                        90, 89, 88, 79, 84, 74, 75, 65, 85, 86, 87, 96, 107, 97, 98, 99, 119, 109, 110, 100, 103, 104, 94, 93,
                                        115, 105, 95, 106, 108, 118, 117, 116, 111, 101, 91, 102, 112, 113, 114, 123, 131, 132, 122, 121, 120,
                                        130, 140, 129, 137, 138, 128, 127, 139, 149, 150, 160, 135, 136, 126, 125, 124, 134, 144, 133, 145, 146,
                                        147, 148, 151, 152, 142, 141, 143, 153, 154, 155, 156, 157, 158, 159,
                                        156, 157, 158, 159, 0, 0, 0, 0, 0};   // Блоки-заглушки

        public int[] mosaicIndexsTen = { 0,         // Блок-заглушка
                                        31, 21, 11, 1, 12, 2, 3, 4, 8, 9, 10, 19, 17, 7, 6, 5, 39, 29, 30, 20, 23, 24, 14, 13, 27, 26, 16, 15,
                                        41, 42, 32, 22, 37, 38, 28, 18, 25, 35, 36, 46, 45, 44, 34, 33, 40, 50, 60, 49, 54, 53, 52, 43, 57, 58,
                                        48, 47, 64, 65, 55, 56, 51, 61, 62, 72, 78, 68, 69, 59, 82, 83, 73, 63, 76, 77, 67, 66, 70, 80, 90, 79,
                                        74, 75, 85, 95, 92, 91, 81, 71, 86, 87, 88, 89, 105, 106, 96, 97, 99, 100, 110, 120, 114, 104, 94, 84,
                                        98, 108, 109, 119, 93, 103, 113, 102, 127, 117, 107, 118, 140, 130, 129, 128, 121, 111, 101, 112, 125,
                                        126, 116, 115, 134, 124, 123, 122, 141, 131, 132, 133, 148, 149, 139, 138, 136, 137, 147, 157, 151, 152,
                                        142, 143, 135, 145, 146, 156, 150, 160, 159, 158, 155, 154, 153, 144,
                                        155, 154, 153, 144, 0, 0, 0, 0, 0};   // Блоки-заглушки

        public int[] mosaicIndexsEleven = { 0,         // Блок-заглушка
                                        1, 2, 3, 4, 9, 10, 20, 30, 14, 15, 5, 6, 19, 18, 8, 7, 11, 12, 13, 22, 26, 27, 17, 16, 35, 25, 24, 23,
                                        51, 41, 31, 21, 40, 39, 29, 28, 46, 36, 37, 38, 33, 32, 42, 52, 34, 44, 45, 55, 63, 53, 43, 54, 56, 57,
                                        47, 48, 62, 61, 71, 81, 59, 60, 50, 49, 58, 68, 67, 66, 76, 75, 65, 64, 78, 79, 69, 70, 84, 74, 73, 72,
                                        88, 87, 86, 77, 92, 93, 83, 82, 80, 90, 100, 89, 104, 94, 95, 85, 91, 101, 102, 112, 96, 97, 98, 99, 114,
                                        115, 105, 106, 120, 110, 109, 108, 124, 123, 113, 103, 107, 117, 118, 119, 127, 126, 125, 116, 131, 121,
                                        111, 122, 160, 150, 140, 130, 138, 139, 129, 128, 142, 143, 133, 132, 148, 147, 137, 136, 141, 151, 152,
                                        153, 149, 159, 158, 157, 135, 145, 146, 156, 155, 154, 144, 134,
                                        155, 154, 144, 134, 0, 0, 0, 0, 0};   // Блоки-заглушки

        public int[] mosaicIndexsTwelve = { 0,         // Блок-заглушка
                                        19, 20, 10, 9, 7, 8, 18, 28, 11, 1, 2, 3, 17, 16, 6, 5, 15, 14, 13, 4, 31, 21, 22, 12, 24, 25, 26, 27,
                                        29, 39, 38, 37, 23, 33, 34, 44, 32, 42, 52, 41, 49, 50, 40, 30, 45, 46, 36, 35, 56, 57, 47, 48, 58, 59,
                                        60, 69, 81, 71, 61, 51, 66, 65, 55, 54, 64, 63, 53, 43, 68, 67, 77, 87, 62, 72, 73, 74, 70, 80, 90, 79,
                                        85, 86, 76, 75, 78, 88, 89, 99, 94, 84, 83, 82, 109, 108, 98, 97, 104, 105, 95, 96, 91, 92, 93, 102, 119,
                                        120, 110, 100, 121, 111, 101, 112, 116, 117, 107, 106, 129, 128, 127, 118, 103, 113, 114, 115, 149, 139,
                                        140, 130, 123, 124, 125, 126, 122, 132, 133, 134, 146, 136, 137, 138, 142, 143, 144, 153, 156, 157, 147,
                                        148, 152, 151, 141, 131, 154, 155, 145, 135, 150, 160, 159, 158,
                                        150, 160, 159, 158, 0, 0, 0, 0, 0};   // Блоки-заглушки

        // Формула нахождения нужного блока по индексу: ((Индекс - 1) / 4) + 1
        // Выбор поворота блоков для установки изображения в режиме Мозаика
        public void RotateMosaicBlocks()
        {
            // 1111111111111111111111111111111111111111111111
            if (GameState.gameOptions.GenerateMosaicType == 1)
            {
                if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksOne[2]) GameState.CurrentBlock.RotateCW();
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksOne[6])
                {
                    GameState.CurrentBlock.RotateCW();
                    GameState.CurrentBlock.RotateCW();
                }
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksOne[7]) GameState.CurrentBlock.RotateCCW();
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksOne[9]) GameState.CurrentBlock.RotateCCW();
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksOne[10]) GameState.CurrentBlock.RotateCCW();
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksOne[11])
                {
                    GameState.CurrentBlock.RotateCW();
                    GameState.CurrentBlock.RotateCW();
                }
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksOne[13]) GameState.CurrentBlock.RotateCW();
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksOne[15])
                {
                    GameState.CurrentBlock.RotateCW();
                    GameState.CurrentBlock.RotateCW();
                }
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksOne[16]) GameState.CurrentBlock.RotateCCW();
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksOne[18]) GameState.CurrentBlock.RotateCW();
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksOne[20]) GameState.CurrentBlock.RotateCCW();
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksOne[21]) GameState.CurrentBlock.RotateCCW();
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksOne[22]) GameState.CurrentBlock.RotateCW();
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksOne[23]) GameState.CurrentBlock.RotateCW();
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksOne[25]) GameState.CurrentBlock.RotateCCW();
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksOne[27]) GameState.CurrentBlock.RotateCW();
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksOne[28])
                {
                    GameState.CurrentBlock.RotateCW();
                    GameState.CurrentBlock.RotateCW();
                }
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksOne[29]) GameState.CurrentBlock.RotateCCW();
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksOne[30]) GameState.CurrentBlock.RotateCCW();
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksOne[32]) GameState.CurrentBlock.RotateCCW();
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksOne[34])
                {
                    GameState.CurrentBlock.RotateCW();
                    GameState.CurrentBlock.RotateCW();
                }
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksOne[35]) GameState.CurrentBlock.RotateCW();
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksOne[38])
                {
                    GameState.CurrentBlock.RotateCW();
                    GameState.CurrentBlock.RotateCW();
                }
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksOne[40])
                {
                    GameState.CurrentBlock.RotateCW();
                    GameState.CurrentBlock.RotateCW();
                }
            }

            // 222222222222222222222222222222222222222222222222222
            else if (GameState.gameOptions.GenerateMosaicType == 2)
            {
                if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksTwo[5]) GameState.CurrentBlock.RotateCCW();
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksTwo[7]) GameState.CurrentBlock.RotateCW();
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksTwo[8]) GameState.CurrentBlock.RotateCCW();
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksTwo[11])
                {
                    GameState.CurrentBlock.RotateCW();
                    GameState.CurrentBlock.RotateCW();
                }
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksTwo[15]) GameState.CurrentBlock.RotateCCW();
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksTwo[16])
                {
                    GameState.CurrentBlock.RotateCW();
                    GameState.CurrentBlock.RotateCW();
                }
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksTwo[17]) GameState.CurrentBlock.RotateCCW();
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksTwo[19]) GameState.CurrentBlock.RotateCW();
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksTwo[22]) GameState.CurrentBlock.RotateCCW();
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksTwo[23]) GameState.CurrentBlock.RotateCCW();
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksTwo[24]) GameState.CurrentBlock.RotateCCW();
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksTwo[25])
                {
                    GameState.CurrentBlock.RotateCW();
                    GameState.CurrentBlock.RotateCW();
                }
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksTwo[26]) GameState.CurrentBlock.RotateCCW();
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksTwo[31]) GameState.CurrentBlock.RotateCW();
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksTwo[33]) GameState.CurrentBlock.RotateCW();
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksTwo[34]) GameState.CurrentBlock.RotateCCW();
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksTwo[35]) GameState.CurrentBlock.RotateCCW();
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksTwo[36])
                {
                    GameState.CurrentBlock.RotateCW();
                    GameState.CurrentBlock.RotateCW();
                }
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksTwo[39]) GameState.CurrentBlock.RotateCCW();
            }

            // 333333333333333333333333333333333333333333333333333
            else if (GameState.gameOptions.GenerateMosaicType == 3)
            {
                if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksThree[6])
                {
                    GameState.CurrentBlock.RotateCW();
                    GameState.CurrentBlock.RotateCW();
                }
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksThree[8])
                {
                    GameState.CurrentBlock.RotateCW();
                    GameState.CurrentBlock.RotateCW();
                }
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksThree[9]) GameState.CurrentBlock.RotateCCW();
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksThree[10])
                {
                    GameState.CurrentBlock.RotateCW();
                    GameState.CurrentBlock.RotateCW();
                }
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksThree[11])
                {
                    GameState.CurrentBlock.RotateCW();
                    GameState.CurrentBlock.RotateCW();
                }
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksThree[14])
                {
                    GameState.CurrentBlock.RotateCW();
                    GameState.CurrentBlock.RotateCW();
                }
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksThree[15]) GameState.CurrentBlock.RotateCW();
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksThree[17])
                {
                    GameState.CurrentBlock.RotateCW();
                    GameState.CurrentBlock.RotateCW();
                }
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksThree[18]) GameState.CurrentBlock.RotateCCW();
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksThree[21]) GameState.CurrentBlock.RotateCCW();
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksThree[22])
                {
                    GameState.CurrentBlock.RotateCW();
                    GameState.CurrentBlock.RotateCW();
                }
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksThree[24]) GameState.CurrentBlock.RotateCCW();
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksThree[25]) GameState.CurrentBlock.RotateCCW();
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksThree[27]) GameState.CurrentBlock.RotateCCW();
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksThree[30]) GameState.CurrentBlock.RotateCW();
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksThree[33]) GameState.CurrentBlock.RotateCW();
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksThree[34]) GameState.CurrentBlock.RotateCW();
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksThree[37])
                {
                    GameState.CurrentBlock.RotateCW();
                    GameState.CurrentBlock.RotateCW();
                }
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksThree[38]) GameState.CurrentBlock.RotateCW();
            }

            // 4444444444444444444444444444444444444444444444444444
            else if (GameState.gameOptions.GenerateMosaicType == 4)
            {
                if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksFour[6])
                {
                    GameState.CurrentBlock.RotateCW();
                    GameState.CurrentBlock.RotateCW();
                }
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksFour[7]) GameState.CurrentBlock.RotateCCW();
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksFour[8])
                {
                    GameState.CurrentBlock.RotateCW();
                    GameState.CurrentBlock.RotateCW();
                }
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksFour[9]) GameState.CurrentBlock.RotateCCW();
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksFour[11]) GameState.CurrentBlock.RotateCCW();
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksFour[15]) GameState.CurrentBlock.RotateCW();
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksFour[18]) GameState.CurrentBlock.RotateCW();
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksFour[21]) GameState.CurrentBlock.RotateCW();
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksFour[23])
                {
                    GameState.CurrentBlock.RotateCW();
                    GameState.CurrentBlock.RotateCW();
                }
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksFour[24]) GameState.CurrentBlock.RotateCW();
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksFour[25]) GameState.CurrentBlock.RotateCW();
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksFour[27]) GameState.CurrentBlock.RotateCCW();
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksFour[30]) GameState.CurrentBlock.RotateCCW();
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksFour[32])
                {
                    GameState.CurrentBlock.RotateCW();
                    GameState.CurrentBlock.RotateCW();
                }
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksFour[34]) GameState.CurrentBlock.RotateCCW();
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksFour[36])
                {
                    GameState.CurrentBlock.RotateCW();
                    GameState.CurrentBlock.RotateCW();
                }
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksFour[38]) GameState.CurrentBlock.RotateCW();
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksFour[39])
                {
                    GameState.CurrentBlock.RotateCW();
                    GameState.CurrentBlock.RotateCW();
                }
            }

            // 5555555555555555555555555555555555555555555555555555
            else if (GameState.gameOptions.GenerateMosaicType == 5)
            {
                if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksFive[7]) GameState.CurrentBlock.RotateCW();
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksFive[10])
                {
                    GameState.CurrentBlock.RotateCW();
                    GameState.CurrentBlock.RotateCW();
                }
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksFive[11]) GameState.CurrentBlock.RotateCCW();
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksFive[12]) GameState.CurrentBlock.RotateCW();
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksFive[14])
                {
                    GameState.CurrentBlock.RotateCW();
                    GameState.CurrentBlock.RotateCW();
                }
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksFive[15]) GameState.CurrentBlock.RotateCW();
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksFive[16]) GameState.CurrentBlock.RotateCCW();
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksFive[17]) GameState.CurrentBlock.RotateCCW();
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksFive[19]) GameState.CurrentBlock.RotateCW();
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksFive[22]) GameState.CurrentBlock.RotateCCW();
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksFive[24]) GameState.CurrentBlock.RotateCCW();
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksFive[25]) GameState.CurrentBlock.RotateCCW();
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksFive[26]) GameState.CurrentBlock.RotateCW();
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksFive[27])
                {
                    GameState.CurrentBlock.RotateCW();
                    GameState.CurrentBlock.RotateCW();
                }
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksFive[29]) GameState.CurrentBlock.RotateCW();
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksFive[30])
                {
                    GameState.CurrentBlock.RotateCW();
                    GameState.CurrentBlock.RotateCW();
                }
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksFive[33])
                {
                    GameState.CurrentBlock.RotateCW();
                    GameState.CurrentBlock.RotateCW();
                }
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksFive[38]) GameState.CurrentBlock.RotateCCW();
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksFive[40]) GameState.CurrentBlock.RotateCW();
            }

            // 6666666666666666666666666666666666666666666666666666
            else if (GameState.gameOptions.GenerateMosaicType == 6)
            {
                if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksSix[5]) GameState.CurrentBlock.RotateCCW();
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksSix[6]) GameState.CurrentBlock.RotateCW();
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksSix[7]) GameState.CurrentBlock.RotateCW();
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksSix[8]) GameState.CurrentBlock.RotateCCW();
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksSix[11])
                {
                    GameState.CurrentBlock.RotateCW();
                    GameState.CurrentBlock.RotateCW();
                }
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksSix[14])
                {
                    GameState.CurrentBlock.RotateCW();
                    GameState.CurrentBlock.RotateCW();
                }
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksSix[16])
                {
                    GameState.CurrentBlock.RotateCW();
                    GameState.CurrentBlock.RotateCW();
                }
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksSix[19]) GameState.CurrentBlock.RotateCW();
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksSix[20]) GameState.CurrentBlock.RotateCCW();
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksSix[24]) GameState.CurrentBlock.RotateCCW();
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksSix[27]) GameState.CurrentBlock.RotateCCW();
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksSix[29]) GameState.CurrentBlock.RotateCCW();
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksSix[30])
                {
                    GameState.CurrentBlock.RotateCW();
                    GameState.CurrentBlock.RotateCW();
                }
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksSix[31])
                {
                    GameState.CurrentBlock.RotateCW();
                    GameState.CurrentBlock.RotateCW();
                }
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksSix[32])
                {
                    GameState.CurrentBlock.RotateCW();
                    GameState.CurrentBlock.RotateCW();
                }
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksSix[34])
                {
                    GameState.CurrentBlock.RotateCW();
                    GameState.CurrentBlock.RotateCW();
                }
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksSix[36])
                {
                    GameState.CurrentBlock.RotateCW();
                    GameState.CurrentBlock.RotateCW();
                }
            }

            // 7777777777777777777777777777777777777777777777777777
            else if (GameState.gameOptions.GenerateMosaicType == 7)
            {
                if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksSeven[3]) GameState.CurrentBlock.RotateCW();
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksSeven[6]) GameState.CurrentBlock.RotateCCW();
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksSeven[7]) GameState.CurrentBlock.RotateCW();
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksSeven[10]) GameState.CurrentBlock.RotateCCW();
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksSeven[11]) GameState.CurrentBlock.RotateCCW();
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksSeven[13]) GameState.CurrentBlock.RotateCW();
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksSeven[15])
                {
                    GameState.CurrentBlock.RotateCW();
                    GameState.CurrentBlock.RotateCW();
                }
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksSeven[16]) GameState.CurrentBlock.RotateCCW();
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksSeven[17]) GameState.CurrentBlock.RotateCCW();
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksSeven[18]) GameState.CurrentBlock.RotateCW();
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksSeven[19]) GameState.CurrentBlock.RotateCCW();
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksSeven[21]) GameState.CurrentBlock.RotateCCW();
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksSeven[22]) GameState.CurrentBlock.RotateCCW();
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksSeven[23]) GameState.CurrentBlock.RotateCCW();
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksSeven[25]) GameState.CurrentBlock.RotateCW();
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksSeven[28]) GameState.CurrentBlock.RotateCW();
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksSeven[29]) GameState.CurrentBlock.RotateCW();
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksSeven[33])
                {
                    GameState.CurrentBlock.RotateCW();
                    GameState.CurrentBlock.RotateCW();
                }
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksSeven[36]) GameState.CurrentBlock.RotateCW();
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksSeven[38])
                {
                    GameState.CurrentBlock.RotateCW();
                    GameState.CurrentBlock.RotateCW();
                }
            }

            // 8888888888888888888888888888888888888888888888888888
            else if (GameState.gameOptions.GenerateMosaicType == 8)
            {
                if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksEight[1]) GameState.CurrentBlock.RotateCW();
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksEight[2]) GameState.CurrentBlock.RotateCCW();
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksEight[5]) GameState.CurrentBlock.RotateCCW();
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksEight[7]) GameState.CurrentBlock.RotateCW();
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksEight[8]) GameState.CurrentBlock.RotateCCW();
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksEight[10])
                {
                    GameState.CurrentBlock.RotateCW();
                    GameState.CurrentBlock.RotateCW();
                }
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksEight[14]) GameState.CurrentBlock.RotateCCW();
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksEight[17]) GameState.CurrentBlock.RotateCW();
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksEight[18])
                {
                    GameState.CurrentBlock.RotateCW();
                    GameState.CurrentBlock.RotateCW();
                }
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksEight[19]) GameState.CurrentBlock.RotateCW();
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksEight[20])
                {
                    GameState.CurrentBlock.RotateCW();
                    GameState.CurrentBlock.RotateCW();
                }
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksEight[21]) GameState.CurrentBlock.RotateCCW();
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksEight[22]) GameState.CurrentBlock.RotateCCW();
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksEight[26]) GameState.CurrentBlock.RotateCW();
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksEight[28]) GameState.CurrentBlock.RotateCW();
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksEight[29])
                {
                    GameState.CurrentBlock.RotateCW();
                    GameState.CurrentBlock.RotateCW();
                }
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksEight[30]) GameState.CurrentBlock.RotateCCW();
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksEight[31]) GameState.CurrentBlock.RotateCW();
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksEight[32]) GameState.CurrentBlock.RotateCCW();
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksEight[35]) GameState.CurrentBlock.RotateCCW();
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksEight[36]) GameState.CurrentBlock.RotateCW();
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksEight[40])
                {
                    GameState.CurrentBlock.RotateCW();
                    GameState.CurrentBlock.RotateCW();
                }
            }

            // 9999999999999999999999999999999999999999999999999999
            else if (GameState.gameOptions.GenerateMosaicType == 9)
            {
                if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksNine[4]) GameState.CurrentBlock.RotateCCW();
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksNine[5]) GameState.CurrentBlock.RotateCCW();
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksNine[7]) GameState.CurrentBlock.RotateCCW();
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksNine[8]) GameState.CurrentBlock.RotateCW();
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksNine[9]) GameState.CurrentBlock.RotateCW();
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksNine[12]) GameState.CurrentBlock.RotateCCW();
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksNine[15]) GameState.CurrentBlock.RotateCW();
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksNine[17]) GameState.CurrentBlock.RotateCCW();
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksNine[18]) GameState.CurrentBlock.RotateCCW();
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksNine[20]) GameState.CurrentBlock.RotateCCW();
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksNine[21])
                {
                    GameState.CurrentBlock.RotateCW();
                    GameState.CurrentBlock.RotateCW();
                }
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksNine[22]) GameState.CurrentBlock.RotateCCW();
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksNine[25]) GameState.CurrentBlock.RotateCCW();
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksNine[27]) GameState.CurrentBlock.RotateCW();
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksNine[28])
                {
                    GameState.CurrentBlock.RotateCW();
                    GameState.CurrentBlock.RotateCW();
                }
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksNine[29]) GameState.CurrentBlock.RotateCW();
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksNine[32]) GameState.CurrentBlock.RotateCCW();
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksNine[34]) GameState.CurrentBlock.RotateCCW();
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksNine[36]) GameState.CurrentBlock.RotateCCW();
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksNine[39])
                {
                    GameState.CurrentBlock.RotateCW();
                    GameState.CurrentBlock.RotateCW();
                }
            }

            // 10 10 10 10 10 10 10 10 10 10 10 10 10 10 10 10 10 10
            else if (GameState.gameOptions.GenerateMosaicType == 10)
            {
                if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksTen[1]) GameState.CurrentBlock.RotateCW();
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksTen[5]) GameState.CurrentBlock.RotateCCW();
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksTen[8]) GameState.CurrentBlock.RotateCCW();
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksTen[9]) GameState.CurrentBlock.RotateCCW();
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksTen[10]) GameState.CurrentBlock.RotateCCW();
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksTen[12]) GameState.CurrentBlock.RotateCCW();
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksTen[13])
                {
                    GameState.CurrentBlock.RotateCW();
                    GameState.CurrentBlock.RotateCW();
                }
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksTen[16]) GameState.CurrentBlock.RotateCCW();
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksTen[17]) GameState.CurrentBlock.RotateCCW();
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksTen[18]) GameState.CurrentBlock.RotateCCW();
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksTen[20]) GameState.CurrentBlock.RotateCCW();
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksTen[21]) GameState.CurrentBlock.RotateCCW();
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksTen[22]) GameState.CurrentBlock.RotateCW();
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksTen[25]) GameState.CurrentBlock.RotateCCW();
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksTen[26]) GameState.CurrentBlock.RotateCW();
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksTen[27]) GameState.CurrentBlock.RotateCCW();
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksTen[28]) GameState.CurrentBlock.RotateCCW();
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksTen[29]) GameState.CurrentBlock.RotateCW();
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksTen[31]) GameState.CurrentBlock.RotateCW();
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksTen[36]) GameState.CurrentBlock.RotateCCW();
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksTen[38]) GameState.CurrentBlock.RotateCCW();
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksTen[39])
                {
                    GameState.CurrentBlock.RotateCW();
                    GameState.CurrentBlock.RotateCW();
                }
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksTen[40])
                {
                    GameState.CurrentBlock.RotateCW();
                    GameState.CurrentBlock.RotateCW();
                }
            }

            // 11 11 11 11 11 11 11 11 11 11 11 11 11 11 11 11 11 11
            else if (GameState.gameOptions.GenerateMosaicType == 11)
            {
                if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksEleven[2]) GameState.CurrentBlock.RotateCCW();
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksEleven[8]) GameState.CurrentBlock.RotateCW();
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksEleven[11]) GameState.CurrentBlock.RotateCW();
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksEleven[12]) GameState.CurrentBlock.RotateCCW();
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksEleven[13]) GameState.CurrentBlock.RotateCW();
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksEleven[15]) GameState.CurrentBlock.RotateCW();
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksEleven[17])
                {
                    GameState.CurrentBlock.RotateCW();
                    GameState.CurrentBlock.RotateCW();
                }
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksEleven[21])
                {
                    GameState.CurrentBlock.RotateCW();
                    GameState.CurrentBlock.RotateCW();
                }
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksEleven[23]) GameState.CurrentBlock.RotateCCW();
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksEleven[24]) GameState.CurrentBlock.RotateCCW();
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksEleven[25]) GameState.CurrentBlock.RotateCCW();
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksEleven[29]) GameState.CurrentBlock.RotateCW();
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksEleven[30])
                {
                    GameState.CurrentBlock.RotateCW();
                    GameState.CurrentBlock.RotateCW();
                }
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksEleven[31])
                {
                    GameState.CurrentBlock.RotateCW();
                    GameState.CurrentBlock.RotateCW();
                }
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksEleven[32]) GameState.CurrentBlock.RotateCW();
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksEleven[33]) GameState.CurrentBlock.RotateCW();
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksEleven[37])
                {
                    GameState.CurrentBlock.RotateCW();
                    GameState.CurrentBlock.RotateCW();
                }
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksEleven[38])
                {
                    GameState.CurrentBlock.RotateCW();
                    GameState.CurrentBlock.RotateCW();
                }
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksEleven[39]) GameState.CurrentBlock.RotateCCW();
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksEleven[40]) GameState.CurrentBlock.RotateCW();
            }

            // 12 12 12 12 12 12 12 12 12 12 12 12 12 12 12 12 12 12
            else if (GameState.gameOptions.GenerateMosaicType == 12)
            {
                if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksTwelve[2]) GameState.CurrentBlock.RotateCCW();
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksTwelve[5])
                {
                    GameState.CurrentBlock.RotateCW();
                    GameState.CurrentBlock.RotateCW();
                }
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksTwelve[6]) GameState.CurrentBlock.RotateCCW();
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksTwelve[8])
                {
                    GameState.CurrentBlock.RotateCW();
                    GameState.CurrentBlock.RotateCW();
                }
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksTwelve[9]) GameState.CurrentBlock.RotateCCW();
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksTwelve[10]) GameState.CurrentBlock.RotateCCW();
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksTwelve[11]) GameState.CurrentBlock.RotateCCW();
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksTwelve[15]) GameState.CurrentBlock.RotateCW();
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksTwelve[17]) GameState.CurrentBlock.RotateCW();
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksTwelve[18]) GameState.CurrentBlock.RotateCW();
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksTwelve[19])
                {
                    GameState.CurrentBlock.RotateCW();
                    GameState.CurrentBlock.RotateCW();
                }
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksTwelve[20]) GameState.CurrentBlock.RotateCCW();
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksTwelve[22]) GameState.CurrentBlock.RotateCCW();
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksTwelve[27]) GameState.CurrentBlock.RotateCCW();
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksTwelve[28]) GameState.CurrentBlock.RotateCW();
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksTwelve[30])
                {
                    GameState.CurrentBlock.RotateCW();
                    GameState.CurrentBlock.RotateCW();
                }
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksTwelve[31])
                {
                    GameState.CurrentBlock.RotateCW();
                    GameState.CurrentBlock.RotateCW();
                }
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksTwelve[32]) GameState.CurrentBlock.RotateCCW();
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksTwelve[34])
                {
                    GameState.CurrentBlock.RotateCW();
                    GameState.CurrentBlock.RotateCW();
                }
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksTwelve[38]) GameState.CurrentBlock.RotateCW();
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksTwelve[39]) GameState.CurrentBlock.RotateCCW();
                else if (GameState.CurrentBlock == GameState.BlockQueue.mosaicBlocksTwelve[40])
                {
                    GameState.CurrentBlock.RotateCW();
                    GameState.CurrentBlock.RotateCW();
                }
            }
        }
    }
}
