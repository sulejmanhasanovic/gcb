<%@ Page Language="C#" MasterPageFile="~/masterpage.Master" AutoEventWireup="true"
    CodeBehind="ResultsEntry.aspx.cs" Inherits="JIIS.Web.Phase3.Tracking.Results.ResultsEntry"
    Theme="Default" %>

<%@ Import Namespace="Resources" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="CrystalDecisions.Web,  Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphContent" runat="server">
    <div id="PageTitle">
        <%=LanguageText.p3_resultsentry%>
        <hr style="border-width: 0px; background-color: #718ca5;" noshade="noshade" />
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
                                    <asp:Button ID="btnBack" runat="server" Text="<%$ Resources:LanguageText, PgBBack %>"
                                        CssClass="button100" OnClick="btnBack_Click" CausesValidation="False" />
                                </td>
                                <td style="text-align: right">
                                    <asp:Button ID="Button2" runat="server" CssClass="button100" Text="<%$Resources:LanguageText, enter%>"
                                        OnClick="Button2_Click" ValidationGroup="validiraj" />
                                    &nbsp;
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
                <div id="divByLevel" runat="server">
                    <table style="width: 100%;">
                        <tr>
                            <td colspan="2" class="error_message">
                                &nbsp;
                                <asp:Label ID="lblError" runat="server" Visible="False"></asp:Label>
                                <br />
                                <asp:Label ID="lblError1" runat="server" Visible="False"></asp:Label>
                                <br />
                                 <asp:Label ID="lblError2" runat="server" Text="<%$Resources:LanguageText, p3_boxReadyResultEntry%>" Visible="False"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="left_table_cell">
                                <asp:Label ID="Label7" runat="server" CssClass="text12_normal" Text="<%$Resources:LanguageText, rt_kategorija%>"></asp:Label>
                            </td>
                            <td class="right_table_cell">
                                <asp:DropDownList ID="DropDownList3" runat="server" CssClass="drop_down_list180"
                                    DataSourceID="SqlDataSource3" DataTextField="MunName" DataValueField="MunicipalityCode"
                                    OnSelectedIndexChanged="DropDownList3_SelectedIndexChanged" AutoPostBack="True"
                                    Width="70%">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td class="left_table_cell">
                                <asp:Label ID="Label6" runat="server" CssClass="text12_normal" Text="<%$Resources:LanguageText, rt_kutija%>"></asp:Label>
                            </td>
                            <td class="right_table_cell">
                                <asp:DropDownList ID="DropDownList1" runat="server" CssClass="drop_down_list180"
                                    DataSourceID="SqlDataSource1" DataTextField="PSCode" DataValueField="ID" AutoPostBack="True"
                                    OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" Width="70%">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td class="left_table_cell">
                                <asp:Label ID="Label2" runat="server" CssClass="text12_normal" Text="<%$ Resources:LanguageText, rt_kutija %>"></asp:Label>
                            </td>
                            <td class="right_table_cell">
                                <asp:TextBox ID="txtPSCode" runat="server" CssClass="text_box"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtPSCode"
                                    ErrorMessage="*" ValidationGroup="validiraj"></asp:RequiredFieldValidator>
                                <asp:Label ID="lblError0" runat="server" CssClass="error_message" Text="" Visible="False"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="left_table_cell">
                                <asp:Label ID="Label5" runat="server" CssClass="text12_normal" Text="<%$Resources:LanguageText, p1candidacyrace%>"></asp:Label>
                            </td>
                            <td class="right_table_cell">
                                <asp:DropDownList ID="DropDownList2" runat="server" CssClass="drop_down_list180"
                                    DataSourceID="SqlDataSource2" DataTextField="CRName" DataValueField="CRID" AutoPostBack="True"
                                    OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged" Width="70%">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td class="left_table_cell">
                                &nbsp;
                            </td>
                            <td class="right_table_cell">
                                <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal"
                                    AutoPostBack="True" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged">
                                    <asp:ListItem Value="1" Text="<%$Resources:LanguageText, cbe_first_entry%>"> </asp:ListItem>
                                    <asp:ListItem Selected="True" Value="2" Text="<%$Resources:LanguageText, cbe_second_entry%>"> </asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                    </table>
                </div>
                <div id="divByPolEntity" runat="server" visible="false">
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:BVOTEConnectionString %>"
                        SelectCommand="p3_PS_GetALLPSsForMunicipalityV2Tracking" SelectCommandType="StoredProcedure">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="DropDownList3" Name="muncode" PropertyName="SelectedValue"
                                Type="String" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:BVOTEConnectionString %>"
                        SelectCommand="p3_Results_GetActiveRaceForMunicipalityTracking" SelectCommandType="StoredProcedure">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="DropDownList3" Name="muncode" PropertyName="SelectedValue"
                                Type="String" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                    <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:BVOTEConnectionString %>"
                        SelectCommand="p3CCResultsEntryMunicipalityTracking" SelectCommandType="StoredProcedure">
                    </asp:SqlDataSource>
                </div>
                <div class="box">
                    <table cellpadding="0" cellspacing="0" border="0" width="100%">
                        <tr>
                            <td style="text-align: left">
                                &nbsp;
                            </td>
                            <td style="text-align: right">
                                <asp:Button ID="Button1" runat="server" CssClass="button100" Text="<%$Resources:LanguageText, enter%>"
                                    OnClick="Button2_Click" ValidationGroup="validiraj" />
                                &nbsp;
                            </td>
                        </tr>
                    </table>
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
