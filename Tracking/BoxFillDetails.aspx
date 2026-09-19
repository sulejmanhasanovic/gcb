<%@ Page Language="C#" MasterPageFile="~/masterpage.Master" AutoEventWireup="true"
    CodeBehind="BoxFillDetails.aspx.cs" Inherits="JIIS.Web.Phase3.Tracking.BoxFillDetails"
    Title="<%$Resources:LanguageText, tr_boxFillDetails%>" Theme="Default" %>

<%@ Import Namespace="Resources" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContent" runat="server">
    <div id="PageTitle">
        <%=LanguageText.tr_boxFillDetails%><hr style="border-width: 0px; background-color: #718ca5;"
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
                                        CausesValidation="False" OnClick="btnBack_Click" />
                                </td>
                                <td style="text-align: right">
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
                <br />
                <table id="Table1" width="100%">
                    <tr>
                        <td class="left_table_cell_bih300px">
                            <asp:Label ID="Label8" runat="server" Text="<%$Resources:LanguageText, tr_boxNumber%>"></asp:Label>
                        </td>
                        <td class="right_table_cell">
                            <asp:Label ID="lblBoxNumber" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="left_table_cell_bih300px">
                            <asp:Label ID="Label1" runat="server" Text="<%$Resources:LanguageText, tr_howMuchEnv%>"></asp:Label>
                        </td>
                        <td class="right_table_cell">
                            <asp:Label ID="lblHowMuchEnvelopes" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="left_table_cell_bih300px">
                            <asp:Label ID="Label3" runat="server" Text="<%$Resources:LanguageText, tr_numberEnvBox%>"></asp:Label>
                        </td>
                        <td class="right_table_cell">
                            <asp:TextBox ID="tBoxNumberEnvelopes" runat="server"  MaxLength="6" CssClass="text_box"></asp:TextBox>
                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" FilterType="Numbers"  TargetControlID="tBoxNumberEnvelopes">
                            </cc1:FilteredTextBoxExtender>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*"
                                ControlToValidate="tBoxNumberEnvelopes"></asp:RequiredFieldValidator >
                        </td>
                    </tr>
                    <tr>
                        <td class="left_table_cell_bih300px">
                            <asp:Label ID="Label5" runat="server" Text="<%$Resources:LanguageText, tr_closeBox%>"></asp:Label>
                        </td>
                        <td class="right_table_cell">
                            <asp:CheckBox ID="chkBoxClosed" runat="server" />
                        </td>
                    </tr>
                </table>
                <br />
                <br />
                <table style="width: 100%">
                    <tr>
                        <td class="left_table_cell" style="width: 250px;">
                            &nbsp;
                        </td>
                        <td class="right_table_cell">
                            <asp:Button ID="btnSave" runat="server" Text="<%$Resources:LanguageText, enter%>"
                                CssClass="button100" OnClick="btnSave_Click" />
                            &nbsp;&nbsp;&nbsp;
                            <asp:Button ID="btnCancel" runat="server" Text="<%$Resources:LanguageText, BCancel %>"
                                CssClass="button100" OnClick="btnCancel_Click" CausesValidation="false" />
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <div class="line">
    </div>
</asp:Content>
