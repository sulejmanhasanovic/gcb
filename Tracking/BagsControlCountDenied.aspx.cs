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
using System.Collections.Generic;
using Resources;

namespace JIIS.Web.Phase3.Tracking
{
    public partial class BagsControlCountDenied : BasePage
    {
        List<string> list = new List<string>();
        string bagNo;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["PositionRank"] == null)
                Response.Redirect("~/session.aspx");

            try
            {
                if (Request.QueryString["bag"] != null)
                {
                    bagNo = Request.QueryString["bag"];
                }
                else
                {
                    //Response.Redirect("");
                }
            }
            catch(Exception )
            {

            }
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

        //protected void ddlChooseBagNo_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (ddlChooseBagNo.SelectedItem.Value != "")
        //    {
        //        DataSet ds = new DataSet();
        //        ds = Functions.p3_getBagForID(ddlChooseBagNo.SelectedItem.Value.ToString());

        //        if (ds.Tables[0].Rows[0]["TypeOfPollingStationCode"].ToString() == "P"
        //            && ds.Tables[0].Rows[0]["PollingStationCode"].ToString().Contains("a"))
        //        {
        //            Response.Redirect("BagsControlCountDenied.aspx?bag=" +
        //                ds.Tables[0].Rows[0]["PollingStationCode"].ToString());
        //        }

        //        lblBagNo.Text = ds.Tables[0].Rows[0]["PollingStationCode"].ToString();
        //        lblTotalEnvelopes.Text = ds.Tables[0].Rows[0]["TotalReceivedEnvelopes"].ToString();
        //    }
        //}

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
                                Functions.p3_Update_p3_Bags_Total_Envelopes(int.Parse(txtCountedByCommision.Text.ToString()), bagNo);
                            }
                        }

                        GridViewRowCollection rowCollection = GridView1.Rows;
                        foreach (GridViewRow gridRow in rowCollection)
                        {
                            Label lbl = (Label)gridRow.FindControl("lblID");
                            TextBox tBox = (TextBox)gridRow.FindControl("tBoxReasonNumber");
                            TextBox txtCom = (TextBox)gridRow.FindControl("txtComment");
                            Functions.p3_Insert_BagsDeniedReasons(bagNo, int.Parse(lbl.Text.ToString()), int.Parse(tBox.Text.ToString()), txtCom.Text);
                        }

                        Functions.p3_Update_p3_Bags_BeforeVerification(bagNo, int.Parse(tBoxApprovedEnv.Text.ToString()), int.Parse(tBoxDeniedEnv.Text.ToString()), txtCommentAll.Text.ToString());

                        if (int.Parse(tBoxDeniedEnv.Text) > 0)
                        {
                            Functions.p3_InsertInto_p3_Bags_Denied(int.Parse(tBoxDeniedEnv.Text), bagNo);
                        }

                        Response.Redirect("~/Default.aspx");
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
                Functions.p3_Insert_NewDenyReason(tBoxReasonName.Text.ToString(), bagNo);
                tblNewReason.Visible = false;
                tBoxReasonName.Text = string.Empty;
                GridView1.DataBind();
                for (int i = 0; i < GridView1.Rows.Count - 1; i++)
                {
                    ((TextBox)GridView1.Rows[i].FindControl("tBoxReasonNumber")).Text = list[i];
                }
            }
            catch (Exception )
            {

            }
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
            try
            {
                btnSave.Visible = true;
                //Button1.Visible = true;
                reasons.Visible = true;
                data.Visible = false;
                Page.Title = LanguageText.tr_bagControlCount;
                Literal2.Text = LanguageText.tr_bagControlCount;
                Literal1.Visible = false;
                Literal2.Visible = true;
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

        //protected void ddlChooseTypeBag_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (ddlChooseTypeBag.SelectedValue == "P")
        //    {
        //        Label9.Text = LanguageText.zt_totalNoEnvPP;
        //    }
        //}
    }
}
