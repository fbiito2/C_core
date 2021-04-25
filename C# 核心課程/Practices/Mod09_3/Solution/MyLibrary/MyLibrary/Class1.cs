using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary {
  public class Utils {
    public string GetMsg( ) {
      return "Hi from MyLibrary, Version No. " +
        System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
    }
  }

  public class Class1 {
  }
}
