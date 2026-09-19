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
    public partial class CCZR_OtvorenaLista2 : BasePage
    {
        //tuka ke treba da napravam eden DataTable so partiite za koi treba 
        //da se vnesuvaat glasovi za kandidatite
        DataTable parties = new DataTable();
        Users loggedUser;
        string D, D1;
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

            loggedUser = (Users)HttpContext.Current.Session["User"]; //ke se smene koga ke se povrze so menito
            Session["UserID"] = loggedUser.ID.ToString();
            DataSet ds = new DataSet();
            ds = Functions.p3getPSStatisticEntry(Session["pscode"].ToString(), Session["level"].ToString(), int.Parse(Session["idrace"].ToString()), int.Parse(Session["kojpat"].ToString()));
            //Nedim
            D1 = ds.Tables[0].Rows[0][5].ToString();
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
            //Vo for ciklusot ke treba da napolnam koloni za DataTable
            //ke mi treba idto na listata, kako i imeto na partijata i ListPosition na partijata
            DataColumn idcandlist = new DataColumn("idcandlist", typeof(int));
            DataColumn listposition = new DataColumn("listposition", typeof(int));
            DataColumn namepe = new DataColumn("namepe", typeof(string));
            DataColumn votespe = new DataColumn("votespe", typeof(int));
            parties.Columns.Add(idcandlist);
            parties.Columns.Add(listposition);
            parties.Columns.Add(namepe);
            parties.Columns.Add(votespe);
            int sumVotes = 0;
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                TextBox VotesTXT = (TextBox)GridView1.Rows[i].FindControl("txtVotes");
                votes = int.Parse(VotesTXT.Text.ToString());
                sumVotes = sumVotes + votes;
            }
            
            //if ((sumVotes == int.Parse(D.ToString())) || (Session["pati"].ToString() == "1"))
            if ((sumVotes == int.Parse(D1.ToString())) || (Session["pati"].ToString() == "1"))
            {
                lblCheck1.Visible = false;
                //naredno sto treba da pratam na narednata strana e brojka = kolku partii ima za vnes
                //kako i ke treba vo sesija da go cuvam redniot broj na partijata koja se vnesuva
                for (int i = 0; i < GridView1.Rows.Count; i++)
                {
                    TextBox VotesTXT = (TextBox)GridView1.Rows[i].FindControl("txtVotes");
                    votes = int.Parse(VotesTXT.Text.ToString());
                    sumVotes = sumVotes + votes;
                    int idlista = int.Parse(GridView1.DataKeys[i].Value.ToString());
                    int listNumber = int.Parse(GridView1.Rows[i].Cells[1].Text.ToString());
                    Functions.RESULTS_InsertIntoZRMayority(Session["pscode"].ToString(), Session["level"].ToString(), int.Parse(Session["idrace"].ToString()),
                        int.Parse(Session["kojpat"].ToString()), listNumber, idlista, votes, int.Parse(Session["UserID"].ToString()));
                    parties.Rows.Add(idlista, listNumber, GridView1.Rows[i].Cells[2].Text.ToString(), votes);
                }
                Session["kojapartija"] = "1";
                Session["kolkuvkupno"] = parties.Rows.Count.ToString();
                Session["politicalEntities"] = parties;
                Session["idlista"] = parties.Rows[0][0].ToString();
                Session["listpos"] = parties.Rows[0][1].ToString();
                Session["PEName"] = parties.Rows[0][2].ToString();
                Session["votes"] = parties.Rows[0][3].ToString();
                Functions.RESULTS_InsertUpdateIntoPSStatistic(2, Session["pscode"].ToString(), Session["level"].ToString(), int.Parse(Session["idrace"].ToString()), int.Parse(Session["kojpat"].ToString()), 4, "NOTOK", "1");
                Functions.RESULTS_InsertUpdateIntoResultsArchive(int.Parse(Session["kojpat"].ToString()), Session["pscode"].ToString(), int.Parse(Session["idrace"].ToString()), Session["level"].ToString(), 4, 1, 0, int.Parse(Session["UserID"].ToString()), 0, 0, 0);

                //isto i tuka ke treba da napravime da se sporedvat dvata vnesa 
                if (Session["kojpat"].ToString() == "2")
                {
                    Functions.RESULTS_CheckOtvorenaLista2TWOEntries(Session["pscode"].ToString(), Session["level"].ToString(), int.Parse(Session["idrace"].ToString()), int.Parse(Session["UserID"].ToString()));
                }
                //Nedim
                //Response.Redirect("~/Phase3/Tracking/Results/CCZROpenParties.aspx");
                int daliImaNM = Functions.RESULTSCheckIfLevelHasNM(Session["level"].ToString());
                if ((Session["idrace"].ToString() == "9") && daliImaNM > 0)
                {

                    Response.Redirect("~/Phase3/Tracking/Results/CCZROpenNM.aspx");
                }
                else
                {
                    Response.Redirect("~/Phase3/Tracking/Results/CCZROpenParties.aspx");
                }
            }
            else
            {
                lblCheck1.Visible = true;
                //Panel3.Visible = true;
                lblCheck1.Text = LanguageText.p3_erorDS;
                //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Success", "alert('Provjerite svoj ulaz na rezultatima još jednom!/Проверите свој улаз на резултатима још једном!')", true);
                Session["pati"] = "1";
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
                Button2.Visible = true;
            }

            else
            {
                Button1.Visible = false;
                Button2.Visible = false;

            }
        }


    }
}
