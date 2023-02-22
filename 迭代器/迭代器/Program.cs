
using System.Collections;
using System.Collections.Generic;

namespace 迭代器
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //标准迭代器的实现方法
            //关键接口：IEnumerator,IEnumerable
            //命名空间：using System.Collections;
            //可以通过同时继承IEnumerable和IEnumerator实现其中的方法
            CustomList list = new CustomList();
            foreach(int item in list)
            {
                Console.WriteLine(item);
            }

        }
         class CustomList: IEnumerable, IEnumerator
        {
            private int[] list;
            //从-1开始的光标 用于表示 数据得到了哪个位置
            private int position = -1;
            public CustomList()
            {
                list = new int[] { 1, 2, 3, 4, 5, 6, 7, 8 };
            }
            public IEnumerator GetEnumerator()
            {
                Reset();
                return this;
            }
            public object Current
            {
                get
                {
                    return list[position];
                }
            }
            public bool MoveNext()
            {
                //移动光标
                ++position;
                //是否溢出 溢出就不合法
                return position < list.Length;
            }

            //reset是重置光标位置 一般写在获取 IEnumerator对象这个函数中
            //用于第一次重置光标位置
            public void Reset()
            {
                position = -1;
            }

        }

        #region yield return语法糖实现迭代器
        class CustomList2: IEnumerable
        {
            private int[] list;
            public CustomList2()
            {
                list = new int[] { 2, 3, 1, 6, 4, 6, 7, 7 };
            }

            public IEnumerator GetEnumerator()
            {
                for(int i =0; i<list.Length; i++)
                {                                           
                    yield return list[i];
                }
            }
        }
        #endregion

        #region 知识点四 用yield return 语法糖为泛型类实现迭代器
        class CustomList<T> : IEnumerable
        {
            private T[] array;

            public CustomList(params T[] array)
            {
                this.array = array;
            }

            public IEnumerator GetEnumerator()
            {
                for (int i = 0; i < array.Length; i++)
                {
                    yield return array[i];
                }
            }
        }
        #endregion
    }
}