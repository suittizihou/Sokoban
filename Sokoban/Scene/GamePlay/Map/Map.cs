using System.Management.Instrumentation;
using System.Windows.Forms;

namespace Sokoban
{
    public enum MapChipType
    {
        None = (1 << 0),

        // 動かないマップチップ
        Wall = (1 << 1),
        Goal = (1 << 2),

        // 動くマップチップ
        Box = (1 << 3),
        Player = (1 << 4)
    }


    public class Map
    {
        public const int MAP_SIZE_WIDTH = 32;  // マップの横幅
        public const int MAP_SIZE_HIGHT = 20;  // マップの縦幅

        public const int MAP_CHIP_WIDTH_SIZE = 32; // マップチップの横幅
        public const int MAP_CHIP_HIGHT_SIZE = 32; // マップチップの縦幅

        private int[,] map = new int[MAP_SIZE_HIGHT, MAP_SIZE_WIDTH];

        private string filePath;

        public Map(string filePath) 
        {
            this.filePath = filePath;
            // マップをロード
            map = LoadMap.Load(filePath);
        }

        /// <summary>
        /// 現在使っているステージのデータがあるパスを返す
        /// </summary>
        /// <returns></returns>
        public string GetStageFilePath()
        {
            return filePath;
        }

        /// <summary>
        /// マップを取得
        /// </summary>
        /// <returns></returns>
        public int[,] GetMap()
        {
            return map;
        }

        /// <summary>
        /// 指定の座標のマップチップを取得
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        public MapChipType GetMapChip(Vector2Int position)
        {
            return (MapChipType)map[position.y, position.x];
        }
        public MapChipType GetMapChip(int x, int y)
        {
            return (MapChipType)map[y, x];
        }

        /// <summary>
        /// 動かないマップチップかどうか
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public bool IsStaticMapChip(int x, int y)
        {
            return MapChipType.None < GetMapChip(x, y) 
                && GetMapChip(x, y) <= MapChipType.Goal;
        }

        /// <summary>
        /// 現在地がゴールかどうか
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        public bool IsGoalMapChip(Vector2Int position)
        {
            return (GetMapChip(position) & MapChipType.Goal) != 0;
        }

        /// <summary>
        /// 配列外かどうかチェック
        /// </summary>
        /// <returns></returns>
        private bool CheckOutOfRange(Vector2Int position)
        {
            if (position.y >= map.GetLength(0) || position.x >= map.GetLength(1))
            {
                MessageBox.Show("指定座標がマップの外です。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
            return false;
        }

        /// <summary>
        /// 指定の場所のマップチップを変更
        /// </summary>
        /// <param name="position"></param>
        /// <param name="chipType"></param>
        public void SetMapChip(Vector2Int position, MapChipType chipType)
        {
            if (CheckOutOfRange(position)) return;

            if (chipType == MapChipType.None)
            {
                // 全ビットフラグを折る
                map[position.y, position.x] &= ~map[position.y, position.x];
            }
            else
            {
                // マップチップに対応した場所にフラグを立てる
                map[position.y, position.x] |= (int)chipType;
            }
        }

        /// <summary>
        /// 指定座標の特定のマップチップフラグを折る
        /// </summary>
        public void FoldMapChip(Vector2Int position, MapChipType foldMapChip)
        {
            if (CheckOutOfRange(position)) return;

            map[position.y, position.x] &= ~(int)foldMapChip;
        }

        /// <summary>
        /// 指定の座標を基準に指定の方向にブロックがあるかチェック
        /// </summary>
        /// <param name="position"></param>
        /// <param name="direction"></param>
        /// <returns></returns>
        public bool MapChipCheck(Vector2Int position, DirectionType direction, MapChipType mapChipTyep)
        {
            switch (direction)
            {
                case DirectionType.Up:
                    return MapChipCheck(position + Vector2Int.up, mapChipTyep);

                case DirectionType.Down:
                    return MapChipCheck(position + Vector2Int.down, mapChipTyep);
                
                case DirectionType.Right:
                    return MapChipCheck(position + Vector2Int.right, mapChipTyep);
                
                default:
                    return MapChipCheck(position + Vector2Int.left, mapChipTyep);
            }
        }

        public bool MapChipCheck(Vector2Int checkPosition, MapChipType mapChipType)
        {
            // 指定座標がマップの外を示している場合trueを返す
            if (checkPosition.y >= map.GetLength(0) || checkPosition.x >= map.GetLength(1)) return true;

            return (GetMapChip(checkPosition) & mapChipType) != 0;
        }

        /// <summary>
        /// 指定の座標にブロックがあるかチェック
        /// </summary>
        /// <param name="checkPosition"></param>
        /// <returns></returns>
        public bool BlockCheck(Vector2Int checkPosition)
        {
            // 指定座標がマップの外を示している場合trueを返す
            if (checkPosition.y >= map.GetLength(0) || checkPosition.x >= map.GetLength(1)) return true;

            return (GetMapChip(checkPosition) & MapChipType.Wall) != 0
                || (GetMapChip(checkPosition) & MapChipType.Box) != 0;
        }
    }
}
