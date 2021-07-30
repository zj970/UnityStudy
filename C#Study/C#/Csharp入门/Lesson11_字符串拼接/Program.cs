using System;

namespace Lesson11_字符串拼接
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Lesson11_字符串拼接");

            #region 字符串拼接方式 +
            //之前的算数运算符 只是用来数值类型变量进行数学运算的\
            //而 sring 不存在算数运算符不能计算 但是可以通过+ 来进行拼接
            //用+进行字符串拼接
            string str = "123";
            str = str + "456";
            Console.WriteLine(str);
            //复合运算+=
            str += 1 + 2 + 3 + 4;//结果123456------10
            Console.WriteLine(str);

            str += "" + 1 + 2 + 3 + 4;
            Console.WriteLine(str);//结果123456----101234

            str += 1 + 2 + "" + 3 + 4;//结果123456101234----334
            Console.WriteLine(str);
            //注意字符串的运算方式
            #endregion

            #region 字符串拼接方式 string.Format
            //固定语法
            //string.Format("待拼接的内容",内容1，内容2，.....);
            //拼接内容的固定规则 后面的内容大于等于占位数
            //想要被拼接的内容用占位符替代{数字}数字：0-n,依次往后
           Console.WriteLine( string.Format("我是{0},我今年{1},我要{2}", "周健", 18, "天天向上"));
            #endregion
        }
    }
}
