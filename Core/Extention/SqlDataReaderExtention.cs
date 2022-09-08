using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Core.Extention
{
    public static class SqlDataReaderExtention
    {
        public static T Get <T>(this SqlDataReader reader,string column)
        {
            T value = default;
            if (reader != null )
                value = (T)reader[column];
            return value;
        }
    }
}
