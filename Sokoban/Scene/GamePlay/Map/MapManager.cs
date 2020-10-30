namespace Sokoban
{
    class MapManager
    {
        private IGameObjectManager manager;
        private Map map;
        public MapManager(IGameObjectManager objectManager, Map map)
        {
            this.map = map;
            manager = objectManager;
        }

        /// <summary>
        /// 現在使っているステージデータのファイルパスを返す
        /// </summary>
        /// <returns></returns>
        public string GetStageFilePath()
        {
            return map.GetStageFilePath();
        }

        /// <summary>
        /// 全ゲームオブジェクトのアニメーションがストップしているか
        /// </summary>
        /// <returns></returns>
        public bool IsAllGameObjectAnimationStop()
        {
            var objects = manager.GetAllGameObject();
            // ゲームオブジェクトが０ならfalse
            if (objects.Count == 0) return false;

            foreach (var obj in objects)
            {
                if (obj.IsAnimation) return false;
            }
            return true;
        }

        /// <summary>
        /// マップチップの生成を開始(動くものだけ)
        /// </summary>
        public void StartGeneration()
        {
            for (int y = 0; y < map.GetMap().GetLength(0); y++)
            {
                for (int x = 0; x < map.GetMap().GetLength(1); x++)
                {
                    GameObjectGeneration(map.GetMapChip(x, y), new Vector2Int(x, y));
                }
            }
        }

        /// <summary>
        /// マップチップからゲームオブジェクトを生成
        /// </summary>
        private void GameObjectGeneration(MapChipType mapChipType, Vector2Int position)
        {
            switch (mapChipType)
            {
                case MapChipType.Box:
                    manager.AddGameObject(new Box(manager, map, position));
                    break;

                case MapChipType.Player:
                    manager.AddGameObject(new Player(manager, map, position));
                    break;
            }
        }

        /// <summary>
        /// 動かないマップチップを描画する
        /// </summary>
        public void DrawStaticMapChip(float offset = 0.0f)
        {
            for (int y = 0; y < map.GetMap().GetLength(0); y++)
            {
                for (int x = 0; x < map.GetMap().GetLength(1); x++)
                {
                    if (map.IsStaticMapChip(x, y))
                    {
                        Image.DrawMapChip(x + offset, y + offset, map.GetMapChip(x, y));
                    }
                }
            }
        }
    }
}
