using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using BusinessLayer;

namespace PresentationWebLayer
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static string Search(int vehicleType, int numberOfSeats)
        {
            try
            {
                return Newtonsoft.Json.JsonConvert.SerializeObject(BusinessLayer.Handler.SearchVehicle(vehicleType, numberOfSeats));
            }
            catch (Exception ex)
            {
                return Newtonsoft.Json.JsonConvert.SerializeObject("{error:" + ex.Message + "}");
            }
        }
    }
}