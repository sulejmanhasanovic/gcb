<%@ Page Language="C#" MasterPageFile="~/masterpage.Master" AutoEventWireup="true"
    Theme="Default" CodeBehind="EditZR_OtvorenaLista1.aspx.cs" Inherits="JIIS.Web.Phase3.Tracking.Results.EditResults.EditZR_OtvorenaLista1"
    Title="BiH-Vote" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Import Namespace="Resources" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphContent" runat="server">
    <div id="PageTitle">
        <%=LanguageText.p3_EEditOpen%><hr style="border-width: 0px; background-color: #718ca5;"
            noshade="noshade" />
    </div>
    <div style="height: 10px;">
    </div>
    <div id="MainBody">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
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
                                                    PostBackUrl="~/Phase3/Tracking/Results/EditResults/EditOtvorena.aspx" />
                                            </td>
                                            <td align="right" style="width: 100%">
                                                <asp:Button ID="Button1" runat="server" Text="<%$Resources:LanguageText, BSave%>"
                                                    CssClass="button100" OnClick="Button1_Click" />
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </div>
                        </td>
                    </tr>
                </table>
                <div style="text-align: center;">
                    <asp:Label ID="Label23" runat="server" Text="<%$ Resources:LanguageText, p3_FormTotalOPen%>"></asp:Label>
                </div>
                <asp:Label ID="lblRaceName" runat="server" Style="text-align: center; font-size: large"
                    Text="Label"></asp:Label>
                <br />
                <asp:Label ID="lblPS" runat="server" style="font-size: large" Text="Label"></asp:Label>
                <br />
                <table style="padding: 0px; margin: 0px; border: 2px solid #000000; width: 100%;
                    border-collapse: collapse;">
                    <tr>
                        <td rowspan="2" style="width: 15%; text-align: center; border: 2px solid #000000;">
                            <asp:Label ID="Label1a" runat="server" Text="<%$ Resources:LanguageText, candidateregion%>"></asp:Label>
                        </td>
                        <td rowspan="2" style="text-align: center; border: 2px solid #000000;">
                            <asp:Label ID="lblLevelName" runat="server" Text="Label"></asp:Label>
                            <br />
                            <asp:Label ID="lblLevelCode" runat="server" Text="Label"></asp:Label>
                        </td>
                        <td style="width: 15%; text-align: center; border: 2px solid #000000;">
                            <asp:Label ID="Label3" runat="server" Text="<%$ Resources:LanguageText, rt_kategorija%>"></asp:Label>
                        </td>
                        <td style="width: 15%; text-align: center; border: 2px solid #000000;">
                            <asp:Label ID="Label1" runat="server" Text="<%$ Resources:LanguageText, rt_kutija %>"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 15%; height: 35px; text-align: center; border: 2px solid #000000;">
                            &nbsp;<asp:Label ID="lblKategorija" runat="server" Text="Label"></asp:Label>
&nbsp;</td>
                        <td style="width: 15%; text-align: center; border: 2px solid #000000;">
                            &nbsp;
                            <asp:Label ID="lblPSCode" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                </table>
                <table width="100%">
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                </table>
                <br />
                <table style="padding: 0px; margin: 0px; border: 2px solid #000000; width: 100%;
                    border-collapse: collapse;">
                    <tr>
                        <td style="text-align: center; height: 35px" colspan="3">
                            &nbsp;
                            <asp:Label ID="Label4" runat="server" CssClass="text14_normal" Text="<%$ Resources:LanguageText, p3_TotalOfVotes %>"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 5%; border: 2px solid #000000; vertical-align: middle; text-align: center;">
                            <asp:Label ID="Label6" runat="server" Text="1)" Style="width: 65%;"></asp:Label>
                        </td>
                        <td class="left_table_cell_ZR" style="text-align: left">
                            <asp:Label ID="Label5" runat="server" Text="<%$ Resources:LanguageText,rt_ZRStatBox1 %>"
                                CssClass="text11_normal" BorderColor="Black"></asp:Label>
                        </td>
                        <td class="right_table_cell_ZR" style="width: 30%; text-align: center;">
                            <asp:TextBox ID="txt1" runat="server" CssClass="text_box_bih" MaxLength="4" Width="20%" Style="text-align: right"></asp:TextBox>
                            <cc1:FilteredTextBoxExtender ID="txtDate_FilteredTextBoxExtender" runat="server"
                                FilterType="Numbers" TargetControlID="txt1">
                            </cc1:FilteredTextBoxExtender>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txt1"
                                ErrorMessage="*"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 5%; border: 2px solid #000000; vertical-align: middle; text-align: center;">
                            <asp:Label ID="Label7" runat="server" Text="2)" Style="width: 65%;"></asp:Label>
                        </td>
                        <td class="left_table_cell_ZR" style="text-align: left">
                            <asp:Label ID="Label8" runat="server" Text="<%$ Resources:LanguageText,rt_ZRStatBox2 %>"
                                CssClass="text11_normal"></asp:Label>
                        </td>
                        <td class="right_table_cell_ZR" style="width: 30%; text-align: center;">
                            <asp:TextBox ID="txt2" runat="server" CssClass="text_box_bih" MaxLength="4" Width="20%" Style="text-align: right"></asp:TextBox>
                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" FilterType="Numbers"
                                TargetControlID="txt2">
                            </cc1:FilteredTextBoxExtender>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txt2"
                                ErrorMessage="*"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 5%; border: 2px solid #000000; vertical-align: middle; text-align: center;">
                            <asp:Label ID="Label9" runat="server" Text="3)" Style="width: 65%;"></asp:Label>
                        </td>
                        <td class="left_table_cell_ZR" style="text-align: left">
                            <asp:Label ID="Label28" runat="server" Text="<%$ Resources:LanguageText, rt_ZRStatBox3 %>"
                                CssClass="text11_normal"></asp:Label>
                        </td>
                        <td class="right_table_cell_ZR" style="width: 30%; text-align: center;">
                            <asp:TextBox ID="txt3" runat="server" CssClass="text_box_bih" Width="20%" MaxLength="4" Style="text-align: right"></asp:TextBox>
                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" FilterType="Numbers"
                                TargetControlID="txt3">
                            </cc1:FilteredTextBoxExtender>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txt3"
                                ErrorMessage="*"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 5%; border: 2px solid #000000; vertical-align: middle; text-align: center;">
                            <asp:Label ID="Label11" runat="server" Text="A)" Style="width: 65%;"></asp:Label>
                        </td>
                        <td class="left_table_cell_ZR" style="text-align: left">
                            <asp:Label ID="Label12" runat="server" Text="<%$ Resources:LanguageText, rt_ZRStatBoxA %>"
                                CssClass="text11_normal"></asp:Label>
                        </td>
                        <td class="right_table_cell_ZR" style="width: 30%; text-align: center;">
                            <asp:TextBox ID="txtA" runat="server" CssClass="text_box_bih" Width="20%" MaxLength="4" Style="text-align: right"></asp:TextBox>
                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" FilterType="Numbers"
                                TargetControlID="txtA">
                            </cc1:FilteredTextBoxExtender>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtA"
                                ErrorMessage="*"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 5%; border: 2px solid #000000; vertical-align: middle; text-align: center;">
                            <asp:Label ID="Label13" runat="server" Text="B)" Style="width: 65%;"></asp:Label>
                        </td>
                        <td class="left_table_cell_ZR" style="text-align: left">
                            <asp:Label ID="Label14" runat="server" Text="<%$ Resources:LanguageText, rt_ZRStatBoxB %>"
                                CssClass="text11_normal"></asp:Label>
                        </td>
                        <td class="right_table_cell_ZR" style="width: 30%; text-align: center;">
                            <asp:TextBox ID="txtB" runat="server" CssClass="text_box_bih" Width="20%" MaxLength="4" Style="text-align: right"></asp:TextBox>
                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server" FilterType="Numbers"
                                TargetControlID="txtB">
                            </cc1:FilteredTextBoxExtender>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtB"
                                ErrorMessage="*"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 5%; border: 2px solid #000000; vertical-align: middle; text-align: center;">
                            <asp:Label ID="Label15" runat="server" Text="C)" Style="width: 65%;"></asp:Label>
                        </td>
                        <td class="left_table_cell_ZR" style="text-align: left">
                            <asp:Label ID="Label16" runat="server" Text="<%$ Resources:LanguageText, rt_ZRStatBoxC %>"
                                CssClass="text11_normal"></asp:Label>
                        </td>
                        <td class="right_table_cell_ZR" style="width: 30%; text-align: center;">
                            <asp:TextBox ID="txtC" runat="server" CssClass="text_box_bih" Width="20%" MaxLength="4" Style="text-align: right"></asp:TextBox>
                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" runat="server" FilterType="Numbers"
                                TargetControlID="txtC">
                            </cc1:FilteredTextBoxExtender>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtC"
                                ErrorMessage="*"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 5%; border: 2px solid #000000; vertical-align: middle; text-align: center;">
                            <asp:Label ID="Label17" runat="server" Text="D1)" Style="width: 65%;"></asp:Label>
                        </td>
                        <td class="left_table_cell_ZR" style="text-align: left">
                            <asp:Label ID="Label18" runat="server" Text="<%$ Resources:LanguageText, rt_ZRStatBoxD1 %>"
                                CssClass="text11_normal"></asp:Label>
                        </td>
                        <td class="right_table_cell_ZR" style="width: 30%; text-align: center;">
                            <asp:TextBox ID="txtD1" runat="server" CssClass="text_box_bih" Width="20%" MaxLength="4" Style="text-align: right"></asp:TextBox>
                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender6" runat="server" FilterType="Numbers"
                                TargetControlID="txtD1">
                            </cc1:FilteredTextBoxExtender>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtD1"
                                ErrorMessage="*"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 5%; border: 2px solid #000000; vertical-align: middle; text-align: center;">
                            <asp:Label ID="Label19" runat="server" Text="D2)" Style="width: 65%;"></asp:Label>
                        </td>
                        <td class="left_table_cell_ZR" style="text-align: left">
                            <asp:Label ID="Label20" runat="server" Text="<%$ Resources:LanguageText, rt_ZRStatBoxD2 %>"
                                CssClass="text11_normal"></asp:Label>
                        </td>
                        <td class="right_table_cell_ZR" style="width: 30%; text-align: center;">
                            <asp:TextBox ID="txtD2" runat="server" CssClass="text_box_bih" Width="20%" MaxLength="4" Style="text-align: right"></asp:TextBox>
                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender7" runat="server" FilterType="Numbers"
                                TargetControlID="txtD2">
                            </cc1:FilteredTextBoxExtender>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtD2"
                                ErrorMessage="*"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 5%; border: 2px solid #000000; vertical-align: middle; text-align: center;">
                            <asp:Label ID="Label21" runat="server" Text="D)" Style="width: 65%;"></asp:Label>
                        </td>
                        <td class="left_table_cell_ZR" style="text-align: left">
                            <asp:Label ID="Label22" runat="server" Text="<%$ Resources:LanguageText, rt_ZRStatBoxDOL  %>"
                                CssClass="text11_normal"></asp:Label>
                        </td>
                        <td class="right_table_cell_ZR" style="width: 30%; text-align: center;">
                            <asp:TextBox ID="txtD" runat="server" CssClass="text_box_bih" Width="20%" MaxLength="4" Style="text-align: right"></asp:TextBox>
                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender8" runat="server" FilterType="Numbers"
                                TargetControlID="txtD">
                            </cc1:FilteredTextBoxExtender>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txtD"
                                ErrorMessage="*"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 5%; border: 2px solid #000000; vertical-align: middle; text-align: center;">
                            <asp:Label ID="Label2" runat="server" Text="E)" Style="width: 65%;"></asp:Label>
                        </td>
                        <td class="left_table_cell_ZR" style="text-align: left">
                            <asp:Label ID="Label25" runat="server" Text="<%$ Resources:LanguageText, rt_ZRStatBoxE  %>"
                                CssClass="text11_normal"></asp:Label>
                        </td>
                        <td class="right_table_cell_ZR" style="width: 30%; text-align: center;">
                            <asp:TextBox ID="txtE" runat="server" CssClass="text_box_bih" Width="20%" MaxLength="4" Style="text-align: right"></asp:TextBox>
                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender9" runat="server" FilterType="Numbers"
                                TargetControlID="txtE">
                            </cc1:FilteredTextBoxExtender>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txtE"
                                ErrorMessage="*"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 5%; border: 2px solid #000000; vertical-align: middle; text-align: center;">
                            <asp:Label ID="Label26" runat="server" Text="F)" Style="width: 65%;"></asp:Label>
                        </td>
                        <td class="left_table_cell_ZR" style="text-align: left">
                            <asp:Label ID="Label27" runat="server" p3_testVE Text="<%$ Resources:LanguageText, rt_ZRStatBoxF  %>"
                                CssClass="text11_normal"></asp:Label>
                        </td>
                        <td class="right_table_cell_ZR" style="width: 30%; text-align: center;">
                            <asp:TextBox ID="txtF" runat="server" CssClass="text_box_bih" Width="20%" MaxLength="4" Style="text-align: right"></asp:TextBox>
                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender10" runat="server" FilterType="Numbers"
                                TargetControlID="txtF">
                            </cc1:FilteredTextBoxExtender>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="txtF"
                                ErrorMessage="*"></asp:RequiredFieldValidator>
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
                                                <asp:Button ID="Button2" runat="server" CausesValidation="false" Text="<%$ Resources:LanguageText, PgBBack %>"
                                                    CssClass="button100" 
                                                    PostBackUrl="~/Phase3/Tracking/Results/EditResults/EditOtvorena.aspx" />
                                            </td>
                                            <td align="right" style="width: 100%">
                                                <asp:Button ID="Button4" runat="server" Text="<%$Resources:LanguageText, BSave%>"
                                                    CssClass="button100" OnClick="Button1_Click" />
                                            </td>
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
