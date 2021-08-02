using System;

namespace Lesson5_值类型和引用类型
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Lesson5_值类型和引用类型");

            #region 知识点一 变量类型的复习
            //无符号整型
            //byte ushort uint ulong

            //有符号整型
            //sbyte short int long

            //浮点数
            //float double decimal

            //特殊类型
            //bool char string

            //复杂数据类型
            //枚举enum 数组(一维，二维，交错)


            //将上面变量类型分成 值类型和引用类型
            //引用类型：string 数组 类
            //值类型: 其他、结构体
            #endregion

            #region 知识点二 值类型和引用类型的区别
            //引用类型：string 数组 类
            //值类型: 其他、结构体

            //值类型
            int a = 10;
            //引用类型
            int[] array = { 1, 2, 3, 4 };
            //声明了一个b 让其等于之前的a
            int b = a;
            //声明了一个arrayNew让其等于之前的array
            int[] arrayNew = array;
            Console.WriteLine("a = {0} , b = {1}", a, b);
            Console.WriteLine("array[0] = {0}, arrayNew[0] = {1}", array[0], arrayNew[0]);

            b = 20;
            array[0] = 45;
            Console.WriteLine("------------------------------------------");
            Console.WriteLine("a = {0} , b = {1}", a, b);
            Console.WriteLine("array[0] = {0}, arrayNew[0] = {1}", array[0], arrayNew[0]);

            //值类型 在相互赋值时 把内容拷贝了对方 它变我不变
            //引用类型的相互赋值 是 让两者指向同一个值 它变我也变

            //2.为什么有以上区域
            //值类型 和 引用类型 存储在的 内存区域 是不同的 存储方式是不同
            //所以就造成了 它们在使用上的区别

            //值类型存储在   栈空间 ---系统分配，自动回收，小而快
            //引用类型存储在 堆空间 ---手动申请和释放，大而慢

            arrayNew = new int[] { 11, 22, 44 };//这里使用了new 字符 在堆里 开辟了新的空间。
            Console.WriteLine("array[0] = {0}, arrayNew[0] = {1}", array[0], arrayNew[0]);
            #endregion
        }
    }
}
