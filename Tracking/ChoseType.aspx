<%@ Page Language="C#" MasterPageFile="~/masterpage.Master" AutoEventWireup="true"
    CodeBehind="ChoseType.aspx.cs" Inherits="JIIS.Web.Phase3.Tracking.ChoseType" Title="<%$Resources:LanguageText, tr_bagReceive%>"
    Theme="Default" %>

<%@ Import Namespace="Resources" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContent" runat="server">
    <div id="PageTitle">
        <%=LanguageText.tr_bagReceive%><hr style="border-width: 0px; background-color: #718ca5;"
            noshade="noshade" />
    </div>
    <div id="MainBody">
        <div style="height: 3px;">
        </div>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <div id="Div2">
                    <div class="box">
                        <table cellpadding="0" cellspacing="0" border="0" width="100%">
                            <tr>
                                <td style="text-align: left">
                                    <asp:Button ID="Button5" runat="server" CssClass="button100" Text="<%$Resources:LanguageText, bback%>"
                                        CausesValidation="False" OnClick="btnCancel_Click" />
                                </td>
                                <td style="text-align: right">
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
                <br />
                <table id="Table1" width="100%">
                    <tr>
                        <td class="left_table_cell">
                            <asp:Label ID="Label8" runat="server" Text="<%$Resources:LanguageText, tr_chooseTypeBag%>"></asp:Label>
                        </td>
                        <td class="right_table_cell">
                            <asp:DropDownList ID="ddlChooseTypeBag" runat="server" Width="50%" DataSourceID="dsPSTypes"
                                DataTextField="PSTypeNameDescription" DataValueField="PSTypeName" AutoPostBack="True"
                                OnDataBound="ddl_DataBound" OnSelectedIndexChanged="ddlChooseTypeBag_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr runat="server" id="brP" visible="false">
                        <td class="left_table_cell">
                            <asp:SqlDataSource ID="dsPSTypes" runat="server" 
                                ConnectionString="<%$ ConnectionStrings:BVOTEConnectionString %>" 
                                SelectCommand="p3_getPSTypes" SelectCommandType="StoredProcedure">
                            </asp:SqlDataSource>
                        </td>
                        <td class="right_table_cell">
                            &nbsp;</td>
                    </tr>
                </table>
                <br />
                <br />
                <div style="padding: 5px 10px 0px 10px; font-weight: bold; font-size: 120%; background-color: #718ca5;
                    height: 25px; vertical-align: middle; text-align: center;">
                  
                </div>
                <br />
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <div style="height: 10px;">
    </div>
    <div class="line">
    </div>
    </asp:Content>
