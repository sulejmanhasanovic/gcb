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
    public partial class ChoseType : BasePage
    {
        //int userId;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["PositionRank"] == null)
              Response.Redirect("~/session.aspx");
            DataSet ds = new DataSet();
            ds = Functions.oktomvriIDpagePosition(37, int.Parse(Session["PositionRank"].ToString()));

            if (ds.Tables[0].Rows[0][0].ToString() == "0")
                Response.Redirect("~/Default.aspx");

            if (!Page.IsPostBack)
            {


            }

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }

        protected void ddlChooseTypeBag_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlChooseTypeBag.SelectedItem.Value != "")
            {
                if (ddlChooseTypeBag.SelectedItem.Value == "P")
                {
                   
                    Session["p"] = "P";
                    Session["type"] = ddlChooseTypeBag.SelectedItem.Text;
                    Response.Redirect("FormForStatistics.aspx");
                }
                if (ddlChooseTypeBag.SelectedItem.Value == "N")
                {
                    Session["p"] = "N";
                    Session["type"] = ddlChooseTypeBag.SelectedItem.Text;
                    Response.Redirect("BagsReceive.aspx");
                }
                if (ddlChooseTypeBag.SelectedItem.Value == "O")
                {
                    Session["p"] = "O";
                    Session["type"] = ddlChooseTypeBag.SelectedItem.Text;
                    Response.Redirect("BagsReceive.aspx");
                }
                if (ddlChooseTypeBag.SelectedItem.Value == "F")
                {
                    Session["p"] = "F";
                    Session["type"] = ddlChooseTypeBag.SelectedItem.Text;
                    Response.Redirect("BagsReceive.aspx");
                }
                if (ddlChooseTypeBag.SelectedItem.Value == "D")
                {
                    Session["p"] = "D";
                    Session["type"] = ddlChooseTypeBag.SelectedItem.Text;
                    Response.Redirect("BagsReceive.aspx");
                }
                if (ddlChooseTypeBag.SelectedItem.Value == "M")
                {

                    Session["p"] = "M";
                    Session["type"] = ddlChooseTypeBag.SelectedItem.Text;
                    Response.Redirect("BagsReceive.aspx");
                }
            }
            else
            {

            }
        }


        protected void ddl_DataBound(object sender, EventArgs e)
        {
            DropDownList ddl = (DropDownList)sender;
            ddl.Items.Insert(0, new ListItem(LanguageText.fvlchoose, ""));

        }



    }
}
           
        
    

