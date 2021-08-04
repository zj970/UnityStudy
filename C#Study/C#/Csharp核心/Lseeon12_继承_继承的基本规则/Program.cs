using System;

namespace Lseeon12_继承_继承的基本规则
{
    #region 知识点一 基本概念
    //一个类A继承一个类B
    //类A将会继承类B的所有成员
    //A类将会拥有B类的所有特征和行为
    
    //被继承的类
    //称为 父类、基类、超类

    //继承的类
    //称为子类、派生类

    //子类可以有自己的特征和行为

    //特点
    //1.单根性 子类只能有一个父类
    //2.传递性 子类可以间接继承父类的父类
    #endregion

    #region 知识点二 基本语法
    //class 类名 ：被继承的类名
    //{
    //
    //}
    #endregion

    #region 知识点三 实例

    class Teacher
    {
        public string name;//名字
        protected int number;//职工号
        public void SpeakName()
        {
            Console.WriteLine(name);
        }
    }

    class TeachingTeacher : Teacher
    {

        //科目       
        public string subject;
        //介绍科目
        public void SpeakSubjec()
        {
            name = "zzzz";
            number = 11;
            Console.WriteLine(subject + "老师");
        }
    }

    class ChineseTeacher : TeachingTeacher
    {
        public void skill()
        {
            Console.WriteLine("一行白鹭上青天");
        }
    }
    #endregion

    #region 知识点四 访问修饰符的影响
    //public -公共 内外部访问
    //private -私有的 内部访问
    //protected -受保护的 内部和子类访问

    //之后讲命名空间的时候
    //internal - 内部的 只有在同一个程序集的文件中，内部类型或者是成员才可以访问
    #endregion

    #region 知识点五 子类和父类同名成员
    //概念
    //C#中允许子类存在和父类同名的成员
    //但是 极不建议使用
    #endregion

    class Program
    {
        static void Main(string[] args)
        {
            TeachingTeacher tt = new TeachingTeacher();
            tt.name = "周健";
            //tt.number = 123456;
            tt.SpeakName();
            

            tt.subject = "数学";
            tt.SpeakSubjec();

            ChineseTeacher ct = new ChineseTeacher();
            ct.name = "zj";
            //ct.number = 123456;
            ct.SpeakName();
            ct.subject = "语文";
            ct.SpeakSubjec();
            ct.skill();
        }
        //总结
        //继承基本语法
        //class 类名 ； 父类
        //1.单根性;只能继承一个父类
        //2.传递性:子类可以继承父类的父类的所有内容
        //3.访问修饰符 对于成员的影响

        //4.极其不建议使用 在子类中声明和父类同名的成员
    }
}
