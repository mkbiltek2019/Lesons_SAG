<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true" CodeBehind="ChocolateOrder.aspx.cs" 
    Inherits="ChocoPlanet.ChocolateOrder" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
   <div>
   <asp:Label runat="server" ID="label">Please select product category:</asp:Label>
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
               <a href='<%# Eval("MainImagePath")%>'>
               <img alt="image" src='<%# Eval("ThubmnailImagePath")%>'/>                  
               </a>
              
               </ItemTemplate>
            </asp:TemplateColumn>

                <asp:BoundColumn DataField="Price" />

            <asp:TemplateColumn HeaderText=" ">
               <ItemTemplate>
                  <asp:HyperLink id="hlDetails"
                       Text="Details"
                       NavigateUrl="#"
                       runat="server"/>
               </ItemTemplate>
            </asp:TemplateColumn>
           
         </Columns> 
         
    </asp:DataGrid>
   
    <%-- <asp:ObjectDataSource 
                runat="server" 
                ID="odsProduct"
                TypeName="ChocoPlanet.Business.ProductController"
                SelectMethod="GetAllProducts"> 
    </asp:ObjectDataSource>--%>

    <asp:ObjectDataSource 
                runat="server" 
                ID="odsCategoryList"
                TypeName="ChocoPlanet.Business.ProductController"
                SelectMethod="GetCategoryList"> 
    </asp:ObjectDataSource>

   </div>
</asp:Content>
