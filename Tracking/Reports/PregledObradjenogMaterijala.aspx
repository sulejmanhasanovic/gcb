<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PregledObradjenogMaterijala.aspx.cs" Inherits="JIIS.Web.Phase3.Tracking.Reports.PregledObradjenogMaterijala" Theme="Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <asp:GridView ID="gvPregledMaterijala" runat="server" 
        AutoGenerateColumns="False" DataSourceID="SqlDataSource1" 
        SkinID="KVoteGridView1">
        <Columns>
            <asp:BoundField DataField="Combination" HeaderText="Kombinacija" 
                SortExpression="Combination" />
            <asp:BoundField DataField="MunicipalityName" HeaderText="Opština" 
                SortExpression="MunicipalityName" />
            <asp:BoundField DataField="Regular" HeaderText="Regular" 
                SortExpression="Regular" Visible="False" />
            <asp:BoundField DataField="ByMail" HeaderText="Pošta" 
                SortExpression="ByMail" />
            <asp:BoundField DataField="Absentee" HeaderText="Odsustvo" 
                SortExpression="Absentee" />
            <asp:BoundField DataField="Personally" HeaderText="Lično" 
                SortExpression="Personally" />
            <asp:BoundField DataField="UkupnoPrebrojano" HeaderText="Ukupno Prebrojano" 
                ReadOnly="True" SortExpression="UkupnoPrebrojano" />
            <asp:BoundField DataField="SpremnoZaBrojanje" HeaderText="Ukupno Spremno Za Brojanje" 
                ReadOnly="True" SortExpression="SpremnoZaBrojanje" />
            <asp:BoundField DataField="PostaPrebrojano" HeaderText="Pošta Prebrojano" 
                ReadOnly="True" SortExpression="PostaPrebrojano" />
            <asp:BoundField DataField="OdsustvoPrebrojano" HeaderText="Odsustvo Prebrojano" 
                ReadOnly="True" SortExpression="OdsustvoPrebrojano" />
            <asp:BoundField DataField="MobilniPrebrojano" HeaderText="Mobilni Prebrojano" 
                ReadOnly="True" SortExpression="MobilniPrebrojano" />
            <asp:BoundField DataField="NepotvrdeniPrebrojano" 
                HeaderText="Nepotvrđeni Prebrojano" ReadOnly="True" 
                SortExpression="NepotvrdeniPrebrojano" />
            <asp:BoundField DataField="PostaSpremnoZaBrojanje" 
                HeaderText="Pošta Spremno Za Brojanje" ReadOnly="True" 
                SortExpression="PostaSpremnoZaBrojanje" />
            <asp:BoundField DataField="OdsustvoSpremnoZaBrojanje" 
                HeaderText="Odsustvo Spremno Za Brojanje" ReadOnly="True" 
                SortExpression="OdsustvoSpremnoZaBrojanje" />
            <asp:BoundField DataField="MobilniSpremnoZaBrojanje" 
                HeaderText="Mobilni Spremno Za Brojanje" ReadOnly="True" 
                SortExpression="MobilniSpremnoZaBrojanje" />
            <asp:BoundField DataField="NepotvrdeniSpremnoZaBrojanje" 
                HeaderText="Nepotvrđeni Spremno Za Brojanje" ReadOnly="True" 
                SortExpression="NepotvrdeniSpremnoZaBrojanje" />
        </Columns>
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:BVOTEConnectionString %>" 
        SelectCommand="p3_Get_RegStatsByCombination" 
        SelectCommandType="StoredProcedure"></asp:SqlDataSource>
    </form>
</body>
</html>
