using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SommenFlitser.Models
{
    public class Oplossing
    {
        public int Id { get; set; }
        public int KindId { get; set; }
        public int OefeningId { get; set; }
        public int Antwoord { get; set; }

    }
}