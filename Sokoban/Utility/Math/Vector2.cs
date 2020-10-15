using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban
{
    public struct Vector2
    {
        public float x, y;
        public Vector2(float x, float y)
        {
            this.x = x;
            this.y = y;
        }
        public static Vector2 zero => new Vector2(0.0f, 0.0f);
        public static Vector2 one => new Vector2(1.0f, 1.0f);
        public static Vector2 up => new Vector2(0.0f, 1.0f);
        public static Vector2 down => new Vector2(0.0f, -1.0f);
        public static Vector2 right => new Vector2(1.0f, 0.0f);
        public static Vector2 left => new Vector2(-1.0f, 0.0f);

        /// <summary>
        /// 線形補間
        /// </summary>
        /// <param name="start">開始地点</param>
        /// <param name="end">目標地点</param>
        /// <param name="t">現在の場所(0.0 ～ 1.0)</param>
        /// <returns></returns>
        public static Vector2 Lerp(Vector2 start, Vector2 end, float t)
        {
            return new Vector2(
                (1 - t) * start.x + t * end.x,
                (1 - t) * start.y + t * end.y);
        }

        /// <summary>
        /// 距離
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static float Distance(Vector2 lhs, Vector2 rhs)
        {
            return (rhs.x - lhs.x) * (rhs.x - lhs.x) + (rhs.y - lhs.y) * (rhs.y - lhs.y);
        }

        public static Vector2 operator +(Vector2 lhs, Vector2 rhs)
        {
            return new Vector2(lhs.x + rhs.x, lhs.y + rhs.y);
        }
        public static Vector2 operator -(Vector2 lhs, Vector2 rhs)
        {
            return new Vector2(lhs.x - rhs.x, lhs.y - rhs.y);
        }

        public static explicit operator Vector2Int(Vector2 vector)
        {
            return new Vector2Int((int)vector.x, (int)vector.y);
        }
    }
}
