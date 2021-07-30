using System;

namespace Lesson17_条件分支语句_switch
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Lesson17_条件分支语句_switch");

            #region 知识点一 作用
            //让顺序执行的代码 产生分支
            #endregion

            #region 知识点二 基本语法
            //switch (变量)
            //{
            ////当变量 == 常量就会执行
            //    case 常量:
            //        满足条件执行的代码逻辑;
            //        break;
            //    case 常量:
            //        满足条件执行的代码逻辑;
            //        break;
            //    default:
            //        如果上面都不满足就会执行default中的代码
            //            break;
            //}
            //注意：常量！！只能写一个值 不能去写一个范围 不能写条件运算符，逻辑运算符c中只能是整型，字符型，enum枚举型
            //C#可以是任意，只要是固定值
            #endregion

            #region 知识点三 default可省略

            #endregion

            #region 知识点四 可自定义常量
            //必须初始化 不能修改
            #endregion

            #region 知识点五 贯穿
            //作用：当满足某些条件 就可以使用贯穿 不写break就可以贯穿
            //case 和break 之间可以写n条语句 并且可以嵌套使用
            //switch (switch_on)
            //{
            //    case:
            //    case:
            //    default:
            //}
            #endregion
        }
    }
}
