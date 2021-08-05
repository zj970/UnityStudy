using System;
using System.Collections;
namespace lesson3_Queue
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 知识点一 Queue本质
            //Queue是一个C#为我们封装好的类
            //它的本质也是object[]数组，只是封装了特殊的存储规则

            //Queue是队列存储容器
            //队列是一种先进先出的数据结构
            //先存入的数据ixna获取，后存入的数据后获取
            //先进先出
            #endregion

            //Queue<int> q = Queue<int>();错误

            #region 知识点二 声明
            Queue queue = new Queue();
            #endregion

            #region 知识点三 增取查改
            //增 任意内容
            queue.Enqueue(1);
            queue.Enqueue("333");
            queue.Enqueue(true);
            queue.Enqueue(23);
            queue.Enqueue("4633");
            queue.Enqueue(false);

            //取 先加入的对象
            object o = queue.Dequeue();
            Console.WriteLine(o);
            o = queue.Dequeue();
            Console.WriteLine(o);

            //查
            //1.查看队列头部元素但不会删除
            o = queue.Peek();
            Console.WriteLine(o);
            o = queue.Peek();
            Console.WriteLine(o);
            //2.查看元素是否存在队列中
            if (queue.Contains(false))
            {
                Console.WriteLine("存在false");
            }

            //改
            //队列无法改变其中的元素 只能进出队列
            //要改，只能清空
            //queue.Clear();

            #endregion

            #region 知识点四 遍历
            //长度
            Console.WriteLine(queue.Count);
            //用foreach遍历
            foreach (object item in queue)
            {
                Console.Write(item + "\t");
            }
            Console.WriteLine();
            //也可以将 队列转换为object数组
            //循环出列
            while (queue.Count > 0)
            {
                o = queue.Dequeue();
                Console.WriteLine(o);
            }
            #endregion

            #region 知识点五 装箱拆箱
            //由于用万物之父来存储数据，自然存在装箱拆箱
            //当往其中进行 值类型存储时 就是在装箱，
            //当将值类型对象取出来转换使用时，就存在拆箱
            #endregion
        }
    }
}
