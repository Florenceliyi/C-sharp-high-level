using System;
using System.Net;

namespace 事件;
internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        Test t = new Test();

        t.bibao();

        //委托可以在外部调用
        t.myFun();
        t.myFun = Test123;
        t.myFun();
        //事件不可在外部调用
        t.DoEvent();

        Action a = Test123;

        //无参匿名函数
        Action b = delegate ()
        {
            Console.WriteLine("匿名函数逻辑");
        };

        b();

        //带参匿名函数
        Action<string, string> c = delegate (string a, string b)
        {
            Console.WriteLine(a+b);
        };

        c("Florence", "Xiao");

        t.GetFun()();

        //lambad表达式
        //1.无参无返回
        Action a1 = () =>
        {
            Console.WriteLine("无参无返回值的lambad表达式");
        };
        a1();
        //2.有参
        Action<int> a2 = (int value) =>
        {
            Console.WriteLine("有参数lambad表达式{0}", value);
        };
        a2(20);
        //3.参数类型可以省略，参数类型和委托或事件容器一致
        Action<int> a3 = (value) =>
        {
            Console.WriteLine("省略参数类型的写法{0}", value);
        };
        a3(520);
        //4.有返回值
        Func<string, int> a4 = (value) =>
        {
            Console.WriteLine("返回值的表达式");
            return 3231;
        };

    }
    static void Test123()
    {
        Console.Write("测试哈哈哈哈哈哈");
    }
    class Test
    {
        public Action myFun;

        public event Action myEvent;


        public Test()
        {
            //委托与事件的相同之处
            myFun = TestFun;
            myFun += TestFun;
            myFun();

            myEvent = TestEventFun;
            myEvent += TestEventFun;
            myEvent();

            
        }

        public void DoEvent()
        {
            if(myEvent != null)
            {
                myEvent();
            }
        }
        public void TestFun()
        {
            Console.WriteLine("Florence测试委托");
        }

        public void TestEventFun()
        {
            Console.WriteLine("Florence测试事件");
        }

        //作为返回值
        public Action GetFun()
        {
            return delegate () {
                Console.WriteLine("函数内部返回的一个匿名函数逻辑");
            };
        }

        public void bibao()
        {
            int value = 20;
            myFun = () =>
            {
                Console.WriteLine(value);
            };

            for(int i = 0; i< 10; i++)
            {
                int index = i;
                myFun += () =>
                {
                    Console.WriteLine(index);
                };
            }
        }


    }
    

}
