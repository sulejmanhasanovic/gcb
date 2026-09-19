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


namespace JIIS.Web.Phase3.Tracking
{
    public partial class StatisticsForPollingStationandMaterials: BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["PositionRank"] == null)
                Response.Redirect("~/session.aspx");
            DataSet ds = new DataSet();
            ds = Functions.oktomvriIDpagePosition(36, int.Parse(Session["PositionRank"].ToString()));

            if (ds.Tables[0].Rows[0][0].ToString() == "0")
                Response.Redirect("~/Default.aspx");
            if (!Page.IsPostBack)
            {

               DataSet dt= new DataSet();
              dt=Functions.p3getStatisticForPSAndMaterials("0");
                GridView1.DataSource=dt;
                GridView1.DataBind();
            }
           
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
          if(txtSearch.Text.ToString()== "")
            {   
            DataSet dt = new DataSet();
            dt = Functions.p3getStatisticForPSAndMaterials("0");
            GridView1.DataSource = dt;
            GridView1.DataBind();
            }
            else
            {
            DataSet dt = new DataSet();
            dt = Functions.p3getStatisticForPSAndMaterials(txtSearch.Text.ToString());
            GridView1.DataSource = dt;
            GridView1.DataBind();
            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    Label lb = (Label)e.Row.FindControl("Label2");

                    HyperLink hp = (HyperLink)e.Row.FindControl("hpToAccepted");
                    if (Int32.Parse(lb.Text.ToString()) == 0)

                        hp.Visible = false;
                }
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    Label lb = (Label)e.Row.FindControl("Label3");

                    HyperLink hp = (HyperLink)e.Row.FindControl("hpToNotAccepted");
                    if (Int32.Parse(lb.Text.ToString()) == 0)

                        hp.Visible = false;
                }
            }
            catch (Exception )
            {

            }
            /////////////////

            
        }

        
    }
}
