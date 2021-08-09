using System;

namespace Lesson24_值和引用
{
    class Test
    {

    }

    struct TestStruct
    {
        public Test t;
        public int i;
    }

    #region 知识回顾
    //值类型
    //无符号：byte,ushort,uint,ulong
    //有符号: sbyte,short,int,long
    //浮点数：float,double.decrimal
    //特殊: char,bool
    //枚举: enum
    //结构体:struct

    //引用类型
    //string
    //数组
    //class
    //interface
    //委托

    //值类型和引用类型的本质区别
    //值的具体内容存在栈内存上
    //引用的具体内容存在堆内存上
    #endregion

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Lesson24_值和引用");

            #region 问题一 如何判断 值类型和引用类型
            //F12 进到类型的内部去查看
            //是class就是引用
            //是struct就是值
            #endregion

            #region 问题二 语句块
            //命名空间
            //    ⬇
            //类、接口、结构体
            //    ⬇
            //函数、属性、索引器、运算符重载等（类、接口、结构体）
            //    ⬇
            //条件分支、循环

            //上层语句块：类、结构体
            //中层语句块：函数
            //底层的语句块：条件分支 循环等

            //我们的代码逻辑写在哪里？
            //函数、条件分支、循环-中层底层语句块中

            //我们的变量可以声明在哪里
            //上、中、底部能声明变量
            //上层语句块中：成员变量
            //中、底层语句块中：临时变量
            #endregion

            #region 问题三 变量的生命周期
            //变量的生命周期
            //在中底层声明的临时变量（函数、条件分支、循环语句块等）
            //语句块执行结束
            //没有被记录的对象将被回收或变成垃圾
            //值类型：被系统自动回收
            //引用类型:栈上用于存地址的房间被系统自动回收，堆中具体内容变成垃圾，待下次GC回收

            //想要不被回收或者不变垃圾
            //必须将其记录下来
            //如何记录？
            //在更高层级记录 或者 使用静态全局变量记录

            #endregion

            #region 问题四 结构体中的值和引用
            //结构体本身就是值类型
            //前提：该结构体没有作为其他类的成员
            //在结构体中的值，栈中存储值具体的内容
            //在结构体中的引用，堆中存储引用具体的内容

            //引用类型始终存储在堆中
            //真正通过结构体使用其中引用类型时，只是顺藤摸瓜
            TestStruct ts = new TestStruct();
            ts.t = new Test();
            #endregion

            #region 问题五 类中的值和引用
            //类本身是引用类型
            //在类中的值，堆中存储具体的值
            //在类中的引用，堆中存储具体的值

            //值类型跟着大哥走，引用类型一根筋
            #endregion

            #region 问题六 数组中的存储规则
            //数组本身就是引用类型
            //值类型数组，堆中房间存在具体内容
            //引用类型数组，堆中房间存地址
            #endregion

            #region 问题七 结构体继承接口
            //利用里氏替换原则，用接口容器装载结构体存在装箱拆箱
            TestS obj = new TestS();
            obj.Value = 1;
            Console.WriteLine(obj.Value);
            TestS obj2 = obj;
            obj.Value = 2;
            Console.WriteLine(obj.Value);
            Console.WriteLine(obj2.Value);

            ITest iobj1 = obj;//装箱 value = 1
            ITest iobj2 = iobj1;//装箱
            iobj2.Value = 999;
            Console.WriteLine(iobj2.Value);
            Console.WriteLine(iobj1.Value);

            TestS obj3 = (TestS)iobj1;//拆箱
            
            #endregion
        }
    }

    interface ITest
    {
        int Value
        {
            get;
            set;
        }
    }
    struct TestS : ITest
    {
        private int val;
        public int Value
        {
            get
            {
                return val;
            }
            set
            {
                val = value;
            }
        }
    }
}
