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
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace JIIS.Web.Phase3.Tracking
{
    public partial class BagsReceiveDetails : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["PositionRank"] == null)
                Response.Redirect("~/session.aspx");
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Phase3/Tracking/BagsReceive.aspx");
        }
    }
}
