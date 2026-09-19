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
    public partial class FormForStatistics : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["PositionRank"] == null)
                Response.Redirect("~/session.aspx");
            if (!Page.IsPostBack)
            {
                if (Session["noBack"] != null)
                {

                    if (Session["back"] != null)
                    {
                        if (int.Parse(Session["back"].ToString()) == 1)
                        {
                            TxtShipmentN.Text = Session["shipment"].ToString();
                           
                            txtDate.Text = Session["Date"].ToString();
                            txtTotalPost.Text = Session["TotalShipments"].ToString();
                            txtOtherPost.Text = Session["TotalOthers"].ToString();

                        }
                    }
                }
                if (txtDate.Text != null)
                {
                    CompareValidator1.ValueToCompare = DateTime.Now.ToShortDateString();
                }
                string numberRows = GridView2.Rows.Count.ToString();
                if (numberRows == "0")
                {
                    TxtShipmentN.Text = "1";
                }
                else
                {
                    int numberShipment = Convert.ToInt32(numberRows);
                    numberShipment++;
                    TxtShipmentN.Text = numberShipment.ToString();
                }
            }
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }

        protected void ddl_DataBound(object sender, EventArgs e)
        {
            DropDownList ddl = (DropDownList)sender;
            ddl.Items.Insert(0, new ListItem(LanguageText.fvlchoose, ""));
        }

        protected void txtDate_TextChanged(object sender, EventArgs e)
        {
           // int n = Functions.p3_Get_ShipmentNumber(txtDate.Text.ToString());
          //  TxtShipmentN.Text = n.ToString();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            int n;
            if (Session["zbir"] != null)
            {
                {
                    if (int.Parse(Session["zbir"].ToString()) == 1)
                        Session["zbir"] = 2;
                }
            }
            n = Functions.p3_GetIfShipmentExists(int.Parse(TxtShipmentN.Text.ToString()));
            // 01.10.2012 Nedim 
            //if (n == 1 || Session["back"] == null || Session["noBack"] == null)
            if (n == 1 && Session["back"] == null && Session["noBack"] == null)
            {
                lblM.Visible = true;
            }
            else
            {

                lblM.Visible = false;
                Session["shipment"] = int.Parse(TxtShipmentN.Text.ToString());
                Session["Date"] = txtDate.Text.ToString();
                Session["TotalShipments"] = txtTotalPost.Text.ToString();
                Session["TotalOthers"] = txtOtherPost.Text;
                Session["comment"] = txtComment.Text;
                //Session["l"] = Session["label"];
                Functions.p3_InsertInto_ShipmentNumber(Session["Date"].ToString(), int.Parse(Session["TotalShipments"].ToString()), int.Parse(Session["shipment"].ToString()), int.Parse(Session["TotalOthers"].ToString()), Session["comment"].ToString(),0);
                Session["date1"] = Session["Date"].ToString();
                Response.Redirect("BagsReceive.aspx");       
            }
            //Functions.p3_InsertInto_ShipmentNumber(txtDate.Text.ToString(), int.Parse(txtTotalPost.Text.ToString()), int.Parse(TxtShipmentN.Text.ToString()), int.Parse(txtOtherPost.Text.ToString()), txtComment.Text.ToString());
                
        }

        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }

        protected void TxtShipmentN_TextChanged(object sender, EventArgs e)
        {
            int n=0;
            n = Functions.p3_GetIfShipmentExists(int.Parse(TxtShipmentN.Text.ToString()));
            if (n == 1)
            {
                lblM.Visible = true;
            }
            else 
            {
                lblM.Visible = false;
            }
            txtOtherPost.Focus();
        }

        int sum, sum1 = 0;

        protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ((HyperLink)e.Row.Cells[5].FindControl("hlEdit")).NavigateUrl = "~/Phase3/Tracking/EditFormForStatistic.aspx?mp=5&pf=15&id=" + GridView2.DataKeys[e.Row.RowIndex].Value;
            }

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                sum = sum + Convert.ToInt32(e.Row.Cells[2].Text);
                sum1 = sum1 + Convert.ToInt32(e.Row.Cells[3].Text);
            }
            else if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[2].Text = "Ukupno: " + sum.ToString();
                e.Row.Cells[2].HorizontalAlign = HorizontalAlign.Center;
                e.Row.Cells[3].Text = "Ukupno: " + sum1.ToString();
                e.Row.Cells[3].HorizontalAlign = HorizontalAlign.Center;
            }
        }  
    }
}
