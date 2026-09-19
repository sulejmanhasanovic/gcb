<%@ Page Language="C#" MasterPageFile="~/masterpage.Master" AutoEventWireup="true"
    CodeBehind="BagsReceiveReport.aspx.cs" Inherits="JIIS.Web.Phase3.Tracking.BagsReceiveReport"
    Title="Untitled Page" Theme="Default" %>

<%@ Import Namespace="Resources" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContent" runat="server">
    <div id="PageTitle">
        <%=LanguageText.p3_bagsReceiving%>
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
                <table width="100%">
                    <tr align="center">
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:GridView ID="GridView1" runat="server" Width="100%" SkinID="KVoteGridView" 
            AutoGenerateColumns="False" DataKeyNames="id" DataSourceID="dsPOBox" PageSize="100">
            <Columns>
                <asp:BoundField DataField="PoBox" HeaderText="PoBox" SortExpression="PoBox" />
                <asp:BoundField DataField="ShipmentNumber" HeaderText="ShipmentNumber" 
                    SortExpression="ShipmentNumber" />
                <asp:BoundField DataField="BagNo" HeaderText="BagNo" SortExpression="BagNo" />
                <asp:BoundField DataField="RegularEnvelopes" HeaderText="Regular" 
                    SortExpression="RegularEnvelopes" />
                <asp:BoundField DataField="ExpressPost" HeaderText="Express" 
                    SortExpression="ExpressPost" />
                <asp:BoundField DataField="Undelivered" HeaderText="Undelivered" 
                    SortExpression="Undelivered" />
                <asp:BoundField DataField="Others" HeaderText="Others" 
                    SortExpression="Others" />
                <asp:BoundField DataField="TotalReceivedEnvelopes" 
                    HeaderText="Total" SortExpression="TotalReceivedEnvelopes" />
                <asp:BoundField DataField="DateReceived" HeaderText="Received" 
                    SortExpression="DateReceived" />
                <asp:BoundField DataField="Comment" HeaderText="Comment" 
                    SortExpression="Comment" />
                <asp:BoundField DataField="Type" HeaderText="Type" SortExpression="Type" />
                <asp:BoundField DataField="Clerk" HeaderText="Clerk" SortExpression="Clerk" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="dsPOBox" runat="server" 
            ConnectionString="<%$ ConnectionStrings:BVOTEConnectionString %>" 
            SelectCommand="p3_GetData_p3_PO_Package" SelectCommandType="StoredProcedure">
        </asp:SqlDataSource>
    </div>
    <div style="height: 10px;">
    </div>
    <div class="line">
    </div>
</asp:Content>
