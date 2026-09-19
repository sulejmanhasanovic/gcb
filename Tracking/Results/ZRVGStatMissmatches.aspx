<%@ Page Language="C#" MasterPageFile="~/masterpage.Master" AutoEventWireup="true"
    Theme="Default" CodeBehind="ZRVGStatMissmatches.aspx.cs" Inherits="JIIS.Web.Phase3.Tracking.Results.ZRVGStatMissmatches"
    Title="BiH-Vote" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Import Namespace="Resources" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphContent" runat="server">

    <script language="JavaScript1.2" type="text/javascript">
function dblclick() 
{ 
  window.scrollTo(0,0) 
}
    </script>

    <div id="PageTitle">
        <%=LanguageText.p3_ResultsMismatches%><hr style="border-width: 0px; background-color: #718ca5;"
            noshade="noshade" />
    </div>
    <div style="height: 10px;">
    </div>
    <div id="MainBody">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
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
                <div style="text-align: center;">
                    <asp:Label ID="Label23" runat="server" Text="<%$ Resources:LanguageText, p3_FormTotal %>"></asp:Label>
                </div>
                <asp:Label ID="lblRaceName" runat="server" Text="Label" Style="font-size: large"></asp:Label>
                <br />
                <asp:Label ID="lblPS" runat="server" Style="font-size: large" Text="Label"></asp:Label>
                <br />
                <table style="padding: 0px; margin: 0px; border: 2px solid #000000; width: 100%;
                    border-collapse: collapse;">
                    <tr>
                        <td rowspan="2" style="width: 15%; text-align: center; border: 2px solid #000000;">
                            <asp:Label ID="Label1" runat="server" Text="<%$ Resources:LanguageText, candidateregion%>"></asp:Label>
                        </td>
                        <td rowspan="2" style="text-align: center; border: 2px solid #000000;">
                            <asp:Label ID="lblLevelName" runat="server" Text="Label"></asp:Label>
                        </td>
                        <td style="width: 15%; text-align: center; border: 2px solid #000000;">
                            <asp:Label ID="Label3" runat="server" Text="<%$ Resources:LanguageText, rt_kategorija%>"></asp:Label>
                        </td>
                        <td style="width: 15%; text-align: center; border: 2px solid #000000;">
                            <asp:Label ID="Label2" runat="server" Text="<%$ Resources:LanguageText, rt_kutija %>"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 15%; height: 35px; text-align: center; border: 2px solid #000000;">
                            <asp:Label ID="lblCode" runat="server" Text="Label"></asp:Label>
                        </td>
                        <td style="width: 15%; text-align: center; border: 2px solid #000000;">
                            <asp:Label ID="lblPSCode" runat="server" Text="Label"></asp:Label>
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
                        <td style="text-align: center; height: 35px">
                            &nbsp;
                        </td>
                        <td style="text-align: center; height: 35px">
                            <asp:Label ID="Label24" runat="server" ForeColor="#FF3300" 
                                Text="Missmatches !!!" Visible="False"></asp:Label>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 5%; border: 2px solid #000000; vertical-align: middle; text-align: center;">
                            <asp:Label ID="Label6" runat="server" Text="1)" Style="width: 65%;"></asp:Label>
                        </td>
                        <td class="left_table_cell_ZR" style="width: 50%; text-align: left;">
                            <asp:Label ID="Label5" runat="server" Text="<%$ Resources:LanguageText, rt_ZRStatBox1 %>"
                                CssClass="text11_normal"></asp:Label>
                        </td>
                        <td class="right_table_cell_ZR" style="width: 11%; text-align: center;">
                            <asp:TextBox ID="txt11" runat="server" CssClass="text_box_bih" Width="50px" Enabled="False"></asp:TextBox>
                        </td>
                        <td class="right_table_cell_ZR" style="width: 11%; text-align: center;">
                            <asp:TextBox ID="txt12" runat="server" CssClass="text_box_bih" Width="50px" Enabled="False"></asp:TextBox>
                        </td>
                        <td class="right_table_cell_ZR" style="width: 11%; text-align: center;">
                            <asp:TextBox ID="txt13" runat="server" MaxLength="4" CssClass="text_box_bih" 
                                Width="50px" ontextchanged="txt13_TextChanged"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt13"
                                ErrorMessage="*"></asp:RequiredFieldValidator>
                            <cc1:FilteredTextBoxExtender ID="txtDate_FilteredTextBoxExtender" runat="server"
                                FilterType="Numbers" TargetControlID="txt13">
                            </cc1:FilteredTextBoxExtender>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 5%; border: 2px solid #000000; vertical-align: middle; text-align: center;">
                            <asp:Label ID="Label7" runat="server" Text="2)" Style="width: 65%;"></asp:Label>
                        </td>
                        <td class="left_table_cell_ZR" style="text-align: left">
                            <asp:Label ID="Label8" runat="server" Text="<%$ Resources:LanguageText, rt_ZRStatBox2 %>"
                                CssClass="text11_normal"></asp:Label>
                        </td>
                        <td class="right_table_cell_ZR" style="width: 11%; text-align: center;">
                            <asp:TextBox ID="txt21" runat="server" CssClass="text_box_bih" Width="50px" Enabled="False"></asp:TextBox>
                        </td>
                        <td class="right_table_cell_ZR" style="width: 11%; text-align: center;">
                            <asp:TextBox ID="txt22" runat="server" CssClass="text_box_bih" Width="50px" Enabled="False"></asp:TextBox>
                        </td>
                        <td class="right_table_cell_ZR" style="width: 11%; text-align: center;">
                            <asp:TextBox ID="txt23" runat="server" MaxLength="4" CssClass="text_box_bih" Width="50px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txt23"
                                ErrorMessage="*"></asp:RequiredFieldValidator>
                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" FilterType="Numbers"
                                TargetControlID="txt23">
                            </cc1:FilteredTextBoxExtender>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 5%; border: 2px solid #000000; vertical-align: middle; text-align: center;">
                            <asp:Label ID="Label9" runat="server" Text="3)" Style="width: 65%;"></asp:Label>
                        </td>
                        <td class="left_table_cell_ZR" style="text-align: left">
                            <asp:Label ID="Label10" runat="server" Text="<%$ Resources:LanguageText, rt_ZRStatBox3 %>"
                                CssClass="text11_normal"></asp:Label>
                        </td>
                        <td class="right_table_cell_ZR" style="width: 11%; text-align: center;">
                            <asp:TextBox ID="txt31" runat="server" CssClass="text_box_bih" Width="50px" Enabled="False"></asp:TextBox>
                        </td>
                        <td class="right_table_cell_ZR" style="width: 11%; text-align: center;">
                            <asp:TextBox ID="txt32" runat="server" CssClass="text_box_bih" Width="50px" Enabled="False"></asp:TextBox>
                        </td>
                        <td class="right_table_cell_ZR" style="width: 11%; text-align: center;">
                            <asp:TextBox ID="txt33" runat="server" MaxLength="4" CssClass="text_box_bih" Width="50px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txt33"
                                ErrorMessage="*"></asp:RequiredFieldValidator>
                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" FilterType="Numbers"
                                TargetControlID="txt33">
                            </cc1:FilteredTextBoxExtender>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 5%; border: 2px solid #000000; vertical-align: middle; text-align: center;">
                            <asp:Label ID="Label11" runat="server" Text="A)" Style="width: 65%;"></asp:Label>
                        </td>
                        <td class="left_table_cell_ZR" style="text-align: left">
                            <asp:Label ID="Label12" runat="server" p3_InvalidVotes Text="<%$ Resources:LanguageText, rt_ZRStatBoxA %>"
                                CssClass="text11_normal"></asp:Label>
                        </td>
                        <td class="right_table_cell_ZR" style="width: 11%; text-align: center;">
                            <asp:TextBox ID="txtA1" runat="server" CssClass="text_box_bih" Width="50px" Enabled="False"></asp:TextBox>
                        </td>
                        <td class="right_table_cell_ZR" style="width: 11%; text-align: center;">
                            <asp:TextBox ID="txtA2" runat="server" CssClass="text_box_bih" Width="50px" Enabled="False"></asp:TextBox>
                        </td>
                        <td class="right_table_cell_ZR" style="width: 11%; text-align: center;">
                            <asp:TextBox ID="txtA3" runat="server" MaxLength="4" CssClass="text_box_bih" Width="50px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtA3"
                                ErrorMessage="*"></asp:RequiredFieldValidator>
                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" FilterType="Numbers"
                                TargetControlID="txtA3">
                            </cc1:FilteredTextBoxExtender>
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
                        <td class="right_table_cell_ZR" style="width: 11%; text-align: center;">
                            <asp:TextBox ID="txtB1" runat="server" CssClass="text_box_bih" Width="50px" Enabled="False"></asp:TextBox>
                        </td>
                        <td class="right_table_cell_ZR" style="width: 11%; text-align: center;">
                            <asp:TextBox ID="txtB2" runat="server" CssClass="text_box_bih" Width="50px" Enabled="False"></asp:TextBox>
                        </td>
                        <td class="right_table_cell_ZR" style="width: 11%; text-align: center;">
                            <asp:TextBox ID="txtB3" MaxLength="4" runat="server" CssClass="text_box_bih" Width="50px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtB3"
                                ErrorMessage="*"></asp:RequiredFieldValidator>
                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server" FilterType="Numbers"
                                TargetControlID="txtB3">
                            </cc1:FilteredTextBoxExtender>
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
                        <td class="right_table_cell_ZR" style="width: 11%; text-align: center;">
                            <asp:TextBox ID="txtC1" runat="server" CssClass="text_box_bih" Width="50px" Enabled="False"></asp:TextBox>
                        </td>
                        <td class="right_table_cell_ZR" style="width: 11%; text-align: center;">
                            <asp:TextBox ID="txtC2" runat="server" CssClass="text_box_bih" Width="50px" Enabled="False"></asp:TextBox>
                        </td>
                        <td class="right_table_cell_ZR" style="width: 11%; text-align: center;">
                            <asp:TextBox ID="txtC3" runat="server" MaxLength="4" CssClass="text_box_bih" Width="50px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtC3"
                                ErrorMessage="*"></asp:RequiredFieldValidator>
                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" runat="server" FilterType="Numbers"
                                TargetControlID="txtC3">
                            </cc1:FilteredTextBoxExtender>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 5%; border: 2px solid #000000; vertical-align: middle; text-align: center;">
                            <asp:Label ID="Label17" runat="server" Text="D)" Style="width: 65%;"></asp:Label>
                        </td>
                        <td class="left_table_cell_ZR" style="text-align: left">
                            <asp:Label ID="Label18" runat="server" Text="<%$ Resources:LanguageText, rt_ZRStatBoxD %>"
                                CssClass="text11_normal"></asp:Label>
                        </td>
                        <td class="right_table_cell_ZR" style="width: 11%; text-align: center;">
                            <asp:TextBox ID="txtD1" runat="server" CssClass="text_box_bih" Width="50px" Enabled="False"></asp:TextBox>
                        </td>
                        <td class="right_table_cell_ZR" style="width: 11%; text-align: center;">
                            <asp:TextBox ID="txtD2" runat="server" CssClass="text_box_bih" Width="50px" Enabled="False"></asp:TextBox>
                        </td>
                        <td class="right_table_cell_ZR" style="width: 11%; text-align: center;">
                            <asp:TextBox ID="txtD3" MaxLength="4" runat="server" CssClass="text_box_bih" Width="50px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtD3"
                                ErrorMessage="*"></asp:RequiredFieldValidator>
                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender6" runat="server" FilterType="Numbers"
                                TargetControlID="txtD3">
                            </cc1:FilteredTextBoxExtender>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 5%; border: 2px solid #000000; vertical-align: middle; text-align: center;">
                            <asp:Label ID="Label19" runat="server" Text="E)" Style="width: 65%;"></asp:Label>
                        </td>
                        <td class="left_table_cell_ZR" style="text-align: left">
                            <asp:Label ID="Label20" runat="server" Text="<%$ Resources:LanguageText, rt_ZRStatBoxE %>"
                                CssClass="text11_normal"></asp:Label>
                        </td>
                        <td class="right_table_cell_ZR" style="width: 11%; text-align: center;">
                            <asp:TextBox ID="txtE1" runat="server" CssClass="text_box_bih" Width="50px" Enabled="False"></asp:TextBox>
                        </td>
                        <td class="right_table_cell_ZR" style="width: 11%; text-align: center;">
                            <asp:TextBox ID="txtE2" runat="server" CssClass="text_box_bih" Width="50px" Enabled="False"></asp:TextBox>
                        </td>
                        <td class="right_table_cell_ZR" style="width: 11%; text-align: center;">
                            <asp:TextBox ID="txtE3" runat="server" MaxLength="4" CssClass="text_box_bih" Width="50px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtE3"
                                ErrorMessage="*"></asp:RequiredFieldValidator>
                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender7" runat="server" FilterType="Numbers"
                                TargetControlID="txtE3">
                            </cc1:FilteredTextBoxExtender>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 5%; border: 2px solid #000000; vertical-align: middle; text-align: center;">
                            <asp:Label ID="Label21" runat="server" Text="F)" Style="width: 65%;"></asp:Label>
                        </td>
                        <td class="left_table_cell_ZR" style="text-align: left">
                            <asp:Label ID="Label22" runat="server" Text="<%$ Resources:LanguageText, rt_ZRStatBoxF %>"
                                CssClass="text11_normal"></asp:Label>
                        </td>
                        <td class="right_table_cell_ZR" style="width: 11%; text-align: center;">
                            <asp:TextBox ID="txtF1" runat="server" CssClass="text_box_bih" Width="50px" Enabled="False"></asp:TextBox>
                        </td>
                        <td class="right_table_cell_ZR" style="width: 11%; text-align: center;">
                            <asp:TextBox ID="txtF2" runat="server" CssClass="text_box_bih" Width="50px" Enabled="False"></asp:TextBox>
                        </td>
                        <td class="right_table_cell_ZR" style="width: 11%; text-align: center;">
                            <asp:TextBox ID="txtF3" runat="server" MaxLength="4" CssClass="text_box_bih" Width="50px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtF3"
                                ErrorMessage="*"></asp:RequiredFieldValidator>
                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender8" runat="server" FilterType="Numbers"
                                TargetControlID="txtF3">
                            </cc1:FilteredTextBoxExtender>
                        </td>
                    </tr>
                </table>
                <br />
                <table style="width: 100%;">
                    <tr>
                        <td style="text-align: right;">
                            <asp:Button ID="Button1" runat="server" Text="<%$ Resources:LanguageText, BSave  %>"
                                CssClass="button100" OnClick="Button1_Click" />
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
