<%@ Page Language="C#" MasterPageFile="~/masterpage.Master" AutoEventWireup="true"
    CodeBehind="BoxCounting.aspx.cs" Inherits="JIIS.Web.Phase3.Tracking.BoxCounting" Title="<%$Resources:LanguageText, tr_boxCount%>"
    Theme="Default" %>

<%@ Import Namespace="Resources" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContent" runat="server">
    <div id="PageTitle">
        <%=LanguageText.tr_boxCount%><hr style="border-width: 0px; background-color: #718ca5;"
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
                            <asp:Label ID="Label8" runat="server" Text="<%$Resources:LanguageText, tr_chooseBox%>"></asp:Label>
                        </td>
                        <td class="right_table_cell">
                            <asp:DropDownList ID="ddlBoxes" runat="server" Width="50%" DataSourceID="dsBoxesSorting"
                                DataTextField="BoxName" DataValueField="BoxName" AutoPostBack="True" OnDataBound="ddl_DataBound">
                            </asp:DropDownList>
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
                            <asp:Button ID="btnConfirm" runat="server" Text="<%$Resources:LanguageText, tr_confirm%>"
                                CssClass="button100" OnClick="btnConfirm_Click" />
                        </td>
                    </tr>
                </table>
                <br />
                <div style="padding: 5px 10px 0px 10px; font-weight: bold; font-size: 120%; background-color: #718ca5;
                    height: 25px; vertical-align: middle; text-align: center;">
                    <%=LanguageText.tr_boxesCounting%>
                </div>
                <br />
                <asp:GridView ID="GridView1" runat="server" SkinID="KVoteGridView1" Width="100%"
                    AutoGenerateColumns="False" DataSourceID="dsBoxInCounting" PageSize="100" DataKeyNames="Id">
                    <Columns>
                        <asp:BoundField DataField="id" HeaderText="id" SortExpression="id" Visible="false" />
                        <asp:BoundField DataField="BoxName" HeaderText="<%$Resources:LanguageText, tr_boxName%>"
                            SortExpression="BoxName" />
                        <asp:BoundField DataField="BoxNo" HeaderText="<%$Resources:LanguageText, tr_boxNumber%>"
                            SortExpression="BoxNo" />
                        <asp:BoundField DataField="BoxCombination" HeaderText="<%$Resources:LanguageText, tr_boxCombination%>"
                            SortExpression="BoxCombination" />
                        <asp:BoundField DataField="BoxType" HeaderText="<%$Resources:LanguageText, tr_boxType%>"
                            SortExpression="BoxType" />
                        <asp:BoundField DataField="TotalNoOfEnvelopes" HeaderText="<%$Resources:LanguageText, zt_totalNoBallots%>"
                            SortExpression="TotalNoOfEnvelopes" />
                        <asp:TemplateField HeaderText="">
                            <ItemTemplate>
                                <%--<asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# "BoxCountingDetails.aspx?id="+Eval("id")+"&Combination="+Eval("BoxCombination") %>'
                                    Text="<%$Resources:LanguageText, DocumentsMenuMainEdit%>"></asp:HyperLink>--%>
                                <asp:LinkButton ID="linkCounting" runat="server" Font-Underline="false" OnClick="linkCounting_Click"
                                    Text="<%$Resources:LanguageText, DocumentsMenuMainEdit%>"></asp:LinkButton>
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
        SelectCommand="p3_getBoxReadyForCounting" SelectCommandType="StoredProcedure">
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="dsBoxInCounting" runat="server" ConnectionString="<%$ ConnectionStrings:BVOTEConnectionString %>"
        SelectCommand="p3_getBoxInCounting" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
</asp:Content>
