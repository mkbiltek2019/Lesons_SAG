<%@ Page Title="" Language="C#" 
MasterPageFile="~/Site.Master" AutoEventWireup="true" 
CodeBehind="OrderBasket.aspx.cs" Inherits="ChocoPlanet.OrderBasket" %>

<asp:Content ID="Content1" 
             ContentPlaceHolderID="HeadContent" 
             runat="server">
</asp:Content>

<asp:Content ID="Content2" 
             ContentPlaceHolderID="MainContent" 
             runat="server">
             <h2>Список прокуктів у вашому кошику</h2>
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
                    <asp:LinkButton ID="LinkButton1" runat="server" 
                                    CommandName="Edit"
                                    CommandArgument='<%# Eval("Id") %>' 
                                    OnCommand="LinkButton_Command"
                                    Text="Редагувати" />
                    <asp:LinkButton ID="LinkButton2" runat="server" 
                                    CommandName="Delete" 
                                    CommandArgument='<%# Eval("Id") %>' 
                                    OnCommand="LinkButton_Command"                                            
                                    Text="Видалити"
                                    OnClientClick='return confirm("Ви впевнені, що хочете видалити вказаний продукт?");' />
                    <asp:LinkButton ID="LinkButton3" runat="server" 
                                    CommandName="New"               
                                    OnCommand="LinkButton_Command"                                           
                                    Text="Додати" />                                                              
                  </ItemTemplate>
                 </asp:TemplateColumn>
            </Columns>               
                   
    </asp:DataGrid>
</div>

<asp:ObjectDataSource 
                runat="server" 
                ID="odsCategoryList"
                TypeName="ChocoPlanet.Business.CategoryController"
                SelectMethod="GetAllCategories"> 
</asp:ObjectDataSource>

</asp:Content>
