using System.IO;
using System.Web;
using System.Web.Script.Serialization;
using swaggerAPIClone.Models;

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
            var JSONText = File.ReadAllText(HttpContext.Current.Server.MapPath("~/App_Data/data2.json"));

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