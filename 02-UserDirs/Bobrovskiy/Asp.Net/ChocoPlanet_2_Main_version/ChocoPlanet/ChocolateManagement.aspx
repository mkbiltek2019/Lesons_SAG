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
                 <asp:TemplateColumn>                  
                   <ItemTemplate>                          
                            <asp:LinkButton runat="server" 
                                            CommandName="Edit"
                                            CommandArgument='<%# Eval("Id") %>' 
                                            OnCommand="LinkButton_Command"
                                            Text="Редагувати" />
                            <asp:LinkButton runat="server" 
                                            CommandName="Delete" 
                                            CommandArgument='<%# Eval("Id") %>' 
                                            OnCommand="LinkButton_Command"                                            
                                            Text="Видалити"
                                            OnClientClick='return confirm("Ви впевнені що хочете видалити вказану категорію?");' />
                            <asp:LinkButton runat="server" 
                                            CommandName="New"               
                                            OnCommand="LinkButton_Command"                                           
                                            Text="Додати" />                                                              
                  </ItemTemplate>
                 </asp:TemplateColumn>
            </Columns>   
            
                   
    </asp:DataGrid>

   <br/>
   <div><p>
        <asp:Button runat="server" 
                    ID="btnAddNewCategory" 
                    OnClick="btnAddNewCategory_Click"
                    PostBackUrl="~/AddCategoryPage.aspx"
                    Text="Додати нову категорію" />
         <asp:Button runat="server" 
                    ID="btnAddProduct" 
                    OnClick="btnAddNewProduct_Click"
                    PostBackUrl="~/ProductEditWindow.aspx"
                    Text="Додати новий продукт" />
        </p>
        <p>
            <asp:Button runat="server"                                        
                    PostBackUrl="/Manager/BasketList.aspx"
                    Text="Переглянути  список кошиків" />
        </p>
   </div>
    <asp:ObjectDataSource 
                runat="server" 
                ID="odsCategoryList"
                TypeName="ChocoPlanet.Business.CategoryController"
                SelectMethod="GetAllCategories"> 
    </asp:ObjectDataSource>

   </div>
</asp:Content>
