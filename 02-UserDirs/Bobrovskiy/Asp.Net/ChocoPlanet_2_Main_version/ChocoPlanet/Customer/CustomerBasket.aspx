<%@ Page Title="" Language="C#"
     MasterPageFile="~/Site.Master" 
     AutoEventWireup="true" 
     CodeBehind="CustomerBasket.aspx.cs" 
     Inherits="ChocoPlanet.Customer.CustomerBasket" %>

<asp:Content ID="Content1" 
    ContentPlaceHolderID="HeadContent" 
    runat="server">
</asp:Content>

<asp:Content ID="Content2" 
             ContentPlaceHolderID="MainContent" 
             runat="server">
             <h2>Кошик з замовленнями.</h2>
        <fieldset>           

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
               <img style="border:0" alt="image" src='<%#"../" + Eval("ThumbnailName")%>'/>                  
               </a>
              
               </ItemTemplate>
            </asp:TemplateColumn>

                <asp:BoundColumn DataField="Price" />               

            <asp:TemplateColumn HeaderText=" ">
               <ItemTemplate>
                   <asp:LinkButton ID="btnRemove" 
                        runat="server" 
                        CommandName="Remove"
                        CommandArgument='<%# Eval("ProductId") %>' 
                        OnCommand="btnRemoveFromBasket"
                        Text="Видалити" /> 
              </ItemTemplate>
            </asp:TemplateColumn>
           
         </Columns> 
         
    </asp:DataGrid>
    </fieldset>

    <asp:Button runat="server" ID="btnPlaceOrder" Text="Оформити замовлення" OnClick="btnPlaceOrder_Click"/>
   
</asp:Content>
