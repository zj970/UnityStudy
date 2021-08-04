using System;
//using MyGame;
namespace MyGame
{
    class GameObject
    {

    }
}
namespace MyGame
{
  internal class Player : GameObject
    {

    }
}
namespace MyGame2
{
    class GameObject
    {

    }
}
namespace Lesson21_面向对象相关_命名空间
{
    #region 知识点一 命名空间的基本概念
    //概念
    //命名空间是用来组织和重用代码的
    //作用
    //就像一个工具包，类就像是一件一件的工具，都是声明再命名空间中的
    #endregion

    #region 知识点二 命名空间的使用
    //基本语法
    //namespace 命名空间名
    //{
    //  类
    //  类
    //}
    namespace MyGame
    {
        class GameObject
        {

        }
    }
    #endregion


    #region 知识点四 不同命名空间中允许有同名类

    #endregion

    #region 知识点五 命名空间可以包裹命名空间

    #endregion

    #region 知识点六 关于修饰符的访问修饰符
    //public    -- 命名空间中的类 默认为public
    //internal ---只能在程序集中使用
    //abstract ---抽象类
    //sealed  ----密封类
    //pertial ----分部类
    #endregion

    class Program
    {
        static void Main(string[] args)
        {
            #region 知识点三 不同命名空间中相互作用 需要引用命名空间或指明出处
            //1.using 命名空间
            //GameObject g = new GameObject();
            //2.命名空间.类
            MyGame.GameObject h = new MyGame.GameObject();            
            MyGame2.GameObject h1= new MyGame2.GameObject();
            #endregion

        }
    }
}

//总结
//1.命名空间是一个工具包，是用来管理类的
//2.不同命名空间中 可以有同名类
//3.不同命名空间中相互作用 需要using引用命名空间 或者 指明出处
//4.命名空间可以包裹空间
//5.程序集就是一个项目
