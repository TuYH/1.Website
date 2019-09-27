using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using HXD.ModelField.Model;
using HXD.ModelField.Common;
using HXD.Common;
using HXD.DBUtility;

namespace HXD.ModelField.SQLServerDAL
{
    public class Field
    {
        /// <summary>
        /// ²åÈë×Ö¶Î
        /// </summary>
        /// <param name="Val"></param>
        public void InsertField(HXD.ModelField.Model.Field Val)
        {
            string Sql = "";
            switch (Val.Type)
            {
                case "SingleLine":
                    Sql = "ALTER TABLE " + Val.TableName + " ADD [" + Val.Name + "] [NVARCHAR] (" + Val.MaxLength + ") NULL DEFAULT ('" + Val.Default + "')";
                    break;
                case "Password":
                    Sql = "ALTER TABLE " + Val.TableName + " ADD [" + Val.Name + "] [NVARCHAR] (" + Val.MaxLength + ") NULL DEFAULT ('" + Val.Default + "')";
                    break;
                case "MultiLine":
                    Sql = "ALTER TABLE " + Val.TableName + " ADD [" + Val.Name + "] [NTEXT] NULL DEFAULT ('" + Val.Default + "')";
                    break;
                case "Editor":
                    Sql = "ALTER TABLE " + Val.TableName + " ADD [" + Val.Name + "] [NTEXT] NULL DEFAULT ('" + Val.Default + "')";
                    break;
                case "Select":
                    Sql = "ALTER TABLE " + Val.TableName + " ADD [" + Val.Name + "] [NVARCHAR] (4000) NULL DEFAULT ('" + Val.Default + "')";
                    break;
                case "Number":
                    Sql = "ALTER TABLE " + Val.TableName + " ADD [" + Val.Name + "] [DECIMAL] (18, " + Val.Bit + ") NULL DEFAULT (" + Val.Default + ")";
                    break;
                case "DateTime":
                    Sql = "ALTER TABLE " + Val.TableName + " ADD [" + Val.Name + "] [DATETIME] NULL DEFAULT (" + Val.Default + ")";
                    break;
                case "Image":
                    Sql = "ALTER TABLE " + Val.TableName + " ADD [" + Val.Name + "] [NVARCHAR] (1200) NULL DEFAULT ('" + Val.Default + "')";
                    break;
                case "File":
                    Sql = "ALTER TABLE " + Val.TableName + " ADD [" + Val.Name + "] [NVARCHAR] (1200) NULL DEFAULT ('" + Val.Default + "')";
                    break;
                case "BatchImage":
                    Sql = "ALTER TABLE " + Val.TableName + " ADD [" + Val.Name + "] [TEXT] NULL DEFAULT ('" + Val.Default + "')";
                    break;
                case "BatchFile":
                    Sql = "ALTER TABLE " + Val.TableName + " ADD [" + Val.Name + "] [TEXT] NULL DEFAULT ('" + Val.Default + "')";
                    break;
                case "OtherMenu":
                    Sql = "ALTER TABLE " + Val.TableName + " ADD [" + Val.Name + "] [INT] NULL DEFAULT ('" + Val.Default + "')";
                    break;
                case "Provinces":
                    Sql = "ALTER TABLE " + Val.TableName + " ADD [" + Val.Name + "] [NVARCHAR] (200) NULL DEFAULT ('')";
                    SQLHelper.ExecuteNonQuery("FieldCreate", Val.TableName, Val.Name + "_City", "ALTER TABLE " + Val.TableName + " ADD [" + Val.Name + "_City] [NVARCHAR] (200) NULL DEFAULT ('')");
                    break;
                case "Increment":
                    Sql = "ALTER TABLE " + Val.TableName + " ADD [" + Val.Name + "] [NTEXT] NULL DEFAULT ('" + Val.Default + "')";
                    break;
            }
            if (!String.IsNullOrEmpty(Sql))
            {
                SQLHelper.ExecuteNonQuery("FieldCreate", Val.TableName, Val.Name, Sql);
            }
        }

        /// <summary>
        /// ÐÞ¸Ä×Ö¶Î
        /// </summary>
        /// <param name="Val"></param>
        public void UpdateField(HXD.ModelField.Model.Field Val)
        {
            string Sql = "";
            switch (Val.Type)
            {
                case "SingleLine":
                    Sql = "ALTER TABLE " + Val.TableName + " ALTER COLUMN [" + Val.Name + "] [NVARCHAR] (" + Val.MaxLength + ") NULL";
                    Sql += " ALTER TABLE " + Val.TableName + " ADD CONSTRAINT DF_" + Val.TableName + "_" + Val.Name + " DEFAULT ('" + Val.Default + "') FOR [" + Val.Name + "]";
                    break;
                case "Password":
                    Sql = "ALTER TABLE " + Val.TableName + " ALTER COLUMN [" + Val.Name + "] [NVARCHAR] (" + Val.MaxLength + ") NULL";
                    Sql += " ALTER TABLE " + Val.TableName + " ADD CONSTRAINT DF_" + Val.TableName + "_" + Val.Name + " DEFAULT ('" + Val.Default + "') FOR [" + Val.Name + "]";
                    break;
                case "MultiLine":
                    Sql = "ALTER TABLE " + Val.TableName + " ADD CONSTRAINT DF_" + Val.TableName + "_" + Val.Name + " DEFAULT ('" + Val.Default + "') FOR [" + Val.Name + "]";
                    break;
                case "Editor":
                    Sql = "ALTER TABLE " + Val.TableName + " ADD CONSTRAINT DF_" + Val.TableName + "_" + Val.Name + " DEFAULT ('" + Val.Default + "') FOR [" + Val.Name + "]";
                    break;
                case "Select":
                    Sql = "ALTER TABLE " + Val.TableName + " ADD CONSTRAINT DF_" + Val.TableName + "_" + Val.Name + " DEFAULT ('" + Val.Default + "') FOR [" + Val.Name + "]";
                    break;
                case "Number":
                    Sql = "ALTER TABLE " + Val.TableName + " ALTER COLUMN [" + Val.Name + "] [DECIMAL] (18, " + Val.Bit + ") NULL";
                    Sql += " ALTER TABLE " + Val.TableName + " ADD CONSTRAINT DF_" + Val.TableName + "_" + Val.Name + " DEFAULT (" + Val.Default + ") FOR [" + Val.Name + "]";
                    break;
                case "DateTime":
                    Sql = "ALTER TABLE " + Val.TableName + " ADD CONSTRAINT DF_" + Val.TableName + "_" + Val.Name + " DEFAULT (" + Val.Default + ") FOR [" + Val.Name + "]";
                    break;
                case "Image":
                    Sql = "ALTER TABLE " + Val.TableName + " ADD CONSTRAINT DF_" + Val.TableName + "_" + Val.Name + " DEFAULT ('" + Val.Default + "') FOR [" + Val.Name + "]";
                    break;
                case "File":
                    Sql = "ALTER TABLE " + Val.TableName + " ADD CONSTRAINT DF_" + Val.TableName + "_" + Val.Name + " DEFAULT ('" + Val.Default + "') FOR [" + Val.Name + "]";
                    break;
                case "BatchImage":
                    Sql = "ALTER TABLE " + Val.TableName + " ADD CONSTRAINT DF_" + Val.TableName + "_" + Val.Name + " DEFAULT ('" + Val.Default + "') FOR [" + Val.Name + "]";
                    break;
                case "BatchFile":
                    Sql = "ALTER TABLE " + Val.TableName + " ADD CONSTRAINT DF_" + Val.TableName + "_" + Val.Name + " DEFAULT ('" + Val.Default + "') FOR [" + Val.Name + "]";
                    break;
                case "OtherMenu":
                    Sql = "ALTER TABLE " + Val.TableName + " ADD CONSTRAINT DF_" + Val.TableName + "_" + Val.Name + " DEFAULT ('" + Val.Default + "') FOR [" + Val.Name + "]";
                    break;
                case "Provinces":
                    Sql = "ALTER TABLE " + Val.TableName + " ADD CONSTRAINT DF_" + Val.TableName + "_" + Val.Name + " DEFAULT ('') FOR [" + Val.Name + "]";
                    SQLHelper.ExecuteNonQuery("FieldCreate", Val.TableName, Val.Name + "_City", "ALTER TABLE " + Val.TableName + " ADD CONSTRAINT DF_" + Val.TableName + "_" + Val.Name + "_City DEFAULT ('') FOR [" + Val.Name + "_City]");
                    break;
                case "Increment":
                    Sql = "ALTER TABLE " + Val.TableName + " ADD CONSTRAINT DF_" + Val.TableName + "_" + Val.Name + " DEFAULT ('" + Val.Default + "') FOR [" + Val.Name + "]";
                    break;
            }
            if (!String.IsNullOrEmpty(Sql))
            {
                SQLHelper.ExecuteNonQuery("FieldCreate", Val.TableName, Val.Name, Sql);
            }
        }

    }
}
