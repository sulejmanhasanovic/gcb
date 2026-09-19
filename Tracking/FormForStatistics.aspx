<%@ Page Language="C#" MasterPageFile="~/masterpage.Master" AutoEventWireup="true"
    CodeBehind="FormForStatistics.aspx.cs" Inherits="JIIS.Web.Phase3.Tracking.FormForStatistics"
    Title="<%$Resources:LanguageText, tr_bagControlCount%>" Theme="Default" %>

<%@ Import Namespace="Resources" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContent" runat="server">
    <div id="PageTitle">
        <%=LanguageText.p3_insertShipment%>
        <hr style="border-width: 0px; background-color: #718ca5;" noshade="noshade" />
    </div>
    <div id="MainBody">
        <div style="height: 3px;">
        </div>
        <div id="Div2">
            <div class="box">
                <table cellpadding="0" cellspacing="0" border="0" width="100%">
                    <tr>
                        <td style="text-align: left">
                            <asp:Button ID="Button5" runat="server" CssClass="button100" Text="<%$Resources:LanguageText, bback%>"
                                CausesValidation="False" OnClick="Button5_Click" TabIndex="7" />
                        </td>
                        <td style="text-align: right">
                            <asp:Button ID="Button1" runat="server" CssClass="button100" 
                                Text="<%$Resources:LanguageText, GVDocumentCommentEditAlt %>" 
                                onclick="btnSave_Click" TabIndex="6" />
                        </td>
                    </tr>
                </table>
            </div>
        </div>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <br />
                <table id="Table1" width="100%">
                    <tr>
                        <td align="left">
                            <asp:Label ID="Label1" runat="server" Text="<%$Resources:LanguageText, tr_date %>"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:Label ID="Label2" runat="server" Text="<%$Resources:LanguageText, p3_MEC_totalPos %>"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:Label ID="Label3" runat="server" Text="<%$Resources:LanguageText, tr_numberShipment %>"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:Label ID="Label4" runat="server" Text="<%$Resources:LanguageText, p3_MEC_totalOtherPost %>"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:Label ID="Label5" runat="server" Text="<%$Resources:LanguageText, PgDocumentUploadIDocumentComment %>"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="txtDate" runat="server" Height="30px" TabIndex="1"></asp:TextBox>
                            <asp:CompareValidator ID="CompareValidator1" runat="server"
                                       ErrorMessage="<%$Resources:LanguageText, errMessageDate %>"
                                       ControlToValidate="txtDate"
                                       Type="Date"
                                       Operator="LessThanEqual"
                                       ValueToCompare='<%# DateTime.Now.ToString("d") %>'
                                       Display="Dynamic">
                            </asp:CompareValidator>
                            <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy" TargetControlID="txtDate">
                            </cc1:CalendarExtender>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"  Display="Dynamic" ControlToValidate="txtDate"
                                ErrorMessage="*"></asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <asp:TextBox ID="txtTotalPost" runat="server" Height="30px" TabIndex="2"></asp:TextBox>
                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" 
                                FilterType="Numbers" TargetControlID="txtTotalPost" ValidChars="6">
                            </cc1:FilteredTextBoxExtender>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"  Display="Dynamic" ControlToValidate="txtTotalPost"
                                ErrorMessage="*"></asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <asp:TextBox ID="TxtShipmentN" runat="server" Height="30px"  AutoPostBack="true"
                                ontextchanged="TxtShipmentN_TextChanged" TabIndex="3" ></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                                ControlToValidate="TxtShipmentN" Display="Dynamic" ErrorMessage="*"></asp:RequiredFieldValidator>
                            <br />
                            <asp:Label ID="lblM" runat="server" Text="Broj posilke vec postoi" ForeColor="Red" Visible="false"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtOtherPost" runat="server" Height="30px" TabIndex="4"></asp:TextBox>
                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" 
                                FilterType="Numbers" TargetControlID="txtOtherPost"  >
                            </cc1:FilteredTextBoxExtender>
                             <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"  Display="Dynamic" ControlToValidate="txtOtherPost"
                                ErrorMessage="*"></asp:RequiredFieldValidator>
                        </td>
                        
                        <td>
                            <asp:TextBox ID="txtComment" runat="server" Height="30px" TabIndex="5"></asp:TextBox>
                        </td>
                    </tr>
                </table>
                <br />
             <table cellpadding="0" cellspacing="0" border="0" width="100%">
                <tr>
                    <td style="text-align: left">
                             <asp:GridView ID="GridView2" runat="server" Width="100%" SkinID="KVoteGridView" AutoGenerateColumns="False"
                    DataSourceID="SqlDataSource1" PageSize="100" onrowdatabound="GridView2_RowDataBound" 
                                 DataKeyNames="ID" ShowFooter="True">
                    <Columns>
                        <%--<asp:BoundField DataField="ID" HeaderText="ID" 
                            InsertVisible="False" ReadOnly="True" SortExpression="ID" />--%>
                        <asp:BoundField DataField="dateReceive" HeaderText="<%$Resources:LanguageText, tr_date %>" 
                            SortExpression="dateReceive" />
                             <asp:BoundField DataField="shipmentnumber" HeaderText="<%$Resources:LanguageText, tr_numberShipment %>"
                            SortExpression="shipmentnumber" />
                        <asp:BoundField DataField="shipmentN" HeaderText="<%$Resources:LanguageText, p3_MEC_totalPos %>"
                            SortExpression="shipmentN" />
                       
                        <asp:BoundField DataField="totalOtherPost" HeaderText="<%$Resources:LanguageText, p3_MEC_totalOtherPost %>"
                            SortExpression="totalOtherPost" />
                        <asp:BoundField DataField="comment" HeaderText="<%$Resources:LanguageText, PgDocumentUploadIDocumentComment %>"
                            SortExpression="comment" />
                        <asp:TemplateField HeaderText="<%$Resources:LanguageText, DocumentsMenuMainEdit%>"
                            HeaderStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <table style="width: 100%; text-align: left" align="center">
                                    <tr>
                                        <td style="text-align: left;">
                                            <table border="0" cellpadding="0" cellspacing="0" style="width: 100%;">
                                                <tr>
                                                    <td align="center" valign="middle">
                                                        <asp:HyperLink ID="hlEdit" runat="server" CssClass="grid_link" ImageUrl="~/App_Themes/Default/default_images/edit.png"
                                                            ToolTip="<%$ Resources:LanguageText, DocumentsMenuMainEdit %>" Text="<%$ Resources:LanguageText, GVSysAdminOrgUnitEdit %>"></asp:HyperLink>
                                                    </td>
                                                    <%--<td align="center" valign="middle">
                                                        <asp:ImageButton ID="imgbtnDelete" runat="server" AlternateText="<%$ Resources:LanguageText, GVSysAdminOrgUnitDeleteAlt %>"
                                                            ImageAlign="Middle" ImageUrl="~/App_Themes/Default/default_images/delete.png"
                                                            OnClick="imgbtnDeleteOrgUnit_Click" ToolTip="<%$ Resources:LanguageText, GVSysAdminOrgUnitToolTip %>" />
                                                    </td>--%>
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
                </asp:GridView>
                             <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                                 ConnectionString="<%$ ConnectionStrings:BVOTEConnectionString %>" 
                                 SelectCommand="p3_ShowShipment" SelectCommandType="StoredProcedure">
                             </asp:SqlDataSource>
                    </td>
                    
                </tr>
            </table>
            </ContentTemplate>
        </asp:UpdatePanel>
        <div class="box">
            <table cellpadding="0" cellspacing="0" border="0" width="100%">
                <tr>
                    <td style="text-align: left">
                        <asp:Button ID="Button2" runat="server" CssClass="button100" Text="<%$Resources:LanguageText, bback%>"
                            CausesValidation="False" OnClick="Button5_Click" />
                    </td>
                    <td style="text-align: right">
                        <asp:Button ID="btnSave" runat="server" CssClass="button100" Text="<%$Resources:LanguageText, GVDocumentCommentEditAlt %>"
                            OnClick="btnSave_Click" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <div style="height: 10px;">
    </div>
    <div class="line">
    </div>
</asp:Content>
