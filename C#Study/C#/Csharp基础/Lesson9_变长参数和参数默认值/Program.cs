using System;

namespace Lesson9_变长参数和参数默认值
{
    class Program
    {
        #region 知识点一 函数语法的复习
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
        //1.静态关键词 可选 目前必须写
        //2.返回值 没有返回值填void 可以填写任意类型的变量
        //3.函数名 ，帕斯克命名法
        //4.参数可以是0-n 个 前面加 ref 或out 修饰可以从函数内部改变内容的变量
        //5.如果返回类型不是void 必须有return 对应的类型的内容 return k可以打断函数语句块中的逻辑，直接停止后面的逻辑
        #endregion

        #region 知识点二 变长参数关键字
        //举例 函数要计算 n 个 整数的和
        //static int sum (int a,int b.int c,....)

        //变长参数关键字 params

        static int Sum(params int[] arr)
        {
            int sum = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                sum += arr[i];
            }
            return sum;
        }
        //params int[] 意味着可以传入n个int参数 n可以等于0 传入的参数会存在arr数组中
        //注意;
        //1.params关键字后面必为数组
        //2.数组的类型可以是任意数据类型
        //3.函数参数可以有 别的参数和 params 关键字修饰的参数
        //4.函数参数中只能最多出现一个params关键字 并且一定是在最后一组参数 前面可以有n个其他参数

        static void Eat(string a,int b, params int[] c)
        {

        }

        #endregion

        #region 知识点三 参数默认值
        //有参数默认值的参数 一般称为可选参数
        //作用是 当调用函数时可以不传入参数，不传就会使用默认值作为参数的值

        static void Speak(string str = "我无话可说")
        {
            Console.WriteLine(str);
        }

        //注意:
        //1.支持多参数默认值 每个参数都可以有默认值
        //2.如果要昏庸可选参数必须写在 普通参数的后面
        #endregion


        //总结
        //1.变长参数关键字 params
        //作用：可以传入n个同类型参数 n可以是0
        //注意
        //1.params 后面必须跟数组 意味着只能是同一类型的可变参数
        //2.变长参数只能有一个
        //3.必须在所有参数后面写变长参数

        //2.参数默认值（可选参数）
        //作用：可以给参数默认值 使用是不传参 机会引用默认的
        //注意：
        //1.可选参数可以有很多个
        //2.可选参数必须写在所有参数后面
        //
        static void SSS(int a, int c =1,params int[] x)
        {

        }

        static void Main(string[] args)
        {
            Console.WriteLine("Lesson9_变长参数和参数默认值");

            Console.WriteLine(Sum(1, 332, 3, 34, 3, 55, 5));
            Console.WriteLine(Sum(1, 332, 3, 34, 3));
            Speak();
            Speak("15749");
        }
    }
}
