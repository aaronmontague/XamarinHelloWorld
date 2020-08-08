using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinHelloWorld.Models
{
    public class Monkey
    {
        // Attributes
        public string Name { get; set; }
        public string Location { get; set; }
        public string ImageUrl { get; set; }

        // Constructors
        public Monkey() { }

        public Monkey(string name, string loc, string imgurl)
        {
            Name = name;
            Location = loc;
            ImageUrl = imgurl;
        }

        // Methods
        public override string ToString()
        {
            return Name;
        }
    }
}
