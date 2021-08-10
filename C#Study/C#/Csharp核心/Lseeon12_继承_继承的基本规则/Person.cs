using System;
using System.Collections.Generic;
using System.Text;

namespace Lseeon12_继承_继承的基本规则
{
    abstract class Person
    {
        public string name;
        protected byte age;

        public abstract void Atk();

        public byte Age
        {
            get
            {
                return age;
            }
            set
            {
                if (value>0&&value<150)
                {
                    age = value;
                }
                else
                {
                    Console.WriteLine("年龄输入错误");
                }
            }
        }

        public void Speak()
        {
            Console.WriteLine($"我是{name},我今年{age}岁了");
        }
    }

    class Warrior : Person
    {
        public override void Atk()
        {
            Console.WriteLine($"我是{name},我今年{age}岁了,我开始攻击了");

        }
    }
}
