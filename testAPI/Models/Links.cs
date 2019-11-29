using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace swaggerAPIClone.Models
{
    public class Links
    {
        public string href { get; set; }
        public string rel { get; set; }
        public string method { get; set; }

        public Links(string href, string rel, string method)
        {
            this.href = href;
            this.rel = rel;
            this.method = method;
        }
    }
}