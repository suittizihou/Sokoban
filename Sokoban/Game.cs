using MyLib;

namespace Sokoban
{
    public class Game
    {
        // シーンマネージャー
        private SceneManager sceneManager;

        public void Init()
        {
            Input.Init();
            Image.Load();

            sceneManager = new SceneManager();

            // シーンを追加する
            sceneManager.AddScene(new GameTitle(new GameObjectManager(), sceneManager, SceneType.Title));
            sceneManager.AddScene(new StageSelect(new GameObjectManager(), sceneManager, SceneType.Select));
            sceneManager.AddScene(new GamePlay(new GameObjectManager(), sceneManager, SceneType.Play));
            sceneManager.AddScene(new GameClear(new GameObjectManager(), sceneManager, SceneType.Clear));
            
            // 最初のシーンを切り替える(End呼ばれない)
            sceneManager.ChangeScene(SceneType.Title);
        }

        public void Update()
        {
            Input.Update();
            sceneManager.Update();
        }

        public void Draw()
        {
            sceneManager.Draw();
        }
    }
}
