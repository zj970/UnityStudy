using System;

namespace Lesson17_协变逆变
{
    #region 知识点一 什么是协变逆变
    //协变
    //和谐的变化，自然的变化
    //因为 里式替换原则 父类可以装子类
    //所以 子类变父类
    //比如 string 变成 object
    //感受是 和谐的

    //逆变
    //逆常规的变化，不正常的变化
    //因为 里式替换原则 父类可以装子类 但是 子类不能装父类 
    //所以 父类变子类
    //比如 object 变成 string
    //感受是 不和谐的

    //协变和逆变是用来修饰泛型的
    //协变：   out
    //逆变:    in
    //用于在泛型中 修饰泛型字母中
    //只有泛型接口和泛型委托能使用
    #endregion

    #region 知识点二 作用
    //1.返回值 和 参数
    //用out修饰的泛型 只能作为返回值
    delegate T TestOut<out T>();
    //用in修饰的泛型 只能作为参数
    delegate void TestIn<in T>(T t);

    interface ITest<out T>
    {
        T TestFun();
    }

    //2.结合里氏替换原则理解
    class Father
    {

    }

    class Son:Father
    {

    }
    #endregion
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Lesson17_协变逆变");
            #region 知识点三 作用(结合里氏替换原则理解)
            //协变    父类总是能被子类替换
            //看起来son --> father
            TestOut<Son> os = () =>
            {
                return new Son();
            };

            TestOut<Father> fa = os;
            Father f = fa();//实际上上 返回的 是os里面装的函数 返回的是 son
            //逆变    父类总是能被子类替换
            TestIn<Father> iF = (value) =>
            {

            };
            TestIn<Son> ad = iF;
            ad (new Son());//实际上 调用的是 iF；
            #endregion
        }
    }
    //总结
    //协变 out
    //逆变 in
    //用来修饰 泛型替代符的 只能修饰接口和委托类型中的泛型

    //作用两点
    //1.out修饰的泛型类型 只能作为返回值类型 in 修饰的泛型类型 只能作为参数类型
    //2.遵循里氏替换原则 用out和in修饰的 泛型委托 可以相互装载（有父子关系的泛型）
    //协变out 父类泛型委托子类泛型委托 逆变in 子类泛型委托父类泛型委托
}
