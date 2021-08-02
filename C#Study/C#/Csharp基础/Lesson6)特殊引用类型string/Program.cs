using System;

namespace Lesson6_特殊引用类型string
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Lesson6_特殊引用类型string");
            #region 知识点一 复习值和引用类型
            //值类型 -- 它变我不变---存储在栈空间中
            //无符号整型 有符号整型 浮点数 char bool 结构体

            //引用类型--它变我也变 -- 存储在堆内存中
            //数组（一维、二维、交错） string 类
            #endregion

            #region 知识点二 string的它变我不变

            //string非常特殊 ，它具备 值类型的特征 它变我不变（C#底层）
            //string 虽然方便 但是有一个缺点 频繁地 改变string的值会 造成内存垃圾
            #endregion

            //通过断点调试 在监视窗口中查看 内存信息
            string str1 = "11234";
            string str2 = str1;
            str2 = "321";
        }
    }
}
