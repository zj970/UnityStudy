using System;
using System.Collections;
using System.Collections.Generic;
namespace Lesson8_Dictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            #region 知识点一 Dictionary的本质
            //可以将Dictionary理解为 拥有泛型的Hashtable
            //它也是基于键的哈希代码组织起来的 键/值对
            //键值对 类型从Hashtable的object变为了 可以自己指定的类型
            #endregion

            #region 知识点二 声明
            Dictionary<int, string> dictionary = new Dictionary<int, string>();

            #endregion

            #region 知识点三 增删查改
            //增
            //注意不能出现相同键
            dictionary.Add(1, "13465");
            dictionary.Add(2, "15");
            dictionary.Add(3, "132265");
            dictionary.Add(4, "1346445");

            //删
            //1.只能通过键去删除
            //删除不存在的键，没有反应
            dictionary.Remove(3);
            //2.清空
            //dictionary.Clear();

            //查
            //1.通过键查看值
            //找不到会出错
            Console.WriteLine(dictionary[2]);
            //2.检查是否存在
            //根据键检测
            if (dictionary.ContainsKey(1))
            {
                Console.WriteLine("存在键为1");
            }
            //根据值检测
            if (dictionary.ContainsValue("15"))
            {
                Console.WriteLine("存在值为15");

            }

            //改
            Console.WriteLine(dictionary[1]);
            dictionary[1] = "49786";
            Console.WriteLine(dictionary[1]);

            #endregion

            #region 遍历
            Console.WriteLine("******************");
            Console.WriteLine(dictionary.Count);//得到对数
            //1.遍历所有键
            foreach (int item in dictionary.Keys)
            {
                Console.WriteLine(item);
                Console.WriteLine(dictionary[item]);
            }
            Console.WriteLine("******************");

            //2.遍历所有值
            foreach (string item in dictionary.Values)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("******************");

            //3.键值对一起遍历
            foreach (KeyValuePair<int,string> item in dictionary)
            {
                Console.WriteLine(item.Key);
                Console.WriteLine(item.Value);
            }
            Console.WriteLine("******************");
            //迭代器遍历
            IDictionaryEnumerator myEnumerator = dictionary.GetEnumerator();//返回一个接口类型
            bool flag = myEnumerator.MoveNext();//获取下一个键值对，有true,无false
            while (flag)
            {
                Console.Write("键" + myEnumerator.Key);
                Console.Write("\t值" + myEnumerator.Value);
                Console.WriteLine();
                flag = myEnumerator.MoveNext();
            }
            #endregion
        }
    }
}
