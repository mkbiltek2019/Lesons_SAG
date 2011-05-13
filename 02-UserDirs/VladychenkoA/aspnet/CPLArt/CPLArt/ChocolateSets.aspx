<%@ Page Title="" Language="C#" MasterPageFile="~/design/MasterPage.master" AutoEventWireup="true"
    CodeBehind="ChocolateSets.aspx.cs" Inherits="CPLArt.ChocolateSets" %>

<%@ Register TagPrefix="artisteer" Namespace="Artisteer" %>
<%@ Register TagPrefix="art" TagName="DefaultMenu" Src="DefaultMenu.ascx" %>
<%@ Register TagPrefix="art" TagName="DefaultHeader" Src="DefaultHeader.ascx" %>
<%@ Register TagPrefix="art" TagName="DefaultSidebar1" Src="DefaultSidebar1.ascx" %>
<asp:Content ID="PageTitle" ContentPlaceHolderID="TitleContentPlaceHolder" runat="Server">
    ChocoPlanet - Шоколадные наборы
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
    <artisteer:Article ID="Article1" Caption="Шоколадные наборы" runat="server">
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

            <p align="center" class="style12">
                <strong>Всегда к месту!</strong></p>
            <p>
                <span class="style12">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Использование корпоративных
                    шоколадных наборов в качестве подарков или сувениров открывает широкие возможности
                    для воплощения Ваших желаний.
                    <br>
                    В этом случае создается серия шоколадных съедобных сувениров, объединенных единой
                    концепцией, которая позволяет наиболее полно представить весь спектр Ваших товаров
                    или услуг.<br>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Серия шоколадок или конфет упакована в яркую
                    красочную коробку, дизайн которой подчеркивает и многократно усиливает воздействие
                    корпоративного сувенира. Рекламное изображение высокого качества и отменный вкус
                    бельгийского шоколада взаимно дополняют друг друга, усиливая впечатление.<br>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Наша компания предлагает широкий ассортимент
                    наборов <a href="ChocolateLogo.aspx">шоколада с логотипом</a> (коробки шоколада)
                    и конфет.
                    <br>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span><span class="style12">Осуществляем доставку в
                        Ваш город.</span><br>
                <br>
            </p>
            <div class="art-content-layout overview-table">
                <div class="art-content-layout-row">
                    <div class="art-layout-cell">
                        <a href="javascript:popup('./images/volvo2.jpg',820,620,0,'Прямоугольный', '', ' 4 двадцатиграммовые шоколадки', '212 х 150 х 20 мм');">
                            <img class="art-article" src="images/volvo2.jpg" width="250" height="250" alt="«ТЕТРА КНИГА»"
                                style="float: left; border: 0; margin: 1em 1em 0 0;" /></a>
                    </div>
                    <div class="art-layout-cell">
                        <br />
                        <br />
                        <br />
                        <p align="center">
                            <strong>Корпоративный набор &quot;ТЕТРА КНИГА&quot;<br>
                                4 двадцатиграммовые шоколадки </strong>
                        </p>
                        <p align="left">
                            - набор из 4 двадцатиграммовых шоколадок<br>
                            - картонная коробка размером 212 х 150 х 20 мм<br>
                            - полноцветная печать<br>
                            - возможны дополнительные услуги (пантон, тиснение), покрытие УФ-лаком (глянцевым,
                            матовым), ламинирование</p>
                        <br />
                    </div>
                </div>
            </div>
            <div class="art-content-layout-row">
                <div class="art-content-layout-row">
                    <div class="art-layout-cell">
                    <a href="javascript:popup('./images/volvo2.jpg',820,620,0,'Прямоугольный', '', ' 3 стограммовые шоколадки', '275 х 200 х 10 мм');">
                        <img class="art-article" src="images/korobka.jpg" width="250" height="250" alt="УДОВОЛЬСТВИЯ"
                            style="float: left; border: 0; margin: 1em 1em 0 0;" /></a>
                    </div>
                    <div class="art-layout-cell">
                        <br />
                        <br />
                        <br />
                        <p align="center">
                            <strong>Корпоративный набор
                                <br>
                                &quot;300 г. УДОВОЛЬСТВИЯ&quot;
                                <br>
                            </strong><strong>3 стограммовые шоколадки </strong>
                        </p>
                        <p align="left">
                            - набор из 3 стограммовых шоколадок<br>
                            - картонная коробка размером 275 х 200 х 10 мм<br>
                            - полноцветная печать<br>
                            - возможны дополнительные услуги (пантон, тиснение), покрытие УФ-лаком (глянцевым,
                            матовым), ламинирование</p>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </artisteer:Article>
</asp:Content>
