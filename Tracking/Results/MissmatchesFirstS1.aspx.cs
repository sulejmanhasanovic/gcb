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
using System.Collections.Generic;
using Resources;
using System.IO;
using System.Text;
using System.Xml;
using System.Globalization;
using JIIS.DataLayer;
using log4net;
using JIIS.Web.Classes;

namespace JIIS.Web.Phase3.Tracking.Results
{
    public partial class MissmatchesFirstS1 : BasePage
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["PositionRank"] == null)
                Response.Redirect("~/session.aspx");
            DataSet ds = new DataSet();
            string ps = Session["pscode"].ToString();
            int race = int.Parse(Session["idrace"].ToString());
            string lv = Session["level"].ToString();
            ds = Functions.p3getEntriesArchiveItemsTracking(Session["pscode"].ToString(), int.Parse(Session["idrace"].ToString()), Session["level"].ToString(), 2);
            int count = ds.Tables[0].Rows.Count;
            for (int i = 0; i <= count - 1; i++)
            {
                if (ds.Tables[0].Rows[i][0].ToString().Contains('1'))
                {
                    divStatus1.Visible = true;

                }
                if (ds.Tables[0].Rows[i][0].ToString().Contains('2'))
                {
                    divStatus2.Visible = true;

                }
                if (ds.Tables[0].Rows[i][0].ToString().Contains('3'))
                {
                    divStatus3.Visible = true;

                }
                if (ds.Tables[0].Rows[i][0].ToString().Contains('4') && ds.Tables[0].Rows[i][1].ToString() == "0")
                {
                    divStatus4.Visible = true;

                }
                else { divP.Visible = true; }
            }

        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            Response.Redirect("MissmatchesFirstS.aspx");
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {

            Response.Redirect("MissmatchesFirstS.aspx");
        }

        



        protected void ddlActiveRace_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

       

        protected void btnStat_Click(object sender, EventArgs e)
        {
            if (int.Parse(Session["idrace"].ToString()) == 1 || int.Parse(Session["idrace"].ToString()) == 5 || int.Parse(Session["idrace"].ToString()) == 8)
            {
                Response.Redirect("~/Phase3/Tracking/Results/ZRVGStatMissmatches.aspx");
            }
            else
            {
                Response.Redirect("~/Phase3/Tracking/Results/ZROLStatMissmatches.aspx");
            }
        }

        protected void btnVG_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Phase3/Tracking/Results/ZRVGMissmatches.aspx");
        }

        protected void btnNM_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Phase3/Tracking/Results/ZRNMMissmatches.aspx");
        }

        protected void btnOL_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Phase3/Tracking/Results/ZROLMissmatches.aspx");
        }
      
    }
}
