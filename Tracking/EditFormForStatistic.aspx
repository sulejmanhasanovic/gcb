<%@ Page Title="" Language="C#" MasterPageFile="~/masterpage.Master" AutoEventWireup="true"
    CodeBehind="EditFormForStatistic.aspx.cs" Inherits="JIIS.Web.Phase3.Tracking.EditFormForStatistic" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<%@ Import Namespace="Resources" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphContent" runat="server">
    <div id="PageTitle">
        <%--<%=LanguageText.Admin_Level_Levels%><hr style="border-width: 0px; background-color: #718ca5;"
            noshade="noshade" />--%>
    </div>
    <div id="MainBody">
        <div style="height: 3px;">
        </div>
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
                                        <asp:Button ID="Button3" runat="server" CssClass="button100" Text="<%$ Resources:LanguageText, BCancel %>"
                                            OnClick="Button1_Click" CausesValidation="False" />&nbsp;
                                        <asp:Button ID="Button4" runat="server" CssClass="button100" Text="<%$ Resources:LanguageText, PgAdminUsersBEditUser %>"
                                            OnClick="Button2_Click" />
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                </td>
            </tr>
        </table>
        <div style="height: 3px;">
        </div>
        <table style="width: 100%;">
            <tr>
                <td>
                </td>
                <td style="width: 223px">
                </td>
                <td>
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="left_table_cell">
                    <asp:Label ID="Label1" runat="server" Text="<%$Resources:LanguageText, tr_date %>"
                        CssClass="text12_normal"></asp:Label>
                </td>
                <td style="padding-left: 5px; font-weight: normal; width: 223px; margin-left: 40px;">
                    <asp:TextBox ID="txtDateReceived" runat="server" Width="200px" 
                        CssClass="text_box" ></asp:TextBox>
                         <asp:CalendarExtender ID="CalendarExtender3" runat="server" 
                                    Format="dd/MM/yyyy"
                                    PopupButtonID ="Image2"
                                    TargetControlID="txtDateReceived"> 
                       </asp:CalendarExtender>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        ControlToValidate="txtDateReceived" ErrorMessage="*"></asp:RequiredFieldValidator>
                </td>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td class="left_table_cell">
                    <asp:Label ID="Label2" runat="server" Text="<%$Resources:LanguageText, tr_numberShipment %>"
                        CssClass="text12_normal"></asp:Label>
                </td>
                <td style="padding-left: 5px; font-weight: normal; width: 223px; margin-left: 120px;">
                    <asp:TextBox ID="txtShipmentNumber" runat="server" CssClass="text_box" 
                        Width="200px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                        ControlToValidate="txtShipmentNumber" ErrorMessage="*"></asp:RequiredFieldValidator>
                </td>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td class="left_table_cell">
                    <asp:Label ID="Label3" runat="server" Text="<%$Resources:LanguageText, p3_MEC_totalPos %>"
                        CssClass="text12_normal"></asp:Label>
                </td>
                <td style="padding-left: 5px; font-weight: normal; width: 223px; margin-left: 160px;">
                    <asp:TextBox ID="txtTotalShip" runat="server" CssClass="text_box" Width="200px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                        ControlToValidate="txtTotalShip" ErrorMessage="*"></asp:RequiredFieldValidator>
                </td>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td class="left_table_cell">
                    <asp:Label ID="Label4" runat="server" Text="<%$Resources:LanguageText, p3_MEC_totalOtherPost %>"
                        CssClass="text12_normal"></asp:Label>
                </td>
                <td style="padding-left: 5px; font-weight: normal; width: 223px;">
                    
                    <%--<asp:TextBox ID="txtDate1" runat="server" CssClass="text_box" 
                        Width="200px"></asp:TextBox>--%>
                  
                        
                    <asp:TextBox ID="txtTotalOtherPost" runat="server" CssClass="text_box" 
                        Width="200px"></asp:TextBox>
                    <%--<asp:CalendarExtender ID="CalendarExtender3" runat="server" 
                                    Format="yyyy.MM.dd"
                                    PopupButtonID ="Image2"
                                    TargetControlID="txtTotalOtherPost"> 
                       </asp:CalendarExtender>--%><asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                        ControlToValidate="txtTotalOtherPost" ErrorMessage="*"></asp:RequiredFieldValidator>
                </td>
                <td>
                    
                </td>
                <td>
                   
                </td>
                <td
                </td>
            </tr>
            <tr>
                <td class="left_table_cell">
                    <asp:Label ID="Label6" runat="server" Text="<%$Resources:LanguageText, PgDocumentUploadIDocumentComment %>"
                        CssClass="text12_normal"></asp:Label>
                </td>
                <td style="padding-left: 1px; font-weight: normal; width: 223px;">
                    <asp:TextBox ID="txtComment" runat="server" CssClass="text_box" Width="200px"></asp:TextBox>
                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                        ControlToValidate="TextBox2" ErrorMessage="*"></asp:RequiredFieldValidator>--%>
                </td>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
            </tr>
            
            </table>
        <div style="height: 10px;">
        </div>
        <div class="line">
        </div>
    </div>
</asp:Content>
