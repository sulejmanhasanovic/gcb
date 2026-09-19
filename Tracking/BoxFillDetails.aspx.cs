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
    public partial class BoxFillDetails : BasePage
    {
        DataSet dsBox = new DataSet();
        string boxType, combination = string.Empty;
        int boxNo = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["PositionRank"] == null)
                Response.Redirect("~/session.aspx");
            string boxID = Request.QueryString["id"].ToString();
            dsBox = Functions.p3_getDataFromBox(int.Parse(boxID));

            lblBoxNumber.Text = dsBox.Tables[0].Rows[0]["BoxName"].ToString();
            boxNo = int.Parse(dsBox.Tables[0].Rows[0]["BoxNo"].ToString());
            boxType = dsBox.Tables[0].Rows[0]["BoxType"].ToString();
            combination = dsBox.Tables[0].Rows[0]["BoxCombination"].ToString();
            int numberEnvelopes = Functions.p3_getNumberOfEnvelopesCounted(combination,boxType, boxNo);
            if (dsBox.Tables[0].Rows[0]["BoxStatus"].ToString() == "2")
            {
                tBoxNumberEnvelopes.Text = dsBox.Tables[0].Rows[0]["TotalNoOfEnvelopes"].ToString();
            }

            lblHowMuchEnvelopes.Text = numberEnvelopes.ToString();
            tBoxNumberEnvelopes.Text = numberEnvelopes.ToString();
            tBoxNumberEnvelopes.ReadOnly = true;

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (chkBoxClosed.Checked)
            {
                Functions.p3_updateBoxTotalEnvelopes(lblBoxNumber.Text, int.Parse(tBoxNumberEnvelopes.Text.ToString()), "3");
                Response.Redirect("~/Phase3/Tracking/BoxFill.aspx");
            }
            else
            {
                Functions.p3_updateBoxTotalEnvelopes(lblBoxNumber.Text, int.Parse(tBoxNumberEnvelopes.Text.ToString()), "2");
                Response.Redirect("~/Phase3/Tracking/BoxFill.aspx");
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Phase3/Tracking/BoxFill.aspx");
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Phase3/Tracking/BoxFill.aspx");
        }
    }
}
