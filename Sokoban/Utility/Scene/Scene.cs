using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban
{
    public abstract class Scene : ISceneState
    {
        public ISceneManager sceneManager;
        private SceneType sceneType;

        public IGameObjectManager ObjectManager { get; private set; }
        protected IGameObjectState GameObjectState { get; private set; }

        public Scene(GameObjectManager objectManager, ISceneManager sceneManager, SceneType sceneType)
        {
            this.sceneManager = sceneManager;
            this.sceneType = sceneType;
            ObjectManager = objectManager;
            GameObjectState = objectManager;
        }

        /// <summary>
        /// 自分のシーンタイプを取得
        /// </summary>
        /// <returns></returns>
        public SceneType GetSceneType()
        {
            return sceneType;
        }

        /// <summary>
        /// 初期化
        /// </summary>
        /// <param name="sendValues">前シーンから送られた値が入っている配列</param>
        public abstract void Init(object[] sendValues);
        
        /// <summary>
        /// 更新
        /// </summary>
        public abstract void Update();
        
        /// <summary>
        /// 描画
        /// </summary>
        public abstract void Draw();

        /// <summary>
        /// 終了
        /// </summary>
        public abstract void End();
    }
}
