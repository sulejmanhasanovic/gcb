<%@ Page Language="C#" MasterPageFile="~/masterpage.Master" AutoEventWireup="true"
    CodeBehind="BoxFill.aspx.cs" Inherits="JIIS.Web.Phase3.Tracking.BoxFill" Title="<%$Resources:LanguageText, tr_boxFill%>"
    Theme="Default" %>

<%@ Import Namespace="Resources" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContent" runat="server">
    <div id="PageTitle">
        <%=LanguageText.tr_boxFill%><hr style="border-width: 0px; background-color: #718ca5;"
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
                <hr style="border-width: 0px; background-color: #718ca5;" noshade="noshade" />
                <asp:GridView ID="GridView1" runat="server" SkinID="KVoteGridView1" Width="100%" DataKeyNames="BoxNo"
                    AutoGenerateColumns="False" DataSourceID="dsBags" PageSize="100" OnRowDataBound="GridView1_DataBound">
                    <Columns>
                        <asp:BoundField DataField="id" HeaderText="id" SortExpression="id" Visible="false" />
                        <asp:BoundField DataField="BoxName" HeaderText="<%$Resources:LanguageText, tr_boxName%>"
                            SortExpression="BoxName" />
                        <asp:BoundField DataField="BoxCombination" HeaderText="<%$Resources:LanguageText, tr_boxCombination%>"
                            SortExpression="BoxCombination" />
                        <asp:BoundField DataField="BoxType" HeaderText="<%$Resources:LanguageText, tr_boxType%>"
                            SortExpression="BoxType" />
                        <asp:BoundField DataField="TotalNoOfEnvelopes" HeaderText="<%$Resources:LanguageText, tr_totalNoEnvelopes%>"
                            SortExpression="TotalNoOfEnvelopes" />
                        <asp:TemplateField HeaderText="">
                            <ItemTemplate>
                                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# "BoxFillDetails.aspx?id="+Eval("id") %>'
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
                <asp:SqlDataSource ID="dsBags" runat="server" ConnectionString="<%$ ConnectionStrings:BVOTEConnectionString %>"
                    SelectCommand="p3_getOpenBoxes" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <div class="line">
    </div>
    <asp:SqlDataSource ID="dsPSTypes" runat="server" ConnectionString="<%$ ConnectionStrings:BVOTEConnectionString %>"
        SelectCommand="p3_getPSTypes1" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
    <asp:SqlDataSource ID="ds_Combinations" runat="server" ConnectionString="<%$ ConnectionStrings:BVOTEConnectionString %>"
        SelectCommand="p3_getCombinations" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
</asp:Content>
