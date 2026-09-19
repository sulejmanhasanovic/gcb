<%@ Page Language="C#" MasterPageFile="~/masterpage.Master" AutoEventWireup="true"
    CodeBehind="DeniedBagsReceiveVerification.aspx.cs" Inherits="JIIS.Web.Phase3.Tracking.DeniedBagsReceiveVerification"
    Title="<%$Resources:LanguageText, tr_deniedBagReceiveVerification%>" Theme="Default" %>

<%@ Import Namespace="Resources" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContent" runat="server">
    <div id="PageTitle">
        <%=LanguageText.tr_deniedBagReceiveVerification%><hr style="border-width: 0px; background-color: #718ca5;"
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
                            <asp:Label ID="Label8" runat="server" Text="<%$Resources:LanguageText, tr_chooseTypeDeniedBag%>"></asp:Label>
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
                <asp:GridView ID="GridView1" runat="server" SkinID="KVoteGridView1" Width="100%" OnRowDataBound="GridView1_RowDataBound"
                    AutoGenerateColumns="False" DataKeyNames="Id" DataSourceID="dsBags" PageSize="100">
                    <Columns>
                        <asp:BoundField DataField="PollingStationCode" HeaderText="PollingStationCode" 
                            SortExpression="PollingStationCode" />
                        <asp:BoundField DataField="PSTypeNameDescription" 
                            HeaderText="PSTypeNameDescription" SortExpression="PSTypeNameDescription" />
                        <asp:BoundField DataField="DateReceived" HeaderText="DateReceived" 
                            SortExpression="DateReceived" />
                        <asp:BoundField DataField="VerificationReceived" 
                            HeaderText="VerificationReceived" SortExpression="VerificationReceived" />
                            
                          <asp:TemplateField 
                            HeaderStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <table style="width: 100%; text-align: left" align="center">
                                    <tr>
                                        <td style="text-align: left;">
                                            <table border="0" cellpadding="0" cellspacing="0" style="width: 100%;">
                                                <tr>
                                                    <td align="center" valign="middle">
                                                        <asp:HyperLink ID="hlEdit" runat="server" CssClass="grid_link" ImageUrl="~/App_Themes/Default/default_images/edit.png"
                                                            ToolTip="<%$ Resources:LanguageText, DocumentsMenuMainEdit %>" Text="<%$ Resources:LanguageText, GVSysAdminOrgUnitEdit %>"></asp:HyperLink>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                            <ItemStyle HorizontalAlign="Center" />
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
                <asp:SqlDataSource ID="dsBags" runat="server" ConnectionString="<%$ ConnectionStrings:BVOTEConnectionString %>"
                    SelectCommand="p3_getDataFromDeniedBagsVerification" 
                    SelectCommandType="StoredProcedure" ProviderName="System.Data.SqlClient">
                </asp:SqlDataSource>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <div style="height: 10px;">
    </div>
    <div class="line">
    </div>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:BVOTEConnectionString %>"
        SelectCommand="p3_getDeniedBagsForTypeOfPS_Verification" 
        SelectCommandType="StoredProcedure" ProviderName="System.Data.SqlClient">
        <SelectParameters>
            <asp:ControlParameter ControlID="ddlChooseTypeBag" Name="TypePS" PropertyName="SelectedValue"
                Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="dsPSTypes" runat="server" ConnectionString="<%$ ConnectionStrings:BVOTEConnectionString %>"
        SelectCommand="p3_getPSTypes1" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
</asp:Content>
