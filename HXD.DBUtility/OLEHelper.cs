using System;
using System.Data;
using System.Web;
using System.Collections;
using System.Configuration;
using System.Data.OleDb;

namespace HXD.DBUtility
{
    public abstract class OLEHelper
    {
        //数据库连接字符串
        private static string AccessPath = "Data Source=" + HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings["AccessPath"].ToString());
        private static string ConnectionString = ConfigurationManager.ConnectionStrings["OledbConnString"].ConnectionString + AccessPath;

        #region ExecuteNonQuery
        /// <summary>
        /// 根据给定的sql语句执行OleDbCommand命令
        /// </summary>
        /// <param name="cmdText">要执行的sql语句</param>
        /// <returns>一个int类型的返回值，代表此操作所影响的行数</returns>
        public static int ExecuteNonQuery(string cmdText)
        {
            using (OleDbConnection connection = new OleDbConnection(ConnectionString))
            {
                OleDbCommand cmd = new OleDbCommand(cmdText, connection);
                cmd.Connection.Open();
                return cmd.ExecuteNonQuery();
                //参照了MSDN，这里不用显示关闭连接
            }
        }

        /// <summary>
        /// 根据给定的sql语句执行OleDbCommand命令
        /// </summary>
        /// <param name="cmdText">要执行的sql语句</param>
        /// <param name="cmdParams">sql语句中的OleDbParameter参数数组</param>
        /// <returns>一个int类型的返回值，代表此操作所影响的行数</returns>
        public static int ExecuteNonQuery(string cmdText, params OleDbParameter[] cmdParams)
        {
            using (OleDbConnection connection = new OleDbConnection(ConnectionString))
            {
                OleDbCommand cmd = new OleDbCommand();
                PrepareCommand(cmd, connection, null, cmdText, cmdParams);
                int val = cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                return val;
                //参照了MSDN，这里不用显示关闭连接
            }
        }

        /// <summary>
        /// 根据给定的sql语句用事务的方式执行OleDbCommand命令
        /// </summary>
        /// <param name="cmdText">要执行的sql语句</param>
        /// <param name="trans">事物参数</param>
        /// <returns></returns>
        public static int ExecuteNonQuery(string cmdText, OleDbTransaction trans)
        {
            OleDbCommand cmd = new OleDbCommand(cmdText, trans.Connection);
            cmd.Transaction = trans;
            if (trans.Connection.State != ConnectionState.Open)
            {
                trans.Connection.Open();
            }
            return cmd.ExecuteNonQuery();
        }

        /// <summary>
        /// 根据给定的sql语句用事务的方式执行OleDbCommand命令
        /// </summary>
        /// <param name="cmdText">要执行的sql语句</param>
        /// <param name="trans">事物参数</param>
        /// <param name="cmdParams">sql语句中的OleDbParameter参数数组</param>
        /// <returns></returns>
        public static int ExecuteNonQuery(string cmdText, OleDbTransaction trans, params OleDbParameter[] cmdParams)
        {
            OleDbCommand cmd = new OleDbCommand();
            PrepareCommand(cmd, trans.Connection, trans, cmdText, cmdParams);
            int val = cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            return val;
        }
        #endregion

        #region ExecuteReader
        /// <summary>
        /// 根据给定的sql语句执行OleDbCommand命令，这里应该是个select查询多行的语句。
        /// </summary>
        /// <param name="cmdText">要执行的sql语句</param>
        /// <returns>返回一个包含查询结果的OleDbDataReader对象</returns>
        public static OleDbDataReader ExecuteReader(string cmdText)
        {
            OleDbConnection connection = new OleDbConnection(ConnectionString);
            OleDbCommand cmd = new OleDbCommand(cmdText, connection);

            //在这里用了try/catch，微软工程师们的解释是：如果cmd.ExecuteReader方法发生异常，而我们想关闭conn连接，
            //因为不存在DataReader，所以CommandBehavior.CloseConnection也将失效。
            try
            {
                cmd.Connection.Open();
                return cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch
            {
                connection.Close();
                throw;
            }
        }

        /// <summary>
        /// 根据给定的sql语句执行OleDbCommand命令，这里应该是个select查询多行的语句。
        /// </summary>
        /// <param name="cmdText">要执行的sql语句</param>
        /// <param name="cmdParams">sql语句中的OleDbParameter参数数组</param>
        /// <returns>返回一个包含查询结果的OleDbDataReader对象</returns>
        public static OleDbDataReader ExecuteReader(string cmdText, params OleDbParameter[] cmdParams)
        {
            OleDbConnection connection = new OleDbConnection(ConnectionString);
            OleDbCommand cmd = new OleDbCommand();


            //在这里用了try/catch，微软工程师们的解释是：如果cmd.ExecuteReader方法发生异常，而我们想关闭conn连接，
            //因为不存在DataReader，所以CommandBehavior.CloseConnection也将失效。
            try
            {
                PrepareCommand(cmd, connection, null, cmdText, cmdParams);
                OleDbDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                cmd.Parameters.Clear();
                return rdr;
            }
            catch
            {
                connection.Close();
                throw;
            }
        }
        #endregion

        #region ExecuteDataset
        public static DataSet ExecuteDataset(string cmdText)
        {
            cmdText = cmdText.Trim();

            if (cmdText.IndexOf(' ') > 0)
                return ExecuteDataset(cmdText, null);
            else
                return ExecuteDataset(cmdText, null);
        }

        public static DataSet ExecuteDataset(string cmdText, params OleDbParameter[] cmdParams)
        {
            OleDbCommand cmd = new OleDbCommand();

            using (OleDbConnection connection = new OleDbConnection(ConnectionString))
            {
                PrepareCommand(cmd, connection, null, cmdText, cmdParams);
                OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                cmd.Parameters.Clear();
                return ds;
            }
        }
        #endregion

        #region ExecuteScalar
        /// <summary>
        /// 根据给定sql语句执行OleDbCommand命令，返回结果的第一行的第一列。
        /// </summary>
        /// <param name="cmdText">要执行的sql语句</param>
        /// <returns>返回一个object类型的值，应该可以用Convert.To{Type}转换为sql语句中对应的字段的类型的值。</returns>
        public static object ExecuteScalar(string cmdText)
        {
            using (OleDbConnection connection = new OleDbConnection(ConnectionString))
            {
                OleDbCommand cmd = new OleDbCommand(cmdText, connection);
                cmd.Connection.Open();
                return cmd.ExecuteScalar();
                //参照了MSDN，这里不用显示关闭连接
            }
        }

        /// <summary>
        /// 根据给定sql语句执行OleDbCommand命令，返回结果的第一行的第一列。
        /// </summary>
        /// <param name="cmdText">要执行的sql语句</param>
        /// <param name="cmdParams">sql语句中的OleDbParameter参数数组</param>
        /// <returns>返回一个object类型的值，应该可以用Convert.To{Type}转换为sql语句中对应的字段的类型的值。</returns>
        public static object ExecuteScalar(string cmdText, params OleDbParameter[] cmdParams)
        {
            using (OleDbConnection connection = new OleDbConnection(ConnectionString))
            {
                OleDbCommand cmd = new OleDbCommand();
                PrepareCommand(cmd, connection, null, cmdText, cmdParams);
                object val = cmd.ExecuteScalar();
                cmd.Parameters.Clear();
                return val;
                //参照了MSDN，这里不用显示关闭连接
            }
        }
        #endregion

        ///<summary>
        ///为要执行的命令添加sql语句的参数，并打开数据库连接。本方法只在此类中使用，所以修饰符用private。
        ///</summary>
        ///<param name="cmd">OleDbCommand对象</param>
        ///<param name="conn">OleDbConnection对象</param>
        ///<param name="cmdText">OleDbCommand要执行的sql语句</param>
        ///<param name="SqlParameter">OleDbCommand要执行的sql语句里的对应的参数</param>
        private static void PrepareCommand(OleDbCommand cmd, OleDbConnection connection, OleDbTransaction trans, string cmdText, params OleDbParameter[] cmdParams)
        {
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }

            cmd.Connection = connection;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = cmdText;

            if (trans != null)
            {
                cmd.Transaction = trans;
            }

            if (cmdParams != null)
            {
                foreach (OleDbParameter param in cmdParams)
                {
                    cmd.Parameters.Add(param);
                }
            }
        }
    }
}
