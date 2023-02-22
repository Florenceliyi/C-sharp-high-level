namespace 多线程
{
    internal class Program
    {
        /*static bool isRunning = true;
        static object obj = new object();*/
        static Icon icon;
        enum E_MoveDir
        {
            Up, Down, Left, Right,
        }

        class Icon
        {
            public E_MoveDir dir;
            public int x;
            public int y;
            public Icon(int x, int y, E_MoveDir dir)
            {
                this.x = x;
                this.y = y;
                this.dir = dir;
            }
            public void Move()
            {
                switch (dir)
                {
                    case E_MoveDir.Up:
                        y -= 1;
                        break;
                    case E_MoveDir.Down:
                        y += 2;
                        break;
                    case E_MoveDir.Left:
                        x -= 2;
                        break;
                    case E_MoveDir.Right:
                        x += 2;
                        break;
                    default:
                        break;
                }
            }
            //绘制
            public void Draw()
            {
                Console.SetCursorPosition(x, y);
                Console.Write("■");
            }
            //擦除
            public void Clear()
            {
                Console.SetCursorPosition(x, y);
                Console.Write("  ");
            }
            //转向
            public void ChangeDir(E_MoveDir dir)
            {
                this.dir = dir;
            }
        }
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            icon = new Icon(10, 5, E_MoveDir.Right);
            icon.Draw();

            //开启多线程
            Thread newThread = new Thread(NewThreadLogic);
            newThread.IsBackground = true;
            newThread.Start();

            while (true)
            {
                Thread.Sleep(500);
                icon.Clear();
                icon.Move();
                icon.Draw();
            }
            /*//新开线程
            Thread t = new Thread(NewThreadlogic);
           //启动线程
            t.Start();
            //后台线程
            t.IsBackground= true;
            //让线程休眠
            //Thread.Sleep(10000);

            while (true)
            {
                lock (obj)
                {
                    Console.SetCursorPosition(20, 0);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("线程池");
                    Console.Write("●");
                }
            }*/
        }
        /*static void NewThreadlogic()
        {
            while (isRunning)

            {
                lock (obj)
                {
                    Console.SetCursorPosition(10, 5);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("■");
                }
            }
        }*/
        static void NewThreadLogic()
        {
            while (true)
            {
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.W:
                        icon.ChangeDir(E_MoveDir.Up);
                        break;
                    case ConsoleKey.A:
                        icon.ChangeDir(E_MoveDir.Left);
                        break;
                    case ConsoleKey.S:
                        icon.ChangeDir(E_MoveDir.Down);
                        break;
                    case ConsoleKey.D:
                        icon.ChangeDir(E_MoveDir.Right);
                        break;
                }
            }
        }
    }
}

   