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
    public partial class CreateBox : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["PositionRank"] == null)
                Response.Redirect("~/session.aspx");
            DataSet ds = new DataSet();
            ds = Functions.oktomvriIDpagePosition(46, int.Parse(Session["PositionRank"].ToString()));

            if (ds.Tables[0].Rows[0][0].ToString() == "0")
                Response.Redirect("~/Default.aspx");

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Functions.p3_CreateBox(ddlCombination.SelectedItem.Value.ToString(), ddlChooseTypeBag.SelectedItem.Value.ToString());
            //Clear();
            GridView1.DataBind();
        }

        private void Clear()
        {
            ddlCombination.SelectedItem.Value = "";
            //ddlChooseTypeBag.SelectedItem.Value = "";
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }

        protected void ddlCombination_DataBound(object sender, EventArgs e)
        {
            DropDownList ddl = (DropDownList)sender;
            ddl.Items.Insert(0, new ListItem(LanguageText.fvlchoose, ""));
            ddl.Items.Insert(1, new ListItem("KR", "KR"));
        }

        protected void ddl_DataBound(object sender, EventArgs e)
        {
            DropDownList ddl = (DropDownList)sender;
            ddl.Items.Insert(0, new ListItem(LanguageText.fvlchoose, ""));
          
            
        }

        protected void ddlChooseTypeBag_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (ddlChooseTypeBag.SelectedValue == "P")
            //{
                //ddlCombination.Items.Insert(1, new ListItem("KR", "KR"));
            //}
            //else
            //{
            //    if (ddlCombination.Items[1].Text.Contains("KR"))
             //   {
              //      ddlCombination.Items.RemoveAt(1);
              //  }
            //}
        }
        protected void GridView1_DataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                int numberEnvelopes = Functions.p3_getNumberOfEnvelopesCounted(e.Row.Cells[2].Text,
                    e.Row.Cells[3].Text, int.Parse(e.Row.Cells[1].Text));
                e.Row.Cells[4].Text = numberEnvelopes.ToString();
            }
        }
    }
}
