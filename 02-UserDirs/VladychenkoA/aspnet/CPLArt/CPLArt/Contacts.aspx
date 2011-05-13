<%@ Page Title="" Language="C#" MasterPageFile="~/design/MasterPage.master" AutoEventWireup="true" 
CodeBehind="Contacts.aspx.cs" Inherits="CPLArt.Contacts" %>


<%@ Register TagPrefix="artisteer" Namespace="Artisteer" %>
<%@ Register TagPrefix="art" TagName="DefaultMenu" Src="DefaultMenu.ascx" %> 
<%@ Register TagPrefix="art" TagName="DefaultHeader" Src="DefaultHeader.ascx" %> 
<%@ Register TagPrefix="art" TagName="DefaultSidebar1" Src="DefaultSidebar1.ascx" %>
          

<asp:Content ID="PageTitle" ContentPlaceHolderID="TitleContentPlaceHolder" Runat="Server">
    ChocoPlanet - Контакты
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

<artisteer:Article ID="Article1" Caption=" Оставить свой отзыв о компании ChocoPlanet" runat="server"><ContentTemplate>
<div >
   <asp:HyperLink ID="HyperLink1" runat="server" 
        NavigateUrl="FeedBack.aspx" ForeColor="Blue" ToolTip="Нажмите здесь, чтобы оставить свой отзыв">Оставить отзыв!</asp:HyperLink>
       </div>
</ContentTemplate></artisteer:Article>
<artisteer:Article ID="Article2" Caption=" Контакты Компании компании ChocoPlanet" runat="server"><ContentTemplate>
<div >
   <b>ChocoPlanet Co.</b><br />
          Rivne, Ukraine 33000<br />
          Email: <a href="mailto:info@chocplanet.com">info@chocplanet.com</a><br />
          <br />
          Phone: (123) 456-7890 <br />
          Fax: (123) 456-7890
  </div>
</ContentTemplate></artisteer:Article>
</asp:Content>

