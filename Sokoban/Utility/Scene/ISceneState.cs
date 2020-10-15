namespace Sokoban
{
    public interface ISceneState
    {
        /// <summary>
        /// 初期化
        /// </summary>
        void Init(object[] sendValues);
        /// <summary>
        /// 更新
        /// </summary>
        void Update();
        /// <summary>
        /// 描画
        /// </summary>
        void Draw();
        /// <summary>
        /// 終了
        /// </summary>
        void End();
    }
}
