using DxLibDLL;
using MyLib;

namespace Sokoban
{
    public class GameClear : Scene
    {
        private MapManager mapManager;

        public GameClear(GameObjectManager objectManager, ISceneManager sceneManager, SceneType sceneType) :
            base(objectManager, sceneManager, sceneType)
        {
        }

        public override void Init(object[] sendValues)
        {
            mapManager = new MapManager(ObjectManager, new Map("Resources/Other/GameClear.csv"));
        }

        public override void Update()
        {
            // Zキーでタイトルへ
            if (Input.GetButtonDown(DX.PAD_INPUT_1))
            {
                sceneManager.LoadScene(SceneType.Title);
            }
            // Xキーでシーンセレクトへ
            if (Input.GetButtonDown(DX.PAD_INPUT_2))
            {
                sceneManager.LoadScene(SceneType.Select);
            }
        }

        public override void Draw()
        {
            mapManager.DrawStaticMapChip();
        }

        public override void End()
        {
        }
    }
}
