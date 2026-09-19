<%@ Page Language="C#" MasterPageFile="~/masterpage.Master" AutoEventWireup="true"
    CodeBehind="StatisticsForPollingStationandMaterialsData.aspx.cs" Inherits="JIIS.Web.Phase3.Tracking.StatisticsForPollingStationandMaterialsData" Title="Untitled Page"  Theme="Default" %>

<%@ Import Namespace="Resources" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContent" runat="server">
    <div id="PageTitle">
        <%=LanguageText.p3_StatisticsForPolling%><hr style="border-width: 0px; background-color: #718ca5;"
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
                                        CausesValidation="False" OnClick="Button5_Click" />
                                </td>
                                <td style="text-align: right">
                                    &nbsp;</td>
                            </tr>
                        </table>
                    </div>
                </div>
                <table width="100%">
                    <tr>
                        <td>
                            <asp:GridView ID="GridView1" runat="server" Width="100%" SkinID="KVoteGridView"
                                AutoGenerateColumns="False" DataSourceID="SqlDataSource1" >
                                <Columns>
                                        
                                          <asp:BoundField DataField="PSCode" HeaderText="<%$Resources:LanguageText, p3_PollingStation%>"
                                        SortExpression="PSCode" />
                                    <asp:BoundField DataField="NameMaterial" HeaderText="<%$Resources:LanguageText, p3_materialName%>"
                                        SortExpression="NameMaterial" />
                                    <asp:BoundField DataField="currenta" HeaderText="<%$Resources:LanguageText, p3_currentArea%>"
                                        SortExpression="currenta" />
                                       
                                          <asp:BoundField DataField="next" HeaderText="<%$Resources:LanguageText, p3_NextArea%>" ReadOnly="True" 
                                              SortExpression="next" />
                                          <asp:BoundField DataField="Timing"  HeaderText="<%$Resources:LanguageText, fvlTime%>"
                                              SortExpression="Timing" />
                                       
                                </Columns>
                                 <EmptyDataTemplate>
                        <table style="width: 100%">
                            <tr>
                                <td align="center">
                                    <asp:Label ID="lblNoData" runat="server" Text="No Data Found" CssClass="text12_normal"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </EmptyDataTemplate>
                            </asp:GridView>
                           
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                                ConnectionString="<%$ ConnectionStrings:BVOTEConnectionString %>" 
                                SelectCommand="p3getTrackingOfMaterialsforPSCode" 
                                SelectCommandType="StoredProcedure">
                                <SelectParameters>
                                    <asp:SessionParameter Name="language" SessionField="language" Type="Int32" />
                                    <asp:QueryStringParameter Name="PSCode" QueryStringField="path1" Type="String" />
                                </SelectParameters>
                            </asp:SqlDataSource>
                           
                        </td>
                    </tr>
                    <tr>
                        
                        <td>
                            &nbsp;</td>
                    </tr>
                    <div id="poraka" visible="false" runat="server">
                    </div>
                </table>
            </ContentTemplate>
            <Triggers>
                
            </Triggers>
        </asp:UpdatePanel>
    </div>
    <div style="height: 10px;">
    </div>
    <div class="line">
    </div>
</asp:Content>
