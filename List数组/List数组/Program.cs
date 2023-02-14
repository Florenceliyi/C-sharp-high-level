using System;
using System.Collections.Generic;

namespace List数组
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);

            list.Remove(2);
            list.Remove(3);

            if (list.Contains(1))
            {
                Console.WriteLine("存在元素1");
            }

            //遍历
            //长度
            Console.WriteLine(list.Count);
            //容量
            //避免产生垃圾
            Console.WriteLine(list.Capacity);
            Console.WriteLine("**********************");
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(list[i]);
            }
            Console.WriteLine("**********************");
            foreach (int item in list)
            {
                Console.WriteLine(item);
            }

            List<int> list1 = new List<int>();

            list.RemoveAt(4);

            for (int i = 10; i > 0; i--)
            {
                list1.Add(i);
            }
            foreach (int item in list)
            {
                Console.WriteLine(item);
            }
        }
            //一个Monster基类，Boss和Gablin类继承它。
            //在怪物类的构造函数中，将其存储到一个怪物List中
            //遍历列表可以让Boss和Gablin对象产生不同攻击
               abstract class Monster
            {
            public static List<Monster> monsters = new List<Monster>();
            public Monster()
            {
                monsters.Add(this);
            }

            public abstract void Atk();
        }

        class Gablin : Monster
        {
            public Gablin()
            {

            }
        }
            


        }
    }
}