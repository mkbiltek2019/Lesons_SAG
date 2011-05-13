<%@ Page Title="" Language="C#" MasterPageFile="~/design/MasterPage.master" AutoEventWireup="true"
    CodeBehind="ChocolateLogo.aspx.cs" Inherits="CPLArt.ChocolateLogo" %>

<%@ Register TagPrefix="artisteer" Namespace="Artisteer" %>
<%@ Register TagPrefix="art" TagName="DefaultMenu" Src="DefaultMenu.ascx" %>
<%@ Register TagPrefix="art" TagName="DefaultHeader" Src="DefaultHeader.ascx" %>
<%@ Register TagPrefix="art" TagName="DefaultSidebar1" Src="DefaultSidebar1.ascx" %>
<asp:Content ID="PageTitle" ContentPlaceHolderID="TitleContentPlaceHolder" runat="Server">
    ChocoPlanet - Шоколад с логотипом
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
    <artisteer:Article ID="Article1" Caption="Шоколад с логотипом" runat="server">
        <ContentTemplate>
            <p>
                <span class="style12">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Воплощая в жизнь стратегию
                    развития вашего бизнеса, возьмите в союзники еще один эффективный инструмент, улучшающий
                    взаимоотношения с клиентом.<br />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;В нашем маленьком, но эффективном сувенире сконцентрировались
                    все положительные качества, присущие этому изысканному и благородному продукту.<br>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Мы предлагаем Вашему вниманию шоколад с логотипом
                    - шоколадные изделия с нанесением индивидуальной символики и информации, как на
                    этикетку, так и, непосредственно, на сам шоколад, на шоколадные плитки (логотип,
                    фотография, фирменный стиль). По Вашему желанию может быть изготовлена шоколадная
                    плитка индивидуального размера и формы. Для производства мы используем горький,
                    темный, молочный, десертный и шоколад с орехами лучших бельгийских производителей.<br />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Шоколад с логотипом - это оригинальный и приятный
                    подарок. Вкусный презент с логотипом и другой полезной информацией о Вашей компании
                    на этикетке может быть использован и как корпоративный сувенир, и в качестве ненавязчивого
                    рекламного продукта на выставках, акциях и других мероприятиях. Кроме того, выразить
                    благодарность посетителю кафе, гостиницы или ресторана, преподнеся скромный шоколадный
                    сувенир, считается хорошим тоном и оставляет «сладкие» воспоминания о заведении.
                    <br>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Полноцветная (CMYK) печать этикеток производится
                    на новейшей печатной машине &quot;Хейдельберг&quot;. Возможны дополнительные услуги
                    (печать пантоном, тиснение и т.д.).<br />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Осуществляем доставку в Ваш город.</span><br>
                <br />
            </p>
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
