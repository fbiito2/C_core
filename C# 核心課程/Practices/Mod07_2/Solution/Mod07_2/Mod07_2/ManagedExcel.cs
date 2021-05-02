using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace Mod07_2
{
    public class ManagedExcel : IDisposable
    {
        //用dynamic 型別物件，要自己打出要使用的方法與要自己做回收
        //--------excel 元件-------------
        dynamic excelApp;
        dynamic workbook;
        dynamic workbooks;
        //--------excel 元件-------------
        // 建構函式
        public ManagedExcel(string FileName)
        {
            // 建立動態物件
            Type excelType = Type.GetTypeFromProgID("Excel.Application");
            excelApp = Activator.CreateInstance(excelType);
            workbooks = excelApp.Workbooks;
            workbook = workbooks.Open(FileName);
            excelApp.Visible = true;
        }

        // 原生的解構函式
        ~ManagedExcel()
        {
            Console.WriteLine("執行解構函式");
            Dispose(false);
        }

        // 匯出PDF 文件
        public void ExportToPDF(string output)
        {
            workbook.ExportAsFixedFormat(0, output);
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls


        //dispose 的實作介面
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.
                try
                {
                    Console.WriteLine("執行Excel 的 Quit 方法");
                    excelApp.Quit();  //關掉excel釋放

                }
                finally
                {
                    Console.WriteLine("釋放com 物件");
                    Marshal.ReleaseComObject(workbooks);  //確實釋放
                    Marshal.ReleaseComObject(excelApp);   //確實釋放
                }

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~ManagedExcel() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            Console.WriteLine("Dispose() -- 呼叫Dispose () 釋放資源");
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            //GC = 垃圾車   告訴垃圾車我們做釋放了
            GC.SuppressFinalize(this);
        }
        #endregion

    }
}
