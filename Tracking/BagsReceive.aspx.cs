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
    public partial class BagsReceive : BasePage
    {
        int userId;
        //int shipN;
        int totalOthers; 
        int totalPost;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["PositionRank"] == null)
                Response.Redirect("~/session.aspx");

            if (Session["p"].ToString() == "P")
            {

                tBoxShipment.Text = Session["shipment"].ToString();
                totalOthers = Convert.ToInt32(Session["TotalOthers"]);
                totalPost = Convert.ToInt32(Session["TotalShipments"]);

                //tblEdit.Visible = false;
            }
            else
            {

                Button5.Visible = false;
            }
            if (!Page.IsPostBack)
            {
                // btnFinish.Attributes.Add("onclick", "alert('Uspešno ste završili/Успјешно сте завршили!');");
                //if (Session["label"] != null)
                //{
                //    lblNumberShipm.Text = Session["l"].ToString();
                //}
                tblEdit.Visible = false;
                tblEditOthers.Visible = false;
                tBoxDateReceived_CalendarExtender.SelectedDate = DateTime.Now;
                tBoxDateReceivedBirackiSpisak_CalendarExtender.SelectedDate = DateTime.Now;
                tBoxDateReceivedNepotvrdjeni_CalendarExtender.SelectedDate = DateTime.Now;
                tBoxDateReceivedOtsustvo_CalendarExtender.SelectedDate = DateTime.Now;
                //tblByMail.Visible = false;
                //tblNepotvrdjeni.Visible = false;
                //tblOtsustvo.Visible = false;
                //tblBirackiSpisak.Visible = false;
                lblType.Text = Session["type"].ToString();

                Session["shipN"] = 0;
                Session["sumPost"] = 0;
                Session["sumOthers"] = 0;
                Session["ifok"] = "1";
                SelectInput();

            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            int vkupno = 0;
            Users loggedUser = (Users)HttpContext.Current.Session["User"];
            userId = loggedUser.ID;

            try
            {
                if (Session["p"].ToString() == "P")
                {
                    if (ddlbagNumber.SelectedIndex != 1 && ddlbagNumber.SelectedIndex != 2)
                    {
                        if ((int.Parse(Session["sumPost"].ToString()) + int.Parse(tBoxRegEnvelopes.Text) + int.Parse(tBoxFastPost.Text)) <= (totalPost) || int.Parse(Session["ifok"].ToString()).Equals(3))
                        {
                            vkupno = int.Parse(tBoxRegEnvelopes.Text.ToString()) + int.Parse(tBoxFastPost.Text.ToString()) + int.Parse(tBoxUndelivered.Text.ToString());
                            Functions.p3_InsertInto_p3_Bags(int.Parse(ddlPoBox.SelectedItem.Value.ToString()), ddlbagNumber.SelectedItem.Value.ToString(), int.Parse(tBoxShipment.Text.ToString()),
                            int.Parse(tBoxRegEnvelopes.Text.ToString()), int.Parse(tBoxFastPost.Text.ToString()), int.Parse(tBoxUndelivered.Text.ToString()),
                            int.Parse(tBoxOthers.Text.ToString()), vkupno, Session["Date"].ToString(), tBoxComment.Text.ToString(),
                            "", userId);

                            Session["date1"] = Session["Date"].ToString();
                            Session["sumPost"] = int.Parse(Session["sumPost"].ToString())
                                + int.Parse(tBoxRegEnvelopes.Text) + int.Parse(tBoxFastPost.Text);

                            GridView2.DataBind();
                            tblByMail.Visible = true;
                            tBoxRegEnvelopes.Text = "";
                            tBoxFastPost.Text = "";
                            tBoxUndelivered.Text = "";
                            tBoxOthers.Text = "";
                            tBoxComment.Text = "";
                            RadioButtonList1.ClearSelection();

                            lblNumberShipm.Text = (int.Parse(Session["sumPost"].ToString()) + int.Parse(Session["sumOthers"].ToString())).ToString();
                            trEx.Visible = false;
                            trR.Visible = false;
                            trNe.Visible = false;
                            trO.Visible = false;
                            drlist.Visible = true;
                            Session["ifok"] = 2;
                        }

                        else
                        {
                            Session["ifok"] = 3;
                            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Success", "alert('Zelite da unosite vise posiljki nego uneseni broj!/Желите да усносите више пошилјке него унесени број!')", true);
                        }
                    }
                    else
                    {
                        if ((int.Parse(Session["sumOthers"].ToString()) + int.Parse(tBoxUndelivered.Text.ToString()) + int.Parse(tBoxOthers.Text.ToString())) <= (totalOthers) || int.Parse(Session["ifok"].ToString()).Equals(3))
                        {
                            if (ddlbagNumber.SelectedIndex == 1)
                            {
                                Functions.p3_insertOtherMaterialsFromShipment(int.Parse(Session["shipment"].ToString()), "U", int.Parse(tBoxUndelivered.Text.ToString()), userId);
                                Session["sumOthers"] = int.Parse(Session["sumOthers"].ToString())
                                    + int.Parse(tBoxUndelivered.Text) + int.Parse(tBoxOthers.Text);

                                Session["date1"] = Session["Date"].ToString();
                                GridView2.DataBind();
                                tblByMail.Visible = true;
                                tBoxRegEnvelopes.Text = "";
                                tBoxFastPost.Text = "";
                                tBoxUndelivered.Text = "";
                                tBoxOthers.Text = "";
                                tBoxComment.Text = "";
                                RadioButtonList1.ClearSelection();

                                lblNumberShipm.Text = (int.Parse(Session["sumPost"].ToString()) + int.Parse(Session["sumOthers"].ToString())).ToString();
                                trEx.Visible = false;
                                trR.Visible = false;
                                trNe.Visible = false;
                                trO.Visible = false;
                                drlist.Visible = true;
                                gvUO.DataBind();
                            }
                            if (ddlbagNumber.SelectedIndex == 2)
                            {
                                Functions.p3_insertOtherMaterialsFromShipment(int.Parse(Session["shipment"].ToString()), "O", int.Parse(tBoxOthers.Text.ToString()), userId);
                                Session["sumOthers"] = int.Parse(Session["sumOthers"].ToString())
                                    + int.Parse(tBoxUndelivered.Text) + int.Parse(tBoxOthers.Text);

                                Session["date1"] = Session["Date"].ToString();
                                GridView2.DataBind();
                                tblByMail.Visible = true;
                                tBoxRegEnvelopes.Text = "";
                                tBoxFastPost.Text = "";
                                tBoxUndelivered.Text = "";
                                tBoxOthers.Text = "";
                                tBoxComment.Text = "";
                                RadioButtonList1.ClearSelection();

                                lblNumberShipm.Text = (int.Parse(Session["sumPost"].ToString()) + int.Parse(Session["sumOthers"].ToString())).ToString();
                                trEx.Visible = false;
                                trR.Visible = false;
                                trNe.Visible = false;
                                trO.Visible = false;
                                drlist.Visible = true;
                                gvUO.DataBind();
                            }
                            Session["ifok"] = 2;
                        }
                        else
                        {
                            Session["ifok"] = 3;
                            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Success", "alert('Zelite da unosite vise posiljki nego uneseni broj!/Желите да усносите више пошилјке него унесени број!')", true);
                        }
                    }
                }

                if (Session["p"].ToString() == "N")
                {
                    Functions.p3_InsertInto_p3_Bags_Nepotvrdjeni(ddlbagNumber.SelectedItem.Value.ToString(),
                    int.Parse(tBoxNumberOfEnvNepotvrdjeni.Text.ToString()), tBoxDateReceivedNepotvrdjeni.Text.ToString(), tBoxCommentNepotvrdjeni.Text.ToString(), userId);
                    Session["date1"] = tBoxDateReceivedNepotvrdjeni.Text.ToString();
                    tBoxNumberOfEnvNepotvrdjeni.Text = "";
                    tBoxCommentNepotvrdjeni.Text = "";
                    GridView2.DataBind();
                    gvUO.Visible = false;
                }

                if (Session["p"].ToString() == "O")
                {
                    Functions.p3_InsertInto_p3_Bags_Otsustvo(ddlbagNumber.SelectedItem.Value.ToString(),
                    int.Parse(tBoxNumberOfEnvOtsustvo.Text.ToString()), tBoxDateReceivedOtsustvo.Text.ToString(), tBoxCommentOtsustvo.Text.ToString(), userId);
                    Session["date1"] = tBoxDateReceivedOtsustvo.Text.ToString();
                    tblOtsustvo.Visible = true;
                    tBoxNumberOfEnvOtsustvo.Text = "";
                    tBoxCommentOtsustvo.Text = "";
                    GridView2.DataBind();
                    gvUO.Visible = false;
                }

                if (Session["p"].ToString() == "F")
                {
                    Functions.p3_InsertInto_p3_Bags_BSpisak(ddlbagNumber.SelectedItem.Value.ToString(),
                    tBoxDateReceivedBirackiSpisak.Text.ToString(), tBoxDateCommentBirackiSpisak.Text.ToString(), userId);
                    Session["date1"] = tBoxDateReceivedBirackiSpisak.Text.ToString();
                    GridView2.DataBind();
                    tblBirackiSpisak.Visible = true;
                    tBoxDateCommentBirackiSpisak.Text = "";
                    gvUO.Visible = false;
                }
                if (Session["p"].ToString() == "D")
                {
                    Functions.p3_InsertInto_p3_Bags_Otsustvo(ddlbagNumber.SelectedItem.Value.ToString(),
                    int.Parse(tBoxNumberOfEnvOtsustvo.Text.ToString()), tBoxDateReceivedOtsustvo.Text.ToString(), tBoxCommentOtsustvo.Text.ToString(), userId);
                    Session["date1"] = tBoxDateReceivedOtsustvo.Text.ToString();
                    GridView2.DataBind();
                    tblByMail.Visible = false;
                    tblNepotvrdjeni.Visible = false;
                    tblOtsustvo.Visible = true;
                    tblBirackiSpisak.Visible = false;
                    tBoxCommentOtsustvo.Text = "";
                    tBoxNumberOfEnvOtsustvo.Text = "";
                    gvUO.Visible = false;
                }
                if (Session["p"].ToString() == "M")
                {
                    Functions.p3_InsertInto_p3_Bags_Otsustvo(ddlbagNumber.SelectedItem.Value.ToString(),
                    int.Parse(tBoxNumberOfEnvOtsustvo.Text.ToString()), tBoxDateReceivedOtsustvo.Text.ToString(), tBoxCommentOtsustvo.Text.ToString(), userId);
                    Session["date1"] = tBoxDateReceivedOtsustvo.Text.ToString();
                    tblOtsustvo.Visible = true;
                    tBoxCommentOtsustvo.Text = "";
                    tBoxNumberOfEnvOtsustvo.Text = "";
                    GridView2.DataBind();
                    gvUO.Visible = false;
                }
                //tblByMail.Visible = false;
                //tblNepotvrdjeni.Visible = false;
                //tblOtsustvo.Visible = false;
                //tblBirackiSpisak.Visible = false;
                // ddlChooseTypeBag.SelectedItem.Value = "";
                //ddlbagNumber.SelectedIndex = 0;
                ddlbagNumber.DataBind();
                tblMsg.Visible = false;
                Session["noBack"] = 1;
            }
            catch (Exception )
            {
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Session["zbir"] = 1;
            Session["back"] = 1;
            Session["noBack"] = 1;
           
            Functions.p3_InsertInto_ShipmentNumber(Session["Date"].ToString(), int.Parse(Session["TotalShipments"].ToString()), int.Parse(Session["shipment"].ToString()), int.Parse(Session["TotalOthers"].ToString()), Session["comment"].ToString(), 2);
            //Session["label"] = lblNumberShipm.Text;
            Response.Redirect("FormForStatistics.aspx");



        }
        protected void btnC1ancel_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow gvRow in GridView2.Rows)
            {
                Functions.p3_UpdateBagStatusPost(gvRow.Cells[1].Text, 0);
            }

            Response.Redirect("~/Default.aspx");

        }
        //protected void ddlChooseTypeBag_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    SelectInput();
        //}

        private void SelectInput()
        {
            if (Session["p"].ToString() == "P")
            {
                tblByMail.Visible = true;
                tblNepotvrdjeni.Visible = false;
                tblOtsustvo.Visible = false;
                tblBirackiSpisak.Visible = false;
                brP.Visible = true;
                tBoxShipment.Text = Session["shipment"].ToString();
                lbltotalShipment.Text = (totalPost + totalOthers).ToString();
                lblNumberShipm.Text = Session["shipN"].ToString();
            }
            if (Session["p"].ToString() == "N")
            {
                tblByMail.Visible = false;
                tblNepotvrdjeni.Visible = true;
                tblOtsustvo.Visible = false;
                tblBirackiSpisak.Visible = false;
                tBoxShipment.Text = "0";
            }
            if (Session["p"].ToString() == "O")
            {
                tblByMail.Visible = false;
                tblNepotvrdjeni.Visible = false;
                tblOtsustvo.Visible = true;
                tblBirackiSpisak.Visible = false;
                tBoxShipment.Text = "0";
            }
            if (Session["p"].ToString() == "F")
            {
                tblByMail.Visible = false;
                tblNepotvrdjeni.Visible = false;
                tblOtsustvo.Visible = false;
                tblBirackiSpisak.Visible = true;
                tBoxShipment.Text = "0";
            }
            if (Session["p"].ToString() == "D")
            {
                tblByMail.Visible = false;
                tblNepotvrdjeni.Visible = false;
                tblOtsustvo.Visible = true;
                tblBirackiSpisak.Visible = false;
                tBoxShipment.Text = "0";
            }
            if (Session["p"].ToString() == "M")
            {
                tblByMail.Visible = false;
                tblNepotvrdjeni.Visible = false;
                tblOtsustvo.Visible = true;
                tblBirackiSpisak.Visible = false;
                tBoxShipment.Text = "0";
            }
        }

        protected void ddl_DataBound(object sender, EventArgs e)
        {
            DropDownList ddl = (DropDownList)sender;
            ddl.Items.Insert(0, new ListItem(LanguageText.fvlchoose, ""));
            if (Session["p"].ToString() == "P")
            {
                ddl.Items.Insert(1, new ListItem(LanguageText.tr_Undelivered, "U"));
                ddl.Items.Insert(2, new ListItem(LanguageText.tr_others, "O"));
            }
        }

        protected void ddlbagNumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlbagNumber.SelectedIndex == 1)
            {
                trEx.Visible = false;
                trR.Visible = false;
                trNe.Visible = true;
                trO.Visible = false;
                tBoxRegEnvelopes.Text = "0";
                tBoxFastPost.Text = "0";
                tBoxOthers.Text = "0";
                drlist.Visible = false;
            }


            if (ddlbagNumber.SelectedIndex == 2)
            {
                trEx.Visible = false;
                trR.Visible = false;
                trNe.Visible = false;
                trO.Visible = true;
                tBoxRegEnvelopes.Text = "0";
                tBoxFastPost.Text = "0";
                tBoxUndelivered.Text = "0";
                drlist.Visible = false;
            }
            if (ddlbagNumber.SelectedIndex != 1 && ddlbagNumber.SelectedIndex != 2)
            {
                trEx.Visible = false;
                trR.Visible = false;
                trNe.Visible = false;
                trO.Visible = false;
                drlist.Visible = true;

            }
            RadioButtonList1.ClearSelection();
        }

        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (RadioButtonList1.SelectedValue == "1")
            {
                trR.Visible = true;
                trEx.Visible = false;
                trNe.Visible = false;
                trO.Visible = false;
                tBoxFastPost.Text = "0";
                tBoxUndelivered.Text = "0";
                tBoxOthers.Text = "0";
            }
            if (RadioButtonList1.SelectedValue == "2")
            {
                trEx.Visible = true;
                trR.Visible = false;
                trNe.Visible = false;
                trO.Visible = false;
                tBoxRegEnvelopes.Text = "0";
                tBoxUndelivered.Text = "0";
                tBoxOthers.Text = "0";
            }
        }

        protected void btnFinish_Click(object sender, EventArgs e)
        {
            if (Session["p"].ToString() == "P")
            {
                if (int.Parse(lblNumberShipm.Text) != int.Parse(lbltotalShipment.Text))
                {
                    lblMsg.Text = lblNumberShipm.Text + " <> " + lbltotalShipment.Text;
                    tblMsg.Visible = true;
                }
                else
                {
                    int sumPost = 0;
                    int sumOthers = 0;

                    foreach (GridViewRow gvRow in GridView2.Rows)
                    {
                        sumPost += int.Parse(gvRow.Cells[3].Text);
                    }

                    foreach (GridViewRow gvRow in gvUO.Rows)
                    {
                        sumOthers += int.Parse(gvRow.Cells[3].Text);
                    }

                    if (sumPost != totalPost)
                    {
                        lblMsg.Text = sumPost.ToString() + " <> " + totalPost.ToString();
                        tblMsg.Visible = true;
                    }
                    else
                    {
                        if (sumOthers != totalOthers)
                        {
                            lblMsg.Text = sumOthers.ToString() + " <> " + totalOthers.ToString();
                            tblMsg.Visible = true;
                        }
                        else
                        {
                            foreach (GridViewRow gvRow in GridView2.Rows)
                            {
                                Functions.p3_UpdateBagStatusPost(gvRow.Cells[1].Text, 1);
                                Functions.p3_InsertInto_ShipmentNumber(Session["Date"].ToString(), int.Parse(Session["TotalShipments"].ToString()), int.Parse(Session["shipment"].ToString()), int.Parse(Session["TotalOthers"].ToString()), Session["comment"].ToString(), 1);
                            }
                            Panel3.Visible = true;

                        }
                    }
                }
            }
            else
            {
                //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Success", "alert('Uspešno ste završili/Успјешно сте завршили!')", true);
                //btnFinish.Attributes.Add("onclick", "alert('Uspešno ste završili/Успјешно сте завршили!');");

                Panel3.Visible = true;
            }
        }
        protected void okButton_Click(object sender, EventArgs e)
        {
            Session.Remove("back");
            Session.Remove("noBack");
            Session.Remove("zbir");

            Panel3.Visible = false;
            Response.Redirect("~/Default.aspx");
        }
        protected void btnEditNoEnv_Click(object sender, EventArgs e)
        {
            lblWhichBag.Text = Session["rowID1"].ToString();
            int totalEnv = int.Parse(Session["sumPost"].ToString());
            totalEnv = totalEnv - int.Parse(Session["noEnv"].ToString());
            totalEnv = totalEnv + int.Parse(txtEditNoEnv.Text);
            if (totalEnv <= totalPost)
            {
                tblMsg.Visible = false;
                Functions.p3_EditBags(int.Parse(Session["rowID"].ToString()), int.Parse(txtEditNoEnv.Text));
                GridView2.DataBind();
                lblNumberShipm.Text = (totalEnv + int.Parse(Session["sumOthers"].ToString())).ToString();
                //total = total + int.Parse(txtEditNoEnv.Text);
                Session["sumPost"] = totalEnv;
                txtEditNoEnv.Text = "";
                tblEdit.Visible = false;
                Session.Remove("rowID");
                Session.Remove("noEnv");
            }
            else
            {
                tblEdit.Visible = true;
                tblMsg.Visible = true;
            }
        }

        protected void linkEdit_Click(object sender, EventArgs e)
        {
            LinkButton lbEdit = (LinkButton)sender;
            GridViewRow gvRow = (GridViewRow)lbEdit.NamingContainer;

            Session["rowID"] = GridView2.DataKeys[gvRow.RowIndex].Values["Id"].ToString();
            Session["rowID1"] = GridView2.DataKeys[gvRow.RowIndex].Values["PollingStationCode"].ToString();
            Session["noEnv"] = gvRow.Cells[3].Text;
            lblWhichBag.Text = Session["rowID1"].ToString();
            // Session["bag1"] = GridView2.DataKeys[gvRow.RowIndex].Values["PollingStationCode"].ToString();

            tblEdit.Visible = true;
            txtEditNoEnv.Focus();
        }

        protected void linkEditOthers_Click(object sender, EventArgs e)
        {
            LinkButton lbEdit = (LinkButton)sender;
            GridViewRow gvRow = (GridViewRow)lbEdit.NamingContainer;

            Session["rowID"] = gvUO.DataKeys[gvRow.RowIndex].Values["ID"].ToString();
            Session["rowID1"] = gvUO.DataKeys[gvRow.RowIndex].Values["Type"].ToString();
            Session["noEnv"] = gvRow.Cells[3].Text;
            lblWhichBag1.Text = Session["rowID1"].ToString();
            tblEditOthers.Visible = true;
            txtEditOthers.Focus();
        }

        protected void btnEditOthers_Click(object sender, EventArgs e)
        {
            int totalO = int.Parse(Session["sumOthers"].ToString());
            totalO = totalO - int.Parse(Session["noEnv"].ToString());
            totalO = totalO + int.Parse(txtEditOthers.Text);
            if (totalO <= (totalOthers + totalPost))
            {
                tblMsg.Visible = false;
                Functions.p3_EditOtherMaterials(int.Parse(Session["rowID"].ToString()), int.Parse(txtEditOthers.Text));
                gvUO.DataBind();
                lblNumberShipm.Text = (totalO + int.Parse(Session["sumPost"].ToString())).ToString();
                //total = total + int.Parse(txtEditNoEnv.Text);
                Session["sumOthers"] = totalO;
                txtEditOthers.Text = "";
                tblEditOthers.Visible = false;
                Session.Remove("rowID");
                Session.Remove("noEnv");
            }
            else
            {
                tblEditOthers.Visible = true;
                tblMsg.Visible = true;
            }
        }

        protected void tBoxDateReceivedNepotvrdjeni_TextChanged(object sender, EventArgs e)
        {
            Session["date1"] = tBoxDateReceivedNepotvrdjeni.Text.ToString();
        }

        protected void tBoxDateReceivedOtsustvo_TextChanged(object sender, EventArgs e)
        {
            Session["date1"] = tBoxDateReceivedOtsustvo.Text.ToString();
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            lblMsg.Visible = false;
            tblEdit.Visible = false;
        }

        protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (Session["zbir"] != null)
            {

                if (int.Parse(Session["zbir"].ToString()) == 2)
                {
                    int k = 0;
                    foreach (GridViewRow gvRow in GridView2.Rows)
                    {
                        k += int.Parse(gvRow.Cells[3].Text);
                    }

                    Session["sumPost"] = k.ToString();
                    lblNumberShipm.Text = (int.Parse(Session["sumPost"].ToString()) + int.Parse(Session["sumOthers"].ToString())).ToString();
                    //foreach (GridViewRow gvRow in gvUO.Rows)
                    //{
                    //    lblNumberShipm.Text += int.Parse(gvRow.Cells[3].Text);
                    //}
                }

            }
        }

        protected void gvUO_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void gvUO_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (Session["zbir"] != null)
            {
                if (e.Row.Cells[2].Text == "U")
                {
                    e.Row.Cells[2].Text = LanguageText.tr_Undelivered;
                }
                if (e.Row.Cells[2].Text == "O")
                {
                    e.Row.Cells[2].Text = LanguageText.tr_others;
                }
                if (int.Parse(Session["zbir"].ToString()) == 2)
                {
                    int k = 0;
                    foreach (GridViewRow gvRow in gvUO.Rows)
                    {
                        k += int.Parse(gvRow.Cells[3].Text);
                    }

                    Session["sumOthers"] = k.ToString();
                    lblNumberShipm.Text = (int.Parse(Session["sumPost"].ToString()) + int.Parse(Session["sumOthers"].ToString())).ToString();
                    //foreach (GridViewRow gvRow in gvUO.Rows)
                    //{
                    //    lblNumberShipm.Text += int.Parse(gvRow.Cells[3].Text);
                    //}
                }
            }
        }

        protected void Button7_Click(object sender, EventArgs e)
        {
            lblMsg.Visible = false;
            tblEditOthers.Visible = false;
        }
    }
}
