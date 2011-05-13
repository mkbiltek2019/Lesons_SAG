<%@ Page Title="" Language="C#" MasterPageFile="~/design/MasterPage.master" AutoEventWireup="true" 
CodeBehind="Products.aspx.cs" Inherits="CPLArt.Products" %>

<%@ Register TagPrefix="artisteer" Namespace="Artisteer" %>
<%@ Register TagPrefix="art" TagName="DefaultMenu" Src="DefaultMenu.ascx" %> 
<%@ Register TagPrefix="art" TagName="DefaultHeader" Src="DefaultHeader.ascx" %> 
<%@ Register TagPrefix="art" TagName="DefaultSidebar1" Src="DefaultSidebar1.ascx" %>

<asp:Content ID="PageTitle" ContentPlaceHolderID="TitleContentPlaceHolder" Runat="Server">
    ChocoPlanet - Продукция
</asp:Content>

<asp:Content ID="HeaderContent" ContentPlaceHolderID="HeaderContentPlaceHolder" Runat="Server">
    <art:DefaultHeader ID="DefaultHeader" runat="server" />
</asp:Content>
<asp:Content ID="MenuContent" ContentPlaceHolderID="MenuContentPlaceHolder" Runat="Server">
    <art:DefaultMenu ID="DefaultMenuContent" runat="server" />
</asp:Content>
<asp:Content ID="SideBar1" ContentPlaceHolderID="Sidebar1ContentPlaceHolder" Runat="Server">
    <art:DefaultSidebar1 ID="DefaultSidebar1Content" runat="server" />
</asp:Content>
<asp:Content ID="SheetContent" ContentPlaceHolderID="SheetContentPlaceHolder" Runat="Server">
<artisteer:Article ID="Article1" Caption="Продукция компании ChocoPlanet" runat="server"><ContentTemplate>
</ContentTemplate>
</artisteer:Article>
</asp:Content>