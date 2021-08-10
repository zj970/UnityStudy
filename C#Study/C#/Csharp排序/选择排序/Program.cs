using System;

namespace 选择排序
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 知识点一 选择排序基本原理
            // 8 7 1 5 4 2 6 3 9
            //新建中间商
            //依次比较
            //找出极值
            //放入目标位置
            //比较n轮
            int[] arr = { 8, 7, 5, 9, 4, 6, 3, 1, 2 };
            #endregion

            #region 知识点二 代码实现
            //实现升序

            //for (int i = 0; i < arr.Length - 1; i++)
            //{
            //    for (int j = i; j < arr.Length; j++)
            //    {
            //        if (arr[i] > arr[j])
            //        {
            //            arr[i] = arr[i] ^ arr[j];
            //            arr[j] = arr[i] ^ arr[j];
            //            arr[i] = arr[i] ^ arr[j];

            //        }
            //    }
            //}

            //第一步 声明一个中间商 来记录索引
            //每一轮开始 默认第一个是极值
            //第二步 依次比较
            //第三步 找出极值
            //第四步 放入目标我位置
            //第五步 比较 m 轮
            for (int m = 0; m < arr.Length; m++)
            {
                int index = 0;
                for (int n = 0; n < arr.Length -m; n++)
                {
                    if (arr[index] < arr[n])
                    {
                        index = n;
                    }
                }
                if (index != arr.Length-1-m)
                {
                    int temp = arr[index];
                    arr[index] = arr[arr.Length - 1 - m];
                    arr[arr.Length-1-m] = temp;
                }
            }

            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(arr[i]);
            }
            #endregion
        }
    }
    
    //总结
    //基本概念 
    //新建中间商 依次比较 找出极值 放入目标位置 比较m轮
    //套路写法
    //两层循环 外层轮数 内层寻找 初始索引 记录极值 内循环外交换
}
