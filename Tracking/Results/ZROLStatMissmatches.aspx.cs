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
    public partial class ZROLStatMissmatches : BasePage
    {
        Users loggedUser;
        protected void Page_Load(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            DataSet ds2 = new DataSet();
            DataSet dsData = new DataSet();
            //Session["pscode"] = "00165-86";
            //Session["level"] = "001";
            //Session["idrace"] = "8";
            if (Session["PositionRank"] == null)
                Response.Redirect("~/session.aspx");
            loggedUser = (Users)HttpContext.Current.Session["User"]; //ke se smene koga ke se povrze so menito
            Session["UserID"] = loggedUser.ID.ToString();
            dsData = Functions.RESULTSLevelGetNameForCodeTracking(Session["level"].ToString(), int.Parse(Session["idrace"].ToString()));
            lblRaceName.Text = dsData.Tables[1].Rows[0][0].ToString();
            lblLevelName.Text = dsData.Tables[0].Rows[0][0].ToString();
            lblCode.Text = Session["level"].ToString();
            lblPS.Text = Session["pscode"].ToString();

            ds = Functions.p3getPSStatisticEntryTracking(Session["pscode"].ToString(), Session["level"].ToString(), int.Parse(Session["idrace"].ToString()), 1);
            txt11.Text = ds.Tables[0].Rows[0][0].ToString();
            txt21.Text = ds.Tables[0].Rows[0][1].ToString();
            txt31.Text = ds.Tables[0].Rows[0][9].ToString();
            txtA1.Text = ds.Tables[0].Rows[0][2].ToString();
            txtB1.Text = ds.Tables[0].Rows[0][3].ToString();
            txtC1.Text = ds.Tables[0].Rows[0][4].ToString();
            txtD11.Text = ds.Tables[0].Rows[0][5].ToString();
            txtD21.Text = ds.Tables[0].Rows[0][6].ToString();
            txtD1.Text = ds.Tables[0].Rows[0][7].ToString();
            txtE1.Text = ds.Tables[0].Rows[0][8].ToString();
            txtF1.Text = ds.Tables[0].Rows[0][10].ToString();
            ds2 = Functions.p3getPSStatisticEntryTracking(Session["pscode"].ToString(), Session["level"].ToString(), int.Parse(Session["idrace"].ToString()), 2);
            txt12.Text = ds2.Tables[0].Rows[0][0].ToString();
            txt22.Text = ds2.Tables[0].Rows[0][1].ToString();
            txt32.Text = ds2.Tables[0].Rows[0][9].ToString();
            txtA2.Text = ds2.Tables[0].Rows[0][2].ToString();
            txtB2.Text = ds2.Tables[0].Rows[0][3].ToString();
            txtC2.Text = ds2.Tables[0].Rows[0][4].ToString();
            txtD12.Text = ds2.Tables[0].Rows[0][5].ToString();
            txtD22.Text = ds2.Tables[0].Rows[0][6].ToString();
            txtD2.Text = ds2.Tables[0].Rows[0][7].ToString();
            txtE2.Text = ds2.Tables[0].Rows[0][8].ToString();
            txtF2.Text = ds2.Tables[0].Rows[0][10].ToString();
            if (!Page.IsPostBack)
            {
                if (txt11.Text.Equals(txt12.Text))
                {
                    txt13.Text = txt12.Text;
                }
                else
                {
                    txt13.Text = "";
                    txt13.BorderColor = Color.Red;
                }

                if (txt21.Text.Equals(txt22.Text))
                {
                    txt23.Text = txt22.Text;
                }
                else
                {
                    txt23.Text = "";
                    txt23.BorderColor = Color.Red;
                }

                if (txt31.Text.Equals(txt32.Text))
                {
                    txt33.Text = txt32.Text;
                }
                else
                {
                    txt33.Text = "";
                    txt33.BorderColor = Color.Red;
                }


                if (txtA1.Text.Equals(txtA2.Text))
                {
                    txtA3.Text = txtA2.Text;
                }
                else
                {
                    txtA3.Text = "";
                    txtA3.BorderColor = Color.Red;
                }

                if (txtB1.Text.Equals(txtB2.Text))
                {
                    txtB3.Text = txtB2.Text;
                }
                else
                {
                    txtB3.Text = "";
                    txtB3.BorderColor = Color.Red;
                }

                if (txtC1.Text.Equals(txtC2.Text))
                {
                    txtC3.Text = txtC2.Text;
                }
                else
                {
                    txtC3.Text = "";
                    txtC3.BorderColor = Color.Red;
                }

                if (txtD11.Text.Equals(txtD12.Text))
                {
                    txtD13.Text = txtD12.Text;
                }
                else
                {
                    txtD13.Text = "";
                    txtD13.BorderColor = Color.Red;
                }

                if (txtD21.Text.Equals(txtD22.Text))
                {
                    txtD23.Text = txtD22.Text;
                }
                else
                {
                    txtD23.Text = "";
                    txtD23.BorderColor = Color.Red;
                }

                if (txtD1.Text.Equals(txtD2.Text))
                {
                    txtD3.Text = txtD2.Text;
                }
                else
                {
                    txtD3.Text = "";
                    txtD3.BorderColor = Color.Red;
                }

                if (txtE1.Text.Equals(txtE2.Text))
                {
                    txtE3.Text = txtE2.Text;
                }
                else
                {
                    txtE3.Text = "";
                    txtE3.BorderColor = Color.Red;
                }

                if (txtF1.Text.Equals(txtF2.Text))
                {
                    txtF3.Text = txtF2.Text;
                }
                else
                {
                    txtF3.Text = "";
                    txtF3.BorderColor = Color.Red;
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string levelce = "";
            DataSet dtL = Functions.RESULTSLevelGetLevelForCOmbinationTracking(Session["level"].ToString(), int.Parse(Session["idrace"].ToString()));
            levelce = dtL.Tables[0].Rows[0][0].ToString();


            Functions.RESULTS_InsertIntoPSStatistic(Session["pscode"].ToString(), levelce, int.Parse(Session["idrace"].ToString()),
               3, int.Parse(Session["UserID"].ToString()), int.Parse(txt13.Text.ToString()), int.Parse(txt23.Text.ToString()),
               int.Parse(txtA3.Text.ToString()), int.Parse(txtB3.Text.ToString()), int.Parse(txtC3.Text.ToString()),
              int.Parse(txtD13.Text.ToString()), int.Parse(txtD23.Text.ToString()), int.Parse(txtD3.Text.ToString()),
              int.Parse(txtE3.Text.ToString()), int.Parse(txt33.Text.ToString()), int.Parse(txtF3.Text.ToString()));

            Functions.RESULTS_InsertIntoPSStatistic(Session["pscode"].ToString(), levelce, int.Parse(Session["idrace"].ToString()),
               4, int.Parse(Session["UserID"].ToString()), int.Parse(txt13.Text.ToString()), int.Parse(txt23.Text.ToString()),
               int.Parse(txtA3.Text.ToString()), int.Parse(txtB3.Text.ToString()), int.Parse(txtC3.Text.ToString()),
              int.Parse(txtD13.Text.ToString()), int.Parse(txtD23.Text.ToString()), int.Parse(txtD3.Text.ToString()),
              int.Parse(txtE3.Text.ToString()), int.Parse(txt33.Text.ToString()), int.Parse(txtF3.Text.ToString()));

            Functions.RESULTS_InsertUpdateIntoResultsArchive(2, Session["pscode"].ToString(), int.Parse(Session["idrace"].ToString()), levelce, 1, 3, 0, 0, 0, int.Parse(Session["UserID"].ToString()), 0);

            //Nedim
            DataSet ds = new DataSet();
            ds = Functions.p3getPSStatisticEntry(Session["pscode"].ToString(), levelce, int.Parse(Session["idrace"].ToString()), 4);
            int brPotpisaCentralniBirSpisak = int.Parse(ds.Tables[0].Rows[0][0].ToString());
            Functions.p3_Insert_Into_ObrazacBrojnogStanja(Session["pscode"].ToString(), levelce,
                int.Parse(Session["idrace"].ToString()), int.Parse(Session["UserID"].ToString()), 0, 0, 0, 0, brPotpisaCentralniBirSpisak,
                0, 0, 0, 0, 0, 4);
            Functions.OBS_InsertIntoResultsArchive(Session["pscode"].ToString(), int.Parse(Session["idrace"].ToString()), levelce);
            Functions.NewValidation_InsertUpdateIntop3ValS(Session["pscode"].ToString(), int.Parse(Session["idrace"].ToString()), 3);
            
            Response.Redirect("MissmatchesFirstS.aspx");
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("MissmatchesFirstS1.aspx");
        }


    }
}
