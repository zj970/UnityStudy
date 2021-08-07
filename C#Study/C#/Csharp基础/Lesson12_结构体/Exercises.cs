using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson12_结构体
{
    struct Player
    {
        public string name;
        public enum Profession
        {
            warrior,//战士
            hunter,//猎人
            charmer//法师
        }
        public Player(string name)
        {
            this.name = name;
        }
        public void Speak(Profession profession)
        {
            switch (profession)
            {
                case Profession.warrior:
                    Console.WriteLine("战士{0}释放了技能---冲锋", name);
                    break;
                case Profession.hunter:
                    Console.WriteLine("猎人{0}释放了技能---假死", name);
                    break;
                case Profession.charmer:
                    Console.WriteLine("法师{0}释放了技能---奥数冲击", name);
                    break;
                default:
                    Console.WriteLine("没有该职业与技能！！！");
                    break;
            }
        }
    }

    class Exercises
    {

    }
}
