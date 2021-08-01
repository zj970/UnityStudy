
using System;

namespace Lesson1_枚举
{


    #region 知识点一 基本概念

    #region 1.枚举是什么
    //枚举是一个比较特别的存在
    //它是一个被命名的整型常量的集合
    //一般用它来表示  状态 类型 等等
    #endregion

    #region 2.声明枚举 和 声明枚举变量
    //注意：声明枚举 和 声明枚举变量 是两个概念
    //声明枚举：     相当于是创建一个自定义的枚举类型
    //声明枚举变量： 使用声明的自定义枚举类型 创建一个枚举变量
    #endregion

    #region 3.声明枚举名
    //枚举名  以E或者E_开头 作为我们的命名规范
    //    enum E_自定义枚举名
    //{
    //    自定义枚举项名字,//枚举中包裹的 整型变量 第一个默认值是0 下面会依次累加
    //    自定义枚举项名字1,//1
    //    自定义枚举项名字2,//2
    //    自定义枚举项名字3,//3
    //}

    //enum E_自定义枚举名
    //{
    //    自定义枚举项名字 = 5,//第一个枚举项的默认值 变成5
    //    自定义枚举项名字1,//6
    //    自定义枚举项名字2 = 100,//又自定义变成100了
    //    自定义枚举项名字3,//101
    //}
    #endregion

    #endregion

    #region 知识点二 在哪里声明枚举
    //1.namespace语句块中（常用）
    //2.class语句块中 struct语句块中
    //注意 ： 枚举不能在函数语句块中声明
    //C中最后需要分号;
    enum E_MonsterType
    {
        Normal,//0
        Boss,//0
    }

    enum E_PlayerType
    {
        Main,
        Other,
    }

    #endregion


    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Lesson1_枚举");
            #region 知识点三 枚举的使用
            //声明枚举变量
            //自定义的枚举类型 变量名 = 默认值;(自定义的枚举类型.枚举项)
            E_PlayerType playerType = E_PlayerType.Other;

            if (playerType == E_PlayerType.Main)
            {
                Console.WriteLine("主玩家逻辑");
            }
            else if(playerType == E_PlayerType.Other)
            {
                Console.WriteLine("其它玩家逻辑");
            }
            //枚举的最大作用是增加程序的易读性，方便维护查看代码（光写0，1，2别人看不懂）
            //枚举和switch是天生一对
            E_MonsterType monsterType = E_MonsterType.Boss;
            switch (monsterType)
            {
                case E_MonsterType.Normal:
                    Console.WriteLine("普通怪物逻辑");
                    break;
                case E_MonsterType.Boss:
                    Console.WriteLine("BOSS逻辑");
                    break;
                default:
                    break;
            }
            #endregion


            #region 知识点四  枚举的类型转换
            //1.枚举和int相互转换
            int i = (int)playerType;
            Console.WriteLine(i);
            //int 转换 枚举
            //其他只能强行转换
            playerType = (E_PlayerType)1;//0可以直接隐式转换
            //2.枚举和string相互转换
            string str = playerType.ToString();
            Console.WriteLine(str);//超出自定义的枚举项，只能转换成数字

            //把string转成枚举呢
            playerType = (E_PlayerType)Enum.Parse(typeof(E_PlayerType), "Main");//转的字符串只能是出现在枚举项声明的字符串
            //转换后 是一个通用的类型 我们需要用括号强转成我们想要的目标枚举类型
            Console.WriteLine(playerType);
            #endregion


            #region 知识点五 枚举的作用
            //在游戏开发中，对象很多时候 会有许多的状态
            //比如玩家 有一个动作状态 我们需要用一个变量或者标识当前玩家处于的是哪种状态
            //综合考虑 可能会使用 int 来表示它的状态
            //1 行走 2 待机 3跑步 4跳跃。。。。。等等 
            //枚举可以帮助我们 清晰地分清楚状态的含义
            #endregion
        }
    }
}
