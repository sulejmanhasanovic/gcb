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
    public partial class VerificationReceive : BasePage
    {
        int userId;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["PositionRank"] == null)
                Response.Redirect("~/session.aspx");
            if (!Page.IsPostBack)
            {
                TextBox3_CalendarExtender.SelectedDate = DateTime.Now;
            }
           
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            int vkupno = int.Parse(tBoxRegEnvelopes.Text.ToString()) + int.Parse(tBoxFastPost.Text.ToString()) + int.Parse(tBoxUndelivered.Text.ToString());
            Users loggedUser = (Users)HttpContext.Current.Session["User"];
            userId = loggedUser.ID;
            Functions.p3_InsertInto_p3_PO_Package(int.Parse(ddlPoBox.SelectedItem.Value.ToString()), int.Parse(tBoxBag.Text.ToString()), int.Parse(tBoxShipment.Text.ToString()),
                int.Parse(tBoxShipment.Text.ToString()), int.Parse(tBoxFastPost.Text.ToString()), int.Parse(tBoxUndelivered.Text.ToString()),
                int.Parse(tBoxOthers.Text.ToString()), vkupno, tBoxDateReceived.Text.ToString(), tBoxComment.Text.ToString(),
                ddlTypeShipment.SelectedItem.Text.ToString(), userId);
            Response.Redirect("~/Default.aspx");
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }
    }
}
