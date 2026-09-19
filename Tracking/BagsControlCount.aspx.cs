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
    public partial class BagsControlCount : BasePage
    {
        //bool reasonsVisible;
        List<string> list = new List<string>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["PositionRank"] == null)
                Response.Redirect("~/session.aspx");
            DataSet ds = new DataSet();
            ds = Functions.oktomvriIDpagePosition(38, int.Parse(Session["PositionRank"].ToString()));

            if (ds.Tables[0].Rows[0][0].ToString() == "0")
                Response.Redirect("~/Default.aspx");

            ds = Functions.oktomvriIDpagePosition(145, int.Parse(Session["PositionRank"].ToString()));

            if (ds.Tables[0].Rows[0][0].ToString() == "0")
            {
                Session["ReasonVisible"] = "0";
            }
            else 
            {
                Session["ReasonVisible"] = "1";
            }

            //if (!Page.IsPostBack)
            //{
            //    Label16.Text = Session["posB"].ToString();
            //    Label18.Text = Session["vrecaB"].ToString();
            //    Label19.Text = Session["total"].ToString();
            //}
            if (!Page.IsPostBack)
            {
                btnSave.Visible = false;
                //Button1.Visible = false;
                reasons.Visible = false;
                data.Visible = true;
                Page.Title = LanguageText.tr_bagControlCount + " (" + LanguageText.tr_controlCount + ")";
                Literal1.Text = LanguageText.tr_bagControlCount + " (" + LanguageText.tr_controlCount + ")";
                Literal2.Text = LanguageText.tr_bagControlCount;
                Literal2.Visible = false;
                Literal1.Visible = true;
                

                int ukRazloga = 0;
                GridViewRowCollection rowCollection2 = GridView1.Rows;
                foreach (GridViewRow gridRow in rowCollection2)
                {
                    TextBox tBox = (TextBox)gridRow.FindControl("tBoxReasonNumber");
                    ukRazloga += int.Parse(tBox.Text.ToString());
                }

                lblNumberReason.Text = ukRazloga.ToString();

                Session["kojiPokusaj"] = "1";

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

        protected void ddlChooseBagNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlChooseBagNo.SelectedItem.Value != "")
            {
                DataSet ds = new DataSet();
                ds = Functions.p3_getBagForID(ddlChooseBagNo.SelectedItem.Value.ToString());

                //if (ds.Tables[0].Rows[0]["TypeOfPollingStationCode"].ToString() == "P"
                //    && ds.Tables[0].Rows[0]["PollingStationCode"].ToString().Contains("a"))
                //{
                //    Response.Redirect("BagsControlCountDenied.aspx?bag=" +
                //        ds.Tables[0].Rows[0]["PollingStationCode"].ToString());
                //}

                lblBagNo.Text = ds.Tables[0].Rows[0]["PollingStationCode"].ToString();
                lblTotalEnvelopes.Text = ds.Tables[0].Rows[0]["TotalReceivedEnvelopes"].ToString();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {            
            int zbir = 0;
            GridViewRowCollection rowCollection1 = GridView1.Rows;
            foreach (GridViewRow gridRow in rowCollection1)
            {
                TextBox tBox = (TextBox)gridRow.FindControl("tBoxReasonNumber");
                zbir += int.Parse(tBox.Text.ToString());
            }
            if ((int.Parse(tBoxApprovedEnv.Text) + int.Parse(tBoxDeniedEnv.Text)) == int.Parse(txtCountedByCommision.Text))
            {
                if (zbir.ToString() == tBoxDeniedEnv.Text.ToString())
                {
                    try
                    {
                        if (int.Parse(lblTotalEnvelopes.Text.ToString()) != 0)
                        {
                            if (int.Parse(lblTotalEnvelopes.Text.ToString()) != int.Parse(txtCountedByCommision.Text.ToString()))
                            {
                                Functions.p3_Update_p3_Bags_Total_Envelopes(int.Parse(txtCountedByCommision.Text.ToString()), ddlChooseBagNo.SelectedItem.Value.ToString());
                            }
                        }

                        GridViewRowCollection rowCollection = GridView1.Rows;
                        foreach (GridViewRow gridRow in rowCollection)
                        {
                            Label lbl = (Label)gridRow.FindControl("lblID");
                            TextBox tBox = (TextBox)gridRow.FindControl("tBoxReasonNumber");
                            TextBox txtCom = (TextBox)gridRow.FindControl("txtComment");
                            Functions.p3_Insert_BagsDeniedReasons(ddlChooseBagNo.SelectedItem.Value.ToString(), int.Parse(lbl.Text.ToString()), int.Parse(tBox.Text.ToString()), txtCom.Text);
                        }
                        
                        Functions.p3_Update_p3_Bags_BeforeVerification(ddlChooseBagNo.SelectedItem.Value.ToString(), int.Parse(tBoxApprovedEnv.Text.ToString()), int.Parse(tBoxDeniedEnv.Text.ToString()),txtCommentAll.Text.ToString());

                        if (int.Parse(tBoxDeniedEnv.Text) > 0 && ddlChooseTypeBag.SelectedValue == "P")
                        {
                            Functions.p3_InsertInto_p3_Bags_Denied(int.Parse(tBoxDeniedEnv.Text), ddlChooseBagNo.SelectedValue);
                        }

                        //
                        Panel3.Visible = true;
                        //Response.Redirect("~/Default.aspx");
                    }
                    catch (Exception )
                    {

                    }
                }
                else
                {
                    lblMessage.Text = LanguageText.tr_envNotMatch;
                }
            }
            else
            {
                lblMessage.Text = LanguageText.zzMessageDoesent;
            }
        }

        protected void btnSaveReason_Click(object sender, EventArgs e)
        {
            try
            {
                list.Clear();
                foreach (GridViewRow gvRow in GridView1.Rows)
                {
                    list.Add(((TextBox)gvRow.FindControl("tBoxReasonNumber")).Text);
                }
                Functions.p3_Insert_NewDenyReason(tBoxReasonName.Text.ToString(), ddlChooseTypeBag.SelectedValue);
                tblNewReason.Visible = false;
                tBoxReasonName.Text = string.Empty;
                GridView1.DataBind();
                for (int i = 0; i < GridView1.Rows.Count - 1; i++)
                {
                    ((TextBox)GridView1.Rows[i].FindControl("tBoxReasonNumber")).Text = list[i];
                }

                int ukRazloga = 0;
                GridViewRowCollection rowCollection2 = GridView1.Rows;
                foreach (GridViewRow gridRow in rowCollection2)
                {
                    TextBox tBox = (TextBox)gridRow.FindControl("tBoxReasonNumber");
                    ukRazloga += int.Parse(tBox.Text.ToString());
                }

                lblNumberReason.Text = ukRazloga.ToString();

            }
            catch (Exception )
            {

            }
        }


        protected void okButton_Click(object sender, EventArgs e)
        {
            Panel3.Visible = false;
            Response.Redirect("~/Default.aspx");
        }

        protected void getData()
        {
            DataSet ds = Functions.SelectDeniedReason(ddlChooseTypeBag.SelectedValue.ToString().Trim());
                
        }

        protected void btnAddNewReason_Click(object sender, EventArgs e)
        {
            tblNewReason.Visible = true;
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            tBoxReasonName.Text = string.Empty;
            tblNewReason.Visible = false;
        }

        protected void btnUpdateNoEnv_Click(object sender, EventArgs e)
        {
            
        }

        protected void btnContinue_Click(object sender, EventArgs e)
        {
            if (lblTotalEnvelopes.Text.ToString().Trim() != txtCountedByCommision.Text.ToString().Trim())
            {
                if (int.Parse(Session["kojiPokusaj"].ToString()).Equals(2))
                {
                    lblMissmatch.Visible = false;
                }
                else
                {
                    lblMissmatch.Visible = true;
                    Session["kojiPokusaj"] = "2";
                    return;
                }
            }
            
                reasons.Visible = true;
                GridView1.DataBind();
                list.Clear();
                foreach (GridViewRow gvRow in GridView1.Rows)
                {
                    list.Add(((TextBox)gvRow.FindControl("tBoxReasonNumber")).Text);
                }

            try
            {
                
                getData();
                btnSave.Visible = true;
                //Button1.Visible = true;
                reasons.Visible = true;
                data.Visible = false;
                Page.Title = LanguageText.tr_bagControlCount;
                Literal2.Text = LanguageText.tr_bagControlCount;
                Literal1.Visible = false;
                Literal2.Visible = true;

                if (int.Parse(Session["ReasonVisible"].ToString()).Equals(0))
                {
                    //reasons.Visible = false;
                    btnAddNewReason.Visible = false;
                }

                //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Success", "alert('Zelite da unosite vise posiljki nego uneseni broj!/Желите да усносите више пошилјке него унесени број!')", true);

            }
            catch (Exception )
            {

            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{
            //    TextBox txtCom = (TextBox)e.Row.FindControl("txtComment");
            //    if (GridView1.DataKeys[e.Row.RowIndex].Value.ToString() == "2")
            //    {
            //        txtCom.Visible = true;
            //    }
            //}
        }

        protected void ddlChooseTypeBag_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlChooseTypeBag.SelectedValue == "P")
            {
                Label9.Text = LanguageText.zt_totalNoEnvPP;
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int ukRazloga = 0;
            GridViewRowCollection rowCollection2 = GridView1.Rows;
            foreach (GridViewRow gridRow in rowCollection2)
            {
                TextBox tBox = (TextBox)gridRow.FindControl("tBoxReasonNumber");
                ukRazloga += int.Parse(tBox.Text.ToString());
            }

            lblNumberReason.Text = ukRazloga.ToString();
        }

        protected void GridView1_RowUpdated(object sender, GridViewUpdatedEventArgs e)
        {
            
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            
        }

        protected void GridView1_PreRender(object sender, EventArgs e)
        {
            int ukRazloga = 0;
            GridViewRowCollection rowCollection2 = GridView1.Rows;
            foreach (GridViewRow gridRow in rowCollection2)
            {
                TextBox tBox = (TextBox)gridRow.FindControl("tBoxReasonNumber");
                ukRazloga += int.Parse(tBox.Text.ToString());
            }

            lblNumberReason.Text = ukRazloga.ToString();
        }

        protected void GridView1_Disposed(object sender, EventArgs e)
        {

        }

    }
}
