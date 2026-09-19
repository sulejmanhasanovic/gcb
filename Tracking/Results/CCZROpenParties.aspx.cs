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
    public partial class CCZROpenParties : BasePage
    {
        DataTable pe = new DataTable();
        int kolku = 0;
        int momentalno;
        Users loggedUser;
        int userce = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["PositionRank"] == null)
                Response.Redirect("~/session.aspx");
            loggedUser = (Users)HttpContext.Current.Session["User"];
            userce = loggedUser.ID;
            lblPSCode.Text = Session["pscode"].ToString();
            lblPS.Text = Session["pscode"].ToString();
            lblRace.Text = Session["raceName"].ToString();
            lblLevelName.Text = Session["levelName"].ToString();
            lblLevelCode.Text = Session["level"].ToString();
            lblCurrent.Text = Session["kojapartija"].ToString();
            lblListPos.Text = Session["listpos"].ToString();
            lblPEName.Text = Session["PEName"].ToString();
            kolku = int.Parse(Session["kolkuvkupno"].ToString());
            lblKategorija.Text = Session["kategorija"].ToString();
            lblTotal.Text = kolku.ToString();
            lblVotes.Text = Session["votes"].ToString();
            momentalno = int.Parse(lblCurrent.Text.ToString());
            TextBox VotesTXTF = (TextBox)GridView1.Rows[0].FindControl("txtVotes");
            VotesTXTF.Focus();
            if (!Page.IsPostBack)
            {
                Session["pati"] = "2";
            }
            if (momentalno == kolku)
            {
                //Nedim
                //Button2.Text = "Finish";
                Button2.Text = LanguageText.Finish;
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int candID = int.Parse(GridView1.DataKeys[0].Value.ToString());
            int ListaID = Functions.RESULTSGetCandidatesListIDForCandidate(candID);

            if (ListaID == int.Parse(Session["idlista"].ToString()))
            {
                int sumOfVotes = int.Parse(lblVotes.Text.ToString());
                int OK = 0;
                for (int i = 0; i < GridView1.Rows.Count; i++)
                {
                    TextBox VotesTXT = (TextBox)GridView1.Rows[i].FindControl("txtVotes");
                    int votes = int.Parse(VotesTXT.Text.ToString());
                    if (votes <= sumOfVotes)
                    {
                    }
                    else
                    {

                        OK++;
                    }
                }
                if (OK > 0)
                    OK = 1;
                else OK = 0;
                if ((OK == 0) || (Session["pati"].ToString() == "1"))
                {
                    for (int i = 0; i < GridView1.Rows.Count; i++)
                    {
                        TextBox VotesTXT = (TextBox)GridView1.Rows[i].FindControl("txtVotes");
                        int votes = int.Parse(VotesTXT.Text.ToString());
                        Functions.RESULTS_InsertIntoZROpenList(Session["pscode"].ToString(), Session["level"].ToString(),
                                    int.Parse(Session["idrace"].ToString()), int.Parse(Session["kojpat"].ToString()), int.Parse(GridView1.Rows[i].Cells[1].Text.ToString()),
                                    ListaID, int.Parse(GridView1.DataKeys[i].Value.ToString()), votes, userce);


                    }
                    Functions.RESULTS_InsertUpdateIntoPSStatistic(2, Session["pscode"].ToString(), Session["level"].ToString(), int.Parse(Session["idrace"].ToString()), int.Parse(Session["kojpat"].ToString()), 4, "NOTOK", (momentalno + 1).ToString());
                    Functions.RESULTS_InsertUpdateIntoResultsArchive(int.Parse(Session["kojpat"].ToString()), Session["pscode"].ToString(), int.Parse(Session["idrace"].ToString()), Session["level"].ToString(), 4, 1, ListaID, userce, 0, 0, 0);
                    if (Session["kojpat"].ToString() == "2")
                    {
                        Functions.RESULTS_CheckOtvorenaListaOPTWOEntries(Session["pscode"].ToString(), Session["level"].ToString(), int.Parse(Session["idrace"].ToString()), userce, int.Parse(Session["idlista"].ToString()));
                    }

                    if (momentalno == kolku)
                    {
                        //Nedim
                        //int daliImaNM = Functions.RESULTSCheckIfLevelHasNM(Session["level"].ToString());
                        //if ((Session["idrace"].ToString() == "9") && daliImaNM > 0)
                        //{
                            if (Session["kojpat"].ToString() == "1")
                            {
                                Functions.RESULTS_InsertUpdateIntoPSStatistic(2, Session["pscode"].ToString(), Session["level"].ToString(), int.Parse(Session["idrace"].ToString()), 1, 5, "OK", "Entry2");
                            }
                            else
                            {
                                //Functions.RESULTS_InsertUpdateIntoTotalREA(int.Parse(Session["kojpat"].ToString()), Session["pscode"].ToString(), int.Parse(Session["idrace"].ToString()), lblLevelCode.Text.ToString(), lblLevelName.Text.ToString(), int.Parse(Session["kojpat"].ToString()));
                                Functions.RESULTS_InsertUpdateIntoPSStatistic(2, Session["pscode"].ToString(), Session["level"].ToString(), int.Parse(Session["idrace"].ToString()), 2, 5, "OK", "Entry3");
                                //Nedim
                                int dali = Functions.NewValidationCheckIFOKZR(Session["pscode"].ToString(), int.Parse(Session["idrace"].ToString()));
                                if (dali == 1)
                                {
                                    Functions.NewValidation_InsertUpdateIntop3ValS(Session["pscode"].ToString(), int.Parse(Session["idrace"].ToString()), 1);

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
                        //}
                        //else
                        //{
                            //if (Session["kojpat"].ToString() == "1")
                            //{
                            //    Functions.RESULTS_InsertUpdateIntoPSStatistic(2, Session["pscode"].ToString(), Session["level"].ToString(), int.Parse(Session["idrace"].ToString()), 1, 5, "OK", "Entry2");
                            //}
                            //else
                            //{
                            //    //Functions.RESULTS_InsertUpdateIntoTotalREA(int.Parse(Session["kojpat"].ToString()), Session["pscode"].ToString(), int.Parse(Session["idrace"].ToString()), lblLevelCode.Text.ToString(), lblLevelName.Text.ToString(), int.Parse(Session["kojpat"].ToString()));
                            //    Functions.RESULTS_InsertUpdateIntoPSStatistic(2, Session["pscode"].ToString(), Session["level"].ToString(), int.Parse(Session["idrace"].ToString()), 2, 5, "OK", "Entry3");
                            //}
                            //Response.Redirect("~/Phase3/Tracking/Results/ResultsEntry.aspx");
                        //}
                    }
                    else
                    {
                        pe = (DataTable)Session["politicalEntities"];
                        Session["idlista"] = pe.Rows[momentalno][0].ToString();
                        Session["listpos"] = pe.Rows[momentalno][1].ToString();
                        Session["PEName"] = pe.Rows[momentalno][2].ToString();
                        Session["kojapartija"] = (momentalno + 1).ToString();
                        Session["votes"] = pe.Rows[momentalno][3].ToString();
                        Response.Redirect("~/Phase3/Tracking/Results/CCZROpenParties.aspx");
                    }

                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Success", "alert('Provjerite svoj ulaz na rezultatima još jednom!/Проверите свој улаз на резултатима још једном!')", true);
                    //lblCheck1.Visible = true;
                    //Panel3.Visible = true;
                    Session["pati"] = "1";
                }
            }
            else
            {
                Response.Redirect("~/Default.aspx");
            }
        }
        protected void okButton_Click(object sender, EventArgs e)
        {
            //Panel3.Visible = false;

        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            //tuka na klik na kopceto ako se rabote za Level koj ima NM
            //ke treba da se otvori forma za vnes na NM
            //ako ne da ide na nekoj default strana
            //i toa ke treba da se proveruva za Trka = 9 (Skupstine Opstine)


        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Phase3/Tracking/Results/ResultsEntry.aspx");
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                TextBox VotesTXT = (TextBox)GridView1.Rows[i].FindControl("txtVotes");
                VotesTXT.Text = "0";
            }
        }


    }
}
