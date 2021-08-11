using System;

namespace Lesson13_继承_里氏替换原则
{
    #region 知识点一 基本概念
    //里氏替换原则是面向对象七大原则中最重要的原则
    //概念;
    //任何父类出现的地方，子类都可以替代
    //重点:
    //语法表现--父类容器装子类对象，因为子类对象包含了父类的所有内容
    //作用：
    //方便进行对象的存储和管理
    #endregion

    #region 知识点二 基本实现
    class GameObject
    {

    }

    class Player : GameObject,IEquip
    {
        public Weapon weapons = new Weapon("小刀");
        public void PlayerAtk()
        {
            Console.WriteLine("玩家攻击");
        }

        public void Weaponly(int i = 0)
        {
            weapons = weapons.Weaponly(i);
        }
    }

    /// <summary>
    /// 装备武器接口
    /// </summary>
    interface IEquip
    {
        public void Weaponly(int i);
    }


    class Weapon 
    {
        protected Weapon dagger;//匕首
        protected Weapon handgun;//手枪
        protected Weapon shotgun;//散弹枪
        protected Weapon submachineGun;//冲锋枪
        public string name;

        public Weapon(string name)
        {
            this.name = name;
        }

        public Weapon Weaponly(int i = 0)
        {
            
            switch (i)
            {
                case 0:return dagger = new Weapon("小刀");
                case 1:return handgun = new Weapon("手枪");
                case 2:return shotgun = new Weapon("散弹枪");
                case 4:return submachineGun = new Weapon("冲锋枪");
                default:return dagger = new Weapon("小刀");
            }
        }

    }

    class Monster : GameObject
    {
        public void MonsterAtk()
        {
            Console.WriteLine("怪物攻击");
        }

        Random random = new Random();

        public Monster[] Instantiation(Monster[] monsters,int num)
        {
            int j = 0;
            for (int i = 0; i < num; i++)
            {
                if(random.Next(0,5) > 2)
                {
                    monsters[j++] = new Boss();

                }
                else
                {
                    monsters[j++] = new Goblin();
                }

            }
            return monsters;
        }      
    }

    class Boss : Monster
    {
        public void BossAtk()
        {
            Console.WriteLine("Boss攻击");
        }
    }

    class Goblin : Monster
    {
        public void GoblinAtk()
        {
            Console.WriteLine("普通攻击");
        }
    }
    #endregion
    class Program
    {
        static void Main(string[] args)
        {
            //里氏替换原则 用父类容器 装载子类对象

            GameObject player = new Player();
            GameObject monster = new Monster();
            GameObject boss = new Boss();

            GameObject[] objects = new GameObject[] { new Player(), new Monster(), new Boss() };
            Monster monster1 = new Monster();
            Monster[] monsters2 = new Monster[10];
            monsters2 = monster1.Instantiation(monsters2, 10);
            for (int i = 0; i < monsters2.Length; i++)
            {
              
                if ((monsters2[i] is Goblin))
                {
                    (monsters2[i] as Goblin).GoblinAtk();
                }
                else if (monsters2[i] is Boss)
                {
                    (monsters2[i] as Boss).BossAtk();
                }
            }

            Player player1 = new Player();
            player1.Weaponly();
            Console.WriteLine(player1.weapons.name);
            player1.Weaponly(1);
            Console.WriteLine(player1.weapons.name);
            player1.Weaponly(2);
            Console.WriteLine(player1.weapons.name);


            #region 知识点三 is和as
            //基本概念
            //is：判断一个对象是否是指定类对象
            //返回值 ：bool 是真，不是为假

            if (player is Player)
            {
                Console.WriteLine("player 是 Player类型的对象");
                Player p = player as Player;
                p.PlayerAtk();

                (player as Player).PlayerAtk();
            }

            //as ：将一个对象转换为指定类对象
            //返回值:指定类型对象
            //成功返回执行类型对象,失败返回null
            for (int i = 0; i < objects.Length; i++)
            {
                if (objects[i] is Player)
                {
                    (objects[i] as Player).PlayerAtk();
                }
                else if ((objects[i] is Monster))
                {
                    (objects[i] as Monster).MonsterAtk();
                }
                else if (objects[i] is Boss)
                {
                    (objects[i] as Boss).BossAtk();
                }
            }
            

            //基本语法
            //类对象 is 类名 该语句块 会有一个bool返回值 true和false
            //类对象 as 类名 该语句块 会有一个对象返回值 对象和null



            #endregion
        }

        //总结
        //概念：父类容器装子类对象
        //作用：方便进行对象的存储和管理
        //使用 ：is和as
        //is 用于判断
        //as 用于转换
        //注意：不能用子类容器装父类对象
    }
}
