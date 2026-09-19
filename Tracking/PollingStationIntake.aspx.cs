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
    public partial class PollingStationIntake : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["PositionRank"] == null)
                Response.Redirect("~/session.aspx");
            DataSet ds = new DataSet();
            ds = Functions.oktomvriIDpagePosition(33, int.Parse(Session["PositionRank"].ToString()));

            if (ds.Tables[0].Rows[0][0].ToString() == "0")
                Response.Redirect("~/Default.aspx");
        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
              for (int i = 0; i < gvUsers.Rows.Count; i++)
            {
                   TextBox tb = (TextBox)gvUsers.Rows[i].FindControl("TextBox1");
               
                Label tb1 = (Label)gvUsers.Rows[i].FindControl("Label1");
              CheckBox cb = (CheckBox)gvUsers.Rows[i].FindControl("cb");
                if (cb.Checked == true)
                        {
                            Functions.p3_InsertP3IntakePs(ddlLevels.SelectedItem.Value.ToString(), tb1.Text.ToString(), true, tb.Text.ToString());
                        }
                        //else
                        //{
                        //    Functions.p3_InsertP3IntakePs(ddlLevels.SelectedItem.Value.ToString(), tb1.Text.ToString(), false, tb.Text.ToString());
                        //}
                    }
             gvUsers.DataBind();
        }

            
             
        

        protected void Button5_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }

        protected void cboxAll_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cbox = (CheckBox)gvUsers.HeaderRow.FindControl("cboxAll");

            foreach (GridViewRow row in gvUsers.Rows)
            {
                CheckBox cbox1 = (CheckBox)row.FindControl("cboxUser");

                if (cbox.Checked)
                {
                    cbox1.Checked = true;
                }
                else
                {
                    cbox1.Checked = false;
                }
            }
        }

    

        protected void gvUsers_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{
            //    e.Row.FindControl
            //}
        }

        protected void ddlLevels_DataBound(object sender, EventArgs e)
        {
            DropDownList ddl = (DropDownList)sender;
            ddlLevels.Items.Insert(0, new ListItem(LanguageText.fvlchoose, ""));
            if (ddlLevels.SelectedItem.Text == LanguageText.fvlchoose)
            {

                btnSend.Visible = false;
            }
            else
            {
                btnSend.Visible = true;
            }
        }

        //protected void linkComment_Click(object sender, EventArgs e)
        //{
        //    panelComment.Visible = true;
        //    LinkButton link = (LinkButton)sender;
        //    GridViewRow row = (GridViewRow)link.NamingContainer;

        //    txtMessage.Text = row.Cells[1].Text;
        //}

        protected void Button6_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < gvUsers.Rows.Count; i++)
            {
                CheckBox cb = (CheckBox)gvUsers.Rows[i].FindControl("cb");
                cb.Checked = true;
            } 
        }

        protected void ddlLevels_SelectedIndexChanged(object sender, EventArgs e)
        {
            skrij.Visible = true;
            if (ddlLevels.SelectedItem.Text == LanguageText.fvlchoose)
            {
                skrij.Visible = false;

            }
            else
            { btnSend.Visible = true; }
        }

        protected void gvUsers_DataBound(object sender, EventArgs e)
        {
            if (gvUsers.Rows.Count > 0)
            {
                skrij.Visible = true;
                Div1.Visible = true;
                btnSend.Visible = true;
            }
            else
            {
                skrij.Visible = false;
                Div1.Visible = false;
                btnSend.Visible = false;
            }
        }

      
      
    }
}
