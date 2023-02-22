using static System.Net.Mime.MediaTypeNames;
using System.Reflection;

namespace 反射
{
    internal class Program

    {
        class Test
        {
            private int i = 1;
            public int j = 0;
            public string str = "123";
            public Test()
            {

            }

            public Test(int i)
            {
                this.i = i;
            }

            public Test(int i, string str) : this(i)
            {
                this.str = str;

            }

            public void Speak()
            {
                Console.WriteLine(i);
            }
        }
        static void Main(string[] args)
        {
            //Type反射功能的基础
            #region 获取Type
            //1.万物之父object中的 GetType()可以获取对象的Type
            string a = "Florence";
            Type type = a.GetType();
            Console.WriteLine(type);
            //2.通过typeof关键字 传入类名 也可以得到对象的Type
            Type type2 = typeof(string);
            Console.WriteLine(type2);
            //3.通过类的名字 也可以获取类型
            //  注意 类名必须包含命名空间 不然找不到
            Type type3 = Type.GetType("System.Int32");
            Console.WriteLine(type3);
            #endregion

            #region 得到类的程序集信息
            //可以通过Type可以得到类型所在程序集信息
            Console.WriteLine(type.Assembly);
            Console.WriteLine(type2.Assembly);
            Console.WriteLine(type3.Assembly);
            #endregion

            #region 获取类中的所有公共成员
            //首先得到Type
            Type t = typeof(Test);
            //然后得到所有公共成员
            //需要引用命名空间 using System.Reflection;
            MemberInfo[] infos = t.GetMembers();
            for (int i = 0; i < infos.Length; i++)
            {
                Console.WriteLine(infos[i]);
            }
            #endregion

            #region 获取类的公共构造函数并调用
            //1.获取所有构造函数
            ConstructorInfo[] ctors = t.GetConstructors();
            for (int i = 0; i < ctors.Length; i++)
            {
                Console.WriteLine(ctors[i]);
            }

            //2.获取其中一个构造函数 并执行
            //得构造函数传入 Type数组 数组中内容按顺序是参数类型
            //执行构造函数传入  object数组 表示按顺序传入的参数
            //  2-1得到无参构造
            ConstructorInfo info = t.GetConstructor(new Type[0]);
            //执行无参构造 无参构造 没有参数 传null
            Test obj = info.Invoke(null) as Test;
            Console.WriteLine(obj.j);

            //  2-2得到有参构造
            ConstructorInfo info2 = t.GetConstructor(new Type[] { typeof(int) });
            obj = info2.Invoke(new object[] { 2 }) as Test;
            Console.WriteLine(obj.str);

            ConstructorInfo info3 = t.GetConstructor(new Type[] { typeof(int), typeof(string) });
            obj = info3.Invoke(new object[] { 4, "444444" }) as Test;
            Console.WriteLine(obj.str);
            #endregion

            #region 获取类的公共成员变量
            //1.得到所有成员变量
            FieldInfo[] fieldInfos = t.GetFields();
            for (int i = 0; i < fieldInfos.Length; i++)
            {
                Console.WriteLine(fieldInfos[i]);
            }
            //2.得到指定名称的公共成员变量
            FieldInfo infoJ = t.GetField("j");
            Console.WriteLine(infoJ);

            //3.通过反射获取和设置对象的值
            Test test = new Test();
            test.j = 99;
            test.str = "2222";
            //  3-1通过反射 获取对象的某个变量的值
            Console.WriteLine(infoJ.GetValue(test));
            //  3-2通过反射 设置指定对象的某个变量的值
            infoJ.SetValue(test, 100);
            Console.WriteLine(infoJ.GetValue(test));
            #endregion

            #region 获取类的公共成员方法
            //通过Type类中的 GetMethod方法 得到类中的方法
            //MethodInfo 是方法的反射信息
            Type strType = typeof(string);
            MethodInfo[] methods = strType.GetMethods();
            for (int i = 0; i < methods.Length; i++)
            {
                Console.WriteLine(methods[i]);
            }
            //1.如果存在方法重载 用Type数组表示参数类型
            MethodInfo subStr = strType.GetMethod("Substring",
                new Type[] { typeof(int), typeof(int) });
            //2.调用该方法
            //注意：如果是静态方法 Invoke中的第一个参数传null即可
            string str = "Hello,World!";
            //第一个参数 相当于 是哪个对象要执行这个成员方法
            object result = subStr.Invoke(str, new object[] { 7, 5 });
            Console.WriteLine(result);
            #endregion
        }
    }
}