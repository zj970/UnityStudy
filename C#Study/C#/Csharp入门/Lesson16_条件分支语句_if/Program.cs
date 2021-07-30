using System;

namespace Lesson16_条件分支语句_if
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Lesson16_条件分支语句_if");

            #region 知识点一 作用
            //让顺序执行的代码 产生分支
            //if语句是第一个 可以让我们的程序产生逻辑变化的语句
            #endregion

            #region 知识点二 if语句
            //作用：满足条件时 多执行一些代码
            //语法;
            //if (bool类型值)
            //{
            //  满足条件要执行的代码 写在if代码块中;
            //}
            //注意if语句可以嵌套使用 可以无限嵌套 哈哈哈 最多有5000左右if是电脑配置决定
            string name = "周健";
            string passWord = "666";
           
            if (name.Equals("周健") && passWord == "666")
            {
                Console.WriteLine("登录成功！");
            }
            #endregion

            #region 知识点三 if...else语句
            //作用：产生两分支 满足做什么，不满足做什么
            //if (bool)
            //{
            //满足做什么
            //}
            //else
            //{
            //不满足做什么
            //}可以嵌套使用
            #endregion

            #region 知识点四 if...else if...else语句
            //产生n条分支
            /////........
            #endregion
        }
    }
}
