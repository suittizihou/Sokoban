using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban
{
    public static class LoadMap
    {
        public static int[,] Load(string filePath)
        {
            int[,] tempMap = new int[Map.MAP_SIZE_HIGHT, Map.MAP_SIZE_WIDTH];

            using (StreamReader reader = new StreamReader(filePath))
            {
                // for文で一行ずつ読み込んでいく
                for (int readLine = 0; !reader.EndOfStream; readLine++)
                {
                    // 一行読み込む
                    string line = reader.ReadLine();
                    // 読み込んだ一行をカンマ区切りで一次元配列にしてそれぞれ入れていく
                    string[] values = line.Split(',');

                    // １データずつ文字を整数に変換して格納していく
                    for (int column = 0; column < values.Length; column++)
                    {
                        // マップのビットフラグを立てる
                        tempMap[readLine, column] = (1 << 1 + int.Parse(values[column]));
                    }
                }

            }

            return tempMap;
        }
    }
}
