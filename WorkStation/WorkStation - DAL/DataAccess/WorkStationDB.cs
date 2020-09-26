//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Configuration;
//using System.Data;
//using System.Data.SqlClient;

//namespace WorkStationDAL.DataAccess // o DataAccess é o nome do folder não o do ficheiro .cs
//{
//    public static class WorkStationDB //is static bc we not gona store data here
//    {
//        public static string GetConnectionString(string connectionName = "WorkStationDB")
//        {
//            return ConfigurationManager.ConnectionStrings[connectionName].ConnectionString;
//        }

//        public static List<T> LoadData<T>(string sql)
//        {
//            using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
//            {
//               return cnn.Query<T>(sql).ToList();
//            }
//        }

//        public static int SaveData<T>(string sql, T data)
//        {
//            using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
//            {
//              //  return cnn.Execute(sql, data);
//            }
//        }

//        public static string Login<T>(string sql, T data)
//        {
//            using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
//            {
//                return cnn.Execute(sql, data).ToString();
//            }
//        }


//    }
//}
