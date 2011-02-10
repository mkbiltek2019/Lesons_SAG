<%@ Page Title="Home Page" Language="C#" 
         MasterPageFile="~/Site.master" AutoEventWireup="true"
         CodeBehind="Default.aspx.cs" Inherits="ChocoPlanet._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
  
    
   <div>
   <asp:Label runat="server" ID="label1">Most wanted...</asp:Label>
    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl = "/Not_used/SlideShow.aspx" Text="SlideShow"/>

    </div>
    
      
     
    
</asp:Content>
