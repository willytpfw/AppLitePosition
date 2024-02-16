using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppLitePosition.Data
{
    public  interface IPositionLite
    {
        SQLiteConnection GetConnection();   

    }
}
