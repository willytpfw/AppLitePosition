using AppLitePosition.Data;
using SQLite;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Text;
using Xamarin.Essentials;


namespace AppLitePosition.Data
{
    public class GeographyPositiong
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }

    public class Position
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        // [Ignore]
        // public GeographyPositiong Positiong { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string GPS
        {

            get
            {
                string result = "";
                result = Latitude.ToString() + " - " + Longitude.ToString();
                return result;

            }

        }

    }
}
