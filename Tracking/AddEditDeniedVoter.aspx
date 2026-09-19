<%@ Page Title="" Language="C#" MasterPageFile="~/masterpage.Master" AutoEventWireup="true" Theme="Default"
    CodeBehind="AddEditDeniedVoter.aspx.cs" Inherits="JIIS.Web.Phase3.Tracking.AddEditDeniedVoter" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<%@ Import Namespace="Resources" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphContent" runat="server">
    <div id="PageTitle">
        <%=LanguageText.tr_deniedBagReceiveVerification%><hr style="border-width: 0px; background-color: #718ca5;"
            noshade="noshade" />
            <div>
            </div>
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
                                    
                                    <td width="60%">
                                    <asp:Label ID="Label8" runat="server" Text="  VREÆA: " Font-Bold="False" 
            ForeColor="Black"></asp:Label>
                                        <asp:Label ID="lblBagsName" runat="server" Text="Label"></asp:Label>
                                        </td>
                                    
                                    
                                    
                                    <td align="right" style="width: 90%">
                                        <asp:Button ID="Button3" runat="server" CssClass="button100" Text="<%$ Resources:LanguageText, BCancel %>"
                                            OnClick="Button1_Click" CausesValidation="False" />&nbsp;
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
                    <asp:Label ID="lblEnteredAllDeniedVoters" runat="server" ForeColor="#FF3300" 
                        Visible="False" Text="<%$ Resources:LanguageText, lblEnteredDeniedVoter %>"></asp:Label>
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
                    <asp:Label ID="Label1" runat="server" Text="JMB"
                        CssClass="text12_normal"></asp:Label>
                </td>
                <td style="padding-left: 5px; font-weight: normal; width: 223px;">
                    <asp:TextBox ID="txtJMB" runat="server" Width="200px" 
                        CssClass="text_box" ></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        ControlToValidate="txtJMB" ErrorMessage="*"></asp:RequiredFieldValidator>
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
                    <asp:Label ID="Label2" runat="server" Text="<%$ Resources:LanguageText, lblNumberBagsDeniedVoter %>"
                        CssClass="text12_normal"></asp:Label>
                </td>
                <td style="padding-left: 5px; font-weight: normal; width: 223px;">
                            <asp:DropDownList ID="ddlNumberBag" runat="server" Width="200px" DataSourceID="dsNumberBag"
                                DataTextField="PollingStationCode" DataValueField="Id" 
                        AutoPostBack="True" Enabled="False">
                            </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                        ControlToValidate="txtJMB" ErrorMessage="*" Enabled="False"></asp:RequiredFieldValidator>
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
                    <asp:Label ID="Label3" runat="server" Text="<%$Resources:LanguageText, lblReasonDenied%>"
                        CssClass="text12_normal"></asp:Label>
                </td>
                <td style="padding-left: 5px; font-weight: normal; width: 223px;">
                            <asp:DropDownList ID="ddlDenyReason" runat="server" Width="200px" DataSourceID="dsDenyReason"
                                DataTextField="ReasonName" DataValueField="id" >
                            </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
                        ControlToValidate="txtJMB" ErrorMessage="*" Enabled="False"></asp:RequiredFieldValidator>
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
                    <asp:Label ID="Label4" runat="server" Text="<%$Resources:LanguageText, lblNameOfDeniedVoter%>"
                        CssClass="text12_normal"></asp:Label>
                </td>
                <td style="padding-left: 5px; font-weight: normal; width: 223px;">
                    
                    <%--<asp:TextBox ID="txtDate1" runat="server" CssClass="text_box" 
                        Width="200px"></asp:TextBox>--%><asp:TextBox ID="txtName" runat="server" CssClass="text_box" Width="200px"></asp:TextBox>
                    
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                        ControlToValidate="txtName" ErrorMessage="*"></asp:RequiredFieldValidator>
                </td>
                <td>
                    &nbsp;
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
                    <asp:Label ID="Label5" runat="server" Text="<%$Resources:LanguageText, lblSurnameOfDeniedVoter%>"
                        CssClass="text12_normal"></asp:Label>
                </td>
                <td style="padding-left: 5px; font-weight: normal">
                  
                        
                    <asp:TextBox ID="txtSurname" runat="server" CssClass="text_box" Width="200px"></asp:TextBox>
                    
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                        ControlToValidate="txtSurname" ErrorMessage="*"></asp:RequiredFieldValidator>
                    
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
                    &nbsp;</td>
                <td style="padding-left: 5px; font-weight: normal">
                  
                        
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            
            <tr>
                <td class="left_table_cell">
                    &nbsp;</td>
                <td style="padding-left: 5px; font-weight: normal">
                  
                        
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                  
                        
                                        <asp:Button ID="Button4" runat="server" CssClass="button100" Text="<%$ Resources:LanguageText, PgAdminUsersBEditUser %>"
                                            OnClick="Button2_Click" />
                    
                </td>
                <td align = "left">
                    <asp:Button ID="Button1" runat="server" CausesValidation="False" 
                        CssClass="button100" OnClick="Button1_Click" 
                        Text="<%$ Resources:LanguageText, bFinish %>" />
                    &nbsp; </td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            
            <tr>
                <td>
                    <br />
                </td>
            </tr>
            
            <asp:GridView ID="gvDeniedVoter" runat="server" Width="560px"
                            SkinID="KVoteGridView" AutoGenerateColumns="False" OnRowDataBound="GridView_RowDataBound"
                            DataSourceID="dsDeniedVoters" PageSize="100"
                            GridLines="Vertical" DataKeyNames="IdDeniedVoter">
                            <Columns>
                               
                               <%-- <asp:CommandField ShowDeleteButton="True" />--%>
                               
                                <asp:BoundField DataField="IdDeniedVoter" HeaderText="IdDeniedVoter" 
                                    SortExpression="IdDeniedVoter" InsertVisible="False" ReadOnly="True" 
                                    Visible="False" />
                                <asp:BoundField DataField="JMB" HeaderText="JMB" 
                                    SortExpression="JMB" />
                                <asp:BoundField DataField="NumberBags" HeaderText="NumberBags" 
                                    SortExpression="NumberBags" />
                                <asp:BoundField DataField="Reason" HeaderText="Reason" 
                                    SortExpression="Reason" />
                                     <asp:BoundField DataField="NameVoter" HeaderText="NameVoter" 
                                    SortExpression="NameVoter" />
                                    
                                    <asp:BoundField DataField="SurnameVoter" HeaderText="SurnameVoter" 
                                    SortExpression="SurnameVoter" />
                                    
                                    <asp:TemplateField HeaderText="<%$Resources:LanguageText, DocumentsMenuMainEdit%>"
                            HeaderStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <table style="width: 100%; text-align: left" align="center">
                                    <tr>
                                        <td style="text-align: left;">
                                            <table border="0" cellpadding="0" cellspacing="0" style="width: 100%;">
                                                <tr>
                                                    <td align="center" valign="middle">
                                                        <asp:ImageButton ID="imgbtnDelete" runat="server"
                                                            ImageAlign="Middle" ImageUrl="~/App_Themes/Default/default_images/delete.png"
                                                            OnClick="imgbtnDeleteDenVoters_Click" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                                    
                            </Columns>
                            <EmptyDataTemplate>
                                <table style="width: 100%">
                                    <tr>
                                        <td align="center">
                                            <asp:Label ID="lblNoData0" runat="server" Text="<%$Resources:LanguageText, noData%>"
                                                CssClass="text12_normal"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </EmptyDataTemplate>
                        </asp:GridView>
            
            <tr>
                <td>
                    <br />
                <asp:SqlDataSource ID="dsDenyReason" runat="server" ConnectionString="<%$ ConnectionStrings:BVOTEConnectionString %>"
                    SelectCommand="p3_GetAllDenyReasons" 
                    SelectCommandType="StoredProcedure">
                </asp:SqlDataSource>
                    <br />
                <asp:SqlDataSource ID="dsNumberBag" runat="server" ConnectionString="<%$ ConnectionStrings:BVOTEConnectionString %>"
                    SelectCommand="p3_getDataFromBagsByID" 
                    SelectCommandType="StoredProcedure">
                    <SelectParameters>
                        <asp:QueryStringParameter Name="Id" QueryStringField="id" Type="Int32" />
                    </SelectParameters>
                </asp:SqlDataSource>
                </td>
            </tr>
            
            </table>
        <div style="height: 10px;">
        </div>
        <div class="line">
        </div>
    </div>
    
    <asp:SqlDataSource ID="dsDeniedVoters" runat="server" ConnectionString="<%$ ConnectionStrings:BVOTEConnectionString %>"
        SelectCommand="p3_getDeniedVoters" SelectCommandType="StoredProcedure" 
        ProviderName="System.Data.SqlClient" DeleteCommand="p3_DeleteDeniedVoter" 
        DeleteCommandType="StoredProcedure">
        <SelectParameters>
            <asp:ControlParameter ControlID="lblBagsName" Name="NumberBags" 
                PropertyName="Text" Type="String" />
        </SelectParameters>
        <DeleteParameters>
            <asp:Parameter Name="ID" Type="Int32" />
        </DeleteParameters>
    </asp:SqlDataSource>
    
</asp:Content>
