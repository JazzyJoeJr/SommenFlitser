using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SommenFlitser.Models
{
    public class Kind
    {
        public int Id { get; set; }
        public string Naam { get; set; }
        public bool Actief { get; set; }
        public string Color { get; set; }
    }
}