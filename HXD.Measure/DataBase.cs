using System;
using System.Data;
using System.Data.SqlClient;

namespace HXD.Measure
{
    public class DataBase : IDisposable
    {
        private SqlConnection con;
        public DataBase()
        {
            this.con = new SqlConnection(Config.ConnectionString);
        }
        public DataBase(string connectionString)
        {
            this.con = new SqlConnection(connectionString);
        }
        public int RunProc(string procName)
        {
            SqlCommand cmd = CreateCommand(procName, null, 4);
            cmd.ExecuteNonQuery();
            this.Close();
            return (int)cmd.Parameters["ReturnValue"].Value;

        }
        public int RunProc(string procName, SqlParameter[] prams)
        {
            SqlCommand cmd = this.CreateCommand(procName, prams, 4);
            cmd.ExecuteNonQuery();
            this.Close();
            return (int)cmd.Parameters["ReturnValue"].Value;
        }
        public int RunProc(string procName, out DataSet dataSet)
        {
            dataSet = new DataSet();
            SqlCommand cmd = this.CreateCommand(procName, null, 4);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dataSet);
            this.Close();
            return (int)cmd.Parameters["ReturnValue"].Value;
        }
        public int RunProc(string procName, SqlParameter[] prams, out DataSet dataSet)
        {
            dataSet = new DataSet();
            SqlCommand cmd = this.CreateCommand(procName, prams, 4);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dataSet);
            this.Close();
            return (int)cmd.Parameters["ReturnValue"].Value;
        }
        //public void RunProc(string procName, out SqlDataReader dataReader)
        //{
        //    SqlCommand cmd = CreateCommand(procName, null, 4);

        //}
        public void RunProc(string procName, SqlParameter[] prams, out SqlDataReader dataReader)
        {
            SqlCommand cmd = this.CreateCommand(procName, prams, 4);
            dataReader = cmd.ExecuteReader();
        }
        public void RunProc(string procName, SqlParameter[] prams, out object[][] objects, int currentPage, int pageSize, ref int numResults)
        {
            SqlDataReader reader;
            this.RunProc(procName, prams, out reader);
            this.GetAPageData(currentPage, pageSize, reader, out numResults, out objects);
        }
        public void ExecuteSql(string strSQL, SqlParameter[] prams)
        {
            SqlCommand cmd = this.CreateCommand(strSQL, prams, 1);
            cmd.ExecuteNonQuery();
            this.Close();
        }
        public void ExecuteSql(string strSQL, SqlParameter[] prams, out DataSet dataSet)
        {
            SqlCommand cmd = CreateCommand(strSQL,prams,1);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            dataSet = new DataSet();
            da.Fill(dataSet);
            this.Close();
        }

        private SqlCommand CreateCommand(string strSQL, SqlParameter[] prams, int p)
        {
            throw new NotImplementedException();
        }
        public void ExecuteSql(string strSQL, SqlParameter[] prams, out SqlDataReader dataReader)
        {
            SqlCommand cmd = CreateCommand(strSQL, prams, 1);
            dataReader = cmd.ExecuteReader();
        }
        public object ExecuteSqlScalar(string strSQL, SqlParameter[] prams)
        {
            SqlCommand cmd = CreateCommand(strSQL, prams, 1);
            object res = cmd.ExecuteScalar();
            this.Close();
            return res;
        }
        public void ExecuteSql(string strSQL, SqlParameter[] prams, out object[][] objects, int currentPage, int pageSize, out int numResults)
        {
            SqlDataReader reader;
            this.ExecuteSql(strSQL, prams, out reader);
            this.GetAPageData(currentPage, pageSize, reader, out numResults, out objects);
        }
        public void ExecuteSql(string[] strSQLs)
        {
            SqlCommand myCmd = new SqlCommand();
            int i = strSQLs.Length;
            this.Open();
            SqlTransaction myTrans = this.con.BeginTransaction();
            try
            {
               
                myCmd.Connection=this.con;
                myCmd.Transaction=myTrans;
                for (int j = 0; j < strSQLs.Length; j++)
                {
                    string str = strSQLs[j];
                    myCmd.CommandText=str;
                    myCmd.ExecuteNonQuery();
                }
                myTrans.Commit();
            }
            catch (SqlException e)
            {
                myTrans.Rollback();
                throw new Exception(e.Message);
            }
            finally
            {
                myCmd.Dispose();
                this.Close();
            }
        }
        private void GetAPageData(int currentPage, int pageSize, SqlDataReader reader, out int numResults, out object[][] objects)
        {
            numResults = 0;
            int index = 0;
            object[][] results = new object[pageSize][];
            int start = (currentPage - 1) * pageSize;
            if (start < 0)
            {
                start = 0;
            }
            for (int i = 0; i < start; i++)
            {
                if (reader.Read())
                {
                    numResults++;
                }
            }
            while (reader.Read())
            {
                if (index < pageSize)
                {
                    results[index] = new object[reader.GetSchemaTable().Columns.Count];
                    reader.GetValues(results[index++]);
                }
                numResults++;
            }
            if (index == pageSize)
            {
                objects = results;
            }
            else
            {
                object[][] results2 = new object[index][];
                for (int j = 0; j < index; j++)
                {
                    results2[j] = new object[reader.GetSchemaTable().Columns.Count];
                }
                Array.Copy(results, results2, index);
                objects = results2;
            }
            reader.Close();
        }
        private SqlCommand CreateCommand(string cmdText, SqlParameter[] prams, CommandType cmdType)
        {
            this.Open();
            SqlCommand cmd = new SqlCommand(cmdText, this.con);
            cmd.CommandType = cmdType;
            //cmd.CommandType(cmdType);
            if (prams != null)
            {
                for (int i = 0; i < prams.Length; i++)
                {
                    SqlParameter parameter = prams[i];
                    
                    cmd.Parameters.Add(parameter);
                }
            }
            if (int.Parse(cmdType.ToString()) == 4)
            {
                //cmd.Parameters.Add(new SqlParameter("ReturnValue", "8", 4, 6, false, 0, 0, string.Empty, 1536, null));
            }
            return cmd;
        }
        private void Open()
        {
            if (this.con == null)
            {
                this.con = new SqlConnection(Config.ConnectionString);
                this.con.Open();
            }
            else
            {
                if (this.con.State==ConnectionState.Closed)
                {
                    this.con.Open();
                }
            }
        }
        public void Close()
        {
            if (this.con != null)
            {
                this.con.Close();
            }
        }
        public void Dispose()
        {
            if (this.con != null)
            {
                this.con.Dispose();
                this.con = null;
            }
        }
        public SqlParameter MakeInParam(string ParamName, SqlDbType DbType, int Size, object Value)
        {
            return MakeParam(ParamName, DbType, Size, 1, Value);
        }

        private SqlParameter MakeParam(string ParamName, SqlDbType DbType, int Size, int p, object Value)
        {
            throw new NotImplementedException();
        }
        public SqlParameter MakeOutParam(string ParamName, SqlDbType DbType, int Size)
        {
            return MakeParam(ParamName, DbType, Size, 2, null);
            
        }
        //protected SqlParameter bd()
        //{
        //    return "123";
        //}
        protected SqlParameter MakeParam(string ParamName, SqlDbType DbType, int Size, ParameterDirection Direction, object Value)
        {
            SqlParameter param;
            if (Size > 0)
            {
                param = new SqlParameter(ParamName, DbType, Size);
            }
            else
            {
                param = new SqlParameter(ParamName, DbType);
            }
            //param.Direction(Direction);
            param.Direction = Direction;
            if (int.Parse(Direction.ToString()) != 2 || Value != null)
            {
                param.Value=Value;
            }
            return param;
        }

        internal SqlParameter MakeInParam(string p, int p_2, int p_3, int paperId)
        {
            throw new NotImplementedException();
        }

        internal SqlParameter MakeInParam(string p, int p_2, int p_3, string filter)
        {
            throw new NotImplementedException();
        }
    }
}
