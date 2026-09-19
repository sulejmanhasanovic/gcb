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
    public partial class IntakeArea : BasePage
    {
        private int areaid;
        private Users loggedUser = new Users();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["PositionRank"] == null)
                Response.Redirect("~/session.aspx");

            loggedUser = (Users)Session["user"];
            areaid = int.Parse(loggedUser.Supervisor_ID.Remove(0, 1));
            hdnArea.Value = areaid.ToString();

            if (!Page.IsPostBack)
            {
                lblCode.Text = Session["station"].ToString();
                DataSet dsMaterials = Functions.p3_GetStartMaterialsForAreaID(areaid, int.Parse(Session["language"].ToString()));
                DataSet dsTracking = Functions.p3_GetTrackingMaterials(lblCode.Text, int.Parse(Session["language"].ToString()), areaid);
                //DataSet dsMID = Functions.p3_GetMaterialIDFromPSM();
                bool check = false;
                //bool chk = false;

                if (dsMaterials.Tables[0].Rows.Count != 0)
                {
                    foreach (DataRow dr in dsMaterials.Tables[0].Rows)
                    {
                        if (dsTracking.Tables[0].Rows.Count != 0)
                        {
                            foreach (DataRow dr1 in dsTracking.Tables[0].Rows)
                            {
                                if (dr[0].ToString() == dr1[2].ToString())
                                {
                                    check = true;
                                    break;
                                }
                                else
                                {
                                    check = false;
                                    //foreach (DataRow row in dsMID.Tables[0].Rows)
                                    //{
                                    //    if (row[0].ToString() == dr[0].ToString())
                                    //    {
                                    //        chk = true;
                                    //        break;
                                    //    }
                                    //    else
                                    //    {
                                    //        chk = false;
                                    //    }
                                    //}
                                }
                            }
                            if (!check)
                            {
                                Functions.p3_InsertTrackingMaterials(lblCode.Text, Convert.ToInt32(dr[0]), 0, areaid, loggedUser.ID);
                            }
                        }
                        else
                        {
                            //foreach (DataRow row in dsMID.Tables[0].Rows)
                            //{
                            //    if (row[0].ToString() == dr[0].ToString())
                            //    {
                            //        chk = true;
                            //        break;
                            //    }
                            //    else
                            //    {
                            //        chk = false;
                            //    }
                            //}
                            //if (!chk)
                            //{
                                Functions.p3_InsertTrackingMaterials(lblCode.Text, Convert.ToInt32(dr[0]), 0, areaid, loggedUser.ID);
                            //}
                        }
                    }
                }
                dsTracking = Functions.p3_GetTrackingMaterials(lblCode.Text, int.Parse(Session["language"].ToString()), areaid);
                gvTracking.DataSource = dsTracking.Tables[0];
                gvTracking.DataBind();
                //foreach (GridViewRow row in gvTracking.Rows)
                //{
                //    DropDownList ddl = (DropDownList)row.FindControl("ddlSendArea");
                //    //ddl.DataBind();
                //    if (ddl.Items.Count == 0)
                //    {
                //        ddl.Visible = false;
                //    }
                //    else
                //    {
                //        ddl.Visible = true;
                //    }
                //}
            }
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            Response.Redirect("TrackingMaterial.aspx");
        }

        protected void gvTracking_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {                
                DropDownList ddl = (DropDownList)e.Row.FindControl("ddlSendArea");
                //ddl.DataBind();
                //if (ddl.Items.Count == 0)
                //{
                //    ddl.Visible = false;
                //}
                //else
                //{
                //    ddl.Visible = true;
                //}

                Label next = (Label)e.Row.FindControl("lblNextArea");
                Label current = (Label)e.Row.FindControl("lblCurrentArea");
                Label mid = (Label)e.Row.FindControl("lblMID");
                Label quarantine = (Label)e.Row.FindControl("lblQuarantine");
                Label nextArea = (Label)e.Row.FindControl("lblNext");

                //e.Row.Cells[0].Text = name.Text;

                if (Convert.ToInt32(gvTracking.DataKeys[e.Row.RowIndex].Values[1]) == 0)
                {
                    e.Row.Cells[2].Text = "Received from " + current.Text;// + " to " + next.Text;
                    ddl.Enabled = true;
                }
                else
                {
                    DataSet dsNext = Functions.p3_GetNextArea(lblCode.Text, int.Parse(Session["language"].ToString()), Convert.ToInt32(nextArea.Text), Convert.ToInt32(mid.Text));

                    e.Row.Cells[2].Text = "Sent from " + dsNext.Tables[0].Rows[0][2].ToString() + " to " + dsNext.Tables[0].Rows[0][3].ToString();
                    ddl.Enabled = false;
                }

                if (quarantine.Text == "True")
                {
                    e.Row.Enabled = false;
                }
                else
                {
                    e.Row.Enabled = true;
                }

                DataSet ds = Functions.p3_GetAreasToForArea(areaid, Convert.ToInt32(mid.Text), Convert.ToInt32(Session["language"]));
                ddl.DataSource = ds.Tables[0];
                ddl.DataBind();
                if (ddl.Items.Count == 0)
                {
                    ddl.Visible = false;
                }
                else
                {
                    ddl.Visible = true;
                }
            }
            if (e.Row.RowType == DataControlRowType.EmptyDataRow)
            {

            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow dr in gvTracking.Rows)
            {
                DropDownList ddl = (DropDownList)dr.FindControl("ddlSendArea");
                if (ddl.Items.Count != 0 && ddl.Enabled == true)
                {
                    Label mid = (Label)dr.FindControl("lblMID");
                    int i = Convert.ToInt32(gvTracking.DataKeys[dr.RowIndex].Values[0].ToString());
                    int j = Convert.ToInt32(mid.Text);
                    Functions.p3_UpdateTrackingMaterials(i, lblCode.Text, j, areaid, Convert.ToInt32(ddl.SelectedValue), loggedUser.ID);
                }
            }
            DataSet dsTracking = Functions.p3_GetTrackingMaterials(lblCode.Text, int.Parse(Session["language"].ToString()), areaid);
            gvTracking.DataSource = dsTracking.Tables[0];
            gvTracking.DataBind();
        }
    }
}
