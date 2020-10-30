using System.Collections.Generic;

namespace Sokoban
{
    public interface IGameObjectManager
    {
        void AddGameObject(GameObject gameObject);
        GameObject GetGameObject(int x, int y);
        GameObject GetGameObject(Vector2Int position);
        List<GameObject> GetGameObjects(MapChipType mapChipType);
        List<GameObject> GetAllGameObject();
        void DestroyObject();
    }
}
