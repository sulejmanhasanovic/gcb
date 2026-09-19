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
    public partial class ZROLPartyMissmatches : BasePage
    {
        Users loggedUser;
        int userce = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            //Session["pscode"] = "00165-86";
            //Session["level"] = "701";
            //Session["idrace"] = "1";
            if (Session["PositionRank"] == null)
                Response.Redirect("~/session.aspx");
            loggedUser = (Users)HttpContext.Current.Session["User"]; //ke se smene koga ke se povrze so menito
            Session["UserID"] = loggedUser.ID.ToString();
            userce = loggedUser.ID;
            DataSet dsData = new DataSet();
            dsData = Functions.RESULTSLevelGetNameForCodeTracking(Session["level"].ToString(), int.Parse(Session["idrace"].ToString()));
            lblRaceName.Text = dsData.Tables[1].Rows[0][0].ToString();
            lblLevelName.Text = dsData.Tables[0].Rows[0][0].ToString();
            lblCode.Text = Session["level"].ToString();

            lblPS.Text = Session["pscode"].ToString();

            if (!Page.IsPostBack)
            {
                //int votes;
                int vkupno = GridView1.Rows.Count;

                for (int i = 0; i <= vkupno - 1; i++)
                {
                    TextBox VotesTXT = (TextBox)GridView1.Rows[i].FindControl("txtVotes");
                    //votes = int.Parse(VotesTXT.Text.ToString());

                    int votes1 = int.Parse(GridView1.Rows[i].Cells[4].Text.ToString());
                    int votes2 = int.Parse(GridView1.Rows[i].Cells[5].Text.ToString());
                    //int votes3 = int.Parse(GridView1.Rows[i].Cells[5].Text.ToString());
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

            string levelce = "";
            DataSet dtL = Functions.RESULTSLevelGetLevelForCOmbinationTracking(Session["level"].ToString(), int.Parse(Session["idrace"].ToString()));
            levelce = dtL.Tables[0].Rows[0][0].ToString();

            for (int i = 0; i <= vkupno - 1; i++)
            {
                TextBox VotesTXT = (TextBox)GridView1.Rows[i].FindControl("txtVotes");
                int votes = int.Parse(VotesTXT.Text.ToString());
                //SelectedDataKey["ProductID"].ToString();
                int ID = int.Parse(GridView1.DataKeys[i].Value.ToString());
                //int ID = int.Parse(GridView1.Rows[i].Cells[0].Text.ToString());
                int listNumber = int.Parse(GridView1.Rows[i].Cells[1].Text.ToString());
                Functions.RESULTS_InsertIntoZROpenList(Session["pscode"].ToString(), levelce,
                                int.Parse(Session["idrace"].ToString()), 3, int.Parse(GridView1.Rows[i].Cells[1].Text.ToString()),
                                int.Parse(Request.QueryString["ID"].ToString()), ID, votes, userce);


                Functions.RESULTS_InsertIntoZROpenList(Session["pscode"].ToString(), levelce,
                                int.Parse(Session["idrace"].ToString()), 4, int.Parse(GridView1.Rows[i].Cells[1].Text.ToString()),
                                int.Parse(Request.QueryString["ID"].ToString()), ID, votes, userce);


            }

            Functions.RESULTS_InsertUpdateIntoResultsArchive(2, Session["pscode"].ToString(), int.Parse(Session["idrace"].ToString()), levelce, 4, 3, int.Parse(Request.QueryString["ID"].ToString()), 0, 0, userce, 0);

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
