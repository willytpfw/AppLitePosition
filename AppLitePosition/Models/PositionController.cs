using AppLitePosition.Data;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using AppLitePosition.Data;
using System.Linq;

namespace AppLitePosition.Models
{
    public class PositionController
    {

        static object locker = new object();

        SQLiteConnection database;

        public PositionController()
        {
            try
            {
                database = DependencyService.Get<IPositionLite>().GetConnection();
                database.CreateTable<Position>();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public Position GetPosition()
        {
            lock (locker)
            {

                if (database.Table<Position>().Count() == 0)
                    return null;
                else
                    return database.Table<Position>().First();
            }
        }

        public Position GetPosition(int id)
        {
            lock (locker)
            {

                if (database.Table<Position>().Count() == 0)
                    return null;
                else
                    return database.Table<Position>().Where(x=> x.Id == id).FirstOrDefault();
            }
        }


        public List<Position> GetLstPosition()
        {
            lock (locker)
            {

                if (database.Table<Position>().Count() == 0)
                    return null;
                else
                    return database.Table<Position>().ToList();
            }
        }

        public int SavePosition(Position position)
        {

            lock (locker)
            {
                if (position.Id != 0)
                {
                    database.Update(position);
                    return position.Id;
                }
                else
                    return database.Insert(position);
            }
        }

        public int DeletePosition (Position id)
        {

        lock (locker) { 
                return database.Delete(id); 
            }
        }
    }
}
