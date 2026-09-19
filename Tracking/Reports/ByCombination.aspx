<%@ Page Language="C#" MasterPageFile="~/masterpage.Master" AutoEventWireup="true" EnableEventValidation="false"
    CodeBehind="ByCombination.aspx.cs" Inherits="JIIS.Web.Phase3.Tracking.Reports.ByCombination" Title="<%$Resources:LanguageText, tr_bagReceive%>"
    Theme="Default" %>

<%@ Import Namespace="Resources" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContent" runat="server">
    <div id="PageTitle">
        <%=LanguageText.zt_reportsByCombinations%><hr style="border-width: 0px; background-color: #718ca5;"
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
                                    &nbsp;</td>
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
                            Vrsta
                        </td>
                        <td class="right_table_cell">
                            <asp:DropDownList ID="ddlModes" runat="server" DataSourceID="SqlModes" 
                                DataTextField="Description" DataValueField="Description" 
                                AutoPostBack="True">
                            </asp:DropDownList>
                            <asp:SqlDataSource ID="SqlModes" runat="server" 
                                ConnectionString="<%$ ConnectionStrings:BVOTEConnectionString %>" SelectCommand="select '0','Sve' as Description
union
SELECT * FROM [P3_mode]"></asp:SqlDataSource>
                        </td>
                    </tr>
                    <tr>
                        <td class="left_table_cell">
                            Vreæa&nbsp;
                        </td>
                        <td class="right_table_cell">
                            <asp:DropDownList ID="ddlBags" runat="server" AutoPostBack="True" 
                                DataSourceID="SqlBags" DataTextField="PollingStationCode" 
                                DataValueField="PollingStationCode">
                            </asp:DropDownList>
                            <asp:SqlDataSource ID="SqlBags" runat="server" 
                                ConnectionString="<%$ ConnectionStrings:BVOTEConnectionString %>" 
                                SelectCommand="SELECT 0 as Sort, 'Sve' AS PollingStationCode UNION SELECT 1 as Sort,PollingStationCode FROM p3_Bags">
                            </asp:SqlDataSource>
                        </td>
                    </tr>
                    <tr>
                        <td class="left_table_cell">
                            Pregled po vrećama i statusima</td>
                        <td class="right_table_cell">
                            <asp:Button ID="Button1" runat="server" CssClass="button100" 
                                onclick="Button1_Click" Text="<%$Resources:LanguageText, cbestatus%>" />
                        </td>
                    </tr>
                    <tr runat="server" id="brP">
                        <td class="left_table_cell">
                            Pregled po kombinacijama i kategorijama</td>
                        <td class="right_table_cell">
                            <asp:Button ID="Button2" runat="server" CssClass="button100" 
                                Text="<%$Resources:LanguageText, cbestatus%>" 
                                PostBackUrl="~/Phase3/Tracking/Reports/ByCombinationSecond.aspx" />
                        </td>
                    </tr>
                    <tr>
                    <td class="left_table_cell">
                     <asp:Label ID="Label1" runat="server" 
                                Text="Pregled obrađenog materijala"></asp:Label>
                        &nbsp;(excel)</td>
                    <td  class="right_table_cell">
                    <asp:Button ID="btnThird" runat="server" CssClass="button100" 
                                Text="<%$Resources:LanguageText, cbestatus%>" 
                            onclick="btnThird_Click" />
                    </td>
                    </tr>
                    <tr>
                        <td class="left_table_cell">
                            Izvještaj po razlozima odbijanja (excel)</td>
                        <td class="right_table_cell">
                            <asp:Button ID="btnForth" runat="server" CssClass="button100" 
                                onclick="btnForth_Click" Text="<%$Resources:LanguageText, cbestatus%>" />
                        </td>
                    </tr>
                    <tr>
                        <td class="left_table_cell">
                            Izvještaj kombinacije kutije (excel)</td>
                        <td class="right_table_cell">
                            <asp:Button ID="btnFive" runat="server" CssClass="button100" 
                                onclick="btnFive_Click" Text="<%$Resources:LanguageText, cbestatus%>" />
                        </td>
                    </tr>
                </table>
                
                
                
                <br />
                <br />
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <div style="height: 10px;">
    </div>
    <div class="line">
    </div>
    </asp:Content>
