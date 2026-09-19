<%@ Page Language="C#" MasterPageFile="~/masterpage.Master" AutoEventWireup="true"
    CodeBehind="ScanningOdsustvo.aspx.cs" Inherits="JIIS.Web.Phase3.Tracking.ScanningOdsustvo" Theme="Default" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Import Namespace="Resources" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphContent" runat="server">

    <script language="javascript" type="text/javascript">
    
        function clickButton(e)
        {
                if (navigator.appName.indexOf("Microsoft Internet Explorer")>(-1)){ 
                    if (event.keyCode == 13){ 
                        countDisplay();     
                        return false; 
                    } 
                }             
        }


        function countDisplay() {
            var txtBC = document.getElementById('<%=txtBarCode.ClientID%>');
            var numTxt = txtBC.value;
                        
  
            if(numTxt.length == 13)
            {
                        
                var btn = document.getElementById('<%=btnScan.ClientID%>');
                btn.click();
        
                var tb2 = document.getElementById('<%=txtBarCode.ClientID%>');
                tb2.focus();  
            }  
            
            
            if(numTxt.length == 2)
            {
                var pnlC = document.getElementById('<%=pnlCofirmed.ClientID%>');
                var pnlD = document.getElementById('<%=pnlDenied.ClientID%>');
                var pnlAE = document.getElementById('<%=pnlAlreadyEntered.ClientID%>');
                if(pnlC.style.display == '')
                {
                    pnlC.style.display = 'none';
                }
                 if(pnlD.style.display == '')
                {
                    pnlD.style.display = 'none';
                }
                if(pnlAE.style.display == '')
                {
                    pnlAE.style.display = 'none';
                }
            }
        }
        function panelAccepted() {

            var lblSave = document.getElementById('<%=pnlCofirmed.ClientID%>');
            lblSave.style.display = 'none';
            
            return true;
        }
        function hideAcceptedPanel()
        {
            setTimeout('panelAccepted()',5000);
            return true;
        }
        
        
        function panelNotAccepted() {

            var lblSave = document.getElementById('<%=pnlDenied.ClientID%>');
            lblSave.style.display = 'none';
            
            return true;
        }
        function hideNotAcceptedPanel()
        {
            setTimeout('panelNotAccepted()',5000);
            return true;
        }
        
        
        function panelAlreadyEntered() {

            var lblSave = document.getElementById('<%=pnlAlreadyEntered.ClientID%>');
            lblSave.style.display = 'none';
            
            return true;
        }
        function hideAlreadyEnteredPanel()
        {
            setTimeout('panelAlreadyEntered()',5000);
            return true;
        }
        function openDocument(docName) {
            if (docName != "") {
                window.open('/Phase3/CC/PreviewPdf.aspx?docName=' + docName + "&ps=" + '<% = lblBag.Text %>', 'mywindow', 'width=1000,height=750');
            }
            else
                alert("Dokument nije priložen uz odabranu stavku!")
        }
    </script>

    <div id="PageTitle">
        <%=LanguageText.p3_Scan%><hr style="border-width: 0px; background-color: #718ca5;"
            noshade="noshade" />
    </div>
    <div style="height: 10px;">
    </div>
    <div id="MainBody">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
            <Triggers> 
                <asp:PostBackTrigger ControlID="btnScan" />                
             </Triggers>
            <ContentTemplate>
                <div style="text-align: center;">
                    <asp:Label ID="lblBag" runat="server" CssClass="text18_normal"></asp:Label>
                </div>
                <br />
                <asp:Panel ID="pnlCofirmed" runat="server">
                    <table width="100%">
                        <tr>
                            <td align="center">
                                <table width="80%">
                                    <tr>
                                        <td style="border: thin solid #008000;">
                                            <table width="95%">
                                                <tr>
                                                    <td rowspan="2" style="width: 130px">
                                                        <asp:Image ID="imgOK" runat="server" ImageUrl="~/Phase3/images/Tick.png" Width="60px"
                                                            Height="60px" />
                                                    </td>
                                                    <td colspan="3">
                                                        <asp:Label ID="lblVoteForMunicipality" runat="server" CssClass="text16_normal" Font-Size="XX-Large"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 50%" align="center">
                                                        <asp:Label ID="lblName" runat="server" CssClass="text12_normal"></asp:Label>
                                                    </td>
                                                    <td style="width: 15%;" align="right">
                                                        <asp:Label ID="lblJMB" runat="server" CssClass="text12_normal"></asp:Label>
                                                    </td>
                                                    <td align="left" style="width: 35%">
                                                        <asp:Label ID="lblTime" runat="server" CssClass="text12_normal"></asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                <asp:Panel ID="pnlDenied" runat="server">
                    <table width="100%">
                        <tr>
                            <td align="center">
                                <table width="80%">
                                    <tr>
                                        <td style="border: thin solid #FF0000;">
                                            <table width="95%">
                                                <tr>
                                                    <td rowspan="2" style="width: 130px">
                                                        <asp:Image ID="imgError" runat="server" ImageUrl="~/Phase3/images/Error.png" Width="60px"
                                                            Height="60px" />
                                                    </td>
                                                    <td colspan="3">
                                                        <asp:Label ID="lblMsg" runat="server" CssClass="text18_normal" Text="<%$ Resources:LanguageText, p3_VoterNotRegisteredAbsent %>"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 50%;" align="right">
                                                        <asp:Label ID="lblJMB1" runat="server" CssClass="text12_normal"></asp:Label>
                                                    </td>
                                                    <td style="width: 15%;" align="center">
                                                        <asp:Label ID="lblVoteForMunicipality1" runat="server" CssClass="text12_normal"></asp:Label>
                                                    </td>
                                                    <td style="width: 35%" align="left">
                                                        <asp:Label ID="lblTime1" runat="server" CssClass="text12_normal"></asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                <asp:Panel ID="pnlAlreadyEntered" runat="server">
                    <table width="100%">
                        <tr>
                            <td align="center">
                                <table width="80%">
                                    <tr>
                                        <td style="border: thin solid #FF9933;">
                                            <table width="95%">
                                                <tr>
                                                    <td rowspan="2" style="width: 130px">
                                                        <asp:Image ID="Image1" runat="server" ImageUrl="~/Phase3/images/warning.png" Width="60px"
                                                            Height="60px" />
                                                    </td>
                                                    <td colspan="3">
                                                        <asp:Label ID="lblMSG2" runat="server" CssClass="text18_normal" Text="<%$ Resources:LanguageText, p3_AlreadyScanned %>"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 50%;" align="right">
                                                        <asp:Label ID="lblJMB2" runat="server" CssClass="text12_normal"></asp:Label>
                                                    </td>
                                                    <td style="width: 15%;" align="center">
                                                        <asp:Label ID="lblVoteForMunicipality2" runat="server" CssClass="text12_normal"></asp:Label>
                                                    </td>
                                                    <td style="width: 35%" align="left">
                                                        <asp:Label ID="lblTime2" runat="server" CssClass="text12_normal"></asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                <br />
                <table align="left" style="width: 70%">
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label1" runat="server" Text="Prihvaceni:"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:Label ID="lblAccepted" runat="server"></asp:Label>
                        </td>
                        <td align="right">
                            <asp:Label ID="Label3" runat="server" Text="Odbijeni:"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:Label ID="lblDenied" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
                <br />
                <br />
                <table width="100%" cellpadding="0" cellspacing="0">
                    <tr>
                        <td style="height: 10px">
                        </td>
                    </tr>
                    <tr style="height: 30px; vertical-align: middle">
                        <td align="right" style="width: 25%">
                            <asp:Label ID="lblTxtScanJMB" runat="server" Text="<%$ Resources:LanguageText, p3_BarCode %>"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtBarCode" runat="server" CssClass="text_box" MaxLength="13"></asp:TextBox>
                            <cc1:FilteredTextBoxExtender ID="txtBarCode_FilteredTextBoxExtender" runat="server"
                                Enabled="True" FilterType="Numbers" TargetControlID="txtBarCode">
                            </cc1:FilteredTextBoxExtender>&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
                            <asp:CheckBox runat="server" ID="chbSuspicious" Visible="false" Checked="false" />
                          <%--  <asp:Label runat="server">Sumnjivi potpis?</asp:Label>&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
                            <asp:FileUpload runat="server" ID="upload"/>
                            &nbsp;--%><asp:Button ID="btnScan" runat="server" OnClick="btnScan_Click" Text="Scan" 
                                Width="70px" />
                        </td>
                    </tr>
                    <%--<tr style="height: 30px; vertical-align: middle">
                        <td align="right" style="width: 45%">
                            <asp:Label ID="Label1" runat="server" Text="<%$ Resources:LanguageText, DVSysAdminPositionName %>"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtName" runat="server" CssClass="text_box"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*"
                                ControlToValidate="txtName"></asp:RequiredFieldValidator>
                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server"
                                Enabled="True" FilterType="Custom" FilterMode="ValidChars" TargetControlID="txtName">
                            </cc1:FilteredTextBoxExtender>
                        </td>
                    </tr>--%>
                    <%--<tr style="height: 30px; vertical-align: middle">
                        <td align="right" style="width: 45%">
                            <asp:Label ID="Label2" runat="server" Text="<%$ Resources:LanguageText, DVSysAdminUserLastName %>"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtSurname" runat="server" CssClass="text_box"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*"
                                ControlToValidate="txtSurname"></asp:RequiredFieldValidator>
                        </td>
                    </tr>--%>
                    <%--<tr style="height: 30px; vertical-align: middle">
                        <td align="right" style="width: 45%">
                            <asp:Label ID="Label3" runat="server" Text="<%$ Resources:LanguageText, de_dateBirth %>"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtBirthDate" runat="server" CssClass="text_box"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*"
                                ControlToValidate="txtBirthDate"></asp:RequiredFieldValidator>
                        </td>
                    </tr>--%>
                    <tr style="height: 30px; vertical-align: middle">
                        <td align="center" colspan="2">
                            <asp:Label ID="lblMessage" runat="server" Visible="false"></asp:Label>
                        </td>
                    </tr>
                    <%--<tr style="vertical-align: middle">
                        <td align="center" colspan="2" style="height: 15px">
                            <asp:Button ID="btnScan" runat="server" OnClick="btnScan_Click" Text="Scan" CssClass="button120" />
                        </td>
                    </tr>--%>
                    <tr style="vertical-align: middle">
                        <td align="center" colspan="2" style="height: 15px">
                        </td>
                    </tr>
                    <tr style="height: 30px; vertical-align: middle">
                        <td align="center" colspan="2">
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Button ID="btnFinishScanning" runat="server" CssClass="button120" OnClick="btnFinishScanning_Click"
                                Text="<%$ Resources:LanguageText, bFinish %>" />
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 10px">
                            <asp:CheckBox ID="CheckBoxPaging" runat="server" ForeColor="Black" AutoPostBack="true"
                                oncheckedchanged="CheckBoxPaging_CheckedChanged" Text="Paging" />
                            &nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:DropDownList ID="ddlPageSize" runat="server" AutoPostBack="true" 
                                CausesValidation="false" CssClass="drop_down_list" 
                                OnSelectedIndexChanged="ddlPageSize_SelectedIndexChanged" Visible="False" 
                                Width="40px">
                                <asp:ListItem Selected="True" Text="5" Value="5"></asp:ListItem>
                                <asp:ListItem Text="10" Value="10"></asp:ListItem>
                                <asp:ListItem Text="20" Value="20"></asp:ListItem>
                                <asp:ListItem Text="30" Value="30"></asp:ListItem>
                                <asp:ListItem Text="40" Value="40"></asp:ListItem>
                                <asp:ListItem Text="50" Value="50"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 10px">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td align="right" colspan="2">
                            <asp:GridView ID="gView" runat="server" Width="100%" SkinID="KVoteGridView" AutoGenerateColumns="False"
                                DataKeyNames="ID" AllowSorting="False" AllowPaging="False" OnRowDataBound="gvOrgUnits_RowDataBound"
                                PageSize="1000">
                                <Columns>
                                    <asp:TemplateField HeaderText="#">
                                        <ItemTemplate>
                                            <asp:Label ID="ID" runat="server" Text='<%# Eval("ID") %>' />
                                            <%--<asp:HiddenField ID="tblID" runat="server" Value='<%# Eval("tblID") %>' />--%>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Width="10%" />
                                        <HeaderStyle HorizontalAlign="Center" Width="10%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="<%$Resources:LanguageText, DVSysAdminUserFirstName%>">
                                        <ItemTemplate>
                                            <asp:Label ID="Name" runat="server" Text='<%# Eval("Name") %>' />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="15%" />
                                        <HeaderStyle HorizontalAlign="Left" Width="15%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="<%$Resources:LanguageText, DVSysAdminUserLastName%>">
                                        <ItemTemplate>
                                            <asp:Label ID="Surname" runat="server" Text='<%# Eval("Surname") %>' />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="20%" />
                                        <HeaderStyle HorizontalAlign="Left" Width="20%" />
                                    </asp:TemplateField>
                                    
                                     <asp:TemplateField HeaderText="<%$Resources:LanguageText, p3_CCheaderScanVoter%>">
                                        <ItemTemplate>
                                            <asp:Label ID="TypeOfPollingCode" runat="server" Text='<%# Eval("TypeOfPollingStationCode") %>' />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="left" Width="20%" />
                                        <HeaderStyle HorizontalAlign="Center" Width="20%" />
                                    </asp:TemplateField>
                                    
                                    <asp:TemplateField HeaderText="<%$Resources:LanguageText, de_JMB%>">
                                        <ItemTemplate>
                                            <asp:Label ID="JMB" runat="server" Text='<%# Eval("RegID") %>' />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Width="20%" />
                                        <HeaderStyle HorizontalAlign="Center" Width="20%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="<%$Resources:LanguageText, p3_voteFor%>">
                                        <ItemTemplate>
                                            <asp:Label ID="VoteFor" runat="server" Text='<%# Eval("VoteForLevel") %>' />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Width="5%" />
                                        <HeaderStyle HorizontalAlign="Center" Width="5%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="<%$Resources:LanguageText, p3_PollingStation%>">
                                        <ItemTemplate>
                                            <asp:Label ID="PS" runat="server" Text='<%# Eval("PSBag") %>' />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Width="10%" />
                                        <HeaderStyle HorizontalAlign="Center" Width="10%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="<%$Resources:LanguageText, fvlTime%>">
                                        <ItemTemplate>
                                            <asp:Label ID="Time" runat="server" Text='<%# Eval("TimeVerified") %>' />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Width="5%" />
                                        <HeaderStyle HorizontalAlign="Center" Width="5%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Can vote">
                                        <ItemTemplate>
                                            <asp:Label ID="lblAccepted" runat="server" Text='<%# Eval("Accepted") %>' />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Width="5%" />
                                        <HeaderStyle HorizontalAlign="Center" Width="5%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Reason">
                                        <ItemTemplate>
                                            <asp:Label ID="lblReason" runat="server" Text='<%# Eval("Reason") %>' />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Width="15%" />
                                        <HeaderStyle HorizontalAlign="Center" Width="15%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="imgbtnDelete" runat="server" AlternateText="<%$ Resources:LanguageText, GVSysAdminOrgUnitDeleteAlt %>"
                                                ImageAlign="Middle" ImageUrl="~/App_Themes/Default/default_images/delete.png"
                                                OnClick="imgbtnDeleteOrgUnit_Click" ToolTip="<%$ Resources:LanguageText, GVSysAdminOrgUnitToolTip %>" />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Width="5%" />
                                        <HeaderStyle HorizontalAlign="Center" Width="5%" />
                                    </asp:TemplateField>
<%--                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="btnOpenDocument" runat="server" AlternateText="<%$ Resources:LanguageText, GVSysAdminOrgUnitDeleteAlt %>"
                                                ImageAlign="Middle" ImageUrl="~/App_Themes/Default/default_images/comments.png" OnClientClick='<%# Eval("DocumentName", "return openDocument(\"{0}\");") %>'
                                                 ToolTip="<%$ Resources:LanguageText, GVSysAdminOrgUnitToolTip %>" />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Width="5%" />
                                        <HeaderStyle HorizontalAlign="Center" Width="5%" />
                                    </asp:TemplateField>--%>
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
                <br />
                <table style="width: 100%;">
                    <tr>
                        <td style="text-align: right;">
                            &nbsp;
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:UpdateProgress ID="uprogressFolderClicked" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
            <ProgressTemplate>
                <table class="loaderFolders" border="0">
                    <tr>
                        <td align="center" valign="middle">
                            <img src="../../App_Themes/Default/default_images/loader.gif" align="middle" alt="Loading..."
                                title="Loading..." />
                        </td>
                    </tr>
                </table>
            </ProgressTemplate>
        </asp:UpdateProgress>
        <div style="height: 10px;">
        </div>
        <div class="line">
        </div>
    </div>
</asp:Content>
