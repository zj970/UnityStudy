//引用命名空间
using System;

//命名空间
namespace Lesson2_变量
{

    //类
    class Program
    {
        static void Main(string[] args)
        {
            //函数语句快 目前学习的内容都写在这里
            Console.WriteLine("变量");

            //知识点一 折叠代码
            //主要作用 是让我们编程时 逻辑更加清晰
            //它是有 #region #endregion配对出现的
            //它的作用是可以将中间包裹的代码折叠起来，避免代码太凌乱
            //本质是 编辑器提供给我们的预处理指令
            //它只会在编辑时有用，发布了代码 或执行代码 它会被自动删除

            #region 如何申明变量
            //变量 就是可以变化的容器 变量就是用来存储各种不同类型数值的 一个容器
            //不同的 变量类型 可以存储不同类型的值

            //变量申明固定写法
            //变量类型 变量名 = 初始值;
            int testInt = 0;
            //变量类型 有14种
            //变量名 我们自定义 但有一定的规则
            //初始值 一定要和变量类型统一
            // = 和 ; 是固定的 不变的 ;是英文符号

            //变量类型
            //一点要死记硬背 各种变量类型的关键字
            //一点要记住 各种不同变量类型 所能存储的范围
            //一定要记住 各种不同变量类型 所能存储的类型

            //1.有符号的整形变量 是能存储 一定范围 正负数包括0的变量类型
            //sybet -128 - 127
            sbyte sb = 1;
            //潜在 可以通过+来进行拼接打印
            Console.WriteLine(sb);
            // int -21亿 - 21亿
            int i = 2;
            //short -32768 - 32767
            short j = 3;
            //long -900万兆- 900万兆
            long k = 4;

            //2.无符号的整形变量 是能存储 一定范围 0 和整数的变量类型
            //byte 0-255
            //uint 0 - 42亿
            //ushort 0 - 65535之间的数
            //ulong 0-1800万兆


            //3.浮点数（小数）
            //float 存储7/8位有效数字 是从非0数字左到右开始计算有效数字，四舍五入。
            //之所以要在后面加f 是因为 声明的小数 默认是double的类型 加f 告诉编译器是float 类型
            float f = 0.1234567890f;
            Console.WriteLine(f);
            //double 存储15-17位有效数字
            //decimal 存储27-28位有效数字,声明必须加M/m;
            decimal de = 0.123456789012345678903456789m;

            //4.特殊类型
            //bool true false 表示真假的数据类型

            //char 是用来存储单个字符的变量类型
            char a = '1';

            //string 是字符串类型 用来存储多个字符的，没有上限

            //变量的使用和修改 不能不中生有 必须先声明后使用
            #endregion

            #region 为什么有那么多不同的变量类型
            //不同的变量 存储的范围和类型不一样 本质上占用的内存空间不同
            //选择不同的数据类型（变量）装在不同的变量

            //姓名
            //string 多个字符赋予初值用双引号 ，单字符用单引号
            string name = "周健";
            //年龄
            //byte
            byte age = 18;
            //身高
            //float
            float height = 169.45f;
            //体重
            float weight = 74.12f;
            //性别 true女false男
            bool sex = false;
            Console.WriteLine("name:\t"+name+"\nage:\t"+age+"\nheight:\t"+height+"\nweight:\t"+weight+"\nsex(false为男，true为女):\t"+sex);
            //数字用int 小数用float 字符串用string 真假用bool

            #endregion

            #region 多个相同类型变量同时声明
            //多个同类型变量声明
            //固定写法
            //<type> <name> = initialization, <name> = initialization....;
            #endregion

            #region 变量初始化关
            //变量声明时 可以不设置初始值 但是不建立这样写，这样不安全
            //int sbyte....为0，string 和char为null, bool为false;
            #endregion
        }
    }
}
