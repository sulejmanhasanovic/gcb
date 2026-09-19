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
    public partial class BagsPackaging : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["PositionRank"] == null)
                Response.Redirect("~/session.aspx");
            DataSet ds = new DataSet();
            ds = Functions.oktomvriIDpagePosition(47, int.Parse(Session["PositionRank"].ToString()));

            if (ds.Tables[0].Rows[0][0].ToString() == "0")
                Response.Redirect("~/Default.aspx");
        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            if (ddlChooseTypeBag.SelectedValue == "P")
            {
                Session["typePS"] = "P";
            }
            else
            {
                Session["typePS"] = "O";
            }
            Session["ConfirmedEnv"] = lblConfirmed.Text;
            Session["deniedEnv"] = lblDenied.Text;
            Response.Redirect("~/Phase3/Tracking/BagsPackagingDetail.aspx?PSType=" + ddlChooseTypeBag.SelectedItem.Value.ToString() + "&PS=" + ddlBagNumber.SelectedItem.Value.ToString());
        }

        private void Clear()
        {
            ddlChooseTypeBag.SelectedItem.Value = "-1";
            ddlBagNumber.SelectedItem.Value = "-1";
            lblDate.Text = string.Empty;
            lblReceivedVerification.Text = string.Empty;
            lblConfirmed.Text = string.Empty;
            lblDenied.Text = string.Empty;
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
                if (ds.Tables[0].Rows.Count > 0)
                {
                    lblDate.Text = ds.Tables[0].Rows[0]["DateReceived"].ToString();
                    lblReceivedVerification.Text = ds.Tables[0].Rows[0]["VerificationReceived"].ToString();
                    lblConfirmed.Text = ds.Tables[0].Rows[0]["VerificationAccepted"].ToString();
                    lblDenied.Text = ds.Tables[0].Rows[0]["VerificationRejected"].ToString();
                    if (ddlChooseTypeBag.SelectedValue == "P" && ddlBagNumber.SelectedValue.Contains("aa"))
                    {
                        lblReceivedVerification.Text = ds.Tables[0].Rows[0]["TotalReceivedEnvelopes"].ToString();
                        lblConfirmed.Text = "0";
                        lblDenied.Text = ds.Tables[0].Rows[0]["TotalReceivedEnvelopes"].ToString();
                    }
                }
            }
        }
    }
}
