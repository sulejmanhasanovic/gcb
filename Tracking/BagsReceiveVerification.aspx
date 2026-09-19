<%@ Page Language="C#" MasterPageFile="~/masterpage.Master" AutoEventWireup="true"
    CodeBehind="BagsReceiveVerification.aspx.cs" Inherits="JIIS.Web.Phase3.Tracking.BagsReceiveVerification"
    Title="<%$Resources:LanguageText, tr_bagReceiveVerification%>" Theme="Default" %>

<%@ Import Namespace="Resources" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContent" runat="server">
    <div id="PageTitle">
        <%=LanguageText.tr_bagReceiveVerification%><hr style="border-width: 0px; background-color: #718ca5;"
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
                        </td>
                    </tr>
                </table>
                <br />
                <table width="100%">
                    <tr>
                        <td class="left_table_cell">
                            <asp:Label ID="Label2" runat="server" Text="<%$Resources:LanguageText, tr_approvedControlCount%>"></asp:Label>
                        </td>
                        <td class="right_table_cell">
                            <asp:Label ID="lblApprovedControlCount" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="left_table_cell">
                            <asp:Label ID="Label3" runat="server" Text="<%$Resources:LanguageText, tr_date%>"></asp:Label>
                        </td>
                        <td class="right_table_cell">
                            <asp:Label ID="lblDate" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="left_table_cell">
                            <asp:Label ID="Label4" runat="server" Text="<%$Resources:LanguageText, tr_numberEnvelopes %>"></asp:Label>
                        </td>
                        <td class="right_table_cell">
                            <asp:TextBox ID="tBoxNumberEnvelopes" runat="server"  MaxLength="6" CssClass="text_box"></asp:TextBox>
                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server"  TargetControlID="tBoxNumberEnvelopes" FilterType="Numbers">
                            </cc1:FilteredTextBoxExtender>
                        </td>
                    </tr>
                </table>
                <br />
                <asp:Label ID="lblMessage0" runat="server"  Text="<%$Resources:LanguageText, tr_envNotMatch%>" ForeColor="Red" Visible="false"></asp:Label>
                <asp:Label ID="lblMessage" runat="server" ForeColor="Green" Text=""></asp:Label>
                <table style="width: 100%">
                    <tr>
                        <td class="left_table_cell" style="width: 250px;">
                            &nbsp;
                        </td>
                        <td class="right_table_cell">
                            <asp:Button ID="btnSave" runat="server" Text="<%$Resources:LanguageText, GVDocumentCommentEditAlt %>"
                                CssClass="button100" OnClick="btnSave_Click" />
                            &nbsp;&nbsp;&nbsp;
                            <asp:Button ID="btnCancel" runat="server" Text="<%$Resources:LanguageText, BCancel %>"
                                CssClass="button100" OnClick="btnCancel_Click" />
                                &nbsp;&nbsp;&nbsp;
                            <asp:Button ID="btnChangeStatus" runat="server" Text="Vrati na pripremu za verifikaciju"
                                CssClass="button" onclick="btnChangeStatus_Click" />
                        </td>
                    </tr>
                </table>
                <br />
                <div style="padding: 5px 10px 0px 10px; font-weight: bold; font-size: 120%; background-color: #718ca5;
                    height: 25px; vertical-align: middle; text-align: center;">
                    <%=LanguageText.tr_bagsInVerification%>
                </div>
                <br />
                <asp:GridView ID="GridView1" runat="server" SkinID="KVoteGridView1" Width="100%"
                    AutoGenerateColumns="False" DataKeyNames="Id" DataSourceID="dsBags" PageSize="100">
                    <Columns>
                        <asp:BoundField DataField="PollingStationCode" HeaderText="<%$Resources:LanguageText, tr_psCode%>" SortExpression="PollingStationCode" />
                        <asp:BoundField DataField="PSTypeNameDescription" HeaderText="<%$Resources:LanguageText, tr_psType%>" SortExpression="PSTypeNameDescription" />
                        <asp:BoundField DataField="DateReceived" HeaderText="<%$Resources:LanguageText, tr_date%>" SortExpression="DateReceived" />
                        <asp:BoundField DataField="VerificationReceived" HeaderText="<%$Resources:LanguageText, tr_receivedVerification%>"
                            SortExpression="VerificationReceived" />
                    </Columns>
                    <EmptyDataTemplate>
                        <table style="width: 100%">
                            <tr>
                                <td align="center">
                                    <asp:Label ID="lblNoData" runat="server" Text="<%$Resources:LanguageText, noData%>"
                                        CssClass="text12_normal"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </EmptyDataTemplate>
                </asp:GridView>
                <asp:SqlDataSource ID="dsBags" runat="server" ConnectionString="<%$ ConnectionStrings:BVOTEConnectionString %>"
                    SelectCommand="p3_getDataFromBagsVerification" SelectCommandType="StoredProcedure">
                </asp:SqlDataSource>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <div style="height: 10px;">
    </div>
    <div class="line">
    </div>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:BVOTEConnectionString %>"
        SelectCommand="p3_getBagsForTypeOfPS_Verification" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:ControlParameter ControlID="ddlChooseTypeBag" Name="TypePS" PropertyName="SelectedValue"
                Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="dsPSTypes" runat="server" ConnectionString="<%$ ConnectionStrings:BVOTEConnectionString %>"
        SelectCommand="p3_getPSTypes1" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
</asp:Content>
