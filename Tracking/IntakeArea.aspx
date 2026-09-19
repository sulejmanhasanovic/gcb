<%@ Page Language="C#" MasterPageFile="~/masterpage.Master" AutoEventWireup="true"
    CodeBehind="IntakeArea.aspx.cs" Inherits="JIIS.Web.Phase3.Tracking.IntakeArea" Theme="Default" %>

<%@ Import Namespace="Resources" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphContent" runat="server">
    <div id="PageTitle">
        <%=LanguageText.p3_previewreceived%><hr style="border-width: 0px; background-color: #718ca5;"
            noshade="noshade" />
    </div>
    <div id="MainBody">
        <div style="height: 3px;">
        </div>
        <asp:HiddenField ID="hdnArea" runat="server" />
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
                                    <asp:Button ID="btnUpdate" runat="server" Text="<%$ Resources:LanguageText, BUpdate %>"
                                        CssClass="button100" OnClick="btnUpdate_Click" ValidationGroup="OrgUnitValidate" />
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
                <br />
                <table width="100%" style="border-width: 2px; border-color: Black;" cellpadding="4">
                    <tr>
                        <td>
                            <table width="100%" style="background-color: Black; color: White">
                                <tr>
                                    <td style="text-align: left">
                                        <asp:Label ID="lblCode" runat="server"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <asp:GridView ID="gvTracking" runat="server" Width="100%" AutoGenerateColumns="False"
                                OnRowDataBound="gvTracking_RowDataBound" DataKeyNames="ID, Send" SkinID="KVoteGridView">
                                <Columns>
                                    <asp:TemplateField Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblMID" runat="server" Text="<%# Bind('MID') %>"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField HeaderText="Items" DataField="NameMaterial">
                                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="35" />
                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="35%" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Status" DataField="CurrentArea">
                                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="35" />
                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="35%" />
                                    </asp:BoundField>
                                    <asp:TemplateField Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblNextArea" runat="server" Text="<%# Bind('NameNext') %>"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblCurrentArea" runat="server" Text="<%# Bind('NameCurrent') %>"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Send To">
                                        <ItemTemplate>
                                            <asp:DropDownList ID="ddlSendArea" runat="server" CssClass="drop_down_list" DataTextField="NameArea"
                                                DataValueField="ToArea">
                                            </asp:DropDownList>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="30" />
                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="30%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblQuarantine" runat="server" Text="<%# Bind('Quarantine') %>"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblNext" runat="server" Text="<%# Bind('NextArea') %>"></asp:Label>
                                        </ItemTemplate>
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
                        </td>
                    </tr>
                </table>
                <br />
                <div id="Div1">
                    <div class="box">
                        <table cellpadding="0" cellspacing="0" border="0" width="100%">
                            <tr>
                                <td style="text-align: left">
                                    <asp:Button ID="btnBack1" runat="server" CssClass="button100" Text="<%$Resources:LanguageText, bback%>"
                                        CausesValidation="False" OnClick="Button5_Click" />
                                </td>
                                <td style="text-align: right">
                                    <asp:Button ID="btnUpdate1" runat="server" Text="<%$ Resources:LanguageText, BUpdate %>"
                                        CssClass="button100" OnClick="btnUpdate_Click" />
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
                <div style="height: 10px;">
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:SqlDataSource ID="sqldsTrackingMaterials" runat="server" ConnectionString="<%$ ConnectionStrings:BVOTEConnectionString %>"
            SelectCommand="p3_getTrackingMaterials" SelectCommandType="StoredProcedure">
            <SelectParameters>
                <asp:ControlParameter ControlID="lblCode" Name="code" PropertyName="Text" Type="String" />
                <asp:SessionParameter Name="user" SessionField="userID" Type="Int32" />
                <asp:ControlParameter ControlID="hdnArea" DefaultValue="" Name="area" PropertyName="Value"
                    Type="Int32" />
            </SelectParameters>
        </asp:SqlDataSource>
        <%--<asp:SqlDataSource ID="sqldsAreas" runat="server" ConnectionString="<%$ ConnectionStrings:BVOTEConnectionString %>"
            SelectCommand="p3_GetAreasToForArea" SelectCommandType="StoredProcedure">
            <SelectParameters>
                <asp:ControlParameter ControlID="gvTracking" Name="area" PropertyName="SelectedValue"
                    Type="Int32" DefaultValue="" />
                <asp:ControlParameter ControlID="gvTracking" Name="mid" PropertyName="SelectedValue"
                    Type="Int32" />
                <asp:SessionParameter Name="lang" SessionField="language" Type="Int32" />
            </SelectParameters>
        </asp:SqlDataSource>--%>
        <div style="height: 10px;">
        </div>
        <div class="line">
        </div>
    </div>
</asp:Content>
