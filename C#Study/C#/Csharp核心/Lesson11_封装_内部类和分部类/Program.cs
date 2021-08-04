using System;

namespace Lesson11_封装_内部类和分部类
{
    #region 知识点一 内部类
    //概念
    //在一个类中再声明一个类

    //特点
    //使用时要用包裹者点出自己

    //作用
    //亲密关系的表现

    //注意
    //访问修饰符作用很大

    class Person
    {
        public int age;
        public string name;
        public Body body;

        public class Body
        {
            Arm leftArm;
            Arm rightArm;
            class Arm
            {

            }
        }
    }
    #endregion

    #region 知识点二 分部类
    //概念
    //把一个类分成几部分声明

    //关键字
    //pertial

    //作用
    //分部描述一个类
    //增加程序的拓展性

    //注意
    //分部类可以写在多个脚本文件中
    //分部类的访问修饰符要一致
    //分部类中不能有重复成员

    partial class Student
    {
        public bool sex;
        public string name;

        partial void Speak(string str);
    }

    partial class Student
    {
        public int number;
        partial void Speak(string str)
        {
            throw new NotImplementedException();//提示没有实现它
            //实现逻辑
        }

        public void Speaking(string str)
        {
            Console.WriteLine("你好" + str);
        }
    }
    #endregion

    #region 知识点三 分部方法
    //概念
    //将方法的声明和实现分离
    //特点
    //1.不能加访问修饰符 默认私有
    //2.只能在分部类中声明
    //3.返回值只能是void
    //4.可以有参数但不用 out关键字

    //局限性很大，了解即可
    #endregion

    class Program
    {
        static void Main(string[] args)
        {
            Person p = new Person();
            Person.Body body = new Person.Body();
            Student stu1 = new Student();
            stu1.Speak("456");
        }
    }
}
