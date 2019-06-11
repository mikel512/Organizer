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
        public SQLiteConnection GetConnection()
        {
            var dbPath = Path.GetFullPath(@"~/Databases/todolists.db");
            return new SQLiteConnection(dbPath);
        }
        public int AddTaskRow()
        {
            return 0;

        }
    }
}
