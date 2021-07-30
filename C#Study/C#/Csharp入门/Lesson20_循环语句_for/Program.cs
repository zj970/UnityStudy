using System;

namespace Lesson20_循环语句_for
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Lesson20_循环语句_for");

            #region 知识点一 基本语法
            ////.......
            //for (/*初始表达式*/;/*条件表达式*/;/*增量表达式*/ )
            //{
            //    //循环代码逻辑
            //}
            ////初始表达式：一般声明一个临时变量，用来计数循环次数
            ////条件表达式：表示进入循环的条件
            ////增量表达式：用第一个变量进行自增减

            ////第一次进入时 才会调用
            ////每次进入循环之前 都会判断条件表达式 
            ////执行完循环代码逻辑才执行增量表达式
            #endregion

            #region 知识点二 支持嵌套
            //.......
            #endregion

            #region 知识点三 特殊写法
            //.......也可以写死循环for(;;)
            #endregion

            #region 知识点四 对比while循环
            //.......
            //for循环 一般用来可以准确得到 一个范围中的所有数
            //用for比较多 switch也可以相互转换
            #endregion
        }
    }
}
