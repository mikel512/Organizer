using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using SQLite;
using DataAccessLibrary.Models;

namespace DataAccessLibrary.Logic
{
    public class SqlDataAccess
    {
        public static SQLiteConnection GetConnection()
        {
            return new SQLiteConnection("Data Source=./.../.../todolists.db; Version = 3; New = False; FailIfMissing = True");
        }
        public static int AddTaskRow(TaskLibraryModel model)
        {
            using(var conn = GetConnection())
            {
                return conn.Insert(model);
            }
        }

        public static int UpdateTaskRow(TaskLibraryModel model)
        {
            using (var conn = GetConnection())
            {
                return conn.Update(model);
            }
        }

        public static int DeleteTaskRow(int id)
        {
            using (var conn = GetConnection())
            {
                return conn.Delete(id);
            }
        }

        public static List<TaskLibraryModel> TaskQuery()
        {
            using(var conn = GetConnection())
            {
                var query = conn.Table<TaskLibraryModel>().Where(v => v.IsDone == false);
                return query.ToList();
            }
        }
    }
}
