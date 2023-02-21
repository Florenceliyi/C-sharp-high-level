using System;

namespace Lesson12_委托
{
    delegate void MyFun();

    public delegate int MyFun2(int a);
    class Test
    {
        public MyFun fun;
        public MyFun2 fun2;

        public Action action;

        public void TestFun(MyFun fun, MyFun2 fun2)
        {
            //先处理一些别的逻辑 当这些逻辑处理完了 再执行传入的函数
            int i = 1;
            i *= 2;
            i += 2;

            //fun();
            //fun2(i);
            //this.fun = fun;
            //this.fun2 = fun2;
        }


        #region 增
        public void AddFun(MyFun fun, MyFun2 fun2)
        {
            this.fun += fun;
            this.fun2 += fun2;
        }
        #endregion

        #region 删
        public void RemoveFun(MyFun fun, MyFun2 fun2)
        {
            //this.fun = this.fun - fun;
            this.fun -= fun;
            this.fun2 -= fun2;
        }
        #endregion
    }
  

    #region 知识点五 委托变量可以存储多个函数(多播委托)


    #endregion



    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("委托");
            //专门用来装载 函数的 容器
            MyFun f = new MyFun(Fun);

            MyFun f2 = Fun3;

            MyFun ff = null;

            //委托存储多个函数
            ff += f;
            ff += f2;
            ff();
           
        }

        static void Fun()
        {
            Console.WriteLine("张三做什么");
        }
        static void Fun3()
        {
            Console.WriteLine("李四做什么");
        }

        static string Fun4()
        {
            return "";
        }

        static int Fun5()
        {
            return 1;
        }

        static void Fun6(int i, string s)
        {

        }

        static int Fun2(int value)
        {
            return value;
        }
    }

    //总结
    //简单理解 委托 就是装载、传递函数的容器而已
    //可以用委托变量 来存储函数或者传递函数的
    //系统其实已经提供了很多委托给我们用 
    //Action:没有返回值，参数提供了 0~16个委托给我们用
    //Func:有返回值，参数提供了 0~16个委托给我们用
}
