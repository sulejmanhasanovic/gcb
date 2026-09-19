<%@ Page Language="C#" MasterPageFile="~/masterpage.Master" AutoEventWireup="true"
    CodeBehind="BoxEdit.aspx.cs" Inherits="JIIS.Web.Phase3.Tracking.BoxEdit" Title="<% $Resources:LanguageText, zzzBoxEdit%>"
    Theme="Default" %>

<%@ Import Namespace="Resources" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContent" runat="server">
    <div id="PageTitle">
        <%=LanguageText.zzzBoxEdit%><hr style="border-width: 0px; background-color: #718ca5;"
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
                <table width="100%">
                    <tr>
                        <td class="left_table_cell">
                            <asp:Label ID="Label8" runat="server" CssClass="text12_normal" Text="<%$Resources:LanguageText, tr_chooseTypeBag%>"></asp:Label>
                        </td>
                        <td class="right_table_cell">
                            <asp:DropDownList ID="ddlChooseTypeBag" runat="server" CssClass="drop_down_list"
                                Width="60%" DataSourceID="dsPSTypes" DataTextField="PSTypeNameDescription" DataValueField="PSTypeName"
                                AutoPostBack="True" OnDataBound="ddl_DataBound">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="left_table_cell">
                            <asp:Label ID="Label1" runat="server" Text="<%$Resources:LanguageText, tr_chooseBox%>"></asp:Label>
                        </td>
                        <td class="right_table_cell">
                            <asp:DropDownList ID="ddlBoxes" runat="server" CssClass="drop_down_list" Width="60%"
                                DataSourceID="dsNumberOfBags" DataTextField="BoxName" DataValueField="BoxName"
                                AutoPostBack="True" OnDataBound="ddl_DataBound" OnSelectedIndexChanged="ddlBoxes_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <asp:Panel ID="panelData" runat="server" Visible="false">
                        <tr>
                            <td class="left_table_cell">
                                <br />
                            </td>
                            <td class="right_table_cell">
                            </td>
                        </tr>
                        <%--<tr>
                            <td class="left_table_cell">
                                <asp:Label ID="Label2" runat="server" Text="Status" CssClass="text12_normal"></asp:Label>
                            </td>
                            <td class="right_table_cell">
                                <asp:Label ID="lblStatus" runat="server" CssClass="text12_normal"></asp:Label>
                            </td>
                        </tr>--%>
                        <tr>
                            <td class="left_table_cell">
                                <asp:Label ID="Label10" runat="server" Text="Status" CssClass="text12_normal"></asp:Label>
                            </td>
                          
                           <td class="right_table_cell">
                                <asp:DropDownList ID="DropDownList1" runat="server" Width="30%" 
                                     AutoPostBack="True" DataSourceID="SqlDataSource1" DataTextField="BoxStatusDesc" DataValueField="BoxStatus">
                                </asp:DropDownList>
                            
                           </td>
                           
                        </tr>
                        <tr>
                            <td class="left_table_cell">
                                <asp:Label ID="Label3" runat="server" Text="Total Number Of Envelopes" CssClass="text12_normal"></asp:Label>
                            </td>
                            <td class="right_table_cell">
                                <asp:TextBox ID="txtTotalNoOfEnvelopes" runat="server" CssClass="text_box"></asp:TextBox>
                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender24" runat="server" TargetControlID="txtTotalNoOfEnvelopes"
                                    FilterType="Numbers">
                                </cc1:FilteredTextBoxExtender>
                            </td>
                        </tr>
                        <tr>
                            <td class="left_table_cell">
                                <asp:Label ID="Label4" runat="server" Text="Rejected In Sorting" CssClass="text12_normal"></asp:Label>
                            </td>
                            <td class="right_table_cell">
                                <asp:TextBox ID="txtRejectedInSorting" runat="server" CssClass="text_box"></asp:TextBox>
                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender12" runat="server" TargetControlID="txtRejectedInSorting"
                                    FilterType="Numbers">
                                </cc1:FilteredTextBoxExtender>
                            </td>
                        </tr>
                        <tr>
                            <td class="right_table_cell" colspan="2">
                                <asp:GridView ID="gvBoxDetail" runat="server" AutoGenerateColumns="False" DataSourceID="dsCombinations"
                                    Width="100%" GridLines="None" SkinID="KVoteGridView" DataKeyNames="Id">
                                    <Columns>
                                        <asp:TemplateField HeaderText="">
                                            <ItemTemplate>
                                                <table id="Table1">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="Label2" runat="server" Text="<%$Resources:LanguageText, GVHeaderType%> "></asp:Label>
                                                            <%#Container.DataItemIndex + 1%>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="">
                                            <ItemTemplate>
                                                <asp:Label ID="lblLevel" runat="server" Text="<% #Bind('LevelCode') %>"></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Number Of Ballots Sorted">
                                            <ItemTemplate>
                                                <asp:TextBox ID="tBoxNumberEnvLevel" runat="server" MaxLength="6" CssClass="text_box"
                                                    Text="<% #Bind('NoOfBallotsSorted') %>"></asp:TextBox>
                                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" TargetControlID="tBoxNumberEnvLevel"
                                                    FilterType="Numbers">
                                                </cc1:FilteredTextBoxExtender>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$Resources:LanguageText, tr_controlCount%>">
                                            <ItemTemplate>
                                                <asp:TextBox ID="tBoxControlCount" runat="server" CssClass="text_box" Text="<% #Bind('NoOfBallotsCounted') %>"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*"
                                                    ControlToValidate="tBoxControlCount"></asp:RequiredFieldValidator>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$Resources:LanguageText, tr_validBallots%>">
                                            <ItemTemplate>
                                                <asp:TextBox ID="tBoxValidBallots" runat="server" MaxLength="6" CssClass="text_box"
                                                    Text="<% #Bind('NoOfValidBallots') %>"></asp:TextBox>
                                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="tBoxValidBallots"
                                                    FilterType="Numbers">
                                                </cc1:FilteredTextBoxExtender>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator21" runat="server" ErrorMessage="*"
                                                    ControlToValidate="tBoxValidBallots"></asp:RequiredFieldValidator>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$Resources:LanguageText, tr_invalidBallots%>">
                                            <ItemTemplate>
                                                <asp:TextBox ID="tBoxInvalidBallots" runat="server" MaxLength="6" CssClass="text_box"
                                                    Text="<% #Bind('NoOfInvalidBallots') %>"></asp:TextBox>
                                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender245" runat="server" TargetControlID="tBoxInvalidBallots"
                                                    FilterType="Numbers">
                                                </cc1:FilteredTextBoxExtender>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*"
                                                    ControlToValidate="tBoxInvalidBallots"></asp:RequiredFieldValidator>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </td>
                        </tr>
                        <tr>
                            <td class="left_table_cell">
                                &nbsp;
                            </td>
                            <td class="right_table_cell">
                                <asp:Button ID="btnSave" runat="server" Text="<%$Resources:LanguageText, BUpdate %>"
                                    CssClass="button100" OnClick="btnSave_Click" />
                                &nbsp;&nbsp;&nbsp;
                                <asp:Button ID="btnCancel" runat="server" Text="<%$Resources:LanguageText, BCancel %>"
                                    CssClass="button100" OnClick="btnCancel_Click" />
                            </td>
                        </tr>
                    </asp:Panel>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <div style="height: 10px;">
    </div>
    <div class="line">
    </div>
    <asp:SqlDataSource ID="dsNumberOfBags" runat="server" ConnectionString="<%$ ConnectionStrings:BVOTEConnectionString %>"
        SelectCommand="p3_getBoxByType" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:ControlParameter ControlID="ddlChooseTypeBag" Name="boxType" PropertyName="SelectedValue"
                Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="dsPSTypes" runat="server" ConnectionString="<%$ ConnectionStrings:BVOTEConnectionString %>"
        SelectCommand="p3_getPSTypes" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
    <asp:SqlDataSource ID="dsCombinations" runat="server" ConnectionString="<%$ ConnectionStrings:BVOTEConnectionString %>"
        SelectCommand="p3_getBoxDetailForEdit" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:ControlParameter ControlID="ddlBoxes" Name="boxName" PropertyName="SelectedValue"
                Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:BVOTEConnectionString %>" 
        SelectCommand="p3_getBoxStatus" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
</asp:Content>
