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
using JIIS.Web.Classes;
using Resources;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace JIIS.Web.Phase3.Tracking.Results
{
    public partial class CCZROpenNM : BasePage
    {
        //Users loggedUser;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["PositionRank"] == null)
                Response.Redirect("~/session.aspx");
            lblPSCode.Text = Session["pscode"].ToString();
            lblRace.Text = Session["raceName"].ToString();
            lblLevelName.Text = Session["levelName"].ToString();
            lblLevelCode.Text = Session["level"].ToString();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            int votes = 0;
            //TextBox VotesTXT = (TextBox)GridView1.FindControl("txtVotes");
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                TextBox VotesTXT = (TextBox)GridView1.Rows[i].FindControl("txtVotes");
                votes = int.Parse(VotesTXT.Text.ToString());
                string listaid = GridView1.DataKeys[i].Value.ToString();
                int idlista = int.Parse(listaid.ToString());
                int listNumber = int.Parse(GridView1.Rows[i].Cells[1].Text.ToString());
                Functions.RESULTS_InsertIntoZRMayority(Session["pscode"].ToString(), Session["level"].ToString(), 10,
                    int.Parse(Session["kojpat"].ToString()), listNumber, idlista, votes, int.Parse(Session["UserID"].ToString()));
            }



            Functions.RESULTS_InsertUpdateIntoResultsArchive(int.Parse(Session["kojpat"].ToString()), Session["pscode"].ToString(), 10, Session["level"].ToString(), 3, 1, 0, int.Parse(Session["UserID"].ToString()), 0, 0, 0);
            if (int.Parse(Session["kojpat"].ToString()) == 1)
            {
                Functions.RESULTS_InsertUpdateIntoPSStatistic(2, Session["pscode"].ToString(), Session["level"].ToString(), 10, 1, 5, "OK", "Entry2");
            }
            else
            {
                Functions.RESULTS_InsertUpdateIntoPSStatistic(2, Session["pscode"].ToString(), Session["level"].ToString(), 10, 2, 5, "OK", "Entry3");
                Functions.RESULTS_CheckVecinskiGlas2TWOEntries(Session["pscode"].ToString(), Session["level"].ToString(), 10, int.Parse(Session["UserID"].ToString()));
            }
           
            //Nedim
            //Response.Redirect("~/Phase3/Tracking/Results/ResultsEntry.aspx");
            Response.Redirect("~/Phase3/Tracking/Results/CCZROpenParties.aspx");
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Phase3/Tracking/Results/ResultsEntry.aspx");
        }
    }
}
