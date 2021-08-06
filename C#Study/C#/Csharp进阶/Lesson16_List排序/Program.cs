using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Lesson16_List排序
{
    class ShopItem
    {
        public int id;

        public ShopItem(int id)
        {
            this.id = id;
        }
    }

    //玩家背包物品排序
    class Item:IComparable<Item>
    {
        public int money;

        public Item(int money)
        {
            this.money = money;
        }

        public int CompareTo([AllowNull] Item other)
        {
            //返回值的含义
            //小于0；
            //放在传入对象的前面
            //等于0
            //保持位置不变
            //大于0
            //放在对象的后面

            //可以简单理解 传入对象的位置 就是0
            //如果你的返回为负数 就放在它的左边 也就是前面
            //如果你的返回为正数 就放在它的右边 也就是后面

            if (this.money > other.money)//实现了接口的升序
            {
                return 1;
            }
            else
            {
                return -1;
            }

            //return 0;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Lesson16_List排序");

            #region 知识点一 List自带排序方法
            List<int> list = new List<int>();
            list.Add(1);
            list.Add(3);
            list.Add(4);
            list.Add(6);
            list.Add(9);
            list.Add(2);
            for (int i = 0; i < list.Count; i++)
            {
                Console.Write(list[i]+"\t");
            }
            list.Sort();//升序排序
            Console.WriteLine("\n**************************");
            for (int i = 0; i < list.Count; i++)
            {
                Console.Write(list[i] + "\t");
            }
            //ArrayList也有list排序方法
            #endregion

            #region 知识点二 自定义类的排序
            //排序的接口 IComparable
            List<Item> itemList = new List<Item>();
            itemList.Add(new Item(45));
            itemList.Add(new Item(4));
            itemList.Add(new Item(898));
            itemList.Add(new Item(13));
            itemList.Add(new Item(789));
            itemList.Add(new Item(12));
            Console.WriteLine("\n**************************");
            //调用排序
            itemList.Sort();//as IComparable
            for (int i = 0; i < itemList.Count; i++)
            {
                Console.Write(itemList[i].money + "\t");
            }
            #endregion

            #region 知识点三 通过委托函数进行排序
            List<ShopItem> shopItems = new List<ShopItem>();
            shopItems.Add(new ShopItem(4));
            shopItems.Add(new ShopItem(1));
            shopItems.Add(new ShopItem(5));
            shopItems.Add(new ShopItem(2));
            shopItems.Add(new ShopItem(9));
            shopItems.Add(new ShopItem(0));

            //shopItems.Sort(SortShopItem);

            //shopItems.Sort(delegate (ShopItem a, ShopItem b) {
            //    if (a.id > b.id)
            //    {
            //        return 1;
            //    }
            //    else
            //    {
            //        return -1;
            //    }
            //});

            shopItems.Sort(( a, b) =>{ return a.id > b.id ? -1 : 1; });//lambad表达式
            Console.WriteLine("\n**************************");
            //调用排序
            for (int i = 0; i < shopItems.Count; i++)
            {
                Console.Write(shopItems[i].id + "\t");
            }
            #endregion
        }

        static int SortShopItem(ShopItem a,ShopItem b)
        {
            //传入的两个对象 为列表中的两个对象
            //进行两两比较 用左边的和右边的条件 比较
            //返回规则和上一样

            if (a.id >b.id)
            {
                return 1;
            }
            else
            {
                return -1;
            }
        }
    }
    //总结
    //系统自带的变量(int,float,....) 一般都可以直接Sort()
    //自定义类 Sort 有两种方式
    //1.继承接口 IComparable
    //2.在Sort中传入委托函数
}
