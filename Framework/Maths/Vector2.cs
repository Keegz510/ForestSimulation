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

        /// <summary>
        /// Default Constructor
        /// </summary>
        public Vector2()
        {
            x = 0;
            y = 0;
        }

        /// <summary>
        /// Float Constructor
        /// </summary>
        /// <param name="x">Position X</param>
        /// <param name="y">Postiion Y</param>
        public Vector2(float x, float y)
        {
            this.x = x;
            this.y = y;
        }


        /// <summary>
        /// Creates a new Vector from the specified Vector
        /// </summary>
        /// <param name="vec">Vector to copy</param>
        public Vector2(Vector2 vec)
        {
            x = vec.x;
            y = vec.y;
        }

        /// <summary>
        /// Addition By Vector
        /// </summary>
        /// <param name="lhs">Vector on the left hand side</param>
        /// <param name="rhs">Vector on the right hand side</param>
        /// <returns>Returns the 2 Vectors added together</returns>
        public static Vector2 operator+(Vector2 lhs, Vector2 rhs)
        {
            return new Vector2
            {
                x = lhs.x + rhs.x,
                y = lhs.y + rhs.y
            };
        }

        /// <summary>
        /// Addition by scale
        /// </summary>
        /// <param name="vec">Vector o</param>
        /// <param name="scale">Scale to add to the vector</param>
        /// <returns>A new vector with the scale applied to the vector</returns>
        public static Vector2 operator +(Vector2 vec, float scale)
        {
            return new Vector2
            {
                x = vec.x + scale,
                y = vec.y + scale
            };
        }

        /// <summary>
        /// Addition by scale
        /// </summary>
        /// <param name="vec">Vector o</param>
        /// <param name="scale">Scale to add to the vector</param>
        /// <returns>A new vector with the scale applied to the vector</returns>
        public static Vector2 operator +(float scale, Vector2 vec)
        {
            return new Vector2
            {
                x = vec.x + scale,
                y = vec.y + scale
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

        /// <summary>
        /// Subtraction by scale
        /// </summary>
        /// <param name="vec">Vector o</param>
        /// <param name="scale">Scale to add to the vector</param>
        /// <returns>A new vector with the scale applied to the vector</returns>
        public static Vector2 operator -(Vector2 vec, float scale)
        {
            return new Vector2
            {
                x = vec.x - scale,
                y = vec.y - scale
            };
        }

        /// <summary>
        /// Subtraction by scale
        /// </summary>
        /// <param name="vec">Vector o</param>
        /// <param name="scale">Scale to add to the vector</param>
        /// <returns>A new vector with the scale applied to the vector</returns>
        public static Vector2 operator -(float scale, Vector2 vec)
        {
            return new Vector2
            {
                x = vec.x - scale,
                y = vec.y - scale
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


        /// <summary>
        /// Multiply by scale
        /// </summary>
        /// <param name="vec">Vector o</param>
        /// <param name="scale">Scale to add to the vector</param>
        /// <returns>A new vector with the scale applied to the vector</returns>
        public static Vector2 operator *(Vector2 vec, float scale)
        {
            return new Vector2
            {
                x = vec.x * scale,
                y = vec.y * scale
            };
        }

        /// <summary>
        /// Multiply by scale
        /// </summary>
        /// <param name="vec">Vector o</param>
        /// <param name="scale">Scale to add to the vector</param>
        /// <returns>A new vector with the scale applied to the vector</returns>
        public static Vector2 operator *(float scale, Vector2 vec)
        {
            return new Vector2
            {
                x = vec.x * scale,
                y = vec.y * scale
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

        /// <summary>
        /// Divide by scale
        /// </summary>
        /// <param name="vec">Vector o</param>
        /// <param name="scale">Scale to add to the vector</param>
        /// <returns>A new vector with the scale applied to the vector</returns>
        public static Vector2 operator /(Vector2 vec, float scale)
        {
            return new Vector2
            {
                x = vec.x / scale,
                y = vec.y / scale
            };
        }

        /// <summary>
        /// Divide by scale
        /// </summary>
        /// <param name="vec">Vector o</param>
        /// <param name="scale">Scale to add to the vector</param>
        /// <returns>A new vector with the scale applied to the vector</returns>
        public static Vector2 operator /(float scale, Vector2 vec)
        {
            return new Vector2
            {
                x = vec.x / scale,
                y = vec.y / scale
            };
        }

        public static bool operator==(Vector2 lhs, Vector2 rhs)
        {
            if(lhs.x == rhs.x && lhs.y == rhs.y)
            {
                return true;
            }

            return false;
        }

        public static bool operator !=(Vector2 lhs, Vector2 rhs)
        {
            if (rhs == lhs)
                return false;

            return true;
        }

        public override string ToString()
        {
            return String.Format("X: {0}, Y: {1}", x, y);
        }
    }
}
