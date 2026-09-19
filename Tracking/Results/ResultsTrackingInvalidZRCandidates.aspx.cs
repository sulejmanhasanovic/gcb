using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using Resources;
using JIIS.Web.Classes;

namespace JIIS.Web.Phase3.Tracking.Results
{
    public partial class ResultsTrackingInvalidZRCandidates : BasePage
    {
        //private int retirevedRows = 0;
        DataSet dsUserNews = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["PositionRank"] == null)
                Response.Redirect("~/session.aspx");

            //if (Session["PositionRank"] != null)
            //{
            //    if (Convert.ToInt16(Session["PositionRank"]) != 0 & Convert.ToInt16(Session["PositionRank"]) != 1)
            //    {
            //        Response.Redirect("~/default.aspx", true);
            //    }
            //}
            if (!Page.IsPostBack)
            {

               
            }
        
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Phase3/Admin/DetalenPocetna.aspx");
        }

     
    }
}
