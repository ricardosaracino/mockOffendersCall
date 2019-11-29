using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace swaggerAPIClone.Models
{
    public class Packet
    {
        public Paging paging { get; set; }
        public Links links { get; set; }
        public List<Offenders> offenders { get; set; }
    }
}