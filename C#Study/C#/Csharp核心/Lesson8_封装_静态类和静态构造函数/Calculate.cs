using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson8_封装_静态类和静态构造函数
{
    /// <summary>
    /// 用于提供数学计算的静态类
    /// </summary>
    static class Calculate
    {
        //该类中提供了计算圆面积，圆周长，矩形面积，矩形周长，取一个数的绝对值等方法

        const float PI = 3.1415926f;
        public static float CircleArea(float radius) => radius * radius * PI;
        public static float CirclePerimeter(float radius) => 2 * radius * PI;
        public static float RectangleArea(float height,float weight) => height *weight;
        public static float RectanglePerimeter(float height, float weight) => (height + weight) * 2;
        public static float AbsoluteValue(float value) => value > 0 ? value : -value;
       
    }
}
