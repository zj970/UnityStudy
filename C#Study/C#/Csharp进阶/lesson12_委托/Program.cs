using System;

namespace lesson12_委托
{
    #region 知识点一 委托是什么
    //委托是 函数（方法）的容器
    //可以理解为 表示函数（方法） 的变量类型
    //用来 存储、传递函数（方法）
    //委托的本质是一个类， 用来定义函数（方法）的类型（返回值和参数类型）
    //不同的 函数（方法）必须对应和各自"格式"一致的委托
    #endregion

    #region 知识点二 基本语法
    //关键字： delegate
    //语法：访问修饰符 delegate 返回值 委托名（参数列表）;

    //写在哪里？
    //可以声明在namespace 和 class 语句块中
    //更多的写在namespace中

    //简单记忆委托语法 就是 函数声明语法前面加一个delegate关键字
    #endregion

    #region 知识点三 定义自定义委托
    //访问修饰默认不写 为public 在别的命名空间中也能使用
    //private 其他命名空间就不能用了
    //一般使用public

    //声明了一个可以用来 存储 无参无返回值函数 的容器
    //这里只是定义了规则 并没有使用
    delegate void MyFun();
    //表示用来装载或传递 返回值为int 有一个int参数的函数的 委托 容器规则
     public  delegate int MyFun1(int a);//委托的声明是不能重名的，在同一命名空间中
    #endregion

    #region 知识点四 使用定义好的委托
    //委托变量是函数的容器
    //委托常用在;
    //1.作为类的成员
    //2.作为函数的参数

    class Test
    {
        public MyFun fun;
        public MyFun1 fun1;

        public void TestFun(MyFun fun,MyFun1 fun1)
        {
            //先处理一些别的逻辑 当这些逻辑处理完了 再执行传入的函数
            fun();
            fun1(1);

            this.fun1 = fun1;
        }
        //增
        public void AddFun(MyFun fun,MyFun1 fun1)
        {
            this.fun += fun;
            this.fun1 += fun1;
        }
        //删 多删不会报错
        public void RemoveFun(MyFun fun, MyFun1 fun1)
        {
            this.fun -= fun;
            this.fun1 -= fun1;
        }
      
    }
    #endregion

    #region 知识点五 委托变量可以存储多个函数(多播委托）

    #endregion

  
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            //专门用来装载 函数 的容器
            MyFun f = new MyFun(Fun);
            Console.WriteLine("1"); 
            Console.WriteLine("2"); 
            Console.WriteLine("3"); 
            Console.WriteLine("4");
            f.Invoke();//调用Fun

            MyFun f2 = Fun;
            Console.WriteLine("1");
            Console.WriteLine("2");
            Console.WriteLine("3");
            Console.WriteLine("4");
            Console.WriteLine("4");
            f2();

            MyFun1 f3 = new MyFun1(Fun1);
            Console.WriteLine(f3.Invoke(5));

            Test t = new Test();
            t.TestFun(Fun, Fun1);

            Console.WriteLine("====================================");
            //如何用委托存储多个函数
            MyFun ff = Fun;
            ff += Fun2;
            ff();
            //清空容器
            ff = null;
            if (ff != null)
            {
                ff();
            }

            t.AddFun(Fun, Fun1);
        }
        #region 知识点六 系统定义好的委托
        //无参无返回值 Action
        Action action = Fun;
        //泛型委托 Func 可以指定返回类型
        //Func<int> func = Fun1;
        Func<string> func1 = Fun3;
        //可以传n个参数
        Action<int, string> funs = Fun6;
        //返回值且n个参数
        Func<int, int> funss = Fun1;
        #endregion

        static void Fun()
        {
            Console.WriteLine("1387978/*9/");
        }

        static int Fun1(int value)
        {
            Console.WriteLine("138797");
            return value;
        }


        static void Fun2()
        {
            Console.WriteLine("138*9/");
        }

        static string Fun3()
        {
            return "";
        }
        static void Fun6(int a ,string b)
        {
            Console.WriteLine("138*9/");
        }
    }
    //总结
    //简单理解 委托 就是装载、传递函数的容器而已
    //可以用委托变量 来存储函数或者传递函数的
    //系统提供的
    //Action:没有返回值，可选参数16
    //Func:有返回值，可选参数16
}
