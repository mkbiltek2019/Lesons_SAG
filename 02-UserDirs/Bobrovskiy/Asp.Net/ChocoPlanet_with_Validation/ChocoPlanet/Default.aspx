<%@ Page Title="Home Page" Language="C#" 
         MasterPageFile="~/Site.master" AutoEventWireup="true"
         CodeBehind="Default.aspx.cs" Inherits="ChocoPlanet._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
   <div id="outerFrame"> 
        <div id="headerFrame">
            <h1>Авторизація</h1>
        </div>

        <div id="avatarFrame">
        </div>

        <div id="loginPasswordOutterFrame">
            <div id="logonPasswordInnerFrame">
                <fieldset>
                    <p>
                        <asp:Label ID="lLogin" runat="server" Text="Логін:" />
                        <asp:TextBox runat="server" ID="tbLogin" TextMode="SingleLine" />
                    </p>
                    <p>
                        <asp:Label ID="lPassword" runat="server" Text="Пароль:" />
                        <asp:TextBox runat="server" ID="tbPassword" TextMode="Password" />
                    </p>
                    <p>
                        <asp:Button runat="server" ID="btnLogin" Text="Увійти" />
                    </p>
                </fieldset>
            </div>
            <p>
               <asp:HyperLink runat="server" NavigateUrl="RegistrationWebForm.aspx">Реєстрація</asp:HyperLink> | 
               <asp:HyperLink runat="server" NavigateUrl="#">Відновлення паролю</asp:HyperLink>
            </p>
        </div>
   </div>
    
</asp:Content>
