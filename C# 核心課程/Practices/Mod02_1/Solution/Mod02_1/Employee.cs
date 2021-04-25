using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
namespace Mod02_1
{
    [Serializable]  //加這個就可以自動序列反序列了
    public class Employee : ISerializable
    {
        //預設建構式，平常要使用這個物件類別時用的
        public Employee()
        {
        }

        //反序列化(要自己實做)
        private Employee(SerializationInfo info, StreamingContext context)
        {
            Name = info.GetString("Name");
            Level = info.GetInt16("Level");
            Salary = info.GetDecimal("Salary");
        }

        public String Name { get; set; }
        public short Level { get; set; }

        private decimal _salary;
        public decimal Salary
        {
            get { return _salary; }
            set { _salary = value; }
        }

        //序列化  ISerializable按右鍵生成
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Name", Name);
            info.AddValue("Level", Level);
            info.AddValue("Salary", Salary);

        }
    }
}
