using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfService1 {
  // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
  [ServiceContract]
  public interface IService1 {

    [OperationContract]
    [WebGet(UriTemplate = "GetData?value={value}")]
    string GetData( int value );

    [OperationContract]
    [WebGet(UriTemplate = "Player?id={id}")]
    Player GetPlayer( int id );
  }

  [DataContract]
  public class Player {
    [DataMember]
    public int ID { get; set; }
    [DataMember]
    public string Name { get; set; }
  }
}
