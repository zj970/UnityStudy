using System;

namespace Lesson15_lambad表达式
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Lesson15_lambad表达式");

            #region 知识点一 什么是lambad表达式
            //可以将lambad表达式 理解为匿名函数的简写
            //它除了写法不同外
            //使用上和匿名函数一模一样
            //都是和委托或者事件 配合使用的
            #endregion

            #region 知识点二 lambad表达式语法
            //匿名函数
            //delegate(参数列表)
            //{
            //};

            //lambad表达式
            //(参数列表) =>
            //{
            //  函数体;
            //};
            #endregion

            #region 知识点三 使用
            //1.无参无返回
            Action a = () => { Console.WriteLine("无参无返回的lambad表达式"); };
            a();
            //2.有参
            Action<string> c = (string b) => { Console.WriteLine("有参数的" + b); };
            c("昵称    顶顶顶顶");
            //3.甚至参数类型都可以省略 参数类型和委托或事件容器一致
            Action<string, int> b = (a, b) => { Console.WriteLine("多参数(省略)："+a+b); };
            b("132464你", 2134);
            //4.有返回值
            Func<string, int> fc = (value) => { Console.WriteLine(value+"\t");return 0; };
            Console.WriteLine(fc("1567"));
            //其他传参使用等和匿名函数一样
            //缺点和匿名函数一样
            #endregion

            Test n = new Test();
            n.DoSomething();
        }
    }

    #region 知识点四 闭包
    //内存的函数可以引用包含在它外层的函数的变量
    //计实外层函数的执行已经终止
    //注意;
    //该变量提供的值并非变量创建时的值，而是在父函数范围内的最终值

    class Test
    {
        public event Action action;

        public Test()
        {
            int value = 10;
            //这里就形成了闭包
            //因为 当构造函数执行完毕时 其中声明的临时变量value的生命周期被改变了
            action = () =>
            {
                Console.WriteLine(value);
            };
            for (int i = 0; i < 10; i++)
            {
                //此index非index;
                int index = i;
                action += () =>
                {
                    Console.WriteLine(i);
                };
                action += () =>
                {
                    Console.WriteLine(index);
                };
            }
        }

        public void DoSomething()
        {
            action();
        }
    }
    #endregion

    //总结
    //匿名函数的特殊写法 就是lambad表达式
    //固定写法 (参数列表)=>{};
    //参数列表 可以直接省略参数类型
    //主要在 委托传递和存储时 为了方便可以直接使用匿名函数或者lambad表达式

    //缺点：无法指定移除
}
