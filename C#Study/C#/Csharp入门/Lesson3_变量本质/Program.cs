using System;

namespace Lesson3_变量本质
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 变量类型回顾
            //有符号
            //sbyte (-128 - 127)
            //int (-21亿-21亿)
            //short (-32768 -- 32767)
            //long (-900万兆 -- 900万兆)

            //无符号   c中用unsigned修饰范围只有一半
            //byte (0-255)
            //uint (0-42亿) 
            //ushort (0-6万多)
            //ulong (0-1800万兆)

            //浮点数
            //float (7/8位有效数字)
            //double (15 -17位有效数字)
            //decimal (27-28位有效数字)

            //特殊
            //bool (true 和 false)
            //char (单个字节用单引号)
            //string (用双引号存储多个字节--一个字节等于8bit)
            #endregion

            #region 知识点一 变量的存储空间（内存中）
            //ibyte = 8bit
            //1KB =1024byte
            //1MB = 1024KB
            //1GB = 1024MB
            //1TB = 1024GB

            //通过sizeof方法可以获取变量类型所占的内存空间（字节），在c中添加string.h,也有sizeof函数
            Console.WriteLine("-----------------------------有符号----------------------------");
            int sbyteSize = sizeof(sbyte);
            Console.WriteLine("sbyte 所占的字节数 ：\t" + sbyteSize);
            int shortSize = sizeof(short);
            Console.WriteLine("short 所占的字节数 ：\t" + shortSize);
            int intSize = sizeof(int);
            Console.WriteLine("int 所占的字节数 ：\t" + intSize);
            int longSize = sizeof(long);
            Console.WriteLine("long 所占的字节数 ：\t" + longSize);

            Console.WriteLine("-----------------------------无符号----------------------------");
            int byteSize = sizeof(byte);
            Console.WriteLine("byte 所占的字节数 ：\t" + byteSize);
            int ushortSize = sizeof(ushort);
            Console.WriteLine("ushort 所占的字节数 ：\t" + ushortSize);
            int uintSize = sizeof(uint);
            Console.WriteLine("uint 所占的字节数 ：\t" + uintSize);
            int ulongSize = sizeof(long);
            Console.WriteLine("ulong 所占的字节数 ：\t" + ulongSize);

            Console.WriteLine("-----------------------------浮点数----------------------------");
            int floatSize = sizeof(float);
            Console.WriteLine("float 所占的字节数 ：\t" + floatSize);
            int doubleSize = sizeof(double);
            Console.WriteLine("double 所占的字节数 ：\t" + doubleSize);
            int decimalSize = sizeof(decimal);
            Console.WriteLine("decimal 所占的字节数 ：\t" + decimalSize);


            Console.WriteLine("-----------------------------特殊类型----------------------------");
            int boolSize = sizeof(bool);
            Console.WriteLine("bool 所占的字节数 ：\t" + boolSize);
            int charSize = sizeof(char);
            Console.WriteLine("char 所占的字节数 ：\t" + charSize);

            //sizeof是不能得到string类型所占内存大小
            //因为它的长度是可变的,但是C中可以用strlen函数求得字符串长度，sizeof也可以，但不会遇到\0停止
            //C#中汉字占3个字节，char占两个字节。。。。

            #endregion

            #region 知识点二 变量的本质
            //变量的本质是二进制--》计算机中所有数据的本质都是二进制 是一堆0和1
            //为什么是二进制？
            //数据传递只能通过电信号，只有开和关两种状态。所以就用0和1来表示这两种状态
            //计算机中的存储单位最小为bit（位），它只能表示0和1两个数字
            //1bit 就是1个数 要不是0，要不是1
            //为了方便数据表示
            //出现了一个叫byte(字节)的单位，它是由8个bit组成的存储单元
            //所以我们一般说一个字节（byte) = 8个bit
            //即 1byte = 0000 0000 
            //二进制和十进制的对比
            //二进制和十进制之间的转换
            //注意浮点数是以----------指数---------的方式存储
            //单精度占用4个字节，共32位bit.其格式为：
            //1位符号， 8位指数，23位小数
            #endregion
        }
    }
}
