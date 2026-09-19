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
    public partial class BagEdit : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["PositionRank"] == null)
                Response.Redirect("~/session.aspx");            
        }

        private void SetData()
        {
            DataSet dsBagDetails = Functions.p3_getBagDetailsForEdit(ddlbagNumber.SelectedValue);
            //lblStatus.Text = dsBagDetails.Tables[0].Rows[0]["BagStatusName"].ToString();
            int index = 1;
            if (dsBagDetails.Tables[0].Rows[0]["BagStatusName"].ToString() == "Received")
                index = 1;
            else if (dsBagDetails.Tables[0].Rows[0]["BagStatusName"].ToString() == "Control Count")
                index = 2;
            else if (dsBagDetails.Tables[0].Rows[0]["BagStatusName"].ToString() == "Verification")
                index = 3;
            else if (dsBagDetails.Tables[0].Rows[0]["BagStatusName"].ToString() == "Control & Pack")
                index = 4;
            else if (dsBagDetails.Tables[0].Rows[0]["BagStatusName"].ToString() == "Finished")
                index = 5;
            DropDownList1.SelectedValue= index.ToString();
            txtBeforeVerificationApproved.Text = dsBagDetails.Tables[0].Rows[0]["BeforeVerificationApproved"].ToString();
            txtBeforeVerificationRejected.Text = dsBagDetails.Tables[0].Rows[0]["BeforeVerificationRejected"].ToString();
            txtTotalReceivedEnvelopes.Text = dsBagDetails.Tables[0].Rows[0]["TotalReceivedEnvelopes"].ToString();
            txtVerificationAccepted.Text = dsBagDetails.Tables[0].Rows[0]["VerificationAccepted"].ToString();
            txtVerificationReceived.Text = dsBagDetails.Tables[0].Rows[0]["VerificationReceived"].ToString();
            txtVerificationRejected.Text = dsBagDetails.Tables[0].Rows[0]["VerificationRejected"].ToString();
            panelData.Visible = true;
        }

        protected void ddl_DataBound(object sender, EventArgs e)
        {
            DropDownList ddl = (DropDownList)sender;
            ddl.Items.Insert(0, new ListItem(LanguageText.fvlchoose, ""));
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }

        protected void ddlbagNumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetData();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Functions.p3_updateBagDetails(int.Parse(txtTotalReceivedEnvelopes.Text),
                int.Parse(txtVerificationReceived.Text), int.Parse(txtVerificationAccepted.Text),
                int.Parse(txtVerificationRejected.Text), int.Parse(txtBeforeVerificationApproved.Text),
                int.Parse(txtBeforeVerificationRejected.Text), ddlbagNumber.SelectedValue, DropDownList1.SelectedValue);
            if (gvBagDetails.Rows.Count > 0)
            {
                foreach (GridViewRow gvRow in gvBagDetails.Rows)
                {
                    TextBox txtBallotsSorted = (TextBox)gvRow.FindControl("tBoxNumberEnvLevel");
                    TextBox txtBallotsCounted = (TextBox)gvRow.FindControl("tBoxControlCount");
                    TextBox txtBallotsValid = (TextBox)gvRow.FindControl("tBoxValidBallots");
                    TextBox txtBallotsInValid = (TextBox)gvRow.FindControl("tBoxInvalidBallots");
                    Functions.p3_updateBagDetail(int.Parse(gvBagDetails.DataKeys[gvRow.RowIndex].Value.ToString()),
                        int.Parse(txtBallotsSorted.Text), int.Parse(txtBallotsCounted.Text),
                        int.Parse(txtBallotsValid.Text), int.Parse(txtBallotsInValid.Text));
                }
            }
            SetData();
        }
    }
}
