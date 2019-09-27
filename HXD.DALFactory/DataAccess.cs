using System;
using System.Reflection;
using System.Configuration;
using HXD.IDAL;

namespace HXD.DALFactory
{
    public sealed class DataAccess
    {
        private static readonly string path = ConfigurationSettings.AppSettings["WebDAL"];
        public DataAccess() { }
        public static iAdmin CreateAdmin()
        {
            string className = path + ".sAdmin";
            return (iAdmin)Assembly.Load(path).CreateInstance(className);
        }
        public static iChannel CreateChannel()
        {
            string className = path + ".sChannel";
            return (iChannel)Assembly.Load(path).CreateInstance(className);
        }
        public static iAdminGroup CreateAdminGroup()
        {
            string className = path + ".sAdminGroup";
            return (iAdminGroup)Assembly.Load(path).CreateInstance(className);
        }
        public static iSetType CreateSetType()
        {
            string className = path + ".sSetType";
            return (iSetType)Assembly.Load(path).CreateInstance(className);
        }
        public static iMenu CreateMenu()
        {
            string className = path + ".sMenu";
            return (iMenu)Assembly.Load(path).CreateInstance(className);
        }
        public static iMenuField CreateMenuField()
        {
            string className = path + ".sMenuField";
            return (iMenuField)Assembly.Load(path).CreateInstance(className);
        }
        public static iTable CreateTable()
        {
            string className = path + ".sTable";
            return (iTable)Assembly.Load(path).CreateInstance(className);
        }
        public static iField CreateField()
        {
            string className = path + ".sField";
            return (iField)Assembly.Load(path).CreateInstance(className);
        }
        public static iOnlineAdmin CreateOnlineAdmin()
        {
            string className = path + ".sOnlineAdmin";
            return (iOnlineAdmin)Assembly.Load(path).CreateInstance(className);
        }
        public static iUserGroup CreateUserGroup()
        {
            string className = path + ".sUserGroup";
            return (iUserGroup)Assembly.Load(path).CreateInstance(className);
        }
        public static iUser CreateUser()
        {
            string className = path + ".sUser";
            return (iUser)Assembly.Load(path).CreateInstance(className);
        }

        public static Izhubo Createbzhubo()
        {
            string className = path + ".sZhuBo";
            return (Izhubo)Assembly.Load(path).CreateInstance(className);
        }

    }
}
