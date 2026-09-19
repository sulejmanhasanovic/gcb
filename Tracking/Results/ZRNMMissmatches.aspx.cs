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
using System.Drawing;

namespace JIIS.Web.Phase3.Tracking.Results
{
    public partial class ZRNMMissmatches : BasePage
    {
        Users loggedUser;
        string muni;
        protected void Page_Load(object sender, EventArgs e)
        {
            //Session["pscode"] = "00165-86";
            //Session["level"] = "701";
            //Session["idrace"] = "1";
            if (Session["PositionRank"] == null)
                Response.Redirect("~/session.aspx");
            loggedUser = (Users)HttpContext.Current.Session["User"]; //ke se smene koga ke se povrze so menito
            Session["UserID"] = loggedUser.ID.ToString();
            DataSet dsData = new DataSet();
            dsData = Functions.RESULTSLevelGetNameForCodeTracking(Session["level"].ToString(), int.Parse(Session["idrace"].ToString()));
            lblRaceName.Text = dsData.Tables[1].Rows[0][0].ToString();
            lblLevelName.Text = dsData.Tables[0].Rows[0][0].ToString();
            lblCode.Text = Session["level"].ToString();

            muni = lblLevelName.Text.Substring(0, 3);
            Session["muni"] = muni.ToString();

            lblPSCode.Text = Session["pscode"].ToString();
            if (!Page.IsPostBack)
            {
                int vkupno = GridView1.Rows.Count;

                for (int i = 0; i <= vkupno - 1; i++)
                {
                    TextBox VotesTXT = (TextBox)GridView1.Rows[i].FindControl("txtVotes");
                    //votes = int.Parse(VotesTXT.Text.ToString());

                    int votes1 = int.Parse(GridView1.Rows[i].Cells[4].Text.ToString());
                    int votes2 = int.Parse(GridView1.Rows[i].Cells[5].Text.ToString());

                    if (votes1 == votes2)
                    {
                        VotesTXT.Text = Convert.ToString(votes2);

                    }
                    else
                    {
                        VotesTXT.BorderColor = Color.Red;
                    }


                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int vkupno = GridView1.Rows.Count;

            for (int i = 0; i <= vkupno - 1; i++)
            {
                TextBox VotesTXT = (TextBox)GridView1.Rows[i].FindControl("txtVotes");
                int votes = int.Parse(VotesTXT.Text.ToString());

                int ID = int.Parse(GridView1.DataKeys[i].Value.ToString());
                int listNumber = int.Parse(GridView1.Rows[i].Cells[1].Text.ToString());
                Functions.RESULTS_InsertIntoZRMayority(Session["pscode"].ToString(), Session["muni"].ToString(), int.Parse(Session["idrace"].ToString()), 3, listNumber, ID, votes, int.Parse(Session["UserID"].ToString()));
                Functions.RESULTS_InsertIntoZRMayority(Session["pscode"].ToString(), Session["muni"].ToString(), int.Parse(Session["idrace"].ToString()), 4, listNumber, ID, votes, int.Parse(Session["UserID"].ToString()));


            }


            Functions.RESULTS_InsertUpdateIntoResultsArchive(2, Session["pscode"].ToString(), 10, muni, 3, 3, 0, 0, 0, int.Parse(Session["UserID"].ToString()), 0);

            //Nedim
            DataSet ds = new DataSet();
            ds = Functions.p3getPSStatisticEntry(Session["pscode"].ToString(), Session["muni"].ToString(), 9, 4);
            int brPotpisaCentralniBirSpisak = int.Parse(ds.Tables[0].Rows[0][0].ToString());
            Functions.p3_Insert_Into_ObrazacBrojnogStanja(Session["pscode"].ToString(), Session["muni"].ToString(),
                9, int.Parse(Session["UserID"].ToString()), 0, 0, 0, 0, brPotpisaCentralniBirSpisak,
                0, 0, 0, 0, 0, 4);
            Functions.OBS_InsertIntoResultsArchive(Session["pscode"].ToString(), int.Parse(Session["idrace"].ToString()), Session["muni"].ToString());
            Functions.NewValidation_InsertUpdateIntop3ValS(Session["pscode"].ToString(), 9, 3);

            Response.Redirect("MissmatchesFirstS.aspx");


        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("MissmatchesFirstS1.aspx");
        }


    }
}