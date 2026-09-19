<%@ Page Language="C#" MasterPageFile="~/masterpage.Master" AutoEventWireup="true"
    CodeBehind="StatisticsForIntakeOfPollingStations.aspx.cs" Inherits="JIIS.Web.Phase3.Tracking.StatisticsForIntakeOfPollingStations"
    Theme="Default" %>

<%@ Import Namespace="Resources" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphContent" runat="server">
    <div id="PageTitle">
        <%=LanguageText.p3_mMaterialsIntake%><hr style="border-width: 0px; background-color: #718ca5;"
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
                <br />
            
                <asp:GridView ID="gvUsers" runat="server" AutoGenerateColumns="False" SkinID="KVoteGridView"
                    PageSize="1000" DataSourceID="SqlDataSource1" Width="100%" 
                   >
                    <Columns>
                           <asp:BoundField DataField="MunicipalityCode" HeaderText= "MunicipalityCode"
                            SortExpression="MunicipalityCode" />
                        <asp:BoundField DataField="MunicipalityName" HeaderText= "MunicipalityName"   ItemStyle-HorizontalAlign="Left"
                            SortExpression="MunicipalityName" >
                        </asp:BoundField>
                         <asp:BoundField DataField="total" HeaderText="total" ReadOnly="True" 
                            SortExpression="total" />
                        <asp:BoundField DataField="received" HeaderText="received" ReadOnly="True" 
                            SortExpression="received" />
                        <asp:BoundField DataField="notreceived" HeaderText="notreceived" 
                            ReadOnly="True" SortExpression="notreceived" />
                      
                      
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
                    SelectCommand="p3_getStatisticsFor_p3_IntakePs" 
                    SelectCommandType="StoredProcedure"></asp:SqlDataSource>
              
                <div id="Div1" visible="false" runat="server">
                    <div class="box">
                        <table cellpadding="0" cellspacing="0" border="0" width="100%">
                            <tr>
                                <td style="text-align: left">
                                    <asp:Button ID="Button1" runat="server" CssClass="button100" Text="<%$Resources:LanguageText, bback%>"
                                        CausesValidation="False" OnClick="Button5_Click" />
                                </td>
                                <td style="text-align: right">
                                    &nbsp;</td>
                            </tr>
                        </table>
                    </div>
                </div>
                <div style="height: 10px;">
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        <div style="height: 10px;">
        </div>
        <div class="line">
        </div>
    </div>
</asp:Content>
