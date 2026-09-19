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
    public partial class BoxCounting : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["PositionRank"] == null)
                Response.Redirect("~/session.aspx");
            DataSet ds = new DataSet();
            ds = Functions.oktomvriIDpagePosition(50, int.Parse(Session["PositionRank"].ToString()));

            if (ds.Tables[0].Rows[0][0].ToString() == "0")
                Response.Redirect("~/Default.aspx");

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

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            Functions.p3_UpdateBoxStatus("5", ddlBoxes.SelectedItem.Value.ToString());
            GridView1.DataBind();
            ddlBoxes.DataBind();
        }

        protected void linkCounting_Click(object sender, EventArgs e)
        {
            LinkButton link = (LinkButton)sender;
            GridViewRow gvRow = (GridViewRow)link.NamingContainer;

            Session["boxNumber"] = gvRow.Cells[1].Text;
            Response.Redirect("BoxCountingDetails.aspx?id=" + GridView1.DataKeys[gvRow.RowIndex].Value.ToString() +
                "&Combination=" + gvRow.Cells[3].Text);
        }
    }
}
