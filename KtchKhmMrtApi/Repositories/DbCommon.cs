using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KtchKhmMrtApi.Repositories
{
    internal static class DbCommon
    {
        public const string SCHEMA = "dbo";
        public const string DB = "KtchKhmMrtDB";
        public const string DBWITHSCHEMA = DB + "." + SCHEMA + ".";
        public const string SQL_CONNECTION_STRING = @"server=VICHET-PC\SQLEXPRESS;database=KtchKhmMrtDB;user id=sa;password=12345";
    }
}
