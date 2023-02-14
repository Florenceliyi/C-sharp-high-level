namespace 链表
{
    internal class Program
    {
        static void Main(string[] args)
        {
            LinkedList<int> list = new LinkedList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            LinkedNode<int> node = list.Head;
            //正向遍历
            while(node != null)
            {
                Console.WriteLine(node.value);
                node = node.nextNode;
            }

            //反向遍历
            node = list.Last;
            while (node != null)
            {
                Console.WriteLine(node.value);
                node = node.frontNode;
            }
        }


        //双向链表的实现方法

        class LinkedNode<T>
        {
            public T value;
            public LinkedNode<T> frontNode;
            public LinkedNode<T> nextNode;

            public LinkedNode(T val)
            {
                this.value = val;
            }
        }

        class LinkedList<T>
        {
            private int count;
            private LinkedNode<T> head;
            private LinkedNode<T> last;

            public int Count
            {
                get
                {
                    return count;
                }
            }

            public LinkedNode<T> Head
            {
                get
                {
                    return head;
                }
            }
            public LinkedNode<T> Last
            {
                get
                {
                    return last;
                }
            }

            public void Add(T value)
            {
                LinkedNode<T> node = new LinkedNode<T>(value);
                //新增的第一个节点，若原本没有任何节点
                if (head == null)
                {
                    head = node;
                    last = node;
                }
                else
                {
                    last.nextNode = node;
                    node.frontNode = last;
                    //让但钱新加的节点变成最后一个节点
                    last = node;
                }
                //新增一个节点
                ++count;
            }

            public void RemoveAt(int index) {
                //首先判断有没有越界
                if (index >= count || index < 0)
                {
                    Console.WriteLine("只有{0}个节点，请输入合法位置", count);
                    return;
                }
                int tempCount = 0;
                LinkedNode<T> tempNode = head;
                while (true)
                {
                    
                    if(tempCount == index)
                    {
                        //当前要移除的节点的上一个节点 指向自己的下一个节点
                        if (tempNode.frontNode != null)
                        {
                            tempNode.frontNode.nextNode = tempNode.nextNode;

                        }
                        if(tempNode.nextNode!= null)
                        {
                            tempNode.nextNode.frontNode = tempNode.frontNode;
                        }
                        //如果是头节点 需要改变头节点的指向
                        if(index == 0)
                        {
                            head = tempNode.nextNode;
                            //尾节点被移除的情况
                        }else if(index == count - 1)
                        {
                            last = last.frontNode;
                        }
                        --count;
                        break;
                    }
                    //每次循环完过后 要让当前临时节点 等于下一个节点
                    tempNode = tempNode.nextNode;
                    ++tempCount;
                }
            }
        }
    }
}