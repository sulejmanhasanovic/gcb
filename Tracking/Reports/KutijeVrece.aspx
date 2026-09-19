<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="KutijeVrece.aspx.cs" Inherits="JIIS.Web.Phase3.Tracking.Reports.KutijeVrece" Theme="Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <asp:GridView ID="gvKutijeVrece" runat="server" DataSourceID="SqlDataSource1" 
        SkinID="KVoteGridView1">
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:BVOTEConnectionString %>" 
        SelectCommand="p3_GetKutijeVrece" 
        SelectCommandType="StoredProcedure"></asp:SqlDataSource>
    </form>
</body>
</html>
