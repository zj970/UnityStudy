using System;
using System.Reflection;

namespace Lesson20_反射
{
    #region 知识点回顾
    //编译器是一种编译程序
    //它用于将源语言程序翻译为目标语言程序

    //源语言程序：某种程序设计语言写成的，比如C#、C、C++、Java等语言写的程序
    //目标语言程序:二进制数表示的伪机器代码写的程序
    #endregion

    #region 知识点一 什么是程序集
    //程序集是经由编译器编译得到的，供进一步编译执行的那个中间产物
    //在window系统中，它一般表示为 后缀为.dll(库文件) 或者是.exe(可执行文件)的格式

    //程序集就是我们写的一个代码集合，我们现在写的所有代码
    //最终会被编译器编译为一个程序集供 别人使用
    //比如一个代码库文件(dll)或者一个可执行文件(exe)
    #endregion

    #region 知识点二 元数据
    //元数据就是用来描述数据的数据
    //这个概念不仅仅用于程序上，在别的领域也有元数据
    //程序中的类，类中的函数，变量等等信息就是 程序的 元数据
    //有关程序以及类型的数据 被称为 元数据， 它们保存在数据集中
    #endregion

    #region 知识点三 反射的概念
    //程序正在运行时，可以查看其他程序集或者自身的元数据。
    //一个运行的程序集查看本身或者其他程序的元数据的行为 就叫 反射

    //在程序运行时，通过反射可以得到其他程序集或者自己程序集代码的各种信息
    //类、函数、变量、对象等等，实例化它们、执行它们、操作它们
    #endregion

    #region 知识点四 反射的作用
    //因为反射可以在程序编译后获得信息，所以它提高了程序的拓展性和灵活性‘
    //1.程序在运行时 可以获得所有元数据，包括元数据的特性
    //2.程序运行时，实例化对象、操作对象
    //3.程序运行时创建新的对象，用这些对象执行任务
    #endregion

    class Test
    {
        private int i = 2;
        public int j = 4;
        public string str = "dfin";

        public Test()
        {

        }
        public Test(int i)
        {
            this.i = i;
        }
        public Test(int i,string str) : this(i)
        {
            this.str = str;
        }

        public void Speak()
        {
            Console.WriteLine("Test");
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            #region 知识点五 语法相关
            #region Type
            //Type（类的信息类)
            //它是反射功能的基础
            //它是访问从元数据的基本方式
            //使用 Type 的成员获取有关类型 声明的信息
            //有关类型的成员（如构造函数、方法、字段、属性和类的事件）

            #region 获取Type
            //1.万物之父object中的 GetType()可以获取对象的Type
            int a = 2;
            Type type = a.GetType();
            Console.WriteLine(type);
            //2.通过Typeof关键字 传入类名 也可以得到对象的Type
            Type type1 = typeof(int);
            Console.WriteLine(type1);
            //3.通过类的名字 也可以获取类型
            //  注意 类名必须包含命名空间 不然找不到
            Type type2 = Type.GetType("System.Int32");
            Console.WriteLine(type2);
            //type type1 type2 所指向的堆内存地址是一样的 
            //每一个类型的Type都是唯一的，因为元数据只有一份
            #endregion

            #region 得到类的程序集信息
            //可以通过Type可以得到类型所在程序集信息
            Console.WriteLine(type.Assembly);
            Console.WriteLine(type1.Assembly);
            Console.WriteLine(type2.Assembly);
            #endregion
            Console.WriteLine("*********************************************");
            #region 得到类的所有公共成员
            //首先得到Type
            Type type3 = typeof(Test);
            //然后得到所有公共成员
            //需要引用命名空间 using System.Reflection
            MemberInfo[] memberInfos = type3.GetMembers();
            for (int i = 0; i <memberInfos.Length; i++)
            {
                Console.WriteLine(memberInfos[i]);
            }
            #endregion
            Console.WriteLine("*********************************************");

            #region 得到类的公共构造函数并调用
            //1.获取所有构造函数
            ConstructorInfo[] ctors = type3.GetConstructors();
            for (int i = 0; i < ctors.Length; i++)
            {
                Console.WriteLine(ctors[i]);
            }
            Console.WriteLine("*********************************************");
            //2.获取其中一个构造函数 并执行
            //得到构造函数传入 Type数组 数组中内容按顺序是参数类型
            //执行构造函数并传入 object数组 表示按顺序传入的参数
            //2.1 - 得到无参构造
            ConstructorInfo info = type3.GetConstructor(new Type[0]);
            //执行无参构造 无参构造 没有参数 传null
            Test obj = info.Invoke(null) as Test;
            Console.WriteLine(obj.j);
            //2.2 - 得到有参构造
            ConstructorInfo info1 = type3.GetConstructor(new Type[] { typeof(int) });
            obj = info1.Invoke(new object[] { 2 }) as Test;
            Console.WriteLine(obj.str);

            ConstructorInfo constructorInfo = type3.GetConstructor(new Type[] { typeof(int), typeof(string) });
            obj = constructorInfo.Invoke(new object[] { 2, "13546" }) as Test;
            Console.WriteLine(obj.str);
            #endregion
            Console.WriteLine("*********************************************");

            #region 得到类的公共成员变量
            //1.得到所有成员变量
            FieldInfo[] fieldInfos = type3.GetFields();
            for (int i = 0; i < fieldInfos.Length; i++)
            {
                Console.WriteLine(fieldInfos[i]);
            }
            //2.得到指定名称的公共成员变量
            Console.WriteLine("*********************************************");
            FieldInfo infoJ = type3.GetField("j");
            Console.WriteLine(infoJ);
            Console.WriteLine("*********************************************");
            //3.通过反射获取和设置对象的值
            Test test = new Test();
            test.j = 333;
            test.str = "ghjgfvbj";
            //3.1 -- 通过反射 获取对象的某个变量的值
            Console.WriteLine(infoJ.GetValue(test));
            //3.2 -- 通过反射 获取指定对象的某个变量的值
            infoJ.SetValue(test, 156789);
            FieldInfo info2 = type3.GetField("str");
            info2.SetValue(test, "78956654");
            Console.WriteLine(infoJ.GetValue(test));
            Console.WriteLine(info2.GetValue(test));
            #endregion
            Console.WriteLine("*********************************************");
            #region 获取类的公共成员方法
            //通过Type类中的 GetMethod 方法得到类中的方法
            //MethodInfo 是方法的反射信息
            Type strType = typeof(string);
            //1.如果存在方法重载 用Type数组表示参数类型
            MethodInfo[] methodInfos = strType.GetMethods();
            for (int i = 0; i < methodInfos.Length; i++)
            {
                Console.WriteLine(methodInfos[i]);
            }
            MethodInfo subStr = strType.GetMethod("Substring",new Type[] { typeof(int),typeof(int)});
            Console.WriteLine(subStr);
            //2.调用该方法
            //注意:如果是静态方法 Invoke 中的第一个参数传null即可
            string str = "Hello";
            //第一个参数相当于 是那个对象 要执行这个成员方法
            Console.WriteLine( subStr.Invoke(str, new object[] { 1, 3 }));
            #endregion

            #region 其他
            //Type;
            //得枚举
            //GetEnumName
            //GetEnumNames

            //得事件
            //GetEvent
            //GetEvents

            //得接口
            //GetInterface
            //GetInterfaces

            //得属性
            //GetProperty
            //GetPropertys
            //等等
            #endregion
            #endregion
            Console.WriteLine("*********************************************");
            #region  Assembly
            //程序集类
            //主要用来加载其他程序集，加载后
            //才能用Type来使用其他程序集中的信息
            //如果想要使用不是自己程序集中的内容 需要先加载程序集
            //比如 dll文件（库文件）
            //简单的把库文件看成一种代码仓库，它提供给使用者一些可以直接拿来用的变量、函数或类

            //三种加载程序集的函数
            //一般用来加载在同一文件下的其他程序集
            //Assembly asembly2 = Asembly.Load("程序集名称");

            //一般用来加载不在同一文件下的其他程序集
            //Assembly asembly3 = Asembly.LoadForm("包含程序集清单的文件的名称或路径");
            //Assembly asembly4 = Asembly.LoadFile("要加载的文件的完全限定路径");

            //1.先加载一个指定程序集
            Assembly assembly = Assembly.LoadFrom(@"E:\UnityDate\C#Study\C#\Csharp进阶\Lesson10_LinkedList\bin\Debug\netcoreapp3.1");
            Type[] types = assembly.GetTypes();
            for (int i = 0; i < types.Length; i++)
            {
                Console.WriteLine(types[i]);
            }
            //2再加载程序集中的一个类对象 之后才能使用反射
            Type icon = assembly.GetType("Lesson10_LinkedList.Program");
            MemberInfo[] memberInfos1 = icon.GetMembers();
            for (int i = 0; i < memberInfos1.Length; i++)
            {
                Console.WriteLine(memberInfos1[i]);
            }
            //通过反射 实例化一个 icon 对象
            //首先得到成员变量 来得到可以传入的参数
            //直接实例化对象
            //得到对象中的方法 通过反射
            #endregion

            Console.WriteLine("*********************************************");
            #region  Activator
            //用于快速实例化对象的类
            //用于将Type对象快捷实例化为对象
            //先得到Type
            //然后 快速实例化一个对象
            Type testType = typeof(Test);
            //1.无参构造
            Test testObj = Activator.CreateInstance(testType) as Test;
            Console.WriteLine(testObj.str);
            //2.有参构造
            testObj = Activator.CreateInstance(testType, 999) as Test;
            Console.WriteLine(testObj.j);
            testObj = Activator.CreateInstance(testType, 999,"45678789") as Test;
            Console.WriteLine(testObj.j);
            Console.WriteLine(testObj.str);
            #endregion
            #endregion
        }
    }

    //总结
    //反射
    //在程序运行时，通过反射可以得到其他程序集或者自己 的程序集代码的各种信息
    //类、函数、变量、对象等等，实例化它们，执行它们、操作它们

    //关键类
    //Type
    //Assembly
    //Activator

    //重要！！！！！！！！！！！！！！！！！！
}
