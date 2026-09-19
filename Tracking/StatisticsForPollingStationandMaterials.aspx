<%@ Page Language="C#" MasterPageFile="~/masterpage.Master" AutoEventWireup="true"
    CodeBehind="StatisticsForPollingStationandMaterials.aspx.cs" Inherits="JIIS.Web.Phase3.Tracking.StatisticsForPollingStationandMaterials"
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
                                    <asp:TextBox ID="txtSearch" runat="server" AutoPostBack="True" ToolTip="Insert ps code"></asp:TextBox>
                                    <asp:Button ID="btnSearch" runat="server" Text="<%$Resources:LanguageText, PgBSearch%>"
                                        CssClass="button100" OnClick="btnSearch_Click" />
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
                <table width="100%">
                    <tr>
                        <td>
                            <asp:GridView ID="GridView1" runat="server" Width="100%" SkinID="KVoteGridView" AutoGenerateColumns="False"
                                PageSize="200" OnRowDataBound="GridView1_RowDataBound">
                                <Columns>
                                    <asp:TemplateField HeaderText="<%$Resources:LanguageText, p3_CodeMunicipality%>">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox1" runat="server" Text="<%$Resources:LanguageText, p3_CodeMunicipality%>"></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("MunicipalityCode") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="MunicipalityName" HeaderText="<%$Resources:LanguageText, p3_NameMunicipality%>" />
                                    <asp:BoundField DataField="ps" HeaderText="<%$Resources:LanguageText, p3_PollingStation1%>"
                                        ReadOnly="True" />
                                    <asp:TemplateField HeaderText="<%$Resources:LanguageText, p3_PollingStationAccepted%>">
                                        <EditItemTemplate>
                                            <asp:Label ID="Label2" runat="server" Text='<%# Eval("Expr1") %>'></asp:Label>
                                            &nbsp
                                            <asp:HyperLink ID="hpToAccepted" runat="server" NavigateUrl='<%# string.Concat("StatisticsForPollingStationandMaterials1.aspx?path=", Eval("MunicipalityCode"))%>'>
                                                <asp:Image ID="Image1" runat="server" ImageUrl="../../images/tracking.png" /></asp:HyperLink>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Label2" runat="server" Text='<%# Bind("Expr1") %>'></asp:Label>
                                            &nbsp
                                            <asp:HyperLink ID="hpToAccepted" runat="server" NavigateUrl='<%# string.Concat("StatisticsForPollingStationandMaterials1.aspx?path=", Eval("MunicipalityCode"))%>'>
                                                <asp:Image ID="Image3" runat="server" ImageUrl="../../images/tracking.png" /></asp:HyperLink>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="<%$Resources:LanguageText, p3_PollingStationsWaitingTobeA%>">
                                        <EditItemTemplate>
                                            <asp:Label ID="Label3" runat="server" Text='<%# Eval("diference") %>'></asp:Label>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Label3" runat="server" Text='<%# Bind("diference") %>'></asp:Label>
                                            <asp:HyperLink ID="hpToNotAccepted" runat="server" NavigateUrl='<%# string.Concat("StatisticsForPollingStationandMaterials2.aspx?path1=", Eval("MunicipalityCode"))%>'>
                                                <asp:Image ID="Image2" runat="server" ImageUrl="../../images/tracking.png" /></asp:HyperLink>
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
