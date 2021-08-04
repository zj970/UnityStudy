using System;

namespace Lesson10_封装_运算符重载
{
    #region 知识点一 基本概念
    //概念
    //让自定义类和结构体
    //能够使用运算符

    //使用关键字
    //operator

    //特点
    //1.一定是一个公共的静态方法
    //2.返回值写在operator前
    //3.逻辑处理自定义

    //作用
    //让自定义类和结构体对象可以进行运算
    //注意
    //1.条件运算符需要成对实现
    //2.一个符号可以多个重载
    //3.不能使用ref 和 out
    #endregion

    #region 知识点二 基本语法
    //public static 返回类型 operator 运算符（参数列表）
    //参数必须有1个类名 类型的参数变量
    //运算符 满足的 参数变量 有限制
    #endregion

    #region 知识点三 实例

    class Point
    {
        public int x;
        public int y;

        public static Point operator +(Point p1,Point p2)
        {
            Point p = new Point();
            p.x = p1.x + p2.x;
            p.y = p1.y + p2.y;
            return p;
        } 
        public static Point operator +(Point p1,int value)
        {
            Point p = new Point();
            p.x = p1.x + value;
            p.y = p1.y + value;
            return p;
        }

        #region 知识点五 可重载和不可重载的运算符
        #region 可重载的运算符

        #region 算数运算符

        #endregion

        #region 逻辑运算符
        public static bool operator !(Point p)
        {
            return false;
        }
        #endregion

        #region 位运算符
        public static Point operator <<(Point p1, int num)
        {
            return null;
        }
        public static Point operator >>(Point p1, int num)
        {
            return null;
        }
        public static Point operator ^(Point p1, Point p2)
        {
            return null;
        }
        public static Point operator |(Point p1, Point p2)
        {
            return null;
        }
        public static Point operator &(Point p1, Point p2)
        {
            return null;
        }
        public static Point operator ~(Point p1)
        {
            return null;
        }
        #endregion

        #region 条件运算符
        //1.返回值一般是bool值，也可以是其他的
        //2.相关符号必须配对实现 比如有 > 必须有 <
        public static bool operator >(Point p1,Point p2)
        {
            return true;
        }
        public static bool operator <(Point p1, Point p2)
        {
            return true;
        }
        #endregion

        #endregion


        #region 不可重载运算符
        //逻辑与&& 逻辑或||
        //索引符 []
        //强转运算符 （）
        //特殊运算符
        //点 . 三目运算符 ? :  赋值符号 =
        #endregion


        #endregion
    }
    #endregion


    class Program
    {
        static void Main(string[] args)
        {
            #region 知识点四 使用
            Point p1 = new Point();
            p1.y = 1;
            p1.x = 1;
            Point p2 = new Point();
            p2.y = 3;
            p2.x = 2;

            Point p = p1 + p2;
            Console.WriteLine(p.x + "\t" + p.y);

            int a = 8;
            Point p3 = p1 + a;
            Console.WriteLine(p3.x + "\t" + p3.y);

            #endregion

            //总结
            //关键字 operator
            // 固定语法 public static 返回值 operator 运算符（参数列表)
            //作用:
            //让自定义的类或结构体对象 进行运算
            //注意
            //1.参数的数量与限制
            //2.条件运算符的配对实现
            //3.一个符号可以多个重载
            //4.不能使用ref 和 out
        }
    }
}
