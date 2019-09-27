using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.IO;
using System.Data.OleDb;
namespace HXD.Common
{
   public  class ExcelCtrl
    {


       static OleDbType GetOledbType(System.Type DataType)
       {
           OleDbType ctype = OleDbType.VarWChar;

           if (DataType == System.Type.GetType("System.Int32") || DataType == System.Type.GetType("System.Int16") || DataType == System.Type.GetType("System.Int64"))
           {
               ctype = OleDbType.Integer;
           }
           else if (DataType == System.Type.GetType("System.String"))
           {

               ctype = OleDbType.VarChar;

           }

           else if (DataType == System.Type.GetType("System.Boolean"))
           {

               ctype = OleDbType.Boolean;

           }

           else if (DataType == System.Type.GetType("System.DateTime"))
           {

               ctype = OleDbType.Date;

           }

           else if (DataType == System.Type.GetType("System.Guid"))
           {

               ctype = OleDbType.Guid;

           }
           else
           {
               ctype = OleDbType.VarChar;

           }
           return ctype;
       
       }

       static private string GetExcelType(DataColumn col)
       {          
           OleDbType ctype = GetOledbType(col.DataType);

           string clen = col.MaxLength == -1 ? "" : ("(" + (ctype != OleDbType.BSTR ? col.MaxLength.ToString() : "-1") + ")");
           
           return " " + Enum.GetName(typeof(OleDbType), ctype) + clen;
       }

        ///   <summary>  
        ///   DataSet导出到Excel文件 
        ///   </summary>  
       ///   <param   name="ds">数据集</param>  
        ///   <param   name="Excelfile">Excel文件 FullPath</param>  
        ///   <returns></returns>   
        public static bool  DataSetToExcelFile(DataSet ds,string Excelfile){

            if (ds.Tables.Count ==0)
            {
                return false;
            }

            string  TemplateFile = System.Web.HttpContext.Current.Server.MapPath("~/Excel/Template.xls");
            if (System.IO.File.Exists (Excelfile))
            {
                System.IO.File.Delete(Excelfile); 
            }
            System.IO.File.Copy(TemplateFile, Excelfile);

            string strConn;
            strConn = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + Excelfile + "; Extended Properties=Excel 8.0;";

            using (OleDbConnection conn = new OleDbConnection(strConn))
            {
                conn.Open();
                foreach (DataTable tempTable in ds.Tables)
                {
                    if (tempTable.Columns.Count ==0 )
                    {
                        break;
                    }

                    OleDbCommand myInsertCommand = new OleDbCommand("", conn);

                    StringBuilder cmdtxt = new StringBuilder("Create Table [");
                    cmdtxt.Append(tempTable.TableName);
                    cmdtxt.Append("] (");

                    StringBuilder insertCmdtxt = new StringBuilder("Insert into [");
                    insertCmdtxt.Append(tempTable.TableName);
                    insertCmdtxt.Append("] (");

                    StringBuilder insertValues = new StringBuilder(" Values(");


                    for (int i = 0; i < tempTable.Columns.Count; i++)
                    {
                        
                        myInsertCommand.Parameters.Add(
                            new OleDbParameter("@" + tempTable.Columns[i].ColumnName, GetOledbType(tempTable.Columns[i].DataType ))
                            );

                        cmdtxt.Append("[" + tempTable.Columns[i].ColumnName + "]");                        

                        cmdtxt.Append(GetExcelType(tempTable.Columns[i]));  

                        insertCmdtxt.Append(tempTable.Columns[i].ColumnName);
                        insertValues.Append("@" + tempTable.Columns[i].ColumnName);


                        if (i != tempTable.Columns.Count - 1)
                        {
                            cmdtxt.Append(",");
                            insertCmdtxt.Append(",");
                            insertValues.Append(",");
                        }
                    }
                    cmdtxt.Append(")");
                    insertCmdtxt.Append(")");
                    insertValues.Append(")");

                    insertCmdtxt.Append(insertValues);

                    //添加数据表
                    OleDbCommand myCommand = new OleDbCommand(cmdtxt.ToString(), conn);
                    myCommand.ExecuteNonQuery();


                    //删除模版中数据表Sheet1，占时不能成功？？。。。
                    myCommand.CommandText = "drop table [Sheet1$]";
                    myCommand.ExecuteNonQuery();
                    //插入行
                    myInsertCommand.CommandText = insertCmdtxt.ToString();

                    for (int i = 0; i < tempTable.Rows.Count; i++)
                    {
                        for (int j = 0; j < tempTable.Columns.Count; j++)
                        {
                            myInsertCommand.Parameters[j].Value = tempTable.Rows[i][j];
                        }

                        myInsertCommand.ExecuteNonQuery();

                    }
                }
                conn.Close();

            }
            return true;
        }


        ///   <summary>  
        ///   Excel文件导出到DataSet 
        ///   </summary>         
        ///   <param   name="Excelfile">Excel文件 FullPath</param>  
        ///   <returns></returns>   

        public static DataSet ExcelFileToDataSet(string Excelfile)
        {
             string strConn;
            strConn = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + Excelfile + "; Extended Properties=Excel 8.0;";

            using (OleDbConnection conn = new OleDbConnection(strConn))
            {
                conn.Open();
                string[] res=null ;
                DataTable dt = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                if (null != dt)
                {
                    res = new string[dt.Rows.Count];

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        res[i] = dt.Rows[i]["TABLE_NAME"].ToString();
                       // res[i] = res[i].Substring(0, res[i].Length - 1);
                    }


                    DataSet retDS = new DataSet();

                    StringBuilder selectCmdtxt = new StringBuilder();

                    for (int i = 0; i < res.Length; i++)
                    {
                        DataTable tempdt = new DataTable();
                        //  "SELECT   *   FROM   ["   +SheetName   +"$"   +   StartCell   +":"+   EndCell   +   "]";   
                      

                        OleDbDataAdapter ap = new OleDbDataAdapter("SELECT   *   FROM   [" + res[i] + "]  ", conn);
                        ap.Fill(tempdt);

                        retDS.Tables.Add(tempdt);
                    }
                                       

                    conn.Close();

                    return retDS;
                }
            }
            return null;
        }
    }
}
