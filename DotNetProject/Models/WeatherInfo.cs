using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetProject.Models
{

    public class WeatherInfo
    {
        public City City { get; set; }
        public List<List> List { get; set; }
    }

    public class City
    {
        public string Name { get; set; }
        public string Country { get; set; }
    }

    public class Temp
    {
        public double Day { get; set; }
        public double Min { get; set; }
        public double Max { get; set; }
        public double Night { get; set; }
    }

    public class Weather
    {
        public string Description { get; set; }
        public string Icon { get; set; }
    }

    public class List
    {
        public Temp Temp { get; set; }
        public int Humidity { get; set; }
        public List<Weather> Weather { get; set; }
    }

}
