using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SommenFlitser.Models
{
    public class Oefening
    {
        public int Id { get; set; }
        public string Vraag { get; set; }
        public bool Actief { get; set; }
        public int Resultaat { get; set; }
    }
}