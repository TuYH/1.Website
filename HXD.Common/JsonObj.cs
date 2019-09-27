using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;
namespace JsonClassLibrary
{
    public class JsonObj
    {
        public static void Jsons()
        {
            List<Pointnfo> Pointns = new List<Pointnfo>();
            for (int i = 0; i < 10; i++)
            {
                Pointnfo Pointnfo1 = new Pointnfo();
                Pointnfo1.lat = Guid.NewGuid().ToString();
                Pointnfo1.lng = Guid.NewGuid().ToString();
                Pointns.Add(Pointnfo1);
            }
            DataContractJsonSerializer json = new DataContractJsonSerializer(Pointns.GetType());
            json.WriteObject(System.Web.HttpContext.Current.Response.OutputStream, Pointns);
        }
    }

    [DataContract]
    public class Pointnfo
    {
        string _lat = "";
        string _lng = "";
        [DataMember]
        public string lat
        {
            get { return _lat; }
            set { _lat = value; }
        }
        [DataMember]
        public string lng
        {
            get { return _lng; }
            set { _lng = value; }
        }
    }
}
