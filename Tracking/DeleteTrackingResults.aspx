<%@ Page Language="C#" MasterPageFile="~/masterpage.Master" AutoEventWireup="true"
    CodeBehind="DeleteTrackingResults.aspx.cs" Inherits="JIIS.Web.Phase3.Tracking.DeleteTrackingResults" Title="<%$Resources:LanguageText, tr_archive%>"
    Theme="Default" %>

<%@ Import Namespace="Resources" %>
<asp:Content ContentPlaceHolderID="cphContent" runat="server" ID="cContent">
    <div id="PageTitle">
        <%=LanguageText.oktomvri_DeleteBags%>
        <span>
            <%=LanguageText.oktomvri_DeleteBags%></span>
        <hr style="border-width: 0px; background-color: #718ca5;" noshade="noshade" />
    </div>
    <div id="MainBody">
        <div style="height: 3px;">
        </div>
        <div class="box">
            <table cellpadding="0" cellspacing="0" border="0" width="100%">
                <tr>
                    <td class="left_table_cell">
                        &nbsp;</td>
                    <td class="right_table_cell">
                        &nbsp;</td>
                </tr>
            </table>
        </div>
        <br />
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <table border="0" style="width: 100%;">
                    <tr>
                        <td class="left_table_cell">
                            <asp:Label ID="Label1" runat="server" Text="<%$ Resources:LanguageText, p1candidacyrace %>"
                                CssClass="text12_normal"></asp:Label>
                        </td>
                        <td class="right_table_cell">
                            <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource1"
                                DataTextField="CRName" DataValueField="FKRace" CssClass="drop_down_list180"
                                Width="80%">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="DropDownList1"
                                ErrorMessage="*"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="left_table_cell">
                            <asp:Label ID="Label2" runat="server" Text="<%$ Resources:LanguageText, tr_NumberBag %>"
                                CssClass="text12_normal"></asp:Label>
                        </td>
                        <td class="right_table_cell">
                            <asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource2"
                                DataTextField="PSCode" DataValueField="PSCode" CssClass="drop_down_list180"
                                Width="80%">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="DropDownList2"
                                ErrorMessage="*"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="left_table_cell">
                            <asp:Label ID="Label5" runat="server" Text="<%$ Resources:LanguageText, cbe_status %>"
                                CssClass="text12_normal"></asp:Label>
                        </td>
                        <td class="right_table_cell">
                            <asp:DropDownList ID="DropDownList3" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource4"
                                DataTextField="Description" DataValueField="IDDeletedStatus" CssClass="drop_down_list180"
                                Width="80%">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="left_table_cell">
                            <asp:Label ID="Label4" runat="server" Text="<%$ Resources:LanguageText, de_comment %>"
                                CssClass="text12_normal"></asp:Label>
                        </td>
                        <td class="right_table_cell">
                            <asp:TextBox ID="TextBox1" runat="server" TextMode="MultiLine" Width="80%"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1"
                                ErrorMessage="*"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="left_table_cell">
                        </td>
                        <td class="right_table_cell">
                            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="<%$ Resources:LanguageText, GVSysAdminGroupDeleteAlt %>"
                                CssClass="button180" />
                        </td>
                    </tr>
                    <tr>
                        <td class="left_table_cell">
                            &nbsp;
                        </td>
                        <td class="right_table_cell">
                            <%--<asp:RequiredFieldValidator ID="rfvOrgUnitName" runat="server" ControlToValidate="txtName"
                        ErrorMessage="<%$ Resources:LanguageText, RFVOrgUnitName %>" Display="None" SetFocusOnError="true"
                        ValidationGroup="OrgUnitValidate"></asp:RequiredFieldValidator>--%>
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:BVOTEConnectionString %>"
                                SelectCommand="oktomvriDeleteTrackingResultsRace" 
                                SelectCommandType="StoredProcedure">
                            </asp:SqlDataSource>
                            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:BVOTEConnectionString %>"
                                SelectCommand="oktomvriDeleteTrackingResultsPSCode" 
                                SelectCommandType="StoredProcedure">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="DropDownList1" Name="race" PropertyName="SelectedValue"
                                        Type="Int32" />
                                </SelectParameters>
                            </asp:SqlDataSource>
                            <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:BVOTEConnectionString %>"
                                SelectCommand="p3_getStatusDeletedPS" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
                            
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