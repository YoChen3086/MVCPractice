using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCPractice
{
    public class Village
    {
        public Village(string id, string name)
        {
            this.id = id;
            this.name = name;
        }

        public string id { get; set; }

        public string name { get; set; }
    }
}