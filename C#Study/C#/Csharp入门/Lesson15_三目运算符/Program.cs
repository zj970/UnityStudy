using System;

namespace Lesson15_三目运算符
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Lesson15_三目运算符");
            #region 知识点一 基本语法
            //套路： 3个空位 2个符号！！！！
            //固定语法：空位       ？ 空位                ：     空位;
            //关键信息：bool类型   ？ bool类型为真返回内容：bool类型为真返回内容;
            //三目运算符 会有返回值 ，这个返回值类型必须一致，并且必须使用
            #endregion

            #region 知识二 具体作用 
            string str = true ? "条件为真" : "条件为假";
            Console.WriteLine(str);

            //第一个空位 始终是结果为bool类型的表达式 bool变量 条件表达式 逻辑运算符表达式
            //第二三个空位 什么表达式都可以 只要保证它们的结果类型是一致的
            #endregion
        }
    }
}
