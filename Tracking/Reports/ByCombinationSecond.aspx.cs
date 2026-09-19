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
using Microsoft.Reporting;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Web.Configuration;
using CrystalDecisions.CrystalReports.Engine;
using JIIS.Web.Classes;
using Resources;
using CrystalDecisions.ReportSource;
using CrystalDecisions.Web;
using CrystalDecisions.Reporting.WebControls;
using CrystalDecisions.Shared.Interop;
using System.IO;

namespace JIIS.Web.Phase3.Tracking.Reports
{
    public partial class ByCombinationSecond : BasePage
    {
        protected System.Data.SqlClient.SqlCommand sqlcommand1;
        protected ReportDocument act1;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["PositionRank"] == null)
            {
                Response.Redirect("~/session.aspx");
            }
            DataSet ds = new DataSet();
            ds = Functions.oktomvriIDpagePosition(52, int.Parse(Session["PositionRank"].ToString()));

            if (ds.Tables[0].Rows[0][0].ToString() == "0")
                Response.Redirect("~/Default.aspx");

        }

        protected void Page_Init(object sender, EventArgs e)
        {
            ConfigureCrystalReports();
        }

        protected void ConfigureCrystalReports()
        {
            string dataName = WebConfigurationManager.ConnectionStrings["BVOTEConnectionString"].ConnectionString;
            SqlConnection sqlConnection1 = new SqlConnection(dataName);
            sqlcommand1 = new SqlCommand("p3_trackingReportCombinationV2", sqlConnection1);
            sqlConnection1.Open();
            sqlcommand1.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(sqlcommand1);
            sqlcommand1.CommandTimeout = 600000;
            //da = sqlcommand1.ExecuteReader();
            JIIS.Web.Phase3.Tracking.Reports.dsCombinationV2 d = new JIIS.Web.Phase3.Tracking.Reports.dsCombinationV2();

            da.Fill(d);

            act1 = new CRCombinationV2();
            act1.SetDataSource(d.Tables[1]);


            CrystalReportViewer1.ReportSource = act1;

            sqlcommand1.Dispose();

            sqlConnection1.Close();
        }

        protected void CrystalReportViewer1_Unload(object sender, EventArgs e)
        {
            act1.Close();
            act1.Dispose();
        }
    }
}
