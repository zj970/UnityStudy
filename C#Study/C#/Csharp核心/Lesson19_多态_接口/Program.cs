using System;

namespace Lesson19_多态_接口
{
    #region 知识点一 接口的概念
    //接口是 行为的 抽象规范
    //它也是一种自定义类型
    //关键字: interface
    
    //接口声明的规范
    //1.不包含成员变量
    //2.只包含方法、属性、索引器、事件
    //3.成员不能被实现
    //4.成员可以不用写访问修饰符，不能是私有的，不写默认是public
    //5.接口不能继承类，但是可以继承另外一个接口

    //接口的使用规范
    //1.类可以继承多个接口
    //2.类继承接口后，必须实现接口中所有成员

    //特点;
    //1.它和类的声明类似
    //2.接口是用来继承的
    //3.接口不能被实例化，但是可以作为容器存储对象
    #endregion


    #region 知识点二 接口的声明
    //接口的关键字    interface
    //语法;
    //interface 接口名
    //{
    //
    //}
    //一句话记忆：接口是抽象行为的基类
    //接口命名规范 帕斯卡命名法前面加一个  I

    interface IFly
    {
       public void Fly();

       //属性
        string Name
        {
            get;
            set;
        }
        //索引器
        int this[int index]
        {
            get;
            set;
        }
        //事件
        event Action doSomthing;
    }
    #endregion


    #region 知识点三 接口的使用
    //接口用来继承
    class Animal { }
    class Person : Animal, IFly
    {
        public int this[int index] { 
            get 
            { 
                return 0;
            }
            set 
            { 
            } 
        }

        public string Name { get; set; }

        public event Action doSomthing;

        public virtual void Fly()
        {
            throw new NotImplementedException();
        }
    }

    //1.类可以继承1个类，n个接口
    //2.继承了接口后必须实现其中的内容 并且必须是public的
    //3.实现的接口函数，可以加virtual再在子类重写
    //4.接口也遵循里氏替换原则
    #endregion


    #region 知识点四 接口可以继承接口
    //接口继承接口时  不需要去实现
    //待类继承接口后  类自己去实现所有内容

    interface IWalk
    {
        void Walk();
    }

    interface IMove : IFly, IWalk
    {

    }

    class Move : IMove
    {
        public int this[int index] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public string Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public event Action doSomthing;

        public void Fly()
        {
            throw new NotImplementedException();
        }

        public void Walk()
        {
            throw new NotImplementedException();
        }
    }
    #endregion

    #region 知识点五 显示实现接口
    //当一个类继承两个接口
    //但是接口中存在着同名方法时
    //注意：显示实现接口时 不能写访问修饰符

    interface IAtk
    {
        void Atk();
    }

    interface ISuperAtk 
    {
        void Atk();
    }

    class Player : Move, IAtk, ISuperAtk
    {
        //显示实现接口 就是用 接口名.行为名 去实现
        void IAtk.Atk()
        {
            Console.WriteLine("普通攻击");
        }

        void ISuperAtk.Atk()
        {
            Console.WriteLine("超级攻击");
        }

        public void Atk()
        {
            Console.WriteLine("自己攻击");
        }
    }


    #endregion

    class Program
    {
        static void Main(string[] args)
        {    
            //4.接口也遵循里氏替换原则
            IFly i = new Person();

            IMove im = new Move();
            IFly ifly = new Move();
            IWalk iw = new Move();

            Player p = new Player();
            p.Atk();
            (p as IAtk).Atk();
            (p as ISuperAtk).Atk();
        }
    }

    //总结
    //继承类;是对象间的继承，包括特征行为等等
    //继承接口：是行为间的接口，继承接口的行为规范，按照规范去实现内容
    //由于接口也是遵循里氏替换原则 所以可以用接口容器装对象
    //那么就可以实现 装载各种毫无关系但是却有相同行为的对象

    //注意：
    //1.接口值包含 成员方法、属性、索引器、事件，并且都不实现，都没有访问修饰符
    //2.可以继承多个接口，但是只能继承一个类
    //3.接口可以继承接口，相当于在进行行为合并，待子类继承时再去实现具体的行为
    //4.接口可以被显示实现 主要用于实现不同接口中的同名函数的不同表现
    //5.实现的接口方法 可以加virtual关键字之后又 子类再重写
}
