<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SearchVoters.aspx.cs"
    Inherits="JIIS.Web.Phase3.Tracking.SearchVoters" MasterPageFile="~/masterpage.Master" Theme="Default" %>

<%@ Import Namespace="Resources" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphContent" runat="server">
    <div id="PageTitle">
        <%=LanguageText.searchVoters%><hr style="border-width: 0px; background-color: #718ca5;"
            noshade="noshade" />
    </div>
    <div id="MainBody">
        <div style="height: 3px;">
        </div>
        <table width="100%" cellpadding="0" cellspacing="0" frame="void" style="padding: 0px;
            margin: 0px">
            <tr>
                <td>
                    <div id="Div3">
                        <div class="box">
                            <table cellpadding="0" cellspacing="0" border="0">
                                <tr>
                                    <td align="left">
                                        <asp:Button ID="btnBack" runat="server" CausesValidation="false" Text="<%$ Resources:LanguageText, PgBBack %>"
                                            CssClass="button100" OnClick="btnBack_Click" />
                                    </td>
                                    <td align="right" style="width: 100%">
                                        &nbsp;
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                </td>
            </tr>
        </table>
        <br />
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <table style="width: 100%;" border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td class="left_table_cell" style="width:35%">
                            &nbsp;&nbsp;&nbsp;
                            <asp:Label ID="Label6" runat="server" Text="<%$Resources:LanguageText, de_jmbg%>" CssClass="text12_normal" 
                                ></asp:Label>
                        </td>
                        <td class="right_table_cell" colspan="2">
                            <asp:TextBox ID="TextBox2" runat="server" CssClass="text_box_bih_80percent" 
                                MaxLength="50" Width="400px"></asp:TextBox>
                            <cc1:TextBoxWatermarkExtender ID="TextBox2_TextBoxWatermarkExtender" 
                                runat="server" Enabled="True" TargetControlID="TextBox2" 
                                WatermarkCssClass="watermark" 
                                WatermarkText="<%$ Resources:LanguageText, choosejmb %>">
                            </cc1:TextBoxWatermarkExtender>
                        </td>
                    </tr>                
                    <tr>
                        <td class="left_table_cell" style="width:35%">
                            <asp:Label ID="Label7" runat="server" Text="<%$Resources:LanguageText, de_FirstName%>" CssClass="text12_normal"></asp:Label></td><td class="right_table_cell" colspan="2"><asp:TextBox ID="TextBox3" runat="server" CssClass="text_box_bih_80percent" 
                                MaxLength="50" Width="400px"></asp:TextBox></td></tr><tr>
                        <td class="left_table_cell" style="width:35%">
                            <asp:Label ID="Label8" runat="server" Text="<%$Resources:LanguageText, de_LastName%>" CssClass="text12_normal" ></asp:Label></td><td class="right_table_cell" colspan="2">
                            <asp:TextBox ID="TextBox4" runat="server" CssClass="text_box_bih_80percent" 
                                MaxLength="50" Width="400px"></asp:TextBox><cc1:TextBoxWatermarkExtender ID="TextBox4_TextBoxWatermarkExtender" 
                                runat="server" Enabled="True" TargetControlID="TextBox4" 
                                WatermarkCssClass="watermark" 
                                WatermarkText="Unesite prezime">
                            </cc1:TextBoxWatermarkExtender>
                        </td>
                    </tr>
                    <tr>
                        <td class="left_table_cell" style="width:35%">
                            <asp:Label ID="Label1" runat="server" Text="<%$Resources:LanguageText, de_ElectionPlace%>"  CssClass="text12_normal" ></asp:Label></td><td class="right_table_cell" colspan="2">
                            <asp:TextBox ID="TextBox1" runat="server" CssClass="text_box_bih_80percent" 
                                MaxLength="50" Width="400px"></asp:TextBox><cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" 
                                runat="server" Enabled="True" TargetControlID="TextBox1" 
                                WatermarkCssClass="watermark" 
                                WatermarkText="Unesite biracko mjesto">
                            </cc1:TextBoxWatermarkExtender>
                        </td>
                    </tr>
                    <tr>
                        <td class="left_table_cell" style="width:35%">
                            &nbsp;</td><td class="right_table_cell" colspan="2">
                            &nbsp;&nbsp;&nbsp;&nbsp;
                            <cc1:TextBoxWatermarkExtender ID="TextBox3_TextBoxWatermarkExtender" runat="server"
                                Enabled="True" TargetControlID="TextBox3" WatermarkCssClass="watermark" WatermarkText="<%$ Resources:LanguageText, choosename %>">
                            </cc1:TextBoxWatermarkExtender>
                            <asp:Button ID="Button1" runat="server" CssClass="button120" 
                                OnClick="Button1_Click" Text="<%$ Resources:LanguageText, search %>" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <hr style="border-width: 0px; background-color: #718ca5;" noshade="noshade" />
                            <asp:GridView ID="gvOrgUnits" runat="server" AllowPaging="True" AllowSorting="True"
                                AutoGenerateColumns="False" DataSourceID="dbVoters" OnRowDataBound="gvOrgUnits_RowDataBound"
                                RowStyle-Wrap="True" SkinID="KVoteGridView" Width="95%" PageSize="50">
                                <RowStyle Wrap="True" />
                                <Columns>
                                    <asp:BoundField DataField="PersonalID" HeaderText="PersonalID"
                                        SortExpression="PersonalID" ItemStyle-Width="20px" 
                                        ItemStyle-HorizontalAlign="Center">
                                        <ItemStyle HorizontalAlign="Center" Width="20px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="FirstName" HeaderText="FirstName"
                                        SortExpression="FirstName" ItemStyle-Width="20%">
                                        <ItemStyle Width="20%" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="LastName" HeaderText="LastName"
                                        SortExpression="LastName">
                                    </asp:BoundField>
                                    <asp:BoundField DataField="CurrentMunicipalityCode" HeaderText="CurrentMunicipalityCode"
                                        SortExpression="CurrentMunicipalityCode">
                                    </asp:BoundField>
                                    <asp:BoundField DataField="TypeOfPollingStationCode" 
                                        HeaderText="TypeOfPollingStationCode" 
                                        SortExpression="TypeOfPollingStationCode" />
                                    <asp:BoundField DataField="IsScanned" HeaderText="IsScanned" 
                                        SortExpression="IsScanned" />
                                </Columns>
                                <EmptyDataTemplate>
                                    <table style="width: 100%">
                                        <tr>
                                            <td align="center">
                                                <asp:Label ID="lblNoData" runat="server" CssClass="text12_normal" Text="<%$ Resources:LanguageText, noData %>"></asp:Label></td></tr></table></EmptyDataTemplate></asp:GridView><hr style="border-width: 0px; background-color: #718ca5;" noshade="noshade" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:SqlDataSource ID="dbVoters" runat="server" 
                                ConnectionString="<%$ ConnectionStrings:BVOTEConnectionString %>" 
                                DeleteCommand="BDELETECandidatesbyIDPF" DeleteCommandType="StoredProcedure" 
                                ProviderName="System.Data.SqlClient" SelectCommand="p3_GetScannedVoters" 
                                SelectCommandType="StoredProcedure">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="TextBox3" Name="Ime" PropertyName="Text" 
                                        Type="String" />
                                    <asp:ControlParameter ControlID="TextBox2" Name="JMB" PropertyName="Text" 
                                        Type="String" />
                                    <asp:ControlParameter ControlID="TextBox4" Name="Prezime" PropertyName="Text"
                                    Type="String" />
                                    <asp:ControlParameter ControlID="TextBox1" Name="BirackoMjesto" 
                                        PropertyName="Text" />
                                </SelectParameters>
                                <DeleteParameters>
                                    <asp:Parameter Name="ID" Type="Int32" />
                                </DeleteParameters>
                            </asp:SqlDataSource>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
        <div style="height: 3px;">
        </div>
        <div style="height: 10px;">
        </div>
    </div>
</asp:Content>
