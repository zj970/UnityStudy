using System;
using System.Collections;
namespace Lesson4_Hashtable
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 知识点一 Hashtable的本质
            //Hashtable（又称为散列表) 是基于键的哈希代码组织起来的 键/值对
            //它的主要作用是提高数据查询的效率
            //使用键来访问集合中的元素
            #endregion

            #region 知识点二 Hashtable的声明
            Hashtable hashtable = new Hashtable();
            #endregion

            #region 知识点三 Hashtable的增删查改
            //增 不能出现相同键
            hashtable.Add(1, "123456");//第一参数是键，第二个是值
            hashtable.Add(2, true);
            hashtable.Add(3, false);
            hashtable.Add("123", "134567489");

            //删
            //1.只能通过键去删除
            hashtable.Remove(1);
            //2.删除不存在的键 没反应
            hashtable.Remove(5);
            //3.清空
            //hashtable.Clear();

            //查
            //1.通过键查看值 找不到会返回空
            Console.WriteLine(hashtable["123"]);
            Console.WriteLine(hashtable[1]);//中括号里 是键
            Console.WriteLine(hashtable[5]);//返回空
            //2.查看是否存在
            //根据键检测
            if (hashtable.Contains(2))
            {
                Console.WriteLine("存在键为2的内容");
            }
            if (hashtable.ContainsKey("123"))
            {
                Console.WriteLine("存在键为123的内容");
            }
            //根据值检测
            if (hashtable.ContainsValue(true))
            {
                Console.WriteLine("存在值为true的内容");
            }

            //改
            //只能改键对应的值内容 无法修改键
            Console.WriteLine(hashtable[1]);
            hashtable[1] = 1111111;
            Console.WriteLine(hashtable[1]);
            #endregion

            #region 知识点四 Hashtable的遍历
            //得到键值对 对数
            Console.WriteLine(hashtable.Count);
            //1.遍历所有键
            foreach (object item in hashtable.Keys)
            {
                Console.Write("键" + item);
                Console.Write("\t值" + hashtable[item]);
                Console.WriteLine();//无规律的
            }
            Console.WriteLine();
            //2.遍历所有值
            foreach (object item in hashtable.Values)
            {
                Console.WriteLine("值" + item);
            }
            Console.WriteLine();
            //3.键值对一起遍历---字典
            foreach (DictionaryEntry item in hashtable)
            {
                Console.Write("键" + item.Key);
                Console.Write("\t值" + item.Value);
                Console.WriteLine();//无规律的
            }
            Console.WriteLine();
            //迭代器遍历法
            IDictionaryEnumerator myEnumerator = hashtable.GetEnumerator();//返回一个接口类型
            bool flag = myEnumerator.MoveNext();//获取下一个键值对，有true,无false
            while (flag)
            {
                Console.Write("键" + myEnumerator.Key);
                Console.Write("\t值" + myEnumerator.Value);
                Console.WriteLine();
                flag = myEnumerator.MoveNext();
            }
            #endregion

            #region 知识点五 Hashtable的装箱拆箱
            //由于用万物之父来存储数据，自然存在装箱拆箱
            //当往其中进行 值类型存储时 就是在装箱，
            //当将值类型对象取出来转换使用时，就存在拆箱
            #endregion
        }
    }
}
