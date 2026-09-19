<%@ Page Language="C#" MasterPageFile="~/masterpage.Master" AutoEventWireup="true"
    CodeBehind="DeniedVoters.aspx.cs" Inherits="JIIS.Web.Phase3.Tracking.DeniedVoters"
    Title="<%$Resources:LanguageText, tr_DeniedVoters%>" Theme="Default" %>

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
                                    <asp:Button ID="btnNew" runat="server" CssClass="button100" 
                                        OnClick="btnSave_Click" Text="Novi" ValidationGroup="Save" />
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
                <br />
                <div id="ListDeniedVoters" runat="server">
                    <br />
                    <div style="text-align: left;">
                        <asp:GridView ID="gvDeniedVoter" runat="server" Width="560px" 
                            SkinID="KVoteGridView" AutoGenerateColumns="False" OnRowDataBound="GridView_RowDataBound"
                            DataSourceID="dsDeniedVoters" PageSize="100"
                            GridLines="Vertical" DataKeyNames="IdDeniedVoter">
                            <Columns>
                               
                                <asp:CommandField ShowDeleteButton="True" />
                               
                                <asp:BoundField DataField="IdDeniedVoter" HeaderText="IdDeniedVoter" 
                                    SortExpression="IdDeniedVoter" InsertVisible="False" ReadOnly="True" 
                                    Visible="False" />
                                <asp:BoundField DataField="JMB" HeaderText="JMB" 
                                    SortExpression="JMB" />
                                <asp:BoundField DataField="NumberBags" HeaderText="NumberBags" 
                                    SortExpression="NumberBags" />
                                <asp:BoundField DataField="Reason" HeaderText="Reason" 
                                    SortExpression="Reason" />
                                     <asp:BoundField DataField="NameVoter" HeaderText="NameVoter" 
                                    SortExpression="NameVoter" />
                                    
                                    <asp:BoundField DataField="SurnameVoter" HeaderText="SurnameVoter" 
                                    SortExpression="SurnameVoter" />
                                    
                                    <asp:TemplateField HeaderText="<%$Resources:LanguageText, DocumentsMenuMainEdit%>"
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
                                                    <td align="center" valign="middle">
                                                        <asp:ImageButton ID="imgbtnDelete" runat="server"
                                                            ImageAlign="Middle" ImageUrl="~/App_Themes/Default/default_images/delete.png"
                                                            OnClick="imgbtnDeleteDenVoters_Click" />
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
                                            <asp:Label ID="lblNoData0" runat="server" Text="<%$Resources:LanguageText, noData%>"
                                                CssClass="text12_normal"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </EmptyDataTemplate>
                        </asp:GridView>
                        <br />
                    </div>
                    <br />
                    <table width="100%">
                        <tr>
                            <td >
                            </td>
                            <td>
                                <asp:Button ID="btnSave" runat="server" CssClass="button100" 
                                    OnClick="btnSave_Click" 
                                    Text="<%$Resources:LanguageText, GVDocumentCommentEditAlt %>" 
                                    ValidationGroup="Save" Visible="False" />
                            </td>
                        </tr>
                        <tr>
                            <td >
                                &nbsp;</td>
                            <td class="right_table_cell">
                                &nbsp;</td>
                        </tr>
                    </table>
                </div>
                <br />
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
    <asp:SqlDataSource ID="dsDeniedVoters" runat="server" ConnectionString="<%$ ConnectionStrings:BVOTEConnectionString %>"
        SelectCommand="p3_getDeniedVoters" SelectCommandType="StoredProcedure" 
        ProviderName="System.Data.SqlClient" DeleteCommand="p3_DeleteDeniedVoter" 
        DeleteCommandType="StoredProcedure">
        <DeleteParameters>
            <asp:Parameter Name="ID" Type="Int32" />
        </DeleteParameters>
    </asp:SqlDataSource>
    </asp:Content>
