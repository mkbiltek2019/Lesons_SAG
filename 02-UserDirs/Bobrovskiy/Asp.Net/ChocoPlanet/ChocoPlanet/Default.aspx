<%@ Page Title="Home Page" Language="C#" 
         MasterPageFile="~/Site.master" AutoEventWireup="true"
         CodeBehind="Default.aspx.cs" Inherits="ChocoPlanet._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        Chocolate Sun
    </h2>
    <p>
        <asp:Image ImageUrl="~/sun.jpg" runat="server"/>
    </p>
    
</asp:Content>
