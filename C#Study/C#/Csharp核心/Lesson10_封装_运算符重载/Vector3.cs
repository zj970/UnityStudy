using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson10_封装_运算符重载
{
    struct Vector2
    {
        public float x;
        public float y;
        public static bool operator ==(Vector2 v1, Vector2 v2) => (v1.x == v2.x) && (v1.y == v2.y) ? true : false;
        public static bool operator !=(Vector2 v1, Vector2 v2) => (v1.x != v2.x) || (v1.y != v2.y) ? true : false;
    }
    class Vector3
    {
        private float x;
        private float y;
        private float z;

        public Vector3(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
        /// <summary>
        /// 实现三维向量的相加
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static Vector3 operator +(Vector3 v1, Vector3 v2) => new Vector3(v1.x + v2.x, v1.y + v2.y, v1.z + v2.z);
        /// <summary>
        /// 实现三维向量的相减
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static Vector3 operator -(Vector3 v1, Vector3 v2) => new Vector3(v1.x - v2.x, v1.y - v2.y, v1.z - v2.z);

        public static Vector3 operator *(Vector3 v1, float value) => new Vector3(v1.x * value, v1.y * value, v1.z * value);


    }
}
