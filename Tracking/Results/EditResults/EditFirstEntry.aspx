<%@ Page Language="C#" MasterPageFile="~/masterpage.Master" AutoEventWireup="true" CodeBehind="EditFirstEntry.aspx.cs" Inherits="JIIS.Web.Phase3.Tracking.Results.EditResults.EditFirstEntry" Title="Untitled Page"  Theme="Default" %>
<%@ Import Namespace="Resources" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="CrystalDecisions.Web,  Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphContent" runat="server">
    <div id="PageTitle">
        <%=LanguageText.p3_mEditResults%><hr style="border-width: 0px; background-color: #718ca5;"
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
                                <td style="text-align: right">
                                    &nbsp;
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
                <table style="width: 100%;">
                    <tr>
                        <td colspan="2">
                        </td>
                    </tr>
                    <tr>
                        <td class="left_table_cell">
                            <asp:Label ID="Label5" runat="server" CssClass="text12_normal" Text="<%$Resources:LanguageText, p1candidacyrace%>"></asp:Label>
                        </td>
                        <td class="right_table_cell">
                            <asp:DropDownList ID="ddlActiveRace" runat="server" AutoPostBack="True" 
                                CssClass="drop_down_list" DataSourceID="SqlDataSource1" DataTextField="nameR" 
                                DataValueField="CRID" 
                                onselectedindexchanged="ddlActiveRace_SelectedIndexChanged">
                            </asp:DropDownList>
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                                ConnectionString="<%$ ConnectionStrings:BVOTEConnectionString %>" 
                                SelectCommand="p3_getRaceForResultsEditControlorTracking" SelectCommandType="StoredProcedure">
                            </asp:SqlDataSource>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*"
                                ControlToValidate="ddlActiveRace"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="left_table_cell">
                            <asp:Label ID="Label7" runat="server" CssClass="text12_normal" 
                                    Text="<%$Resources:LanguageText, rt_kategorija%>"></asp:Label></td>
                        <td class="right_table_cell">
                            <asp:DropDownList ID="DropDownList1" runat="server" 
                                CssClass="drop_down_list" DataSourceID="SqlDataSource2" 
                                DataTextField="MunicipalityName" DataValueField="MunicipalityCode" 
                                AutoPostBack="True">
                            </asp:DropDownList>
                            <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                                ConnectionString="<%$ ConnectionStrings:BVOTEConnectionString %>" 
                                SelectCommand="p3_getMunForResultsEditControlorTracking" 
                                SelectCommandType="StoredProcedure">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="ddlActiveRace" Name="race" 
                                        PropertyName="SelectedValue" Type="Decimal" />
                                </SelectParameters>
                            </asp:SqlDataSource>
                        </td>
                    </tr>
                </table>
                <asp:GridView ID="GridView1" runat="server" SkinID="KVoteGridView" Width="100%" AutoGenerateColumns="False"
                    AllowPaging="True" AllowSorting="True" DataSourceID="SqlDataSource3" 
                    onselectedindexchanged="GridView1_SelectedIndexChanged" PageSize="300" >
                  
                    <Columns>
                        <%--<asp:CheckBoxField DataField="Processed" HeaderText="<%$Resources:LanguageText, lblProcessed%>"
                            SortExpression="Processed"></asp:CheckBoxField>--%><asp:BoundField 
                            DataField="MunicipalityCode" HeaderText="<%$Resources:LanguageText, candidateregion%>" 
                            SortExpression="MunicipalityCode" ItemStyle-Width="20%"/>
                        <asp:BoundField DataField="MunicipalityName" HeaderText="<%$Resources:LanguageText, rt_kategorija%>" 
                            SortExpression="MunicipalityName" ItemStyle-Width="30%"/>
                        <asp:BoundField DataField="PSNumber" HeaderText="<%$Resources:LanguageText, rt_kutija%>"  
                            SortExpression="PSNumber" ItemStyle-Width="40%"/>
                               <asp:TemplateField HeaderText="<%$Resources:LanguageText, DocumentsMenuMainEdit%>"
                            HeaderStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <table style="width: 100%; text-align: left" align="center">
                                    <tr>
                                        <td style="text-align: left;">
                                            <table border="0" cellpadding="0" cellspacing="0" style="width: 100%;">
                                                <tr>
                                                    <td align="center" valign="middle">
                                                        <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/App_Themes/Default/default_images/edit.png" OnClick="ImageButton1_OnClick"/>
                                                       </td>
                                                    
                                                </tr>
                                    </tr>
                                </table>
                                </td> </tr> </table>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                    </Columns>
                    <EmptyDataTemplate>
                        <table style="width: 100%">
                            <tr>
                                <td align="center">
                                    <asp:Label ID="lblNoData" runat="server" Text="No Data Found" CssClass="text12_normal"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </EmptyDataTemplate>
                </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSource3" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:BVOTEConnectionString %>" 
                    SelectCommand="p3_getDataForResultsEditControlorTracking" 
                    SelectCommandType="StoredProcedure">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="ddlActiveRace" Name="race" 
                            PropertyName="SelectedValue" Type="Decimal" />
                        <asp:ControlParameter ControlID="DropDownList1" Name="munCode" 
                            PropertyName="SelectedValue" Type="String" />
                    </SelectParameters>
                </asp:SqlDataSource>
                <br />
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

