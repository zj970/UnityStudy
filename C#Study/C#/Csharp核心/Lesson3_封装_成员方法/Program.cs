using System;

namespace Lesson3_封装_成员方法
{
    #region 知识点一 成员方法的声明
    //基本概念
    //成员方法（函数）用来表现对象行为
    //1.申明在类语句块中
    //2.是用来描述对象的行为的
    //3.规则和函数声明的规则相同
    //4.收到访问修饰符规则影响
    //5.返回值参数不做限制
    //6.方法数量不做限制

    //注意;
    //1.成员方法不要加static关键字
    //2.成员方法 必须实例化对象 再通过对象来使用 相当于该对象执行了摸个行为
    //3.成员访问 受到访问修饰符影响


    class Person
    {

        public string name;
        public int age;
        public Person[] friends;

        /// <summary>
        /// 添加朋友
        /// </summary>
        /// <param name="p"></param>
        public void AddFriend(Person p)
        {
            if (friends == null)
            {
                friends = new Person[] { p };
            }
            else
            {
                //扩容
                Person[] newFriends = new Person[friends.Length + 1];
                //迁移
                for (int i = 0; i < friends.Length; i++)
                {
                    newFriends[i] = friends[i];
                }
                //增加
                newFriends[newFriends.Length - 1] = p;
                //地址重定向
                friends = newFriends;
            }
        }

        /// <summary>
        /// 说话的行为
        /// </summary>
        /// <param name="str">说话的内容</param>
        public void Speak(string str)
        {
            Console.WriteLine("{0}说{1}", name, str);
        }

        /// <summary>
        /// 判断是否成年
        /// </summary>
        /// <returns></returns>
        public bool IsAdult()
        {
            return age >= 18;
        }

    }
    #endregion

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Lesson3_封装_成员方法");

            #region 知识点二 成员方法的使用
            //2.成员方法 必须实例化对象 再通过对象来使用 相当于该对象执行了摸个行为
            Person p = new Person();
            p.name = "周健";
            p.age = 18;
            p.Speak("我爱你");

            if (p.IsAdult())
            {
                p.Speak("我要耍朋友");
            }

            Person p2 = new Person();
            p2.name = "小黄";
            p2.age = 19;
            Person p3 = new Person();
            p3.name = "小绿";
            p3.age = 21;
            Person p4 = new Person();
            p4.name = "小黑";
            p4.age = 18;

            p.AddFriend(p2);
            p.AddFriend(p3);
            p.AddFriend(p4);
            for (int i = 0; i < p.friends.Length; i++)
            {
                Console.WriteLine(p.friends[i].name);
            }
            #endregion

            //总结
            //成员方法
            //描述方法
            //类中声明
            //任意数量
            //返回值和参数根据需求决定
        }
    }
}
