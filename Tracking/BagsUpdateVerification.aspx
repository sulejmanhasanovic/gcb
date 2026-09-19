<%@ Page Language="C#" MasterPageFile="~/masterpage.Master" AutoEventWireup="true"
    CodeBehind="BagsUpdateVerification.aspx.cs" Inherits="JIIS.Web.Phase3.Tracking.BagsUpdateVerification"
    Title="<%$Resources:LanguageText, tr_bagVerification%>" Theme="Default" %>

<%@ Import Namespace="Resources" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContent" runat="server">
    <div id="PageTitle">
        <%=LanguageText.tr_bagVerification%><hr style="border-width: 0px; background-color: #718ca5;"
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
                        <td>
                            <asp:GridView ID="gvStatistic" runat="server" SkinID="KVoteGridView1" Width="100%"
                                AutoGenerateColumns="False" DataKeyNames="Clerk" DataSourceID="sqldsStatistic"
                                PageSize="100" OnRowDataBound="gvStatistic_RowDataBound">
                                <Columns>
                                    <asp:BoundField DataField="UserName" HeaderText="<%$Resources:LanguageText, p1_NameSurname %>"
                                        SortExpression="UserName" />
                                    <asp:BoundField DataField="broj" HeaderText="<%$Resources:LanguageText, m_NumberAccepted %>"
                                        SortExpression="broj" />
                                    <asp:BoundField DataField="broj" HeaderText="<%$Resources:LanguageText, m_NumberDenied %>"
                                        SortExpression="broj" />
                                    <asp:BoundField DataField="broj" HeaderText="<%$Resources:LanguageText, p3_total %>"
                                        SortExpression="broj" />
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="linkPreview" runat="server" OnClick="linkPreview_Click" Text="<%$Resources:LanguageText, PgScanBPreview %>"
                                                Font-Underline="false"></asp:LinkButton>
                                        </ItemTemplate>
                                        <ItemStyle Width="10%" HorizontalAlign="Center" />
                                        <HeaderStyle Width="10%" HorizontalAlign="Center" />
                                    </asp:TemplateField>
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
                        </td>
                    </tr>
                </table>
                <br />
                <table width="100%">
                    <tr>
                        <td>
                            <asp:GridView ID="gvStatisticByClerk" runat="server" SkinID="KVoteGridView1" Width="100%"
                                AutoGenerateColumns="False" DataKeyNames="id" DataSourceID="sqldsStatisticByClerk"
                                PageSize="10" OnRowDataBound="gvStatisticByClerk_RowDataBound" AllowPaging="True">
                                <Columns>
                                    <asp:BoundField DataField="RegID" HeaderText="<% $Resources:LanguageText, jmb %>"
                                        SortExpression="RegID" />
                                    <asp:BoundField DataField="Name" HeaderText="<% $Resources:LanguageText, lblName %>"
                                        SortExpression="Name" />
                                    <asp:BoundField DataField="Surname" HeaderText="<% $Resources:LanguageText, lblSurname %>"
                                        SortExpression="Surname" />
                                    <asp:BoundField DataField="Accepted" HeaderText="<% $Resources:LanguageText, m_CanVote %>"
                                        SortExpression="Accepted" />
                                    <asp:BoundField DataField="Reason" HeaderText="<% $Resources:LanguageText, p1_reason %>"
                                        SortExpression="Reason" />
                                    <asp:BoundField DataField="TimeVerified" HeaderText="<% $Resources:LanguageText, fvlTime %>"
                                        SortExpression="TimeVerified" />
                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="imgbtnDelete" runat="server" AlternateText="<%$ Resources:LanguageText, GVSysAdminOrgUnitDeleteAlt %>"
                                                ImageAlign="Middle" ImageUrl="~/App_Themes/Default/default_images/delete.png"
                                                OnClick="imgbtnDeleteOrgUnit_Click" ToolTip="<%$ Resources:LanguageText, GVSysAdminOrgUnitToolTip %>" />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Width="5%" />
                                        <HeaderStyle HorizontalAlign="Center" Width="5%" />
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <br />
                        </td>
                    </tr>
                </table>
                <table width="100%">
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
                            <asp:Label ID="Label4" runat="server" Text="<%$Resources:LanguageText, tr_receivedEnvelopes%>"></asp:Label>
                        </td>
                        <td class="right_table_cell">
                            <asp:Label ID="lblReceivedVerification" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="left_table_cell">
                            <asp:Label ID="Label5" runat="server" Text="<%$Resources:LanguageText, tr_confEnv%>"></asp:Label>
                        </td>
                        <td class="right_table_cell">
                            <asp:TextBox ID="tBoxConfirmed" runat="server" CssClass="text_box" MaxLength="6"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="tBoxConfirmed"
                                Display="Dynamic" ErrorMessage="*"></asp:RequiredFieldValidator>
                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="tBoxConfirmed"
                                FilterType="Numbers">
                            </cc1:FilteredTextBoxExtender>
                            &nbsp;
                            <asp:Label ID="lblAccScanned" runat="server"></asp:Label>
                            &nbsp;
                            <asp:Label ID="lblMsgAcc" runat="server" CssClass="error_message"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="left_table_cell">
                            <asp:Label ID="Label7" runat="server" Text="<%$Resources:LanguageText, tr_denEnv%>"></asp:Label>
                        </td>
                        <td class="right_table_cell">
                            <asp:TextBox ID="tBoxDenied" runat="server" CssClass="text_box" MaxLength="6"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="tBoxDenied"
                                Display="Dynamic" ErrorMessage="*"></asp:RequiredFieldValidator>&nbsp;&nbsp;&nbsp;
                            
                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" TargetControlID="tBoxDenied"
                                FilterType="Numbers">
                            </cc1:FilteredTextBoxExtender>
                            &nbsp;
                            <asp:Label ID="lblDenScanned" runat="server"></asp:Label>
                            &nbsp;
                            <asp:Label ID="lblMsgDen" runat="server" CssClass="error_message"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
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
                            <asp:Button ID="btnSave" runat="server" Text="<%$Resources:LanguageText, GVDocumentCommentEditAlt %>"
                                CssClass="button100" OnClick="btnSave_Click" />
                            &nbsp;&nbsp;&nbsp;
                            <asp:Button ID="btnCancel" runat="server" Text="<%$Resources:LanguageText, BCancel %>"
                                CssClass="button100" OnClick="btnCancel_Click" />
                            &nbsp;&nbsp;&nbsp;
                            <asp:Button ID="btnChangeStatus" runat="server" Text="Vrati na verifikacija - prijem materijala"
                                CssClass="button" OnClick="btnChangeStatus_Click" />
                        </td>
                    </tr>
                </table>
                <br />
                <div style="padding: 5px 10px 0px 10px; font-weight: bold; font-size: 120%; background-color: #718ca5;
                    height: 25px; vertical-align: middle; text-align: center;">
                    Verified bags
                </div>
                <br />
                <asp:GridView ID="GridView1" runat="server" SkinID="KVoteGridView1" Width="100%"
                    AutoGenerateColumns="False" DataKeyNames="Id" DataSourceID="dsBags" PageSize="100">
                    <Columns>
                        <asp:BoundField DataField="PollingStationCode" HeaderText="<%$Resources:LanguageText, tr_psCode%>"
                            SortExpression="PollingStationCode" />
                        <asp:BoundField DataField="PSTypeNameDescription" HeaderText="<%$Resources:LanguageText, tr_psType%>"
                            SortExpression="PSTypeNameDescription" />
                        <asp:BoundField DataField="DateReceived" HeaderText="<%$Resources:LanguageText, tr_date%>"
                            SortExpression="DateReceived" />
                        <asp:BoundField DataField="VerificationAccepted" HeaderText="<%$Resources:LanguageText, tr_verApproved%>"
                            SortExpression="VerificationAccepted" />
                        <asp:BoundField DataField="VerificationRejected" HeaderText="<%$Resources:LanguageText, tr_verDenied%>"
                            SortExpression="VerificationRejected" />
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
                    SelectCommand="p3_getDataFromBagsAfterVerification" SelectCommandType="StoredProcedure">
                </asp:SqlDataSource>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <div class="line">
    </div>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:BVOTEConnectionString %>"
        SelectCommand="p3_getDataFromBagsVerificationByID" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:ControlParameter ControlID="ddlChooseTypeBag" Name="PSType" PropertyName="SelectedValue"
                Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="dsPSTypes" runat="server" ConnectionString="<%$ ConnectionStrings:BVOTEConnectionString %>"
        SelectCommand="p3_getPSTypes1" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
    <asp:SqlDataSource ID="sqldsStatistic" runat="server" ConnectionString="<%$ ConnectionStrings:BVOTEConnectionString %>"
        SelectCommand="p3_getScannedStatistic" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:ControlParameter ControlID="ddlBagNumber" Name="psBag" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="sqldsStatisticByClerk" runat="server" ConnectionString="<%$ ConnectionStrings:BVOTEConnectionString %>"
        SelectCommand="p3_getScannedStatisticByClerk" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:ControlParameter ControlID="ddlBagNumber" Name="psBag" Type="String" />
            <asp:SessionParameter Name="clerk" SessionField="clerkID" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>
</asp:Content>
