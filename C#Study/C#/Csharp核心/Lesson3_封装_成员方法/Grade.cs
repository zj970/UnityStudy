using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson3_封装_成员方法
{

    class Grade
    {
        public int gradeNumber;//班级代码
        public string grade;//年级
        public string specialty;//专业

        public Grade[] grades;



        /// <summary>
        /// 添加班级
        /// </summary>
        /// <param name="p"></param>
        public void AddGrade(Grade grade)
        {
            if (grades == null)
            {
                grades = new Grade[] { grade };
            }
            else
            {
                //扩容
                Grade[] newGrades = new Grade[grades.Length + 1];
                //迁移
                for (int i = 0; i < grades.Length; i++)
                {
                    newGrades[i] = grades[i];
                }
                //增加
                newGrades[newGrades.Length - 1] = grade;
                //地址重定向
                grades = newGrades;
            }
        }

        public void GradeShow()
        {
            for (int i = 0; i < grades.Length; i++)
            {
                Console.WriteLine("我来自{0}-----{1}{2}",grades[i].gradeNumber, grades[i].grade, grades[i].specialty);
            }
        }
    }
}
