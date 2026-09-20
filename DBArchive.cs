using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Microsoft.SqlServer.Server;

namespace JIIS.DataLayer
{
    public class DBArchive : DBBase
    {
        #region Public Methods

        public DataSet GetAllOrganizationalUnits()
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            DataSet dsTmp = new DataSet();
            dsTmp = executeResults("dms_ArchiveGetAllOrganizationalUnits", pTypes, pVals, "OrganizationalUnits");
            return dsTmp;
        }

        public DataSet GetAllNews()
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            DataSet dsTmp = new DataSet();
            dsTmp = executeResults("dms_GetAllNews", pTypes, pVals, "News");
            return dsTmp;
        }

        public void BDeleteFinalAll()
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();
            executeScalar("BDeleteFinalAll", pTypes, pVals);
        }
        public DataSet GetAllNewsPozicija()
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            DataSet dsTmp = new DataSet();
            dsTmp = executeResults("dms_GetAllNewsPozicija", pTypes, pVals, "News_Pozicija");
            return dsTmp;
        }
        public void DeleteCandidate(int id)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@id", id);

            pTypes.Add("@id", "nvarchar");

            executeScalar("BDeleteCandidate", pTypes, pVals);
        }
        public void InsertOrganizationalUnit(string orgUnitName)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@orgUnitName", orgUnitName);

            pTypes.Add("@orgUnitName", "nvarchar");

            executeScalar("dms_ArchiveInsertOrganizationalUnit", pTypes, pVals);
        }

        public void AddNews(string Title, string Tekst, string Todate, int IDUser)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@Title", Title);
            pVals.Add("@Tekst", Tekst);
            pVals.Add("@Todate", Todate);
            pVals.Add("@IDUser", IDUser);

            pTypes.Add("@Title", "nvarchar");
            pTypes.Add("@Tekst", "nvarchar");
            pTypes.Add("@Todate", "nvarchar");
            pTypes.Add("@IDUser", "int");

            executeScalar("dms_insertNews", pTypes, pVals);

        }

        public void AddNewsPozicija(int News_ID, int Pozicija)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@News_ID", News_ID);
            pVals.Add("@Pozicija", Pozicija);


            pTypes.Add("@News_ID", "int");
            pTypes.Add("@Pozicija", "int");


            executeScalar("dms_insertNewspozicija", pTypes, pVals);

        }
        public void RemoveNewsPozicija(int News_ID, int Pozicija)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@News_ID", News_ID);
            pVals.Add("@Pozicija", Pozicija);


            pTypes.Add("@News_ID", "int");
            pTypes.Add("@Pozicija", "int");


            executeScalar("dms_DeleteNewsfromPozicija", pTypes, pVals);

        }
        public void DeleteBatchPSMembers(string BPSNumber, string PSNumber)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@BPSNumber", BPSNumber);
            pVals.Add("@PSNumber", PSNumber);

            pTypes.Add("@BPSNumber", "nvarchar");
            pTypes.Add("@PSNumber", "nvarchar");

            executeScalar("dms_DeleteBatchPSMembers", pTypes, pVals);

        }
        public void UpdateOrganizationalUnit(int orgUnitId, string orgUnitName)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@orgUnitId", orgUnitId);
            pVals.Add("@orgUnitName", orgUnitName);

            pTypes.Add("@orgUnitId", "int");
            pTypes.Add("@orgUnitName", "nvarchar");

            executeScalar("dms_ArchiveUpdateOrganizationalUnit", pTypes, pVals);
        }
        public void UpdateNews(int News_ID, string Title, string Tekst, string Todate)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@News_ID", News_ID);
            pVals.Add("@Title", Title);
            pVals.Add("@Tekst", Tekst);
            pVals.Add("@Todate", Todate);

            pTypes.Add("@News_ID", "int");
            pTypes.Add("@Title", "nvarchar");
            pTypes.Add("@Tekst", "nvarchar");
            pTypes.Add("@Todate", "nvarchar");

            executeScalar("dms_UpdateNews", pTypes, pVals);
        }
        public void DeleteOrganizationalUnit(int orgUnitId)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@orgUnitId", orgUnitId);

            pTypes.Add("@orgUnitId", "int");

            executeScalar("dms_ArchiveDeleteOrganizationalUnit", pTypes, pVals);
        }
        //delete news

        public void DeleteNews(int News_ID)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@News_ID", News_ID);

            pTypes.Add("@News_ID", "int");

            executeScalar("dms_DeleteNews", pTypes, pVals);
        }
        /// <summary>
        /// Opens connection to database.
        /// </summary>
        public void OpenConnection()
        {
            openConnection();
        }

        public void OpenConnectionElectionRepository()
        {
            openConnectionElectionRepository();
        }

        public void OpenConnectionWebResultWeb()
        {
            openConnectionWebResultWeb();
        }

        public void OpenConnectionWebResult()
        {
            openConnectionWebResult();
        }
        /// <summary>
        /// Closes connection to database.
        /// </summary>
        public void CloseConnection()
        {
            closeConnection();
        }

        #endregion // Public Methods

        public string GetOrganizationalUnitName(int id)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();
            pVals.Add("@id", id);

            pTypes.Add("@id", "int");

            object tmpObj = executeScalar("dms_ArchiveGetOrganizationalUnitName", pTypes, pVals);
            return tmpObj as string;
        }

        public DataSet p3_UnconfirmedTurnout_GetCountTime(string munCode)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@munCode", munCode);

            pTypes.Add("@munCode", "string");

            DataSet ds = executeResults("p3_UnconfirmedTurnout_GetCountTime", pTypes, pVals, "p3_UnconfirmedTurnout");
            return ds;

            //////////////
        }
        public DataSet GetNewsbyID(int News_ID)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@News_ID", News_ID);

            pTypes.Add("@News_ID", "int");

            DataSet dsTmp = new DataSet();
            dsTmp = executeResults("dms_GetNewsbyID", pTypes, pVals, "News_Pozicija");
            return dsTmp;
        }
        public DataSet GetNewsbyUserID(int IDUser)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@IDUser", IDUser);

            pTypes.Add("@IDUser", "int");

            DataSet dsTmp = new DataSet();
            dsTmp = executeResults("dms_GetNewsbyUserID", pTypes, pVals, "News");
            return dsTmp;
        }
        public DataSet GetUserNews()
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            DataSet dsTmp = new DataSet();
            dsTmp = executeResults("dms_GetUserNews", pTypes, pVals, "User_News");
            return dsTmp;
        }
        public void InsertUserNews(int UserIDNews)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@UserIDNews", UserIDNews);

            pTypes.Add("@UserIDNews", "int");

            executeScalar("dms_InsertUserNews", pTypes, pVals);
        }
        public void DeleteUserNews(int UserIDNews)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@UserIDNews", UserIDNews);

            pTypes.Add("@UserIDNews", "int");

            executeScalar("dms_DeleteUserNews", pTypes, pVals);

        }
        public void UpdateUserNews(int User_ID, bool User_News)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@User_News", User_News);

            pTypes.Add("@User_News", "bit");

            executeScalar("dms_UpdateUserNews", pTypes, pVals);
        }
        public DataSet GetUserGroupsID(int User_ID)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@User_ID", User_ID);

            pTypes.Add("@User_ID", "int");

            DataSet dsTmp = new DataSet();
            dsTmp = executeResults("dms_GetUserGroupsID", pTypes, pVals, "UsersGroups");
            return dsTmp;
        }
        public DataSet GetNewsPozicijaID(int Pozicija)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@Pozicija", Pozicija);

            pTypes.Add("@Pozicija", "int");

            DataSet dsTmp = new DataSet();
            dsTmp = executeResults("dms_GetNewsPozicijaID", pTypes, pVals, "News_Pozicija");
            return dsTmp;
        }
        public DataSet GetNewsbyPozicija(int News_ID)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@News_ID", News_ID);

            pTypes.Add("@News_ID", "int");

            DataSet dsTmp = new DataSet();
            dsTmp = executeResults("dms_GetNewsbyPozicija", pTypes, pVals, "News");
            return dsTmp;
        }
        public DataSet GetAllGroupPozicija()
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();
            DataSet dsTmp = new DataSet();
            dsTmp = executeResults("dms_getAllGroupPozicija", pTypes, pVals, "OrganizationalUnits");
            return dsTmp;
        }

        public string GetNewsName(int News_ID)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@News_ID", News_ID);

            pTypes.Add("@News_ID", "int");

            object tmpObj = executeScalar("dms_GetNewsName", pTypes, pVals);
            return tmpObj as string;
        }

        public DataSet p3_SelectDeniedReason(string typePS)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@typePS", typePS);

            pTypes.Add("@typePS", "string");
            
            DataSet dsTmp = new DataSet();
            dsTmp = executeResults("p3_GetDenyReasons", pTypes, pVals, "p3_PO_DenyReasons");
            return dsTmp;

        }

        public string GetNewsTekst(int News_ID)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@News_ID", News_ID);

            pTypes.Add("@News_ID", "int");

            object tmpObj = executeScalar("dms_GetNewsTekst", pTypes, pVals);
            return tmpObj as string;
        }

        public string GetNewsDate(int News_ID)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@News_ID", News_ID);

            pTypes.Add("@News_ID", "int");

            object tmpObj = executeScalar("dms_GetNewsDate", pTypes, pVals);
            return tmpObj as string;
        }
        public DataSet GetUserPriviledges(int User_ID)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@User_ID", User_ID);

            pTypes.Add("@User_ID", "int");

            DataSet dsTmp = new DataSet();
            dsTmp = executeResults("dms_GetUserPriviledges", pTypes, pVals, "Users_Priviledges");
            return dsTmp;
        }
        public DataSet GetAllUsersforDD()
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            DataSet dsTmp = new DataSet();
            dsTmp = executeResults("dms_GetAllUsersforDD", pTypes, pVals, "Users");
            return dsTmp;
        }
        public void InsertUserPriviledges(int User_ID, bool News, bool Archive)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@User_ID", User_ID);
            pVals.Add("@News", News);
            pVals.Add("@Archive", Archive);

            pTypes.Add("@User_ID", "int");
            pTypes.Add("@News", "bit");
            pTypes.Add("@Archive", "bit");

            executeScalar("dms_InsertUserPriviledges", pTypes, pVals);
        }
        public void UpdateUsersPriviledges(int User_ID, bool News, bool Archive)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@User_ID", User_ID);
            pVals.Add("@News", News);
            pVals.Add("@Archive", Archive);

            pTypes.Add("@User_ID", "int");
            pTypes.Add("@News", "bit");
            pTypes.Add("@Archive", "bit");

            executeScalar("dms_UpdateUsersPriviledges", pTypes, pVals);
        }
        public void DeleteUserPriviledges(int User_ID)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@User_ID", User_ID);

            pTypes.Add("@User_ID", "int");

            executeScalar("dms_DeleteUserPriviledges", pTypes, pVals);

        }
        public void DeleteCandidacyRace(int CandidacyRace)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@CRID", CandidacyRace);
            pTypes.Add("@CRID", "numeric");
            executeScalar("BDeleteCanidacyRace", pTypes, pVals);

        }
        public void AddCanidacyRace(string CRName, string CRisActive, string CRDate, int NumberMandates)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@CRName", CRName);
            pVals.Add("@CRisActive", CRisActive);
            pVals.Add("@CRDate", CRDate);
            pVals.Add("@NumberMandates", NumberMandates);
            pTypes.Add("@CRName", "nvarchar");
            pTypes.Add("@CRisActive", "bit");
            pTypes.Add("@CRDate", "nvarchar");
            pTypes.Add("@NumberMandates", "numeric");
            executeScalar("BAddCanidacyRace", pTypes, pVals);

        }

        public void ModifyCanidacyRace(int ID, string CRName, string CRisActive, string CRDate, int NumberMandates)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@CRID", ID);
            pTypes.Add("@CRID", "numeric");
            pVals.Add("@CRName", CRName);
            pVals.Add("@CRisActive", CRisActive);
            pVals.Add("@CRDate", CRDate);
            pVals.Add("@NumberMandates", NumberMandates);
            pTypes.Add("@CRName", "nvarchar");
            pTypes.Add("@CRisActive", "bit");
            pTypes.Add("@CRDate", "nvarchar");
            pTypes.Add("@NumberMandates", "numeric");
            executeScalar("BModifyCanidacyRace", pTypes, pVals);

        }
        public void Sinchronise_BMunicipalityRegion_p3_NationalityAllocation()
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();
            executeScalar("Sinchronise_BMunicipalityRegion_p3_NationalityAllocation", pTypes, pVals);
        }
        public DataSet SelectCanidacyRaceForID(int ID)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();
            pVals.Add("@CRID", ID);
            pTypes.Add("@CRID", "numeric");
            DataSet dsTmp = new DataSet();
            dsTmp = executeResults("BSelectCanidacyRaceForID", pTypes, pVals, "CandidacyRace");
            return dsTmp;
        }

        //IZMJENA KING ICT 23.2.
        public DataSet BGetAllActiveCandidacyRaceForMand()
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();
            pVals.Add("@election", "2016MUNI1");
            pTypes.Add("@election", "varchar");
            DataSet dsTmp = new DataSet();
            dsTmp = executeResults("p4_BGetAllActiveCandidacyRaceForMandates", pTypes, pVals, "CandidacyRace");
            return dsTmp;
        }
        //END

        public int p3_getBoxReadyForEntryResults(string boxName)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();
            pVals.Add("@BoxName", boxName);
            pTypes.Add("@BoxName", "nvarchar");
            DataSet dsTmp = new DataSet();
            dsTmp = executeResults("p3_getBoxReadyForEntryResults", pTypes, pVals, "p3_Box");
            return int.Parse(dsTmp.Tables[0].Rows[0][0].ToString());
        }

        public int verification1()
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();
            DataSet dsTmp = new DataSet();
            dsTmp = executeResults("bVerification1", pTypes, pVals, "BCandidates");
            return int.Parse(dsTmp.Tables[0].Rows[0][0].ToString());
        }
        public int verification2()
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();
            DataSet dsTmp = new DataSet();
            dsTmp = executeResults("bVerification2", pTypes, pVals, "BCandidates");
            return int.Parse(dsTmp.Tables[0].Rows[0][0].ToString());
        }

        public int verification3()
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();
            DataSet dsTmp = new DataSet();
            dsTmp = executeResults("bVerification3", pTypes, pVals, "BCandidates");
            return int.Parse(dsTmp.Tables[0].Rows[0][0].ToString());
        }
        public int verification4()
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();
            DataSet dsTmp = new DataSet();
            dsTmp = executeResults("bVerification4", pTypes, pVals, "BCandidates");
            return int.Parse(dsTmp.Tables[0].Rows[0][0].ToString());
        }
        public int verification5()
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();
            DataSet dsTmp = new DataSet();
            dsTmp = executeResults("bVerification5", pTypes, pVals, "BCandidates");
            return int.Parse(dsTmp.Tables[0].Rows[0][0].ToString());
        }
        public int verificationComplete()
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();
            DataSet dsTmp = new DataSet();
            dsTmp = executeResults("bVerificationComplete", pTypes, pVals, "BCandidates");
            return int.Parse(dsTmp.Tables[0].Rows[0][0].ToString());
        }

        public int GetLastUser()
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();


            object obj = executeScalar("dms_GetLastUser", pTypes, pVals);
            int count = 0;
            count = Convert.ToInt32(obj);
            return count;
        }
        public int GetCRC()
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();


            object obj = executeScalar("GetCRC", pTypes, pVals);
            int count = 0;
            count = Convert.ToInt32(obj);
            return count;
        }
        public int GetTop1OUnit()
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();


            object obj = executeScalar("dms_GetTop1OUnit", pTypes, pVals);
            int count = 0;
            count = Convert.ToInt32(obj);
            return count;
        }
        public int GetOrganizationalUnitbyUserID(int User_ID)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@User_ID", User_ID);

            pTypes.Add("@User_ID", "int");

            object obj = executeScalar("dms_GetOrganizationalUnitbyUserID", pTypes, pVals);
            int count = 0;
            count = Convert.ToInt32(obj);
            return count;
        }

        public void UpdateSupervisor(int SupervisorID, int ClerkID, int Crc)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@SupervisorID", SupervisorID);
            pVals.Add("@ClerkID", ClerkID);
            pVals.Add("@Crc", Crc);

            pTypes.Add("@SupervisorID", "int");
            pTypes.Add("@ClerkID", "int");
            pTypes.Add("@Crc", "int");

            executeScalar("UpdateSupervisor", pTypes, pVals);
        }
        public int checkUserName(string User_Username)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@User_Username", User_Username);

            pTypes.Add("@User_Username", "nvarchar");

            object obj = executeScalar("dms_checkUserName", pTypes, pVals);
            int count = 0;
            count = Convert.ToInt32(obj);
            return count;
        }
        public int checkUserName2(string User_Username, string User_Username2)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@User_Username", User_Username);
            pVals.Add("@User_Username2", User_Username2);

            pTypes.Add("@User_Username", "nvarchar");
            pTypes.Add("@User_Username2", "nvarchar");

            object obj = executeScalar("dms_checkUserName2", pTypes, pVals);
            int count = 0;
            count = Convert.ToInt32(obj);
            return count;
        }
        public DataSet GetSysSettings()
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            DataSet dsTmp = new DataSet();
            dsTmp = executeResults("GetSysSettings", pTypes, pVals, "SystemSettings");
            return dsTmp;
        }
        public void UpdateSysSettings(int SysID, bool Voted, bool SingleEntry, int tolRRFMA1, int tolRRFMA2, int tolRRFMA3, int tolRRFMay1, int tolRRFMay2, int tolRRFMay3, int tolBRFMA, int tolBRFMay, bool isNumbertolRRFMA1, bool isNumbertolRRFMA2, bool isNumbertolRRFMA3, bool isNumbertolRRFMay1, bool isNumbertolRRFMay2, bool isNumbertolRRFMay3, bool isNumbertolBRFMA, bool isNumbertolBRFMay, int ToleranceLevel, bool isProcentFVL)
        {

            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@SysID", SysID);
            pVals.Add("@Voted", Voted);
            pVals.Add("@SingleEntry", SingleEntry);
            pVals.Add("@tolRRFMA1", tolRRFMA1);
            pVals.Add("@tolRRFMA2", tolRRFMA2);
            pVals.Add("@tolRRFMA3", tolRRFMA3);
            pVals.Add("@tolRRFMay1", tolRRFMay1);
            pVals.Add("@tolRRFMay2", tolRRFMay2);
            pVals.Add("@tolRRFMay3", tolRRFMay3);
            pVals.Add("@tolBRFMA", tolBRFMA);
            pVals.Add("@tolBRFMay", tolBRFMay);
            pVals.Add("@isNumbertolRRFMA1", isNumbertolRRFMA1);
            pVals.Add("@isNumbertolRRFMA2", isNumbertolRRFMA2);
            pVals.Add("@isNumbertolRRFMA3", isNumbertolRRFMA3);
            pVals.Add("@isNumbertolRRFMay1", isNumbertolRRFMay1);
            pVals.Add("@isNumbertolRRFMay2", isNumbertolRRFMay2);
            pVals.Add("@isNumbertolRRFMay3", isNumbertolRRFMay3);
            pVals.Add("@isNumbertolBRFMA", isNumbertolBRFMA);
            pVals.Add("@isNumbertolBRFMay", isNumbertolBRFMay);
            pVals.Add("@ToleranceLevel", ToleranceLevel);
            pVals.Add("@isProcentFVL", isProcentFVL);

            pTypes.Add("@SysID", "int");
            pTypes.Add("@Voted", "bit");
            pTypes.Add("@SingleEntry", "bit");
            pTypes.Add("@tolRRFMA1", "int");
            pTypes.Add("@tolRRFMA2", "int");
            pTypes.Add("@tolRRFMA3", "int");
            pTypes.Add("@tolRRFMay1", "int");
            pTypes.Add("@tolRRFMay2", "int");
            pTypes.Add("@tolRRFMay3", "int");
            pTypes.Add("@tolBRFMA", "int");
            pTypes.Add("@tolBRFMay", "int");
            pTypes.Add("@isNumbertolRRFMA1", "bit");
            pTypes.Add("@isNumbertolRRFMA2", "bit");
            pTypes.Add("@isNumbertolRRFMA3", "bit");
            pTypes.Add("@isNumbertolRRFMay1", "bit");
            pTypes.Add("@isNumbertolRRFMay2", "bit");
            pTypes.Add("@isNumbertolRRFMay3", "bit");
            pTypes.Add("@isNumbertolBRFMA", "bit");
            pTypes.Add("@isNumbertolBRFMay", "bit");
            pTypes.Add("@ToleranceLevel", "int");
            pTypes.Add("@isProcentFVL", "bit");

            executeScalar("UpdateSysSettings", pTypes, pVals);

        }


        public DataSet BGetMunicipalityRegionForCandidacyRace(int race)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@race", race);
            pTypes.Add("@race", "int");

            DataSet dsTmp = new DataSet();
            dsTmp = executeResults("BGetMunicipalityRegionForCandidacyRace", pTypes, pVals, "BMunicipalityRegion");
            return dsTmp;
        }

        public DataSet p4_BGetPoliticalEntityNameForMandates()
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();


            DataSet dsTmp = new DataSet();
            dsTmp = executeResults("Phase4.MandatesImplementationGetPartyName", pTypes, pVals, "Party");
            return dsTmp;
        }

        //IZMJENA KING ICT 23.2.
        public DataSet p4_BGetMunicipalityRegionForMandates()
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();
            pVals.Add("@election", "2016MUNI1");//zakucano
            pTypes.Add("@election", "varchar");

            DataSet dsTmp = new DataSet();
            dsTmp = executeResults("p4_BGetMunicipalityRegionForMandates", pTypes, pVals, "BMunicipalityRegion");
            return dsTmp;
        }
        //END

        

        public DataSet BGetCertifiedPoliticalEntitiesForCandidacyRace(int race, int mureg)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@race", race);
            pVals.Add("@mureg", mureg);
            pTypes.Add("@race", "int");
            pTypes.Add("@mureg", "int");

            DataSet dsTmp = new DataSet();
            dsTmp = executeResults("BGetCertifiedPoliticalEntitiesForCandidacyRace", pTypes, pVals, "BPoliticalEntities");
            return dsTmp;
        }

        public int BGetCertifiedPoliticalEntitiesID(int race, int mureg, int pe)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@race", race);
            pVals.Add("@mureg", mureg);
            pVals.Add("@pe", pe);
            pTypes.Add("@race", "int");
            pTypes.Add("@mureg", "int");
            pTypes.Add("@pe", "int");

            object dsTmp = executeScalar("BGetCertifiedPoliticalEntitiesID", pTypes, pVals);
            int idto = 0;
            idto = Convert.ToInt32(dsTmp);
            return idto;
        }


        public bool BCheckCandidateIfEntry(string name, string surname, string jmb, int certified, string serialnum)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@name", name);
            pVals.Add("@surname", surname);
            pVals.Add("@jmb", jmb);
            pVals.Add("@certified", certified);
            pVals.Add("@serialnum", serialnum);

            pTypes.Add("@name", "nvarchar");
            pTypes.Add("@surname", "nvarchar");
            pTypes.Add("@jmb", "nvarchar");
            pTypes.Add("@certified", "int");
            pTypes.Add("@serialnum", "nvarchar");

            DataSet ds = executeResults("BCheckCandidateIfEntry", pTypes, pVals, "BCandidates");
            if (Int32.Parse(ds.Tables[0].Rows[0][0].ToString()) > 0)
                return false;
            else
                return true;
        }


        public void BInsertBCandidatesFirst(string name, string surname, string jmb, int certified,
                            string serialnum, string gender, string address, int fkuser, int registredps)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@name", name);
            pVals.Add("@surname", surname);
            pVals.Add("@jmb", jmb);
            pVals.Add("@certified", certified);
            pVals.Add("@serialnum", serialnum);
            pVals.Add("@gender", gender);
            pVals.Add("@address", address);
            pVals.Add("@fkuser", fkuser);
            pVals.Add("@registredps", registredps);

            pTypes.Add("@name", "string");
            pTypes.Add("@surname", "string");
            pTypes.Add("@jmb", "string");
            pTypes.Add("@certified", "int");
            pTypes.Add("@serialnum", "string");
            pTypes.Add("@gender", "string");
            pTypes.Add("@address", "string");
            pTypes.Add("@fkuser", "int");
            pTypes.Add("@registredps", "int");

            executeScalar("BInsertBCandidatesFirst", pTypes, pVals);
        }
        public void BInsertBCandidatesExcel(string name, string surname, string nameCyr, string surnameCyr, string jmb, int certified,
                          string serialnum, string gender, string address, string addressCyr, int fkuser, int registredps)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@name", name);
            pVals.Add("@surname", surname);
            pVals.Add("@nameCyr", nameCyr);
            pVals.Add("@surnameCyr", surnameCyr);
            pVals.Add("@jmb", jmb);
            pVals.Add("@certified", certified);
            pVals.Add("@serialnum", serialnum);
            pVals.Add("@gender", gender);
            pVals.Add("@address", address);
            pVals.Add("@addressCyr", addressCyr);
            pVals.Add("@fkuser", fkuser);
            pVals.Add("@registredps", registredps);

            pTypes.Add("@name", "nvarchar");
            pTypes.Add("@surname", "nvarchar");
            pTypes.Add("@nameCyr", "nvarchar");
            pTypes.Add("@surnameCyr", "nvarchar");
            pTypes.Add("@jmb", "nvarchar");
            pTypes.Add("@certified", "int");
            pTypes.Add("@serialnum", "nvarchar");
            pTypes.Add("@gender", "nvarchar");
            pTypes.Add("@address", "nvarchar");
            pTypes.Add("@addressCyr", "nvarchar");
            pTypes.Add("@fkuser", "int");
            pTypes.Add("@registredps", "int");

            executeScalar("BInsertBCandidatesExcel", pTypes, pVals);
        }


        public DataSet BGetCandidateDataForEdit(int CID)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@CID", CID);
            pTypes.Add("@CID", "int");

            DataSet dsTmp = new DataSet();
            dsTmp = executeResults("BGetCandidateDataForEdit", pTypes, pVals, "BCandidates");
            return dsTmp;
        }

        public void BUpdateBCandidates(int idcand, string name, string surname, string jmb, int certified,
                            string serialnum, string gender, string address, int registredps)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@idcand", idcand);
            pVals.Add("@name", name);
            pVals.Add("@surname", surname);
            pVals.Add("@jmb", jmb);
            pVals.Add("@certified", certified);
            pVals.Add("@serialnum", serialnum);
            pVals.Add("@gender", gender);
            pVals.Add("@address", address);
            pVals.Add("@registredps", registredps);

            pTypes.Add("@idcand", "int");
            pTypes.Add("@name", "string");
            pTypes.Add("@surname", "string");
            pTypes.Add("@jmb", "string");
            pTypes.Add("@certified", "int");
            pTypes.Add("@serialnum", "string");
            pTypes.Add("@gender", "string");
            pTypes.Add("@address", "string");
            pTypes.Add("@registredps", "int");

            executeScalar("BUpdateBCandidates", pTypes, pVals);
        }


        //////////////////// NIDZZO 28.03.2010 /////////////////////////////

        public int BInsertCandidateFirstEntry(int FKPoliticalEntity, int ListPos, string Prefix, string Surname, string MiddleName,
            string FirstName, string Suffix, string DateBirth, string PlaceBirth, string JMB, string Address, int FKNationality, string Gender, string ValidDocumentNo,
            string VDNPlace, int isPassport, string ConctactAddress, string Phone, int FKEducation, string FaxNo, string Mail, string SignDate, int CandidateSign,
            int PresidentSign, int Statement, int PropertyStatement, int Obrazac, string StatementPath, string Comment, int FKUser, string DateEntered, string ProtocolNo, string MainInfo, int NatMinority, int Cyrilic, int Minority)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@FKPoliticalEntity", FKPoliticalEntity);
            pVals.Add("@ListPos", ListPos);
            pVals.Add("@Prefix", Prefix);
            pVals.Add("@Surname", Surname);
            pVals.Add("@MiddleName", MiddleName);
            pVals.Add("@FirstName", FirstName);
            pVals.Add("@Suffix", Suffix);
            pVals.Add("@Datebirth", DateBirth);
            pVals.Add("@PlaceBirth", PlaceBirth);
            pVals.Add("@JMB", JMB);
            pVals.Add("@Address", Address);
            pVals.Add("@FKNationality", FKNationality);
            pVals.Add("@Gender", Gender);
            pVals.Add("@ValidDocumentNo", ValidDocumentNo);
            pVals.Add("@VDNPlace", VDNPlace);
            pVals.Add("@isPassport", isPassport);
            pVals.Add("@ConctactAddress", ConctactAddress);
            pVals.Add("@Phone", Phone);
            pVals.Add("@FKEducation", FKEducation);
            pVals.Add("@FaxNo", FaxNo);
            pVals.Add("@Mail", Mail);
            pVals.Add("@SignDate", SignDate);
            pVals.Add("@CandidateSign", CandidateSign);
            pVals.Add("@PresidentSign", PresidentSign);
            pVals.Add("@Statement", Statement);
            pVals.Add("@StatementPath", StatementPath);
            pVals.Add("@Comment", Comment);
            pVals.Add("@FKUser", FKUser);
            pVals.Add("@DateEntered", DateEntered);
            pVals.Add("@ProtocolNo", ProtocolNo);
            pVals.Add("@MainInfo", MainInfo);
            pVals.Add("@NatMinority", NatMinority);
            pVals.Add("@Cyrilic", Cyrilic);
            pVals.Add("@Minority", Minority);
            pVals.Add("@PropertyStatement", PropertyStatement);
            pVals.Add("@Obrazac", Obrazac);


            pTypes.Add("@FKPoliticalEntity", "int");
            pTypes.Add("@ListPos", "int");
            pTypes.Add("@Prefix", "nvarchar");
            pTypes.Add("@Surname", "nvarchar");
            pTypes.Add("@MiddleName", "nvarchar");
            pTypes.Add("@FirstName", "nvarchar");
            pTypes.Add("@Suffix", "nvarchar");
            pTypes.Add("@Datebirth", "nvarchar");
            pTypes.Add("@PlaceBirth", "nvarchar");
            pTypes.Add("@JMB", "nvarchar");
            pTypes.Add("@Address", "nvarchar");
            pTypes.Add("@FKNationality", "int");
            pTypes.Add("@Gender", "nvarchar");
            pTypes.Add("@ValidDocumentNo", "nvarchar");
            pTypes.Add("@VDNPlace", "nvarchar");
            pTypes.Add("@isPassport", "nvarchar");
            pTypes.Add("@ConctactAddress", "nvarchar");
            pTypes.Add("@Phone", "nvarchar");
            pTypes.Add("@FKEducation", "int");
            pTypes.Add("@FaxNo", "nvarchar");
            pTypes.Add("@Mail", "nvarchar");
            pTypes.Add("@SignDate", "nvarchar");
            pTypes.Add("@CandidateSign", "int");
            pTypes.Add("@PresidentSign", "int");
            pTypes.Add("@Statement", "int");
            pTypes.Add("@StatementPath", "nvarchar");
            pTypes.Add("@Comment", "nvarchar");
            pTypes.Add("@FKUser", "int");
            pTypes.Add("@DateEntered", "nvarchar");
            pTypes.Add("@ProtocolNo", "nvarchar");
            pTypes.Add("@MainInfo", "nvarchar");
            pTypes.Add("@NatMinority", "int");
            pTypes.Add("@Cyrilic", "int");
            pTypes.Add("@Minority", "int");
            pTypes.Add("@PropertyStatement", "int");
            pTypes.Add("@Obrazac", "int");

            object obj = executeScalar("BInsertCandidateFirstEntry", pTypes, pVals);
            return Convert.ToInt32(obj);
        }

        public int BInsertCandidateSecondEntry(int FKPoliticalEntity, int ListPos, string Prefix, string Surname, string MiddleName,
            string FirstName, string Suffix, string DateBirth, string PlaceBirth, string JMB, string Address, int FKNationality, string Gender, string ValidDocumentNo,
            string VDNPlace, int isPassport, string ConctactAddress, string Phone, int FKEducation, string FaxNo, string Mail, string SignDate, int CandidateSign,
            int PresidentSign, int Statement, int PropertyStatement, int Obrazac, string StatementPath, string Comment, int FKUser, string DateEntered, string ProtocolNo, string MainInfo, int NatMinority, int Cyrilic, int Minority)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@FKPoliticalEntity", FKPoliticalEntity);
            pVals.Add("@ListPos", ListPos);
            pVals.Add("@Prefix", Prefix);
            pVals.Add("@Surname", Surname);
            pVals.Add("@MiddleName", MiddleName);
            pVals.Add("@FirstName", FirstName);
            pVals.Add("@Suffix", Suffix);
            pVals.Add("@Datebirth", DateBirth);
            pVals.Add("@PlaceBirth", PlaceBirth);
            pVals.Add("@JMB", JMB);
            pVals.Add("@Address", Address);
            pVals.Add("@FKNationality", FKNationality);
            pVals.Add("@Gender", Gender);
            pVals.Add("@ValidDocumentNo", ValidDocumentNo);
            pVals.Add("@VDNPlace", VDNPlace);
            pVals.Add("@isPassport", isPassport);
            pVals.Add("@ConctactAddress", ConctactAddress);
            pVals.Add("@Phone", Phone);
            pVals.Add("@FKEducation", FKEducation);
            pVals.Add("@FaxNo", FaxNo);
            pVals.Add("@Mail", Mail);
            pVals.Add("@SignDate", SignDate);
            pVals.Add("@CandidateSign", CandidateSign);
            pVals.Add("@PresidentSign", PresidentSign);
            pVals.Add("@Statement", Statement);
            pVals.Add("@StatementPath", StatementPath);
            pVals.Add("@Comment", Comment);
            pVals.Add("@FKUser", FKUser);
            pVals.Add("@DateEntered", DateEntered);
            pVals.Add("@ProtocolNo", ProtocolNo);
            pVals.Add("@MainInfo", MainInfo);
            pVals.Add("@NatMinority", NatMinority);
            pVals.Add("@Cyrilic", Cyrilic);
            pVals.Add("@Minority", Minority);
            pVals.Add("@PropertyStatement", PropertyStatement);
            pVals.Add("@Obrazac", Obrazac);


            pTypes.Add("@FKPoliticalEntity", "int");
            pTypes.Add("@ListPos", "int");
            pTypes.Add("@Prefix", "nvarchar");
            pTypes.Add("@Surname", "nvarchar");
            pTypes.Add("@MiddleName", "nvarchar");
            pTypes.Add("@FirstName", "nvarchar");
            pTypes.Add("@Suffix", "nvarchar");
            pTypes.Add("@Datebirth", "nvarchar");
            pTypes.Add("@PlaceBirth", "nvarchar");
            pTypes.Add("@JMB", "nvarchar");
            pTypes.Add("@Address", "nvarchar");
            pTypes.Add("@FKNationality", "int");
            pTypes.Add("@Gender", "nvarchar");
            pTypes.Add("@ValidDocumentNo", "nvarchar");
            pTypes.Add("@VDNPlace", "nvarchar");
            pTypes.Add("@isPassport", "nvarchar");
            pTypes.Add("@ConctactAddress", "nvarchar");
            pTypes.Add("@Phone", "nvarchar");
            pTypes.Add("@FKEducation", "int");
            pTypes.Add("@FaxNo", "nvarchar");
            pTypes.Add("@Mail", "nvarchar");
            pTypes.Add("@SignDate", "nvarchar");
            pTypes.Add("@CandidateSign", "int");
            pTypes.Add("@PresidentSign", "int");
            pTypes.Add("@Statement", "int");
            pTypes.Add("@StatementPath", "nvarchar");
            pTypes.Add("@Comment", "nvarchar");
            pTypes.Add("@FKUser", "int");
            pTypes.Add("@DateEntered", "nvarchar");
            pTypes.Add("@ProtocolNo", "nvarchar");
            pTypes.Add("@MainInfo", "nvarchar");
            pTypes.Add("@NatMinority", "int");
            pTypes.Add("@Cyrilic", "int");
            pTypes.Add("@Minority", "int");
            pTypes.Add("@PropertyStatement", "int");
            pTypes.Add("@Obrazac", "int");

            object obj = executeScalar("BInsertCandidateSecondEntry", pTypes, pVals);
            return Convert.ToInt32(obj);
        }

        public DataSet BGetCandidatePersonalInfo(string JMB)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@JMB", JMB);
            pTypes.Add("@JMB", "nvarchar");

            DataSet dsTmp = new DataSet();
            dsTmp = executeResults("BGetCandidatePersonalInfo", pTypes, pVals, "Voter");
            return dsTmp;
        }

        public void BInsertMinority(string Minority)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@Minority", Minority);

            pTypes.Add("@Minority", "nvarchar");

            executeScalar("BInsertMinority", pTypes, pVals);
        }

        public int BGetLevelByID(string Code)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@Code", Code);

            pTypes.Add("@Code", "nvarchar");

            DataSet dsTmp = new DataSet();
            dsTmp = executeResults("BGetLevelByID", pTypes, pVals, "BMunicipalityRegion");
            return int.Parse(dsTmp.Tables[0].Rows[0][0].ToString());
        }

        public int BGetPoliticalEntityByID(string NameOnBallot)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@NameOnBallot", NameOnBallot);

            pTypes.Add("@NameOnBallot", "nvarchar");

            DataSet dsTmp = new DataSet();
            dsTmp = executeResults("BGetPoliticalEntityByID", pTypes, pVals, "BPoliticalEntities");
            return int.Parse(dsTmp.Tables[0].Rows[0][0].ToString());
        }

        public int BGetCertifiedPoliticalEntity(int polEntity, int munReg)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@polEntity", polEntity);
            pVals.Add("@munReg", munReg);

            pTypes.Add("@polEntity", "int");
            pTypes.Add("@munReg", "int");

            DataSet dsTmp = new DataSet();
            dsTmp = executeResults("BGetCertifiedPoliticalEntity", pTypes, pVals, "BCertifiedPolitivalEntities");
            return int.Parse(dsTmp.Tables[0].Rows[0][0].ToString());
        }

        public bool BCheckIfListNumberIsAlreadyEntered1(int lNumber, int certPolParty)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@lNumber", lNumber);
            pVals.Add("@certPolParty", certPolParty);

            pTypes.Add("@lNumber", "int");
            pTypes.Add("@certPolParty", "int");

            DataSet dsTmp = new DataSet();
            dsTmp = executeResults("BCheckIfListNumberIsAlreadyEntered1", pTypes, pVals, "BCandidates1");
            if (dsTmp.Tables[0].Rows.Count > 0)
            {
                return true;
            }
            else
                return false;
        }

        public bool BCheckIfListNumberIsAlreadyEntered2(int lNumber, int certPolParty)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@lNumber", lNumber);
            pVals.Add("@certPolParty", certPolParty);

            pTypes.Add("@lNumber", "int");
            pTypes.Add("@certPolParty", "int");

            DataSet dsTmp = new DataSet();
            dsTmp = executeResults("BCheckIfListNumberIsAlreadyEntered2", pTypes, pVals, "BCandidates2");
            if (dsTmp.Tables[0].Rows.Count > 0)
            {
                return true;
            }
            else
                return false;
        }

        ////////////////// SPASOV 30.03.2010 ///////////////////////////////////////////////////


        public void DeleteEducation(int Education)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@ID", Education);
            pTypes.Add("@ID", "numeric");
            executeScalar("BDeleteEducation", pTypes, pVals);

        }

        public void DeleteElection(int Election)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@ID", Election);
            pTypes.Add("@ID", "numeric");
            executeScalar("BDeleteElection", pTypes, pVals);

        }
        public void DeleteGeneratedResults()
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            executeScalar("DeleteGeneratedResults", pTypes, pVals);

        }
        public void DeleteDeniedVoters(int denVoter)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@ID", denVoter);
            pTypes.Add("@ID", "int");
            executeScalar("p3_DeleteDeniedVoter", pTypes, pVals);

        }


        public void DeleteNationality(int CandidacyRace)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@CRID", CandidacyRace);
            pTypes.Add("@CRID", "numeric");
            executeScalar("BDeleteNationality", pTypes, pVals);

        }

        public DataSet SelectNationalityForID(int CID)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@ID", CID);
            pTypes.Add("@ID", "numeric");

            DataSet dsTmp = new DataSet();
            dsTmp = executeResults("BSelectNationalityForID", pTypes, pVals, "BNationality");
            return dsTmp;
        }
        public DataSet SelectEducationForID(int CID)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@ID", CID);
            pTypes.Add("@ID", "numeric");

            DataSet dsTmp = new DataSet();
            dsTmp = executeResults("BSelectEducationForID", pTypes, pVals, "BEducationLevel");
            return dsTmp;
        }

        public DataSet SelectReasonForID(int id, int lid)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@ID", id);
            pVals.Add("@Language_ID", lid);

            pTypes.Add("@ID", "numeric");
            pTypes.Add("@Language_ID", "int");

            DataSet dsTmp = new DataSet();
            dsTmp = executeResults("BSelectReasonForID", pTypes, pVals, "BReason");
            return dsTmp;
        }

        public void AddNationality(string text)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@nat", text);
            pTypes.Add("@nat", "nvarchar");

            executeScalar("BAddNationality", pTypes, pVals);
        }
        public void AddEducation(string text)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@nat", text);
            pTypes.Add("@nat", "nvarchar");

            executeScalar("BAddEducation", pTypes, pVals);
        }
        public void AddIzbori(string code, string nameLatinic, string nameCirilic, string date, string radioButtonIsActive)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@ElectionCode", code);
            pVals.Add("@ElectionNameLatinica", nameLatinic);
            pVals.Add("@ElectionNameCirilica", nameCirilic);
            pVals.Add("@ElectionDate", date);
            pVals.Add("@ElectionIsActive", radioButtonIsActive);

            pTypes.Add("@ElectionCode", "nchar");
            pTypes.Add("@ElectionNameLatinica", "nvarchar");
            pTypes.Add("@ElectionNameCirilica", "nvarchar");
            pTypes.Add("@ElectionDate", "nchar");
            pTypes.Add("@ElectionIsActive", "bit");

            executeScalar("BAddIzbori", pTypes, pVals);
        }

        public void AddShipment(string txtDateReceived, string txtShipmentNumber, string txtTotalShip, string txtTotalOtherPost, string txtComment)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@DateReceive", txtDateReceived);
            pVals.Add("@ShipmentN", txtShipmentNumber);
            pVals.Add("@TotalShip", txtTotalShip);
            pVals.Add("@TotalOtherPost", txtTotalOtherPost);
            pVals.Add("@Comment", txtComment);

            pTypes.Add("@DateReceive", "nvarchar(50)");
            pTypes.Add("@ShipmentN", "int");
            pTypes.Add("@TotalShip", "int");
            pTypes.Add("@TotalOtherPost", "int");
            pTypes.Add("@Comment", "nvarchar(MAX)");

            executeScalar("BAddIzbori", pTypes, pVals);
        }

        public void UpdateShipment(int id, string txtDateReceived, string txtShipmentNumber, string txtTotalShip, string txtTotalOtherPost, string txtComment)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@id", id);
            pVals.Add("@dateReceive", txtDateReceived);
            pVals.Add("@shipmentN", txtShipmentNumber);
            pVals.Add("@shipmentnumber", txtTotalShip);
            pVals.Add("@totalOtherPost", txtTotalOtherPost);
            pVals.Add("@comment", txtComment);

            pTypes.Add("@id", "int");
            pTypes.Add("@dateReceive", "nvarchar(50)");
            pTypes.Add("@shipmentN", "int");
            pTypes.Add("@shipmentnumber", "int");
            pTypes.Add("@totalOtherPost", "int");
            pTypes.Add("@comment", "nvarchar(MAX)");

            executeScalar("p3_UpdateShipment", pTypes, pVals);
        }


        public void AddDeniedVoter(string JMB, string numberBag, string Reason, string Name, string Surname, int IdBags, int IdReason)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@JMB", JMB);
            pVals.Add("@NumberBags", numberBag);
            pVals.Add("@Reason", Reason);
            pVals.Add("@NameVoter", Name);
            pVals.Add("@Surname", Surname);
            pVals.Add("@IdBags", IdBags);
            pVals.Add("@IdReason", IdReason);

            pTypes.Add("@JMB", "string");
            pTypes.Add("@NumberBags", "nvarchar");
            pTypes.Add("@Reason", "nvarchar");
            pTypes.Add("@NameVoter", "nvarchar");
            pTypes.Add("@Surname", "nvarchar");
            pTypes.Add("@IdBags", "int");
            pTypes.Add("@IdReason", "int");

            executeScalar("p3_AddDeniedVoter", pTypes, pVals);
        }

        public void ModifyNationality(int ID, string text)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@ID", ID);
            pTypes.Add("@ID", "numeric");
            pVals.Add("@nat", text);
            pTypes.Add("@nat", "nvarchar");


            executeScalar("ModifyNationality", pTypes, pVals);
        }

        public void ModifyEducation(int ID, string text)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@ID", ID);
            pTypes.Add("@ID", "numeric");
            pVals.Add("@nat", text);
            pTypes.Add("@nat", "nvarchar");


            executeScalar("BModifyEducation", pTypes, pVals);
        }

        public void ModifyReason(int id, int lid, string reason)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@id", id);
            pVals.Add("@lid", lid);
            pVals.Add("@reason", reason);

            pTypes.Add("@id", "numeric");
            pTypes.Add("@lid", "int");
            pTypes.Add("@reason", "nvarchar");

            executeScalar("BModifyReason", pTypes, pVals);
        }

        public DataSet BGetAllFieldControlsForElectionType(int ID)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@Type", ID);
            pTypes.Add("@Type", "numeric");

            DataSet dsTmp = new DataSet();
            dsTmp = executeResults("BGetAllFieldControlsForElectionType", pTypes, pVals, "FieldControl");
            return dsTmp;

        }
        public void BUpdateFieldControlsForElectionType(int id, string first, string second)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();


            pVals.Add("@id", id);
            pTypes.Add("@id", "numeric");
            pVals.Add("@first", first);
            pTypes.Add("@first", "numeric");
            pVals.Add("@second", second);
            pTypes.Add("@second", "nvarchar");


            executeScalar("BUpdateFieldControlsForElectionType", pTypes, pVals);
        }

        public void DeleteLevel(int CandidacyRace)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@ID", CandidacyRace);
            pTypes.Add("@ID", "int");
            executeScalar("BDeleteLevel", pTypes, pVals);

        }

        public void DeleteLevelRelation(int level1, int level2)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@level1", level1.ToString());
            pTypes.Add("@level1", "nvarchar(50)");
            pVals.Add("@level2", level2.ToString());
            pTypes.Add("@level2", "nvarchar(50)");
            executeScalar("BDeleteLevelRelation", pTypes, pVals);

        }

        public DataSet SelectLevelForID(int ID)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();
            pVals.Add("@CRID", ID);
            pTypes.Add("@CRID", "int");
            DataSet dsTmp = new DataSet();
            dsTmp = executeResults("BSelectLevelForID", pTypes, pVals, "BMunicipalityRegion");
            return dsTmp;
        }

        public DataSet SelectAllFromMandatesForID(int id)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();
            pVals.Add("@CRID", id);
            pTypes.Add("@CRID", "int");
            DataSet dsTmp = new DataSet();
            dsTmp = executeResults("Phase4.MandatesImplementationGetForId", pTypes, pVals, "MandatesImplementation");
            return dsTmp;
        }

        public DataSet GetNextMandate(string LevelCode, string PECode, string FKRace, string ElectionCode)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();
            pVals.Add("@LevelCode", LevelCode);
            pVals.Add("@PECode", PECode);
            pVals.Add("@FKRace", FKRace);
            pVals.Add("@ElectionCode", ElectionCode);

            pTypes.Add("@LevelCode", "varchar(3)");
            pTypes.Add("@PECode", "varchar(5)");
            pTypes.Add("@FKRace", "varchar(2)");
            pTypes.Add("@ElectionCode", "varchar(10)");
            DataSet dsTmp = new DataSet();
            dsTmp = executeResults("MandatesImplementationGetNextMandate", pTypes, pVals, "p4_MandatesImplementation");
            return dsTmp;
        }

        public DataSet GetNextCMandate(string Region, string PECode, string FKRace, string ElectionCode)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();
            pVals.Add("@Region", Region);
            pVals.Add("@PECode", PECode);
            pVals.Add("@FKRace", FKRace);
            pVals.Add("@ElectionCode", ElectionCode);
            //pVals.Add("@Compensatory", Compensatory);

            pTypes.Add("@Region", "varchar(3)");
            pTypes.Add("@PECode", "varchar(5)");
            pTypes.Add("@FKRace", "varchar(2)");
            pTypes.Add("@ElectionCode", "varchar(10)");
            //pTypes.Add("@Compensatory", "bit");
            DataSet dsTmp = new DataSet();
            dsTmp = executeResults("[Phase4].[MandatesImplementationGetNextCMandate]", pTypes, pVals, "p4_MandatesImplementation");
            return dsTmp;
        }

        public DataSet SelectElectionForID(int id)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();
            pVals.Add("@CRID", id);
            pTypes.Add("@CRID", "int");
            DataSet dsTmp = new DataSet();
            dsTmp = executeResults("BSelectIzboriForID", pTypes, pVals, "BElection");
            return dsTmp;
        }
        //Nedim
        public DataSet SelectActiveElection()
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();
            DataSet dsTmp = new DataSet();
            dsTmp = executeResults("BGetElectionActive", pTypes, pVals, "BElection");
            return dsTmp;
        }


        public DataSet SelectShipmentForID(int id)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();
            pVals.Add("@ID", id);
            pTypes.Add("@ID", "int");
            DataSet dsTmp = new DataSet();
            dsTmp = executeResults("p3_GetShipmentByID", pTypes, pVals, "p3_Shipment");
            return dsTmp;
        }

        public DataSet SelectDeniedVoterForID(int id)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();
            pVals.Add("@ID", id);
            pTypes.Add("@ID", "int");
            DataSet dsTmp = new DataSet();
            dsTmp = executeResults("BSelectDeniedVoterForID", pTypes, pVals, "p3_DeniedVoters");
            return dsTmp;
        }


        public DataSet SelectMenuItemForID(int upid)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();
            pVals.Add("@UserPage", upid);
            pTypes.Add("@UserPage", "int");
            DataSet dsTmp = new DataSet();
            dsTmp = executeResults("oktomvriGetUSERPagesByIDUP", pTypes, pVals, "UserPageData");
            return dsTmp;
        }

        public void AddLevels(string Code, string Name, int NumberVoters, int NumberPS, int FKRace, int NumberMandates, int minority, int maxcandidates, string script)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@Code", Code);
            pVals.Add("@Name", Name);
            pVals.Add("@NumberVoters", NumberVoters);
            pVals.Add("@NumberPS", NumberPS);
            pVals.Add("@FKRace", FKRace);
            pVals.Add("@NumberMandates", NumberMandates);
            pVals.Add("@minority", minority);
            pVals.Add("@maxcandidates", maxcandidates);
            pVals.Add("@script", script);

            pTypes.Add("@Code", "nvarchar");
            pTypes.Add("@Name", "nvarchar");
            pTypes.Add("@NumberVoters", "int");
            pTypes.Add("@NumberPS", "int");
            pTypes.Add("@FKRace", "int");
            pTypes.Add("@NumberMandates", "int");
            pTypes.Add("@minority", "int");
            pTypes.Add("@maxcandidates", "int");
            pTypes.Add("@script", "varchar");

            executeScalar("BAddLevels", pTypes, pVals);

        }

        public void ModifyLevels(int id, string Code, string Name, int NumberVoters, int NumberPS, int FKRace, int NumberMandates, int minority, int maxcandidates, string script)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@id", id);
            pVals.Add("@Code", Code);
            pVals.Add("@Name", Name);
            pVals.Add("@NumberVoters", NumberVoters);
            pVals.Add("@NumberPS", NumberPS);
            pVals.Add("@FKRace", FKRace);
            pVals.Add("@NumberMandates", NumberMandates);
            pVals.Add("@minority", minority);
            pVals.Add("@maxcandidates", maxcandidates);
            pVals.Add("@script", script);

            pTypes.Add("@id", "int");
            pTypes.Add("@Code", "nvarchar");
            pTypes.Add("@Name", "nvarchar");
            pTypes.Add("@NumberVoters", "int");
            pTypes.Add("@NumberPS", "int");
            pTypes.Add("@FKRace", "int");
            pTypes.Add("@NumberMandates", "int");
            pTypes.Add("@minority", "int");
            pTypes.Add("@maxcandidates", "int");
            pTypes.Add("@script", "varchar");
            executeScalar("BModifyLevels", pTypes, pVals);

        }

        public void ModifyIzbori(int id, string Code, string NameLatin, string NameCyrilic, String DatumIzbora, string radioButtonIsActive)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@id", id);
            pVals.Add("@Code", Code);
            pVals.Add("@NameLatin", NameLatin);
            pVals.Add("@NameCyrilic", NameCyrilic);
            pVals.Add("@Date", DatumIzbora);
            pVals.Add("@ElectionIsActive", radioButtonIsActive);

            pTypes.Add("@id", "int");
            pTypes.Add("@Code", "nvarchar");
            pTypes.Add("@NameLatin", "nvarchar");
            pTypes.Add("@NameCyrilic", "nvarchar");
            pTypes.Add("@Date", "nvarchar");
            pTypes.Add("@ElectionIsActive", "bit");

            executeScalar("BModifyIzbori", pTypes, pVals);

        }


        public void UpdateMandatesImplementation(int id, string chbMandRepl, string chbMandEnd, string chbMandWait,
           string chbPropertyCardStart, string chbPropertyCard2,
           string txtReplacedWith, string ddlMandReason, string txtDateEndMand, string txtDateStartMand, string txtDatePC1, string txtDatePC2, string chbMandRepC, string chbMandWC)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@id", id);
            pVals.Add("@chbMandEnd", chbMandEnd);
            pVals.Add("@chbMandWait", chbMandWait);
            pVals.Add("@chbMandWaitComp", chbMandWC);
            pVals.Add("@chbMandRepl", chbMandRepl);
            pVals.Add("@chbMandReplComp", chbMandRepC);
            pVals.Add("@chbPropertyCardStart", chbPropertyCardStart);
            pVals.Add("@chbPropertyCard2", chbPropertyCard2);
            pVals.Add("@txtReplacedWith", txtReplacedWith);
            pVals.Add("@txtReasonMandEnd", ddlMandReason);
            pVals.Add("@txtDateEndMand", txtDateEndMand);
            pVals.Add("@txtDateStartMand", txtDateStartMand);
            pVals.Add("@txtDatePC1", txtDatePC1);
            pVals.Add("@txtDatePC2", txtDatePC2);
            

            pTypes.Add("@id", "int");
            pTypes.Add("@chbMandEnd", "varchar(1)");
            pTypes.Add("@chbMandWait", "varnchar(1)");
            pTypes.Add("@chbMandWaitComp", "varnchar(1)");
            pTypes.Add("@chbMandRepl", "varchar(1)");
            pTypes.Add("@chbMandReplComp", "varchar(1)");
            pTypes.Add("@chbPropertyCardStart", "varchar(1)");
            pTypes.Add("@chbPropertyCard2", "varchar(1)");
            pTypes.Add("@txtReplacedWith", "varchar(2)");
            pTypes.Add("@txtReasonMandEnd", "varchar(2)");
            pTypes.Add("@txtDateEndMand", "nvarchar(50)");
            pTypes.Add("@txtDateStartMand", "nvarchar(50)");
            pTypes.Add("@txtDatePC1", "nvarchar(50)");
            pTypes.Add("@txtDatePC2", "nvarchar(50)");
            

            executeScalar("[Phase4].[MandatesImplementationUpdate]", pTypes, pVals);

        }

        public void UpdateMandatesRace158(int id, string chbMandRepl, string chbMandEnd, string chbMandWait,
          string chbPropertyCardStart, string chbPropertyCard2,
          string txtReplacedWith, string ddlMandReason, string txtDateEndMand, string txtDateStartMand, string txtDatePC1, string txtDatePC2, 
            string chbMandRepC, string chbMandWC, string ListEnding)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@id", id);
            pVals.Add("@chbMandEnd", chbMandEnd);
            pVals.Add("@chbMandWait", chbMandWait);
            pVals.Add("@chbMandWaitComp", chbMandWC);
            pVals.Add("@chbMandRepl", chbMandRepl);
            pVals.Add("@chbMandReplComp", chbMandRepC);
            pVals.Add("@chbPropertyCardStart", chbPropertyCardStart);
            pVals.Add("@chbPropertyCard2", chbPropertyCard2);
            pVals.Add("@txtReplacedWith", txtReplacedWith);
            pVals.Add("@txtReasonMandEnd", ddlMandReason);
            pVals.Add("@txtDateEndMand", txtDateEndMand);
            pVals.Add("@txtDateStartMand", txtDateStartMand);
            pVals.Add("@txtDatePC1", txtDatePC1);
            pVals.Add("@txtDatePC2", txtDatePC2);
            pVals.Add("@ListEnding", ListEnding);

            pTypes.Add("@id", "int");
            pTypes.Add("@chbMandEnd", "varchar(1)");
            pTypes.Add("@chbMandWait", "varnchar(1)");
            pTypes.Add("@chbMandWaitComp", "varnchar(1)");
            pTypes.Add("@chbMandRepl", "varchar(1)");
            pTypes.Add("@chbMandReplComp", "varchar(1)");
            pTypes.Add("@chbPropertyCardStart", "varchar(1)");
            pTypes.Add("@chbPropertyCard2", "varchar(1)");
            pTypes.Add("@txtReplacedWith", "varchar(2)");
            pTypes.Add("@txtReasonMandEnd", "varchar(2)");
            pTypes.Add("@txtDateEndMand", "nvarchar(50)");
            pTypes.Add("@txtDateStartMand", "nvarchar(50)");
            pTypes.Add("@txtDatePC1", "nvarchar(50)");
            pTypes.Add("@txtDatePC2", "nvarchar(50)");
            pTypes.Add("@ListEnding", "varchar(1)");

            executeScalar("p4_UpdateMandatesRace158", pTypes, pVals);

        }

        public void InsertMandatesRace1(string ElectionCode, string ElectionName, string Ime, string Prezime, string Gender, string jmbg, string Nationality, string PartyCode2, string Party, 
            string Level, string LevelCode, int Race, string txtDateMandStart2, string Adresa, string Telefon, string PropertyCardStart2, string txtDatePC12)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@ElectionCode", ElectionCode);
            pVals.Add("@ElectionName", ElectionName);
            pVals.Add("@Ime", Ime);
            pVals.Add("@Prezime", Prezime);
            pVals.Add("@Gender", Gender);
            pVals.Add("@jmbg", jmbg);
            pVals.Add("@Nationality", Nationality);
            pVals.Add("@PartyCode", PartyCode2);
            pVals.Add("@Party", Party);
            pVals.Add("@Level", Level);
            pVals.Add("@LevelCode", LevelCode);
            pVals.Add("@FKRace", Race);
            pVals.Add("@txtDateMandStart", txtDateMandStart2);
            pVals.Add("@Adresa", Adresa);
            pVals.Add("@Telefon", Telefon);
            pVals.Add("@PropertyCardStart", PropertyCardStart2);
            pVals.Add("@txtDatePC12", txtDateMandStart2);

            pTypes.Add("@ElectionCode", "varchar(10)");
            pTypes.Add("@ElectionName", "varchar(50)");
            pTypes.Add("@Ime", "nvarchar(50)");
            pTypes.Add("@Prezime", "varnchar(50)");
            pTypes.Add("@Gender", "varnchar(1)");
            pTypes.Add("@jmbg", "varchar(13)");
            pTypes.Add("@Nationality", "varchar(1)");
            pTypes.Add("@PartyCode", "varchar(5)");
            pTypes.Add("@Party", "nvarchar(max)");
            pTypes.Add("@Level", "nvarchar(max)");
            pTypes.Add("@LevelCode", "varchar(3)");
            pTypes.Add("@FKRace", "int");
            pTypes.Add("@txtDateMandStart", "nvarchar(50)");
            pTypes.Add("@Adresa", "nvarchar(50)");
            pTypes.Add("@Telefon", "varchar(20)");
            pTypes.Add("@PropertyCardStart", "varchar(1)");
            pTypes.Add("@txtDatePC12", "nvarchar(50)");

            executeScalar("p4_InsertIntoMandatesRace1", pTypes, pVals);

        }


        public void UpdateListEnding(string ElectionCode, string LevelCode, int Race)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@ElectionCode", ElectionCode);
            pVals.Add("@LevelCode", LevelCode);
            pVals.Add("@Race", Race);

            pTypes.Add("@ElectionCode", "varchar(10)");
            pTypes.Add("@LevelCode", "varchar(3)");
            pTypes.Add("@Race", "int");
            
            executeScalar("p4_UpdateListEnding", pTypes, pVals);

        }

        public int DeleteUsersByType(int UserPositions_ID)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@UserPositions_ID", UserPositions_ID);

            pTypes.Add("@UserPositions_ID", "int");
            int error;
            error = Convert.ToInt32(executeScalar("dms_deleteUsersByType", pTypes, pVals));
            
            return error;

        }

        public void DisableUsersByType(int UserPositions_ID)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@UserPositions_ID", UserPositions_ID);

            pTypes.Add("@UserPositions_ID", "int");

            executeScalar("dms_disableUsersByType", pTypes, pVals);
        }

        public void EnableUsersByType(int UserPositions_ID)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@UserPositions_ID", UserPositions_ID);

            pTypes.Add("@UserPositions_ID", "int");

            executeScalar("dms_enableUsersByType", pTypes, pVals);
        }

        public void UpdateMandatesImplementation2(int id, string chbMandRepl, string chbMandReplComp,  string chbMandEnd, string chbMandWait, string chbMandWaitComp,
          string chbPropertyCardStart, string chbPropertyCard2,
          string txtReplacedWith, string ddlMandReason, string txtDateEndMand, string txtDateStartMand, string txtDatePC1, string txtDatePC2)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@id", id);
            pVals.Add("@chbMandEnd", chbMandEnd);
            pVals.Add("@chbMandWait", chbMandWait);
            pVals.Add("@chbMandWaitComp", chbMandWaitComp);
            pVals.Add("@chbMandRepl", chbMandRepl);
            pVals.Add("@chbMandReplComp", chbMandReplComp);
            pVals.Add("@chbPropertyCardStart", chbPropertyCardStart);
            pVals.Add("@chbPropertyCard2", chbPropertyCard2);
            pVals.Add("@txtReplacedWith", txtReplacedWith);
            pVals.Add("@txtReasonMandEnd", ddlMandReason);
            pVals.Add("@txtDateEndMand", txtDateEndMand);
            pVals.Add("@txtDateStartMand", txtDateStartMand);
            pVals.Add("@txtDatePC1", txtDatePC1);
            pVals.Add("@txtDatePC2", txtDatePC2);


            pTypes.Add("@id", "int");
            pTypes.Add("@chbMandEnd", "varchar");
            pTypes.Add("@chbMandWait", "varnchar");
            pTypes.Add("@chbMandWaitComp", "varnchar");
            pTypes.Add("@chbMandRepl", "varchar");
            pTypes.Add("@chbMandReplComp", "varchar");
            pTypes.Add("@chbPropertyCardStart", "varchar");
            pTypes.Add("@chbPropertyCard2", "varchar");
            pTypes.Add("@txtReplacedWith", "varchar");
            pTypes.Add("@txtReasonMandEnd", "varchar");
            pTypes.Add("@txtDateEndMand", "nvarchar");
            pTypes.Add("@txtDateStartMand", "nvarchar");
            pTypes.Add("@txtDatePC1", "nvarchar");
            pTypes.Add("@txtDatePC2", "nvarchar");


            executeScalar("p4_UpdateMandatesImplementation", pTypes, pVals);

        }

        public void UpdateWaitMandates(int id, string chbMandRepl, string chbMandReplComp, string chbMandWait, string chbMandWaitComp, string chbPropertyCardStart, string txtDateStartMand, string txtDatePC1)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@id", id);
            pVals.Add("@chbMandWait", chbMandWait);
            pVals.Add("@chbMandWaitComp", chbMandWaitComp);
            pVals.Add("@chbMandRepl", chbMandRepl);
            pVals.Add("@chbMandReplComp", chbMandReplComp);
            pVals.Add("@chbPropertyCardStart", chbPropertyCardStart);
            pVals.Add("@txtDateStartMand", txtDateStartMand);
            pVals.Add("@txtDatePC1", txtDatePC1);


            pTypes.Add("@id", "int");
            pTypes.Add("@chbMandWait", "varnchar");
            pTypes.Add("@chbMandWaitComp", "varnchar(");
            pTypes.Add("@chbMandRepl", "varchar");
            pTypes.Add("@chbMandReplComp", "varchar");
            pTypes.Add("@chbPropertyCardStart", "varchar");
            pTypes.Add("@txtDateStartMand", "nvarchar");
            pTypes.Add("@txtDatePC1", "nvarchar");

            executeScalar("p4_UpdateWaitMandates", pTypes, pVals);

        }

        public void UpdateCCMandatesImplementation(int id, string txtListForMunCouncil, string txtListPositionForMunCouncil, string txtChoosenForMunCouncil,
             string txtMandEndForMunCouncil, string txtReplaceMandForMunCouncil, string txtDateMandEndForMunCouncil, string txtDateStartForMunCouncil)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@id", id);
            
            pVals.Add("@txtListForMunCouncil", txtListForMunCouncil);
            pVals.Add("@txtListPositionForMunCouncil", txtListPositionForMunCouncil);
            pVals.Add("@txtChoosenForMunCouncil", txtChoosenForMunCouncil);
            pVals.Add("@txtMandEndForMunCouncil", txtMandEndForMunCouncil);
            pVals.Add("@txtReplaceMandForMunCouncil", txtReplaceMandForMunCouncil);
            pVals.Add("@txtDateMandEndForMunCouncil", txtDateMandEndForMunCouncil);
            pVals.Add("@txtDateStartForMunCouncil", txtDateStartForMunCouncil);

            pTypes.Add("@id", "int");
            
            pTypes.Add("@txtListForMunCouncil", "varchar");
            pTypes.Add("@txtListPositionForMunCouncil", "varchar");
            pTypes.Add("@txtChoosenForMunCouncil", "varchar");
            pTypes.Add("@txtMandEndForMunCouncil", "varchar");
            pTypes.Add("@txtReplaceMandForMunCouncil", "varchar");
            pTypes.Add("@txtDateMandEndForMunCouncil", "nvarchar");
            pTypes.Add("@txtDateStartForMunCouncil", "nvarchar");

            executeScalar("p4_UpdateCCMandatesImplementation", pTypes, pVals);

        }

        public void InsertintoMandatesCityCouncil(string txtCityCouncilCode, string txtCityCouncilName)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@CityCouncilCode", txtCityCouncilCode);
            pVals.Add("@CityCouncilName", txtCityCouncilName);


            pTypes.Add("@CityCouncilCode", "varchar(6)");
            pTypes.Add("@CityCouncilName", "nvarchar(MAX)");


            executeScalar("p4_InsertIntoMandatesCityCouncil", pTypes, pVals);

        }


        public void InsertIntoMandatesImplementationbyRaceLevel(string levelcode, string fkrace, string txtDateMandStart, string electioncode, string ElectionName)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@levelcode", levelcode);
            pVals.Add("@FKrace", fkrace);
            pVals.Add("@txtDateMandStart", txtDateMandStart);
            pVals.Add("@electioncode", electioncode);
            pVals.Add("@ElectionName", ElectionName);
          
            pTypes.Add("@levelcode", "nvarchar(3)");
            pTypes.Add("@FKrace", "nvarchar(2)");
            pTypes.Add("@txtDateMandStart", "nvarchar(30)");
            pTypes.Add("@electioncode", "nvarchar(20)");
            pTypes.Add("@ElectionName", "nvarchar(50)");
            
            executeScalar("p4_InsertIntoMandatesImplementationbyRaceLevel", pTypes, pVals);

        }

        public void ModifyDeniedVoter(int id, string JMB, string numberBags, string Reason, string Name, string Surname)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@ID", id);
            pVals.Add("@JMB", JMB);
            pVals.Add("@numberBags", numberBags);
            pVals.Add("@Reason", Reason);
            pVals.Add("@NameVoter", Name);
            pVals.Add("@Surname", Surname);

            pTypes.Add("@ID", "int");
            pTypes.Add("@JMB", "nvarchar");
            pTypes.Add("@numberBags", "nvarchar");
            pTypes.Add("@Reason", "nvarchar");
            pTypes.Add("@NameVoter", "nvarchar");
            pTypes.Add("@Surname", "nvarchar");

            executeScalar("p3_ModifyDeniedVoter", pTypes, pVals);

        }

        public void InsertLevelRelation(string level1, string level2, string lname1, string lname2)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@level1", level1);
            pVals.Add("@level2", level2);
            pVals.Add("@lname1", lname1);
            pVals.Add("@lname2", lname2);

            pTypes.Add("@level1", "string");
            pTypes.Add("@level2", "string");
            pTypes.Add("@lname1", "string");
            pTypes.Add("@lname2", "string");

            executeScalar("InsertLevelRelation", pTypes, pVals);
        }

        public DataSet BGetMismatchesForPoliticalEntity(int PolEntity)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@PolEntity", PolEntity);
            pTypes.Add("@PolEntity", "int");

            DataSet dsTmp = new DataSet();
            dsTmp = executeResults("BGetMismatchesForPoliticalEntity", pTypes, pVals, "BCandidates1");
            return dsTmp;
        }

        public DataSet SelectMandatesAllocationForID(int CID)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@ID", CID);
            pTypes.Add("@ID", "numeric");

            DataSet dsTmp = new DataSet();
            dsTmp = executeResults("BSelectMandatesAllocationForID", pTypes, pVals, "MinorityGenderAllocation");
            return dsTmp;
        }

        public void AddMandatesAllocation(int total, int min)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@total", total);
            pVals.Add("@min", min);
            pTypes.Add("@total", "int");
            pTypes.Add("@min", "int");

            executeScalar("BAddMandatesAllocation", pTypes, pVals);
        }

        public void ModifyMandatesAllocation(int ID, int min)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@ID", ID);
            pTypes.Add("@ID", "int");
            pVals.Add("@min", min);
            pTypes.Add("@min", "int");
            executeScalar("BModifyMandatesAllocation", pTypes, pVals);
        }

        public void DeleteMandatesAllocation(int ID)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@ID", ID);
            pTypes.Add("@ID", "int");
            executeScalar("BDeleteMandatesAllocation", pTypes, pVals);

        }

        /// <summary>
        ///  06.04.2010
        /// </summary>
        /// <param name="CID"></param>
        /// <returns></returns>


        public DataSet BGetMismatchesForElection(int CandRace)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@CandRace", CandRace);
            pTypes.Add("@CandRace", "int");

            DataSet dsTmp = new DataSet();
            dsTmp = executeResults("BGetMismatchesForElection", pTypes, pVals, "BCertifiedPolitivalEntities");
            return dsTmp;
        }

        public DataSet BGetAllActiveLevelsForCandidacyRace()
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            DataSet dsTmp = new DataSet();
            dsTmp = executeResults("BGetAllActiveLevelsForCandidacyRace", pTypes, pVals, "BCandidacyRace");
            return dsTmp;
        }
        public DataSet BGetAllActiveDistinctMunicipality()
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            DataSet dsTmp = new DataSet();
            dsTmp = executeResults("BGetAllActiveLevelsForCandidacyRace_Distinct_Cand", pTypes, pVals, "BCandidacyRace");
            return dsTmp;
        }
        public DataSet BGetStatisticsForUser(int user)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@user", user);
            pTypes.Add("@user", "int");

            DataSet dsTmp = new DataSet();
            dsTmp = executeResults("BGetStatisticsForUser", pTypes, pVals, "BCandidates1");
            return dsTmp;
        }
        public DataSet BGetStatisticsForUser2(int user)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@user", user);
            pTypes.Add("@user", "int");

            DataSet dsTmp = new DataSet();
            dsTmp = executeResults("BGetStatisticsForUser2", pTypes, pVals, "BCandidates2");
            return dsTmp;
        }
        public DataSet BGetStatisticsForUserRecent(int user)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@user", user);
            pTypes.Add("@user", "int");

            DataSet dsTmp = new DataSet();
            dsTmp = executeResults("BGetStatisticsForUserRecent", pTypes, pVals, "BCandidates1");
            return dsTmp;
        }
        public DataSet BGetStatisticsForUserRecent2(int user)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@user", user);
            pTypes.Add("@user", "int");

            DataSet dsTmp = new DataSet();
            dsTmp = executeResults("BGetStatisticsForUserRecent2", pTypes, pVals, "BCandidates2");
            return dsTmp;
        }
        public DataSet BCreateUserPrivileges()
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();


            DataSet dsTmp = new DataSet();
            dsTmp = executeResults("BCreateUserPrivileges", pTypes, pVals, "Users");
            return dsTmp;
        }
        public void UpdateUserPrivileges(int user, string privilege)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@uid", user);
            pTypes.Add("@uid", "int");
            pVals.Add("@privilege", privilege);
            pTypes.Add("@privilege", "nvarchar");


            executeScalar("BUpdateUserPrivileges", pTypes, pVals);
        }

        public DataSet BGetMismatchesForPoliticalEntityByID(int ID)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@ID", ID);
            pTypes.Add("@ID", "int");

            DataSet dsTmp = new DataSet();
            dsTmp = executeResults("BGetMismatchesForPoliticalEntityByID", pTypes, pVals, "BCandidates1");
            return dsTmp;
        }

        public int BGetRaceIDfromBMunicipalityRegion(string Code)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@Code", Code);

            pTypes.Add("@Code", "nvarchar");

            DataSet dsTmp = new DataSet();
            dsTmp = executeResults("BGetRaceIDfromBMunicipalityRegion", pTypes, pVals, "BMunicipalityRegion");
            return int.Parse(dsTmp.Tables[0].Rows[0][0].ToString());
        }

        public void BGetCertifiedPoliticalEntityWithNull(int polEntity, int munReg, int param, int race)
        {

            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@polEntity", polEntity);
            pVals.Add("@munReg", munReg);
            pVals.Add("@param", param);
            pVals.Add("@race", race);

            pTypes.Add("@polEntity", "int");
            pTypes.Add("@munReg", "int");
            pTypes.Add("@param", "int");
            pTypes.Add("@race", "int");

            executeScalar("BGetCertifiedPoliticalEntityWithNull", pTypes, pVals);
        }
        public void BGetCertifiedPoliticalEntityUnlockWithNull(int polEntity, int munReg, int param)
        {

            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@polEntity", polEntity);
            pVals.Add("@munReg", munReg);
            pVals.Add("@param", param);

            pTypes.Add("@polEntity", "int");
            pTypes.Add("@munReg", "int");
            pTypes.Add("@param", "int");

            executeScalar("BGetCertifiedPoliticalEntityUnlockWithNull", pTypes, pVals);
        }
        public DataSet BGetAllPreFinalCandidates(int certPolEnt)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@CertPolEntity", certPolEnt);

            pTypes.Add("@CertPolEntity", "int");

            DataSet dsTemp = new DataSet();
            dsTemp = executeResults("BGetAllPreFinalCandidates", pTypes, pVals, "BCandidatesPreFinal");
            return dsTemp;
        }

        public int BGetRaceIDfromCertifiedPoliticalEntities(string certPolEnt)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@certPolEnt", certPolEnt);

            pTypes.Add("@certPolEnt", "nvarchar");

            DataSet dsTmp = new DataSet();
            dsTmp = executeResults("BGetRaceIDfromCertifiedPoliticalEntities", pTypes, pVals, "BCertifiedPolitivalEntities");
            return int.Parse(dsTmp.Tables[0].Rows[0][0].ToString());
        }
        public void BUpdatePFCandidatesListPosition(int id, int lid)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@id", id);
            pVals.Add("@listPos", lid);

            pTypes.Add("@id", "int");
            pTypes.Add("@listPos", "int");

            executeScalar("BUpdatePFCandidatesListPosition", pTypes, pVals);
        }

        public void UpdateCCCandidatesListPosition(string jmbg, int lid)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@jmbg", jmbg);
            pVals.Add("@listPos", lid);

            pTypes.Add("@jmbg", "varchar");
            pTypes.Add("@listPos", "int");

            executeScalar("p4_UpdateCCCandidatesListPosition", pTypes, pVals);
        }


        public DataSet ProccCountCandidateListsForParametar(int level, int pe, int param)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@level", level);
            pVals.Add("@pe", pe);
            pVals.Add("@param", param);

            pTypes.Add("@level", "int");
            pTypes.Add("@pe", "int");
            pTypes.Add("@param", "int");

            DataSet dsTemp = new DataSet();
            dsTemp = executeResults("ProccCountCandidateListsForParametar", pTypes, pVals, "BCertifiedPolitivalEntities");
            return dsTemp;
        }

        public int BGetIDofNationality(string nationalityName)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@nationalityName", nationalityName);

            pTypes.Add("@nationalityName", "nvarchar");

            DataSet dsTmp = new DataSet();
            dsTmp = executeResults("BGetIDofNationality", pTypes, pVals, "BNationality");
            return int.Parse(dsTmp.Tables[0].Rows[0][0].ToString());
        }

        public int BGetIDofEducation(string EducationName)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@EducationName", EducationName);

            pTypes.Add("@EducationName", "nvarchar");

            DataSet dsTmp = new DataSet();
            dsTmp = executeResults("BGetIDofEducation", pTypes, pVals, "BEducationLevel");
            return int.Parse(dsTmp.Tables[0].Rows[0][0].ToString());
        }

        public string BGetEducationFromID(int id)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@id", id);

            pTypes.Add("@id", "int");

            object tmpObj = executeScalar("BGetEducationFromID", pTypes, pVals);
            return tmpObj as string;
        }

        public string BGetNationalityFromID(int id)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@id", id);

            pTypes.Add("@id", "int");

            object tmpObj = executeScalar("BGetNationalityFromID", pTypes, pVals);
            return tmpObj as string;
        }

        public int BInsertCandidatePreFinal(int FKPoliticalEntity, int ListPos, string Prefix, string Surname, string MiddleName,
            string FirstName, string Suffix, string DateBirth, string PlaceBirth, string JMB, string Address, int FKNationality, string Gender, string ValidDocumentNo,
            string VDNPlace, int isPassport, string ConctactAddress, string Phone, int FKEducation, string FaxNo, string Mail, string SignDate, int CandidateSign,
            int PresidentSign, int Statement, int PropertyStatement, int obrazac, string StatementPath, string Comment, int FKUser, string DateEntered, string ProtocolNo, string MainInfo, int NatMinority, int Cyrilic, int Minority)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@FKPoliticalEntity", FKPoliticalEntity);
            pVals.Add("@ListPos", ListPos);
            pVals.Add("@Prefix", Prefix);
            pVals.Add("@Surname", Surname);
            pVals.Add("@MiddleName", MiddleName);
            pVals.Add("@FirstName", FirstName);
            pVals.Add("@Suffix", Suffix);
            pVals.Add("@Datebirth", DateBirth);
            pVals.Add("@PlaceBirth", PlaceBirth);
            pVals.Add("@JMB", JMB);
            pVals.Add("@Address", Address);
            pVals.Add("@FKNationality", FKNationality);
            pVals.Add("@Gender", Gender);
            pVals.Add("@ValidDocumentNo", ValidDocumentNo);
            pVals.Add("@VDNPlace", VDNPlace);
            pVals.Add("@isPassport", isPassport);
            pVals.Add("@ConctactAddress", ConctactAddress);
            pVals.Add("@Phone", Phone);
            pVals.Add("@FKEducation", FKEducation);
            pVals.Add("@FaxNo", FaxNo);
            pVals.Add("@Mail", Mail);
            pVals.Add("@SignDate", SignDate);
            pVals.Add("@CandidateSign", CandidateSign);
            pVals.Add("@PresidentSign", PresidentSign);
            pVals.Add("@Statement", Statement);
            pVals.Add("@StatementPath", StatementPath);
            pVals.Add("@Comment", Comment);
            pVals.Add("@FKUser", FKUser);
            pVals.Add("@DateEntered", DateEntered);
            pVals.Add("@ProtocolNo", ProtocolNo);
            pVals.Add("@MainInfo", MainInfo);
            pVals.Add("@NatMinority", NatMinority);
            pVals.Add("@Cyrilic", Cyrilic);
            pVals.Add("@Minority", Minority);
            pVals.Add("@PropertyStatement", PropertyStatement);
            pVals.Add("@Obrazac", obrazac);


            pTypes.Add("@FKPoliticalEntity", "int");
            pTypes.Add("@ListPos", "int");
            pTypes.Add("@Prefix", "nvarchar");
            pTypes.Add("@Surname", "nvarchar");
            pTypes.Add("@MiddleName", "nvarchar");
            pTypes.Add("@FirstName", "nvarchar");
            pTypes.Add("@Suffix", "nvarchar");
            pTypes.Add("@Datebirth", "nvarchar");
            pTypes.Add("@PlaceBirth", "nvarchar");
            pTypes.Add("@JMB", "nvarchar");
            pTypes.Add("@Address", "nvarchar");
            pTypes.Add("@FKNationality", "int");
            pTypes.Add("@Gender", "nvarchar");
            pTypes.Add("@ValidDocumentNo", "nvarchar");
            pTypes.Add("@VDNPlace", "nvarchar");
            pTypes.Add("@isPassport", "nvarchar");
            pTypes.Add("@ConctactAddress", "nvarchar");
            pTypes.Add("@Phone", "nvarchar");
            pTypes.Add("@FKEducation", "int");
            pTypes.Add("@FaxNo", "nvarchar");
            pTypes.Add("@Mail", "nvarchar");
            pTypes.Add("@SignDate", "nvarchar");
            pTypes.Add("@CandidateSign", "int");
            pTypes.Add("@PresidentSign", "int");
            pTypes.Add("@Statement", "int");
            pTypes.Add("@StatementPath", "nvarchar");
            pTypes.Add("@Comment", "nvarchar");
            pTypes.Add("@FKUser", "int");
            pTypes.Add("@DateEntered", "nvarchar");
            pTypes.Add("@ProtocolNo", "nvarchar");
            pTypes.Add("@MainInfo", "nvarchar");
            pTypes.Add("@NatMinority", "int");
            pTypes.Add("@Cyrilic", "int");
            pTypes.Add("@Minority", "int");
            pTypes.Add("@PropertyStatement", "int");
            pTypes.Add("@Obrazac", "int");

            object obj = executeScalar("BInsertCandidatePreFinal", pTypes, pVals);
            return Convert.ToInt32(obj);
        }


        public void ProccStep1Complete(int level, int pe, int param)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@level", level);
            pVals.Add("@pe", pe);
            pVals.Add("@param", param);

            pTypes.Add("@level", "int");
            pTypes.Add("@pe", "int");
            pTypes.Add("@param", "int");

            executeScalar("ProccStep1Complete", pTypes, pVals);

        }
        public int verificationStep1_1()
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            DataSet dsTemp;
            dsTemp = executeResults("bVerification1-1", pTypes, pVals, "BCandidatesPreFinal");
            return int.Parse(dsTemp.Tables[0].Rows[0][0].ToString());
        }

        public int verificationStep1_2(int level)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();
            pVals.Add("@level", level);

            pTypes.Add("@level", "numeric");

            DataSet dsTemp;
            dsTemp = executeResults("bVerification1-2", pTypes, pVals, "BCandidatesPreFinal");
            return int.Parse(dsTemp.Tables[0].Rows[0][0].ToString());
        }

        public int verificationStep1_3(int politicalEntity)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();
            pVals.Add("@politicalEntity", politicalEntity);

            pTypes.Add("@politicalEntity", "numeric");
            DataSet dsTemp;
            dsTemp = executeResults("bVerification1-3", pTypes, pVals, "BCandidatesPreFinal");
            return int.Parse(dsTemp.Tables[0].Rows[0][0].ToString());
        }

        public int verificationStep1_4(int level, int politicalEntity)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();
            pVals.Add("@level", level);
            pVals.Add("@politicalEntity", politicalEntity);

            pTypes.Add("@level", "numeric");
            pTypes.Add("@politicalEntity", "numeric");
            DataSet dsTemp;
            dsTemp = executeResults("bVerification1-4", pTypes, pVals, "BCandidatesPreFinal");
            return int.Parse(dsTemp.Tables[0].Rows[0][0].ToString());
        }

        public int verificationStep2_1()
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();
            DataSet dsTemp;
            dsTemp = executeResults("bVerification2-1", pTypes, pVals, "BCandidatesPreFinal");
            return int.Parse(dsTemp.Tables[0].Rows[0][0].ToString());
        }
        public int verificationStep2_2(int level)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();
            pVals.Add("@level", level);
            pTypes.Add("@level", "numeric");
            DataSet dsTemp;
            dsTemp = executeResults("bVerification2-2", pTypes, pVals, "BCandidatesPreFinal");
            return int.Parse(dsTemp.Tables[0].Rows[0][0].ToString());
        }
        public int verificationStep2_3(int politicalEntity)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();
            pVals.Add("@politicalEntity", politicalEntity);
            pTypes.Add("@politicalEntity", "numeric");
            DataSet dsTemp;
            dsTemp = executeResults("bVerification2-3", pTypes, pVals, "BCandidatesPreFinal");
            return int.Parse(dsTemp.Tables[0].Rows[0][0].ToString());
        }
        public int verificationStep2_4(int level, int politicalEntity)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();
            pVals.Add("@level", level);
            pVals.Add("@politicalEntity", politicalEntity);

            pTypes.Add("@level", "numeric");
            pTypes.Add("@politicalEntity", "numeric");
            DataSet dsTemp;
            dsTemp = executeResults("bVerification2-4", pTypes, pVals, "BCandidatesPreFinal");
            return int.Parse(dsTemp.Tables[0].Rows[0][0].ToString());
        }
        public DataSet verificationAddComment(int id, string textBOS, string textSR, string textHR, string textEN)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();
            pVals.Add("@id", id);
            pVals.Add("@textBOS", textBOS);
            pVals.Add("@textSR", textSR);
            pVals.Add("@textHR", textHR);
            pVals.Add("@textEN", textEN);

            pTypes.Add("@id", "numeric");
            pTypes.Add("@textBOS", "nvarchar");
            pTypes.Add("@textSR", "nvarchar");
            pTypes.Add("@textHR", "nvarchar");
            pTypes.Add("@textEN", "nvarchar");

            DataSet dsTemp;
            dsTemp = executeResults("bVerificationAddComment", pTypes, pVals, "BCandidatesPreFinal");
            return dsTemp;
        }

        public DataSet ProccStep2Start(int level, int pe, int param)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@level", level);
            pVals.Add("@pe", pe);
            pVals.Add("@param", param);

            pTypes.Add("@level", "int");
            pTypes.Add("@pe", "int");
            pTypes.Add("@param", "int");

            DataSet dsTemp = new DataSet();
            dsTemp = executeResults("ProccStep2Start", pTypes, pVals, "BCertifiedPolitivalEntities");
            return dsTemp;
        }

        public void BInsertLogs(int uid, string action, string page, DateTime dtime, string ipadress)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@User_ID", uid);
            pVals.Add("@Action", action);
            pVals.Add("@Page", page);
            pVals.Add("@DateTime", dtime);
            pVals.Add("@IPadress", ipadress);

            pTypes.Add("@User_ID", "int");
            pTypes.Add("@Action", "nvarchar");
            pTypes.Add("@Page", "nvarchar");
            pTypes.Add("@DateTime", "datetime");
            pTypes.Add("@IPadress", "nvarchar");

            executeScalar("BInsertLogs", pTypes, pVals);
        }

        public void BUpdateCorrectedMismatches(int id)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@id", id);

            pTypes.Add("@id", "int");

            executeScalar("BUpdateCorrectedMismatches", pTypes, pVals);
        }

        public DataSet ProccGetMandatesAllocation()
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            DataSet dsTemp = new DataSet();
            dsTemp = executeResults("ProccGetMandatesAllocation", pTypes, pVals, "MinorityGenderAllocation");
            return dsTemp;
        }

        public int verificationStep3_1()
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();
            DataSet dsTemp;
            dsTemp = executeResults("bVerification3-1", pTypes, pVals, "BCandidatesPreFinal");
            return int.Parse(dsTemp.Tables[0].Rows[0][0].ToString());
        }
        public int verificationStep3_2(int level)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();
            pVals.Add("@level", level);
            pTypes.Add("@level", "numeric");
            DataSet dsTemp;
            dsTemp = executeResults("bVerification3-2", pTypes, pVals, "BCandidatesPreFinal");
            return int.Parse(dsTemp.Tables[0].Rows[0][0].ToString());
        }
        public int verificationStep3_3(int politicalEntity)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();
            pVals.Add("@politicalEntity", politicalEntity);
            pTypes.Add("@politicalEntity", "numeric");
            DataSet dsTemp;
            dsTemp = executeResults("bVerification3-3", pTypes, pVals, "BCandidatesPreFinal");
            return int.Parse(dsTemp.Tables[0].Rows[0][0].ToString());
        }
        public int verificationStep3_4(int level, int politicalEntity)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();
            pVals.Add("@level", level);
            pVals.Add("@politicalEntity", politicalEntity);

            pTypes.Add("@level", "numeric");
            pTypes.Add("@politicalEntity", "numeric");
            DataSet dsTemp;
            dsTemp = executeResults("bVerification3-4", pTypes, pVals, "BCandidatesPreFinal");
            return int.Parse(dsTemp.Tables[0].Rows[0][0].ToString());
        }

        public int verificationStep5_1()
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            DataSet dsTemp;
            dsTemp = executeResults("bVerification5-1", pTypes, pVals, "BCandidatesPreFinal");
            return int.Parse(dsTemp.Tables[0].Rows[0][0].ToString());
        }

        public int verificationStep5_2(int level)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();
            pVals.Add("@level", level);

            pTypes.Add("@level", "numeric");

            DataSet dsTemp;
            dsTemp = executeResults("bVerification5-2", pTypes, pVals, "BCandidatesPreFinal");
            return int.Parse(dsTemp.Tables[0].Rows[0][0].ToString());
        }

        public int verificationStep5_3(int politicalEntity)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();
            pVals.Add("@politicalEntity", politicalEntity);

            pTypes.Add("@politicalEntity", "numeric");
            DataSet dsTemp;
            dsTemp = executeResults("bVerification5-3", pTypes, pVals, "BCandidatesPreFinal");
            return int.Parse(dsTemp.Tables[0].Rows[0][0].ToString());
        }

        public int verificationStep5_4(int level, int politicalEntity)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();
            pVals.Add("@level", level);
            pVals.Add("@politicalEntity", politicalEntity);

            pTypes.Add("@level", "numeric");
            pTypes.Add("@politicalEntity", "numeric");
            DataSet dsTemp;
            dsTemp = executeResults("bVerification5-4", pTypes, pVals, "BCandidatesPreFinal");
            return int.Parse(dsTemp.Tables[0].Rows[0][0].ToString());
        }
        public int verificationStep4_1()
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            DataSet dsTemp;
            dsTemp = executeResults("bVerification4-1", pTypes, pVals, "BCandidatesPreFinal");
            return int.Parse(dsTemp.Tables[0].Rows[0][0].ToString());
        }

        public int verificationStep4_2(int level)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();
            pVals.Add("@level", level);

            pTypes.Add("@level", "numeric");

            DataSet dsTemp;
            dsTemp = executeResults("bVerification4-2", pTypes, pVals, "BCandidatesPreFinal");
            return int.Parse(dsTemp.Tables[0].Rows[0][0].ToString());
        }

        public int verificationStep4_3(int politicalEntity)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();
            pVals.Add("@politicalEntity", politicalEntity);

            pTypes.Add("@politicalEntity", "numeric");
            DataSet dsTemp;
            dsTemp = executeResults("bVerification4-3", pTypes, pVals, "BCandidatesPreFinal");
            return int.Parse(dsTemp.Tables[0].Rows[0][0].ToString());
        }

        public int verificationStep4_4(int level, int politicalEntity)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();
            pVals.Add("@level", level);
            pVals.Add("@politicalEntity", politicalEntity);

            pTypes.Add("@level", "numeric");
            pTypes.Add("@politicalEntity", "numeric");
            DataSet dsTemp;
            dsTemp = executeResults("bVerification4-4", pTypes, pVals, "BCandidatesPreFinal");
            return int.Parse(dsTemp.Tables[0].Rows[0][0].ToString());
        }

        public int bCountAllForVerification1()
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            DataSet dsTemp;
            dsTemp = executeResults("bCountAllForVerification-1", pTypes, pVals, "BCandidatesPreFinal");
            return int.Parse(dsTemp.Tables[0].Rows[0][0].ToString());
        }

        public int bCountAllForVerification2(int level)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();
            pVals.Add("@level", level);

            pTypes.Add("@level", "numeric");

            DataSet dsTemp;
            dsTemp = executeResults("bCountAllForVerification-2", pTypes, pVals, "BCandidatesPreFinal");
            return int.Parse(dsTemp.Tables[0].Rows[0][0].ToString());
        }

        public int bCountAllForVerification3(int politicalEntity)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();
            pVals.Add("@politicalEntity", politicalEntity);

            pTypes.Add("@politicalEntity", "numeric");
            DataSet dsTemp;
            dsTemp = executeResults("bCountAllForVerification-3", pTypes, pVals, "BCandidatesPreFinal");
            return int.Parse(dsTemp.Tables[0].Rows[0][0].ToString());
        }

        public int bCountAllForVerification4(int level, int politicalEntity)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();
            pVals.Add("@level", level);
            pVals.Add("@politicalEntity", politicalEntity);

            pTypes.Add("@level", "numeric");
            pTypes.Add("@politicalEntity", "numeric");
            DataSet dsTemp;
            dsTemp = executeResults("bCountAllForVerification-4", pTypes, pVals, "BCandidatesPreFinal");
            return int.Parse(dsTemp.Tables[0].Rows[0][0].ToString());
        }

        public int BCompareSecondCandidateEntry(int FKPoliticalEntity, int ListPos, string Prefix, string Surname, string MiddleName, string FirstName, string Suffix, string JMB)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@FKPoliticalEntity", FKPoliticalEntity);
            pVals.Add("@ListPos", ListPos);
            pVals.Add("@Prefix", Prefix);
            pVals.Add("@Surname", Surname);
            pVals.Add("@MiddleName", MiddleName);
            pVals.Add("@FirstName", FirstName);
            pVals.Add("@Suffix", Suffix);
            pVals.Add("@JMB", JMB);

            pTypes.Add("@FKPoliticalEntity", "int");
            pTypes.Add("@ListPos", "int");
            pTypes.Add("@Prefix", "nvarchar");
            pTypes.Add("@Surname", "nvarchar");
            pTypes.Add("@MiddleName", "nvarchar");
            pTypes.Add("@FirstName", "nvarchar");
            pTypes.Add("@Suffix", "nvarchar");
            pTypes.Add("@JMB", "nvarchar");

            DataSet dsTemp = new DataSet();
            dsTemp = executeResults("BCompareSecondCandidateEntry", pTypes, pVals, "BCandidates1");
            if (int.Parse(dsTemp.Tables[0].Rows[0][0].ToString()) > 0)
            {
                return int.Parse(dsTemp.Tables[1].Rows[0][0].ToString());
            }
            else
            {
                return 0;
            }
        }

        public void ProccStep2UpdateList(int idlist, int errorpos)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@idlist", idlist);
            pVals.Add("@errorpos", errorpos);

            pTypes.Add("@idlist", "int");
            pTypes.Add("@errorpos", "int");

            executeScalar("ProccStep2UpdateList", pTypes, pVals);
        }
        public void BGetFinalize(int idcr, int idpe, int idmr, int param)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@idcr", idcr);
            pVals.Add("@idpe", idpe);
            pVals.Add("@idmr", idmr);
            pVals.Add("@param", param);

            pTypes.Add("@idcr", "int");
            pTypes.Add("@idpe", "int");
            pTypes.Add("@idmr", "int");
            pTypes.Add("@param", "int");
            executeScalar("BGetFinalize", pTypes, pVals);
        }
        public void BDeleteFinal(int param1, int param2, int param3)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@param1", param1);
            pVals.Add("@param2", param2);
            pVals.Add("@param3", param3);

            pTypes.Add("@param1", "int");
            pTypes.Add("@param2", "int");
            pTypes.Add("@param3", "int");

            executeScalar("BDeleteFinal", pTypes, pVals);
        }

        public void bVerificationFinalize1()
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();
            executeScalar("bVerificationFinalize1", pTypes, pVals);

        }
        public void bVerificationFinalize2(int level)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();
            pVals.Add("@level", level);
            pTypes.Add("@level", "numeric");

            executeScalar("bVerificationFinalize2", pTypes, pVals);
        }
        public void bVerificationFinalize3(int politicalEntity)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();
            pVals.Add("@politicalEntity", politicalEntity);
            pTypes.Add("@politicalEntity", "numeric");
            executeScalar("bVerificationFinalize3", pTypes, pVals);
        }
        public void bVerificationFinalize4(int level, int politicalEntity)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();
            pVals.Add("@level", level);
            pVals.Add("@politicalEntity", politicalEntity);

            pTypes.Add("@level", "numeric");
            pTypes.Add("@politicalEntity", "numeric");
            executeScalar("bVerificationFinalize4", pTypes, pVals);
        }

        public void BInsertCorrectToCandidatesPreFinal(int id)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@id", id);

            pTypes.Add("@id", "id");

            executeScalar("BInsertCorrectToCandidatesPreFinal", pTypes, pVals);
        }


        //// NIDZZO 13.04.2010 //////////////////////////////////////////////////

        public string BGetPoliticalEntityName(int ID)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@ID", ID);

            pTypes.Add("@ID", "int");

            object tmpObj = executeScalar("BGetPoliticalEntityName", pTypes, pVals);
            return tmpObj as string;
        }

        public string BGetLevelByName(int ID)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@ID", ID);

            pTypes.Add("@ID", "int");

            object tmpObj = executeScalar("BGetLevelByName", pTypes, pVals);
            return tmpObj as string;
        }

        public int ProccStep1Complete1(int level, int pe, int param)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@level", level);
            pVals.Add("@pe", pe);
            pVals.Add("@param", param);

            pTypes.Add("@level", "int");
            pTypes.Add("@pe", "int");
            pTypes.Add("@param", "int");

            DataSet dsTemp = new DataSet();
            dsTemp = executeResults("ProccStep1Complete1", pTypes, pVals, "BCertifiedPolitivalEntities");
            if (int.Parse(dsTemp.Tables[0].Rows[0][0].ToString()) > 0)
            {
                return int.Parse(dsTemp.Tables[0].Rows[0][0].ToString());
            }
            else
            {
                return 0;
            }

        }

        public void DeleteMinority(int id)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@id", id);

            pTypes.Add("@id", "int");

            executeScalar("BDeleteMinority", pTypes, pVals);
        }

        public DataSet SelectMinorityForID(int id)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@id", id);

            pTypes.Add("@id", "int");
            DataSet ds = executeResults("SelectMinorityForID", pTypes, pVals, "Minority");
            return ds;
        }
        public void ModifyMinority(int id, string name)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@id", id);

            pTypes.Add("@id", "int");
            pVals.Add("@name", name);

            pTypes.Add("@name", "nvarchar");

            executeScalar("ModifyMinority", pTypes, pVals);

        }
        public void AddMinority(string name)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@name", name);

            pTypes.Add("@name", "nvarchar");
            executeScalar("AddMinority", pTypes, pVals);

        }

        public DataSet GetMinoritiesByCandidacyRace(int id)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@id", id);

            pTypes.Add("@id", "numeric");
            DataSet ds = executeResults("GetMinorities", pTypes, pVals, "BMunicipalityRegion");
            return ds;
        }
        public void updateMinorities(int id, string hasMinority, int numMinorities)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@id", id);
            pVals.Add("@hasMin", hasMinority);
            pVals.Add("@numMin", numMinorities);
            pTypes.Add("@id", "numeric");
            pTypes.Add("@hasMin", "nvarchar");
            pTypes.Add("@numMin", "numeric");
            executeScalar("updateMinorities", pTypes, pVals);
        }

        public int ImportCountForImport()
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            DataSet dsTemp = new DataSet();
            dsTemp = executeResults("ImportCountForImport", pTypes, pVals, "Partije");
            if (int.Parse(dsTemp.Tables[0].Rows[0][0].ToString()) > 0)
            {
                return int.Parse(dsTemp.Tables[0].Rows[0][0].ToString());
            }
            else
            {
                return 0;
            }
        }


        public void ImportDataFromIzbori2010()
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();
            executeScalar("ImportDataFromIzbori2010", pTypes, pVals);

        }

        public void ImportDataIntoBVoteDB()
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();
            executeScalar("ImportDataIntoBVoteDB", pTypes, pVals);

        }

        public DataSet M11GetTitlesForType(int type, int langu)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@type", type);
            pVals.Add("@langu", langu);


            pTypes.Add("@type", "numeric");
            pTypes.Add("@langu", "int");
            DataSet ds = executeResults("M11GetTitlesForType", pTypes, pVals, "M11Titles");
            return ds;
        }
        public void M11UpdateTitlesForType(int type, int langu, string head, string foot)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@type", type);
            pVals.Add("@langu", langu);
            pVals.Add("@head", head);
            pVals.Add("@foot", foot);

            pTypes.Add("@type", "numeric");
            pTypes.Add("@langu", "int");
            pTypes.Add("@head", "nvarchar");
            pTypes.Add("@foot", "nvarchar");
            executeScalar("M11UpdateTitlesForType", pTypes, pVals);

        }
        public DataSet M11GetTitlesForTypeM11D(int type, int langu)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@type", type);
            pVals.Add("@langu", langu);


            pTypes.Add("@type", "numeric");
            pTypes.Add("@langu", "int");
            DataSet ds = executeResults("M11GetTitlesForTypeM11D", pTypes, pVals, "M11Titles");
            return ds;
        }
        public DataSet M11GetTitlesForTypeM11E(int type, int langu)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@type", type);
            pVals.Add("@langu", langu);


            pTypes.Add("@type", "numeric");
            pTypes.Add("@langu", "int");
            DataSet ds = executeResults("M11GetTitlesForTypeM11E", pTypes, pVals, "M11Titles");
            return ds;
        }
        public void M11UpdateTitlesForTypeM11D(int type, int langu, string Head, string Odluku,
            string obrazlozenje, string PravnaOdluka, string FooterLeft, string FooterRight)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@type", type);
            pVals.Add("@langu", langu);
            pVals.Add("@Head", Head);
            pVals.Add("@Odluku", Odluku);
            pVals.Add("@obrazlozenje", obrazlozenje);
            pVals.Add("@PravnaOdluka", PravnaOdluka);
            pVals.Add("@FooterLeft", FooterLeft);
            pVals.Add("@FooterRight", FooterRight);


            pTypes.Add("@type", "int");
            pTypes.Add("@langu", "int");
            pTypes.Add("@Head", "nvarchar");
            pTypes.Add("@Odluku", "nvarchar");
            pTypes.Add("@obrazlozenje", "nvarchar");
            pTypes.Add("@PravnaOdluka", "nvarchar");
            pTypes.Add("@FooterLeft", "nvarchar");
            pTypes.Add("@FooterRight", "nvarchar");
            executeScalar("M11UpdateTitlesForTypeM11D", pTypes, pVals);

        }


        public void M11UpdateTitlesForTypeM11E(int type, int langu, string Head, string Odluku,
            string obrazlozenje, string PravnaOdluka, string FooterLeft, string FooterRight)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@type", type);
            pVals.Add("@langu", langu);
            pVals.Add("@Head", Head);
            pVals.Add("@Odluku", Odluku);
            pVals.Add("@obrazlozenje", obrazlozenje);
            pVals.Add("@PravnaOdluka", PravnaOdluka);
            pVals.Add("@FooterLeft", FooterLeft);
            pVals.Add("@FooterRight", FooterRight);


            pTypes.Add("@type", "int");
            pTypes.Add("@langu", "int");
            pTypes.Add("@Head", "nvarchar");
            pTypes.Add("@Odluku", "nvarchar");
            pTypes.Add("@obrazlozenje", "nvarchar");
            pTypes.Add("@PravnaOdluka", "nvarchar");
            pTypes.Add("@FooterLeft", "nvarchar");
            pTypes.Add("@FooterRight", "nvarchar");

            executeScalar("M11UpdateTitlesForTypeM11E", pTypes, pVals);

        }
        //ImportVoter
        public void ImportVoter()
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            //// 0-e Time Out, i Time Outot znaci deka ne e ograniceno vremeto na izvrsuvanje
            executeScalarWithTimeOut("ImportVoter", pTypes, pVals, 0);
        }




        public DataSet GetMandatesByCandidacyRace(int id)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@id", id);

            pTypes.Add("@id", "numeric");
            DataSet ds = executeResults("GetMandatesByCandidacyRace", pTypes, pVals, "BMunicipalityRegion");
            return ds;
        }
        public void updateMandates(int id, int numMin, int maxNum)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@id", id);
            pVals.Add("@numMin", numMin);
            pVals.Add("@maxNum", maxNum);
            pTypes.Add("@id", "int");
            pTypes.Add("@numMin", "int");
            pTypes.Add("@maxNum", "int");
            executeScalar("updateMandates", pTypes, pVals);
        }

        public string BGetCertifiedPoliticalEntityName(int ID)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@ID", ID);

            pTypes.Add("@ID", "int");

            object tmpObj = executeScalar("BGetCertifiedPoliticalEntityName", pTypes, pVals);
            return tmpObj as string;
        }

        ////////////////////////////// NIDZZO 26.04.2010 ///////////////////////////////////////////////

        public void BDeleteCanidateFromBCandidates1(int id)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@id", id);

            pTypes.Add("@id", "int");

            executeScalar("BDeleteCanidateFromBCandidates1", pTypes, pVals);
        }

        public void BDeleteCanidateFromBCandidates2(int id, string jmb)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@id", id);
            pVals.Add("@jmb", jmb);
            pTypes.Add("@id", "int");
            pTypes.Add("@jmb", "nvarchar");

            executeScalar("BDeleteCanidateFromBCandidates2", pTypes, pVals);
        }

        public bool BCheckIfJMBIsAlreadyEntered1(string JMB, int certPolParty)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@JMB", JMB);
            pVals.Add("@certPolParty", certPolParty);

            pTypes.Add("@JMB", "string");
            pTypes.Add("@certPolParty", "int");

            DataSet dsTmp = new DataSet();
            dsTmp = executeResults("BCheckIfJMBIsAlreadyEntered1", pTypes, pVals, "BCandidates1");
            if (dsTmp.Tables[0].Rows.Count > 0)
            {
                return true;
            }
            else
                return false;
        }

        public bool BCheckIfJMBIsAlreadyEntered2(string JMB, int certPolParty)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@JMB", JMB);
            pVals.Add("@certPolParty", certPolParty);

            pTypes.Add("@JMB", "string");
            pTypes.Add("@certPolParty", "int");

            DataSet dsTmp = new DataSet();
            dsTmp = executeResults("BCheckIfJMBIsAlreadyEntered2", pTypes, pVals, "BCandidates2");
            if (dsTmp.Tables[0].Rows.Count > 0)
            {
                return true;
            }
            else
                return false;
        }

        public void BUpdateMismatchByUpdatedSecondEntry(string JMB, int certPolParty)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@JMB", JMB);
            pVals.Add("@certPolParty", certPolParty);

            pTypes.Add("@JMB", "string");
            pTypes.Add("@certPolParty", "int");

            executeScalar("BUpdateMismatchByUpdatedSecondEntry", pTypes, pVals);
        }

        // NIDZZO 30.04.2010 ////////////////////////////////////////////////////////

        public DataSet BGetCertifiedPoliticalEntityDataByID(int id)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@id", id);

            pTypes.Add("@id", "int");
            DataSet ds = executeResults("BGetCertifiedPoliticalEntityDataByID", pTypes, pVals, "BCertifiedPolitivalEntities");
            return ds;
        }

        // NIDZZO 05.05.2010 ////////////////////////////////////////////////////////

        public DataSet BGetCandidateFromBCandidate1byJMB(string JMB, int certPolEnt)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@JMB", JMB);
            pVals.Add("@certPolEnt", certPolEnt);

            pTypes.Add("@JMB", "nvarchar");
            pTypes.Add("@certPolEnt", "int");

            DataSet ds = executeResults("BGetCandidateFromBCandidate1byJMB", pTypes, pVals, "BCandidate1");
            return ds;
        }

        public void BDeleteCanidateFromBCandidates2afterUpdate(string jmb)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@jmb", jmb);
            pTypes.Add("@jmb", "nvarchar");

            executeScalar("BDeleteCanidateFromBCandidates2afterUpdate", pTypes, pVals);
        }

        public void BUpdateCorrectedMismatchesToFalseAfterUpdateSecondEntry(string jmb)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@jmb", jmb);
            pTypes.Add("@jmb", "nvarchar");

            executeScalar("BUpdateCorrectedMismatchesToFalseAfterUpdateSecondEntry", pTypes, pVals);
        }


        public DataSet BGetAllActiveLevelsForCandidacyRace1(int crid)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@candidacyRace", crid);

            pTypes.Add("@candidacyRace", "int");

            DataSet ds = executeResults("BGetAllActiveLevelsForCandidacyRace1", pTypes, pVals, "BMunicipalityRegion");
            return ds;
        }
        //getLabelText(string type, int race, string label)
        public DataSet getLabelText(string type, int race, string label, string latin)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@type", type);
            pVals.Add("@race", race);
            pVals.Add("@label", label);
            pVals.Add("@latin", latin);
            pTypes.Add("@latin", "varchar");
            pTypes.Add("@type", "varchar");
            pTypes.Add("@race", "int");
            pTypes.Add("@label", "varchar");

            DataSet ds = executeResults("GetAllTypesOfZRDataComplete", pTypes, pVals, "ReportData");
            return ds;

            //////////////
        }
        public void updateLabelText(string type, int race, string label, string latin, string description)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@type", type);
            pVals.Add("@race", race);
            pVals.Add("@label", label);
            pVals.Add("@latin", latin);
            pVals.Add("@descr", description);
            pTypes.Add("@descr", "varchar");
            pTypes.Add("@latin", "varchar");
            pTypes.Add("@type", "varchar");
            pTypes.Add("@race", "int");
            pTypes.Add("@label", "varchar");

            executeScalar("UpdateTypesOfZRData", pTypes, pVals);
        }


        public void updateBallotText(string type, int race, string label, string latin, string description)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@type", type);
            pVals.Add("@race", race);
            pVals.Add("@label", label);
            pVals.Add("@latin", latin);
            pVals.Add("@descr", description);
            pTypes.Add("@descr", "varchar");
            pTypes.Add("@latin", "varchar");
            pTypes.Add("@type", "varchar");
            pTypes.Add("@race", "int");
            pTypes.Add("@label", "varchar");

            executeScalar("UpdateTypesOfBallotData", pTypes, pVals);
        }
        public DataSet getBallotsText(string type, int race, string label, string latin)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@type", type);
            pVals.Add("@race", race);
            pVals.Add("@label", label);
            pVals.Add("@latin", latin);
            pTypes.Add("@latin", "varchar");
            pTypes.Add("@type", "varchar");
            pTypes.Add("@race", "int");
            pTypes.Add("@label", "varchar");

            DataSet ds = executeResults("GetAllTypesOfBallotsDataComplete", pTypes, pVals, "BallotData");
            return ds;

            //////////////
        }
        public DataSet GetLevelDataByScript(int id, string script)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@id", id);
            pVals.Add("@script", script);

            pTypes.Add("@id", "int");
            pTypes.Add("@script", "varchar");



            DataSet ds = executeResults("GetLevelDataByScript", pTypes, pVals, "LevelData");
            return ds;

            //////////////
        }
        public DataSet P2GetCandidacyRaceCyrilic(int type)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@type", type);

            pTypes.Add("@type", "int");
            DataSet ds = executeResults("P2GetCandidacyRaceCyrilic", pTypes, pVals, "BCandidacyRace");
            return ds;

            //////////////
        }
        public DataSet P2GetFieldsTemplate(int type)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@type", type);

            pTypes.Add("@type", "int");
            DataSet ds = executeResults("P2GetFieldsTemplate", pTypes, pVals, "BallotData");
            return ds;

            //////////////
        }
        public int LevelHasNM(string code)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@code", code);

            pTypes.Add("@code", "nvarchar");

            object obj = executeScalar("LevelHasNM", pTypes, pVals);
            int count = 0;
            count = Convert.ToInt32(obj);
            return count;
        }
        public DataSet P2_SelectBallotsParameter(string type, int number)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@type", type);
            pVals.Add("@number", number);

            pTypes.Add("@type", "varchar");
            pTypes.Add("@number", "int");

            DataSet ds = executeResults("P2_SelectBallotsParameter", pTypes, pVals, "p2_BallotsParameter");
            return ds;

            //////////////
        }



        public DataSet p2_CountBallotsCandidate(int race, int level)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@race", race);
            pVals.Add("@level", level);

            pTypes.Add("@race", "int");
            pTypes.Add("@level", "int");

            DataSet ds = executeResults("p2_CountBallotsCandidate", pTypes, pVals, "BFinalCandidatesLists");
            return ds;

            //////////////
        }
        public DataSet M12GetAllLevelsForGenerating()
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();


            DataSet ds = executeResults("M12GetAllLevelsForGenerating", pTypes, pVals, "BFinalCandidatesLists");
            return ds;

            //////////////
        }
        public DataSet M12GetAllLevelsForGeneratingVG()
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();


            DataSet ds = executeResults("M12GetAllLevelsForGeneratingVG", pTypes, pVals, "BFinalCandidatesLists");
            return ds;

            //////////////
        }
        public DataSet BGetAllActiveLevelsForCandidacyRace1New(int crid)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@candidacyRace", crid);

            pTypes.Add("@candidacyRace", "int");

            DataSet ds = executeResults("BGetAllActiveLevelsForCandidacyRace1New", pTypes, pVals, "BMunicipalityRegion");
            return ds;
        }

        public DataSet BGetCompensationListCandidatesGenderForValidation(string Region, string party)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@Region", Region);
            pVals.Add("@party", party);

            pTypes.Add("@Region", "string");
            pTypes.Add("@party", "string");

            DataSet ds = executeResults("BGetCompensationListCandidatesGenderForValidation", pTypes, pVals, "CompensationLists");
            return ds;

            //////////////
        }

        public void BGetCompensationListUPDATE(string Region, string party, int brojce)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@Region", Region);
            pVals.Add("@party", party);
            pVals.Add("@brojce", brojce);

            pTypes.Add("@Region", "string");
            pTypes.Add("@party", "string");
            pTypes.Add("@brojce", "int");

            executeScalar("BGetCompensationListUPDATE", pTypes, pVals);
        }

        public DataSet BGetFinalizeListCandidates(string level, string pname, int race)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@level", level);
            pVals.Add("@pname", pname);
            pVals.Add("@race", race);

            pTypes.Add("@level", "nvarchar");
            pTypes.Add("@pname", "nvarchar");
            pTypes.Add("@race", "int");

            DataSet ds = executeResults("BGetFinalizeListCandidates", pTypes, pVals, "BCandidatesFinal");
            return ds;

            //////////////
        }

        public void BCopyCandidatesFinishedFirstRound()
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            executeScalar("BCopyCandidatesFinishedFirstRound", pTypes, pVals);
        }

        //brisenje na bazata
        public void DeleteAll()
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            executeScalar("BTRUNCATEAll", pTypes, pVals);

        }

        //Delete candidates
        public void DeleteAllCandidates()
        {
            try
            {
                Dictionary<string, object> pVals = new Dictionary<string, object>();
                Dictionary<string, string> pTypes = new Dictionary<string, string>();

                executeScalar1("BTRUNCATECANDIDATES", pTypes, pVals);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }

        }

        public string BGetMinorityFromID(int id)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@id", id);

            pTypes.Add("@id", "int");

            object tmpObj = executeScalar("BGetMinorityFromID", pTypes, pVals);
            return tmpObj as string;
        }

        public int BGetMinorityFromName(string Name)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@Name", Name);

            pTypes.Add("@Name", "nvarchar");
            DataSet dsTmp = new DataSet();
            dsTmp = executeResults("BGetMinorityFromName", pTypes, pVals, "Minority");
            return int.Parse(dsTmp.Tables[0].Rows[0][0].ToString());
        }

        //////////////31.05.2010


        // Aleksandra 25.05.2010
        public void p3BUpdateTurnoutSettings(string FirstTime, string SecondTime, string ThirdTime)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@FirstTime", FirstTime);
            pVals.Add("@SecondTime", SecondTime);
            pVals.Add("@ThirdTime", ThirdTime);

            pTypes.Add("@FirstTime", "varchar");
            pTypes.Add("@SecondTime", "varchar");
            pTypes.Add("@ThirdTime", "varchar");

            executeScalar("p3BUpdateTurnoutSettings", pTypes, pVals);
        }

        public DataSet p3_Turnout_GetDataFromTurnoutSettings()
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            DataSet ds = executeResults("p3_Turnout_GetDataFromTurnoutSettings", pTypes, pVals, "p3_TurnoutSettings");
            return ds;

            //////////////
        }

        //Aleksandra 25.05.2010

        public DataSet p3BSelectTurnoutSettings()
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();
            DataSet ds = executeResults("p3BSelectTurnoutSettings", pTypes, pVals, "p3_TurnoutSettings");
            return ds;


            //////////////
        }

        public DataSet p3_Turnout_GetTotalVotersForPS(int idps)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@idps", idps);

            pTypes.Add("@idps", "int");

            DataSet ds = executeResults("p3_Turnout_GetTotalVotersForPS", pTypes, pVals, "p3_PollingStation");
            return ds;

            //////////////
        }


        public void p3_Turnout_Insert(int fkps, string codeps, string muncode, bool open, int first,
           double firstperc, int second, double secondperc, int third, double thirdperc, bool closed)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@fkps", fkps);
            pVals.Add("@codeps", codeps);
            pVals.Add("@muncode", muncode);
            pVals.Add("@open", open);
            pVals.Add("@first", first);
            pVals.Add("@firstperc", firstperc);
            pVals.Add("@second", second);
            pVals.Add("@secondperc", secondperc);
            pVals.Add("@third", third);
            pVals.Add("@thirdperc", thirdperc);
            pVals.Add("@closed", closed);

            pTypes.Add("@fkps", "int");
            pTypes.Add("@codeps", "string");
            pTypes.Add("@muncode", "string");
            pTypes.Add("@open", "bit");
            pTypes.Add("@first", "int");
            pTypes.Add("@firstperc", "double");
            pTypes.Add("@second", "int");
            pTypes.Add("@secondperc", "double");
            pTypes.Add("@third", "int");
            pTypes.Add("@thirdperc", "double");
            pTypes.Add("@closed", "bit");

            executeScalar("p3_Turnout_Insert", pTypes, pVals);
        }

        public DataSet BGetMunRegionDataForUserID(int user)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@userId", user);

            pTypes.Add("@userId", "int");

            DataSet ds = executeResults("p3GetMunRegionDataForUserID", pTypes, pVals, "p3_MECUsers");
            return ds;
        }
        public string BGetMunRegionDataForMunCode(string munCode)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@munCode", munCode);

            pTypes.Add("@munCode", "nvarchar");

            DataSet ds = executeResults("BGetMunicipalityRegionForMunicipalityCode", pTypes, pVals, "BMunicipalityRegion");
            return ds.Tables[0].Rows[0][0].ToString();
        }
        public void BInsertMunRegionDataForUserID(int user, string code)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@userId", user);
            pVals.Add("@code", code);

            pTypes.Add("@userId", "int");
            pTypes.Add("@code", "nvarchar");

            executeScalar("p3InsertMunRegionDataForUserID", pTypes, pVals);
        }

        public void BUpdateMunRegionDataForUserID(int user, string code)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@userId", user);
            pVals.Add("@code", code);

            pTypes.Add("@userId", "int");
            pTypes.Add("@code", "nvarchar");

            executeScalar("p3UpdateMunRegionDataForUserID", pTypes, pVals);
        }
        public void BUpdateP3_MECUsers(int UserID, string MunCode, string MunName, short ResultsEntry, string MECKey)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@userId", UserID);
            pVals.Add("@MunCode", MunCode);
            pVals.Add("@MunName", MunName);
            pVals.Add("@ResultsEntry", ResultsEntry);
            pVals.Add("@MECKey", MECKey);

            pTypes.Add("@userId", "int");
            pTypes.Add("@MunCode", "nvarchar");
            pTypes.Add("@MunName", "varchar");
            pTypes.Add("@ResultsEntry", "bit");
            pTypes.Add("@MECKey", "nvarchar");

            executeScalar("dms_update_p3_MECUsers", pTypes, pVals);
        }
        public void BDeleteMunRegionDataForUserID(int user)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@userId", user);

            pTypes.Add("@userId", "int");

            executeScalar("p3DeleteMunRegionDataForUserID", pTypes, pVals);
        }


        public DataSet p3_getDataFromBoxByID(string BoxName)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@BoxName", BoxName);

            pTypes.Add("@BoxName", "nvarchar");

            DataSet ds = executeResults("p3_getDataFromBoxByID", pTypes, pVals, "p3_Box");
            return ds;
        }


        public DataSet p3getNationalityAllocation(string code, int param, int raceID)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@code", code);
            pVals.Add("@param", param);
            pVals.Add("@raceID", raceID);


            pTypes.Add("@code", "nvarchar");
            pTypes.Add("@param", "int");
            pTypes.Add("@raceID", "int");


            DataSet ds = executeResults("p3getNationalityAllocation", pTypes, pVals, "p3_NationalityAllocation");
            return ds;
        }

        public void p3_Insert_p3_PSTurnout(int FKPS, string CodePS, bool IsOpenOnTime, string comment, string openingTime)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@FKPS", FKPS);
            pVals.Add("@CodePS", CodePS);
            pVals.Add("@IsOpenOnTime", IsOpenOnTime);
            pVals.Add("@commentOpen", comment);
            pVals.Add("@openingTime", openingTime);

            pTypes.Add("@FKPS", "numeric");
            pTypes.Add("@CodePS", "nvarchar");
            pTypes.Add("@IsOpenOnTime", "bit");
            pTypes.Add("@commentOpen", "nvarchar");
            pTypes.Add("@openingTime", "nvarchar");

            executeScalar("p3_Insert_p3_PSTurnout", pTypes, pVals);
        }

        public void p3_InsertMessages(string msg, int userFrom, int userTo)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@msg", msg);
            pVals.Add("@userFrom", userFrom);
            pVals.Add("@userTo", userTo);

            pTypes.Add("@msg", "nvarchar");
            pTypes.Add("@userFrom", "int");
            pTypes.Add("@userTo", "int");

            executeScalar("p3InsertMessages", pTypes, pVals);
        }

        public string p3_PreviewMessage(int id)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@id", id);

            pTypes.Add("@id", "int");

            string temp = (string)executeScalar("p3PreviewMessage", pTypes, pVals);
            return temp;
        }


        public DataSet p3_Turnout_GetCountTime(string pscode)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@pscode", pscode);

            pTypes.Add("@pscode", "string");

            DataSet ds = executeResults("p3_Turnout_GetCountTime", pTypes, pVals, "p3_PSTurnOut");
            return ds;

            //////////////
        }


        public void p3_Turnout_UpdateForTime(int param, string pscode, int turnout, string perc)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@param", param);
            pVals.Add("@pscode", pscode);
            pVals.Add("@turnout", turnout);
            pVals.Add("@perc", perc);

            pTypes.Add("@param", "int");
            pTypes.Add("@pscode", "string");
            pTypes.Add("@turnout", "int");
            pTypes.Add("@perc", "string");

            executeScalar("p3_Turnout_UpdateForTime", pTypes, pVals);
        }

        public void p3_TurnoutUnConfirmed_UpdateForTime(int param, string munCode, int turnout)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@param", param);
            pVals.Add("@munCode", munCode);
            pVals.Add("@turnout", turnout);
            pTypes.Add("@param", "int");
            pTypes.Add("@munCode", "string");
            pTypes.Add("@turnout", "int");

            executeScalar("p3_TurnoutUnConfirmed_UpdateForTime", pTypes, pVals);
        }
        public void p3_UpdateMessage(int id)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@id", id);

            pTypes.Add("@id", "int");

            executeScalar("p3UpdateMessage", pTypes, pVals);
        }
        public DataSet p3_getDataFromBagsByID(int ID)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@ID", ID);

            pTypes.Add("@ID", "int");

            DataSet ds = executeResults("p3_getDataFromBagsByID", pTypes, pVals, "p3_Bags");
            return ds;
        }

        public void p3_InsertEmptyBagsInto_P3Bags(string typeBag, int numberCopies, string TypeMunicipality)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@TypeBag", typeBag);

            pTypes.Add("@TypeBag", "nvarchar");

            pVals.Add("@NumberCopies", numberCopies);

            pTypes.Add("@NumberCopies", "int");

            pVals.Add("@TypeMunicipality", TypeMunicipality);

            pTypes.Add("@TypeMunicipality", "nvarchar");

            executeScalar("p3_InsertEmptyBagsInto_P3Bags", pTypes, pVals);
        }
        //sh 06.10.2012
        public void p3_InsertEmptyBagsInto_P3Bags_Odsustvo(string typeBag, string PSCode)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@TypeBag", typeBag);

            pTypes.Add("@TypeBag", "nvarchar");

            pVals.Add("@PSCode", PSCode);

            pTypes.Add("@PSCode", "nvarchar");

            executeScalar("p3_InsertEmptyBagsInto_P3Bags_Odsustvo", pTypes, pVals);
        }

        public void p3_InsertEmptyBagsInto_P3Bags_Mobilni(string typeBag, string MunCode, string Entity, string NumberMobile, string NumberGenerate)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@TypeBag", typeBag);

            pTypes.Add("@TypeBag", "nvarchar");

            pVals.Add("@MunCode", MunCode);

            pTypes.Add("@MunCode", "nvarchar");

            pVals.Add("@Entity", Entity);

            pTypes.Add("@Entity", "varchar");

            pVals.Add("@NumberMobile", NumberMobile);

            pTypes.Add("@NumberMobile", "nvarchar");

            pVals.Add("@NumberGenerate", NumberGenerate);

            pTypes.Add("@NumberGenerate", "nvarchar");

            executeScalar("p3_InsertEmptyBagsInto_P3Bags_Mobilni", pTypes, pVals);
        }
        //---------------------

        public void p3_UpdateCloseStation(string CodePS, string commentClose, string closingTime, bool closed)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();


            pVals.Add("@CodePS", CodePS);

            pVals.Add("@commentClose", commentClose);
            pVals.Add("@closingTime", closingTime);
            pVals.Add("@closed", closed);



            pTypes.Add("@CodePS", "nvarchar");
            pTypes.Add("@commentClose", "nvarchar");
            pTypes.Add("@closingTime", "nvarchar");
            pTypes.Add("@closed", "bit");
            executeScalar("p3_UpdateCloseStation", pTypes, pVals);
        }

        public void p3_UpdateCloseStation(string CodePS)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();


            pVals.Add("@CodePS", CodePS);



            pTypes.Add("@CodePS", "nvarchar");


            executeScalar("p3_UpdateCloseStation", pTypes, pVals);
        }
        public void p3_UpdateResultsEntry(int id, int allow, string code)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@user", id);
            pVals.Add("@allow", allow);
            pVals.Add("@code", code);

            pTypes.Add("@user", "int");
            pTypes.Add("@allow", "int");
            pTypes.Add("@code", "varchar");

            executeScalar("p3UpdateResultsEntry", pTypes, pVals);
        }

        public bool p3_Results_CheckIfUserCanEnter(int iduser)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@iduser", iduser);

            pTypes.Add("@iduser", "int");

            DataSet ds = executeResults("p3_Results_CheckIfUserCanEnter", pTypes, pVals, "p3_MECUsers");
            if (ds.Tables[0].Rows.Count > 0)
            {
                return Boolean.Parse(ds.Tables[0].Rows[0][0].ToString());
            }
            else
            {
                return false;
            }
        }



        public string p3_getlevelsMecUsersSELECT(int iduser)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@id", iduser);

            pTypes.Add("@id", "int");

            DataSet ds = executeResults("p3_getlevelsMecUsersSELECT", pTypes, pVals, "p3_MECUsers");
            if (ds.Tables[0].Rows.Count > 0)
            {
                return ds.Tables[0].Rows[0][1].ToString();
            }
            else
            {
                return "false";
            }
        }

        public DataSet p3_Results_CheckIfPSReadyForEntry(string PSNumber, int FKCandidacyRace)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@PSNumber", PSNumber);
            pVals.Add("@FKCandidacyRace", FKCandidacyRace);

            pTypes.Add("@PSNumber", "string");
            pTypes.Add("@FKCandidacyRace", "int");

            DataSet dsTmp = new DataSet();
            dsTmp = executeResults("p3_Results_CheckIfPSReadyForEntry", pTypes, pVals, "p3_ResultsEntriesArchive");
            return dsTmp;
        }

        public string p3_Results_GetLevelCodeForMunicipalityAndRace(int idrace, string muncode)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@idrace", idrace);
            pVals.Add("@muncode", muncode);

            pTypes.Add("@idrace", "int");
            pTypes.Add("@muncode", "string");

            DataSet dsTmp = new DataSet();
            dsTmp = executeResults("p3_Results_GetLevelCodeForMunicipalityAndRace", pTypes, pVals, "BMunicipalityRegion");
            return dsTmp.Tables[0].Rows[0][0].ToString();
        }
        public int p3_ActivatePSforScanning(string psCode)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@psCode", psCode);
            pTypes.Add("@psCode", "nvarchar");

            DataSet dsTmp = new DataSet();
            dsTmp = executeResults("p3_ActivatePSforScanning", pTypes, pVals, "p3_VotesCast");
            return int.Parse(dsTmp.Tables[0].Rows[0][0].ToString());
        }

        public int p3_ActivateBagforScanning(string psCode)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@psCode", psCode);
            pTypes.Add("@psCode", "nvarchar");

            DataSet dsTmp = new DataSet();
            dsTmp = executeResults("p3_ActivateBagforScanning", pTypes, pVals, "p3_VotesCast");
            return int.Parse(dsTmp.Tables[0].Rows[0][0].ToString());
        }
        public void p3_FinalizePSforScanning(string psCode, int accepted)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();


            pVals.Add("@psCode", psCode);
            pVals.Add("@accepted", accepted);

            pTypes.Add("@psCode", "nvarchar");
            pTypes.Add("@accepted", "int");

            executeScalar("p3_FinalizePSforScanning", pTypes, pVals);
        }
        public void p3_FinalizeBagforScanning(string psCode, int accepted)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();


            pVals.Add("@psCode", psCode);
            pVals.Add("@accepted", accepted);

            pTypes.Add("@psCode", "nvarchar");
            pTypes.Add("@accepted", "int");

            executeScalar("p3_FinalizeBagforScanning", pTypes, pVals);
        }



        public void p3_EditOpenStation(int FKPS, int TurnOutFirst, int TurnOutSecond, int TurnOutThird, string TurnOutFirstPerc, string TurnOutSecondPerc, string TurnOutThirdPerc)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@FKPS", FKPS);
            pVals.Add("@TurnOutFirst", TurnOutFirst);
            pVals.Add("@TurnOutSecond", TurnOutSecond);
            pVals.Add("@TurnOutThird", TurnOutThird);

            pVals.Add("@TurnOutFirstPerc", TurnOutFirstPerc);
            pVals.Add("@TurnOutSecondPerc", TurnOutSecondPerc);
            pVals.Add("@TurnOutThirdPerc", TurnOutThirdPerc);


            pTypes.Add("@FKPS", "numeric");
            pTypes.Add("@TurnOutFirst", "int");
            pTypes.Add("@TurnOutSecond", "int");
            pTypes.Add("@TurnOutThird", "int");

            pTypes.Add("@TurnOutFirstPerc", "nvarchar");
            pTypes.Add("@TurnOutSecondPerc", "nvarchar");
            pTypes.Add("@TurnOutThirdPerc", "nvarchar");
            executeScalar("p3_EditOpenStation", pTypes, pVals);
        }

        public DataSet RESULTSLevelGetNameForCode(string Code, int idrace)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@Code", Code);
            pVals.Add("@idrace", idrace);
            pTypes.Add("@Code", "string");
            pTypes.Add("@idrace", "int");

            DataSet ds = executeResults("RESULTSLevelGetNameForCode", pTypes, pVals, "BMunicipalityRegion");
            return ds;
        }

        public void RESULTS_InsertIntoPSStatistic(string PSCode, string LevelCode, int FKRace,
                int EntryNumber, int FKUser, int TotalVotersInCVR1, int NumberBallotsInBox2,
                int InvalidUnMarkBallotsA, int InvalidOthersBallotsB, int TotalInvalidBallotsC,
                int TotalValidVotesD1, int TotalValidVotesNMD2, int TotalValidVotesD,
                int TotalAllBallotsE, int AccuracyTest23, int AccuracyTest3F)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@PSCode", PSCode);
            pVals.Add("@LevelCode", LevelCode);
            pVals.Add("@FKRace", FKRace);
            pVals.Add("@EntryNumber", EntryNumber);
            pVals.Add("@FKUser", FKUser);
            pVals.Add("@TotalVotersInCVR1", TotalVotersInCVR1);
            pVals.Add("@NumberBallotsInBox2", NumberBallotsInBox2);
            pVals.Add("@InvalidUnMarkBallotsA", InvalidUnMarkBallotsA);
            pVals.Add("@InvalidOthersBallotsB", InvalidOthersBallotsB);
            pVals.Add("@TotalInvalidBallotsC", TotalInvalidBallotsC);
            pVals.Add("@TotalValidVotesD1", TotalValidVotesD1);
            pVals.Add("@TotalValidVotesNMD2", TotalValidVotesNMD2);
            pVals.Add("@TotalValidVotesD", TotalValidVotesD);
            pVals.Add("@TotalAllBallotsE", TotalAllBallotsE);
            pVals.Add("@AccuracyTest23", AccuracyTest23);
            pVals.Add("@AccuracyTest3F", AccuracyTest3F);

            pTypes.Add("@PSCode", "string");
            pTypes.Add("@LevelCode", "string");
            pTypes.Add("@FKRace", "int");
            pTypes.Add("@EntryNumber", "int");
            pTypes.Add("@FKUser", "int");
            pTypes.Add("@TotalVotersInCVR1", "int");
            pTypes.Add("@NumberBallotsInBox2", "int");
            pTypes.Add("@InvalidUnMarkBallotsA", "int");
            pTypes.Add("@InvalidOthersBallotsB", "int");
            pTypes.Add("@TotalInvalidBallotsC", "int");
            pTypes.Add("@TotalValidVotesD1", "int");
            pTypes.Add("@TotalValidVotesNMD2", "int");
            pTypes.Add("@TotalValidVotesD", "int");
            pTypes.Add("@TotalAllBallotsE", "int");
            pTypes.Add("@AccuracyTest23", "int");
            pTypes.Add("@AccuracyTest3F", "int");


            executeScalar("RESULTS_InsertIntoPSStatistic", pTypes, pVals);
        }
        public DataSet p3getPSStatistic(string pscode, string level, int race)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@pscode", pscode);
            pVals.Add("@level", level);
            pVals.Add("@race", race);
            pTypes.Add("@pscode", "string");
            pTypes.Add("@level", "string");
            pTypes.Add("@race", "int");

            DataSet ds = executeResults("p3getPSStatistic", pTypes, pVals, "p3_PSStatistic");
            return ds;
        }

        public DataSet RESULTSGetPoliticalEntitiesForOL(int fkRace, string levelCode)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@fkRace", fkRace);
            pVals.Add("@levelCode", levelCode);
            pTypes.Add("@fkRace", "int");
            pTypes.Add("@levelCode", "string");

            DataSet ds = executeResults("RESULTSGetPoliticalEntitiesForOL", pTypes, pVals, "BFinalCandidatesLists");
            return ds;
        }

        public void p3_InsertTrackingArea(string nameBos, string nameEng, string nameSer, string nameCro)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@nameBos", nameBos);
            pVals.Add("@nameEng", nameEng);
            pVals.Add("@nameSer", nameSer);
            pVals.Add("@nameCro", nameCro);

            pTypes.Add("@nameBos", "nvarchar");
            pTypes.Add("@nameEng", "nvarchar");
            pTypes.Add("@nameSer", "nvarchar");
            pTypes.Add("@nameCro", "nvarchar");

            executeScalar("p3_insertTrackingArea", pTypes, pVals);
        }

        public void p3_InsertMaterialsData(string nameBos, string nameEng, string nameSer, string nameCro)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@nameBos", nameBos);
            pVals.Add("@nameEng", nameEng);
            pVals.Add("@nameSer", nameSer);
            pVals.Add("@nameCro", nameCro);

            pTypes.Add("@nameBos", "nvarchar");
            pTypes.Add("@nameEng", "nvarchar");
            pTypes.Add("@nameSer", "nvarchar");
            pTypes.Add("@nameCro", "nvarchar");

            executeScalar("p3_insertMaterialsData", pTypes, pVals);
        }

        public void p3_UpdateMaterialsData(string nameBos, string nameEng, string nameSer, string nameCro, int id)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@nameBos", nameBos);
            pVals.Add("@nameEng", nameEng);
            pVals.Add("@nameSer", nameSer);
            pVals.Add("@nameCro", nameCro);
            pVals.Add("@id", id);

            pTypes.Add("@nameBos", "nvarchar");
            pTypes.Add("@nameEng", "nvarchar");
            pTypes.Add("@nameSer", "nvarchar");
            pTypes.Add("@nameCro", "nvarchar");
            pTypes.Add("@id", "int");

            executeScalar("p3_updateMaterialsData", pTypes, pVals);
        }

        public void p3_UpdateTrackingArea(string nameBos, string nameEng, string nameSer, string nameCro, int id)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@nameBos", nameBos);
            pVals.Add("@nameEng", nameEng);
            pVals.Add("@nameSer", nameSer);
            pVals.Add("@nameCro", nameCro);
            pVals.Add("@id", id);

            pTypes.Add("@nameBos", "nvarchar");
            pTypes.Add("@nameEng", "nvarchar");
            pTypes.Add("@nameSer", "nvarchar");
            pTypes.Add("@nameCro", "nvarchar");
            pTypes.Add("@id", "int");

            executeScalar("p3_updateTrackingArea", pTypes, pVals);
        }

        public void p3_DeleteTrackingArea(int id)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@id", id);

            pTypes.Add("@id", "int");

            executeScalar("p3_deleteTrackingArea", pTypes, pVals);
        }

        public void p3_DeleteMaterialsData(int id)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@id", id);

            pTypes.Add("@id", "int");

            executeScalar("p3_deleteMaterialsData", pTypes, pVals);
        }

        public DataSet p3_getMaterialsDataData(int id)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@id", id);

            pTypes.Add("@id", "int");

            DataSet ds = executeResults("p3_getMaterialsDataData", pTypes, pVals, "p3_MaterialsData");
            return ds;
        }

        public DataSet p3_getTrackingAreaData(int id)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@id", id);

            pTypes.Add("@id", "int");

            DataSet ds = executeResults("p3_getTrackingAreaData", pTypes, pVals, "p3_TrackingArea");
            return ds;
        }

        public void RESULTS_InsertIntoZRMayority(string PSCode, string LevelCode,
                int FKRace, int EntryNumber, int ListNumber, int PEorCandidate, int Votes, int FKUser)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@PSCode", PSCode);
            pVals.Add("@LevelCode", LevelCode);
            pVals.Add("@FKRace", FKRace);
            pVals.Add("@EntryNumber", EntryNumber);
            pVals.Add("@ListNumber", ListNumber);
            pVals.Add("@PEorCandidate", PEorCandidate);
            pVals.Add("@Votes", Votes);
            pVals.Add("@FKUser", FKUser);

            pTypes.Add("@PSCode", "string");
            pTypes.Add("@LevelCode", "string");
            pTypes.Add("@FKRace", "int");
            pTypes.Add("@EntryNumber", "int");
            pTypes.Add("@ListNumber", "int");
            pTypes.Add("@PEorCandidate", "int");
            pTypes.Add("@Votes", "int");
            pTypes.Add("@FKUser", "int");

            executeScalar("RESULTS_InsertIntoZRMayority", pTypes, pVals);
        }

        public void UpdateCityCouncilListsByVotes(int ListID, int Votes, int FKUser)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@ListID", ListID);
            pVals.Add("@Votes", Votes);
            pVals.Add("@FKUser", FKUser);

            pTypes.Add("@ListID", "int");
            pTypes.Add("@Votes", "int");
            pTypes.Add("@FKUser", "int");

            executeScalar("UpdateCityCouncilListsByVotes", pTypes, pVals);
        }

        //Nedim
        public void RESULTS_UpdateZRMayority(string PSCode, string LevelCode,
                int FKRace, int ListNumber, int PEorCandidate, int Votes, int FKUser, int decisionId)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@PSCode", PSCode);
            pVals.Add("@LevelCode", LevelCode);
            pVals.Add("@FKRace", FKRace);
            //pVals.Add("@EntryNumber", EntryNumber);
            pVals.Add("@ListNumber", ListNumber);
            pVals.Add("@PEorCandidate", PEorCandidate);
            pVals.Add("@Votes", Votes);
            pVals.Add("@FKUser", FKUser);
            pVals.Add("@DecisionID", decisionId);

            pTypes.Add("@PSCode", "string");
            pTypes.Add("@LevelCode", "string");
            pTypes.Add("@FKRace", "int");
            //pTypes.Add("@EntryNumber", "int");
            pTypes.Add("@ListNumber", "int");
            pTypes.Add("@PEorCandidate", "int");
            pTypes.Add("@Votes", "int");
            pTypes.Add("@FKUser", "int");
            pTypes.Add("@DecisionID", "int");

            executeScalar("RESULTS_UpdateZRMayority", pTypes, pVals);
        }

        public void p3_InsertTrackingRelation(int matid, int from, int to)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@matid", matid);
            pVals.Add("@from", from);
            pVals.Add("@to", to);

            pTypes.Add("@matid", "int");
            pTypes.Add("@from", "int");
            pTypes.Add("@to", "int");

            executeScalar("p3_insertTrackingRelation", pTypes, pVals);
        }

        public void p3_DeleteTrackingRelation(int id)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@id", id);

            pTypes.Add("@id", "int");

            executeScalar("p3_deleteTrackingRelation", pTypes, pVals);
        }
        //        p3_ScanVoter
        public DataSet p3_ScanVoter(string jmb, int accepted, int clerk, string psBag, bool suspicious)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@jmb", jmb);
            pVals.Add("@accepted", accepted);
            pVals.Add("@clerk", clerk);
            pVals.Add("@psBag", psBag);
            pVals.Add("@suspicious", suspicious);
           // pVals.Add("@document", document);

            pTypes.Add("@jmb", "nvarchar");
            pTypes.Add("@accepted", "int");
            pTypes.Add("@clerk", "int");
            pTypes.Add("@psBag", "nvarchar");
            pTypes.Add("@suspicious", "BIT");
            //pTypes.Add("@document", "nvarchar");

            DataSet ds = executeResults("p3_ScanJMB", pTypes, pVals, "p3_VotesCast");
            return ds;
        }

        public void RESULTS_InsertIntoZROpenList(string PSCode, string LevelCode,
               int FKRace, int EntryNumber, int ListPositionCandidate, int FKFinalCandidateList,
               int FKCandidate, int Votes, int FKUser)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@PSCode", PSCode);
            pVals.Add("@LevelCode", LevelCode);
            pVals.Add("@FKRace", FKRace);
            pVals.Add("@EntryNumber", EntryNumber);
            pVals.Add("@ListPositionCandidate", ListPositionCandidate);
            pVals.Add("@FKFinalCandidateList", FKFinalCandidateList);
            pVals.Add("@FKCandidate", FKCandidate);
            pVals.Add("@Votes", Votes);
            pVals.Add("@FKUser", FKUser);

            pTypes.Add("@PSCode", "string");
            pTypes.Add("@LevelCode", "string");
            pTypes.Add("@FKRace", "int");
            pTypes.Add("@EntryNumber", "int");
            pTypes.Add("@ListPositionCandidate", "int");
            pTypes.Add("@FKFinalCandidateList", "int");
            pTypes.Add("@FKCandidate", "int");
            pTypes.Add("@Votes", "int");
            pTypes.Add("@FKUser", "int");

            executeScalar("RESULTS_InsertIntoZROpenList", pTypes, pVals);
        }
        //Nedim
        public void RESULTS_UpdateZROpenList(string PSCode, string LevelCode,
               int FKRace, int ListPositionCandidate, int FKFinalCandidateList,
               int FKCandidate, int Votes, int FKUser,int decisionID)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@PSCode", PSCode);
            pVals.Add("@LevelCode", LevelCode);
            pVals.Add("@FKRace", FKRace);
            //pVals.Add("@EntryNumber", EntryNumber);
            pVals.Add("@ListPositionCandidate", ListPositionCandidate);
            pVals.Add("@FKFinalCandidateList", FKFinalCandidateList);
            pVals.Add("@FKCandidate", FKCandidate);
            pVals.Add("@Votes", Votes);
            pVals.Add("@FKUser", FKUser);
            pVals.Add("@DecisionID", decisionID);

            pTypes.Add("@PSCode", "string");
            pTypes.Add("@LevelCode", "string");
            pTypes.Add("@FKRace", "int");
            //pTypes.Add("@EntryNumber", "int");
            pTypes.Add("@ListPositionCandidate", "int");
            pTypes.Add("@FKFinalCandidateList", "int");
            pTypes.Add("@FKCandidate", "int");
            pTypes.Add("@Votes", "int");
            pTypes.Add("@FKUser", "int");
            pTypes.Add("@DecisionID", "int");

            executeScalar("RESULTS_UpdateZROpenList", pTypes, pVals);
        }
        public DataSet p3getPSStatisticEntry(string pscode, string level, int race, int entry)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@pscode", pscode);
            pVals.Add("@level", level);
            pVals.Add("@race", race);
            pVals.Add("@entry", entry);
            pTypes.Add("@pscode", "string");
            pTypes.Add("@level", "string");
            pTypes.Add("@race", "int");
            pTypes.Add("@entry", "int");
            DataSet ds = executeResults("p3getPSStatisticEntry", pTypes, pVals, "p3_PSStatistic");
            return ds;
        }

        public int p3GetTotalValidVotesNM_D2(string pscode, string LevelCode, string EntryNumber)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@pscode", pscode);
            pTypes.Add("@pscode", "string");
            pVals.Add("@EntryNumber", EntryNumber);
            pTypes.Add("@EntryNumber", "string");
            pVals.Add("@LevelCode", LevelCode);
            pTypes.Add("@LevelCode", "string");

            object Votes = executeScalar("p3GetTotalValidVotesNM_D2", pTypes, pVals);
            int count = 0;
            count = Convert.ToInt32(Votes);
            return count;
        }


        public int RESULTSCheckIfLevelHasNM(string levelCode)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@levelCode", levelCode);

            pTypes.Add("@levelCode", "string");

            DataSet dsTmp = new DataSet();
            dsTmp = executeResults("RESULTSCheckIfLevelHasNM", pTypes, pVals, "BMunicipalityRegion");
            return dsTmp.Tables[0].Rows.Count;
        }

        public void RESULTS_InsertUpdateIntoPSStatistic(int param, string PSCode, string LevelCode,
               int FKRace, int EntryNumber, int Item, string Status, string NextStep)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@param", param);
            pVals.Add("@PSCode", PSCode);
            pVals.Add("@LevelCode", LevelCode);
            pVals.Add("@FKRace", FKRace);
            pVals.Add("@EntryNumber", EntryNumber);
            pVals.Add("@Item", Item);
            pVals.Add("@Status", Status);
            pVals.Add("@NextStep", NextStep);

            pTypes.Add("@param", "int");
            pTypes.Add("@PSCode", "string");
            pTypes.Add("@LevelCode", "string");
            pTypes.Add("@FKRace", "int");
            pTypes.Add("@EntryNumber", "int");
            pTypes.Add("@Item", "int");
            pTypes.Add("@Status", "string");
            pTypes.Add("@NextStep", "string");


            executeScalar("RESULTS_InsertUpdateIntoPSStatistic", pTypes, pVals);
        }
        public DataSet p3_GetTrackingRelations(int matid, int lang)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@matid", matid);
            pVals.Add("@lang", lang);

            pTypes.Add("@matid", "int");
            pTypes.Add("@lang", "int");

            DataSet ds = executeResults("p3_getTrackingRelations", pTypes, pVals, "p3_TrackingRelations");
            return ds;
        }

        //

        public void DeleteScannedVoter(int id, string level)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@id", id);
            pVals.Add("@psBag", level);

            pTypes.Add("@id", "int");
            pTypes.Add("@psBag", "nvarchar");

            executeScalar("p3_DeleteScannedVoter", pTypes, pVals);

        }
        public void p3_InsertInto_p3_PO_Package(int PoBox, int BagNo, int ShipmentNumber, int RegularEnvelopes, int ExpressPost, int Undelivered, int Others,
    int TotalReceivedEnvelopes, string DateReceived, string Comment, string Type, int Clerk)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@PoBox", PoBox);
            pVals.Add("@BagNo", BagNo);
            pVals.Add("@ShipmentNumber", ShipmentNumber);
            pVals.Add("@RegularEnvelopes", RegularEnvelopes);
            pVals.Add("@ExpressPost", ExpressPost);
            pVals.Add("@Undelivered", Undelivered);
            pVals.Add("@Others", Others);
            pVals.Add("@TotalReceivedEnvelopes", TotalReceivedEnvelopes);
            pVals.Add("@DateReceived", DateReceived);
            pVals.Add("@Comment", Comment);
            pVals.Add("@Type", Type);
            pVals.Add("@Clerk", Clerk);

            pTypes.Add("@PoBox", "int");
            pTypes.Add("@BagNo", "int");
            pTypes.Add("@ShipmentNumber", "numeric");
            pTypes.Add("@RegularEnvelopes", "numeric");
            pTypes.Add("@ExpressPost", "numeric");
            pTypes.Add("@Undelivered", "numeric");
            pTypes.Add("@Others", "numeric");
            pTypes.Add("@TotalReceivedEnvelopes", "numeric");
            pTypes.Add("@DateReceived", "nvarchar");
            pTypes.Add("@Comment", "nvarchar");
            pTypes.Add("@Type", "nvarchar");
            pTypes.Add("@Clerk", "int");

            executeScalar("p3_InsertInto_p3_PO_Package", pTypes, pVals);
        }

        public DataSet RESULTSGetPoliticalEntitiesForOLWithVotesForResume(int fkrace, string levelCode, int entryNum, string pscode)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@fkrace", fkrace);
            pVals.Add("@levelCode", levelCode);
            pVals.Add("@entryNum", entryNum);
            pVals.Add("@pscode", pscode);

            pTypes.Add("@fkrace", "int");
            pTypes.Add("@levelCode", "string");
            pTypes.Add("@entryNum", "int");
            pTypes.Add("@pscode", "string");
            DataSet ds = executeResults("RESULTSGetPoliticalEntitiesForOLWithVotesForResume", pTypes, pVals, "p3_ZRMayority");
            return ds;
        }

        public DataSet p3_GetMaterialsForAreaID(int areaid, int lang)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@areaid", areaid);
            pVals.Add("@lang", lang);

            pTypes.Add("@areaid", "int");
            pTypes.Add("@lang", "int");

            DataSet ds = executeResults("p3_getMaterialsForAreaID", pTypes, pVals, "p3_TrackingRelations");
            return ds;
        }

        public DataSet p3_GetTrackingMaterials(string code, int lang, int area)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@code", code);
            pVals.Add("@lang", lang);
            pVals.Add("@area", area);

            pTypes.Add("@code", "nvarchar");
            pTypes.Add("@lang", "int");
            pTypes.Add("@area", "int");

            DataSet ds = executeResults("p3_getTrackingMaterials", pTypes, pVals, "p3_PSMaterials");
            return ds;
        }

        public void p3_InsertTrackingMaterials(string code, int mid, int areaFrom, int areaTo, int user)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@code", code);
            pVals.Add("@mid", mid);
            pVals.Add("@areaFrom", areaFrom);
            pVals.Add("@areaTo", areaTo);
            pVals.Add("@user", user);

            pTypes.Add("@code", "nvarchar");
            pTypes.Add("@mid", "int");
            pTypes.Add("@areaFrom", "int");
            pTypes.Add("@areaTo", "int");
            pTypes.Add("@user", "int");

            executeScalar("p3_insertTrackingMaterials", pTypes, pVals);
        }

        public DataSet p3_GetAreasToForArea(int area, int mid, int lang)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@area", area);
            pVals.Add("@mid", mid);
            pVals.Add("@lang", lang);

            pTypes.Add("@area", "int");
            pTypes.Add("@mid", "int");
            pTypes.Add("@lang", "int");

            DataSet ds = executeResults("p3_GetAreasToForArea", pTypes, pVals, "p3_TrackingRelations");
            return ds;
        }

        public DataSet p3_GetStartMaterialsForAreaID(int areaid, int lang)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@areaid", areaid);
            pVals.Add("@lang", lang);

            pTypes.Add("@areaid", "int");
            pTypes.Add("@lang", "int");

            DataSet ds = executeResults("p3_getStartMaterialsForAreaID", pTypes, pVals, "p3_TrackingRelations");
            return ds;
        }

        public DataSet p3_GetAllPSCodes()
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            DataSet ds = executeResults("p3_getAllPSCode", pTypes, pVals, "p3_PollingStation");
            return ds;
        }


        public void DeleteScannedVoterBag(int id, string level)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@id", id);
            pVals.Add("@psBag", level);

            pTypes.Add("@id", "int");
            pTypes.Add("@psBag", "nvarchar");

            executeScalar("p3_DeleteScannedVoterBag", pTypes, pVals);

        }
        //        p3_ScanVoter
        public DataSet p3_ScanVoterBag(string jmb, int accepted, int clerk, string psBag)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@jmb", jmb);
            pVals.Add("@accepted", accepted);
            pVals.Add("@clerk", clerk);
            pVals.Add("@psBag", psBag);

            pTypes.Add("@jmb", "nvarchar");
            pTypes.Add("@accepted", "int");
            pTypes.Add("@clerk", "int");
            pTypes.Add("@psBag", "nvarchar");

            DataSet ds = executeResults("p3_ScanJMBBag", pTypes, pVals, "p3_VotesCast");
            return ds;
        }
        //public DataSet p3_GetMaterialIDFromPSM()
        //{
        //    Dictionary<string, object> pVals = new Dictionary<string, object>();
        //    Dictionary<string, string> pTypes = new Dictionary<string, string>();

        //    DataSet ds = executeResults("p3_getMaterialIDFromPSM", pTypes, pVals, "p3_PSMaterials");
        //    return ds;
        //}

        public DataSet p3_GetScanningForPSData(string psBag)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@psBag", psBag);

            pTypes.Add("@psBag", "nvarchar");

            DataSet ds = executeResults("p3_GetScanningForPSData", pTypes, pVals, "p3_VotesCast");
            return ds;
        }

        public void p3_UpdateTrackingMaterials(int id, string code, int mid, int areaFrom, int areaTo, int user)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@id", id);
            pVals.Add("@code", code);
            pVals.Add("@mid", mid);
            pVals.Add("@areaFrom", areaFrom);
            pVals.Add("@areaTo", areaTo);
            pVals.Add("@user", user);

            pTypes.Add("@id", "int");
            pTypes.Add("@code", "nvarchar");
            pTypes.Add("@mid", "int");
            pTypes.Add("@areaFrom", "int");
            pTypes.Add("@areaTo", "int");
            pTypes.Add("@user", "int");

            executeScalar("p3_updateTrackingMaterials", pTypes, pVals);
        }


        public void RESULTS_InsertUpdateIntoResultsArchive(int param, string PSNumber, int FKCandidacyRace,
                    string LevelCode, int FKItem, int Status, int FKFinalCandidateList, int UserFirst,
                    int UserSecond, int UserSuper, int UserControlor)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@param", param);
            pVals.Add("@PSNumber", PSNumber);
            pVals.Add("@FKCandidacyRace", FKCandidacyRace);
            pVals.Add("@LevelCode", LevelCode);
            pVals.Add("@FKItem", FKItem);
            pVals.Add("@Status", Status);
            pVals.Add("@FKFinalCandidateList", FKFinalCandidateList);
            pVals.Add("@UserFirst", UserFirst);
            pVals.Add("@UserSecond", UserSecond);
            pVals.Add("@UserSuper", UserSuper);
            pVals.Add("@UserControlor", UserControlor);

            pTypes.Add("@param", "int");
            pTypes.Add("@PSNumber", "string");
            pTypes.Add("@FKCandidacyRace", "int");
            pTypes.Add("@LevelCode", "string");
            pTypes.Add("@FKItem", "int");
            pTypes.Add("@Status", "int");
            pTypes.Add("@FKFinalCandidateList", "int");
            pTypes.Add("@UserFirst", "int");
            pTypes.Add("@UserSecond", "int");
            pTypes.Add("@UserSuper", "int");
            pTypes.Add("@UserControlor", "int");

            executeScalar("RESULTS_InsertUpdateIntoResultsArchive", pTypes, pVals);
        }

        public int BGetActiveCandidacyRaceForMissmatchesTracking(string PSCode, string LevelCode, int FKRace, int FKUser)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@PSCode", PSCode);
            pVals.Add("@LevelCode", LevelCode);
            pVals.Add("@FKRace", FKRace);
            pVals.Add("@FKUser", FKUser);

            pTypes.Add("@PSCode", "string");
            pTypes.Add("@LevelCode", "string");
            pTypes.Add("@FKRace", "int");
            pTypes.Add("@FKUser", "int");

            DataSet temp = new DataSet();
            int results;
            temp = executeResults("BGetActiveCandidacyRaceForMissmatchesTracking", pTypes, pVals, "p3_ResultsEntriesArchive");
            if (temp == null)
            {
            }
            if (temp.Tables.Count == 0)
            {
                results = 0;
            }
            else
            {
                results = int.Parse(temp.Tables[0].Rows[0][0].ToString());
            }
            return results;
        }

        public void p3_SetQuarantine(int mid, string code, int set)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@mid", mid);
            pVals.Add("@code", code);
            pVals.Add("@set", set);

            pTypes.Add("@mid", "int");
            pTypes.Add("@code", "nvarchar");
            pTypes.Add("@set", "int");

            executeScalar("p3_setQuarantine", pTypes, pVals);
        }

        public DataSet p3getStatisticForPSAndMaterials(string param)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@param", param);

            pTypes.Add("@param", "varchar");

            DataSet ds = executeResults("p3getStatisticForPSAndMaterials", pTypes, pVals, "p3_PollingStation");
            return ds;
        }
        public void p3UpdateTolarenceParametars(int id, string TolDescriptionB, string TolDescriptionS, string TolDescriptionC, string TolDescriptionE, decimal TolValue, string TolType)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@id", id);
            pVals.Add("@TolDescriptionB", TolDescriptionB);
            pVals.Add("@TolDescriptionS", TolDescriptionS);
            pVals.Add("@TolDescriptionC", TolDescriptionC);
            pVals.Add("@TolDescriptionE", TolDescriptionE);
            pVals.Add("@TolValue", TolValue);
            pVals.Add("@TolType", TolType);


            pTypes.Add("@id", "int");
            pTypes.Add("@TolDescriptionB", "nvarchar");
            pTypes.Add("@TolDescriptionS", "nvarchar");
            pTypes.Add("@TolDescriptionC", "nvarchar");
            pTypes.Add("@TolDescriptionE", "nvarchar");
            pTypes.Add("@TolValue", "decimal");
            pTypes.Add("@TolType", "nvarchar");

            executeScalar("p3UpdateTolarenceParametars", pTypes, pVals);
        }

        public DataSet p3_GetNextArea(string code, int lang, int area, int mid)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@code", code);
            pVals.Add("@lang", lang);
            pVals.Add("@area", area);
            pVals.Add("@mid", mid);

            pTypes.Add("@code", "nvarchar");
            pTypes.Add("@lang", "int");
            pTypes.Add("@area", "int");
            pTypes.Add("@mid", "int");

            DataSet ds = executeResults("p3_getNextArea", pTypes, pVals, "p3_PSMaterials");
            return ds;
        }
        public DataSet p3getTolarenceParametarsByID(int id)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@id", id);

            pTypes.Add("@id", "int");

            DataSet ds = executeResults("p3getTolarenceParametarsByID", pTypes, pVals, "p3_ToleranceParametars");
            return ds;
        }
        public DataSet p3GetMaterialsforPSCOde()
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            DataSet dsTmp = new DataSet();
            dsTmp = executeResults("p3GetMaterialsforPSCOde", pTypes, pVals, "p3_PSMaterials");
            return dsTmp;
        }
        public DataSet p3TotalTurnOutByMun()
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            DataSet dsTmp = new DataSet();
            dsTmp = executeResults("p3TotalTurnOutByMun", pTypes, pVals, "p3_PSTurnOut");
            return dsTmp;
        }       
        public DataSet p3_GetNameResource(int lang, int id)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@lang", lang);
            pVals.Add("@id", id);

            pTypes.Add("@lang", "int");
            pTypes.Add("@id", "int");

            DataSet dsTmp = new DataSet();
            dsTmp = executeResults("p3_GetNameResource", pTypes, pVals, "p3_ReportResources");
            return dsTmp;
        }
        public void p3_UpdateNameResource(int lang, int id, string name)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@lang", lang);
            pVals.Add("@id", id);
            pVals.Add("@name", name);

            pTypes.Add("@lang", "int");
            pTypes.Add("@id", "int");
            pTypes.Add("@name", "nvarchar");

            executeScalar("p3_UpdateNameResource", pTypes, pVals);
        }
        public DataSet p3_ResultsEntriesStatusByLanguage(int lan)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@lan", lan);

            pTypes.Add("@lan", "int");

            DataSet dsTmp = new DataSet();
            dsTmp = executeResults("p3_ResultsEntriesStatusByLanguage", pTypes, pVals, "p3_PSTotalREA");
            return dsTmp;
        }

        public void FINALIZEInvalidListInsertIntoFinal(int race, int level, int party)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@race", race);
            pVals.Add("@level", level);
            pVals.Add("@party", party);

            pTypes.Add("@race", "int");
            pTypes.Add("@level", "int");
            pTypes.Add("@party", "int");

            executeScalar("FINALIZEInvalidListInsertIntoFinal", pTypes, pVals);
        }
        public DataSet p3getEntriesArchiveItems(string PSNumber, int FKCandidacyRace, string LevelCode, int status)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@PSNumber", PSNumber);
            pVals.Add("@FKCandidacyRace", FKCandidacyRace);
            pVals.Add("@LevelCode", LevelCode);
            pVals.Add("@status", status);

            pTypes.Add("@PSNumber", "nvarchar");
            pTypes.Add("@FKCandidacyRace", "int");
            pTypes.Add("@LevelCode", "nvarchar");
            pTypes.Add("@status", "int");

            DataSet dsTmp = new DataSet();
            dsTmp = executeResults("p3getEntriesArchiveItems", pTypes, pVals, "p3_ResultsEntriesArchive");
            return dsTmp;
        }
        public void p3_InsertInto_p3_Bags(int PoBox, string PollingStationCode, int ShipmentNumber, int RegularEnvelopes, int ExpressPost, int Undelivered, int Others,
          int TotalReceivedEnvelopes, string DateReceived, string Comment, string Type, int Clerk)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@PoBox", PoBox);
            pVals.Add("@PollingStationCode", PollingStationCode);
            pVals.Add("@ShipmentNumber", ShipmentNumber);
            pVals.Add("@RegularEnvelopes", RegularEnvelopes);
            pVals.Add("@ExpressPost", ExpressPost);
            pVals.Add("@Undelivered", Undelivered);
            pVals.Add("@Others", Others);
            pVals.Add("@TotalReceivedEnvelopes", TotalReceivedEnvelopes);
            pVals.Add("@DateReceived", DateReceived);
            pVals.Add("@Comment", Comment);
            pVals.Add("@Type", Type);
            pVals.Add("@Clerk", Clerk);

            pTypes.Add("@PoBox", "int");
            pTypes.Add("@PollingStationCode", "nvarchar");
            pTypes.Add("@ShipmentNumber", "numeric");
            pTypes.Add("@RegularEnvelopes", "numeric");
            pTypes.Add("@ExpressPost", "numeric");
            pTypes.Add("@Undelivered", "numeric");
            pTypes.Add("@Others", "numeric");
            pTypes.Add("@TotalReceivedEnvelopes", "numeric");
            pTypes.Add("@DateReceived", "nvarchar");
            pTypes.Add("@Comment", "nvarchar");
            pTypes.Add("@Type", "nvarchar");
            pTypes.Add("@Clerk", "int");

            executeScalar("p3_InsertInto_p3_Bags", pTypes, pVals);
        }

        public void p3_InsertInto_p3_Bags_Otsustvo(string PollingStationCode, int TotalReceivedEnvelopes, string DateReceived, string Comment, int Clerk)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@PollingStationCode", PollingStationCode);
            pVals.Add("@TotalReceivedEnvelopes", TotalReceivedEnvelopes);
            pVals.Add("@DateReceived", DateReceived);
            pVals.Add("@Comment", Comment);
            pVals.Add("@Clerk", Clerk);

            pTypes.Add("@PollingStationCode", "nvarchar");
            pTypes.Add("@TotalReceivedEnvelopes", "numeric");
            pTypes.Add("@DateReceived", "nvarchar");
            pTypes.Add("@Comment", "nvarchar");
            pTypes.Add("@Clerk", "int");

            executeScalar("p3_InsertInto_p3_Bags_Otsustvo", pTypes, pVals);
        }


        public void p3_InsertInto_p3_Bags_Nepotvrdjeni(string PollingStationCode, int TotalReceivedEnvelopes, string DateReceived, string Comment, int Clerk)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@PollingStationCode", PollingStationCode);
            pVals.Add("@TotalReceivedEnvelopes", TotalReceivedEnvelopes);
            pVals.Add("@DateReceived", DateReceived);
            pVals.Add("@Comment", Comment);
            pVals.Add("@Clerk", Clerk);

            pTypes.Add("@PollingStationCode", "nvarchar");
            pTypes.Add("@TotalReceivedEnvelopes", "numeric");
            pTypes.Add("@DateReceived", "nvarchar");
            pTypes.Add("@Comment", "nvarchar");
            pTypes.Add("@Clerk", "int");

            executeScalar("p3_InsertInto_p3_Bags_Nepotvrdjeni", pTypes, pVals);
        }
        public void p3_InsertInto_p3_Bags_BSpisak(string PollingStationCode, string DateReceived, string Comment, int Clerk)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@PollingStationCode", PollingStationCode);
            pVals.Add("@DateReceived", DateReceived);
            pVals.Add("@Comment", Comment);
            pVals.Add("@Clerk", Clerk);

            pTypes.Add("@PollingStationCode", "nvarchar");
            pTypes.Add("@DateReceived", "nvarchar");
            pTypes.Add("@Comment", "nvarchar");
            pTypes.Add("@Clerk", "int");

            executeScalar("p3_InsertInto_p3_Bags_BSpisak", pTypes, pVals);
        }

        public string p3_GetMECUsersKey(int user, string code)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@user", user);
            pVals.Add("@code", code);

            pTypes.Add("@user", "int");
            pTypes.Add("@code", "varchar");

            string temp = string.Empty;

            try
            {
                temp = (string)executeScalar("p3_GetMECUsersKey", pTypes, pVals);
            }
            catch (Exception)
            {
                
            }
            return temp;
        }
        public void p3_AddMECUsersKey(int user, string code, string key)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@user", user);
            pVals.Add("@code", code);
            pVals.Add("@key", key);

            pTypes.Add("@user", "int");
            pTypes.Add("@code", "varchar");
            pTypes.Add("@key", "nvarchar");

            executeScalar("p3_AddMECUsersKey", pTypes, pVals);
        }


        public DataSet p3_getBagForID(int id)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@id", id);

            pTypes.Add("@id", "int");

            DataSet dsTmp = new DataSet();
            dsTmp = executeResults("p3_getBagForID", pTypes, pVals, "p3_Bags");
            return dsTmp;
        }
        public DataSet p3_getBagForID(string PollingStationCode)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@PollingStationCode", PollingStationCode);

            pTypes.Add("@PollingStationCode", "nvarchar");

            DataSet dsTmp = new DataSet();
            dsTmp = executeResults("p3_getBagForID", pTypes, pVals, "p3_Bags");
            return dsTmp;
        }

        //Nedim
        public DataSet p3_getBagDetails(string PollingStationCode)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@bagName", PollingStationCode);

            pTypes.Add("@bagName", "varchar");

            DataSet dsTmp = new DataSet();
            dsTmp = executeResults("p3_getBagDetails", pTypes, pVals, "p3_BagDetails");
            return dsTmp;
        }
        public DataSet p3_getBagDetailsByBoxName(string boxName)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            //pVals.Add("@bagName", PollingStationCode);
            pVals.Add("@boxName", boxName);

            //pTypes.Add("@bagName", "varchar");
            pTypes.Add("@boxName", "varchar");

            DataSet dsTmp = new DataSet();
            dsTmp = executeResults("p3_getBagDetailsByBoxName", pTypes, pVals, "p3_BagDetails");
            return dsTmp;
        }
        public void RESULTS_InsertUpdateIntoTotalREA(int param, string PSCode, int Race,
            string MunCode, string MunName, int Status)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@param", param);
            pVals.Add("@PSCode", PSCode);
            pVals.Add("@Race", Race);
            pVals.Add("@MunCode", MunCode);
            pVals.Add("@MunName", MunName);
            pVals.Add("@Status", Status);

            pTypes.Add("@param", "int");
            pTypes.Add("@PSCode", "string");
            pTypes.Add("@Race", "int");
            pTypes.Add("@MunCode", "string");
            pTypes.Add("@MunName", "string");
            pTypes.Add("@Status", "int");

            executeScalar("RESULTS_InsertUpdateIntoTotalREA", pTypes, pVals);
        }

        public void p3_Insert_BagsDeniedReasons(string BagNumber, int DenyReasonID, int NoDeniedEnv, string Comment)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@BagNumber", BagNumber);
            pVals.Add("@DenyReasonID", DenyReasonID);
            pVals.Add("@NoDeniedEnv", NoDeniedEnv);
            pVals.Add("@Comment", Comment);

            pTypes.Add("@BagNumber", "nvarchar");
            pTypes.Add("@DenyReasonID", "int");
            pTypes.Add("@NoDeniedEnv", "int");
            pTypes.Add("@Comment", "nvarchar");

            executeScalar("p3_Insert_BagsDeniedReasons", pTypes, pVals);
        }


        public void p3_Insert_NewDenyReason(string DenyReasonName, string typePS)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@DenyReasonName", DenyReasonName);
            pVals.Add("@typePS", typePS);

            pTypes.Add("@DenyReasonName", "nvarchar");
            pTypes.Add("@typePS", "nvarchar");

            executeScalar("p3_Insert_NewDenyReason", pTypes, pVals);
        }

        public DataSet ARezultatiProc(string race, string pool)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@race", race);
            pVals.Add("@pool", pool);

            pTypes.Add("@race", "nvarchar");
            pTypes.Add("@pool", "nvarchar");

            DataSet ds = executeResults("ARezultatiProc", pTypes, pVals, "ARezultati");
            return ds;
        }
        public void RESULTS_GeneratePreliminary(int userID)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@userID", userID);

            pTypes.Add("@userID", "int");

            executeScalar("RESULTS_GeneratePreliminary", pTypes, pVals);
        }
        public void RESULTS_GeneratePreliminaryEntry5(int userID)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@userID", userID);

            pTypes.Add("@userID", "int");

            executeScalar("RESULTS_GeneratePreliminaryEntry5", pTypes, pVals);
        }
        public DataSet p3_UpdateUnconfirmedTurnout(int id, int TurnOutFirst, int TurnOutSecond, int TurnOutThird, string MunCode)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@id", id);
            pVals.Add("@TurnOutFirst", TurnOutFirst);
            pVals.Add("@TurnOutSecond", TurnOutSecond);
            pVals.Add("@TurnOutThird", TurnOutThird);
            pVals.Add("@MunCode", MunCode);



            pTypes.Add("@id", "int");
            pTypes.Add("@TurnOutFirst", "int");
            pTypes.Add("@TurnOutSecond", "int");
            pTypes.Add("@TurnOutThird", "int");

            pTypes.Add("@MunCode", "varchar");

            DataSet ds = executeResults("p3_UpdateUnconfirmedTurnout", pTypes, pVals, "p3_UnconfirmedTurnout");
            return ds;
        }
        public DataSet RESULTS_getPSStatisticEntry1(string PSCode, string LevelCode, int FKRace, int FKUser)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@PSCode", PSCode);
            pVals.Add("@LevelCode", LevelCode);
            pVals.Add("@FKRace", FKRace);
            pVals.Add("@FKUser", FKUser);

            pTypes.Add("@PSCode", "nvarchar");
            pTypes.Add("@LevelCode", "nvarchar");
            pTypes.Add("@FKRace", "int");
            pTypes.Add("@FKUser", "int");

            DataSet ds = executeResults("RESULTS_getPSStatisticEntry1", pTypes, pVals, "p3_PSStatistic");
            return ds;
        }
        public string p2_getLevelNameForTitle(int level)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@level", level);

            pTypes.Add("@level", "int");

            string ds = executeScalar("p2_getLevelNameForTitle", pTypes, pVals).ToString();
            return ds;
        }
        public void RESULTS_updatePSStatisticEntry1(string PSCode, string LevelCode, int FKRace, int FKUser, int TotalVotersInCVR1, int NumberBallotsInBox2, int InvalidUnMarkBallotsA, int InvalidOthersBallotsB, int TotalInvalidBallotsC, int TotalValidVotesD1, int TotalValidVotesNMD2, int TotalValidVotesD, int TotalAllBallotsE, int AccuracyTest23, int AccuracyTest3F)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@PSCode", PSCode);
            pVals.Add("@LevelCode", LevelCode);
            pVals.Add("@FKRace", FKRace);
            pVals.Add("@FKUser", FKUser);
            pVals.Add("@TotalVotersInCVR1", TotalVotersInCVR1);
            pVals.Add("@NumberBallotsInBox2", NumberBallotsInBox2);
            pVals.Add("@InvalidUnMarkBallotsA", InvalidUnMarkBallotsA);
            pVals.Add("@InvalidOthersBallotsB", InvalidOthersBallotsB);
            pVals.Add("@TotalInvalidBallotsC", TotalInvalidBallotsC);
            pVals.Add("@TotalValidVotesD1", TotalValidVotesD1);
            pVals.Add("@TotalValidVotesNMD2", TotalValidVotesNMD2);
            pVals.Add("@TotalValidVotesD", TotalValidVotesD);
            pVals.Add("@TotalAllBallotsE", TotalAllBallotsE);
            pVals.Add("@AccuracyTest23", AccuracyTest23);
            pVals.Add("@AccuracyTest3F", AccuracyTest3F);


            pTypes.Add("@PSCode", "nvarchar");
            pTypes.Add("@LevelCode", "nvarchar");
            pTypes.Add("@FKRace", "int");
            pTypes.Add("@FKUser", "int");
            pTypes.Add("@TotalVotersInCVR1", "int");
            pTypes.Add("@NumberBallotsInBox2", "int");
            pTypes.Add("@InvalidUnMarkBallotsA", "int");
            pTypes.Add("@InvalidOthersBallotsB", "int");
            pTypes.Add("@TotalInvalidBallotsC", "int");
            pTypes.Add("@TotalValidVotesD1", "int");
            pTypes.Add("@TotalValidVotesNMD2", "int");
            pTypes.Add("@TotalValidVotesD", "int");
            pTypes.Add("@TotalAllBallotsE", "int");
            pTypes.Add("@AccuracyTest23", "int");
            pTypes.Add("@AccuracyTest3F", "int");

            executeScalar("RESULTS_updatePSStatisticEntry1", pTypes, pVals);
        }
        public void RESULTSUpdatePoliticalEntitiesVG2(string PSCode, string LevelCode, int FKRace, int FKUser, int votes, int listnumber)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();
            pVals.Add("@PSCode", PSCode);
            pVals.Add("@LevelCode", LevelCode);
            pVals.Add("@FKRace", FKRace);
            pVals.Add("@FKUser", FKUser);
            pVals.Add("@votes", votes);
            pVals.Add("@listnumber", listnumber);


            pTypes.Add("@PSCode", "nvarchar");
            pTypes.Add("@LevelCode", "nvarchar");
            pTypes.Add("@FKRace", "int");
            pTypes.Add("@FKUser", "int");
            pTypes.Add("@votes", "int");
            pTypes.Add("@listnumber", "int");
            executeScalar("RESULTSUpdatePoliticalEntitiesVG2", pTypes, pVals);

        }
        public void p3_UpdateFinalCandidatesForOpenListVotes(int FKRace, string LevelCode, int FKUser, string PSCode, int FKFCL, int fkCandidate, int votes)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@FKRace", FKRace);
            pVals.Add("@LevelCode", LevelCode);
            pVals.Add("@FKUser", FKUser);
            pVals.Add("@PSCode", PSCode);
            pVals.Add("@FKFCL", FKFCL);
            pVals.Add("@fkCandidate", fkCandidate);
            pVals.Add("@votes", votes);

            pTypes.Add("@FKRace", "numeric");
            pTypes.Add("@LevelCode", "nvarchar");
            pTypes.Add("@FKUser", "int");
            pTypes.Add("@PSCode", "nvarchar");
            pTypes.Add("@FKFCL", "int");
            pTypes.Add("@fkCandidate", "int");
            pTypes.Add("@votes", "int");


            executeScalar("p3_UpdateFinalCandidatesForOpenListVotes", pTypes, pVals);
        }

        public void p3_Update_p3_Bags_BeforeVerification(string BagNumber, int Approved, int Rejected, string ControlCountComment)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@BagNumber", BagNumber);
            pVals.Add("@Approved", Approved);
            pVals.Add("@Rejected", Rejected);
            pVals.Add("@ControlCountComment", ControlCountComment);

            pTypes.Add("@BagNumber", "nvarchar");
            pTypes.Add("@Approved", "int");
            pTypes.Add("@Rejected", "int");
            pTypes.Add("@ControlCountComment", "nvarchar");

            executeScalar("p3_Update_p3_Bags_BeforeVerification", pTypes, pVals);
        }
        public int p3_CountMessages(int userID)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@userID", userID);


            pTypes.Add("@userID", "int");

            object obj = executeScalar("p3_CountMessages", pTypes, pVals);
            int count = 0;
            count = Convert.ToInt32(obj);
            return count;
        }


        public void p3_InsertP3IntakePs(string levelCode, string psCode, bool received, string comment)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@levelCode", levelCode);
            pVals.Add("@psCode", psCode);
            pVals.Add("@received", received);
            pVals.Add("@comment", comment);

            pTypes.Add("@levelCode", "nvarchar");
            pTypes.Add("@psCode", "nvarchar");
            pTypes.Add("@received", "bit");
            pTypes.Add("@comment", "nvarchar");
            executeScalar("p3_InsertP3IntakePs", pTypes, pVals);
        }

        public DataSet RESULTSGetPreliminaryZRmayority(int fkRace, string levelCode)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@fkRace", fkRace);
            pVals.Add("@levelCode", levelCode);


            pTypes.Add("@fkRace", "int");
            pTypes.Add("@levelCode", "nvarchar");

            DataSet ds = executeResults("RESULTSGetPreliminaryZRmayority", pTypes, pVals, "p3_PreliminaryZRMayority");
            return ds;
        }
        public DataSet p3_getBFinalCandidatesPreliminary(int FKRace, string LevelCode, int FKFCL)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@FKRace", FKRace);
            pVals.Add("@LevelCode", LevelCode);
            pVals.Add("@FKFCL", FKFCL);

            pTypes.Add("@FKRace", "int");
            pTypes.Add("@LevelCode", "nvarchar");
            pTypes.Add("@FKFCL", "nvarchar");

            DataSet ds = executeResults("p3_getBFinalCandidatesPreliminary", pTypes, pVals, "p3_PreliminaryZROpenList");
            return ds;
        }


        //Izraboteno vo Bosnaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa
        public int M12Opstinski4Koloni19KolkuGrupi(int level, int race)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@level", level);
            pVals.Add("@race", race);

            pTypes.Add("@level", "int");
            pTypes.Add("@race", "int");

            object obj = executeScalar("M12Opstinski4Koloni19KolkuGrupi", pTypes, pVals);
            int count = 0;
            count = Convert.ToInt32(obj);
            return count;
        }


        public int M12GetZROpstinski1ProbaCountTotal(int level, int race)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@level", level);
            pVals.Add("@race", race);

            pTypes.Add("@level", "int");
            pTypes.Add("@race", "int");

            object obj = executeScalar("M12GetZROpstinski1ProbaCountTotal", pTypes, pVals);
            int count = 0;
            count = Convert.ToInt32(obj);
            return count;
        }


        public string M12GetKratenkaScriptForLevel(int level)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@level", level);

            pTypes.Add("@level", "int");

            object obj = executeScalar("M12GetKratenkaScriptForLevel", pTypes, pVals);
            string count = "";
            count = Convert.ToString(obj);
            return count;
        }

        public string M12GetRaceData(string language, int race)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@language", language);
            pVals.Add("@race", race);

            pTypes.Add("@language", "string");
            pTypes.Add("@race", "int");

            object obj = executeScalar("M12GetRaceData", pTypes, pVals);
            string count = "";
            count = Convert.ToString(obj);
            return count;
        }


        public void TRUNCATEFROMCYRILIC()
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            executeScalar("TRUNCATEFROMCYRILIC", pTypes, pVals);

        }


        public bool ProccStep2CheckIsProccesed(int idlist)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@idlist", idlist);

            pTypes.Add("@idlist", "int");

            DataSet dsTmp = new DataSet();
            dsTmp = executeResults("ProccStep2CheckIsProccesed", pTypes, pVals, "BCertifiedPolitivalEntities");
            if (Boolean.Parse(dsTmp.Tables[0].Rows[0][0].ToString()).Equals(true))
            {
                return true;
            }
            else
                return false;
        }
        public void p3_VerificationUpdate(string PollingStationCode, int Accepted, int Denied)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@PollingStationCode", PollingStationCode);
            pVals.Add("@Accepted", Accepted);
            pVals.Add("@Denied", Denied);

            pTypes.Add("@PollingStationCode", "nvarchar");
            pTypes.Add("@Accepted", "int");
            pTypes.Add("@Denied", "int");

            executeScalar("p3_VerificationUpdate", pTypes, pVals);

        }

        public void p3_CreateBox(string Combination, string PSType)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@Combination", Combination);
            pVals.Add("@PSType", PSType);

            pTypes.Add("@Combination", "nvarchar");
            pTypes.Add("@PSType", "nvarchar");

            executeScalar("p3_CreateBox", pTypes, pVals);

        }
        public DataSet p3_getDataFromBagsByID(string PollingStationCode)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@PollingStationCode", PollingStationCode);

            pTypes.Add("@PollingStationCode", "nvarchar");

            DataSet ds = executeResults("p3_getDataFromBagsByID", pTypes, pVals, "p3_Bags");
            return ds;
        }


        public DataSet p3_getBagNameFromBagsByID(int Id)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@Id", Id);

            pTypes.Add("@Id", "int");

            DataSet ds = executeResults("p3_getDataFromBagsByID", pTypes, pVals, "p3_Bags");
            return ds;
        }

        public DataSet p3_getBagNameFromBagsByPSCode(string PollingStationCode)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@PsCode", PollingStationCode);

            pTypes.Add("@PsCode", "nvarchar");

            DataSet ds = executeResults("p3_getBagNameFromBagsByPSCode", pTypes, pVals, "p3_Bags");
            return ds;
        }


        


        public DataSet p3_GetNumberDenyReasonsForDeniedVoters(int IdDeniedReason, string numberBag)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@IdDeniedReason", IdDeniedReason);

            pTypes.Add("@IdDeniedReason", "int");

            pVals.Add("@bagNumber", numberBag);

            pTypes.Add("@bagNumber", "nvarchar");


            DataSet ds = executeResults("p3_GetNumberDenyReasonsForDeniedVoters", pTypes, pVals, "p3_Bags");
            return ds;
        }

        
        


        public void p3_VerificationReceivedEnvelopesUpdate(string PollingStationCode, int EnvNumber)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@PollingStationCode", PollingStationCode);
            pVals.Add("@EnvNumber", EnvNumber);

            pTypes.Add("@PollingStationCode", "nvarchar");
            pTypes.Add("@EnvNumber", "int");

            executeScalar("p3_VerificationReceivedEnvelopesUpdate", pTypes, pVals);

        }

        public void p3_VerificationReceivedEnvelopesUpdate(int ID, int EnvNumber)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@ID", ID);
            pVals.Add("@EnvNumber", EnvNumber);

            pTypes.Add("@ID", "int");
            pTypes.Add("@EnvNumber", "int");

            executeScalar("p3_VerificationReceivedEnvelopesUpdate", pTypes, pVals);

        }

        public void p3_insertBagsDetail(string PollingStationCode, int BagNo, string BoxCombination, string PSType, int NoEnvelopes, int NoSignatures,
                                        int NoEnvelopesCounted, int Difference, int BoxNo, string BoxType, int UserID, string boxName)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@PollingStationCode", PollingStationCode);
            pVals.Add("@BagNo", BagNo);
            pVals.Add("@BoxCombination", BoxCombination);
            pVals.Add("@PSType", PSType);
            pVals.Add("@NoEnvelopes", NoEnvelopes);
            pVals.Add("@NoSignatures", NoSignatures);
            pVals.Add("@NoEnvelopesCounted", NoEnvelopesCounted);
            pVals.Add("@Difference", Difference);
            pVals.Add("@BoxNo", BoxNo);
            pVals.Add("@BoxType", BoxType);
            pVals.Add("@UserID", UserID);
            pVals.Add("@BoxName", boxName);

            pTypes.Add("@PollingStationCode", "nvarchar");
            pTypes.Add("@BagNo", "int");
            pTypes.Add("@BoxCombination", "nvarchar");
            pTypes.Add("@PSType", "nvarchar");
            pTypes.Add("@NoEnvelopes", "int");
            pTypes.Add("@NoSignatures", "int");
            pTypes.Add("@NoEnvelopesCounted", "int");
            pTypes.Add("@Difference", "int");
            pTypes.Add("@BoxNo", "int");
            pTypes.Add("@BoxType", "nvarchar");
            pTypes.Add("@UserID", "int");
            pTypes.Add("@BoxName", "nvarchar");

            executeScalar("p3_insertBagsDetail", pTypes, pVals);

        }
        public DataSet p3_getDataFromBox(int id)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@id", id);

            pTypes.Add("@id", "int");

            DataSet ds = executeResults("p3_getDataFromBox", pTypes, pVals, "p3_Box");
            return ds;
        }
        public void p3_UpdateBagStatus(string Status, string PSCode, string PSType)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@Status", Status);
            pVals.Add("@PSCode", PSCode);
            pVals.Add("@PSType", PSType);

            pTypes.Add("@Status", "nvarchar");
            pTypes.Add("@PSCode", "nvarchar");
            pTypes.Add("@PSType", "nvarchar");

            executeScalar("p3_UpdateBagStatus", pTypes, pVals);

        }
        public void web_FinalImportByRaceLevel(int race, int param, string level)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@race ", race);
            pVals.Add("@param", param);
            pVals.Add("@level", level);


            pTypes.Add("@race ", "int");
            pTypes.Add("@param", "int");
            pTypes.Add("@level", "nvarchar");

            executeScalar("web_FinalImportByRaceLevel", pTypes, pVals);
        }
        public void web_PreliminaryImportByRaceLevel(int race, int param, string level)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@race ", race);
            pVals.Add("@param", param);
            pVals.Add("@level", level);


            pTypes.Add("@race ", "int");
            pTypes.Add("@param", "int");
            pTypes.Add("@level", "nvarchar");

            executeScalar("web_PreliminaryImportByRaceLevel", pTypes, pVals);
        }



        public void web_DeleteFinalImportByRaceLevel(int race, int param, string level)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@race ", race);
            pVals.Add("@param", param);
            pVals.Add("@level", level);


            pTypes.Add("@race ", "int");
            pTypes.Add("@param", "int");
            pTypes.Add("@level", "nvarchar");

            executeScalar("web_DeleteFinalImportByRaceLevel", pTypes, pVals);
        }
        public void DeleteFinal()
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            executeScalar("web_DeleteFinal", pTypes, pVals);
        }


        public void DeletePreliminary()
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            executeScalar("web_DeletePreliminary", pTypes, pVals);
        }

        public void web_InsertPreliminary()
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            executeScalar("web_InsertPreliminary", pTypes, pVals);
        }

        public void web_InsertFinal()
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            executeScalar("web_InsertFinal", pTypes, pVals);
        }
        public void web_UpdateWebAppPRLevelCandidateResultsForReports()
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            executeScalar("UpdateWebAppPRLevelCandidateResultsForReports", pTypes, pVals);
        }
        public void p3_UpdateBoxDetailsCounting(string BoxName, int NoBallotsCounted, int ValidBallots, int InvalidBallots, string LevelCode)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@BoxName", BoxName);
            pVals.Add("@NoBallotsCounted", NoBallotsCounted);
            pVals.Add("@ValidBallots", ValidBallots);
            pVals.Add("@InvalidBallots", InvalidBallots);
            pVals.Add("@LevelCode", LevelCode);

            pTypes.Add("@BoxName", "nvarchar");
            pTypes.Add("@NoBallotsCounted", "int");
            pTypes.Add("@ValidBallots", "int");
            pTypes.Add("@InvalidBallots", "int");
            pTypes.Add("@LevelCode", "nvarchar");

            executeScalar("p3_UpdateBoxDetailsCounting", pTypes, pVals);
        }

        public void web_DeletePreliminaryImportByRaceLevel(int race, int param, string level)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@race ", race);
            pVals.Add("@param", param);
            pVals.Add("@level", level);


            pTypes.Add("@race ", "int");
            pTypes.Add("@param", "int");
            pTypes.Add("@level", "nvarchar");

            executeScalar("web_DeletePreliminaryImportByRaceLevel", pTypes, pVals);
        }

        public void p3_UpdateBoxStatus(string Status, string BoxName)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@Status", Status);
            pVals.Add("@BoxName", BoxName);


            pTypes.Add("@Status", "nvarchar");
            pTypes.Add("@BoxName", "nvarchar");


            executeScalar("p3_UpdateBoxStatus", pTypes, pVals);

        }

        public void p3_InsertBoxDetailsSorting(string BoxName, int BoxNo, string BoxCombination, string BoxType, string LevelCode, int SortedEnvelopes)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@BoxName", BoxName);
            pVals.Add("@BoxNo", BoxNo);
            pVals.Add("@BoxCombination", BoxCombination);
            pVals.Add("@BoxType", BoxType);
            pVals.Add("@LevelCode", LevelCode);
            pVals.Add("@SortedEnvelopes", SortedEnvelopes);

            pTypes.Add("@BoxName", "nvarchar");
            pTypes.Add("@BoxNo", "int");
            pTypes.Add("@BoxCombination", "nvarchar");
            pTypes.Add("@BoxType", "nvarchar");
            pTypes.Add("@LevelCode", "nvarchar");
            pTypes.Add("@SortedEnvelopes", "int");

            executeScalar("p3_InsertBoxDetailsSorting", pTypes, pVals);
        }


        public void p3_updateBoxRejectedEnvelopes(string BoxName, int Rejected, string BoxStatus)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@BoxName", BoxName);
            pVals.Add("@Rejected", Rejected);
            pVals.Add("@BoxStatus", BoxStatus);

            pTypes.Add("@BoxName", "nvarchar");
            pTypes.Add("@Rejected", "int");
            pTypes.Add("@BoxStatus", "nvarchar");

            executeScalar("p3_updateBoxRejectedEnvelopes", pTypes, pVals);
        }

        public void p3_updateBoxTotalEnvelopes(string BoxName, int TotalEnv, string BoxStatus)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@BoxName", BoxName);
            pVals.Add("@TotalEnv", TotalEnv);
            pVals.Add("@BoxStatus", BoxStatus);

            pTypes.Add("@BoxName", "nvarchar");
            pTypes.Add("@TotalEnv", "int");
            pTypes.Add("@BoxStatus", "nvarchar");

            executeScalar("p3_updateBoxTotalEnvelopes", pTypes, pVals);
        }

        public int p3_getNumberOfEnvelopesCounted(string Combination, string BoxType, int BoxNo)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();


            pVals.Add("@Combination", Combination);
            pVals.Add("@BoxType", BoxType);
            pVals.Add("@BoxNo", BoxNo);


            pTypes.Add("@Combination", "nchar");
            pTypes.Add("@BoxType", "nchar");
            pTypes.Add("@BoxNo", "int");

            DataSet dsTmp = new DataSet();
            dsTmp = executeResults("p3_getNumberOfEnvelopesCounted", pTypes, pVals, "p3_BagsDetail");
            if (dsTmp.Tables[0].Rows[0][0].ToString() == "")
            {
                return 0;
            }
            else
            {
                return int.Parse(dsTmp.Tables[0].Rows[0][0].ToString());
            }
        }


        public int p3_checkIfBagDetailExist(string PSCode, int BoxNo, string Combination)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@PSCode", PSCode);
            pVals.Add("@BoxNo", BoxNo);
            pVals.Add("@Combination", Combination);

            pTypes.Add("@PSCode", "nvarchar");
            pTypes.Add("@BoxNo", "int");
            pTypes.Add("@Combination", "nvarchar");

            DataSet dsTmp = new DataSet();
            dsTmp = executeResults("p3_checkIfBagDetailExist", pTypes, pVals, "p3_BagsDetail");
            return int.Parse(dsTmp.Tables[0].Rows[0][0].ToString());
        }



        public void p3_VerificationUpdate(int ID, int Accepted, int Denied)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@ID", ID);
            pVals.Add("@Accepted", Accepted);
            pVals.Add("@Denied", Denied);

            pTypes.Add("@ID", "int");
            pTypes.Add("@Accepted", "int");
            pTypes.Add("@Denied", "int");

            executeScalar("p3_VerificationUpdate", pTypes, pVals);

        }
        public void p3_UpdateIntakeMaterials(bool param, string Comment, int ID)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@param", param);
            pVals.Add("@Comment", Comment);
            pVals.Add("@ID", ID);

            pTypes.Add("@param", "bit");
            pTypes.Add("@Comment", "nvarchar");
            pTypes.Add("@ID", "int");

            executeScalar("p3_UpdateIntakeMaterials", pTypes, pVals);
        }
        public DataSet p3GetLevelName(string Code)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@Code", Code);

            pTypes.Add("@Code", "nvarchar");

            DataSet ds = executeResults("p3GetLevelName", pTypes, pVals, "BMunicipalityRegion");
            return ds;
        }
        public void RESULTS_CheckOtvorenaLista1TWOEntries(string PSCode, string LevelCode, int FKRace,
                           int TotalVotersInCVR1, int NumberBallotsInBox2, int AccuracyTest23,
                           int InvalidUnMarkBallotsA, int InvalidOthersBallotsB, int TotalInvalidBallotsC,
                           int TotalValidVotesD1, int TotalValidVotesNMD2, int TotalValidVotesD,
                           int TotalAllBallotsE, int AccuracyTest3F, int FKUser)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@PSCode", PSCode);
            pVals.Add("@LevelCode", LevelCode);
            pVals.Add("@FKRace", FKRace);
            pVals.Add("@TotalVotersInCVR1", TotalVotersInCVR1);
            pVals.Add("@NumberBallotsInBox2", NumberBallotsInBox2);
            pVals.Add("@AccuracyTest23", AccuracyTest23);
            pVals.Add("@InvalidUnMarkBallotsA", InvalidUnMarkBallotsA);
            pVals.Add("@InvalidOthersBallotsB", InvalidOthersBallotsB);
            pVals.Add("@TotalInvalidBallotsC", TotalInvalidBallotsC);
            pVals.Add("@TotalValidVotesD1", TotalValidVotesD1);
            pVals.Add("@TotalValidVotesNMD2", TotalValidVotesNMD2);
            pVals.Add("@TotalValidVotesD", TotalValidVotesD);
            pVals.Add("@TotalAllBallotsE", TotalAllBallotsE);
            pVals.Add("@AccuracyTest3F", AccuracyTest3F);
            pVals.Add("@FKUser", FKUser);

            pTypes.Add("@PSCode", "string");
            pTypes.Add("@LevelCode", "string");
            pTypes.Add("@FKRace", "int");
            pTypes.Add("@TotalVotersInCVR1", "int");
            pTypes.Add("@NumberBallotsInBox2", "int");
            pTypes.Add("@AccuracyTest23", "int");
            pTypes.Add("@InvalidUnMarkBallotsA", "int");
            pTypes.Add("@InvalidOthersBallotsB", "int");
            pTypes.Add("@TotalInvalidBallotsC", "int");
            pTypes.Add("@TotalValidVotesD1", "int");
            pTypes.Add("@TotalValidVotesNMD2", "int");
            pTypes.Add("@TotalValidVotesD", "int");
            pTypes.Add("@TotalAllBallotsE", "int");
            pTypes.Add("@AccuracyTest3F", "int");
            pTypes.Add("@FKUser", "int");

            executeScalar("RESULTS_CheckOtvorenaLista1TWOEntries", pTypes, pVals);
        }

        //ace bosna faza 2

        public void RESULTS_CheckVecinskiGlas1TWOEntries(string PSCode, string LevelCode, int FKRace,
                           int TotalVotersInCVR1, int NumberBallotsInBox2, int AccuracyTest23,
                           int InvalidUnMarkBallotsA, int InvalidOthersBallotsB, int TotalInvalidBallotsC,
                           int TotalValidVotesD, int TotalAllBallotsE, int AccuracyTest3F, int FKUser)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@PSCode", PSCode);
            pVals.Add("@LevelCode", LevelCode);
            pVals.Add("@FKRace", FKRace);
            pVals.Add("@TotalVotersInCVR1", TotalVotersInCVR1);
            pVals.Add("@NumberBallotsInBox2", NumberBallotsInBox2);
            pVals.Add("@AccuracyTest23", AccuracyTest23);
            pVals.Add("@InvalidUnMarkBallotsA", InvalidUnMarkBallotsA);
            pVals.Add("@InvalidOthersBallotsB", InvalidOthersBallotsB);
            pVals.Add("@TotalInvalidBallotsC", TotalInvalidBallotsC);
            pVals.Add("@TotalValidVotesD", TotalValidVotesD);
            pVals.Add("@TotalAllBallotsE", TotalAllBallotsE);
            pVals.Add("@AccuracyTest3F", AccuracyTest3F);
            pVals.Add("@FKUser", FKUser);

            pTypes.Add("@PSCode", "string");
            pTypes.Add("@LevelCode", "string");
            pTypes.Add("@FKRace", "int");
            pTypes.Add("@TotalVotersInCVR1", "int");
            pTypes.Add("@NumberBallotsInBox2", "int");
            pTypes.Add("@AccuracyTest23", "int");
            pTypes.Add("@InvalidUnMarkBallotsA", "int");
            pTypes.Add("@InvalidOthersBallotsB", "int");
            pTypes.Add("@TotalInvalidBallotsC", "int");
            pTypes.Add("@TotalValidVotesD", "int");
            pTypes.Add("@TotalAllBallotsE", "int");
            pTypes.Add("@AccuracyTest3F", "int");
            pTypes.Add("@FKUser", "int");

            executeScalar("RESULTS_CheckVecinskiGlas1TWOEntries", pTypes, pVals);
        }

        public void RESULTS_CheckOtvorenaLista2TWOEntries(string PSCode, string LevelCode, int FKRace, int FKUser)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@PSCode", PSCode);
            pVals.Add("@LevelCode", LevelCode);
            pVals.Add("@FKRace", FKRace);
            pVals.Add("@FKUser", FKUser);

            pTypes.Add("@PSCode", "string");
            pTypes.Add("@LevelCode", "string");
            pTypes.Add("@FKRace", "int");
            pTypes.Add("@FKUser", "int");

            executeScalar("RESULTS_CheckOtvorenaLista2TWOEntries", pTypes, pVals);
        }

        public void RESULTS_CheckOtvorenaLista2TWOEntries(string PSCode, string LevelCode, int FKRace, int FKUser, int listNumber)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@PSCode", PSCode);
            pVals.Add("@LevelCode", LevelCode);
            pVals.Add("@FKRace", FKRace);
            pVals.Add("@FKUser", FKUser);
            pVals.Add("@ListNumber", listNumber);

            pTypes.Add("@PSCode", "string");
            pTypes.Add("@LevelCode", "string");
            pTypes.Add("@FKRace", "int");
            pTypes.Add("@FKUser", "int");
            pTypes.Add("@ListNumber", "int");

            executeScalar("RESULTS_CheckOtvorenaLista2TWOEntriesOIK", pTypes, pVals);
        }

        public void RESULTS_CheckVecinskiGlas2TWOEntries(string PSCode, string LevelCode, int FKRace, int FKUser)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@PSCode", PSCode);
            pVals.Add("@LevelCode", LevelCode);
            pVals.Add("@FKRace", FKRace);
            pVals.Add("@FKUser", FKUser);

            pTypes.Add("@PSCode", "string");
            pTypes.Add("@LevelCode", "string");
            pTypes.Add("@FKRace", "int");
            pTypes.Add("@FKUser", "int");

            executeScalar("RESULTS_CheckVecinskiGlas2TWOEntries", pTypes, pVals);
        }

        public DataSet BGetValidANDInvalidPreliminary(string LevelCode, int Race)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@LevelCode", LevelCode);
            pVals.Add("@Race", Race);

            pTypes.Add("@LevelCode", "nvarchar");
            pTypes.Add("@Race", "numeric");
            DataSet ds = executeResults("BGetValidANDInvalidPreliminary", pTypes, pVals, "p3_PreliminaryPSStatistic");
            return ds;
        }
        public DataSet BGetValidANDInvalidFinal(string LevelCode, int Race)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@LevelCode", LevelCode);
            pVals.Add("@Race", Race);

            pTypes.Add("@LevelCode", "nvarchar");
            pTypes.Add("@Race", "numeric");
            DataSet ds = executeResults("BGetValidANDInvalidFinal", pTypes, pVals, "p3_FinalPSStatistic");
            return ds;
        }

        public void p3_inseretIntoDeletedPS(string psCode, string levelCode, int FKRace, string comment, DateTime datetime, int fkuser, int FKStatus)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@psCode", psCode);
            pVals.Add("@levelCode", levelCode);
            pVals.Add("@FKRace", FKRace);
            pVals.Add("@comment", comment);
            pVals.Add("@datetime", datetime);
            pVals.Add("@fkuser", fkuser);
            pVals.Add("@FKStatus", FKStatus);

            pTypes.Add("@psCode", "string");
            pTypes.Add("@levelCode", "string");
            pTypes.Add("@FKRace", "int");
            pTypes.Add("@comment", "string");
            pTypes.Add("@datetime", "datetime");
            pTypes.Add("@fkuser", "int");
            pTypes.Add("@FKStatus", "int");

            executeScalar("p3_inseretIntoDeletedPS", pTypes, pVals);
        }

        public void JDeleteFromCyrilicCandidates(int idcand)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@idcand", idcand);

            pTypes.Add("@idcand", "int");

            executeScalar("JDeleteFromCyrilicCandidates", pTypes, pVals);

        }

        public void INSERTintoFRBackup()
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();
            executeScalar("INSERTintoFRBackup", pTypes, pVals);
        }

        public void CLEARFRBackup()
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();
            executeScalar("CLEARFRBackup", pTypes, pVals);
        }

        public int COUNTFRForButtons()
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();
            DataSet ds;
            ds = executeResults("COUNTFRForButtons", pTypes, pVals, "FRBCandidatesPreFinal");
            return int.Parse(ds.Tables[0].Rows[0][0].ToString());
        }

        public DataSet p2_getPolEntitiesForRaceAndLevel(int race, int level)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@race", race);
            pVals.Add("@level", level);

            pTypes.Add("@race", "int");
            pTypes.Add("@level", "int");


            DataSet dsTmp = executeResults("p2_getPolEntitiesForRaceAndLevel", pTypes, pVals, "BPoliticalEntities");

            return dsTmp;
        }
        public DataSet p2_getCandidates(int race, int level, int party)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@race", race);
            pVals.Add("@level", level);
            pVals.Add("@party", party);

            pTypes.Add("@race", "int");
            pTypes.Add("@level", "int");
            pTypes.Add("@party", "int");

            DataSet dsTmp = executeResults("p2_getCandidates", pTypes, pVals, "BCandidatesFinal");
            return dsTmp;
        }
        public DataSet p2_getCandidates600700(int race, int level)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@race", race);
            pVals.Add("@level", level);

            pTypes.Add("@race", "int");
            pTypes.Add("@level", "int");

            DataSet dsTmp = executeResults("p2_getCandidates600700", pTypes, pVals, "BCandidatesFinal");
            return dsTmp;
        }


        //OD SANDRA
        public void p1_InsertFromCompensationToFkCom()
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();
            executeScalar("p1_InsertFromCompensationToFkCom", pTypes, pVals);
        }

        public int COUNTFRForButtonsForCompensations()
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();
            //DataSet ds;
            DataSet ds = executeResults("COUNTFRForButtonsForCompensations", pTypes, pVals, "FRCompensationLists");
            return int.Parse(ds.Tables[0].Rows[0][0].ToString());
        }

        public void P1ContinueWithCompensationList()
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();
            executeScalar("P1ContinueWithCompensationList", pTypes, pVals);
        }



        public void p1_DeleteFromCompensationValidated()
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();
            executeScalar("p1_DeleteFromCompensationValidated", pTypes, pVals);
        }

        public void p1_DeleteFromFRCompensationValidated1()
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();


            executeScalar("p1_DeleteFromFRCompensationValidated1", pTypes, pVals);

        }

        public void p2DeleteForManyPETables()
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            executeScalar("p2DeleteForManyPETables", pTypes, pVals);
        }
        public void p2InsertForManyPETables()
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            executeScalar("p2InsertForManyPETables", pTypes, pVals);
        }


        public void GenerateFinalReport()
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            executeScalar("GenerateFinalReport", pTypes, pVals);
        }
        public void p3_Update_p3_Bags_Total_Envelopes(int total, string BagNumber)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@total", total);
            pVals.Add("@BagNumber", @BagNumber);

            pTypes.Add("@total", "numeric");
            pTypes.Add("@BagNumber", "nvarchar");


            executeScalar("p3_Update_p3_Bags_Total_Envelopes", pTypes, pVals);

        }


        public void RESULTS_CheckOtvorenaListaOPTWOEntries(string PSCode, string LevelCode, int FKRace, int FKUser, int Lista)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@PSCode", PSCode);
            pVals.Add("@LevelCode", LevelCode);
            pVals.Add("@FKRace", FKRace);
            pVals.Add("@FKUser", FKUser);
            pVals.Add("@Lista", Lista);

            pTypes.Add("@PSCode", "string");
            pTypes.Add("@LevelCode", "string");
            pTypes.Add("@FKRace", "int");
            pTypes.Add("@FKUser", "int");
            pTypes.Add("@Lista", "int");

            executeScalar("RESULTS_CheckOtvorenaListaOPTWOEntries", pTypes, pVals);
        }
        public void p3_Insert_Into_ObrazacBrojnogStanja(string PSCode, string LevelCode, int FKRace, int FKUser,
    int Box1, int Box2, int Box3, int Box4, int Box5, int Box6, int Box7, int Box8, int Box9, int Box10, int EntryNumber)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@PSCode", PSCode);
            pVals.Add("@LevelCode", LevelCode);
            pVals.Add("@FKRace", FKRace);

            pVals.Add("@FKUser", FKUser);

            pVals.Add("@Box1", Box1);
            pVals.Add("@Box2", Box2);
            pVals.Add("@Box3", Box3);
            pVals.Add("@Box4", Box4);
            pVals.Add("@Box5", Box5);
            pVals.Add("@Box6", Box6);
            pVals.Add("@Box7", Box7);
            pVals.Add("@Box8", Box8);
            pVals.Add("@Box9", Box9);
            pVals.Add("@Box10", Box10);
            pVals.Add("@EntryNumber", EntryNumber);



            pTypes.Add("@PSCode", "nvarchar");
            pTypes.Add("@LevelCode", "nvarchar");
            pTypes.Add("@FKRace", "numeric");
            pTypes.Add("@FKUser", "int");

            pTypes.Add("@Box1", "int");
            pTypes.Add("@Box2", "int");
            pTypes.Add("@Box3", "int");
            pTypes.Add("@Box4", "int");
            pTypes.Add("@Box5", "int");
            pTypes.Add("@Box6", "int");
            pTypes.Add("@Box7", "int");
            pTypes.Add("@Box8", "int");
            pTypes.Add("@Box9", "int");
            pTypes.Add("@Box10", "int");
            pTypes.Add("@EntryNumber", "int");

            executeScalar("p3_Insert_Into_ObrazacBrojnogStanja ", pTypes, pVals);
        }

        public bool p3_GetPsCodeFromObrazec(string PSCode)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@PSCode", PSCode);

            pTypes.Add("@PSCode", "nvarchar");


            DataSet ds = executeResults("p3_GetPsCodeFromObrazec", pTypes, pVals, "p3_ObrazacBrojnogStanje");

            if (int.Parse(ds.Tables[0].Rows[0][0].ToString()) == 1)
                return true;
            else
                return false;
        }
        public bool p3_GetPsCodeFromObrazec1(string PSCode)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@PSCode", PSCode);

            pTypes.Add("@PSCode", "nvarchar");


            DataSet ds = executeResults("p3_GetPsCodeFromObrazec1", pTypes, pVals, "p3_ObrazacBrojnogStanje");

            if (int.Parse(ds.Tables[0].Rows[0][0].ToString()) == 1)
                return true;
            else
                return false;
        }
        public int p3_GetLCOrCL(string @Code)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@Code", @Code);

            pTypes.Add("@Code", "nvarchar");


            DataSet ds = executeResults("p3_GetLCOrCL", pTypes, pVals, "BMunicipalityRegion");

            return int.Parse(ds.Tables[0].Rows[0][0].ToString());


        }
        public void p3_InsertIntoLogs(string item, string ip, int userID, string text)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();


            pVals.Add("@item", item);
            pVals.Add("@ip", ip);
            pVals.Add("@userID", userID);
            pVals.Add("@text", text);



            pTypes.Add("@item", "nvarchar");
            pTypes.Add("@ip", "nvarchar");
            pTypes.Add("@userID", "int");
            pTypes.Add("@text", "nvarchar");

            executeScalar("p3_InsertIntoLogs", pTypes, pVals);
        }

        public void p3_CloseOpenPSForMec(string CodePS, string MistakeOpenFalse)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@CodePS", CodePS);
            pVals.Add("@MistakeOpenFalse", MistakeOpenFalse);

            pTypes.Add("@CodePS", "nvarchar");
            pTypes.Add("@MistakeOpenFalse", "nvarchar");

            executeScalar("p3_CloseOpenPSForMec", pTypes, pVals);
        }
        public void p3_OpenClosePSForMec(string CodePS, string MistakeCloseFalse)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@CodePS", CodePS);
            pVals.Add("@MistakeCloseFalse", MistakeCloseFalse);

            pTypes.Add("@CodePS", "nvarchar");
            pTypes.Add("@MistakeCloseFalse", "nvarchar");

            executeScalar("p3_OpenClosePSForMec", pTypes, pVals);
        }
        public DataSet p3_getUnconfirmed3(string code)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@code", code);

            pTypes.Add("@code", "nvarchar");

            DataSet dsTmp = executeResults("p3_getUnconfirmed3", pTypes, pVals, "p3_UnconfirmedTurnout");
            return dsTmp;
        }
        public DataSet p3_getTotalRegisterVoters(string code)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@code", code);

            pTypes.Add("@code", "nvarchar");

            DataSet dsTmp = executeResults("p3_getTotalRegisterVoters", pTypes, pVals, "p3_PollingStation");
            return dsTmp;
        }
        public DataSet p3_getNumberOpened(string code)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@code", code);
            //pVals.Add("@userid", userid);

            pTypes.Add("@code", "nvarchar");
            //pTypes.Add("@userid", "int");

            DataSet dsTmp = executeResults("p3_getNumberOpened", pTypes, pVals, "p3_PSTurnOut");
            return dsTmp;
        }
        public void p3_UpdateCoefficientAM(int valuepar, string descriprion, string type)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@valuepar", valuepar);
            pVals.Add("@descriprion", descriprion);
            pVals.Add("@type", type);


            pTypes.Add("@valuepar", "int");
            pTypes.Add("@descriprion", "nvarchar");
            pTypes.Add("@type", "varchar");


            executeScalar("p3_UpdateCoefficientAM", pTypes, pVals);

        }


        public string M12GetRaceData1(string language, int race)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@language", language);
            pVals.Add("@race", race);

            pTypes.Add("@language", "string");
            pTypes.Add("@race", "int");

            object obj = executeScalar("M12GetRaceData1", pTypes, pVals);
            string count = "";
            count = Convert.ToString(obj);
            return count;
        }
        public int p3_Get_ShipmentNumber(string date)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@date", date);
            pTypes.Add("@date", "nvarchar");
            DataSet dsTmp = new DataSet();
            dsTmp = executeResults("p3_Get_ShipmentNumber", pTypes, pVals, "p3_Shipment");
            return int.Parse(dsTmp.Tables[0].Rows[0][0].ToString());
        }

        public void p3_InsertInto_ShipmentNumber(string dateReceive, int shipmentN, int shipmentnumber, int totalOtherPost,
  string comment, int status)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@dateReceive", dateReceive);
            pVals.Add("@shipmentN", shipmentN);
            pVals.Add("@shipmentnumber", shipmentnumber);
            pVals.Add("@totalOtherPost", totalOtherPost);
            pVals.Add("@comment", comment);
            pVals.Add("@status", status);
            pTypes.Add("@dateReceive", "nvarchar");
            pTypes.Add("@shipmentN", "int");
            pTypes.Add("@shipmentnumber", "int");
            pTypes.Add("@totalOtherPost", "int");
            pTypes.Add("@comment", "nvarchar");
            pTypes.Add("@status", "int");


            executeScalar("p3_InsertInto_ShipmentNumber", pTypes, pVals);
        }
        public DataSet p2_getLevelNameForTitleV2(int race, int level, string lang)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@race", race);
            pVals.Add("@level", level);
            pVals.Add("@lang", lang);

            pTypes.Add("@race", "int");
            pTypes.Add("@level", "int");
            pTypes.Add("@lang", "string");

            DataSet ds = executeResults("p2_getLevelNameForTitleV2", pTypes, pVals, "BMunicipalityRegion");
            return ds;
        }
        public void p3UpdateNationalityAllocation(int totalMandates, int totalSerbian, int totalBosnian, int totalCroatian, int totalOther, string Code, int RaceID, int TotalCompensation, bool IncludeNationalities, int param)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();


            pVals.Add("@totalMandates", totalMandates);
            pVals.Add("@totalSerbian", totalSerbian);
            pVals.Add("@totalBosnian", totalBosnian);
            pVals.Add("@totalCroatian", totalCroatian);
            pVals.Add("@totalOther", totalOther);
            pVals.Add("@Code", Code);
            pVals.Add("@RaceID", RaceID);
            pVals.Add("@TotalCompensation", TotalCompensation);
            pVals.Add("@IncludeNationalities", IncludeNationalities);
            pVals.Add("@param", param);



            pTypes.Add("@totalMandates", "int");
            pTypes.Add("@totalSerbian", "int");
            pTypes.Add("@totalBosnian", "int");
            pTypes.Add("@totalCroatian", "int");
            pTypes.Add("@totalOther", "int");
            pTypes.Add("@Code", "nvarchar");
            pTypes.Add("@RaceID", "int");
            pTypes.Add("@TotalCompensation", "int");
            pTypes.Add("@IncludeNationalities", "bool");
            pTypes.Add("@param", "int");

            executeScalar("p3UpdateNationalityAllocation", pTypes, pVals);
        }
        public void p3_InsertInto_p3_Bags_Denied(int TotalReceivedEnvelopes, string PollingStationCode)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@TotalReceivedEnvelopes", TotalReceivedEnvelopes);
            pVals.Add("@PollingStationCode", PollingStationCode);

            pTypes.Add("@TotalReceivedEnvelopes", "int");
            pTypes.Add("@PollingStationCode", "nvarchar");

            executeScalar("p3_InsertInto_p3_Bags_Denied", pTypes, pVals);
        }
        public DataSet p3_GetMismatchesOBS(string LevelCode,
    string PSCode, int FKRace, int EntryNumber)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@LevelCode", LevelCode);
            pVals.Add("@PSCode", PSCode);
            pVals.Add("@FKRace", FKRace);
            pVals.Add("@EntryNumber", EntryNumber);



            pTypes.Add("@LevelCode", "nvarchar");
            pTypes.Add("@PSCode", "nvarchar");
            pTypes.Add("@FKRace", "numeric");
            pTypes.Add("@EntryNumber", "int");


            DataSet dsTmp = executeResults("p3_GetMismatchesOBS", pTypes, pVals, "p3_ObrazacBrojnogStanje");
            return dsTmp;
        }
        public DataSet RESULTS_getPSStatisticFinalEntry(string PSCode, string LevelCode, int FKRace)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@PSCode", PSCode);
            pVals.Add("@LevelCode", LevelCode);
            pVals.Add("@FKRace", FKRace);

            pTypes.Add("@PSCode", "nvarchar");
            pTypes.Add("@LevelCode", "nvarchar");
            pTypes.Add("@FKRace", "int");

            DataSet ds = executeResults("RESULTS_getPSStatisticFinalEntry", pTypes, pVals, "p3_PSStatistic");
            return ds;
        }

        public void RESULTS_updatePSStatisticFINALEntry(string PSCode, string LevelCode, int FKRace, int FKUser, int TotalVotersInCVR1, int NumberBallotsInBox2, int InvalidUnMarkBallotsA, int InvalidOthersBallotsB, int TotalInvalidBallotsC, int TotalValidVotesD1, int TotalValidVotesNMD2, int TotalValidVotesD, int TotalAllBallotsE, int AccuracyTest23, int AccuracyTest3F)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@PSCode", PSCode);
            pVals.Add("@LevelCode", LevelCode);
            pVals.Add("@FKRace", FKRace);
            pVals.Add("@FKUser", FKUser);
            pVals.Add("@TotalVotersInCVR1", TotalVotersInCVR1);
            pVals.Add("@NumberBallotsInBox2", NumberBallotsInBox2);
            pVals.Add("@InvalidUnMarkBallotsA", InvalidUnMarkBallotsA);
            pVals.Add("@InvalidOthersBallotsB", InvalidOthersBallotsB);
            pVals.Add("@TotalInvalidBallotsC", TotalInvalidBallotsC);
            pVals.Add("@TotalValidVotesD1", TotalValidVotesD1);
            pVals.Add("@TotalValidVotesNMD2", TotalValidVotesNMD2);
            pVals.Add("@TotalValidVotesD", TotalValidVotesD);
            pVals.Add("@TotalAllBallotsE", TotalAllBallotsE);
            pVals.Add("@AccuracyTest23", AccuracyTest23);
            pVals.Add("@AccuracyTest3F", AccuracyTest3F);


            pTypes.Add("@PSCode", "nvarchar");
            pTypes.Add("@LevelCode", "nvarchar");
            pTypes.Add("@FKRace", "int");
            pTypes.Add("@FKUser", "int");
            pTypes.Add("@TotalVotersInCVR1", "int");
            pTypes.Add("@NumberBallotsInBox2", "int");
            pTypes.Add("@InvalidUnMarkBallotsA", "int");
            pTypes.Add("@InvalidOthersBallotsB", "int");
            pTypes.Add("@TotalInvalidBallotsC", "int");
            pTypes.Add("@TotalValidVotesD1", "int");
            pTypes.Add("@TotalValidVotesNMD2", "int");
            pTypes.Add("@TotalValidVotesD", "int");
            pTypes.Add("@TotalAllBallotsE", "int");
            pTypes.Add("@AccuracyTest23", "int");
            pTypes.Add("@AccuracyTest3F", "int");

            executeScalar("RESULTS_updatePSStatisticFINALEntry", pTypes, pVals);
        }
        //Nedim
        public void RESULTS_updatePSStatisticRepeatCounting(string PSCode, string LevelCode, int FKRace, int FKUser, int TotalVotersInCVR1, int NumberBallotsInBox2, int InvalidUnMarkBallotsA, int InvalidOthersBallotsB, int TotalInvalidBallotsC, int TotalValidVotesD1, int TotalValidVotesNMD2, int TotalValidVotesD, int TotalAllBallotsE, int AccuracyTest23, int AccuracyTest3F, int decisionID)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@PSCode", PSCode);
            pVals.Add("@LevelCode", LevelCode);
            pVals.Add("@FKRace", FKRace);
            pVals.Add("@FKUser", FKUser);
            pVals.Add("@TotalVotersInCVR1", TotalVotersInCVR1);
            pVals.Add("@NumberBallotsInBox2", NumberBallotsInBox2);
            pVals.Add("@InvalidUnMarkBallotsA", InvalidUnMarkBallotsA);
            pVals.Add("@InvalidOthersBallotsB", InvalidOthersBallotsB);
            pVals.Add("@TotalInvalidBallotsC", TotalInvalidBallotsC);
            pVals.Add("@TotalValidVotesD1", TotalValidVotesD1);
            pVals.Add("@TotalValidVotesNMD2", TotalValidVotesNMD2);
            pVals.Add("@TotalValidVotesD", TotalValidVotesD);
            pVals.Add("@TotalAllBallotsE", TotalAllBallotsE);
            pVals.Add("@AccuracyTest23", AccuracyTest23);
            pVals.Add("@AccuracyTest3F", AccuracyTest3F);
            pVals.Add("@DecisionID", decisionID);


            pTypes.Add("@PSCode", "nvarchar");
            pTypes.Add("@LevelCode", "nvarchar");
            pTypes.Add("@FKRace", "int");
            pTypes.Add("@FKUser", "int");
            pTypes.Add("@TotalVotersInCVR1", "int");
            pTypes.Add("@NumberBallotsInBox2", "int");
            pTypes.Add("@InvalidUnMarkBallotsA", "int");
            pTypes.Add("@InvalidOthersBallotsB", "int");
            pTypes.Add("@TotalInvalidBallotsC", "int");
            pTypes.Add("@TotalValidVotesD1", "int");
            pTypes.Add("@TotalValidVotesNMD2", "int");
            pTypes.Add("@TotalValidVotesD", "int");
            pTypes.Add("@TotalAllBallotsE", "int");
            pTypes.Add("@AccuracyTest23", "int");
            pTypes.Add("@AccuracyTest3F", "int");
            pTypes.Add("@DecisionID", "int");

            executeScalar("RESULTS_updatePSStatisticRepeatCounting", pTypes, pVals);
        }
        public void p3_UpdateFinalCandidatesForOpenListVotesFINALVOTES(int FKRace, string LevelCode, int FKUser, string PSCode, int FKFCL, int fkCandidate, int votes)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@FKRace", FKRace);
            pVals.Add("@LevelCode", LevelCode);
            pVals.Add("@FKUser", FKUser);
            pVals.Add("@PSCode", PSCode);
            pVals.Add("@FKFCL", FKFCL);
            pVals.Add("@fkCandidate", fkCandidate);
            pVals.Add("@votes", votes);

            pTypes.Add("@FKRace", "numeric");
            pTypes.Add("@LevelCode", "nvarchar");
            pTypes.Add("@FKUser", "int");
            pTypes.Add("@PSCode", "nvarchar");
            pTypes.Add("@FKFCL", "int");
            pTypes.Add("@fkCandidate", "int");
            pTypes.Add("@votes", "int");


            executeScalar("p3_UpdateFinalCandidatesForOpenListVotesFINALVOTES", pTypes, pVals);
        }
        public void RESULTSUpdatePoliticalEntitiesVG2FINALVOTES(string PSCode, string LevelCode, int FKRace, int FKUser, int votes, int listnumber)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();
            pVals.Add("@PSCode", PSCode);
            pVals.Add("@LevelCode", LevelCode);
            pVals.Add("@FKRace", FKRace);
            pVals.Add("@FKUser", FKUser);
            pVals.Add("@votes", votes);
            pVals.Add("@listnumber", listnumber);


            pTypes.Add("@PSCode", "nvarchar");
            pTypes.Add("@LevelCode", "nvarchar");
            pTypes.Add("@FKRace", "int");
            pTypes.Add("@FKUser", "int");
            pTypes.Add("@votes", "int");
            pTypes.Add("@listnumber", "int");
            executeScalar("RESULTSUpdatePoliticalEntitiesVG2FINALVOTES", pTypes, pVals);

        }

        public void OBS_InsertIntoResultsArchive(string PSNumber, int FKCandidacyRace,
                    string LevelCode)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();


            pVals.Add("@PSNumber", PSNumber);
            pVals.Add("@FKCandidacyRace", FKCandidacyRace);
            pVals.Add("@LevelCode", LevelCode);


            pTypes.Add("@PSNumber", "string");
            pTypes.Add("@FKCandidacyRace", "int");
            pTypes.Add("@LevelCode", "string");

            executeScalar("OBS_InsertIntoResultsArchive", pTypes, pVals);
        }

        public void OBS_Missmatches(string PSCode, string LevelCode, int FKRace, int FKUser)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();


            pVals.Add("@PSCode", PSCode);
            pVals.Add("@LevelCode", LevelCode);
            pVals.Add("@FKRace", FKRace);
            pVals.Add("@FKUser", FKUser);


            pTypes.Add("@PSCode", "string");
            pTypes.Add("@LevelCode", "string");
            pTypes.Add("@FKRace", "int");
            pTypes.Add("@FKUser", "int");


            executeScalar("OBS_Missmatches", pTypes, pVals);
        }



        public void p3_Insert_Into_ObrazacBrojnogStanjaUpdate(string PSCode, string LevelCode, int FKRace, int FKUser,
   int Box1, int Box2, int Box3, int Box4, int Box5, int Box6, int Box7, int Box8, int Box9, int Box10, int EntryNumber)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@PSCode", PSCode);
            pVals.Add("@LevelCode", LevelCode);
            pVals.Add("@FKRace", FKRace);

            pVals.Add("@FKUser", FKUser);

            pVals.Add("@Box1", Box1);
            pVals.Add("@Box2", Box2);
            pVals.Add("@Box3", Box3);
            pVals.Add("@Box4", Box4);
            pVals.Add("@Box5", Box5);
            pVals.Add("@Box6", Box6);
            pVals.Add("@Box7", Box7);
            pVals.Add("@Box8", Box8);
            pVals.Add("@Box9", Box9);
            pVals.Add("@Box10", Box10);
            pVals.Add("@EntryNumber", EntryNumber);



            pTypes.Add("@PSCode", "nvarchar");
            pTypes.Add("@LevelCode", "nvarchar");
            pTypes.Add("@FKRace", "numeric");
            pTypes.Add("@FKUser", "int");

            pTypes.Add("@Box1", "int");
            pTypes.Add("@Box2", "int");
            pTypes.Add("@Box3", "int");
            pTypes.Add("@Box4", "int");
            pTypes.Add("@Box5", "int");
            pTypes.Add("@Box6", "int");
            pTypes.Add("@Box7", "int");
            pTypes.Add("@Box8", "int");
            pTypes.Add("@Box9", "int");
            pTypes.Add("@Box10", "int");
            pTypes.Add("@EntryNumber", "int");

            executeScalar("p3_Insert_Into_ObrazacBrojnogStanjaUpdate", pTypes, pVals);
        }


        public DataSet p3_GetScannedVotersForClerkID(string psBag, int clerk)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@psBag", psBag);
            pVals.Add("@clerk", clerk);

            pTypes.Add("@psBag", "nvarchar");
            pTypes.Add("@clerk", "int");

            DataSet ds = executeResults("p3_GetScannedVotersForClerkID", pTypes, pVals, "p3_VotesCast");
            return ds;
        }

        public void p3_UpdateToleranceForPSValidation(int race, string level, double tolerance, int user, string PSCode)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@race", race);
            pVals.Add("@level", level);
            pVals.Add("@tolerance", tolerance);
            pVals.Add("@user", user);
            pVals.Add("@PSCode", PSCode);

            pTypes.Add("@race", "int");
            pTypes.Add("@level", "nvarchar");
            pTypes.Add("@tolerance", "numeric");
            pTypes.Add("@user", "int");
            pTypes.Add("@PSCode", "nvarchar");


            executeScalar("p3_UpdateToleranceForPSValidation", pTypes, pVals);
        }

        public void p3_UpdateToleranceForPSValidation(int race, string level, double tolerance, int user, string PSCode, string decision)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@race", race);
            pVals.Add("@level", level);
            pVals.Add("@tolerance", tolerance);
            pVals.Add("@user", user);
            pVals.Add("@PSCode", PSCode);
            pVals.Add("@DecisionNum", decision);

            pTypes.Add("@race", "int");
            pTypes.Add("@level", "nvarchar");
            pTypes.Add("@tolerance", "numeric");
            pTypes.Add("@user", "int");
            pTypes.Add("@PSCode", "nvarchar");
            pTypes.Add("@DecisionNum", "nvarchar");


            executeScalar("p3_UpdateToleranceForPSValidationWithDecision", pTypes, pVals);
        }

        public void p3_UpdateLockForPSValidation(int race, string level, int user, string PSCode)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@race", race);
            pVals.Add("@level", level);
            pVals.Add("@user", user);
            pVals.Add("@PSCode", PSCode);

            pTypes.Add("@race", "int");
            pTypes.Add("@level", "nvarchar");
            pTypes.Add("@user", "int");
            pTypes.Add("@PSCode", "nvarchar");


            executeScalar("p3_UpdateLockForPSValidation", pTypes, pVals);
        }
        public void p3_UpdateUnlockForPSValidation(int race, string level, int user, string PSCode)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@race", race);
            pVals.Add("@level", level);
            pVals.Add("@user", user);
            pVals.Add("@PSCode", PSCode);

            pTypes.Add("@race", "int");
            pTypes.Add("@level", "nvarchar");
            pTypes.Add("@user", "int");
            pTypes.Add("@PSCode", "nvarchar");


            executeScalar("p3_UpdateUnlockForPSValidation", pTypes, pVals);
        }

        public void ResultsValidation_CheckPSsForValidationForRace(int race)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@race", race);
            pTypes.Add("@race", "int");
            executeScalar("ResultsValidation_CheckPSsForValidationForRace", pTypes, pVals);
        }


        public void ResultsValidation_ValidatePSForRace(string psCode, int race)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@psCode", psCode);
            pVals.Add("@race", race);

            pTypes.Add("@psCode", "string");
            pTypes.Add("@race", "int");
            executeScalar("ResultsValidation_ValidatePSForRace", pTypes, pVals);
        }

        public void ResultsValidation_CheckPSsForValidationForRaceMEC(int race, int user)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@race", race);
            pVals.Add("@user", user);

            pTypes.Add("@race", "int");
            pTypes.Add("@user", "int");
            executeScalar("ResultsValidation_CheckPSsForValidationForRaceMEC", pTypes, pVals);
        }

        public void ResultsValidation_ValidatePSForRaceMEC(string psCode, int race)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@psCode", psCode);
            pVals.Add("@race", race);

            pTypes.Add("@psCode", "string");
            pTypes.Add("@race", "int");
            executeScalar("ResultsValidation_ValidatePSForRaceMEC", pTypes, pVals);
        }
        //public DataSet p3_InsertIntoVotesCast(string jmb, int clerk, string psBag, bool suspicious, string document)
        public DataSet p3_InsertIntoVotesCast(string jmb, int clerk, string psBag, bool suspicious)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@jmb", jmb);
            pVals.Add("@clerk", clerk);
            pVals.Add("@psBag", psBag);
            pVals.Add("@suspicious", suspicious);
            //pVals.Add("@document", document);

            pTypes.Add("@jmb", "nvarchar");
            pTypes.Add("@clerk", "int");
            pTypes.Add("@psBag", "nvarchar");
            pTypes.Add("@suspicious", "BIT");
            //pTypes.Add("@document", "nvarchar");

            DataSet ds = executeResults("p3_InsertIntoVotesCast", pTypes, pVals, "p3_VotesCast");
            return ds;
        }

        public int p3_getScannedVotesByMail(string bag)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@bag", bag);

            pTypes.Add("@bag", "nvarchar");

            object i = executeScalar("p3_getScannedVotesByMail", pTypes, pVals);
            int j = Convert.ToInt32(i);
            return j;
        }


        public void p3_insertOtherMaterialsFromShipment(int ShipmentNumber, string Type, int Value, int userID)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@ShipmentNumber", ShipmentNumber);
            pVals.Add("@Type", Type);
            pVals.Add("@Value", Value);
            pVals.Add("@userID", userID);


            pTypes.Add("@ShipmentNumber", "int");
            pTypes.Add("@Type", "nchar");
            pTypes.Add("@Value", "int");
            pTypes.Add("@userID", "int");


            executeScalar("p3_insertOtherMaterialsFromShipment", pTypes, pVals);
        }


        // 24 08 2010 elena
        public void p3_UpdateMandatesPartiesAlocation158(int race, string levelCode)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@race", race);
            pVals.Add("@levelCode", levelCode);

            pTypes.Add("@race", "int");
            pTypes.Add("@levelCode", "nvarchar");

            executeScalar("p3_UpdateMandatesPartiesAlocation158", pTypes, pVals);
        }
        public void p3_AllocationPartiesCoeficient(int race, string level)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@race", race);
            pVals.Add("@level", level);

            pTypes.Add("@race", "int");
            pTypes.Add("@level", "nvarchar");



            executeScalar("p3_AllocationPartiesCoeficient", pTypes, pVals);
        }

        public void p3_getCandidatesMandates157(int FKRace, string LevelCode, int parties)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@FKRace", FKRace);
            pVals.Add("@LevelCode", LevelCode);
            pVals.Add("@parties", parties);

            pTypes.Add("@FKRace", "int");
            pTypes.Add("@LevelCode", "nvarchar");
            pTypes.Add("@parties", "int");
            executeScalar("p3_getCandidatesMandates157", pTypes, pVals);
        }
        public DataSet p3_getTotalMandates(int race, string level)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@race", race);
            pVals.Add("@level", level);

            pTypes.Add("@race", "int");
            pTypes.Add("@level", "nvarchar");

            DataSet dsTmp = new DataSet();
            dsTmp = executeResults("p3_getTotalMandates", pTypes, pVals, "p3_NationalityAllocation");
            return dsTmp;
        }
        public void p3_GetUpdateAlocation(int FKRace, string level, int parties, double kolicnik, string comment)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@race", FKRace);
            pVals.Add("@level", level);
            pVals.Add("@parties", parties);
            pVals.Add("@kolicnik", kolicnik);
            pVals.Add("@comment", comment);

            pTypes.Add("@race", "int");
            pTypes.Add("@level", "nvarchar");
            pTypes.Add("@parties", "int");
            pTypes.Add("@kolicnik", "numeric");
            pTypes.Add("@comment", "nvarchar");

            executeScalar("p3_GetUpdateAlocation", pTypes, pVals);
        }


        public void p3_GetUpdateAlocationCLEAR(int FKRace, string level)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@race", FKRace);
            pVals.Add("@level", level);

            pTypes.Add("@race", "int");
            pTypes.Add("@level", "nvarchar");

            executeScalar("p3_GetUpdateAlocationCLEAR", pTypes, pVals);
        }
        public void p3_CountUpdateAlocation(int FKRace, string level, int parties)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@race", FKRace);
            pVals.Add("@level", level);
            pVals.Add("@parties", parties);

            pTypes.Add("@race", "int");
            pTypes.Add("@level", "nvarchar");
            pTypes.Add("@parties", "int");

            executeScalar("p3_CountUpdateAlocation", pTypes, pVals);
        }
        public DataSet p3_getPatiiteUpdateAlocation(int race, string level)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@race", race);
            pVals.Add("@level", level);

            pTypes.Add("@race", "int");
            pTypes.Add("@level", "nvarchar");

            DataSet dsTmp = new DataSet();
            dsTmp = executeResults("p3_getPatiiteUpdateAlocation", pTypes, pVals, "p3_AllocationQuotient");
            return dsTmp;
        }
        public DataSet p3_getTotalCompensatory(int race, string level)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@race", race);
            pVals.Add("@level", level);

            pTypes.Add("@race", "int");
            pTypes.Add("@level", "nvarchar");

            DataSet dsTmp = new DataSet();
            dsTmp = executeResults("p3_getTotalCompensatory", pTypes, pVals, "p3_NationalityAllocation");
            return dsTmp;
        }
        public void p3_GetUpdateAlocationCompensatoryCLEAR(int FKRace, string level)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@race", FKRace);
            pVals.Add("@level", level);

            pTypes.Add("@race", "int");
            pTypes.Add("@level", "nvarchar");

            executeScalar("p3_GetUpdateAlocationCompensatoryCLEAR", pTypes, pVals);
        }
        public void p3_GetUpdateAlocationCompensatory(int FKRace, string level, int parties, double kolicnik, string comment)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@race", FKRace);
            pVals.Add("@level", level);
            pVals.Add("@parties", parties);
            pVals.Add("@kolicnik", kolicnik);
            pVals.Add("@comment", comment);

            pTypes.Add("@race", "int");
            pTypes.Add("@level", "nvarchar");
            pTypes.Add("@parties", "int");
            pTypes.Add("@kolicnik", "double");
            pTypes.Add("@comment", "nvarchar");


            executeScalar("p3_GetUpdateAlocationCompensatory", pTypes, pVals);
        }

        public DataSet p3_getPatiiteUpdateAlocationCompensatory(int race, string level)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@race", race);
            pVals.Add("@level", level);

            pTypes.Add("@race", "int");
            pTypes.Add("@level", "nvarchar");

            DataSet dsTmp = new DataSet();
            dsTmp = executeResults("p3_getPatiiteUpdateAlocationCompensatory", pTypes, pVals, "p3_AllocationQuotient");
            return dsTmp;
        }
        public void p3_CountUpdateAlocationCompensatory(int FKRace, string level, int parties)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@race", FKRace);
            pVals.Add("@level", level);
            pVals.Add("@parties", parties);

            pTypes.Add("@race", "int");
            pTypes.Add("@level", "nvarchar");
            pTypes.Add("@parties", "int");

            executeScalar("p3_CountUpdateAlocationCompensatory", pTypes, pVals);
        }
        public void p3_AllocationPartiesCoeficientCompensatory(string level)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();


            pVals.Add("@level", level);

            pTypes.Add("@level", "nvarchar");



            executeScalar("p3_AllocationPartiesCoeficientCompensatory", pTypes, pVals);
        }

        public DataSet TurnoutGetSummaryByRace(int race, int param)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@race", race);
            pVals.Add("@param", param);

            pTypes.Add("@race", "int");
            pTypes.Add("@param", "int");

            DataSet dsTmp = new DataSet();
            dsTmp = executeResults("TurnoutGetSummaryByRace", pTypes, pVals, "p3_AllocationQuotient");
            return dsTmp;
        }
        public void p3_EditBags(int id, int totalEnv)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@id", id);
            pVals.Add("@totalEnv", totalEnv);


            pTypes.Add("@id", "int");
            pTypes.Add("@totalEnv", "int");

            executeScalar("p3_EditBags", pTypes, pVals);
        }



        public void p3_EditOtherMaterials(int id, int totalEnv)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@id", id);
            pVals.Add("@totalEnv", totalEnv);


            pTypes.Add("@id", "int");
            pTypes.Add("@totalEnv", "int");

            executeScalar("p3_EditOtherMaterials", pTypes, pVals);
        }


        public DataSet p3_getBoxNoOfBallotsSorted(string boxName, string levelCode)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@boxName", boxName);
            pVals.Add("@levelCode", levelCode);

            pTypes.Add("@boxName", "nvarchar");
            pTypes.Add("@levelCode", "nvarchar");

            DataSet ds = executeResults("p3_getBoxNoOfBallotsSorted", pTypes, pVals, "p3_BoxDetail");
            return ds;
        }

        public DataSet p3_GetTotalParties(int race, int parija, string level)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@race", race);
            pVals.Add("@parija", parija);
            pVals.Add("@level", level);

            pTypes.Add("@race", "int");
            pTypes.Add("@parija", "int");
            pTypes.Add("@level", "nvarchar");

            DataSet dsTmp = new DataSet();
            dsTmp = executeResults("p3_GetTotalParties", pTypes, pVals, "FINALPEMandates");
            return dsTmp;
        }
        public void p3_UpdateManualAlocationCandidates(int kandidat)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@kandidat", kandidat);


            pTypes.Add("@kandidat", "int");


            executeScalar("p3_UpdateManualAlocationCandidates", pTypes, pVals);
        }
        public void p3_UpdateManualAlocationCandidatesClear(int race, string level, int parties)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@race", race);
            pVals.Add("@level", level);
            pVals.Add("@parties", parties);

            pTypes.Add("@race", "int");
            pTypes.Add("@level", "nvarchar");
            pTypes.Add("@parties", "int");

            executeScalar("p3_UpdateManualAlocationCandidatesClear", pTypes, pVals);
        }


        public DataSet p3_Check1Entry(int race, string pscode, int userLogged)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@race", race);
            pVals.Add("@pscode", pscode);
            pVals.Add("@userLogged", userLogged);

            pTypes.Add("@race", "int");
            pTypes.Add("@pscode", "nvarchar");
            pTypes.Add("@userLogged", "nvarchar");

            DataSet dsTmp = new DataSet();
            dsTmp = executeResults("p3_Check1Entry", pTypes, pVals, "p3_ResultsEntriesArchive");
            return dsTmp;
        }


        public DataSet p3_getIfEnteredEntry1_2_IntoOBS(int race, string pscode, string levelCode)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@FKRace", race);
            pVals.Add("@PSCode", pscode);
            pVals.Add("@LevelCode", levelCode);

            pTypes.Add("@FKRace", "int");
            pTypes.Add("@PSCode", "nvarchar");
            pTypes.Add("@LevelCode", "nvarchar");

            DataSet dsTmp = new DataSet();
            dsTmp = executeResults("p3_getIfEnteredEntry1_2_IntoOBS", pTypes, pVals, "p3_ObrazacBrojnogStanje");
            return dsTmp;
        }


        public DataSet p3_GetTotalPartiesCompensatory(int parija, string level)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@parija", parija);
            pVals.Add("@level", level);


            pTypes.Add("@parija", "int");
            pTypes.Add("@level", "nvarchar");


            DataSet dsTmp = new DataSet();
            dsTmp = executeResults("p3_GetTotalPartiesCompensatory", pTypes, pVals, "FINALPEMandates");
            return dsTmp;
        }

        public void p3_UpdateManualAlocationCandidatesCompensatory(int kandidat)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@kandidat", kandidat);


            pTypes.Add("@kandidat", "int");


            executeScalar("p3_UpdateManualAlocationCandidatesCompensatory", pTypes, pVals);
        }


        public void p3_UpdateManualAlocationCandidatesClearCompensatory(string level, int parties)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();


            pVals.Add("@level", level);
            pVals.Add("@parties", parties);


            pTypes.Add("@level", "nvarchar");
            pTypes.Add("@parties", "int");

            executeScalar("p3_UpdateManualAlocationCandidatesClearCompensatory", pTypes, pVals);
        }


        public string Tracking_Results_GetLevelForRaceANDCombination(string kom, int race)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@kom", kom);
            pVals.Add("@race", race);

            pTypes.Add("@kom", "string");
            pTypes.Add("@race", "int");

            DataSet dsTmp = new DataSet();
            dsTmp = executeResults("Tracking_Results_GetLevelForRaceANDCombination", pTypes, pVals, "p3_CombinationsLevels");
            return dsTmp.Tables[0].Rows[0][0].ToString();
        }



        public DataSet p3getEntriesArchiveItemsTracking(string PSNumber, int FKCandidacyRace, string LevelCode, int status)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@PSNumber", PSNumber);
            pVals.Add("@FKCandidacyRace", FKCandidacyRace);
            pVals.Add("@LevelCode", LevelCode);
            pVals.Add("@status", status);

            pTypes.Add("@PSNumber", "nvarchar");
            pTypes.Add("@FKCandidacyRace", "int");
            pTypes.Add("@LevelCode", "nvarchar");
            pTypes.Add("@status", "int");

            DataSet dsTmp = new DataSet();
            dsTmp = executeResults("p3getEntriesArchiveItemsTracking", pTypes, pVals, "p3_ResultsEntriesArchive");
            return dsTmp;
        }


        public DataSet p3getPSStatisticEntryTracking(string pscode, string level, int race, int entry)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@pscode", pscode);
            pVals.Add("@level", level);
            pVals.Add("@race", race);
            pVals.Add("@entry", entry);
            pTypes.Add("@pscode", "string");
            pTypes.Add("@level", "string");
            pTypes.Add("@race", "int");
            pTypes.Add("@entry", "int");
            DataSet ds = executeResults("p3getPSStatisticEntryTracking", pTypes, pVals, "p3_PSStatistic");
            return ds;
        }


        public DataSet RESULTSLevelGetNameForCodeTracking(string Code, int idrace)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@Code", Code);
            pVals.Add("@idrace", idrace);
            pTypes.Add("@Code", "string");
            pTypes.Add("@idrace", "int");

            DataSet ds = executeResults("RESULTSLevelGetNameForCodeTracking", pTypes, pVals, "BMunicipalityRegion");
            return ds;
        }


        public DataSet RESULTSLevelGetLevelForCOmbinationTracking(string Code, int idrace)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@Code", Code);
            pVals.Add("@idrace", idrace);
            pTypes.Add("@Code", "string");
            pTypes.Add("@idrace", "int");

            DataSet ds = executeResults("RESULTSLevelGetLevelForCOmbinationTracking", pTypes, pVals, "BMunicipalityRegion");
            return ds;
        }



      //  public DataSet p3_InsertIntoVotesCastUnconfirmed(string jmb, int clerk, string psBag, string firstName, string lastName, string birthDate, bool suspicious, string document)
        public DataSet p3_InsertIntoVotesCastUnconfirmed(string jmb, int clerk, string psBag, string firstName, string lastName, string birthDate, bool suspicious)

        {

            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@jmb", jmb);
            pVals.Add("@clerk", clerk);
            pVals.Add("@psBag", psBag);
            pVals.Add("@firstName", firstName);
            pVals.Add("@lastName", lastName);
            pVals.Add("@birthDate", birthDate);
            pVals.Add("@suspicious", suspicious);
           // pVals.Add("@documentName", document);

            pTypes.Add("@jmb", "nvarchar");
            pTypes.Add("@clerk", "int");
            pTypes.Add("@psBag", "nvarchar");
            pTypes.Add("@firstName", "nvarchar");
            pTypes.Add("@lastName", "nvarchar");
            pTypes.Add("@birthDate", "nvarchar");
            pTypes.Add("@suspicious", "BIT");
          //  pTypes.Add("@documentName", "nvarchar");

            DataSet ds = executeResults("p3_InsertIntoVotesCastUnconfirmed", pTypes, pVals, "p3_VotesCast");
            return ds;
        }


        public string Results_GetLevelForRaceANDMun(int race, string mun)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();
            pVals.Add("@race", race);
            pVals.Add("@mun", mun);

            pTypes.Add("@race", "int");
            pTypes.Add("@mun", "string");

            object tmpObj = executeScalar("Results_GetLevelForRaceANDMun", pTypes, pVals);
            return tmpObj as string;
        }


        public int OBS_CheckStatusForEntry(int race, string psCode)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@race", race);
            pVals.Add("@psCode", psCode);

            pTypes.Add("@race", "int");
            pTypes.Add("@psCode", "string");

            DataSet dsTmp = new DataSet();
            dsTmp = executeResults("OBS_CheckStatusForEntry", pTypes, pVals, "p3_ObrazacBrojnogStanje");
            return int.Parse(dsTmp.Tables[0].Rows[0][0].ToString());
        }


        public DataSet p3_getScannedCountByClerk(string psBag, int clerk)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@psBag", psBag);
            pVals.Add("@clerk", clerk);

            pTypes.Add("@psBag", "nvarchar");
            pTypes.Add("@clerk", "int");

            DataSet ds = executeResults("p3_getScannedCountByClerk", pTypes, pVals, "p3_VotesCast");
            return ds;
        }


        public DataSet ResultsValidation_GetItemsForParametarsCEC(int race, int type, string psCode)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@race", race);
            pVals.Add("@type", type);
            pVals.Add("@psCode", psCode);

            pTypes.Add("@race", "int");
            pTypes.Add("@type", "int");
            pTypes.Add("@psCode", "string");

            DataSet ds = executeResults("ResultsValidation_GetItemsForParametarsCEC", pTypes, pVals, "PSValidationItems");
            return ds;
        }


        public DataSet ResultsValidation_GetTotalVotesForItem7(int race, string psCode)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@race", race);
            pVals.Add("@psCode", psCode);

            pTypes.Add("@race", "int");
            pTypes.Add("@psCode", "string");

            DataSet ds = executeResults("ResultsValidation_GetTotalVotesForItem7", pTypes, pVals, "PSValidationItems");
            return ds;
        }

        public void ResultsValidation_UpdateItemsToValid(string psCode, int race, int type)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@psCode", psCode);
            pVals.Add("@race", race);
            pVals.Add("@type", type);

            pTypes.Add("@psCode", "string");
            pTypes.Add("@race", "int");
            pTypes.Add("@type", "int");

            executeScalar("ResultsValidation_UpdateItemsToValid", pTypes, pVals);
        }

        public DataSet p3_CheckZeroCount()
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();
            DataSet ds = executeResults("p3_CheckZeroCount", pTypes, pVals, "PSValidationItems");
            return ds;


        }

        public void p3DeleteCecMessages(int id)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();


            pVals.Add("@id", id);

            pTypes.Add("@id", "int");

            executeScalar("p3DeleteCecMessages", pTypes, pVals);
        }

        public DataSet p3_InsertIntoVotesCastMobilni(string jmb, int clerk, string psBag, string firstName, string lastName, string birthDate, string potpis, bool suspicious)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@jmb", jmb);
            pVals.Add("@clerk", clerk);
            pVals.Add("@psBag", psBag);
            pVals.Add("@firstName", firstName);
            pVals.Add("@lastName", lastName);
            pVals.Add("@birthDate", birthDate);
            pVals.Add("@potpis", potpis);
            pVals.Add("@suspicious", suspicious);

            pTypes.Add("@jmb", "nvarchar");
            pTypes.Add("@clerk", "int");
            pTypes.Add("@psBag", "nvarchar");
            pTypes.Add("@firstName", "nvarchar");
            pTypes.Add("@lastName", "nvarchar");
            pTypes.Add("@birthDate", "nvarchar");
            pTypes.Add("@potpis", "nvarchar");
            pTypes.Add("@suspicious", "BIT");
           // pTypes.Add("@document", "nvarchar");

            DataSet ds = executeResults("p3_InsertIntoVotesCastMobilni", pTypes, pVals, "p3_VotesCast");
            return ds;
        }


        public DataSet p3_InsertIntoVotesCastDKP(string jmb, int clerk, string psBag, bool suspicious)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@jmb", jmb);
            pVals.Add("@clerk", clerk);
            pVals.Add("@psBag", psBag);
            pVals.Add("@suspicious", suspicious);

            pTypes.Add("@jmb", "nvarchar");
            pTypes.Add("@clerk", "int");
            pTypes.Add("@psBag", "nvarchar");
            pTypes.Add("@suspicious", "BIT");

            DataSet ds = executeResults("p3_InsertIntoVotesCastDKP", pTypes, pVals, "p3_VotesCast");
            return ds;
        }

        public DataSet p3_InsertIntoVotesCastOdsustvo(string jmb, int clerk, string psBag, bool suspicious)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@jmb", jmb);
            pVals.Add("@clerk", clerk);
            pVals.Add("@psBag", psBag);
            pVals.Add("@suspicious", suspicious);

            pTypes.Add("@jmb", "nvarchar");
            pTypes.Add("@clerk", "int");
            pTypes.Add("@psBag", "nvarchar");
            pTypes.Add("@suspicious", "BIT");

            DataSet ds = executeResults("p3_InsertIntoVotesCastOdsustvo", pTypes, pVals, "p3_VotesCast");
            return ds;
        }

        public DataSet p3GetUserByPosition(int langID, string param)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@langID", langID);
            pVals.Add("@param", param);
            pTypes.Add("@langID", "int");
            pTypes.Add("@param", "varchar");

            DataSet ds = executeResults("p3GetUserByPosition", pTypes, pVals, "p3_PollingStation");
            return ds;
        }

        public void WEBAdmin_GenerateForParamANDLevel(int param, int race, string level)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@param", param);
            pVals.Add("@race", race);
            pVals.Add("@level", level);


            pTypes.Add("@param", "int");
            pTypes.Add("@race", "int");
            pTypes.Add("@level", "nvarchar");


            executeScalar("WEBAdmin_GenerateForParamANDLevel", pTypes, pVals);
        }


        public void WEBRESULTS_GeneratePreliminary(int userID, int race, string level)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@userID", userID);
            pVals.Add("@race", race);
            pVals.Add("@level", level);

            pTypes.Add("@userID", "int");
            pTypes.Add("@race", "int");
            pTypes.Add("@level", "string");

            executeScalar("WEBRESULTS_GeneratePreliminary", pTypes, pVals);
        }

        public void WebGenerateResultsGEN(int userID, int race, string level)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@userID", userID);
            pVals.Add("@race", race);
            pVals.Add("@level", level);

            pTypes.Add("@userID", "int");
            pTypes.Add("@race", "int");
            pTypes.Add("@level", "string");

            executeScalar("WebGenerateResultsGEN", pTypes, pVals);
        }
        public void WEBRESULTS_GeneratePreliminaryEntry5(int userID, int race, string level)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@userID", userID);
            pVals.Add("@race", race);
            pVals.Add("@level", level);

            pTypes.Add("@userID", "int");
            pTypes.Add("@race", "int");
            pTypes.Add("@level", "string");

            executeScalar("WEBRESULTS_GeneratePreliminaryEntry5", pTypes, pVals);
        }


        public string GetMunCodeForPS(string pscode)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();
            pVals.Add("@pscode", pscode);

            pTypes.Add("@pscode", "string");

            object tmpObj = executeScalar("GetMunCodeForPS", pTypes, pVals);
            return tmpObj as string;
        }

        public DataSet p3GetMessagesCEC(int user, string param)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@user", user);
            pVals.Add("@param", param);

            pTypes.Add("@user", "int");
            pTypes.Add("@param", "varchar");

            DataSet ds = executeResults("p3GetMessagesCEC", pTypes, pVals, "p3_Messages");
            return ds;
        }


        public int p3_getNoEnvInBagForCombination(string psBag, string combination)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@psBag", psBag);
            pVals.Add("@combination", combination);

            pTypes.Add("@psBag", "nvarchar");
            pTypes.Add("@combination", "nvarchar");

            object obj = executeScalar("p3_getNoEnvInBagForCombination", pTypes, pVals);
            int count = 0;
            count = Convert.ToInt32(obj);
            return count;
        }


        public void p3_UpdateBagStatusPost(string psBag, int bagStatus)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@psBag", psBag);
            pVals.Add("@bagStatus", bagStatus);

            pTypes.Add("@psBag", "nvarchar");
            pTypes.Add("@bagStatus", "int");

            executeScalar("p3_UpdateBagStatusPost", pTypes, pVals);
        }


        public int p3_GetIfShipmentExists(int shipmentnumber)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@shipmentnumber", shipmentnumber);
            pTypes.Add("@shipmentnumber", "int");

            object obj = executeScalar("p3_GetIfShipmentExists", pTypes, pVals);
            int count = 0;
            count = Convert.ToInt32(obj);
            return count;
        }


        public string RESULTSGetCandidatesForPEOLMissmatcesGetPartyName(int fklist)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();
            pVals.Add("@fklist", fklist);

            pTypes.Add("@fklist", "int");

            object tmpObj = executeScalar("RESULTSGetCandidatesForPEOLMissmatcesGetPartyName", pTypes, pVals);
            return tmpObj as string;
        }


        public void NewValidation_InsertUpdateIntop3ValS(string pscode, int race, int param)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@pscode", pscode);
            pVals.Add("@race", race);
            pVals.Add("@param", param);

            pTypes.Add("@pscode", "nvarchar");
            pTypes.Add("@race", "int");
            pTypes.Add("@param", "int");

            executeScalar("NewValidation_InsertUpdateIntop3ValS", pTypes, pVals);
        }


        public void NewValidationResultsValidation_ValidatePSForRace(string pscode, int race)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@pscode", pscode);
            pVals.Add("@race", race);

            pTypes.Add("@pscode", "nvarchar");
            pTypes.Add("@race", "int");

            executeScalar("NewValidationResultsValidation_ValidatePSForRace", pTypes, pVals);
        }

        public void ValidatePSWithTolerance(string pscode, int race, int tt)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@pscode", pscode);
            pVals.Add("@race", race);
            pVals.Add("@tt", tt);

            pTypes.Add("@pscode", "nvarchar");
            pTypes.Add("@race", "int");
            pTypes.Add("@tt", "int");

            executeScalar("p3_ValidatePSWithTolerance", pTypes, pVals);
        }


        public int NewValidationCheckIFOKZR(string pscode, int race)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@pscode", pscode);
            pVals.Add("@race", race);

            pTypes.Add("@pscode", "nvarchar");
            pTypes.Add("@race", "int");

            object obj = executeScalar("NewValidationCheckIFOKZR", pTypes, pVals);
            int count = 0;
            count = Convert.ToInt32(obj);
            return count;
        }


        public int NEWValidation_GetOBS5(string pscode, int race)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@pscode", pscode);
            pVals.Add("@race", race);

            pTypes.Add("@pscode", "nvarchar");
            pTypes.Add("@race", "int");

            object obj = executeScalar("NEWValidation_GetOBS5", pTypes, pVals);
            int count = 0;
            count = Convert.ToInt32(obj);
            return count;
        }

        public void NEWValidation_EditOBS5(string pscode, int race, int value)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@pscode", pscode);
            pVals.Add("@race", race);
            pVals.Add("@value", value);

            pTypes.Add("@pscode", "nvarchar");
            pTypes.Add("@race", "int");
            pTypes.Add("@value", "int");

            executeScalar("NEWValidation_EditOBS5", pTypes, pVals);
        }


        public void p3_GetUpdateAlocationStatus0(int FKRace, string level, int parties, double kolicnik, string comment)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@race", FKRace);
            pVals.Add("@level", level);
            pVals.Add("@parties", parties);
            pVals.Add("@kolicnik", kolicnik);
            pVals.Add("@comment", comment);

            pTypes.Add("@race", "int");
            pTypes.Add("@level", "nvarchar");
            pTypes.Add("@parties", "int");
            pTypes.Add("@kolicnik", "numeric");
            pTypes.Add("@comment", "nvarchar");

            executeScalar("p3_GetUpdateAlocationStatus0", pTypes, pVals);
        }

        public DataSet p3getCountNationalityAllocation(string code)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@code", code);

            pTypes.Add("@code", "nvarchar");

            DataSet ds = executeResults("p3getCountNationalityAllocation", pTypes, pVals, "p3_NationalityAllocation");
            return ds;
        }
        public DataSet AllocationGetNationalitisBoHrSr(string level)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@level", level);

            pTypes.Add("@level", "nvarchar");

            DataSet ds = executeResults("AllocationGetNationalitisBoHrSr", pTypes, pVals, "p3_NationalityAllocation");
            return ds;
        }
        public DataSet AllocationGetNationalitisForAlarm(string level)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@level", level);

            pTypes.Add("@level", "nvarchar");

            DataSet ds = executeResults("AllocationGetNationalitisForAlarm", pTypes, pVals, "p3_NationalityAllocation");
            return ds;
        }
        public void p3_GetUpdateAlocationCompensatoryStatus0(int FKRace, string level, int parties, double kolicnik, string comment)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@race", FKRace);
            pVals.Add("@level", level);
            pVals.Add("@parties", parties);
            pVals.Add("@kolicnik", kolicnik);
            pVals.Add("@comment", comment);

            pTypes.Add("@race", "int");
            pTypes.Add("@level", "nvarchar");
            pTypes.Add("@parties", "int");
            pTypes.Add("@kolicnik", "double");
            pTypes.Add("@comment", "nvarchar");


            executeScalar("p3_GetUpdateAlocationCompensatoryStatus0", pTypes, pVals);
        }
        public DataSet p3_getCandidateFinalMandate(int race, string level, int partii, int finalpe)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();
            pVals.Add("@race", race);
            pVals.Add("@level", level);
            pVals.Add("@partii", partii);
            pVals.Add("@finalpe", finalpe);

            pTypes.Add("@race", "int");
            pTypes.Add("@level", "nvarchar");
            pTypes.Add("@partii", "int");
            pTypes.Add("@finalpe", "int");

            DataSet ds = executeResults("p3_getCandidateFinalMandate", pTypes, pVals, "p3_NationalityAllocation");
            return ds;
        }




        /////// ACE 29 09 

        public int RESULTSGetCandidatesListIDForCandidate(int candID)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@candID", candID);
            pTypes.Add("@candID", "int");

            object obj = executeScalar("RESULTSGetCandidatesListIDForCandidate", pTypes, pVals);
            int count = 0;
            count = Convert.ToInt32(obj);
            return count;
        }


        public int RESULTSGetIdListForNationalMinority(string MunReg)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@levelCode", MunReg);
            pTypes.Add("@levelCode", "string");

            object obj = executeScalar("RESULTSGetIdListForNationalMinority", pTypes, pVals);
            int count = 0;
            count = Convert.ToInt32(obj);
            return count;
        }


        public void WEBAdminMandatesGenerate(int race, string level)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            
            pVals.Add("@race", race);
            pVals.Add("@level", level);

            
            pTypes.Add("@race", "int");
            pTypes.Add("@level", "string");

            executeScalar("WEBAdminMandatesGenerate", pTypes, pVals);
        }

        public void p3_updateBagStatusOneStepBack(string psCode, string bagStatus)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@psCode", psCode);
            pVals.Add("@bagStatus", bagStatus);

            pTypes.Add("@psCode", "nvarchar");
            pTypes.Add("@bagStatus", "nvarchar");

            executeScalar("p3_updateBagStatusOneStepBack", pTypes, pVals);
        }

        public DataSet p3_getNumberOfScannedVoters(string psBag)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@psBag", psBag);

            pTypes.Add("@psBag", "nvarchar");

            DataSet ds = executeResults("p3_getNumberOfScannedVoters", pTypes, pVals, "p3_VotesCast");
            return ds;
        }

        public DataSet dms_getAllAppruvedUsers(int language, string param)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@language", language);
            pVals.Add("@param", param);
            pTypes.Add("@language", "int");
            pTypes.Add("@param", "varchar");
            DataSet dsTmp = new DataSet();
            dsTmp = executeResults("dms_getAllAppruvedUsers", pTypes, pVals, "Users");
            return dsTmp;
        }

        public void VFEValidateForRace(int race)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@race", race);

            pTypes.Add("@race", "int");

            executeScalar("VFEValidateForRace", pTypes, pVals);
        }


        public DataSet ProcedureForGeneralReportOpenClose()
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            DataSet ds = executeResults("ProcedureForGeneralReportOpenClose", pTypes, pVals, "p3_PSTurnOut");
            return ds;
        }
        public DataSet ProcedureForGeneralReportTurnout(int param)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@param", param);

            pTypes.Add("@param", "int");

            DataSet ds = executeResults("ProcedureForGeneralReportTurnout", pTypes, pVals, "p3_PSTurnOut");
            return ds;
        }

        public void p3_EditFormedBoxes(int totalEnvelopes, int Id)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@totalEnvelopes", totalEnvelopes);
            pVals.Add("@Id", Id);
            pTypes.Add("@totalEnvelopes", "numeric");
            pTypes.Add("@Id", "numeric");
            executeScalar("p3_EditFormedBoxes", pTypes, pVals);

        }



        // 12 10 2010
        public int AfterGetTotalVotesForLevelCompensation(string level)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@level", level);
            pTypes.Add("@level", "string");

            object obj = executeScalar("AfterGetTotalVotesForLevelCompensation", pTypes, pVals);
            int count = 0;
            count = Convert.ToInt32(obj);
            return count;
        }


        public DataSet MENIGetPagesForRank(int rank, int lang)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@rank", rank);
            pVals.Add("@lang", lang);

            pTypes.Add("@rank", "int");
            pTypes.Add("@lang", "int");

            DataSet ds = executeResults("MENIGetPagesForRank", pTypes, pVals, "UserPositionPage");
            return ds;
        }

        public DataSet oktomvriIDpagePosition(int id,int rank)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@id", id);
            pVals.Add("@rank", rank);

            pTypes.Add("@id", "int");
            pTypes.Add("@rank", "int");

            DataSet ds = executeResults("oktomvriIDpagePosition", pTypes, pVals, "UserPositionPage");
            return ds;
        }


        public void p3_inseretIntoDeletedPSBAGS(string psCode, int FKRace, string comment, DateTime datetime, int fkuser, int FKStatus)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@psCode", psCode);
            //pVals.Add("@levelCode", levelCode);
            pVals.Add("@FKRace", FKRace);
            pVals.Add("@comment", comment);
            pVals.Add("@datetime", datetime);
            pVals.Add("@fkuser", fkuser);
            pVals.Add("@FKStatus", FKStatus);

            pTypes.Add("@psCode", "string");
            //pTypes.Add("@levelCode", "string");
            pTypes.Add("@FKRace", "int");
            pTypes.Add("@comment", "string");
            pTypes.Add("@datetime", "datetime");
            pTypes.Add("@fkuser", "int");
            pTypes.Add("@FKStatus", "int");

            executeScalar("p3_inseretIntoDeletedPSBAGS", pTypes, pVals);
        }




        ///////////////////////// 01 11 2010 /////////////////////////////
        public void NewValidationMEC_ResultsValidation_ValidatePSForRace(string pscode, int race)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@pscode", pscode);
            pVals.Add("@race", race);

            pTypes.Add("@pscode", "nvarchar");
            pTypes.Add("@race", "int");

            executeScalar("NewValidationMEC_ResultsValidation_ValidatePSForRace", pTypes, pVals);
        }


        public void NewValidationMEC_insertIntoPSVal(string pscode, int race, string munCode)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@pscode", pscode);
            pVals.Add("@race", race);
            pVals.Add("@munCode", munCode);

            pTypes.Add("@munCode", "nvarchar");
            pTypes.Add("@pscode", "nvarchar");
            pTypes.Add("@race", "int");

            executeScalar("NewValidationMEC_insertIntoPSVal", pTypes, pVals);
        }


        //public bool p3_GetPsCodeFromObrazec1Mun(string PSCode, int FKRace)
        //{
        //    Dictionary<string, object> pVals = new Dictionary<string, object>();
        //    Dictionary<string, string> pTypes = new Dictionary<string, string>();

        //    pVals.Add("@PSCode", PSCode);
        //    pVals.Add("@FKRace", FKRace);

        //    pTypes.Add("@PSCode", "nvarchar");
        //    pTypes.Add("@FKRace", "int");

        //    DataSet ds = executeResults("p3_GetPsCodeFromObrazec1Mun", pTypes, pVals, "p3_ObrazacBrojnogStanje");

        //    if (int.Parse(ds.Tables[0].Rows[0][0].ToString()) == 1)
        //        return true;
        //    else
        //        return false;
        //}

        public bool p3_GetPsCodeFromObrazec1Mun(string PSCode, int FKRace)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@PSCode", PSCode);
            pVals.Add("@FKRace", FKRace);

            pTypes.Add("@PSCode", "nvarchar");
            pTypes.Add("@FKRace", "int");

            DataSet ds = executeResults("p3_GetPsCodeFromObrazec1Mun", pTypes, pVals, "p3_ObrazacBrojnogStanje");

            if (int.Parse(ds.Tables[0].Rows[0][0].ToString()) == 1)
                return true;
            else
                return false;
        }

        public DataSet p3_getBagDetailsForEdit(string psBag)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@psBag", psBag);

            pTypes.Add("@psBag", "varchar");

            DataSet ds = executeResults("p3_getBagDetailsForEdit", pTypes, pVals, "p3_Bags");
            return ds;
        }

        public void p3_updateBagDetails(int TotalReceivedEnvelopes, int VerificationReceived,
            int VerificationAccepted, int VerificationRejected, int BeforeVerificationApproved,
            int BeforeVerificationRejected, string psBag, string bagStatus)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@TotalReceivedEnvelopes", TotalReceivedEnvelopes);
            pVals.Add("@VerificationReceived", VerificationReceived);
            pVals.Add("@VerificationAccepted", VerificationAccepted);
            pVals.Add("@VerificationRejected", VerificationRejected);
            pVals.Add("@BeforeVerificationApproved", BeforeVerificationApproved);
            pVals.Add("@BeforeVerificationRejected", BeforeVerificationRejected);
            pVals.Add("@psBag", psBag);
            pVals.Add("@BagStatus", bagStatus);

            pTypes.Add("@TotalReceivedEnvelopes", "int");
            pTypes.Add("@VerificationReceived", "int");
            pTypes.Add("@VerificationAccepted", "int");
            pTypes.Add("@VerificationRejected", "int");
            pTypes.Add("@BeforeVerificationApproved", "int");
            pTypes.Add("@BeforeVerificationRejected", "int");
            pTypes.Add("@psBag", "nvarchar");
            pTypes.Add("@BagStatus", "nvarchar");

            executeScalar("p3_updateBagDetails", pTypes, pVals);
        }

        public DataSet p3_getBoxForEdit(string boxName)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@boxName", boxName);

            pTypes.Add("@boxName", "varchar");

            DataSet ds = executeResults("p3_getBoxForEdit", pTypes, pVals, "p3_Box");
            return ds;
        }

        //Nedim
        public DataSet p3_getBoxDetailForEdit(string boxName, string levelCode)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@boxName", boxName);
            pVals.Add("@levelCode", levelCode);

            pTypes.Add("@boxName", "varchar");
            pTypes.Add("@levelCode", "varchar");

            // 24.09.2012 Energo
            //DataSet ds = executeResults("p3_getBoxForEdit", pTypes, pVals, "p3_BoxDetail");
            DataSet ds = executeResults("p3_getBoxDetail", pTypes, pVals, "p3_BoxDetail");
            return ds;
        }

        public void p3_updateBox(int TotalNoOfEnvelopes, int RejectedInSorting, string boxName, string boxStatus)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@TotalNoOfEnvelopes", TotalNoOfEnvelopes);
            pVals.Add("@RejectedInSorting", RejectedInSorting);
            pVals.Add("@boxName", boxName);
            pVals.Add("@boxStatus", boxStatus);

            pTypes.Add("@TotalNoOfEnvelopes", "int");
            pTypes.Add("@RejectedInSorting", "int");
            pTypes.Add("@boxName", "nvarchar");
            pTypes.Add("@boxStatus", "nvarchar");


            executeScalar("p3_updateBox", pTypes, pVals);
        }

        public void p3_updateBoxDetail(int id, int NoOfBallotsSorted, int NoOfBallotsCounted,
            int NoOfValidBallots, int NoOfInvalidBallots)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@NoOfBallotsSorted", NoOfBallotsSorted);
            pVals.Add("@NoOfBallotsCounted", NoOfBallotsCounted);
            pVals.Add("@NoOfValidBallots", NoOfValidBallots);
            pVals.Add("@NoOfInvalidBallots", NoOfInvalidBallots);
            pVals.Add("@id", id);

            pTypes.Add("@NoOfBallotsSorted", "int");
            pTypes.Add("@NoOfBallotsCounted", "int");
            pTypes.Add("@NoOfValidBallots", "int");
            pTypes.Add("@NoOfInvalidBallots", "int");
            pTypes.Add("@id", "int");

            executeScalar("p3_updateBoxDetail", pTypes, pVals);
        }


        public void p3_updateBagDetail(int id, int NoOfEnvelopes, int NoOfSignatures,
                    int NoOfEnvelopesCounted, int Difference)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@NoOfEnvelopes", NoOfEnvelopes);
            pVals.Add("@NoOfSignatures", NoOfSignatures);
            pVals.Add("@NoOfEnvelopesCounted", NoOfEnvelopesCounted);
            pVals.Add("@Difference", Difference);
            pVals.Add("@id", id);

            pTypes.Add("@NoOfEnvelopes", "int");
            pTypes.Add("@NoOfSignatures", "int");
            pTypes.Add("@NoOfEnvelopesCounted", "int");
            pTypes.Add("@Difference", "int");
            pTypes.Add("@id", "int");

            executeScalar("p3_updateBagDetail", pTypes, pVals);
        }

        public bool p3_GetPsCodeFromObrazecM(string PSCode, int FKRace)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@PSCode", PSCode);
            pVals.Add("@FKRace", FKRace);

            pTypes.Add("@PSCode", "nvarchar");
            pTypes.Add("@FKRace", "int");


            DataSet ds = executeResults("p3_GetPsCodeFromObrazecM", pTypes, pVals, "p3_ObrazacBrojnogStanje");

            if (int.Parse(ds.Tables[0].Rows[0][0].ToString()) == 1)
                return true;
            else
                return false;
        }


        public DataSet NEWGetLogoTextForElection(int param)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@param", param);
            pTypes.Add("@param", "int");

            DataSet ds = executeResults("NEWGetLogoTextForElection", pTypes, pVals, "ReportData");
            return ds;
        }



        ////////////////// 04 11 2010 ///////////
        public void WEBRESULTS_GeneratePreliminaryLocal(int userID, int race, string level)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@userID", userID);
            pVals.Add("@race", race);
            pVals.Add("@level", level);

            pTypes.Add("@userID", "int");
            pTypes.Add("@race", "int");
            pTypes.Add("@level", "string");

            executeScalar("WEBRESULTS_GeneratePreliminaryLocal", pTypes, pVals);
        }

        public void WEBRESULTS_GeneratePreliminaryEntry5Local(int userID, int race, string level)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@userID", userID);
            pVals.Add("@race", race);
            pVals.Add("@level", level);

            pTypes.Add("@userID", "int");
            pTypes.Add("@race", "int");
            pTypes.Add("@level", "string");

            executeScalar("WEBRESULTS_GeneratePreliminaryEntry5Local", pTypes, pVals);
        }

        public void GenerateRegStatByCombination( int race)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();
            pVals.Add("@fkrace", race);

            pTypes.Add("@fkrace", "int");

            executeScalar("p3_Insert_RegStatsByCombination", pTypes, pVals);
        }

        public bool p3_If_1_2_AreActive()
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();
            DataSet dsTmp = new DataSet();

            dsTmp = executeResults("p3_If_1_2_AreActive", pTypes, pVals, "BCandidacyRace");
            if (int.Parse(dsTmp.Tables[0].Rows[0][0].ToString()) == 1)
            {
                return true;
            }
            else
                return false;
        }

        public void web_PreliminaryImportByRaceLevelLocal(int race, int param, string level)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@race ", race);
            pVals.Add("@param", param);
            pVals.Add("@level", level);

            pTypes.Add("@race ", "int");
            pTypes.Add("@param", "int");
            pTypes.Add("@level", "nvarchar");

            executeScalar("web_PreliminaryImportByRaceLevelLocal", pTypes, pVals);
        }


        public void web_FinalImportByRaceLevelLocal(int race, int param, string level)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@race ", race);
            pVals.Add("@param", param);
            pVals.Add("@level", level);


            pTypes.Add("@race ", "int");
            pTypes.Add("@param", "int");
            pTypes.Add("@level", "nvarchar");

            executeScalar("web_FinalImportByRaceLevelLocal", pTypes, pVals);
        }


        public void XMLImportFromMEC(string path1)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@path1", path1);

            pTypes.Add("@path1", "nvarchar");

            executeScalar("XMLImportFromMEC", pTypes, pVals);
        }

        public void ImportFromBallotOrder(string Sifra, string RedniBroj)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@sifra", Sifra);
            pVals.Add("@RedniBroj", RedniBroj);


            pTypes.Add("@sifra", "nvarchar");
            pTypes.Add("@RedniBroj", "nvarchar");


            executeScalar("BUpdatePoliticalEntityBallotOrder", pTypes, pVals);
        }


        public DataSet oktomvri_getResurs(int lan, int pageid)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@lan", lan);
            pTypes.Add("@lan", "int");
            pVals.Add("@pageid", pageid);
            pTypes.Add("@pageid", "int");
            DataSet ds = executeResults("oktomvri_getResurs", pTypes, pVals, "ReportData");
            return ds;
        }

        public DataSet p2_GetAllActiveCandidacyRaceForBallots()
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            DataSet dsTmp = executeResults("p2_GetAllActiveCandidacyRaceForBallots", pTypes, pVals, "BCandidatesFinal");
            return dsTmp;
        }

        public DataSet p2_GetAllActiveLevelsForCandidacyRace(int race)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@candidacyRace", race);

            pTypes.Add("@candidacyRace", "int");

            DataSet dsTmp = executeResults("p2_GetAllActiveLevelsForCandidacyRace", pTypes, pVals, "BCandidacyRace");
            return dsTmp;
        }

        public void p2_insertZipPath(string zipPath)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@zipPath", zipPath);

            pTypes.Add("@zipPath", "nvarchar");

            executeScalar("p2_insertZipPath", pTypes, pVals);
        }

        public string p2_getZipPath()
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            object temp = executeScalar("p2_getZipPath", pTypes, pVals);
            return temp as string;
        }

        public DataSet p2_getCandidatesMayor(int race, int level)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@race", race);
            pVals.Add("@level", level);

            pTypes.Add("@race", "int");
            pTypes.Add("@level", "int");

            DataSet dsTmp = executeResults("p2_getCandidatesMayor", pTypes, pVals, "BCandidatesFinal");
            return dsTmp;
        }

        public DataSet p2_checkNacManjine(int level)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@level", level);

            pTypes.Add("@level", "int");

            DataSet dsTmp = executeResults("p2_checkNacManjine", pTypes, pVals, "BFinalCandidatesLists");
            return dsTmp;
        }
       
        public DataSet BGetAllActiveCandidacyRace()
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();



            DataSet dsTmp = executeResults("BGetAllActiveCandidacyRace", pTypes, pVals, "BCandidacyRace");
            return dsTmp;
        }
        public string BBackupPrefinal(int id, string jmb, int UserChangedID)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@id", id);
            pTypes.Add("@id", "int");
            pVals.Add("@jmb", jmb);
            pTypes.Add("@jmb", "nvarchar");
            pVals.Add("@UserChangedID", UserChangedID);
            pTypes.Add("@UserChangedID", "int");

            object temp  = executeScalar("BBackupPrefinal", pTypes, pVals);
            return temp as string;
        }

        public string updateUserPassword(int userId, string password)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@userId", userId);
            pTypes.Add("@userId", "int");
            pVals.Add("@password", password);
            pTypes.Add("@password", "nvarchar");

            object temp = executeScalar("updateUserPassword", pTypes, pVals);
            return temp as string;
        }

        public int? updateUserNeedResetn(int userId, short resetState)
        {

            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@userId", userId);
            pTypes.Add("@userId", "int");
            pVals.Add("@needReset", resetState);
            pTypes.Add("@needReset", "bit");

            object temp = executeScalar("updateUserNeedReset", pTypes, pVals);
            return temp as int?;
        }

        public string updateUserNeedReset(int userId, short resetState)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@userId", userId);
            pTypes.Add("@userId", "int");
            pVals.Add("@resetState", resetState);
            pTypes.Add("@resetState", "bit");

            object temp = executeScalar("updateUserNeedReset", pTypes, pVals);
            return temp as string;
        }
        public string P3_copyentry1toentry2(int levelCode, int raceID,string PS, int userID)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@levelcodePar", levelCode);
            pTypes.Add("@levelcodePar", "int");
            pVals.Add("@race", raceID);
            pTypes.Add("@race", "int");
            pVals.Add("@PS", PS);
            pTypes.Add("@PS", "nvarchar(max)");
            pVals.Add("@FKUserPar", userID);
            pTypes.Add("@FKUserPar", "int");


            object temp = executeScalar("P3_copyentry1toentry2", pTypes, pVals);
            return temp as string;
        }
        public string P3_repeatCounting(int raceID, int levelCode, string PS, string decicion, int userID)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@race", raceID);
            pTypes.Add("@race", "int");
            pVals.Add("@levelcodePar", levelCode);
            pTypes.Add("@levelcodePar", "int");
            pVals.Add("@PS", PS);
            pTypes.Add("@PS", "nvarchar");
            pVals.Add("@decicion", decicion);
            pTypes.Add("@decicion", "nvarchar");
            pVals.Add("@FKUserPar", userID);
            pTypes.Add("@FKUserPar", "int");


            object temp = executeScalar("P3_repeatCounting", pTypes, pVals);
            return temp as string;
        }
        public DataSet BGetBallotLogs()
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            DataSet dsTmp = new DataSet();
            dsTmp = executeResults("BGetBallotLogs", pTypes, pVals, "BallotLogs");
            return dsTmp;
        }
        public void BDeleteBallotLogs()
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();
            executeScalar("BDeleteBallotLogs", pTypes, pVals);
        }

        //Kenan 10.2.2016

        public void p3_UpdatePoolingStationDocumentData(string psCode, string documentName)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@PSCode", psCode);
            pVals.Add("@documentName", documentName);

            pTypes.Add("@PSCode", "nvarchar");
            pTypes.Add("@documentName", "nvarchar");

            executeScalar("p3_UpdatePoolingStationDocumentData", pTypes, pVals);
        }

        public DataSet p3CCResultsEntryMunicipality()
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            var p = executeResults("p3CCResultsEntryMunicipality", pTypes, pVals, "p3_PollingStation");
            return p;
            //return "";
        }

        public DataSet p3CCResultsEntryMunicipalityFilter(string value)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@filterString", value);
            pTypes.Add("@filterString", "nvarchar");
            var p = executeResults("p3CCResultsEntryMunicipalityFilter", pTypes, pVals, "p3_PollingStation");
            return p;
            //return "";
        }

        public DataSet p3GetHighestCodeFromAccreditationMain(int value)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@IDType", value);
            pTypes.Add("@IDType", "integer");
            var p = executeResults("p0_GetHighestCodeFromAccreditationMain", pTypes, pVals, "AccMain");
            return p;
        }

        public DataSet p0_GetDataForObserversFromVoter(string value)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@jmbg", value);
            pTypes.Add("@jmbg", "nvarchar");
            var p = executeResults("p0_GetDataForObserversFromVoter", pTypes, pVals, "Voter");
            return p;
        }

        public DataSet MunicipalityFilter(string value)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@filterString", value);
            pTypes.Add("@filterString", "nvarchar");
            var p = executeResults("MunicipalityFilter", pTypes, pVals, "p3_Municipalities");
            return p;
        }

        public DataSet GetPoolingStationData(string psCode)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@psCode", psCode);
            pTypes.Add("@psCode", "nvarchar");

            var p = executeResults("p3_GetPoolingStationData", pTypes, pVals, "p3_Municipalities");
            return p;            
        }

        public string p3_UpdatePoolingStationData(string psCode, int total, int notValid)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@PSCode", psCode);
            pTypes.Add("@PSCode", "nvarchar");
            pVals.Add("@total", total);
            pTypes.Add("@total", "int");
            pVals.Add("@notValid", notValid);
            pTypes.Add("@notValid", "int");


            object temp = executeScalar("p3_UpdatePoolingStationData", pTypes, pVals);
            return temp as string;
        }

        public DataSet BGetAllActiveCandidacyRaceForMand(string election)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();
            pVals.Add("@election", election);
            pTypes.Add("@election", "string");
            DataSet dsTmp = new DataSet();
            dsTmp = executeResults("p4_BGetAllActiveCandidacyRaceForMandates", pTypes, pVals, "BCandidacyRace");
            return dsTmp;
        }

        public object ManualAllocation(int id, string ElectionCode, int param, int user)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@id", id);
            pVals.Add("@ElectionCode", ElectionCode);
            pVals.Add("@param", param);
            pVals.Add("@user", user);

            pTypes.Add("@id", "int");
            pTypes.Add("@ElectionCode", "varchar(10)");
            pTypes.Add("@param", "int");
            pTypes.Add("@user", "int");


            //DataSet result = new DataSet();
            object result = new object();
            result = executeScalar("p4_UpdateManualAllocation", pTypes, pVals);
            return result;

        }

        public DataSet p4ps_getCandidateFromMandates(string codeE, string jmb, string codeP, string codeL)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@codeE", codeE);
            pVals.Add("@jmb", jmb);
            pVals.Add("@codeP", codeP);
            pVals.Add("@codeL", codeL);

            pTypes.Add("@codeE", "varchar");
            pTypes.Add("@jmb", "varchar");
            pTypes.Add("@codeP", "varchar");
            pTypes.Add("@codeL", "varchar");

            DataSet ds = executeResults("p4ps_getCandidateFromMandates", pTypes, pVals, "p4ps_getCandidateFromMandates");
            return ds;
        }

        public DataSet getNextCCMandateByJMBG(string jmbg, string ElectionCode, int ListCode, string ListName, string LevelCode, string LevelName, string MunCode, string MunName)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();
            pVals.Add("@jmbg", jmbg);
            pVals.Add("@ElectionCode", ElectionCode);
            pVals.Add("@ListCode", ListCode);
            pVals.Add("@LevelCode", LevelCode);
            pVals.Add("@LevelName", LevelName);
            pVals.Add("@MunCode", MunCode);
            pVals.Add("@ListName", ListName);
            pVals.Add("@MunName", MunName);

            pTypes.Add("@jmbg", "varchar(13)");
            pTypes.Add("@ElectionCode", "varchar(10)");

            pTypes.Add("@ListCode", "int");
            pTypes.Add("@ListName", "nvarchar(max)");
            pTypes.Add("@LevelCode", "varchar(3)");
            pTypes.Add("@LevelName", "nvarchar(max)");
            pTypes.Add("@MunCode", "varchar(3)");
            pTypes.Add("@MunName", "varchar(max)");
            DataSet dsTmp = new DataSet();
            dsTmp = executeResults("p4_getNextCCMandateByJMBG", pTypes, pVals, "p4_CityCouncilLists");
            return dsTmp;
        }


        public DataSet p3_getValidationItemsForPSOIK(int race, string pscode)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();
            pVals.Add("@race", race);
            pVals.Add("@pscode", pscode);

            pTypes.Add("@race", "int");
            pTypes.Add("@pscode", "nvarchar");
            DataSet dsTmp = new DataSet();
            dsTmp = executeResults("p3_getValidationItemsForPSOIK", pTypes, pVals, "ValidationItems");
            return dsTmp;
        }

        public DataSet p4_getCandDetails(string jmbg, string ElectionCode, string LevelCode, string MunCode)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();
            pVals.Add("@ElectionCode", ElectionCode);
            pVals.Add("@LevelCode", LevelCode);
            pVals.Add("@MunCode", MunCode);
            pVals.Add("@jmbg", jmbg);

            pTypes.Add("@ElectionCode", "varchar");
            pTypes.Add("@LevelCode", "varchar");
            pTypes.Add("@MunCode", "varchar");
            pTypes.Add("@jmbg", "varchar");
            DataSet dsTmp = new DataSet();
            dsTmp = executeResults("p4_getTableCCMandatesDetails", pTypes, pVals, "p4_CityCouncilCandidates");
            return dsTmp;
        }

        public DataSet p4_getCandDetailsRegular(string jmbg, string ElectionCode, string LevelCode)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();
            pVals.Add("@ElectionCode", ElectionCode);
            pVals.Add("@LevelCode", LevelCode);

            pVals.Add("@jmbg", jmbg);

            pTypes.Add("@ElectionCode", "varchar");
            pTypes.Add("@LevelCode", "varchar");

            pTypes.Add("@jmbg", "varchar");
            DataSet dsTmp = new DataSet();
            dsTmp = executeResults("[Phase4].[MandatesImplementationGetDetails]", pTypes, pVals, "p4_MandatesImplementation");
            return dsTmp;
        }

        public DataSet SelectAllFromCCListsForID(int id, int param)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();
            pVals.Add("@CRID", id);
            pVals.Add("@param", param);

            pTypes.Add("@CRID", "int");
            pTypes.Add("@param", "int");
            DataSet dsTmp = new DataSet();
            dsTmp = executeResults("p4_getAllFromCCLists", pTypes, pVals, "p4_CityCouncilLists");
            return dsTmp;
        }


        public DataSet p4_BGetMunicipalityRegionForMandates(string election, string race)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@election", election); ;
            pTypes.Add("@election", "string");

            pVals.Add("@race", race); ;
            pTypes.Add("@race", "string");


            DataSet dsTmp = new DataSet();
            dsTmp = executeResults("p4_BGetMunicipalityRegionForMandates", pTypes, pVals, "BMunicipalityRegion");
            return dsTmp;
        }

        public object InsertintoCityCouncilLists(string ElectionCode, string LevelCode, string MunCode, string ListName, int? Nationality)
        {


            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            if (Nationality == null)
            {
                pVals.Add("@Nationality", DBNull.Value);
            }
            else
                pVals.Add("@Nationality", Nationality);

            if (MunCode == null)
            {
                pVals.Add("@MunCode", DBNull.Value);
            }
            else
                pVals.Add("@MunCode", MunCode);

            pVals.Add("@ElectionCode", ElectionCode);
            pVals.Add("@LevelCode", LevelCode);
            pVals.Add("@ListName", ListName);



            pTypes.Add("@ElectionCode", "varchar(10)");
            pTypes.Add("@LevelCode", "varchar(3)");
            pTypes.Add("@MunCode", "varchar(3)");
            pTypes.Add("@ListName", "nvarchar(max)");
            pTypes.Add("@Nationality", "int");

            //DataSet result = new DataSet();
            object result = new object();
            result = executeScalar("p4_InsertintoCityCouncilLists", pTypes, pVals);
            return result;

        }
        public object InsertintoRepeatCount(string decision, string level, string bm, int race, int reason)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@DecisionID", decision);
            pVals.Add("@LevelCode", level);
            pVals.Add("@PSCode", bm);
            pVals.Add("@FKRace", race);
            pVals.Add("@Reason", reason);

            pTypes.Add("@DecisionID", "varchar(20)");
            pTypes.Add("@LevelCode", "varchar(3)");
            pTypes.Add("@PSCode", "varchar(7)");
            pTypes.Add("@FKRace", "int");
            pTypes.Add("@Reason", "int");

            //DataSet result = new DataSet();
            object result = new object();
            result = executeScalar("p3_InsertIntoRepeatCount", pTypes, pVals);
            return result;

        }


        public object InsertintoCityCouncilCandidates(string jmbg, int id, int listposition, string ElectionCode, bool isEnd, bool isReplaced, bool isWait, DateTime DateStart, DateTime DateEnd)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@jmbg", jmbg);
            pVals.Add("@id", id);
            pVals.Add("@ListPosition", listposition);
            pVals.Add("@ElectionCode", ElectionCode);
            pVals.Add("@isEnd", isEnd);
            pVals.Add("@isReplaced", isReplaced);
            pVals.Add("@isWait", isWait);
            pVals.Add("@DateStart", DateStart);
            pVals.Add("@DateEnd", DateEnd);

            pTypes.Add("@jmbg", "char(13)");
            pTypes.Add("@id", "int");
            pTypes.Add("@ListPosition", "int");
            pTypes.Add("@ElectionCode", "varchar(10)");
            pTypes.Add("@isEnd", "bit");
            pTypes.Add("@isReplaced", "bit");
            pTypes.Add("@isWait", "bit");
            pTypes.Add("@DateStart", "datetime");
            pTypes.Add("@DateEnd", "datetime");

            //DataSet result = new DataSet();
            object result = new object();
            result = executeScalar("p4_InsertintoCityCouncilCandidates", pTypes, pVals);
            return result;

        }


        public void DeleteCand(int id)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@id", id);
            pTypes.Add("@id", "int");

            executeScalar("p4_DeleteCCCandidate", pTypes, pVals);
        }

        public void DeleteList(int id)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@id", id);
            pTypes.Add("@id", "int");

            executeScalar("p4_DeleteCCList", pTypes, pVals);
        }

        public void ProcessList(int id)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@id", id);
            pTypes.Add("@id", "int");

            executeScalar("p4_ProcessList", pTypes, pVals);
        }

        public void FinalizeList(int id)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@id", id);
            pTypes.Add("@id", "int");

            executeScalar("p4_FinalizeList", pTypes, pVals);
        }

        public void LockList(int id)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@id", id);
            pTypes.Add("@id", "int");

            executeScalar("p4_LockList", pTypes, pVals);
        }

        public object UpdateCCMandate(string ElectionCode, string jmbg, bool isEnd, bool isReplaced, bool isWait, DateTime? DateStart, DateTime? DateEnd, string Reason, int RplWith, int RplList, string Remark, string Comment)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            if (DateStart == null)
            {
                pVals.Add("@DateStart", DBNull.Value);
            }
            else
                pVals.Add("@DateStart", DateStart);

            if (DateEnd == null)
            {
                pVals.Add("@DateEnd", DBNull.Value);
            }
            else
                pVals.Add("@DateEnd", DateEnd);

            pVals.Add("@ElectionCode", ElectionCode);
            pVals.Add("@jmbg", jmbg);
            pVals.Add("@isReplaced", isReplaced);
            pVals.Add("@isEnd", isEnd);
            pVals.Add("@isWait", isWait);
           //pVals.Add("@DateStart", DateStart);
            //pVals.Add("@DateEnd", DateEnd);
            pVals.Add("@ReasonID", Reason);
            pVals.Add("@RplWith", RplWith);
            pVals.Add("@RplListID", RplList);
            pVals.Add("@RemarkID", Remark);
            pVals.Add("@Comment", Comment);


            pTypes.Add("@ElectionCode", "varchar(10)");
            pTypes.Add("@jmbg", "varchar(13)");
            pTypes.Add("@isReplaced", "bit");
            pTypes.Add("@isEnd", "bit");
            pTypes.Add("@isWait", "bit");
            pTypes.Add("@DateStart", "datetime");
            pTypes.Add("@DateEnd", "datetime");
            pTypes.Add("@ReasonID", "varchar");
            pTypes.Add("@RplWith", "int");
            pTypes.Add("@RplListID", "int");
            pTypes.Add("@RemarkID", "varchar");
            pTypes.Add("@Comment", "nvarchar(max)");
            //DataSet result = new DataSet();
            object result = new object();
            result = executeScalar("p4_UpdateCCMandate", pTypes, pVals);
            return result;

        }


        public object InsertintoVNRSCandidates(string jmbg, int id, int listposition, string ElectionCode, string LevelCode, bool isEnd, bool isReplaced, bool isWait, DateTime DateStart, DateTime DateEnd, int Nat)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@jmbg", jmbg);
            pVals.Add("@id", id);
            pVals.Add("@ListPosition", listposition);
            pVals.Add("@ElectionCode", ElectionCode);
            pVals.Add("@LevelCode", LevelCode);
            pVals.Add("@isEnd", isEnd);
            pVals.Add("@isReplaced", isReplaced);
            pVals.Add("@isWait", isWait);
            pVals.Add("@DateStart", DateStart);
            pVals.Add("@DateEnd", DateEnd);
            pVals.Add("@Nat", Nat);

            pTypes.Add("@jmbg", "char(13)");
            pTypes.Add("@id", "int");
            pTypes.Add("@ListPosition", "int");
            pTypes.Add("@ElectionCode", "varchar(10)");
            pTypes.Add("@LevelCode", "varchar(3)");
            pTypes.Add("@isEnd", "bit");
            pTypes.Add("@isReplaced", "bit");
            pTypes.Add("@isWait", "bit");
            pTypes.Add("@DateStart", "datetime");
            pTypes.Add("@DateEnd", "datetime");
            pTypes.Add("@Nat", "int");

            //DataSet result = new DataSet();
            object result = new object();
            result = executeScalar("p4_InsertintoVNRSCandidates", pTypes, pVals);
            return result;

        }

        public object UpdateLists(string ElectionCode, string LevelCode, string MunCode, int param)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@ElectionCode", ElectionCode);
            pVals.Add("@LevelCode", LevelCode);
            pVals.Add("@MunCode", MunCode);
            pVals.Add("@param", param);


            pTypes.Add("@ElectionCode", "varchar(10)");
            pTypes.Add("@LevelCode", "varchar(3)");
            pTypes.Add("@MunCode", "varchar(3)");
            pTypes.Add("@param", "int");

            //DataSet result = new DataSet();
            object result = new object();
            result = executeScalar("p4_UpdateLists", pTypes, pVals);
            return result;

        }

        public object GenerateMandateCC(string ElectionCode, string LevelCode)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@ElectionCode", ElectionCode);
            pVals.Add("@level", LevelCode);

            pTypes.Add("@ElectionCode", "nchar(10)");
            pTypes.Add("@level", "nchar(3)");

            //DataSet result = new DataSet();
            object result = new object();
            result = executeScalar("p4_AllocationCoeficient", pTypes, pVals);
            return result;

        }

        public object UpdateCityCouncilLists(int id, string ListName)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@id", id);
            pVals.Add("@ListName", ListName);


            pTypes.Add("@id", "int");
            pTypes.Add("@ListName", "nvarchar(50)");

            //DataSet result = new DataSet();
            object result = new object();
            result = executeScalar("p4_UpdateCityCouncilLists", pTypes, pVals);
            return result;

        }

        public DataSet getActiveElection(int id)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();
            pVals.Add("@electionResultId", id);
            pTypes.Add("@electionResultId", "int");
            DataSet dsTmp = new DataSet();
            dsTmp = executeResults("[Administration].[GetElectionWebResultForID]", pTypes, pVals, "ElectionResultId");
            return dsTmp;
        }

        public void UpdateElectionWebResult(int electionResultId, string nameLatin, string nameCyrillic, string radioButtonIsActive, string radioButtonIsFinalResult, string radioButtonShowDetailedResults, string messageBS, string messageSR, string messageHR, string messageEN)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@electionResultId", electionResultId);
            pVals.Add("@nameLatin", nameLatin);
            pVals.Add("@nameCyrillic", nameCyrillic);
            pVals.Add("@isFinalResult", radioButtonIsFinalResult);
            pVals.Add("@active", radioButtonIsActive);
            pVals.Add("@showDetailedResults", radioButtonShowDetailedResults);
            pVals.Add("@messageBS", messageBS);
            pVals.Add("@messageSR", messageSR);
            pVals.Add("@messageHR", messageHR);
            pVals.Add("@messageEN", messageEN);

            pTypes.Add("@electionResultId", "int");
            pTypes.Add("@nameLatin", "nvarchar");
            pTypes.Add("@nameCyrillic", "nvarchar");
            pTypes.Add("@isFinalResult", "bit");
            pTypes.Add("@active", "bit");
            pTypes.Add("@showDetailedResults", "bit");
            pTypes.Add("@messageBS", "nvarchar");
            pTypes.Add("@messageSR", "nvarchar");
            pTypes.Add("@messageHR", "nvarchar");
            pTypes.Add("@messageEN", "nvarchar");


            executeScalar("[Administration].[UpdateElectionResult]", pTypes, pVals);
        }

        public void AddElection(string code, string nameLatinic, string nameCirilic, DateTime dateElection, string radioButtonIsActive)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@code", code);
            pVals.Add("@nameLatin", nameLatinic);
            pVals.Add("@nameCyrillic", nameCirilic);
            pVals.Add("@dateElection", dateElection);
            pVals.Add("@active", radioButtonIsActive);

            pTypes.Add("@code", "nchar");
            pTypes.Add("@nameLatin", "nvarchar");
            pTypes.Add("@nameCyrillic", "nvarchar");
            pTypes.Add("@dateElection", "datetime");
            pTypes.Add("@active", "bit");

            executeScalar("[Administration].[InsertElection]", pTypes, pVals);
        }


        public void AddRace(string dbName, string raceCode, string nameLatinic, string nameCirilic)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@dbName", dbName);
            pVals.Add("@raceCode", raceCode);
            pVals.Add("@nameLatin", nameLatinic);
            pVals.Add("@nameCyrillic", nameCirilic);

            pTypes.Add("@dbName", "nvarchar");
            pTypes.Add("@raceCode", "nchar");
            pTypes.Add("@nameLatin", "nvarchar");
            pTypes.Add("@nameCyrillic", "nvarchar");

            executeScalar("[Administration].[InsertRace]", pTypes, pVals);
        }

        public string AddElectionResult(string electionCode, string nameLatinic, string nameCirilic, string radioButtonIsActive, string radioButtonIsFinalResult, string radioButtonShowDetailedResults, string messageBS, string messageSR, string messageHR, string messageEN)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@electionCode", electionCode);
            pVals.Add("@nameLatin", nameLatinic);
            pVals.Add("@nameCyrillic", nameCirilic);
            pVals.Add("@isFinalResult", radioButtonIsFinalResult);
            pVals.Add("@active", radioButtonIsActive);
            pVals.Add("@showDetailedResults", radioButtonShowDetailedResults);
            pVals.Add("@messageBS", messageBS);
            pVals.Add("@messageSR", messageSR);
            pVals.Add("@messageHR", messageHR);
            pVals.Add("@messageEN", messageEN);

            pTypes.Add("@electionCode", "nvarchar");
            pTypes.Add("@nameLatin", "nvarchar");
            pTypes.Add("@nameCyrillic", "nvarchar");
            pTypes.Add("@isFinalResult", "bit");
            pTypes.Add("@active", "bit");
            pTypes.Add("@showDetailedResults", "bit");
            pTypes.Add("@messageBS", "nvarchar");
            pTypes.Add("@messageSR", "nvarchar");
            pTypes.Add("@messageHR", "nvarchar");
            pTypes.Add("@messageEN", "nvarchar");

            object obj = executeScalar("[Administration].[InsertElectionResult]", pTypes, pVals);

            return Convert.ToString(obj);
        }

        public void DeleteElectionResult(int id)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@electionResultId", id);
            pTypes.Add("@electionResultId", "int");
            executeScalar("[Administration].[DeleteElectionResult]", pTypes, pVals);
        }
        public void CreateWebDatabase(string dbName, string raceList)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@DBName", dbName);
            pTypes.Add("@DBName", "nvarchar");
            pVals.Add("@RaceList", raceList);
            pTypes.Add("@RaceList", "nvarchar");

            executeScalar("[Administration].[CreateWebDatabase]", pTypes, pVals);
        }

        public int RunJob(int raceId, bool webFlag)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@race", raceId);
            pTypes.Add("@race", "int");

            pVals.Add("@webFlag", webFlag);
            pTypes.Add("@webFlag", "bit");

            object obj = executeScalar("[dbo].[RunJob]", pTypes, pVals);

            return Convert.ToInt32(obj);
        }

        //06062020 BMComplaints 
        public string InsertComplaint(
            int ElectionId, 
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
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@ElectionId", ElectionId);
            pVals.Add("@MunicipalitiesId", MunicipalitiesId);
            pVals.Add("@Creator", Creator);
            pVals.Add("@Owner", Owner);
            pVals.Add("@ActId", ActId);
            pVals.Add("@ProtocolNumber", ProtocolNumber);
            pVals.Add("@SubmiterId", SubmiterId);
            pVals.Add("@SubmiterName", SubmiterName);
            pVals.Add("@Fax", Fax);
            pVals.Add("@Email", Email);
            pVals.Add("@SubmitedById", SubmitedById);
            pVals.Add("@SubmitedDate", SubmitedDate);
            //pVals.Add("@EventDate", EventDate);
            if (EventDate == null)
                pVals.Add("@EventDate", DBNull.Value);
            else
                pVals.Add("@EventDate", EventDate);
            pVals.Add("@EventPlace", EventPlace);
            pVals.Add("@EventSubject", EventSubject);
            pVals.Add("@CathegoryId", CathegoryId);
            pVals.Add("@EventDesc", EventDesc);
            pVals.Add("@EventIZ", EventIZ);
            pVals.Add("@EventAttach", EventAttach);
            pVals.Add("@SigniturePlace", SigniturePlace);
            pVals.Add("@SignitureDate", SignitureDate);
            pVals.Add("@SubjectAcceptedBy", SubjectAcceptedBy);

            if (ResoultionNumber == null)
                pVals.Add("@ResoultionNumber", DBNull.Value);
            else
                pVals.Add("@ResoultionNumber", ResoultionNumber);
            //pVals.Add("@ResoultionNumber", ResoultionNumber);
            if (ResolutionDate == null)
                pVals.Add("@ResolutionDate", DBNull.Value);
            else
                pVals.Add("@ResolutionDate", ResolutionDate);
            //pVals.Add("@ResolutionDate", ResolutionDate);
            if (ResolutionContent == null)
                pVals.Add("@ResolutionContent", DBNull.Value);
            else
                pVals.Add("@ResolutionContent", ResolutionContent);
            //pVals.Add("@ResolutionContent", ResolutionContent);


            if (ComplaintDate == null)
                pVals.Add("@ComplaintDate", DBNull.Value);
            else
               pVals.Add("@ComplaintDate", ComplaintDate);


            if (ComplaintContent == null)
                pVals.Add("@ComplaintContent", DBNull.Value);
            else
                pVals.Add("@ComplaintContent", ComplaintContent);
            //pVals.Add("@ComplaintContent", ComplaintContent);



            pVals.Add("@ActState", ActState);
            pVals.Add("@UserId", UserId);
            pVals.Add("@ActDelgated", ActDelgated);
            pVals.Add("@isArchived", isArchived);

            pTypes.Add("@ElectionId", "int");
            pTypes.Add("@MunicipalitiesId", "int");
            pTypes.Add("@Creator", "char");
            pTypes.Add("@Owner", "char");
            pTypes.Add("@ActId", "int");
            pTypes.Add("@ProtocolNumber", "varchar");
            pTypes.Add("@SubmiterId", "int");
            pTypes.Add("@SubmiterName", "nvarchar");
            pTypes.Add("@Fax", "nvarchar");
            pTypes.Add("@Email", "nvarchar");
            pTypes.Add("@SubmitedById", "int");
            pTypes.Add("@SubmitedDate", "datetime");
            pTypes.Add("@EventDate", "datetime");
            pTypes.Add("@EventPlace", "nvarchar");
            pTypes.Add("@EventSubject", "nvarchar");
            pTypes.Add("@CathegoryId", "int");
            pTypes.Add("@EventDesc", "nvarchar");
            pTypes.Add("@EventIZ", "nvarchar");
            pTypes.Add("@EventAttach", "nvarchar");
            pTypes.Add("@SigniturePlace", "nvarchar");
            pTypes.Add("@SignitureDate", "datetime");
            pTypes.Add("@SubjectAcceptedBy", "nvarchar");
            pTypes.Add("@ResoultionNumber", "nvarchar");
            pTypes.Add("@ResolutionDate", "datetime");
            pTypes.Add("@ResolutionContent", "nvarchar");
            pTypes.Add("@ComplaintDate", "datetime");
            pTypes.Add("@ComplaintContent", "nvarchar");
            pTypes.Add("@ActState", "int");
            pTypes.Add("@UserId", "int");
            pTypes.Add("@ActDelgated", "int");
            pTypes.Add("@isArchived", "bit");

            object obj = executeScalar("[Complaints].[InsertComplaint]", pTypes, pVals);

            return Convert.ToString(obj);
        }

        public string EditComplaint(
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
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@Id", Id);
            pVals.Add("@ElectionId", ElectionId);
            pVals.Add("@MunicipalitiesId", MunicipalitiesId);
            pVals.Add("@Owner", Owner);
            pVals.Add("@ActId", ActId);
            pVals.Add("@ProtocolNumber", ProtocolNumber);
            pVals.Add("@SubmiterId", SubmiterId);
            pVals.Add("@SubmiterName", SubmiterName);
            pVals.Add("@Fax", Fax);
            pVals.Add("@Email", Email);
            pVals.Add("@SubmitedById", SubmitedById);
            pVals.Add("@SubmitedDate", SubmitedDate);
            //pVals.Add("@EventDate", EventDate);
            if (EventDate == null)
                pVals.Add("@EventDate", DBNull.Value);
            else
                pVals.Add("@EventDate", EventDate);
            pVals.Add("@EventPlace", EventPlace);
            pVals.Add("@EventSubject", EventSubject);
            pVals.Add("@CathegoryId", CathegoryId);
            pVals.Add("@EventDesc", EventDesc);
            pVals.Add("@EventIZ", EventIZ);
            pVals.Add("@EventAttach", EventAttach);
            pVals.Add("@SigniturePlace", SigniturePlace);
            pVals.Add("@SignitureDate", SignitureDate);
            pVals.Add("@SubjectAcceptedBy", SubjectAcceptedBy);

            if (ResoultionNumber == null)
                pVals.Add("@ResoultionNumber", DBNull.Value);
            else
                pVals.Add("@ResoultionNumber", ResoultionNumber);
            //pVals.Add("@ResoultionNumber", ResoultionNumber);
            if (ResolutionDate == null)
                pVals.Add("@ResolutionDate", DBNull.Value);
            else
                pVals.Add("@ResolutionDate", ResolutionDate);
            //pVals.Add("@ResolutionDate", ResolutionDate);
            if (ResolutionContent == null)
                pVals.Add("@ResolutionContent", DBNull.Value);
            else
                pVals.Add("@ResolutionContent", ResolutionContent);
            //pVals.Add("@ResolutionContent", ResolutionContent);


            if (ComplaintDate == null)
                pVals.Add("@ComplaintDate", DBNull.Value);
            else
                pVals.Add("@ComplaintDate", ComplaintDate);


            if (ComplaintContent == null)
                pVals.Add("@ComplaintContent", DBNull.Value);
            else
                pVals.Add("@ComplaintContent", ComplaintContent);
            //pVals.Add("@ComplaintContent", ComplaintContent);



            pVals.Add("@ActState", ActState);
            pVals.Add("@UserId", UserId);
            pVals.Add("@ActDelgated", ActDelgated);
            pVals.Add("@isArchived", isArchived);

            pTypes.Add("@Id", "int");
            pTypes.Add("@ElectionId", "int");
            pTypes.Add("@MunicipalitiesId", "int");
            pTypes.Add("@Owner", "char");
            pTypes.Add("@ActId", "int");
            pTypes.Add("@ProtocolNumber", "varchar");
            pTypes.Add("@SubmiterId", "int");
            pTypes.Add("@SubmiterName", "nvarchar");
            pTypes.Add("@Fax", "nvarchar");
            pTypes.Add("@Email", "nvarchar");
            pTypes.Add("@SubmitedById", "int");
            pTypes.Add("@SubmitedDate", "datetime");
            pTypes.Add("@EventDate", "datetime");
            pTypes.Add("@EventPlace", "nvarchar");
            pTypes.Add("@EventSubject", "nvarchar");
            pTypes.Add("@CathegoryId", "int");
            pTypes.Add("@EventDesc", "nvarchar");
            pTypes.Add("@EventIZ", "nvarchar");
            pTypes.Add("@EventAttach", "nvarchar");
            pTypes.Add("@SigniturePlace", "nvarchar");
            pTypes.Add("@SignitureDate", "datetime");
            pTypes.Add("@SubjectAcceptedBy", "nvarchar");
            pTypes.Add("@ResoultionNumber", "nvarchar");
            pTypes.Add("@ResolutionDate", "datetime");
            pTypes.Add("@ResolutionContent", "nvarchar");
            pTypes.Add("@ComplaintDate", "datetime");
            pTypes.Add("@ComplaintContent", "nvarchar");
            pTypes.Add("@ActState", "int");
            pTypes.Add("@UserId", "int");
            pTypes.Add("@ActDelgated", "int");
            pTypes.Add("@isArchived", "bit");

            object obj = executeScalar("[Complaints].[UpdateComplaint]", pTypes, pVals);

            return Convert.ToString(obj);
        }




        public DataSet getActiveElections()
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            DataSet dsTmp = new DataSet();
            dsTmp = executeResults("[GlobalCode].[ElectionGetActiveElection]", pTypes, pVals, "[GlobalCode].[Election]");
            return dsTmp;
        }

        public DataSet GetMunicipalityIdByCode(string munCode)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@munCode", munCode);
            pTypes.Add("@munCode", "nvarchar");

            DataSet dsTmp = new DataSet();
            dsTmp = executeResults("[GlobalCode].[GetMunicipalityIdByCode]", pTypes, pVals, "[GlobalCode].[Municipalities]");
            return dsTmp;
        }

        public DataSet getDashboard()
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();
            DataSet dsTmp = new DataSet();
            dsTmp = executeResults("[dbo].[p3_getDashboard]", pTypes, pVals, "Voter");
            return dsTmp;
        }

        public void p3_InsertEmptyBagsInto_P3Bags_Covid(string PSCode)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@PSCode", PSCode);

            pTypes.Add("@PSCode", "nvarchar");

            executeScalar("p3_InsertEmptyBagsInto_P3Bags_Covid", pTypes, pVals);
        }

        public DataSet p3_InsertIntoVotesCastCovid(string jmb, int clerk, string psBag, string firstName, string lastName, string birthDate, string potpis, bool suspicious)
        {
            Dictionary<string, object> pVals = new Dictionary<string, object>();
            Dictionary<string, string> pTypes = new Dictionary<string, string>();

            pVals.Add("@jmb", jmb);
            pVals.Add("@clerk", clerk);
            pVals.Add("@psBag", psBag);
            pVals.Add("@firstName", firstName);
            pVals.Add("@lastName", lastName);
            pVals.Add("@birthDate", birthDate);
            pVals.Add("@potpis", potpis);
            pVals.Add("@suspicious", suspicious);

            pTypes.Add("@jmb", "nvarchar");
            pTypes.Add("@clerk", "int");
            pTypes.Add("@psBag", "nvarchar");
            pTypes.Add("@firstName", "nvarchar");
            pTypes.Add("@lastName", "nvarchar");
            pTypes.Add("@birthDate", "nvarchar");
            pTypes.Add("@potpis", "nvarchar");
            pTypes.Add("@suspicious", "BIT");
            // pTypes.Add("@document", "nvarchar");

            DataSet ds = executeResults("p3_InsertIntoVotesCastCovid", pTypes, pVals, "p3_VotesCast");
            return ds;
        }


    }
}
