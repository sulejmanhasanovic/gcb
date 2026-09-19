using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JIIS.DataLayer;
using log4net;
using JIIS.Web.Classes;
using Resources;
using System.Data;

namespace JIIS.Web.Phase3.Tracking
{
    public partial class SearchVoters : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["PositionRank"] == null)
                Response.Redirect("~/session.aspx");
            DataSet ds = new DataSet();
            ds = Functions.oktomvriIDpagePosition(146, int.Parse(Session["PositionRank"].ToString()));

            if (ds.Tables[0].Rows[0][0].ToString() == "0")
                Response.Redirect("~/Default.aspx");
            if (!IsPostBack)
            {
                dbVoters.SelectParameters[0].DefaultValue = "0";
                dbVoters.SelectParameters[1].DefaultValue = "0";
                dbVoters.SelectParameters[2].DefaultValue = "0";
                dbVoters.SelectParameters[3].DefaultValue = "0";
                //dbcandidates.SelectParameters[3].DefaultValue = "-1";
                //dbcandidates.SelectParameters[4].DefaultValue = "-1";
                dbVoters.Select(DataSourceSelectArguments.Empty);
                gvOrgUnits.DataBind();
            }
        }
        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }

        protected void gvOrgUnits_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lb = (Label)e.Row.FindControl("lblocked");
                HyperLink hl = (HyperLink)e.Row.FindControl("HyperLink1");
                ImageButton ib = (ImageButton)e.Row.FindControl("ImageButton1");
                //if (lb.Text == "True")
                //{
                //    hl.Visible = false;
                //    ib.Visible = false;
                //}
                //ib.OnClientClick = "javascript:return window.confirm(\"" + LanguageText.deletecandidatepf + "\")";

            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (TextBox2.Text == string.Empty)
            {
                dbVoters.SelectParameters[0].DefaultValue = "0";
            }
            if (TextBox3.Text == string.Empty)
            {
                dbVoters.SelectParameters[1].DefaultValue = "0";
            }
            if (TextBox4.Text == string.Empty)
            {
                dbVoters.SelectParameters[2].DefaultValue = "0";
            }
            if (TextBox1.Text == string.Empty)
            {
                dbVoters.SelectParameters[3].DefaultValue = "0";
            }

            DataView view = (DataView)dbVoters.Select(DataSourceSelectArguments.Empty);
            gvOrgUnits.DataBind();
        }

    }
}
