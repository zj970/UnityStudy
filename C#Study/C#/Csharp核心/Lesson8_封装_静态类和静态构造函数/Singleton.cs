using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson8_封装_静态类和静态构造函数
{
    public class Singleton
    {
        public string name;
        private int age;

        //定义一个静态变量来保存类的实例
        private static Singleton uniqueInstance;

        //定义一个标识确保线程同步
        private static readonly object locker = new object();

        //定义私有构造函数，使外界不能创建该实例
        private Singleton(string name, int age)
        {
            this.age = age;
            this.name = name;
        }

        public static Singleton GetInstance(string name,int age)
        {
            // 当第一个线程运行到这里时，此时会对locker对象 "加锁"，
            // 当第二个线程运行该方法时，首先检测到locker对象为"加锁"状态，该线程就会挂起等待第一个线程解锁
            // lock语句运行完之后（即线程运行完之后）会对该对象"解锁"
            // 双重锁定只需要一句判断就可以了
            if (uniqueInstance == null)
            {
                lock (locker)
                {
                    // 如果类的实例不存在则创建，否则直接返回
                    if (uniqueInstance == null)
                    {
                        uniqueInstance = new Singleton(name,age);
                    }
                }
            }
            return uniqueInstance;
        }

    }
}
