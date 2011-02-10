<%@ Page Title="" Language="C#" 
MasterPageFile="~/Site.Master" 
AutoEventWireup="true" 
CodeBehind="UserBasketDetails.aspx.cs" 
Inherits="ChocoPlanet.Manager.UserBasketDetails" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content 
        ID="Content1" 
        ContentPlaceHolderID="HeadContent" 
        runat="server">
</asp:Content>

<asp:Content ID="Content2" 
        ContentPlaceHolderID="MainContent" 
        runat="server">
             
     <h2>Перелік продуктів у кошику.</h2>

     <fieldset>
     <div>
        <asp:DataGrid 
            BorderWidth="0"            
            runat="server"   
            ID="dgOrderItems"            
            AutoGenerateColumns="false">
            
            <Columns>
                <asp:BoundColumn DataField="ProductName" HeaderText="Назва продукту"/>
                <asp:BoundColumn DataField="ProductPrice"  HeaderText="Ціна" />  
                <asp:BoundColumn DataField="OrderState"  HeaderText="Стан замовлення" />  
                <asp:BoundColumn DataField="CurierPassingDate"  HeaderText="Дата передачі курєру" />  
                <asp:BoundColumn DataField="DeliveryDate"  HeaderText="Дата доставки" />  

                 <asp:TemplateColumn>                                  
                   <ItemTemplate>     
                      <asp:LinkButton  runat="server"                         
                        ID="lbtnEdit"                         
                        CommandName="Edit"
                        CommandArgument='<%# Eval("OrderStatusID") %>'                        
                        OnCommand="LinkButton_Command"
                        Text="Редагувати" />                                         
                  </ItemTemplate>
                 </asp:TemplateColumn>
            </Columns>   

    </asp:DataGrid>
    </div>
    </fieldset>  

</asp:Content>
