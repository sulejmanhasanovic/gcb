<%@ Page Language="C#" MasterPageFile="~/masterpage.Master" AutoEventWireup="true"
    Theme="Default" CodeBehind="ZRNMMissmatches.aspx.cs" Inherits="JIIS.Web.Phase3.Tracking.Results.ZRNMMissmatches"
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
        <%=LanguageText.p2ResultsForm%><hr style="border-width: 0px; background-color: #718ca5;"
            noshade="noshade" />
    </div>
    <div style="height: 10px;">
    </div>
  <div id="MainBody">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <div class="box">
                                    <table cellpadding="0" cellspacing="0" border="0">
                                        <tr>
                                            <td align="left">
                                                <asp:Button ID="btnBack" runat="server" CausesValidation="false" Text="<%$ Resources:LanguageText, PgBBack %>"
                                                    CssClass="button100" OnClick="btnBack_Click" />
                                            </td>
                                            <td align="right" style="width: 100%">
                                                &nbsp;</td>
                                        </tr>
                                    </table>
                                </div>
                <div style="text-align: center;">
                    <asp:Label ID="Label23" runat="server" Text="<%$ Resources:LanguageText, p3_FormTotal %>"></asp:Label>
                </div>
                <asp:Label ID="lblRaceName" runat="server" Text="Label"></asp:Label>
                <br />
                <table style="padding: 0px; margin: 0px; border: 2px solid #000000; width: 100%;
                    border-collapse: collapse;">
                    <tr>
                        <td rowspan="2" style="width: 15%; text-align: center; border: 2px solid #000000;">
                            <asp:Label ID="Label1" runat="server"   Text="<%$ Resources:LanguageText, p3_NameMunicipality%>"></asp:Label>
                        </td>
                        <td rowspan="2" style="text-align: center; border: 2px solid #000000;">
                            <asp:Label ID="lblLevelName" runat="server" Text="Label"></asp:Label>
                            <br />
                            <asp:Label ID="Label24" runat="server" Text="<%$ Resources:LanguageText, p3_NMinorities%>"></asp:Label>
                        </td>
                        <td style="width: 15%; text-align: center; border: 2px solid #000000;">
                            <asp:Label ID="Label3" runat="server"  Text="<%$ Resources:LanguageText, p3_CodeMunicipality%>"></asp:Label>
                        </td>
                        <td style="width: 15%; text-align: center; border: 2px solid #000000;">
                            <asp:Label ID="Label2" runat="server" Text="<%$ Resources:LanguageText, p3_CodePolling %>"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 15%; height: 35px; text-align: center; border: 2px solid #000000;">
                            <asp:Label ID="lblCode" runat="server" Text="Label"></asp:Label>
                        </td>
                        <td style="width: 15%; text-align: center; border: 2px solid #000000;">
                            <asp:Label ID="lblPSCode" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                </table>
                <br />
                   <asp:GridView ID="GridView1" SkinID="KVoteGridView" Width="100%" runat="server" 
                    AutoGenerateColumns="False" DataKeyNames="ID" DataSourceID="SqlDataSource1" >
                    
                       <Columns>
                           <asp:BoundField DataField="ID" HeaderText="ID" SortExpression="ID" Visible="false" />
                           <asp:BoundField DataField="ListNumber" HeaderText="<%$ Resources:LanguageText, de_listNumber %>" 
                               SortExpression="ListNumber" />
                           <asp:BoundField DataField="partyname" HeaderText="<%$ Resources:LanguageText, p1political %>" ReadOnly="True" 
                               SortExpression="partyname" />
                                 <asp:BoundField DataField="candName" HeaderText="<%$ Resources:LanguageText, candidate %>" ReadOnly="True" 
                               SortExpression="candName" />
                           <asp:BoundField DataField="Votes1" HeaderText="<%$ Resources:LanguageText, p3_VotesFirstEntry %>" 
                               SortExpression="Votes1" />
                           <asp:BoundField DataField="Votes2" HeaderText="<%$ Resources:LanguageText, p3_VotesFirstEntry1 %>" ReadOnly="True" 
                               SortExpression="Votes2" />
                           <asp:TemplateField  HeaderText="<%$ Resources:LanguageText, p3_Votes %>"  ItemStyle-Width="10%">
                    <ItemTemplate>
                        <asp:TextBox ID="txtVotes" runat="server" Text="" Width="80%" MaxLength="4" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*"
                            ControlToValidate="txtVotes"></asp:RequiredFieldValidator>
                        <cc1:FilteredTextBoxExtender ID="txtDate_FilteredTextBoxExtender" runat="server"
                            FilterType="Numbers" TargetControlID="txtVotes">
                        </cc1:FilteredTextBoxExtender>
                    </ItemTemplate>
                    <ItemStyle Width="10%" />
                </asp:TemplateField>    
                       </Columns>
                    
                </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:BVOTEConnectionString %>" 
                    SelectCommand="RESULTS_GetVGForMissmatchesTracking" SelectCommandType="StoredProcedure">
                    <SelectParameters>
                        <asp:SessionParameter Name="pscode" SessionField="pscode" Type="String" />
                        <asp:SessionParameter Name="level" SessionField="level" Type="String" />
                        <asp:SessionParameter Name="race" SessionField="idrace" Type="Decimal" />
                    </SelectParameters>
                </asp:SqlDataSource>
                <br />
                <table style="width: 100%;">
                    <tr>
                        <td style="text-align: right;">
                            <asp:Button ID="Button1" runat="server" Text="<%$ Resources:LanguageText, BSave  %>" CssClass="button100" 
                                onclick="Button1_Click" />
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