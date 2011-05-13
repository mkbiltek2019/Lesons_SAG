<%@ Page Language="C#" MasterPageFile="~/design/MasterPage.master" AutoEventWireup="true"
    CodeBehind="News.aspx.cs" Inherits="CPLArt.News" %>

<%@ Register TagPrefix="artisteer" Namespace="Artisteer" %>
<%@ Register TagPrefix="art" TagName="DefaultMenu" Src="DefaultMenu.ascx" %>
<%@ Register TagPrefix="art" TagName="DefaultHeader" Src="DefaultHeader.ascx" %>
<%@ Register TagPrefix="art" TagName="DefaultSidebar1" Src="DefaultSidebar1.ascx" %>
<asp:Content ID="PageTitle" ContentPlaceHolderID="TitleContentPlaceHolder" runat="Server">
    ChocoPlanet - Новости
</asp:Content>
<asp:Content ID="HeaderContent" ContentPlaceHolderID="HeaderContentPlaceHolder" runat="Server">
    <art:DefaultHeader ID="DefaultHeader" runat="server" />
</asp:Content>
<asp:Content ID="MenuContent" ContentPlaceHolderID="MenuContentPlaceHolder" runat="Server">
    <art:DefaultMenu ID="DefaultMenuContentC" runat="server" />
</asp:Content>
<asp:Content ID="SideBar1" ContentPlaceHolderID="Sidebar1ContentPlaceHolder" runat="Server">
    <art:DefaultSidebar1 ID="DefaultSidebar1Content" runat="server" />
</asp:Content>
<asp:Content ID="SheetContent" ContentPlaceHolderID="SheetContentPlaceHolder" runat="Server">
    <artisteer:Article ID="Article1" Caption="Новости компании ChocoPlanet" runat="server">
        <ContentTemplate>
            <div>
                <p>
                    <strong>30.04.2011</strong>
                </p>
                <p>
                    <img style="float: left; border: 0pt none; margin: 5px;" src="images/mchoco.jpg"
                        alt="" width="250" />Первый в Украине передвижной музей шоколада, путешествующий
                    по стране, развернул теперь страну Шоколандию на Слобожанщине.</p>
                <p>
                    Дети до 10 лет смогут попасть в мир шоколада бесплатно, продемонстрировав хорошую
                    успеваемость в школе, показав дневник с оценками. Да и для всех остальных, входной
                    билет окажется весьма сладким, в самом прямом смысле слова. Для того чтобы посетить
                    &laquo;Шоколандию&raquo;, необходимо будет просто приобрести сладости от &laquo;АВК&raquo;
                    на 20 грн. в супермаркете &laquo;Класс&raquo; и чек обменять на бесплатный билет.&nbsp;</p>
                <p>
                    В свою очередь, для главных критиков &ndash; для детей, организаторы приготовили
                    много увлекательных конкурсов, в которых, судя по опыту других городов, не прочь
                    поучаствовать и взрослые. Конечно же, в качестве подарков победителям получают шоколадные
                    сюрпризы.</p>
                <p>
                    Харьков стал десятым, юбилейным городом, принимающим музей шоколада. Экспозиция
                    шоколадных миниатюр, специально изготавливается для каждого города эксклюзивно.
                    Вкусная экспозиция состоит из пятидесяти эксклюзивных фигурок, сделанных вручную.
                    Среди них и Эйфелева башня, и компьютерная мышь, и футбольный мяч - они не продаются.</p>
                <p>
                    Изюминкой харьковской &laquo;шоколадно страны&raquo; стали шоколадные мастер-классы,
                    которые организаторы проводят для всех желающих.</p>
                <p>
                    При посещении &laquo;шоколадного музея&raquo; Вас ждет увлекательный экскурс в историю
                    шоколада, с дальнейшей экскурсией к шоколадным скульптурам и оригинальным композициям
                    из шоколада. Завершит визит в шоколадную фантазию &ndash; настоящая феерия шоколадного
                    фонтана, в котором каждый посетитель сможет утолить свою жажду. Чайный партнер чай
                    &laquo;TESS&raquo; и кофейный партнер кофе &laquo;JARDIN&raquo; угостит каждого
                    посетителя ароматным горячим напитком.</p>
                <p>
                    В Харькове двери музея будут открыты в течение трех месяцев. Работает &laquo;Шоколандия&raquo;
                    каждый день с 10:00 до 21:00, за исключением понедельника. Новая экскурсия начинается
                    каждые полчаса. Адрес &laquo;шоколадной страны&raquo;: пр. Тракторостроителей, 128
                    В, ТРЦ &laquo;Класс&raquo; (2-й этаж).</p>
            </div>
            <br />
            <div>
                <p>
                    <strong>05.05.2011</strong></p>
                <p>
                    Темный шоколад и какао-порошок превосходят по содержанию полезных для организма
                    антиоксидантов многие фруктовые соки, которые популярные СМИ включают в списки "самых
                    здоровых", говорится в статье, опубликованной в <a href="http://www.journal.chemistrycentral.com/"
                        target="_blank">Chemistry Central Journal</a> группой ученых из исследовательского
                    центра компании Hershey (США).</p>
                <p>
                    Авторы статьи изучили содержание нескольких веществ-антиоксидантов, препятствующих
                    разрушительным окислительным процессам в клетках организма, в гранатовом соке, соке
                    клюквы, голубики, и ягоды южноамериканской пальмы асаи, а также в какао-порошке,
                    полученном из семян дерева какао (Theobroma cacao), и в темном шоколаде.</p>
                <p>
                    В частности, ученые анализировали содержание флаваноидов, полифенолов, измеряли
                    общую активность антиоксидантов.</p>
                <p>
                    Сопоставление полученных данных показало, что наиболее высокая концентрация антиоксидантов
                    была в какао-порошке. Доза этих веществ в темном шоколаде также оказалась выше,
                    чем в тестируемых фруктовых соках.</p>
                <p>
                    Однако в горячем шоколаде, при изготовлении которого шоколад проходит процедуру
                    ощелачивания, антиоксидантов оказалось мало.</p>
                <p>
                    Прежние исследования свидетельствовали, что употребление умеренных доз темного шоколада
                    - около 6,7 грамма в день - на треть сокращает риск болезней сердца. Однако, как
                    отмечает газета Daily Mail, из-за высокого содержания сахара в шоколадных продуктах,
                    диетологи рекомендуют употреблять его в составе сбалансированной диеты, включающей
                    овощи, нешлифованный рис и фрукты.</p>
            </div>
            <div>
                <b>ChocoPlanet Co.</b><br />
                Rivne, Ukraine 33000<br />
                Email: <a href="mailto:info@chocplanet.com">info@chocplanet.com</a><br />
                <br />
                Phone: (123) 456-7890
                <br />
                Fax: (123) 456-7890
            </div>
        </ContentTemplate>
    </artisteer:Article>
</asp:Content>
