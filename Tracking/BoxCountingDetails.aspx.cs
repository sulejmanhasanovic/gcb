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
using System.Drawing;


namespace JIIS.Web.Phase3.Tracking
{
    public partial class BoxCountingDetails : BasePage
    {
        DataSet dsBox = new DataSet();
        string boxType, combination = string.Empty;
        int boxNo = 0;
        string boxNumber;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["PositionRank"] == null)
                Response.Redirect("~/session.aspx");
            string boxID = Request.QueryString["id"].ToString();
            dsBox = Functions.p3_getDataFromBox(int.Parse(boxID));
            boxNumber = Session["boxNumber"].ToString();

            lblBoxNumber.Text = dsBox.Tables[0].Rows[0]["BoxName"].ToString();
            boxNo = int.Parse(dsBox.Tables[0].Rows[0]["BoxNo"].ToString());
            boxType = dsBox.Tables[0].Rows[0]["BoxType"].ToString();
            combination = dsBox.Tables[0].Rows[0]["BoxCombination"].ToString();

            if (!Page.IsPostBack)
            {
                FillGridView();
                Session["kojiput"] = 1;
            }

            //lblCheck1.Visible = false;
        }

        private void FillGridView()
        {
            //foreach (GridViewRow gvRow in GridView1.Rows)
            //{
            //    TextBox tbox = (TextBox)gvRow.FindControl("tBoxControlCount");
            //    Label lb = (Label)gvRow.FindControl("lblLevel");
            //    DataSet ds = Functions.p3_getBoxNoOfBallotsSorted(boxNumber, lb.Text);

            //    tbox.Text = ds.Tables[0].Rows[0][2].ToString();
            //}
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            //01.10.2012 Nedim Check sorted ballot numbers
            DataSet ds1 = new DataSet();
            int noSortedBallots = 0;
            

           // bool check = true;
            int count = 0;
            int count1 = 0;

            foreach (GridViewRow rowItem in GridView1.Rows)
            {
                TextBox controlCount = (TextBox)(rowItem.FindControl("tBoxControlCount"));
                TextBox validBallots = (TextBox)(rowItem.FindControl("tBoxValidBallots"));
                TextBox invalidBallots = (TextBox)(rowItem.FindControl("tBoxInvalidBallots"));
                Label lblMsg = (Label)(rowItem.FindControl("lblMessage"));                

                // 01.10.2012 Nedim Check sorted ballot numbers
                Label level = (Label)(rowItem.FindControl("lblLevel"));
                string level1 = "";
                if (level.Text.Trim() == "Načelnik")
                {
                    level1 = GridView1.DataKeys[rowItem.RowIndex].Values[1].ToString().Trim() + "NA";
                }
                else if (level.Text.Trim() == "Općinsko vijeće")
                {
                    level1 = GridView1.DataKeys[rowItem.RowIndex].Values[1].ToString().Trim() + "OV";
                }
                else
                {
                    level1 = GridView1.DataKeys[rowItem.RowIndex].Values[1].ToString().Trim();
                }
                ds1 = Functions.p3_getBoxNoOfBallotsSorted(lblBoxNumber.Text.Trim(), level1.Trim());
                if (ds1.Tables != null)
                {
                    noSortedBallots = int.Parse(ds1.Tables[0].Rows[0][2].ToString());
                }
                if (noSortedBallots != int.Parse(controlCount.Text))
                {  
                    controlCount.ForeColor = Color.Red;
                    count1 += 1;
                }


                if (int.Parse(controlCount.Text) != (int.Parse(validBallots.Text) + int.Parse(invalidBallots.Text)))
                {
                    //check = false;
                    lblMsg.Text = "*";
                    count += 1;
                }
                else
                {
                    lblMsg.Text = "";
                }
            }

            if (count1 == 0 || (Session["kojiput"].ToString() == "2"))
            {
                //01.10.2012 Nedim
                lblCheck1.Visible = false;
                if (count == 0)
                {
                    foreach (GridViewRow rowItem in GridView1.Rows)
                    {
                        TextBox controlCount = (TextBox)(rowItem.FindControl("tBoxControlCount"));
                        TextBox validBallots = (TextBox)(rowItem.FindControl("tBoxValidBallots"));
                        TextBox invalidBallots = (TextBox)(rowItem.FindControl("tBoxInvalidBallots"));

                        Label pom = (Label)(rowItem.FindControl("lblLevel"));
                        //25.09.2012 Energo
                        string pom1 = "";
                        if (pom.Text == "Načelnik")
                        {
                            pom1 = GridView1.DataKeys[rowItem.RowIndex].Values[1].ToString().Trim() + "NA";
                        }
                        else if (pom.Text == "Općinsko vijeće")
                        {
                            pom1 = GridView1.DataKeys[rowItem.RowIndex].Values[1].ToString().Trim() + "OV";
                        }
                        else
                        {
                            pom1 = GridView1.DataKeys[rowItem.RowIndex].Values[1].ToString().Trim();
                        }
                        Functions.p3_UpdateBoxDetailsCounting(lblBoxNumber.Text.ToString(), int.Parse(controlCount.Text.ToString()), int.Parse(validBallots.Text.ToString()), int.Parse(invalidBallots.Text.ToString()), pom1);
                    }
                    Functions.p3_UpdateBoxStatus("6", lblBoxNumber.Text.ToString());
                    Response.Redirect("~/Phase3/Tracking/BoxCounting.aspx");
                }
                else
                {
                    lblMessage.Text = "!!!!!!!!!!!!!!!!!!!";
                }
            }
            else
            {
                lblCheck1.Text = LanguageText.p3_error1;
                lblCheck1.Visible = true;
                Session["kojiput"] = "2";                
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Phase3/Tracking/BoxCounting.aspx");
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                TextBox tboxControl = (TextBox)e.Row.FindControl("tBoxControlCount");
                TextBox tboxValid = (TextBox)e.Row.FindControl("tBoxValidBallots");
                TextBox tboxInvalid = (TextBox)e.Row.FindControl("tBoxInvalidBallots");
                Label lb = (Label)e.Row.FindControl("lblLevel");

                if (lb.Text == "0")
                {
                    tboxControl.Text = "0";
                    tboxValid.Text = "0";
                    tboxInvalid.Text = "0";
                    
                    tboxControl.ReadOnly = true;
                    tboxValid.ReadOnly = true;
                    tboxInvalid.ReadOnly = true;
                }

                
                if (int.Parse(GridView1.DataKeys[e.Row.RowIndex].Value.ToString()) == 8)
                {
                    lb.Text = "Načelnik";
                    
                }
                if (int.Parse(GridView1.DataKeys[e.Row.RowIndex].Value.ToString()) == 9)
                {
                    lb.Text = "Općinsko vijeće";
                }
            }
        }

        protected void tBoxValidBallots_TextChanged(object sender, EventArgs e)
        {
            TextBox tbValid = (TextBox)sender;
            GridViewRow gvRow = (GridViewRow)tbValid.NamingContainer;
            TextBox tbInvalid = (TextBox)gvRow.FindControl("tBoxInvalidBallots");
            TextBox tbControlCount = (TextBox)gvRow.FindControl("tBoxControlCount");

            if (int.Parse(tbValid.Text) <= int.Parse(tbControlCount.Text))
            {
                tbInvalid.Text = (int.Parse(tbControlCount.Text) - int.Parse(tbValid.Text)).ToString();
                tbInvalid.Focus();
                lblMessage.Text = "";
            }
            else
            {
                lblMessage.Text = tbValid.Text + " > " + tbControlCount.Text;
            }
        }

        protected void tBoxInvalidBallots_TextChanged(object sender, EventArgs e)
        {
            TextBox tbInvalid = (TextBox)sender;
            GridViewRow gvRow = (GridViewRow)tbInvalid.NamingContainer;
            TextBox tbValid = (TextBox)gvRow.FindControl("tBoxValidBallots");
            TextBox tbControlCount = (TextBox)gvRow.FindControl("tBoxControlCount");

            if (int.Parse(tbInvalid.Text) <= int.Parse(tbControlCount.Text))
            {
                tbValid.Text = (int.Parse(tbControlCount.Text) - int.Parse(tbInvalid.Text)).ToString();
                tbValid.Focus();
                lblMessage.Text = "";
            }
            else
            {
                lblMessage.Text = tbInvalid.Text + " > " + tbControlCount.Text;
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
