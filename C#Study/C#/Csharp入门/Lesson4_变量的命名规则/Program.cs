using System;

namespace Lesson4_变量的命名规则
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Lesson4_变量的命名规则!");


            #region 知识点一 ：必须遵守的规则
            //1.不能重名
            //2.不能以数字开头
            //3.不能使用程序关键字命名
            //4.不能有特殊符号（下划线除外）
            //跟C差不多，C中的命名规则多了一条：只能由数字、下划线、和字母
            //java比C多了个特殊字符----$----

            //建议命名规则： 变量名要有含义 --》用英文（拼音）表示变量的作用
            //非常不建议用汉字命名
            #endregion

            #region 知识点二：常用命名规则
            //驼峰命名法---首字母小写，之后单词首字母大写（变量）
            string myName = "周健";
             
            //帕斯卡命名法---所有单词首字母都大写（函数、类）
            //潜在知识点 ---- c# 中对大小写是敏感的。
            #endregion
        }
    }
}
