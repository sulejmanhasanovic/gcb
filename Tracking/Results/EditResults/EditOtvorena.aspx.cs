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

namespace JIIS.Web.Phase3.Tracking.Results.EditResults
{
    public partial class EditOtvorena : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

      
      

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("EditZR_OtvorenaLista1.aspx");

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("EditZR_OtvorenaLista2.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("EditZR_OLPE.aspx");
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            Response.Redirect("EditZR_NM.aspx");
        }
      
    }
}
