using System;

namespace Lesson6_转义字符
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("转义字符");


            #region 知识点一 转义字符的使用
            //什么是转义字符
            //它是字符串的一部分 用来表示一些特殊含义的字符
            //比如：字符串中表现 单引号 引号 空行等等
            //string str = "asdl"fk";

            //常用转义字符
            //单引号\'
            string str = "\'哈哈哈\'";
            Console.WriteLine(str);

            //双引号
            str = "\"哈哈哈\"";
            Console.WriteLine(str);

            //换行
            str = "1231564654\n14564551556549";
            Console.WriteLine(str);

            //斜杆 计算机路径是需要斜杠
            //str = "很好\\很好"
            str = @"哈哈\哈";
            Console.WriteLine(str);


            //不常用转义字符（了解）
            //制表符 \t
            str = "哈哈\t哈";

            //光标退格 \b
            str = "123\b123";
            Console.WriteLine(str);

            //空字符 \0
            str = "1234\01234";
            Console.WriteLine(str);
            //警报音 \a
            str = "1234\a1234";
            Console.WriteLine(str);
            #endregion

            #region 知识点二 取消转义字符
            //加---------@------------
            #endregion
        }
    }
}
