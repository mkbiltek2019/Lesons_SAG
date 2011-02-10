<%@ Page Title="" Language="C#" 
MasterPageFile="~/Site.Master" AutoEventWireup="true" 
CodeBehind="BasketList.aspx.cs" Inherits="ChocoPlanet.Manager.BasketList" %>

<asp:Content ID="Content1" 
            ContentPlaceHolderID="HeadContent" 
            runat="server">
</asp:Content>

<asp:Content ID="Content2" 
            ContentPlaceHolderID="MainContent" 
            runat="server">
<h2>Список кошиків для обробки</h2>

 <asp:DataGrid 
            BorderWidth="0"
            DataSourceID="odsBasketList" 
            runat="server" 
            ID="dgProducts"            
            AutoGenerateColumns="false">
            
            <Columns>
                <asp:BoundColumn DataField="ID" HeaderText="Номер кошика"/>
                <asp:BoundColumn DataField="CreationDate"  HeaderText="Дата створення" />  
                 <asp:TemplateColumn>                  
                   <ItemTemplate>                          
                    <asp:LinkButton 
                        runat="server" 
                        CommandName="Edit"
                        CommandArgument='<%# Eval("ID") %>' 
                        OnCommand="LinkButton_Command"
                        Text="Переглянути" />                                                                                         
                  </ItemTemplate>
                 </asp:TemplateColumn>
            </Columns>   

    </asp:DataGrid>

    <asp:ObjectDataSource 
                runat="server" 
                ID="odsBasketList"
                TypeName="ChocoPlanet.Business.Managers.BasketsManager"
                SelectMethod="GetBasketList"> 
    </asp:ObjectDataSource>

</asp:Content>
