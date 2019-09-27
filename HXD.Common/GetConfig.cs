using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace HXD.Common
{
    public class GetConfig
    {
        public static string System(string ConfigName)
        {
            if (Caches.GetCache("system_" + ConfigName) == null)
            {
                XmlDoc xml = new XmlDoc();
                xml.xmlfilePath = "~/Config/SystemConfig.config";
                DataSet ds = xml.GetDataSet();
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    Caches.SetCache("system_" + ConfigName, ds.Tables[0].Rows[0][ConfigName].ToString());
                }
            }
            return Caches.GetCache("system_" + ConfigName).ToString();
        }

        public static string User(string ConfigName)
        {
            if (Caches.GetCache("user_" + ConfigName) == null)
            {
                XmlDoc xml = new XmlDoc();
                xml.xmlfilePath = "~/Config/UserConfig.config";
                DataSet ds = xml.GetDataSet();
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    Caches.SetCache("user_" + ConfigName, ds.Tables[0].Rows[0][ConfigName].ToString());
                }
            }
            return Caches.GetCache("user_" + ConfigName).ToString();
        }

        public static string Image(string ConfigName)
        {
            if (Caches.GetCache("image_" + ConfigName) == null)
            {
                XmlDoc xml = new XmlDoc();
                xml.xmlfilePath = "~/Config/ImageConfig.config";
                DataSet ds = xml.GetDataSet();
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    Caches.SetCache("image_" + ConfigName, ds.Tables[0].Rows[0][ConfigName].ToString());
                }
            }
            return Caches.GetCache("image_" + ConfigName).ToString();
        }

        public static string File(string ConfigName)
        {
            if (Caches.GetCache("file_" + ConfigName) == null)
            {
                XmlDoc xml = new XmlDoc();
                xml.xmlfilePath = "~/Config/FileConfig.config";
                DataSet ds = xml.GetDataSet();
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    Caches.SetCache("file_" + ConfigName, ds.Tables[0].Rows[0][ConfigName].ToString());
                }
            }
            return Caches.GetCache("file_" + ConfigName).ToString();
        }
    }
}
