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
using System.Web.Configuration;

namespace JIIS.Web.Phase3.Tracking
{
    public partial class ScanningUnconfirmed : BasePage
    {
        //private int _count = 0;
        int userId;
        //string type;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["PositionRank"] == null)
                Response.Redirect("~/session.aspx");

            userId = ((Users)Session["user"]).ID;

            if (Request.QueryString["ps"] != null)
            {
                lblBag.Text = Request.QueryString["ps"];
            }

            if (!Page.IsPostBack)
            {
                Label3.Text += ":";
                lblTxtScanJMB.Text += ":";
                //btnScan.Style.Add("display", "none");
                //txtBarCode.Attributes.Add("onkeypress", "countDisplay();");
                //txtName.Attributes.Add("onkeypress", "return clickButton(event)");
                //txtSurname.Attributes.Add("onkeypress", "return clickButton(event)");
                //txtBirthDate.Attributes.Add("onkeypress", "return clickButton(event)");
                txtBarCode.Focus();

                this.pnlAlreadyEntered.Style.Add("display", "none");
                this.pnlCofirmed.Style.Add("display", "none");
                this.pnlDenied.Style.Add("display", "none");
                getAlreadyScannedData();
            }

        }
        protected void getAlreadyScannedData()
        {
            if (Request.QueryString["ps"] != null)
            {
                DataSet ds = Functions.p3_GetScannedVotersForClerkID(Request.QueryString["ps"], userId);
                string time;
                time = DateTime.Now.ToString("HH:mm");
                gView.DataSource = ds.Tables[0];
                gView.DataBind();
                int countAcc = 0;
                int countDen = 0;
                foreach (GridViewRow gvRow in gView.Rows)
                {
                    Label lbAcc = (Label)gvRow.FindControl("lblAccepted");

                    if (lbAcc.Text == "True")
                    {
                        countAcc += 1;
                    }
                    if (lbAcc.Text == "False")
                    {
                        countDen += 1;
                    }
                }
                lblDenied.Text = countDen.ToString();
                lblAccepted.Text = countAcc.ToString();
            }
        }

        protected void gvOrgUnits_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lb = (Label)e.Row.FindControl("Time");
                if (lb.Text != string.Empty)
                {
                    lb.Text = Convert.ToDateTime(lb.Text).ToString("HH:mm");
                }
                ((ImageButton)e.Row.Cells[9].FindControl("imgbtnDelete")).OnClientClick = "javascript:return window.confirm('" + LanguageText.p3_deleteScan + "');";
                //    ((HyperLink)e.Row.Cells[5].FindControl("hlEdit")).NavigateUrl = "~/Phase1/Admin/AddEditLevels.aspx?mp=5&pf=15&id=" + gvOrgUnits.DataKeys[e.Row.RowIndex].Value;
            }
        }

        protected void imgbtnDeleteOrgUnit_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton imgbtnDeleteOrgUnit = (ImageButton)sender;
            GridViewRow row = (GridViewRow)imgbtnDeleteOrgUnit.NamingContainer;
            int orgUnitId = Convert.ToInt32(gView.DataKeys[row.RowIndex].Value);

            string psBag = Request.QueryString["ps"].ToString();
            Functions.DeleteScannedVoterBag(orgUnitId, psBag);
            DataSet ds = Functions.p3_GetScannedVotersForClerkID(Request.QueryString["ps"], userId);
            gView.DataSource = ds.Tables[0];
            gView.DataBind();
            int countAcc = 0;
            int countDen = 0;
            foreach (GridViewRow gvRow in gView.Rows)
            {
                Label lbAcc = (Label)gvRow.FindControl("lblAccepted");

                if (lbAcc.Text == "True")
                {
                    countAcc += 1;
                }
                if (lbAcc.Text == "False")
                {
                    countDen += 1;
                }
            }
            lblDenied.Text = countDen.ToString();
            lblAccepted.Text = countAcc.ToString();
            txtBarCode.Focus();
        }

        protected void btnScan_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["ps"] != null)
            {
                string psBag = Request.QueryString["ps"].ToString();
                string time = DateTime.Now.ToString("HH:mm");
                bool suspicious = chbSuspicious.Checked;
                //Guid guid = Guid.Empty;

                //if ((upload.PostedFile != null) && (upload.PostedFile.ContentLength > 0) && System.IO.Path.GetExtension(upload.PostedFile.FileName) == ".pdf")
                //{
                //    guid = Guid.NewGuid();
                //    var path = WebConfigurationManager.AppSettings["ScannedFileLocation"];
                //    path += @"\" + psBag;
                //    if (!System.IO.Directory.Exists(path))
                //        System.IO.Directory.CreateDirectory(path);
                //    string SaveLocation = path + "/" + guid.ToString() + System.IO.Path.GetExtension(upload.PostedFile.FileName);
                //    try
                //    {
                //        upload.PostedFile.SaveAs(SaveLocation);
                //        Response.Write("The file has been uploaded.");
                //    }
                //    catch (Exception ex)
                //    {
                //        Response.Write("Error: " + ex.Message);
                //    }
                //}

                DataSet ds = new DataSet();
              //  ds = Functions.p3_InsertIntoVotesCastUnconfirmed(txtBarCode.Text, userId, psBag, txtName.Text, txtSurname.Text, txtBirthDate.Text, suspicious, guid != Guid.Empty ? guid.ToString() + System.IO.Path.GetExtension(upload.PostedFile.FileName) : "");
                ds = Functions.p3_InsertIntoVotesCastUnconfirmed(txtBarCode.Text, userId, psBag, txtName.Text, txtSurname.Text, txtBirthDate.Text, suspicious);
                 
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ////// PROVERKA DALI E SKENIRAN OVOJ JMB OD NEKOJ DRUG PS                    

                    getAlreadyScannedData();

                    lblName.Text = ds.Tables[0].Rows[0]["Name"].ToString() + " " + ds.Tables[0].Rows[0]["Surname"].ToString();
                    //lblPS.Text = psBag;
                    lblTime.Text = time;
                    lblVoteForMunicipality.Text = ds.Tables[0].Rows[0]["VoteForLevel"].ToString();
                    lblJMB.Text = txtBarCode.Text.ToString();

                    if (ds.Tables[0].Rows[0]["Reason"].ToString() == "Already entered")
                    {
                        this.pnlAlreadyEntered.Style.Add("display", "");
                        this.pnlCofirmed.Style.Add("display", "none");
                        this.pnlDenied.Style.Add("display", "none");
                    }
                    if (ds.Tables[0].Rows[0]["Reason"].ToString() == "Not in Voter")
                    {
                        this.pnlAlreadyEntered.Style.Add("display", "none");
                        this.pnlCofirmed.Style.Add("display", "none");
                        this.pnlDenied.Style.Add("display", "");
                    }
                    if (ds.Tables[0].Rows[0]["Reason"].ToString() == "Scanned regular")
                    {
                        this.pnlAlreadyEntered.Style.Add("display", "");
                        this.pnlCofirmed.Style.Add("display", "none");
                        this.pnlDenied.Style.Add("display", "none");
                    }
                    if (ds.Tables[0].Rows[0]["Accepted"].ToString() == "True")
                    {
                        this.pnlAlreadyEntered.Style.Add("display", "none");
                        this.pnlCofirmed.Style.Add("display", "");
                        this.pnlDenied.Style.Add("display", "none");
                        if (ds.Tables[0].Rows[0]["Reason"].ToString() == "JMB is not correct")
                        {
                            lblMessage.Visible = true;
                            lblMessage.Text = "JMB is not correct";
                        }
                    }
                }

                txtBarCode.Text = "";
                txtBirthDate.Text = "";
                txtName.Text = "";
                txtSurname.Text = "";

                //txtBarCode.Attributes.Add("onkeypress", "countDisplay();");

                txtBarCode.Focus();
            }
            else
            {
                Response.Redirect("~/Phase3/Tracking/ScanningUnconfirmed.aspx");
            }

        }

        protected void btnFinishScanning_Click(object sender, EventArgs e)
        {
            Session["ScannedVoters"] = null;
            Response.Redirect("~/Phase3/Tracking/ScanningUnconfirmed.aspx");
        }

        protected void ddlPageSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            gView.PageSize = Convert.ToInt16(ddlPageSize.SelectedValue);
            getAlreadyScannedData();
        }

        protected void CheckBoxPaging_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBoxPaging.Checked == true)
                ddlPageSize.Visible = true;
            else
                ddlPageSize.Visible = false;
        }
    }
}
