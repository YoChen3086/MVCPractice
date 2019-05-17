using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCPractice
{
    public class City
    {
        public string id { get; set; }
        public string name { get; set; }

        public City()
        {
            id = string.Empty;
            name = string.Empty;
        }

        public City(string _id, string _name)
        {
            id = _id;
            name = _name;
        }
    }
}