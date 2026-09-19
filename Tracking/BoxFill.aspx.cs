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
    public partial class BoxFill : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["PositionRank"] == null)
                Response.Redirect("~/session.aspx");
            DataSet ds = new DataSet();
            ds = Functions.oktomvriIDpagePosition(48, int.Parse(Session["PositionRank"].ToString()));

            if (ds.Tables[0].Rows[0][0].ToString() == "0")
                Response.Redirect("~/Default.aspx");

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }

        protected void GridView1_DataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                int numberEnvelopes = Functions.p3_getNumberOfEnvelopesCounted(e.Row.Cells[2].Text,
                    e.Row.Cells[3].Text, int.Parse(GridView1.DataKeys[e.Row.RowIndex].Value.ToString()));
                e.Row.Cells[4].Text = numberEnvelopes.ToString();
            }
        }
    }
}
