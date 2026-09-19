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
    public partial class BagsUpdateVerification : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["PositionRank"] == null)
                Response.Redirect("~/session.aspx");
            DataSet ds1 = new DataSet();
            ds1 = Functions.oktomvriIDpagePosition(45, int.Parse(Session["PositionRank"].ToString()));

            if (ds1.Tables[0].Rows[0][0].ToString() == "0")
                Response.Redirect("~/Default.aspx");


            if (!IsPostBack)
            {
                Session.Remove("clerkID");
                btnChangeStatus.Visible = false;
            }
            try
            {
                DataSet ds = Functions.p3_getNumberOfScannedVoters(ddlBagNumber.SelectedValue);
                if (ds != null)
                {
                    lblAccScanned.Text = ds.Tables[0].Rows[0]["Accepted"].ToString();
                    lblDenScanned.Text = ds.Tables[0].Rows[0]["Denied"].ToString();
                }
            }
            catch (Exception )
            {

            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            bool checkAcc = true;
            bool checkDen = true;
            bool checkTot = true;
            if (lblAccScanned.Text != tBoxConfirmed.Text)
            {
                lblMsgAcc.Text = "Ima razlika";
                checkAcc = false;
            }
            else
            {
                lblMsgAcc.Text = "";
                checkAcc = true;
            }
            if (lblDenScanned.Text != tBoxDenied.Text)
            {
                lblMsgDen.Text = "Ima razlika";
                checkDen = false;
            }
            else
            {
                lblMsgDen.Text = "";
                checkDen = true;
            }
            if (int.Parse(lblReceivedVerification.Text) != (int.Parse(tBoxConfirmed.Text) + int.Parse(tBoxDenied.Text)))
            {
                lblMessage.Text = "Ima razlika";
                checkTot = false;
            }
            else
            {
                lblMessage.Text = "";
                checkTot = true;
            }
            if (checkAcc && checkDen && checkTot)
            {

                Functions.p3_VerificationUpdate(ddlBagNumber.SelectedItem.Value.ToString(), int.Parse(tBoxConfirmed.Text.ToString()), int.Parse(tBoxDenied.Text.ToString()));

                Functions.p3_FinalizeBagforScanning(ddlBagNumber.SelectedValue, 0);

                btnChangeStatus.Visible = false;
                Clear();
                GridView1.DataBind();

            }
            else
            {
                btnChangeStatus.Visible = true;
            }

            //Response.Redirect("~/Phase3/Tracking/BagsReceive.aspx");
            //lblMessage.Text = "Bag received for verification";
            
        }

        private void Clear()
        {
            //ddlChooseTypeBag.SelectedItem.Value = "-1";
            ddlBagNumber.DataBind();
            tBoxConfirmed.Text = string.Empty;
            tBoxDenied.Text = string.Empty;
            lblDate.Text = string.Empty;
            lblReceivedVerification.Text = string.Empty;
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }

        protected void ddl_DataBound(object sender, EventArgs e)
        {
            DropDownList ddl = (DropDownList)sender;
            ddl.Items.Insert(0, new ListItem(LanguageText.fvlchoose, ""));
        }

        protected void ddlPoBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlBagNumber.SelectedItem.Value.ToString() != "")
            {
                //DataSet ds = Functions.p3_getDataFromBagsByID(ddlBagNumber.SelectedItem.Value.ToString());
                // Necko ...
                DataSet ds = Functions.p3_getBagNameFromBagsByPSCode(ddlBagNumber.SelectedItem.Value.ToString());
                lblDate.Text = ds.Tables[0].Rows[0]["DateReceived"].ToString();
                lblReceivedVerification.Text = ds.Tables[0].Rows[0]["VerificationReceived"].ToString();
                //if (ddlChooseTypeBag.SelectedValue == "P")
                //{
                //    int i = Functions.p3_getScannedVotesByMail(ddlBagNumber.SelectedValue);
                //    tBoxConfirmed.Text = i.ToString();
                //    tBoxDenied.Text = (Convert.ToInt32(ds.Tables[0].Rows[0]["VerificationReceived"]) - i).ToString();
                //}
            }
        }

        protected void linkPreview_Click(object sender, EventArgs e)
        {
            LinkButton link = (LinkButton)sender;
            GridViewRow gvRow = (GridViewRow)link.NamingContainer;

            Session["clerkID"] = gvStatistic.DataKeys[gvRow.RowIndex].Value.ToString();
            //gvStatisticByClerk.DataBind();
        }

        protected void gvStatisticByClerk_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ((ImageButton)e.Row.Cells[6].FindControl("imgbtnDelete")).OnClientClick = "javascript:return window.confirm('" + LanguageText.p3_deleteScan + "');";
                if (e.Row.Cells[5].Text != "")
                {
                    e.Row.Cells[5].Text = Convert.ToDateTime(e.Row.Cells[5].Text).ToString("HH:mm");
                }
                if (e.Row.Cells[3].Text == "True")
                {
                    e.Row.Cells[3].Text = "Da";
                }
                if (e.Row.Cells[3].Text == "False")
                {
                    e.Row.Cells[3].Text = "Ne";
                }
            }
        }

        protected void imgbtnDeleteOrgUnit_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton imgbtnDeleteOrgUnit = (ImageButton)sender;
            GridViewRow row = (GridViewRow)imgbtnDeleteOrgUnit.NamingContainer;
            int orgUnitId = Convert.ToInt32(gvStatisticByClerk.DataKeys[row.RowIndex].Value);

            Functions.DeleteScannedVoterBag(orgUnitId, ddlBagNumber.SelectedValue);
            gvStatisticByClerk.DataBind();
            gvStatistic.DataBind();
        }

        protected void gvStatistic_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DataSet ds = Functions.p3_getScannedCountByClerk(ddlBagNumber.SelectedValue,
                    int.Parse(gvStatistic.DataKeys[e.Row.RowIndex].Value.ToString()));

                e.Row.Cells[1].Text = ds.Tables[0].Rows[0][0].ToString();
                e.Row.Cells[2].Text = ds.Tables[0].Rows[0][1].ToString();
            }
        }

        protected void btnChangeStatus_Click(object sender, EventArgs e)
        {
            Functions.p3_updateBagStatusOneStepBack(ddlBagNumber.SelectedValue, "2");
            Clear();
            //GridView1.DataBind();
            lblMessage.Text = "Vreca je vratena verifikacija - prijem materijala";
            //lblMessage0.Visible = false;
            btnChangeStatus.Visible = false;
        }
    }
}
