using swaggerAPIClone.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script;
using System.Web.Script.Serialization;

namespace swaggerAPIClone.Controllers
{
    // Reads the JSON file and provides a portal
    public class OffenderData
    {
        private Offenders[] data;

        public OffenderData()
        {
            setup();
        }

        private void setup()
        {
            // Read the JSON file
            var JSONText = System.IO.File.ReadAllText(@"M:\DOCUMENT\programming\ricardo\swaggerAPIClone\testAPI\Models\data.json");
            
            // Deserialize it and store
            this.data = new JavaScriptSerializer().Deserialize<Offenders[]>(JSONText);
        }

        // Returns the length of this.data
        public int length()
        {
            return data.Length;
        }

        // Returns this.data
        public Offenders[] getData()
        {
            return this.data;
        }
    }
}