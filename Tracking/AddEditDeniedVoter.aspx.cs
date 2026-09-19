using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JIIS.Web.Classes;
using System.Data;
using System.Globalization;
using Resources;

namespace JIIS.Web.Phase3.Tracking
{
    public partial class AddEditDeniedVoter : BasePage
    {
        private int _count = 0;

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

                    DataSet data = Functions.p3_getBagNameFromBagsByID(Convert.ToInt32(Request.QueryString["id"]));


                    lblBagsName.Text = data.Tables[0].Rows[0]["PollingStationCode"].ToString();
                    //Session["BagName"] = lblBagsName.Text.ToString().Trim();
                    Provjeri();
                }
            }



            

        }

        protected void Provjeri ()
        {
            DataSet ds = Functions.p3_getBagNameFromBagsByID(Convert.ToInt32(Request.QueryString["id"]));
                int NumberRows = gvDeniedVoter.Rows.Count;
                int NumberDeniedVoters = Convert.ToInt32(ds.Tables[0].Rows[0]["VerificationReceived"]);

                //if (NumberRows == NumberDeniedVoters)
                //{
                //    lblEnteredAllDeniedVoters.Visible = true;
                //    Button1.Enabled = false;
                //    Button4.Enabled = false;
                //    return;
                //}
                //else
                //{
                //    lblEnteredAllDeniedVoters.Visible = false;
                //    Button1.Enabled = true;
                //    Button4.Enabled = true;
                //}
        }

        protected void Osvjezi()
        {
            txtJMB.Text = "";
            txtName.Text = "";
            txtSurname.Text = "";
        }

        protected void getData()
        {
            //if (Request.QueryString["id"] != "-2")
            //{
            //    DataSet ds = Functions.SelectDeniedVoterForID(int.Parse(Request.QueryString["id"].ToString()));
            //    if (ds != null)
            //    {
            //        txtJMB.Text = ds.Tables[0].Rows[0]["JMB"].ToString();
            //        TextBox1.Text = ds.Tables[0].Rows[0]["NumberBags"].ToString();
            //        TextBox2.Text = ds.Tables[0].Rows[0]["Reason"].ToString();
            //        txtName.Text = ds.Tables[0].Rows[0]["NameVoter"].ToString();
            //        txtSurname.Text = ds.Tables[0].Rows[0]["SurnameVoter"].ToString();
            //    }
            //}
            //else
            //{
            //    txtJMB.Text = "";
            //    TextBox1.Text = "";
            //    TextBox2.Text = "";
            //    txtName.Text = "";
            //    txtSurname.Text = "";
            //}

        }


        protected void Button2_Click(object sender, EventArgs e)
        {
            //save 
            //if (Int32.Parse(Request.QueryString["id"].ToString()) == -2)
            //{
            Functions.AddDeniedVoter(txtJMB.Text.ToString(), ddlNumberBag.SelectedItem.Text.ToString(), ddlDenyReason.SelectedItem.Text.ToString(), txtName.Text.ToString(), txtSurname.Text.ToString(), Convert.ToInt32(ddlNumberBag.SelectedValue.ToString()), Convert.ToInt32(ddlDenyReason.SelectedValue.ToString()));
            //}
            //else
            //{
            //    Functions.ModifyDeniedVoter(int.Parse(Request.QueryString["id"].ToString()), txtJMB.Text.ToString(), ddlNumberBag.SelectedValue.ToString(), ddlDenyReason.SelectedValue.ToString(), txtName.Text.ToString(), txtSurname.Text.ToString());
            //}
                //Response.Redirect("~/Phase3/Tracking/DeniedBagsReceiveVerification.aspx");
            gvDeniedVoter.DataBind();
            Osvjezi();
            Provjeri();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //Završi
            Response.Redirect("~/Phase3/Tracking/DeniedBagsReceiveVerification.aspx");
        }

        protected void btnBack_Click(object sender, EventArgs e)
        { //back
            Response.Redirect("~/Phase3/Tracking/DeniedBagsReceiveVerification.aspx");
        }

        protected void cboxScript_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void imgbtnDeleteDenVoters_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton imgbtnDeleteDeniedVoters = (ImageButton)sender;
            GridViewRow row = (GridViewRow)imgbtnDeleteDeniedVoters.NamingContainer;
            //gvDeniedVoter.DeleteRow(row.RowIndex);
            int deniedVoter = Convert.ToInt32(gvDeniedVoter.DataKeys[row.RowIndex].Value);
            Functions.DeleteDeniedVoter(deniedVoter);
            gvDeniedVoter.DataBind();
            Provjeri();
            
        }

        protected void GridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                _count++;
                e.Row.Cells[0].Text = _count + ".";
                ((ImageButton)e.Row.Cells[5].FindControl("imgbtnDelete")).OnClientClick = "javascript:return window.confirm('" + LanguageText.PgGCBUsersConfirmDeletingDeniedVoter + "');";
            }
        }



    }
}
