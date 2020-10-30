namespace Sokoban
{
    public interface IGameObjectState
    {
        void Init();
        void AnimeUpdate();
        void Update();
        void Draw();
        void End();
    }
}
