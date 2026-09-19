<%@ Page Language="C#" MasterPageFile="~/masterpage.Master" AutoEventWireup="true"
    Theme="Default" CodeBehind="CCZR_VecinskiGlas2.aspx.cs" Inherits="JIIS.Web.Phase3.Tracking.Results.CCZR_VecinskiGlas2"
    Title="BiH-Vote" %>

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
        <%=LanguageText.p3_inputPP%><hr style="border-width: 0px; background-color: #718ca5;"
            noshade="noshade" />
    </div>
    <div style="height: 10px;">
    </div>
    <div id="MainBody">
        <%-- <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
            <ContentTemplate>--%>
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
            <asp:Label ID="Label23" runat="server" Text="<%$ Resources:LanguageText, p3_FormTotal %>"></asp:Label>
        </div>
        <asp:Label ID="lblRace" runat="server" Style="font-size: large" Text="Label"></asp:Label>
        <br />
        <asp:Label ID="lblPS" runat="server" Style="text-align: center; font-size: large"
            Text="Label"></asp:Label>
        <br />
        <table style="padding: 0px; margin: 0px; border: 2px solid #000000; width: 100%;
            border-collapse: collapse;">
            <tr>
                <td rowspan="2" style="width: 15%; text-align: center; border: 2px solid #000000;">
                    <asp:Label ID="Label1" runat="server" Text="<%$ Resources:LanguageText, candidateregion%>"></asp:Label>
                </td>
                <td rowspan="2" style="text-align: center; border: 2px solid #000000;">
                    <asp:Label ID="lblLevelName" runat="server" Text="Label"></asp:Label>
                    <br />
                    <asp:Label ID="lblLevelCode" runat="server" Text="Label"></asp:Label>
                </td>
                <td style="width: 15%; text-align: center; border: 2px solid #000000;">
                    <asp:Label ID="Label3" runat="server" Text="<%$ Resources:LanguageText, rt_kategorija%>"></asp:Label>
                </td>
                <td style="width: 15%; text-align: center; border: 2px solid #000000;">
                    <asp:Label ID="Label2" runat="server" Text="<%$ Resources:LanguageText, rt_kutija %>"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 15%; height: 35px; text-align: center; border: 2px solid #000000;">
                    &nbsp;<asp:Label ID="lblKategorija" runat="server" Text="Label"></asp:Label>
                    &nbsp;
                </td>
                <td style="width: 15%; text-align: center; border: 2px solid #000000;">
                    <asp:Label ID="lblPSCode" runat="server" Text="Label"></asp:Label>
                    &nbsp;
                </td>
            </tr>
        </table>
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
            DisplayMode="SingleParagraph" 
            HeaderText="SVA POLJA NISU UNESENA / СВИ ПОЈЛА НИСУ УНЕСЕНА" 
            ShowMessageBox="True" ShowSummary="False" />
        <br />
        <asp:GridView ID="GridView1" SkinID="KVoteGridView" Width="100%" runat="server" AutoGenerateColumns="False"
            DataKeyNames="ID" DataSourceID="SqlDataSource1" PageSize="100" OnRowDataBound="GridView1_RowDataBound">
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="ID" ReadOnly="True" SortExpression="ID"
                    Visible="False" />
                <asp:BoundField DataField="ListNumber" HeaderText="<%$ Resources:LanguageText, candidatelistposition %>" ItemStyle-Width="10%"
                    />
                <asp:BoundField DataField="PartyName" HeaderText="<%$ Resources:LanguageText, de_politicalEntity %>" ItemStyle-Width="50%"
                     />
                <asp:BoundField DataField="ListPosition" Visible="false" HeaderText="ListPosition"
                    SortExpression="ListPosition" />
                <asp:BoundField DataField="CandName" HeaderText="<%$ Resources:LanguageText, candidate %>" ItemStyle-Width="30%"
                    ReadOnly="True" />
                <asp:BoundField DataField="Gender" Visible="false" HeaderText="Gender" SortExpression="Gender" />
                <asp:TemplateField ItemStyle-Width="10%" HeaderText="<%$ Resources:LanguageText, p3_TotalVotes %>">
                    <ItemTemplate>
                        <asp:TextBox ID="txtVotes" runat="server" Width="80%" MaxLength="4" style="text-align:right"/>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*"
                            ControlToValidate="txtVotes"></asp:RequiredFieldValidator>
                        <cc1:FilteredTextBoxExtender ID="txtDate_FilteredTextBoxExtender" runat="server"
                            FilterType="Numbers" TargetControlID="txtVotes">
                        </cc1:FilteredTextBoxExtender>
                    </ItemTemplate>
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
                <asp:SessionParameter Name="fkRace" SessionField="idrace" Type="Decimal" />
                <asp:SessionParameter DefaultValue="" Name="levelCode" SessionField="level" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
        <br />
        <table style="width: 100%;">
            <tr>
                <td style="text-align: right;">
                    <asp:Button ID="Button1" runat="server" Text="Snimi" CssClass="button100" Visible="false"
                        OnClick="Button1_Click" />
                </td>
            </tr>
        </table>
        <table>
            <tr>
                <td>
                    <asp:Label ID="lblCheck1" runat="server" Visible="false" Text="<%$Resources:LanguageText, p3_erorDS%>"
                        ForeColor="Red"></asp:Label>
                </td>
            </tr>
        </table>
        <%-- </ContentTemplate>
        </asp:UpdatePanel>--%>
        <%--<asp:Panel ID="Panel3" runat="server" Style="z-index: 100; left: 34%; position: absolute;
            top: 50%; width: 645px; height: 81px;" Visible="False" Wrap="false">
            <asp:Panel ID="Panel2" runat="server" Style="cursor: move; background-color: #DDDDDD;
                border: solid 1px Gray; color: Black" Height="80px" Width="647px">
                <div>
                    <p>
                        <asp:Label ID="Label24" runat="server" Text="<%$ Resources:LanguageText, p3_ErrorEntry %>"
                            Font-Size="X-Large" ForeColor="Red"></asp:Label>
                    </p>
                    <p style="text-align: center;">
                        <asp:Button ID="okButton" runat="server" CssClass="button120" OnClick="okButton_Click"
                            Text="<%$ Resources:LanguageText, ok %>" />
                    </p>
                </div>
            </asp:Panel>
        </asp:Panel>--%>
        <div style="height: 10px;">
        </div>
        <div class="line">
        </div>
    </div>
</asp:Content>
