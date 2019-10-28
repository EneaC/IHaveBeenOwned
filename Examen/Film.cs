using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen
{ // select title, description, length, rating from film where {selectedFilm.title};
    public class Film
    {
        public string title { get; set; }
        public string description { get; set; }
        public string length { get; set; }
        public string rating { get; set; }
        public string idioma { get; set; }
        public string idiomaid { get; set; }
        public string categoria { get; set; }
        public string id { get; set; }


        public string fullInfo
        {
            get
            {
                return title;
            }
        }

    }
}
