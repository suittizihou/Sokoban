using DxLibDLL;
using System.Collections.Generic;

namespace Sokoban
{
    public static class Image
    {
        private static Dictionary<MapChipType, int> mapChipImageHandle = new Dictionary<MapChipType, int>();

        public static void Load()
        {
            ResourceLoad(MapChipType.Wall, "Wall.png");
            ResourceLoad(MapChipType.Goal, "Goal.png");
            ResourceLoad(MapChipType.Box, "Box.png");
            ResourceLoad(MapChipType.Player, "Kakashi.png");
        }

        private static void ResourceLoad(MapChipType mapChipType, string fileName)
        {
            mapChipImageHandle.Add(mapChipType, DX.LoadGraph("Resources/Image/" + fileName));
        }

        public static int GetMapChipGraphHandle(MapChipType mapChipType)
        {
            return mapChipImageHandle[mapChipType];
        }

        /// <summary>
        /// マップチップの描画
        /// </summary>
        /// <param name="position"></param>
        /// <param name="mapChip"></param>
        public static void DrawMapChip(Vector2Int position, MapChipType mapChip)
        {
            DX.DrawGraph(position.x * Map.MAP_CHIP_WIDTH_SIZE, position.y * Map.MAP_CHIP_HIGHT_SIZE, GetMapChipGraphHandle(mapChip), DX.TRUE);
        }

        public static void DrawMapChip(int x, int y, MapChipType mapChip)
        {
            DX.DrawGraph(x * Map.MAP_CHIP_WIDTH_SIZE, y * Map.MAP_CHIP_HIGHT_SIZE, GetMapChipGraphHandle(mapChip), DX.TRUE);
        }

        public static void DrawMapChip(Vector2 position, MapChipType mapChip)
        {
            DX.DrawGraphF(position.x * Map.MAP_CHIP_WIDTH_SIZE, position.y * Map.MAP_CHIP_HIGHT_SIZE, GetMapChipGraphHandle(mapChip), DX.TRUE);
        }
        public static void DrawMapChip(float x, float y, MapChipType mapChip)
        {
            DX.DrawGraphF(x * Map.MAP_CHIP_WIDTH_SIZE, y * Map.MAP_CHIP_HIGHT_SIZE, GetMapChipGraphHandle(mapChip), DX.TRUE);
        }
    }
}
