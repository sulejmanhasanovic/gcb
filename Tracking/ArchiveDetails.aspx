<%@ Page Language="C#" MasterPageFile="~/masterpage.Master" AutoEventWireup="true"
    CodeBehind="ArchiveDetails.aspx.cs" Inherits="JIIS.Web.Phase3.Tracking.ArchiveDetails" Title="<%$Resources:LanguageText, tr_archiveDetails%>"
    Theme="Default" %>

<%@ Import Namespace="Resources" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContent" runat="server">
    <div id="PageTitle">
        <%=LanguageText.tr_archiveDetails%><hr style="border-width: 0px; background-color: #718ca5;"
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
                <hr style="border-width: 0px; background-color: #718ca5;" noshade="noshade" />
                <asp:GridView ID="GridView1" runat="server" SkinID="KVoteGridView1" Width="100%"
                    AutoGenerateColumns="False" DataSourceID="dsBoxesInArchive" PageSize="100" 
                    DataKeyNames="Id">
                    <Columns>
                        <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id" 
                            Visible="False" />
                        <asp:BoundField DataField="BoxName" HeaderText="<%$Resources:LanguageText, tr_boxName%>" 
                            SortExpression="BoxName" />
                        <asp:BoundField DataField="BoxNo" HeaderText="<%$Resources:LanguageText, tr_boxNumber%>" SortExpression="BoxNo" />
                        <asp:BoundField DataField="BoxCombination" HeaderText="<%$Resources:LanguageText, tr_boxCombination%>" 
                            SortExpression="BoxCombination" />
                        <asp:BoundField DataField="BoxType" HeaderText="<%$Resources:LanguageText, tr_boxType%>" 
                            SortExpression="BoxType" />
                        <asp:BoundField DataField="LevelCode" HeaderText="<%$Resources:LanguageText, tr_levelCode%>"
                            SortExpression="LevelCode" />
                        <asp:BoundField DataField="NoOfBallotsSorted" HeaderText="<%$Resources:LanguageText, tr_numberBallotsSorted%>"
                            SortExpression="NoOfBallotsSorted" />
                        <asp:BoundField DataField="NoOfBallotsCounted" HeaderText="<%$Resources:LanguageText, tr_numberBallotsCounted%>" 
                            SortExpression="NoOfBallotsCounted" />
                        <asp:BoundField DataField="NoOfValidBallots" HeaderText="<%$Resources:LanguageText, tr_numberValidBallots%>" 
                            SortExpression="NoOfValidBallots" />
                        <asp:BoundField DataField="NoOfInvalidBallots" HeaderText="<%$Resources:LanguageText, tr_numberInvalidBallots%>" 
                            SortExpression="NoOfInvalidBallots" />
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
                <asp:SqlDataSource ID="dsBoxesInArchive" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:BVOTEConnectionString %>" 
                    SelectCommand="p3_getBoxArchiveDetails" SelectCommandType="StoredProcedure">
                    <SelectParameters>
                        <asp:QueryStringParameter Name="BoxNo" QueryStringField="bNo" Type="Decimal" />
                        <asp:QueryStringParameter Name="BoxCombination" QueryStringField="bCombination" 
                            Type="String" />
                        <asp:QueryStringParameter Name="BoxType" QueryStringField="bType" 
                            Type="String" />
                    </SelectParameters>
                </asp:SqlDataSource>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <div class="line">
    </div>
    </asp:Content>
