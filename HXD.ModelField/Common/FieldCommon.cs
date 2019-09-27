using System;
using System.Collections.Generic;
using System.Text;

namespace HXD.ModelField.Common
{
    public class FieldCommon
    {
        public static string GetDateTimeDefault(string Default)
        {
            if (Default == "getdate()")
            {
                return "getdate()";
            }
            else
            {
                return "'" + Default + "'";
            }
        }
    }
}
