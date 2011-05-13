<%@ Page language="c#" Codebehind="Default.aspx.cs" AutoEventWireup="false"  %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
    <HEAD>
        <title>Default</title>
        <meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
        <meta name="CODE_LANGUAGE" Content="C#">
        <meta name="vs_defaultClientScript" content="JavaScript">
        <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
    </HEAD>
    <body>
        <form id="Default" method="post" runat="server">
            <TABLE id="Table1" style="WIDTH: 499px; HEIGHT: 160px" cellSpacing="0" cols="2" cellPadding="0" width="499" align="left" border="0">
                <TR>
                    <TD style="WIDTH: 226px; HEIGHT: 25px" vAlign="top" align="left">
                        <asp:Label id="Label1" runat="server" Width="146px">User name:</asp:Label></TD>
                    <TD style="WIDTH: 34px; HEIGHT: 25px">
                        <asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" ErrorMessage="Please enter user name" ControlToValidate="txtName">*</asp:RequiredFieldValidator></TD>
                    <TD style="WIDTH: 18px; HEIGHT: 25px">
                        <asp:TextBox id="txtName" runat="server" Width="263px"></asp:TextBox></TD>
                    <TD style="WIDTH: 271px; HEIGHT: 25px"></TD>
                    <TD style="HEIGHT: 25px"></TD>
                    <TD style="HEIGHT: 25px" width="10"></TD>
                </TR>
                <TR>
                    <TD style="WIDTH: 226px; HEIGHT: 23px" vAlign="top">
                        <asp:Label id="Label2" runat="server">User e-mail:</asp:Label></TD>
                    <TD style="WIDTH: 34px; HEIGHT: 23px">
                        <asp:RequiredFieldValidator id="RequiredFieldValidator3" runat="server" ErrorMessage="Please enter e-mail address" ControlToValidate="txtEmail">*</asp:RequiredFieldValidator>
                        <br>
                        <asp:RegularExpressionValidator id="RegularExpressionValidator1" runat="server" ErrorMessage="Please enter correct email" ControlToValidate="txtEmail" ValidationExpression="w+([-+.]w+)*@w+([-.]w+)*.w+([-.]w+)*">*</asp:RegularExpressionValidator>
                    </TD>
                    <TD style="WIDTH: 18px; HEIGHT: 23px">
                        <asp:TextBox id="txtEmail" runat="server" Width="266px"></asp:TextBox></TD>
                    <TD style="WIDTH: 271px; HEIGHT: 23px"></TD>
                    <TD style="HEIGHT: 23px"></TD>
                    <TD style="HEIGHT: 23px"></TD>
                </TR>
                <TR>
                    <TD style="WIDTH: 226px; HEIGHT: 23px" vAlign="top">
                        <asp:Label id="Label3" runat="server">User password:</asp:Label></TD>
                    <TD style="WIDTH: 34px; HEIGHT: 23px">
                        <asp:RequiredFieldValidator id="RequiredFieldValidator2" runat="server" ErrorMessage="Please enter password" ControlToValidate="txtPassword">*</asp:RequiredFieldValidator></TD>
                    <TD style="WIDTH: 18px; HEIGHT: 23px">
                        <asp:TextBox id="txtPassword" runat="server" Width="267px"></asp:TextBox></TD>
                    <TD style="WIDTH: 271px; HEIGHT: 23px"></TD>
                    <TD style="HEIGHT: 23px"></TD>
                    <TD style="HEIGHT: 23px"></TD>
                </TR>
                <TR>
                    <TD style="WIDTH: 226px; HEIGHT: 26px" vAlign="top">
                        <asp:Label id="Label4" runat="server" Width="161px">Confirm password:</asp:Label></TD>
                    <TD style="WIDTH: 34px; HEIGHT: 26px" vAlign="top">
                        <asp:CompareValidator id="CompareValidator1" runat="server" ErrorMessage="Please repeat password" ControlToValidate="txtConfirmPassword" ControlToCompare="txtPassword">*</asp:CompareValidator>
                        <br>
                        <asp:RequiredFieldValidator id="RequiredFieldValidator4" runat="server" ErrorMessage="Please re-enter password" ControlToValidate="txtConfirmPassword">*</asp:RequiredFieldValidator></TD>
                    <TD style="WIDTH: 18px; HEIGHT: 26px" vAlign="top">
                        <asp:TextBox id="txtConfirmPassword" runat="server" Width="267px"></asp:TextBox></TD>
                    <TD style="WIDTH: 271px; HEIGHT: 26px" vAlign="top"></TD>
                    <TD style="HEIGHT: 26px"></TD>
                    <TD style="HEIGHT: 26px"></TD>
                </TR>
                <TR>
                    <TD style="WIDTH: 244px; HEIGHT: 29px" vAlign="top" align="middle" colSpan="3">
                        <asp:Button id="Button1" runat="server" Width="183px" Text="Submit"></asp:Button></TD>
                    <TD style="WIDTH: 271px; HEIGHT: 29px" vAlign="top"></TD>
                    <TD style="WIDTH: 271px; HEIGHT: 29px" vAlign="top"></TD>
                    <TD style="WIDTH: 271px; HEIGHT: 29px" vAlign="top"></TD>
                    <TD style="WIDTH: 271px; HEIGHT: 29px" vAlign="top"></TD>
                    <TD style="HEIGHT: 29px"></TD>
                </TR>
                <TR>
                    <TD style="WIDTH: 244px; HEIGHT: 86px" vAlign="top" align="middle" colSpan="3">
                        <asp:ValidationSummary id="ValidationSummary1" runat="server" Width="332px" HeaderText="Form cannot be submitted due to the following errors:"></asp:ValidationSummary></TD>
                    <TD style="WIDTH: 271px; HEIGHT: 86px" vAlign="top"></TD>
                    <TD style="WIDTH: 271px; HEIGHT: 86px" vAlign="top"></TD>
                    <TD style="WIDTH: 271px; HEIGHT: 86px" vAlign="top"></TD>
                    <TD style="WIDTH: 271px; HEIGHT: 86px" vAlign="top"></TD>
                    <TD style="HEIGHT: 86px"></TD>
                </TR>
            </TABLE>
        </form>
    </body>
</HTML>           
    


<%--Читать дальше: http://www.mgraphics.ru/show_articles.php?act=read&aid=379#ixzz1Llq2i6Eu--%>



          








