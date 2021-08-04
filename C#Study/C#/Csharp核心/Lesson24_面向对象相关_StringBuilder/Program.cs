using System;
using System.Text;

namespace Lesson24_面向对象相关_StringBuilder
{
    #region 知识回顾
    //string 是特殊的引用
    //每次重新赋值或者拼接时会分配新的内存空间
    //如果一个字符串经常改变会非常浪费时间
    #endregion
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            #region 知识点 StringBuilder
            //C#提供的一个用于处理字符串的公共类
            //主要修改的问题是：
            //修改字符串而不创建新的对象，需要频繁修改和拼接的字符串可以使用它，可以提高性能
            //使用前 需要引用命名空间using.System.Text

            #region 初始化 直接指明内容
            StringBuilder str = new StringBuilder("1231232222222222888");//第二个参数是自定义容量
            Console.WriteLine(str);
            #endregion

            #region 容量
            //StringBuilder存在一个容量的问题，每次往里面增加 会自动扩容
            //获得容量
            Console.WriteLine(str.Capacity);//获得容量，最小为16,初始化为16,超过就18 * 2
            Console.WriteLine(str.Length);
            //获得字符长度
            #endregion

            #region 增删查改替换
            //增
            str.Append("456");//往后面增加
            Console.WriteLine(str.Capacity);
            str.AppendFormat("{0}{1}", 12, 1564);
            Console.WriteLine(str.Capacity);
            //插入
            str.Insert(0, "1564");//从第一个参数位置 加
            //删
            str.Remove(0, 10);//第0位后10字符删除
            //清空
            //str.Clear();

            //改
            str[1] = 'q';
            //查
            Console.WriteLine(str[1]);
            //替换
            str.Replace("1", "AA");//直接改变原内容
            Console.WriteLine(str);

            //重新赋值 StringBuilder
            //1.str.Clear();
            //2.在重新赋值


            #endregion
            #endregion
        }
    }
}
