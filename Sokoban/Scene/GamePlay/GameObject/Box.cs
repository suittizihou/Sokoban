namespace Sokoban
{
    class Box : GameObject
    {
        public Box(IGameObjectManager gameObjectManager, Map map, Vector2Int position) :
            base(gameObjectManager, map, position, MapChipType.Box)
        {
        }

        public override void Init()
        {
        }

        public override void Update()
        {
            // ゴール地点にいるかどうかを格納
            isGoal = map.IsGoalMapChip(currentPosition);
        }
    }
}
