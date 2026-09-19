<%@ Page Language="C#" MasterPageFile="~/masterpage.Master" AutoEventWireup="true"
    CodeBehind="BagsReceive.aspx.cs" Inherits="JIIS.Web.Phase3.Tracking.BagsReceive" Title="<%$Resources:LanguageText, tr_bagReceive%>"
    Theme="Default" %>

<%@ Import Namespace="Resources" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContent" runat="server">
    <div id="PageTitle">
        <%=LanguageText.tr_bagReceive%><hr style="border-width: 0px; background-color: #718ca5;"
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
                                        CausesValidation="False" OnClick="btnCancel_Click" />
                                </td>
                                <td style="text-align: right">
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
                <br />
                <table id="Table1" width="100%">
                    <tr>
                        <td class="left_table_cell">
                            <asp:Label ID="Label8" runat="server" Text="<%$Resources:LanguageText, tr_bagType%>"></asp:Label>
                        </td>
                        <td class="right_table_cell">
                            <asp:Label ID="lblType" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr runat="server" id="brP" visible="false">
                        <td class="left_table_cell">
                            <asp:Label ID="lblSecondTime" runat="server" Text="<%$Resources:LanguageText, tr_numberShipment %>"></asp:Label>
                        </td>
                        <td class="right_table_cell">
                            <asp:TextBox ID="tBoxShipment" runat="server" ReadOnly="true"></asp:TextBox>
                            &nbsp;&nbsp;&nbsp;
                            <asp:Label ID="lblNameNumberShipm" runat="server" Text="Ukupan broj pošiljki:"></asp:Label>
                            &nbsp;<asp:Label ID="lblNumberShipm" runat="server" Text="Label"></asp:Label>
                            /<asp:Label ID="lbltotalShipment" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="left_table_cell">
                            <asp:Label ID="lblNBag" runat="server" Text="<%$Resources:LanguageText, tr_NumberBag %>"></asp:Label>
                        </td>
                        <td class="right_table_cell">
                            <asp:DropDownList ID="ddlbagNumber" runat="server" Width="20%" DataSourceID="dsNumberOfBags"
                                DataTextField="PollingStationCode" DataValueField="PollingStationCode" OnDataBound="ddl_DataBound"
                                OnSelectedIndexChanged="ddlbagNumber_SelectedIndexChanged" AutoPostBack="true">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlbagNumber"
                                ErrorMessage="*"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                </table>
                <br />
                <table id="tblByMail" width="100%" runat="server" visible="false">
                    <tr>
                        <td class="left_table_cell">
                            <asp:Label ID="Label1" runat="server" Text="<%$Resources:LanguageText, tr_postBox %>"></asp:Label>
                        </td>
                        <td class="right_table_cell">
                            <asp:DropDownList ID="ddlPoBox" runat="server" Width="20%" DataSourceID="SqlDataSource1"
                                DataTextField="poBox" DataValueField="id">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr runat="server" id="drlist">
                        <td class="left_table_cell">
                            &nbsp;
                        </td>
                        <td class="right_table_cell">
                            <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal"
                                AutoPostBack="True" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged">
                                <asp:ListItem Text="<%$Resources:LanguageText, tr_regEnv %>" Value="1"></asp:ListItem>
                                <asp:ListItem Text="<%$Resources:LanguageText, tr_FastPost %>" Value="2"></asp:ListItem>
                            </asp:RadioButtonList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="RadioButtonList1"
                                Display="Dynamic" ErrorMessage="*"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr runat="server" id="trR" visible="false">
                        <td class="left_table_cell">
                            <asp:Label ID="Label4" runat="server" Text="<%$Resources:LanguageText, tr_regEnv %>">></asp:Label>
                        </td>
                        <td class="right_table_cell">
                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" TargetControlID="tBoxRegEnvelopes"
                                FilterType="Numbers">
                            </cc1:FilteredTextBoxExtender>
                            <asp:TextBox ID="tBoxRegEnvelopes" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr runat="server" id="trEx" visible="false">
                        <td class="left_table_cell">
                            <asp:Label ID="Label5" runat="server" Text="<%$Resources:LanguageText, tr_FastPost %>"></asp:Label>
                        </td>
                        <td class="right_table_cell">
                            <asp:TextBox ID="tBoxFastPost" runat="server"></asp:TextBox>
                            <cc1:FilteredTextBoxExtender ID="TextBox6_FilteredTextBoxExtender" FilterType="Numbers"
                                runat="server" Enabled="True" TargetControlID="tBoxFastPost">
                            </cc1:FilteredTextBoxExtender>
                        </td>
                    </tr>
                    <tr runat="server" id="trNe" visible="false">
                        <td class="left_table_cell">
                            <asp:Label ID="Label7" runat="server" Text="<%$Resources:LanguageText, tr_Undelivered %>"></asp:Label>
                        </td>
                        <td class="right_table_cell">
                            <asp:TextBox ID="tBoxUndelivered" runat="server"></asp:TextBox>
                            <cc1:FilteredTextBoxExtender ID="TextBox7_FilteredTextBoxExtender" FilterType="Numbers"
                                runat="server" Enabled="True" TargetControlID="tBoxUndelivered">
                            </cc1:FilteredTextBoxExtender>
                        </td>
                    </tr>
                    <tr runat="server" id="trO" visible="false">
                        <td class="left_table_cell">
                            <asp:Label ID="Label6" runat="server" Text="<%$Resources:LanguageText, tr_others %>"></asp:Label>
                        </td>
                        <td class="right_table_cell">
                            <asp:TextBox ID="tBoxOthers" runat="server"></asp:TextBox>
                            <cc1:FilteredTextBoxExtender ID="TextBox1_FilteredTextBoxExtender" FilterType="Numbers"
                                runat="server" Enabled="True" TargetControlID="tBoxOthers">
                            </cc1:FilteredTextBoxExtender>
                        </td>
                    </tr>
                    <tr visible="false">
                        <td class="left_table_cell">
                            <asp:Label ID="lblThirdTime" runat="server" Text="<%$Resources:LanguageText, tr_date %>"></asp:Label>
                        </td>
                        <td class="right_table_cell">
                            <asp:TextBox ID="tBoxDateReceived" runat="server"></asp:TextBox>
                            <cc1:CalendarExtender ID="tBoxDateReceived_CalendarExtender" runat="server" Enabled="True"
                                TargetControlID="tBoxDateReceived" Format="dd/MM/yyyy">
                            </cc1:CalendarExtender>
                        </td>
                    </tr>
                    <tr>
                        <td class="left_table_cell">
                            <asp:Label ID="Label2" runat="server" Text="<%$Resources:LanguageText, de_comment %>"></asp:Label>
                        </td>
                        <td class="right_table_cell">
                            <asp:TextBox ID="tBoxComment" runat="server" TextMode="MultiLine"></asp:TextBox>
                        </td>
                    </tr>
                    <tr visible="false">
                        <td class="left_table_cell">
                            <asp:Label ID="Label3" runat="server" Text="<%$Resources:LanguageText, tr_TypePosilka%>"></asp:Label>
                        </td>
                        <td class="right_table_cell">
                            <asp:DropDownList ID="ddlTypeShipment" Visible="false" runat="server" Width="30%"
                                OnDataBound="ddl_DataBound">
                                <asp:ListItem Text="<%$Resources:LanguageText, tr_normal%>"></asp:ListItem>
                                <asp:ListItem Text="<%$Resources:LanguageText, tr_returned%>"></asp:ListItem>
                                <asp:ListItem Text="<%$Resources:LanguageText, tr_registered%>"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                </table>
                <table id="tblNepotvrdjeni" width="100%" runat="server" visible="false">
                    <tr visible="false">
                        <td class="left_table_cell">
                            <asp:Label ID="Label11" runat="server" Text="<%$Resources:LanguageText, tr_NumberBag %>"></asp:Label>
                        </td>
                        <td class="right_table_cell">
                            <asp:TextBox ID="tBoxBagNumberNepotvrdjeni" runat="server" MaxLength="2"></asp:TextBox>
                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" FilterType="Numbers" runat="server"
                                Enabled="True" TargetControlID="tBoxBagNumberNepotvrdjeni">
                            </cc1:FilteredTextBoxExtender>
                        </td>
                    </tr>
                    <tr>
                        <td class="left_table_cell">
                            <asp:Label ID="Label15" runat="server" Text="<%$Resources:LanguageText, tr_numberEnvelopes %>"></asp:Label>
                        </td>
                        <td class="right_table_cell">
                            <asp:TextBox ID="tBoxNumberOfEnvNepotvrdjeni" runat="server"></asp:TextBox>
                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" FilterType="Numbers" runat="server"
                                Enabled="True" TargetControlID="tBoxNumberOfEnvNepotvrdjeni">
                            </cc1:FilteredTextBoxExtender>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                                ErrorMessage="*" ControlToValidate="tBoxNumberOfEnvNepotvrdjeni"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="left_table_cell">
                            <asp:Label ID="Label16" runat="server" Text="<%$Resources:LanguageText, tr_date %>"></asp:Label>
                        </td>
                        <td class="right_table_cell">
                            <asp:TextBox ID="tBoxDateReceivedNepotvrdjeni" runat="server" OnTextChanged="tBoxDateReceivedNepotvrdjeni_TextChanged"></asp:TextBox>
                            <cc1:CalendarExtender ID="tBoxDateReceivedNepotvrdjeni_CalendarExtender" runat="server"
                                Enabled="True" TargetControlID="tBoxDateReceivedNepotvrdjeni" Format="dd/MM/yyyy">
                            </cc1:CalendarExtender>
                        </td>
                    </tr>
                    <tr>
                        <td class="left_table_cell">
                            <asp:Label ID="Label17" runat="server" Text="<%$Resources:LanguageText, de_comment %>"></asp:Label>
                        </td>
                        <td class="right_table_cell">
                            <asp:TextBox ID="tBoxCommentNepotvrdjeni" runat="server" TextMode="MultiLine"></asp:TextBox>
                        </td>
                    </tr>
                </table>
                <table id="tblOtsustvo" width="100%" runat="server" visible="false">
                    <tr>
                        <td class="left_table_cell">
                            <asp:Label ID="Label10" runat="server" Text="<%$Resources:LanguageText, tr_numberEnvelopes %>"></asp:Label>
                        </td>
                        <td class="right_table_cell">
                            <asp:TextBox ID="tBoxNumberOfEnvOtsustvo" runat="server" 
                                ></asp:TextBox>
                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" FilterType="Numbers" runat="server"
                                Enabled="True" TargetControlID="tBoxNumberOfEnvOtsustvo">
                            </cc1:FilteredTextBoxExtender>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server"  ControlToValidate="tBoxNumberOfEnvOtsustvo"
                                ErrorMessage="*"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="left_table_cell">
                            <asp:Label ID="Label12" runat="server" Text="<%$Resources:LanguageText, tr_date %>"></asp:Label>
                        </td>
                        <td class="right_table_cell">
                            <asp:TextBox ID="tBoxDateReceivedOtsustvo" runat="server" OnTextChanged="tBoxDateReceivedOtsustvo_TextChanged"></asp:TextBox>
                            <cc1:CalendarExtender ID="tBoxDateReceivedOtsustvo_CalendarExtender" runat="server"
                                Enabled="True" TargetControlID="tBoxDateReceivedOtsustvo" Format="dd/MM/yyyy">
                            </cc1:CalendarExtender>
                        </td>
                    </tr>
                    <tr>
                        <td class="left_table_cell">
                            <asp:Label ID="Label13" runat="server" Text="<%$Resources:LanguageText, de_comment %>"></asp:Label>
                        </td>
                        <td class="right_table_cell">
                            <asp:TextBox ID="tBoxCommentOtsustvo" runat="server" TextMode="MultiLine"></asp:TextBox>
                        </td>
                    </tr>
                </table>
                <table id="tblBirackiSpisak" width="100%" runat="server" visible="false">
                    <tr>
                        <td class="left_table_cell">
                            <asp:Label ID="Label19" runat="server" Text="<%$Resources:LanguageText, tr_date %>"></asp:Label>
                        </td>
                        <td class="right_table_cell">
                            <asp:TextBox ID="tBoxDateReceivedBirackiSpisak" runat="server"></asp:TextBox>
                            <cc1:CalendarExtender ID="tBoxDateReceivedBirackiSpisak_CalendarExtender" runat="server"
                                Enabled="True" TargetControlID="tBoxDateReceivedBirackiSpisak" Format="dd/MM/yyyy">
                            </cc1:CalendarExtender>
                        </td>
                    </tr>
                    <tr>
                        <td class="left_table_cell">
                            <asp:Label ID="Label20" runat="server" Text="<%$Resources:LanguageText, de_comment %>"></asp:Label>
                        </td>
                        <td class="right_table_cell">
                            <asp:TextBox ID="tBoxDateCommentBirackiSpisak" runat="server" TextMode="MultiLine"></asp:TextBox>
                        </td>
                    </tr>
                </table>
                <br />
                <table style="width: 100%">
                    <tr>
                        <td class="left_table_cell" style="width: 250px;">
                            &nbsp;
                        </td>
                        <td class="right_table_cell">
                            <asp:Button ID="btnSave" runat="server" Text="<%$Resources:LanguageText, BAdd %>"
                                CssClass="button100" OnClick="btnSave_Click" />
                            &nbsp;&nbsp;&nbsp;
                            <asp:Button ID="btnCancel" runat="server" Text="<%$Resources:LanguageText, BCancel %>"
                                CssClass="button100" OnClick="btnC1ancel_Click" CausesValidation="False" />
                            &nbsp;&nbsp;&nbsp;
                            <asp:Button ID="btnFinish" runat="server" Text="<%$Resources:LanguageText, bFinish %>"
                                CssClass="button100" OnClick="btnFinish_Click" CausesValidation="False" />
                        </td>
                    </tr>
                </table>
                <br />
                <table width="100%" runat="server" id="tblMsg" visible="false">
                    <tr>
                        <td align="center">
                            <asp:Label ID="lblMsg" runat="server" Text="<%$Resources:LanguageText, zzDoesntMatch %>"
                                CssClass="error_message"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <br />
                        </td>
                    </tr>
                </table>
                <div style="padding: 5px 10px 0px 10px; font-weight: bold; font-size: 120%; background-color: #718ca5;
                    height: 25px; vertical-align: middle; text-align: center;">
                    <%= LanguageText.tr_receivedBags%>
                </div>
                <br />
                <asp:GridView ID="GridView2" runat="server" Width="100%" SkinID="KVoteGridView" AutoGenerateColumns="False"
                    DataSourceID="dsPOBox" PageSize="100" DataKeyNames="Id,PollingStationCode" OnRowDataBound="GridView2_RowDataBound">
                    <Columns>
                        <asp:BoundField DataField="id" HeaderText="id" SortExpression="id" Visible="false" />
                        <asp:BoundField DataField="PollingStationCode" HeaderText="<%$Resources:LanguageText, tr_NumberBag %>"
                            SortExpression="PollingStationCode" />
                        <asp:BoundField DataField="TypeOfPollingStationCode" HeaderText="<%$Resources:LanguageText, tr_psType %>"
                            SortExpression="TypeOfPollingStationCode" />
                        <asp:BoundField DataField="TotalReceivedEnvelopes" HeaderText="<%$Resources:LanguageText, tr_receivedEnvelopes %>"
                            SortExpression="TotalReceivedEnvelopes" />
                        <asp:BoundField DataField="DateReceived" HeaderText="<%$Resources:LanguageText, tr_dateReceived %>"
                            SortExpression="DateReceived" />
                        <asp:BoundField DataField="User_Username" HeaderText="<%$Resources:LanguageText, de_clerk %>"
                            SortExpression="User_Username" />
                        <asp:TemplateField HeaderText="">
                            <ItemTemplate>
                                <%--<asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# "BagsReceiveDetails.aspx?id="+Eval("id") %>'
                                    Text="<%$Resources:LanguageText, de_preview %>"></asp:HyperLink>
                                    &nbsp;--%>
                                <asp:LinkButton ID="linkEdit" runat="server" CssClass="linkpagertext" Font-Underline="false"
                                    OnClick="linkEdit_Click" Text="Edit" CausesValidation="false"></asp:LinkButton>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <table width="100%" runat="server" id="tblEdit">
                    <tr>
                        <td class="left_table_cell">
                            <asp:Label ID="Label28" runat="server" Text="<%$Resources:LanguageText, tr_NumberBag %>"></asp:Label>
                            &nbsp
                            <asp:Label ID="lblWhichBag" runat="server" Text="Label"></asp:Label>
                            &nbsp
                            <asp:Label ID="Label25" runat="server" Text="<%$Resources:LanguageText, tr_receivedEnvelopes %>"></asp:Label>
                        </td>
                        <td class="right_table_cell">
                            <asp:TextBox ID="txtEditNoEnv" runat="server" ValidationGroup="editPost"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*"
                                ControlToValidate="txtEditNoEnv" ValidationGroup="editPost"></asp:RequiredFieldValidator>
                            &nbsp;
                            <asp:Button ID="btnEditNoEnv" runat="server" Text="<%$Resources: LanguageText, BUpdate %>"
                                OnClick="btnEditNoEnv_Click" ValidationGroup="editPost" />
                            <asp:Button ID="Button6" runat="server" Text="<%$Resources: LanguageText, PgBClose %>"
                                OnClick="Button6_Click" CausesValidation="False" />
                        </td>
                    </tr>
                </table>
                <br />
                <asp:GridView ID="gvUO" runat="server" AutoGenerateColumns="False" Caption="Neuruceni i Ostali"
                    DataKeyNames="ID,Type" DataSourceID="SqlDataSource2" OnSelectedIndexChanged="gvUO_SelectedIndexChanged"
                    SkinID="KVoteGridView" Width="100%" OnRowDataBound="gvUO_RowDataBound">
                    <Columns>
                        <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" ReadOnly="True"
                            SortExpression="ID" Visible="False" />
                        <asp:BoundField DataField="ShipmentNumber" HeaderText="<%$Resources:LanguageText, tr_numberShipment %>"
                            SortExpression="ShipmentNumber" />
                        <asp:BoundField DataField="Type" HeaderText="<%$Resources:LanguageText, GVHeaderType %>"
                            SortExpression="Type" />
                        <%--<asp:TemplateField HeaderText="<%$Resources:LanguageText, tr_receivedEnvelopes %>">
                            <ItemTemplate>
                                <asp:Label ID="lblReceivedEnvelopes" runat="server" Text="<% #Eval('Value') %>"></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtReceivedEnvelopes" runat="server" Text="<% #Eval('Value') %>"></asp:TextBox>
                            </EditItemTemplate>
                        </asp:TemplateField>--%>
                        <asp:BoundField DataField="Value" HeaderText="<%$Resources:LanguageText, tr_receivedEnvelopes %>"
                            SortExpression="Value" />
                        <asp:BoundField DataField="User_Username" HeaderText="<%$Resources:LanguageText, de_clerk %>"
                            SortExpression="User_Username" />
                        <asp:BoundField DataField="dateReceive" HeaderText="<%$Resources:LanguageText, Data %>"
                            SortExpression="dateReceive" />
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="linkEditOthers" runat="server" CausesValidation="false" CssClass="linkpagertext"
                                    Font-Underline="false" OnClick="linkEditOthers_Click" Text="Edit"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <br />
                <table width="100%" runat="server" id="tblEditOthers">
                    <tr>
                        <td class="left_table_cell">
                            <asp:Label ID="Label9" runat="server" Text="<%$Resources:LanguageText, tr_NumberBag %>"></asp:Label>
                            &nbsp
                            <asp:Label ID="lblWhichBag1" runat="server" Text="Label"></asp:Label>
                            &nbsp
                            <asp:Label ID="Label26" runat="server" Text="<%$Resources:LanguageText, tr_receivedEnvelopes %>"></asp:Label>
                        </td>
                        <td class="right_table_cell">
                            <asp:TextBox ID="txtEditOthers" runat="server" ValidationGroup="editOthers"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*"
                                ControlToValidate="txtEditOthers" ValidationGroup="editOthers"></asp:RequiredFieldValidator>
                            &nbsp;
                            <asp:Button ID="btnEditOthers" runat="server" Text="<%$Resources: LanguageText, BUpdate %>"
                                ValidationGroup="editOthers" OnClick="btnEditOthers_Click" />
                            <asp:Button ID="Button7" runat="server" CausesValidation="False" Text="<%$Resources: LanguageText, PgBClose %>"
                                OnClick="Button7_Click" />
                        </td>
                    </tr>
                </table>
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:BVOTEConnectionString %>"
                    SelectCommand="p3_GetData_p3_FromOtherMaterials" SelectCommandType="StoredProcedure">
                    <SelectParameters>
                        <asp:SessionParameter Name="ShimpentNumber" SessionField="shipment" Type="Decimal" />
                    </SelectParameters>
                </asp:SqlDataSource>
                <asp:Panel ID="Panel3" runat="server" Style="z-index: 100; left: 34%; position: absolute;
                    top: 50%; width: 645px; height: 81px;" Visible="False" Wrap="false">
                    <asp:Panel ID="Panel2" runat="server" Style="cursor: move; background-color: #DDDDDD;
                        border: solid 1px Gray; color: Black" Height="70px" Width="500px">
                        <div>
                            <p>
                                <asp:Label ID="Label24" runat="server" Text="<%$ Resources:LanguageText, zzSuccessMessage %>"
                                    Font-Size="Small" ForeColor="green"></asp:Label>
                            </p>
                            <p style="text-align: center;">
                                <asp:Button ID="okButton" runat="server" CssClass="button120" CausesValidation="False"
                                    OnClick="okButton_Click" Text="<%$ Resources:LanguageText, ok %>" />
                            </p>
                        </div>
                    </asp:Panel>
                </asp:Panel>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <div style="height: 10px;">
    </div>
    <div class="line">
    </div>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:BVOTEConnectionString %>"
        SelectCommand="p3_GetPOBOX" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
    <asp:SqlDataSource ID="dsPSTypes" runat="server" ConnectionString="<%$ ConnectionStrings:BVOTEConnectionString %>"
        SelectCommand="p3_getPSTypes" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
    <asp:SqlDataSource ID="dsNumberOfBags" runat="server" ConnectionString="<%$ ConnectionStrings:BVOTEConnectionString %>"
        SelectCommand="p3_getBagFromType" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:SessionParameter Name="type" SessionField="p" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="dsPOBox" runat="server" ConnectionString="<%$ ConnectionStrings:BVOTEConnectionString %>"
        SelectCommand="p3_GetData_p3_PO_PackageWtihShipmentNumber" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:ControlParameter ControlID="tBoxShipment" Name="ShimpentNumber" PropertyName="Text"
                Type="Decimal" />
            <asp:SessionParameter Name="DateEntered" SessionField="date1" Type="String" />
            <asp:SessionParameter Name="type" SessionField="p" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>
</asp:Content>
