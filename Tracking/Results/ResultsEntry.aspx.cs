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

namespace JIIS.Web.Phase3.Tracking.Results
{

    public partial class ResultsEntry : BasePage
    {
        Users loggedUser;
        int userce = 0;
        //ovaa strana ke bide pocetna pri vnes na rezultati od strana na MEC - znaci toa e PRV vnes
        //vo sesija ke go imam kodot na opstinata vo zavisnost od logiraniot korisnik
        //e sega za toj kod ke treba da gi zemam site Izborni trki koj se aktivni
        //i za izbrana trka i izbran PS da se otvore forma za vnes na rezultati
        //tuka ke treba da proveruvam dali korisnikot ima privilegii za vnes na rezultati
        //ako nema ke treba site komcina i dropdown listi da gi stavam disabled
        //i plus da mu napisam poraka deka nema privilegii za vnes
        //drugo so ke treba da se proveruva e dali se raboti za izborna trka - VG ili OL
        int status = 0;
        int idrace = 0;

        string psnumber = "";
        //status e od ResultsEntriesArchive
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["PositionRank"] == null)
                Response.Redirect("~/session.aspx");
            DataSet ds = new DataSet();
            ds = Functions.oktomvriIDpagePosition(54, int.Parse(Session["PositionRank"].ToString()));

            if (ds.Tables[0].Rows[0][0].ToString() == "0")
                Response.Redirect("~/Default.aspx");

            Session["MECMunicipality"] = DropDownList3.SelectedValue.ToString();
            loggedUser = (Users)HttpContext.Current.Session["User"]; //ke se smene koga ke se povrze so menito
            Session["UserID"] = loggedUser.ID.ToString();
            userce = loggedUser.ID;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string levelNov = Functions.Tracking_Results_GetLevelForRaceANDCombination(Session["MECMunicipality"].ToString(), int.Parse(DropDownList2.SelectedValue.ToString()));
            Session["kategorija"] = DropDownList3.SelectedValue.ToString();
            if (txtPSCode.Text != DropDownList1.SelectedItem.Text.ToString())
            {
                lblError0.Visible = true;
                lblError0.Text = LanguageText.p3_MessagePolling;
            }
            else
            {
                lblError0.Visible = false;

                //01.10.2012 Nedim Check if box status = 6
                int boxCount = Functions.p3_getBoxReadyForEntryResults(DropDownList1.SelectedItem.Text.ToString());
                if (boxCount != 0)
                {
                    lblError2.Visible = false;

                    idrace = int.Parse(DropDownList2.SelectedValue.ToString());
                    psnumber = DropDownList1.SelectedItem.Text.ToString();
                    DataSet ds = new DataSet();
                    ds = Functions.p3_Check1Entry(idrace, psnumber, int.Parse(Session["UserID"].ToString()));
                    if (ds.Tables.Count == 0)
                    { }
                    else
                    {
                        if (ds.Tables[0].Rows[0][0].ToString() == "1" && ds.Tables[1].Rows[0][0].ToString() == "0")
                        {
                            lblError1.Visible = false;

                        }
                        else
                        {
                            if (ds.Tables[0].Rows[0][0].ToString() == "2" && ds.Tables[1].Rows[0][0].ToString() == "2")
                            {
                                lblError1.Visible = true;
                                lblError1.Text = LanguageText.p3_insertprv;


                            }
                            else
                            {
                                lblError1.Visible = true;
                                lblError1.Text = LanguageText.p3_sameUser;


                            }
                        }
                    }

                    DataSet dsstatus = Functions.p3_Results_CheckIfPSReadyForEntry(psnumber, idrace);
                    if (dsstatus.Tables[0].Rows.Count == 0)
                    {
                        status = 0;
                    }
                    else
                    {
                        status = 1;
                    }


                    //status ke treba da mi zema od ResultsEntriesStatus
                    //ako EntryNumber = 1, Item = 5 i Status OK i NextStep = Entry2
                    //toa znaci deka ne moze da vnesuva i status ke zema vrednost 1
                    //ako ne postoi seuste redica za toj ps i trka toa znaci se pocnuva od pocetok
                    //i na status ke mu dademe vrednost 0
                    if ((status == 0) && RadioButtonList1.SelectedValue.ToString().Equals("1"))
                    //znaci deka se rabote za prv vnes
                    {
                        //treba da ode na strana za vnes na rezultati, t.e. moze da pocne vnesot
                        //tuka ke treba da prefrlam nekoi podatoci kako sto e Levelot, idRace i pscodot
                        //znaci od pscode i idrace ke mora da go pobaram levelot
                        //ako race = 8 ili 9 (opstincki izbori) levelot = na mucodot
                        //ako se rabote za opci izbori treba da go najdam
                        Session["pscode"] = psnumber;
                        Session["idrace"] = idrace.ToString();
                        Session["kojpat"] = "1";

                        Session["level"] = levelNov;

                        //otkako site sesii se podgotveni da idat dajle treba da opredelime dali ke ode
                        //za vnes kako otvorena lista ili pak vecinski glas
                        //vo zavisnost od tipot na izborot ke se razgranuva na dve strani
                        //ZR_OtvorenaLista.aspx za otvorenite listi i
                        //ZR_VecinskiGlas1.aspx za Vecinski Glas
                        if (idrace == 1 || idrace == 5 || idrace == 8)
                        {
                            Response.Redirect("~/Phase3/Tracking/Results/CCZR_VecinskiGlas1.aspx");
                        }
                        else
                        {
                            Response.Redirect("~/Phase3/Tracking/Results/CCZR_OtvorenaLista1.aspx");
                        }
                    }
                    else if ((status == 0) && RadioButtonList1.SelectedValue.ToString().Equals("2"))
                    {
                        //tuka ke treba da mu se dade poraka deka za toj PS ne se vneseni po prv pat
                        lblError.Text = LanguageText.p3_SecondEntry1;
                        lblError.Visible = true;
                    }
                    //tuka ke treba da se dopravi da se proveruva od kaj da se prodolzi so vnes za toj PS
                    //moze da se sluce da padne sesija i slicno, pa ke treba da se prodolze so vnes onamu kaj so
                    //se zastana. Za toa ke ja koristam tabelata p3_ResultsEntryStatus
                    //i za sekoj PS ke treba da provervam do kaj e i so e
                    //ke treba da gi provervam Item 
                    //1	Stat      
                    //2	VG        
                    //3	NM        
                    //4	OL        
                    //ako sleden cekor e Stat ideme od pocetok,
                    //ako sleden cekor e VG ideme na vtorata strana
                    //ako e OL i nekoe brojce na primer 7
                    //treba da se prodolze so vnes na glasovi za 7mata partija po red
                    //i na kraj ako sledno e NM ideme so vnes na NM
                    //za eden PS i Race moze da ima samo edna redica vo ovaa tabela
                    //i ke se prave update sto e sledno posle zavrsuvanje na sekoja nezavisna aktivnost
                    //ako za toj PS i Race ne vrate nisto funkcijata togas ideme so vnes od pocetok. t.e. nema proverki
                    else if (status == 1)
                    {
                        int entryNum = int.Parse(dsstatus.Tables[0].Rows[0][0].ToString());
                        int item = int.Parse(dsstatus.Tables[0].Rows[0][1].ToString());
                        string statusMess = dsstatus.Tables[0].Rows[0][2].ToString();
                        string NextStep = dsstatus.Tables[0].Rows[0][3].ToString();
                        //veke ima nekoj vneseno za toj ps i toj race
                        //ke treba na error labelata da mu se napise nesto
                        //ke treba da proveram dali site podatoci se vneseni pa da ide so poraka
                        //ili pak ne e kompletno zavrseno pa da se prodolze od kaj so se prekinal vnesot
                        if ((entryNum == 1) && (statusMess == "OK") && (NextStep == "Entry2") && (item == 5) && RadioButtonList1.SelectedValue.ToString().Equals("1"))
                        {
                            lblError.Visible = true;
                            lblError.Text = LanguageText.p3_resultsentered;
                        }
                        else if ((entryNum == 1) && (statusMess == "OK") && (NextStep == "Entry2") && (item == 5) && RadioButtonList1.SelectedValue.ToString().Equals("2"))
                        {
                            //toa znaci deka se cekla na vtor vnes
                            Session["pscode"] = psnumber;
                            Session["idrace"] = idrace.ToString();
                            Session["kojpat"] = "2";
                            Session["level"] = levelNov;

                            //otkako site sesii se podgotveni da idat dajle treba da opredelime dali ke ode
                            //za vnes kako otvorena lista ili pak vecinski glas
                            //vo zavisnost od tipot na izborot ke se razgranuva na dve strani
                            //ZR_OtvorenaLista.aspx za otvorenite listi i
                            //ZR_VecinskiGlas1.aspx za Vecinski Glas
                            if (idrace == 1 || idrace == 5 || idrace == 8)
                            {
                                Response.Redirect("~/Phase3/Tracking/Results/CCZR_VecinskiGlas1.aspx");
                            }
                            else
                            {
                                Response.Redirect("~/Phase3/Tracking/Results/CCZR_OtvorenaLista1.aspx");
                            }
                        }
                        else if ((entryNum == 2) && (statusMess == "OK") && (NextStep == "Entry3") && (item == 5))
                        {
                            lblError.Visible = true;
                            lblError.Text = LanguageText.p3_AllEntiesEntered;

                        }
                        else
                        {
                            if (entryNum == 1)
                            {
                                Session["kojpat"] = "1";

                                //ako entryNum == 1 && status == "NOTOK" && item = 2 toa znaci deka se raboti za VG
                                //if (idrace == 1 || idrace == 5 || idrace == 8)
                                //{
                                //    Response.Redirect("~/Phase3/ZR_VecinskiGlas1.aspx");
                                //}
                                //i ke treba da ide na taa strana i da i dademe soodvetni parametri
                                Session["pscode"] = psnumber;
                                Session["idrace"] = idrace.ToString();

                                Session["level"] = levelNov;

                                DataSet dsData;
                                dsData = Functions.RESULTSLevelGetNameForCode(Session["level"].ToString(), int.Parse(Session["idrace"].ToString()));
                                Session["raceName"] = dsData.Tables[1].Rows[0][0].ToString();
                                Session["levelName"] = dsData.Tables[0].Rows[0][0].ToString();
                                if ((entryNum == 1) && (statusMess == "NOTOK") && (item == 1))
                                {
                                    if (idrace == 1 || idrace == 5 || idrace == 8)
                                    {
                                        Response.Redirect("~/Phase3/Tracking/Results/CCZR_VecinskiGlas2.aspx");
                                    }
                                    else
                                    {
                                        Response.Redirect("~/Phase3/Tracking/Results/CCZR_OtvorenaLista2.aspx");
                                    }
                                }

                                //ako entryNum == 1 && status == "NOTOK" && item = 3 toa znaci deka se raboti za NM
                                //i ke treba da ide na ZROpenNM.aspx i da i dademe soodvetni parametri
                                if ((entryNum == 1) && (statusMess == "NOTOK") && (item == 3))
                                {
                                    Response.Redirect("~/Phase3/Tracking/Results/CCZROpenNM.aspx");
                                }

                                //ako entryNum == 1 && status == "NOTOK" && item = 4 toa znaci deka se raboti za OL
                                //ako NextStep = 1, znaci deka treba da se vnesuvaat glasovite za partiite
                                //if (idrace == 1 || idrace == 5 || idrace == 8)
                                //{
                                //    Response.Redirect("~/Phase3/ZR_VecinskiGlas1.aspx");
                                //}
                                //i ke treba da ide na taa strana i da i dademe soodvetni parametri
                                //else
                                //{
                                //    Response.Redirect("~/Phase3/ZR_OtvorenaLista1.aspx");
                                //}

                                //ako NextStep = P7 - toa znaci deka treba da se prodolzi so vnes na glasovite za kandidatite za 7mata partija
                                //po red, se razbira tuka ke treba da mu gi dademe site potrebni parametri i sesii.

                                if ((entryNum == 1) && (statusMess == "NOTOK") && (item == 4))
                                {
                                    int odkojapartija = 0;
                                    odkojapartija = int.Parse(NextStep);

                                    DataSet partiesDS = Functions.RESULTSGetPoliticalEntitiesForOLWithVotesForResume(int.Parse(Session["idrace"].ToString()), Session["level"].ToString(), 1, Session["pscode"].ToString());
                                    DataTable parties = partiesDS.Tables[0];
                                    Session["kojapartija"] = odkojapartija.ToString();
                                    Session["kolkuvkupno"] = parties.Rows.Count.ToString();
                                    Session["politicalEntities"] = parties;
                                    Session["idlista"] = parties.Rows[odkojapartija - 1][0].ToString();
                                    Session["listpos"] = parties.Rows[odkojapartija - 1][1].ToString();
                                    Session["PEName"] = parties.Rows[odkojapartija - 1][2].ToString();
                                    Session["votes"] = parties.Rows[odkojapartija - 1][3].ToString();
                                    Response.Redirect("~/Phase3/Tracking/Results/CCZROpenParties.aspx");
                                }
                            }
                            else
                            {
                                Session["kojpat"] = "2";
                                Session["pscode"] = psnumber;
                                Session["idrace"] = idrace.ToString();

                                Session["level"] = levelNov;

                                DataSet dsData;
                                dsData = Functions.RESULTSLevelGetNameForCode(Session["level"].ToString(), int.Parse(Session["idrace"].ToString()));
                                Session["raceName"] = dsData.Tables[1].Rows[0][0].ToString();
                                Session["levelName"] = dsData.Tables[0].Rows[0][0].ToString();
                                if ((entryNum == 2) && (statusMess == "NOTOK") && (item == 1))
                                {
                                    if (idrace == 1 || idrace == 5 || idrace == 8)
                                    {
                                        Response.Redirect("~/Phase3/Tracking/Results/CCZR_VecinskiGlas2.aspx");
                                    }
                                    else
                                    {
                                        Response.Redirect("~/Phase3/Tracking/Results/CCZR_OtvorenaLista2.aspx");
                                    }
                                }

                                //ako entryNum == 1 && status == "NOTOK" && item = 3 toa znaci deka se raboti za NM
                                //i ke treba da ide na ZROpenNM.aspx i da i dademe soodvetni parametri
                                if ((entryNum == 2) && (statusMess == "NOTOK") && (item == 3))
                                {
                                    Response.Redirect("~/Phase3/Tracking/Results/CCZROpenNM.aspx");
                                }

                                //ako entryNum == 1 && status == "NOTOK" && item = 4 toa znaci deka se raboti za OL
                                //ako NextStep = 1, znaci deka treba da se vnesuvaat glasovite za partiite
                                //if (idrace == 1 || idrace == 5 || idrace == 8)
                                //{
                                //    Response.Redirect("~/Phase3/ZR_VecinskiGlas1.aspx");
                                //}
                                //i ke treba da ide na taa strana i da i dademe soodvetni parametri
                                //else
                                //{
                                //    Response.Redirect("~/Phase3/ZR_OtvorenaLista1.aspx");
                                //}

                                //ako NextStep = P7 - toa znaci deka treba da se prodolzi so vnes na glasovite za kandidatite za 7mata partija
                                //po red, se razbira tuka ke treba da mu gi dademe site potrebni parametri i sesii.

                                if ((entryNum == 2) && (statusMess == "NOTOK") && (item == 4))
                                {
                                    int odkojapartija = 0;
                                    odkojapartija = int.Parse(NextStep);

                                    DataSet partiesDS = Functions.RESULTSGetPoliticalEntitiesForOLWithVotesForResume(int.Parse(Session["idrace"].ToString()), Session["level"].ToString(), 2, Session["pscode"].ToString());
                                    DataTable parties = partiesDS.Tables[0];
                                    Session["kojapartija"] = odkojapartija.ToString();
                                    Session["kolkuvkupno"] = parties.Rows.Count.ToString();
                                    Session["politicalEntities"] = parties;
                                    Session["idlista"] = parties.Rows[odkojapartija - 1][0].ToString();
                                    Session["listpos"] = parties.Rows[odkojapartija - 1][1].ToString();
                                    Session["PEName"] = parties.Rows[odkojapartija - 1][2].ToString();
                                    Session["votes"] = parties.Rows[odkojapartija - 1][3].ToString();
                                    Response.Redirect("~/Phase3/Tracking/Results/CCZROpenParties.aspx");
                                }
                            }
                        }
                    }
                }
                else
                {
                    lblError2.Visible = true;
                }
            }
        }

        protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["MECMunicipality"] = DropDownList3.SelectedValue.ToString();
            lblError.Visible = false;
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool temp = Functions.p3_GetPsCodeFromObrazec1(DropDownList1.SelectedItem.Text.ToString());
            bool temp1 = Functions.p3_GetPsCodeFromObrazec(DropDownList1.SelectedItem.Text.ToString());
            if (temp || !temp1)
            {
                //Button3.Visible = true;
                //Label1.Visible = true;
            }
            else
            {
                //Button3.Visible = false;
                //Label1.Visible = false;
            }

            lblError.Visible = false;
            if (temp)
                Session["time"] = 1;
            else
                Session["time"] = 2;
        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblError.Visible = false;
        }

        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblError.Visible = false;
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }



    }
}
