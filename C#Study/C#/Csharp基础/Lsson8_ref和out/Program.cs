using System;

namespace Lsson8_ref和out
{
    class Program
    {
        #region 知识点一 学习ref和out的原因
        //学习ref和out 的原因
        //它们可以解决 在函数内部改变外部传入的内容 里面变了 外面也变

        static void ChangeValue(int value)
        {
            value = 3;
        }

        static void ChangeArrayValue(int[] value)
        {
            value[0] = 999999999;
        }

        static void ChangeArray(int[] arr)
        {
            //重新声明了一个数组
            arr = new int[] { 1, 2, 3, 4, 5 };
        }
        #endregion

        #region 知识点二 ref和out的使用
        //函数参数的修饰符
        //当传入的值类型参数在内部修改时 或者引用类型参数在内部重新声明时
        //外部的值会发生改变

        //ref
        static void ChangeValueRef(ref int value)
        {
            value = 3;
        }

        static void ChangeArrayRef(ref int[] arr)
        {
            arr = new int[] { 88, 55, 88, 8, 88, 8, 55, 8 };
        }

        //out
        //作用与ref一致
        static void ChangeValueOut(out int value)
        {
            value = 3333333;
        }
        #endregion

        #region 知识点三 ref和out的区别
        //1.ref传入量必须初始化 ，out可以不用
        //2.out传入的变量必须在内部赋值 ref不用

        //ref传入的变量必须初始化 但是在内部 可改可不改
        //out传入的变量不一定要初始化， 但是在内部，必须改（赋值）
        #endregion

        static bool Login(ref string usr, ref string pas)
        {
            if (usr.Equals("周健") && pas.Equals("123456"))
            {
                return true;
            }
            else if(!usr.Equals("周健") && pas.Equals("123456"))
            {
                usr = "用户名";
                pas = "错误";
                return false;
            }
            else if (usr.Equals("周健") && !pas.Equals("123456"))
            {
                usr = "密码";
                pas = "错误";
                return false;
            }
            else
            {
                usr = "用户名和密码";
                pas = "错误";
                return false;
            }
           
        }

        //总结
        //作用;ref和out的作用：解决值类型和引用类型 在函数内部 改值 或者重新声明 能够影响到 外部传入的变量 让其也被改变


        static void Main(string[] args)
        {
            Console.WriteLine("Lsson8_ref和out");
            int a = 1;
            ChangeValue(a);
            Console.WriteLine(a);

            Console.WriteLine("----------------");
            ChangeValueRef(ref a);
            Console.WriteLine(a);

            Console.WriteLine("----------------");
            ChangeValueOut(out a);
            Console.WriteLine(a);


            int[] arr2 = { 1, 2, 3 };
            ChangeArrayValue(arr2);
            Console.WriteLine(arr2[0]);

            ChangeArray(arr2);
            Console.WriteLine(arr2[1]);

            Console.WriteLine("----------------");
            ChangeArrayRef(ref arr2);
            Console.WriteLine(arr2[6]);
            Console.WriteLine("----------------------------------------------------------------------");

            string userName;
            string passWorld;
            Console.WriteLine("请输入账户：");
            userName = Console.ReadLine();
            
            Console.WriteLine("请输入密码：");
            passWorld = Console.ReadLine();

            if (Login(ref userName,ref passWorld))
            {
                Console.WriteLine("登录成功");
            }
            else
            {
                Console.WriteLine(userName+passWorld);
            }
        }
    }
}
