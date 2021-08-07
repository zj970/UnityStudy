using System;
using System.Collections.Generic;
using System.Text;

namespace Lsson7_函数
{
    class Exercises
    {
        const float PI = 3.1415926f;

        /// <summary>
        /// 比较两个数字的大小，返回最大值
        /// </summary>
        /// <param name="a">浮点数</param>
        /// <param name="b">浮点数</param>
        /// <returns></returns>
        public  float Compare(float a, float b)
        {
            return a > b ? a : b;
        }

        /// <summary>
        /// 返回浮点数组，第一位是圆的面积。第二位是圆的周长
        /// </summary>
        /// <param name="r">圆的半径</param>
        /// <returns></returns>
        public  float[] Compute(float r)
        {
            return new float[] { PI * r * r, 2 * r * PI };
        }

        /// <summary>
        /// 计算数组的总和，最大值，最小值，平均值，并返回
        /// </summary>
        /// <param name="array">传入数组</param>
        /// <returns></returns>
        public  float[] Compute(int[] array)
        {
            int sum = 0;
            float avg = 0;
            int min = array[1];
            int max = array[1];
            for (int i = 0; i < array.Length; i++)
            {
                sum += array[i];
                max = max < array[i] ? array[i] : max;
                min = min < array[i] ? min : array[i];
            }
            avg = sum / array.Length;
            return new float[] { sum, max, min, avg };
        }

        /// <summary>
        /// 判断是否为质数
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool IsPrime(int value)
        {
            bool isPrime = true;//标识位

            for (int i = 2; i < value; i++)
            {
                if (value % i == 0)
                {
                    isPrime = false;
                }
            }
            return isPrime;
        }

        /// <summary>
        /// 判断是否为闰年
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public static bool IsLeapYear(int year)
        {
            return (year % 4 == 0 && year % 100 != 0 || year % 400 == 0) ? true : false;
        }

    }
}

