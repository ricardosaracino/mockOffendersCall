using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace swaggerAPIClone.Models
{
    public class Offenders
    {
        public Status status { get; set; }
        public Facility facility { get; set; }
        public Security security { get; set; }
        public Jurisdiction jurisdiction { get; set; }
        public Sex sex { get; set; }

        public bool statusIndian { get; set; }

        public DateTime birthdate { get; set; }

        public int sentenceNumber { get; set; }
        public int offenderPreferredLangCode { get; set; }
        public int unit { get; set; }
        public int cellNumber { get; set; }

        public string access { get; set; }
        public string oid { get; set; }
        public string fpsNumber { get; set; }
        public string surname { get; set; }
        public string firstname { get; set; }
        public string sentenceId { get; set; }
        public string subUnit { get; set; }
        public string chosenName { get; set; }  
    }
}