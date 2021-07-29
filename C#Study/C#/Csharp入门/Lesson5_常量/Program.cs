using System;

namespace Lesson5_常量
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("常量");
            #region 知识点一 常量的声明
            //关键字  const
            //固定写法
            //const <type> <name> = <initilization>
            //常量的声明——————跟C一样
            const int i = 2;
            #endregion

            #region 知识点 常量的特点
            //1.必须初始化
            //2.不能修改

            //变量声明可以不初始化
            string name;
            //之后再来修改
            name = "周健";
            //作用：声明一些常用不变的变量
            //例如PI，context报文，网址等。。。

            #endregion
        }
    }
}
