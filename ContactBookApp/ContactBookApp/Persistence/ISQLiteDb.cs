using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace ContactBookApp.Persistence
{
    public interface ISQLiteDb
    {
        SQLiteAsyncConnection GetConnection();
    }
}
