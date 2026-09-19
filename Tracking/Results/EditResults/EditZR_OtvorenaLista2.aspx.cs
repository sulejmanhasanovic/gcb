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
    public partial class EditZR_OtvorenaLista2 : BasePage
    {
        //tuka ke treba da napravam eden DataTable so partiite za koi treba 
        //da se vnesuvaat glasovi za kandidatite
        DataTable parties = new DataTable();
        Users loggedUser;
        int userce = 0;
        public int ProjectCount;

        //private int rowcount = 0;
        public string evtHandler;


        protected void Page_Load(object sender, EventArgs e)
        {
           if (Session["PositionRank"] == null)
              Response.Redirect("~/session.aspx");
           loggedUser = (Users)HttpContext.Current.Session["User"]; //ke se smene koga ke se povrze so menito
           Session["UserID"] = loggedUser.ID.ToString();
           lblLevelCode.Text = Session["MunicipalityCode"].ToString();
           lblPSCode.Text = Session["PSNumber"].ToString();
           lblPS.Text = Session["PSNumber"].ToString();
           lblKategorija.Text = Session["kategorija"].ToString();
           //ke mi treba da go zemam od zavisnost na kodot na levelot, da go zemam imeto
           //ke napravam procedura koja ke zema od MunReg so e tabelata
           //i plus ke go zemam imeto na izbornata trka
           DataSet ds = new DataSet();
           ds = Functions.RESULTSLevelGetNameForCode(Session["MunicipalityCode"].ToString(), int.Parse(Session["idrace"].ToString()));
           lblRace.Text = ds.Tables[1].Rows[0][0].ToString();
           lblLevelName.Text = ds.Tables[0].Rows[0][0].ToString();
           userce = loggedUser.ID;
           Session["UserID"] = userce;
            ////lblPSCode.Text = Session["pscode"].ToString();
            ////lblRace.Text = Session["raceName"].ToString();
            ////lblLevelName.Text = Session["levelName"].ToString();
            ////lblLevelCode.Text = Session["level"].ToString();
            //Session["idrace"] = "2";
            //Session["level"] = "511";
            ////  userce = loggedUser.ID;
            //txtKEY.Focus();
        }

       
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{
            //    int rowIndex = Convert.ToInt32(e.Row.DataItemIndex) + 1;

            //    evtHandler = "updateValue(" + GridView1.ClientID + "," + rowIndex + ")";
            //    ((TextBox)e.Row.FindControl("txtVotes")).Attributes.Add("onblur", evtHandler);
              
            //}
        }

      
    }
}
