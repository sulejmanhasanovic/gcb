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
using System.Drawing;


namespace JIIS.Web.Phase3.Tracking
{
    public partial class StatisticsForPollingStationandMaterials3: BasePage
    {
        ArrayList list = new ArrayList();

        DataSet ds = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            
            //if (!Page.IsPostBack)
            //{
            if (Session["PositionRank"] == null)
                Response.Redirect("~/session.aspx");
                 ds= Functions.p3GetMaterialsforPSCOde();
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    list.Add(row[0].ToString());
                }
        //}
           
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            Response.Redirect("StatisticsForPollingStationandMaterials.aspx");
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                CheckBox cb1 = (CheckBox)e.Row.FindControl("cb");
                if (cb1.Checked == true)
                    e.Row.BackColor = Color.LightBlue;
                else
                    e.Row.BackColor = Color.FloralWhite;

            }
        }

        protected void GridView1_DataBinding(object sender, EventArgs e)
        {
           
        }

       

        
    }
}
