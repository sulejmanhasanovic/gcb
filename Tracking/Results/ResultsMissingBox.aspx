<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ResultsMissingBox.aspx.cs" Inherits="JIIS.Web.Phase3.Tracking.Results.ResultsMissingBox"
    MasterPageFile="~/masterpage.Master" Theme="Default" %>

<%@ Import Namespace="Resources" %>
<asp:Content ID="cAdminUsers" ContentPlaceHolderID="cphContent" runat="server">

  
    <div id="PageTitle">
        <%=LanguageText.zz_BoxNotInPss%><hr
            style="border-width: 0px; background-color: #718ca5;" noshade="noshade" />
    </div>
    <div id="MainBody">
     <div class="box">
                        <table cellpadding="0" cellspacing="0" border="0" width="100%">
                            <tr>
                                <td style="text-align: left">
                                  <asp:Button ID="btnBack" runat="server" CausesValidation="false" Text="<%$ Resources:LanguageText, PgBBack %>"
                                        CssClass="button2"  
                                        onclick="btnBack_Click" />
                                </td>
                                <td style="text-align: right">
                                  
                                </td>
                            </tr>
                        </table>
                    </div>
        <div style="height: 3px;">
        </div>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                  <table>
                    <tr>
                    <td >
                    <asp:GridView ID="gvUsers" runat="server" Width="786px" AllowSorting="True" AutoGenerateColumns="False"
                    SkinID="KVoteGridView" 
                     PageSize="50" AllowPaging="True" 
                            DataSourceID="SqlDataSource2">
                    <Columns>
                        <asp:BoundField DataField="BoxName" SortExpression="BoxName" 
                             HeaderText="<%$ Resources:LanguageText, tr_boxName %>">
                        </asp:BoundField>
                        <asp:BoundField DataField="BoxStatus" SortExpression="BoxStatus"  
                            HeaderText="<%$ Resources:LanguageText, zz_BoxStatus %>">
                        </asp:BoundField>
                        <asp:BoundField DataField="BoxName1" HeaderText="BoxName1"  Visible="false"
                            SortExpression="BoxName1" />
                        <asp:BoundField DataField="BoxStatusDesc" HeaderText="<%$ Resources:LanguageText, GVHeaderRootFolderDescription %>" 
                            SortExpression="BoxStatusDesc" />
                    </Columns>
                    <EmptyDataTemplate>
                        <table style="width: 100%">
                            <tr>
                                <td align="center">
                                    <asp:Label ID="lblNoData" runat="server" Text="<%$ Resources:LanguageText, noData %>"
                                        CssClass="GridViewNoData"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </EmptyDataTemplate>
                </asp:GridView>
                        <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                            ConnectionString="<%$ ConnectionStrings:BVOTEConnectionString %>" 
                            SelectCommand="p3_BoxNotInPsStatistics" 
                            SelectCommandType="StoredProcedure">
                        </asp:SqlDataSource>
                    </td>
                    </tr>
                    <caption>
                        <hr />
                    </caption>
                </table>
                <%--<div id="UserFilter">
                    <span>
                        <%=LanguageText.PgSysAdminShow%></span>
                        <asp:DropDownList ID="ddlPageSize" runat="server"
                            Width="40px" AutoPostBack="true" CssClass="drop_down_list" CausesValidation="false"
                            OnSelectedIndexChanged="ddlPageSize_SelectedIndexChanged">
                            <asp:ListItem Selected="True" Text="10" Value="10"></asp:ListItem>
                            <asp:ListItem Text="20" Value="20"></asp:ListItem>
                            <asp:ListItem Text="30" Value="30"></asp:ListItem>
                            <asp:ListItem Text="40" Value="40"></asp:ListItem>
                            <asp:ListItem Text="50" Value="50"></asp:ListItem>
                        </asp:DropDownList>
                    <span>
                        <%=LanguageText.PgSysAdminUsersOnPage%></span></div>--%>
                <br />
                <table width="100%">
                    <tr>
                        <td class="left_table_cell">
                            <div id="Div1">
                            </div>
                        </td>
                       
                    </tr>
                    <caption>
                        <hr />
                    </caption>
                </table>
                
            </ContentTemplate>
        </asp:UpdatePanel>
        <div style="height: 10px;">
        </div>
        <div class="line">
        </div>
        <%--<asp:SqlDataSource ID="sqldsUsers" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="dms_getAllAppruvedUsers" SelectCommandType="StoredProcedure" OnSelected="sqldsUsers_Selected">
            <SelectParameters>
                <asp:SessionParameter DefaultValue="0" Name="language" SessionField="language" Type="Int32" />
            </SelectParameters>
        </asp:SqlDataSource>--%>
    </div>
</asp:Content>
