using System;
using System.Collections.Generic;

namespace Lesson7_List
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");


            #region 知识点一 List的本质
            //List是一个C#为我们封装好的类
            //它的本质是一个可变类型的泛型数组
            //List类帮助我们实现了很多方法
            //比如泛型数组的增删查改
            #endregion

            #region 知识点二 声明
            //需要应用命名空间using System.Collections.Generic;
            List<int> list1 = new List<int>();
            List<string> list2 = new List<string>();
            List<bool> list3 = new List<bool>();

            #endregion

            #region 知识点三 增删查改
            //增
            list1.Add(1);
            list1.Add(2);
            list1.Add(3);
            list1.Add(4);
            list1.Add(5);
            list2.Add("132456");
            list2.Add("1");
            //范围增
            List<string> list2_1 = new List<string>();
            list2_1.AddRange(list2);
            //插入
            list1.Insert(0, 234);

            //删
            //1.移除指定元素
            list1.Remove(1);
            //2.移除指定位置的元素
            list1.RemoveAt(0);
            //3.清空
            //list1.Clear();

            //查
            //1.得到指定位置的元素
            Console.WriteLine(list1[3]);
            //2.查看元素是否存在
            if (list1.Contains(4))
            {
                Console.WriteLine("存在元素4");

            }
            //3.正向查找元素位置
            //找到返回位置 找不到返回 -1
            int index = list1.IndexOf(1);
            Console.WriteLine(index);
            //4.反向查找元素位置
            //找到返回位置 找不到返回 -1
            index = list1.LastIndexOf(5);

            //改
            Console.WriteLine(list1[0]);
            list1[0] = 4444;
            Console.WriteLine(list1[0]);
            #endregion

            #region 知识点四 遍历
            //长度
            Console.WriteLine(list1.Count);
            //容量
            //避免产生垃圾
            Console.WriteLine(list1.Capacity);
            Console.WriteLine("-----------------------");
            for (int i = 0; i < list1.Count; i++)
            {
                Console.Write("\t" + list1[i]);
            }
            Console.WriteLine("\n-----------------------");
            foreach (int item in list1)
            {
                Console.Write("\t" + item);

            }
            #endregion
        }
    }
}
