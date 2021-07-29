using System;

namespace Lesson7_类型转换_隐式转换_
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Lesson7_类型转换_隐式转换_!");

            //什么是类型转换
            //类型转换就是 不同变量类型之间的转换

            //隐式转换的基本规则--》 不同类型之间自动转换
            //大范围装小范围  ---- 超出范围就会数据溢出


            #region 知识点一 相同大类型之间的转换
            //有符号 long--->int--->short--->sbyte
            long l = 1;
            int i = 1; ;
            short s = 1;
            sbyte sb = 1;
            //隐式转换 int隐式转换成了long
            //可以用大范围 装小范围 的类型（隐式转换）
            l = i;
            //不能用小范围的类型 去 装大范围的类型
            l = i;
            l = s;
            //i = l;
            i = s;
            s = sb;

            //无符号 ulong-->uint-->ushort-->ubyte

            //浮点数 decimal          double --->float
            decimal de = 1.1m;
            double d = 1.1d;
            float f = 1.1f;
            //decimal这个类型没有办法用隐式转换的形式 去存储 double 和 float;
            //de = d;
            //de = f;
            //float是可以隐式转换成 double
            d = f;

            //特殊类型 bool char string 不存在隐式转换
            #endregion


            #region 知识点二 不同大类型之间的转换

            #region 无符号和有符号之间
            //无符号装有符号 --- 不能装负数
            //无符号
            byte b2 = 1;
            ushort us2 = 1;
            uint ui2 = 1;
            ulong ul = 1;
            //有符号
            byte sb2 = 1;
            short s2 = 1;
            int i2 = 1;
            long l2 = 1;
            //有符号 是不能狗 隐式转换成 无符号的

            //有符号装无符号 ---可以
            //前提 无符号的范围 在 有符号的范围内
            #endregion

            #region 浮点数和整数（有、无符号）之间
            //浮点数装整数 整型转换为浮点数 是存在隐式转换的
            float f2 = 1.1f;
            double d2 = 1.1d;
            decimal de2 = 1.1m;
            //浮点数 是可以装载 任何类型的 整数的
            f2 = l2;
            f2 = i2;
            f2 = s2;
            f2 = 1000000000000000000f;
            Console.WriteLine(f2);
            //decrimal 不能隐式转换 double 和float
            //但是可以转所有整型
            //double  --> float --->所有整型
            //decrimal --->所有整型



            //整数装浮点数  整数是不能隐式存储 浮点数 因为整数不能存在 小数
            #endregion

            #region 特殊类型和其他类型

            // bool bool 没有办法和其他类型 相互隐式转化
            bool bo2 = true;

            //char char 没有办法隐式的存储 其他类型的变量
            //char 可以隐式的转换成 整数型和浮点型
            //对应的数字 其实是一个 ASCII 码
            
            //计算机里面存储 二进制
            //字符 中文 英文 标点符号 在计算机中都是一个数字
            //一个字符 对应一个数字 ASCII码就是一种对应关系

            char c2 = 'a';
            i2 = c2;
            l2 = c2;
            Console.WriteLine(i2);
            Console.WriteLine(l2);


            //string  类型 无法和其他类型进行隐式转换


            #endregion


            //总结 隐式转换 规则
            //高精度  （大范围） 装 低精度（小范围)
            // double --> float-->整数(有符号、无符号)-->char
            //decimal -->整数(有符号、无符号)-->char
            // string 和 bool 不参与隐式转换规则
            #endregion

        }
    }
}
