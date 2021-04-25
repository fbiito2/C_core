using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
namespace Mod02_1
{
    [Serializable]
    public class Employee2
    {
        public Employee2()
        {
        }

        public String Name { get; set; }
        public short Level { get; set; }

        [NonSerialized]  //排除的項目
        private decimal _salary;
        public decimal Salary
        {
            get { return _salary; }
            set { _salary = value; }
        }
    }
}
