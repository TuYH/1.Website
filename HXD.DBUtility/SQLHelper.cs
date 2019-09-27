using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.Configuration;

namespace HXD.DBUtility
{
    public abstract class SQLHelper
    {
        #region ExecuteNoQuery

        /// <summary>
        /// 返回所影响的行数
        /// </summary>
        /// <param name="cmdText"></param>
        /// <returns></returns>
        public static int ExecuteNonQuery(string cmdText)
        {
            cmdText = cmdText.Trim();

            if (cmdText.IndexOf(' ') > 0)
                return ExecuteNonQuery(CommandType.Text, cmdText, null);
            else
                return ExecuteNonQuery(CommandType.StoredProcedure, cmdText, null);
        }
        /// <summary>
        /// 返回所影响的行数
        /// </summary>
        /// <param name="cmdText"></param>
        /// <param name="cmdParams"></param>
        /// <returns></returns>
        public static int ExecuteNonQuery(string cmdText, params SqlParameter[] cmdParams)
        {
            cmdText = cmdText.Trim();

            if (cmdText.IndexOf(' ') > 0)
                return ExecuteNonQuery(CommandType.Text, cmdText, cmdParams);
            else
                return ExecuteNonQuery(CommandType.StoredProcedure, cmdText, cmdParams);

        }
        /// <summary>
        /// 返回所影响的行数
        /// </summary>
        /// <param name="spName"></param>
        /// <param name="paramValues"></param>
        /// <returns></returns>
        public static int ExecuteNonQuery(string spName, params object[] paramValues)
        {
            if (paramValues != null && paramValues.Length > 0)
            {
                SqlParameter[] cmdParams = GetCachedParameters(spName);

                AssignParamValues(cmdParams, paramValues);

                return ExecuteNonQuery(CommandType.StoredProcedure, spName, cmdParams);
            }
            else
                return ExecuteNonQuery(CommandType.StoredProcedure, spName, null);
        }

        #endregion ExecuteNoQuery

        #region ExecuteScalar

        /// <summary>
        /// 返回第一行第一列的值
        /// </summary>
        /// <param name="cmdText"></param>
        /// <returns></returns>
        public static object ExecuteScalar(string cmdText)
        {
            cmdText = cmdText.Trim();

            if (cmdText.IndexOf(' ') > 0)
                return ExecuteScalar(CommandType.Text, cmdText, null);
            else
                return ExecuteScalar(CommandType.StoredProcedure, cmdText, null);
        }
        /// <summary>
        /// 返回第一行第一列的值
        /// </summary>
        /// <param name="cmdText"></param>
        /// <param name="cmdParams"></param>
        /// <returns></returns>
        public static object ExecuteScalar(string cmdText, params SqlParameter[] cmdParams)
        {
            cmdText = cmdText.Trim();

            if (cmdText.IndexOf(' ') > 0)
                return ExecuteScalar(CommandType.Text, cmdText, cmdParams);
            else
                return ExecuteScalar(CommandType.StoredProcedure, cmdText, cmdParams);

        }
        /// <summary>
        /// 返回第一行第一列的值
        /// </summary>
        /// <param name="spName"></param>
        /// <param name="paramValues"></param>
        /// <returns></returns>
        public static object ExecuteScalar(string spName, params object[] paramValues)
        {
            if (paramValues != null && paramValues.Length > 0)
            {
                SqlParameter[] cmdParams = GetCachedParameters(spName);

                AssignParamValues(cmdParams, paramValues);

                return ExecuteScalar(CommandType.StoredProcedure, spName, cmdParams);
            }
            else
                return ExecuteScalar(CommandType.StoredProcedure, spName, null);
        }

        #endregion ExecuteScalar

        #region ExecuteReader

        public static SqlDataReader ExecuteReader(string cmdText)
        {
            cmdText = cmdText.Trim();

            if (cmdText.IndexOf(' ') > 0)
                return ExecuteReader(CommandType.Text, cmdText, null);
            else
                return ExecuteReader(CommandType.StoredProcedure, cmdText, null);
        }

        public static SqlDataReader ExecuteReader(string cmdText, params SqlParameter[] cmdParams)
        {
            cmdText = cmdText.Trim();

            if (cmdText.IndexOf(' ') > 0)
                return ExecuteReader(CommandType.Text, cmdText, cmdParams);
            else
                return ExecuteReader(CommandType.StoredProcedure, cmdText, cmdParams);
        }

        public static SqlDataReader ExecuteReader(string spName, params object[] paramValues)
        {
            if (paramValues != null && paramValues.Length > 0)
            {
                SqlParameter[] cmdParams = GetCachedParameters(spName);

                AssignParamValues(cmdParams, paramValues);

                return ExecuteReader(CommandType.StoredProcedure, spName, cmdParams);
            }
            else
                return ExecuteReader(CommandType.StoredProcedure, spName, null);
        }

        #endregion ExecuteReader

        #region ExecuteDataset

        public static DataSet ExecuteDataset(string cmdText)
        {
            cmdText = cmdText.Trim();

            if (cmdText.IndexOf(' ') > 0)
                return ExecuteDataset(CommandType.Text, cmdText, null);
            else
                return ExecuteDataset(CommandType.StoredProcedure, cmdText, null);
        }

        public static DataSet ExecuteDataset(string cmdText, params SqlParameter[] cmdParams)
        {
            cmdText = cmdText.Trim();

            if (cmdText.IndexOf(' ') > 0)
                return ExecuteDataset(CommandType.Text, cmdText, cmdParams);
            else
                return ExecuteDataset(CommandType.StoredProcedure, cmdText, cmdParams);
        }

        public static DataSet ExecuteDataset(string spName, params object[] paramValues)
        {
            if (paramValues != null && paramValues.Length > 0)
            {
                SqlParameter[] cmdParams = GetCachedParameters(spName);

                AssignParamValues(cmdParams, paramValues);

                return ExecuteDataset(CommandType.StoredProcedure, spName, cmdParams);
            }
            else
                return ExecuteDataset(CommandType.StoredProcedure, spName, null);
        }

        #endregion ExecuteDataset

        #region Private Porperty & Method
        private static Hashtable paramCache = Hashtable.Synchronized(new Hashtable());
        private static readonly string SqlConnString = ConfigurationManager.ConnectionStrings["SqlConnString"].ConnectionString;

        private static void PrepareCommand(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, CommandType cmdType, string cmdText, SqlParameter[] cmdParms)
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();

            cmd.Connection = conn;
            cmd.CommandText = cmdText;

            if (trans != null)
                cmd.Transaction = trans;

            cmd.CommandType = cmdType;

            if (cmdParms != null)
            {
                foreach (SqlParameter parm in cmdParms)
                    cmd.Parameters.Add(parm);
            }
        }

        private static void AssignParamValues(SqlParameter[] cmdParams, object[] paramValues)
        {
            if ((cmdParams == null) || (paramValues == null))
            {
                return;
            }

            if (cmdParams.Length != paramValues.Length)
            {
                throw new ArgumentException("存储过程的变量和传递参数不匹配！！");
            }

            for (int i = 0; i < cmdParams.Length; i++)
            {
                if (paramValues[i] is IDbDataParameter)
                {
                    IDbDataParameter paramInstance = (IDbDataParameter)paramValues[i];
                    if (paramInstance.Value == null)
                    {
                        cmdParams[i].Value = DBNull.Value;
                    }
                    else
                    {
                        cmdParams[i].Value = paramInstance.Value;
                    }
                }
                else if (paramValues[i] == null)
                {
                    cmdParams[i].Value = DBNull.Value;
                }
                else
                {
                    cmdParams[i].Value = paramValues[i];
                }
            }
        }

        private static SqlParameter[] GetCachedParameters(string cacheKey)
        {
            SqlParameter[] cachedParams = (SqlParameter[])paramCache[cacheKey];

            if (cachedParams == null)
            {
                SqlParameter[] spParams = DiscoverSpParameterSet(cacheKey);
                paramCache[cacheKey] = spParams;
                cachedParams = spParams;
            }

            SqlParameter[] clonedParams = new SqlParameter[cachedParams.Length];

            for (int i = 0, j = cachedParams.Length; i < j; i++)
                clonedParams[i] = (SqlParameter)((ICloneable)cachedParams[i]).Clone();

            return clonedParams;
        }

        private static SqlParameter[] DiscoverSpParameterSet(string spName)
        {
            SqlCommand cmd = new SqlCommand();

            using (SqlConnection conn = new SqlConnection(SqlConnString))
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();

                cmd.Connection = conn;
                cmd.CommandText = spName;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlCommandBuilder.DeriveParameters(cmd);
            }

            cmd.Parameters.RemoveAt(0);

            SqlParameter[] discoveredParameters = new SqlParameter[cmd.Parameters.Count];

            cmd.Parameters.CopyTo(discoveredParameters, 0);

            foreach (SqlParameter discoveredParameter in discoveredParameters)
            {
                discoveredParameter.Value = DBNull.Value;
            }
            return discoveredParameters;
        }

        private static int ExecuteNonQuery(CommandType cmdType, string cmdText, params SqlParameter[] cmdParams)
        {

            SqlCommand cmd = new SqlCommand();

            using (SqlConnection conn = new SqlConnection(SqlConnString))
            {
                PrepareCommand(cmd, conn, null, cmdType, cmdText, cmdParams);
                int val = cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                return val;
            }
        }

        private static object ExecuteScalar(CommandType cmdType, string cmdText, params SqlParameter[] cmdParams)
        {
            SqlCommand cmd = new SqlCommand();

            using (SqlConnection connection = new SqlConnection(SqlConnString))
            {
                PrepareCommand(cmd, connection, null, cmdType, cmdText, cmdParams);
                object val = cmd.ExecuteScalar();
                cmd.Parameters.Clear();
                return val;
            }
        }

        private static SqlDataReader ExecuteReader(CommandType cmdType, string cmdText, params SqlParameter[] cmdParams)
        {
            SqlCommand cmd = new SqlCommand();
            SqlConnection conn = null;

            try
            {
                conn = new SqlConnection(SqlConnString);

                PrepareCommand(cmd, conn, null, cmdType, cmdText, cmdParams);

                SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                cmd.Parameters.Clear();
                return rdr;
            }
            catch
            {
                conn.Close();
                throw;
            }
        }

        private static DataSet ExecuteDataset(CommandType cmdType, string cmdText, params SqlParameter[] cmdParams)
        {
            SqlCommand cmd = new SqlCommand();

            using (SqlConnection connection = new SqlConnection(SqlConnString))
            {
                PrepareCommand(cmd, connection, null, cmdType, cmdText, cmdParams);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                cmd.Parameters.Clear();
                return ds;
            }
        }

        #endregion Private Property & Method
    }
}
