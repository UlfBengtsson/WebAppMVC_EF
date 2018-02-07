using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebEF.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public virtual List<Inspection> Inspections { get; set; }
    }
}