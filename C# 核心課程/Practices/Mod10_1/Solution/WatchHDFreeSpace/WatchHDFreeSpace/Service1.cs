using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace WatchHDFreeSpace
{
    public partial class Service1 : ServiceBase
    {
        System.Timers.Timer serviceTimer;  //背景執行的計時器
        string logName = "MyLog";
        string sourceName = "Mod10";

        public Service1()
        {
            InitializeComponent();  //預設建立時自動建立

            serviceTimer = new System.Timers.Timer();
            serviceTimer.Elapsed += new
            System.Timers.ElapsedEventHandler(serviceTimer_Elapsed);  //每隔一段時間要執行的程式(程式名稱)
            serviceTimer.Interval = 5000;   //多久做一次

            //可不加，執行時程式會自己做，不然就要像範例自己寫，windows 的servic執行時會寫入系統的事件紀錄
            if (!EventLog.SourceExists(sourceName))
            {
                EventLog.CreateEventSource(sourceName, logName);
            }
        }

        void serviceTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            DriveInfo cDrive = new DriveInfo(@"C:\");
            string message = "您的C磁碟目前剩餘空間:" + cDrive.TotalFreeSpace;

            EventLog.WriteEntry(sourceName, message, EventLogEntryType.Information);  //寫到系統的log中，當然可以寫到自己的log中

        }

        
        protected override void OnStart(string[] args)
        {
            serviceTimer.Start();
        }

        protected override void OnStop()
        {
            serviceTimer.Stop();
        }
    }
}
