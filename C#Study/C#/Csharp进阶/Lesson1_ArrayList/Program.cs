using System;
using System.Collections;

namespace Lesson1_ArrayList
{
    class Test
    {

    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Lesson1_ArrayList");

            #region 练习题回顾
            //自定义一个整型数组，该类中有一个整型数组变量
            //为它封装增删查改的方法
            #endregion

            #region 知识点一 ArrayList的本质
            //ArrayList是一个C#为我们封装好的类
            //它的本质是一个object类型的数组
            //ArrayList类帮助我们实现了很多方法
            //比如数组的增删查改
            #endregion

            #region 知识点二 声明
            //需要引用命名空间using System.Collections;
            ArrayList array = new ArrayList();
            #endregion

            #region 知识点三 增删查改

            #region 增
            array.Add(1);
            array.Add("123456");
            array.Add(true);
            array.Add(new Test());
            array.Add(1);
            array.Add(true);

            ArrayList array2 = new ArrayList();
            array2.Add(123);

            //范围增加（批量增加 把另一个List容器里面的内容加到后面）
            array.AddRange(array2);

            //插入
            array.Insert(1, "134");//第一个参数是位置

            #endregion

            #region 删
            //移除指定元素 从头找 找到删
            array.Remove(1);
            //移除指定位置的元素
            array.RemoveAt(2);
            //清空
            //array.Clear();

            #endregion

            #region 查
            //得到指定位置元素
            Console.WriteLine(array[0]);

            //查看元素是否存在
            if (array.Contains("123"))
            {
                Console.WriteLine("存在123");
            }
            else
            {
                Console.WriteLine("不存在123");
            }

            //正向查找元素位置 只找第一个
            //找到的返回值 是位置 找不到 返回值为-1

            int index = array.IndexOf(true);
            Console.WriteLine(index);

            Console.WriteLine(array.IndexOf(false));

            //反向查找元素位置
            //返回是 从头开始找的索引下标
            Console.WriteLine(array.LastIndexOf(true));
            #endregion

            #region 改
            Console.WriteLine(array[0]);
            array[0] = 999;
            Console.WriteLine(array[0]);
            #endregion

            #endregion

            #region 遍历
            //长度
            Console.WriteLine(array.Count);
            //容量
            //避免产生过多的垃圾
            Console.WriteLine(array.Capacity);

            for (int i = 0; i < array.Count; i++)
            {
                Console.Write("\t" + array[i]);
            }
            Console.WriteLine();
            //迭代器遍历
            foreach (object item in array)
            {
                //每次进入array,都会把其中元素放到 临时变量Item 中类型自定义为object与array相同
                Console.Write("\t" + item);
            }
            #endregion

            #region 知识点四 装箱拆箱
            //ArrayList本质上是一个可以自动扩容的object数组
            //由于用万物之父来存储数据，自然存在装箱拆箱
            //当往其中进行 值类型存储时 就是在装箱，当将值类型对象取出来转换使用时，就存在拆箱
            //所以ArrayList尽量少用

            int i = 1;
            array[0] = i;//装箱

            i = (int)array[0];//拆箱
            #endregion

        }
    }
}
