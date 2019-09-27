using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Web;

namespace HXD.SQLServerDAL
{
public  class tb_U_Info
	{
		

		/// <summary>
		/// 增加一条数据
		/// </summary>
        public bool Add(HXD.Model.tb_U_Info model)
		{
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tb_U_Info(");
            strSql.Append("ClassId,IsTop,IsStatus,IsElite,IsHot,Sort,Title,LookPwd,Note,Content,Year,Conut,PostTime,Author,InfoFrom,Title1,Url,InfoEditor,AboutTag,Photo,CreateUsers,CreateTimes,CreateIp,EditUsers,EditTimes,EditIp,KeyWords,Description,fenlei,mp3,f_leibie,p_gl,city_City,city,z_time,jd_time,ms_time,gw_time,zb_time,U_id)");
            strSql.Append(" values (");
            strSql.Append("@ClassId,@IsTop,@IsStatus,@IsElite,@IsHot,@Sort,@Title,@LookPwd,@Note,@Content,@Year,@Conut,@PostTime,@Author,@InfoFrom,@Title1,@Url,@InfoEditor,@AboutTag,@Photo,@CreateUsers,@CreateTimes,@CreateIp,@EditUsers,@EditTimes,@EditIp,@KeyWords,@Description,@fenlei,@mp3,@f_leibie,@p_gl,@city_City,@city,@z_time,@jd_time,@ms_time,@gw_time,@zb_time,@U_id)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@ClassId", SqlDbType.Int,4),
					new SqlParameter("@IsTop", SqlDbType.Bit,1),
					new SqlParameter("@IsStatus", SqlDbType.Bit,1),
					new SqlParameter("@IsElite", SqlDbType.Bit,1),
					new SqlParameter("@IsHot", SqlDbType.Bit,1),
					new SqlParameter("@Sort", SqlDbType.Int,4),
					new SqlParameter("@Title", SqlDbType.NVarChar,200),
					new SqlParameter("@LookPwd", SqlDbType.NVarChar,20),
					new SqlParameter("@Note", SqlDbType.NText),
					new SqlParameter("@Content", SqlDbType.NText),
					new SqlParameter("@Year", SqlDbType.NVarChar,4000),
					new SqlParameter("@Conut", SqlDbType.Decimal,9),
					new SqlParameter("@PostTime", SqlDbType.DateTime),
					new SqlParameter("@Author", SqlDbType.NVarChar,50),
					new SqlParameter("@InfoFrom", SqlDbType.NVarChar,50),
					new SqlParameter("@Title1", SqlDbType.NVarChar,200),
					new SqlParameter("@Url", SqlDbType.NVarChar,300),
					new SqlParameter("@InfoEditor", SqlDbType.NVarChar,50),
					new SqlParameter("@AboutTag", SqlDbType.NVarChar,50),
					new SqlParameter("@Photo", SqlDbType.NVarChar,1200),
					new SqlParameter("@CreateUsers", SqlDbType.NVarChar,200),
					new SqlParameter("@CreateTimes", SqlDbType.DateTime),
					new SqlParameter("@CreateIp", SqlDbType.NVarChar,200),
					new SqlParameter("@EditUsers", SqlDbType.NVarChar,200),
					new SqlParameter("@EditTimes", SqlDbType.DateTime),
					new SqlParameter("@EditIp", SqlDbType.NVarChar,200),
					new SqlParameter("@KeyWords", SqlDbType.NVarChar,200),
					new SqlParameter("@Description", SqlDbType.NText),
					new SqlParameter("@fenlei", SqlDbType.NVarChar,4000),
					new SqlParameter("@mp3", SqlDbType.NVarChar,1200),
					new SqlParameter("@f_leibie", SqlDbType.Int,4),
					new SqlParameter("@p_gl", SqlDbType.Int,4),
					new SqlParameter("@city_City", SqlDbType.NVarChar,200),
					new SqlParameter("@city", SqlDbType.NVarChar,200),
                    new SqlParameter("@z_time", SqlDbType.NVarChar,200),
                    new SqlParameter("@jd_time", SqlDbType.NVarChar,200),
                    new SqlParameter("@ms_time", SqlDbType.NVarChar,200),
                    new SqlParameter("@gw_time", SqlDbType.NVarChar,200),
                    new SqlParameter("@zb_time", SqlDbType.NVarChar,200),
					new SqlParameter("@U_id", SqlDbType.Int,4)};
            parameters[0].Value = model.ClassId;
            parameters[1].Value = model.IsTop;
            parameters[2].Value = model.IsStatus;
            parameters[3].Value = model.IsElite;
            parameters[4].Value = model.IsHot;
            parameters[5].Value = model.Sort;
            parameters[6].Value = model.Title;
            parameters[7].Value = model.LookPwd;
            parameters[8].Value = model.Note;
            parameters[9].Value = model.Content;
            parameters[10].Value = model.Year;
            parameters[11].Value = model.Conut;
            parameters[12].Value = model.PostTime;
            parameters[13].Value = model.Author;
            parameters[14].Value = model.InfoFrom;
            parameters[15].Value = model.Title1;
            parameters[16].Value = model.Url;
            parameters[17].Value = model.InfoEditor;
            parameters[18].Value = model.AboutTag;
            parameters[19].Value = model.Photo;
            parameters[20].Value = model.CreateUsers;
            parameters[21].Value = model.CreateTimes;
            parameters[22].Value = model.CreateIp;
            parameters[23].Value = model.EditUsers;
            parameters[24].Value = model.EditTimes;
            parameters[25].Value = model.EditIp;
            parameters[26].Value = model.KeyWords;
            parameters[27].Value = model.Description;
            parameters[28].Value = model.fenlei;
            parameters[29].Value = model.mp3;
            parameters[30].Value = model.f_leibie;
            parameters[31].Value = model.p_gl;
            parameters[32].Value = model.city_City;
            parameters[33].Value = model.city;
            parameters[34].Value = model.z_time;
            parameters[35].Value = model.jd_time;
            parameters[36].Value = model.ms_time;
            parameters[37].Value = model.gw_time;
            parameters[38].Value = model.zb_time;
            parameters[39].Value = model.U_id;

            return HXD.DBUtility.SQLHelper.ExecuteNonQuery(strSql.ToString(), parameters) == 1;
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(HXD.Model.tb_U_Info model)
		{
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_U_Info set ");
            strSql.Append("ClassId=@ClassId,");
            strSql.Append("IsTop=@IsTop,");
            strSql.Append("IsStatus=@IsStatus,");
            strSql.Append("IsElite=@IsElite,");
            strSql.Append("IsHot=@IsHot,");
            strSql.Append("Sort=@Sort,");
            strSql.Append("Title=@Title,");
            strSql.Append("LookPwd=@LookPwd,");
            strSql.Append("Note=@Note,");
            strSql.Append("Content=@Content,");
            strSql.Append("Year=@Year,");
            strSql.Append("Conut=@Conut,");
            strSql.Append("PostTime=@PostTime,");
            strSql.Append("Author=@Author,");
            strSql.Append("InfoFrom=@InfoFrom,");
            strSql.Append("Title1=@Title1,");
            strSql.Append("Url=@Url,");
            strSql.Append("InfoEditor=@InfoEditor,");
            strSql.Append("AboutTag=@AboutTag,");
            strSql.Append("Photo=@Photo,");
            strSql.Append("CreateUsers=@CreateUsers,");
            strSql.Append("CreateTimes=@CreateTimes,");
            strSql.Append("CreateIp=@CreateIp,");
            strSql.Append("EditUsers=@EditUsers,");
            strSql.Append("EditTimes=@EditTimes,");
            strSql.Append("EditIp=@EditIp,");
            strSql.Append("KeyWords=@KeyWords,");
            strSql.Append("Description=@Description,");
            strSql.Append("fenlei=@fenlei,");
            strSql.Append("mp3=@mp3,");
            strSql.Append("f_leibie=@f_leibie,");
            strSql.Append("p_gl=@p_gl,");
            strSql.Append("city_City=@city_City,");
            strSql.Append("city=@city,");
            strSql.Append("z_time=@z_time,");
            strSql.Append("jd_time=@jd_time,");
            strSql.Append("ms_time=@ms_time,");
            strSql.Append("gw_time=@gw_time,");
            strSql.Append("zb_time=@zb_time,");
            strSql.Append("U_id=@U_id,");
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
					new SqlParameter("@ClassId", SqlDbType.Int,4),
					new SqlParameter("@IsTop", SqlDbType.Bit,1),
					new SqlParameter("@IsStatus", SqlDbType.Bit,1),
					new SqlParameter("@IsElite", SqlDbType.Bit,1),
					new SqlParameter("@IsHot", SqlDbType.Bit,1),
					new SqlParameter("@Sort", SqlDbType.Int,4),
					new SqlParameter("@Title", SqlDbType.NVarChar,200),
					new SqlParameter("@LookPwd", SqlDbType.NVarChar,20),
					new SqlParameter("@Note", SqlDbType.NText),
					new SqlParameter("@Content", SqlDbType.NText),
					new SqlParameter("@Year", SqlDbType.NVarChar,4000),
					new SqlParameter("@Conut", SqlDbType.Decimal,9),
					new SqlParameter("@PostTime", SqlDbType.DateTime),
					new SqlParameter("@Author", SqlDbType.NVarChar,50),
					new SqlParameter("@InfoFrom", SqlDbType.NVarChar,50),
					new SqlParameter("@Title1", SqlDbType.NVarChar,200),
					new SqlParameter("@Url", SqlDbType.NVarChar,300),
					new SqlParameter("@InfoEditor", SqlDbType.NVarChar,50),
					new SqlParameter("@AboutTag", SqlDbType.NVarChar,50),
					new SqlParameter("@Photo", SqlDbType.NVarChar,1200),
					new SqlParameter("@CreateUsers", SqlDbType.NVarChar,200),
					new SqlParameter("@CreateTimes", SqlDbType.DateTime),
					new SqlParameter("@CreateIp", SqlDbType.NVarChar,200),
					new SqlParameter("@EditUsers", SqlDbType.NVarChar,200),
					new SqlParameter("@EditTimes", SqlDbType.DateTime),
					new SqlParameter("@EditIp", SqlDbType.NVarChar,200),
					new SqlParameter("@KeyWords", SqlDbType.NVarChar,200),
					new SqlParameter("@Description", SqlDbType.NText),
					new SqlParameter("@fenlei", SqlDbType.NVarChar,4000),
					new SqlParameter("@mp3", SqlDbType.NVarChar,1200),
					new SqlParameter("@f_leibie", SqlDbType.Int,4),
					new SqlParameter("@p_gl", SqlDbType.Int,4),
					new SqlParameter("@city_City", SqlDbType.NVarChar,200),
					new SqlParameter("@city", SqlDbType.NVarChar,200),
                    new SqlParameter("@z_time", SqlDbType.NVarChar,200),
                    new SqlParameter("@jd_time", SqlDbType.NVarChar,200),
                    new SqlParameter("@ms_time", SqlDbType.NVarChar,200),
                    new SqlParameter("@gw_time", SqlDbType.NVarChar,200),
                    new SqlParameter("@zb_time", SqlDbType.NVarChar,200),
					new SqlParameter("@U_id", SqlDbType.Int,4),
					new SqlParameter("@Id", SqlDbType.Int,4)};
            parameters[0].Value = model.ClassId;
            parameters[1].Value = model.IsTop;
            parameters[2].Value = model.IsStatus;
            parameters[3].Value = model.IsElite;
            parameters[4].Value = model.IsHot;
            parameters[5].Value = model.Sort;
            parameters[6].Value = model.Title;
            parameters[7].Value = model.LookPwd;
            parameters[8].Value = model.Note;
            parameters[9].Value = model.Content;
            parameters[10].Value = model.Year;
            parameters[11].Value = model.Conut;
            parameters[12].Value = model.PostTime;
            parameters[13].Value = model.Author;
            parameters[14].Value = model.InfoFrom;
            parameters[15].Value = model.Title1;
            parameters[16].Value = model.Url;
            parameters[17].Value = model.InfoEditor;
            parameters[18].Value = model.AboutTag;
            parameters[19].Value = model.Photo;
            parameters[20].Value = model.CreateUsers;
            parameters[21].Value = model.CreateTimes;
            parameters[22].Value = model.CreateIp;
            parameters[23].Value = model.EditUsers;
            parameters[24].Value = model.EditTimes;
            parameters[25].Value = model.EditIp;
            parameters[26].Value = model.KeyWords;
            parameters[27].Value = model.Description;
            parameters[28].Value = model.fenlei;
            parameters[29].Value = model.mp3;
            parameters[30].Value = model.f_leibie;
            parameters[31].Value = model.p_gl;
            parameters[32].Value = model.city_City;
            parameters[33].Value = model.city;
            parameters[34].Value = model.z_time;
            parameters[35].Value = model.jd_time;
            parameters[36].Value = model.ms_time;
            parameters[37].Value = model.gw_time;
            parameters[38].Value = model.zb_time;
            parameters[39].Value = model.U_id;
            parameters[40].Value = model.Id;

            return HXD.DBUtility.SQLHelper.ExecuteNonQuery(strSql.ToString(), parameters) == 1;
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int Id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tb_U_Info ");
			strSql.Append(" where Id=@Id");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
			};
			parameters[0].Value = Id;

			return HXD.DBUtility.SQLHelper.ExecuteNonQuery(strSql.ToString(), parameters) == 1;
		}
		/// <summary>
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string Idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tb_U_Info ");
			strSql.Append(" where Id in ("+Idlist + ")  ");
			int rows=HXD.DBUtility.SQLHelper.ExecuteNonQuery(strSql.ToString());
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public HXD.Model.tb_U_Info GetModel(int Id)
		{
			
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select  top 1 Id,ClassId,IsTop,IsStatus,IsElite,IsHot,Sort,Title,LookPwd,Note,Content,Year,Conut,PostTime,Author,InfoFrom,Title1,Url,InfoEditor,AboutTag,Photo,CreateUsers,CreateTimes,CreateIp,EditUsers,EditTimes,EditIp,KeyWords,Description,fenlei,mp3,f_leibie,p_gl,city_City,city,z_time,jd_time,ms_time,gw_time,zb_time,U_id from tb_U_Info ");
            strSql.Append(" where Id=@Id"); 
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
			};
			parameters[0].Value = Id;

			HXD.Model.tb_U_Info model=new HXD.Model.tb_U_Info();
			DataSet ds=HXD.DBUtility.SQLHelper.ExecuteDataset(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				return DataRowToModel(ds.Tables[0].Rows[0]);
			}
			else
			{
				return null;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public HXD.Model.tb_U_Info DataRowToModel(DataRow row)
		{
			HXD.Model.tb_U_Info model=new HXD.Model.tb_U_Info();
			if (row != null)
			{
				if(row["Id"]!=null && row["Id"].ToString()!="")
				{
					model.Id=int.Parse(row["Id"].ToString());
				}
				if(row["ClassId"]!=null && row["ClassId"].ToString()!="")
				{
					model.ClassId=int.Parse(row["ClassId"].ToString());
				}
				if(row["IsTop"]!=null && row["IsTop"].ToString()!="")
				{
					if((row["IsTop"].ToString()=="1")||(row["IsTop"].ToString().ToLower()=="true"))
					{
						model.IsTop=true;
					}
					else
					{
						model.IsTop=false;
					}
				}
				if(row["IsStatus"]!=null && row["IsStatus"].ToString()!="")
				{
					if((row["IsStatus"].ToString()=="1")||(row["IsStatus"].ToString().ToLower()=="true"))
					{
						model.IsStatus=true;
					}
					else
					{
						model.IsStatus=false;
					}
				}
				if(row["IsElite"]!=null && row["IsElite"].ToString()!="")
				{
					if((row["IsElite"].ToString()=="1")||(row["IsElite"].ToString().ToLower()=="true"))
					{
						model.IsElite=true;
					}
					else
					{
						model.IsElite=false;
					}
				}
				if(row["IsHot"]!=null && row["IsHot"].ToString()!="")
				{
					if((row["IsHot"].ToString()=="1")||(row["IsHot"].ToString().ToLower()=="true"))
					{
						model.IsHot=true;
					}
					else
					{
						model.IsHot=false;
					}
				}
				if(row["Sort"]!=null && row["Sort"].ToString()!="")
				{
					model.Sort=int.Parse(row["Sort"].ToString());
				}
				if(row["Title"]!=null)
				{
					model.Title=row["Title"].ToString();
				}
				if(row["LookPwd"]!=null)
				{
					model.LookPwd=row["LookPwd"].ToString();
				}
				if(row["Note"]!=null)
				{
					model.Note=row["Note"].ToString();
				}
				if(row["Content"]!=null)
				{
					model.Content=row["Content"].ToString();
				}
				if(row["Year"]!=null)
				{
					model.Year=row["Year"].ToString();
				}
				if(row["Conut"]!=null && row["Conut"].ToString()!="")
				{
					model.Conut=decimal.Parse(row["Conut"].ToString());
				}
				if(row["PostTime"]!=null && row["PostTime"].ToString()!="")
				{
					model.PostTime=DateTime.Parse(row["PostTime"].ToString());
				}
				if(row["Author"]!=null)
				{
					model.Author=row["Author"].ToString();
				}
				if(row["InfoFrom"]!=null)
				{
					model.InfoFrom=row["InfoFrom"].ToString();
				}
				if(row["Title1"]!=null)
				{
					model.Title1=row["Title1"].ToString();
				}
				if(row["Url"]!=null)
				{
					model.Url=row["Url"].ToString();
				}
				if(row["InfoEditor"]!=null)
				{
					model.InfoEditor=row["InfoEditor"].ToString();
				}
				if(row["AboutTag"]!=null)
				{
					model.AboutTag=row["AboutTag"].ToString();
				}
				if(row["Photo"]!=null)
				{
					model.Photo=row["Photo"].ToString();
				}
				if(row["CreateUsers"]!=null)
				{
					model.CreateUsers=row["CreateUsers"].ToString();
				}
				if(row["CreateTimes"]!=null && row["CreateTimes"].ToString()!="")
				{
					model.CreateTimes=DateTime.Parse(row["CreateTimes"].ToString());
				}
				if(row["CreateIp"]!=null)
				{
					model.CreateIp=row["CreateIp"].ToString();
				}
				if(row["EditUsers"]!=null)
				{
					model.EditUsers=row["EditUsers"].ToString();
				}
				if(row["EditTimes"]!=null && row["EditTimes"].ToString()!="")
				{
					model.EditTimes=DateTime.Parse(row["EditTimes"].ToString());
				}
				if(row["EditIp"]!=null)
				{
					model.EditIp=row["EditIp"].ToString();
				}
				if(row["KeyWords"]!=null)
				{
					model.KeyWords=row["KeyWords"].ToString();
				}
				if(row["Description"]!=null)
				{
					model.Description=row["Description"].ToString();
				}
				if(row["fenlei"]!=null)
				{
					model.fenlei=row["fenlei"].ToString();
				}
				if(row["mp3"]!=null)
				{
					model.mp3=row["mp3"].ToString();
				}
				if(row["f_leibie"]!=null && row["f_leibie"].ToString()!="")
				{
					model.f_leibie=int.Parse(row["f_leibie"].ToString());
				}
                if (row["z_time"] != null)
                {
                    model.z_time = row["z_time"].ToString();
                }
                if (row["jd_time"] != null)
                {
                    model.jd_time = row["jd_time"].ToString();
                }
                if (row["ms_time"] != null)
                {
                    model.ms_time = row["ms_time"].ToString();
                }
                if (row["gw_time"] != null)
                {
                    model.gw_time = row["gw_time"].ToString();
                }
                if (row["zb_time"] != null)
                {
                    model.zb_time = row["zb_time"].ToString();
                }
                if (row["U_id"] != null && row["U_id"].ToString() != "")
                {
                    model.U_id = int.Parse(row["U_id"].ToString());
                }
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select Id,ClassId,IsTop,IsStatus,IsElite,IsHot,Sort,Title,LookPwd,Note,Content,Year,Conut,PostTime,Author,InfoFrom,Title1,Url,InfoEditor,AboutTag,Photo,CreateUsers,CreateTimes,CreateIp,EditUsers,EditTimes,EditIp,KeyWords,Description,fenlei,mp3,f_leibie,p_gl,city_City,city,z_time,jd_time,ms_time,gw_time,zb_time,U_id ");
            strSql.Append(" FROM tb_U_Info ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return HXD.DBUtility.SQLHelper.ExecuteDataset(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
            strSql.Append(" Id,ClassId,IsTop,IsStatus,IsElite,IsHot,Sort,Title,LookPwd,Note,Content,Year,Conut,PostTime,Author,InfoFrom,Title1,Url,InfoEditor,AboutTag,Photo,CreateUsers,CreateTimes,CreateIp,EditUsers,EditTimes,EditIp,KeyWords,Description,fenlei,mp3,f_leibie,p_gl,city_City,city,z_time,jd_time,ms_time,gw_time,zb_time,U_id ");
            strSql.Append(" FROM tb_U_Info ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return HXD.DBUtility.SQLHelper.ExecuteDataset(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM tb_U_Info ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			object obj = HXD.DBUtility.SQLHelper.ExecuteNonQuery(strSql.ToString());
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.Id desc");
			}
			strSql.Append(")AS Row, T.*  from tb_U_Info T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return HXD.DBUtility.SQLHelper.ExecuteDataset(strSql.ToString());
		}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@tblName", SqlDbType.VarChar, 255),
					new SqlParameter("@fldName", SqlDbType.VarChar, 255),
					new SqlParameter("@PageSize", SqlDbType.Int),
					new SqlParameter("@PageIndex", SqlDbType.Int),
					new SqlParameter("@IsReCount", SqlDbType.Bit),
					new SqlParameter("@OrderType", SqlDbType.Bit),
					new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
					};
			parameters[0].Value = "tb_U_Info";
			parameters[1].Value = "Id";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		
	
	}
}
