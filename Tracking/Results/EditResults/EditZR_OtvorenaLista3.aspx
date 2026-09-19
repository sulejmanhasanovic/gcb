<%@ Page Language="C#" MasterPageFile="~/masterpage.Master" AutoEventWireup="true"
    Theme="Default" CodeBehind="EditZR_OtvorenaLista3.aspx.cs" Inherits="JIIS.Web.Phase3.Tracking.Results.EditResults.EditZR_OtvorenaLista3"
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
                            <div id="Div2">
                                <div class="box">
                                    <table cellpadding="0" cellspacing="0" border="0">
                                        <tr>
                                            <td align="left">
                                                <asp:Button ID="Button3" runat="server" CausesValidation="false" Text="<%$ Resources:LanguageText, PgBBack %>"
                                                    CssClass="button100" 
                                                    
                                                    PostBackUrl="~/Phase3/Tracking/Results/EditResults/EditZR_OtvorenaLista2.aspx" />
                                            </td>
                                            <td align="right" style="width: 100%">
                                                <asp:Button ID="Button2" runat="server" Text="<%$Resources:LanguageText, BSave%>"
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
                <asp:Label ID="lblRace" runat="server" Style="font-size: large" Text="Label"></asp:Label>
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
                <br />
                <asp:GridView ID="GridView1" SkinID="KVoteGridView" Width="100%" runat="server" AutoGenerateColumns="False"
                    DataSourceID="SqlDataSource1" PageSize="100" DataKeyNames="ID,Votes">
                    <Columns>
                        <asp:TemplateField HeaderText="ID" InsertVisible="False" SortExpression="ID" Visible="False">
                            <EditItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Eval("ID") %>'></asp:Label>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("ID") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="CandidateName" HeaderText="<%$Resources:LanguageText, candidate%>"
                            ItemStyle-Width="80%">
                            <ItemStyle Width="80%" />
                        </asp:BoundField>
                        <asp:TemplateField ItemStyle-Width="20%" HeaderText="<%$Resources:LanguageText, p3_Votes%>">
                            <ItemTemplate>
                                <asp:TextBox ID="txtVotes" runat="server" Text='<%# Bind("Votes") %>' Width="80%"
                                    MaxLength="4" Style="text-align: right"/>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*"
                                    ControlToValidate="txtVotes"></asp:RequiredFieldValidator>
                                <cc1:FilteredTextBoxExtender ID="txtDate_FilteredTextBoxExtender" runat="server"
                                    FilterType="Numbers" TargetControlID="txtVotes">
                                </cc1:FilteredTextBoxExtender>
                            </ItemTemplate>
                            <ItemStyle Width="10%" />
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
                    SelectCommand="p3_getBFinalCandidatesForFinalEntry" SelectCommandType="StoredProcedure">
                    <SelectParameters>
                        <asp:SessionParameter Name="FKRace" SessionField="idrace" Type="Decimal" />
                        <asp:SessionParameter Name="LevelCode" SessionField="MunicipalityCode" Type="String" />
                        <asp:SessionParameter Name="FKUser" SessionField="UserID" Type="Int32" />
                        <asp:SessionParameter Name="PSCode" SessionField="PSNumber" Type="String" />
                        <asp:QueryStringParameter Name="FKFCL" QueryStringField="listID" Type="String" />
                    </SelectParameters>
                </asp:SqlDataSource>
                <br />
                <table width="100%" cellpadding="0" cellspacing="0" frame="void" style="padding: 0px;
                    margin: 0px">
                    <tr>
                        <td>
                            <div id="Div1">
                                <div class="box">
                                    <table cellpadding="0" cellspacing="0" border="0">
                                        <tr>
                                            <td align="left">
                                                <asp:Button ID="Button1" runat="server" CausesValidation="false" Text="<%$ Resources:LanguageText, PgBBack %>"
                                                    CssClass="button100" 
                                                    
                                                    PostBackUrl="~/Phase3/Tracking/Results/EditResults/EditZR_OtvorenaLista2.aspx" />
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
