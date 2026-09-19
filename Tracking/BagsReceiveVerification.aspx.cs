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
    public partial class BagsReceiveVerification : BasePage
    {
      
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["PositionRank"] == null)
                Response.Redirect("~/session.aspx");
            DataSet ds = new DataSet();
            ds = Functions.oktomvriIDpagePosition(39, int.Parse(Session["PositionRank"].ToString()));

            if (ds.Tables[0].Rows[0][0].ToString() == "0")
                Response.Redirect("~/Default.aspx");
            if (!IsPostBack)
            {
                btnChangeStatus.Visible = false;
                //Session["t"] = 0;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
          
            if (int.Parse(lblApprovedControlCount.Text.ToString()) != int.Parse(tBoxNumberEnvelopes.Text.ToString()))
            { 
                lblMessage0.Visible = true;
                btnChangeStatus.Visible = true;
                //Session["t"] = 1;
            }
           
            else
            {
                lblMessage0.Visible = false;
                btnChangeStatus.Visible = false;
                Functions.p3_VerificationReceivedEnvelopesUpdate(ddlBagNumber.SelectedItem.Value.ToString(), int.Parse(tBoxNumberEnvelopes.Text.ToString()));
                //if (ddlChooseTypeBag.SelectedValue == "P")
                //{
                int num = Functions.p3_ActivateBagforScanning(ddlBagNumber.SelectedValue);
                //}

                //Response.Redirect("~/Phase3/Tracking/BagsReceive.aspx");
                lblMessage.Text = LanguageText.tr_bagReceivedVerification;
                Clear();
                GridView1.DataBind();
                //Session["t"] = 0;
            }
        }

        private void Clear()
        {
            //ddlChooseTypeBag.SelectedItem.Value = "-1";
            ddlBagNumber.DataBind();
            tBoxNumberEnvelopes.Text = string.Empty;
            lblDate.Text = string.Empty;
            lblApprovedControlCount.Text = string.Empty;
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
            //DataSet ds = Functions.p3_getBagNameFromBagsByID(int.Parse(ddlBagNumber.SelectedItem.Value.ToString()));
            // Necko EI ---- 23.09.2012
            DataSet ds = Functions.p3_getBagNameFromBagsByPSCode(ddlBagNumber.SelectedItem.Value.ToString());

            try
            {
                lblApprovedControlCount.Text = ds.Tables[0].Rows[0]["BeforeVerificationApproved"].ToString();
                lblDate.Text = ds.Tables[0].Rows[0]["DateReceived"].ToString();
            }
            catch { }
        }

        protected void btnChangeStatus_Click(object sender, EventArgs e)
        {
            Functions.p3_updateBagStatusOneStepBack(ddlBagNumber.SelectedValue, "1");
            Clear();
            GridView1.DataBind();
            lblMessage.Text = "Vreca je vratena na pripremu za verifikacije";
            lblMessage0.Visible = false;
            btnChangeStatus.Visible = false;
        }
    }
}
