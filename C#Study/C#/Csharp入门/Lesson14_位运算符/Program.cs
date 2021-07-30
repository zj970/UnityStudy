using System;

namespace Lesson14_位运算符
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Lesson14_位运算符");
            //位运算 主要用数值类型进行计算的
            //将数值转换位二进制在进行位计算

            #region 知识点一 位与 &
            //规则 连接两个数值进行位计算 将数值转为二进制
            //对位计算 有0则0
            int a = 1;
            int b = 5;
            int c = a & b;//1
            Console.WriteLine(c);
            //多个数值进行位计算 没有括号时 从左到右 依次计算
            //有括号则先算括号内
            #endregion

            #region 知识点二 位或 |
            //规则 连续两个数值进行位计算 将数值转换为二进制
            //位或计算 有1则1
             a = 1;
             b = 5;
             c = a | b;//5
            Console.WriteLine(c);
            #endregion

            #region 知识点三 异或 ^
            //规则 连续两个数值进行位计算 将数值转换为二进制
            //异或 同0反1
            a = 1;
            b = 5;
            c = a ^ b;//4
            Console.WriteLine(c);
            #endregion

            #region 知识点四 位取反 ~
            //规则 连接两个数值进行位计算 将数值转为二进制
            //位取反 ~ 0变1，1变0 
            c = 5;
            c = ~c;//-6
            //0000 0000 0000 0000 0000 0000 0000 0101
            //~0000 0000 0000 0000 0000 0000 0000 0101
            //1111 1111 1111 1111 1111 1111 1111 1010
            //负数先取反码
            //0000 0000 0000 0000 0000 0000 0000 0101 然后加1 
            //1000 0000 0000 0000 0000 0000 0000 0110补码
            //反码补码知识
            Console.WriteLine(c);
            #endregion

            #region 知识点五 左移<<   右移>>
            //规则 让一个数的二进制数进行左移或者右移
            //左移几位 右侧加几个0
            a = 5;//101
            c = a << 5;
            Console.WriteLine(c);//160
            //1位 1010
            //...
            //5位 10100000


            //右移几位 右侧去掉几个0
            a = 5;//101
            c = a >> 2;
            Console.WriteLine(c);//1
            //1位 10
            //2位 1

            #endregion

        }
    }
}
