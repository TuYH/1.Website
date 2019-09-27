using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace HXD.Measure
{
    public class SchoolDB
    {
        public static string GetCollegeName(string collegeNo)
        {
            string sql = "select CollegeName from t_College where CollegeNo = '{0}'";
            sql = string.Format(sql, collegeNo);
            DataBase db = new DataBase();
            object res = db.ExecuteSqlScalar(sql, null);
            string result;
            if (res == null)
            {
                result = "";
            }
            else
            {
                result = res.ToString();
            }
            return result;
        }
        public static DataTable GetCollegeList(string campusNo)
        {
            string sql = "select CollegeNo as Value, CollegeName as Text from t_College where CampusNo = '{0}' order by CollegeNo";
            sql = string.Format(sql, campusNo);
            DataBase db = new DataBase();
            DataSet ds;
            db.ExecuteSql(sql, null, out ds);
            return ds.Tables[0];
        }
        public static void AddCollege(string collegeNo, string collegeName)
        {
            string sql = "insert into t_College (collegeNo, collegeName) values ('{0}', '{1}')";
            sql = string.Format(sql, collegeNo, collegeName);
            DataBase db = new DataBase();
            db.ExecuteSql(sql, null);
        }
        public static void UpdateCollege(string collegeNo, string collegeName)
        {
            string sql = "update t_College set collegeName = '{0}' where collegeNo = '{1}'";
            sql = string.Format(sql, collegeName, collegeNo);
            DataBase db = new DataBase();
            db.ExecuteSql(sql, null);
        }
        public static void DeleteCollege(string collegeNo)
        {
            string sql = "delete from t_College where collegeNo = '{0}'";
            sql = string.Format(sql, collegeNo);
            DataBase db = new DataBase();
            db.ExecuteSql(sql, null);
        }
        public static string GetStudyName(string studyNo)
        {
            string sql = "select StudyName from t_Study where StudyNo = '{0}'";
            sql = string.Format(sql, studyNo);
            DataBase db = new DataBase();
            object res = db.ExecuteSqlScalar(sql, null);
            string result;
            if (res == null)
            {
                result = "";
            }
            else
            {
                result = res.ToString();
            }
            return result;
        }
        public static DataTable GetStudyList(string collegeNo)
        {
            string sql = "select StudyNo as Value, StudyName as Text from t_Study where CollegeNo = '{0}' order by StudyNo";
            sql = string.Format(sql, collegeNo);
            DataBase db = new DataBase();
            DataSet ds;
            db.ExecuteSql(sql, null, out ds);
            return ds.Tables[0];
        }
        public static void AddStudy(string studyNo, string studyName, string collegeNo)
        {
            string sql = "insert into t_Study (StudyNo, StudyName, CollegeNo) values ('{0}', '{1}', '{2}')";
            sql = string.Format(sql, studyNo, studyName, collegeNo);
            DataBase db = new DataBase();
            db.ExecuteSql(sql, null);
        }
        public static void UpdateStudy(string studyNo, string studyName)
        {
            string sql = "update t_Study set StudyName = '{0}' where StudyNo = '{1}'";
            sql = string.Format(sql, studyName, studyNo);
            DataBase db = new DataBase();
            db.ExecuteSql(sql, null);
        }
        public static void DeleteStudy(string studyNo)
        {
            string sql = "delete from t_Study where StudyNo = '{0}'";
            sql = string.Format(sql, studyNo);
            DataBase db = new DataBase();
            db.ExecuteSql(sql, null);
        }
        public static string GetClassNo(string className)
        {
            string sql = "select ClassNo from t_Class where ClassName = '{0}'";
            sql = string.Format(sql, className);
            DataBase db = new DataBase();
            object res = db.ExecuteSqlScalar(sql, null);
            string result;
            if (res == null)
            {
                result = "";
            }
            else
            {
                result = res.ToString();
            }
            return result;
        }
        public static string GetClassName(string classNo)
        {
            string sql = "select ClassName from t_Class where ClassNo = '{0}'";
            sql = string.Format(sql, classNo);
            DataBase db = new DataBase();
            object res = db.ExecuteSqlScalar(sql, null);
            string result;
            if (res == null)
            {
                result = "";
            }
            else
            {
                result = res.ToString();
            }
            return result;
        }
        public static DataTable GetClassList(string studyNo)
        {
            string sql = "select ClassNo as Value, ClassName as Text from t_Class where StudyNo = '{0}' order by ClassNo";
            sql = string.Format(sql, studyNo);
            DataBase db = new DataBase();
            DataSet ds;
            db.ExecuteSql(sql, null, out ds);
            return ds.Tables[0];
        }
        public static void AddClass(string classNo, string className, string studyNo)
        {
            string sql = "insert into t_Class (ClassNo, ClassName, StudyNo) values ('{0}', '{1}', '{2}')";
            sql = string.Format(sql, classNo, className, studyNo);
            DataBase db = new DataBase();
            db.ExecuteSql(sql, null);
        }
        public static void UpdateClass(string classNo, string className)
        {
            string sql = "update t_Class set ClassName = '{0}' where ClassNo = '{1}'";
            sql = string.Format(sql, className, classNo);
            DataBase db = new DataBase();
            db.ExecuteSql(sql, null);
        }
        public static void DeleteClass(string classNo)
        {
            string sql = "delete from t_Class where ClassNo = '{0}'";
            sql = string.Format(sql, classNo);
            DataBase db = new DataBase();
            db.ExecuteSql(sql, null);
        }
        public static bool IsStudentExists(string studentNo)
        {
            string sql = "select * from t_Student where StudentNo = '" + studentNo + "'";
            DataBase db = new DataBase();
            DataSet ds;
            db.ExecuteSql(sql, null, out ds);
            return ds.Tables[0].Rows.Count != 0;
        }
        public static string GetStudent(string studentNo)
        {
            //select sex from tb_User as a,tb_U_user as b where a.Id=b.id and UserName='20180101'
            string sql = "select sex from tb_User as a,tb_U_user as b where a.Id=b.id and UserName= '" + studentNo + "'";
            string result=HXD.DBUtility.SQLHelper.ExecuteScalar(sql).ToString();
            //DataBase db = new DataBase();
            //DataSet ds;
            //db.ExecuteSql(sql, null, out ds);
            //DataRow result;
            //if (ds.Tables[0].Rows.Count == 0)
            //{
            //    result = null;
            //}
            //else
            //{
            //    result = ds.Tables[0].Rows[0];
            //}
            return result;
        }
        public static DataRow GetStudentInfo(string studentNo)
        {
            string sql = "select * from t_Student_Info where StudentNo = '{0}'";
            sql = string.Format(sql, studentNo);
            DataBase db = new DataBase();
            DataSet ds;
            db.ExecuteSql(sql, null, out ds);
            DataRow result;
            if (ds.Tables[0].Rows.Count == 0)
            {
                result = null;
            }
            else
            {
                result = ds.Tables[0].Rows[0];
            }
            return result;
        }
        public static void DeleteStudent(string studentNo)
        {
            string sql = "delete from t_Student where StudentNo = '{0}'";
            sql = string.Format(sql, studentNo);
            DataBase db = new DataBase();
            db.ExecuteSql(sql, null);
        }
        public static void DeleteStudents(string filter)
        {
            string sql = "delete from t_Student where " + filter;
            DataBase db = new DataBase();
            db.ExecuteSql(sql, null);
        }
        public static DataTable GetStudentList(string filter)
        {
            string sql = "select * from v_StudentInfo t1 where " + filter + " order by StudentNo";
            DataBase db = new DataBase();
            DataSet ds;
            db.ExecuteSql(sql, null, out ds);
            return ds.Tables[0];
        }
        public static DataTable GetStudentListForExport(string filter)
        {
            string sql = "\r\nselect t1.CollegeName as 单位, t1.StudyName as 部门, ClassName as 班级名称,\r\n\tt1.StudentNo as 用户号, StudentName as 姓名, Sex as 性别, Birthday as 生日,\r\n\tCID as 身份证号, NationName as 民族, FamilyAddress as 家庭住址,\r\n\tNowAddress as 现住地址, TelephoneNo as 电话号码, EMail as 电子邮件, OtherContactMode as 其他联系方式,\r\n\tGrade as 届级, PolityVisage as 政治背景, Age as 年龄, MarriageStatus as 婚姻状况,\r\n\tCultureDegree as 文化程度, SeniorHighSchoolAddress as 中学所在地, SeniorHighSchoolGraduateTime as 中学毕业时间, GradeSchoolAddress as 小学所在地,\r\n\tdiagnosis as 诊断结论, meddle as 干预方案, opinion as 综合意见,\r\n\tFatherAge as 父亲年龄, FatherJob as 父亲职业, FatherCulture as 父亲文化程度, FatherHealthStatus as 父亲健康状况,\r\n\tMotherAge as 母亲年龄, MotherJob as 母亲职业, MotherCulture as 母亲文化程度, MotherHealthStatus as 母亲健康状况,\r\n\tIsMindTest as 是否做过心理测试, FamilyCaseHistory as 家庭病史, UnderstandSelf as 对自己了解程度, SatisfactionOfHightsShoolGrade as 高考成绩满意度,\r\n\tIsStudentCadre as 曾担任过学生干部, RelationOfFamliy as 家庭成员关系, HomeNo as 家中排行, ParentMarriageStatus as 父母婚姻状况,\r\n\tMaintenance as 您每月比较稳定的生活费, Stipend as 需要贷款数额, CaseHistory as 病史, IntroduceSelf as 自我介绍,\r\n\tChieflyHelpObject as 首选求助对象, EntranceAim as 入学动机, ReplySatisfaction as 报考满意度, IsSingleton as 是否独生子女,\r\n\tFromWhere as 来源地, FamilyStruct as 家庭结构, FamliyAtmosphere as 家庭氛围, FamliyIncome as 家庭收入\r\nfrom v_StudentInfo t1 left join t_Student_Info t2 on t1.StudentNo = t2.StudentNo \r\nwhere " + filter + " order by t1.StudentNo";
            DataBase db = new DataBase();
            DataSet ds;
            db.ExecuteSql(sql, null, out ds);
            return ds.Tables[0];
        }
        public static string GetStudentName(string studentNo)
        {
            string sql = "select StudentName from t_Student where StudentNo = '{0}'";
            sql = string.Format(sql, studentNo);
            DataBase db = new DataBase();
            object res = db.ExecuteSqlScalar(sql, null);
            string result;
            if (res == null)
            {
                result = "";
            }
            else
            {
                result = res.ToString();
            }
            return result;
        }
        public static bool ModifyPassword(string studentNo, string oldPass, string newPass)
        {
            DataBase db = new DataBase();
            string sql = "select count(StudentPassword) from t_Student where StudentNo = '{0}' and StudentPassword = '{1}'";
            sql = string.Format(sql, studentNo, oldPass);
            bool result;
            if ((int)db.ExecuteSqlScalar(sql, null) == 0)
            {
                result = false;
            }
            else
            {
                sql = "update t_Student set StudentPassword = '{0}' where StudentNo = '{1}'";
                sql = string.Format(sql, newPass, studentNo);
                db.ExecuteSql(sql, null);
                result = true;
            }
            return result;
        }
        public static void ResetStudentPassword(string studentNo, string password)
        {
            DataBase db = new DataBase();
            string sql = "update t_Student set StudentPassword = '{0}' where StudentNo = '{1}'";
            sql = string.Format(sql, password, studentNo);
            db.ExecuteSql(sql, null);
        }
        public static void ResetAllStudentPassword(string password)
        {
            DataBase db = new DataBase();
            string sql = "update t_Student set StudentPassword = '{0}'";
            sql = string.Format(sql, password);
            db.ExecuteSql(sql, null);
        }
        public static bool IsVerifiedStudent(string studentNo)
        {
            DataBase db = new DataBase();
            string sql = "select Verified from t_Student where StudentNo = '{0}'";
            sql = string.Format(sql, studentNo);
            object res = db.ExecuteSqlScalar(sql, null);
            return res != null && (bool)res;
        }
        public static void VerifyStudent(string studentNo)
        {
            DataBase db = new DataBase();
            string sql = "update t_Student set Verified = 1 where StudentNo = '{0}'";
            sql = string.Format(sql, studentNo);
            db.ExecuteSql(sql, null);
        }
        public static bool HasInputInfo(string studentNo)
        {
            string sql = "select StudentNo from t_Student_Info where StudentNo = '{0}'";
            sql = string.Format(sql, studentNo);
            DataBase db = new DataBase();
            return db.ExecuteSqlScalar(sql, null) != null;
        }
        public static void Diagnose(string studentno, string diagnosis, string meddle, string opinion)
        {
            string sql = "update t_student set diagnosis = '{0}', meddle = '{1}', opinion = '{2}' where studentno = '{3}'";
            sql = string.Format(sql, new object[]
			{
				diagnosis.Replace("'", "\""),
				meddle.Replace("'", "\""),
				opinion.Replace("'", "\""),
				studentno
			});
            DataBase db = new DataBase();
            db.ExecuteSql(sql, null);
        }
        public static void TruncateData()
        {
            string[] sqls = new string[]
			{
				"truncate table t_Student",
				"truncate table t_Class",
				"truncate table t_Study",
				"truncate table t_College"
			};
            DataBase db = new DataBase();
            db.ExecuteSql(sqls);
        }
    }
}
