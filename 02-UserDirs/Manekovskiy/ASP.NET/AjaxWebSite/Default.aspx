<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="AjaxWebSite.Default" 
    Trace="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="jquery-1.4.1-vsdoc.js" type="text/javascript"></script>
    <script type="text/javascript">
        function sendAjaxRequest() {
            $.ajax({
                type: "GET",
                url: "/Default.aspx",
                data: "method=GetDate",
                success: function (responseText) {
                    $("#lblDate")[0].innerHTML = responseText;
                },
                error: function () {
                    alert("Request failed");
                }
            });
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager runat="server" />
        <div>
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                    <asp:Label runat="server" ID="lblDate" />
                    <br />
                    <asp:Button ID="btnGetDate" Text="Который час (updatePanel)?" runat="server" 
                                OnClick="GetDateClick"/>

                    <%--<br />
                    <asp:TextBox runat="server" ID="tbNameFilter" />--%>
                </ContentTemplate>
                <Triggers>
                    <%--<asp:AsyncPostBackTrigger ControlID="tbNameFilter" EventName="OnTextChanged" /> триггер частичного запроса --%>
                    <%--<asp:PostBackTrigger ControlID="" /> триггер полноценного запроса --%>
                </Triggers>
            </asp:UpdatePanel>
        </div>
        <div>
            <input type="button" onclick="javascript:sendAjaxRequest()" value="Который час (jquery)"></input>
        </div>
    </form>
</body>
</html>
