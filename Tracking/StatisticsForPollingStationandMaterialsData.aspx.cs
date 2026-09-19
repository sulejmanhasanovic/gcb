using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;
using JIIS.Web.Classes;


namespace JIIS.Web.Phase3.Tracking
{
    public partial class StatisticsForPollingStationandMaterialsData: BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["PositionRank"] == null)
                Response.Redirect("~/session.aspx");
            if (!Page.IsPostBack)
            {
                Session["Languages"] = "1";    
            }
           
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            Response.Redirect("StatisticsForPollingStationandMaterials.aspx");
        }

       

        
    }
}
