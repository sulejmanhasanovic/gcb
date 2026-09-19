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
    public partial class BoxSortingDetails : BasePage
    {
        DataSet dsBox = new DataSet();
        string boxType, combination = string.Empty;
        int boxNo = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["PositionRank"] == null)
                Response.Redirect("~/session.aspx");
            string boxID = Request.QueryString["id"].ToString();
            dsBox = Functions.p3_getDataFromBox(int.Parse(boxID));

            lblBoxNumber.Text = dsBox.Tables[0].Rows[0]["BoxName"].ToString();
            lblNumberEnvelopes.Text = dsBox.Tables[0].Rows[0]["TotalNoOfEnvelopes"].ToString();
            boxNo = int.Parse(dsBox.Tables[0].Rows[0]["BoxNo"].ToString());
            boxType = dsBox.Tables[0].Rows[0]["BoxType"].ToString();
            combination = dsBox.Tables[0].Rows[0]["BoxCombination"].ToString();

            if (!Page.IsPostBack)
            {
                FillGridView();
            }
        }

        private void FillGridView()
        {
            int count = 0;

            foreach (GridViewRow gvRow in GridView1.Rows)
            {
                TextBox tbox = (TextBox)gvRow.FindControl("tBoxNumberEnvLevel");
                Label lb = (Label)gvRow.FindControl("lblLevel");               

                if (lb.Text != "0")
                {
                    tbox.Text = lblNumberEnvelopes.Text;
                    count += int.Parse(lblNumberEnvelopes.Text);
                }

                tBoxTotalNumberEnvelopes.Text = count.ToString();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            bool check = true;

            foreach (GridViewRow rowItem in GridView1.Rows)
            {
                TextBox pom = (TextBox)(rowItem.FindControl("tBoxNumberEnvLevel"));
                int pom1 = int.Parse(pom.Text.ToString());
                int pom2 = int.Parse(lblNumberEnvelopes.Text) - int.Parse(tBoxDeniedEnvelopes.Text);
                if (pom1 > pom2)
                {
                    //lblMessage.Text = "Ne smee da bide pogolema od " + pom2.ToString();
                    check = false;
                    break;
                }
            }

            //int test = (int.Parse(tBoxDeniedEnvelopes.Text.ToString()) + int.Parse(tBoxTotalNumberEnvelopes.Text.ToString())) / 2;
            //if (lblNumberEnvelopes.Text != test.ToString())
            //{
            //    lblMessage.Text = LanguageText.tr_envNotMatch;
            //}
            //else
            //{


            if (check)
            {
                foreach (GridViewRow rowItem in GridView1.Rows)
                {
                    TextBox sortedEnv = (TextBox)(rowItem.FindControl("tBoxNumberEnvLevel"));
                    string pom = GridView1.DataKeys[rowItem.RowIndex].Values[1].ToString();
                    //25.09.2012 Energo
                    string idRace = GridView1.DataKeys[rowItem.RowIndex].Values[0].ToString();
                    if (idRace == "8")
                    {
                        pom = pom.Trim() + "NA";
                    }
                    else if (idRace == "9")
                    {
                        pom = pom.Trim() + "OV";
                    }
                    Functions.p3_InsertBoxDetailsSorting(lblBoxNumber.Text.ToString(), boxNo, combination.ToString().Trim(), boxType.ToString().Trim(), pom.Trim(), int.Parse(sortedEnv.Text.ToString()));
                }
                Functions.p3_updateBoxRejectedEnvelopes(lblBoxNumber.Text.ToString(), int.Parse(tBoxDeniedEnvelopes.Text.ToString()), "4");
                Response.Redirect("~/Phase3/Tracking/BoxSorting.aspx");
            }
            else
            {
                lblMessage.Text = LanguageText.tr_envNotMatch;
            }

            //}
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("BoxSorting.aspx");
        }

        protected void onTextChanged(object sender, EventArgs e)
        {
            int proba = 0;
            if (tBoxDeniedEnvelopes.Text.ToString() != string.Empty)
            {
                foreach (GridViewRow rowItem in GridView1.Rows)
                {
                    TextBox pom = (TextBox)(rowItem.FindControl("tBoxNumberEnvLevel"));
                    int pom1 = int.Parse(pom.Text.ToString());
                    int pom2 = int.Parse(lblNumberEnvelopes.Text) - int.Parse(tBoxDeniedEnvelopes.Text);
                    if (pom1 > pom2)
                    {
                        lblMessage.Text = LanguageText.zzGreaterThan + pom2.ToString();
                    }
                    proba += pom1;
                }
                tBoxTotalNumberEnvelopes.Text = proba.ToString();
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Phase3/Tracking/BoxSorting.aspx");
        }

        protected void tBoxDeniedEnvelopes_TextChanged(object sender, EventArgs e)
        {
            int count = 0;
            if (tBoxDeniedEnvelopes.Text.ToString() != string.Empty)
            {
                foreach (GridViewRow gvRow in GridView1.Rows)
                {
                    Label lb = (Label)gvRow.FindControl("lblLevel");
                    TextBox tbox = (TextBox)gvRow.FindControl("tBoxNumberEnvLevel");
                    if (lb.Text != "0")
                    {
                        tbox.Text = (int.Parse(lblNumberEnvelopes.Text) - int.Parse(tBoxDeniedEnvelopes.Text)).ToString();
                        count += int.Parse(lblNumberEnvelopes.Text) - int.Parse(tBoxDeniedEnvelopes.Text);
                    }
                }
                tBoxTotalNumberEnvelopes.Text = count.ToString();
            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                TextBox tbox = (TextBox)e.Row.FindControl("tBoxNumberEnvLevel");
                Label lb = (Label)e.Row.FindControl("lblLevel");

                if (lb.Text == "0")
                {
                    tbox.ReadOnly = true;
                }

                if (int.Parse(GridView1.DataKeys[e.Row.RowIndex].Value.ToString()) == 8)
                {
                    lb.Text = "Nacelnik";
                }
                if (int.Parse(GridView1.DataKeys[e.Row.RowIndex].Value.ToString()) == 11)
                {
                    lb.Text = "Gradonacelnik Istocnog Sarajeva";
                }
                if (int.Parse(GridView1.DataKeys[e.Row.RowIndex].Value.ToString()) == 9)
                {
                    lb.Text = "Opcinsko vijece";
                }
                if (int.Parse(GridView1.DataKeys[e.Row.RowIndex].Value.ToString()) == 12)
                {
                    lb.Text = "Gradsko vijeće Grada mostara";
                }
            }
        }
    }
}
