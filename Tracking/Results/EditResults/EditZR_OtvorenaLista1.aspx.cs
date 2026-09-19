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
    public partial class EditZR_OtvorenaLista1 : BasePage
    {
        DataSet dsData;
        DataSet ds;
        Users loggedUser;
        int userce = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
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
            lblRaceName.Text = ds.Tables[1].Rows[0][0].ToString();
            lblLevelName.Text = ds.Tables[0].Rows[0][0].ToString();
            userce = loggedUser.ID;
            Session["UserID"] = userce;
            if (!Page.IsPostBack)
            {
                dsData = Functions.RESULTS_getPSStatisticFinalEntry(Session["PSNumber"].ToString(), Session["MunicipalityCode"].ToString(), int.Parse(Session["idrace"].ToString()));
                if (dsData.Tables[0].Rows.Count != 0)
                {
                    txt1.Text = dsData.Tables[0].Rows[0][0].ToString();
                    txt2.Text = dsData.Tables[0].Rows[0][1].ToString();
                    txt3.Text = dsData.Tables[0].Rows[0][9].ToString();
                    txtA.Text = dsData.Tables[0].Rows[0][2].ToString();
                    txtB.Text = dsData.Tables[0].Rows[0][3].ToString();
                    txtC.Text = dsData.Tables[0].Rows[0][4].ToString();
                    txtD1.Text = dsData.Tables[0].Rows[0][5].ToString();
                    txtD2.Text = dsData.Tables[0].Rows[0][6].ToString();
                    txtD.Text = dsData.Tables[0].Rows[0][7].ToString();
                    txtE.Text = dsData.Tables[0].Rows[0][8].ToString();
                    txtF.Text = dsData.Tables[0].Rows[0][10].ToString();
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {



            //    Functions.RESULTS_InsertIntoPSStatistic(Session["pscode"].ToString(), Session["level"].ToString(), int.Parse(Session["idrace"].ToString()),
            //            1, userce, int.Parse(txt1.Text.ToString()), int.Parse(txt2.Text.ToString()), int.Parse(txtA.Text.ToString()), int.Parse(txtB.Text.ToString()),
            //            int.Parse(txtC.Text.ToString()), int.Parse(txtD1.Text.ToString()), int.Parse(txtD2.Text.ToString()),
            //            int.Parse(txtD.Text.ToString()), int.Parse(txtE.Text.ToString()), int.Parse(txt3.Text.ToString()), int.Parse(txtF.Text.ToString()));
            //    Session["raceName"] = dsData.Tables[1].Rows[0][0].ToString();
            //    Session["levelName"] = dsData.Tables[0].Rows[0][0].ToString();
            //    Functions.RESULTS_InsertUpdateIntoPSStatistic(1, Session["pscode"].ToString(), Session["level"].ToString(), int.Parse(Session["idrace"].ToString()), 1, 1, "NOTOK", "4");
            //    Functions.RESULTS_InsertUpdateIntoResultsArchive(1, Session["pscode"].ToString(), int.Parse(Session["idrace"].ToString()), Session["level"].ToString(), 1, 1, 0, userce, 0, 0, 0);
            //    Response.Redirect("~/Phase3/ZR_OtvorenaLista2.aspx");
            //}

            //dsData= Functions.RESULTS_updatePSStatisticEntry1(Session["pscode"].ToString(), Session["level"].ToString(), int.Parse(Session["idrace"].ToString()),
            //               298, int.Parse(txt1.Text.ToString()), int.Parse(txt2.Text.ToString()), int.Parse(txtA.Text.ToString()), int.Parse(txtB.Text.ToString()),
            //               int.Parse(txtC.Text.ToString()), txtD1.Text.ToString(), txtD2.Text.ToString(), int.Parse(txtD.Text.ToString()),
            //               int.Parse(txtE.Text.ToString()), int.Parse(txt3.Text.ToString()), int.Parse(txtF.Text.ToString()));

            Functions.RESULTS_updatePSStatisticFINALEntry(Session["PSNumber"].ToString(), Session["MunicipalityCode"].ToString(), int.Parse(Session["idrace"].ToString()),
                      userce, int.Parse(txt1.Text.ToString()), int.Parse(txt2.Text.ToString()), int.Parse(txtA.Text.ToString()), int.Parse(txtB.Text.ToString()),
                      int.Parse(txtC.Text.ToString()), int.Parse(txtD1.Text.ToString()), int.Parse(txtD2.Text.ToString()), int.Parse(txtD.Text.ToString()),
                      int.Parse(txtE.Text.ToString()), int.Parse(txt3.Text.ToString()), int.Parse(txtF.Text.ToString()));

            //dsData = Functions.RESULTS_getPSStatisticEntry1(Session["PSNumber"].ToString(), Session["MunicipalityCode"].ToString(), int.Parse(Session["idrace"].ToString()), userce);
            Response.Redirect("~/Phase3/Tracking/Results/EditResults/EditFirstEntry.aspx");


        }


    }
}
