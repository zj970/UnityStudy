using System;

namespace lesson20_多态_密封方法
{
    #region 知识回顾
    //密封类
    //用sealed修饰的类
    //让类不再能被继承 "结扎"
    #endregion

    #region 知识点一 密封方法基本概念
    //用密封关键字 sealed 修饰的重写函数
    //作用;   让虚方法或者抽象方法之后不能再被重写
    //特点:   和override一起出现
    #endregion

    #region 知识点二 实例
    abstract class Animal
    {
        public string name;
        public abstract void Eat();

        public virtual void Speak()
        {
            Console.WriteLine("叫");
        }
    }

    class Person : Animal
    {
        public sealed override void Eat()
        {
            Console.WriteLine("吃油条");
        }
        public override void Speak()
        {
            //base.Speak();
            Console.WriteLine("说中文");
        }
    }

    class WhitePerson : Person
    {
        public override void Speak()
        {
            Console.WriteLine("说英文");
        }
        //public override void Eat()
        //{
        //    Console.WriteLine("吃面包");
        //}
    }
    #endregion
    class Program
    {
        static void Main(string[] args)
        {
            Animal a = new Person();
            (a as Person).Eat();
        }
    }

    //总结
    //密封方法 可以让虚方法和抽象方法不能再被子类重写
    //特点：一定是和override 一起出现
}
