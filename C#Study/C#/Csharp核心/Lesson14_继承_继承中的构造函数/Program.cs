using System;

namespace Lesson14_继承_继承中的构造函数
{
    #region 知识回顾
    //构造函数
    //实例化对象调用的函数
    //主要用于初始化成员变量
    //每个类 都会有一个默认的无参构造函数

    //语法
    //访问修饰符 类名()
    //{
    //}
    //不写返回值
    //函数名和类名相同
    //访问修饰符根据需求而定，一般是public
    //构造函数可以重载
    //可以用this语法重用代码
    
    //注意
    //有参构造会顶掉默认的无参构造
    //如想保留无参构造需重载出来

    class Test
    {
        public int testInt;
        public string testStr;

        public Test()
        {

        }

        public Test(int i)
        {
            this.testInt = i;
        }

        public Test(int i ,string str) : this(i)
        {
            this.testStr = str;
        }
    }

    #endregion

    #region 知识点一 继承中的构造函数 基本概念
    //特点
    //当声明一个子类对象时
    //先执行父类的构造函数
    //再执行子类的构造函数

    //注意：
    //1.父类的无参构造 很重要
    //2.子类可以通过base关键字 代表父类 调用父类构造
    #endregion

    #region 知识点二 继承中的构造函数的执行顺序
    //父类的父类的构造 ---->....  父类的构造 ---->.... 子类的构造
    class GameObject
    {
        public GameObject()
        {
            Console.WriteLine("GameObject的构造函数执行");
        }
    }

    class Player : GameObject
    {
        public Player()
        {
            Console.WriteLine("Player的构造函数执行");
        }
    }

    class MainPlayer : Player
    {
        public MainPlayer()
        {
            Console.WriteLine("MainPlayer的构造函数执行");
        }
    }
    #endregion

    #region 知识点三 父类的无参构造函数很重要
    //子类实例化时 默认自动调用 是父类的无参构造 所以如果父类无参构造会被顶掉 会报错
    class Father
    {
        //public Father()
        //{

        //}
        public Father(int i)
        {
            Console.WriteLine("Father的构造函数执行");
        }
    }

    class Son:Father
    {
        public Son(int i):base(i)
        {
            Console.WriteLine("Son的构造函数执行");
        }

        public Son(int i,string str) : this(i)
        {
            Console.WriteLine("Son的构造函数的两个参数执行");
        }
    }
    #endregion

    #region 知识点四 通过base调用指定父类构造
    // public Son(int i):base(i)
    #endregion

    class Program
    {
        static void Main(string[] args)
        {
            MainPlayer mp = new MainPlayer();

            Son s = new Son(1, "dd");
            Worker worker = new Programmer();
            if (worker is Programmer)
            {
                (worker as Programmer).WorkWay();
            }

            Art art = new Art();
            art.WorkWay();
            Planner planner = new Planner();
            planner.WorkWay();
            
        }
    }
    //总结
    //继承中的构造函数
    //特点
    //执行顺序 是先执行父类的构造函数 再执行子类的 从老祖宗开始 一代一代向下执行

    //父类中的无参构造函数 很重要
    //如果被顶掉 子类中就无法默认调用无参构造了
    //解决方法：
    //1.始终保持声明一个无参构造
    //2.通过base关键字 调用父类指定的构造
    //注意：区分base 和 this的区别
}
