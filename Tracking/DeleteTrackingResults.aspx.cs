using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;
using JIIS.Web.Classes;
using Resources;


namespace JIIS.Web.Phase3.Tracking
{
    public partial class DeleteTrackingResults : BasePage
    {
        //private int _id;
        Users loggedUser;
        int userce = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["PositionRank"] == null)
                Response.Redirect("~/session.aspx");
            //DataSet ds1 = new DataSet();
            //ds1 = Functions.oktomvriIDpagePosition(66, int.Parse(Session["PositionRank"].ToString()));

            //if (ds1.Tables[0].Rows[0][0].ToString() == "0")
            //    Response.Redirect("~/Default.aspx");

            loggedUser = (Users)HttpContext.Current.Session["User"]; //ke se smene koga ke se povrze so menito
            Session["UserID"] = loggedUser.ID.ToString();
            userce = loggedUser.ID;

        }



        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/default.aspx?mp=5");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                Functions.p3_inseretIntoDeletedPSBAGS(DropDownList2.SelectedValue.ToString(), int.Parse(DropDownList1.SelectedValue.ToString()), TextBox1.Text.ToString(), DateTime.Now, userce, int.Parse(DropDownList3.SelectedValue.ToString()));


            }
            catch (Exception )
            { }
        }

        
    }
}
