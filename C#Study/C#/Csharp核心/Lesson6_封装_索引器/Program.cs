using System;

namespace Lesson6_封装_索引器
{
    #region 知识回顾
    class name
    {
        #region 特征--成员变量

        #endregion

        #region 行为--成员方法

        #endregion

        #region 初始化调用--构造函数

        #endregion

        #region 释放时调用--析构函数

        #endregion   
        
        #region 保护成员变量--成员属性

        #endregion
    }
    #endregion


    #region 知识点一 索引器基本概念
    //基本概念
    //让对象可以像数组一样通过索引访问其中元素，使程序看起来更直观，更容易编写
    #endregion

    #region 知识点二 索引器概念
    //访问修饰符 返回值 this[参数类型 参数名，参数类型 参数名.....]
    //{
    //  内部的写法规则和成员属性相同
    //  get{}
    //  set{}
    //}

    class Person
    {
        private string name;
        public int age;
        private Person[] friends;

        private int[,] array = new int[2,3];

        #region 知识点五 索引器可以重载
        //重载的概念使 -- 函数名相同 参数类型、顺序、数量不同

        public int this[int i,int j]
        {
            get
            {
                return array[i, j];
            }
            set
            {
                array[i, j] = value;
            }
        }

        public string this[string str]
        {
            get
            {
                switch (str)
                {
                    case "name":return this.name;
                    case "age":return this.age.ToString();
                
                }
              return ""; 
            }
        }
        #endregion

        public Person this[int index]
        {
            get
            {
                #region 知识点四 索引器中可以写逻辑
                if (friends == null || friends.Length - 1 < index)
                {
                    return null;
                }
                
                #endregion
                //可以写逻辑的 根据需求来处理这里面的内容
                return friends[index];
            }
            set
            {
                //可以写逻辑的 根据需求来处理这里面的内容
                //value代表传入的值
                if (friends == null)
                {
                    friends = new Person[] { value };
                }
                else if (index > friends.Length - 1)
                {
                    //自己定了一个规则 如果索引越界 就m默认把最后一个朋友顶掉
                    friends[friends.Length - 1] = null;
                }
                else
                {
                    friends[index] = value;

                }  
            }
        }
    }
    #endregion



    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Lesson6_封装_索引器");

            #region 知识点三 索引器的使用
            Person p = new Person();
            p[0] = new Person();
            Console.WriteLine(p[0]);

            p[0, 0] = 10;
            Console.WriteLine(p[0, 0]);

            Integer intArray = new Integer();
            intArray[0] = new Integer();
            intArray[1] = new Integer();
            intArray[2] = new Integer();
            intArray[3] = new Integer();
            intArray[4] = new Integer();

            Console.WriteLine(intArray[0].target);
            Console.WriteLine(intArray[1].target);

            #endregion


            //总结
            //索引器对于我们来说的主要作用
            //可以让我们以中括号的形式范围自定义类中的元素 规则自己定义 访问时和数组一样
            //比较适用于 在类中有数组变量时使用 可以方便地访问和进行逻辑处理

            //固定写法
            //访问修饰符 返回值 this[参数列表]
            //get 和set
            //可以重载

            //注意：结构体里面也是支持索引器
        }
    }
}
