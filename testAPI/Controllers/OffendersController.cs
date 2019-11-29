using System.Web.Http;
using swaggerAPIClone.Models;
using System.Web;
using System.Collections.Generic;
using System;

namespace swaggerAPIClone.Controllers
{
    public class OffendersController : ApiController
    {
        // Our portal to the offender data
        OffenderData data = new OffenderData();

        public IHttpActionResult GetOffenders()
        {
            // Used to access HttpRequest.Current.Request.QueryString (For some reason, Request.QueryString did not work [TO-DO] Figure out why since the Request object can be referenced without its parent).
            HttpRequest request = HttpContext.Current.Request;

            // Fetch our offenders from our Model
            Offenders[] offenders = this.data.getData();

            // The list responsible for holding our Offenders that match the query data sent by the user.
            List<Offenders> offenderList = new List<Offenders>();

            // Simulates a SELECT statement with a WHERE clause, find the offenders that match the user's query and add them to the offenderList list.
            // Note, comparisons are only made if a user provided a value to query by, otherwise it doesn't affect verification.
            foreach (Offenders offender in offenders)
            {
                bool isMatch = true;

                if (request.QueryString["fpsNumberInput"] != null)
                {
                    if (offender.fpsNumber != request.QueryString["fpsNumberInput"]) isMatch = false;
                }

                if (request.QueryString["oidInput"] != null)
                {
                    if (offender.oid != request.QueryString["oidInput"]) isMatch = false;
                }

                if (request.QueryString["lastNameInput"] != null)
                {
                    if (offender.surname != request.QueryString["lastNameInput"]) isMatch = false;
                }

                if (request.QueryString["firstNameInput"] != null)
                {
                    if (offender.firstname != request.QueryString["firstNameInput"]) isMatch = false;
                }

                if (request.QueryString["facilityCodeInput"] != null)
                {
                    if (offender.facility.code.ToString() != request.QueryString["facilityCodeInput"]) isMatch = false;
                }

                // If isMatch was never turned to false, we've found a match! Add it to our list
                if (isMatch) offenderList.Add(offender);
            }

            // If no results were found or offenderList.Count == 0, just return not found
            // [TO-DO] Replace Ok() with the proper response practice
            if (offenderList.Count == 0) return NotFound();

            // Build our return packet (The three parts are the Paging, Links, and Offender Data)
            Packet packet = new Packet();

            // [Building packet.Paging] Fetch our pageSize, if it isn't a viable entry, set the default to 10
            int pageSize = Convert.ToInt32(request.QueryString["pageSizeInput"]);
            if (pageSize == 0) pageSize = 10;

            // [Building packet.Paging] Fetch our pageNumber, if it isn't a viable entry, set the default to 1
            int pageNumber = Convert.ToInt32(request.QueryString["pageNumberInput"]);
            if (pageNumber == 0) pageNumber = 1;

            // [Building packet.Paging] Add our paging profile to the packet (As long as paging isn't set to false, if it is, the property is left null)
            if (request.QueryString["pagingInput"] != "false")
            { 
                packet.paging = new Paging(offenderList.Count, pageNumber, pageSize);
            }

            // [Building packet.Links] Fetch HTTP request overhead data
            packet.links = new Links(Request.RequestUri.AbsoluteUri, request.HttpMethod, "self");

            // [Building packet.Offenders] If paging is set to false, send us the whole list
            if (request.QueryString["pagingInput"] == "false")
            {
                packet.offenders = offenderList;
            }
            else
            {
                // Attach our matched Offenders according to the page settings setup by the user

                // Handles if the pageNumber starts the List outside of bounds
                if (((pageNumber - 1) * pageSize) >= offenderList.Count)
                {
                    packet.offenders = new List<Offenders>();
                }

                // Handles if the pageSize on the selected page extends past the bounds of the list
                else if (((pageNumber - 1) * pageSize) < offenderList.Count && (((pageNumber - 1) * pageSize) + pageSize) > offenderList.Count)
                {
                    packet.offenders = offenderList.GetRange(((pageNumber - 1) * pageSize), offenderList.Count - ((pageNumber - 1) * pageSize));
                }

                // No out of bounds errors, simply fetch the offender set based on the user's paging settings
                else
                {
                    packet.offenders = offenderList.GetRange(((pageNumber - 1) * pageSize), pageSize);
                }
            }

            return Ok(packet);
        }
    }
}
