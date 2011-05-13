<%@ Control Language="C#" AutoEventWireup="true" CodeFile="DefaultSidebar1.ascx.cs"
    Inherits="Sidebar1" %>
<%@ Import Namespace="Artisteer" %>
<%@ Register TagPrefix="artisteer" Namespace="Artisteer" %>
<%@ Register TagPrefix="art" TagName="DefaultVerticalMenu" Src="DefaultVerticalMenu.ascx" %>
<art:DefaultVerticalMenu ID="DefaultVMenuContent" runat="server" />
<artisteer:Block ID="NewsletterBlock" Caption=" Рассылка на email" runat="server">
    <ContentTemplate>
        <div>
            <input type="text" value="" name="email" id="s" style="width: 95%;" />
            <span class="art-button-wrapper"><span class="l"></span><span class="r"></span>
                <input class="art-button" type="submit" name="search" value="Подписаться" />
            </span>
        </div>
    </ContentTemplate>
</artisteer:Block>
<artisteer:Block ID="HighlightsBlock" Caption="Highlights" runat="server">
    <ContentTemplate>
        <div>
            <ul>
                <li><b>Апрель 30, 20011</b>
                    <p>
                        Первый в Украине передвижной музей шоколада, путешествующий по стране, развернул
                        теперь страну Шоколандию на Слобожанщине.<br />
                        <a href="News.aspx">Читать больше...</a>
                    </p>
                </li>
            </ul>
            <ul>
                <li><b>Мaй 05, 2011</b>
                    <p>
                        Темный шоколад полезнее фруктовых соков, считают ученые.<br />
                        <a href="News.aspx">Читаь больше...</a>
                    </p>
                </li>
            </ul>
        </div>
    </ContentTemplate>
</artisteer:Block>
<artisteer:Block ID="ContactInformationBlock" Caption="Contact Info" runat="server">
    <ContentTemplate>
    <div><b>Котактная информация</b></div>
        <div>
            <img src="images/contact.jpg" alt="an image" style="margin: 0 auto; display: block;
                width: 95%" />
            <br />
            <b>ChocoPlanet Co.</b><br />
            Rivne, Ukraine 33000<br />
            Email: <a href="mailto:info@chocplanet.com">info@chocplanet.com</a><br />
            <br />
            Phone: (123) 456-7890
            <br />
            Fax: (123) 456-7890
        </div>
    </ContentTemplate>
</artisteer:Block>
