using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SestaPaskaita
{
    public class Movie
    {
        public string Name { get; set; }
        public double Rating { get; set; }

        public Movie(string name, double rating)
        {
            Name = name;
            Rating = rating;
        }

        public override string ToString()
        {
            return $"Name: {Name}, Rating: {Rating}";
        }
    }
}
