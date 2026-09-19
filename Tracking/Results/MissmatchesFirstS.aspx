<%@ Page Language="C#" MasterPageFile="~/masterpage.Master" AutoEventWireup="true"
    CodeBehind="MissmatchesFirstS.aspx.cs" Inherits="JIIS.Web.Phase3.Tracking.Results.MissmatchesFirstS"
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
                    <table style="width: 100%;">
                        <tr>
                            <td colspan="2">
                            </td>
                        </tr>
                        <tr>
                            <td class="left_table_cell">
                                <asp:Label ID="Label1" runat="server" CssClass="text12_normal" Text="<%$Resources:LanguageText,rt_kategorija%>"></asp:Label>
                            </td>
                            <td class="right_table_cell">
                                <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" CssClass="drop_down_list180"
                                    DataSourceID="SqlDataSource1" DataTextField="MName" DataValueField="LevelCode"
                                    Width="70%" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*"
                                    ControlToValidate="DropDownList1"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                    </table>
                    <asp:GridView ID="gridShow" runat="server" DataSourceID="SqlDataSource2" AutoGenerateColumns="False"
                        DataKeyNames="CRID" SkinID="KVoteGridView1" Width="100%" OnSelectedIndexChanged="gridShow_SelectedIndexChanged1">
                        <Columns>
                            <asp:BoundField DataField="MName" HeaderText="<%$ Resources:LanguageText, rt_kategorija %>"
                                ReadOnly="True" SortExpression="MName" />
                            <asp:BoundField DataField="CRName" HeaderText="<%$ Resources:LanguageText, p1candidacyrace %>"
                                SortExpression="CRName" />
                            <asp:BoundField DataField="CRID" HeaderText="CRID" SortExpression="CRID" Visible="False" />
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:Label ID="lblSelect" runat="server" Text='<%#Eval("CRID")%>' Visible="False" />
                                    <asp:HiddenField ID="hdID" runat="server" Value='<%#Eval("CRID")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="PSNumber" HeaderText="<%$ Resources:LanguageText, rt_kutija %>"
                                SortExpression="PSNumber" />
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:ImageButton ID="imgSelect" runat="server" ImageUrl="../../../App_Themes/Default/default_images/edit.png"
                                        CommandName="Select" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:BVOTEConnectionString %>"
                        SelectCommand="BGetAllActiveCandidacyRaceForMissmatchesTracking" SelectCommandType="StoredProcedure">
                    </asp:SqlDataSource>
                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:BVOTEConnectionString %>"
                        SelectCommand="p3_getLevelCodeForRaceMissmatchesTracking" SelectCommandType="StoredProcedure">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="DropDownList1" Name="levelCode" PropertyName="SelectedValue"
                                Type="String" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                    <%--<asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:BVOTEConnectionString %>"
                        SelectCommand="p3_getLevelandRace" SelectCommandType="StoredProcedure">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="ddlActiveRace" Name="race" PropertyName="SelectedValue"
                                Type="Decimal" />
                            <asp:ControlParameter ControlID="DropDownList1" Name="LevelCode" PropertyName="SelectedValue"
                                Type="String" />
                            <asp:Parameter DefaultValue="2" Name="status" Type="Int32" />
                        </SelectParameters>
                    </asp:SqlDataSource>--%>
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
                                    &nbsp;
                                </td>
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
