<%@ Page Language="C#" MasterPageFile="~/masterpage.Master" AutoEventWireup="true"
    CodeBehind="GenerateBags.aspx.cs" Inherits="JIIS.Web.Phase3.Tracking.GenerateBags" Title="<%$Resources:LanguageText, tr_bagReceive%>"
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
                            <asp:Label ID="Label8" runat="server" Text="<%$Resources:LanguageText, tr_chooseTypeBag%>"></asp:Label>
                        </td>
                        <td class="right_table_cell">
                            <asp:DropDownList ID="ddlChooseTypeBag" runat="server" Width="50%" DataSourceID="dsPSTypes"
                                DataTextField="PSTypeNameDescription" DataValueField="PSTypeName" AutoPostBack="True"
                                OnDataBound="ddl_DataBound" OnSelectedIndexChanged="ddlChooseTypeBag_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    
                    <tr>
                        <td class="left_table_cell">
                            <asp:Literal ID="lblOpstina" runat="server" 
                                Text="<%$ Resources:LanguageText, p1municipality %>" Visible="False"></asp:Literal>
                                <asp:Literal ID="Literal1" runat="server" 
                                Text=":*" Visible="False"></asp:Literal>
                        </td>
                        <td class="right_table_cell" colspan="2">
                            <asp:DropDownList ID="ddlOpstina" runat="server" CssClass="text12_normal" 
                                DataSourceID="SqlDataSource1" DataTextField="Name" DataValueField="Code" 
                                Visible="False">
                            </asp:DropDownList>
                            <asp:SqlDataSource ID="SqlMobileTeams" runat="server" 
                                ConnectionString="<%$ ConnectionStrings:BVOTEConnectionString %>" SelectCommand="SELECT p3_MobileTeams.MunCode,MunicipalityName,NumberOfMobile,isnull(a.Generisano,'0') as Generisano,Entity  FROM p3_MobileTeams 
inner join p3_Municipalities on p3_MobileTeams.MunCode=p3_Municipalities.MunicipalityCode 
left join 
(select left(PollingStationCode,3) as MunCode,COUNT(PollingStationCode) as Generisano from p3_Bags
where TypeOfPollingStationCode='M'
group by left(PollingStationCode,3)) as a
on p3_MobileTeams.MunCode=a.MunCode
where NumberOfMobile&gt;0
order by  p3_MobileTeams.MunCode

"></asp:SqlDataSource>
                        </td>
                    </tr>
                    
                    <tr runat="server" id="brP" >
                        <td class="left_table_cell" visible="true">
                            &nbsp;</td>
                        <td class="right_table_cell">
                            <asp:RadioButtonList ID="rbListNumberCopies" runat="server" 
                                RepeatDirection="Horizontal" 
                                onselectedindexchanged="rbListNumberCopies_SelectedIndexChanged" 
                                AutoPostBack="True">
                                <asp:ListItem Selected="True">1</asp:ListItem>
                                <asp:ListItem>10</asp:ListItem>
                                <asp:ListItem>20</asp:ListItem>
                                <asp:ListItem>50</asp:ListItem>
                                <asp:ListItem>100</asp:ListItem>
                            </asp:RadioButtonList>
                            <asp:TextBox ID="PSCode" runat="server"></asp:TextBox>
                            <asp:Button ID="btnGenerateMobileTeams" runat="server" 
                                onclick="btnGenerateMobileTeams_Click" Text="Generate" Visible="False" />
                            <br />
                            <br />
                            <asp:Label ID="lblSuccessGenerateBags" runat="server" 
                                Text="Generisanje uspjesno!" Visible="False"></asp:Label>
                            <asp:Label ID="lblNotSuccessGenerateBags" runat="server" 
                                Text="Greska prilikom generisanja !" Visible="False"></asp:Label>
                            <br />
                            <asp:GridView ID="gvMobileTeams" runat="server" AutoGenerateColumns="False" 
                                DataSourceID="SqlMobileTeams" onrowdatabound="gvMobileTeams_RowDataBound" 
                                Visible="False">
                                <Columns>
                                    <asp:TemplateField HeaderText="Kod" SortExpression="MunCode">
                                        <ItemTemplate>
                                            <asp:Label ID="lblKod" runat="server" Text='<%# Bind("MunCode") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="MunicipalityName" HeaderText="Opstina" 
                                        SortExpression="MunicipalityName" />
                                    <asp:TemplateField HeaderText="Broj timova" SortExpression="NumberOfMobile">
                                        <ItemTemplate>
                                            <asp:Label ID="lblBrojTimova" runat="server" 
                                                Text='<%# Bind("NumberOfMobile") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Generisano">
                                        <ItemTemplate>
                                            <asp:Label ID="lblGenerisano" runat="server" Text='<%# Bind("Generisano") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Entitet">
                                        <ItemTemplate>
                                            <asp:Label ID="lblEntity" runat="server" Text='<%# Bind("Entity") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chkMobilni" runat="server" />
                                        </ItemTemplate>
                                        <HeaderTemplate>
                                            <asp:CheckBox ID="cbAllMobilni" runat="server" AutoPostBack="True" 
                                                oncheckedchanged="cbAllMobilni_CheckedChanged" />
                                        </HeaderTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                            <asp:Button ID="btnGenerateOdsustvo" runat="server" 
                                onclick="btnGenerateOdsustvo_Click" Text="Generate" Visible="False" />
                            <br />
&nbsp;<br />
                            <asp:GridView ID="gvOdsustvo" runat="server" AutoGenerateColumns="False" 
                                DataSourceID="SqlOdsustvo" Visible="False">
                                <Columns>
                                    <asp:TemplateField HeaderText="Biračko mjesto" SortExpression="PollingStation">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPollingStation" runat="server" 
                                                Text='<%# Bind("PollingStation") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="Odsustvo" HeaderText="Tip" ReadOnly="True" 
                                        SortExpression="Odsustvo" />
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chkOdsustvo" runat="server" />
                                        </ItemTemplate>
                                           <HeaderTemplate>
                                            <asp:CheckBox ID="cbAll" runat="server" AutoPostBack="True" 
                                                    oncheckedchanged="cbAll_CheckedChanged" />
                                            </HeaderTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                            <asp:SqlDataSource ID="SqlOdsustvo" runat="server" 
                                ConnectionString="<%$ ConnectionStrings:BVOTEConnectionString %>" SelectCommand="select distinct PollingStation,'O' as Odsustvo from Voter
where TypeOfPollingStationCode='2' and Eligible=1 
and not exists (select PollingStationCode from p3_Bags where PollingStationCode=Voter.PollingStation)
order by 1" ProviderName="<%$ ConnectionStrings:BVOTEConnectionString.ProviderName %>"></asp:SqlDataSource>
                            <br />
                            <asp:Button ID="Button6" runat="server" onclick="Button6_Click" 
                                Text="Generate" />
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
                        </td>
                    </tr>
                </table>
                <asp:SqlDataSource ID="dsPSTypes" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:BVOTEConnectionString %>" 
                    SelectCommand="p3_getPSTypes" SelectCommandType="StoredProcedure">
                </asp:SqlDataSource>
                <br />
                <br />
                <div style="padding: 5px 10px 0px 10px; font-weight: bold; font-size: 120%; background-color: #718ca5;
                    height: 25px; vertical-align: middle; text-align: center;">
                  
                </div>
                <br />
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <div style="height: 10px;">
    </div>
    <div class="line">
    
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:BVOTEConnectionString %>" 
            SelectCommand="BGetAllActiveLevelsForCandidacyRace_Distinct_Cand" 
            SelectCommandType="StoredProcedure"></asp:SqlDataSource>
        <div style="height: 10px;">
        </div>
    
    </div>
    </asp:Content>
