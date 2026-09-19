<%@ Page Language="C#" MasterPageFile="~/masterpage.Master" AutoEventWireup="true"
    CodeBehind="StatisticsForPollingStationandMaterials3.aspx.cs" Inherits="JIIS.Web.Phase3.Tracking.StatisticsForPollingStationandMaterials3"
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
                            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                                DataSourceID="SqlDataSource1" ondatabinding="GridView1_DataBinding" 
                                onrowdatabound="GridView1_RowDataBound" SkinID="KVoteGridView" Width="100%">
                                <Columns>
                                    <asp:BoundField DataField="MunicipalityCode" HeaderText="<%$Resources:LanguageText, p3_CodeMunicipality%>"
                                        SortExpression="MunicipalityCode" />
                                    <asp:BoundField DataField="MunicipalityName" HeaderText="<%$Resources:LanguageText, p3_NameMunicipality%>" 
                                        SortExpression="MunicipalityName" />
                                        <asp:BoundField DataField="PsCode" HeaderText="<%$Resources:LanguageText, tr_psCode%>"
                                        SortExpression="PsCode" />
                                    <asp:BoundField DataField="Material" HeaderText="<%$Resources:LanguageText, p3_materialName%>" 
                                        SortExpression="Material" />
                                    <asp:TemplateField HeaderText="<%$Resources:LanguageText, p3_received%>"  SortExpression="Received">
                                        <EditItemTemplate>
                                            <asp:CheckBox ID="cb1" runat="server" Checked='<%# Bind("Received") %>' />
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="cb" runat="server" Checked='<%# Bind("Received") %>' 
                                                Enabled="false" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="Comment" HeaderText="<%$Resources:LanguageText, PgDocumentUploadIDocumentComment%>"  
                                        SortExpression="Comment" />
                                </Columns>
                                <EmptyDataTemplate>
                                    <table style="width: 100%">
                                        <tr>
                                            <td align="center">
                                                <asp:Label ID="lblNoData" runat="server" CssClass="text12_normal" 
                                                    Text="No Data Found"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </EmptyDataTemplate>
                            </asp:GridView>
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:BVOTEConnectionString %>"
                                SelectCommand="p3getMaterialsForAcceptedPoll" 
                                SelectCommandType="StoredProcedure">
                                <SelectParameters>
                                    <asp:QueryStringParameter DefaultValue="" Name="code" QueryStringField="pathM" 
                                        Type="String" />
                                    <asp:QueryStringParameter DefaultValue="" Name="psCode" 
                                        QueryStringField="pathPs" Type="String" />
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
