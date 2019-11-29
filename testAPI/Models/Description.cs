using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace swaggerAPIClone.Models
{
    public class Description
    {
        public string en { get; set; }
        public string fr { get; set; }

        public Description(String en, String fr) {
            this.en = en;
            this.fr = fr;
        }

        public Description()
        {

        }

    }
}