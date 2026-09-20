using System;
using System.Data;
using System.Configuration;
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
using JIIS.DataLayer;
using System.Data.SqlClient;

namespace JIIS.Web.Classes
{
    public class Functions
    {
        public static DataSet Sinchronise_BMunicipalityRegion_p3_NationalityAllocation()
        {
            DataSet ds = new DataSet();
            DBArchive gel = new DBArchive();
            gel.OpenConnection();
            gel.Sinchronise_BMunicipalityRegion_p3_NationalityAllocation();
            gel.CloseConnection();
            return ds;

        }
        public static DataSet SelectCanidacyRaceForID(int ID)
        {
            DataSet ds = new DataSet();
            DBArchive gel = new DBArchive();
            gel.OpenConnection();
            ds = gel.SelectCanidacyRaceForID(ID);
            gel.CloseConnection();
            return ds;

        }

        public static DataSet BGetAllActiveCandidacyRaceForMand()
        {
            DataSet ds = new DataSet();
            DBArchive gel = new DBArchive();
            gel.OpenConnection();
            ds = gel.BGetAllActiveCandidacyRaceForMand();
            gel.CloseConnection();
            return ds;

        }

        

        public static int verification1()
        {
            DBArchive gel = new DBArchive();
            gel.OpenConnection();
            int rowsErrors = gel.verification1();
            gel.CloseConnection();
            return rowsErrors;
        }
        public static int verification2()
        {
            DBArchive gel = new DBArchive();
            gel.OpenConnection();
            int rowsErrors = gel.verification2();
            gel.CloseConnection();
            return rowsErrors;
        }
        public static int verification3()
        {
            DBArchive gel = new DBArchive();
            gel.OpenConnection();
            int rowsErrors = gel.verification3();
            gel.CloseConnection();
            return rowsErrors;
        }
        public static int verification4()
        {
            DBArchive gel = new DBArchive();
            gel.OpenConnection();
            int rowsErrors = gel.verification4();
            gel.CloseConnection();
            return rowsErrors;
        }
        public static int verification5()
        {
            DBArchive gel = new DBArchive();
            gel.OpenConnection();
            int rowsErrors = gel.verification5();
            gel.CloseConnection();
            return rowsErrors;
        }
        public static int verificationComplete()
        {
            DBArchive gel = new DBArchive();
            gel.OpenConnection();
            int rowsErrors = gel.verificationComplete();
            gel.CloseConnection();
            return rowsErrors;
        }
        public static void DeleteCandidate(int id)
        {
            DBArchive gel = new DBArchive();
            gel.OpenConnection();
            gel.DeleteCandidate(id);
            gel.CloseConnection();
        }
        public static void AddCanidacyRace(string CRName, string CRisActive, string CRDate, int NumberMandates)
        {
            DBArchive gel = new DBArchive();
            gel.OpenConnection();
            gel.AddCanidacyRace(CRName, CRisActive, CRDate, NumberMandates);
            gel.CloseConnection();
        }
        public static void ModifyCanidacyRace(int ID, string CRName, string CRisActive, string CRDate, int NumberMandates)
        {
            DBArchive gel = new DBArchive();
            gel.OpenConnection();
            gel.ModifyCanidacyRace(ID, CRName, CRisActive, CRDate, NumberMandates);
            gel.CloseConnection();
        }
        public static void DeleteOrganizationalUnit(int orgUnitId)
        {
            DBArchive dbDeleteOrgUnit = new DBArchive();
            dbDeleteOrgUnit.OpenConnection();
            dbDeleteOrgUnit.DeleteOrganizationalUnit(orgUnitId);
            dbDeleteOrgUnit.CloseConnection();
        }
        public static void DeleteCandidacyRace(int orgUnitId)
        {
            DBArchive dbDeleteOrgUnit = new DBArchive();
            dbDeleteOrgUnit.OpenConnection();
            dbDeleteOrgUnit.DeleteCandidacyRace(orgUnitId);
            dbDeleteOrgUnit.CloseConnection();
        }

        public static void DeleteBatchPSMembers(string BPSNumber, string PSNumber)
        {
            DBArchive dbDeleteOrgUnit = new DBArchive();
            dbDeleteOrgUnit.OpenConnection();
            dbDeleteOrgUnit.DeleteBatchPSMembers(BPSNumber, PSNumber);
            dbDeleteOrgUnit.CloseConnection();
        }
        public static void DeleteNews(int News_ID)
        {
            DBArchive dbDeleteNews = new DBArchive();
            dbDeleteNews.OpenConnection();
            dbDeleteNews.DeleteNews(News_ID);
            dbDeleteNews.CloseConnection();
        }

        public static void UpdateOrganizationalUnit(int orgUnitId, string orgUnitName)
        {
            DBArchive dbDeleteOrgUnit = new DBArchive();
            dbDeleteOrgUnit.OpenConnection();
            dbDeleteOrgUnit.UpdateOrganizationalUnit(orgUnitId, orgUnitName);
            dbDeleteOrgUnit.CloseConnection();
        }
        public static void UpdateNews(int News_ID, string Title, string Tekst, string Todate)
        {
            DBArchive dbUpdateNews = new DBArchive();
            dbUpdateNews.OpenConnection();
            dbUpdateNews.UpdateNews(News_ID, Title, Tekst, Todate);
            dbUpdateNews.CloseConnection();
        }
        public static void DeleteUserNews(int UserIDNews)
        {
           
            DBArchive dbUpdateNews = new DBArchive();
            dbUpdateNews.OpenConnection();
            dbUpdateNews.DeleteUserNews(UserIDNews);
            dbUpdateNews.CloseConnection();
        }
        public static DataSet GetUserNews()
        {
            DBArchive dbNewsName = new DBArchive();
            dbNewsName.OpenConnection();
            DataSet name = dbNewsName.GetUserNews();
            dbNewsName.CloseConnection();
            return name;
        }
        public static DataSet GetAllOrganizationalUnits()
        {
            DBArchive dbNewsName = new DBArchive();
            dbNewsName.OpenConnection();
            DataSet name = dbNewsName.GetAllOrganizationalUnits();
            dbNewsName.CloseConnection();
            return name;
        }
        public static void InsertOrganizationalUnit(string orgUnitName)
        {
            DBArchive dbDeleteOrgUnit = new DBArchive();
            dbDeleteOrgUnit.OpenConnection();
            dbDeleteOrgUnit.InsertOrganizationalUnit(orgUnitName);
            dbDeleteOrgUnit.CloseConnection();
        }
        public static void InsertUserNews(int UserIDNews)
        {
            DBArchive dbDeleteOrgUnit = new DBArchive();
            dbDeleteOrgUnit.OpenConnection();
            dbDeleteOrgUnit.InsertUserNews(UserIDNews);
            dbDeleteOrgUnit.CloseConnection();
        }
        public static void AddNews(string Title, string Tekst, string Todate, int IDUser)
        {
            DBArchive dbAddNews = new DBArchive();
            dbAddNews.OpenConnection();
            dbAddNews.AddNews(Title, Tekst, Todate, IDUser);
            dbAddNews.CloseConnection();
        }
        public static void AddNewsPozicija(int News_ID, int Pozicija)
        {
            DBArchive dbAddNewsPozicija = new DBArchive();
            dbAddNewsPozicija.OpenConnection();
            dbAddNewsPozicija.AddNewsPozicija(News_ID, Pozicija);
            dbAddNewsPozicija.CloseConnection();
        }
        public static void RemoveNewsPozicija(int News_ID, int Pozicija)
        {
            DBArchive dbRemoveNewsPozicija = new DBArchive();
            dbRemoveNewsPozicija.OpenConnection();
            dbRemoveNewsPozicija.RemoveNewsPozicija(News_ID, Pozicija);
            dbRemoveNewsPozicija.CloseConnection();
        }
        public static string GetOrganizationalUnitName(int id)
        {
            DBArchive dbDeleteOrgUnit = new DBArchive();
            dbDeleteOrgUnit.OpenConnection();
            string name = dbDeleteOrgUnit.GetOrganizationalUnitName(id);
            dbDeleteOrgUnit.CloseConnection();
            return name;
        }

        public static string GetNewsName(int News_ID)
        {
            DBArchive dbNewsName = new DBArchive();
            dbNewsName.OpenConnection();
            string name = dbNewsName.GetNewsName(News_ID);
            dbNewsName.CloseConnection();
            return name;
        }
        public static DataSet GetNewsbyID(int News_ID)
        {
            DBArchive dbNewsName = new DBArchive();
            dbNewsName.OpenConnection();
            DataSet name = dbNewsName.GetNewsbyID(News_ID);
            dbNewsName.CloseConnection();
            return name;
        }
        public static string GetNewsTekst(int News_ID)
        {
            DBArchive dbNewsTekst = new DBArchive();
            dbNewsTekst.OpenConnection();
            string tekst = dbNewsTekst.GetNewsTekst(News_ID);
            dbNewsTekst.CloseConnection();
            return tekst;
        }
        public static string GetNewsDate(int News_ID)
        {
            DBArchive dbNewsDate = new DBArchive();
            dbNewsDate.OpenConnection();
            string date = dbNewsDate.GetNewsDate(News_ID);
            dbNewsDate.CloseConnection();
            return date;
        }
        public static DataSet GetUserPriviledges(int User_ID)
        {
            DBArchive dbNewsName = new DBArchive();
            dbNewsName.OpenConnection();
            DataSet name = dbNewsName.GetUserPriviledges(User_ID);
            dbNewsName.CloseConnection();
            return name;
        }
        public static DataSet GetAllUsersforDD()
        {
            DBArchive dbNewsName = new DBArchive();
            dbNewsName.OpenConnection();
            DataSet name = dbNewsName.GetAllUsersforDD();
            dbNewsName.CloseConnection();
            return name;
        }
        public static DataSet GetSysSettings()
        {
            DBArchive dbNewsName = new DBArchive();
            dbNewsName.OpenConnection();
            DataSet name = dbNewsName.GetSysSettings();
            dbNewsName.CloseConnection();
            return name;
        }
        public static void UpdateSysSettings(int SysID, bool Voted, bool SingleEntry, int tolRRFMA1, int tolRRFMA2, int tolRRFMA3, int tolRRFMay1, int tolRRFMay2, int tolRRFMay3, int tolBRFMA, int tolBRFMay, bool isNumbertolRRFMA1, bool isNumbertolRRFMA2, bool isNumbertolRRFMA3, bool isNumbertolRRFMay1, bool isNumbertolRRFMay2, bool isNumbertolRRFMay3, bool isNumbertolBRFMA, bool isNumbertolBRFMay, int ToleranceLevel, bool isProcentFVL)
        {
            DBArchive dbDeleteOrgUnit = new DBArchive();
            dbDeleteOrgUnit.OpenConnection();
            dbDeleteOrgUnit.UpdateSysSettings(SysID, Voted, SingleEntry, tolRRFMA1, tolRRFMA2, tolRRFMA3, tolRRFMay1, tolRRFMay2, tolRRFMay3, tolBRFMA, tolBRFMay, isNumbertolRRFMA1, isNumbertolRRFMA2, isNumbertolRRFMA3, isNumbertolRRFMay1, isNumbertolRRFMay2, isNumbertolRRFMay3, isNumbertolBRFMA, isNumbertolBRFMay, ToleranceLevel, isProcentFVL);
            dbDeleteOrgUnit.CloseConnection();
        }
        public static void InsertUserPriviledges(int User_ID, bool News, bool Archive)
        {
            DBArchive dbAddNewsPozicija = new DBArchive();
            dbAddNewsPozicija.OpenConnection();
            dbAddNewsPozicija.InsertUserPriviledges(User_ID, News, Archive);
            dbAddNewsPozicija.CloseConnection();
        }
        public static void DeleteUserPriviledges(int User_ID)
        {
            DBArchive dbDeleteOrgUnit = new DBArchive();
            dbDeleteOrgUnit.OpenConnection();
            dbDeleteOrgUnit.DeleteUserPriviledges(User_ID);
            dbDeleteOrgUnit.CloseConnection();
        }
        public static void UpdateUsersPriviledges(int User_ID, bool News, bool Archive)
        {
            DBArchive dbDeleteOrgUnit = new DBArchive();
            dbDeleteOrgUnit.OpenConnection();
            dbDeleteOrgUnit.UpdateUsersPriviledges(User_ID, News, Archive);
            dbDeleteOrgUnit.CloseConnection();
        }
        public static int GetLastUser()
        {
            DBArchive dbNewsName = new DBArchive();
            dbNewsName.OpenConnection();
            int name = dbNewsName.GetLastUser();
            dbNewsName.CloseConnection();
            return name;
        }
        public static int GetCRC()
        {
            DBArchive dbNewsName = new DBArchive();
            dbNewsName.OpenConnection();
            int name = dbNewsName.GetCRC();
            dbNewsName.CloseConnection();
            return name;
        }
        public static int checkUserName(string User_Username)
        {
            DBArchive dbNewsName = new DBArchive();
            dbNewsName.OpenConnection();
            int name = dbNewsName.checkUserName(User_Username);
            dbNewsName.CloseConnection();
            return name;
        }
        public static int checkUserName2(string User_Username, string User_Username2)
        {
            DBArchive dbNewsName = new DBArchive();
            dbNewsName.OpenConnection();
            int name = dbNewsName.checkUserName2(User_Username, User_Username2);
            dbNewsName.CloseConnection();
            return name;
        }
        public static int GetTop1OUnit()
        {
            DBArchive dbNewsName = new DBArchive();
            dbNewsName.OpenConnection();
            int name = dbNewsName.GetTop1OUnit();
            dbNewsName.CloseConnection();
            return name;
        }
        public static void updateUserOUS(int userId, int SupervisorID, int OrganizationalUnitID)
        {
            DBUsers dbDeleteOrgUnit = new DBUsers();
            dbDeleteOrgUnit.OpenConnection();
            dbDeleteOrgUnit.updateUserOUS(userId, SupervisorID, OrganizationalUnitID);
            dbDeleteOrgUnit.CloseConnection();
        }
        public static void UpdateSupervisor(int SupervisorID, int ClerkID, int Crc)
        {
            DBArchive dbDeleteOrgUnit = new DBArchive();
            dbDeleteOrgUnit.OpenConnection();
            dbDeleteOrgUnit.UpdateSupervisor(SupervisorID, ClerkID, Crc);
            dbDeleteOrgUnit.CloseConnection();
        }


        public static int GetOrganizationalUnitbyUserID(int User_ID)
        {
            DBArchive dbNewsName = new DBArchive();
            dbNewsName.OpenConnection();
            int name = dbNewsName.GetOrganizationalUnitbyUserID(User_ID);
            dbNewsName.CloseConnection();
            return name;
        }


        //Bosnaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa

        public static DataSet BGetMunicipalityRegionForCandidacyRace(int race)
        {
            DBArchive gel = new DBArchive();
            gel.OpenConnection();
            DataSet name = gel.BGetMunicipalityRegionForCandidacyRace(race);
            gel.CloseConnection();
            return name;
        }

        public static DataSet p4_BGetPoliticalEntityNameForMandates()
        {
            DBArchive gel = new DBArchive();
            gel.OpenConnectionElectionRepository();
            DataSet name = gel.p4_BGetPoliticalEntityNameForMandates();
            gel.CloseConnection();
            return name;
        }

        public static DataSet p4_BGetMunicipalityRegionForMandates()
        {
            DBArchive gel = new DBArchive();
            gel.OpenConnection();
            DataSet name = gel.p4_BGetMunicipalityRegionForMandates();
            gel.CloseConnection();
            return name;
        }

        


        public static DataSet BGetCertifiedPoliticalEntitiesForCandidacyRace(int race, int mureg)
        {
            DBArchive gel = new DBArchive();
            gel.OpenConnection();
            DataSet name = gel.BGetCertifiedPoliticalEntitiesForCandidacyRace(race, mureg);
            gel.CloseConnection();
            return name;
        }

        public static int BGetCertifiedPoliticalEntitiesID(int race, int mureg, int pe)
        {
            DBArchive gel = new DBArchive();
            gel.OpenConnection();
            int name = gel.BGetCertifiedPoliticalEntitiesID(race, mureg, pe);
            gel.CloseConnection();
            return name;
        }


        public static bool BCheckCandidateIfEntry(string name, string surname, string jmb, int certified, string serialnum)
        {
            DBArchive gel = new DBArchive();
            gel.OpenConnection();
            bool name1 = gel.BCheckCandidateIfEntry(name, surname, jmb, certified, serialnum);
            gel.CloseConnection();
            return name1;
        }


        public static void BInsertBCandidatesFirst(string name, string surname, string jmb, int certified,
                            string serialnum, string gender, string address, int fkuser, int registredps)
        {
            DBArchive dbDeleteOrgUnit = new DBArchive();
            dbDeleteOrgUnit.OpenConnection();
            dbDeleteOrgUnit.BInsertBCandidatesFirst(name, surname, jmb, certified, serialnum, gender, address, fkuser, registredps);
            dbDeleteOrgUnit.CloseConnection();
        }
        public static void BInsertBCandidatesExcel(string name, string surname, string nameCyr, string surnameCyr, string jmb, int certified,
                          string serialnum, string gender, string address, string addressCyr, int fkuser, int registredps)
        {
            DBArchive dbDeleteOrgUnit = new DBArchive();
            dbDeleteOrgUnit.OpenConnection();
            dbDeleteOrgUnit.BInsertBCandidatesExcel(name, surname, nameCyr, surnameCyr, jmb, certified, serialnum, gender, address, addressCyr, fkuser, registredps);
            dbDeleteOrgUnit.CloseConnection();
        }

        public static DataSet BGetCandidateDataForEdit(int CID)
        {
            DBArchive gel = new DBArchive();
            gel.OpenConnection();
            DataSet name = gel.BGetCandidateDataForEdit(CID);
            gel.CloseConnection();
            return name;
        }

        public static void BUpdateBCandidates(int idcand, string name, string surname, string jmb, int certified,
                            string serialnum, string gender, string address, int registredps)
        {
            DBArchive dbDeleteOrgUnit = new DBArchive();
            dbDeleteOrgUnit.OpenConnection();
            dbDeleteOrgUnit.BUpdateBCandidates(idcand, name, surname, jmb, certified, serialnum, gender, address, registredps);
            dbDeleteOrgUnit.CloseConnection();
        }

        //////////////////// NIDZZO 28.03.2010 /////////////////////////////

        public static int BInsertCandidateFirstEntry(int FKPoliticalEntity, int ListPos, string Prefix, string Surname, string MiddleName,
            string FirstName, string Suffix, string DateBirth, string PlaceBirth, string JMB, string Address, int FKNationality, string Gender, string ValidDocumentNo,
            string VDNPlace, int isPassport, string ConctactAddress, string Phone, int FKEducation, string FaxNo, string Mail, string SignDate, int CandidateSign,
            int PresidentSign, int Statement, int PropertyStatement, int Obrazac, string StatementPath, string Comment, int FKUser, string DateEntered, string ProtocolNo, string MainInfo, int NatMinority, int Cyrilic, int Minority)
        {
            DBArchive dbDeleteOrgUnit = new DBArchive();
            dbDeleteOrgUnit.OpenConnection();
            int rValue = dbDeleteOrgUnit.BInsertCandidateFirstEntry(FKPoliticalEntity, ListPos, Prefix, Surname, MiddleName,
            FirstName, Suffix, DateBirth, PlaceBirth, JMB, Address, FKNationality, Gender, ValidDocumentNo,
            VDNPlace, isPassport, ConctactAddress, Phone, FKEducation, FaxNo, Mail, SignDate, CandidateSign,
            PresidentSign, Statement, PropertyStatement, Obrazac, StatementPath, Comment, FKUser, DateEntered, ProtocolNo, MainInfo, NatMinority, Cyrilic, Minority);
            dbDeleteOrgUnit.CloseConnection();
            return rValue;
            //return 0;
        }

        public static int BInsertCandidateSecondEntry(int FKPoliticalEntity, int ListPos, string Prefix, string Surname, string MiddleName,
            string FirstName, string Suffix, string DateBirth, string PlaceBirth, string JMB, string Address, int FKNationality, string Gender, string ValidDocumentNo,
            string VDNPlace, int isPassport, string ConctactAddress, string Phone, int FKEducation, string FaxNo, string Mail, string SignDate, int CandidateSign,
            int PresidentSign, int Statement, int PropertyStatement, int Obrazac, string StatementPath, string Comment, int FKUser, string DateEntered, string ProtocolNo, string MainInfo, int NatMinority, int Cyrilic, int Minority)
        {
            DBArchive dbDeleteOrgUnit = new DBArchive();
            dbDeleteOrgUnit.OpenConnection();
            int rValue = dbDeleteOrgUnit.BInsertCandidateSecondEntry(FKPoliticalEntity, ListPos, Prefix, Surname, MiddleName,
            FirstName, Suffix, DateBirth, PlaceBirth, JMB, Address, FKNationality, Gender, ValidDocumentNo,
            VDNPlace, isPassport, ConctactAddress, Phone, FKEducation, FaxNo, Mail, SignDate, CandidateSign,
            PresidentSign, Statement, PropertyStatement, Obrazac, StatementPath, Comment, FKUser, DateEntered, ProtocolNo, MainInfo, NatMinority, Cyrilic, Minority);
            dbDeleteOrgUnit.CloseConnection();
            return rValue;
            //return 0;
        }


        public static DataSet BGetCandidatePersonalInfo(string JMB)
        {
            DBArchive gel = new DBArchive();
            gel.OpenConnection();
            DataSet name = gel.BGetCandidatePersonalInfo(JMB);
            gel.CloseConnection();
            return name;
        }

        public static void BInsertMinority(string Minority)
        {
            DBArchive dbDeleteOrgUnit = new DBArchive();
            dbDeleteOrgUnit.OpenConnection();
            dbDeleteOrgUnit.BInsertMinority(Minority);
            dbDeleteOrgUnit.CloseConnection();
        }

        public static int BGetLevelByID(string Code)
        {
            DBArchive dbNewsName = new DBArchive();
            dbNewsName.OpenConnection();
            int name = dbNewsName.BGetLevelByID(Code);
            dbNewsName.CloseConnection();
            return name;
        }

        public static int BGetPoliticalEntityByID(string NameOnBallot)
        {
            DBArchive dbNewsName = new DBArchive();
            dbNewsName.OpenConnection();
            int name = dbNewsName.BGetPoliticalEntityByID(NameOnBallot);
            dbNewsName.CloseConnection();
            return name;
        }


        public static int BGetCertifiedPoliticalEntity(int polEntity, int munReg)
        {
            DBArchive dbNewsName = new DBArchive();
            dbNewsName.OpenConnection();
            int name = dbNewsName.BGetCertifiedPoliticalEntity(polEntity, munReg);
            dbNewsName.CloseConnection();
            return name;
        }

        public static bool BCheckIfListNumberIsAlreadyEntered1(int lNumber, int certPolParty)
        {
            DBArchive gel = new DBArchive();
            gel.OpenConnection();
            bool name1 = gel.BCheckIfListNumberIsAlreadyEntered1(lNumber, certPolParty);
            gel.CloseConnection();
            return name1;
        }

        public static bool BCheckIfListNumberIsAlreadyEntered2(int lNumber, int certPolParty)
        {
            DBArchive gel = new DBArchive();
            gel.OpenConnection();
            bool name1 = gel.BCheckIfListNumberIsAlreadyEntered2(lNumber, certPolParty);
            gel.CloseConnection();
            return name1;
        }


        //////////////////// SPASOV 30.03.2010 //////////////////////////////////////////////

        public static void DeleteEducation(int orgUnitId)
        {
            DBArchive dbDeleteOrgUnit = new DBArchive();
            dbDeleteOrgUnit.OpenConnection();
            dbDeleteOrgUnit.DeleteEducation(orgUnitId);
            dbDeleteOrgUnit.CloseConnection();
        }
        public static void DeleteElection(int orgUnitId)
        {
            DBArchive dbDeleteOrgUnit = new DBArchive();
            dbDeleteOrgUnit.OpenConnection();
            dbDeleteOrgUnit.DeleteElection(orgUnitId);
            dbDeleteOrgUnit.CloseConnection();
        }

     

        public static void DeleteDeniedVoter(int deniedVoter)
        {
            DBArchive dbDeleteDeniedVoter = new DBArchive();
            dbDeleteDeniedVoter.OpenConnection();
            dbDeleteDeniedVoter.DeleteDeniedVoters(deniedVoter);
            dbDeleteDeniedVoter.CloseConnection();
        }

        public static void DeleteNationality(int orgUnitId)
        {
            DBArchive dbDeleteOrgUnit = new DBArchive();
            dbDeleteOrgUnit.OpenConnection();
            dbDeleteOrgUnit.DeleteNationality(orgUnitId);
            dbDeleteOrgUnit.CloseConnection();
        }

        public static void AddNationality(string orgUnitId)
        {
            DBArchive dbDeleteOrgUnit = new DBArchive();
            dbDeleteOrgUnit.OpenConnection();
            dbDeleteOrgUnit.AddNationality(orgUnitId);
            dbDeleteOrgUnit.CloseConnection();
        }
        public static void AddEducation(string orgUnitId)
        {
            DBArchive dbDeleteOrgUnit = new DBArchive();
            dbDeleteOrgUnit.OpenConnection();
            dbDeleteOrgUnit.AddEducation(orgUnitId);
            dbDeleteOrgUnit.CloseConnection();
        }

        public static void AddIzbori(string code, string nameLatinic, string nameCirilic, string date, string radioButtonIsActive)
        {
            DBArchive dbDeleteOrgUnit = new DBArchive();
            dbDeleteOrgUnit.OpenConnection();
            dbDeleteOrgUnit.AddIzbori(code, nameLatinic, nameCirilic, date, radioButtonIsActive);
            dbDeleteOrgUnit.CloseConnection();
        }

       

        public static void AddShipment(string txtDateReceived, string txtShipmentNumber, string txtTotalShip, string txtTotalOtherPost, string txtComment)
        {
            DBArchive dbDeleteOrgUnit = new DBArchive();
            dbDeleteOrgUnit.OpenConnection();
            dbDeleteOrgUnit.AddShipment(txtDateReceived, txtShipmentNumber, txtTotalShip, txtTotalOtherPost, txtComment);
            dbDeleteOrgUnit.CloseConnection();
        }

        public static void UpdateShipment(int id, string txtDateReceived, string txtShipmentNumber, string txtTotalShip, string txtTotalOtherPost, string txtComment)
        {
            DBArchive dbDeleteOrgUnit = new DBArchive();
            dbDeleteOrgUnit.OpenConnection();
            dbDeleteOrgUnit.UpdateShipment(id, txtDateReceived, txtShipmentNumber, txtTotalShip, txtTotalOtherPost, txtComment);
            dbDeleteOrgUnit.CloseConnection();
        }

        public static void AddDeniedVoter(string JMB, string numberBag, string Reason, string Name, string Surname, int IdBags, int IdReason)
        {
            DBArchive dbDeleteOrgUnit = new DBArchive();
            dbDeleteOrgUnit.OpenConnection();
            dbDeleteOrgUnit.AddDeniedVoter(JMB, numberBag, Reason, Name, Surname, IdBags, IdReason);
            dbDeleteOrgUnit.CloseConnection();
        }

        public static void ModifyNationality(int id, string orgUnitId)
        {
            DBArchive dbDeleteOrgUnit = new DBArchive();
            dbDeleteOrgUnit.OpenConnection();
            dbDeleteOrgUnit.ModifyNationality(id, orgUnitId);
            dbDeleteOrgUnit.CloseConnection();
        }

        public static void ModifyEducation(int id, string orgUnitId)
        {
            DBArchive dbDeleteOrgUnit = new DBArchive();
            dbDeleteOrgUnit.OpenConnection();
            dbDeleteOrgUnit.ModifyEducation(id, orgUnitId);
            dbDeleteOrgUnit.CloseConnection();
        }

        public static void ModifyReason(int id, int lid, string reason)
        {
            DBArchive dbReason = new DBArchive();
            dbReason.OpenConnection();
            dbReason.ModifyReason(id, lid, reason);
            dbReason.CloseConnection();
        }

        public static DataSet SelectNationalityForID(int CID)
        {
            DBArchive gel = new DBArchive();
            gel.OpenConnection();
            DataSet name = gel.SelectNationalityForID(CID);
            gel.CloseConnection();
            return name;
        }
        public static DataSet SelectEducationForID(int CID)
        {
            DBArchive gel = new DBArchive();
            gel.OpenConnection();
            DataSet name = gel.SelectEducationForID(CID);
            gel.CloseConnection();
            return name;
        }
        public static DataSet SelectReasonForID(int ID, int LID)
        {
            DBArchive dbReason = new DBArchive();
            dbReason.OpenConnection();
            DataSet dsReason = dbReason.SelectReasonForID(ID, LID);
            dbReason.CloseConnection();
            return dsReason;
        }
        public static DataSet GetAllFieldControlsForElectionType(int CID)
        {
            DBArchive gel = new DBArchive();
            gel.OpenConnection();
            DataSet name = gel.BGetAllFieldControlsForElectionType(CID);
            gel.CloseConnection();
            return name;
        }
        public static void BUpdateFieldControlsForElectionType(int id, string first, string second)
        {
            DBArchive gel = new DBArchive();
            gel.OpenConnection();
            gel.BUpdateFieldControlsForElectionType(id, first, second);
            gel.CloseConnection();
        }
        public static DataSet p3_getValidationItemsForPSOIK(int race, string pscode)
        {
            DataSet ds = new DataSet();
            DBArchive gel = new DBArchive();
            gel.OpenConnection();
            ds = gel.p3_getValidationItemsForPSOIK(race, pscode);
            gel.CloseConnection();
            return ds;
        }

        public static DataSet p4_getCandDetails(string jmbg, string ElectionCode, string LevelCode, string MunCode)
        {
            DataSet ds = new DataSet();
            DBArchive gel = new DBArchive();
            gel.OpenConnection();
            ds = gel.p4_getCandDetails(jmbg , ElectionCode, LevelCode, MunCode);
            gel.CloseConnection();
            return ds;
        }

        public static DataSet p4_getCandDetailsRegular(string jmbg, string ElectionCode, string LevelCode)
        {
            DataSet ds = new DataSet();
            DBArchive gel = new DBArchive();
            gel.OpenConnectionElectionRepository();
            ds = gel.p4_getCandDetailsRegular(jmbg, ElectionCode, LevelCode);
            gel.CloseConnection();
            return ds;
        }


        public static DataSet SelectAllFromCCListsForID(int id, int param)
        {
            DataSet ds = new DataSet();
            DBArchive gel = new DBArchive();
            gel.OpenConnection();
            ds = gel.SelectAllFromCCListsForID(id, param);
            gel.CloseConnection();
            return ds;
        }


        public static void DeleteLevel(int orgUnitId)
        {
            DBArchive dbDeleteOrgUnit = new DBArchive();
            dbDeleteOrgUnit.OpenConnection();
            dbDeleteOrgUnit.DeleteLevel(orgUnitId);
            dbDeleteOrgUnit.CloseConnection();
        }

        public static void DeleteLevelRelation(int level1, int level2)
        {
            DBArchive dbDeleteOrgUnit = new DBArchive();
            dbDeleteOrgUnit.OpenConnection();
            dbDeleteOrgUnit.DeleteLevelRelation(level1, level2);
            dbDeleteOrgUnit.CloseConnection();
        }

       

        public static DataSet SelectLevelForID(int ID)
        {
            DataSet ds = new DataSet();
            DBArchive gel = new DBArchive();
            gel.OpenConnection();
            ds = gel.SelectLevelForID(ID);
            gel.CloseConnection();
            return ds;

        }

        public static DataSet SelectElectionForID(int id)
        {
            DataSet ds = new DataSet();
            DBArchive gel = new DBArchive();
            gel.OpenConnection();
            ds = gel.SelectElectionForID(id);
            gel.CloseConnection();
            return ds;
        }

       
        //Nedim
        public static DataSet SelectActiveElection()
        {
            DataSet ds = new DataSet();
            DBArchive gel = new DBArchive();
            gel.OpenConnection();
            ds = gel.SelectActiveElection();
            gel.CloseConnection();
            return ds;
        }


        public static DataSet SelectAllFromMandatesForID(int id)
        {
            DataSet ds = new DataSet();
            DBArchive gel = new DBArchive();
            gel.OpenConnectionElectionRepository();
            ds = gel.SelectAllFromMandatesForID(id);
            gel.CloseConnection();
            return ds;
        }

        public static DataSet GetNextMandate(string LevelCode, string PECode, string FKRace, string ElectionCode)
        {
            DataSet ds = new DataSet();
            DBArchive gel = new DBArchive();
            gel.OpenConnectionElectionRepository();
            ds = gel.GetNextMandate(LevelCode, PECode, FKRace, ElectionCode);
            gel.CloseConnection();
            return ds;
        }

        public static DataSet GetNextCMandate(string Region, string PECode, string FKRace, string ElectionCode)
        {
            DataSet ds = new DataSet();
            DBArchive gel = new DBArchive();
            gel.OpenConnection();
            ds = gel.GetNextCMandate(Region, PECode, FKRace, ElectionCode);
            gel.CloseConnection();
            return ds;
        }

        public static DataSet SelectShipmentForID(int id)
        {
            DataSet ds = new DataSet();
            DBArchive gel = new DBArchive();
            gel.OpenConnection();
            ds = gel.SelectShipmentForID(id);
            gel.CloseConnection();
            return ds;
        }

        public static DataSet SelectDeniedVoterForID(int id)
        {
            DataSet ds = new DataSet();
            DBArchive gel = new DBArchive();
            gel.OpenConnection();
            ds = gel.SelectDeniedVoterForID(id);
            gel.CloseConnection();
            return ds;
        }

        public static DataSet SelectDeniedReason(string typePS)
        {
            DataSet ds = new DataSet();
            DBArchive gel = new DBArchive();
            gel.OpenConnection();
            ds = gel.p3_SelectDeniedReason(typePS);
            gel.CloseConnection();
            return ds;
        }

        public static DataSet SelectMenuItemForID(int upid)
        {
            DataSet ds = new DataSet();
            DBArchive gel = new DBArchive();
            gel.OpenConnection();
            ds = gel.SelectMenuItemForID(upid);
            gel.CloseConnection();
            return ds;
        }


        public static void AddLevels(string Code, string Name, int NumberVoters, int NumberPS, int FKRace, int NumberMandates, int minority, int maxcandidates, string script)
        {
            DBArchive gel = new DBArchive();
            gel.OpenConnection();
            gel.AddLevels(Code, Name, NumberVoters, NumberPS, FKRace, NumberMandates, minority, maxcandidates, script);
            gel.CloseConnection();
        }
        public static void ModifyLevels(int id, string Code, string Name, int NumberVoters, int NumberPS, int FKRace, int NumberMandates, int minority, int maxcandidates, string script)
        {
            DBArchive gel = new DBArchive();
            gel.OpenConnection();
            gel.ModifyLevels(id, Code, Name, NumberVoters, NumberPS, FKRace, NumberMandates, minority, maxcandidates, script);
            gel.CloseConnection();
        }

        public static void ModifyIzbori(int id, string Code, string NameLatin, string NameCyrilic, String DatumIzbora, string radioButtonIsActive)
        {
            DBArchive gel = new DBArchive();
            gel.OpenConnection();
            gel.ModifyIzbori(id, Code, NameLatin, NameCyrilic, DatumIzbora, radioButtonIsActive);
            gel.CloseConnection();
        }


        public static void UpdateMandatesImplementation(int id, string chbMandRepl, string chbMandEnd, string chbMandWait, string chbPropertyCardStart, string chbPropertyCard2,
            string txtReplacedWith, string ddlMandReason, string txtDateEndMand, string txtDateStartMand, string txtDatePC1, string txtDatePC2, string chbMandRepC, string chbMandWC)
        {
            DBArchive gel = new DBArchive();
            gel.OpenConnectionElectionRepository();
            gel.UpdateMandatesImplementation(id, chbMandRepl, chbMandEnd, chbMandWait, chbPropertyCardStart, chbPropertyCard2,
             txtReplacedWith, ddlMandReason, txtDateEndMand, txtDateStartMand, txtDatePC1, txtDatePC2, chbMandRepC, chbMandWC);
            gel.CloseConnection();

        }

        public static void UpdateMandatesRace158(int id, string chbMandRepl, string chbMandEnd, string chbMandWait, string chbPropertyCardStart, string chbPropertyCard2,
           string txtReplacedWith, string ddlMandReason, string txtDateEndMand, string txtDateStartMand, string txtDatePC1, string txtDatePC2, string chbMandRepC, 
            string chbMandWC, string ListEnding)
        {
            DBArchive gel = new DBArchive();
            gel.OpenConnection();
            gel.UpdateMandatesRace158(id, chbMandRepl, chbMandEnd, chbMandWait, chbPropertyCardStart, chbPropertyCard2,
             txtReplacedWith, ddlMandReason, txtDateEndMand, txtDateStartMand, txtDatePC1, txtDatePC2, chbMandRepC, chbMandWC, ListEnding);
            gel.CloseConnection();

        }

        public static void InsertMandatesRace1(string ElectionCode,string ElectionName, string Ime,string Prezime,string Gender,string jmbg,string Nationality,string PartyCode2,string Party,string Level,
            string LevelCode, int Race, string txtDateMandStart2, string Adresa,string Telefon,string PropertyCardStart2, string txtDatePC12)
        {
            DBArchive gel = new DBArchive();
            gel.OpenConnection();
            gel.InsertMandatesRace1(ElectionCode, ElectionName, Ime, Prezime, Gender, jmbg, Nationality, PartyCode2, Party, Level, LevelCode, Race, txtDateMandStart2,
                 Adresa, Telefon, PropertyCardStart2, txtDatePC12);
            gel.CloseConnection();

        }


        public static void UpdateListEnding(string ElectionCode,string LevelCode, int Race)
        {
            DBArchive gel = new DBArchive();
            gel.OpenConnection();
            gel.UpdateListEnding(ElectionCode, LevelCode, Race);
            gel.CloseConnection();

        }


        public static int DeleteUsersByType(int UserPositions_ID)
        {
            int error = 0;
            DBArchive gel = new DBArchive();
            gel.OpenConnection();
            error = gel.DeleteUsersByType(UserPositions_ID);
            gel.CloseConnection();
            return error;

        }

        public static void DisableUsersByType(int UserPositions_ID)
        {
            
            DBArchive gel = new DBArchive();
            gel.OpenConnection();
            gel.DisableUsersByType(UserPositions_ID);
            gel.CloseConnection();
           
        }

        public static void EnableUsersByType(int UserPositions_ID)
        {

            DBArchive gel = new DBArchive();
            gel.OpenConnection();
            gel.EnableUsersByType(UserPositions_ID);
            gel.CloseConnection();

        }


        public static void UpdateMandatesImplementation2(int id, string chbMandRepl,string chbMandReplComp, string chbMandEnd, string chbMandWait,string chbMandWaitComp, string chbPropertyCardStart, string chbPropertyCard2,
            string txtReplacedWith, string ddlMandReason, string txtDateEndMand, string txtDateStartMand, string txtDatePC1, string txtDatePC2)
        {
            DBArchive gel = new DBArchive();
            gel.OpenConnection();
            gel.UpdateMandatesImplementation2(id, chbMandRepl, chbMandReplComp, chbMandEnd, chbMandWait, chbMandWaitComp, chbPropertyCardStart, chbPropertyCard2,
             txtReplacedWith, ddlMandReason, txtDateEndMand, txtDateStartMand, txtDatePC1, txtDatePC2);
            gel.CloseConnection();

        }


        public static void UpdateWaitMandates(int id, string chbMandRepl, string chbMandReplComp, string chbMandWait, string chbMandWaitComp, string chbPropertyCardStart, string txtDateStartMand,string txtDatePC1)
        {
            DBArchive gel = new DBArchive();
            gel.OpenConnection();
            gel.UpdateWaitMandates(id, chbMandRepl, chbMandReplComp, chbMandWait, chbMandWaitComp, chbPropertyCardStart, txtDateStartMand, txtDatePC1);
            gel.CloseConnection();

        }

        public static void UpdateCCMandatesImplementation(int id, string txtListForMunCouncil, string txtListPositionForMunCouncil, string txtChoosenForMunCouncil,
             string txtMandEndForMunCouncil, string txtReplaceMandForMunCouncil, string txtDateMandEndForMunCouncil, string txtDateStartForMunCouncil)
        {
            DBArchive gel = new DBArchive();
            gel.OpenConnection();
            gel.UpdateCCMandatesImplementation(id,  txtListForMunCouncil,  txtListPositionForMunCouncil,  txtChoosenForMunCouncil,
              txtMandEndForMunCouncil,  txtReplaceMandForMunCouncil,  txtDateMandEndForMunCouncil,  txtDateStartForMunCouncil);
            gel.CloseConnection();

        }

        public static void InsertintoMandatesCityCouncil(string txtCityCouncilCode, string txtCityCouncilName)
        {
            DBArchive gel = new DBArchive();
            gel.OpenConnection();
            gel.InsertintoMandatesCityCouncil(txtCityCouncilCode, txtCityCouncilName);
            gel.CloseConnection();

        }


        public static void InsertIntoMandatesImplementationbyRaceLevel(string levelcode, string fkrace, string txtDateMandStart, string electioncode, string ElectionName)
        {
            DBArchive gel = new DBArchive();
            gel.OpenConnection();
            gel.InsertIntoMandatesImplementationbyRaceLevel(levelcode, fkrace, txtDateMandStart, electioncode, ElectionName);
            gel.CloseConnection();

        }


        public static void ModifyDeniedVoter(int id, string JMB, string numberBags, string Reason, string Name, string Surname)
        {
            DBArchive gel = new DBArchive();
            gel.OpenConnection();
            gel.ModifyDeniedVoter(id, JMB, numberBags, Reason, Name, Surname);
            gel.CloseConnection();
        }

        public static void InsertLevelRelation(string level1, string level2, string lname1, string lname2)
        {
            DBArchive dbDeleteOrgUnit = new DBArchive();
            dbDeleteOrgUnit.OpenConnection();
            dbDeleteOrgUnit.InsertLevelRelation(level1, level2, lname1, lname2);
            dbDeleteOrgUnit.CloseConnection();
        }

        public static DataSet BGetMismatchesForPoliticalEntity(int PolEntity)
        {
            DBArchive gel = new DBArchive();
            gel.OpenConnection();
            DataSet name = gel.BGetMismatchesForPoliticalEntity(PolEntity);
            gel.CloseConnection();
            return name;
        }

        public static DataSet SelectMandatesAllocationForID(int CID)
        {
            DBArchive gel = new DBArchive();
            gel.OpenConnection();
            DataSet name = gel.SelectMandatesAllocationForID(CID);
            gel.CloseConnection();
            return name;
        }

        public static void AddMandatesAllocation(int total, int min)
        {
            DBArchive dbDeleteOrgUnit = new DBArchive();
            dbDeleteOrgUnit.OpenConnection();
            dbDeleteOrgUnit.AddMandatesAllocation(total, min);
            dbDeleteOrgUnit.CloseConnection();
        }

        public static void ModifyMandatesAllocation(int ID, int min)
        {
            DBArchive dbDeleteOrgUnit = new DBArchive();
            dbDeleteOrgUnit.OpenConnection();
            dbDeleteOrgUnit.ModifyMandatesAllocation(ID, min);
            dbDeleteOrgUnit.CloseConnection();
        }

        public static void DeleteMandatesAllocation(int orgUnitId)
        {
            DBArchive dbDeleteOrgUnit = new DBArchive();
            dbDeleteOrgUnit.OpenConnection();
            dbDeleteOrgUnit.DeleteMandatesAllocation(orgUnitId);
            dbDeleteOrgUnit.CloseConnection();
        }

        public static DataSet BGetMismatchesForElection(int CandRace)
        {
            DBArchive gel = new DBArchive();
            gel.OpenConnection();
            DataSet name = gel.BGetMismatchesForElection(CandRace);
            gel.CloseConnection();
            return name;
        }

        public static DataSet BGetAllActiveLevelsForCandidacyRace()
        {
            DBArchive gel = new DBArchive();
            gel.OpenConnection();
            DataSet name = gel.BGetAllActiveLevelsForCandidacyRace();
            gel.CloseConnection();
            return name;
        }

        public static DataSet BGetAllActiveDistinctMunicipality()
        {
            DBArchive gel = new DBArchive();
            gel.OpenConnection();
            DataSet name = gel.BGetAllActiveDistinctMunicipality();
            gel.CloseConnection();
            return name;
        }
        public static DataSet BGetStatisticsForUser(int user)
        {
            DBArchive gel = new DBArchive();
            gel.OpenConnection();
            DataSet name = gel.BGetStatisticsForUser(user);
            gel.CloseConnection();
            return name;
        }
        public static DataSet BGetStatisticsForUser2(int user)
        {
            DBArchive gel = new DBArchive();
            gel.OpenConnection();
            DataSet name = gel.BGetStatisticsForUser2(user);
            gel.CloseConnection();
            return name;
        }
        public static DataSet BGetStatisticsForUserRecent2(int user)
        {
            DBArchive gel = new DBArchive();
            gel.OpenConnection();
            DataSet name = gel.BGetStatisticsForUserRecent2(user);
            gel.CloseConnection();
            return name;
        }
        public static DataSet BGetStatisticsForUserRecent(int user)
        {
            DBArchive gel = new DBArchive();
            gel.OpenConnection();
            DataSet name = gel.BGetStatisticsForUserRecent(user);
            gel.CloseConnection();
            return name;
        }
        public static DataSet BCreateUserPrivileges()
        {
            DBArchive gel = new DBArchive();
            gel.OpenConnection();
            DataSet name = gel.BCreateUserPrivileges();
            gel.CloseConnection();
            return name;
        }
        public static void UpdateUserPrivileges(int uid, string privilege)
        {
            DBArchive gel = new DBArchive();
            gel.OpenConnection();
            gel.UpdateUserPrivileges(uid, privilege);
            gel.CloseConnection();
        }

        public static DataSet BGetMismatchesForPoliticalEntityByID(int ID)
        {
            DBArchive gel = new DBArchive();
            gel.OpenConnection();
            DataSet name = gel.BGetMismatchesForPoliticalEntityByID(ID);
            gel.CloseConnection();
            return name;
        }

        public static int BGetRaceIDfromBMunicipalityRegion(string Code)
        {
            DBArchive dbNewsName = new DBArchive();
            dbNewsName.OpenConnection();
            int name = dbNewsName.BGetRaceIDfromBMunicipalityRegion(Code);
            dbNewsName.CloseConnection();
            return name;
        }
        public static void BGetCertifiedPoliticalEntityWithNull(int polEntity, int munReg, int param, int race)
        {
            DBArchive gel = new DBArchive();
            gel.OpenConnection();
            gel.BGetCertifiedPoliticalEntityWithNull(polEntity, munReg, param, race);
            gel.CloseConnection();

        }
        public static void BGetCertifiedPoliticalEntityUnlockWithNull(int polEntity, int munReg, int param)
        {
            DBArchive gel = new DBArchive();
            gel.OpenConnection();
            gel.BGetCertifiedPoliticalEntityUnlockWithNull(polEntity, munReg, param);
            gel.CloseConnection();

        }
        public static DataSet BGetAllPreFinalCandidates(int cerPolEnt)
        {
            DBArchive cand = new DBArchive();
            cand.OpenConnection();
            DataSet dsCand = cand.BGetAllPreFinalCandidates(cerPolEnt);
            cand.CloseConnection();
            return dsCand;
        }

        public static int BGetRaceIDfromCertifiedPoliticalEntities(string certPolEnt)
        {
            DBArchive dbNewsName = new DBArchive();
            dbNewsName.OpenConnection();
            int name = dbNewsName.BGetRaceIDfromCertifiedPoliticalEntities(certPolEnt);
            dbNewsName.CloseConnection();
            return name;
        }

        public static void BUpdatePFCandidatesListPosition(int id, int lid)
        {
            DBArchive dbCand = new DBArchive();
            dbCand.OpenConnection();
            dbCand.BUpdatePFCandidatesListPosition(id, lid);
            dbCand.CloseConnection();
        }

        public static void UpdateCCCandidatesListPosition(string jmbg, int lid)
        {
            DBArchive dbCand = new DBArchive();
            dbCand.OpenConnection();
            dbCand.UpdateCCCandidatesListPosition(jmbg, lid);
            dbCand.CloseConnection();
        }

        public static void SetPositionOneLevelUp(int id, int id2, int lid, int lid2)
        {
            BUpdatePFCandidatesListPosition(id, lid2);
            BUpdatePFCandidatesListPosition(id2, lid);
        }

        public static void SetPositionOneLevelUp(string id, string id2, int lid, int lid2)
        {
            UpdateCCCandidatesListPosition(id, lid2);
            UpdateCCCandidatesListPosition(id2, lid);

        }

        public static void SetPositionOneLevelDown(int id, int id2, int lid, int lid2)
        {
            BUpdatePFCandidatesListPosition(id, lid2);
            BUpdatePFCandidatesListPosition(id2, lid);
        }

        public static void SetPositionOneLevelDown(string id, string id2, int lid, int lid2)
        {
            UpdateCCCandidatesListPosition(id, lid2);
            UpdateCCCandidatesListPosition(id2, lid);
        }


        public static DataSet ProccCountCandidateListsForParametar(int level, int pe, int param)
        {
            DBArchive cand = new DBArchive();
            cand.OpenConnection();
            DataSet dsCand = cand.ProccCountCandidateListsForParametar(level, pe, param);
            cand.CloseConnection();
            return dsCand;
        }

        public static int BGetIDofNationality(string nationalityName)
        {
            DBArchive gel = new DBArchive();
            gel.OpenConnection();
            int rowsErrors = gel.BGetIDofNationality(nationalityName);
            gel.CloseConnection();
            return rowsErrors;
        }
        public static int BGetIDofEducation(string EducationName)
        {
            DBArchive gel = new DBArchive();
            gel.OpenConnection();
            int rowsErrors = gel.BGetIDofEducation(EducationName);
            gel.CloseConnection();
            return rowsErrors;
        }

        public static string BGetEducationFromID(int id)
        {
            DBArchive dbDeleteOrgUnit = new DBArchive();
            dbDeleteOrgUnit.OpenConnection();
            string name = dbDeleteOrgUnit.BGetEducationFromID(id);
            dbDeleteOrgUnit.CloseConnection();
            return name;
        }

        public static string BGetNationalityFromID(int id)
        {
            DBArchive dbNewsName = new DBArchive();
            dbNewsName.OpenConnection();
            string name = dbNewsName.BGetNationalityFromID(id);
            dbNewsName.CloseConnection();
            return name;
        }

        public static int BInsertCandidatePreFinal(int FKPoliticalEntity, int ListPos, string Prefix, string Surname, string MiddleName,
            string FirstName, string Suffix, string DateBirth, string PlaceBirth, string JMB, string Address, int FKNationality, string Gender, string ValidDocumentNo,
            string VDNPlace, int isPassport, string ConctactAddress, string Phone, int FKEducation, string FaxNo, string Mail, string SignDate, int CandidateSign,
            int PresidentSign, int Statement,int PropertyStatement, int obrazac, string StatementPath, string Comment, int FKUser, string DateEntered, string ProtocolNo, string MainInfo, int NatMinority, int Cyrilic, int Minority)
        {
            DBArchive dbDeleteOrgUnit = new DBArchive();
            dbDeleteOrgUnit.OpenConnection();
            int rValue = dbDeleteOrgUnit.BInsertCandidatePreFinal(FKPoliticalEntity, ListPos, Prefix, Surname, MiddleName,
            FirstName, Suffix, DateBirth, PlaceBirth, JMB, Address, FKNationality, Gender, ValidDocumentNo,
            VDNPlace, isPassport, ConctactAddress, Phone, FKEducation, FaxNo, Mail, SignDate, CandidateSign,
            PresidentSign, Statement, PropertyStatement, obrazac, StatementPath, Comment, FKUser, DateEntered, ProtocolNo, MainInfo, NatMinority, Cyrilic, Minority);
            dbDeleteOrgUnit.CloseConnection();
            return rValue;
        }


        public static void ProccStep1Complete(int level, int pe, int param)
        {
            DBArchive cand = new DBArchive();
            cand.OpenConnection();
            cand.ProccStep1Complete(level, pe, param);
            cand.CloseConnection();
        }

        public static int verificationStep1_1()
        {
            DBArchive cand = new DBArchive();
            cand.OpenConnection();
            int dsCand = cand.verificationStep1_1();
            cand.CloseConnection();
            return dsCand;
        }

        public static int verificationStep1_2(int level)
        {
            DBArchive cand = new DBArchive();
            cand.OpenConnection();
            int dsCand = cand.verificationStep1_2(level);
            cand.CloseConnection();
            return dsCand;
        }

        public static int verificationStep1_3(int politicalEntity)
        {
            DBArchive cand = new DBArchive();
            cand.OpenConnection();
            int dsCand = cand.verificationStep1_3(politicalEntity);
            cand.CloseConnection();
            return dsCand;
        }
        public static int verificationStep1_4(int level, int politicalEntity)
        {
            DBArchive cand = new DBArchive();
            cand.OpenConnection();
            int dsCand = cand.verificationStep1_4(level, politicalEntity);
            cand.CloseConnection();
            return dsCand;
        }
        public static int verificationStep2_1()
        {
            //string textB;
            //string textH;
            //string textS;
            //string textE;

            DBArchive cand = new DBArchive();
            cand.OpenConnection();
            int dsCand = cand.verificationStep2_1();
            //textB = dsCand.Tables[1].Rows[0][0].ToString();
            //textH = dsCand.Tables[1].Rows[3][0].ToString();
            //textS = dsCand.Tables[1].Rows[2][0].ToString();
            //textE = dsCand.Tables[1].Rows[1][0].ToString();
            //if (dsCand.Tables[0].Rows.Count > 0)
            //{
            //    foreach (DataRow tr in dsCand.Tables[0].Rows)
            //    {
            //        cand.verificationAddComment(int.Parse(tr[0].ToString()), textB + " " + tr[1].ToString(), textS + " " + tr[1].ToString(), textH + " " + tr[1].ToString(), textE + " " + tr[1].ToString());
            //    }
            //}
            cand.CloseConnection();

            return dsCand;
        }
        public static int verificationStep2_2(int level)
        {
            //string textB;
            //string textH;
            //string textS;
            //string textE;

            DBArchive cand = new DBArchive();
            cand.OpenConnection();
            int dsCand = cand.verificationStep2_2(level);

            //textB = dsCand.Tables[1].Rows[0][0].ToString();
            //textH = dsCand.Tables[1].Rows[3][0].ToString();
            //textS = dsCand.Tables[1].Rows[2][0].ToString();
            //textE = dsCand.Tables[1].Rows[1][0].ToString();
            //if (dsCand.Tables[0].Rows.Count > 0)
            //{
            //    foreach (DataRow tr in dsCand.Tables[0].Rows)
            //    {
            //        cand.verificationAddComment(int.Parse(tr[0].ToString()), textB + " " + tr[1].ToString(), textS + " " + tr[1].ToString(), textH + " " + tr[1].ToString(), textE + " " + tr[1].ToString());
            //    }
            //}
            cand.CloseConnection();
            return dsCand;
        }
        public static int verificationStep2_3(int politicalEntity)
        {
            //string textB;
            //string textH;
            //string textS;
            //string textE;

            DBArchive cand = new DBArchive();
            cand.OpenConnection();
            int dsCand = cand.verificationStep2_3(politicalEntity);
            //textB = dsCand.Tables[1].Rows[0][0].ToString();
            //textH = dsCand.Tables[1].Rows[3][0].ToString();
            //textS = dsCand.Tables[1].Rows[2][0].ToString();
            //textE = dsCand.Tables[1].Rows[1][0].ToString();
            //if (dsCand.Tables[0].Rows.Count > 0)
            //{
            //    foreach (DataRow tr in dsCand.Tables[0].Rows)
            //    {
            //        cand.verificationAddComment(int.Parse(tr[0].ToString()), textB + " " + tr[1].ToString(), textS + " " + tr[1].ToString(), textH + " " + tr[1].ToString(), textE + " " + tr[1].ToString());
            //    }
            //}
            cand.CloseConnection();

            return dsCand;
        }
        public static int verificationStep2_4(int level, int politicalEntity)
        {
            //string textB;
            //string textH;
            //string textS;
            //string textE;

            DBArchive cand = new DBArchive();
            cand.OpenConnection();
            int dsCand = cand.verificationStep2_4(level, politicalEntity);
            //textB = dsCand.Tables[1].Rows[0][0].ToString();
            //textH = dsCand.Tables[1].Rows[3][0].ToString();
            //textS = dsCand.Tables[1].Rows[2][0].ToString();
            //textE = dsCand.Tables[1].Rows[1][0].ToString();
            //if (dsCand.Tables[0].Rows.Count > 0)
            //{
            //    foreach (DataRow tr in dsCand.Tables[0].Rows)
            //    {
            //        cand.verificationAddComment(int.Parse(tr[0].ToString()), textB + " " + tr[1].ToString(), textS + " " + tr[1].ToString(), textH + " " + tr[1].ToString(), textE + " " + tr[1].ToString());
            //    }
            //}
            cand.CloseConnection();
            return dsCand;
        }

        public static DataSet ProccStep2Start(int level, int pe, int param)
        {
            DBArchive cand = new DBArchive();
            cand.OpenConnection();
            DataSet dsCand = cand.ProccStep2Start(level, pe, param);
            cand.CloseConnection();
            return dsCand;
        }

        public static void BInsertLogs(int uid, string action, string page, DateTime dtime, string ipadress)
        {
            DBArchive dbLogs = new DBArchive();
            dbLogs.OpenConnection();
            dbLogs.BInsertLogs(uid, action, page, dtime, ipadress);
            dbLogs.CloseConnection();
        }
        public static void BDeleteFinalAll()
        {
            DBArchive dbLogs = new DBArchive();
            dbLogs.OpenConnection();
            dbLogs.BDeleteFinalAll();
            dbLogs.CloseConnection();
        }
        public static void BUpdateCorrectedMismatches(int id)
        {
            DBArchive dbLogs = new DBArchive();
            dbLogs.OpenConnection();
            dbLogs.BUpdateCorrectedMismatches(id);
            dbLogs.CloseConnection();
        }

        public static DataSet ProccGetMandatesAllocation()
        {
            DBArchive cand = new DBArchive();
            cand.OpenConnection();
            DataSet dsCand = cand.ProccGetMandatesAllocation();
            cand.CloseConnection();
            return dsCand;
        }
        public static int verificationStep3_1()
        {
            //string textB;
            //string textH;
            //string textS;
            //string textE;

            DBArchive cand = new DBArchive();
            cand.OpenConnection();
            int br = cand.verificationStep3_1();
            //textB = dsCand.Tables[1].Rows[0][0].ToString();
            //textH = dsCand.Tables[1].Rows[3][0].ToString();
            //textS = dsCand.Tables[1].Rows[2][0].ToString();
            //textE = dsCand.Tables[1].Rows[1][0].ToString();
            //if (dsCand.Tables[0].Rows.Count > 0)
            //{
            //    foreach (DataRow tr in dsCand.Tables[0].Rows)
            //    {
            //        cand.verificationAddComment(int.Parse(tr[0].ToString()), textB + " " + tr[1].ToString(), textS + " " + tr[1].ToString(), textH + " " + tr[1].ToString(), textE + " " + tr[1].ToString());
            //    }
            //}
            cand.CloseConnection();
            return br;
            //int.Parse(dsCand.Tables[2].Rows[0][0].ToString());
        }
        public static int verificationStep3_2(int level)
        {
            //string textB;
            //string textH;
            //string textS;
            //string textE;

            DBArchive cand = new DBArchive();
            cand.OpenConnection();
            //  DataSet dsCand = 
            int br = cand.verificationStep3_2(level);
            //textB = dsCand.Tables[1].Rows[0][0].ToString();
            //textH = dsCand.Tables[1].Rows[3][0].ToString();
            //textS = dsCand.Tables[1].Rows[2][0].ToString();
            //textE = dsCand.Tables[1].Rows[1][0].ToString();
            //if (dsCand.Tables[0].Rows.Count > 0)
            //{
            //    foreach (DataRow tr in dsCand.Tables[0].Rows)
            //    {
            //        cand.verificationAddComment(int.Parse(tr[0].ToString()), textB + " " + tr[1].ToString(), textS + " " + tr[1].ToString(), textH + " " + tr[1].ToString(), textE + " " + tr[1].ToString());
            //    }
            //}
            cand.CloseConnection();
            return br;
        }
        public static int verificationStep3_3(int politicalEntity)
        {
            //string textB;
            //string textH;
            //string textS;
            //string textE;

            DBArchive cand = new DBArchive();
            cand.OpenConnection();
            int br = cand.verificationStep3_3(politicalEntity);
            //textB = dsCand.Tables[1].Rows[0][0].ToString();
            //textH = dsCand.Tables[1].Rows[3][0].ToString();
            //textS = dsCand.Tables[1].Rows[2][0].ToString();
            //textE = dsCand.Tables[1].Rows[1][0].ToString();
            //if (dsCand.Tables[0].Rows.Count > 0)
            //{
            //    foreach (DataRow tr in dsCand.Tables[0].Rows)
            //    {
            //        cand.verificationAddComment(int.Parse(tr[0].ToString()), textB + " " + tr[1].ToString(), textS + " " + tr[1].ToString(), textH + " " + tr[1].ToString(), textE + " " + tr[1].ToString());
            //    }
            //}
            cand.CloseConnection();
            return br;
            //int.Parse(dsCand.Tables[2].Rows[0][0].ToString());
        }
        public static int verificationStep3_4(int level, int politicalEntity)
        {
            //string textB;
            //string textH;
            //string textS;
            //string textE;

            DBArchive cand = new DBArchive();
            cand.OpenConnection();
            int br = cand.verificationStep3_4(level, politicalEntity);
            //textB = dsCand.Tables[1].Rows[0][0].ToString();
            //textH = dsCand.Tables[1].Rows[3][0].ToString();
            //textS = dsCand.Tables[1].Rows[2][0].ToString();
            //textE = dsCand.Tables[1].Rows[1][0].ToString();
            //if (dsCand.Tables[0].Rows.Count > 0)
            //{
            //    foreach (DataRow tr in dsCand.Tables[0].Rows)
            //    {
            //        cand.verificationAddComment(int.Parse(tr[0].ToString()), textB + " " + tr[1].ToString(), textS + " " + tr[1].ToString(), textH + " " + tr[1].ToString(), textE + " " + tr[1].ToString());
            //    }
            //}
            cand.CloseConnection();
            return br;
        }

        public static int verificationStep5_1()
        {
            DBArchive cand = new DBArchive();
            cand.OpenConnection();
            int dsCand = cand.verificationStep5_1();
            cand.CloseConnection();
            return dsCand;
        }

        public static int verificationStep5_2(int level)
        {
            DBArchive cand = new DBArchive();
            cand.OpenConnection();
            int dsCand = cand.verificationStep5_2(level);
            cand.CloseConnection();
            return dsCand;
        }

        public static int verificationStep5_3(int politicalEntity)
        {
            DBArchive cand = new DBArchive();
            cand.OpenConnection();
            int dsCand = cand.verificationStep5_3(politicalEntity);
            cand.CloseConnection();
            return dsCand;
        }
        public static int verificationStep5_4(int level, int politicalEntity)
        {
            DBArchive cand = new DBArchive();
            cand.OpenConnection();
            int dsCand = cand.verificationStep5_4(level, politicalEntity);
            cand.CloseConnection();
            return dsCand;
        }
        public static int verificationStep4_1()
        {
            DBArchive cand = new DBArchive();
            cand.OpenConnection();
            int dsCand = cand.verificationStep4_1();
            cand.CloseConnection();
            return dsCand;
        }

        public static int verificationStep4_2(int level)
        {
            DBArchive cand = new DBArchive();
            cand.OpenConnection();
            int dsCand = cand.verificationStep4_2(level);
            cand.CloseConnection();
            return dsCand;
        }

        public static int verificationStep4_3(int politicalEntity)
        {
            DBArchive cand = new DBArchive();
            cand.OpenConnection();
            int dsCand = cand.verificationStep4_3(politicalEntity);
            cand.CloseConnection();
            return dsCand;
        }
        public static int verificationStep4_4(int level, int politicalEntity)
        {
            DBArchive cand = new DBArchive();
            cand.OpenConnection();
            int dsCand = cand.verificationStep4_4(level, politicalEntity);
            cand.CloseConnection();
            return dsCand;
        }

        public static int bCountAllForVerification1()
        {
            DBArchive cand = new DBArchive();
            cand.OpenConnection();
            int dsCand = cand.bCountAllForVerification1();
            cand.CloseConnection();
            return dsCand;
        }

        public static int bCountAllForVerification2(int level)
        {
            DBArchive cand = new DBArchive();
            cand.OpenConnection();
            int dsCand = cand.bCountAllForVerification2(level);
            cand.CloseConnection();
            return dsCand;
        }

        public static int bCountAllForVerification3(int politicalEntity)
        {
            DBArchive cand = new DBArchive();
            cand.OpenConnection();
            int dsCand = cand.bCountAllForVerification3(politicalEntity);
            cand.CloseConnection();
            return dsCand;
        }
        public static int bCountAllForVerification4(int level, int politicalEntity)
        {
            DBArchive cand = new DBArchive();
            cand.OpenConnection();
            int dsCand = cand.bCountAllForVerification4(level, politicalEntity);
            cand.CloseConnection();
            return dsCand;
        }

        public static int BCompareSecondCandidateEntry(int FKPoliticalEntity, int ListPos, string Prefix, string Surname, string MiddleName, string FirstName, string Suffix, string JMB)
        {
            DBArchive gel = new DBArchive();
            gel.OpenConnection();
            int rowsErrors = gel.BCompareSecondCandidateEntry(FKPoliticalEntity, ListPos, Prefix, Surname, MiddleName, FirstName, Suffix, JMB);
            gel.CloseConnection();
            return rowsErrors;
        }

        public static void ProccStep2UpdateList(int idlist, int errorpos)
        {
            DBArchive dbLogs = new DBArchive();
            dbLogs.OpenConnection();
            dbLogs.ProccStep2UpdateList(idlist, errorpos);
            dbLogs.CloseConnection();
        }
        public static void BGetFinalize(int idcr, int idpe, int idmr, int param)
        {
            DBArchive dbCand = new DBArchive();
            dbCand.OpenConnection();
            dbCand.BGetFinalize(idcr, idpe, idmr, param);
            dbCand.CloseConnection();
        }
        public static void BDeleteFinal(int param1, int param2, int param3)
        {
            DBArchive dbLogs = new DBArchive();
            dbLogs.OpenConnection();
            dbLogs.BDeleteFinal(param1, param2, param3);
            dbLogs.CloseConnection();
        }

        public static void bVerificationFinalize1()
        {
            DBArchive cand = new DBArchive();
            cand.OpenConnection();
            cand.bVerificationFinalize1();
            cand.CloseConnection();

        }

        public static void bVerificationFinalize2(int level)
        {
            DBArchive cand = new DBArchive();
            cand.OpenConnection();
            cand.bVerificationFinalize2(level);
            cand.CloseConnection();

        }

        public static void bVerificationFinalize3(int politicalEntity)
        {
            DBArchive cand = new DBArchive();
            cand.OpenConnection();
            cand.bVerificationFinalize3(politicalEntity);
            cand.CloseConnection();

        }
        public static void bVerificationFinalize4(int level, int politicalEntity)
        {
            DBArchive cand = new DBArchive();
            cand.OpenConnection();
            cand.bVerificationFinalize4(level, politicalEntity);
            cand.CloseConnection();

        }

        public static void BInsertCorrectToCandidatesPreFinal(int id)
        {
            DBArchive cand = new DBArchive();
            cand.OpenConnection();
            cand.BInsertCorrectToCandidatesPreFinal(id);
            cand.CloseConnection();

        }

        /// NIDZZO 13.04.2010 /////////////////////////////////////////

        public static string BGetPoliticalEntityName(int ID)
        {
            DBArchive dbDeleteOrgUnit = new DBArchive();
            dbDeleteOrgUnit.OpenConnection();
            string name = dbDeleteOrgUnit.BGetPoliticalEntityName(ID);
            dbDeleteOrgUnit.CloseConnection();
            return name;
        }

        public static string BGetLevelByName(int ID)
        {
            DBArchive dbDeleteOrgUnit = new DBArchive();
            dbDeleteOrgUnit.OpenConnection();
            string name = dbDeleteOrgUnit.BGetLevelByName(ID);
            dbDeleteOrgUnit.CloseConnection();
            return name;
        }

        public static int ProccStep1Complete1(int level, int pe, int param)
        {
            DBArchive cand = new DBArchive();
            cand.OpenConnection();
            int rows = cand.ProccStep1Complete1(level, pe, param);
            cand.CloseConnection();
            return rows;
        }

        public static void DeleteMinority(int orgUnitId)
        {
            DBArchive dbDeleteOrgUnit = new DBArchive();
            dbDeleteOrgUnit.OpenConnection();
            dbDeleteOrgUnit.DeleteMinority(orgUnitId);
            dbDeleteOrgUnit.CloseConnection();
        }

        public static DataSet SelectMinorityForID(int ID)
        {
            DBArchive dbDeleteOrgUnit = new DBArchive();
            dbDeleteOrgUnit.OpenConnection();
            DataSet name = dbDeleteOrgUnit.SelectMinorityForID(ID);
            dbDeleteOrgUnit.CloseConnection();
            return name;
        }
        public static void AddMinority(string name)
        {
            DBArchive dbDeleteOrgUnit = new DBArchive();
            dbDeleteOrgUnit.OpenConnection();
            dbDeleteOrgUnit.AddMinority(name);
            dbDeleteOrgUnit.CloseConnection();
        }
        public static void ModifyMinority(int ID, string name)
        {
            DBArchive dbDeleteOrgUnit = new DBArchive();
            dbDeleteOrgUnit.OpenConnection();
            dbDeleteOrgUnit.ModifyMinority(ID, name);
            dbDeleteOrgUnit.CloseConnection();
        }

        public static DataSet GetMinoritiesByCandidacyRace(int ID)
        {
            DBArchive dbDeleteOrgUnit = new DBArchive();
            dbDeleteOrgUnit.OpenConnection();
            DataSet name = dbDeleteOrgUnit.GetMinoritiesByCandidacyRace(ID);
            dbDeleteOrgUnit.CloseConnection();
            return name;
        }

        public static DataSet GetMandatesByCandidacyRace(int ID)
        {
            DBArchive dbDeleteOrgUnit = new DBArchive();
            dbDeleteOrgUnit.OpenConnection();
            DataSet name = dbDeleteOrgUnit.GetMandatesByCandidacyRace(ID);
            dbDeleteOrgUnit.CloseConnection();
            return name;
        }

        public static void updateMinorities(int ID, string hasMin, int numMin)
        {
            DBArchive dbDeleteOrgUnit = new DBArchive();
            dbDeleteOrgUnit.OpenConnection();
            dbDeleteOrgUnit.updateMinorities(ID, hasMin, numMin);
            dbDeleteOrgUnit.CloseConnection();
        }
        //updateMandates
        public static void updateMandates(int ID, int numMin, int maxNum)
        {
            DBArchive dbDeleteOrgUnit = new DBArchive();
            dbDeleteOrgUnit.OpenConnection();
            dbDeleteOrgUnit.updateMandates(ID, numMin, maxNum);
            dbDeleteOrgUnit.CloseConnection();
        }
        public static int ImportCountForImport()
        {
            DBArchive cand = new DBArchive();
            cand.OpenConnection();
            int rows = cand.ImportCountForImport();
            cand.CloseConnection();
            return rows;
        }

        public static void ImportDataFromIzbori2010()
        {
            DBArchive dbDeleteOrgUnit = new DBArchive();
            dbDeleteOrgUnit.OpenConnection();
            dbDeleteOrgUnit.ImportDataFromIzbori2010();
            dbDeleteOrgUnit.CloseConnection();
        }

        public static void ImportDataIntoBVoteDB()
        {
            DBArchive dbDeleteOrgUnit = new DBArchive();
            dbDeleteOrgUnit.OpenConnection();
            dbDeleteOrgUnit.ImportDataIntoBVoteDB();
            dbDeleteOrgUnit.CloseConnection();
        }

        public static DataSet M11GetTitlesForType(int type, int langu)
        {
            DBArchive dbDeleteOrgUnit = new DBArchive();
            dbDeleteOrgUnit.OpenConnection();
            DataSet name = dbDeleteOrgUnit.M11GetTitlesForType(type, langu);
            dbDeleteOrgUnit.CloseConnection();
            return name;
        }
        public static void M11UpdateTitlesForType(int type, int langu, string head, string foot)
        {
            DBArchive dbDeleteOrgUnit = new DBArchive();
            dbDeleteOrgUnit.OpenConnection();
            dbDeleteOrgUnit.M11UpdateTitlesForType(type, langu, head, foot);
            dbDeleteOrgUnit.CloseConnection();
        }
        public static DataSet M11GetTitlesForTypeM11D(int type, int langu)
        {
            DBArchive dbDeleteOrgUnit = new DBArchive();
            dbDeleteOrgUnit.OpenConnection();
            DataSet name = dbDeleteOrgUnit.M11GetTitlesForTypeM11D(type, langu);
            dbDeleteOrgUnit.CloseConnection();
            return name;
        }
        public static DataSet M11GetTitlesForTypeM11E(int type, int langu)
        {
            DBArchive dbDeleteOrgUnit = new DBArchive();
            dbDeleteOrgUnit.OpenConnection();
            DataSet name = dbDeleteOrgUnit.M11GetTitlesForTypeM11E(type, langu);
            dbDeleteOrgUnit.CloseConnection();
            return name;
        }


        public static void M11UpdateTitlesForTypeM11D(int type, int langu, string Head, string Odluku,
            string obrazlozenje, string PravnaOdluka, string FooterLeft, string FooterRight)
        {
            DBArchive dbDeleteOrgUnit = new DBArchive();
            dbDeleteOrgUnit.OpenConnection();
            dbDeleteOrgUnit.M11UpdateTitlesForTypeM11D(type, langu, Head, Odluku, obrazlozenje, PravnaOdluka, FooterLeft, FooterRight);
            dbDeleteOrgUnit.CloseConnection();
        }


        public static void M11UpdateTitlesForTypeM11E(int type, int langu, string Head, string Odluku,
            string obrazlozenje, string PravnaOdluka, string FooterLeft, string FooterRight)
        {
            DBArchive dbDeleteOrgUnit = new DBArchive();
            dbDeleteOrgUnit.OpenConnection();
            dbDeleteOrgUnit.M11UpdateTitlesForTypeM11E(type, langu, Head, Odluku, obrazlozenje, PravnaOdluka, FooterLeft, FooterRight);
            dbDeleteOrgUnit.CloseConnection();
        }
        public static void ImportVoter()
        {
            DBArchive dbDeleteOrgUnit = new DBArchive();
            dbDeleteOrgUnit.OpenConnection();
            dbDeleteOrgUnit.ImportVoter();
            dbDeleteOrgUnit.CloseConnection();
        }

        public static string BGetCertifiedPoliticalEntityName(int ID)
        {
            DBArchive dbNewsName = new DBArchive();
            dbNewsName.OpenConnection();
            string name = dbNewsName.BGetCertifiedPoliticalEntityName(ID);
            dbNewsName.CloseConnection();
            return name;
        }

        public static void BDeleteCanidateFromBCandidates1(int id)
        {
            DBArchive dbDeleteOrgUnit = new DBArchive();
            dbDeleteOrgUnit.OpenConnection();
            dbDeleteOrgUnit.BDeleteCanidateFromBCandidates1(id);
            dbDeleteOrgUnit.CloseConnection();
        }

        public static void BDeleteCanidateFromBCandidates2(int id, string jmb)
        {
            DBArchive dbDeleteOrgUnit = new DBArchive();
            dbDeleteOrgUnit.OpenConnection();
            dbDeleteOrgUnit.BDeleteCanidateFromBCandidates2(id, jmb);
            dbDeleteOrgUnit.CloseConnection();
        }

        public static bool BCheckIfJMBIsAlreadyEntered1(string JMB, int certPolParty)
        {
            DBArchive gel = new DBArchive();
            gel.OpenConnection();
            bool name1 = gel.BCheckIfJMBIsAlreadyEntered1(JMB, certPolParty);
            gel.CloseConnection();
            return name1;
        }

        public static bool BCheckIfJMBIsAlreadyEntered2(string JMB, int certPolParty)
        {
            DBArchive gel = new DBArchive();
            gel.OpenConnection();
            bool name1 = gel.BCheckIfJMBIsAlreadyEntered2(JMB, certPolParty);
            gel.CloseConnection();
            return name1;
        }

        public static void BUpdateMismatchByUpdatedSecondEntry(string JMB, int certPolParty)
        {
            DBArchive dbLogs = new DBArchive();
            dbLogs.OpenConnection();
            dbLogs.BUpdateMismatchByUpdatedSecondEntry(JMB, certPolParty);
            dbLogs.CloseConnection();
        }

        // NIDZZO 30.04.2010 /////////////////////////////////////////////

        public static DataSet BGetCertifiedPoliticalEntityDataByID(int id)
        {
            DBArchive dbDeleteOrgUnit = new DBArchive();
            dbDeleteOrgUnit.OpenConnection();
            DataSet name = dbDeleteOrgUnit.BGetCertifiedPoliticalEntityDataByID(id);
            dbDeleteOrgUnit.CloseConnection();
            return name;
        }


        // NIDZZO 05.05.2010 ////////////////////////////////////////////////////////

        public static DataSet BGetCandidateFromBCandidate1byJMB(string JMB, int certPolEnt)
        {
            DBArchive dbDeleteOrgUnit = new DBArchive();
            dbDeleteOrgUnit.OpenConnection();
            DataSet name = dbDeleteOrgUnit.BGetCandidateFromBCandidate1byJMB(JMB, certPolEnt);
            dbDeleteOrgUnit.CloseConnection();
            return name;
        }

        public static void BDeleteCanidateFromBCandidates2afterUpdate(string jmb)
        {
            DBArchive dbDeleteOrgUnit = new DBArchive();
            dbDeleteOrgUnit.OpenConnection();
            dbDeleteOrgUnit.BDeleteCanidateFromBCandidates2afterUpdate(jmb);
            dbDeleteOrgUnit.CloseConnection();
        }

        public static void BUpdateCorrectedMismatchesToFalseAfterUpdateSecondEntry(string jmb)
        {
            DBArchive dbLogs = new DBArchive();
            dbLogs.OpenConnection();
            dbLogs.BUpdateCorrectedMismatchesToFalseAfterUpdateSecondEntry(jmb);
            dbLogs.CloseConnection();
        }
        /// PHASE 2
        public static DataSet BGetAllActiveLevelsForCandidacyRace1(int crid)
        {
            DBArchive dbCR = new DBArchive();
            dbCR.OpenConnection();
            DataSet dsCR = dbCR.BGetAllActiveLevelsForCandidacyRace1(crid);
            dbCR.CloseConnection();
            return dsCR;
        }
        public static DataSet getLabelText(string type, int race, string label, string latin)
        {
            DBArchive dbCR = new DBArchive();
            dbCR.OpenConnection();
            DataSet dsCR = dbCR.getLabelText(type, race, label, latin);
            dbCR.CloseConnection();
            return dsCR;
        }

        public static void updateLabelText(string type, int race, string label, string latin, string description)
        {
            DBArchive dbCR = new DBArchive();
            dbCR.OpenConnection();
            dbCR.updateLabelText(type, race, label, latin, description);
            dbCR.CloseConnection();

        }


        //getBallotsText
        public static DataSet getBallotsText(string type, int race, string label, string latin)
        {
            DBArchive dbCR = new DBArchive();
            dbCR.OpenConnection();
            DataSet dsCR = dbCR.getBallotsText(type, race, label, latin);
            dbCR.CloseConnection();
            return dsCR;
        }
        //UpdateTypesOfBallotData

        public static void updateBallotText(string type, int race, string label, string latin, string description)
        {
            DBArchive dbCR = new DBArchive();
            dbCR.OpenConnection();
            dbCR.updateBallotText(type, race, label, latin, description);
            dbCR.CloseConnection();

        }
        public static DataSet GetLevelDataByScript(int id, string script)
        {
            DBArchive dbCR = new DBArchive();
            dbCR.OpenConnection();
            DataSet dsCR = dbCR.GetLevelDataByScript(id, script);
            dbCR.CloseConnection();
            return dsCR;
        }

        public static DataSet P2GetCandidacyRaceCyrilic(int type)
        {
            DBArchive dbCR = new DBArchive();
            dbCR.OpenConnection();
            DataSet dsCR = dbCR.P2GetCandidacyRaceCyrilic(type);
            dbCR.CloseConnection();
            return dsCR;
        }
        public static DataSet P2GetFieldsTemplate(int type)
        {
            DBArchive dbCR = new DBArchive();
            dbCR.OpenConnection();
            DataSet dsCR = dbCR.P2GetFieldsTemplate(type);
            dbCR.CloseConnection();
            return dsCR;
        }

        public static int LevelHasNM(string code)
        {
            DBArchive cand = new DBArchive();
            cand.OpenConnection();
            int rows = cand.LevelHasNM(code);
            cand.CloseConnection();
            return rows;
        }

        public static DataSet P2_SelectBallotsParameter(string type, int number)
        {
            DBArchive dbCR = new DBArchive();
            dbCR.OpenConnection();
            DataSet dsCR = dbCR.P2_SelectBallotsParameter(type, number);
            dbCR.CloseConnection();
            return dsCR;
        }


        public static DataSet p2_CountBallotsCandidate(int race, int level)
        {
            DBArchive dbCR = new DBArchive();
            dbCR.OpenConnection();
            DataSet dsCR = dbCR.p2_CountBallotsCandidate(race, level);
            dbCR.CloseConnection();
            return dsCR;
        }


        public static DataSet M12GetAllLevelsForGenerating()
        {
            DBArchive dbCR = new DBArchive();
            dbCR.OpenConnection();
            DataSet dsCR = dbCR.M12GetAllLevelsForGenerating();
            dbCR.CloseConnection();
            return dsCR;
        }


        public static DataSet M12GetAllLevelsForGeneratingVG()
        {
            DBArchive dbCR = new DBArchive();
            dbCR.OpenConnection();
            DataSet dsCR = dbCR.M12GetAllLevelsForGeneratingVG();
            dbCR.CloseConnection();
            return dsCR;
        }

        public static DataSet BGetAllActiveLevelsForCandidacyRace1New(int crid)
        {
            DBArchive dbCR = new DBArchive();
            dbCR.OpenConnection();
            DataSet dsCR = dbCR.BGetAllActiveLevelsForCandidacyRace1New(crid);
            dbCR.CloseConnection();
            return dsCR;
        }
        public static DataSet BGetCompensationListCandidatesGenderForValidation(string Region, string party)
        {
            DBArchive dbCR = new DBArchive();
            dbCR.OpenConnection();
            DataSet dsCR = dbCR.BGetCompensationListCandidatesGenderForValidation(Region, party);
            dbCR.CloseConnection();
            return dsCR;
        }


        public static void BGetCompensationListUPDATE(string Region, string party, int brojce)
        {
            DBArchive gel = new DBArchive();
            gel.OpenConnection();
            gel.BGetCompensationListUPDATE(Region, party, brojce);
            gel.CloseConnection();
        }

        public static DataSet BGetFinalizeListCandidates(string level, string pname, int race)
        {
            DBArchive dbCR = new DBArchive();
            dbCR.OpenConnection();
            DataSet dsCR = dbCR.BGetFinalizeListCandidates(level, pname, race);
            dbCR.CloseConnection();
            return dsCR;
        }

        public static void BCopyCandidatesFinishedFirstRound()
        {
            DBArchive gel = new DBArchive();
            gel.OpenConnection();
            gel.BCopyCandidatesFinishedFirstRound();
            gel.CloseConnection();
        }

        //brisenje na bazata
        public static void DeleteAll()
        {
            DBArchive gel = new DBArchive();
            gel.OpenConnection();
            gel.DeleteAll();
            gel.CloseConnection();
        }

        //Delete all candidates
        public static void DeleteAllCandidates()
        {
            try
            {
                DBArchive gel = new DBArchive();
                gel.OpenConnection();
                gel.DeleteAllCandidates();
                gel.CloseConnection();
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public static string BGetMinorityFromID(int id)
        {
            DBArchive dbNewsName = new DBArchive();
            dbNewsName.OpenConnection();
            string name = dbNewsName.BGetMinorityFromID(id);
            dbNewsName.CloseConnection();
            return name;
        }

        public static int BGetMinorityFromName(string Name)
        {
            DBArchive dbNewsName = new DBArchive();
            dbNewsName.OpenConnection();
            int name1 = dbNewsName.BGetMinorityFromName(Name);
            dbNewsName.CloseConnection();
            return name1;
        }
        public static DataSet p3_Turnout_GetDataFromTurnoutSettings()
        {
            DBArchive dbCR = new DBArchive();
            dbCR.OpenConnection();
            DataSet dsCR = dbCR.p3_Turnout_GetDataFromTurnoutSettings();
            dbCR.CloseConnection();
            return dsCR;
        }
        //Aleksandra 25.05.2010
        public static void p3BUpdateTurnoutSettings(string FirstTime, string SecondTime, string ThirdTime)
        {
            DBArchive dbDeleteOrgUnit = new DBArchive();
            dbDeleteOrgUnit.OpenConnection();
            dbDeleteOrgUnit.p3BUpdateTurnoutSettings(FirstTime, SecondTime, ThirdTime);
            dbDeleteOrgUnit.CloseConnection();
        }

        public static DataSet p3BSelectTurnoutSettings()
        {

            DBArchive dbCR = new DBArchive();
            dbCR.OpenConnection();
            DataSet dsCR = dbCR.p3BSelectTurnoutSettings();
            dbCR.CloseConnection();
            return dsCR;
        }

        public static DataSet p3_Turnout_GetTotalVotersForPS(int idps)
        {
            DBArchive dbCR = new DBArchive();
            dbCR.OpenConnection();
            DataSet dsCR = dbCR.p3_Turnout_GetTotalVotersForPS(idps);
            dbCR.CloseConnection();
            return dsCR;
        }

        public static void p3_Turnout_Insert(int fkps, string codeps, string muncode, bool open, int first,
           double firstperc, int second, double secondperc, int third, double thirdperc, bool closed)
        {
            DBArchive gel = new DBArchive();
            gel.OpenConnection();
            gel.p3_Turnout_Insert(fkps, codeps, muncode, open, first, firstperc, second, secondperc, third, thirdperc, closed);
            gel.CloseConnection();
        }

        public static DataSet BGetMunRegionDataForUserID(int user)
        {
            DBArchive dbCR = new DBArchive();
            dbCR.OpenConnection();
            DataSet dsCR = dbCR.BGetMunRegionDataForUserID(user);
            dbCR.CloseConnection();
            return dsCR;
        }
        public static string BGetMunRegionDataFormunCode(string munCode)
        {
            DBArchive dbCR = new DBArchive();
            dbCR.OpenConnection();
            string munName = dbCR.BGetMunRegionDataForMunCode(munCode);
            dbCR.CloseConnection();
            return munName;
        }
        public static void BInsertMunRegionDataForUserID(int user, string code)
        {
            DBArchive dbCR = new DBArchive();
            dbCR.OpenConnection();
            dbCR.BInsertMunRegionDataForUserID(user, code);
            dbCR.CloseConnection();
        }

        public static void BUpdateMunRegionDataForUserID(int user, string code)
        {
            DBArchive dbCR = new DBArchive();
            dbCR.OpenConnection();
            dbCR.BUpdateMunRegionDataForUserID(user, code);
            dbCR.CloseConnection();
        }

        public static void BDeleteMunRegionDataForUserID(int user)
        {
            DBArchive dbCR = new DBArchive();
            dbCR.OpenConnection();
            dbCR.BDeleteMunRegionDataForUserID(user);
            dbCR.CloseConnection();
        }




        public static void p3_InsertMessages(string msg, int userFrom, int userTo)
        {
            DBArchive dbCR = new DBArchive();
            dbCR.OpenConnection();
            dbCR.p3_InsertMessages(msg, userFrom, userTo);
            dbCR.CloseConnection();
        }

        public static string p3_PreviewMessage(int id)
        {
            DBArchive dbCR = new DBArchive();
            dbCR.OpenConnection();
            string dsCR = dbCR.p3_PreviewMessage(id);
            dbCR.CloseConnection();
            return dsCR;
        }

        public static DataSet p3_Turnout_GetCountTime(string pscode)
        {
            DBArchive dbCR = new DBArchive();
            dbCR.OpenConnection();
            DataSet dsCR = dbCR.p3_Turnout_GetCountTime(pscode);
            dbCR.CloseConnection();
            return dsCR;
        }

        public static DataSet p3_UnconfirmedTurnout_GetCountTime(string munCode)
        {
            DBArchive dbCR = new DBArchive();
            dbCR.OpenConnection();
            DataSet dsCR = dbCR.p3_UnconfirmedTurnout_GetCountTime(munCode);
            dbCR.CloseConnection();
            return dsCR;
        }

        public static void p3_Turnout_UpdateForTime(int param, string pscode, int turnout, string perc)
        {
            DBArchive dbCR = new DBArchive();
            dbCR.OpenConnection();
            dbCR.p3_Turnout_UpdateForTime(param, pscode, turnout, perc);
            dbCR.CloseConnection();
        }
        public static void p3_TurnoutUnConfirmed_UpdateForTime(int param, string munCode, int turnout)
        {
            DBArchive dbCR = new DBArchive();
            dbCR.OpenConnection();
            dbCR.p3_TurnoutUnConfirmed_UpdateForTime(param, munCode, turnout);
            dbCR.CloseConnection();

        }

        public static void p3_UpdateMessage(int id)
        {
            DBArchive dbCR = new DBArchive();
            dbCR.OpenConnection();
            dbCR.p3_UpdateMessage(id);
            dbCR.CloseConnection();
        }

        public static void p3_UpdateCloseStation(string CodePS)
        {
            DBArchive dbCR = new DBArchive();
            dbCR.OpenConnection();
            dbCR.p3_UpdateCloseStation(CodePS);
            dbCR.CloseConnection();
        }
        public static void p3_UpdateCloseStation(string CodePS, string commentClose, string closingTime, bool closed)
        {
            DBArchive dbCR = new DBArchive();
            dbCR.OpenConnection();
            dbCR.p3_UpdateCloseStation(CodePS, commentClose, closingTime, closed);
            dbCR.CloseConnection();
        }


        public static void p3_UpdateResultsEntry(int user, int allow, string code)
        {
            DBArchive dbCR = new DBArchive();
            dbCR.OpenConnection();
            dbCR.p3_UpdateResultsEntry(user, allow, code);
            dbCR.CloseConnection();
        }

        public static bool p3_Results_CheckIfUserCanEnter(int iduser)
        {
            DBArchive gel = new DBArchive();
            gel.OpenConnection();
            bool name1 = gel.p3_Results_CheckIfUserCanEnter(iduser);
            gel.CloseConnection();
            return name1;
        }


        public static string p3_getlevelsMecUsersSELECT(int iduser)
        {
            DBArchive gel = new DBArchive();
            gel.OpenConnection();
            string name1 = gel.p3_getlevelsMecUsersSELECT(iduser);
            gel.CloseConnection();
            return name1;
        }
        public static DataSet p3_Results_CheckIfPSReadyForEntry(string PSNumber, int FKCandidacyRace)
        {
            DBArchive gel = new DBArchive();
            gel.OpenConnection();
            DataSet status = gel.p3_Results_CheckIfPSReadyForEntry(PSNumber, FKCandidacyRace);
            gel.CloseConnection();
            return status;
        }

        public static string p3_Results_GetLevelCodeForMunicipalityAndRace(int idrace, string muncode)
        {
            DBArchive gel = new DBArchive();
            gel.OpenConnection();
            string status = gel.p3_Results_GetLevelCodeForMunicipalityAndRace(idrace, muncode);
            gel.CloseConnection();
            return status;
        }

        public static int p3_ActivatePSforScanning(string psCode)
        {
            DBArchive gel = new DBArchive();
            gel.OpenConnection();
            int status = gel.p3_ActivatePSforScanning(psCode);
            gel.CloseConnection();
            return status;
        }

        public static int p3_ActivateBagforScanning(string psCode)
        {
            DBArchive gel = new DBArchive();
            gel.OpenConnection();
            int status = gel.p3_ActivateBagforScanning(psCode);
            gel.CloseConnection();
            return status;
        }
        public static void p3_FinalizePSforScanning(string psCode, int accepted)
        {
            DBArchive gel = new DBArchive();
            gel.OpenConnection();
            gel.p3_FinalizePSforScanning(psCode, accepted);
            gel.CloseConnection();

        }

        public static void p3_FinalizeBagforScanning(string psCode, int accepted)
        {
            DBArchive gel = new DBArchive();
            gel.OpenConnection();
            gel.p3_FinalizeBagforScanning(psCode, accepted);
            gel.CloseConnection();

        }

        public static void p3_EditOpenStation(int FKPS, int TurnOutFirst, int TurnOutSecond, int TurnOutThird, string TurnOutFirstPerc, string TurnOutSecondPerc, string TurnOutThirdPerc)
        {
            DBArchive dbDeleteOrgUnit = new DBArchive();
            dbDeleteOrgUnit.OpenConnection();
            dbDeleteOrgUnit.p3_EditOpenStation(FKPS, TurnOutFirst, TurnOutSecond, TurnOutThird, TurnOutFirstPerc, TurnOutSecondPerc, TurnOutThirdPerc);
            dbDeleteOrgUnit.CloseConnection();
        }


        public static DataSet RESULTSLevelGetNameForCode(string Code, int idrace)
        {
            DBArchive dbCR = new DBArchive();
            dbCR.OpenConnection();
            DataSet dsCR = dbCR.RESULTSLevelGetNameForCode(Code, idrace);
            dbCR.CloseConnection();
            return dsCR;
        }

        public static void RESULTS_InsertIntoPSStatistic(string PSCode, string LevelCode, int FKRace,
                int EntryNumber, int FKUser, int TotalVotersInCVR1, int NumberBallotsInBox2,
                int InvalidUnMarkBallotsA, int InvalidOthersBallotsB, int TotalInvalidBallotsC,
                int TotalValidVotesD1, int TotalValidVotesNMD2, int TotalValidVotesD,
                int TotalAllBallotsE, int AccuracyTest23, int AccuracyTest3F)
        {
            DBArchive dbDeleteOrgUnit = new DBArchive();
            dbDeleteOrgUnit.OpenConnection();
            dbDeleteOrgUnit.RESULTS_InsertIntoPSStatistic(PSCode, LevelCode, FKRace,
                EntryNumber, FKUser, TotalVotersInCVR1, NumberBallotsInBox2,
                InvalidUnMarkBallotsA, InvalidOthersBallotsB, TotalInvalidBallotsC,
                TotalValidVotesD1, TotalValidVotesNMD2, TotalValidVotesD,
                TotalAllBallotsE, AccuracyTest23, AccuracyTest3F);
            dbDeleteOrgUnit.CloseConnection();
        }
        public static DataSet p3getPSStatistic(string pscode, string level, int race)
        {
            DBArchive dbCR = new DBArchive();
            dbCR.OpenConnection();
            DataSet dsCR = dbCR.p3getPSStatistic(pscode, level, race);
            dbCR.CloseConnection();
            return dsCR;
        }

        public static DataSet RESULTSGetPoliticalEntitiesForOL(int fkRace, string levelCode)
        {
            DBArchive dbCR = new DBArchive();
            dbCR.OpenConnection();
            DataSet dsCR = dbCR.RESULTSGetPoliticalEntitiesForOL(fkRace, levelCode);
            dbCR.CloseConnection();
            return dsCR;
        }

        public static void p3_InsertTrackingArea(string nameBos, string nameEng, string nameSer, string nameCro)
        {
            DBArchive dbCR = new DBArchive();
            dbCR.OpenConnection();
            dbCR.p3_InsertTrackingArea(nameBos, nameEng, nameSer, nameCro);
            dbCR.CloseConnection();
        }

        public static void p3_InsertMaterialsData(string nameBos, string nameEng, string nameSer, string nameCro)
        {
            DBArchive dbCR = new DBArchive();
            dbCR.OpenConnection();
            dbCR.p3_InsertMaterialsData(nameBos, nameEng, nameSer, nameCro);
            dbCR.CloseConnection();
        }

        public static void p3_UpdateMaterialsData(string nameBos, string nameEng, string nameSer, string nameCro, int id)
        {
            DBArchive dbCR = new DBArchive();
            dbCR.OpenConnection();
            dbCR.p3_UpdateMaterialsData(nameBos, nameEng, nameSer, nameCro, id);
            dbCR.CloseConnection();
        }

        public static void p3_UpdateTrackingArea(string nameBos, string nameEng, string nameSer, string nameCro, int id)
        {
            DBArchive dbCR = new DBArchive();
            dbCR.OpenConnection();
            dbCR.p3_UpdateTrackingArea(nameBos, nameEng, nameSer, nameCro, id);
            dbCR.CloseConnection();
        }

        public static void p3_DeleteTrackingArea(int id)
        {
            DBArchive dbCR = new DBArchive();
            dbCR.OpenConnection();
            dbCR.p3_DeleteTrackingArea(id);
            dbCR.CloseConnection();
        }

        public static void p3_DeleteMaterialsData(int id)
        {
            DBArchive dbCR = new DBArchive();
            dbCR.OpenConnection();
            dbCR.p3_DeleteMaterialsData(id);
            dbCR.CloseConnection();
        }

        public static DataSet p3_getMaterialsDataData(int id)
        {
            DBArchive dbCR = new DBArchive();
            dbCR.OpenConnection();
            DataSet ds = dbCR.p3_getMaterialsDataData(id);
            dbCR.CloseConnection();
            return ds;
        }

        public static DataSet p3_getTrackingAreaData(int id)
        {
            DBArchive dbCR = new DBArchive();
            dbCR.OpenConnection();
            DataSet ds = dbCR.p3_getTrackingAreaData(id);
            dbCR.CloseConnection();
            return ds;
        }

        public static void RESULTS_InsertIntoZRMayority(string PSCode, string LevelCode,
                int FKRace, int EntryNumber, int ListNumber, int PEorCandidate, int Votes, int FKUser)
        {
            DBArchive dbCR = new DBArchive();
            dbCR.OpenConnection();
            dbCR.RESULTS_InsertIntoZRMayority(PSCode, LevelCode,
                FKRace, EntryNumber, ListNumber, PEorCandidate, Votes, FKUser);
            dbCR.CloseConnection();
        }
        //Nedim
        public static void RESULTS_UpdateZRMayority(string PSCode, string LevelCode,
               int FKRace, int ListNumber, int PEorCandidate, int Votes, int FKUser, int decisionID)
        {
            DBArchive dbCR = new DBArchive();
            dbCR.OpenConnection();
            dbCR.RESULTS_UpdateZRMayority(PSCode, LevelCode,
                FKRace, ListNumber, PEorCandidate, Votes, FKUser, decisionID);
            dbCR.CloseConnection();
        }

        public static void p3_InsertTrackingRelation(int matid, int from, int to)
        {
            DBArchive dbCR = new DBArchive();
            dbCR.OpenConnection();
            dbCR.p3_InsertTrackingRelation(matid, from, to);
            dbCR.CloseConnection();
        }

        public static void p3_DeleteTrackingRelation(int id)
        {
            DBArchive dbCR = new DBArchive();
            dbCR.OpenConnection();
            dbCR.p3_DeleteTrackingRelation(id);
            dbCR.CloseConnection();
        }
       // public static DataSet p3_ScanVoter(string jmb, int accepted, int clerk, string psBag, bool suspicious, string document)
        
        public static DataSet p3_ScanVoter(string jmb, int accepted, int clerk, string psBag, bool suspicious)
        {
            DBArchive dbCR = new DBArchive();
            dbCR.OpenConnection();
            //DataSet ds = dbCR.p3_ScanVoter(jmb, accepted, clerk, psBag, suspicious, document);//KENAN
            DataSet ds = dbCR.p3_ScanVoter(jmb, accepted, clerk, psBag, suspicious);
            dbCR.CloseConnection();
            return ds;
        }
        //KENAN 3.3.2016

        public static void p3_UpdatePoolingStationDocumentData(string psCode, string documentName)
        {
            DBArchive dbCR = new DBArchive();
            dbCR.OpenConnection();
            dbCR.p3_UpdatePoolingStationDocumentData(psCode, documentName);
            dbCR.CloseConnection();            
        }

        public static DataSet GetPoolingStationData(string psCode)
        {
            DBArchive dbCR = new DBArchive();
            dbCR.OpenConnection();
            DataSet ds = dbCR.GetPoolingStationData(psCode);
            dbCR.CloseConnection();
            return ds;
        }

        public static void p3_UpdatePoolingStationData(string psCode, int total, int notValid)
        {
            DBArchive dbCR = new DBArchive();
            dbCR.OpenConnection();
            dbCR.p3_UpdatePoolingStationData(psCode, total,notValid);
            dbCR.CloseConnection();
        }

        public static void RESULTS_InsertIntoZROpenList(string PSCode, string LevelCode,
               int FKRace, int EntryNumber, int ListPositionCandidate, int FKFinalCandidateList,
               int FKCandidate, int Votes, int FKUser)
        {
            DBArchive dbCR = new DBArchive();
            dbCR.OpenConnection();
            dbCR.RESULTS_InsertIntoZROpenList(PSCode, LevelCode,
               FKRace, EntryNumber, ListPositionCandidate, FKFinalCandidateList,
               FKCandidate, Votes, FKUser);
            dbCR.CloseConnection();
        }

        public static void UpdateCityCouncilListsByVotes(int ListID, int Votes, int FKUser)
        {
            DBArchive dbCR = new DBArchive();
            dbCR.OpenConnection();
            dbCR.UpdateCityCouncilListsByVotes(ListID, Votes, FKUser);
            dbCR.CloseConnection();
        }


        //Nedim
        public static void RESULTS_UpdateZROpenList(string PSCode, string LevelCode,
               int FKRace, int ListPositionCandidate, int FKFinalCandidateList,
               int FKCandidate, int Votes, int FKUser,int decisionID)
        {
            DBArchive dbCR = new DBArchive();
            dbCR.OpenConnection();
            dbCR.RESULTS_UpdateZROpenList(PSCode, LevelCode,
               FKRace, ListPositionCandidate, FKFinalCandidateList,
               FKCandidate, Votes, FKUser, decisionID);
            dbCR.CloseConnection();
        }
        public static DataSet p3getPSStatisticEntry(string pscode, string level, int race, int entry)
        {
            DBArchive dbCR = new DBArchive();
            dbCR.OpenConnection();
            DataSet dsCR = dbCR.p3getPSStatisticEntry(pscode, level, race, entry);
            dbCR.CloseConnection();
            return dsCR;
        }

        public static int p3GetTotalValidVotesNM_D2(string pscode, string LevelCode, string EntryNumber)
        {
            DBArchive dbCR = new DBArchive();
            dbCR.OpenConnection();
            int dsCR = dbCR.p3GetTotalValidVotesNM_D2(pscode, LevelCode, EntryNumber);
            dbCR.CloseConnection();
            return dsCR;
        }

        public static int RESULTSCheckIfLevelHasNM(string levelCode)
        {
            DBArchive dbCR = new DBArchive();
            dbCR.OpenConnection();
            int dsCR = dbCR.RESULTSCheckIfLevelHasNM(levelCode);
            dbCR.CloseConnection();
            return dsCR;
        }

        public static void RESULTS_InsertUpdateIntoPSStatistic(int param, string PSCode, string LevelCode,
               int FKRace, int EntryNumber, int Item, string Status, string NextStep)
        {
            DBArchive dbCR = new DBArchive();
            dbCR.OpenConnection();
            dbCR.RESULTS_InsertUpdateIntoPSStatistic(param, PSCode, LevelCode,
               FKRace, EntryNumber, Item, Status, NextStep);
            dbCR.CloseConnection();
        }

        public static DataSet p3_GetTrackingRelations(int matid, int lang)
        {
            DBArchive dbCR = new DBArchive();
            dbCR.OpenConnection();
            DataSet dsCR = dbCR.p3_GetTrackingRelations(matid, lang);
            dbCR.CloseConnection();
            return dsCR;
        }

        public static void DeleteScannedVoter(int id, string level)
        {
            DBArchive dbDeleteOrgUnit = new DBArchive();
            dbDeleteOrgUnit.OpenConnection();
            dbDeleteOrgUnit.DeleteScannedVoter(id, level);
            dbDeleteOrgUnit.CloseConnection();
        }
        public static void p3_InsertInto_p3_PO_Package(int PoBox, int BagNo, int ShipmentNumber, int RegularEnvelopes, int ExpressPost, int Undelivered, int Others,
    int TotalReceivedEnvelopes, string DateReceived, string Comment, string Type, int Clerk)
        {
            DBArchive dbDeleteOrgUnit = new DBArchive();
            dbDeleteOrgUnit.OpenConnection();
            dbDeleteOrgUnit.p3_InsertInto_p3_PO_Package(PoBox, BagNo, ShipmentNumber, RegularEnvelopes, ExpressPost, Undelivered, Others,
     TotalReceivedEnvelopes, DateReceived, Comment, Type, Clerk);
            dbDeleteOrgUnit.CloseConnection();
        }

        public static DataSet RESULTSGetPoliticalEntitiesForOLWithVotesForResume(int fkrace, string levelCode, int entryNum, string pscode)
        {
            DBArchive dbCR = new DBArchive();
            dbCR.OpenConnection();
            DataSet dsCR = dbCR.RESULTSGetPoliticalEntitiesForOLWithVotesForResume(fkrace, levelCode, entryNum, pscode);
            dbCR.CloseConnection();
            return dsCR;
        }

        public static DataSet p3_GetMaterialsForAreaID(int areaid, int lang)
        {
            DBArchive dbCR = new DBArchive();
            dbCR.OpenConnection();
            DataSet dsCR = dbCR.p3_GetMaterialsForAreaID(areaid, lang);
            dbCR.CloseConnection();
            return dsCR;
        }

        public static DataSet p3_GetTrackingMaterials(string code, int lang, int area)
        {
            DBArchive dbCR = new DBArchive();
            dbCR.OpenConnection();
            DataSet dsCR = dbCR.p3_GetTrackingMaterials(code, lang, area);
            dbCR.CloseConnection();
            return dsCR;
        }

        public static void p3_InsertTrackingMaterials(string code, int mid, int areaFrom, int areaTo, int user)
        {
            DBArchive dbCR = new DBArchive();
            dbCR.OpenConnection();
            dbCR.p3_InsertTrackingMaterials(code, mid, areaFrom, areaTo, user);
            dbCR.CloseConnection();
        }

        public static DataSet p3_GetAreasToForArea(int area, int mid, int lang)
        {
            DBArchive dbCR = new DBArchive();
            dbCR.OpenConnection();
            DataSet dsCR = dbCR.p3_GetAreasToForArea(area, mid, lang);
            dbCR.CloseConnection();
            return dsCR;
        }

        public static DataSet p3_GetStartMaterialsForAreaID(int areaid, int lang)
        {
            DBArchive dbCR = new DBArchive();
            dbCR.OpenConnection();
            DataSet dsCR = dbCR.p3_GetStartMaterialsForAreaID(areaid, lang);
            dbCR.CloseConnection();
            return dsCR;
        }

        public static DataSet p3_GetAllPSCodes()
        {
            DBArchive dbCR = new DBArchive();
            dbCR.OpenConnection();
            DataSet dsCR = dbCR.p3_GetAllPSCodes();
            dbCR.CloseConnection();
            return dsCR;
        }

        public static void DeleteScannedVoterBag(int id, string level)
        {
            DBArchive dbDeleteOrgUnit = new DBArchive();
            dbDeleteOrgUnit.OpenConnection();
            dbDeleteOrgUnit.DeleteScannedVoterBag(id, level);
            dbDeleteOrgUnit.CloseConnection();
        }
        public static DataSet p3_ScanVoterBag(string jmb, int accepted, int clerk, string psBag)
        {
            DBArchive dbCR = new DBArchive();
            dbCR.OpenConnection();
            DataSet ds = dbCR.p3_ScanVoterBag(jmb, accepted, clerk, psBag);
            dbCR.CloseConnection();
            return ds;
        }

        //public static DataSet p3_GetMaterialIDFromPSM()
        //{
        //    DBArchive dbCR = new DBArchive();
        //    dbCR.OpenConnection();
        //    DataSet dsCR = dbCR.p3_GetMaterialIDFromPSM();
        //    dbCR.CloseConnection();
        //    return dsCR;
        //}

        public static DataSet p3_GetScanningForPSData(string psBag)
        {
            DBArchive dbCR = new DBArchive();
            dbCR.OpenConnection();
            DataSet ds = dbCR.p3_GetScanningForPSData(psBag);
            dbCR.CloseConnection();
            return ds;
        }

        public static void p3_UpdateTrackingMaterials(int id, string code, int mid, int areaFrom, int areaTo, int user)
        {
            DBArchive dbCR = new DBArchive();
            dbCR.OpenConnection();
            dbCR.p3_UpdateTrackingMaterials(id, code, mid, areaFrom, areaTo, user);
            dbCR.CloseConnection();
        }

        public static void p3_SetQuarantine(int mid, string code, int set)
        {
            DBArchive dbCR = new DBArchive();
            dbCR.OpenConnection();
            dbCR.p3_SetQuarantine(mid, code, set);
            dbCR.CloseConnection();
        }
        public static DataSet p3getStatisticForPSAndMaterials(string param)
        {
            DBArchive dbCR = new DBArchive();
            dbCR.OpenConnection();
            DataSet ds = dbCR.p3getStatisticForPSAndMaterials(param);
            dbCR.CloseConnection();
            return ds;
        }

        public static void RESULTS_InsertUpdateIntoResultsArchive(int param, string PSNumber, int FKCandidacyRace,
                    string LevelCode, int FKItem, int Status, int FKFinalCandidateList, int UserFirst,
                    int UserSecond, int UserSuper, int UserControlor)
        {
            DBArchive dbCR = new DBArchive();
            dbCR.OpenConnection();
            dbCR.RESULTS_InsertUpdateIntoResultsArchive(param, PSNumber, FKCandidacyRace,
                    LevelCode, FKItem, Status, FKFinalCandidateList, UserFirst,
                    UserSecond, UserSuper, UserControlor);
            dbCR.CloseConnection();
        }
        public static void p3UpdateTolarenceParametars(int id, string TolDescriptionB, string TolDescriptionS, string TolDescriptionC, string TolDescriptionE, decimal TolValue, string TolType)
        {
            DBArchive dbCR = new DBArchive();
            dbCR.OpenConnection();
            dbCR.p3UpdateTolarenceParametars(id, TolDescriptionB, TolDescriptionS, TolDescriptionC, TolDescriptionE, TolValue, TolType);
            dbCR.CloseConnection();
        }

        public static DataSet p3_GetNextArea(string code, int lang, int area, int mid)
        {
            DBArchive dbCR = new DBArchive();
            dbCR.OpenConnection();
            DataSet ds = dbCR.p3_GetNextArea(code, lang, area, mid);
            dbCR.CloseConnection();
            return ds;
        }
        public static DataSet p3getTolarenceParametarsByID(int id)
        {
            DBArchive dbCR = new DBArchive();
            dbCR.OpenConnection();
            DataSet ds = dbCR.p3getTolarenceParametarsByID(id);
            dbCR.CloseConnection();
            return ds;
        }
        public static DataSet p3GetMaterialsforPSCOde()
        {
            DBArchive dbNewsName = new DBArchive();
            dbNewsName.OpenConnection();
            DataSet name = dbNewsName.p3GetMaterialsforPSCOde();
            dbNewsName.CloseConnection();
            return name;
        }

        public static DataSet p3TotalTurnOutByMun()
        {
            DBArchive dbNewsName = new DBArchive();
            dbNewsName.OpenConnection();
            DataSet name = dbNewsName.p3TotalTurnOutByMun();
            dbNewsName.CloseConnection();
            return name;
        }

        public static DataSet p3_GetNameResource(int lang, int id)
        {
            DBArchive dbNewsName = new DBArchive();
            dbNewsName.OpenConnection();
            DataSet name = dbNewsName.p3_GetNameResource(lang, id);
            dbNewsName.CloseConnection();
            return name;
        }

        public static void p3_UpdateNameResource(int lang, int id, string name)
        {
            DBArchive dbNewsName = new DBArchive();
            dbNewsName.OpenConnection();
            dbNewsName.p3_UpdateNameResource(lang, id, name);
            dbNewsName.CloseConnection();
        }

        public static DataSet p3_ResultsEntriesStatusByLanguage(int lan)
        {
            DBArchive dbNewsName = new DBArchive();
            dbNewsName.OpenConnection();
            DataSet name = dbNewsName.p3_ResultsEntriesStatusByLanguage(lan);
            dbNewsName.CloseConnection();
            return name;
        }

        public static void FINALIZEInvalidListInsertIntoFinal(int race, int level, int party)
        {
            DBArchive dbNewsName = new DBArchive();
            dbNewsName.OpenConnection();
            dbNewsName.FINALIZEInvalidListInsertIntoFinal(race, level, party);
            dbNewsName.CloseConnection();
        }
        public static DataSet p3getEntriesArchiveItems(string PSNumber, int FKCandidacyRace, string LevelCode, int status)
        {
            DBArchive dbNewsName = new DBArchive();
            dbNewsName.OpenConnection();
            DataSet name = dbNewsName.p3getEntriesArchiveItems(PSNumber, FKCandidacyRace, LevelCode, status);
            dbNewsName.CloseConnection();
            return name;
        }

        public static void p3_InsertInto_p3_Bags(int PoBox, string PollingStationCode, int ShipmentNumber, int RegularEnvelopes, int ExpressPost, int Undelivered, int Others,
     int TotalReceivedEnvelopes, string DateReceived, string Comment, string Type, int Clerk)
        {
            DBArchive dbDeleteOrgUnit = new DBArchive();
            dbDeleteOrgUnit.OpenConnection();
            dbDeleteOrgUnit.p3_InsertInto_p3_Bags(PoBox, PollingStationCode, ShipmentNumber, RegularEnvelopes, ExpressPost, Undelivered, Others,
     TotalReceivedEnvelopes, DateReceived, Comment, Type, Clerk);
            dbDeleteOrgUnit.CloseConnection();
        }
 
        public static void p3_InsertEmptyBagsInto_P3Bags(string typeBag, int numberCopies, string TypeMunicipality)
        {
            DBArchive dbDeleteOrgUnit = new DBArchive();
            dbDeleteOrgUnit.OpenConnection();
            dbDeleteOrgUnit.p3_InsertEmptyBagsInto_P3Bags(typeBag, numberCopies, TypeMunicipality);
            dbDeleteOrgUnit.CloseConnection();
        }

        //sh 10.06.2012
        public static void p3_InsertEmptyBagsInto_P3Bags_Odsustvo(string typeBag, string PSCode)
        {
            DBArchive dbDeleteOrgUnit = new DBArchive();
            dbDeleteOrgUnit.OpenConnection();
            dbDeleteOrgUnit.p3_InsertEmptyBagsInto_P3Bags_Odsustvo(typeBag, PSCode);
            dbDeleteOrgUnit.CloseConnection();
        }

        public static void p3_InsertEmptyBagsInto_P3Bags_Mobilni(string typeBag, string MunCode,string Entity,string NumberMobile,string NumberGenerate)
        {
            DBArchive dbDeleteOrgUnit = new DBArchive();
            dbDeleteOrgUnit.OpenConnection();
            dbDeleteOrgUnit.p3_InsertEmptyBagsInto_P3Bags_Mobilni(typeBag, MunCode,Entity,NumberMobile,NumberGenerate);
            dbDeleteOrgUnit.CloseConnection();
        }
        //---------------

        public static void p3_InsertInto_p3_Bags_Otsustvo(string PollingStationCode, int TotalReceivedEnvelopes, string DateReceived, string Comment, int Clerk)
        {
            DBArchive dbDeleteOrgUnit = new DBArchive();
            dbDeleteOrgUnit.OpenConnection();
            dbDeleteOrgUnit.p3_InsertInto_p3_Bags_Otsustvo(PollingStationCode, TotalReceivedEnvelopes, DateReceived, Comment, Clerk);
            dbDeleteOrgUnit.CloseConnection();
        }
        public static void p3_InsertInto_p3_Bags_Nepotvrdjeni(string PollingStationCode, int TotalReceivedEnvelopes, string DateReceived, string Comment, int Clerk)
        {
            DBArchive dbDeleteOrgUnit = new DBArchive();
            dbDeleteOrgUnit.OpenConnection();
            dbDeleteOrgUnit.p3_InsertInto_p3_Bags_Nepotvrdjeni(PollingStationCode, TotalReceivedEnvelopes, DateReceived, Comment, Clerk);
            dbDeleteOrgUnit.CloseConnection();
        }
        public static void p3_InsertInto_p3_Bags_BSpisak(string PollingStationCode, string DateReceived, string Comment, int Clerk)
        {
            DBArchive dbDeleteOrgUnit = new DBArchive();
            dbDeleteOrgUnit.OpenConnection();
            dbDeleteOrgUnit.p3_InsertInto_p3_Bags_BSpisak(PollingStationCode, DateReceived, Comment, Clerk);
            dbDeleteOrgUnit.CloseConnection();
        }

        public static string p3_GetMECUsersKey(int user, string code)
        {
            DBArchive dbNewsName = new DBArchive();
            dbNewsName.OpenConnection();
            string name = dbNewsName.p3_GetMECUsersKey(user, code);
            dbNewsName.CloseConnection();
            return name;
        }

        public static void p3_AddMECUsersKey(int user, string code, string key)
        {
            DBArchive dbNewsName = new DBArchive();
            dbNewsName.OpenConnection();
            dbNewsName.p3_AddMECUsersKey(user, code, key);
            dbNewsName.CloseConnection();
        }
        public static void p3_Update_P3_MECUsers(int UserID, string MunCode, string MunName, short ResultsEntry, string MECKey)
        {
            DBArchive dbNewsName = new DBArchive();
            dbNewsName.OpenConnection();
            dbNewsName.BUpdateP3_MECUsers(UserID, MunCode, MunName, ResultsEntry, MECKey);
            dbNewsName.CloseConnection();
        }
        public static DataSet p3_getBagForID(string PollingStationCode)
        {
            DBArchive cand = new DBArchive();
            cand.OpenConnection();
            DataSet dsCand = cand.p3_getBagForID(PollingStationCode);
            cand.CloseConnection();
            return dsCand;
        }
        //Nedim
        public static DataSet p3_getBagDetails(string PollingStationCode)
        {
            DBArchive cand = new DBArchive();
            cand.OpenConnection();
            DataSet dsCand = cand.p3_getBagDetails(PollingStationCode);
            cand.CloseConnection();
            return dsCand;
        }
        public static DataSet p3_getBagDetailsByBoxName(string boxName)
        {
            DBArchive cand = new DBArchive();
            cand.OpenConnection();
            DataSet dsCand = cand.p3_getBagDetailsByBoxName(boxName);
            cand.CloseConnection();
            return dsCand;
        }
        public static void RESULTS_InsertUpdateIntoTotalREA(int param, string PSCode, int Race,
            string MunCode, string MunName, int Status)
        {
            DBArchive dbCR = new DBArchive();
            dbCR.OpenConnection();
            dbCR.RESULTS_InsertUpdateIntoTotalREA(param, PSCode, Race,
            MunCode, MunName, Status);
            dbCR.CloseConnection();
        }

        public static void p3_Insert_BagsDeniedReasons(string BagNumber, int DenyReasonID, int NoDeniedEnv, string Comment)
        {
            DBArchive dbCR = new DBArchive();
            dbCR.OpenConnection();
            dbCR.p3_Insert_BagsDeniedReasons(BagNumber, DenyReasonID, NoDeniedEnv, Comment);
            dbCR.CloseConnection();
        }

        public static void p3_Insert_NewDenyReason(string DenyReasonName, string typePS)
        {
            DBArchive dbCR = new DBArchive();
            dbCR.OpenConnection();
            dbCR.p3_Insert_NewDenyReason(DenyReasonName, typePS);
            dbCR.CloseConnection();
        }


        public static DataSet ARezultatiProc(string race, string pool)
        {
            DBArchive dbCR = new DBArchive();
            dbCR.OpenConnection();
            DataSet ds = dbCR.ARezultatiProc(race, pool);
            dbCR.CloseConnection();
            return ds;
        }
        public static void RESULTS_GeneratePreliminary(int userID)
        {
            DBArchive dbCR = new DBArchive();
            dbCR.OpenConnection();
            dbCR.RESULTS_GeneratePreliminary(userID);
            dbCR.CloseConnection();
        }
        public static void RESULTS_GeneratePreliminaryEntry5(int userID)
        {
            DBArchive dbCR = new DBArchive();
            dbCR.OpenConnection();
            dbCR.RESULTS_GeneratePreliminaryEntry5(userID);
            dbCR.CloseConnection();
        }
        public static void p3_UpdateUnconfirmedTurnout(int id, int TurnOutFirst, int TurnOutSecond, int TurnOutThird, string MunCode)
        {
            DBArchive dbDeleteOrgUnit = new DBArchive();
            dbDeleteOrgUnit.OpenConnection();
            dbDeleteOrgUnit.p3_UpdateUnconfirmedTurnout(id, TurnOutFirst, TurnOutSecond, TurnOutThird, MunCode);
            dbDeleteOrgUnit.CloseConnection();
        }
        public static DataSet RESULTS_getPSStatisticEntry1(string PSCode, string LevelCode, int FKRace, int FKUser)
        {
            DBArchive dbCR = new DBArchive();
            dbCR.OpenConnection();
            DataSet ds = dbCR.RESULTS_getPSStatisticEntry1(PSCode, LevelCode, FKRace, FKUser);
            dbCR.CloseConnection();
            return ds;
        }
        //Nedim B
        public static int BGetActiveCandidacyRaceForMissmatchesTracking(string PSCode, string LevelCode, int FKRace, int FKUser)
        {
            DBArchive dbDeleteOrgUnit = new DBArchive();
            dbDeleteOrgUnit.OpenConnection();
            int ds = dbDeleteOrgUnit.BGetActiveCandidacyRaceForMissmatchesTracking(PSCode, LevelCode, FKRace, FKUser);
            dbDeleteOrgUnit.CloseConnection();
            return ds;
        }

        public static string p2_getLevelNameForTitle(int level)
        {
            DBArchive dbCR = new DBArchive();
            dbCR.OpenConnection();
            string ds = dbCR.p2_getLevelNameForTitle(level);
            dbCR.CloseConnection();
            return ds;
        }
        public static void RESULTS_updatePSStatisticEntry1(string PSCode, string LevelCode, int FKRace, int FKUser, int TotalVotersInCVR1, int NumberBallotsInBox2, int InvalidUnMarkBallotsA, int InvalidOthersBallotsB, int TotalInvalidBallotsC, int TotalValidVotesD1, int TotalValidVotesNMD2, int TotalValidVotesD, int TotalAllBallotsE, int AccuracyTest23, int AccuracyTest3F)
        {
            DBArchive dbDeleteOrgUnit = new DBArchive();
            dbDeleteOrgUnit.OpenConnection();
            dbDeleteOrgUnit.RESULTS_updatePSStatisticEntry1(PSCode, LevelCode, FKRace, FKUser, TotalVotersInCVR1, NumberBallotsInBox2, InvalidUnMarkBallotsA, InvalidOthersBallotsB, TotalInvalidBallotsC, TotalValidVotesD1, TotalValidVotesNMD2, TotalValidVotesD, TotalAllBallotsE, AccuracyTest23, AccuracyTest3F);
            dbDeleteOrgUnit.CloseConnection();
        }
        public static void RESULTSUpdatePoliticalEntitiesVG2(string PSCode, string LevelCode, int FKRace, int FKUser, int votes, int listnumber)
        {
            DBArchive dbDeleteOrgUnit = new DBArchive();
            dbDeleteOrgUnit.OpenConnection();
            dbDeleteOrgUnit.RESULTSUpdatePoliticalEntitiesVG2(PSCode, LevelCode, FKRace, FKUser, votes, listnumber);
            dbDeleteOrgUnit.CloseConnection();
        }
        public static void p3_UpdateFinalCandidatesForOpenListVotes(int FKRace, string LevelCode, int FKUser, string PSCode, int FKFCL, int fkCandidate, int votes)
        {
            DBArchive dbDeleteOrgUnit = new DBArchive();
            dbDeleteOrgUnit.OpenConnection();
            dbDeleteOrgUnit.p3_UpdateFinalCandidatesForOpenListVotes(FKRace, LevelCode, FKUser, PSCode, FKFCL, fkCandidate, votes);
            dbDeleteOrgUnit.CloseConnection();
        }

        public static void p3_Update_p3_Bags_BeforeVerification(string BagNumber, int Approved, int Rejected, string ControlCountComment)
        {
            DBArchive dbDeleteOrgUnit = new DBArchive();
            dbDeleteOrgUnit.OpenConnection();
            dbDeleteOrgUnit.p3_Update_p3_Bags_BeforeVerification(BagNumber, Approved, Rejected, ControlCountComment);
            dbDeleteOrgUnit.CloseConnection();
        }
        public static int p3_CountMessages(int userID)
        {
            DBArchive cand = new DBArchive();
            cand.OpenConnection();
            int dsCand = cand.p3_CountMessages(userID);
            cand.CloseConnection();
            return dsCand;
        }

        public static void p3_InsertP3IntakePs(string levelCode, string psCode, bool received, string comment)
        {
            DBArchive dbDeleteOrgUnit = new DBArchive();
            dbDeleteOrgUnit.OpenConnection();
            dbDeleteOrgUnit.p3_InsertP3IntakePs(levelCode, psCode, received, comment);
            dbDeleteOrgUnit.CloseConnection();
        }
        public static DataSet RESULTSGetPreliminaryZRmayority(int fkRace, string levelCode)
        {
            DBArchive dbCR = new DBArchive();
            dbCR.OpenConnection();
            DataSet ds = dbCR.RESULTSGetPreliminaryZRmayority(fkRace, levelCode);
            dbCR.CloseConnection();
            return ds;
        }
        public static DataSet p3_getBFinalCandidatesPreliminary(int FKRace, string LevelCode, int FKFCL)
        {
            DBArchive dbCR = new DBArchive();
            dbCR.OpenConnection();
            DataSet ds = dbCR.p3_getBFinalCandidatesPreliminary(FKRace, LevelCode, FKFCL);
            dbCR.CloseConnection();
            return ds;
        }

        //Izraboteno vo Bosnaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa
        public static int M12Opstinski4Koloni19KolkuGrupi(int level, int race)
        {
            DBArchive cand = new DBArchive();
            cand.OpenConnection();
            int dsCand = cand.M12Opstinski4Koloni19KolkuGrupi(level, race);
            cand.CloseConnection();
            return dsCand;
        }

        public static int M12GetZROpstinski1ProbaCountTotal(int level, int race)
        {
            DBArchive cand = new DBArchive();
            cand.OpenConnection();
            int dsCand = cand.M12GetZROpstinski1ProbaCountTotal(level, race);
            cand.CloseConnection();
            return dsCand;
        }

        public static string M12GetKratenkaScriptForLevel(int level)
        {
            DBArchive cand = new DBArchive();
            cand.OpenConnection();
            string dsCand = cand.M12GetKratenkaScriptForLevel(level);
            cand.CloseConnection();
            return dsCand;
        }

        public static string M12GetRaceData(string language, int race)
        {
            DBArchive cand = new DBArchive();
            cand.OpenConnection();
            string dsCand = cand.M12GetRaceData(language, race);
            cand.CloseConnection();
            return dsCand;
        }

        public static void TRUNCATEFROMCYRILIC()
        {
            DBArchive dbCR = new DBArchive();
            dbCR.OpenConnection();
            dbCR.TRUNCATEFROMCYRILIC();
            dbCR.CloseConnection();
        }

        public static bool ProccStep2CheckIsProccesed(int idlist)
        {
            DBArchive gel = new DBArchive();
            gel.OpenConnection();
            bool name1 = gel.ProccStep2CheckIsProccesed(idlist);
            gel.CloseConnection();
            return name1;
        }

        public static void p3_CreateBox(string Combination, string PSType)
        {
            DBArchive dbCR = new DBArchive();
            dbCR.OpenConnection();
            dbCR.p3_CreateBox(Combination, PSType);
            dbCR.CloseConnection();
        }
        public static void p3_VerificationUpdate(string PollingStationCode, int Accepted, int Denied)
        {
            DBArchive dbCR = new DBArchive();
            dbCR.OpenConnection();
            dbCR.p3_VerificationUpdate(PollingStationCode, Accepted, Denied);
            dbCR.CloseConnection();
        }



        public static DataSet p3_getDataFromBagsByID(string PollingStationCode)
        {
            DBArchive dbCR = new DBArchive();
            dbCR.OpenConnection();
            DataSet ds = dbCR.p3_getDataFromBagsByID(PollingStationCode);
            dbCR.CloseConnection();
            return ds;
        }



        public static DataSet p3_getBagNameFromBagsByID(int Id)
        {
            DBArchive dbCR = new DBArchive();
            dbCR.OpenConnection();
            DataSet ds = dbCR.p3_getBagNameFromBagsByID(Id);
            dbCR.CloseConnection();
            return ds;
        }


        public static DataSet p3_getBagNameFromBagsByPSCode(string PollingStationCode)
        {
            DBArchive dbCR = new DBArchive();
            dbCR.OpenConnection();
            DataSet ds = dbCR.p3_getBagNameFromBagsByPSCode(PollingStationCode);
            dbCR.CloseConnection();
            return ds;
        }

        



        public static DataSet p3_GetNumberDenyReasonsForDeniedVoters(int IdDeniedReason, string numberBag)
        {
            DBArchive dbCR = new DBArchive();
            dbCR.OpenConnection();
            DataSet ds = dbCR.p3_GetNumberDenyReasonsForDeniedVoters(IdDeniedReason, numberBag);
            dbCR.CloseConnection();
            return ds;
        }


        public static void p3_VerificationReceivedEnvelopesUpdate(string PollingStationCode, int EnvNumber)
        {
            DBArchive dbCR = new DBArchive();
            dbCR.OpenConnection();
            dbCR.p3_VerificationReceivedEnvelopesUpdate(PollingStationCode, EnvNumber);
            dbCR.CloseConnection();
        }




        public static void p3_VerificationReceivedEnvelopesUpdate(int ID, int EnvNumber)
        {
            DBArchive dbCR = new DBArchive();
            dbCR.OpenConnection();
            dbCR.p3_VerificationReceivedEnvelopesUpdate(ID, EnvNumber);
            dbCR.CloseConnection();
        }


        public static void p3_VerificationUpdate(int ID, int Accepted, int Denied)
        {
            DBArchive dbCR = new DBArchive();
            dbCR.OpenConnection();
            dbCR.p3_VerificationUpdate(ID, Accepted, Denied);
            dbCR.CloseConnection();
        }

        public static void p3_UpdateIntakeMaterials(bool param, string Comment, int ID)
        {
            DBArchive dbDeleteOrgUnit = new DBArchive();
            dbDeleteOrgUnit.OpenConnection();
            dbDeleteOrgUnit.p3_UpdateIntakeMaterials(param, Comment, ID);
            dbDeleteOrgUnit.CloseConnection();
        }
        public static DataSet p3GetLevelName(string Code)
        {
            DBArchive dbCR = new DBArchive();
            dbCR.OpenConnection();
            DataSet ds = dbCR.p3GetLevelName(Code);
            dbCR.CloseConnection();
            return ds;
        }
        public static void RESULTS_CheckOtvorenaLista1TWOEntries(string PSCode, string LevelCode, int FKRace,
                           int TotalVotersInCVR1, int NumberBallotsInBox2, int AccuracyTest23,
                           int InvalidUnMarkBallotsA, int InvalidOthersBallotsB, int TotalInvalidBallotsC,
                           int TotalValidVotesD1, int TotalValidVotesNMD2, int TotalValidVotesD,
                           int TotalAllBallotsE, int AccuracyTest3F, int FKUser)
        {
            DBArchive dbDeleteOrgUnit = new DBArchive();
            dbDeleteOrgUnit.OpenConnection();
            dbDeleteOrgUnit.RESULTS_CheckOtvorenaLista1TWOEntries(PSCode, LevelCode, FKRace,
                    TotalVotersInCVR1, NumberBallotsInBox2, AccuracyTest23,
                    InvalidUnMarkBallotsA, InvalidOthersBallotsB, TotalInvalidBallotsC,
                    TotalValidVotesD1, TotalValidVotesNMD2, TotalValidVotesD,
                    TotalAllBallotsE, AccuracyTest3F, FKUser);
            dbDeleteOrgUnit.CloseConnection();
        }

        public static void RESULTS_CheckVecinskiGlas1TWOEntries(string PSCode, string LevelCode, int FKRace,
                   int TotalVotersInCVR1, int NumberBallotsInBox2, int AccuracyTest23,
                   int InvalidUnMarkBallotsA, int InvalidOthersBallotsB, int TotalInvalidBallotsC,
                   int TotalValidVotesD, int TotalAllBallotsE, int AccuracyTest3F, int FKUser)
        {
            DBArchive dbDeleteOrgUnit = new DBArchive();
            dbDeleteOrgUnit.OpenConnection();
            dbDeleteOrgUnit.RESULTS_CheckVecinskiGlas1TWOEntries(PSCode, LevelCode, FKRace,
                    TotalVotersInCVR1, NumberBallotsInBox2, AccuracyTest23,
                    InvalidUnMarkBallotsA, InvalidOthersBallotsB, TotalInvalidBallotsC,
                    TotalValidVotesD, TotalAllBallotsE, AccuracyTest3F, FKUser);
            dbDeleteOrgUnit.CloseConnection();
        }

        public static void RESULTS_CheckOtvorenaLista2TWOEntries(string PSCode, string LevelCode, int FKRace, int FKUser, int ListNumber)
        {
            DBArchive dbDeleteOrgUnit = new DBArchive();
            dbDeleteOrgUnit.OpenConnection();
            dbDeleteOrgUnit.RESULTS_CheckOtvorenaLista2TWOEntries(PSCode, LevelCode, FKRace, FKUser, ListNumber);
            dbDeleteOrgUnit.CloseConnection();
        }

        public static void RESULTS_CheckOtvorenaLista2TWOEntries(string PSCode, string LevelCode, int FKRace, int FKUser)
        {
            DBArchive dbDeleteOrgUnit = new DBArchive();
            dbDeleteOrgUnit.OpenConnection();
            dbDeleteOrgUnit.RESULTS_CheckOtvorenaLista2TWOEntries(PSCode, LevelCode, FKRace, FKUser);
            dbDeleteOrgUnit.CloseConnection();
        }

        public static void RESULTS_CheckVecinskiGlas2TWOEntries(string PSCode, string LevelCode, int FKRace, int FKUser)
        {
            DBArchive dbDeleteOrgUnit = new DBArchive();
            dbDeleteOrgUnit.OpenConnection();
            dbDeleteOrgUnit.RESULTS_CheckVecinskiGlas2TWOEntries(PSCode, LevelCode, FKRace, FKUser);
            dbDeleteOrgUnit.CloseConnection();
        }
        public static DataSet BGetValidANDInvalidPreliminary(string LevelCode, int Race)
        {
            DBArchive dbCR = new DBArchive();
            dbCR.OpenConnection();
            DataSet ds = dbCR.BGetValidANDInvalidPreliminary(LevelCode, Race);
            dbCR.CloseConnection();
            return ds;
        }
        public static DataSet BGetValidANDInvalidFinal(string LevelCode, int Race)
        {
            DBArchive dbCR = new DBArchive();
            dbCR.OpenConnection();
            DataSet ds = dbCR.BGetValidANDInvalidFinal(LevelCode, Race);
            dbCR.CloseConnection();
            return ds;
        }
        public static void p3_inseretIntoDeletedPS(string psCode, string levelCode, int FKRace, string comment, DateTime datetime, int fkuser, int FKStatus)
        {
            DBArchive dbDeleteOrgUnit = new DBArchive();
            dbDeleteOrgUnit.OpenConnection();
            dbDeleteOrgUnit.p3_inseretIntoDeletedPS(psCode, levelCode, FKRace, comment, datetime, fkuser, FKStatus);
            dbDeleteOrgUnit.CloseConnection();
        }

        //ace bosna faza 2



        public static void JDeleteFromCyrilicCandidates(int idcand)
        {
            DBArchive dbDeleteOrgUnit = new DBArchive();
            dbDeleteOrgUnit.OpenConnection();
            dbDeleteOrgUnit.JDeleteFromCyrilicCandidates(idcand);
            dbDeleteOrgUnit.CloseConnection();
        }

        public static void INSERTintoFRBackup()
        {
            DBArchive dbDeleteOrgUnit = new DBArchive();
            dbDeleteOrgUnit.OpenConnection();
            dbDeleteOrgUnit.INSERTintoFRBackup();
            dbDeleteOrgUnit.CloseConnection();
        }

        public static void CLEARFRBackup()
        {
            DBArchive dbDeleteOrgUnit = new DBArchive();
            dbDeleteOrgUnit.OpenConnection();
            dbDeleteOrgUnit.CLEARFRBackup();
            dbDeleteOrgUnit.CloseConnection();
        }

        public static int COUNTFRForButtons()
        {
            DBArchive dbDeleteOrgUnit = new DBArchive();
            dbDeleteOrgUnit.OpenConnection();
            int kolku = dbDeleteOrgUnit.COUNTFRForButtons();
            dbDeleteOrgUnit.CloseConnection();
            return kolku;
        }



        public static DataSet p2_getPolEntitiesForRaceAndLevel(int race, int level)
        {
            DBArchive gel = new DBArchive();
            gel.OpenConnection();
            DataSet name1 = gel.p2_getPolEntitiesForRaceAndLevel(race, level);
            gel.CloseConnection();
            return name1;

        }

        // 24.09 Energo dodato ime box name 
        public static void p3_insertBagsDetail(string PollingStationCode, int BagNo, string BoxCombination, string PSType, int NoEnvelopes, int NoSignatures, int NoEnvelopesCounted, int Difference, int BoxNo, string BoxType, int UserID, string boxName)
        {
            DBArchive dbCR = new DBArchive();
            dbCR.OpenConnection();
            dbCR.p3_insertBagsDetail(PollingStationCode, BagNo, BoxCombination, PSType, NoEnvelopes, NoSignatures, NoEnvelopesCounted, Difference, BoxNo, BoxType, UserID, boxName);
            dbCR.CloseConnection();
        }
        public static DataSet p3_getDataFromBox(int id)
        {
            DBArchive dbCR = new DBArchive();
            dbCR.OpenConnection();
            DataSet ds = dbCR.p3_getDataFromBox(id);
            dbCR.CloseConnection();
            return ds;
        }

        public static DataSet p3_getDataFromBoxByID(string BoxName)
        {
            DBArchive dbCR = new DBArchive();
            dbCR.OpenConnection();
            DataSet ds = dbCR.p3_getDataFromBoxByID(BoxName);
            dbCR.CloseConnection();
            return ds;
        }
        public static DataSet p2_getCandidates(int race, int level, int party)
        {
            DBArchive gel = new DBArchive();
            gel.OpenConnection();
            DataSet name1 = gel.p2_getCandidates(race, level, party);
            gel.CloseConnection();
            return name1;
        }
        public static int p3_checkIfBagDetailExist(string PSCode, int BoxNo, string Combination)
        {
            DBArchive gel = new DBArchive();
            gel.OpenConnection();
            int rowsErrors = gel.p3_checkIfBagDetailExist(PSCode, BoxNo, Combination);
            gel.CloseConnection();
            return rowsErrors;
        }
        public static DataSet p2_getCandidates600700(int race, int level)
        {
            DBArchive gel = new DBArchive();
            gel.OpenConnection();
            DataSet name1 = gel.p2_getCandidates600700(race, level);
            gel.CloseConnection();
            return name1;
        }
        public static void p3_UpdateBagStatus(string Status, string PSCode, string PSType)
        {
            DBArchive dbCR = new DBArchive();
            dbCR.OpenConnection();
            dbCR.p3_UpdateBagStatus(Status, PSCode, PSType);
            dbCR.CloseConnection();
        }

        public static int p3_getNumberOfEnvelopesCounted(string Combination, string BoxType, int BoxNo)
        {
            DBArchive gel = new DBArchive();
            gel.OpenConnection();
            int rowsErrors = gel.p3_getNumberOfEnvelopesCounted(Combination, BoxType, BoxNo);
            gel.CloseConnection();
            return rowsErrors;
        }
        public static void p3_updateBoxTotalEnvelopes(string BoxName, int TotalEnv, string BoxStatus)
        {
            DBArchive dbCR = new DBArchive();
            dbCR.OpenConnection();
            dbCR.p3_updateBoxTotalEnvelopes(BoxName, TotalEnv, BoxStatus);
            dbCR.CloseConnection();
        }
        public static void p3_updateBoxRejectedEnvelopes(string BoxName, int Rejected, string BoxStatus)
        {
            DBArchive dbCR = new DBArchive();
            dbCR.OpenConnection();
            dbCR.p3_updateBoxRejectedEnvelopes(BoxName, Rejected, BoxStatus);
            dbCR.CloseConnection();
        }
        public static void p3_InsertBoxDetailsSorting(string BoxName, int BoxNo, string BoxCombination, string BoxType, string LevelCode, int SortedEnvelopes)
        {
            DBArchive dbCR = new DBArchive();
            dbCR.OpenConnection();
            dbCR.p3_InsertBoxDetailsSorting(BoxName, BoxNo, BoxCombination, BoxType, LevelCode, SortedEnvelopes);
            dbCR.CloseConnection();
        }

        public static void P1ContinueWithCompensationList()
        {
            DBArchive dbDeleteOrgUnit = new DBArchive();
            dbDeleteOrgUnit.OpenConnection();
            dbDeleteOrgUnit.P1ContinueWithCompensationList();
            dbDeleteOrgUnit.CloseConnection();
        }
        public static void p3_UpdateBoxStatus(string Status, string BoxName)
        {
            DBArchive dbCR = new DBArchive();
            dbCR.OpenConnection();
            dbCR.p3_UpdateBoxStatus(Status, BoxName);
            dbCR.CloseConnection();
        }

        public static int p3_getBoxReadyForEntryResults(string boxName)
        {
            DBArchive dbBoxStatus = new DBArchive();
            dbBoxStatus.OpenConnection();
            int boxStatus = dbBoxStatus.p3_getBoxReadyForEntryResults(boxName);
            dbBoxStatus.CloseConnection();
            return boxStatus;
        }

        public static int COUNTFRForButtonsForCompensations()
        {
            DBArchive dbDeleteOrgUnit = new DBArchive();
            dbDeleteOrgUnit.OpenConnection();
            int kolku1 = dbDeleteOrgUnit.COUNTFRForButtonsForCompensations();
            dbDeleteOrgUnit.CloseConnection();
            return kolku1;
        }
        public static void web_FinalImportByRaceLevel(int race, int param, string level)
        {
            DBArchive dbCR = new DBArchive();
            dbCR.OpenConnection();
            dbCR.web_FinalImportByRaceLevel(race, param, level);
            dbCR.CloseConnection();
        }
        public static void p3_UpdateBoxDetailsCounting(string BoxName, int NoBallotsCounted, int ValidBallots, int InvalidBallots, string LevelCode)
        {
            DBArchive dbCR = new DBArchive();
            dbCR.OpenConnection();
            dbCR.p3_UpdateBoxDetailsCounting(BoxName, NoBallotsCounted, ValidBallots, InvalidBallots, LevelCode);
            dbCR.CloseConnection();
        }
        public static void p1_DeleteFromCompensationValidated()
        {
            DBArchive dbDeleteOrgUnit = new DBArchive();
            dbDeleteOrgUnit.OpenConnection();
            dbDeleteOrgUnit.p1_DeleteFromCompensationValidated();
            dbDeleteOrgUnit.CloseConnection();
        }

        public static void p1_InsertFromCompensationToFkCom()
        {
            DBArchive dbDeleteOrgUnit = new DBArchive();
            dbDeleteOrgUnit.OpenConnection();
            dbDeleteOrgUnit.p1_InsertFromCompensationToFkCom();
            dbDeleteOrgUnit.CloseConnection();
        }

        public static void p1_DeleteFromFRCompensationValidated1()
        {
            DBArchive dbDeleteOrgUnit = new DBArchive();
            dbDeleteOrgUnit.OpenConnection();
            dbDeleteOrgUnit.p1_DeleteFromFRCompensationValidated1();
            dbDeleteOrgUnit.CloseConnection();
        }

        public static void p2DeleteForManyPETables()
        {
            DBArchive dbDeleteOrgUnit = new DBArchive();
            dbDeleteOrgUnit.OpenConnection();
            dbDeleteOrgUnit.p2DeleteForManyPETables();
            dbDeleteOrgUnit.CloseConnection();
        }
        public static void p2InsertForManyPETables()
        {
            DBArchive dbDeleteOrgUnit = new DBArchive();
            dbDeleteOrgUnit.OpenConnection();
            dbDeleteOrgUnit.p2InsertForManyPETables();
            dbDeleteOrgUnit.CloseConnection();
        }


        public static void GenerateFinalReport()
        {
            DBArchive dbDeleteOrgUnit = new DBArchive();
            dbDeleteOrgUnit.OpenConnection();
            dbDeleteOrgUnit.GenerateFinalReport();
            dbDeleteOrgUnit.CloseConnection();
        }

        public static void web_PreliminaryImportByRaceLevel(int race, int param, string level)
        {
            DBArchive dbCR = new DBArchive();
            dbCR.OpenConnection();
            dbCR.web_PreliminaryImportByRaceLevel(race, param, level);
            dbCR.CloseConnection();
        }

        public static void web_DeleteFinalImportByRaceLevel(int race, int param, string level)
        {
            DBArchive dbCR = new DBArchive();
            dbCR.OpenConnection();
            dbCR.web_DeleteFinalImportByRaceLevel(race, param, level);
            dbCR.CloseConnection();
        }
        public static void web_DeletePreliminaryImportByRaceLevel(int race, int param, string level)
        {
            DBArchive dbCR = new DBArchive();
            dbCR.OpenConnection();
            dbCR.web_DeletePreliminaryImportByRaceLevel(race, param, level);
            dbCR.CloseConnection();
        }
        public static void web_InsertFinal()
        {
            DBArchive dbDeleteOrgUnit = new DBArchive();
            dbDeleteOrgUnit.OpenConnection();
            dbDeleteOrgUnit.web_InsertFinal();
            dbDeleteOrgUnit.CloseConnection();
        }
        public static void web_prepareMandatesforWebModule()
        {
            DBArchive dbDeleteOrgUnit = new DBArchive();
            dbDeleteOrgUnit.OpenConnection();
            dbDeleteOrgUnit.web_UpdateWebAppPRLevelCandidateResultsForReports();
            dbDeleteOrgUnit.CloseConnection();
        }

        public static void web_InsertPreliminary()
        {
            DBArchive dbDeleteOrgUnit = new DBArchive();
            dbDeleteOrgUnit.OpenConnection();
            dbDeleteOrgUnit.web_InsertPreliminary();
            dbDeleteOrgUnit.CloseConnection();
        }
        public static void DeletePreliminary()
        {
            DBArchive dbDeleteOrgUnit = new DBArchive();
            dbDeleteOrgUnit.OpenConnection();
            dbDeleteOrgUnit.DeletePreliminary();
            dbDeleteOrgUnit.CloseConnection();
        }
        public static void DeleteFinal()
        {
            DBArchive dbDeleteOrgUnit = new DBArchive();
            dbDeleteOrgUnit.OpenConnection();
            dbDeleteOrgUnit.DeleteFinal();
            dbDeleteOrgUnit.CloseConnection();
        }
        public static void DeleteGeneratedResults()
        {
            DBArchive dbDeleteOrgUnit = new DBArchive();
            dbDeleteOrgUnit.OpenConnection();
            dbDeleteOrgUnit.DeleteGeneratedResults();
            dbDeleteOrgUnit.CloseConnection();
        }
        public static void p3_Insert_p3_PSTurnout(int FKPS, string CodePS, bool IsOpenOnTime, string comment, string openingTime)
        {
            DBArchive dbCR = new DBArchive();
            dbCR.OpenConnection();
            dbCR.p3_Insert_p3_PSTurnout(FKPS, CodePS, IsOpenOnTime, comment, openingTime);
            dbCR.CloseConnection();
        }


        public static DataSet p3getNationalityAllocation(string code, int param, int raceID)
        {
            DBArchive dbCR = new DBArchive();
            dbCR.OpenConnection();
            DataSet ds = dbCR.p3getNationalityAllocation(code, param, raceID);
            dbCR.CloseConnection();
            return ds;
        }

        public static void p3_UpdateCoefficientAM(int valuepar, string descriprion, string type)
        {
            DBArchive dbDeleteOrgUnit = new DBArchive();
            dbDeleteOrgUnit.OpenConnection();
            dbDeleteOrgUnit.p3_UpdateCoefficientAM(valuepar, descriprion, type);
            dbDeleteOrgUnit.CloseConnection();
        }

        public static void p3_Update_p3_Bags_Total_Envelopes(int total, string BagNumber)
        {
            DBArchive dbDeleteOrgUnit = new DBArchive();
            dbDeleteOrgUnit.OpenConnection();
            dbDeleteOrgUnit.p3_Update_p3_Bags_Total_Envelopes(total, BagNumber);
            dbDeleteOrgUnit.CloseConnection();
        }
        public static void p3UpdateNationalityAllocation(int totalMandates, int totalSerbian, int totalBosnian, int totalCroatian, int totalOther, string Code, int RaceID, int TotalCompensation, bool IncludeNationalities, int param)
        {
            DBArchive dbCR = new DBArchive();
            dbCR.OpenConnection();
            dbCR.p3UpdateNationalityAllocation(totalMandates, totalSerbian, totalBosnian, totalCroatian, totalOther, Code, RaceID, TotalCompensation, IncludeNationalities, param);
            dbCR.CloseConnection();
        }
        public static void RESULTS_CheckOtvorenaListaOPTWOEntries(string PSCode, string LevelCode, int FKRace, int FKUser, int Lista)
        {
            DBArchive dbDeleteOrgUnit = new DBArchive();
            dbDeleteOrgUnit.OpenConnection();
            dbDeleteOrgUnit.RESULTS_CheckOtvorenaListaOPTWOEntries(PSCode, LevelCode, FKRace, FKUser, Lista);
            dbDeleteOrgUnit.CloseConnection();
        }
        public static void p3_Insert_Into_ObrazacBrojnogStanja(string PSCode, string LevelCode, int FKRace, int FKUser,
 int Box1, int Box2, int Box3, int Box4, int Box5, int Box6, int Box7, int Box8, int Box9, int Box10, int EntryNumber)
        {
            DBArchive dbDeleteOrgUnit = new DBArchive();
            dbDeleteOrgUnit.OpenConnection();
            dbDeleteOrgUnit.p3_Insert_Into_ObrazacBrojnogStanja(PSCode, LevelCode, FKRace, FKUser,
 Box1, Box2, Box3, Box4, Box5, Box6, Box7, Box8, Box9, Box10, EntryNumber);
            dbDeleteOrgUnit.CloseConnection();
        }
        public static bool p3_GetPsCodeFromObrazec(string PSCode)
        {
            DBArchive gel = new DBArchive();
            gel.OpenConnection();
            bool name1 = gel.p3_GetPsCodeFromObrazec(PSCode);
            gel.CloseConnection();
            return name1;
        }
        public static bool p3_GetPsCodeFromObrazec1(string PSCode)
        {
            DBArchive gel = new DBArchive();
            gel.OpenConnection();
            bool name1 = gel.p3_GetPsCodeFromObrazec1(PSCode);
            gel.CloseConnection();
            return name1;
        }
        public static int p3_GetLCOrCL(string @Code)
        {
            DBArchive dbNewsName = new DBArchive();
            dbNewsName.OpenConnection();
            int script = dbNewsName.p3_GetLCOrCL(@Code);
            dbNewsName.CloseConnection();
            return script;
        }
        public static void p3_InsertIntoLogs(string item, string ip, int userID, string text)
        {
            DBArchive dbLogs = new DBArchive();
            dbLogs.OpenConnection();
            dbLogs.p3_InsertIntoLogs(item, ip, userID, text);
            dbLogs.CloseConnection();
        }
        public static void p3_CloseOpenPSForMec(string CodePS, string MistakeOpenFalse)
        {
            DBArchive dbDeleteOrgUnit = new DBArchive();
            dbDeleteOrgUnit.OpenConnection();
            dbDeleteOrgUnit.p3_CloseOpenPSForMec(CodePS, MistakeOpenFalse);
            dbDeleteOrgUnit.CloseConnection();
        }

        public static void p3_OpenClosePSForMec(string CodePS, string MistakeCloseFalse)
        {
            DBArchive dbDeleteOrgUnit = new DBArchive();
            dbDeleteOrgUnit.OpenConnection();
            dbDeleteOrgUnit.p3_OpenClosePSForMec(CodePS, MistakeCloseFalse);
            dbDeleteOrgUnit.CloseConnection();
        }
        public static DataSet p3_getUnconfirmed3(string code)
        {
            DBArchive dbCR = new DBArchive();
            dbCR.OpenConnection();
            DataSet ds = dbCR.p3_getUnconfirmed3(code);
            dbCR.CloseConnection();
            return ds;
        }
        public static DataSet p3_getTotalRegisterVoters(string code)
        {
            DBArchive dbCR = new DBArchive();
            dbCR.OpenConnection();
            DataSet ds = dbCR.p3_getTotalRegisterVoters(code);
            dbCR.CloseConnection();
            return ds;
        }
        public static DataSet p3_getNumberOpened(string code)
        {
            DBArchive dbCR = new DBArchive();
            dbCR.OpenConnection();
            DataSet ds = dbCR.p3_getNumberOpened(code);
            dbCR.CloseConnection();
            return ds;
        }

        public static string M12GetRaceData1(string language, int race)
        {
            DBArchive cand = new DBArchive();
            cand.OpenConnection();
            string dsCand = cand.M12GetRaceData1(language, race);
            cand.CloseConnection();
            return dsCand;
        }

        public static int p3_Get_ShipmentNumber(string date)
        {
            DBArchive gel = new DBArchive();
            gel.OpenConnection();
            int rowsErrors = gel.p3_Get_ShipmentNumber(date);
            gel.CloseConnection();
            return rowsErrors;
        }
        public static void p3_InsertInto_ShipmentNumber(string dateReceive, int shipmentN, int shipmentnumber, int totalOtherPost,
            string comment, int status)
        {
            DBArchive dbCR = new DBArchive();
            dbCR.OpenConnection();
            dbCR.p3_InsertInto_ShipmentNumber(dateReceive, shipmentN, shipmentnumber, totalOtherPost, comment, status);
            dbCR.CloseConnection();
        }
        public static DataSet p2_getLevelNameForTitleV2(int race, int level, string lang)
        {
            DBArchive dbCR = new DBArchive();
            dbCR.OpenConnection();
            DataSet ds = dbCR.p2_getLevelNameForTitleV2(race, level, lang);
            dbCR.CloseConnection();
            return ds;
        }
        public static void p3_InsertInto_p3_Bags_Denied(int TotalReceivedEnvelopes, string PollingStationCode)
        {
            DBArchive cand = new DBArchive();
            cand.OpenConnection();
            cand.p3_InsertInto_p3_Bags_Denied(TotalReceivedEnvelopes, PollingStationCode);
            cand.CloseConnection();
        }
        public static DataSet p3_GetMismatchesOBS(string LevelCode,
     string PSCode, int FKRace, int EntryNumber)
        {
            DBArchive obs = new DBArchive();
            obs.OpenConnection();
            DataSet dsOBS = obs.p3_GetMismatchesOBS(LevelCode, PSCode, FKRace, EntryNumber);
            obs.CloseConnection();
            return dsOBS;
        }
        public static DataSet RESULTS_getPSStatisticFinalEntry(string PSCode, string LevelCode, int FKRace)
        {
            DBArchive dbCR = new DBArchive();
            dbCR.OpenConnection();
            DataSet ds = dbCR.RESULTS_getPSStatisticFinalEntry(PSCode, LevelCode, FKRace);
            dbCR.CloseConnection();
            return ds;
        }
        public static void RESULTS_updatePSStatisticFINALEntry(string PSCode, string LevelCode, int FKRace, int FKUser, int TotalVotersInCVR1, int NumberBallotsInBox2, int InvalidUnMarkBallotsA, int InvalidOthersBallotsB, int TotalInvalidBallotsC, int TotalValidVotesD1, int TotalValidVotesNMD2, int TotalValidVotesD, int TotalAllBallotsE, int AccuracyTest23, int AccuracyTest3F)
        {
            DBArchive dbDeleteOrgUnit = new DBArchive();
            dbDeleteOrgUnit.OpenConnection();
            dbDeleteOrgUnit.RESULTS_updatePSStatisticFINALEntry(PSCode, LevelCode, FKRace, FKUser, TotalVotersInCVR1, NumberBallotsInBox2, InvalidUnMarkBallotsA, InvalidOthersBallotsB, TotalInvalidBallotsC, TotalValidVotesD1, TotalValidVotesNMD2, TotalValidVotesD, TotalAllBallotsE, AccuracyTest23, AccuracyTest3F);
            dbDeleteOrgUnit.CloseConnection();
        }
        //Nedim
        public static void RESULTS_updatePSStatisticRepeatCounting(string PSCode, string LevelCode, int FKRace, int FKUser, int TotalVotersInCVR1, int NumberBallotsInBox2, int InvalidUnMarkBallotsA, int InvalidOthersBallotsB, int TotalInvalidBallotsC, int TotalValidVotesD1, int TotalValidVotesNMD2, int TotalValidVotesD, int TotalAllBallotsE, int AccuracyTest23, int AccuracyTest3F, int idDecision)
        {
            DBArchive dbDeleteOrgUnit = new DBArchive();
            dbDeleteOrgUnit.OpenConnection();
            dbDeleteOrgUnit.RESULTS_updatePSStatisticRepeatCounting(PSCode, LevelCode, FKRace, FKUser, TotalVotersInCVR1, NumberBallotsInBox2, InvalidUnMarkBallotsA, InvalidOthersBallotsB, TotalInvalidBallotsC, TotalValidVotesD1, TotalValidVotesNMD2, TotalValidVotesD, TotalAllBallotsE, AccuracyTest23, AccuracyTest3F, idDecision);
            dbDeleteOrgUnit.CloseConnection();
        }
        public static void p3_UpdateFinalCandidatesForOpenListVotesFINALVOTES(int FKRace, string LevelCode, int FKUser, string PSCode, int FKFCL, int fkCandidate, int votes)
        {
            DBArchive dbDeleteOrgUnit = new DBArchive();
            dbDeleteOrgUnit.OpenConnection();
            dbDeleteOrgUnit.p3_UpdateFinalCandidatesForOpenListVotesFINALVOTES(FKRace, LevelCode, FKUser, PSCode, FKFCL, fkCandidate, votes);
            dbDeleteOrgUnit.CloseConnection();
        }



        public static void RESULTSUpdatePoliticalEntitiesVG2FINALVOTES(string PSCode, string LevelCode, int FKRace, int FKUser, int votes, int listnumber)
        {
            DBArchive dbDeleteOrgUnit = new DBArchive();
            dbDeleteOrgUnit.OpenConnection();
            dbDeleteOrgUnit.RESULTSUpdatePoliticalEntitiesVG2FINALVOTES(PSCode, LevelCode, FKRace, FKUser, votes, listnumber);
            dbDeleteOrgUnit.CloseConnection();
        }


        public static void OBS_InsertIntoResultsArchive(string PSNumber, int FKCandidacyRace,
                     string LevelCode)
        {
            DBArchive dbCR = new DBArchive();
            dbCR.OpenConnection();
            dbCR.OBS_InsertIntoResultsArchive(PSNumber, FKCandidacyRace,
                     LevelCode);
            dbCR.CloseConnection();
        }

        public static void OBS_Missmatches(string PSCode, string LevelCode, int FKRace, int FKUser)
        {
            DBArchive dbCR = new DBArchive();
            dbCR.OpenConnection();
            dbCR.OBS_Missmatches(PSCode, LevelCode, FKRace, FKUser);
            dbCR.CloseConnection();
        }
        public static void p3_Insert_Into_ObrazacBrojnogStanjaUpdate(string PSCode, string LevelCode, int FKRace, int FKUser,
 int Box1, int Box2, int Box3, int Box4, int Box5, int Box6, int Box7, int Box8, int Box9, int Box10, int EntryNumber)
        {
            DBArchive dbDeleteOrgUnit = new DBArchive();
            dbDeleteOrgUnit.OpenConnection();
            dbDeleteOrgUnit.p3_Insert_Into_ObrazacBrojnogStanjaUpdate(PSCode, LevelCode, FKRace, FKUser,
 Box1, Box2, Box3, Box4, Box5, Box6, Box7, Box8, Box9, Box10, EntryNumber);
            dbDeleteOrgUnit.CloseConnection();
        }
        public static DataSet p3_GetScannedVotersForClerkID(string psBag, int clerk)
        {
            DBArchive dbCR = new DBArchive();
            dbCR.OpenConnection();
            DataSet ds = dbCR.p3_GetScannedVotersForClerkID(psBag, clerk);
            dbCR.CloseConnection();
            return ds;
        }
        public static void p3_UpdateToleranceForPSValidation(int race, string level, double tolerance, int user, string PSCode)
        {
            DBArchive dbDeleteOrgUnit = new DBArchive();
            dbDeleteOrgUnit.OpenConnection();
            dbDeleteOrgUnit.p3_UpdateToleranceForPSValidation(race, level, tolerance, user, PSCode);
            dbDeleteOrgUnit.CloseConnection();
        }
        public static void p3_UpdateToleranceForPSValidation(int race, string level, double tolerance, int user, string PSCode, string decision)
        {
            DBArchive dbDeleteOrgUnit = new DBArchive();
            dbDeleteOrgUnit.OpenConnection();
            dbDeleteOrgUnit.p3_UpdateToleranceForPSValidation(race, level, tolerance, user, PSCode, decision);
            dbDeleteOrgUnit.CloseConnection();
        }
        public static void p3_UpdateLockForPSValidation(int race, string level, int user, string PSCode)
        {
            DBArchive dbDeleteOrgUnit = new DBArchive();
            dbDeleteOrgUnit.OpenConnection();
            dbDeleteOrgUnit.p3_UpdateLockForPSValidation(race, level, user, PSCode);
            dbDeleteOrgUnit.CloseConnection();
        }
        public static void p3_UpdateUnlockForPSValidation(int race, string level, int user, string PSCode)
        {
            DBArchive dbDeleteOrgUnit = new DBArchive();
            dbDeleteOrgUnit.OpenConnection();
            dbDeleteOrgUnit.p3_UpdateUnlockForPSValidation(race, level, user, PSCode);
            dbDeleteOrgUnit.CloseConnection();
        }


        public static void ResultsValidation_CheckPSsForValidationForRace(int race)
        {
            DBArchive dbCR = new DBArchive();
            dbCR.OpenConnection();
            dbCR.ResultsValidation_CheckPSsForValidationForRace(race);
            dbCR.CloseConnection();
        }



        public static void ResultsValidation_ValidatePSForRace(string psCode, int race)
        {
            DBArchive dbCR = new DBArchive();
            dbCR.OpenConnection();
            dbCR.ResultsValidation_ValidatePSForRace(psCode, race);
            dbCR.CloseConnection();
        }


        public static void ResultsValidation_CheckPSsForValidationForRaceMEC(int race, int user)
        {
            DBArchive dbCR = new DBArchive();
            dbCR.OpenConnection();
            dbCR.ResultsValidation_CheckPSsForValidationForRaceMEC(race, user);
            dbCR.CloseConnection();
        }
        public static void ResultsValidation_ValidatePSForRaceMEC(string psCode, int race)
        {
            DBArchive dbCR = new DBArchive();
            dbCR.OpenConnection();
            dbCR.ResultsValidation_ValidatePSForRaceMEC(psCode, race);
            dbCR.CloseConnection();
        }
        //public static DataSet p3_InsertIntoVotesCast(string jmb, int clerk, string psBag, bool suspicious, string document)
        public static DataSet p3_InsertIntoVotesCast(string jmb, int clerk, string psBag, bool suspicious)
        {
            DBArchive dbCR = new DBArchive();
            dbCR.OpenConnection();
            //DataSet ds = dbCR.p3_InsertIntoVotesCast(jmb, clerk, psBag, suspicious, document);
            DataSet ds = dbCR.p3_InsertIntoVotesCast(jmb, clerk, psBag, suspicious);
            dbCR.CloseConnection();
            return ds;
        }

        public static int p3_getScannedVotesByMail(string bag)
        {
            DBArchive dbCR = new DBArchive();
            dbCR.OpenConnection();
            int i = dbCR.p3_getScannedVotesByMail(bag);
            dbCR.CloseConnection();
            return i;
        }


        public static void p3_insertOtherMaterialsFromShipment(int ShipmentNumber, string Type, int Value, int userID)
        {
            DBArchive dbDeleteOrgUnit = new DBArchive();
            dbDeleteOrgUnit.OpenConnection();
            dbDeleteOrgUnit.p3_insertOtherMaterialsFromShipment(ShipmentNumber, Type, Value, userID);
            dbDeleteOrgUnit.CloseConnection();
        }


        // 24 08 2010 elena
        public static void p3_UpdateMandatesPartiesAlocation158(int race, string levelCode)
        {
            DBArchive dbDeleteOrgUnit = new DBArchive();
            dbDeleteOrgUnit.OpenConnection();
            dbDeleteOrgUnit.p3_UpdateMandatesPartiesAlocation158(race, levelCode);
            dbDeleteOrgUnit.CloseConnection();
        }
        public static void p3_AllocationPartiesCoeficient(int race, string level)
        {
            DBArchive dbDeleteOrgUnit = new DBArchive();
            dbDeleteOrgUnit.OpenConnection();
            dbDeleteOrgUnit.p3_AllocationPartiesCoeficient(race, level);
            dbDeleteOrgUnit.CloseConnection();
        }
        public static void p3_getCandidatesMandates157(int FKRace, string LevelCode, int parties)
        {
            DBArchive dbDeleteOrgUnit = new DBArchive();
            dbDeleteOrgUnit.OpenConnection();
            dbDeleteOrgUnit.p3_getCandidatesMandates157(FKRace, LevelCode, parties);
            dbDeleteOrgUnit.CloseConnection();
        }
        public static DataSet p3_getTotalMandates(int race, string level)
        {
            DBArchive dbCR = new DBArchive();
            dbCR.OpenConnection();
            DataSet ds = dbCR.p3_getTotalMandates(race, level);
            dbCR.CloseConnection();
            return ds;
        }
        public static void p3_GetUpdateAlocation(int FKRace, string level, int parties, double kolicnik, string comment)
        {
            DBArchive dbDeleteOrgUnit = new DBArchive();
            dbDeleteOrgUnit.OpenConnection();
            dbDeleteOrgUnit.p3_GetUpdateAlocation(FKRace, level, parties, kolicnik, comment);
            dbDeleteOrgUnit.CloseConnection();
        }


        public static void p3_GetUpdateAlocationCLEAR(int FKRace, string level)
        {
            DBArchive dbDeleteOrgUnit = new DBArchive();
            dbDeleteOrgUnit.OpenConnection();
            dbDeleteOrgUnit.p3_GetUpdateAlocationCLEAR(FKRace, level);
            dbDeleteOrgUnit.CloseConnection();
        }
        public static void p3_CountUpdateAlocation(int FKRace, string level, int parties)
        {
            DBArchive dbDeleteOrgUnit = new DBArchive();
            dbDeleteOrgUnit.OpenConnection();
            dbDeleteOrgUnit.p3_CountUpdateAlocation(FKRace, level, parties);
            dbDeleteOrgUnit.CloseConnection();
        }
        public static DataSet p3_getPatiiteUpdateAlocation(int race, string level)
        {
            DBArchive dbCR = new DBArchive();
            dbCR.OpenConnection();
            DataSet ds = dbCR.p3_getPatiiteUpdateAlocation(race, level);
            dbCR.CloseConnection();
            return ds;
        }
        public static DataSet p3_getTotalCompensatory(int race, string level)
        {
            DBArchive dbCR = new DBArchive();
            dbCR.OpenConnection();
            DataSet ds = dbCR.p3_getTotalCompensatory(race, level);
            dbCR.CloseConnection();
            return ds;
        }
        public static void p3_GetUpdateAlocationCompensatoryCLEAR(int FKRace, string level)
        {
            DBArchive dbDeleteOrgUnit = new DBArchive();
            dbDeleteOrgUnit.OpenConnection();
            dbDeleteOrgUnit.p3_GetUpdateAlocationCompensatoryCLEAR(FKRace, level);
            dbDeleteOrgUnit.CloseConnection();
        }

        public static void p3_GetUpdateAlocationCompensatory(int FKRace, string level, int parties, double kolicnik, string comment)
        {
            DBArchive dbDeleteOrgUnit = new DBArchive();
            dbDeleteOrgUnit.OpenConnection();
            dbDeleteOrgUnit.p3_GetUpdateAlocationCompensatory(FKRace, level, parties, kolicnik, comment);
            dbDeleteOrgUnit.CloseConnection();
        }


        public static DataSet p3_getPatiiteUpdateAlocationCompensatory(int race, string level)
        {
            DBArchive dbCR = new DBArchive();
            dbCR.OpenConnection();
            DataSet ds = dbCR.p3_getPatiiteUpdateAlocationCompensatory(race, level);
            dbCR.CloseConnection();
            return ds;
        }
        public static void p3_CountUpdateAlocationCompensatory(int FKRace, string level, int parties)
        {
            DBArchive dbDeleteOrgUnit = new DBArchive();
            dbDeleteOrgUnit.OpenConnection();
            dbDeleteOrgUnit.p3_CountUpdateAlocationCompensatory(FKRace, level, parties);
            dbDeleteOrgUnit.CloseConnection();
        }
        public static void p3_AllocationPartiesCoeficientCompensatory(string level)
        {
            DBArchive dbDeleteOrgUnit = new DBArchive();
            dbDeleteOrgUnit.OpenConnection();
            dbDeleteOrgUnit.p3_AllocationPartiesCoeficientCompensatory(level);
            dbDeleteOrgUnit.CloseConnection();
        }

        public static DataSet TurnoutGetSummaryByRace(int race, int param)
        {
            DBArchive dbCR = new DBArchive();
            dbCR.OpenConnection();
            DataSet ds = dbCR.TurnoutGetSummaryByRace(race, param);
            dbCR.CloseConnection();
            return ds;
        }
        public static void p3_EditBags(int id, int totalEnv)
        {
            DBArchive dbDeleteOrgUnit = new DBArchive();
            dbDeleteOrgUnit.OpenConnection();
            dbDeleteOrgUnit.p3_EditBags(id, totalEnv);
            dbDeleteOrgUnit.CloseConnection();
        }

        public static void p3_EditOtherMaterials(int id, int totalEnv)
        {
            DBArchive dbDeleteOrgUnit = new DBArchive();
            dbDeleteOrgUnit.OpenConnection();
            dbDeleteOrgUnit.p3_EditOtherMaterials(id, totalEnv);
            dbDeleteOrgUnit.CloseConnection();
        }



        public static DataSet p3_getBoxNoOfBallotsSorted(string boxName, string levelCode)
        {
            DBArchive dbDeleteOrgUnit = new DBArchive();
            dbDeleteOrgUnit.OpenConnection();
            DataSet ds = dbDeleteOrgUnit.p3_getBoxNoOfBallotsSorted(boxName, levelCode);
            dbDeleteOrgUnit.CloseConnection();
            return ds;
        }
        public static DataSet p3_GetTotalParties(int race, int parija, string level)
        {
            DBArchive dbCR = new DBArchive();
            dbCR.OpenConnection();
            DataSet ds = dbCR.p3_GetTotalParties(race, parija, level);
            dbCR.CloseConnection();
            return ds;
        }

        public static void p3_UpdateManualAlocationCandidates(int kandidat)
        {
            DBArchive dbDeleteOrgUnit = new DBArchive();
            dbDeleteOrgUnit.OpenConnection();
            dbDeleteOrgUnit.p3_UpdateManualAlocationCandidates(kandidat);
            dbDeleteOrgUnit.CloseConnection();
        }
        public static void p3_UpdateManualAlocationCandidatesClear(int race, string level, int parties)
        {
            DBArchive dbDeleteOrgUnit = new DBArchive();
            dbDeleteOrgUnit.OpenConnection();
            dbDeleteOrgUnit.p3_UpdateManualAlocationCandidatesClear(race, level, parties);
            dbDeleteOrgUnit.CloseConnection();
        }


        public static DataSet p3_Check1Entry(int race, string pscode, int userLogged)
        {
            DBArchive dbCR = new DBArchive();
            dbCR.OpenConnection();
            DataSet ds = dbCR.p3_Check1Entry(race, pscode, userLogged);
            dbCR.CloseConnection();
            return ds;
        }

        public static DataSet p3_getIfEnteredEntry1_2_IntoOBS(int race, string pscode, string levelCode)
        {
            DBArchive dbCR = new DBArchive();
            dbCR.OpenConnection();
            DataSet ds = dbCR.p3_getIfEnteredEntry1_2_IntoOBS(race, pscode, levelCode);
            dbCR.CloseConnection();
            return ds;
        }


        public static DataSet p3_GetTotalPartiesCompensatory(int parija, string level)
        {
            DBArchive dbCR = new DBArchive();
            dbCR.OpenConnection();
            DataSet ds = dbCR.p3_GetTotalPartiesCompensatory(parija, level);
            dbCR.CloseConnection();
            return ds;
        }


        public static void p3_UpdateManualAlocationCandidatesCompensatory(int kandidat)
        {
            DBArchive dbDeleteOrgUnit = new DBArchive();
            dbDeleteOrgUnit.OpenConnection();
            dbDeleteOrgUnit.p3_UpdateManualAlocationCandidatesCompensatory(kandidat);
            dbDeleteOrgUnit.CloseConnection();
        }



        public static void p3_UpdateManualAlocationCandidatesClearCompensatory(string level, int parties)
        {
            DBArchive dbDeleteOrgUnit = new DBArchive();
            dbDeleteOrgUnit.OpenConnection();
            dbDeleteOrgUnit.p3_UpdateManualAlocationCandidatesClearCompensatory(level, parties);
            dbDeleteOrgUnit.CloseConnection();
        }


        public static string Tracking_Results_GetLevelForRaceANDCombination(string kom, int race)
        {
            DBArchive dbDeleteOrgUnit = new DBArchive();
            dbDeleteOrgUnit.OpenConnection();
            string name = dbDeleteOrgUnit.Tracking_Results_GetLevelForRaceANDCombination(kom, race);
            dbDeleteOrgUnit.CloseConnection();
            return name;
        }

        public static int RESULTSGetIdListForNationalMinority(string MunReg)
        {
            DBArchive dbNewsName = new DBArchive();
            dbNewsName.OpenConnection();
            int name = dbNewsName.RESULTSGetIdListForNationalMinority(MunReg);
            dbNewsName.CloseConnection();
            return name;
        }


        public static DataSet p3getEntriesArchiveItemsTracking(string PSNumber, int FKCandidacyRace, string LevelCode, int status)
        {
            DBArchive dbNewsName = new DBArchive();
            dbNewsName.OpenConnection();
            DataSet name = dbNewsName.p3getEntriesArchiveItemsTracking(PSNumber, FKCandidacyRace, LevelCode, status);
            dbNewsName.CloseConnection();
            return name;
        }


        public static DataSet p3getPSStatisticEntryTracking(string pscode, string level, int race, int entry)
        {
            DBArchive dbCR = new DBArchive();
            dbCR.OpenConnection();
            DataSet dsCR = dbCR.p3getPSStatisticEntryTracking(pscode, level, race, entry);
            dbCR.CloseConnection();
            return dsCR;
        }


        public static DataSet RESULTSLevelGetNameForCodeTracking(string Code, int idrace)
        {
            DBArchive dbCR = new DBArchive();
            dbCR.OpenConnection();
            DataSet dsCR = dbCR.RESULTSLevelGetNameForCodeTracking(Code, idrace);
            dbCR.CloseConnection();
            return dsCR;
        }


        public static DataSet RESULTSLevelGetLevelForCOmbinationTracking(string Code, int idrace)
        {
            DBArchive dbCR = new DBArchive();
            dbCR.OpenConnection();
            DataSet dsCR = dbCR.RESULTSLevelGetLevelForCOmbinationTracking(Code, idrace);
            dbCR.CloseConnection();
            return dsCR;
        }


        //public static DataSet p3_InsertIntoVotesCastUnconfirmed(string jmb, int clerk, string psBag, string firstName, string lastName, string birthDate, bool suspicious, string document)
       public static DataSet p3_InsertIntoVotesCastUnconfirmed(string jmb, int clerk, string psBag, string firstName, string lastName, string birthDate, bool suspicious)
        {
            DBArchive dbCR = new DBArchive();
            dbCR.OpenConnection();
            DataSet ds = dbCR.p3_InsertIntoVotesCastUnconfirmed(jmb, clerk, psBag, firstName, lastName, birthDate, suspicious);
            dbCR.CloseConnection();
            return ds;
        }



        public static string Results_GetLevelForRaceANDMun(int race, string mun)
        {
            DBArchive dbDeleteOrgUnit = new DBArchive();
            dbDeleteOrgUnit.OpenConnection();
            string name = dbDeleteOrgUnit.Results_GetLevelForRaceANDMun(race, mun);
            dbDeleteOrgUnit.CloseConnection();
            return name;
        }


        public static int OBS_CheckStatusForEntry(int race, string psCode)
        {
            DBArchive gel = new DBArchive();
            gel.OpenConnection();
            int name = gel.OBS_CheckStatusForEntry(race, psCode);
            gel.CloseConnection();
            return name;
        }


        public static DataSet p3_getScannedCountByClerk(string psBag, int clerk)
        {
            DBArchive dbDeleteOrgUnit = new DBArchive();
            dbDeleteOrgUnit.OpenConnection();
            DataSet ds = dbDeleteOrgUnit.p3_getScannedCountByClerk(psBag, clerk);
            dbDeleteOrgUnit.CloseConnection();
            return ds;
        }


        public static DataSet ResultsValidation_GetItemsForParametarsCEC(int race, int type, string psCode)
        {
            DBArchive dbDeleteOrgUnit = new DBArchive();
            dbDeleteOrgUnit.OpenConnection();
            DataSet ds = dbDeleteOrgUnit.ResultsValidation_GetItemsForParametarsCEC(race, type, psCode);
            dbDeleteOrgUnit.CloseConnection();
            return ds;
        }


        public static DataSet ResultsValidation_GetTotalVotesForItem7(int race, string psCode)
        {
            DBArchive dbDeleteOrgUnit = new DBArchive();
            dbDeleteOrgUnit.OpenConnection();
            DataSet ds = dbDeleteOrgUnit.ResultsValidation_GetTotalVotesForItem7(race, psCode);
            dbDeleteOrgUnit.CloseConnection();
            return ds;
        }


        public static void ResultsValidation_UpdateItemsToValid(string psCode, int race, int type)
        {
            DBArchive gel = new DBArchive();
            gel.OpenConnection();
            gel.ResultsValidation_UpdateItemsToValid(psCode, race, type);
            gel.CloseConnection();
        }

        public static DataSet p3_CheckZeroCount()
        {
            DBArchive dbDeleteOrgUnit = new DBArchive();
            dbDeleteOrgUnit.OpenConnection();
            DataSet ds = dbDeleteOrgUnit.p3_CheckZeroCount();
            dbDeleteOrgUnit.CloseConnection();
            return ds;
        }
        public static void p3DeleteCecMessages(int id)
        {
            DBArchive dbDeleteOrgUnit = new DBArchive();
            dbDeleteOrgUnit.OpenConnection();
            dbDeleteOrgUnit.p3DeleteCecMessages(id);
            dbDeleteOrgUnit.CloseConnection();
        }

        //public static DataSet p3_InsertIntoVotesCastMobilni(string jmb, int clerk, string psBag, string firstName, string lastName, string birthDate, string potpis, bool suspicious, string document)
        public static DataSet p3_InsertIntoVotesCastMobilni(string jmb, int clerk, string psBag, string firstName, string lastName, string birthDate, string potpis, bool suspicious)
 
        {
            DBArchive dbCR = new DBArchive();
            dbCR.OpenConnection();
            DataSet ds = dbCR.p3_InsertIntoVotesCastMobilni(jmb, clerk, psBag, firstName, lastName, birthDate, potpis, suspicious);
            dbCR.CloseConnection();
            return ds;
        }

        //public static DataSet p3_InsertIntoVotesCastOdsustvo(string jmb, int clerk, string psBag, bool suspicious, string document)
        public static DataSet p3_InsertIntoVotesCastOdsustvo(string jmb, int clerk, string psBag, bool suspicious)
        {
            DBArchive dbCR = new DBArchive();
            dbCR.OpenConnection();
            DataSet ds = dbCR.p3_InsertIntoVotesCastOdsustvo(jmb, clerk, psBag, suspicious);
            dbCR.CloseConnection();
            return ds;
        }
        //public static DataSet p3_InsertIntoVotesCastDKP(string jmb, int clerk, string psBag, bool suspicious, string document)
        public static DataSet p3_InsertIntoVotesCastDKP(string jmb, int clerk, string psBag, bool suspicious)
        {
            DBArchive dbCR = new DBArchive();
            dbCR.OpenConnection();
            DataSet ds = dbCR.p3_InsertIntoVotesCastDKP(jmb, clerk, psBag, suspicious);
            dbCR.CloseConnection();
            return ds;
        }

        public static DataSet p3GetUserByPosition(int langID, string param)
        {
            DBArchive dbCR = new DBArchive();
            dbCR.OpenConnection();
            DataSet ds = dbCR.p3GetUserByPosition(langID, param);
            dbCR.CloseConnection();
            return ds;
        }
        public static void WEBAdmin_GenerateForParamANDLevel(int param, int race, string level)
        {
            DBArchive gel = new DBArchive();
            gel.OpenConnection();
            gel.WEBAdmin_GenerateForParamANDLevel(param, race, level);
            gel.CloseConnection();
        }

        public static void WEBRESULTS_GeneratePreliminary(int userID, int race, string level)
        {
            DBArchive dbCR = new DBArchive();
            dbCR.OpenConnection();
            dbCR.WEBRESULTS_GeneratePreliminary(userID, race, level);
            dbCR.CloseConnection();
        }
        public static void WEBRESULTS_GeneratePreliminaryEntry5(int userID, int race, string level)
        {
            DBArchive dbCR = new DBArchive();
            dbCR.OpenConnection();
            dbCR.WEBRESULTS_GeneratePreliminaryEntry5(userID, race, level);
            dbCR.CloseConnection();
        }


        public static void WebGenerateResultsGEN(int userID, int race, string level)
        {
            DBArchive dbCR = new DBArchive();
            dbCR.OpenConnection();
            dbCR.WebGenerateResultsGEN(userID, race, level);
            dbCR.CloseConnection();
        }


        public static string GetMunCodeForPS(string pscode)
        {
            DBArchive dbDeleteOrgUnit = new DBArchive();
            dbDeleteOrgUnit.OpenConnection();
            string name = dbDeleteOrgUnit.GetMunCodeForPS(pscode);
            dbDeleteOrgUnit.CloseConnection();
            return name;
        }

        public static DataSet p3GetMessagesCEC(int user, string param)
        {
            DBArchive dbCR = new DBArchive();
            dbCR.OpenConnection();
            DataSet ds = dbCR.p3GetMessagesCEC(user, param);
            dbCR.CloseConnection();
            return ds;
        }


        public static int p3_getNoEnvInBagForCombination(string psBag, string combination)
        {
            DBArchive gel = new DBArchive();
            gel.OpenConnection();
            int rowsErrors = gel.p3_getNoEnvInBagForCombination(psBag, combination);
            gel.CloseConnection();
            return rowsErrors;
        }



        public static void p3_UpdateBagStatusPost(string psBag, int bagStatus)
        {
            DBArchive gel = new DBArchive();
            gel.OpenConnection();
            gel.p3_UpdateBagStatusPost(psBag, bagStatus);
            gel.CloseConnection();
        }


        public static int p3_GetIfShipmentExists(int shipmentnumber)
        {
            DBArchive gel = new DBArchive();
            gel.OpenConnection();
            int rowsErrors = gel.p3_GetIfShipmentExists(shipmentnumber);
            gel.CloseConnection();
            return rowsErrors;
        }


        public static string RESULTSGetCandidatesForPEOLMissmatcesGetPartyName(int fklist)
        {
            DBArchive dbDeleteOrgUnit = new DBArchive();
            dbDeleteOrgUnit.OpenConnection();
            string name = dbDeleteOrgUnit.RESULTSGetCandidatesForPEOLMissmatcesGetPartyName(fklist);
            dbDeleteOrgUnit.CloseConnection();
            return name;
        }


        public static void NewValidation_InsertUpdateIntop3ValS(string pscode, int race, int param)
        {
            DBArchive gel = new DBArchive();
            gel.OpenConnection();
            gel.NewValidation_InsertUpdateIntop3ValS(pscode, race, param);
            gel.CloseConnection();
        }


        public static void NewValidationResultsValidation_ValidatePSForRace(string pscode, int race)
        {
            DBArchive gel = new DBArchive();
            gel.OpenConnection();
            gel.NewValidationResultsValidation_ValidatePSForRace(pscode, race);
            gel.CloseConnection();
        }

        public static void ValidatePSWithTolerance(string pscode, int race, int tt)
        {
            DBArchive gel = new DBArchive();
            gel.OpenConnection();
            gel.ValidatePSWithTolerance(pscode, race, tt);
            gel.CloseConnection();
        }

        public static int NewValidationCheckIFOKZR(string pscode, int race)
        {
            DBArchive gel = new DBArchive();
            gel.OpenConnection();
            int dali = gel.NewValidationCheckIFOKZR(pscode, race);
            gel.CloseConnection();
            return dali;
        }


        public static int NEWValidation_GetOBS5(string pscode, int race)
        {
            DBArchive gel = new DBArchive();
            gel.OpenConnection();
            int dali = gel.NEWValidation_GetOBS5(pscode, race);
            gel.CloseConnection();
            return dali;
        }


        public static void NEWValidation_EditOBS5(string pscode, int race, int value)
        {
            DBArchive gel = new DBArchive();
            gel.OpenConnection();
            gel.NEWValidation_EditOBS5(pscode, race, value);
            gel.CloseConnection();
        }


        public static void p3_GetUpdateAlocationStatus0(int FKRace, string level, int parties, double kolicnik, string comment)
        {
            DBArchive dbDeleteOrgUnit = new DBArchive();
            dbDeleteOrgUnit.OpenConnection();
            dbDeleteOrgUnit.p3_GetUpdateAlocationStatus0(FKRace, level, parties, kolicnik, comment);
            dbDeleteOrgUnit.CloseConnection();
        }
        public static DataSet p3getCountNationalityAllocation(string code)
        {
            DBArchive dbCR = new DBArchive();
            dbCR.OpenConnection();
            DataSet ds = dbCR.p3getCountNationalityAllocation(code);
            dbCR.CloseConnection();
            return ds;
        }
        public static DataSet AllocationGetNationalitisBoHrSr(string level)
        {
            DBArchive dbCR = new DBArchive();
            dbCR.OpenConnection();
            DataSet ds = dbCR.AllocationGetNationalitisBoHrSr(level);
            dbCR.CloseConnection();
            return ds;
        }
        public static DataSet AllocationGetNationalitisForAlarm(string level)
        {
            DBArchive dbCR = new DBArchive();
            dbCR.OpenConnection();
            DataSet ds = dbCR.AllocationGetNationalitisForAlarm(level);
            dbCR.CloseConnection();
            return ds;
        }
        public static void p3_GetUpdateAlocationCompensatoryStatus0(int FKRace, string level, int parties, double kolicnik, string comment)
        {
            DBArchive dbDeleteOrgUnit = new DBArchive();
            dbDeleteOrgUnit.OpenConnection();
            dbDeleteOrgUnit.p3_GetUpdateAlocationCompensatoryStatus0(FKRace, level, parties, kolicnik, comment);
            dbDeleteOrgUnit.CloseConnection();
        }
        public static DataSet p3_getCandidateFinalMandate(int race, string level, int partii, int finalpe)
        {
            DBArchive dbCR = new DBArchive();
            dbCR.OpenConnection();
            DataSet ds = dbCR.p3_getCandidateFinalMandate(race, level, partii, finalpe);
            dbCR.CloseConnection();
            return ds;
        }



        /////// ACE 29 09 

        public static int RESULTSGetCandidatesListIDForCandidate(int candID)
        {
            DBArchive dbNewsName = new DBArchive();
            dbNewsName.OpenConnection();
            int name = dbNewsName.RESULTSGetCandidatesListIDForCandidate(candID);
            dbNewsName.CloseConnection();
            return name;
        }


        public static void WEBAdminMandatesGenerate(int race, string level)
        {
            DBArchive dbCR = new DBArchive();
            dbCR.OpenConnection();
            dbCR.WEBAdminMandatesGenerate(race, level);
            dbCR.CloseConnection();
        }

        public static void p3_updateBagStatusOneStepBack(string psCode, string bagStatus)
        {
            DBArchive dbCR = new DBArchive();
            dbCR.OpenConnection();
            dbCR.p3_updateBagStatusOneStepBack(psCode, bagStatus);
            dbCR.CloseConnection();
        }

        public static DataSet p3_getNumberOfScannedVoters(string psBag)
        {
            DBArchive dbCR = new DBArchive();
            dbCR.OpenConnection();
            DataSet ds = dbCR.p3_getNumberOfScannedVoters(psBag);
            dbCR.CloseConnection();
            return ds;
        }

        public static DataSet dms_getAllAppruvedUsers(int language, string param)
        {
            DBArchive dbCR = new DBArchive();
            dbCR.OpenConnection();
            DataSet ds = dbCR.dms_getAllAppruvedUsers(language, param);
            dbCR.CloseConnection();
            return ds;
        }

        public static void VFEValidateForRace(int race)
        {
            DBArchive gel = new DBArchive();
            gel.OpenConnection();
            gel.VFEValidateForRace(race);
            gel.CloseConnection();
        }

        public static DataSet ProcedureForGeneralReportOpenClose()
        {
            DBArchive dbCR = new DBArchive();
            dbCR.OpenConnection();
            DataSet ds = dbCR.ProcedureForGeneralReportOpenClose();
            dbCR.CloseConnection();
            return ds;
        }
        public static DataSet ProcedureForGeneralReportTurnout(int param)
        {
            DBArchive dbCR = new DBArchive();
            dbCR.OpenConnection();
            DataSet ds = dbCR.ProcedureForGeneralReportTurnout(param);
            dbCR.CloseConnection();
            return ds;
        }

        public static void p3_EditFormedBoxes(int totalEnvelopes, int Id)
        {
            DBArchive dbDeleteOrgUnit = new DBArchive();
            dbDeleteOrgUnit.OpenConnection();
            dbDeleteOrgUnit.p3_EditFormedBoxes(totalEnvelopes, Id);
            dbDeleteOrgUnit.CloseConnection();
        }



        // 12 10 2010
        public static int AfterGetTotalVotesForLevelCompensation(string level)
        {
            DBArchive dbNewsName = new DBArchive();
            dbNewsName.OpenConnection();
            int name = dbNewsName.AfterGetTotalVotesForLevelCompensation(level);
            dbNewsName.CloseConnection();
            return name;
        }



        public static DataSet MENIGetPagesForRank(int rank, int lang)
        {
            DBArchive dbDeleteOrgUnit = new DBArchive();
            dbDeleteOrgUnit.OpenConnection();
            DataSet name = dbDeleteOrgUnit.MENIGetPagesForRank(rank, lang);
            dbDeleteOrgUnit.CloseConnection();
            return name;
        }
        public static DataSet oktomvriIDpagePosition(int id, int rank)
        {
            DBArchive dbCR = new DBArchive();
            dbCR.OpenConnection();
            DataSet ds = dbCR.oktomvriIDpagePosition(id,rank);
            dbCR.CloseConnection();
            return ds;
        }
        public static void p3_inseretIntoDeletedPSBAGS(string psCode, int FKRace, string comment, DateTime datetime, int fkuser, int FKStatus)
        {
            DBArchive dbDeleteOrgUnit = new DBArchive();
            dbDeleteOrgUnit.OpenConnection();
            dbDeleteOrgUnit.p3_inseretIntoDeletedPSBAGS(psCode,FKRace, comment, datetime, fkuser, FKStatus);
            dbDeleteOrgUnit.CloseConnection();
        }


        ///////////////////////// 01 11 2010 /////////////////////////////

        public static void NewValidationMEC_ResultsValidation_ValidatePSForRace(string pscode, int race)
        {
            DBArchive dbDeleteOrgUnit = new DBArchive();
            dbDeleteOrgUnit.OpenConnection();
            dbDeleteOrgUnit.NewValidationMEC_ResultsValidation_ValidatePSForRace(pscode, race);
            dbDeleteOrgUnit.CloseConnection();
        }

        public static void NewValidationMEC_insertIntoPSVal(string pscode, int race, string munCode)
        {
            DBArchive dbDeleteOrgUnit = new DBArchive();
            dbDeleteOrgUnit.OpenConnection();
            dbDeleteOrgUnit.NewValidationMEC_insertIntoPSVal(pscode, race, munCode);
            dbDeleteOrgUnit.CloseConnection();
        }


        //public static bool p3_GetPsCodeFromObrazec1Mun(string PSCode, int FKRace)
        //{
        //    DBArchive gel = new DBArchive();
        //    gel.OpenConnection();
        //    bool name1 = gel.p3_GetPsCodeFromObrazec1Mun(PSCode, FKRace);
        //    gel.CloseConnection();
        //    return name1;
        //}


        public static bool p3_GetPsCodeFromObrazec1Mun(string PSCode, int FKRace)
        {
            DBArchive gel = new DBArchive();
            gel.OpenConnection();
            bool name1 = gel.p3_GetPsCodeFromObrazec1Mun(PSCode, FKRace);
            gel.CloseConnection();
            return name1;
        }


        public static DataSet p3_getBagDetailsForEdit(string psBag)
        {
            DBArchive dbCR = new DBArchive();
            dbCR.OpenConnection();
            DataSet ds = dbCR.p3_getBagDetailsForEdit(psBag);
            dbCR.CloseConnection();
            return ds;
        }

        public static void p3_updateBagDetails(int TotalReceivedEnvelopes, int VerificationReceived,
            int VerificationAccepted, int VerificationRejected, int BeforeVerificationApproved,
            int BeforeVerificationRejected, string psBag, string bagStatus)
        {
            DBArchive dbCR = new DBArchive();
            dbCR.OpenConnection();
            dbCR.p3_updateBagDetails(TotalReceivedEnvelopes, VerificationReceived, VerificationAccepted,
                VerificationRejected, BeforeVerificationApproved, BeforeVerificationRejected, psBag, bagStatus);
            dbCR.CloseConnection();
        }

        public static DataSet p3_getBoxForEdit(string boxName)
        {
            DBArchive dbCR = new DBArchive();
            dbCR.OpenConnection();
            DataSet ds = dbCR.p3_getBoxForEdit(boxName);
            dbCR.CloseConnection();
            return ds;
        }

        //Nedim
        public static DataSet p3_getBoxDetailForEdit(string boxName, string levelCode)
        {
            DBArchive dbCR = new DBArchive();
            dbCR.OpenConnection();
            DataSet ds = dbCR.p3_getBoxDetailForEdit(boxName, levelCode);
            dbCR.CloseConnection();
            return ds;
        }

        public static void p3_updateBox(int TotalNoOfEnvelopes, int RejectedInSorting, string boxName, string boxStatus)
        {
            DBArchive dbCR = new DBArchive();
            dbCR.OpenConnection();
            dbCR.p3_updateBox(TotalNoOfEnvelopes, RejectedInSorting, boxName, boxStatus);
            dbCR.CloseConnection();
        }

        public static void p3_updateBoxDetail(int id, int NoOfBallotsSorted, int NoOfBallotsCounted,
            int NoOfValidBallots, int NoOfInvalidBallots)
        {
            DBArchive dbCR = new DBArchive();
            dbCR.OpenConnection();
            dbCR.p3_updateBoxDetail(id, NoOfBallotsSorted, NoOfBallotsCounted,
                NoOfValidBallots, NoOfInvalidBallots);
            dbCR.CloseConnection();
        }

        public static void p3_updateBagDetail(int id, int NoOfEnvelopes, int NoOfSignatures,
                    int NoOfEnvelopesCounted, int Difference)
        {
            DBArchive dbCR = new DBArchive();
            dbCR.OpenConnection();
            dbCR.p3_updateBagDetail(id, NoOfEnvelopes, NoOfSignatures, NoOfEnvelopesCounted, Difference);
            dbCR.CloseConnection();
        }

        public static bool p3_GetPsCodeFromObrazecM(string PSCode, int FKRace)
        {
            DBArchive gel = new DBArchive();
            gel.OpenConnection();
            bool name1 = gel.p3_GetPsCodeFromObrazecM(PSCode, FKRace);
            gel.CloseConnection();
            return name1;
        }


        public static DataSet NEWGetLogoTextForElection(int param)
        {
            DBArchive dbCR = new DBArchive();
            dbCR.OpenConnection();
            DataSet ds = dbCR.NEWGetLogoTextForElection(param);
            dbCR.CloseConnection();
            return ds;
        }



        ////////////////// 04 11 2010 ///////////

        public static void WEBRESULTS_GeneratePreliminaryLocal(int userID, int race, string level)
        {
            DBArchive dbCR = new DBArchive();
            dbCR.OpenConnection();
            dbCR.WEBRESULTS_GeneratePreliminaryLocal(userID, race, level);
            dbCR.CloseConnection();
        }


        public static void WEBRESULTS_GeneratePreliminaryEntry5Local(int userID, int race, string level)
        {
            DBArchive dbCR = new DBArchive();
            dbCR.OpenConnection();
            dbCR.WEBRESULTS_GeneratePreliminaryEntry5Local(userID, race, level);
            dbCR.CloseConnection();
        }

        public static void GenerateRegStatByCombination(int race)
        {
            DBArchive dbCR = new DBArchive();
            dbCR.OpenConnection();
            dbCR.GenerateRegStatByCombination(race);
            dbCR.CloseConnection();
        }

        public static bool p3_If_1_2_AreActive()
        {
            DBArchive gel = new DBArchive();
            gel.OpenConnection();
            bool name1 = gel.p3_If_1_2_AreActive();
            gel.CloseConnection();
            return name1;
        }


        public static void web_PreliminaryImportByRaceLevelLocal(int race, int param, string level)
        {
            DBArchive dbCR = new DBArchive();
            dbCR.OpenConnection();
            dbCR.web_PreliminaryImportByRaceLevelLocal(race, param, level);
            dbCR.CloseConnection();
        }



        public static void web_FinalImportByRaceLevelLocal(int race, int param, string level)
        {
            DBArchive dbCR = new DBArchive();
            dbCR.OpenConnection();
            dbCR.web_FinalImportByRaceLevelLocal(race, param, level);
            dbCR.CloseConnection();
        }


        public static void XMLImportFromMEC(string path1)
        {
            DBArchive dbCR = new DBArchive();
            dbCR.OpenConnection();
            dbCR.XMLImportFromMEC(path1);
            dbCR.CloseConnection();
        }

        public static void ImportFromBallotOrder(string Sifra, string RedniBroj)
        {
            DBArchive dbCR = new DBArchive();
            dbCR.OpenConnection();
            dbCR.ImportFromBallotOrder(Sifra, RedniBroj);
            dbCR.CloseConnection();
        }

        public static DataSet oktomvri_getResurs(int lan, int pageid)
        {
            DBArchive dbCR = new DBArchive();
            dbCR.OpenConnection();
            DataSet ds = dbCR.oktomvri_getResurs(lan,pageid);
            dbCR.CloseConnection();
            return ds;
        }
        public static DataSet p2_GetAllActiveCandidacyRaceForBallots()
        {
            DBArchive gel = new DBArchive();
            gel.OpenConnection();
            DataSet name1 = gel.p2_GetAllActiveCandidacyRaceForBallots();
            gel.CloseConnection();
            return name1;
        }

        public static void p2_insertZipPath(string zipPath)
        {
            DBArchive gel = new DBArchive();
            gel.OpenConnection();
            gel.p2_insertZipPath(zipPath);
            gel.CloseConnection();
        }

        public static string p2_getZipPath()
        {
            DBArchive gel = new DBArchive();
            gel.OpenConnection();
            string name1 = gel.p2_getZipPath();
            gel.CloseConnection();
            return name1;
        }

        public static DataSet p2_GetAllActiveLevelsForCandidacyRace(int race)
        {
            DBArchive gel = new DBArchive();
            gel.OpenConnection();
            DataSet name1 = gel.p2_GetAllActiveLevelsForCandidacyRace(race);
            gel.CloseConnection();
            return name1;
        }

        public static DataSet p2_getCandidatesMayor(int race, int level)
        {
            DBArchive gel = new DBArchive();
            gel.OpenConnection();
            DataSet name1 = gel.p2_getCandidatesMayor(race, level);
            gel.CloseConnection();
            return name1;
        }

        public static DataSet p2_checkNacManjine(int level)
        {
            DBArchive gel = new DBArchive();
            gel.OpenConnection();
            DataSet name1 = gel.p2_checkNacManjine(level);
            gel.CloseConnection();
            return name1;
        }
     
        public static DataSet BGetAllActiveCandidacyRace()
        {
            DBArchive gel = new DBArchive();
            gel.OpenConnection();
            DataSet name1 = gel.BGetAllActiveCandidacyRace();
            gel.CloseConnection();
            return name1;
        }
        public static string BBackupPrefinal(int id, string jmb, int UserChangedID)
        {
            DBArchive gel = new DBArchive();
            gel.OpenConnection();
            string name1 = gel.BBackupPrefinal(id, jmb, UserChangedID);
            gel.CloseConnection();
            return name1;
        } 
        internal static string updateUserPassword(int userId, string password)
        {
            DBArchive gel = new DBArchive();
            gel.OpenConnection();
            string name1 = gel.updateUserPassword(userId, password);
            gel.CloseConnection();
            return name1;
        }
        internal static int updateUserNeedReset(int userId, short resetState)
        {
            string connStr = ConfigurationManager.ConnectionStrings["BVOTEConnectionString"].ConnectionString;
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();
            SqlCommand cmd = new SqlCommand("updateUserNeedReset", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@userId", SqlDbType.Int).Value = userId;
            cmd.Parameters.Add("@needReset", SqlDbType.Bit).Value = resetState;
    
            int i = cmd.ExecuteNonQuery();
            conn.Close();
            return i;
        }
        internal static string P3_copyentry1toentry2(int levelCode, int raceID,string PS, int userID)
        {
            DBArchive gel = new DBArchive();
            gel.OpenConnection();
            string result = gel.P3_copyentry1toentry2(levelCode, raceID,PS, userID);
            gel.CloseConnection();
            return result;
        }
          internal static string P3_repeatCounting(int raceID,int levelCode,string PS,string decicion, int userID)
        {
            DBArchive gel = new DBArchive();
            gel.OpenConnection();
            string result = gel.P3_repeatCounting(raceID, levelCode,PS, decicion,userID);
            gel.CloseConnection();
            return result;
        }
          internal static void BDeleteBallotLogs()
          {
              DBArchive gel = new DBArchive();
              gel.OpenConnection();
              gel.BDeleteBallotLogs();
              gel.CloseConnection();
          }
          internal static DataSet BGetBallotLogs()
          {
              DBArchive gel = new DBArchive();
              gel.OpenConnection();
              DataSet result = gel.BGetBallotLogs();
              gel.CloseConnection();
              return result;
          }

          public static object ManualAllocation(int id, string ElCode, int param, int user)
          {
              DBArchive gel = new DBArchive();
              gel.OpenConnection();
              object result = gel.ManualAllocation(id, ElCode, param, user);
              gel.CloseConnection();
              return result;
          }

          public static DataSet P4FindCandidateImpl(string codeE, string jmb, string codeP, string codeL)
          {
              DBArchive dbCR = new DBArchive();
              dbCR.OpenConnection();
              DataSet ds = dbCR.p4ps_getCandidateFromMandates(codeE, jmb, codeP, codeL);
              dbCR.CloseConnection();
              return ds;
          }
          public static DataSet BGetAllActiveCandidacyRaceForMand(string Election)
          {
              DataSet ds = new DataSet();
              DBArchive gel = new DBArchive();
              gel.OpenConnection();
              ds = gel.BGetAllActiveCandidacyRaceForMand(Election);
              gel.CloseConnection();
              return ds;

          }
       
          public static DataSet getNextCCMandateByJMBG(string jmbg, string ElectionCode, int ListCode, string ListName, string LevelCode, string LevelName, string MunCode, string MunName)
          {
              DataSet ds = new DataSet();
              DBArchive gel = new DBArchive();
              gel.OpenConnection();
              ds = gel.getNextCCMandateByJMBG(jmbg, ElectionCode, ListCode, ListName, LevelCode, LevelName, MunCode, MunName);
              gel.CloseConnection();
              return ds;
          }

          public static object GenerateMandateCC(string ElectionCode, string LevelCode)
          {
              DBArchive gel = new DBArchive();
              gel.OpenConnection();
              object result = gel.GenerateMandateCC(ElectionCode, LevelCode);
              gel.CloseConnection();
              return result;
          }

          public static DataSet p4_BGetMunicipalityRegionForMandates(string Election, string race)
          {
              DBArchive gel = new DBArchive();
              gel.OpenConnection();
              DataSet name = gel.p4_BGetMunicipalityRegionForMandates(Election, race);
              gel.CloseConnection();
              return name;
          }


          public static object InsertintoCityCouncilLists(string ElectionCode, string LevelCode, string MunCode, string ListName, int? nat)
          {
              DBArchive gel = new DBArchive();
              gel.OpenConnection();
              object result = gel.InsertintoCityCouncilLists(ElectionCode, LevelCode, MunCode, ListName, nat);
              gel.CloseConnection();
              return result;
          }

          public static void InsertintoRepeatCount(string decision, string level, string bm, int race, int reason)
          {
              DBArchive gel = new DBArchive();
              gel.OpenConnection();
              object result = gel.InsertintoRepeatCount(decision, level, bm, race, reason);
              gel.CloseConnection();
             
          }


          public static object InsertintoCityCouncilCandidates(string jmbg, int id, int listposition, string ElCode, bool isEnd, bool isReplaced, bool isWait, DateTime DateStart, DateTime DateEnd)
          {
              DBArchive gel = new DBArchive();
              gel.OpenConnection();
              object result = gel.InsertintoCityCouncilCandidates(jmbg, id, listposition, ElCode, isEnd, isReplaced, isWait, DateStart, DateEnd);
              gel.CloseConnection();
              return result;
          }


          public static void DeleteCand(int id)
          {
              DBArchive dbCand = new DBArchive();
              dbCand.OpenConnection();
              dbCand.DeleteCand(id);
              dbCand.CloseConnection();
          }

          public static void DeleteList(int id)
          {
              DBArchive dbCand = new DBArchive();
              dbCand.OpenConnection();
              dbCand.DeleteList(id);
              dbCand.CloseConnection();
          }

          public static void ProcessList(int id)
          {
              DBArchive dbCand = new DBArchive();
              dbCand.OpenConnection();
              dbCand.ProcessList(id);
              dbCand.CloseConnection();
          }

          public static void FinalizeList(int id)
          {
              DBArchive dbCand = new DBArchive();
              dbCand.OpenConnection();
              dbCand.FinalizeList(id);
              dbCand.CloseConnection();
          }

          public static void LockList(int id)
          {
              DBArchive dbCand = new DBArchive();
              dbCand.OpenConnection();
              dbCand.LockList(id);
              dbCand.CloseConnection();
          }

          public static object UpdateCCMandate(string ElectionCode, string jmbg, bool isEnd, bool isReplaced, bool isWait, DateTime? DateStart, DateTime? DateEnd, string Reason, int RplWith, int RplList, string Remark, string Comment)
          {
              DBArchive gel = new DBArchive();
              gel.OpenConnection();
              object result = gel.UpdateCCMandate(ElectionCode, jmbg, isEnd, isReplaced, isWait, DateStart, DateEnd, Reason, RplWith, RplList, Remark, Comment);
              gel.CloseConnection();
              return result;
          }

          public static object InsertintoVNRSCandidates(string jmbg, int id, int listposition, string ElCode, string LevelCode, bool isEnd, bool isReplaced, bool isWait, DateTime DateStart, DateTime DateEnd, int Nat)
          {
              DBArchive gel = new DBArchive();
              gel.OpenConnection();
              object result = gel.InsertintoVNRSCandidates(jmbg, id, listposition, ElCode, LevelCode, isEnd, isReplaced, isWait, DateStart, DateEnd, Nat);
              gel.CloseConnection();
              return result;
          }


          public static object UpdateLists(string ElectionCode, string LevelCode, string MunCode, int param)
          {
              DBArchive gel = new DBArchive();
              gel.OpenConnection();
              object result = gel.UpdateLists(ElectionCode, LevelCode, MunCode, param);
              gel.CloseConnection();
              return result;
          }

          public static object UpdateCityCouncilLists(int id, string ListName)
          {
              DBArchive gel = new DBArchive();
              gel.OpenConnection();
              object result = gel.UpdateCityCouncilLists(id, ListName);
              gel.CloseConnection();
              return result;
          }

        public static DataSet SelectElectionWebResultForID(int id)
        {
            DataSet ds = new DataSet();
            DBArchive gel = new DBArchive();
            gel.OpenConnectionWebResult();
           // ds = gel.SelectElectionWebResultForID(id);
            gel.CloseConnection();
            return ds;
        }

        public static DataSet SelectElectionWebResultForIDWEB(int id)
        {
            DataSet ds = new DataSet();
            DBArchive gel = new DBArchive();
            gel.OpenConnectionWebResultWeb();
           // ds = gel.SelectElectionWebResultForID(id);
            gel.CloseConnection();
            return ds;
        }

        public static void UpdateElectionWebResult(int electionResultId, string nameLatin, string nameCyrillic, string radioButtonIsActive, string radioButtonIsFinalResult, string radioButtonShowDetailedResults, string messageBS, string messageSR, string messageHR, string messageEN)
          {
              DBArchive gel = new DBArchive();
              gel.OpenConnectionWebResult();
              gel.UpdateElectionWebResult(electionResultId, nameLatin, nameCyrillic, radioButtonIsActive, radioButtonIsFinalResult, radioButtonShowDetailedResults, messageBS, messageSR, messageHR, messageEN);
              gel.CloseConnection();
          }

        public static void UpdateElectionWebResultWEB(int electionResultId, string nameLatin, string nameCyrillic, string radioButtonIsActive, string radioButtonIsFinalResult, string radioButtonShowDetailedResults, string messageBS, string messageSR, string messageHR, string messageEN)
          {
            DBArchive gel = new DBArchive();
            gel.OpenConnectionWebResultWeb();
            gel.UpdateElectionWebResult(electionResultId, nameLatin, nameCyrillic, radioButtonIsActive, radioButtonIsFinalResult, radioButtonShowDetailedResults, messageBS, messageSR, messageHR, messageEN);
            gel.CloseConnection();
        }

        public static void AddElection(string code, string nameLatinic, string nameCirilic, DateTime dateElection, string radioButtonIsActive)
          {
              DBArchive db= new DBArchive();
              db.OpenConnectionWebResult();
              db.AddElection(code, nameLatinic, nameCirilic, dateElection, radioButtonIsActive);
              db.CloseConnection();
          }


        public static void AddElectionWEB(string code, string nameLatinic, string nameCirilic, DateTime dateElection, string radioButtonIsActive)
        {
            DBArchive db = new DBArchive();
            db.OpenConnectionWebResultWeb();
            db.AddElection(code, nameLatinic, nameCirilic, dateElection, radioButtonIsActive);
            db.CloseConnection();
        }

        public static void AddRace(string electionCode, string raceCode, string nameLatinic, string nameCirilic)
          {
              DBArchive db = new DBArchive();
              db.OpenConnectionWebResult();
              db.AddRace(electionCode, raceCode, nameLatinic, nameCirilic);
              db.CloseConnection();
          }

        public static void AddRaceWEB(string electionCode, string raceCode, string nameLatinic, string nameCirilic)
        {
            DBArchive db = new DBArchive();
            db.OpenConnectionWebResultWeb();
            db.AddRace(electionCode, raceCode, nameLatinic, nameCirilic);
            db.CloseConnection();
        }

        public static string AddElectionResult(string electionCode, string nameLatinic, string nameCirilic, string radioButtonIsActive, string radioButtonIsFinalResult, string radioButtonShowDetailedResults, string messageBS, string messageSR, string messageHR, string messageEN)
          {
              DBArchive db = new DBArchive();
              db.OpenConnectionWebResult();
              string dbName = db.AddElectionResult(electionCode, nameLatinic, nameCirilic, radioButtonIsActive, radioButtonIsFinalResult, radioButtonShowDetailedResults, messageBS, messageSR, messageHR, messageEN);
              db.CloseConnection();
              return dbName;
          }

        public static string AddElectionResultWEB(string electionCode, string nameLatinic, string nameCirilic, string radioButtonIsActive, string radioButtonIsFinalResult, string radioButtonShowDetailedResults, string messageBS, string messageSR, string messageHR, string messageEN)
          {
              DBArchive db = new DBArchive();
            db.OpenConnectionWebResultWeb();
            string dbName = db.AddElectionResult(electionCode, nameLatinic, nameCirilic, radioButtonIsActive, radioButtonIsFinalResult, radioButtonShowDetailedResults, messageBS, messageSR, messageHR, messageEN);
            db.CloseConnection();
            return dbName;
        }

        public static void DeleteResultElection(int id)
          {
              DBArchive db = new DBArchive();
              db.OpenConnectionWebResult();
              db.DeleteElectionResult(id);
              db.CloseConnection();
          }

        public static void DeleteResultElectionWEB(int id)
        {
            DBArchive db = new DBArchive();
            db.OpenConnectionWebResultWeb();
            db.DeleteElectionResult(id);
            db.CloseConnection();
        }

        public static void CreateWebDatabase(string dbName, string raceList)
          {
              DBArchive db = new DBArchive();
              db.OpenConnectionWebResult();
              db.CreateWebDatabase(dbName,raceList);
              db.CloseConnection();
          }

        public static void CreateWebDatabaseWEB(string dbName, string raceList)
          {
              DBArchive db = new DBArchive();
            db.OpenConnectionWebResultWeb();
            db.CreateWebDatabase(dbName, raceList);
            db.CloseConnection();
        }

        public static int RunJob(int raceId, bool webFlag)
          {
              DBArchive db = new DBArchive();
              db.OpenConnection();
              int res = db.RunJob(raceId, webFlag);
              db.CloseConnection();
              return res;
          }


        //060620220 Prigovori i zalbe
        public static object InsertComplaint(int ElectionId,
            int MunicipalitiesId,
            string Creator,
            string Owner,
            int ActId,
            string ProtocolNumber,
            int SubmiterId,
            string SubmiterName,
            string Fax,
            string Email,
            int SubmitedById,
            DateTime SubmitedDate,
            DateTime? EventDate,
            string EventPlace,
            string EventSubject,
            int CathegoryId,
            string EventDesc,
            string EventIZ,
            string EventAttach,
            string SigniturePlace,
            DateTime SignitureDate,
            string SubjectAcceptedBy,
            string ResoultionNumber,
            DateTime? ResolutionDate,
            string ResolutionContent,
            DateTime? ComplaintDate,
            string ComplaintContent,
            int ActState,
            int UserId,
            int ActDelgated,
            bool isArchived)
        {
            DBArchive gel = new DBArchive();
            gel.OpenConnectionElectionRepository();
            object result = gel.InsertComplaint(
            ElectionId,
             MunicipalitiesId,
             Creator,
             Owner,
             ActId,
             ProtocolNumber,
             SubmiterId,
             SubmiterName,
             Fax,
             Email,
             SubmitedById,
             SubmitedDate,
             EventDate,
             EventPlace,
             EventSubject,
             CathegoryId,
             EventDesc,
             EventIZ,
             EventAttach,
             SigniturePlace,
             SignitureDate,
             SubjectAcceptedBy,
             ResoultionNumber,
             ResolutionDate,
             ResolutionContent,
             ComplaintDate,
             ComplaintContent,
             ActState,
             UserId,
             ActDelgated,
             isArchived);
            gel.CloseConnection();
            return result;
        }

        public static object EditComplaint(
            int Id,
            int ElectionId,
            int MunicipalitiesId,
            string Owner,
            int ActId,
            string ProtocolNumber,
            int SubmiterId,
            string SubmiterName,
            string Fax,
            string Email,
            int SubmitedById,
            DateTime SubmitedDate,
            DateTime? EventDate,
            string EventPlace,
            string EventSubject,
            int CathegoryId,
            string EventDesc,
            string EventIZ,
            string EventAttach,
            string SigniturePlace,
            DateTime SignitureDate,
            string SubjectAcceptedBy,
            string ResoultionNumber,
            DateTime? ResolutionDate,
            string ResolutionContent,
            DateTime? ComplaintDate,
            string ComplaintContent,
            int ActState,
            int UserId,
            int ActDelgated,
            bool isArchived)
        {
            DBArchive gel = new DBArchive();
            gel.OpenConnectionElectionRepository();
            object result = gel.EditComplaint(
             Id,
             ElectionId,
             MunicipalitiesId,
             Owner,
             ActId,
             ProtocolNumber,
             SubmiterId,
             SubmiterName,
             Fax,
             Email,
             SubmitedById,
             SubmitedDate,
             EventDate,
             EventPlace,
             EventSubject,
             CathegoryId,
             EventDesc,
             EventIZ,
             EventAttach,
             SigniturePlace,
             SignitureDate,
             SubjectAcceptedBy,
             ResoultionNumber,
             ResolutionDate,
             ResolutionContent,
             ComplaintDate,
             ComplaintContent,
             ActState,
             UserId,
             ActDelgated,
             isArchived);
            gel.CloseConnection();
            return result;
        }

        public static DataSet getActiveElection()
        {
            DataSet ds = new DataSet();
            DBArchive gel = new DBArchive();
            gel.OpenConnectionElectionRepository();
            ds = gel.getActiveElections();
            gel.CloseConnection();
            return ds;
        }

        public static DataSet GetMunicipalityIdByCode(string munCode)
        {
            DataSet ds = new DataSet();
            DBArchive gel = new DBArchive();
            gel.OpenConnectionElectionRepository();
            ds = gel.GetMunicipalityIdByCode(munCode);
            gel.CloseConnection();
            return ds;
        }

        public static DataSet getDashboard()
        {
            DBArchive dbCR = new DBArchive();
            dbCR.OpenConnection();
            DataSet ds = dbCR.getDashboard();
            dbCR.CloseConnection();
            return ds;
        }
        public static void p3_InsertEmptyBagsInto_P3Bags_Covid(string PSCode)
        {
            DBArchive dbDeleteOrgUnit = new DBArchive();
            dbDeleteOrgUnit.OpenConnection();
            dbDeleteOrgUnit.p3_InsertEmptyBagsInto_P3Bags_Covid(PSCode);
            dbDeleteOrgUnit.CloseConnection();
        }

        public static DataSet p3_InsertIntoVotesCastCovid(string jmb, int clerk, string psBag, string firstName, string lastName, string birthDate, string potpis, bool suspicious)

        {
            DBArchive dbCR = new DBArchive();
            dbCR.OpenConnection();
            DataSet ds = dbCR.p3_InsertIntoVotesCastCovid(jmb, clerk, psBag, firstName, lastName, birthDate, potpis, suspicious);
            dbCR.CloseConnection();
            return ds;
        }



    }
}
