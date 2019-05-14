using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using MySql.Data.MySqlClient;

namespace FoodOrderOnline.Repository
{
    public class SQLBaseRepository
    {
        //连接MySql

        //public List<T> Select<T>(string sql, object param)
        //{
        //    using (var conn = new MySqlConnection(ConnectionString))
        //    {
        //        var result = conn.Query<T>(sql, param);

        //        return result.ToList();
        //    }
        //}

        //public T SelectSingle<T>(string sql, object param)
        //{
        //    using (var conn = new MySqlConnection(ConnectionString))
        //    {
        //        var result = conn.Query<T>(sql, param).ToList();
        //        if (result.Count != 0)
        //        {
        //            return result.First();
        //        }
        //        else
        //        {
        //            return default;
        //        }
        //    }
        //}

        ////审计日志放这，事务执行前先判断，数据？
        //public int Execute(string sql, object param)
        //{
        //    using (var conn = new MySqlConnection(ConnectionString))
        //    {
        //        var data = conn.Execute(sql, param);

        //        return data;
        //    }
        //}
    }
}
