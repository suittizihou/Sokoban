using DxLibDLL;
using MyLib;

namespace Sokoban
{
    class Player : GameObject
    {
        private DirectionType lastDirection;

        public Player(IGameObjectManager gameObjectManager, Map map, Vector2Int position) :
            base(gameObjectManager, map, position, MapChipType.Player)
        {
        }

        public override void Init()
        {

        }

        public override void Update()
        {
            // 上に進む
            if (Input.GetButtonDown(DX.PAD_INPUT_8))
            {
                Move(Vector2Int.up);
                lastDirection = DirectionType.Up;
            }

            // 下に進む
            if (Input.GetButtonDown(DX.PAD_INPUT_5))
            {
                Move(Vector2Int.down);
                lastDirection = DirectionType.Down;
            }

            // 右に進む
            if (Input.GetButtonDown(DX.PAD_INPUT_6))
            {
                Move(Vector2Int.right);
                lastDirection = DirectionType.Right;
            }

            // 左に進む
            if (Input.GetButtonDown(DX.PAD_INPUT_4))
            {
                Move(Vector2Int.left);
                lastDirection = DirectionType.Left;
            }

            // 箱を押す
            if (Input.GetButtonDown(DX.PAD_INPUT_10))
            {
                PushBox();
            }
        }

        // 箱を押す
        private void PushBox()
        {
            // 押した方向にブロックがない場合早期リターン
            if (!map.MapChipCheck(currentPosition, lastDirection, MapChipType.Box)) return;

            switch (lastDirection)
            {
                // 箱を上に押す
                case DirectionType.Up:
                    gameObjectManager.GetGameObject(currentPosition + Vector2Int.up).Move(Vector2Int.up);
                    break;

                // 箱を下に押す
                case DirectionType.Down:
                    gameObjectManager.GetGameObject(currentPosition + Vector2Int.down).Move(Vector2Int.down);
                    break;

                // 箱を右に押す
                case DirectionType.Right:
                    gameObjectManager.GetGameObject(currentPosition + Vector2Int.right).Move(Vector2Int.right);
                    break;

                // 箱を左に押す
                case DirectionType.Left:
                    gameObjectManager.GetGameObject(currentPosition + Vector2Int.left).Move(Vector2Int.left);
                    break;
            }
        }
    }
}