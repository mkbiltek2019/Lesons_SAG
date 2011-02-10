<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true" CodeBehind="ChocolateOrder.aspx.cs"
    EnableEventValidation="false" 
    Inherits="ChocoPlanet.ChocolateOrder" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

   <div>
   <asp:Label runat="server" ID="label">Оберіть категорію продуктів :</asp:Label>
    <asp:DropDownList 
            EnableViewState="False"
            CssClass="header" 
            AutoPostBack="True"
            OnTextChanged="OnDDListSelectionChanged_Click"                      
            runat="server"             
            DataSourceID="odsCategoryList"          
            ID="ddlProductCategory">   
    </asp:DropDownList>
   </div>

   <div>
     <asp:DataGrid 
            BorderWidth="0"
            runat="server" 
            ID="dgProducts"            
            AutoGenerateColumns="false">

            <Columns>
            <asp:BoundColumn DataField="Name"/>
            <asp:BoundColumn DataField="Description"/>
                       
            <asp:TemplateColumn HeaderText=" ">
               <ItemTemplate>
               <a href='<%# Eval("ImageName")%>'>
               <img style="border:0" alt="image" src='<%# Eval("ThumbnailName")%>'/>                  
               </a>
              
               </ItemTemplate>
            </asp:TemplateColumn>

                <asp:BoundColumn DataField="Price" />
                <asp:BoundColumn DataField="PlacementDate" />
                <asp:BoundColumn DataField="CategoryId" />

            <asp:TemplateColumn HeaderText=" ">
               <ItemTemplate>
                   <asp:LinkButton ID="btnAdd" 
                        runat="server" 
                        CommandName="Edit"
                        CommandArgument='<%# Eval("ProductId") %>' 
                        OnCommand="btnAddToBasket"
                        Text="Додати до кошика" />                   
               </ItemTemplate>
            </asp:TemplateColumn>
           
         </Columns> 
         
    </asp:DataGrid>
   
    <asp:ObjectDataSource 
                runat="server" 
                ID="odsProduct"
                TypeName="ChocoPlanet.Business.ProductController"
                SelectMethod="GetAllProducts"> 
    </asp:ObjectDataSource>

    <asp:ObjectDataSource 
                runat="server" 
                ID="odsCategoryList"
                TypeName="ChocoPlanet.Business.CategoryController"
                SelectMethod="GetCategoryList"> 
    </asp:ObjectDataSource>

   </div>
</asp:Content>
