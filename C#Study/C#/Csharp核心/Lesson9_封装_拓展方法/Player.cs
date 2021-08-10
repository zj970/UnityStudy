using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson9_封装_拓展方法
{
    struct Position
    {
        float x;
        float y;
        float z;
    }

    /// <summary>
    /// 玩家类
    /// </summary>
    class Player
    {
        private string name;//姓名
        private float bloodVolume;//血量
        private float attack;//攻击力
        private float defense;//防御力
        public Position playerPos;
        Random random = new Random();

        public Player(string name, float bloodVolume = 100f, float attack = 50f, float defense = 20f)
        {
            this.name = name;
            this.bloodVolume = bloodVolume;
            this.attack = attack;
            this.defense = defense;
        }

        /// <summary>
        /// 攻击行为
        /// </summary>
        public void Atk()
        {
            Console.WriteLine("你开始攻击怪物，造成伤害: " +attack*random.Next(0,2));
        }

        /// <summary>
        /// 移动
        /// </summary>
        public void Move()
        {
            //DOTO 移动
            Console.WriteLine("开始移动.............");
        }

        /// <summary>
        /// 受伤
        /// </summary>
        public void Hurt()
        {
            float harmValue = attack * random.Next(0, 2);
            bloodVolume -= harmValue;
            if (bloodVolume > 0)
            {
                Console.WriteLine("你收到怪物的造成伤害: " + harmValue + "\n目前血量还剩: " +bloodVolume);
            }
            else
            {
                Console.WriteLine("你已经死亡");
            }
        }
    }
}
