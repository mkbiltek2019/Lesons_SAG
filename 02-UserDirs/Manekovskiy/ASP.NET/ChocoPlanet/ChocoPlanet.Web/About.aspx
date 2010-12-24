<%@ Page Title="About Us" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="About.aspx.cs" Inherits="ChocoPlanet.About" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">

    <asp:HyperLink runat="server" 
        NavigateUrl="~/Feedback.aspx">Пожелайте что-нибудь нашему замечательному сервису!</asp:HyperLink>
       
</asp:Content>
