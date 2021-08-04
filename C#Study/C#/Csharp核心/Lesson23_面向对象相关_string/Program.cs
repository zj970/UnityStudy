using System;

namespace Lesson23_面向对象相关_string
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            #region 知识点一 字符串指定位置获取
            //字符串本质是char数组
            string str = "123456";
            Console.WriteLine(str[1]);
            //转为数组
            char[] chars = str.ToCharArray();

            #endregion

            #region 知识点二 字符串拼接
            str = string.Format("{0}{1}", 1, 2334);
            #endregion

            #region 知识点三 正向查找字符位置
            str = "xccvvvccvbnm";
            Console.WriteLine(str.IndexOf("v")); //有返回索引值，没有返回-1；多个相同取第一个
            #endregion

            #region 知识点四 反向查找字符位置
            str = "xcvfffffdfdbnm";
            Console.WriteLine(str.LastIndexOf("ff"));//有返回索引值，没有返回-1；多个相同取最后一个
            #endregion

            #region 知识点五 移除指定位置后的字符
            str = "xcvffffdbnm";
            str.Remove(5);
            Console.WriteLine(str);//不会移除原字符
            string str1 = str.Remove(5);
            Console.WriteLine(str1);//会移除

            //执行两个参数进行移除
            //参数1 开始位置
            //参数2 字符个数
            str1 = str1.Remove(1, 2);
            Console.WriteLine(str);//不会移除
            #endregion

            #region 知识点六 替换指定位置后的字符
            str = "我是唐老师唐老师";
            str.Replace("唐老师", "老泡儿");
            Console.WriteLine(str);//不会改变原来
            str1 = str.Replace("唐老师", "老泡儿");
            Console.WriteLine(str1);
            #endregion

            #region 知识点七 大小写转换
            //小转大 ToUpper
            str = "zbjfjkfvn";
            str.ToUpper();
            str1 = str.ToUpper();
            Console.WriteLine(str1);
            //大转小 ToLower
            Console.WriteLine(str1.ToLower());
            #endregion

            #region 知识点八 字符串截取
            str = "sdfdffvvf";
            str.Substring(2);//从第2位开始截取
            Console.WriteLine(str.Substring(2));
            //执行两个参数进行截取
            //参数1 开始位置
            //参数2 字符个数
            Console.WriteLine(str.Substring(2,2));//第二个参数不能超出范围
            #endregion

            #region 知识点九 字符串切割 重要 -----
            str = "1_1,2,3,4,5,6,7,8";
            string[] strs = str.Split(",");//以 , 切割出存放在strs[] 里面
            #endregion

        }
    }
}
