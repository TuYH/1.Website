using System;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Security;

using System.Data.SqlClient;


namespace HXD.Common
{
    public class APLFrame
    {
        public delegate void dtCallRow(StringBuilder sbData, DataTable dt, int rowIndex);
        public delegate string dtCallCol(DataTable dt, string colName, int rowIndex);
        public delegate string dtCallExcelRow(DataTable dt, int rowIndex);
        public delegate string dtCallExcelCol(DataTable dt, string colName, int rowIndex);
        public delegate string dtCallExcelVal(DataTable dt, string colName, int rowIndex);
        public delegate void dvCallRow(StringBuilder sbData, DataView dv, int rowIndex);
        public delegate string dvCallCal(DataView dv, string colName, int rowIndex);
        public delegate string dvCallExcelRow(DataView dv, int rowIndex);
        public delegate string dvCallExcelCol(DataView dv, string colName, int rowIndex);
        public delegate string dvCallExcelVal(DataView dv, string colName, int rowIndex);

        private StringBuilder sbHtmlSelects = null;
        private StringBuilder sbHtmlChks = null;
        private StringBuilder sbhideTabCols = null;
        public int rsCount = 0;
        public string Message = "";
        public string ErrMessage = "";
        public string strTotal = "";
        public string encoding = "";
        public string cols = "";
        public string tabName = "";
        public string JS = "";
        public APLFrame.dtCallCol callColdt = null;
        public APLFrame.dvCallCal callColdv = null;
        public StringBuilder sbData = null;
        public string ProxyDomain = "";
        public string ProxyUrl = "";
        public string ProxyLogin = "";
        public string ProxyCompany = "";
        public string ProxyUserID = "";
        public string ProxyPass = "";
        private static string xml_xls_top = "<?xml version='1.0'?>\r\n<?mso-application progid='Excel.Sheet'?>\r\n<Workbook xmlns='urn:schemas-microsoft-com:office:spreadsheet'\r\n xmlns:o='urn:schemas-microsoft-com:office:office'\r\n xmlns:x='urn:schemas-microsoft-com:office:excel'\r\n xmlns:ss='urn:schemas-microsoft-com:office:spreadsheet'\r\n xmlns:html='http://www.w3.org/TR/REC-html40'>\r\n <DocumentProperties xmlns='urn:schemas-microsoft-com:office:office'>\r\n  <Title>{4}</Title>\r\n  <Author>{5}</Author>\r\n  <LastAuthor>{6}</LastAuthor>\r\n  <Created>{3}</Created>\r\n  <Company>{6}</Company>\r\n  <Version>11.5606</Version>\r\n </DocumentProperties>\r\n <ExcelWorkbook xmlns='urn:schemas-microsoft-com:office:excel'>\r\n  <WindowHeight>13050</WindowHeight>\r\n  <WindowWidth>14940</WindowWidth>\r\n  <WindowTopX>480</WindowTopX>\r\n  <WindowTopY>45</WindowTopY>\r\n  <ProtectStructure>False</ProtectStructure>\r\n  <ProtectWindows>False</ProtectWindows>\r\n </ExcelWorkbook>\r\n <Styles>\r\n  <Style ss:ID='Default' ss:Name='Normal'>\r\n   <Alignment ss:Vertical='Center'/>\r\n   <Borders/>\r\n   <Font ss:FontName='宋体' x:CharSet='134' ss:Size='12'/>\r\n   <Interior/>\r\n   <NumberFormat/>\r\n   <Protection/>\r\n  </Style>\r\n  <Style ss:ID='s21'>\r\n   <Alignment ss:Horizontal='Center' ss:Vertical='Center'/>\r\n   <Font ss:FontName='宋体' x:CharSet='134' ss:Bold='1'/>\r\n  </Style>\r\n<Style ss:ID='s22'>\r\n   <Alignment ss:Horizontal='Center' ss:Vertical='Center'/>\r\n   <Font ss:FontName='宋体' x:CharSet='134'/>\r\n  </Style>\r\n </Styles>\r\n <Worksheet ss:Name='{0}'>\r\n  <Table ss:ExpandedColumnCount='{1}' ss:ExpandedRowCount='{2}' x:FullColumns='1'\r\n   x:FullRows='1' ss:DefaultColumnWidth='54' ss:DefaultRowHeight='18'>";
        private static string xml_xls_bottom = "  </Table>\r\n  <WorksheetOptions xmlns='urn:schemas-microsoft-com:office:excel'>\r\n   <Unsynced/>\r\n   <Print>\r\n    <ValidPrinterInfo/>\r\n    <PaperSizeIndex>149</PaperSizeIndex>\r\n    <HorizontalResolution>180</HorizontalResolution>\r\n    <VerticalResolution>180</VerticalResolution>\r\n   </Print>\r\n   <Selected/>\r\n   <Panes>\r\n    <Pane>\r\n     <Number>3</Number>\r\n     <ActiveRow>1</ActiveRow>\r\n     <ActiveCol>1</ActiveCol>\r\n    </Pane>\r\n   </Panes>\r\n   <ProtectObjects>False</ProtectObjects>\r\n   <ProtectScenarios>False</ProtectScenarios>\r\n  </WorksheetOptions>\r\n </Worksheet>\r\n</Workbook>\r\n";
        private static byte[] Keys = new byte[]
		{
			18,
			52,
			86,
			120,
			144,
			171,
			205,
			239
		};
        private static string encryptKey = "apla5623";

        public static string MD5(string str)
        {
            return FormsAuthentication.HashPasswordForStoringInConfigFile(str, "MD5").ToString();
        }
        public static string EncryptDES(string encryptString)
        {
            string result;
            try
            {
                byte[] bytes = Encoding.UTF8.GetBytes(APLFrame.encryptKey.Substring(0, 8));
                byte[] keys = APLFrame.Keys;
                byte[] bytes2 = Encoding.UTF8.GetBytes(encryptString);
                DESCryptoServiceProvider dESCryptoServiceProvider = new DESCryptoServiceProvider();
                MemoryStream memoryStream = new MemoryStream();
                CryptoStream cryptoStream = new CryptoStream(memoryStream, dESCryptoServiceProvider.CreateEncryptor(bytes, keys), CryptoStreamMode.Write);
                cryptoStream.Write(bytes2, 0, bytes2.Length);
                cryptoStream.FlushFinalBlock();
                result = Convert.ToBase64String(memoryStream.ToArray());
            }
            catch
            {
                result = encryptString;
            }
            return result;
        }
        public static string DecryptDES(string decryptString)
        {
            string result;
            try
            {
                byte[] bytes = Encoding.UTF8.GetBytes(APLFrame.encryptKey);
                byte[] keys = APLFrame.Keys;
                byte[] array = Convert.FromBase64String(decryptString);
                DESCryptoServiceProvider dESCryptoServiceProvider = new DESCryptoServiceProvider();
                MemoryStream memoryStream = new MemoryStream();
                CryptoStream cryptoStream = new CryptoStream(memoryStream, dESCryptoServiceProvider.CreateDecryptor(bytes, keys), CryptoStreamMode.Write);
                cryptoStream.Write(array, 0, array.Length);
                cryptoStream.FlushFinalBlock();
                result = Encoding.UTF8.GetString(memoryStream.ToArray());
            }
            catch
            {
                result = decryptString;
            }
            return result;
        }
        public static string FormDecode(string prm)
        {
            string result;
            if (prm == "")
            {
                result = "";
            }
            else
            {
                result = HttpContext.Current.Server.UrlDecode(Convert.ToString(HttpContext.Current.Request.Form[prm]));
            }
            return result;
        }
    }
}
