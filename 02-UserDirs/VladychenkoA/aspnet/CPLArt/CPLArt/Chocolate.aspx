<%@ Page Title="" Language="C#" MasterPageFile="~/design/MasterPage.master" AutoEventWireup="true"
    CodeBehind="Chocolate.aspx.cs" Inherits="CPLArt.Chocolate" %>

<%@ Register TagPrefix="artisteer" Namespace="Artisteer" %>
<%@ Register TagPrefix="art" TagName="DefaultMenu" Src="DefaultMenu.ascx" %>
<%@ Register TagPrefix="art" TagName="DefaultHeader" Src="DefaultHeader.ascx" %>
<%@ Register TagPrefix="art" TagName="DefaultSidebar1" Src="DefaultSidebar1.ascx" %>
<asp:Content ID="PageTitle" ContentPlaceHolderID="TitleContentPlaceHolder" runat="Server">
    ChocoPlanet - Шоколад
</asp:Content>
<asp:Content ID="HeaderContent" ContentPlaceHolderID="HeaderContentPlaceHolder" runat="Server">
    <art:DefaultHeader ID="DefaultHeader" runat="server" />
</asp:Content>
<asp:Content ID="MenuContent" ContentPlaceHolderID="MenuContentPlaceHolder" runat="Server">
    <art:DefaultMenu ID="DefaultMenuContent" runat="server" />
</asp:Content>
<asp:Content ID="SideBar1" ContentPlaceHolderID="Sidebar1ContentPlaceHolder" runat="Server">
    <art:DefaultSidebar1 ID="DefaultSidebar1Content" runat="server" />
</asp:Content>
<asp:Content ID="SheetContent" ContentPlaceHolderID="SheetContentPlaceHolder" runat="Server">
    <artisteer:Article ID="Article1" Caption="Шоколад" runat="server">
        <ContentTemplate>

            <script type="text/javascript">
                function popup(img, sx, sy, num, name, cacao, ves, razmer) {
                    var winl = (screen.width - sx) / 2;
                    var wint = (screen.height - sy) / 2;
                    image = "<a href='javascript:self.close()'><img src=" + img + " border=0 alt='Click to Close'></a>";
                    popupwin = window.open("", "photo" + num, "toolbar=no,location=no,directories=no,status=no,menubar=no,top=" + wint + ",left=" + winl + ",width=" + sx + ",height=" + sy + "");
                    /* 
                    popupwin.document.write("<HTML><HEAD><TITLE>Autogallery Pop-Up Title</TITLE><BASE HREF=\http://www.interchoc.ru/\></HEAD><BODY BGCOLOR=#FFFFFF><CENTER>" + image + "</CENTER></BODY></HTML>");
                    */

                    popupwin.document.write("<head><title>Корпоративные наборы</title><meta http-equiv=\"Content-Type\" content=\"text/html; charset=windows-1251\" /><link href=\"images/big.css\" rel=\"stylesheet\" type=\"text/css\" /></head><body><div class=\"close\"><a href=\"JavaScript:window.close();\">Закрыть</a></div><table cellspacing=\"1\" cellpadding=\"1\" border=\"0\" align=\"center\"><tr>    <td colspan=\"2\" height=\"15\">&nbsp;</td></tr>   <tr>  <tr>    <td colspan=\"2\" align=\"center\"><a href=\"JavaScript:window.close();\">" + image + "</a></td></tr>   <tr>    <td colspan=\"2\" align=\"left\" class=\"title2\" >" + name + "</td>  </tr>      <tr>    <td align=\"left\" width=\"30%\"><b>Содержание какао: </b></td><td align=\"left\">" + cacao + "</td>  </tr>          <tr>    <td align=\"left\"><b>Вес: </b></td><td align=\"left\">" + ves + "</td>  </tr>        <tr>    <td align=\"left\"><b>Размер изделия: </b></td><td align=\"left\">" + razmer + "</td></tr></table></body></html>");

                    popupwin.document.close();
                }
            </script>

            
            <div class="art-content-layout overview-table">
                <div class="art-content-layout-row">
                    <div class="art-layout-cell">
                        <img class="art-article" src="images/20gr.jpg" width="250" height="250" alt="«кредитная карта»"
                            style="float: left; border: 0; margin: 1em 1em 0 0;" />
                    </div>
                    <div class="art-layout-cell">
                        <br />
                        <br />
                        <br />
                        <p align="left">
                            <b>Шоколад с логотипом</b><br />
                            20 г. прямоугольный,<br />
                            формат «кредитная карта»<br />
                        </p>
                        <br />
                        <p align="left">
                            - прямоугольный шоколад с логотипом, размером 55 х 85 мм
                            <br>
                            - полноцветная печать<br>
                            - возможны дополнительные услуги (пантон, тиснение)<br>
                            - цвет фольги – серебро<br>
                            - шоколад расфасован в коробки по 750 шт.</p>
                    </div>
                </div>
            </div>
            <div class="art-content-layout-row">
                <div class="art-content-layout-row">
                    <div class="art-layout-cell">
                        <img class="art-article" src="images/100gr.jpg" width="250" height="250" alt="happy family"
                            style="float: left; border: 0; margin: 1em 1em 0 0;" />
                    </div>
                    <div class="art-layout-cell">
                        <br />
                        <br />
                        <br />
                        <p align="left">
                            <p align="center">
                                <strong>Шоколад с логотипом<br>
                                    100 г. классический</strong></p>
                            <p align="center">
                                - прямоугольный шоколад, размером 160 х 80 мм
                                <br />
                                - полноцветная печать<br>
                                - возможны дополнительные услуги (пантон, тиснение)<br />
                                - цвет фольги – серебро
                                <br />
                                - шоколад расфасован в коробки по 20 шт.</p>
                        </p>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </artisteer:Article>
</asp:Content>
