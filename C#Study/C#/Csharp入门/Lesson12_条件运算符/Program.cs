using System;

namespace Lesson12_条件运算符
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Lesson12_条件运算符");

            #region 知识点一 条件运算符
            //用于比较两个变量或常量
            //是否大于  >
            //是否小于  <
            //是否等于  ==
            //是否大于等于  >=
            //是否小于等于  <=
            //是否等于 !=


            //条件运算符 一定存在两边的内容
            //左边内容 条件运算符 右边内容

            //条件运算符不能直接使用
            //比较结果 返回的是 一个bool 类型的值
            //条件满足返回true 反之 false;

            int a = 5;
            int b = 10;
            bool c = a < b;
            Console.WriteLine(c);
            #endregion

            #region 知识点二 各种应用写法
            //变量和变量比较

            //变量和数值(常量)比较

            //数值和数值比较

            //计算结果比较

            //条件运算符的 优先级 低于算数运算符
            bool result = a + 3 > a - 2 + 10;//false
            #endregion

            #region 知识点三 不能进行范围比较
            //判断是否再某两个值之间
            //1<a<6
            //a>1 && a <6

            #endregion

            #region 不同类型之间的比较
            //不同数值类型之间 可以随意进行条件运算符比较

            //特殊类型 char string bool 只能同类型进行 == 和 != 比较
            //char 不仅可以和自己类型进行== != 还可以和数值类型进行比较
            #endregion
        }
    }
}
