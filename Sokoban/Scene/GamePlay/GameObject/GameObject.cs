namespace Sokoban
{
    public abstract class GameObject
    {
        private const float ANIMATION_SPEED = 0.6f;

        protected IGameObjectManager gameObjectManager;

        protected Map map;
        protected MapChipType mapChipType;

        protected Vector2Int currentPosition;
        protected Vector2Int nextPosition;
        protected Vector2 animePosition;

        public bool IsAnimation { get; private set; }
        public bool isGoal;
        public bool isDead;

        public GameObject(IGameObjectManager gameObjectManager, Map map, Vector2Int position, MapChipType mapChipType)
        {
            this.map = map;
            this.mapChipType = mapChipType;
            this.gameObjectManager = gameObjectManager;

            currentPosition = position;
            nextPosition = currentPosition;

            animePosition = (Vector2)currentPosition;
        }

        /// <summary>
        /// マップチップの取得
        /// </summary>
        /// <returns></returns>
        public MapChipType GetMapChip()
        {
            return mapChipType;
        }

        /// <summary>
        /// 座標の取得(二次元配列上での場所)
        /// </summary>
        /// <returns></returns>
        public Vector2Int GetPosition()
        {
            return currentPosition;
        }

        /// <summary>
        /// 座標の取得(画面上での座標)
        /// </summary>
        /// <returns></returns>
        public Vector2 GetAnimationPosition()
        {
            return animePosition;
        }

        /// <summary>
        /// 指定座標に移動
        /// </summary>
        /// <param name="nextPosition"></param>
        public void Move(Vector2Int nextPosition)
        {
            // 行先にブロックがあったら早期リターン
            if (map.BlockCheck(currentPosition + nextPosition)) return;

            // アニメーション開始フラグを立てる
            IsAnimation = true;
            // 今いた場所の自分のマップチップフラグを折る
            map.FoldMapChip(currentPosition, mapChipType);
            // 次移動する座標を決定
            this.nextPosition = currentPosition + nextPosition;
            // 今いた場所を次移動する場所にする
            currentPosition = this.nextPosition;
            // 移動したところのマップチップを自分のマップチップにする
            map.SetMapChip(currentPosition, mapChipType);
        }

        public abstract void Init();

        public void AnimeUpdate()
        {
            // 現在の座標と次の座標が同じなら早期リターン
            if (Vector2.Distance(animePosition, (Vector2)nextPosition) <= 0.0000001f)
            {
                animePosition = (Vector2)nextPosition;
                IsAnimation = false;
                return;
            }

            // 移動アニメーション
            animePosition = Vector2.Lerp(animePosition, (Vector2)nextPosition, ANIMATION_SPEED);
        }

        public abstract void Update();

        public void Draw()
        {
            // 座標を補完したうえで描画
            Image.DrawMapChip(animePosition, mapChipType);
        }

        public virtual void End() { }
    }
}
