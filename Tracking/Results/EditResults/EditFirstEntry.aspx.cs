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

namespace JIIS.Web.Phase3.Tracking.Results.EditResults
{
    public partial class EditFirstEntry : BasePage
    {
        Users loggedUser;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["PositionRank"] == null)
                Response.Redirect("~/session.aspx");
            DataSet ds = new DataSet();
            ds = Functions.oktomvriIDpagePosition(56, int.Parse(Session["PositionRank"].ToString()));

            if (ds.Tables[0].Rows[0][0].ToString() == "0")
                Response.Redirect("~/Default.aspx");

            loggedUser = (Users)HttpContext.Current.Session["User"]; //ke se smene koga ke se povrze so menito
            Session["UserID"] = loggedUser.ID.ToString();


        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }

        protected void ddlActiveRace_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["race"] = int.Parse(ddlActiveRace.SelectedItem.Value);
        }
        protected void ImageButton1_OnClick(object sender, ImageClickEventArgs e)
        {
            ImageButton ImageButton1 = (ImageButton)sender;
            GridViewRow row = (GridViewRow)ImageButton1.NamingContainer;
            Session["kategorija"] = DropDownList1.SelectedValue.ToString();
            if (ddlActiveRace.SelectedValue.ToString() == "1" || ddlActiveRace.SelectedValue.ToString() == "5" || ddlActiveRace.SelectedValue.ToString() == "8")
            {
                Session["MunicipalityCode"] = row.Cells[0].Text;
                Session["MunicipalityName"] = row.Cells[1].Text;
                Session["PSNumber"] = row.Cells[2].Text;
                Session["idrace"] = ddlActiveRace.SelectedValue.ToString();
                Response.Redirect("EditVecinski.aspx");
            }
            else
            {
                if (ddlActiveRace.SelectedValue.ToString() == "10")
                {
                    Session["MunicipalityCode"] = row.Cells[0].Text;
                    Session["MunicipalityName"] = row.Cells[1].Text;
                    Session["PSNumber"] = row.Cells[2].Text;
                    Session["idrace"] = ddlActiveRace.SelectedValue.ToString();
                    Response.Redirect("EditZR_NM.aspx");
                }
                else
                {
                    Session["MunicipalityCode"] = row.Cells[0].Text;
                    Session["MunicipalityName"] = row.Cells[1].Text;
                    Session["PSNumber"] = row.Cells[2].Text;
                    Session["idrace"] = ddlActiveRace.SelectedValue.ToString();
                    Response.Redirect("EditOtvorena.aspx");
                }
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

            Session["MunicipalityCode"] = GridView1.SelectedRow.Cells[0].Text;
            Session["MunicipalityName"] = GridView1.SelectedRow.Cells[1].Text;
            Session["PSNumber"] = GridView1.SelectedRow.Cells[2].Text;
        }

    }
}
