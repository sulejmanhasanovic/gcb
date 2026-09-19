<%@ Page Language="C#" MasterPageFile="~/masterpage.Master" AutoEventWireup="true"
    CodeBehind="BoxSorting.aspx.cs" Inherits="JIIS.Web.Phase3.Tracking.BoxSorting" Title="<%$Resources:LanguageText, tr_boxSort%>"
    Theme="Default" %>

<%@ Import Namespace="Resources" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContent" runat="server">
    <div id="PageTitle">
        <%=LanguageText.tr_boxSort%><hr style="border-width: 0px; background-color: #718ca5;"
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
                <div style="padding: 5px 10px 0px 10px; font-weight: bold; font-size: 120%; background-color: #718ca5;
                    height: 25px; vertical-align: middle; text-align: center;">
                    <%=LanguageText.tr_boxesSorting%>
                </div>
                <br />
                <asp:GridView ID="GridView1" runat="server" SkinID="KVoteGridView1" Width="100%"
                    AutoGenerateColumns="False" DataSourceID="dsBoxesSorting" PageSize="100" DataKeyNames="Id">
                    <Columns>
                        <asp:BoundField DataField="id" HeaderText="id" SortExpression="id" Visible="false" />
                        <asp:BoundField DataField="BoxName" HeaderText="<%$Resources:LanguageText, tr_boxName%>" SortExpression="BoxName" />
                        <asp:BoundField DataField="BoxNo" HeaderText="<%$Resources:LanguageText, tr_boxNumber%>" SortExpression="BoxNo" />
                        <asp:BoundField DataField="BoxCombination" HeaderText="<%$Resources:LanguageText, tr_boxCombination%>" SortExpression="BoxCombination" />
                        <asp:BoundField DataField="BoxType" HeaderText="<%$Resources:LanguageText, tr_boxType%>" SortExpression="BoxType" />
                        <asp:BoundField DataField="TotalNoOfEnvelopes" HeaderText="<%$Resources:LanguageText, tr_totalNoEnvelopes%>"
                            SortExpression="TotalNoOfEnvelopes" />
                        <asp:TemplateField HeaderText="">
                            <ItemTemplate>
                                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# "BoxSortingDetails.aspx?id="+Eval("id")+"&Combination="+Eval("BoxCombination") %>'
                                    Text="<%$Resources:LanguageText, DocumentsMenuMainEdit%>"></asp:HyperLink>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
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
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <div class="line">
    </div>
    <asp:SqlDataSource ID="dsBoxesSorting" runat="server" ConnectionString="<%$ ConnectionStrings:BVOTEConnectionString %>"
        SelectCommand="p3_getBoxSorting" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
</asp:Content>
