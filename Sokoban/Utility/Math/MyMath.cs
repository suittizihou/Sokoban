namespace Sokoban
{
    public static class MyMath
    {
        /// <summary>
        /// 値の制限
        /// </summary>
        /// <param name="value"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public static int Clamp(int value, int min, int max)
        {
            return (value < min) ? min : ((value > max) ? max : value);
        }
    }
}
