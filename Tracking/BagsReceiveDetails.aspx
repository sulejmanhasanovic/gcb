<%@ Page Language="C#" MasterPageFile="~/masterpage.Master" AutoEventWireup="true"
    CodeBehind="BagsReceiveDetails.aspx.cs" Inherits="JIIS.Web.Phase3.Tracking.BagsReceiveDetails"
    Title="Untitled Page" Theme="Default" %>

<%@ Import Namespace="Resources" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContent" runat="server">
    <div id="PageTitle">
        <%=LanguageText.tr_bagDetails%>
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
                                        CausesValidation="False" OnClick="Button5_Click" />
                                </td>
                                <td style="text-align: right">
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
                <br />
                <div style="text-align: left;">
                    <asp:DetailsView ID="DetailsView1" runat="server" SkinID="Details" AutoGenerateRows="False"
                        DataSourceID="dsBagsReceived">
                        <Fields>
                            <asp:BoundField DataField="BagNo" HeaderText="<%$Resources:LanguageText, tr_NumberBag%>" SortExpression="BagNo" />
                            <asp:BoundField DataField="PollingStationCode" HeaderText="<%$Resources:LanguageText, tr_psCode%>" SortExpression="PollingStationCode" />
                            <asp:BoundField DataField="TypeOfPollingStationCode" HeaderText="<%$Resources:LanguageText, tr_psType%>"
                                SortExpression="TypeOfPollingStationCode" />
                            <asp:BoundField DataField="PoBox" HeaderText="<%$Resources:LanguageText, tr_postBox%>" SortExpression="PoBox" />
                            <asp:BoundField DataField="ShipmentNumber" HeaderText="<%$Resources:LanguageText, tr_numberShipment%>" SortExpression="ShipmentNumber" />
                            <asp:BoundField DataField="RegularEnvelopes" HeaderText="<%$Resources:LanguageText, tr_regEnv%>" SortExpression="RegularEnvelopes" />
                            <asp:BoundField DataField="ExpressPost" HeaderText="<%$Resources:LanguageText, tr_FastPost%>" SortExpression="ExpressPost" />
                            <asp:BoundField DataField="Undelivered" HeaderText="<%$Resources:LanguageText, tr_Undelivered%>" SortExpression="Undelivered" />
                            <asp:BoundField DataField="Others" HeaderText="<%$Resources:LanguageText, tr_others%>" SortExpression="Others" />
                            <asp:BoundField DataField="TotalReceivedEnvelopes" HeaderText="<%$Resources:LanguageText, tr_receivedEnvelopes%>"
                                SortExpression="TotalReceivedEnvelopes" />
                            <asp:BoundField DataField="DateReceived" HeaderText="<%$Resources:LanguageText, tr_date%>" SortExpression="DateReceived" />
                            <asp:BoundField DataField="Comment" HeaderText="<%$Resources:LanguageText, de_comment%>" SortExpression="Comment" />
                            <asp:BoundField DataField="Type" HeaderText="<%$Resources:LanguageText, GVHeaderType%>" SortExpression="Type" />
                            <asp:BoundField DataField="Clerk" HeaderText="<%$Resources:LanguageText, de_clerk%>" SortExpression="Clerk" />
                        </Fields>
                    </asp:DetailsView>
                </div>
                <asp:SqlDataSource ID="dsBagsReceived" runat="server" ConnectionString="<%$ ConnectionStrings:BVOTEConnectionString %>"
                    SelectCommand="p3_GetBagsReceivedInfo" SelectCommandType="StoredProcedure">
                    <SelectParameters>
                        <asp:QueryStringParameter Name="id" QueryStringField="id" Type="Int32" />
                    </SelectParameters>
                </asp:SqlDataSource>
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:SqlDataSource ID="dsPOBox" runat="server" ConnectionString="<%$ ConnectionStrings:BVOTEConnectionString %>"
            SelectCommand="p3_GetData_p3_PO_Package" SelectCommandType="StoredProcedure">
        </asp:SqlDataSource>
    </div>
    <div style="height: 10px;">
    </div>
    <div class="line">
    </div>
</asp:Content>
