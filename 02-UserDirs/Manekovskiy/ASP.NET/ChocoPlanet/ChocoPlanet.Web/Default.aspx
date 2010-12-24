<%@ Page Title="Home Page" Language="C#" AutoEventWireup="true"
         CodeBehind="Default.aspx.cs" Inherits="ChocoPlanet.Web._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="content-type" content="text/html; charset=utf-8" />
    <title></title>

    <meta name="title" content="" />
    <meta name="keywords" content="" />
    <meta name="description" content="" />

    <link href="/Styles/ui-lightness/jquery-ui-1.8.7.custom.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="/Styles/base_style.css" type="text/css" media="screen, projection" />
    <!--[if lte IE 6]><link rel="stylesheet" href="/Styles/base_style_ie.css" type="text/css" media="screen, projection" /><![endif]-->

    <script src="/Scripts/jquery-1.4.4.min.js" type="text/javascript"></script>
    <script src="/Scripts/jquery-ui-1.8.7.custom.min.js" type="text/javascript"></script>
    <script src="/Scripts/Site.Master.js" type="text/javascript"></script>

    <script language="javascript" type="text/javascript">
        function LoadControlAsync(controlUrl) {
            debugger;
            $.ajax({
                type: "POST",
                url: "Default.aspx/LoadControlIntoPlaceHolder",
                data: "{ }",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: true,
                cache: false,
                success: function (msg) { return false; },
                error: function (msg) { debugger; alert(msg); }
            });
            return false;
        }
    </script>
</head>
<body>
    <div id="wrapper">
        <%--<div id="header">
        </div>
        <!-- #header-->--%>
        <div id="content">
            <form runat="server" id="contentForm">
                <%--<asp:ScriptManager runat="server" EnablePageMethods="true"></asp:ScriptManager>--%>
                <asp:SiteMapDataSource runat="server" ID="smdsSite" StartFromCurrentNode="false" />
                <div id="tabs">
                    <asp:Repeater runat="server" ID="rpMenu" DataSourceID="smdsSite">
                        <ItemTemplate>
                            <ul>
                                <asp:Repeater ID="Repeater1" runat="server" DataSource='<%# Eval("ChildNodes") %>'>
                                    <ItemTemplate>
                                        <li>
                                            <asp:HyperLink runat="server" 
                                                           NavigateUrl="#tab" 
                                                           Text='<%# Eval("Title") %>'
                                                           onclick='<%# "LoadControlAsync(&#39;" + Eval("Url") + "&#39;)" %>'   />
                                        </li>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </ul>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
                <div id="tab">
                    <asp:PlaceHolder runat="server" ID="phContentControl"></asp:PlaceHolder>
                </div>
            </form>
        </div>
        <!-- #content-->
    </div>
    <!-- #wrapper -->
    <div id="footer">
       All Rights Reserved
    </div>
    <!-- #footer -->
</body>
</html>