using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static WebEF.Models.Inspection;

namespace WebEF.Models
{
    public class Inspection
    {
        public int Id { get; set; }
        public DateTime TimeStamp { get; set; }
        public string Resultat { get; set; }
        public C_Status CarStatus { get; set; }
    }
}