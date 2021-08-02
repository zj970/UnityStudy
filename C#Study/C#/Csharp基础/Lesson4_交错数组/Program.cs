using System;

namespace Lesson4_交错数组
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Lesson4_交错数组");

            #region 知识点一 基本概念
            //交错数组 是 数组的数组 ，每个维度的数量可以是不同

            //注意：二维数组的每行的列数相同，交错数组每行的列数可以不同
            #endregion

            #region 知识点二 数组的声明
            //变量类型[][] 交错数组名;
            int[][] arr1;
            //变量类型[][] 交错数组名 = new 变量类型[行数][];
            int[][] arr2 = new int[2][];
            //变量类型[][] 交错数组名 = new 变量类型[行数][];{一维数组1，一维数组2,...};
            int[][] arr3 = new int[3][] { new int[] { 1, 2 }, new int[3], new int[4] };
            //变量类型[][] 交错数组名 = new 变量类型[行数][];{一维数组1，一维数组2,...};
            int[][] arr4 = new int[][] { new int[] { 1, 2 }, new int[3], new int[4] };
            //变量类型[][] 交错数组名 = new 变量类型[行数][];{一维数组1，一维数组2,...};
            int[][] arr5 ={ new int[] { 1, 2 }, new int[3], new int[4] };
            #endregion

            #region 知识点三 数组的使用
            int[][] array = { new int[] { 2, 3, 1 }, new int[] { 1, 2, 3, 4, 5 } };

            //1.数组的长度
            //行
            Console.WriteLine(array.GetLength(0));
            //得到某一行的列数
            Console.WriteLine(array[1].Length);

            //2.获取交错数组中的元素
            //注意:不能越界
            Console.WriteLine(array[1][1]);

            //3.修改交错数组中的元素
            array[1][1] = 99;

            //4.遍历交错数组
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    Console.Write("\t"+array[i][j]);
                }
                Console.WriteLine();
            }

            //5.增加交错数组的元素

            //6.删除交错数组的元素

            //7.查找交错数组的元素
            #endregion

            //总结
            //1.概念：交错数组 可以存储同一类型的m行不确定列的数据
            //2.一定要掌握 数组的 声明 遍历 增删改查
            //3.所有的变量类型都可以声明成 数组
           
        }
    }
}
