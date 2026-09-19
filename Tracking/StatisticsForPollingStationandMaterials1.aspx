<%@ Page Language="C#" MasterPageFile="~/masterpage.Master" AutoEventWireup="true"
    CodeBehind="StatisticsForPollingStationandMaterials1.aspx.cs" Inherits="JIIS.Web.Phase3.Tracking.StatisticsForPollingStationandMaterials1"
    Title="Untitled Page" Theme="Default" %>

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
                                    &nbsp;
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
                <table width="100%">
                    <tr>
                        <td>
                            <asp:GridView ID="GridView1" runat="server" Width="100%" SkinID="KVoteGridView" AutoGenerateColumns="False"
                                DataSourceID="SqlDataSource1" onrowdatabound="GridView1_RowDataBound" 
                                ondatabinding="GridView1_DataBinding" PageSize="20">
                                <Columns>
                                    <asp:TemplateField HeaderText="<%$Resources:LanguageText, p3_CodeMunicipality%>"
                                        SortExpression="MunicipalityCode">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox1" runat="server" 
                                                Text='<%# Bind("MunicipalityCode") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("MunicipalityCode") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="MunicipalityName" HeaderText="<%$Resources:LanguageText, p3_NameMunicipality%>" 
                                        SortExpression="MunicipalityName" />
                                    <asp:TemplateField HeaderText="<%$Resources:LanguageText, tr_psCode%>"  SortExpression="psCode" >
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("psCode") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Label2" runat="server" Text='<%# Bind("psCode") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="comment" HeaderText="<%$Resources:LanguageText, PgDocumentUploadIDocumentComment%>"  
                                        SortExpression="comment" />
                                        <asp:TemplateField >
                                        <EditItemTemplate>
                                        
                                             
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            
                                            <asp:HyperLink ID="hpToNotAccepted" runat="server" NavigateUrl='<%# string.Concat("StatisticsForPollingStationandMaterials3.aspx?pathM=", Eval("MunicipalityCode"),"&pathPs=", Eval("psCode"))%>'>
                                    <asp:Image ID="Image1" runat="server" ImageUrl="../../images/tracking.png" /></asp:HyperLink>
                                        </ItemTemplate>
                                    </asp:TemplateField> 
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
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:BVOTEConnectionString %>"
                                SelectCommand="p3getStatisticForPSAndMaterialsAccepted" 
                                SelectCommandType="StoredProcedure">
                                <SelectParameters>
                                    <asp:QueryStringParameter Name="code" QueryStringField="path" Type="String" />
                                </SelectParameters>
                            </asp:SqlDataSource>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
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
