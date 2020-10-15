using DxLibDLL;
using MyLib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban
{
    public class StageSelect : Scene
    {
        private string[] stageDataFileNames;
        private int select;

        public StageSelect(GameObjectManager objectManager, ISceneManager sceneManager, SceneType sceneType) :
            base(objectManager, sceneManager, sceneType)
        {
        }

        public override void Init(object[] sendValues)
        {
            stageDataFileNames = Directory.GetFiles("Resources/Map", "*", SearchOption.TopDirectoryOnly);
        }

        public override void Update()
        {
            if (Input.GetButtonDown(DX.PAD_INPUT_8)) select -= 1;
            if (Input.GetButtonDown(DX.PAD_INPUT_5)) select += 1;

            select = MyMath.Clamp(select, 0, stageDataFileNames.Length - 1);

            if (Input.GetButtonDown(DX.PAD_INPUT_1))
            {
                sceneManager.LoadScene(SceneType.Play, new object[] { stageDataFileNames[select] });
            }
        }

        public override void Draw()
        {
            for(int fileNum = 0; fileNum < stageDataFileNames.Length; fileNum++)
            {
                int blueColor = 255;
                if (select == fileNum) blueColor = 0;
                
                DX.DrawString(50, fileNum * 32, stageDataFileNames[fileNum], DX.GetColor(255, 255, blueColor));
            }
        }

        public override void End()
        {
        }
    }
}
