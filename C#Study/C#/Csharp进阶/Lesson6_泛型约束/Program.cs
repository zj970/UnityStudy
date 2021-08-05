using System;

namespace Lesson6_泛型约束
{
    #region 知识回顾
    //泛型类
    class Test<T, U>
    {
        public T valuea;
        public U valueb;

        //非泛型方法
        public void Fun<T>()
        {
            Console.WriteLine();
        }
        //泛型方法
        public void Fun<S>(S s)
        {
            Console.WriteLine(s);
        }
    }
    #endregion

    #region 知识点一 什么是泛型约束
    //让泛型的类型有一定的限制
    //关键字：where
    //泛型约束一共有6种
    //1.值类型                             where 泛型字母:struct
    //2.引用类型                           where 泛型字母:class
    //3.存在无参公共构造函数               where 泛型字母:new()
    //4.某个类本身或者其派生类             where 泛型字母:类名
    //5.某个接口的派生类型                 where 泛型字母:接口名
    //6.另一个泛型类型本身或者派生类型     where 泛型字母:另一个泛型字母

    //基本语法 where 泛型字母:(约束的类型)
    #endregion

    #region 知识点二 各泛型约束讲解
    class Test
    {

    }
    //值类型约束
    class Test1<T> where T : struct
    {
        public T value;
        public void TestFun<K>(K k) where K : struct
        {

        }
    }
    //引用类型约束
    class Test2<T> where T : class
    {
        public T value;
        public void TestFun<K>(K k) where K : class
        {

        }
    }
    //存在无参公共构造函数的非抽象类
    class Test3<T> where T : new()
    {
        public T value;
        public void TestFun<K>(K k) where K : new()
        {

        }
    }
    //类的约束 不能是泛类
    class Test4<T> where T : Test
    {
        public T value;
        public void TestFun<K>(K k) where K : Test
        {

        }
    }
    //接口约束
    interface IFly
    {

    }
    class Test5 : IFly
    {

    }
    class Test5<T, U> where T : U
    {
        public T value;
        public void TestFun<K>(K k) where K : IFly
        {

        }
    }
    //另一个泛型约束
    class Test6<T> where T : IFly
    {
        public T value;
        public void TestFun<K>(K k) where K : IFly
        {

        }
    }
    #endregion

    #region 知识点三 约束的组合使用
    class Test<T> where T:class,new()
    {

     }
    #endregion

    #region 知识点四 多个泛型有约束
    class Test8<T,K>where T :class,new() where K : struct
    {

    }
    #endregion

    #region 总结
    //泛型约束：让类型有一定限制
    //class
    //struct
    //new()
    //类名
    //接口名
    //另一个泛型字母

    //注意
    //1.可以组合使用
    //2.多个泛型约束 用where连接即可
    #endregion



    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
