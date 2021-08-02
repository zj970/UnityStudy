using System;

namespace Lesson2_一维数组
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Lesson2_一维数组");

            #region 知识点一 基本概念
            //数组是存储一组相同类型数据的集合
            //数组分为一维、多维、交错数组
            //一般情况 一维数组 就简称为 数组
            #endregion

            #region 知识点二 数组的声明
            //变量类型[] 数组名;//只是声明了一个数组 但是并没有赋予空间
            
            //变量类型 可以是我们学过的 或者 没有学过的所有变量类型
            int[] arr1;//后面使用需要对其进行初始化

            //固定写法 变量类型[] 数组名 = new 变量类型[数组长度];
            int[] arr2 = new int[5];//相当于开了5个房间，里面的内容默认 int值 都为0

            //变量类型[] 数组名 = new 变量类型[数组的长度]{内容1，内容2，内容3，.....};必须对应数组的长度
            int[] arr3 = new int[4] { 1, 2, 3, 4 };

            //变量类型[] 数组名 = new 变量类型[] {内容1，内容2，内容3，.....};//后面的内容决定了数组的长度
            int[] arr4 = new int[] { 1, 2, 3, 4, 5, 6 };

            //变量类型[] 数组名 =  {内容1，内容2，内容3，.....};//后面的内容决定了数组的长度
            int[] arr5 = { 1, 2, 3, 4, 5 };//注意，数组的元素必须等同定义数据类型的基类型

            //数组的基类型可以是很多，包括枚举类型
            #endregion

            #region 知识点三 数组的使用
            int[] array = { 1, 2, 3, 4, 5, 6 };

            //1.数组的元素
            //数组变量名.Length
            Console.WriteLine(array.Length);

            //2.获取数组中的元素  不能越界
            //数组中的下标和索引 都是从0 开始
            //通过 索引下标  去获得数组某个元素的值时----------不能越界
            //数组的索引范围是  0--Array.Length
            Console.WriteLine(array[1]);
            Console.WriteLine(array[3]);

            //3.修改数组中的元素
            array[3] = 10;
            Console.WriteLine(array[3]);

            //4.遍历数组 通过循环 快速获取数组中的每一个元素
            for(int i = 0; i < array.Length; i++)
            {
                Console.Write("\t"+array[i]);
            }

            //5.增加数组的元素
            //数组初始化以后是不能 直接添加新的元素 只能通过重新开辟新的数组
            int[] array2 = new int[10];
            for (int i = 0; i < array.Length; i++)
            {
                array2[i] = array[i];
            }


            //6.删除数组的元素
            //数组初始化以后是不能 直接删除新的元素 只能通过重新开辟新的数组


            //7.查找数组中的元素
            // 1 2 3 4 5
            //要查找 3 这个元素在哪个位置
            //只有通过遍历才能确定 数组中 是否存储了一个数组目标
            int a = 3;
            for (int i = 0; i < array.Length; i++)
            {
                if (a == array[i])
                {
                    Console.WriteLine("数字 {0} 在数组array的位置为:{1}", a, i);
                    break;
                }
            }
            #endregion

            //总结
            //1.概念 ：同一变量类型的数据集合
            //2.一定要掌握 数组的 声明 遍历 增删改查
            //3.所有的变量类型都可以声明成 数组
            //4. 他是用来批量存储游戏中的同一类型对象 的容器，比如所有的怪物、所有的玩家
        }
    }
}
