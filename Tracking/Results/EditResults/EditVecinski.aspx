<%@ Page Language="C#" MasterPageFile="~/masterpage.Master" AutoEventWireup="true"
    CodeBehind="EditVecinski.aspx.cs" Inherits="JIIS.Web.Phase3.Tracking.Results.EditResults.EditVecinski"
    Title="Untitled Page" Theme="Default" %>

<%@ Import Namespace="Resources" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="CrystalDecisions.Web,  Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphContent" runat="server">
    <div id="PageTitle">
        <%=LanguageText.p3_EEditVecinski%><hr style="border-width: 0px; background-color: #718ca5;"
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
                            <div id="Div1">
                                <div class="box">
                                    <table cellpadding="0" cellspacing="0" border="0">
                                        <tr>
                                            <td align="left">
                                                <asp:Button ID="Button3" runat="server" CausesValidation="false" Text="<%$ Resources:LanguageText, PgBBack %>"
                                                    CssClass="button100" 
                                                    PostBackUrl="~/Phase3/Tracking/Results/EditResults/EditFirstEntry.aspx" />
                                            </td>
                                            <td align="right" style="width: 100%">
                                                &nbsp;</td>
                                        </tr>
                                    </table>
                                </div>
                            </div>
                        </td>
                    </tr>
                </table>
                <table style="width: 100%;">
                    <tr>
                        <td colspan="2">
                        </td>
                    </tr>
                    <tr>
                        <td class="left_table_cell">
                            <asp:Label ID="Label5" runat="server" CssClass="text12_normal" 
                                Text="<%$Resources:LanguageText, stats%>"></asp:Label>
                        </td>
                        <td class="right_table_cell">
                            <asp:Button ID="Button1" runat="server" CssClass="button120" Text="<%$ Resources:LanguageText, resPreview%>"
                                OnClick="Button1_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td class="left_table_cell">
                            <asp:Label ID="Label6" runat="server" CssClass="text12_normal" 
                                Text="<%$Resources:LanguageText, p3_EntryVotes%>"></asp:Label>
                        </td>
                        <td class="right_table_cell">
                            <asp:Button ID="Button2" runat="server" CssClass="button120" Text="<%$ Resources:LanguageText, resPreview%>"
                                OnClick="Button2_Click" />
                        </td>
                    </tr>
                   
                </table>
                <br />
                 <table width="100%" cellpadding="0" cellspacing="0" frame="void" style="padding: 0px;
                    margin: 0px">
                    <tr>
                        <td>
                            <div id="Div2">
                                <div class="box">
                                    <table cellpadding="0" cellspacing="0" border="0">
                                        <tr>
                                            <td align="left">
                                                <asp:Button ID="Button4" runat="server" CausesValidation="false" Text="<%$ Resources:LanguageText, PgBBack %>"
                                                    CssClass="button100" 
                                                    PostBackUrl="~/Phase3/Tracking/Results/EditResults/EditFirstEntry.aspx" />
                                            </td>
                                            <td align="right" style="width: 100%">
                                                &nbsp;</td>
                                        </tr>
                                    </table>
                                </div>
                            </div>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
        <div style="height: 10px;">
        </div>
        <div class="line">
        </div>
    </div>
</asp:Content>
