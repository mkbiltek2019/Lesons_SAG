<%@ Page Title="" Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeBehind="Order.aspx.cs" Inherits="ChocoPlanet.Order" %>
<%@ Import Namespace="ChocoPlanet.Business" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
    <title>Заказ</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cphContent" runat="server">
    <asp:ObjectDataSource runat="server" ID="odsProduct"
        TypeName="ChocoPlanet.Business.ProductController"
        SelectMethod="GetAllProducts"> 
    </asp:ObjectDataSource>

    <asp:DataGrid runat="server" ID="dgProducts"
        DataSourceId="odsProduct" 
        AutoGenerateColumns="true">
    </asp:DataGrid>

</asp:Content>
