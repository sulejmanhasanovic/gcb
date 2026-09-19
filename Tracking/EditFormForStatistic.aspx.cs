using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JIIS.Web.Classes;
using System.Data;
using System.Globalization;

namespace JIIS.Web.Phase3.Tracking
{
    public partial class EditFormForStatistic : BasePage
    {
        Users loggedUser;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["PositionRank"] == null)
                Response.Redirect("~/session.aspx");
            loggedUser = (Users)HttpContext.Current.Session["User"];
            if (!Page.IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    getData();
                }
            }

        }
        protected void getData()
        {
            DataSet ds = Functions.SelectShipmentForID(int.Parse(Request.QueryString["id"].ToString()));
            txtDateReceived.Text = ds.Tables[0].Rows[0]["dateReceive"].ToString();
            txtShipmentNumber.Text = ds.Tables[0].Rows[0]["shipmentnumber"].ToString();
            txtTotalShip.Text = ds.Tables[0].Rows[0]["shipmentN"].ToString();
            txtTotalOtherPost.Text = ds.Tables[0].Rows[0]["totalOtherPost"].ToString();
            txtComment.Text = ds.Tables[0].Rows[0]["comment"].ToString();
            //DateTime datum;
            //String datum;
            ////datum = Convert.ToDateTime(ds.Tables[0].Rows[0][2]);
            //datum = (ds.Tables[0].Rows[0][2]).ToString();
            //txtDate.Text = datum;
            //RadioButtonList1.SelectedValue = ds.Tables[0].Rows[0]["ElectionIsActive"].ToString();
        }

        public static string FormatirajDatum(DateTime dt)
        {
            return dt.ToString("dd.MM.yyyy");
        }

        public static DateTime ConvertToDate(string datum)
        {
            DateTime dt = DateTime.Now;

            if (!DateTime.TryParseExact(datum, "dd.MM.yyyy HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out dt))
                if (!DateTime.TryParseExact(datum, "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out dt))
                    if (!DateTime.TryParseExact(datum, "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dt))
                        DateTime.TryParseExact(datum, "d.M.yyyy HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out dt);

            return dt;
        }


        protected void Button2_Click(object sender, EventArgs e)
        { //save 
            //if (Request.QueryString["id"] == null)
            //{
            //    //String dt = txtDateReceived.Text.ToString();
            //    //ConvertToDate(dt);
            //    Functions.AddShipment(txtDateReceived.Text.ToString(), txtShipmentNumber.Text.ToString(), txtTotalShip.Text.ToString(), txtTotalOtherPost.ToString(), txtComment.Text.ToString());
            //    Functions.BInsertLogs(loggedUser.ID, "INSERT", "EDITFORMFORSTATISTIC.aspx", DateTime.Now, HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"].ToString());
            //}
            //else
            //{
                //String dt = txtDate.Text.ToString();
                //ConvertToDate(dt);
            Functions.UpdateShipment(int.Parse(Request.QueryString["id"].ToString()), txtDateReceived.Text.ToString(), txtTotalShip.Text.ToString(), txtShipmentNumber.Text.ToString(), txtTotalOtherPost.Text.ToString(), txtComment.Text.ToString());
                Functions.BInsertLogs(loggedUser.ID, "UPDATE", "EDITFORMFORSTATISTIC.aspx", DateTime.Now, HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"].ToString());
            //}
            Response.Redirect("~/Phase3/Tracking/FormForStatistics.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //cancel
            Response.Redirect("~/Phase3/Tracking/FormForStatistics.aspx");
        }

        protected void btnBack_Click(object sender, EventArgs e)
        { //back
            Response.Redirect("~/Phase3/Tracking/FormForStatistics.aspx");
        }

        protected void cboxScript_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
