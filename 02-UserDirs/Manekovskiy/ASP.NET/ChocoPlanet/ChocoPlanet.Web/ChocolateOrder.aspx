<%@ Page Title="" Language="C#"     AutoEventWireup="true" CodeBehind="ChocolateOrder.aspx.cs" 
    Inherits="ChocoPlanet.Web.ChocolateOrder" %>
<%@ Import Namespace="ChocoPlanet.Business" %>

<%--<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>--%>

<%--<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">--%>
    <asp:ObjectDataSource 
                runat="server" 
                ID="odsProduct"
                TypeName="ChocoPlanet.Business.ProductController"
                SelectMethod="GetAllProductsWithFilter"> 
        <SelectParameters>
            <asp:ControlParameter ControlID="ddlProductCategory" 
                Name="categoryId"
                PropertyName="SelectedValue" 
                Type="Int32" 
                Direction="Input"
                ConvertEmptyStringToNull="true" />
        </SelectParameters>
    </asp:ObjectDataSource>

    <asp:ObjectDataSource 
                runat="server" 
                ID="odsCategory"
                TypeName="ChocoPlanet.Business.CategoryController"
                SelectMethod="GetAllCategories"> 
    </asp:ObjectDataSource>

   <div>
   <asp:Label runat="server" ID="label">Please select product category:</asp:Label>
    <asp:DropDownList runat="server"             
            ID="ddlProductCategory"
            AutoPostBack="True"
            DataSourceID="odsCategory"
            DataTextField="Name"
            DataValueField="Id">   
    </asp:DropDownList>
   </div>

   <div>
     <asp:DataGrid BorderWidth="0"
                   runat="server" 
                   ID="dgProducts"            
                   AutoGenerateColumns="false"
                   DataSourceID="odsProduct">
        <Columns>
            <asp:BoundColumn DataField="Name" HeaderText="Название"/>
            <asp:BoundColumn DataField="Description" HeaderText="Описание"/>
            
            <asp:TemplateColumn HeaderText="Фото">
               <ItemTemplate>
                   <asp:HyperLink runat="server"
                                  NavigateUrl='<%# "~/images/" + Eval("ImageName")%>' 
                                  ImageUrl='<%# "~/images/" + Eval("ThumbnailName")%>'>
                   </asp:HyperLink>
               </ItemTemplate>
            </asp:TemplateColumn>

            <asp:BoundColumn DataField="Price" HeaderText="Цена" />
            
            <asp:TemplateColumn HeaderText="Дата поступления в продажу">
               <ItemTemplate>
                   <asp:Label runat="server" Text='<%# ((DateTime?)Eval("PlacementDate")).GetFormattedDate() %>'></asp:Label>
               </ItemTemplate>
            </asp:TemplateColumn>
         </Columns> 
        </asp:DataGrid>

        

   </div>
<%--</asp:Content>--%>
