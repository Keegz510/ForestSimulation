using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Maths
{
    public class Vector2
    {
        /// Position Properties
        float x, y;

        public Vector2()
        {
            x = 0;
            y = 0;
        }

        public Vector2(float x, float y)
        {
            this.x = x;
            this.y = y;
        }

        public Vector2(Vector2 vec)
        {
            x = vec.x;
            y = vec.y;
        }

        public static Vector2 operator+(Vector2 lhs, Vector2 rhs)
        {
            return new Vector2
            {
                x = lhs.x + rhs.x,
                y = lhs.y + rhs.y
            };
        }

        public static Vector2 operator +(Vector2 lhs, float scale)
        {
            return new Vector2
            {
                x = lhs.x + scale,
                y = lhs.y + scale
            };
        }

        public static Vector2 operator +(float scale, Vector2 rhs)
        {
            return new Vector2
            {
                x = rhs.x + scale,
                y = rhs.y + scale
            };
        }

        public static Vector2 operator -(Vector2 lhs, Vector2 rhs)
        {
            return new Vector2
            {
                x = lhs.x - rhs.x,
                y = lhs.y - rhs.y
            };
        }

        public static Vector2 operator -(Vector2 lhs, float scale)
        {
            return new Vector2
            {
                x = lhs.x - scale,
                y = lhs.y - scale
            };
        }

        public static Vector2 operator -(float scale, Vector2 rhs)
        {
            return new Vector2
            {
                x = rhs.x - scale,
                y = rhs.y - scale
            };
        }

        public static Vector2 operator *(Vector2 lhs, Vector2 rhs)
        {
            return new Vector2
            {
                x = lhs.x * rhs.x,
                y = lhs.y * rhs.y
            };
        }

        public static Vector2 operator *(Vector2 lhs, float scale)
        {
            return new Vector2
            {
                x = lhs.x * scale,
                y = lhs.y * scale
            };
        }

        public static Vector2 operator *(float scale, Vector2 rhs)
        {
            return new Vector2
            {
                x = rhs.x * scale,
                y = rhs.y * scale
            };
        }

        public static Vector2 operator /(Vector2 lhs, Vector2 rhs)
        {
            return new Vector2
            {
                x = lhs.x / rhs.x,
                y = lhs.y / rhs.y
            };
        }

        public static Vector2 operator /(Vector2 lhs, float scale)
        {
            return new Vector2
            {
                x = lhs.x / scale,
                y = lhs.y / scale
            };
        }

        public static Vector2 operator /(float scale, Vector2 rhs)
        {
            return new Vector2
            {
                x = rhs.x / scale,
                y = rhs.y / scale
            };
        }
    }
}
