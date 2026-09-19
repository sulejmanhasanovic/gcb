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
    public partial class BoxEdit : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["PositionRank"] == null)
                Response.Redirect("~/session.aspx");
        }

        protected void ddl_DataBound(object sender, EventArgs e)
        {
            DropDownList ddl = (DropDownList)sender;
            ddl.Items.Insert(0, new ListItem(LanguageText.fvlchoose, ""));
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Functions.p3_updateBox(int.Parse(txtTotalNoOfEnvelopes.Text),
                int.Parse(txtRejectedInSorting.Text), ddlBoxes.SelectedValue, DropDownList1.SelectedValue);
            if (gvBoxDetail.Rows.Count > 0)
            {
                foreach (GridViewRow gvRow in gvBoxDetail.Rows)
                {
                    TextBox txtBallotsSorted = (TextBox)gvRow.FindControl("tBoxNumberEnvLevel");
                    TextBox txtBallotsCounted = (TextBox)gvRow.FindControl("tBoxControlCount");
                    TextBox txtBallotsValid = (TextBox)gvRow.FindControl("tBoxValidBallots");
                    TextBox txtBallotsInValid = (TextBox)gvRow.FindControl("tBoxInvalidBallots");
                    Functions.p3_updateBoxDetail(int.Parse(gvBoxDetail.DataKeys[gvRow.RowIndex].Value.ToString()),
                        int.Parse(txtBallotsSorted.Text), int.Parse(txtBallotsCounted.Text),
                        int.Parse(txtBallotsValid.Text), int.Parse(txtBallotsInValid.Text));
                }
            }
            SetData();
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Phase3/Tracking/BoxCounting.aspx");
        }

        protected void ddlBoxes_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetData();
        }

        private void SetData()
        {
            panelData.Visible = true;
            DataSet dsBox = Functions.p3_getBoxForEdit(ddlBoxes.SelectedValue);
            //lblStatus.Text = dsBox.Tables[0].Rows[0]["BoxStatusDesc"].ToString();
            //03.10.2012 Nedim
            int index = 1;
            if (dsBox.Tables[0].Rows[0]["BoxStatusDesc"].ToString() == "Formirana")
                index = 1;
            if (dsBox.Tables[0].Rows[0]["BoxStatusDesc"].ToString() == "Napunjena")
                index = 2;
            if (dsBox.Tables[0].Rows[0]["BoxStatusDesc"].ToString() == "Na sortiranju")
                index = 3;
            if (dsBox.Tables[0].Rows[0]["BoxStatusDesc"].ToString() == "Sortirana")
                index = 4;
            if (dsBox.Tables[0].Rows[0]["BoxStatusDesc"].ToString() == "Na brojanju")
                index = 5;
            if (dsBox.Tables[0].Rows[0]["BoxStatusDesc"].ToString() == "Prebrojana")
                index = 6;
            if (dsBox.Tables[0].Rows[0]["BoxStatusDesc"].ToString() == "Arhivirana")
                index = 7;

            DropDownList1.SelectedValue = index.ToString();
            
            txtTotalNoOfEnvelopes.Text = dsBox.Tables[0].Rows[0]["TotalNoOfEnvelopes"].ToString();
            txtRejectedInSorting.Text = dsBox.Tables[0].Rows[0]["RejectedInSorting"].ToString();
        }
    }
}
