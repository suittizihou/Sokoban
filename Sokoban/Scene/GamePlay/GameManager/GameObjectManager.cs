using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban
{
    public class GameObjectManager : IGameObjectManager, IGameObjectState
    {
        private List<GameObject> gameObjects = new List<GameObject>();

        /// <summary>
        /// ゲームオブジェクトの追加
        /// </summary>
        /// <param name="gameObject"></param>
        public void AddGameObject(GameObject gameObject)
        {
            gameObject.Init();
            gameObjects.Add(gameObject);
        }

        /// <summary>
        /// 座標でゲームオブジェクトを検索する
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public GameObject GetGameObject(int x, int y)
        {
            return GetGameObject(new Vector2Int(x, y));
        }
        public GameObject GetGameObject(Vector2Int position)
        {
            foreach (var obj in gameObjects)
            {
                if(obj.GetPosition() == position)
                {
                    return obj;
                }
            }
            return null;
        }
        public List<GameObject> GetGameObjects(MapChipType mapChipType)
        {
            List<GameObject> temp = new List<GameObject>();
            foreach(var obj in gameObjects)
            {
                if(obj.GetMapChip() == mapChipType)
                {
                    temp.Add(obj);
                }
            }
            return temp;
        }

        public List<GameObject> GetAllGameObject()
        {
            return gameObjects;
        }

        /// <summary>
        /// フラグが立ってるゲームオブジェクトを削除
        /// </summary>
        public void DestroyObject()
        {
            gameObjects.RemoveAll(delegate(GameObject obj)
            {
                if (obj.isDead)
                {
                    // 死亡フラグが立っていたら終了処理を呼ぶ
                    obj.End();
                    return true;
                }
                else
                {
                    return false;
                }
            });
        }

        public void Init() { }

        public void AnimeUpdate()
        {
            foreach(var obj in gameObjects)
            {
                obj.AnimeUpdate();
            }
        }

        public void Update()
        {
            foreach(var obj in gameObjects)
            {
                obj.Update();
            }
        }

        public void Draw()
        {
            foreach(var obj in gameObjects)
            {
                obj.Draw();
            }
        }

        public void End() { }
    }
}
