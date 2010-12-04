<%@ Page Language="C#" 
         AutoEventWireup="true" 
         Trace="false"
         CodeBehind="Default.aspx.cs" 
         Inherits="HelloWorldWebApplication.Default" EnableViewState="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <%=string.Format("Hello, {0}", "world") %>
        <br />
        <asp:Label runat="server" ID="HelloWorldLabel">
           <%-- <%=string.Format("Hello, {0}", "world") %> --%>
        </asp:Label>
        <br />

        <asp:TextBox runat="server" ID="tbNumber1"></asp:TextBox>
        <asp:DropDownList runat="server" ID="ddlOperation" AutoPostBack="true">
            <asp:ListItem Text="Додати" Value="+" />
            <asp:ListItem Text="Відняти" Value="-" />
        </asp:DropDownList>
        <asp:TextBox runat="server" ID="tbNumber2"></asp:TextBox>
        =
        <%--<asp:Button runat="server" ID="btnResult"
                    OnClick="btnResult_Click"></asp:Button>--%>
        <asp:LinkButton runat="server" ID="lbResult" OnClick="lbResult_Click" Text="Click me" />

    </div>
    </form>
</body>
</html>
