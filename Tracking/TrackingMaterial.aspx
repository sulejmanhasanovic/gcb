<%@ Page Language="C#" MasterPageFile="~/masterpage.Master" AutoEventWireup="true"
    CodeBehind="TrackingMaterial.aspx.cs" Inherits="JIIS.Web.Phase3.Tracking.TrackingMaterial"
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
                            <asp:Label ID="Label1" runat="server" Text="Enter code" CssClass="text12_normal"></asp:Label>
                        </td>
                        <td class="right_table_cell">
                            <asp:TextBox ID="txtPollingStation" runat="server" CssClass="text_box"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="left_table_cell">
                            &nbsp;
                        </td>
                        <td class="right_table_cell">
                            <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click"
                                CssClass="button100" />
                            <asp:Label ID="lblError" runat="server" Text="Theri is no polling station with that code!"
                                CssClass="error_message" Visible="false"></asp:Label>
                        </td>
                    </tr>
                </table>
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
