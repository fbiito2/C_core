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

namespace WatchHDFreeSpace {
  public partial class Service1 : ServiceBase {
    System.Timers.Timer serviceTimer;
    string logName = "MyLog";
    string sourceName = "Mod10";

    public Service1( ) {
      InitializeComponent();

      serviceTimer = new System.Timers.Timer();
      serviceTimer.Elapsed += new
      System.Timers.ElapsedEventHandler(serviceTimer_Elapsed);
      serviceTimer.Interval = 60000;

      if ( !EventLog.SourceExists(sourceName) ) {
        EventLog.CreateEventSource(sourceName, logName);
      }
    }

    void serviceTimer_Elapsed( object sender, System.Timers.ElapsedEventArgs e ) {
      DriveInfo cDrive = new DriveInfo(@"C:\");
      string message = "您的C磁碟目前剩餘空間:" + cDrive.TotalFreeSpace;

      EventLog.WriteEntry(sourceName, message, EventLogEntryType.Information);

    }

    protected override void OnStart( string[] args ) {
      serviceTimer.Start();
    }

    protected override void OnStop( ) {
      serviceTimer.Stop();
    }
  }
}
