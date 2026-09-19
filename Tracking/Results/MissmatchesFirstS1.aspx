<%@ Page Language="C#" MasterPageFile="~/masterpage.Master" AutoEventWireup="true"
    CodeBehind="MissmatchesFirstS1.aspx.cs" Inherits="JIIS.Web.Phase3.Tracking.Results.MissmatchesFirstS1"
    Title="Untitled Page" Theme="Default" %>

<%@ Import Namespace="Resources" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="CrystalDecisions.Web,  Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphContent" runat="server">
    <div id="PageTitle">
        <%=LanguageText.p3_ResultsMismatches%><hr style="border-width: 0px; background-color: #718ca5;"
            noshade="noshade" />
    </div>
    <div id="MainBody">
        <div style="height: 3px;">
        </div>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
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
                <table width="100%" cellpadding="0" cellspacing="0" frame="void" style="padding: 0px;
                    margin: 0px">
                    <tr>
                        <td>
                            <div id="Div3">
                              
                            </div>
                        </td>
                    </tr>
                    <table style="width: 100%;">
                        
                           <div id="divStatus1" align="left" visible="false" runat="server">
                        <tr>                     
                            <td class="left_table_cell">
                            </td>                                 
                            <td class="right_table_cell">                              
                   <asp:Button ID="btnStat" runat="server" Text="Stat" 
                       CssClass="button120" onclick="btnStat_Click"/>                           
               
               </td>
                        </tr>
                        </div> 
                        <div id="divStatus2" align="left" visible="false" runat="server">
                        <tr>
                    <td class="left_table_cell">
                        </td>
                    <td class="right_table_cell">
              
           <asp:Button ID="btnVG" runat="server" Text="VG" 
                CssClass="button120" onclick="btnVG_Click"/>
               
               </td>
                    </tr>
                    </div>
                     <div id="divStatus3" runat="server" align="left" visible="false">
                    <tr>
                            <td class="left_table_cell">
                               </td>
                            <td class="right_table_cell">
                                
                   <asp:Button ID="btnNM" runat="server" Text="NM"
                        CssClass="button120" onclick="btnNM_Click" />
             </td>
                        </tr>
                          </div>
                          <div id="divStatus4" align="left" visible="false" runat="server">
                        <tr>
                            <td class="left_table_cell">
                                </td>
                            <td class="right_table_cell">
                               
                  <asp:Button ID="btnOL" runat="server" Text="OL"  
                        CssClass="button120" onclick="btnOL_Click"/>
            
               </td>
                        </tr>
                           </div>
                           <div id="divP" runat="server" visible="false">
                        <tr>
                            <td class="left_table_cell">
                            </td>
                            <td class="right_table_cell">
                                <asp:GridView ID="GridView1" SkinID="KVoteGridView" Width="100%" runat="server" 
                                    AutoGenerateColumns="False"
                                    DataSourceID="SqlDataSource1">
                                    <Columns>  
                                      
                
                                 
                                <%--    <asp:BoundField DataField="FKFinalCandidateList" 
                                            HeaderText="FKFinalCandidateList" SortExpression="FKFinalCandidateList" />--%>
                                       <%-- <asp:BoundField DataField="FKFinalCandidateList" HeaderText="FKFinalCandidateList" 
                                            SortExpression="FKFinalCandidateList" /> --%>                                
                                        <asp:BoundField DataField="party" HeaderText="party" ReadOnly="True" 
                                            SortExpression="party" />
                                             <asp:HyperLinkField DataNavigateUrlFields="FKFinalCandidateList" DataNavigateUrlFormatString="ZROLPartyMissmatches.aspx?ID={0}" Text="IZBERETE" />
                                    </Columns>
                                </asp:GridView>
                                <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                                    ConnectionString="<%$ ConnectionStrings:BVOTEConnectionString %>" 
                                    SelectCommand="Results_GetPECandidatesForMissmatchTracking" 
                                    SelectCommandType="StoredProcedure">
                                    <SelectParameters>
                                        <asp:SessionParameter Name="pscode" SessionField="pscode" Type="String" />
                                        <asp:SessionParameter Name="race" SessionField="idrace" Type="Int32" />
                                        <asp:SessionParameter Name="levelcode" SessionField="level" Type="String" />
                                    </SelectParameters>
                                </asp:SqlDataSource>
                               <%-- <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                                    ConnectionString="<%$ ConnectionStrings:BVOTEConnectionString %>" 
                                    SelectCommand="Results_GetPECandidatesForMissmatch" 
                                    SelectCommandType="StoredProcedure">
                                    <SelectParameters>
                                        <asp:SessionParameter Name="pscode" SessionField="pscode" Type="String" />
                                        <asp:SessionParameter Name="race" SessionField="idrace" Type="Int32" />
                                        <asp:SessionParameter Name="levelcode" SessionField="level" Type="String" />
                                    </SelectParameters>
                                </asp:SqlDataSource>--%>
                            </td>
                        </tr>
                        </div>
                    </table>
        <div style="height: 10px;">
        </div>
                <div class="box">
                    <table cellpadding="0" cellspacing="0" border="0" width="100%">
                        <tr>
                            <td align="left">
                                <asp:Button ID="Button5" runat="server" CausesValidation="false" Text="<%$ Resources:LanguageText, PgBBack %>"
                                    CssClass="button100" OnClick="Button5_Click" />
                            </td>
                            <td align="right">
                                &nbsp;</td>
                        </tr>
                    </table>
                </div>
                         
            </ContentTemplate>
        </asp:UpdatePanel>
        <div style="height: 10px;">
        </div>
        <div class="line">
        </div>
    </div>
</asp:Content>
