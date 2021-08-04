using System;

namespace Lesson15_继承_万物之父和装箱拆箱
{
    #region 里氏替换知识点回顾
    //概念： 父类容器装子类对象
    //作用：方便进行对象存储和管理
    //使用：
    //is 和 as
    //is 用于判断
    //as 用于转换
    class Father
    {
        //public Father()
        //{

        //}
       
    }

    class Son : Father
    {
        public void Speak()
        {
            Console.WriteLine("你好");
        }
    }
    #endregion

    #region 知识点一 万物之父
    //万物之父
    //关键字 ： object
    //概念：
    //object是所有类型的基类，它是一个类（引用类型）
    //作用：
    //1.可以利用里氏替换原则，用object容器装所有对象
    //2.可以用来表示不确定类型，作为函数参数类型
    #endregion

    class Program
    {
        static void Main(string[] args)
        {
            Father son = new Son();
            if (son is Son)
            {
                (son as Son).Speak();
            }


            #region 知识点二 万物之父的使用
            //引用类型
            object s = new Son();
            s = son;


            //用is as 来判断和转换即可
            if (s is Son)
            {
                (s as Son).Speak();
            }
            //值类型
            object o = 1f;
            //用强转
            float a = (float)o;
            //特殊的string类型
            object str = "132456";
            string str1 = str.ToString();
            string str2 = str as string;

            object arr = new int[3];
            int[] ar = (int[])arr;
            int[] arr2 = arr as int[];
            #endregion

            #region 装箱拆箱
            //发生条件
            //用object存值类型(装箱)
            //再用object转为值类型(拆箱)

            //装箱
            //把值类型用引用类型存储
            //栈内存会迁移到堆内存中
            //造成性能的消耗

            //拆箱
            //把引用类型存储的值类型取出来
            //堆内存会迁移到栈内存中
            
            //好处;不确定类型时可以方便参数的存储和传递
            //坏处:存在内存迁移，增加性能消耗
            #endregion
        }

        //总结
        //万物之父 object
        //基于里氏替换原则的 可以用object容器装载一切类型的变量
        //它是所有类型的基类

        //装箱
        //把值类型用引用类型存储
        //栈内存会迁移到堆内存中

        //拆箱
        //把引用类型存储的值类型取出来
        //堆内存会迁移到栈内存中

        //好处;不确定类型时可以方便参数的存储和传递
        //坏处:存在内存迁移，增加性能消耗
        //不是不用，少用
    }
}
