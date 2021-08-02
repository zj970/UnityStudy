using System;

namespace Lesson12_结构体
{

    #region 知识点一 基本概念
    //结构体 是一种自定义变量类型 类似枚举需要自己定义
    //它是数据与函数的集合
    //在结构体中 可以声明各种变量和方法

    //作用： 用来表现存在关系的数据集合 比如用结构体表现学生 动物 人类等等
    #endregion

    #region 知识点二 基本语法
    //1.结构体一般写在 namespace语句块中
    //2.结构体关键字 struct

    //struct 自定义结构体名
    //{
    //        第一部分
    //        变量
    //        第二部分
    //        构造函数（可选）
    //        第三部分
    //        函数
    // }
    #endregion

    #region 知识点三 实例
    //表现学生数据的结构体
    struct Student 
    {
        //在结构体中声明的变量不能初始化
        //变量类型 可以写任意类型 包括结构体 但是 不能是自己的结构体
        //变量
        public  int age;
        public bool sex;
        public int number;
        public string name;

        //构造函数
        public Student(int age,bool sex,int number,string name)
        {
            //关键字
            this.age = age;
            this.sex = sex;
            this.number = number;
            this.name = name;
        }
        //函数方法
        //表现这个数据结构的行为

        //注意 在结构体中的方法 目前不需要static 关键字
        public  void Speak()
        {
            //函数中可以直接使用结构体内部声明的变量
            Console.WriteLine("我的名字是{0},我今年{1}岁", name, age);
        }
        //可以根据需求可以写无数个
    }

    #endregion

    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Lesson12_结构体");
            #region 知识点四 结构体的使用
            //结构体类型 变量名;
            Student s1;
            s1.age = 18;
            s1.name = "周健";
            s1.number = 18060;
            s1.sex = false;
            s1.Speak();
            #endregion


            #region 知识点五 访问修饰符
            //修饰结构体中变量和方法 是否能被外部使用
            //public 公开的 可以被外部访问
            //private 私有的 只能在内容中使用
            //默认不写是privates
            #endregion

            #region 知识点六 结构体的构造函数
            //基本概念
            //1.没有返回值
            //2.函数名必须和结构体名相同
            //3.必须有参数
            //4.如果申明了构造函数 那么必须在其中对所有变量数据初始化

            //构造函数 一般是用于在外部方便初始化的
            #endregion

            Student s2 = new Student(18, true,  18949, "小红");
            s2.Speak();

            //总结
            //1.概念：结构体 struct 是变量和函数的集合 用来表示特定的数据集合
            //访问修饰符：public 和 private 用来修饰变量和方法的 public 外部可以调用 private内部用，不写默认为private
            //构造函数;没有返回值 函数名和结构体名相同 可以重载 主要是帮助我们快速初始化结构体对象的
            
            //注意：
            //1.在结构体中声明的变量 不能初始化 只能在外部或者在函数中赋值（初始化）
            //2.在结构体中声明的函数，不用加static 
        }
    }
}
