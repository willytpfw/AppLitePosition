using AppLitePosition.Data;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xamarin.Forms;

[assembly: Dependency(typeof(PositionLite))]
namespace AppLitePosition.Data
{
    
    public class PositionLite : IPositionLite
    {
        public PositionLite() { }
        public SQLiteConnection GetConnection()
        { 
            var sqliteFileName ="Position.db3";
            string documentPath = System.Environment.GetFolderPath(Environment.SpecialFolder.Personal);  
            var path = Path.Combine(documentPath, sqliteFileName);  
            var conn = new SQLiteConnection(path);  
            return conn;
        }
    }
}
