using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson3_封装_成员方法
{

    class Ticket 
    {
        private float price; //价格
        private int distance;
        public int Distance
        {
            get
            {
                return distance;
            }
            set
            {
                if (value < 0)
                {
                    Console.WriteLine("公里数不能少于0，强制设置为 0 了");
                    value = 0;
                }
                distance = value;
            }
        }

        public  Ticket(int distance)
        {
            this.Distance = distance;
        }

        public void GetPrice()
        {
    
            if (distance <= 100)
            {
                price = distance;
            }
            else if (100<distance&&distance<=200)
            {
                price = (float)(distance * 0.95);
            }
            else if (200 < distance && distance <= 300)
            {
                price = (float)(distance * 0.9);
            }
            else
            {
                price = (float)(distance * 0.8);
            }
        }

        public void PriceShow()
        {
            Console.WriteLine("{0}公里{1}块钱",distance,price);
        }
    }
}
