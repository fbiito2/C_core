using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            //TaskStart();

            //TaskWait();

            //TaskReturnValue();

            //TaskLongRuning();

            //TaskCancel();

            UseParallelInvoke();


            //UseParallelFor();


            //UseParallelForEach();

            Console.ReadLine();
        }



        private static void UseParallelForEach()
        {
            //不能指定CPU
            var room = new[] {
                new  { ID = 101, Name = "Room A" , Floor="12" }, 
                new  { ID = 102, Name = "Room B"  , Floor="12"}, 
                new  { ID = 103, Name = "Room C"  , Floor="14"}, 
                new  { ID = 104, Name = "Room D" , Floor="14" }
            };
            //foreach (var item in room)
            //{
            //    Console.WriteLine("{0} - {1} - {2}", item.ID, item.Name, item.Floor  );
            //}
            //範例
            Random rnd = new Random();
            Parallel.ForEach(room, item =>
            {
                Thread.Sleep(rnd.Next(500));
                Console.WriteLine("{0} - {1} - {2}", item.ID, item.Name, item.Floor);
            });
        }

        private static void UseParallelFor()
        {
            Random rnd = new Random();
            //for (int i = 0; i < length; i++)
            //{
                
            //}
            //不用i++  自己會加
            Parallel.For(0, 60, idx =>
            {
                Thread.Sleep(rnd.Next(1, 500));
                Console.WriteLine(idx);
            });
        }

        private static void UseParallelInvoke()
        {
            //cpu的id是不會看到2的，id=2給UI
            Random rnd = new Random();
            Parallel.Invoke(
                () =>
                {
                    Thread.Sleep(rnd.Next(1, 5000));
                    Console.WriteLine("task 1 id: " + Thread.CurrentThread.ManagedThreadId);
                },
                () =>
                {
                    Thread.Sleep(rnd.Next(1, 5000));
                    Console.WriteLine("task 2 id: " + Thread.CurrentThread.ManagedThreadId);
                },
                () =>
                {
                    Thread.Sleep(rnd.Next(1, 5000));
                    Console.WriteLine("task 3 id: " + Thread.CurrentThread.ManagedThreadId);
                });

            Console.WriteLine("平行處理 Parallel.Invoke .");
        }

        private static void TaskCancel()
        {
            CancellationTokenSource source = new CancellationTokenSource();
            CancellationToken token = source.Token;
            Task.Run(() => LRWorkCanCancel(token));
            Console.WriteLine("waiting long running , Press X -- Cancel");
            string theWord = Console.ReadLine();
            if (theWord.ToLower().StartsWith("x"))
            {
                Console.WriteLine("Cancellation Requested, waiting cancel.");
                source.Cancel();
            }
        }
        private static void LRWorkCanCancel(CancellationToken token)
        {

            int i = 0;
            while (i < 30)
            {
                i++;
                Thread.Sleep(100);
                Console.Write(".");
                if (token.IsCancellationRequested)
                {
                    Console.WriteLine("接收到 cancel 的要求 ");
                    break;
                }
            }
            Console.WriteLine("task complete");


        }

        private static void TaskLongRuning()
        {
            Task.Run(() =>
            {
                int i = 0;
                while (i < 30)
                {
                    i++;
                    Thread.Sleep(100);
                    Console.Write(".");
                }
                Console.WriteLine("task complete");
            });
            Console.WriteLine("waiting long running");
        }

        private static void TaskReturnValue()
        {
            Task<bool> taskIsAM = Task.Run<bool>(() =>
            {
                Thread.Sleep(2000);
                return DateTime.Now.Hour < 12;
            });


            Console.WriteLine("現在是: " + DateTime.Now.ToLongTimeString());

            Console.WriteLine("waiting result ....");

            Console.WriteLine("Is AM?" + taskIsAM.Result);
        }

        private static void TaskWait()
        {
            Console.WriteLine("開始執行一堆工作 ...id:" + Thread.CurrentThread.ManagedThreadId);

            Task[] manyTasks = new Task[] {
                Task.Run (()=>{
                    Thread.Sleep(2000);
                    Console.WriteLine("task 1 ...id:" + Thread.CurrentThread.ManagedThreadId);
                }), 
                Task.Run (delegate{
                    Thread.Sleep(500);
                    Console.WriteLine("task 2 ...id:" + Thread.CurrentThread.ManagedThreadId);
                })
            };
            //Console.WriteLine("Wait All");
            //Task.WaitAll(manyTasks);
            //Console.WriteLine("Wait All - complete");

            //Console.WriteLine("Wait Any");
            //Task.WaitAny(manyTasks);
            //Console.WriteLine("Wait Any - complete");

            //Console.WriteLine("AAAAA");
        }

        private static void TaskStart()
        {
            //1
            //Task myTask = new Task(new Action(MyAction));

            //2
            //Task myTask = new Task(delegate
            //{
            //    Console.WriteLine("使用delegate 執行" + Thread.CurrentThread.ManagedThreadId);
            //});

            //3
            Task myTask = new Task(() =>
            {
                Console.WriteLine("使用Lambada 執行 id:" + Thread.CurrentThread.ManagedThreadId);
            });



            Console.WriteLine("開始執行一個工作 ...id:" + Thread.CurrentThread.ManagedThreadId);
            myTask.Start();
        }

        static void MyAction()
        {
            Console.WriteLine("使用Action 執行" + Thread.CurrentThread.ManagedThreadId);
        }
    }
}
