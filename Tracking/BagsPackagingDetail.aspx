<%@ Page Language="C#" MasterPageFile="~/masterpage.Master" AutoEventWireup="true"
    CodeBehind="BagsPackagingDetail.aspx.cs" Inherits="JIIS.Web.Phase3.Tracking.BagsPackagingDetail"
    Title="<%$Resources:LanguageText, tr_packDetails%>" Theme="Default" %>

<%@ Import Namespace="Resources" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContent" runat="server">
    <div id="PageTitle">
        <%=LanguageText.tr_packDetails%>
        <hr style="border-width: 0px; background-color: #718ca5;" noshade="noshade" />
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
                        <td class="left_table_cell_bih300px">
                            <asp:Label ID="Label8" runat="server" Text="<%$Resources:LanguageText, tr_bagType%>"></asp:Label>
                        </td>
                        <td class="right_table_cell">
                            <asp:Label ID="lblPSType" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="left_table_cell_bih300px">
                            <asp:Label ID="Label110" runat="server" Text="<%$Resources:LanguageText, tr_NumberBag%>"></asp:Label>
                        </td>
                        <td class="right_table_cell">
                            <asp:Label ID="lblBagNumber" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                </table>
                <br />
                <table width="100%">
                    <tr>
                        <td class="left_table_cell_bih300px">
                            <asp:Label ID="Label1" runat="server" Text="<%$Resources:LanguageText, tr_combination%>"></asp:Label>
                        </td>
                        <td class="right_table_cell">
                            <asp:DropDownList ID="ddlCombination" runat="server" DataSourceID="ds_Combinations"
                                DataTextField="Combination" DataValueField="Combination" OnDataBound="ddlCombination_DataBound"
                                AutoPostBack="True" 
                                onselectedindexchanged="ddlCombination_SelectedIndexChanged" TabIndex="1">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="*"
                                ControlToValidate="ddlCombination" Display="Dynamic">
                            </asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <div id="valid" runat="server">
                        <tr>
                            <td class="left_table_cell_bih300px">
                                <asp:Label ID="Label3" runat="server" Text="<%$Resources:LanguageText, tr_listRow14%>"></asp:Label>
                            </td>
                            <td class="right_table_cell">
                                <asp:TextBox ID="tBoxNumberEnvelopesVoterList" runat="server" CssClass="text_box"
                                    AutoPostBack="true" 
                                    OnTextChanged="tBoxNumberEnvelopesVoterList_TextChanged" TabIndex="2"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*"
                                    ControlToValidate="tBoxNumberEnvelopesVoterList" Display="Dynamic"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="left_table_cell_bih300px">
                                <asp:Label ID="Label4" runat="server" Text="<%$Resources:LanguageText, tr_sign6and7%>"></asp:Label>
                            </td>
                            <td class="right_table_cell">
                                <asp:TextBox ID="tBoxNumberSignatuers" runat="server" CssClass="text_box" 
                                    TabIndex="3"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*"
                                    ControlToValidate="tBoxNumberSignatuers" Display="Dynamic"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="left_table_cell_bih300px">
                                <asp:Label ID="Label5" runat="server" Text="<%$Resources:LanguageText, tr_numCountEnv%>"></asp:Label>
                            </td>
                            <td class="right_table_cell">
                                <asp:TextBox ID="tBoxNumberCountedEnvelopes" runat="server" CssClass="text_box" AutoPostBack="true"
                                    OnTextChanged="tBoxNumberCountedEnvelopes_TextChanged" TabIndex="4"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*"
                                    ControlToValidate="tBoxNumberCountedEnvelopes" Display="Dynamic"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="left_table_cell_bih300px">
                                <asp:Label ID="Label7" runat="server" Text="<%$Resources:LanguageText, tr_difference%>"></asp:Label>
                            </td>
                            <td class="right_table_cell">
                                <asp:TextBox ID="tBoxDifference" runat="server" CssClass="text_box" 
                                    ReadOnly="true" TabIndex="5"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*"
                                    ControlToValidate="tBoxDifference" Display="Dynamic"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                    </div>
                    <div id="invalid" runat="server">
                        <tr>
                            <td class="left_table_cell_bih300px">
                                <asp:Label ID="Label6" runat="server" Text="<%$Resources:LanguageText, tr_listRow14%>"></asp:Label>
                            </td>
                            <td class="right_table_cell">
                                <asp:TextBox ID="txtInvalid" runat="server" CssClass="text_box" AutoPostBack="true"
                                    OnTextChanged="tBoxNumberEnvelopesVoterList_TextChanged" TabIndex="6"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="*"
                                    ControlToValidate="txtInvalid" Display="Dynamic"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                    </div>
                    <tr>
                        <td class="left_table_cell_bih300px">
                            <asp:Label ID="Label2" runat="server" Text="<%$Resources:LanguageText, tr_packSeries%>"></asp:Label>
                        </td>
                        <td class="right_table_cell">
                            <asp:DropDownList ID="ddlBoxNumber" runat="server" AutoPostBack="True" DataSourceID="dsBoxes"
                                DataTextField="BoxName" DataValueField="BoxName" 
                                OnDataBound="ddl_DataBound" TabIndex="7">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="*"
                                ControlToValidate="ddlBoxNumber" Display="Dynamic"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="left_table_cell_bih300px">
                        </td>
                        <td class="right_table_cell">
                            <asp:Label ID="lblMessage" runat="server" Text="" ForeColor="Red"></asp:Label>
                        </td>
                    </tr>
                </table>
                <table style="width: 100%">
                    <tr>
                        <td class="left_table_cell_bih300px">
                            &nbsp;
                        </td>
                        <td class="right_table_cell">
                            <asp:Button ID="btnEnter" runat="server" Text="<%$Resources:LanguageText, enter%>"
                                CssClass="button100" OnClick="btnEnter_Click" TabIndex="8" />&nbsp;&nbsp;&nbsp;
                            <asp:Button ID="btnFinish" runat="server" Text="<%$Resources:LanguageText, tr_bagFinished%>"
                                CssClass="button100" OnClick="btnFinish_Click" CausesValidation="false" 
                                TabIndex="9" />
                        </td>
                    </tr>
                </table>
                <br />
                <div style="padding: 5px 10px 0px 10px; font-weight: bold; font-size: 120%; background-color: #718ca5;
                    height: 25px; vertical-align: middle; text-align: center;">
                    <%=LanguageText.tr_enteredCombinations%>
                </div>
                <br />
                <asp:GridView ID="GridView1" runat="server" Width="100%" SkinID="KVoteGridView" AutoGenerateColumns="False"
                    DataSourceID="dsEnteredCombinations" DataKeyNames="id" PageSize="1000">
                    <Columns>
                    
                        <asp:BoundField DataField="Combination" HeaderText="<%$Resources:LanguageText, tr_combination%>"
                            SortExpression="Combination" />
                        <asp:BoundField DataField="TotalKoverata" HeaderText="<%$Resources:LanguageText, tr_totalNoEnvelopes%>"
                            ReadOnly="True" SortExpression="TotalKoverata" />
                        <asp:BoundField DataField="BoxName" HeaderText="<%$Resources:LanguageText, tr_boxName%>"
                            SortExpression="BoxName" />
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
                        <asp:BoundField DataField="Id" HeaderText="<%$Resources:LanguageText, tr_combination%>"
                            SortExpression="id" Visible="false" />
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
                  <table width="100%" runat="server" id="tblEdit" visible="false">
                    <tr>
                        <td class="left_table_cell">
                            <asp:Label ID="Label28" runat="server" Text="<%$Resources:LanguageText, tr_boxName %>"></asp:Label>
                            &nbsp
                            <asp:Label ID="lblWhichBag" runat="server" Text="Label"></asp:Label>
                            &nbsp
                            <asp:Label ID="Label25" runat="server" Text="<%$Resources:LanguageText, tr_totalNoEnvelopes %>"></asp:Label>
                        </td>
                        <td class="right_table_cell">
                            <asp:TextBox ID="txtEditNoEnv" runat="server" ValidationGroup="editPost"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="*"
                                ControlToValidate="txtEditNoEnv" ValidationGroup="editPost"></asp:RequiredFieldValidator>
                            &nbsp;
                            <asp:Button ID="btnEditNoEnv" runat="server" Text="<%$Resources: LanguageText, BUpdate %>"
                                OnClick="btnEditNoEnv_Click" ValidationGroup="editPost" />
                            <asp:Button ID="Button6" runat="server" Text="<%$Resources: LanguageText, PgBClose %>"
                                OnClick="Button6_Click" CausesValidation="False" />
                        </td>
                    </tr>
                </table>
                <hr style="border-width: 0px; background-color: #718ca5;" noshade="noshade" />
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <div class="line">
    </div>
    <asp:SqlDataSource ID="ds_Combinations" runat="server" ConnectionString="<%$ ConnectionStrings:BVOTEConnectionString %>"
        SelectCommand="p3_getCombinations" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
    <asp:SqlDataSource ID="dsBoxes" runat="server" ConnectionString="<%$ ConnectionStrings:BVOTEConnectionString %>"
        SelectCommand="p3_getBoxNumbersPackaging" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:QueryStringParameter Name="PSType" QueryStringField="PSType" Type="String" />
            <asp:ControlParameter ControlID="ddlCombination" Name="Combination" PropertyName="SelectedValue"
                Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="dsEnteredCombinations" runat="server" ConnectionString="<%$ ConnectionStrings:BVOTEConnectionString %>"
        SelectCommand="p3_getDataForEnteredCombinations" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:QueryStringParameter Name="PSCode" QueryStringField="PS" Type="String" />
            <asp:QueryStringParameter Name="PSType" QueryStringField="PSType" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>
</asp:Content>
