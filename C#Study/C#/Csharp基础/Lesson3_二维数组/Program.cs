using System;

namespace Lesson3_二维数组
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Lesson3_二维数组");

            #region 知识点一 基本概念
            //二维数组是 使用两个下标（索引）来确定元素的数组
            //两个下标可以理解成 行标 和 列标
            //比如矩阵
            // 1 2 3
            // 4 5 6
            //就可以用二维数组 int[2,3] 表示
            //好比 两行三列 的数据集合 //但其在内存空间上是 顺序存储的
            #endregion

            #region 知识点二 二维数组的声明
            //1.变量类型[ , ] 二维数组变量名;
            int[,] arr;//声明过后 会在后面进行初始化

            //2.变量类型[, ] 二维数组变量名 = new 变量类型[行，列];
            int[,] arr1 = new int[2, 4];

            //3.变量类型[, ] 二维数组变量名 = new 变量类型[行，列] {{0行内容0，0行内容1...},{1行内容0，1行内容1...},{2行内容0，2行内容1...}..,};
            int[,] arr3 = new int[3, 4] { { 1,2,3,4},
                                          { 5,6,7,8 },
                                          { 1,2,3,4} };

            //4.变量类型[, ] 二维数组变量名 = new 变量类型[，] {{0行内容0，0行内容1...},{1行内容0，1行内容1...},{2行内容0，2行内容1...}..,};


            //5.变量类型[, ] 二维数组变量名 ={{0行内容0，0行内容1...},{1行内容0，1行内容1...},{2行内容0，2行内容1...}..,};

            #endregion

            #region 知识点三 二维数组的使用
            int[,] arr4 = new int[, ] { { 1,2,3,4},
                                          { 5,6,7,8},
                                          { 1,2,3,4} };

            //1.二维数组的长度
            //我们要获取 行和列分别是多长 Array.GetLength() ,0获取行，1获取列
            //得到多少行
            Console.WriteLine(arr4.GetLength(0));
            //得到多少列
            Console.WriteLine(arr4.GetLength(1));

            //2.获取二维数组中的元素
            //注意： 第一个元素的索引是0 最后一个元素的索引 是Length -1
            Console.WriteLine(arr4[arr4.GetLength(0) - 1, arr4.GetLength(1) - 1]);

            //3.修改二维数组的元素
            arr4[2, 3] = 99;

            //4.遍历二维数组的元素
            Console.WriteLine("---------------------分割线-----------------");
            for (int i = 0; i < arr4.GetLength(0); i++)
            {
                for (int j = 0; j < arr4.GetLength(1); j++)
                {
                    Console.Write("\t" + arr4[i, j]);
                }
                Console.Write("\n");
            }

            //5.增加二维数组的元素
            //数组初始化以后是不能 直接添加新的元素 只能通过重新开辟新的数组
            int[,] array = new int[5, 6];

            //数组初始化以后是不能 直接添加新的元素 只能通过重新开辟新的数组

            //7.查看二维数组的元素
            int a = 7;
            for (int i = 0; i < arr4.GetLength(0); i++)
            {
                for (int j = 0; j < arr4.GetLength(1); j++)
                {
                    if (a == arr4[i,j])
                    {
                        Console.WriteLine("数字 {0} 在数组array的位置为:第{1}行，第{2}列", a, i+1,j+1);
                        break;
                    }
                   
                }
            }

            #endregion

            //总结;
            //1.概念：同一变量类型的 行列数据集合
            //2.一定要掌握 数组的 声明 遍历 增删改查
            //3.所有的变量类型都可以声明成 二维数组
            //4.由此中一般用来存储 矩阵，在控制台小游戏中可以二维数组 来表示地图格子


            //练习题
            //1.将1到10000赋值给一个二维数组
            int[,] array1 = new int[100, 100];
            int target = 1;
            for (int i = 0; i < array1.GetLength(0); i++)
            {
                for (int j = 0; j < array1.GetLength(1); j++)
                {
                    array1[i, j] = target++;
                    //Console.Write("\t" + array1[i, j]);
                }
                //Console.Write("\n");
            }
            //2.将二维数组（4行4列）的右上部分置零（元素随机1-100）
            int[,] array2 = new int[4, 4];
            Random rd = new Random();
            for (int i = 0; i < array2.GetLength(0); i++)
            { 
                for (int j = 0; j < array2.GetLength(1); j++)
                {
                    if ((i == 0 && j <= 1) || (i == 1 && j <= 1))
                    {
                        Console.Write("\t" + array2[i, j]);
                        continue;
                    }
                    array2[i, j] = (int)rd.Next(1, 100);
                    Console.Write("\t" + array2[i, j]);
                }
                Console.Write("\n");
            }
            Console.WriteLine("----------------------------------------------");
            //3.求二维数组（3行3列）的对角线元素的和（元素随机1-10）
            int[,] array3 = new int[3, 3];
            int sum = 0;
            for (int i = 0; i < array3.GetLength(0); i++)
            {
                for (int j = 0; j < array3.GetLength(1); j++)
                {
                    array3[i, j] = (int)rd.Next(1, 10);
                    Console.Write("\t" + array3[i, j]);
                    if (i == j)
                    {
                        sum += array3[i, j];
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine("这个数组对角线元素的和为：{0}",sum);
            Console.WriteLine("----------------------------------------------");

            //4.求二维数组(5行5列)中最大元素值及其行列号（元素随机1-500）
            int[,] array4 = new int[5, 5];
            int[] test = new int[2];
            int max = 0;
            //先遍历找出最大值，再遍历得出下标  还有就是用你一维数组存放下标，时间复杂度降低，空间复杂度上升
            //for (int i = 0; i < array4.GetLength(0); i++)
            //{
            //    for (int j = 0; j < array4.GetLength(1); j++)
            //    {
            //        array4[i, j] = (int)rd.Next(1, 500);
            //        Console.Write("\t" + array4[i, j]);
            //        if (array4[i, j] > max)
            //        {
            //            max = array4[i, j];
            //        }
            //    }
            //    Console.WriteLine();
            //}
            for (int i = 0; i < array4.GetLength(0); i++)
            {
                for (int j = 0; j < array4.GetLength(1); j++)
                {
                    array4[i, j] = (int)rd.Next(1, 500);
                    Console.Write("\t" + array4[i, j]);
                    if (array4[i, j] > max)
                    {
                        max = array4[i, j];
                        test[0] = i + 1;
                        test[1] = j + 1;
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine("这个数的最大值为：{0},在数组的第 {1}行，第 {2} 列", max, test[0], test[1]);
            Console.WriteLine("----------------------------------------------");

            //5.给定数组按要求转换    //有问题
            //00000 00000 01000 00110 00000
            //转换为 01110 01110 11111 11111 01110
            bool needFillFirstRow = false;
            bool needFillFirstColum = false;

            int[,] array5 = { { 0,0,0,0,0},
                              { 0,0,0,0,0},
                              { 0,1,0,0,0},
                              { 0,0,1,1,0},
                              { 0,0,0,0,0}};
            for (int i = 0; i < array5.GetLength(0); i++)
            {
                for (int j = 0; j < array5.GetLength(1); j++)
                {
                    if (array5[i,j] == 1)
                    {
                        if (i == 0)
                        {
                            needFillFirstRow = true;
                        }
                        if(j == 0)
                        {
                            needFillFirstColum = true; 
                        }
                        array5[i, 0] = 1;
                        array5[0, j] = 1;
                    }
                    //Console.Write("\t" + array5[i, j]);
                }
               // Console.WriteLine();
            }
            //填充行
            for (int i = 0; i < array5.GetLength(0); i++)
            {
                if (array5[i,0] == 1)
                {
                    for (int j = 0; j < array5.GetLength(1); j++)
                    {
                        array5[i, j] = 1;
                    }
                }
            }
            //填充列
            for (int i = 0; i < array5.GetLength(1); i++)
            {
                if (array5[0, i] == 1)
                {
                    for (int j = 0; j < array5.GetLength(0); j++)
                    {
                        array5[j, i] = 1;
                    }
                }
            }

            if (needFillFirstRow)
            {
                for (int i = 0; i < array5.GetLength(0); i++)
                {
                    array5[0, i] = 1;
                }

            }

            if (needFillFirstColum)
            {
                for (int i = 0; i < array5.GetLength(1); i++)
                {
                    array5[i, 0] = 1;
                }

            }
            for (int i = 0; i < array5.GetLength(0); i++)
            {
                for (int j = 0; j < array5.GetLength(1); j++)
                {
                    
                    Console.Write("\t" + array5[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}
