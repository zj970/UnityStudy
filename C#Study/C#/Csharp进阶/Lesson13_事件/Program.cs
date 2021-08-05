using System;

namespace Lesson13_事件
{
    #region 知识点一 事件是什么
    //事件是基于委托的存在
    //事件是委托的安全包裹
    //让委托的使用更具有安全性
    //事件 是一种特殊的变量类型
    #endregion

    #region 知识点二 事件的使用
    //声明语法:
    //访问修饰符 event 委托类型 事件名
    //事件的使用;
    //1.事件是作为 成员变量存在于类中
    //2.委托怎么用 事件就怎么用
    //事件相对于委托的区别
    //1.不能在类外部 赋值
    //2.不能在类外部 调用
    //注意;
    //它只能作为成员存在于类和接口以及结构体中
    class Test
    {
        //委托成员变量 用于存储 函数的
        public Action myFun;
        //事件成员变量 用于存储 函数的
        public event Action myEvent;

        public Test()
        {
            //事件的使用和委托 一模一样 只是有些 细微的区别
            myFun = TestFun;
            myFun += TestFun; 
            myFun -= TestFun;
            myFun();
            myFun.Invoke();
            myFun = null;

            myEvent = TestFun;
            myEvent += TestFun;
            myEvent -= TestFun;
            myEvent();
            myEvent.Invoke();
            myEvent = null;


        }
         
        public void TestFun()
        {
            Console.WriteLine("123");
        }
    }
    #endregion

    #region 知识点三 为什么有事件
    //1.防止外部随意置空委托
    //2.防止外部随意调用委托
    //3.事件相当于对委托惊进行了 依次封装 让其更加安全
    #endregion

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Test t = new Test();
            //委托可以在外部赋值
            t.myFun = null;
            t.myFun = Tesd;
            //事件不可以赋值，但可以加减运算
            t.myEvent += Tesd;
            //事件不能在外部调用
            //只能在类的内部的封装去调用

            //事件是不能作为临时变量放在函数里

        }
        static void Tesd()
        {


        }

        //总结
        //事件和委托的区别
        //事件和委托的使用基本一模一样的
        //事件是特殊的委托
    }
}
