using DxLibDLL;
using MyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban
{
    public class GameTitle : Scene
    {
        private MapManager mapManager;

        public GameTitle(GameObjectManager gameObjectManager, ISceneManager sceneManager, SceneType sceneType) :
            base(gameObjectManager, sceneManager, sceneType)
        {
        }

        public override void Init(object[] sendValues)
        {
            mapManager = new MapManager(ObjectManager, new Map("Resources/Other/GameStart.csv"));
        }

        public override void Update()
        {
            if (Input.GetButtonDown(DX.PAD_INPUT_1))
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
