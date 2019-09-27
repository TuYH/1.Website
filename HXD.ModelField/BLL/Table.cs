using System;
using System.Collections.Generic;
using System.Text;
using HXD.Common;
using HXD.Model;

namespace HXD.ModelField.BLL
{
    public class Table
    {
        /// <summary>
        /// ����ģ�ͱ�XML
        /// </summary>
        /// <param name="Val"></param>
        public void CreateXml(mTable Val)
        {
            XmlDoc xml = new XmlDoc();
            xml.xmlfilePath = GetConfig.System("TableXmlPath") + Val.TableName + ".xml";
            xml.CreateXml("utf-8", Val.TableName);
        }

        /// <summary>
        /// ɾ��ģ�ͱ�XML
        /// </summary>
        /// <param name="Val"></param>
        public void DeleteXml(mTable Val)
        {
            Files.DeleteFile(GetConfig.System("TableXmlPath") + Val.TableName + ".xml");
        }
    }
}
