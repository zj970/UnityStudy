using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson5_成员属性
{
    //定义一个学生类，有5种属性，分别为姓名，性别，年龄、Csharp成绩、Unity成绩
    //两个方法：
    //打招呼：介绍自己XXX今年几岁了，是男是女，计算自己总分数和平均分的显示
    //使用属性完成：年龄必须是0-150岁之间成绩必须是0-100，性别只能是男或女
    //实力化两个对象并测试
    class Student
    {
        private string name;
        private bool sex;
        private int age ;
        private byte cScore;
        private byte uScore;
        private float avg;

        public int Age
        {
            get
            {
                return age;
            }
            set
            {
                if(value > 150)
                {
                    Console.WriteLine("年龄超出上限");
                    value = 150;
                }
                else if (value<0)
                {
                    Console.WriteLine("年龄不规范");
                    value = 0;
                }
                age = value;
            }
        }

        public byte CScore
        {
            get
            {
                return cScore;
            }
            set
            {
                if (value>100)
                {
                    Console.WriteLine("超出上限，强制为100");
                    value = 100;
                }
                cScore = value;
            }
        }

        public byte UScore
        {
            get
            {
                return uScore;
            }
            set
            {
                if (value > 100)
                {
                    Console.WriteLine("超出上限，强制为100");
                    value = 100;
                }
                uScore = value;
            }
        }

        public Student(string name,bool sex)
        {
            this.name = name;
            this.sex = sex;
        }

        public void Introduce()
        {
            avg = cScore + uScore;
            string se = sex ? "女" : "男";
            Console.WriteLine("我是{0}，我今年{1}岁了\n我是{2}孩子\nCSharp成绩为:\t{3}\nUinty成绩为:\t{4}\n总分为:\t{5}\t\t平均分为:\t{6}", name,age,se,cScore,uScore,avg,avg/2);
        }
    }
}
