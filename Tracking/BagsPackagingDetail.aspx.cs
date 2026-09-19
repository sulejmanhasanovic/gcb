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
using Resources;

namespace JIIS.Web.Phase3.Tracking
{
    public partial class BagsPackagingDetail : BasePage
    {
        int confirmed;
        int denied;
        string typePS;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["PositionRank"] == null)
                Response.Redirect("~/session.aspx");

            confirmed = int.Parse(Session["ConfirmedEnv"].ToString());
            denied = int.Parse(Session["deniedEnv"].ToString());
            typePS = Session["typePS"].ToString();
            
            lblBagNumber.Text = Request.QueryString["PS"].ToString();
            lblPSType.Text = Request.QueryString["PSType"].ToString();

            if (!IsPostBack)
            {
                valid.Visible = true;
                invalid.Visible = false;
                if (lblBagNumber.Text.Contains("aa") && lblPSType.Text == "P")
                {
                    tBoxNumberEnvelopesVoterList.Text = denied.ToString();
                    ddlCombination.ClearSelection();
                    ddlCombination.Items.Insert(0, new ListItem("KR", "KR"));
                    ddlCombination.Items[0].Selected = true;
                }
            }
        }

        protected void btnEnter_Click(object sender, EventArgs e)
        {
            int countValid = 0;
            int countDenied = 0;
            bool valid = false;
            bool invalid = false;
            int entered = 0;
            
            if (ddlCombination.SelectedValue == "KR")
            {
                entered = int.Parse(tBoxNumberCountedEnvelopes.Text);
                invalid = true;
            }
            else
            {
                entered = int.Parse(tBoxNumberCountedEnvelopes.Text);  
                valid = true;
            }

            foreach (GridViewRow gvRow in GridView1.Rows)
            {
                if (gvRow.Cells[0].Text == "KR")
                {
                    countDenied += int.Parse(gvRow.Cells[1].Text);
                }
                else
                {
                    countValid += int.Parse(gvRow.Cells[1].Text);
                }
            }

            if (valid)
            {
                if ((countValid + entered) <= confirmed)
                {
                    lblMessage.Text = "";
                    InsertNewDetail();                    
                }
                else
                {
                    lblMessage.Text = (countValid + entered).ToString() + " > " + confirmed.ToString();
                }
            }

            if (invalid)
            {
                if ((countDenied + entered) <= denied)
                {
                    lblMessage.Text = "";
                    InsertNewDetail();
                }
                else
                {
                    lblMessage.Text = (countDenied + entered).ToString() + " > " + denied.ToString();
                }
            }
        }

        private void InsertNewDetail()
        {
            Users loggedUser = (Users)HttpContext.Current.Session["User"];
            int userId = loggedUser.ID;
            //DataSet dsBag = Functions.p3_getDataFromBagsByID(lblBagNumber.Text.ToString());

            // Necko 24.09.2012...
            DataSet dsBag = Functions.p3_getBagNameFromBagsByPSCode(lblBagNumber.Text.ToString());

            DataSet dsBox = Functions.p3_getDataFromBoxByID(ddlBoxNumber.Text.ToString());
            int bagNo = int.Parse(dsBag.Tables[0].Rows[0]["BagNo"].ToString());
            int boxNo = int.Parse(dsBox.Tables[0].Rows[0]["BoxNo"].ToString());
            string boxType = dsBox.Tables[0].Rows[0]["BoxType"].ToString();

            int postoi = Functions.p3_checkIfBagDetailExist(lblBagNumber.Text.ToString(), boxNo, ddlCombination.SelectedItem.Value.ToString());

            if (postoi == 0)
            {
                // 24.09 Energo
                //Functions.p3_insertBagsDetail(lblBagNumber.Text.ToString(), bagNo, ddlCombination.SelectedItem.Value.ToString(), lblPSType.Text.ToString(),
                //    int.Parse(tBoxNumberEnvelopesVoterList.Text.ToString()), int.Parse(tBoxNumberSignatuers.Text.ToString()), int.Parse(tBoxNumberCountedEnvelopes.Text.ToString()),
                //    int.Parse(tBoxDifference.Text.ToString()), boxNo, boxType, userId);
                Functions.p3_insertBagsDetail(lblBagNumber.Text.ToString(), bagNo, ddlCombination.SelectedItem.Value.ToString(), lblPSType.Text.ToString(),
                    int.Parse(tBoxNumberEnvelopesVoterList.Text.ToString()), int.Parse(tBoxNumberSignatuers.Text.ToString()), int.Parse(tBoxNumberCountedEnvelopes.Text.ToString()),
                    int.Parse(tBoxDifference.Text.ToString()), boxNo, boxType, userId, dsBox.Tables[0].Rows[0]["BoxName"].ToString());
                Clear();
                GridView1.DataBind();
            }
            else
            {
                lblMessage.Text = LanguageText.tr_alreadyEnteredComb;
            }
        }

        private void Clear()
        {
            ddlCombination.SelectedValue = "";
            ddlBoxNumber.SelectedValue = "";
            lblMessage.Text = string.Empty;
            tBoxDifference.Text = string.Empty;
            tBoxNumberCountedEnvelopes.Text = string.Empty;
            tBoxNumberEnvelopesVoterList.Text = string.Empty;
            tBoxNumberSignatuers.Text = string.Empty;
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("BagsPackaging.aspx");
        }

        protected void ddl_DataBound(object sender, EventArgs e)
        {
            DropDownList ddl = (DropDownList)sender;
            ddl.Items.Insert(0, new ListItem(LanguageText.fvlchoose, ""));
        }

        protected void ddlCombination_DataBound(object sender, EventArgs e)
        {
            ddlCombination.Items.Insert(0, new ListItem(LanguageText.fvlchoose, ""));

           // if (typePS == "P")
           // {
                ddlCombination.Items.Insert(1, new ListItem("KR", "KR"));
           // }
        }

        protected void btnFinish_Click(object sender, EventArgs e)
        {
            //InsertNewDetail();
            int countValid = 0;
            int countDenied = 0;

            foreach (GridViewRow gvRow in GridView1.Rows)
            {
                if (gvRow.Cells[0].Text == "KR")
                {
                    countDenied += int.Parse(gvRow.Cells[1].Text);
                }
                else
                {
                    countValid += int.Parse(gvRow.Cells[1].Text);
                }
            }

            if (countValid == confirmed)
            {
                if (countDenied == denied)
                {
                    Functions.p3_UpdateBagStatus("5", lblBagNumber.Text.ToString(), lblPSType.Text.ToString());
                    Response.Redirect("~/Phase3/Tracking/BagsPackaging.aspx");
                }
                else
                {
                    lblMessage.Text = countDenied.ToString() + " <> " + denied.ToString();
                }
            }
            else
            {
                lblMessage.Text = countValid.ToString() + " <> " + confirmed.ToString();
            }
        }

        protected void tBoxNumberEnvelopesVoterList_TextChanged(object sender, EventArgs e)
        {
            if (tBoxNumberEnvelopesVoterList.Text != "" && tBoxNumberCountedEnvelopes.Text != "")
            {
                tBoxDifference.Text = (int.Parse(tBoxNumberEnvelopesVoterList.Text) - int.Parse(tBoxNumberCountedEnvelopes.Text)).ToString();
            }
            tBoxNumberSignatuers.Focus();
        }

        protected void tBoxNumberCountedEnvelopes_TextChanged(object sender, EventArgs e)
        {
            if (tBoxNumberEnvelopesVoterList.Text != "" && tBoxNumberCountedEnvelopes.Text != "")
            {
                tBoxDifference.Text = (int.Parse(tBoxNumberEnvelopesVoterList.Text) - int.Parse(tBoxNumberCountedEnvelopes.Text)).ToString();
            }
            tBoxDifference.Focus();
        }

        protected void ddlCombination_SelectedIndexChanged(object sender, EventArgs e)
        {
            int noEnv = Functions.p3_getNoEnvInBagForCombination(Request.QueryString["PS"].ToString(), 
                ddlCombination.SelectedValue);

            tBoxNumberEnvelopesVoterList.Text = noEnv.ToString();

            if (lblBagNumber.Text.Contains("aa") && lblPSType.Text == "P")
            {
                tBoxNumberEnvelopesVoterList.Text = denied.ToString();
            }
        }
        protected void linkEdit_Click(object sender, EventArgs e)
        {
            LinkButton lbEdit = (LinkButton)sender;
            GridViewRow gvRow = (GridViewRow)lbEdit.NamingContainer;

            Session["ID"] = GridView1.DataKeys[gvRow.RowIndex].Values["id"].ToString();
            Session["boxN"] = gvRow.Cells[2].Text;

            lblWhichBag.Text = Session["boxN"].ToString();
            // Session["bag1"] = GridView2.DataKeys[gvRow.RowIndex].Values["PollingStationCode"].ToString();

            tblEdit.Visible = true;
            //txtEditNoEnv.Focus();
        }
        protected void btnEditNoEnv_Click(object sender, EventArgs e)
        {
            Functions.p3_EditFormedBoxes(int.Parse(txtEditNoEnv.Text.ToString()), int.Parse(Session["ID"].ToString()));
            tblEdit.Visible = false;
            GridView1.DataBind();
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            tblEdit.Visible = false;
        }

    }
}
