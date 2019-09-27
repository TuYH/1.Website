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
        //���ݿ������ַ���
        private static string AccessPath = "Data Source=" + HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings["AccessPath"].ToString());
        private static string ConnectionString = ConfigurationManager.ConnectionStrings["OledbConnString"].ConnectionString + AccessPath;

        #region ExecuteNonQuery
        /// <summary>
        /// ���ݸ�����sql���ִ��OleDbCommand����
        /// </summary>
        /// <param name="cmdText">Ҫִ�е�sql���</param>
        /// <returns>һ��int���͵ķ���ֵ������˲�����Ӱ�������</returns>
        public static int ExecuteNonQuery(string cmdText)
        {
            using (OleDbConnection connection = new OleDbConnection(ConnectionString))
            {
                OleDbCommand cmd = new OleDbCommand(cmdText, connection);
                cmd.Connection.Open();
                return cmd.ExecuteNonQuery();
                //������MSDN�����ﲻ����ʾ�ر�����
            }
        }

        /// <summary>
        /// ���ݸ�����sql���ִ��OleDbCommand����
        /// </summary>
        /// <param name="cmdText">Ҫִ�е�sql���</param>
        /// <param name="cmdParams">sql����е�OleDbParameter��������</param>
        /// <returns>һ��int���͵ķ���ֵ������˲�����Ӱ�������</returns>
        public static int ExecuteNonQuery(string cmdText, params OleDbParameter[] cmdParams)
        {
            using (OleDbConnection connection = new OleDbConnection(ConnectionString))
            {
                OleDbCommand cmd = new OleDbCommand();
                PrepareCommand(cmd, connection, null, cmdText, cmdParams);
                int val = cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                return val;
                //������MSDN�����ﲻ����ʾ�ر�����
            }
        }

        /// <summary>
        /// ���ݸ�����sql���������ķ�ʽִ��OleDbCommand����
        /// </summary>
        /// <param name="cmdText">Ҫִ�е�sql���</param>
        /// <param name="trans">�������</param>
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
        /// ���ݸ�����sql���������ķ�ʽִ��OleDbCommand����
        /// </summary>
        /// <param name="cmdText">Ҫִ�е�sql���</param>
        /// <param name="trans">�������</param>
        /// <param name="cmdParams">sql����е�OleDbParameter��������</param>
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
        /// ���ݸ�����sql���ִ��OleDbCommand�������Ӧ���Ǹ�select��ѯ���е���䡣
        /// </summary>
        /// <param name="cmdText">Ҫִ�е�sql���</param>
        /// <returns>����һ��������ѯ�����OleDbDataReader����</returns>
        public static OleDbDataReader ExecuteReader(string cmdText)
        {
            OleDbConnection connection = new OleDbConnection(ConnectionString);
            OleDbCommand cmd = new OleDbCommand(cmdText, connection);

            //����������try/catch��΢����ʦ�ǵĽ����ǣ����cmd.ExecuteReader���������쳣����������ر�conn���ӣ�
            //��Ϊ������DataReader������CommandBehavior.CloseConnectionҲ��ʧЧ��
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
        /// ���ݸ�����sql���ִ��OleDbCommand�������Ӧ���Ǹ�select��ѯ���е���䡣
        /// </summary>
        /// <param name="cmdText">Ҫִ�е�sql���</param>
        /// <param name="cmdParams">sql����е�OleDbParameter��������</param>
        /// <returns>����һ��������ѯ�����OleDbDataReader����</returns>
        public static OleDbDataReader ExecuteReader(string cmdText, params OleDbParameter[] cmdParams)
        {
            OleDbConnection connection = new OleDbConnection(ConnectionString);
            OleDbCommand cmd = new OleDbCommand();


            //����������try/catch��΢����ʦ�ǵĽ����ǣ����cmd.ExecuteReader���������쳣����������ر�conn���ӣ�
            //��Ϊ������DataReader������CommandBehavior.CloseConnectionҲ��ʧЧ��
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
        /// ���ݸ���sql���ִ��OleDbCommand������ؽ���ĵ�һ�еĵ�һ�С�
        /// </summary>
        /// <param name="cmdText">Ҫִ�е�sql���</param>
        /// <returns>����һ��object���͵�ֵ��Ӧ�ÿ�����Convert.To{Type}ת��Ϊsql����ж�Ӧ���ֶε����͵�ֵ��</returns>
        public static object ExecuteScalar(string cmdText)
        {
            using (OleDbConnection connection = new OleDbConnection(ConnectionString))
            {
                OleDbCommand cmd = new OleDbCommand(cmdText, connection);
                cmd.Connection.Open();
                return cmd.ExecuteScalar();
                //������MSDN�����ﲻ����ʾ�ر�����
            }
        }

        /// <summary>
        /// ���ݸ���sql���ִ��OleDbCommand������ؽ���ĵ�һ�еĵ�һ�С�
        /// </summary>
        /// <param name="cmdText">Ҫִ�е�sql���</param>
        /// <param name="cmdParams">sql����е�OleDbParameter��������</param>
        /// <returns>����һ��object���͵�ֵ��Ӧ�ÿ�����Convert.To{Type}ת��Ϊsql����ж�Ӧ���ֶε����͵�ֵ��</returns>
        public static object ExecuteScalar(string cmdText, params OleDbParameter[] cmdParams)
        {
            using (OleDbConnection connection = new OleDbConnection(ConnectionString))
            {
                OleDbCommand cmd = new OleDbCommand();
                PrepareCommand(cmd, connection, null, cmdText, cmdParams);
                object val = cmd.ExecuteScalar();
                cmd.Parameters.Clear();
                return val;
                //������MSDN�����ﲻ����ʾ�ر�����
            }
        }
        #endregion

        ///<summary>
        ///ΪҪִ�е��������sql���Ĳ������������ݿ����ӡ�������ֻ�ڴ�����ʹ�ã��������η���private��
        ///</summary>
        ///<param name="cmd">OleDbCommand����</param>
        ///<param name="conn">OleDbConnection����</param>
        ///<param name="cmdText">OleDbCommandҪִ�е�sql���</param>
        ///<param name="SqlParameter">OleDbCommandҪִ�е�sql�����Ķ�Ӧ�Ĳ���</param>
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
