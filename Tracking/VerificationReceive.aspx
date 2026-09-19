<%@ Page Language="C#" MasterPageFile="~/masterpage.Master" AutoEventWireup="true"
    CodeBehind="VerificationReceive.aspx.cs" Inherits="JIIS.Web.Phase3.Tracking.VerificationReceive" Title="Untitled Page"  Theme="Default" %>

<%@ Import Namespace="Resources" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContent" runat="server">
    <div id="PageTitle">
        <%=LanguageText.p3_bagsReceiving%><hr style="border-width: 0px; background-color: #718ca5;"
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
                                        CausesValidation="False" OnClick="btnCancel_Click" />
                                </td>
                                <td style="text-align: right">
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
                <table width="100%">
                    <tr>
                        <td class="left_table_cell">
                            <asp:Label ID="Label1" runat="server" Text="Choose type of bag"></asp:Label>
                        </td>
                        <td class="right_table_cell">
                            <asp:DropDownList ID="ddlPoBox" runat="server" Width="20%" DataSourceID="SqlDataSource1"
                                DataTextField="poBox" DataValueField="id">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="left_table_cell">
                            <asp:Label ID="lblSecondTime" runat="server" Text="<%$Resources:LanguageText, p3_NSend %>"></asp:Label>
                        </td>
                        <td class="right_table_cell">
                            <asp:TextBox ID="tBoxShipment" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="left_table_cell">
                            <asp:Label ID="lblNBag" runat="server" Text="<%$Resources:LanguageText, p3_NBag %>"></asp:Label>
                        </td>
                        <td class="right_table_cell">
                            <asp:TextBox ID="tBoxBag" runat="server" MaxLength="2"></asp:TextBox>
                            <cc1:FilteredTextBoxExtender ID="TextBox2_FilteredTextBoxExtender" FilterType="Numbers"
                                runat="server" Enabled="True" TargetControlID="tBoxBag">
                            </cc1:FilteredTextBoxExtender>
                        </td>
                    </tr>
                    <tr>
                        <td class="left_table_cell">
                            <asp:Label ID="Label4" runat="server" Text="<%$Resources:LanguageText, p3_regE %>">></asp:Label>
                        </td>
                        <td class="right_table_cell">
                            <asp:TextBox ID="tBoxRegEnvelopes" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="left_table_cell">
                            <asp:Label ID="Label5" runat="server" Text="<%$Resources:LanguageText,p3_FastPost %>"></asp:Label>
                        </td>
                        <td class="right_table_cell">
                            <asp:TextBox ID="tBoxFastPost" runat="server"></asp:TextBox>
                            <cc1:FilteredTextBoxExtender ID="TextBox6_FilteredTextBoxExtender"  FilterType="Numbers"
                                runat="server" Enabled="True" TargetControlID="tBoxFastPost">
                            </cc1:FilteredTextBoxExtender>
                        </td>
                    </tr>
                    <tr>
                        <td class="left_table_cell">
                            <asp:Label ID="Label7" runat="server" Text="<%$Resources:LanguageText,p3_Undelivered %>"></asp:Label>
                        </td>
                        <td class="right_table_cell">
                            <asp:TextBox ID="tBoxUndelivered" runat="server"></asp:TextBox>
                            <cc1:FilteredTextBoxExtender ID="TextBox7_FilteredTextBoxExtender"  FilterType="Numbers"
                                runat="server" Enabled="True" TargetControlID="tBoxUndelivered">
                            </cc1:FilteredTextBoxExtender>
                        </td>
                    </tr>
                    <tr>
                        <td class="left_table_cell">
                            <asp:Label ID="Label6" runat="server" Text="<%$Resources:LanguageText,de_others %>"></asp:Label>
                        </td>
                        <td class="right_table_cell">
                            <asp:TextBox ID="tBoxOthers" runat="server"></asp:TextBox>
                            <cc1:FilteredTextBoxExtender ID="TextBox1_FilteredTextBoxExtender"   FilterType="Numbers"
                                runat="server" Enabled="True" TargetControlID="tBoxOthers">
                            </cc1:FilteredTextBoxExtender>
                        </td>
                    </tr>
                    <tr>
                        <td class="left_table_cell">
                            <asp:Label ID="lblThirdTime" runat="server" Text="<%$Resources:LanguageText, p3_Day %>"></asp:Label>
                        </td>
                        <td class="right_table_cell">
                            <asp:TextBox ID="tBoxDateReceived" runat="server"></asp:TextBox>
                            <cc1:CalendarExtender ID="TextBox3_CalendarExtender" runat="server" Enabled="True"
                                TargetControlID="tBoxDateReceived" Format="dd/MM/yyyy"  >
                            </cc1:CalendarExtender>
                        </td>
                    </tr>
                    <tr>
                        <td class="left_table_cell">
                            <asp:Label ID="Label2" runat="server" Text="<%$Resources:LanguageText, de_comment %>"></asp:Label>
                        </td>
                        <td class="right_table_cell">
                            <asp:TextBox ID="tBoxComment" runat="server" TextMode="MultiLine"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="left_table_cell">
                            <asp:Label ID="Label3" runat="server" Text="<%$Resources:LanguageText,p3_TypePosilka%>"></asp:Label>
                        </td>
                        <td class="right_table_cell">
                            <asp:DropDownList ID="ddlTypeShipment" runat="server" Width="30%">
                                <asp:ListItem>Normal</asp:ListItem>
                                <asp:ListItem>Returned</asp:ListItem>
                                <asp:ListItem>Registered</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="left_table_cell">
                            &nbsp;
                        </td>
                        <td class="right_table_cell">
                            <asp:Button ID="btnSave" runat="server" Text="<%$Resources:LanguageText, GVDocumentCommentEditAlt %>"
                                CssClass="button100" OnClick="btnSave_Click" />
                                &nbsp;&nbsp;&nbsp;
                                <asp:Button ID="btnCancel" runat="server" Text="<%$Resources:LanguageText, BCancel %>"
                                CssClass="button100" onclick="btnCancel_Click"/>
                        </td>
                    </tr>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:BVOTEConnectionString %>" 
                        SelectCommand="p3_GetPOBOX" SelectCommandType="StoredProcedure">
                    </asp:SqlDataSource>
                    <div id="poraka" visible="false" runat="server">
                    </div>
                </table>
            </ContentTemplate>
<%--            <Triggers>
                <asp:PostBackTrigger ControlID="Button6" />
            </Triggers>--%>
        </asp:UpdatePanel>
    </div>
    <div style="height: 10px;">
    </div>
    <div class="line">
    </div>
</asp:Content>
