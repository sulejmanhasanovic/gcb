<%@ Page Language="C#" MasterPageFile="~/masterpage.Master" AutoEventWireup="true"
    CodeBehind="BagsControlCount.aspx.cs" Inherits="JIIS.Web.Phase3.Tracking.BagsControlCount"
    Title="<%$Resources:LanguageText, tr_bagControlCount%>" Theme="Default" %>

<%@ Import Namespace="Resources" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContent" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <div id="PageTitle">
                <asp:Literal ID="Literal1" runat="server"></asp:Literal>
                <asp:Literal ID="Literal2" runat="server"></asp:Literal>
                <hr style="border-width: 0px; background-color: #718ca5;" noshade="noshade" />
            </div>
            <div id="MainBody">
                <div style="height: 3px;">
                </div>
                <div id="Div2">
                    <div class="box">
                        <table cellpadding="0" cellspacing="0" border="0" width="100%">
                            <tr>
                                <td style="text-align: left">
                                    <asp:Button ID="Button5" runat="server" CssClass="button100" Text="<%$Resources:LanguageText, bback%>"
                                        CausesValidation="False" OnClick="Button5_Click" />
                                </td>
                                <td style="text-align: right">
                                    <%--<asp:Button ID="Button1" runat="server" CssClass="button100" Text="<%$Resources:LanguageText, GVDocumentCommentEditAlt %>"
                                        OnClick="btnSave_Click" ValidationGroup="Save" />--%>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
                <br />
                <div id="data" runat="server">
                    <table id="Table1" width="100%">
                        <tr>
                            <td class="left_table_cell">
                                <asp:Label ID="Label8" runat="server" Text="<%$Resources:LanguageText, tr_chooseTypeBag%>"></asp:Label>
                            </td>
                            <td class="right_table_cell">
                                <asp:DropDownList ID="ddlChooseTypeBag" runat="server" Width="50%" AutoPostBack="True"
                                    OnDataBound="ddl_DataBound" DataSourceID="dsPSTypes1" DataTextField="PSTypeNameDescription"
                                    DataValueField="PSTypeName" OnSelectedIndexChanged="ddlChooseTypeBag_SelectedIndexChanged">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*"
                                    ValidationGroup="valGroupNoEnv" Display="Dynamic" SetFocusOnError="true" ControlToValidate="ddlChooseTypeBag"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="left_table_cell">
                                <asp:Label ID="Label1" runat="server" Text="<%$Resources:LanguageText, tr_NumberBag%>"></asp:Label>
                            </td>
                            <td class="right_table_cell">
                                <asp:DropDownList ID="ddlChooseBagNo" runat="server" Width="50%" AutoPostBack="True"
                                    OnDataBound="ddl_DataBound" DataSourceID="dsBagsID" DataTextField="PollingStationCode"
                                    DataValueField="PollingStationCode" OnSelectedIndexChanged="ddlChooseBagNo_SelectedIndexChanged">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="*"
                                    ValidationGroup="valGroupNoEnv" Display="Dynamic" SetFocusOnError="true" ControlToValidate="ddlChooseBagNo"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                    </table>
                    <br />
                    <table width="100%">
                        <tr>
                            <td class="left_table_cell" style="width: 250px">
                                <asp:Label ID="lblBagNumber" runat="server" Text="<%$Resources:LanguageText, tr_NumberBag%>"></asp:Label>
                            </td>
                            <td class="right_table_cell">
                                <asp:Label ID="lblBagNo" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="left_table_cell" style="width: 250px">
                                <asp:Label ID="Label9" runat="server" Text="<%$Resources:LanguageText, tr_totalNoEnvelopes %>"></asp:Label>
                            </td>
                            <td class="right_table_cell">
                                <asp:TextBox ID="lblTotalEnvelopes" runat="server" Text="" CssClass="text_box" BorderStyle="None"
                                    ReadOnly="True"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="left_table_cell" style="width: 250px">
                                <asp:Label ID="Label4" runat="server" Text="<%$Resources:LanguageText, zt_totalNoEnvGCB %>"></asp:Label>
                            </td>
                            <td class="right_table_cell">
                                <asp:TextBox ID="txtCountedByCommision" runat="server" CssClass="text_box" MaxLength="6"></asp:TextBox>
                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" FilterType="Numbers"
                                    TargetControlID="txtCountedByCommision">
                                </cc1:FilteredTextBoxExtender>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*"
                                    ValidationGroup="valGroupNoEnv" Display="Dynamic" SetFocusOnError="true" ControlToValidate="txtCountedByCommision"></asp:RequiredFieldValidator>
                                &nbsp;<asp:Label ID="lblMissmatch" runat="server" ForeColor="#FF3300" 
                                    Text="Missmatch" Visible="False"></asp:Label>
                                &nbsp;<br />
                                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="lblTotalEnvelopes"
                                    ControlToValidate="txtCountedByCommision" Display="Dynamic" ErrorMessage="<%$Resources:LanguageText, ag_TheEnytiesAreNotTheSame%>"></asp:CompareValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="left_table_cell">
                            </td>
                            <td class="right_table_cell">
                            </td>
                        </tr>
                        <tr>
                            <td class="left_table_cell">
                            </td>
                            <td class="right_table_cell">
                                <asp:Button ID="btnContinue" runat="server" Text="<%$Resources:LanguageText, btnContinue %>"
                                    CssClass="button100" ValidationGroup="valGroupNoEnv" OnClick="btnContinue_Click" />
                            </td>
                        </tr>
                    </table>
                </div>
                <div id="reasons" runat="server">
                    <table width="100%">
                        <tr>
                            <td class="left_table_cell" style="width: 250px">
                                <asp:Label ID="lblSecondTime" runat="server" Text="<%$Resources:LanguageText, tr_appBeforeVerification%>"></asp:Label>
                            </td>
                            <td class="right_table_cell">
                                <asp:TextBox ID="tBoxApprovedEnv" runat="server" ValidationGroup="Save" CssClass="text_box"
                                    MaxLength="6"></asp:TextBox>
                                <cc1:FilteredTextBoxExtender ID="tBoxApprovedEnv_FilteredTextBoxExtender" runat="server"
                                    Enabled="True" FilterMode="ValidChars" FilterType="Numbers" TargetControlID="tBoxApprovedEnv">
                                </cc1:FilteredTextBoxExtender>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="tBoxApprovedEnv"
                                    runat="server" ValidationGroup="Save" ErrorMessage="*"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                    </table>
                    <br />
                    <div style="text-align: left;">
                        <table style="text-align: center; width: 410px;">
                            <tr>
                                <td class="left_table_cell">
                                    <asp:Label ID="Label3" runat="server" Text="<%$Resources:LanguageText, tr_reasonDenying%>"></asp:Label>
                                </td>
                                <td style="text-align: right;">
                                    <asp:Button ID="btnAddNewReason" runat="server" CssClass="button" Text="<%$Resources:LanguageText, tr_newReason%>"
                                        OnClick="btnAddNewReason_Click" ValidationGroup="NewReason" />
                                </td>
                            </tr>
                            <table id="tblNewReason" runat="server" style="text-align: center; width: 410px;"
                                visible="false">
                                <tr>
                                    <td class="left_table_cell">
                                        <asp:Label ID="Label2" runat="server" Text="<%$Resources:LanguageText, tr_reasonName%>"></asp:Label>
                                    </td>
                                    <td class="right_table_cell">
                                        <asp:TextBox ID="tBoxReasonName" runat="server" CssClass="text_box"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="left_table_cell">
                                    </td>
                                    <td class="right_table_cell">
                                        <asp:Button ID="btnSaveReason" runat="server" CssClass="button" OnClick="btnSaveReason_Click"
                                            Text="<%$Resources:LanguageText, BSave%>" ValidationGroup="SaveReason" />&nbsp;&nbsp;
                                        <asp:Button ID="btnCancel" runat="server" CssClass="button" Text="<%$Resources:LanguageText, BCancel%>"
                                            ValidationGroup="SaveReason" OnClick="btnCancel_Click" />
                                    </td>
                                </tr>
                            </table>
                        </table>
                        <asp:GridView ID="GridView1" runat="server" Width="560px" SkinID="KVoteGridView"
                            ShowHeader="False" AutoGenerateColumns="False" 
                            DataSourceID="dsDenyReasons" PageSize="100"
                            GridLines="None" OnRowDataBound="GridView1_RowDataBound" DataKeyNames="id" 
                            onselectedindexchanged="GridView1_SelectedIndexChanged"
                            ondisposed="GridView1_Disposed" onprerender="GridView1_PreRender" 
                            onrowediting="GridView1_RowEditing" onrowupdated="GridView1_RowUpdated" 
                            onrowupdating="GridView1_RowUpdating">
                            <Columns>
                                <asp:BoundField DataField="ReasonName" SortExpression="ReasonName">
                                    <ItemStyle Width="260px" HorizontalAlign="right" />
                                </asp:BoundField>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        &nbsp;&nbsp;<asp:TextBox runat="server" ID="tBoxReasonNumber" Text="0" CssClass="text_box"
                                            Width="50px" AutoPostBack = "true">
                                        </asp:TextBox>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" Width="60px" />
                                </asp:TemplateField>
                                <asp:TemplateField Visible="false">
                                    <ItemTemplate>
                                        &nbsp;&nbsp;<asp:Label runat="server" ID="lblID" Text='<%# Bind("ID") %>'>
                                        </asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" Width="100px" />
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        &nbsp;&nbsp;<asp:TextBox runat="server" ID="txtComment" CssClass="text_box" Width="230px">
                                        </asp:TextBox>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" Width="240px" />
                                </asp:TemplateField>
                                <%-- <asp:BoundField DataField="id" SortExpression="id" Visible="false">
                                <ItemStyle Width="10px" HorizontalAlign="Left" />
                            </asp:BoundField>--%>
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
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</div>
                    <br />
                    <table width="100%">
                        <tr>
                            <td>
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:HyperLink ID="HyperLink1" runat="server" ForeColor="Blue" Visible="false"
                                    NavigateUrl="~/Phase3/Tracking/DeniedVoters.aspx">Odbijeni glasaèi</asp:HyperLink>
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
                            <td class="right_table_cell">
                                <asp:Label ID="lblNumberReason" runat="server" ForeColor="Blue"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="left_table_cell">
                                <asp:Label ID="lblNBag" runat="server" 
                                    Text="<%$Resources:LanguageText, tr_deniedBeforeVerification%>"></asp:Label>
                            </td>
                            <td class="right_table_cell">
                                <asp:TextBox ID="tBoxDeniedEnv" runat="server" CssClass="text_box" 
                                    MaxLength="6" ValidationGroup="Save"></asp:TextBox>
                                <cc1:FilteredTextBoxExtender ID="tBoxDeniedEnv_FilteredTextBoxExtender" 
                                    runat="server" Enabled="True" FilterMode="ValidChars" FilterType="Numbers" 
                                    TargetControlID="tBoxDeniedEnv">
                                </cc1:FilteredTextBoxExtender>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                    ControlToValidate="tBoxDeniedEnv" ErrorMessage="*" ValidationGroup="Save"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="left_table_cell">
                                <asp:Label ID="Label5" runat="server" Text="<%$Resources:LanguageText, de_comment%>"></asp:Label>
                            </td>
                            <td class="right_table_cell">
                                <asp:TextBox ID="txtCommentAll" runat="server" ValidationGroup="Save" CssClass="text_box"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="left_table_cell">
                            </td>
                            <td class="right_table_cell">
                                <asp:Label ID="lblMessage" runat="server" Text="" ForeColor="Red"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="left_table_cell">
                                <asp:Label ID="Label6" runat="server" Text="<%$Resources:LanguageText, zt_bagFinishedGCB%>"></asp:Label>
                            </td>
                            <td class="right_table_cell">
                                <asp:Button ID="btnSave" runat="server" CssClass="button100" Text="<%$Resources:LanguageText, GVDocumentCommentEditAlt %>"
                                    OnClick="btnSave_Click" ValidationGroup="Save" />
                            </td>
                        </tr>
                    </table>
                </div>
                <br />
                
                 <asp:Panel ID="Panel3" runat="server" Style="z-index: 100; left: 34%; position: absolute;
                    top: 50%; width: 645px; height: 81px;" Visible="False" Wrap="false">
                    <asp:Panel ID="Panel2" runat="server" Style="cursor: move; background-color: #DDDDDD;
                        border: solid 1px Gray; color: Black" Height="70px" Width="500px">
                        <div>
                            <p>
                                <asp:Label ID="Label24" runat="server" Text="<%$ Resources:LanguageText, zzSuccessMessage %>"
                                    Font-Size="Small" ForeColor="Green"></asp:Label>
                            </p>
                            <p style="text-align: center;">
                                <asp:Button ID="okButton" runat="server" CssClass="button120" CausesValidation="False"
                                    OnClick="okButton_Click" Text="<%$ Resources:LanguageText, ok %>" />
                            </p>
                        </div>
                    </asp:Panel>
                </asp:Panel>
                
                <div class="box">
                    <table cellpadding="0" cellspacing="0" border="0" width="100%">
                        <tr>
                            <td style="text-align: left">
                                <asp:Button ID="Button2" runat="server" CssClass="button100" Text="<%$Resources:LanguageText, bback%>"
                                    CausesValidation="False" OnClick="Button5_Click" />
                            </td>
                            <td style="text-align: right">
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <div style="height: 10px;">
    </div>
    <div class="line">
    </div>
    
 
    
    <asp:SqlDataSource ID="dsDenyReasons" runat="server" ConnectionString="<%$ ConnectionStrings:BVOTEConnectionString %>"
        SelectCommand="p3_GetDenyReasons" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:ControlParameter ControlID="ddlChooseTypeBag" Name="typePS" PropertyName="SelectedValue"
                Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="dsPSTypes1" runat="server" ConnectionString="<%$ ConnectionStrings:BVOTEConnectionString %>"
        SelectCommand="p3_getPSTypes1" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
    <asp:SqlDataSource ID="dsBagsID" runat="server" ConnectionString="<%$ ConnectionStrings:BVOTEConnectionString %>"
        SelectCommand="p3_getBagsForTypeOfPS" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:ControlParameter ControlID="ddlChooseTypeBag" Name="TypePS" PropertyName="SelectedValue"
                Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>
</asp:Content>
