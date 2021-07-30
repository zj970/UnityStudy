using System;

namespace Lesson18_循环语句_while
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Lesson18_循环语句_while");

            #region 知识点一 作用
            //让顺序执行的代码 可以不停的循环执行某一代码块的内容
            //条件分支语句 是 让代码产生分支
            //循环语句 是 让代码可以被重复执行
            #endregion

            #region 知识点二 语法相关
            //先判断条件
            //// bool 类型变量 条件运算符 逻辑运算符
            //while (bool类型的值（条件）)
            //{
            //    满足执行
            //        执行一次
            //        判断一次
            //     满足再执行
            //}
            //死循环会造成程序卡死，会因为内存问题 造成程序奔溃闪退
            //int i = 0;
            //while (i < 10)
            //{
            //    ++i;
            //}
            #endregion

            #region 知识点三 嵌套使用
            //可以嵌套if switch 等等
            //int a2 = 0;
            //while (a2 <10)
            //{
            //    ++a2;
            //    int b2 = 0;
            //    b2++;

            //    每次从外层循环进来
            //        b2和上一次b2 没有关系!!!!!!!作用域，时间
            //}
            //Console.WriteLine()
            #endregion

            #region 知识点四 流程控制关键词
            //作用 ：控制循环逻辑的关键词
            //break:跳出最里层循环
            //continue;跳出此次循环
            //return 退出整个循环
            #endregion
        }
    }
}
