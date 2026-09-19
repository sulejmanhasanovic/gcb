using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Collections.Generic;
using Resources;
using System.IO;
using System.Text;
using System.Xml;
using System.Globalization;
using JIIS.DataLayer;
using log4net;
using JIIS.Web.Classes;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace JIIS.Web.Phase3.Tracking
{
    public partial class DeniedVoters : BasePage
    {
        private int _count = 0;

        List<string> list = new List<string>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["PositionRank"] == null)
                Response.Redirect("~/session.aspx");
            DataSet ds = new DataSet();
            ds = Functions.oktomvriIDpagePosition(38, int.Parse(Session["PositionRank"].ToString()));

            if (ds.Tables[0].Rows[0][0].ToString() == "0")
                Response.Redirect("~/Default.aspx");
          
            if (!Page.IsPostBack)
            {
                btnSave.Visible = false;

                Page.Title = LanguageText.tr_DeniedVoters;
                Literal1.Text = LanguageText.tr_DeniedVoters;
                Literal2.Text = LanguageText.tr_DeniedVoters;
                Literal2.Visible = false;
                Literal1.Visible = true;
            }
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Phase3/Tracking/BagsControlCount.aspx");
        }

        protected void ddl_DataBound(object sender, EventArgs e)
        {
            DropDownList ddl = (DropDownList)sender;
            ddl.Items.Insert(0, new ListItem(LanguageText.fvlchoose, ""));
        }

       

        protected void btnSave_Click(object sender, EventArgs e)
        {   
                    try
                    {
                        Response.Redirect("~/Phase3/Tracking/AddEditDeniedVoter.aspx?id=" + "-2");
                    }
                    catch (Exception )
                    {

                    }
        }

       


        

        protected void btnUpdateNoEnv_Click(object sender, EventArgs e)
        {
            
        }

        protected void imgbtnDeleteDenVoters_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton imgbtnDeleteDeniedVoters = (ImageButton)sender;
            GridViewRow row = (GridViewRow)imgbtnDeleteDeniedVoters.NamingContainer;
            //gvDeniedVoter.DeleteRow(row.RowIndex);
            int deniedVoter = Convert.ToInt32(gvDeniedVoter.DataKeys[row.RowIndex].Value);
            Functions.DeleteDeniedVoter(deniedVoter);
            gvDeniedVoter.DataBind();
        }

        protected void GridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                _count++;
                e.Row.Cells[0].Text = _count + ".";
                ((ImageButton)e.Row.Cells[5].FindControl("imgbtnDelete")).OnClientClick = "javascript:return window.confirm('" + LanguageText.PgGCBUsersConfirmDeletingDeniedVoter + "');";
                ((HyperLink)e.Row.Cells[5].FindControl("hlEdit")).NavigateUrl = "~/Phase3/Tracking/AddEditDeniedVoter.aspx?id=" + gvDeniedVoter.DataKeys[e.Row.RowIndex].Value;
            }
        }

        
    }
}
