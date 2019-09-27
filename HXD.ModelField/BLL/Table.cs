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
        /// 生成模型表XML
        /// </summary>
        /// <param name="Val"></param>
        public void CreateXml(mTable Val)
        {
            XmlDoc xml = new XmlDoc();
            xml.xmlfilePath = GetConfig.System("TableXmlPath") + Val.TableName + ".xml";
            xml.CreateXml("utf-8", Val.TableName);
        }

        /// <summary>
        /// 删除模型表XML
        /// </summary>
        /// <param name="Val"></param>
        public void DeleteXml(mTable Val)
        {
            Files.DeleteFile(GetConfig.System("TableXmlPath") + Val.TableName + ".xml");
        }
    }
}
