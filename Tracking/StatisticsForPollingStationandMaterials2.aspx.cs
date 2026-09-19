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
    public partial class StatisticsForPollingStationandMaterials2: BasePage
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
            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{
            //    //   _count++;
            //    // e.Row.Cells[0].Text = _count + ".";
            //    HiddenField hidden= ((HiddenField)e.Row.Cells[3].FindControl("hf1"));
            //    HyperLink hp = (HyperLink)e.Row.FindControl("hpToCandidates");
            //    if(list.Contains(hidden.Value))
            //    {
            //    //    ((HyperLink)e.Row.Cells[5].FindControl("hlEdit")).NavigateUrl = "~/Phase1/Admin/AddEditLevels.aspx?mp=5&pf=15&id=" + gvOrgUnits.DataKeys[e.Row.RowIndex].Value;

            //        hp.Visible = true;      
            //    }
            //}

        }

        protected void GridView1_DataBinding(object sender, EventArgs e)
        {
           
        }

       

        
    }
}
