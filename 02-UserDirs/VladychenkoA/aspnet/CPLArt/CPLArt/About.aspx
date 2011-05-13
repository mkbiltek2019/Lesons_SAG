<%@ Page Language="C#" MasterPageFile="~/design/MasterPage.master" AutoEventWireup="true"
    CodeBehind="About.aspx.cs" Inherits="CPLArt.About" %>

<%@ Register TagPrefix="artisteer" Namespace="Artisteer" %>
<%@ Register TagPrefix="art" TagName="DefaultHeader" Src="DefaultHeader.ascx" %>
<%@ Register TagPrefix="art" TagName="DefaultMenu" Src="DefaultMenu.ascx" %>
<%@ Register TagPrefix="art" TagName="DefaultSidebar1" Src="DefaultSidebar1.ascx" %>
<asp:Content ID="PageTitle" ContentPlaceHolderID="TitleContentPlaceHolder" runat="Server">
    ChocoPlanet - О компании
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
    <artisteer:Article ID="Article1" Caption="О компании ChocoPlanet" runat="server">
        <ContentTemplate>
            <p align="center">
                <span class="style14"><h5>О компании</h5> </span>
            </p>
            <p align="justify">
                <span class="style14">&nbsp; </span>&nbsp;Компания «ChocoPlanet» выпускает шоколадную
                продукцию с 1999 года. За это время наша компания зарекомендовала себя как надежный
                и принципиальный партнер для более, чем 1000 организаций, в числе которых рестораны,
                казино, банки, инвестиционные и строительные компании. Выполнено большое количество
                индивидуальных заказов для небольших фирм и частных лиц.
            </p>
            <p align="justify">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;За прошедшие годы нам удалось собрать дружную команду
                единомышленников и профессионалов, насчитывающую более 30 человек.
            </p>
            <p align="justify">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Основной концепцией компании всегда было сохранение
                профессиональной специализации, поскольку именно она является настоящей гарантией
                качества выпускаемых продуктов. Мы стремимся постоянно совершенствовать уже существующие
                технологии, опираясь на опыт прошлых лет, учитывая пожелания наших заказчиков и
                принимая во внимание условия работы, которые диктует российский шоколадный рынок.
            </p>
            <p align="justify">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Опыт мастеров высокого класса, сырье бельгийских
                производителей, современное оборудование и соблюдение интересов заказчика позволяют
                нам производить продукцию, полностью отвечающую потребностям наших клиентов
            </p>
            <p align="justify">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Мы предлагаем самые низкие цены, систему скидок для
                постоянных клиентов и рекламных агентств. Высокое качество, оперативность выполнения
                заказов, профессионализм сотрудников - все это дает компании «Интершок» ряд конкурентных
                преимуществ!
            </p>
            <p align="justify">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Элитная продукция высшего качества с фирменной символикой
                - шоколад с логотипом - создается при Вашем непосредственном участии и под Вашим
                контролем.
            </p>
            <p align="justify">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Надеемся, что сотрудничество с нами будет для Вас
                не только выгодным, но и приятным.
            </p>
            <p align="justify" class="style14">
                &nbsp;</p>
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
