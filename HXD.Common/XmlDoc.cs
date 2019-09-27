using System;
using System.Collections;
using System.Xml;
using System.Web;
using System.Data;
using System.IO;

namespace HXD.Common
{
    public class XmlDoc
    {
        /// <summary>
        /// XML文件的物理路径
        /// </summary>
        public string xmlfilePath;
        /// <summary>
        /// XML文件文档信息
        /// </summary>
        public string xmlfileInfo;
        /// <summary>
        /// Xml文档
        /// </summary>
        private XmlDocument xml;
        /// <summary>
        /// 单个节点
        /// </summary>
        private XmlNode root;
        /// <summary>
        /// XML的元素
        /// </summary>
        private XmlElement element;

        /// <summary>
        /// 创建根节点对象
        /// </summary>
        /// <param name="xmlFilePath">Xml文件的相对路径</param>        
        private void CreateElement()
        {
            xml = new XmlDocument();//创建XmlDocument对象
            string filepath = HttpContext.Current.Server.MapPath(xmlfilePath);
            if (!String.IsNullOrEmpty(xmlfilePath))//加载XML文件
            {
                try
                {
                    xml.Load(filepath);
                }
                catch { }
            }
            else
            {
                xml.LoadXml(xmlfileInfo);
            }
            element = xml.DocumentElement;//返回根节点
        }

        /// <summary>
        /// 创建XML并插入根节点
        /// </summary>
        /// <param name="Encode">编码格式</param>
        /// <param name="Node">根节点名称</param>
        public void CreateXml(string Encoding, string Node)
        {
            CreateElement();
            root = xml.CreateXmlDeclaration("1.0", Encoding, null);
            xml.AppendChild(root);
            element = xml.CreateElement("", Node, "");
            xml.AppendChild(element);
            xml.Save(HttpContext.Current.Server.MapPath(xmlfilePath));
        }

        /// <summary>
        /// 获取指定XPath表达式节点的值
        /// </summary>
        /// <param name="xPath">XPath表达式范例: /Root/Info[0]</param>
        public string GetValue(string xPath)
        {
            CreateElement();//创建根对象
            return element.SelectSingleNode(xPath).InnerText;//返回XPath节点的值
        }

        /// <summary>
        /// 获取指定XPath表达式节点的属性值
        /// </summary>
        /// <param name="xPath">XPath表达式范例: /Root/Info/Name</param>
        /// <param name="attributeName">属性名</param>
        public string GetAttributeValue(string xPath, string attributeName)
        {
            CreateElement();//创建根对象
            return element.SelectSingleNode(xPath).Attributes[attributeName].Value;//返回XPath节点的属性值
        }

        #region DataSet操作XML
        /// <summary>
        /// 把XML读到DataSet里
        /// </summary>
        /// <returns>DataSet</returns>
        public DataSet GetDataSet()
        {
            DataSet ds = new DataSet();
            string filepath = HttpContext.Current.Server.MapPath(xmlfilePath);
            if (!String.IsNullOrEmpty(xmlfilePath))
            {
                ds.ReadXml(filepath);
            }
            else
            {
                xml.LoadXml(xmlfilePath);
                XmlNodeReader xnr = new XmlNodeReader(xml);
                ds.ReadXml(xnr);
            }
            return ds;
        }

        /// <summary>
        /// 把XML读到DataTable里并筛选和排序
        /// </summary>
        /// <param name="RowFilter">条件</param>
        /// <param name="Sort">排序</param>
        /// <returns></returns>
        public DataTable GetDataTable(string RowFilter, string Sort)
        {
            DataView dv = new DataView(GetDataSet().Tables[0]);
            if (!String.IsNullOrEmpty(RowFilter))
            {
                dv.RowFilter = RowFilter;
            }
            if (!String.IsNullOrEmpty(Sort))
            {
                dv.Sort = Sort;
            }
            DataTable dt = dv.ToTable();
            return dt;
        }
        #endregion

        #region 插入节点
        /// <summary>
        /// 插入节点
        /// </summary>
        /// <param name="xPath"></param>
        /// <param name="NodeName">节点名称</param>
        public void InsertNode(string xPath, string NodeName)
        {
            CreateElement();
            root = xml.SelectSingleNode(xPath);//查找节点
            element = xml.CreateElement(NodeName);//创建一个<Node>节点
            root.AppendChild(element);//插入节点
            xml.Save(HttpContext.Current.Server.MapPath(xmlfilePath));
        }

        /// <summary>
        /// 插入节点并插入其值
        /// </summary>
        /// <param name="xPath"></param>
        /// <param name="NodeName">节点名称</param>
        /// <param name="NodeVal">节点值</param>
        public void InsertNode(string xPath, string NodeName, string NodeVal)
        {
            CreateElement();
            root = xml.SelectSingleNode(xPath);//查找节点
            element = xml.CreateElement(NodeName);//创建一个<Node>节点
            element.AppendChild(xml.CreateCDataSection(NodeVal));
            root.AppendChild(element);//插入节点
            xml.Save(HttpContext.Current.Server.MapPath(xmlfilePath));
        }

        /// <summary>
        /// 插入多个节点及值
        /// </summary>
        /// <param name="xPath">/root/node</param>
        /// <param name="NodeName">节点名称数组</param>
        /// <param name="NodeVal">值数组</param>
        public void InsertNode(string xPath, string[] NodeName, string[] NodeVal)
        {
            CreateElement();
            root = xml.SelectSingleNode(xPath);//查找节点
            for (int i = 0; i < NodeName.Length; i++)
            {
                element = xml.CreateElement(NodeName[i]);//创建一个<Node>节点
                element.AppendChild(xml.CreateCDataSection(NodeVal[i]));
                root.AppendChild(element);//插入节
            }
            xml.Save(HttpContext.Current.Server.MapPath(xmlfilePath));
        }

        /// <summary>
        /// 插入节点并插入一个属性及值
        /// </summary>
        /// <param name="xPath"></param>
        /// <param name="NodeName">节点名称</param>
        /// <param name="AttributeName">属性名称数组</param>
        /// <param name="AttributeValue">属性值数组</param>
        public void InsertNode(string xPath, string NodeName, string AttributeName, string AttributeVal)
        {
            CreateElement();
            root = xml.SelectSingleNode(xPath);//查找节点
            element = xml.CreateElement(NodeName);//创建一个<Node>节点
            element.SetAttribute(AttributeName, AttributeVal);//设置该节点genre属性
            root.AppendChild(element);//插入节
            xml.Save(HttpContext.Current.Server.MapPath(xmlfilePath));
        }

        /// <summary>
        /// 插入节点并插入一组属性及值
        /// </summary>
        /// <param name="xPath"></param>
        /// <param name="NodeName">节点名称</param>
        /// <param name="AttributeName">节点属性数组</param>
        /// <param name="AttributeValue">节点属性值数组</param>
        public void InsertNode(string xPath, string NodeName, string[] AttributeName, string[] AttributeVal)
        {
            CreateElement();
            root = xml.SelectSingleNode(xPath);//查找节点
            element = xml.CreateElement(NodeName);//创建一个<Node>节点
            for (int i = 0; i < AttributeName.Length; i++)
            {
                element.SetAttribute(AttributeName[i], AttributeVal[i]);//设置该节点genre属性
            }
            root.AppendChild(element);//插入节
            xml.Save(HttpContext.Current.Server.MapPath(xmlfilePath));

        }

        /// <summary>
        /// 插入节点、值并插入一组属性及值
        /// </summary>
        /// <param name="xPath"></param>
        /// <param name="NodeName">节点名称</param>
        /// <param name="NodeVal">节点值</param>
        /// <param name="AttributeName">节点属性数组</param>
        /// <param name="AttributeValue">节点属性值数组</param>
        public void InsertNode(string xPath, string NodeName, string NodeVal, string[] AttributeName, string[] AttributeVal)
        {
            CreateElement();
            root = xml.SelectSingleNode(xPath);//查找节点
            element = xml.CreateElement(NodeName);//创建一个<Node>节点
            element.AppendChild(xml.CreateCDataSection(NodeVal));
            for (int i = 0; i < AttributeName.Length; i++)
            {
                element.SetAttribute(AttributeName[i], AttributeVal[i]);//设置该节点genre属性
            }
            root.AppendChild(element);//插入节
            xml.Save(HttpContext.Current.Server.MapPath(xmlfilePath));

        }
        #endregion

        #region 修改节点
        /// <summary>
        /// 根据节点某个属性值，更改该节点值并从新插入一组属性及值
        /// </summary>
        /// <param name="xPath"></param>
        /// <param name="Filter">条件属性</param>
        /// <param name="FilterVal">条件属性值</param>
        /// <param name="NodeVal">该节点新值</param>
        /// <param name="NodeName">属性名称数组</param>
        /// <param name="NodeVal">属性值数组</param>
        public void UpdateNote(string xPath, string Filter, string FilterVal, string NodeVal, string[] AttributeName, string[] AttributeVal)
        {
            CreateElement();
            root = xml.SelectSingleNode(xPath);
            XmlNodeList xnl = xml.SelectSingleNode(xPath).ChildNodes;
            for (int i = 0; i < xnl.Count; i++)
            {
                element = (XmlElement)xnl.Item(i);
                if (element.GetAttribute(Filter) == FilterVal)
                {
                    element.RemoveAll();
                    element.AppendChild(xml.CreateCDataSection(NodeVal));
                    for (int j = 0; j < AttributeName.Length; j++)
                    {
                        element.SetAttribute(AttributeName[j], AttributeVal[j]);//设置该节点genre属性
                    }
                    root.AppendChild(element);//插入节
                    xml.Save(HttpContext.Current.Server.MapPath(xmlfilePath));
                }
            }
        }
        #endregion

        /// <summary>
        /// 给指定节点添加属性
        /// </summary>
        /// <param name="xmlPath"></param>
        /// <param name="MainNode"></param>
        /// <param name="AttributeName"></param>
        /// <param name="AttributeValue"></param>
        static void AddAttribute(string xmlPath, string MainNode, string AttributeName, string AttributeValue)
        {
            XmlDocument objXmlDoc = new XmlDocument();
            objXmlDoc.Load(xmlPath);//加载XML文档
            XmlNode objNode = objXmlDoc.SelectSingleNode(MainNode);//选取指定节点
            XmlAttribute nodeAttribute = objXmlDoc.CreateAttribute(AttributeName);//创建属性
            objNode.Attributes.Append(nodeAttribute);//把属性添加到指定节点
            XmlElement objElement = (XmlElement)objNode;
            objElement.SetAttribute(AttributeName, AttributeValue);
            objXmlDoc.Save(xmlPath);
        }

        /// <summary>
        /// 给指定节点添加属性
        /// 
        /// </summary>
        /// <param name="objXmlDoc"></param>
        /// <param name="objNode"></param>
        /// <param name="AttributeName"></param>
        /// <param name="AttributeValue"></param>
        static XmlDocument AddAttribute(XmlDocument objXmlDoc, System.Xml.XmlNode objNode, string AttributeName, string AttributeValue)
        {
            XmlAttribute nodeAttribute = objXmlDoc.CreateAttribute(AttributeName);//创建属性
            objNode.Attributes.Append(nodeAttribute);//把属性添加到指定节点
            XmlElement objElement = (XmlElement)objNode;
            objElement.SetAttribute(AttributeName, AttributeValue);
            return objXmlDoc;
        }

        #region 删除节点
        /// <summary>
        /// 删除节点下的所有子节点
        /// </summary>
        /// <param name="xPath"></param>
        public void DeleteNode(string xPath)
        {
            CreateElement();
            element = (XmlElement)xml.SelectSingleNode(xPath);
            element.RemoveAll();
            xml.Save(HttpContext.Current.Server.MapPath(xmlfilePath));
        }
        /// <summary>
        /// 根据某个属性值删除节点
        /// </summary>
        /// <param name="xPath"></param>
        /// <param name="Filter">条件属性</param>
        /// <param name="FilterVal">值</param>
        public void DeleteNode(string xPath, string Filter, string FilterVal)
        {
            CreateElement();
            root = xml.SelectSingleNode(xPath);
            XmlNodeList xnl = xml.SelectSingleNode(xPath).ChildNodes;
            for (int i = 0; i < xnl.Count; i++)
            {
                element = (XmlElement)xnl.Item(i);
                if (element.GetAttribute(Filter) == FilterVal)
                {
                    root.RemoveChild(element);
                    xml.Save(HttpContext.Current.Server.MapPath(xmlfilePath));
                }
            }
        }
        #endregion

        /// <summary>
        /// 插入属性值
        /// </summary>
        /// <param name="xPath"></param>
        /// <param name="AttributeName">属性名称</param>
        /// <param name="AttributeValue">属性值</param>
        public void InsertAttribute(string xPath, string AttributeName, string AttributeValue)
        {
            CreateElement();
            element = (XmlElement)xml.SelectSingleNode(xPath);
            element.SetAttribute(AttributeName, AttributeValue);
            xml.Save(HttpContext.Current.Server.MapPath(xmlfilePath));
        }

    }
}
