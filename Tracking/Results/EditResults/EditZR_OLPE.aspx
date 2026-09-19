<%@ Page Language="C#" MasterPageFile="~/masterpage.Master" AutoEventWireup="true"
    Theme="Default" CodeBehind="EditZR_OLPE.aspx.cs" Inherits="JIIS.Web.Phase3.Tracking.Results.EditResults.EditZR_OLPE"
    Title="BiH-Vote" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Import Namespace="Resources" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphContent" runat="server">
    <div id="PageTitle">
        <%=LanguageText.p3_EEditVecinski%><hr style="border-width: 0px; background-color: #718ca5;"
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
                                                <asp:Button ID="Button2" runat="server" CausesValidation="false" Text="<%$ Resources:LanguageText, PgBBack %>"
                                                    CssClass="button100" 
                                                    PostBackUrl="~/Phase3/Tracking/Results/EditResults/EditOtvorena.aspx" />
                                            </td>
                                            <td align="right" style="width: 100%">
                                                <asp:Button ID="Button1" runat="server" Text="Snimi" CssClass="button100" OnClick="Button1_Click" />
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
                <asp:Label ID="lblRace" runat="server" Style="font-size: large" Text="Label"></asp:Label>
                <br />
                <asp:Label ID="lblPS" runat="server" style="font-size: large" Text="Label"></asp:Label>
                <br />
                <table style="padding: 0px; margin: 0px; border: 2px solid #000000; width: 100%;
                    border-collapse: collapse;">
                    <tr>
                        <td rowspan="2" style="width: 15%; text-align: center; border: 2px solid #000000;">
                            <asp:Label ID="Label1" runat="server" Text="<%$ Resources:LanguageText, candidateregion%>"></asp:Label>
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
                            <asp:Label ID="Label2" runat="server" Text="<%$ Resources:LanguageText, rt_kutija %>"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 15%; height: 35px; text-align: center; border: 2px solid #000000;">
                            &nbsp;&nbsp;&nbsp;<asp:Label ID="lblKategorija" runat="server" Text="Label"></asp:Label>
                        </td>
                        <td style="width: 15%; text-align: center; border: 2px solid #000000;">
                            <asp:Label ID="lblPSCode" runat="server" Text="Label"></asp:Label>
                            &nbsp;
                        </td>
                    </tr>
                   <%-- <tr>
                        <td colspan="4">
                            &nbsp;
                        </td>
                    </tr>--%>
                </table>
                <br />
                <asp:GridView ID="GridView1" SkinID="KVoteGridView" Width="100%" runat="server" AutoGenerateColumns="False"
                    DataKeyNames="ListNumber" DataSourceID="SqlDataSource1" PageSize="100">
                    <Columns>
                        <asp:BoundField DataField="ListNumber" HeaderText="<%$ Resources:LanguageText, de_listNumber%>"
                            ReadOnly="True" HeaderStyle-Width="10%" />
                        <asp:BoundField DataField="PEOrCandidate" Visible="false" HeaderText="<%$ Resources:LanguageText, p3_DateEntered%>"
                            ItemStyle-Width="50%" SortExpression="PEOrCandidate" />
                        <asp:BoundField DataField="NameONBallot" HeaderText="<%$ Resources:LanguageText, p1political%>"
                            HeaderStyle-Width="40%" />
                        <asp:TemplateField ItemStyle-Width="15%" HeaderText="<%$Resources:LanguageText, p3_Votes%>">
                            <ItemTemplate>
                                <asp:TextBox ID="txtVotes" runat="server" Text='<%# Bind("Votes") %>' MaxLength="4"
                                    Width="60%" Style="text-align: right"/>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*"
                                    ControlToValidate="txtVotes"></asp:RequiredFieldValidator>
                                <cc1:FilteredTextBoxExtender ID="txtDate_FilteredTextBoxExtender" runat="server"
                                    FilterType="Numbers" TargetControlID="txtVotes">
                                </cc1:FilteredTextBoxExtender>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <EmptyDataTemplate>
                        <table style="width: 100%">
                            <tr>
                                <td align="center">
                                    <asp:Label ID="lblNoData" runat="server" Text="<%$Resources:LanguageText, noData%>"
                                        CssClass="text12_normal"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </EmptyDataTemplate>
                </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:BVOTEConnectionString %>"
                    SelectCommand="RESULTSGetPoliticalEntitiesOLPEFINALVOTES" SelectCommandType="StoredProcedure">
                    <SelectParameters>
                        <asp:SessionParameter Name="fkRace" SessionField="idrace" Type="Decimal" />
                        <asp:SessionParameter DefaultValue="" Name="levelCode" SessionField="MunicipalityCode"
                            Type="String" />
                        <asp:SessionParameter Name="PSCode" SessionField="PSNumber" Type="String" />
                    </SelectParameters>
                </asp:SqlDataSource>
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
                                                <asp:Button ID="Button3" runat="server" CausesValidation="false" Text="<%$ Resources:LanguageText, PgBBack %>"
                                                    CssClass="button100" 
                                                    PostBackUrl="~/Phase3/Tracking/Results/EditResults/EditOtvorena.aspx" />
                                            </td>
                                            <td align="right" style="width: 100%">
                                                <asp:Button ID="Button4" runat="server" Text="Snimi" CssClass="button100" OnClick="Button1_Click" />
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
