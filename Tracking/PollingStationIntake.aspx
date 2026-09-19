<%@ Page Language="C#" MasterPageFile="~/masterpage.Master" AutoEventWireup="true"
    CodeBehind="PollingStationIntake.aspx.cs" Inherits="JIIS.Web.Phase3.Tracking.PollingStationIntake"
    Theme="Default" %>

<%@ Import Namespace="Resources" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphContent" runat="server">
    <div id="PageTitle">
        <%=LanguageText.p3_mPollingStationIntake%><hr style="border-width: 0px; background-color: #718ca5;"
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
                                    <asp:Button ID="btnSend" runat="server" Text="<%$Resources:LanguageText, p3_insert%>"
                                        OnClick="btnSend_Click" CssClass="button100" />
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
                
                <table width="100%">
                    <tr>
                        <td class="left_table_cell">
                            <asp:Label ID="lblLevel" runat="server" Text="Choose level:" CssClass="text12_normal"></asp:Label>
                        </td>
                        <td class="right_table_cell">
                            <asp:DropDownList ID="ddlLevels" runat="server" CssClass="drop_down_list" AutoPostBack="True"
                                DataSourceID="sqldsLevels" DataTextField="MunRegion" DataValueField="MunicipalityCode"
                                OnDataBound="ddlLevels_DataBound" 
                                onselectedindexchanged="ddlLevels_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <div runat="server" id="skrij" visible="false">
                    <tr>
                        <td >
                            &nbsp;</td>
                        <td  align="right">
                            <asp:Button ID="Button6" runat="server" onclick="Button6_Click" Text="Received All" CssClass="button100"/>
                        </td>
                    </tr>
                    </div>
                </table>
                
                <asp:GridView ID="gvUsers" runat="server" AutoGenerateColumns="False" SkinID="KVoteGridView"
                    PageSize="1000" DataSourceID="sqldsOrgUnits" Width="100%" DataKeyNames="Id,PSCode"
                    OnRowDataBound="gvUsers_RowDataBound" ondatabound="gvUsers_DataBound">
                    <Columns>
                        <asp:TemplateField HeaderText="<%$Resources:LanguageText, PgArchiveNumber%>">
                            <ItemTemplate>
                                <%#Container.DataItemIndex + 1%>
                                <asp:Label ID="lbbroj" runat="server" Text="."></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="5%" />
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="5%" />
                        </asp:TemplateField>
                        <asp:TemplateField SortExpression="PSCode" HeaderText="<%$Resources:LanguageText, p3_PollingStation%>">
                            <EditItemTemplate>
                                <asp:TextBox ID="psCode" runat="server" Text='<%# Bind("PSCode") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("PSCode") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="30%" />
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="30%" />
                        </asp:TemplateField>
                         <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="cb" runat="server" AutoPostBack="True" />
                                        </ItemTemplate>
                                        <ItemStyle Width="40px" />
                                    </asp:TemplateField>
                               
                       
                        <asp:TemplateField HeaderText="<%$Resources:LanguageText, de_comment%>">
                            <ItemTemplate>
                                <asp:TextBox ID="TextBox1" runat="server" ></asp:TextBox>
                            </ItemTemplate>
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
                <br />
              
                <div id="Div1" runat="server" visible="false">
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
        <asp:SqlDataSource ID="sqldsOrgUnits" runat="server" ConnectionString="<%$ ConnectionStrings:BVOTEConnectionString %>"
            SelectCommand="p3_getPollingStationForMunCode2_1" 
            SelectCommandType="StoredProcedure">
            <SelectParameters>
                <asp:ControlParameter ControlID="ddlLevels" Name="code" 
                    PropertyName="SelectedValue" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
        <div style="height: 10px;">
        </div>
        <div class="line">
        </div>
    </div>
</asp:Content>
