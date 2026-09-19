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
using Resources;
using System.Web.Configuration;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.IO;


namespace JIIS.Web.Phase3.Tracking.Reports
{
    public partial class ByCombination : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["PositionRank"] == null)
              Response.Redirect("~/session.aspx");

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect(String.Format("~/Phase3/Tracking/Reports/ByCombinationFirst.aspx?mode={0}&psbag={1}", ddlModes.SelectedValue, ddlBags.SelectedValue));
        }

        protected void btnThird_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Phase3/Tracking/Reports/PregledObradjenogMaterijala.aspx");
  
        }

        protected void btnForth_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Phase3/Tracking/Reports/OdbijeniPoRazlozima.aspx");
        }

        protected void btnFive_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Phase3/Tracking/Reports/KutijeVrece.aspx");
        }
      
    }
}
           
        
    

