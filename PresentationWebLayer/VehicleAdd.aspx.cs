using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;

namespace PresentationWebLayer
{
    public partial class VehicleAdd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        [WebMethod]
        public static string Add(int vehicleType, string brand, string model, string colour, int year, int numberOfSeats, bool hasAirConditioning, bool hasABS, bool hasRadio)
        {
            try
            {
                return Newtonsoft.Json.JsonConvert.SerializeObject(new {Saved = Handler.SaveVehicle(vehicleType, brand, model, colour, year, numberOfSeats, hasAirConditioning, hasABS, hasRadio)});
            }
            catch (Exception ex)
            {
                return Newtonsoft.Json.JsonConvert.SerializeObject("{error:" + ex.Message + "}");
            }
        }
    }
}