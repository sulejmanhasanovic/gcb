<%@ Page Language="C#" MasterPageFile="~/masterpage.Master" AutoEventWireup="true"
    CodeBehind="BagsPackaging.aspx.cs" Inherits="JIIS.Web.Phase3.Tracking.BagsPackaging"
    Title="<%$Resources:LanguageText, tr_bagPackage%>" Theme="Default" %>

<%@ Import Namespace="Resources" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContent" runat="server">
    <div id="PageTitle">
        <%=LanguageText.tr_bagPackage%><hr style="border-width: 0px; background-color: #718ca5;"
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
                                OnDataBound="ddl_DataBound">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                ErrorMessage="*" ControlToValidate="ddlChooseTypeBag"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="left_table_cell">
                            <asp:Label ID="Label1" runat="server" Text="<%$Resources:LanguageText, tr_NumberBag%>"></asp:Label>
                        </td>
                        <td class="right_table_cell">
                            <asp:DropDownList ID="ddlBagNumber" runat="server" Width="20%" DataSourceID="SqlDataSource1"
                                DataTextField="PollingStationCode" DataValueField="PollingStationCode" OnDataBound="ddl_DataBound"
                                OnSelectedIndexChanged="ddlPoBox_SelectedIndexChanged" AutoPostBack="True">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlBagNumber" 
                                ErrorMessage="*"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                </table>
                <br />
                <table width="100%">
                    <tr>
                        <td class="left_table_cell">
                            <asp:Label ID="Label3" runat="server" Text="<%$Resources:LanguageText,tr_date%>"></asp:Label>
                        </td>
                        <td class="right_table_cell">
                            <asp:Label ID="lblDate" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="left_table_cell">
                            <asp:Label ID="Label4" runat="server" Text="<%$Resources:LanguageText,tr_receivedEnvelopes%>"></asp:Label>
                        </td>
                        <td class="right_table_cell">
                            <asp:Label ID="lblReceivedVerification" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="left_table_cell">
                            <asp:Label ID="Label5" runat="server" Text="<%$Resources:LanguageText,tr_confEnv%>"></asp:Label>
                        </td>
                        <td class="right_table_cell">
                            <asp:Label ID="lblConfirmed" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="left_table_cell">
                            <asp:Label ID="Label7" runat="server" Text="<%$Resources:LanguageText,tr_denEnv%>"></asp:Label>
                        </td>
                        <td class="right_table_cell">
                            <asp:Label ID="lblDenied" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
                <br />
                <table style="width: 100%">
                    <tr>
                        <td class="left_table_cell" style="width: 250px;">
                            &nbsp;
                        </td>
                        <td class="right_table_cell">
                            <asp:Button ID="btnNext" runat="server" Text="<%$Resources:LanguageText,bNext%>"
                                CssClass="button100" OnClick="btnNext_Click" />
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <div class="line">
    </div>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:BVOTEConnectionString %>"
        SelectCommand="p3_getDataFromBagsPackaging" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:ControlParameter ControlID="ddlChooseTypeBag" Name="PSType" PropertyName="SelectedValue"
                Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="dsPSTypes" runat="server" ConnectionString="<%$ ConnectionStrings:BVOTEConnectionString %>"
        SelectCommand="p3_getPSTypesPackaging" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
</asp:Content>
