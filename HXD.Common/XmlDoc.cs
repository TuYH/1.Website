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
        /// XML�ļ�������·��
        /// </summary>
        public string xmlfilePath;
        /// <summary>
        /// XML�ļ��ĵ���Ϣ
        /// </summary>
        public string xmlfileInfo;
        /// <summary>
        /// Xml�ĵ�
        /// </summary>
        private XmlDocument xml;
        /// <summary>
        /// �����ڵ�
        /// </summary>
        private XmlNode root;
        /// <summary>
        /// XML��Ԫ��
        /// </summary>
        private XmlElement element;

        /// <summary>
        /// �������ڵ����
        /// </summary>
        /// <param name="xmlFilePath">Xml�ļ������·��</param>        
        private void CreateElement()
        {
            xml = new XmlDocument();//����XmlDocument����
            string filepath = HttpContext.Current.Server.MapPath(xmlfilePath);
            if (!String.IsNullOrEmpty(xmlfilePath))//����XML�ļ�
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
            element = xml.DocumentElement;//���ظ��ڵ�
        }

        /// <summary>
        /// ����XML��������ڵ�
        /// </summary>
        /// <param name="Encode">�����ʽ</param>
        /// <param name="Node">���ڵ�����</param>
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
        /// ��ȡָ��XPath���ʽ�ڵ��ֵ
        /// </summary>
        /// <param name="xPath">XPath���ʽ����: /Root/Info[0]</param>
        public string GetValue(string xPath)
        {
            CreateElement();//����������
            return element.SelectSingleNode(xPath).InnerText;//����XPath�ڵ��ֵ
        }

        /// <summary>
        /// ��ȡָ��XPath���ʽ�ڵ������ֵ
        /// </summary>
        /// <param name="xPath">XPath���ʽ����: /Root/Info/Name</param>
        /// <param name="attributeName">������</param>
        public string GetAttributeValue(string xPath, string attributeName)
        {
            CreateElement();//����������
            return element.SelectSingleNode(xPath).Attributes[attributeName].Value;//����XPath�ڵ������ֵ
        }

        #region DataSet����XML
        /// <summary>
        /// ��XML����DataSet��
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
        /// ��XML����DataTable�ﲢɸѡ������
        /// </summary>
        /// <param name="RowFilter">����</param>
        /// <param name="Sort">����</param>
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

        #region ����ڵ�
        /// <summary>
        /// ����ڵ�
        /// </summary>
        /// <param name="xPath"></param>
        /// <param name="NodeName">�ڵ�����</param>
        public void InsertNode(string xPath, string NodeName)
        {
            CreateElement();
            root = xml.SelectSingleNode(xPath);//���ҽڵ�
            element = xml.CreateElement(NodeName);//����һ��<Node>�ڵ�
            root.AppendChild(element);//����ڵ�
            xml.Save(HttpContext.Current.Server.MapPath(xmlfilePath));
        }

        /// <summary>
        /// ����ڵ㲢������ֵ
        /// </summary>
        /// <param name="xPath"></param>
        /// <param name="NodeName">�ڵ�����</param>
        /// <param name="NodeVal">�ڵ�ֵ</param>
        public void InsertNode(string xPath, string NodeName, string NodeVal)
        {
            CreateElement();
            root = xml.SelectSingleNode(xPath);//���ҽڵ�
            element = xml.CreateElement(NodeName);//����һ��<Node>�ڵ�
            element.AppendChild(xml.CreateCDataSection(NodeVal));
            root.AppendChild(element);//����ڵ�
            xml.Save(HttpContext.Current.Server.MapPath(xmlfilePath));
        }

        /// <summary>
        /// �������ڵ㼰ֵ
        /// </summary>
        /// <param name="xPath">/root/node</param>
        /// <param name="NodeName">�ڵ���������</param>
        /// <param name="NodeVal">ֵ����</param>
        public void InsertNode(string xPath, string[] NodeName, string[] NodeVal)
        {
            CreateElement();
            root = xml.SelectSingleNode(xPath);//���ҽڵ�
            for (int i = 0; i < NodeName.Length; i++)
            {
                element = xml.CreateElement(NodeName[i]);//����һ��<Node>�ڵ�
                element.AppendChild(xml.CreateCDataSection(NodeVal[i]));
                root.AppendChild(element);//�����
            }
            xml.Save(HttpContext.Current.Server.MapPath(xmlfilePath));
        }

        /// <summary>
        /// ����ڵ㲢����һ�����Լ�ֵ
        /// </summary>
        /// <param name="xPath"></param>
        /// <param name="NodeName">�ڵ�����</param>
        /// <param name="AttributeName">������������</param>
        /// <param name="AttributeValue">����ֵ����</param>
        public void InsertNode(string xPath, string NodeName, string AttributeName, string AttributeVal)
        {
            CreateElement();
            root = xml.SelectSingleNode(xPath);//���ҽڵ�
            element = xml.CreateElement(NodeName);//����һ��<Node>�ڵ�
            element.SetAttribute(AttributeName, AttributeVal);//���øýڵ�genre����
            root.AppendChild(element);//�����
            xml.Save(HttpContext.Current.Server.MapPath(xmlfilePath));
        }

        /// <summary>
        /// ����ڵ㲢����һ�����Լ�ֵ
        /// </summary>
        /// <param name="xPath"></param>
        /// <param name="NodeName">�ڵ�����</param>
        /// <param name="AttributeName">�ڵ���������</param>
        /// <param name="AttributeValue">�ڵ�����ֵ����</param>
        public void InsertNode(string xPath, string NodeName, string[] AttributeName, string[] AttributeVal)
        {
            CreateElement();
            root = xml.SelectSingleNode(xPath);//���ҽڵ�
            element = xml.CreateElement(NodeName);//����һ��<Node>�ڵ�
            for (int i = 0; i < AttributeName.Length; i++)
            {
                element.SetAttribute(AttributeName[i], AttributeVal[i]);//���øýڵ�genre����
            }
            root.AppendChild(element);//�����
            xml.Save(HttpContext.Current.Server.MapPath(xmlfilePath));

        }

        /// <summary>
        /// ����ڵ㡢ֵ������һ�����Լ�ֵ
        /// </summary>
        /// <param name="xPath"></param>
        /// <param name="NodeName">�ڵ�����</param>
        /// <param name="NodeVal">�ڵ�ֵ</param>
        /// <param name="AttributeName">�ڵ���������</param>
        /// <param name="AttributeValue">�ڵ�����ֵ����</param>
        public void InsertNode(string xPath, string NodeName, string NodeVal, string[] AttributeName, string[] AttributeVal)
        {
            CreateElement();
            root = xml.SelectSingleNode(xPath);//���ҽڵ�
            element = xml.CreateElement(NodeName);//����һ��<Node>�ڵ�
            element.AppendChild(xml.CreateCDataSection(NodeVal));
            for (int i = 0; i < AttributeName.Length; i++)
            {
                element.SetAttribute(AttributeName[i], AttributeVal[i]);//���øýڵ�genre����
            }
            root.AppendChild(element);//�����
            xml.Save(HttpContext.Current.Server.MapPath(xmlfilePath));

        }
        #endregion

        #region �޸Ľڵ�
        /// <summary>
        /// ���ݽڵ�ĳ������ֵ�����ĸýڵ�ֵ�����²���һ�����Լ�ֵ
        /// </summary>
        /// <param name="xPath"></param>
        /// <param name="Filter">��������</param>
        /// <param name="FilterVal">��������ֵ</param>
        /// <param name="NodeVal">�ýڵ���ֵ</param>
        /// <param name="NodeName">������������</param>
        /// <param name="NodeVal">����ֵ����</param>
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
                        element.SetAttribute(AttributeName[j], AttributeVal[j]);//���øýڵ�genre����
                    }
                    root.AppendChild(element);//�����
                    xml.Save(HttpContext.Current.Server.MapPath(xmlfilePath));
                }
            }
        }
        #endregion

        /// <summary>
        /// ��ָ���ڵ��������
        /// </summary>
        /// <param name="xmlPath"></param>
        /// <param name="MainNode"></param>
        /// <param name="AttributeName"></param>
        /// <param name="AttributeValue"></param>
        static void AddAttribute(string xmlPath, string MainNode, string AttributeName, string AttributeValue)
        {
            XmlDocument objXmlDoc = new XmlDocument();
            objXmlDoc.Load(xmlPath);//����XML�ĵ�
            XmlNode objNode = objXmlDoc.SelectSingleNode(MainNode);//ѡȡָ���ڵ�
            XmlAttribute nodeAttribute = objXmlDoc.CreateAttribute(AttributeName);//��������
            objNode.Attributes.Append(nodeAttribute);//��������ӵ�ָ���ڵ�
            XmlElement objElement = (XmlElement)objNode;
            objElement.SetAttribute(AttributeName, AttributeValue);
            objXmlDoc.Save(xmlPath);
        }

        /// <summary>
        /// ��ָ���ڵ��������
        /// 
        /// </summary>
        /// <param name="objXmlDoc"></param>
        /// <param name="objNode"></param>
        /// <param name="AttributeName"></param>
        /// <param name="AttributeValue"></param>
        static XmlDocument AddAttribute(XmlDocument objXmlDoc, System.Xml.XmlNode objNode, string AttributeName, string AttributeValue)
        {
            XmlAttribute nodeAttribute = objXmlDoc.CreateAttribute(AttributeName);//��������
            objNode.Attributes.Append(nodeAttribute);//��������ӵ�ָ���ڵ�
            XmlElement objElement = (XmlElement)objNode;
            objElement.SetAttribute(AttributeName, AttributeValue);
            return objXmlDoc;
        }

        #region ɾ���ڵ�
        /// <summary>
        /// ɾ���ڵ��µ������ӽڵ�
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
        /// ����ĳ������ֵɾ���ڵ�
        /// </summary>
        /// <param name="xPath"></param>
        /// <param name="Filter">��������</param>
        /// <param name="FilterVal">ֵ</param>
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
        /// ��������ֵ
        /// </summary>
        /// <param name="xPath"></param>
        /// <param name="AttributeName">��������</param>
        /// <param name="AttributeValue">����ֵ</param>
        public void InsertAttribute(string xPath, string AttributeName, string AttributeValue)
        {
            CreateElement();
            element = (XmlElement)xml.SelectSingleNode(xPath);
            element.SetAttribute(AttributeName, AttributeValue);
            xml.Save(HttpContext.Current.Server.MapPath(xmlfilePath));
        }

    }
}
