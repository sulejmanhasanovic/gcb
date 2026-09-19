<%@ Page Language="C#" MasterPageFile="~/masterpage.Master" AutoEventWireup="true"
    Theme="Default" CodeBehind="CCZROpenNM.aspx.cs" Inherits="JIIS.Web.Phase3.Tracking.Results.CCZROpenNM" Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Import Namespace="Resources" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphContent" runat="server">

    <script language="JavaScript1.2" type="text/javascript">
function dblclick() 
{ 
  window.scrollTo(0,0) 
}
    </script>

    <div id="PageTitle">
        <%=LanguageText.de_firstDE%><hr style="border-width: 0px; background-color: #718ca5;"
            noshade="noshade" />
    </div>
    <div style="height: 10px;">
    </div>
    <div id="MainBody">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
               <div class="box">
                                    <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                        <tr>
                                            <td align="left">
                                                <asp:Button ID="btnBack" runat="server" CausesValidation="false" Text="<%$ Resources:LanguageText, PgBBack %>"
                                                    CssClass="button100" OnClick="btnBack_Click" />
                                            </td>
                                            <td align="right" style="width: 100%">
                                               
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                <div style="text-align: center;">
                    <asp:Label ID="Label23" runat="server" Text="OBRAZAC ZA ZBIRNE / ZBROJNE REZULTATE ZR (OTVORENA LISTA)"></asp:Label>
                </div>
                <asp:Label ID="lblRace" runat="server" Style="font-size: large" Text="Label"></asp:Label>
                <br />
                <table style="padding: 0px; margin: 0px; border: 2px solid #000000; width: 100%;
                    border-collapse: collapse;">
                    <tr>
                        <td rowspan="2" style="width: 15%; text-align: center; border: 2px solid #000000;">
                            <asp:Label ID="Label1a" runat="server" Text="<%$ Resources:LanguageText, p3_NameMunicipality%>"></asp:Label>
                        </td>
                        <td rowspan="2" style="text-align: center; border: 2px solid #000000;">
                            <asp:Label ID="lblLevelName" runat="server" Text="Label"></asp:Label>
                        </td>
                        <td style="width: 15%; text-align: center; border: 2px solid #000000;">
                            <asp:Label ID="Label3" runat="server" Text="<%$ Resources:LanguageText, p3_CodeMunicipality%>"></asp:Label>
                        </td>
                        <td style="width: 15%; text-align: center; border: 2px solid #000000;">
                            <asp:Label ID="Label1" runat="server" Text="<%$ Resources:LanguageText, p3_CodePolling %>"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 15%; height: 35px; text-align: center; border: 2px solid #000000;">
                            <asp:Label ID="lblLevelCode" runat="server" Text="Label"></asp:Label>
                            &nbsp;
                        </td>
                        <td style="width: 15%; text-align: center; border: 2px solid #000000;">
                            &nbsp;
                            <asp:Label ID="lblPSCode" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                </table>
                <br />
                <table style="width: 100%;">
                    <tr>
                        <td style="text-align: right;">
                            <asp:Button ID="Button2" runat="server" Text="Finish" CssClass="button100" OnClick="Button2_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: right;">
                            &nbsp;
                        </td>
                    </tr>
                </table>
                <asp:GridView ID="GridView1" SkinID="KVoteGridView" Width="100%" runat="server" AutoGenerateColumns="False"
                    DataKeyNames="IDCAND" DataSourceID="SqlDataSource1" PageSize="100">
                    <Columns>
                        <asp:BoundField DataField="ID" Visible="false" HeaderText="ID" ReadOnly="True" SortExpression="ID" />
                        <asp:BoundField DataField="ListNumber" HeaderText="ListNumber" SortExpression="ListNumber" />
                        <asp:BoundField DataField="PartyName" HeaderText="PartyName" ReadOnly="True" SortExpression="PartyName" />
                        <asp:BoundField DataField="ListPosition" Visible="false" HeaderText="ListPosition" SortExpression="ListPosition" />
                        <asp:BoundField DataField="CandName" HeaderText="CandName" ReadOnly="True" SortExpression="CandName" />
                        <asp:BoundField DataField="Gender" HeaderText="Gender" SortExpression="Gender" />
                        <asp:TemplateField ItemStyle-Width="10%" HeaderText="Votes">
                            <ItemTemplate>
                                <asp:TextBox ID="txtVotes" runat="server" Width="80%" MaxLength="4" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*"
                                    ControlToValidate="txtVotes"></asp:RequiredFieldValidator>
                                <cc1:FilteredTextBoxExtender ID="txtDate_FilteredTextBoxExtender" runat="server"
                                    FilterType="Numbers" TargetControlID="txtVotes">
                                </cc1:FilteredTextBoxExtender>
                            </ItemTemplate>
                            <ItemStyle Width="10%" />
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
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:BVOTEConnectionString %>"
                    SelectCommand="RESULTSGetPoliticalEntitiesANDCandidatesForVG" SelectCommandType="StoredProcedure">
                    <SelectParameters>
                        <asp:Parameter DefaultValue="10" Name="fkRace" Type="Decimal" />
                        <asp:SessionParameter Name="levelCode" SessionField="level" Type="String" />
                    </SelectParameters>
                </asp:SqlDataSource>
                <br />
                <table style="width: 100%;">
                    <tr>
                        <td style="text-align: right;">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: right;">
                            <asp:Button ID="Button1" runat="server" CssClass="button100" Text="Finish" 
                                onclick="Button2_Click" />
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
        <div style="height: 10px;">
        </div>
        <div class="line">
        </div>
    </div>
</asp:Content>
