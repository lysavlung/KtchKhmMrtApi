using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;

namespace KtchKhmMrtApi.CRUD
{
    public class Crud
    {
        public static IEnumerable<T> GetList<T>(string strConnectionString, string sql)
        {
            List<T> list = new List<T>();

            using (IDbConnection con = new SqlConnection(strConnectionString))
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();

                list = con.Query<T>(sql).ToList();
                
            }

            return list;
        }

        public static T GetSingleObject<T>(string strConnectionString, string sql, object parameters)
        {
            T obj = default(T);

            using (IDbConnection con = new SqlConnection(strConnectionString))
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();

                obj = con.QueryFirstOrDefault<T>(sql, parameters);
            }

            return obj;
        }
    }
}
