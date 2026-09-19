<%@ Page Language="C#" MasterPageFile="~/masterpage.Master" AutoEventWireup="true"
    CodeBehind="SetQuarantine.aspx.cs" Inherits="JIIS.Web.Phase3.Tracking.SetQuarantine"
    Theme="Default" %>

<%@ Import Namespace="Resources" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphContent" runat="server">
    <div id="PageTitle">
        <%=LanguageText.p3_previewreceived%><hr style="border-width: 0px; background-color: #718ca5;"
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
                            </tr>
                        </table>
                    </div>
                </div>
                <br />
                <table width="100%">
                    <tr>
                        <td class="left_table_cell">
                            <asp:Label ID="Label1" runat="server" Text="Choose polling station:" CssClass="text12_normal"></asp:Label>
                        </td>
                        <td class="right_table_cell">
                            <asp:DropDownList ID="ddlPollingStation" runat="server" AutoPostBack="True" DataSourceID="sqldsPollingStations"
                                DataTextField="PSCode" DataValueField="PSCode" OnDataBound="ddlPollingStation_DataBound">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <%--<tr>
                        <td class="left_table_cell">
                            <asp:Label ID="Label2" runat="server" Text="Choose material:" CssClass="text12_normal"></asp:Label>
                        </td>
                        <td class="right_table_cell">
                            <asp:DropDownList ID="ddlMaterials" runat="server" DataSourceID="sqldsMaterials"
                                DataTextField="NameMaterial" DataValueField="MID">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="left_table_cell">
                            &nbsp;
                        </td>
                        <td class="right_table_cell">
                            <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click"
                                CssClass="button100" />
                            <%--<asp:Label ID="lblError" runat="server" Text="Theri is no polling station with that code!"
                                CssClass="error_message" Visible="false"></asp:Label>
                        </td>
                    </tr>--%>
                </table>
                <br />
                <asp:GridView ID="gvTracking" runat="server" Width="100%" AutoGenerateColumns="False"
                    DataKeyNames="MID" SkinID="KVoteGridView" DataSourceID="sqldsMaterials" OnRowDataBound="gvTracking_RowDataBound"
                    PageSize="100">
                    <Columns>
                        <asp:TemplateField HeaderText="">
                            <ItemTemplate>
                                <%#Container.DataItemIndex + 1%>
                                <asp:Label ID="lbbroj" runat="server" Text="."></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="5%" />
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="5%" />
                        </asp:TemplateField>
                        <asp:BoundField HeaderText="Material" DataField="NameMaterial">
                            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="35" />
                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="35%" />
                        </asp:BoundField>
                        <%--<asp:BoundField HeaderText="Quarantine" DataField="Quarantine">
                            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="35" />
                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="35%" />
                        </asp:BoundField>--%>
                        <asp:TemplateField HeaderText="Quarantine">
                            <ItemTemplate>
                                <asp:Label ID="lblQuarantine" runat="server" Text="<%# Bind('Quarantine') %>"></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="35" />
                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="35%" />
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="linkQuarantine" runat="server" Text="Quarantine" Font-Underline="false"
                                    OnClick="linkQuarantine_Click"></asp:LinkButton>
                                <asp:LinkButton ID="linkUnQuarantine" runat="server" Text="Unquarantine" Font-Underline="false"
                                    OnClick="linkUnQuarantine_Click"></asp:LinkButton>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="25" />
                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="25%" />
                        </asp:TemplateField>
                    </Columns>
                    <EmptyDataTemplate>
                        <table style="width: 100%">
                            <tr>
                                <td align="center">
                                    <asp:Label ID="lblNoData" runat="server" Text="<%$ Resources:LanguageText, noData %>"
                                        CssClass="text12_normal"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </EmptyDataTemplate>
                </asp:GridView>
                <div style="height: 10px;">
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:SqlDataSource ID="sqldsPollingStations" runat="server" ConnectionString="<%$ ConnectionStrings:BVOTEConnectionString %>"
            SelectCommand="p3_getAllPollingStations" SelectCommandType="StoredProcedure">
        </asp:SqlDataSource>
        <asp:SqlDataSource ID="sqldsMaterials" runat="server" ConnectionString="<%$ ConnectionStrings:BVOTEConnectionString %>"
            SelectCommand="p3_getMaterialIDFromPSM" SelectCommandType="StoredProcedure">
            <SelectParameters>
                <asp:SessionParameter Name="lang" SessionField="language" Type="Int32" DefaultValue="1" />
                <asp:ControlParameter ControlID="ddlPollingStation" Name="code" PropertyName="SelectedValue"
                    Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
        <div style="height: 10px;">
        </div>
        <div class="line">
        </div>
    </div>
</asp:Content>
