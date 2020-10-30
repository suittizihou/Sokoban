using DxLibDLL;
using MyLib;

namespace Sokoban
{
    class GamePlay : Scene
    {
        private MapManager mapManager;

        public GamePlay(GameObjectManager gameObjectManager, ISceneManager sceneManager, SceneType sceneType) :
            base(gameObjectManager, sceneManager, sceneType)
        {
        }

        public override void Init(object[] sendValues)
        {
            mapManager = new MapManager(ObjectManager, new Map((string)sendValues[0]));
            mapManager.StartGeneration();
        }

        public override void Update()
        {
            // Zキーでリスタート(Rキーがわからなかったため)
            if (Input.GetButtonDown(DX.PAD_INPUT_1))
            {
                sceneManager.LoadScene(SceneType.Play, new object[] { mapManager.GetStageFilePath() });
            }

            // Xキーでシーンセレクトへ
            if (Input.GetButtonDown(DX.PAD_INPUT_2))
            {
                sceneManager.LoadScene(SceneType.Select);
            }

            // 全ゲームオブジェクトのアニメーションが終了しているなら通常の更新を再開
            if (mapManager.IsAllGameObjectAnimationStop())
            {
                // 全ボックスがゴールに到達しているか
                if (CheckAllBoxGoal())
                {
                    sceneManager.LoadScene(SceneType.Clear);
                }
                // ゲームオブジェクトの更新をする
                GameObjectState.Update();
            }
            else
            {
                // ゲームオブジェクトのアニメーション処理
                GameObjectState.AnimeUpdate();
            }
        }

        /// <summary>
        /// 全ボックスがゴールに到達しているか
        /// </summary>
        /// <returns></returns>
        private bool CheckAllBoxGoal()
        {
            foreach (var obj in ObjectManager.GetGameObjects(MapChipType.Box))
            {
                if (!obj.isGoal) return false;
            }
            return true;
        }

        public override void Draw()
        {
            // 動くオブジェクトの描画
            GameObjectState.Draw();
            // 動かないオブジェクトの描画
            mapManager.DrawStaticMapChip();
        }

        public override void End()
        {
        }
    }
}
