<%@ Page Title="" 
         Language="C#"
         MasterPageFile="~/Site.Master"
         AutoEventWireup="true" 
         CodeBehind="ChocolateManagement.aspx.cs" 
         Inherits="ChocoPlanet.ChocolateManagement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" 
             ContentPlaceHolderID="MainContent" 
             runat="server">
    <div>
        <asp:Label runat="server" 
                   ID="label">Категорії:</asp:Label>    
    </div>

   <div>
     <asp:DataGrid 
            BorderWidth="0"
            DataSourceID="odsCategoryList" 
            runat="server" 
            ID="dgProducts"            
            AutoGenerateColumns="false">

            <Columns>
                <asp:BoundColumn DataField="Name" HeaderText="Назва"/>
                <asp:BoundColumn DataField="Description"  HeaderText="Опис" />  
            </Columns> 
         
    </asp:DataGrid>
   <br/>
   <div>
        <asp:Button runat="server" 
                    ID="btnAddNewCategory" 
                    OnClick="btnAddNewCategory_Click"
                    PostBackUrl="~/ProductEditWindow.aspx"
                    Text="Додати нову категорію" />
   </div>
    <asp:ObjectDataSource 
                runat="server" 
                ID="odsCategoryList"
                TypeName="ChocoPlanet.Business.ProductController"
                SelectMethod="GetCategoryListWithDescription"> 
    </asp:ObjectDataSource>

   </div>
</asp:Content>
