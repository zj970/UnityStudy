using System;

namespace Lesson10_算数运算符
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Lesson10_算数运算符");

            //算数运算符 是用于 数值类型变量计算的运算符
            //它的返回结果是数值

            #region 知识点一：赋值符号
            // = 
            //关键知识点
            //先看左侧 在看右侧 把右侧的值赋值给左侧的变量
            string myName = "周健";
            int myAge = 18;
            float myHeight = 170.4f;
            #endregion

            #region 知识点二：算数运算符
            #region  加 +
            //用自己计算 先算右侧结果 再赋值给左侧变量
            int i = 1;
            //i = i + 2;
            i += 2;
            Console.WriteLine(i);
            //连续运算 先算右侧结果 再赋值给左侧变量
            //初始化时就计算 先算右侧结果 再赋值给左侧变量
            #endregion

            #region 减 -
            //用自己计算 先算右侧结果 再赋值给左侧变量
            //连续运算 先算右侧结果 再赋值给左侧变量
            //初始化时就计算 先算右侧结果 再赋值给左侧变量
            #endregion

            #region 乘 *
            //用自己计算 先算右侧结果 再赋值给左侧变量
            //连续运算 先算右侧结果 再赋值给左侧变量
            //初始化时就计算 先算右侧结果 再赋值给左侧变量
            #endregion

            #region 除 /
            //用自己计算 先算右侧结果 再赋值给左侧变量
            //连续运算 先算右侧结果 再赋值给左侧变量
            //初始化时就计算 先算右侧结果 再赋值给左侧变量

            //注意： 默认的整数是int ,如果用来做除法运算 要注意 会丢失小数点后面的小数
            //如果你想要浮点数来存储 一定是 运算时要有浮点数的特征
            int a = 2;
            a = 2 / 5;
            Console.WriteLine(a);
            #endregion

            #region 取余 %
            //用自己计算 先算右侧结果 再赋值给左侧变量
            //连续运算 先算右侧结果 再赋值给左侧变量
            //初始化时就计算 先算右侧结果 再赋值给左侧变量
            int y = 4;
            y = 4 % 3 % 2;
            Console.WriteLine(y);//y = 1;
            #endregion
            #endregion

            #region 知识点三 算数运算符的 优先级
            //优先级是指 在混合运算时的运算符号

            //乘除取余 优先高于 加减 先算乘除取余 后算加减

            //括号可以改变优先级 优先计算括号内

            //多组括号 先算最里层括号 依次往外算

            #endregion

            #region  知识点四 复合运算符
            //固定写法 运算符
            //+= -= *= /=
            //复合运算符 是用于 自己 = 自己进行运算
            //左边只有一种运算符

            //计算机最快的运算 位运算
            #endregion

            #region 知识点五 ：算数运算符的自增加

            //自增
            int i2 = 0;
            Console.WriteLine(i2++);//先用再加 0
            Console.WriteLine(++i2);//先加再用 2

            //自减
            i2--;
            --i2;
            #endregion
        }
    }
}
