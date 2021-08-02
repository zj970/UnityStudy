using System;

namespace Lesson11_递归函数
{
    class Program
    {
        #region 知识点一 基本概念
        //递归函数 就是 让函数自己调用自己

        //static void Fun()
        //{
        //    if (true)
        //    {
        //        return;
        //    }
        //    Fun();
        //}
        //一个正确的递归函数
        //1.必须有结束调用的条件
        //2.用于条件判断的 这个条件 必须改变 能够达到停止的目的
        #endregion

        #region 知识点二 实例
        //用递归函数打印0到10

        static void Fun(int a = 0)
        {
            if(a == 11)//构造条件
            {
                return;
            }
            Console.WriteLine(a);//打印
            Fun(++a);//第一步构成一个递归
        }
        #endregion

        static void Main(string[] args)
        {
            Console.WriteLine("Lesson11_递归函数");
            Fun();
        }
    }
}
