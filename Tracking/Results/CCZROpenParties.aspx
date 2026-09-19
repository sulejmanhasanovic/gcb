<%@ Page Language="C#" MasterPageFile="~/masterpage.Master" AutoEventWireup="true"
    Theme="Default" CodeBehind="CCZROpenParties.aspx.cs" Inherits="JIIS.Web.Phase3.Tracking.Results.CCZROpenParties"
    Title="Untitled Page" %>

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
        <%=LanguageText.p3_zrOpen%><hr style="border-width: 0px; background-color: #718ca5;"
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
            <asp:Label ID="Label23" runat="server" Text="<%$ Resources:LanguageText, p3_FormTotalOPen%>"></asp:Label>
        </div>
        <asp:Label ID="lblRace" runat="server" Style="font-size: large" Text="Label"></asp:Label>
        <br />
                 <asp:Label ID="lblPS" runat="server" 
                    style="text-align: center; font-size: large" Text="Label"></asp:Label>
        <br />
        <table style="padding: 0px; margin: 0px; border: 2px solid #000000; width: 100%;
            border-collapse: collapse;">
            <tr>
                <td rowspan="2" style="width: 15%; text-align: center; border: 2px solid #000000;">
                    <asp:Label ID="Label1a" runat="server" Text="<%$ Resources:LanguageText, candidateregion%>"></asp:Label>
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
                    <asp:Label ID="Label1" runat="server" Text="<%$ Resources:LanguageText, rt_kutija %>"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 15%; height: 35px; text-align: center; border: 2px solid #000000;">
                    <asp:Label ID="lblKategorija" runat="server" Text="Label"></asp:Label>
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
                <td style="text-align: left; width: 85%;">
                    <asp:Label ID="lblListPos" runat="server" CssClass="text16_normal" Text="Label"></asp:Label>
                    .
                    <asp:Label ID="lblPEName" runat="server" CssClass="text14_normal" Text="Label"></asp:Label>
                </td>
                <td style="text-align: right; width: 15%;">
                    <asp:Label ID="lblCurrent" runat="server" Text="Label"></asp:Label>
                    &nbsp;/
                    <asp:Label ID="lblTotal" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="2" style="text-align: right;">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td style="text-align: left;">
                    <asp:Label ID="Label24" runat="server" CssClass="text12_normal" Text="Votes"></asp:Label>
                    :
                    <asp:Label ID="lblVotes" runat="server" CssClass="text12_normal" Text="Label"></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="Button5" runat="server" CausesValidation="False" 
                        CssClass="button100" onclick="Button5_Click" Text="<%$Resources:LanguageText, p3AllVotesZero%>" />
                </td>
                <td style="text-align: right;">
                    <asp:Button ID="Button3" runat="server" CssClass="button100" OnClick="Button4_Click"
                        Text="<%$Resources:LanguageText, Finish%>" Visible="False" />
                    <asp:Button ID="Button2" runat="server" CssClass="button100" OnClick="Button1_Click"
                        Text="<%$Resources:LanguageText, bNext%>" />
                </td>
            </tr>
            <tr>
                <td colspan="2" style="text-align: right;">
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
                        DisplayMode="SingleParagraph" 
                        HeaderText="SVA POLJA NISU UNESENA / СВИ ПОЈЛА НИСУ УНЕСЕНА" 
                        ShowMessageBox="True" ShowSummary="False" />
                </td>
            </tr>
            <tr>
                <td style="text-align: right;" colspan="2">
                    <asp:GridView ID="GridView1" SkinID="KVoteGridView" Width="100%" runat="server" AutoGenerateColumns="False"
                        DataKeyNames="ID" DataSourceID="SqlDataSource1" Style="text-align: left" PageSize="100">
                        <Columns>
                            <asp:BoundField DataField="ID" HeaderText="ID" ReadOnly="True" SortExpression="ID"
                                Visible="False" />
                            <asp:BoundField DataField="ListPosition" ItemStyle-Width="10%" HeaderText="<%$ Resources:LanguageText, de_listPosition %>"
                                >
                                <ItemStyle Width="10%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="candname" ItemStyle-Width="70%" HeaderText="<%$ Resources:LanguageText, candidate %>"
                                ReadOnly="True">
                                <ItemStyle Width="70%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Gender" Visible="false" ItemStyle-Width="10%" HeaderText="<%$ Resources:LanguageText, de_gender %>"
                                SortExpression="Gender">
                                <ItemStyle Width="10%" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="<%$ Resources:LanguageText, p3_Votes %>" ItemStyle-Width="10%">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtVotes" runat="server" Width="80%" MaxLength="4" style="text-align:right"/>
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
                        SelectCommand="RESULTSGetCandidatesForPEOL" SelectCommandType="StoredProcedure">
                        <SelectParameters>
                            <asp:SessionParameter Name="fklist" SessionField="idlista" Type="Decimal" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                </td>
            </tr>
            <tr>
                <td style="text-align: right;" colspan="2">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td style="text-align: right;" colspan="2">
                    &nbsp;</td>
            </tr>
        </table>
        <table>
            <tr>
                <td>
                    <asp:Label ID="lblCheck1" runat="server" Text="!!!Glasovite na kandidatot mora da se pomalku ili ednakvo so glasovite na partijata"
                        Visible="False" ForeColor="Red"></asp:Label>
                </td>
            </tr>
        </table>
        <asp:UpdateProgress ID="uprogressFolderClicked" runat="server" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="0">
            <ProgressTemplate>
                <table class="loaderFolders" border="0">
                    <tr>
                        <td align="center" valign="middle">
                            <img src="../../loading.gif" align="middle" alt="Loading..."
                                title="Loading..." />
                        </td>
                    </tr>
                </table>
            </ProgressTemplate>
        </asp:UpdateProgress>
        <%-- </ContentTemplate>
        </asp:UpdatePanel>--%>
        <%--<asp:Panel ID="Panel3" runat="server" Style="z-index: 100; left: 34%; position: absolute;
            top: 50%; width: 645px; height: 81px;" Visible="False" Wrap="false">
            <asp:Panel ID="Panel2" runat="server" Style="cursor: move; background-color: #DDDDDD;
                border: solid 1px Gray; color: Black" Height="80px" Width="647px">
                <div>
                    <p>
                        <asp:Label ID="Label2" runat="server" Text="<%$ Resources:LanguageText, p3_ErrorEntry %>"
                            Font-Size="X-Large" ForeColor="Red"></asp:Label>
                    </p>
                    <p style="text-align: center;">
                        <asp:Button ID="okButton" runat="server" CssClass="button120" OnClick="okButton_Click"
                            Text="<%$ Resources:LanguageText, ok %>" />
                    </p>
                </div>
            </asp:Panel>--%>
            </ContentTemplate>
        </asp:UpdatePanel>
        <div style="height: 10px;">
        </div>
        <div class="line">
        </div>
    </div>
</asp:Content>
