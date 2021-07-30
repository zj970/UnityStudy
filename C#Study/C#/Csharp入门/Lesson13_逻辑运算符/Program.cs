using System;

namespace Lesson13_逻辑运算符
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Lesson13_逻辑运算符");
            //对bool类型 进行逻辑运算

            #region 知识点一 逻辑与
            //符号 &&
            //规则 对两个bool值进行逻辑运算 有假则假 同真为真
            bool result = true && false;
            Console.WriteLine(result);
            result = false && false;
            Console.WriteLine(result);
            result = true && true;
            Console.WriteLine(result);

            Console.WriteLine("-----------结束符---------------");
            //bool相关的类型 bool变量 
            //逻辑运算符优先级 低于 条件运算符 低于 算数运算符

            //多个逻辑与 组合运用 无括号依次看，有括号先看括号
            #endregion

            #region 知识点二 逻辑或
            //符号 || 或者
            //规则 对两个bool值进行逻辑运算 有真为真，同假为假
            result = false || false;
            Console.WriteLine(result);
            result = true || false;
            Console.WriteLine(result);
            result = true || true;
            Console.WriteLine(result);
            Console.WriteLine("-----------结束符---------------");
            #endregion

            #region 知识点三 逻辑非
            //符号 !
            //规则 对一个Bool值进行取反 真变假 假变真
            //逻辑非的优先级比条件运算符较高
            result = !(3>2);
            Console.WriteLine(result);

            Console.WriteLine("-----------结束符---------------");
            #endregion

            #region 知识点四 混合使用优先级问题
            //规则 逻辑非（！）优先级最高  逻辑与（&&）--》逻辑或（||）
            //逻辑运算符优先级 低于 条件运算符 低于 算数运算符（逻辑非除外）
            bool gameOver = false;
            int hp = 100;
            bool isDead = false;
            bool isMustOver = true;

            //false || false || && true ||true
            //false ||false||true
            result = gameOver || hp < 0 && !isDead || isMustOver;
            Console.WriteLine(result);
            Console.WriteLine("-----------结束符---------------");
            #endregion

            #region 逻辑运算符短路规则
            int i = 1;
            // ||有真则真 && 全真异假
            // i > 0 true
            //只要 逻辑与 逻辑或 满足了条件 左边满足了条件 右边就不计算了
            result = i > 0 || ++i >= 1;
            Console.WriteLine(result);//结果1
            Console.WriteLine("-----------结束符---------------");
            #endregion
        }
    }
}
