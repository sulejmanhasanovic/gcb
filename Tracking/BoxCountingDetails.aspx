<%@ Page Language="C#" MasterPageFile="~/masterpage.Master" AutoEventWireup="true"
    CodeBehind="BoxCountingDetails.aspx.cs" Inherits="JIIS.Web.Phase3.Tracking.BoxCountingDetails"
    Title="<%$Resources:LanguageText, tr_boxCountDetails%>" Theme="Default" %>

<%@ Import Namespace="Resources" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContent" runat="server">
    <div id="PageTitle">
        <%=LanguageText.tr_boxCountDetails%><hr style="border-width: 0px; background-color: #718ca5;"
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
                </table>
                
            </ContentTemplate>
        </asp:UpdatePanel>
        <%--<div id="divMess" style="text-align: center;">
            <table  width="100%">
                    <tr>
                        <td align="center">
                            <asp:Label ID="lblCheck1" runat="server" ForeColor="Red" Text="<%$Resources:LanguageText, p3_error1%>"
                                 Font-Bold="True" Font-Size="Larger"></asp:Label>
                        </td>
                    </tr>
              </table>
        </div>--%><asp:GridView ID="GridView1" runat="server" 
            AutoGenerateColumns="False" DataSourceID="dsCombinations"
                        Width="740px" GridLines="None" OnRowDataBound="GridView1_RowDataBound" 
                        DataKeyNames="CRID,Level" 
            onselectedindexchanged="GridView1_SelectedIndexChanged">
                        <Columns>
                            <asp:TemplateField HeaderText="" ItemStyle-Width="200px">
                                <ItemTemplate>
                                    <table id="Table1">
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label2" runat="server" 
                                                    Text="<%$Resources:LanguageText, GVHeaderType%> "></asp:Label>
                                                <%#Container.DataItemIndex + 1%>
                                            </td>
                                        </tr>
                                    </table>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Left" />
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="" ItemStyle-Width="50px">
                                <ItemTemplate>
                                    <asp:Label ID="lblLevel" runat="server" Text='<%#Eval("Level") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="<%$Resources:LanguageText, tr_controlCount%>" 
                                ItemStyle-Width="130px">
                                <ItemTemplate>
                                    <asp:TextBox ID="tBoxControlCount" runat="server" CssClass="text_box"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*"
                                        ControlToValidate="tBoxControlCount"></asp:RequiredFieldValidator>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="<%$Resources:LanguageText, tr_validBallots%>" 
                                ItemStyle-Width="130px">
                                <ItemTemplate>
                                    <asp:TextBox ID="tBoxValidBallots" runat="server"  MaxLength="6" 
                                        CssClass="text_box"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" 
                                        TargetControlID="tBoxValidBallots" FilterType="Numbers">
                                    </cc1:FilteredTextBoxExtender>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*"
                                        ControlToValidate="tBoxValidBallots"></asp:RequiredFieldValidator>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="<%$Resources:LanguageText, tr_invalidBallots%>" 
                                ItemStyle-Width="130px">
                                <ItemTemplate>
                                    <asp:TextBox ID="tBoxInvalidBallots" runat="server"  MaxLength="6" 
                                        CssClass="text_box"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" 
                                        TargetControlID="tBoxInvalidBallots" FilterType="Numbers">
                                    </cc1:FilteredTextBoxExtender>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*"
                                        ControlToValidate="tBoxInvalidBallots"></asp:RequiredFieldValidator>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="" ItemStyle-Width="5px">
                                <ItemTemplate>
                                    <asp:Label ID="lblMessage" runat="server" CssClass="error_message"></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                &nbsp;<br />
        <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <div style="text-align: left;">
                </div>
                <br />
                <asp:Label ID="lblMessage" runat="server" Text="" ForeColor="Red"></asp:Label>
                <asp:Label ID="lblCheck1" runat="server" Visible="False" ForeColor="Red" Text="<%$Resources:LanguageText, p3_error1%>"
                                 Font-Bold="True" Font-Size="Larger"></asp:Label>
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
                            <asp:Button ID="btnSave" runat="server" Text="<%$Resources:LanguageText, p2_btnAdd %>" CssClass="button100" OnClick="btnSave_Click" />
                            &nbsp;&nbsp;&nbsp;
                            <asp:Button ID="btnCancel" runat="server" Text="<%$Resources:LanguageText, BCancel %>"
                                CssClass="button100" OnClick="btnCancel_Click" />
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <div class="line">
    </div>
</asp:Content>
