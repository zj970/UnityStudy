using System;

namespace Lesson8_类型转换_显示转换
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Lesson8_类型转换_显示转换");

            //显示转换-->手动处理 强制转换


            #region 知识点一 括号强转
            //作用 一般情况下 将高精度的类型强制转换为低精度
            //语法: <type> <name> = (type) <name>;
            //注意： 精度范围 范围问题

            //相同大类的整型
            //有符号整型
            sbyte sb = 1;
            short s = 1;
            int i = 40000;

            //括号强转 可能会出现范围问题 造成的异常
            s = (sbyte)i;
            Console.WriteLine(s);

            //无符号之间整型 同上


            //浮点数之间 会造成精度缺失
            float f = 1.1f;
            double d = 1.1235456748979d;

            f = (float)d;
            Console.WriteLine(f);

            //无符号和有符号
            uint ui2 = 2;
            int i2 = -2;
            //在强转时 一定要注意范围 不然得到的结果 可能会有异常
            ui2 = (uint)i2;
            Console.WriteLine(ui2);

            //浮点和整型 浮点数强转整型时 会直接抛弃掉小数点后面的小数，不存在四舍五入
            i2 = (int)1.8f;
            Console.WriteLine(i2);

            //char和数值类型
            i2 = 'A';
            char c = (char)i2;
            Console.WriteLine(c);

            //bool 和 string 是不能通过括号的形式强行转换



            #endregion

            #region 知识点二 Parse法
            //作用 把字符串类型转换为对应的类型
            //语法： 变量类型.Parse("字符串");
            //注意： 字符串必须能够把转换成对应类型 否则报错

            //有符号
            //string str = "123";
            int i4 = int.Parse("1231");
            Console.WriteLine(i4);
            //我们填写的字符串 必须是要能够转换成对应类型的字符 如果不符合就会报错
            //i4 = int.Parse("123.4");
            //Console.WriteLine(i4);

            //值的范围 必须是能够被变量存储的值 否则报错
            //short s3 = short.Parse("40000");
            //Console.WriteLine(s3);
            Console.WriteLine(int.Parse("1234"));

            //无符号
            Console.WriteLine(uint.Parse("1234"));
            Console.WriteLine(ulong.Parse("1234"));
            //Console.WriteLine(byte.Parse("1234"));
            //Console.WriteLine(short.Parse("1234"));

            //浮点数
            float f3 = float.Parse("1.121");
            double d3 = double.Parse("1.2153");

            //特殊类型
            bool b4 = bool.Parse("true");
            Console.WriteLine(b4);

            char c2 = char.Parse("B");
            Console.WriteLine(c2);

            #endregion

            #region 知识点三 Convert法
            //作用 更准确的将各个类型之间进行相互转换
            //语法 Convert.To目标类型(变量或常量)
            //注意： 填写的变量或常量必须正确 否则会出错

            //转字符串 如果是把字符串转对应类型 那字符串一定要合法合规
            int a = Convert.ToInt32("132");
            Console.WriteLine(a);

            a = Convert.ToInt32(1.65489f);//会四舍五入
            Console.WriteLine(a);

            //精度更准确
            //特殊类型转换
            a = Convert.ToInt32(true);//为0
            Console.WriteLine(a);
            a = Convert.ToInt32(false);//为1
            Console.WriteLine(a);

            //每个类型都存在对应的Convert中的方法
            sbyte sb5 = Convert.ToSByte("1");
            short s5 = Convert.ToInt16("1");
            int i5 = Convert.ToInt32("1");
            long l5 = Convert.ToInt64("1");


            byte b6 = Convert.ToByte("1");
            ushort us6 = Convert.ToUInt16("1");
            uint ui6 = Convert.ToUInt32("1");
            ulong ul6 = Convert.ToUInt64("1");

            float f5 = Convert.ToSingle("13.2");
            double d5 = Convert.ToDouble("13.2");
            decimal de5 = Convert.ToDecimal("13.2");

            bool bo5 = Convert.ToBoolean("true");
            char c5 = Convert.ToChar("A");
            string str5 = Convert.ToString(1564);
            #endregion

            #region 其他类型转string
            //作用： 拼接打印 就会自动调用toString转换string
            //语法: 变量.toString();

            int aa = 1;
            Console.WriteLine(aa.ToString());
            #endregion
        }
    }
}
