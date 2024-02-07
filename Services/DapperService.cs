using Dapper;
using Microsoft.Data.SqlClient;
using RashakaGroupsAdmin.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Web;
using static Dapper.SqlMapper;

namespace RashakaGroupsAdmin.Services
{
    public class DapperService<T> : IDisposable where T : class
    {
        private readonly IntPtr _bufferPtr = Marshal.AllocHGlobal(1024 * 1024 * 10);// 10 MB
        private bool _disposed = false;
        //private static readonly string _connectionString = DatabaseConnectionString.ConnectionString;
        private static readonly string _connectionString = "data source=85.195.94.22; initial catalog=Rashaka;user id=sa;password=hV5}aF2%cL7*;TrustServerCertificate=True;Encrypt=True;";
        public static IDbConnection Connection => new SqlConnection(_connectionString);
        public DapperService()
        {
            _bufferPtr = Marshal.AllocHGlobal(_bufferPtr);
        }

        public static IEnumerable<T> Query(string sqlCommandOrSP, object param, CommandType commandType)
        {
             using (IDbConnection _db = Connection)
            {
                return _db.Query<T>(sqlCommandOrSP, param, commandType: commandType);
            };
        } 
        
       
        public static IEnumerable<T> Query(string SqlQuery)
        {
            using (IDbConnection _db = Connection)
            {
                return _db.Query<T>(SqlQuery);
            };
        }
        public static IEnumerable<T> Query(string SqlQuery,object param)
        {
             using (IDbConnection _db = Connection)
            {
                return _db.Query<T>(SqlQuery, param);
            };
        }
        public static async Task<IEnumerable<T>> QueryAsync(string SqlQuery, object param)
        {
             using (IDbConnection _db = Connection)
            {
                return await _db.QueryAsync<T>(SqlQuery, param);
            };
        }       
        public static async Task<IEnumerable<T>> QueryAsync(string storedProcedure, object param, CommandType commandType)
        {
             using (IDbConnection _db = Connection)
            {
                return await _db.QueryAsync<T>(storedProcedure, param, commandType: commandType);
            };
        }
        public static async Task<IEnumerable<T>> QueryAsync(string SqlQuery)
        {
             using (IDbConnection _db = Connection)
            {
                return await _db.QueryAsync<T>(SqlQuery);
            };
        }

        public static async Task<GridReader> QueryMultipleAsync(string storedProcedure, object param)
        {
             using (IDbConnection _db = Connection)
            {
                return await _db.QueryMultipleAsync(storedProcedure, param, commandType: CommandType.StoredProcedure);
            }
        }
        public static void ExecuteQuery(string query, object param)
        {
             using (IDbConnection _db = Connection)
            {
                _db.Execute(query, param, commandType: CommandType.Text);
            };
        }
        public static void Execute(string storedProcedure, object param)
        {
             using (IDbConnection _db = Connection)
            {
                _db.Execute(storedProcedure, param, commandType: CommandType.StoredProcedure);
            };
        }
        public static async Task<int> ExecuteAsync(string storedProcedure, object param)
        {
            int affectedRows = 0;
             using (IDbConnection _db = Connection)
            {
                affectedRows = await _db.ExecuteAsync(storedProcedure, param, commandType: CommandType.StoredProcedure);
            };
            return affectedRows;
        }
        //reutn one selected value
        public static object ExecuteScalar(string sqlQueryOrSP, object param, CommandType commandType)
        {
             using (IDbConnection _db = Connection)
            {
                return _db.ExecuteScalar(sqlQueryOrSP, param, commandType: commandType);
            };
        }
       
        public static object ExecuteScalar(string query)
        {
             using (IDbConnection _db = Connection)
            {
                return _db.ExecuteScalar(query, commandType: CommandType.Text);
            };
        }
        
        //public static async Task<T> QuerySingleAsync(string storedProcedure, object param)
        //{
        //     using (IDbConnection _db = Connection)
        //    {
        //        return await _db.QuerySingleAsync<T>(storedProcedure, param, commandType: CommandType.StoredProcedure);
        //    }

        //}
        public static T QuerySingle(string query, object param)
        {
             using (IDbConnection _db = Connection)
            {
                return _db.QuerySingle<T>(query, param, commandType: CommandType.Text);
            }

        }

        internal static IEnumerable<StepModel> Query(object value)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
    //public class DapperService<T> where T : class
    //{
    //    public static string ConnectionString = ConfigurationManager.ConnectionStrings["DapperConnectionString"].ToString();

    //    public static IEnumerable<T> Query(string storedProcedure, object param)
    //    {
    //         using (IDbConnection _db = Connection)
    //        {
    //            return _db.Query<T>(storedProcedure, param, commandType: CommandType.StoredProcedure);
    //        };
    //    }
    //    public static object ExecuteScalar(string storedProcedure, object param)
    //    {
    //         using (IDbConnection _db = Connection)
    //        {
    //            return _db.ExecuteScalar(storedProcedure, param, commandType: CommandType.StoredProcedure);
    //        };
    //    }
    //    public static IEnumerable<T> Query(string SqlQuery)
    //    {
    //         using (IDbConnection _db = Connection)
    //        {
    //            return _db.Query<T>(SqlQuery);
    //        };
    //    }
    //    public static IEnumerable<T> Query(string SqlQuery, object param)
    //    {
    //         using (IDbConnection _db = Connection)
    //        {
    //            return _db.Query<T>(SqlQuery,param);
    //        };           
    //    }
    //    public static object ExecuteScalar(string query)
    //    {
    //         using (IDbConnection _db = Connection)
    //        {
    //            return _db.ExecuteScalar(query, null, commandType: CommandType.Text);
    //        };
    //    }

    //    public static object ExecuteScalar(string query, object param)
    //    {
    //        try
    //        {
    //             using (IDbConnection _db = Connection)
    //            {
    //                return _db.ExecuteScalar(query, param, commandType: CommandType.Text);
    //            };
    //        }
    //        catch (System.Exception ex)
    //        {
    //            string x = ex.Message;
    //            return x;
    //        }

    //    }
    //}
}