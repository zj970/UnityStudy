using System;

namespace Lsson7_函数
{
    class Program
    {
        #region 知识点一 基本概念
        //函数（方法）
        //本质上是一块具有名称的代码块
        //可以使用函数（方法）的名称来执行该代码块
        //函数（方法) 是封装代码进行重复使用的一种机制

        //函数（方法）  的主要作用
        //1.封装代码
        //2.提升代码复用率（少写代码）
        //3.抽象行为
        #endregion

        #region 知识点二 函数写在哪里
        //1.class语句块中
        //2.struct语句块中
        #endregion

        #region 知识点三 基本语法
        //  1       2       3                       4
        //static 返回类型 函数名(参数类型 参数名1.参数类型 参数名2.参数类型 参数名3...)
        //{
        //  函数的代码逻辑;
        //  函数的代码逻辑;
        //  函数的代码逻辑;
        // .......
        //  5
        // return 返回值;(如果有返回类型才返回)
        //}

        //1.关于static 不是必须的，在没有学习类和结构体之前，都是必须写的
        //2-1. 关于返回类型 引出一个新的关键字 void(表示没有返回值)
        //2-2. 返回类型 可以写任意的变量类型 14种变量类型+复杂数据类型(数组，枚举，结构体，类Class)
        //3.关于函数名 使用帕斯卡命名法命名 myName(驼峰命名法) MyName(帕斯卡命名法)
        //4-1.参数不是必须的，可以有0-n个参数 参数的类型可以是 14种变量类型+复杂数据类型(数组，枚举，结构体，类Class)
        //     多个参数时，需要用逗号,隔开
        //4-2.参数名 --驼峰命名法
        //5.当返回值类型不为void时 必须通过新的关键词 return 返回对应类型的内容 （注意：即使是void 也可以选择性使用return)
        #endregion

        #region 知识点四 实际应用
        //1.无参无返回值函数

        static void SayHello()
        {
            //函数语句块
            Console.WriteLine("Hello,World");
        }

        //2.有参无返回值函数

        static void SayYourName(string name)
        {
            Console.WriteLine("你的名字是：{0}", name);
        }

        //3.无参有返回值函数

        static string WhatYourName()
        {
            return "周健";
        }

        //4.有参有返回值函数
        static int Sum(int a, int b)
        {
            return a + b;//return 后面可以写一个表达式 只要这个表达式的结果和返回值类型是一致的
        }
        //5.有参有多返回值函数=================================

        //传入两个数 然后计算两个数的和 以及它们俩的平均数 得出结果返回出来
        //函数的返回值 一定是一个类型 只能是一个内容
        static int[] Calc(int a, int b)
        {
            //如果用数组作为返回值出去 要知道数组的大小
            return new int[] { a + b,(a + b) / 2 };
        }

        #endregion

        #region 知识点五 关于return
       //即使函数没有返回值，我们也可以使用return;
       //return 可以直接不执行之后的代码，直接返回函数外部
        #endregion

        //总结
        //1.基本概念
        //2.函数写在哪里 -- class 或者 struct中
        //3.基本语法12345
        //4.return 可以提前结束函数逻辑 程序是线性执行的 从上到下

        static void Main(string[] args)
        {
            Console.WriteLine("Lsson7_函数");

            //使用函数 直接写 函数名（参数） 即可
            SayHello();//断点F11
            SayYourName(Console.ReadLine());//断点测试 F11一步一步执行代码
            SayYourName(WhatYourName());//断点测试 F11一步一步执行代码
            Console.WriteLine("3+5结果是" + Sum(3, 5));

            int[] arr = Calc(5,7);
            Console.WriteLine(arr[0] + " " + arr[1]);

            for (int i = 0; i < 99; i++)
            {
                for (int j = 0; j < 11; j++)
                {
                    if (i == 8 || j ==8)
                    {
                        Console.WriteLine("test");
                        break;
                        //return;
                    }
                }
            }

            Console.WriteLine("test-----------------------------------------------");
        }
    }
}
