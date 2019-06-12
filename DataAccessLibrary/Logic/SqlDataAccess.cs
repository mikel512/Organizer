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
            return new SQLiteConnection("Data Source=./.../.../todolists.db; Version = 3; New = False; FailIfMissing = True");
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
