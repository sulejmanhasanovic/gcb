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
    public partial class CCZR_VecinskiGlas2 : BasePage
    {
        Users loggedUser;
        string D;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["PositionRank"] == null)
                Response.Redirect("~/session.aspx");
            lblPSCode.Text = Session["pscode"].ToString();
            lblPS.Text = Session["pscode"].ToString();
            lblRace.Text = Session["raceName"].ToString();
            lblLevelName.Text = Session["levelName"].ToString();
            lblLevelCode.Text = Session["level"].ToString();
            lblKategorija.Text = Session["kategorija"].ToString();
            //Session["idrace"] = "1";
            //Session["level"] = "701";
            loggedUser = (Users)HttpContext.Current.Session["User"]; //ke se smene koga ke se povrze so menito
            Session["UserID"] = loggedUser.ID.ToString();
            DataSet ds = new DataSet();
            ds = Functions.p3getPSStatisticEntry(Session["pscode"].ToString(), Session["level"].ToString(), int.Parse(Session["idrace"].ToString()), int.Parse(Session["kojpat"].ToString()));
            D = ds.Tables[0].Rows[0][7].ToString();
            TextBox VotesTXTF = (TextBox)GridView1.Rows[0].FindControl("txtVotes");
            VotesTXTF.Focus();
            if (!Page.IsPostBack)
            {
                Session["pati"] = "2";
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int votes = 0;
            int sumVotes = 0;
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                TextBox VotesTXT = (TextBox)GridView1.Rows[i].FindControl("txtVotes");
                votes = int.Parse(VotesTXT.Text.ToString());
                sumVotes = sumVotes + votes;
            }
            //TextBox VotesTXT = (TextBox)GridView1.FindControl("txtVotes");

            if ((sumVotes == int.Parse(D.ToString())) || (Session["pati"].ToString() == "1"))
            {
                for (int i = 0; i < GridView1.Rows.Count; i++)
                {
                    TextBox VotesTXT = (TextBox)GridView1.Rows[i].FindControl("txtVotes");
                    votes = int.Parse(VotesTXT.Text.ToString());
                    sumVotes = sumVotes + votes;
                    string listaid = GridView1.DataKeys[i].Value.ToString();
                    int idlista = int.Parse(listaid.ToString());
                    int listNumber = int.Parse(GridView1.Rows[i].Cells[1].Text.ToString());
                    Functions.RESULTS_InsertIntoZRMayority(Session["pscode"].ToString(), Session["level"].ToString(), int.Parse(Session["idrace"].ToString()),
                        int.Parse(Session["kojpat"].ToString()), listNumber, idlista, votes, int.Parse(Session["UserID"].ToString()));

                }

                lblCheck1.Visible = false;
                if (int.Parse(Session["kojpat"].ToString()) == 1)
                {
                    Functions.RESULTS_InsertUpdateIntoPSStatistic(2, Session["pscode"].ToString(), Session["level"].ToString(), int.Parse(Session["idrace"].ToString()), 1, 5, "OK", "Entry2");
                }
                else
                {
                    Functions.RESULTS_InsertUpdateIntoPSStatistic(2, Session["pscode"].ToString(), Session["level"].ToString(), int.Parse(Session["idrace"].ToString()), 2, 5, "OK", "Entry3");
                }
                Functions.RESULTS_InsertUpdateIntoResultsArchive(int.Parse(Session["kojpat"].ToString()), Session["pscode"].ToString(), int.Parse(Session["idrace"].ToString()), Session["level"].ToString(), 2, 1, 0, int.Parse(Session["UserID"].ToString()), 0, 0, 0);
                //Functions.RESULTS_InsertUpdateIntoTotalREA(int.Parse(Session["kojpat"].ToString()), Session["pscode"].ToString(), int.Parse(Session["idrace"].ToString()), lblLevelCode.Text.ToString(), lblLevelName.Text.ToString(), int.Parse(Session["kojpat"].ToString()));
                if (Session["kojpat"].ToString() == "2")
                {
                    Functions.RESULTS_CheckVecinskiGlas2TWOEntries (Session["pscode"].ToString(), Session["level"].ToString(), int.Parse(Session["idrace"].ToString()), int.Parse(Session["UserID"].ToString()));

                    int temp = Functions.BGetActiveCandidacyRaceForMissmatchesTracking(Session["pscode"].ToString(), Session["level"].ToString(), int.Parse(Session["idrace"].ToString()), int.Parse(Session["UserID"].ToString()));
                    if (temp == 0)
                    {
                        //Nedim
                        DataSet ds = new DataSet();
                        ds = Functions.p3getPSStatisticEntry(Session["pscode"].ToString(), Session["level"].ToString(), int.Parse(Session["idrace"].ToString()), 4);
                        int brPotpisaCentralniBirSpisak = int.Parse(ds.Tables[0].Rows[0][0].ToString());
                        Functions.p3_Insert_Into_ObrazacBrojnogStanja(Session["pscode"].ToString(), Session["level"].ToString(),
                            int.Parse(Session["idrace"].ToString()), int.Parse(Session["UserID"].ToString()), 0, 0, 0, 0, brPotpisaCentralniBirSpisak,
                            0, 0, 0, 0, 0, 4);
                        Functions.OBS_InsertIntoResultsArchive(Session["pscode"].ToString(), int.Parse(Session["idrace"].ToString()), Session["level"].ToString());
                        Functions.NewValidation_InsertUpdateIntop3ValS(Session["pscode"].ToString(), int.Parse(Session["idrace"].ToString()), 3);
                    }
                }

                

                Response.Redirect("~/Phase3/Tracking/Results/ResultsEntry.aspx");

            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Success", "alert('Provjerite svoj ulaz na rezultatima još jednom!/Проверите свој улаз на резултатима још једном!')", true);
                //lblCheck1.Visible = true;
                Session["pati"] = "1";
                //Panel3.Visible = true;
            }
        }
        protected void okButton_Click(object sender, EventArgs e)
        {
            //Panel3.Visible = false;

        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Phase3/Tracking/Results/ResultsEntry.aspx");
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (GridView1.Rows.Count > 0)
            {
                Button1.Visible = true;
            }
            else
            {
                Button1.Visible = false;
            }
        }
    }
}
