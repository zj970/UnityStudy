using System;

namespace Lesson10_函数重载
{
    class Program
    {

        #region 知识点一 基本概念
        //重载概念
        //在同一语句中（class或者struct)中
        //函数（方法）名相同
        //参数的数量不同
        //或者参数的数量相同，但参数的类型或顺序不同

        //作用：
        //1.命名一组功能相似的函数，减少函数名的数量，避免命名空间的污染
        //2.提升程序可读性
        #endregion

        #region 实例
        //注意;
        //1.重载和返回值类型无光，只和参数类型，个数，顺序有关
        //2.调用时，程序会自己根据传入的参数类型判断使用哪一个重载
        static int CalcSum(int a,int b)
        {
            return a + b;
        }

        //参数数量不同
        static int CalcSum(int a, int b,int c)
        {
            return a + b + c;
        }

        //数量相同，类型不同
        static float CalcSum(float a, float b)
        {
            return a + b ;
        }
        //数量相同，类型不同
        static float CalcSum(int  a, float b)
        {
            return a + b;
        }

        //数量相同 顺序不同
        static float CalcSum( float b,int a)
        {
            return a + b;
        }
        //ref 和 out 可以理解成 他们也是一种变量类型 所以可以用在重载中 但是 ref和out不能同时修饰
        static float CalcSum( ref float b, int a)
        {
            return a + b;
        }

        #endregion

        //总结
        //概念：同一个语句块中 ，函数名相同，参数数量、类型、顺序不同的函数，就称为我们的重载函数
        //注意：和返回值无关
        //作用;一般用来处理不同参数的同一类型的逻辑处理
        static void Main(string[] args)
        {
            Console.WriteLine("Lesson10_函数重载");

            Console.Write(CalcSum(2, 3));
            Console.Write(CalcSum(2.1f, 3.5f));
            Console.Write(CalcSum(2, 3,4));
        }
    }
}
