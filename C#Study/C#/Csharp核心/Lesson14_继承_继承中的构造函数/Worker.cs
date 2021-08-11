using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson14_继承_继承中的构造函数
{
    abstract class Worker
    {
        //打工人基类，有工种，工作内容两个特征，一个工作方法
        protected string name;
        protected string workContent;

        public abstract void WorkWay();
    }

    class Programmer : Worker
    {
        
        public override void WorkWay()
        {
            name = "程序员";
            workContent = "写程序";
            Console.WriteLine($"我是{name}，我的工作内容是 : {workContent}");
        }
    }

    class Art : Worker
    {
        public override void WorkWay()
        {
            name = "美术";
            workContent = "建模";
            Console.WriteLine($"我是{name}，我的工作内容是 : {workContent}");
        }
    }

    class Planner : Worker
    {
        public override void WorkWay()
        {
            name = "策划";
            workContent = "制定需求";
            Console.WriteLine($"我是{name}，我的工作内容是 : {workContent}");
        }
    }
}
