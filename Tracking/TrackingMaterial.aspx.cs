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

namespace JIIS.Web.Phase3.Tracking
{
    public partial class TrackingMaterial : BasePage
    {
        private int areaid;
        private Users loggedUser = new Users();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["PositionRank"] == null)
                Response.Redirect("~/session.aspx");

            loggedUser = (Users)Session["user"];
            areaid = int.Parse(loggedUser.Supervisor_ID.Remove(0, 1));
        }

        protected void Button5_Click(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            DataSet ds = Functions.p3_GetAllPSCodes();
            bool check = false;

            foreach(DataRow dr in ds.Tables[0].Rows)
            {
                if (dr[0].ToString() == txtPollingStation.Text)
                {
                    check = true;
                    break;
                }
            }

            if (check)
            {
                Session["station"] = txtPollingStation.Text;
                Response.Redirect("IntakeArea.aspx");
            }
            else
            {
                lblError.Visible = true;
            }            
        }
    }
}
