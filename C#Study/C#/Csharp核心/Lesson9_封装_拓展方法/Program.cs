using System;

namespace Lesson9_封装_拓展方法
{
    #region 知识点一 拓展方法的基本概念
    //概念
    //为现有非静态类 变量类型添加 新方法
    //作用
    //1.提升程序拓展性
    //2.不需要在对象中重写方法
    //3.不需要要继承来添加方法
    //4.为别人封装的类型写额外的方法

    //特点
    //1.一定是写在静态类中
    //2.一定是个静态函数
    //3.第一个参数为拓展目标
    //4.第一个参数用this修饰
    #endregion

    #region 知识点二 基本语法
    //访问修饰符 static 返回值 函数名(this 拓展类名 参数名，参数类型 参数名，参数类型 参数名，，，）
    #endregion

    #region 知识点三 实例
    static class Tools
    {
        //为int拓展了一个成员方法
        //成员方法 是需要 实例化对象后 才能使用的
        //value 代表 使用该方法的 实例化对象
        public static  void SpeakValue(this int value)
        {
            //拓展的方法 的逻辑
            Console.WriteLine("为int拓展的方法" + value);
        }

        public static void SpeakStringInfo(this string str,string str1,string str2)
        {
            Console.WriteLine("为string拓展的方法" );
            Console.WriteLine("拓展方法的对象-------"+str );
            Console.WriteLine("传的参数"+str1+"-------"+str2 );
        }

        public static void Fun3(this Test t)
        {
            Console.WriteLine("拓展方法");
        }
    }
    #endregion


    #region 知识点五 为自定义的类型拓展方法

    //注意
    //如果拓展方法和原来方法一致，会执行原来方法
    class Test
    {
        public int i = 10;
        public void Fun1()
        {
            Console.WriteLine("第一个方法");
        }
        public void Fun3()
        {
            Console.WriteLine("第二个方法");
        }
    }
    #endregion

    class Program
    {
        static void Main(string[] args)
        {
            #region 知识点四 使用
            int i = 10;
            i.SpeakValue();//拓展的方法

            string name = "周健";
            name.SpeakStringInfo("报错", "警告");

            Test t = new Test();
            t.Fun3();
            #endregion

            //总结
            //概念：为现有的非静态 变量类型 添加方法
            //作用
            //提升程序拓展性
            //不需要再在对象中重新写方法
            //不需要继承来添加方法
            //为别人封装的类型写额外的方法

            //特点;
            //静态类中的静态方法
            //第一个参数this 代表拓展的目标
            //前面必须加this

            //注意;
            //可以有返回值 和 n个参数
            //根据需求而定
        }
    }
}
