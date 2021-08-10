using System;

namespace 冒泡排序
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 知识点一 排序的基本概念
            //排序是计算机内经常进行的一种操作，其目的是将一组“无序”的记录序列调整为“有序”的记录序列
            //常用的排序例子
            //8 7 5 9 4 6 3 1 2
            //把上面的这个无序序列 变为有序（升序或降序） 的序列过程
            //1 2 3 4 5 6 7 8 9(升序)
            //9 8 7 6 5 4 3 2 1(降序)

            //在程序中 序列一般 存储在数组当中
            //所以 排序往往是对数组进行排序
            int[] arr = { 8, 7, 5, 9, 4, 6, 3, 1, 2 };
            //把数组里面的内容变为有序的
            #endregion

            #region 知识点二 冒泡排序的基本原理
            //8 7 5 9 4 6 3 1 2
            //两两相邻
            //不停比较
            //不停交换
            //比较n轮
            #endregion

            #region 知识点三 代码实现
            ////比较n轮
            //for (int i = 0; i < arr.Length; i++)
            //{
            //    for (int j = 0; j < arr.Length-1; j++)
            //    {
            //        //如果 第n个数 比 第n+1个数 大 他们就要交换位置
            //        if (arr[j] > arr[j+1])
            //        {
            //            arr[j] = arr[j] ^ arr[j+1]; 
            //            arr[j+1] = arr[j] ^ arr[j+1];
            //            arr[j] = arr[j] ^ arr[j+1];
            //        }
            //    }
            //}
            //优化
            //1.确定位置的数字 不用比较了
            //  确定了一轮后 极值（最大或最小）已经到了对应的位置
            //  所以 每完成一轮，后面位置的数+1 就不用再参与比较了
            //比较n轮
            //for (int i = 0; i < arr.Length; i++)
            //{
            //    for (int j = 0; j < arr.Length - 1 - i; j++)
            //    {
            //        //如果 第n个数 比 第n+1个数 大 他们就要交换位置
            //        if (arr[j] > arr[j + 1])
            //        {
            //            arr[j] = arr[j] ^ arr[j + 1];
            //            arr[j + 1] = arr[j] ^ arr[j + 1];
            //            arr[j] = arr[j] ^ arr[j + 1];
            //        }
            //    }
            //}

            //2.特殊情况的优化
            bool isSort = false;
            for (int i = 0; i < arr.Length; i++)
            {
                isSort = false;
                for (int j = 0; j < arr.Length - 1; j++)
                {
                    //如果 第n个数 比 第n+1个数 大 他们就要交换位置
                    if (arr[j] > arr[j + 1])
                    {
                        isSort = true;
                        arr[j] = arr[j] ^ arr[j + 1];
                        arr[j + 1] = arr[j] ^ arr[j + 1];
                        arr[j] = arr[j] ^ arr[j + 1];
                    }
                }

                //当一轮结束后 如果isSort这个标识 还是false
                //那就意味着 已经是最终的序列了，就不用再判断交换了
                if (!isSort)
                {
                    break;
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
    //两两相邻 两两比较 两两交换

    //套路写法
    //两层循环 外层轮数 内存比较 两值比较 满足交换
    
    //优化
    //1.比过不比
    //2.加标识位
}
