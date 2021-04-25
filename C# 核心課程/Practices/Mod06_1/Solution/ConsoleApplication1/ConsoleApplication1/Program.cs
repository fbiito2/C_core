using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ConsoleApplication1 {
  class Program {
    static void Main( string[] args ) {
      Console.WriteLine("進入Long run work!");
      //LRWorkCanCancel();
      TaskCanCancel();
      Console.WriteLine("結束");
    }

    private static void LRWorkCanCancel( CancellationToken token ) {
      int i = 0;
      while ( i < 30 ) {
        i++;
        Thread.Sleep(100);
        Console.Write(".");
        // 偵測取消信號
        if ( token.IsCancellationRequested ) {
          // 結束迴圈已停止長時工作
          Console.WriteLine("接收到 cancel 的要求 ");
          break;
        }
      }
      Console.WriteLine("工作完成");
    }

    private static void TaskCanCancel( ) {
      // 設定取消信號的來源
      CancellationTokenSource source = new CancellationTokenSource();
      // 取得取消信號
      CancellationToken token = source.Token;
      // 使用多工執行長時工作，並傳入取消信號
      Task.Run(( ) => LRWorkCanCancel(token));
      Console.WriteLine("請按 X [Enter] 已取消長時工作程序");
      // 接收輸入以決定是否取消
      string theWord = Console.ReadLine();
      if ( theWord.ToLower().StartsWith("x") ) {
        Console.WriteLine("接收到取消的要求，取消此工作.");
        // 傳送取消信號
        source.Cancel();
      }
    }

  }
}
