<%@ Page Title="" Language="C#" MasterPageFile="~/design/MasterPage.master" AutoEventWireup="true"
    CodeBehind="History.aspx.cs" Inherits="CPLArt.History" %>

<%@ Register TagPrefix="artisteer" Namespace="Artisteer" %>
<%@ Register TagPrefix="art" TagName="DefaultMenu" Src="DefaultMenu.ascx" %>
<%@ Register TagPrefix="art" TagName="DefaultHeader" Src="DefaultHeader.ascx" %>
<%@ Register TagPrefix="art" TagName="DefaultSidebar1" Src="DefaultSidebar1.ascx" %>
<asp:Content ID="PageTitle" ContentPlaceHolderID="TitleContentPlaceHolder" runat="Server">
    ChocoPlanet - История шоколада
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
    <artisteer:Article ID="Article1" Caption="История шоколада" runat="server">
        <ContentTemplate>
            <img src="images/istorija-shokolada.jpg" width="184" height="256" alt="история шоколада"
                hspace="15" vspace="5" align="right" class="img_cl" />
            <p>
                <b>История шоколада</b>, столь привычного нам сейчас, началась очень давно, более
                3000 лет назад. Примерно за 1500 лет до нашей эры в низменностях на берегу Мексиканского
                залива в Америке возникла цивилизация ольмеков. Их культура оставила нам очень мало,
                но некоторые лингвисты полагают, что слово "какао" впервые прозвучало как "kakawa"
                примерно за 1000 лет до нашей эры, в момент расцвета цивилизации ольмеков.
            </p>
            <p>
                <b>История шоколада. Индейцы Майя.</b>
                <br />
                Позднее на смену ольмекам пришла цивилизация майя. Предки майя пришли в низменные
                области северной Гватемалы примерно за 1000 лет до нашей эры. Cпустившись с плоскогорьев,
                майя обнаружили и стали культивировать дикорастущее какао-дерево и как раз в тот
                период скорее всего и возникло современное произношение слова "какао".
            </p>
            <p>
                <b>История шоколада. Толтеки и ацтеки.</b>
                <br />
                После 9 века нашей эры классическая культура майя начала распадаться, и на смену
                майя примерно в 1000 году нашей эры пришли толтеки. Но и эта культура угасла в 12
                веке в результате внутренних разноглассий и восттаний. После 1200 года контроль
                над Мексикой и окружающими территориями установили ацтеки. Их цивилизация просуществовала
                вплоть до 1521 года, пока не была разрушена испанцами.
            </p>
            <p>
                <b>История шоколада. Колумб.</b>
                <br />
                Говорят что Кристофер Колумб привез какао-бобы королю Фердинанду из своей четвертой
                экспедиции в Новый Свет, но никто так и не обратил на них особого внимания ввиду
                большого количества прочих сокровищ, привезенных Колумбом. В последующие 100 лет
                после Колумба шоколад появился и в Европе. Стоя по 10-15 шиллингов за фунт, шоколад
                считался напитком для высшего света. В шестнадцатом столетии испанский историк Овиедо
                писал: "Только богатый и благородный мог позволить себе пить шоколад, так как он
                буквально пил деньги. Какао-бобы использовали как валюту все нации; за 100 этих
                семян какао вполне можно было купить хорошего раба."
            </p>
            <p>
                <b>История шоколада. Европа.</b>
                <br />
                Ввозимое в Европу какао попадает сначала в монастыри и во Двор короля, где пользуется
                большой популярностью у придворных дам. Из Испании "ксоколатл" проникает в Европу,
                быстро вытесняя мексиканские пряности, сделанные из тростникового сахара и ванили.
                Правительство немецкого императора Карла V, сознавая коммерческую важность какао,
                требует монополии на этот продукт. Однако уже в XVII веке отряды контрабандистов
                активно ввозят его в Нидерланды. Первые лицензии на создание шоколадного производства
                изобретают итальянцы. В Англии "Chocolate Houses" более посещаемы, чем кофейные
                и чайные салоны. В XIX веке появляются первые шоколадные плитки, а Жан Неаус изобретает
                первую конфету с начинкой пралине.
            </p>
        </ContentTemplate>
    </artisteer:Article>
</asp:Content>
