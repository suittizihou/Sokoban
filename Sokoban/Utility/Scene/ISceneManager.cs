namespace Sokoban
{
    public interface ISceneManager
    {
        /// <summary>
        /// シーンの追加
        /// </summary>
        /// <param name="sceneType"></param>
        /// <param name="scene"></param>
        void AddScene(Scene scene);

        /// <summary>
        /// シーンのロード
        /// </summary>
        /// <param name="sceneType"></param>
        void LoadScene(SceneType sceneType, object[] sendValues = null);
    }
}
