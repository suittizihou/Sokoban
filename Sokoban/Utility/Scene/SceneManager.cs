using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban
{
    public class SceneManager : ISceneState, ISceneManager
    {
        // シーンの実態が入る連想配列
        private Dictionary<SceneType, Scene> scenes = new Dictionary<SceneType, Scene>();
        // 現在のシーン
        private Scene currentScene;

        /// <summary>
        /// シーンの追加
        /// </summary>
        /// <param name="sceneType"></param>
        /// <param name="scene"></param>
        public void AddScene(Scene scene)
        {
            scenes.Add(scene.GetSceneType(), scene);
        }

        /// <summary>
        /// シーンのロード
        /// </summary>
        /// <param name="sceneType"></param>
        public void LoadScene(SceneType sceneType, object[] sendValues = null)
        {
            // 現在のシーンの終了処理を呼ぶ
            End();

            // シーン切り替え時保持しているゲームオブジェクトのisDeadフラグを全部立てて死亡させる
            foreach(var obj in currentScene.ObjectManager.GetAllGameObject())
            {
                obj.isDead = true;
            }

            currentScene.ObjectManager.DestroyObject();

            // シーンを切り替える
            ChangeScene(sceneType, sendValues);
        }

        /// <summary>
        /// シーンを切り替える(Endは呼ばれない)
        /// </summary>
        /// <param name="sceneType"></param>
        public void ChangeScene(SceneType sceneType, object[] sendValues = null)
        {
            // 現在のシーンを選ばれたシーンに変更
            currentScene = scenes[sceneType];
            // 現在のシーンを初期化
            Init(sendValues);
        }

        /// <summary>
        /// 現在のシーンの初期化を呼ぶ
        /// </summary>
        public void Init(object[] sendValues)
        {
            currentScene.Init(sendValues);
        }

        /// <summary>
        /// 現在のシーンの更新を呼ぶ
        /// </summary>
        public void Update()
        {
            currentScene.Update();
            currentScene.ObjectManager.DestroyObject();
        }

        /// <summary>
        /// 現在のシーンの描画を呼ぶ
        /// </summary>
        public void Draw()
        {
            currentScene.Draw();
        }

        /// <summary>
        /// 現在のシーンの終了処理を呼ぶ
        /// </summary>
        public void End()
        {
            currentScene.End();
        }
    }
}
