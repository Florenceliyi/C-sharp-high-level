namespace Csharp进阶
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TestClass<int> a = new TestClass<int>();
            a.value = 212312;
            Console.WriteLine(a.value);

            TestClass<string> b = new TestClass<string>();
            b.value = "florence";
            Console.WriteLine(b.value);

            Console.WriteLine(Fun<int>());
            Console.WriteLine(Fun<string>());
            Console.WriteLine(Fun<char>());
            Console.WriteLine(Fun<float>());
            Console.WriteLine(Fun<double>());
            Console.WriteLine(Fun<uint>());

            Test5<IMove> t5 = new Test5<IMove>();
            Console.WriteLine(t5.value);

            Console.WriteLine("单例模式"+ Test.Instance.value);
            Console.WriteLine("单例模式" + Test2.Instance.value);
            Console.WriteLine("单例模式" + GameMgr.Instance.value);



        }
        //泛型
        class TestClass<T>
        {
            public T value;
            public void Test<M>(M t)
            {
                Console.WriteLine(t);
            }
            public void TestFun(T t)
            {
                Console.WriteLine(t);
            }
        }

        //泛型用法
        static string Fun<T>()
        {
            if (typeof(T) == typeof(int))
            {
                return string.Format("{0},{1}字节", "整形", sizeof(int));
            }
            else if (typeof(T) == typeof(char))
            {
                return string.Format("{0},{1}字节", "字符", sizeof(char));
            }
            else if (typeof(T) == typeof(float))
            {
                return string.Format("{0},{1}字节", "单精度浮点数", sizeof(float));
            }
            else if (typeof(T) == typeof(string))
            {
                return string.Format("{0},{1}字节", "字符串", "?");
            }
            return "其它类型";
        }

        //泛型约束
        //值类型约束
        class Test1<T> where T : struct
        {
            public T v;
            public void Test<K>(T t) where K : struct 
            {
                Console.WriteLine(t);
            }
        }

        //引用类型约束
        class Test2<T> where T : class
        {
            public T v;
            public void Test<M>(T t) where M : class{
                Console.WriteLine(t);
            }
        }

        //公共无参构造约束
        class Test3<K> where K : new()
        {
            public K value;
            public void Test<R>(R r) where R : new()
            {
                Console.WriteLine(r);
            }
        }

        //类约束
        class Test4<T> where T : Test1<int>
        {
            public T v;
            public void Test<M>(M m) where M : Test1<int>{

            }
        }

        //接口约束
        interface IFly
        {

        }

        interface IMove : IFly
        {

        }

        class Test4 : IFly
        {

        }

        class Test5<T> where T : IFly
        {
            public T value;

            public void TestFun<K>(K k) where K : IFly
            {
                Console.WriteLine(k);
            }
        }

        //另一个泛型约束
        class Test6<T, U> where T: U
        {
            public T value;

            public void Test<K, U>(K k) where K: U
            {
                Console.WriteLine(k);
            }
        }

        //约束的组合使用
        class Test7<T> where T: class, new()
        {

        }

        //多个泛型约束
        class Test8<T, K>where T: class, new() where K : struct
        {
            public T value;
        }

        //用泛型实现一个单例模式基类
        class SingBase<T> where T : new()
        {
            private static T instance = new T();

            public static T Instance
            {
                get { return instance; }
            }
        }

        class GameMgr: SingBase<GameMgr>
        {
            public int value = 10;
        }

        class Test : SingBase<Test>
        {
            public int value = 20;
        }

        class Test2
        {
            private static Test2 instance = new Test2();
            public int value = 130;
            private Test2()
            {

            }
            public static Test2 Instance
            {
                get
                {
                    return instance;
                }
            }
        }


    }
}