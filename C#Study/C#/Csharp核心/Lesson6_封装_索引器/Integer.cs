using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson6_封装_索引器
{
    class Integer
    {
        public int target;

        private Integer[] integers;

        public Integer this[int index]
        {
            get
            {
                if (integers == null || integers.Length < index)
                {
                    //索引超出范围或者为空
                    return null;
                }
                return integers[index];
            }
            set
            {
                if (integers == null)
                {
                    integers = new Integer[] { value };
                }
                else if (index > integers.Length -1)
                {
                    //如果索引越界，就默认把最后一个数顶掉
                    integers[integers.Length - 1] = null;
                }
                else
                {
                    integers[index] = value;
                }
            }
        }

        
        /// <summary>
        /// 增加
        /// </summary>
        /// <param name="integer"></param>
        public void Add(Integer integer)
        {
            if (integers == null)
            {
                integers = new Integer[] { integer };//如果数组里面为空
            }
            else
            {
                Integer[] newInteger = new Integer[integers.Length + 1];//扩容
                //迁移
                for (int i = 0; i < integers.Length; i++)
                {
                    newInteger[i] = integers[i];
                }
                //增加
                newInteger[newInteger.Length - 1] = integer;
                //地址重定向
                integers = newInteger;
            }
        }

        /// <summary>
        /// 移除
        /// </summary>
        public void Remove()
        {
            if (integers != null)
            {
                integers[integers.Length - 1] = null;
            }
        }

        /// <summary>
        /// 指定移除
        /// </summary>
        /// <param name="index">下标</param>
        public void Remove(int index)
        {
            if (integers != null && index<=integers.Length-1)
            {
                for (int i = index; i < integers.Length; i++)
                {
                    integers[i] = integers[i++];
                }
                integers[integers.Length - 1] = null;
            }       
        }
        
    }
}
