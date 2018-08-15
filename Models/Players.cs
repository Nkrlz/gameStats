using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace gameStats.Models
{
    public class Players
    {
        public long Id { get; set;}
        public string Nickname { get; set;}
        public double? Distance { get; set; }
        public long? Shots { get; set; }
        public long? Hits { get; set; }
    }
}
