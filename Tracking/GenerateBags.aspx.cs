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
using System.Data.SqlClient;
using System.Drawing;


namespace JIIS.Web.Phase3.Tracking
{
    public partial class GenerateBags : BasePage
    {
        //int userId;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["PositionRank"] == null)
              Response.Redirect("~/session.aspx");
            DataSet ds = new DataSet();
            ds = Functions.oktomvriIDpagePosition(37, int.Parse(Session["PositionRank"].ToString()));

            if (ds.Tables[0].Rows[0][0].ToString() == "0")
                Response.Redirect("~/Default.aspx");

            lblSuccessGenerateBags.Visible = false;
            lblNotSuccessGenerateBags.Visible = false;

            if (!Page.IsPostBack)
            {


            }

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }

        protected void ddlChooseTypeBag_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblSuccessGenerateBags.Visible = false;
            lblNotSuccessGenerateBags.Visible = false;

            if (ddlChooseTypeBag.SelectedItem.Value != "")
            {
                if (ddlChooseTypeBag.SelectedItem.Value == "P")
                {
                   
                    Session["p"] = "P";
                    Session["type"] = ddlChooseTypeBag.SelectedItem.Text;
                    ddlOpstina.Visible = false;
                    Button6.Visible = true;
                    rbListNumberCopies.Visible = true;
                    gvMobileTeams.Visible = false;
                    gvOdsustvo.Visible = false;
                    btnGenerateMobileTeams.Visible = false;
                    btnGenerateOdsustvo.Visible = false;
                    if (rbListNumberCopies.Items.Count == 1)
                    {
                        ListItem li1 = new ListItem();
                        ListItem li2 = new ListItem();
                        ListItem li3 = new ListItem();
                        ListItem li4 = new ListItem();
                        
                        li1.Text = "10";
                        li1.Value = "10";
                        li2.Text = "20";
                        li2.Value = "20";
                        li3.Text = "50";
                        li3.Value = "50";
                        li4.Text = "100";
                        li4.Value = "100";

                        rbListNumberCopies.Items.Add(li1);
                        rbListNumberCopies.Items.Add(li2);
                        rbListNumberCopies.Items.Add(li3);
                        rbListNumberCopies.Items.Add(li4);
                    }

                }
                if (ddlChooseTypeBag.SelectedItem.Value == "N")
                {
                    Session["p"] = "N";
                    Session["type"] = ddlChooseTypeBag.SelectedItem.Text;
                    //Session["municipality"] = ddlOpstina.SelectedValue.ToString();
                    ddlOpstina.Visible = true;
                    Button6.Visible = true;
                    rbListNumberCopies.Visible = true;

                    gvMobileTeams.Visible = false;
                    gvOdsustvo.Visible = false;
                    btnGenerateMobileTeams.Visible = false;
                    btnGenerateOdsustvo.Visible = false;
                    if (rbListNumberCopies.Items.Count > 1)
                    {
                        rbListNumberCopies.Items.RemoveAt(1);
                        rbListNumberCopies.Items.RemoveAt(2);
                        rbListNumberCopies.Items.RemoveAt(2);
                        rbListNumberCopies.Items.RemoveAt(1);
                    }
                    
                }
                if (ddlChooseTypeBag.SelectedItem.Value == "O")
                {
                    Session["p"] = "O";
                    Session["type"] = ddlChooseTypeBag.SelectedItem.Text;
                    //sh 06.10.2012
                    ddlOpstina.Visible = false;
                    rbListNumberCopies.Visible = false;
                    gvOdsustvo.Visible = true;
                    btnGenerateOdsustvo.Visible = true;
                    Button6.Visible = false;
                    gvMobileTeams.Visible = false;
                    btnGenerateMobileTeams.Visible = false;




                    //if (rbListNumberCopies.Items.Count > 1)
                    //{
                    //    rbListNumberCopies.Items.RemoveAt(1);
                    //    rbListNumberCopies.Items.RemoveAt(2);
                    //    rbListNumberCopies.Items.RemoveAt(2);
                    //    rbListNumberCopies.Items.RemoveAt(1);
                    //}
                }
                if (ddlChooseTypeBag.SelectedItem.Value == "F")
                {
                    Session["p"] = "F";
                    Session["type"] = ddlChooseTypeBag.SelectedItem.Text;
                    ddlOpstina.Visible = false;
                    Button6.Visible = true;
                    rbListNumberCopies.Visible = true;

                    gvMobileTeams.Visible = false;
                    gvOdsustvo.Visible = false;
                    btnGenerateMobileTeams.Visible = false;
                    btnGenerateOdsustvo.Visible = false;

                    if (rbListNumberCopies.Items.Count > 1)
                    {
                        rbListNumberCopies.Items.RemoveAt(1);
                        rbListNumberCopies.Items.RemoveAt(2);
                        rbListNumberCopies.Items.RemoveAt(2);
                        rbListNumberCopies.Items.RemoveAt(1);
                    }
                }
                if (ddlChooseTypeBag.SelectedItem.Value == "D")
                {
                    Session["p"] = "D";
                    Session["type"] = ddlChooseTypeBag.SelectedItem.Text;
                    ddlOpstina.Visible = false;
                    Button6.Visible = true;
                    rbListNumberCopies.Visible = true;

                    gvMobileTeams.Visible = false;
                    gvOdsustvo.Visible = false;
                    btnGenerateMobileTeams.Visible = false;
                    btnGenerateOdsustvo.Visible = false;
                    if (rbListNumberCopies.Items.Count > 1)
                    {
                        rbListNumberCopies.Items.RemoveAt(1);
                        rbListNumberCopies.Items.RemoveAt(2);
                        rbListNumberCopies.Items.RemoveAt(2);
                        rbListNumberCopies.Items.RemoveAt(1);
                    }
                }
                if (ddlChooseTypeBag.SelectedItem.Value == "M")
                {

                    Session["p"] = "M";
                    Session["type"] = ddlChooseTypeBag.SelectedItem.Text;
                    //Session["municipality"] = ddlOpstina.SelectedValue.ToString();
                    ddlOpstina.Visible = false;
                    gvMobileTeams.DataBind();
                    gvMobileTeams.Visible = true;
                    btnGenerateMobileTeams.Visible = true;
                    Button6.Visible = false;
                    btnGenerateOdsustvo.Visible = false;
                    rbListNumberCopies.Visible = false;
                    gvOdsustvo.Visible = false;

                    //if (rbListNumberCopies.Items.Count > 1)
                    //{
                    //    rbListNumberCopies.Items.RemoveAt(1);
                    //    rbListNumberCopies.Items.RemoveAt(2);
                    //    rbListNumberCopies.Items.RemoveAt(2);
                    //    rbListNumberCopies.Items.RemoveAt(1);
                    //}
                }
            }
            else
            {

            }
        }


        protected void ddl_DataBound(object sender, EventArgs e)
        {
            DropDownList ddl = (DropDownList)sender;
            ddl.Items.Insert(0, new ListItem(LanguageText.fvlchoose, ""));

        }

        protected void Button6_Click(object sender, EventArgs e)
        {
          try
            {
                Functions.p3_InsertEmptyBagsInto_P3Bags(ddlChooseTypeBag.SelectedItem.Value.ToString().Trim(), Convert.ToInt32(rbListNumberCopies.SelectedValue), ddlOpstina.SelectedValue.ToString());
                lblSuccessGenerateBags.Visible = true;
                lblNotSuccessGenerateBags.Visible = false;
            }
            catch
            {
                lblNotSuccessGenerateBags.Visible = true;
                lblSuccessGenerateBags.Visible = false;
            }
        }

        protected void rbListNumberCopies_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblSuccessGenerateBags.Visible = false;
            lblNotSuccessGenerateBags.Visible = false;
        }

        protected void btnGenerateOdsustvo_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (GridViewRow row in gvOdsustvo.Rows)
                {
                    CheckBox chkOdsustvo = (CheckBox)row.FindControl("chkOdsustvo");
                    if (chkOdsustvo.Checked)
                    {
                        Label PollingStationCode = (Label)row.FindControl("lblPollingStation");
                        Functions.p3_InsertEmptyBagsInto_P3Bags_Odsustvo(ddlChooseTypeBag.SelectedItem.Value.ToString().Trim(),PollingStationCode.Text);
                        lblSuccessGenerateBags.Visible = true;
                        lblNotSuccessGenerateBags.Visible = false;
                    }
                }
                gvOdsustvo.DataBind();
            }
            catch
            {
                lblNotSuccessGenerateBags.Visible = true;
                lblSuccessGenerateBags.Visible = false;
            }
        }

        protected void cbAll_CheckedChanged(object sender, EventArgs e)
        {

            if (gvOdsustvo.Rows.Count > 0)
            {
                CheckBox cb = (CheckBox)gvOdsustvo.HeaderRow.FindControl("cbAll");
                if (cb.Checked)
                {
                    foreach (GridViewRow dt in gvOdsustvo.Rows)
                    {
                        CheckBox cb1 = (CheckBox)dt.FindControl("chkOdsustvo");
                        cb1.Checked = true;
                    }

                }

                else
                {
                    foreach (GridViewRow dt in gvOdsustvo.Rows)
                    {
                        CheckBox cb1 = (CheckBox)dt.FindControl("chkOdsustvo");
                        cb1.Checked = false;
                    }
                }
            }

        }


        protected void cbAllMobilni_CheckedChanged(object sender, EventArgs e)
        {

            if (gvMobileTeams.Rows.Count > 0)
            {
                CheckBox cb = (CheckBox)gvMobileTeams.HeaderRow.FindControl("cbAllMobilni");
                if (cb.Checked)
                {
                    foreach (GridViewRow dt in gvMobileTeams.Rows)
                    {
                        CheckBox cb1 = (CheckBox)dt.FindControl("chkMobilni");
                        cb1.Checked = true;
                    }

                }

                else
                {
                    foreach (GridViewRow dt in gvMobileTeams.Rows)
                    {
                        CheckBox cb1 = (CheckBox)dt.FindControl("chkMobilni");
                        cb1.Checked = false;
                    }
                }
            }

        }

        protected void btnGenerateMobileTeams_Click(object sender, EventArgs e)
        {
            try
            {
                if (gvMobileTeams.Rows.Count > 0) { 
                foreach (GridViewRow row in gvMobileTeams.Rows)
                {
                    Label NumberMobile = (Label)row.FindControl("lblBrojTimova");
                    Label NumberGenerate = (Label)row.FindControl("lblGenerisano");
                    CheckBox chkMobilni = (CheckBox)row.FindControl("chkMobilni");
                    if (chkMobilni.Checked && (int.Parse(NumberMobile.Text) > int.Parse(NumberGenerate.Text)))
                    {
                        Label MunCode = (Label)row.FindControl("lblKod");
                        Label Entity = (Label)row.FindControl("lblEntity");
                        Functions.p3_InsertEmptyBagsInto_P3Bags_Mobilni(ddlChooseTypeBag.SelectedItem.Value.ToString().Trim(), MunCode.Text, Entity.Text, NumberMobile.Text, NumberGenerate.Text);
                        lblSuccessGenerateBags.Visible = true;
                        lblNotSuccessGenerateBags.Visible = false;
                    }
                }
                gvMobileTeams.DataBind();
                }
                if (PSCode.Text != "") { 
                    Functions.p3_InsertEmptyBagsInto_P3Bags_Covid(PSCode.Text);
                }

            }
            catch (Exception )
            {
                lblNotSuccessGenerateBags.Visible = true;
                lblSuccessGenerateBags.Visible = false;
            }
        }

        protected void gvMobileTeams_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label NumberMobile = (Label)e.Row.FindControl("lblBrojTimova");
                Label NumberGenerate = (Label)e.Row.FindControl("lblGenerisano");

                if (int.Parse(NumberMobile.Text) > int.Parse(NumberGenerate.Text))
                    e.Row.BackColor = ColorTranslator.FromHtml("#ffcc99");
            }
        }


    }
}
           
        
    

