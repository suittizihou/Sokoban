using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban
{
    public struct Vector2Int
    {
        public int x, y;
        public Vector2Int(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public static Vector2Int zero => new Vector2Int(0, 0);
        public static Vector2Int one => new Vector2Int(1, 1);
        public static Vector2Int up => new Vector2Int(0, -1);
        public static Vector2Int down => new Vector2Int(0, 1);
        public static Vector2Int right => new Vector2Int(1, 0);
        public static Vector2Int left => new Vector2Int(-1, 0);

        public static Vector2Int operator+ (Vector2Int lhs, Vector2Int rhs)
        {
            return new Vector2Int(lhs.x + rhs.x, lhs.y + rhs.y);
        }
        public static Vector2Int operator- (Vector2Int lhs, Vector2Int rhs)
        {
            return new Vector2Int(lhs.x - rhs.x, lhs.y - rhs.y);
        }
        public static Vector2Int operator *(Vector2Int lhs, int scalar)
        {
            return new Vector2Int(lhs.x * scalar, lhs.y * scalar);
        }

        public static bool operator!= (Vector2Int lhs, Vector2Int rhs)
        {
            return lhs.x != rhs.x || lhs.y != rhs.y;
        }
        public static bool operator== (Vector2Int lhs, Vector2Int rhs)
        {
            return lhs.x == rhs.x && lhs.y == rhs.y;
        }

        public static explicit operator Vector2(Vector2Int vector)
        {
            return new Vector2(vector.x, vector.y);
        }
    }
}
