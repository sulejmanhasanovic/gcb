<%@ Page Language="C#" MasterPageFile="~/masterpage.Master" AutoEventWireup="true"
    CodeBehind="BoxSortingDetails.aspx.cs" Inherits="JIIS.Web.Phase3.Tracking.BoxSortingDetails"
    Title="<%$Resources:LanguageText, tr_boxSortDetails%>" Theme="Default" %>

<%@ Import Namespace="Resources" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContent" runat="server">
    <div id="PageTitle">
        <%=LanguageText.tr_boxSortDetails%><hr style="border-width: 0px; background-color: #718ca5;"
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
                                        CausesValidation="False" OnClick="btnBack_Click" />
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
                            <asp:Label ID="Label8" runat="server" Text="<%$Resources:LanguageText, tr_boxNumber%>"></asp:Label>
                        </td>
                        <td class="right_table_cell">
                           <asp:Label ID="lblBoxNumber" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="left_table_cell_bih300px">
                            <asp:Label ID="Label1" runat="server" Text="<%$Resources:LanguageText, tr_numberEnvelopes%>"></asp:Label>
                        </td>
                        <td class="right_table_cell">
                            <asp:Label ID="lblNumberEnvelopes" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                </table>
                <br />
                <table id="Table2" width="100%">
                    <tr>
                        <td class="left_table_cell_bih300px">
                            <asp:Label ID="Label3" runat="server" Text="<%$Resources:LanguageText, tr_denEnvelopes%>"></asp:Label>
                        </td>
                        <td class="right_table_cell">
                            <asp:TextBox ID="tBoxDeniedEnvelopes" runat="server" CssClass="text_box"  MaxLength="6"
                                ontextchanged="tBoxDeniedEnvelopes_TextChanged" AutoPostBack="true"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*"
                                    ControlToValidate="tBoxDeniedEnvelopes"></asp:RequiredFieldValidator>
                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="tBoxDeniedEnvelopes" FilterType="Numbers">
                            </cc1:FilteredTextBoxExtender>
                        </td>
                    </tr>
                </table>
            <%--</ContentTemplate>
        </asp:UpdatePanel>
        <br />
        <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
            <ContentTemplate>--%>
            <br />
                <div style="text-align: left;">
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="dsCombinations"
                        ShowHeader="False" Width="550px" GridLines="None" 
                        onrowdatabound="GridView1_RowDataBound" DataKeyNames="CRID,Level" 
                      >
                        <Columns>
                            <asp:TemplateField HeaderText="No.">
                                <ItemTemplate>
                                    <table id="Table1">
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label2" runat="server" Text="<%$Resources:LanguageText, GVHeaderType%> " ></asp:Label>
                                                <%#Container.DataItemIndex + 1%>
                                               
                                            </td>
                                        </tr>
                                    </table>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Left" />
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="No.">
                                <ItemTemplate>
                                    <asp:Label ID="lblLevel" runat="server" Text='<%#Eval("Level") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="No.">
                                <ItemTemplate>
                                    <asp:TextBox ID="tBoxNumberEnvLevel" runat="server"  MaxLength="6" CssClass="text_box" Text="0" OnTextChanged="onTextChanged" AutoPostBack="True"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" TargetControlID="tBoxNumberEnvLevel" FilterType="Numbers">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Left" />
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
                <br />
                <asp:Label ID="lblMessage" runat="server" Text="" ForeColor="Red"></asp:Label>
                <table id="Table3" width="100%">
                    <tr>
                        <td class="left_table_cell_bih300px">
                            <asp:Label ID="Label4" runat="server" Text="<%$Resources:LanguageText, m_TotalBallotsCounting%>"></asp:Label>
                        </td>
                        <td class="right_table_cell">
                            <asp:TextBox ID="tBoxTotalNumberEnvelopes" runat="server" CssClass="text_box" MaxLength="6"></asp:TextBox>
                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" FilterType ="Numbers" TargetControlID="tBoxTotalNumberEnvelopes">
                            </cc1:FilteredTextBoxExtender>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:SqlDataSource ID="dsCombinations" runat="server" ConnectionString="<%$ ConnectionStrings:BVOTEConnectionString %>"
            SelectCommand="p3_GetLevelsForCombination" SelectCommandType="StoredProcedure">
            <SelectParameters>
                <asp:QueryStringParameter Name="Combination" QueryStringField="Combination" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
        <br />
        <table style="width: 100%">
            <tr>
                <td class="left_table_cell" style="width: 250px;">
                    &nbsp;
                </td>
                <td class="right_table_cell">
                    <asp:Button ID="btnSave" runat="server" Text="<%$Resources:LanguageText, enter %>" CssClass="button100" OnClick="btnSave_Click" />
                    &nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnCancel" runat="server" Text="<%$Resources:LanguageText, BCancel %>"
                        CssClass="button100" OnClick="btnCancel_Click" />
                </td>
            </tr>
        </table>
    </div>
    <div class="line">
    </div>
</asp:Content>
