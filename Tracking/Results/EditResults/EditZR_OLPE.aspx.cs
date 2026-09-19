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
using System.Security.Cryptography;

namespace JIIS.Web.Phase3.Tracking.Results.EditResults
{
    public partial class EditZR_OLPE : BasePage
    {
        Users loggedUser;
        int userce = 0;
        public string evtHandler;

        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Session["PositionRank"] == null)
            //Response.Redirect("~/session.aspx");
            //////loggedUser = (Users)HttpContext.Current.Session["User"]; //ke se smene koga ke se povrze so menito
            //////userce = loggedUser.ID;
            //lblPSCode.Text = Session["pscode"].ToString();
            //lblRace.Text = Session["raceName"].ToString();
            //lblLevelName.Text = Session["levelName"].ToString();
            //lblLevelCode.Text = Session["level"].ToString();
            //Session["idrace"] = "1";
            //Session["level"] = "701";
            DataSet ds = new DataSet();
            if (Session["PositionRank"] == null)
                Response.Redirect("~/session.aspx");
            loggedUser = (Users)HttpContext.Current.Session["User"]; //ke se smene koga ke se povrze so menito
            lblLevelCode.Text = Session["MunicipalityCode"].ToString();
            lblPSCode.Text = Session["PSNumber"].ToString();
            lblPS.Text = Session["PSNumber"].ToString();
            lblKategorija.Text = Session["kategorija"].ToString();

            //ke mi treba da go zemam od zavisnost na kodot na levelot, da go zemam imeto
            //ke napravam procedura koja ke zema od MunReg so e tabelata
            //i plus ke go zemam imeto na izbornata trka
            ds = Functions.RESULTSLevelGetNameForCode(Session["MunicipalityCode"].ToString(), int.Parse(Session["idrace"].ToString()));
            lblRace.Text = ds.Tables[1].Rows[0][0].ToString();
            lblLevelName.Text = ds.Tables[0].Rows[0][0].ToString();
            userce = loggedUser.ID;
            Session["UserID"] = userce;
            // DataSet dsData = new DataSet();
            //ke mi treba da go zemam od zavisnost na kodot na levelot, da go zemam imeto
            //ke napravam procedura koja ke zema od MunReg so e tabelata
            //i plus ke go zemam imeto na izbornata trka
            //   dsData = Functions.RESULTS_getPSStatisticEntry1(Session["PSNumber"].ToString(), Session["MunicipalityCode"].ToString(), int.Parse(Session["idrace"].ToString()), userce);
            //lblRaceName.Text = dsData.Tables[1].Rows[0][0].ToString();
            //lblLevelName.Text = dsData.Tables[0].Rows[0][0].ToString();

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int votes = 0;
            //TextBox VotesTXT = (TextBox)GridView1.FindControl("txtVotes");
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                TextBox VotesTXT = (TextBox)GridView1.Rows[i].FindControl("txtVotes");

                votes = int.Parse(VotesTXT.Text.ToString());
                //string listaid = GridView1.DataKeys[i].Value.ToString();
                //int idlista = int.Parse(listaid.ToString());
                int listNumber = int.Parse(GridView1.Rows[i].Cells[0].Text.ToString());
                Functions.RESULTSUpdatePoliticalEntitiesVG2FINALVOTES(Session["PSNumber"].ToString(), Session["MunicipalityCode"].ToString(), int.Parse(Session["idrace"].ToString()), userce, votes, listNumber);
                Functions.p3_InsertIntoLogs("PoliticalEntitiesVG2", HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"].ToString(), userce, "Polling Station  " + Session["PSNumber"].ToString() + " - " + "Level  " + Session["MunicipalityCode"].ToString() + " - " + " Race  " + int.Parse(Session["idrace"].ToString()) + " Votes " + votes + "List Number: " + listNumber);
            }
            Response.Redirect("~/Phase3/Tracking/Results/EditResults/EditFirstEntry.aspx");
            //Functions.RESULTS_InsertUpdateIntoPSStatistic(2, Session["pscode"].ToString(), Session["level"].ToString(), int.Parse(Session["idrace"].ToString()), 1, 5, "OK", "Entry2");
            //Functions.RESULTS_InsertUpdateIntoResultsArchive(1, Session["pscode"].ToString(), int.Parse(Session["idrace"].ToString()), Session["level"].ToString(), 2, 1, 0, userce, 0, 0, 0);
            //Functions.RESULTS_InsertUpdateIntoTotalREA(1, Session["pscode"].ToString(), int.Parse(Session["idrace"].ToString()), lblLevelCode.Text.ToString(), lblLevelName.Text.ToString(), 1);

            //Response.Redirect("~/Phase3/MEC/ResultsEntryFirst.aspx");
        }

        //protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        //{
        //    if (e.Row.RowType == DataControlRowType.DataRow)
        //    {
        //        int rowIndex = Convert.ToInt32(e.Row.DataItemIndex) + 1;

        //        evtHandler = "updateValue(" + GridView1.ClientID + "," + rowIndex + ")";
        //        ((TextBox)e.Row.FindControl("txtVotes")).Attributes.Add("onblur", evtHandler);
        //    }
        //}

    }
}
