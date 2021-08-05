using System;

namespace Lesson5_泛型
{
    #region 知识点一 泛型是什么
    //泛型实现了类型参数化，达到代码重用目的
    //通过类型参数化来实现同一份代码上操作多种类型

    //泛型相当于类型占位符
    //定义类或方法时使用替代符代表变量类型
    //当真正使用类或者方法时再具体指定类型
    #endregion

    #region 知识点二 泛型分类
    //泛型类和泛型接口
    //基本语法;
    //class 类名<泛型占位字母>
    //interface 接口名<泛型占位字母>

    //泛型函数
    //基本语法;函数名<泛型占位字母>(参数列表）

    //注意：泛型占位字母可以有很多个，用逗号分开
    #endregion

    #region 知识点三 泛型类和接口
    class TestClass<T, K>
    {
        public T value;
    }

    interface IIestInter<T>
    {
        T Value
        {
            set;
            get;
        }
    }

    class Test : IIestInter<int>
    {
        public int Value { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }

    class Test1 : IIestInter<string>
    {
        public string Value { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
    #endregion

    #region 知识点四 泛型方法
    //1.普通类中的泛型方法
    class Tes
    {
        public void TestFun<T>(T vale,T ve)
        {
            Console.WriteLine(vale +""+ ve);
        }

        public void TestFun<T>()
        {
            T t = default(T);
            Console.WriteLine(t);
        }

        public T TestFun<T>(T v)
        {
            return default(T);
        }
    }
    //泛型类中的泛型方法
    class Test2<T>
    {
        public T value;
        
        //这个不叫泛型方法 因为 T是泛型类声明的时候 就 制定了 在使用这个函数的类型
        //我们就不能再去动态的变化了
        public void TestFun(T t)
        {

        }
        public void TestFun<A>(A t)
        {
            Console.WriteLine(t);
        }

    }
    #endregion

    #region 知识点五 泛型的作用

    #endregion

    #region 总结

    #endregion


    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            TestClass<string,int> t = new TestClass<string,int>();
            t.value = "198798";
            Console.WriteLine(t.value);

            TestClass<int, int> s = new TestClass<int, int>();
            s.value = 1567;
            Console.WriteLine(s.value);

            Tes tt = new Tes();
            tt.TestFun<string>("123456");

            Test2<int> tst = new Test2<int>();
            tst.TestFun<string>("1657489"); 
            tst.TestFun<int>(134);
            tst.TestFun("1657489");
        }
    }
}
