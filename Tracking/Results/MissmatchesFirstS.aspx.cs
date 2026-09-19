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
    public partial class MissmatchesFirstS : BasePage
    {
        //private int _count = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["PositionRank"] == null)
                Response.Redirect("~/session.aspx");
            DataSet ds = new DataSet();
            ds = Functions.oktomvriIDpagePosition(55, int.Parse(Session["PositionRank"].ToString()));

            if (ds.Tables[0].Rows[0][0].ToString() == "0")
                Response.Redirect("~/Default.aspx");


        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }


        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //DropDownList2.DataBind();
        }




        protected void gridShow_SelectedIndexChanged1(object sender, EventArgs e)
        {

            string sValue = ((HiddenField)gridShow.SelectedRow.Cells[1].FindControl("hdID")).Value;
            Session["pscode"] = gridShow.SelectedRow.Cells[4].Text;
            Session["idrace"] = int.Parse(sValue.ToString());
            Session["level"] = DropDownList1.SelectedValue.ToString();
            Response.Redirect("MissmatchesFirstS1.aspx");
        }



    }
}
