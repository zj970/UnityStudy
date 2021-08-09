using System;
using System.Collections.Generic;

namespace lesson23_特殊语法
{
    class Person
    {
        private int money;
        public bool sex;

        public string Name
        {
            get=>"吱吱吱吱";
            set=>sex = true;
        }
        public int Age
        {
            get;
            set;
        }

        public int Add(int x, int y) => x + y;
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("lesson23_特殊语法");

            #region 知识点一 var隐式类型
            //var是一种特殊的变量类型
            //它可以用来表示任意类型的变量
            //注意:
            //1.var不能作为类的成员 只能用于临时变量声明 也就是 一般写在函数语句块中
            //2.var必须初始化

            var i = 5;
            var s = "123";
            var array = new int[] { 1,2,3,4,5};
            var list = new List<int>();
            #endregion

            #region 知识点二 设置对象初始值
            //声明对象时
            //可以通过直接写大括号的形式初始化公共成员变量和属性

            Person person = new Person { sex = true, Age = 18, Name = "jk" };
            var person1 = new Person { sex = true, Age = 18, Name = "jk" };
            #endregion

            #region 知识点三 设置集合初始值
            //声明集合对象时
            //也可以通过大括号 直接初始化内部属性
            int[] array2 = new int[] { 1, 3, 54, 6, 7 };

            List<int> listInt = new List<int>() { 1, 2, 5, 6, 7 };
            List<Person> listPerson = new List<Person>()
            {
                new Person(),
                new Person(){Age = 12}

            };
            Dictionary<int, string> listDictionary = new Dictionary<int, string>()
            {
                {1,"123" },
                {2,"fd" }
            };
            #endregion

            #region 知识点四 匿名类型
            //var 变量可以声明为自定义的匿名类型
            var v = new { age = 10, money = 11, name = "小明" };
            Console.WriteLine(v.age);
            Console.WriteLine(v.name);
            #endregion

            #region 知识点五 可空类型
            //1.值类型是不能赋值为 空的

            //2.声明时 在值类型后面加? 可以赋值为空
            int? c = null;//C已经为结构体
            c = 6;
            //3.判断是否为空
            if (c.HasValue)
            {
                Console.WriteLine(c);
                Console.WriteLine(c.Value);
            }
            //4.安全获取可空类型值
            int? value = null;
            //4.1 如果为空 默认返回值类型的默认值
            Console.WriteLine(value.GetValueOrDefault());
            //4.2也可以指定一个默认值
            Console.WriteLine(value.GetValueOrDefault(100));
            //Console.WriteLine(value);

            object o = null;
            //相当于一种语法糖 能够帮助我们自动去判断o是否为空
            //如果是null 就不会执行tostring也不会报错
            o?.ToString();
            Action action = null;
            action?.Invoke();
            #endregion

            #region 知识点六 空合并操作符
            //空合并操作符 ??
            //左边值 ?? 右边值
            //如果左边值为 null 就返回右边值 否则返回左边值
            //只要是可以为null的类型都能用
            int? intV = null;
            int intI = intV == null ? 100 : intV.Value;
            int intInt = intV ?? 100;
            Console.WriteLine(intI);
            Console.WriteLine(intInt);
            #endregion

            #region 知识点七 内插字符串
            //关键符号: $
            //用$来构造字符串，让字符串可以拼接变量
            string name = "周健";
            Console.WriteLine($"好好学习，{name}");
            #endregion

            #region 知识点八 单句逻辑简略写法
             //函数只有一句可以直接     =>  就行
            #endregion
        }
    }
}
