using System;

namespace Lesson22_面向对象相关_万物之父中的方法
{
    class Test
    {
        public int i = 1;
        public Test2 t22 = new Test2(); 

        public Test Clone()
        {
            return MemberwiseClone() as Test;
        }
    }

    class Test2
    {
        public int i = 2;
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            #region 知识回顾
            //万物之父 object
            //所有类型的基类 是一个引用类型
            //可以利用里氏替换原则装载一切对象
            //存在装箱拆箱
            #endregion

            #region 知识点一 object中的静态方法
            //静态方法 Equals 判断两个对象是否相等
            //最终的判断权，交给左侧对象的Equals方法
            //不管值类型还是引用类型都会按照左侧对象Equals方法的规则来进行比较
            Console.WriteLine(Object.Equals(1, 1));//ture
            Test t1 = new Test();
            Test t2 = new Test();        
            Test t3 =t1;
            Console.WriteLine(Object.Equals(t1, t3));//false
         
            Console.WriteLine(Equals(t1, t2));//true
                                                     //比较引用类型的是 比较 所开辟空间是否一致 不是比较类类型

            //静态方法ReferenceEquals
            //比较两个对象是否是相同的引用，主要是用来比较引用类型的对象
            //值类型对象始终返回是false
            Console.WriteLine(Object.ReferenceEquals(1, 1));//false
            Console.WriteLine(Object.ReferenceEquals(t3, t1));//false

            #endregion

            #region 知识点二 object中的成员方法
            //普通方法GetType
            //该方法在反射相关知识点中是非常重要的方法，之后我们会具体的讲解这里返回的Type类型
            //该方法的主要作用就是获取对象运行时的类型Type
            //通过Type结合反射相关知识可以做很多关于对象的操作
            Test ys = new Test();
            Type type = ys.GetType();

            //普通方法MemberwiseClone
            //该方法用于获取对象的浅拷贝对象，口语化的意思就是会返回一个新的对象
            //但是新对象中的引用变量会和老对象中一致

            Test t33 = ys.Clone();
            Console.WriteLine("克隆对象前");
            Console.WriteLine("ys.i = " + ys.i);
            Console.WriteLine("ys.t22.i = " + ys.t22.i);
            Console.WriteLine("克隆对象后");
            Console.WriteLine("t33.i = " + t33.i);
            Console.WriteLine("t33.t22.i = " + t33.t22.i);

            ys.i = 200;
            ys.t22.i = 999;

            Console.WriteLine("改变克隆对象前");
            Console.WriteLine("ys.i = " + ys.i);
            Console.WriteLine("ys.t22.i = " + ys.t22.i);
            Console.WriteLine("改变克隆对象后");
            Console.WriteLine("t33.i = " + t33.i);
            Console.WriteLine("t33.t22.i = " + t33.t22.i);
            #endregion

            #region 知识点三 object中的虚方法
            //虚方法Equals
            //默认实现还是比较两者是否还是为同一个引用的，即相当于ReferenceEquals
            //但是微软在所有值类型的基类System.Value中重写了该方法，用来比较值相等
            //我们也可以重写该方法，定义自己的 比较相等 的规则

            //虚方法GetHashCode
            //该方法是获取对象的哈希码
            //(一种通过算法算出的，表示对象的唯一编码，不同对象哈希码有可能一样，具体值根据哈希算法决定)
            //我们可以通过重写该方法来定义对象的哈希码算法

            //虚方法ToString
            //该方法用于返回当前对象代表的字符串，我们可以重写它定义我们自己的对象转字符串规则
            //该方法非常常用。当我们调用打印方法时，默认使用的就是对象的ToString方法打印出来的内容
            #endregion
        }
    }
    //总结
    //1.虚方法 toString 自定义字符串转换规则
    //2.成员方法 GetType 反射相关
    //3.成员方法 MemberwiseClone 浅拷贝
    //4.虚方法 Equals 自定义判断相等的规则
}
