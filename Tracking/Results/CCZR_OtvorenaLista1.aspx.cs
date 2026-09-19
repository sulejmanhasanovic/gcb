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
using JIIS.Web.Classes;
using Resources;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Drawing;

namespace JIIS.Web.Phase3.Tracking.Results
{
    public partial class CCZR_OtvorenaLista1 : BasePage
    {
        DataSet dsData;
        Users loggedUser;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["PositionRank"] == null)
                Response.Redirect("~/session.aspx");
            lblLevelCode.Text = Session["level"].ToString();
            lblPSCode.Text = Session["pscode"].ToString();
            lblPS.Text = Session["pscode"].ToString();
            //ke mi treba da go zemam od zavisnost na kodot na levelot, da go zemam imeto
            //ke napravam procedura koja ke zema od MunReg so e tabelata
            //i plus ke go zemam imeto na izbornata trka
            dsData = Functions.RESULTSLevelGetNameForCode(Session["level"].ToString(), int.Parse(Session["idrace"].ToString()));
            lblRaceName.Text = dsData.Tables[1].Rows[0][0].ToString();
            lblLevelName.Text = dsData.Tables[0].Rows[0][0].ToString();
            lblKategorija.Text = Session["kategorija"].ToString();

            loggedUser = (Users)HttpContext.Current.Session["User"]; //ke se smene koga ke se povrze so menito
            Session["UserID"] = loggedUser.ID.ToString();
            if (!Page.IsPostBack)
            {
                Session["ifok"] = "2";
                Session["pati"] = "2";
                Session["eror2"] = "2";
                Session["eror3"] = "2";
                Session["eror4"] = "2";
                Session["eror5"] = "2";
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            bool field1;
            bool field2;
            bool field3;
            bool filed4;
            //Nedim
           // bool field5;
            if (int.Parse(txtC.Text.ToString()) + int.Parse(txtD.Text.ToString()) != int.Parse(txtE.Text.ToString()))
            {
                lblField1.Text = LanguageText.p3_erorCDE;
                field1 = false;
                //lblField1.Visible = true;
            }
            else
            {
                field1 = true;
                lblField1.Visible = false;
            }
            if (int.Parse(txtA.Text.ToString()) + int.Parse(txtB.Text.ToString()) != int.Parse(txtC.Text.ToString()))
            {
                lblField2.Text = LanguageText.p3_erorABC;
                field2 = false;
                //lblField2.Visible = true;

            }
            else
            {
                field2 = true;
                lblField2.Visible = false;
            }
            if (txt3.Text.ToString() != Math.Abs(int.Parse(txt1.Text.ToString()) - int.Parse(txt2.Text.ToString())).ToString())
            {
                lblField3.Text = LanguageText.p3_eror123;
                field3 = false;
                //lblField3.Visible = true;
            }
            else
            {
                field3 = true;
                lblField3.Visible = false;
            }
            if (txtF.Text.ToString() != Math.Abs(int.Parse(txt2.Text.ToString()) - int.Parse(txtE.Text.ToString())).ToString())
            {
                lblField4.Text = LanguageText.p3_eror2EF;
                filed4 = false;
                //lblField4.Visible = true;
            }
            else
            {
                filed4 = true;
                lblField4.Visible = false;
            }

            //Nedim
            DataSet ds = new DataSet();
            int sumOfSignature = 0; 
            
            ds = Functions.p3_getBagDetailsByBoxName(Session["pscode"].ToString());
            if (ds.Tables != null)
            {
                for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                {
                    sumOfSignature += int.Parse(ds.Tables[0].Rows[i][2].ToString());    
                }
            }

            DataSet ds1 = new DataSet();
            int sumOfSortedBallot = 0;
            string levelCode;
            if (int.Parse(Session["idrace"].ToString()) == 8)
            {
                levelCode = Session["level"].ToString().Trim() + "NA";
            }
            else if (int.Parse(Session["idrace"].ToString()) == 9)
            {
                levelCode = Session["level"].ToString().Trim() + "OV";
            }
            else
            {
                levelCode = Session["level"].ToString();
            }
            ds1 = Functions.p3_getBoxDetailForEdit(Session["pscode"].ToString(), levelCode);
            if (ds1.Tables != null)
            {
                for (int i = 0; i <= ds1.Tables[0].Rows.Count - 1; i++)
                {
                    sumOfSortedBallot += int.Parse(ds1.Tables[0].Rows[i][2].ToString());    
                }
            }

            int sumOfInvalidBallots = 0;
            if (ds1.Tables != null)
            {
                for (int i = 0; i <= ds1.Tables[0].Rows.Count - 1; i++)
                {
                    sumOfInvalidBallots += int.Parse(ds1.Tables[0].Rows[i][5].ToString());
                }
            }

            int sumOfValidBallots = 0;
            if (ds1.Tables != null)
            {
                for (int i = 0; i <= ds1.Tables[0].Rows.Count - 1; i++)
                {
                    sumOfValidBallots += int.Parse(ds1.Tables[0].Rows[i][4].ToString());
                }
            }

            int sumOfCountedBallots = 0;
            if (ds1.Tables != null)
            {
                for (int i = 0; i <= ds1.Tables[0].Rows.Count - 1; i++)
                {
                    sumOfCountedBallots += int.Parse(ds1.Tables[0].Rows[i][3].ToString());
                }
            }

            //if (txt2.Text != sumOfSignature.ToString())
            //{
            //    lblCheck2.Text = LanguageText.p3_eror2;
            //    field5 = false;
            //}
            //else
            //{
            //    field5 = true;
            //    lblCheck2.Visible = false;
            //}
            //Nedim
            if ((sumOfSignature == int.Parse(txt1.Text)) || (Session["pati"].ToString() == "1"))
            {
                lblCheck1.Visible = false;

                if ((sumOfSortedBallot == int.Parse(txt2.Text)) || (Session["eror2"].ToString() == "1"))
                {
                    lblCheck2.Visible = false;

                    if ((sumOfInvalidBallots == int.Parse(txtC.Text)) || (Session["eror3"].ToString() == "1"))
                    {
                        lblCheck3.Visible = false;

                        if ((sumOfValidBallots == int.Parse(txtD.Text)) || (Session["eror4"].ToString() == "1"))
                        {
                            lblCheck4.Visible = false;

                            if ((sumOfCountedBallots == int.Parse(txtE.Text)) || (Session["eror5"].ToString() == "1"))
                            {
                                lblCheck5.Visible = false;

                                if ((field1 == true && field2 == true && field3 == true && filed4 == true) || (Session["ifok"].ToString() == "1"))
                                {
                                    Functions.RESULTS_InsertIntoPSStatistic(Session["pscode"].ToString(), Session["level"].ToString(), int.Parse(Session["idrace"].ToString()),
                                            int.Parse(Session["kojpat"].ToString()), int.Parse(Session["UserID"].ToString()), int.Parse(txt1.Text.ToString()),
                                            int.Parse(txt2.Text.ToString()), int.Parse(txtA.Text.ToString()), int.Parse(txtB.Text.ToString()),
                                            int.Parse(txtC.Text.ToString()), int.Parse(txtD1.Text.ToString()), int.Parse(txtD2.Text.ToString()),
                                            int.Parse(txtD.Text.ToString()), int.Parse(txtE.Text.ToString()), int.Parse(txt3.Text.ToString()), int.Parse(txtF.Text.ToString()));
                                    Session["raceName"] = dsData.Tables[1].Rows[0][0].ToString();
                                    Session["levelName"] = dsData.Tables[0].Rows[0][0].ToString();
                                    int parametarce = 0;
                                    if (int.Parse(Session["kojpat"].ToString()) == 1)
                                    {
                                        parametarce = 1;
                                    }
                                    else
                                    {
                                        parametarce = 2;

                                    }
                                    Functions.RESULTS_InsertUpdateIntoPSStatistic(parametarce, Session["pscode"].ToString(), Session["level"].ToString(), int.Parse(Session["idrace"].ToString()), int.Parse(Session["kojpat"].ToString()), 1, "NOTOK", "4");
                                    Functions.RESULTS_InsertUpdateIntoResultsArchive(parametarce, Session["pscode"].ToString(), int.Parse(Session["idrace"].ToString()), Session["level"].ToString(), 1, 1, 0, int.Parse(Session["UserID"].ToString()), 0, 0, 0);
                                    if (parametarce == 2)
                                    {
                                        //tuka ke treba da proveram dali prviot i vtoriot vnes se isti za soodvetnoto,
                                        //ako se isti da zapisam deka se isti, a ako ne deka treba da bidat resolev od supervisorot
                                        Functions.RESULTS_CheckOtvorenaLista1TWOEntries(Session["pscode"].ToString(), Session["level"].ToString(), int.Parse(Session["idrace"].ToString()),
                                                int.Parse(txt1.Text.ToString()), int.Parse(txt2.Text.ToString()), int.Parse(txt3.Text.ToString()), int.Parse(txtA.Text.ToString()), int.Parse(txtB.Text.ToString()),
                                            int.Parse(txtC.Text.ToString()), int.Parse(txtD1.Text.ToString()), int.Parse(txtD2.Text.ToString()),
                                            int.Parse(txtD.Text.ToString()), int.Parse(txtE.Text.ToString()), int.Parse(txtF.Text.ToString()), int.Parse(Session["UserID"].ToString()));
                                    }
                                    Response.Redirect("~/Phase3/Tracking/Results/CCZR_OtvorenaLista2.aspx");
                                }
                                else
                                {
                                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Success", "alert('Provjerite svoj ulaz na rezultatima još jednom!/Проверите свој улаз на резултатима још једном!')", true);
                                    //Panel3.Visible = true;
                                    Session["ifok"] = "1";
                                }
                            }
                            else
                            {
                                lblCheck5.Visible = true;
                                Session["eror5"] = "1";
                                txtE.ForeColor = Color.Red;
                            }
                        }
                        else
                        {
                            lblCheck4.Visible = true;
                            Session["eror4"] = "1";
                            txtD.ForeColor = Color.Red;
                        }
                    }
                    else
                    {
                        lblCheck3.Visible = true;
                        Session["eror3"] = "1";
                        txtC.ForeColor = Color.Red;
                    }
                }
                else
                {
                    lblCheck2.Visible = true;
                    Session["eror2"] = "1";
                    txt2.ForeColor = Color.Red;
                }
            }
            else
            {
                lblCheck1.Visible = true;
                Session["pati"] = "1";
                txt1.ForeColor = Color.Red;
            }
        }
        protected void okButton_Click(object sender, EventArgs e)
        {
            //Panel3.Visible = false;

        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Phase3/Tracking/Results/ResultsEntry.aspx");
        }


    }
}
