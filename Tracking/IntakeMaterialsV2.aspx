<%@ Page Language="C#" MasterPageFile="~/masterpage.Master" AutoEventWireup="true"
    CodeBehind="IntakeMaterialsV2.aspx.cs" Inherits="JIIS.Web.Phase3.Tracking.IntakeMaterialsV2"
    Theme="Default" %>

<%@ Import Namespace="Resources" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphContent" runat="server">
    <div id="PageTitle">
        <%=LanguageText.p3_mMaterialsIntake%><hr style="border-width: 0px; background-color: #718ca5;"
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
                                          <asp:Button ID="Button2" runat="server" Text="<%$Resources:LanguageText, p3_insert%>"
                                        OnClick="btnSend_Click" CssClass="button100" />
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
                <br />
                <table width="100%">
                    <tr>
                        <td class="left_table_cell">
                            <asp:Label ID="lblLevel" runat="server" Text="Choose level:" CssClass="text12_normal"></asp:Label>
                        </td>
                        <td class="right_table_cell">
                            <asp:DropDownList ID="ddlLevels" runat="server" CssClass="drop_down_list" AutoPostBack="True"
                                DataSourceID="sqldsLevels" DataTextField="MunRegion" DataValueField="MunicipalityCode"
                                OnDataBound="ddlLevels_DataBound" OnSelectedIndexChanged="ddlLevels_SelectedIndexChanged"
                                AppendDataBoundItems="True">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <div runat="server" id="skrij" visible="false">
                    </div>
                    <div runat="server" id="divSelectAll" visible="false">
                        <tr>
                            <td colspan="2" align="right">
                                &nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Button ID="btnSelectAll" runat="server" CssClass="button100" OnClick="btnSelectAll_Click"
                                    Text="<%$ Resources:LanguageText, p3_SelectAll %>" />
                            </td>
                        </tr>
                    </div>
                </table>
                <asp:GridView ID="gvUsers" runat="server" AutoGenerateColumns="False" SkinID="KVoteGridView"
                    PageSize="1000" DataSourceID="SqlDataSource3" Width="100%" OnRowDataBound="gvUsers_RowDataBound"
                    DataKeyNames="ID" OnDataBound="gvUsers_DataBound">
                    <Columns>
                        <asp:TemplateField HeaderText="ID" InsertVisible="False" SortExpression="ID" Visible="False">
                            <EditItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Eval("ID") %>'></asp:Label>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("ID") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="PSCode" HeaderText="<%$Resources:LanguageText, p3_PollingStationCode%>"
                            SortExpression="PSCode" />
                        <asp:BoundField DataField="Material" HeaderText="<%$Resources:LanguageText, p3_materialName%>"
                            ItemStyle-HorizontalAlign="Left" SortExpression="Material">
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="<%$Resources:LanguageText, PgDocumentUploadIDocumentComment%>">
                            <ItemTemplate>
                                <asp:TextBox ID="tbComment" runat="server" Text='<%# Bind("Comment") %>'></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="<%$Resources:LanguageText, p3_received%>">
                            <ItemTemplate>
                                <asp:CheckBox ID="cb" runat="server" AutoPostBack="True" />
                            </ItemTemplate>
                            <ItemStyle Width="40px" />
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
                <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:BVOTEConnectionString %>"
                    SelectCommand="p3_Get_IntakeMaterials1" SelectCommandType="StoredProcedure">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="ddlLevels" Name="LevelCode" PropertyName="SelectedValue"
                            Type="String" />
                    </SelectParameters>
                </asp:SqlDataSource>
                <asp:SqlDataSource ID="SqlDataSource2" runat="server"></asp:SqlDataSource>
                <br />
                <div id="Div1" visible="false" runat="server">
                    <div class="box">
                        <table cellpadding="0" cellspacing="0" border="0" width="100%">
                            <tr>
                                <td style="text-align: left">
                                    <asp:Button ID="Button1" runat="server" CssClass="button100" Text="<%$Resources:LanguageText, bback%>"
                                        CausesValidation="False" OnClick="Button5_Click" />
                                </td>
                                <td style="text-align: right">
                                    <asp:Button ID="btnSend1" runat="server" Text="<%$Resources:LanguageText, p3_insert%>"
                                        OnClick="btnSend_Click" CssClass="button100" />
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
                <div style="height: 10px;">
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:SqlDataSource ID="sqldsLevels" runat="server" ConnectionString="<%$ ConnectionStrings:BVOTEConnectionString %>"
            SelectCommand="p3GetMunRegionFromPollStation" SelectCommandType="StoredProcedure">
        </asp:SqlDataSource>
        <div style="height: 10px;">
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:BVOTEConnectionString %>"
                SelectCommand="p3_IntakeMaterials" SelectCommandType="StoredProcedure">
                <SelectParameters>
                    <asp:ControlParameter ControlID="ddlLevels" Name="level" PropertyName="SelectedValue"
                        Type="String" />
                </SelectParameters>
            </asp:SqlDataSource>
        </div>
       <%-- <asp:UpdateProgress ID="uprogressFolderClicked" runat="server" 
            AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="0">
            <ProgressTemplate>
                <table class="loaderFolders" border="0">
                    <tr>
                        <td align="center" valign="middle">
                            <img src="../loading.gif" align="middle" alt="Loading..." title="Loading..." />
                        </td>
                    </tr>
                </table>
            </ProgressTemplate>
        </asp:UpdateProgress>--%>
        <div class="line">
        </div>
    </div>
</asp:Content>
