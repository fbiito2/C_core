using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
namespace Mod02_1
{
    [DataContract]
    public class Employee
    {
        [DataMember]
        public String Name { get; set; }
        [DataMember]
        public short Level { get; set; }
        public decimal Salary { get; set; }
    }

    //[Serializable]
    //public class Employee : ISerializable
    //{
    //    public Employee()
    //    {
    //    }
    //    private Employee(SerializationInfo info, StreamingContext context)
    //    {
    //        Name = info.GetString("Name");
    //        Level = info.GetInt16("Level");
    //        Salary = info.GetDecimal("Salary");
    //    }

    //    public String Name { get; set; }
    //    public short Level { get; set; }

    //    private decimal _salary;
    //    public decimal Salary
    //    {
    //        get { return _salary; }
    //        set { _salary = value; }
    //    }

    //    public void GetObjectData(SerializationInfo info, StreamingContext context)
    //    {
    //        info.AddValue("Name", Name);
    //        info.AddValue("Level", Level);
    //        info.AddValue("Salary", Salary);

    //    }
    //}
}
