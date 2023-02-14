using System.Collections.Generic;

namespace 泛型双向链表
{
    internal class Program
    {
        static void Main(string[] args)
        {
            LinkedList<int> list1 = new LinkedList<int>();
            LinkedList<string> list2 = new LinkedList<string>();

            //1.在链表尾部添加元素
            list1.AddLast(2);
            list1.AddLast(11);
            list1.AddLast(12);
            list1.AddLast(13);

            //2.在链表头部添加元素
            list1.AddFirst(20);

            //3.在某一个节点之后添加一个节点
            //指定一个节点
            LinkedListNode<int> node = list1.Find(11);
            list1.AddAfter(node, 45);

            //4.在某一个节点之前添加一个节点
            list1.AddBefore(node, 88);

            //删除头节点
            list1.RemoveFirst();
            //删除尾节点
            list1.RemoveLast();
            //移除指定节点
            list1.Remove(10);

            //头节点
            LinkedListNode<int> first = list1.First;
            //尾节点
            LinkedListNode<int> last = list1.Last;

            LinkedListNode<int> node2 = list1.Find(45);
            Console.WriteLine("node2", node2.Value);
            Console.WriteLine(node.Value);
            node = list1.Find(12);

            if (list1.Contains(12))
            {
                Console.WriteLine("链表中存在1");
            }

            //遍历
            foreach(int item in list1)
            {
                Console.WriteLine(item);
            }

            //查
            Console.WriteLine("first", first);
            Console.WriteLine("last", last);

            //从头遍历
            Console.WriteLine("&&&&&&&&&&&&&&&&&&&&&&&&&&&");
            LinkedListNode<int> currentNode = list1.First;
            while(currentNode != null)
            {
                Console.WriteLine(currentNode.Value);
                currentNode = currentNode.Next;
            }
            //从尾遍历
            Console.WriteLine("&&&&&&&&&&&&&&&&&&&&&&&&&&&");
            currentNode = list1.Last;
            while (currentNode != null)
            {
                Console.WriteLine(currentNode.Value);
                currentNode = currentNode.Previous;
            }

            #region 习题
            //使用Linkedlist，向其中加入10个随机整形变量
            //正向遍历一次打印出信息
            //反向遍历一次打印出信息

            LinkedList<int> list3 = new LinkedList<int>();
            Random val = new Random();
            for(int i = 0; i<10; i++)
            {
                list3.AddLast(val.Next(1, 101));
            }

            //正向遍历
            LinkedListNode<int> nowNode = list3.First;
            while(nowNode != null) { 
                Console.WriteLine(nowNode.Value);
                nowNode = nowNode.Next;
            }
            Console.WriteLine("&&&&&&&&&&&&&&&&&&&&&&&&&&&");
            //反向遍历
            nowNode = list3.Last;
            while (nowNode != null)
            {
                Console.WriteLine(nowNode.Value);
                nowNode = nowNode.Previous;
            }
            #endregion

        }
    }
}