using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace DataAccessLibrary.Logic
{
    internal class SqlDataAccess
    {
        public SQLiteConnection GetConnection()
        {
            var dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Databases\\todolists.db");
            return new SQLiteConnection(dbPath);
        }
        public int AddTaskRow<T>(T model)
        {
            using(var conn = GetConnection())
            {
                return conn.Insert(model);
            }
        }

        public int UpdateTaskRow<T>(T model)
        {
            using (var conn = GetConnection())
            {
                return conn.Update(model);
            }
        }

        public int DeleteTaskRow<T>(int id)
        {
            using (var conn = GetConnection())
            {
                return conn.Delete(id);
            }
        }
    }
}
