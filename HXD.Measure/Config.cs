using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.Configuration;



namespace HXD.Measure
{
    public abstract class Config
    {
        
     
        public static string ConnectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["SqlConnString"].ConnectionString;
               
                
            }
        }
        public static string CompanyName
        {
            get
            {
                ///return ConfigurationSettings.AppSettings().Item("CompanyName");
                return ConfigurationManager.ConnectionStrings["CompanyName"].ConnectionString;
               
            }
        }
        public static string DomainName
        {
            get
            {
                //return ConfigurationSettings.AppSettings.AppSettings().Item("DomainName");
                return ConfigurationManager.ConnectionStrings["DomainName"].ConnectionString;
            }
        }
    }
}
