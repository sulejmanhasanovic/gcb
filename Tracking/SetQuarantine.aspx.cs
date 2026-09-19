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
    public partial class SetQuarantine : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["PositionRank"] == null)
                Response.Redirect("~/session.aspx");
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {

        }

        protected void Button5_Click(object sender, EventArgs e)
        {

        }

        protected void gvTracking_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lbQuarantine = (Label)e.Row.FindControl("lblQuarantine");
                LinkButton linkQuarantine = (LinkButton)e.Row.FindControl("linkQuarantine");
                LinkButton linkUnQuarantine = (LinkButton)e.Row.FindControl("linkUnQuarantine");

                if (lbQuarantine.Text == "True")
                {
                    lbQuarantine.Text = "Quarantined";
                    linkQuarantine.Visible = false;
                    linkUnQuarantine.Visible = true;
                }
                else
                {
                    lbQuarantine.Text = "Not Quarantined";
                    linkQuarantine.Visible = true;
                    linkUnQuarantine.Visible = false;
                }
            }
        }

        protected void linkQuarantine_Click(object sender, EventArgs e)
        {
            LinkButton link = (LinkButton)sender;
            GridViewRow row = (GridViewRow)link.NamingContainer;

            Functions.p3_SetQuarantine((int)gvTracking.DataKeys[row.RowIndex].Value, ddlPollingStation.SelectedValue, 1);

            gvTracking.DataBind();
        }

        protected void linkUnQuarantine_Click(object sender, EventArgs e)
        {
            LinkButton link = (LinkButton)sender;
            GridViewRow row = (GridViewRow)link.NamingContainer;

            Functions.p3_SetQuarantine((int)gvTracking.DataKeys[row.RowIndex].Value, ddlPollingStation.SelectedValue, 0);

            gvTracking.DataBind();
        }

        protected void ddlPollingStation_DataBound(object sender, EventArgs e)
        {
            ddlPollingStation.Items.Insert(0, new ListItem(LanguageText.fvlchoose, ""));
        }
    }
}
