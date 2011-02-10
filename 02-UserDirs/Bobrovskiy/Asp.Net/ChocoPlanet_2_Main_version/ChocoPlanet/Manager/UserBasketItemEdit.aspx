<%@ Page Title="" Language="C#" 
    MasterPageFile="~/Site.Master" 
    AutoEventWireup="true"
    CodeBehind="UserBasketItemEdit.aspx.cs" 
    Inherits="ChocoPlanet.Manager.UserBasketItemEdit" %>

<asp:Content ID="Content1" 
    ContentPlaceHolderID="HeadContent" 
    runat="server">
</asp:Content>

<asp:Content ID="Content2" 
    ContentPlaceHolderID="MainContent" 
    runat="server">

    <div>
        <p>
        <asp:Label runat="server" ID="label">Оберіть статус замовлення :</asp:Label>
        <asp:DropDownList 
                EnableViewState="False"
                CssClass="header" 
                runat="server"             
                DataSourceID="odsOrderStateList"          
                ID="ddlOrderState">   
        </asp:DropDownList>
        </p>

        <p><asp:Label ID="Label1" runat="server" Text="Дата передачі в курєрську службу: "/>
           <asp:TextBox runat="server" ID="tbCurierDate" OnPreRender="tbRenderText"/>
           <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                        ErrorMessage="Введіть дату."
                                        ControlToValidate="tbCurierDate" 
                                        Enabled="true"
                                        Visible="true"
                                        Display="Dynamic"/>
        </p>

        <p><asp:Label ID="Label2" runat="server" Text="Дата доставки: "/>
           <asp:TextBox runat="server" ID="tbDeliveryDate" TextMode="SingleLine"/>
           <asp:RequiredFieldValidator ID="RequiredFieldValidator2"  runat="server"
                                        ErrorMessage="Введіть дату."
                                        ControlToValidate="tbDeliveryDate" 
                                        Enabled="true"
                                        Visible="true"
                                        Display="Dynamic"/>
        </p>
        <p><asp:Button runat="server" 
                       ID="btnSaveChanges" 
                       OnClick="btnSaveChanges_Click" 
                       Text="Зберегти зміни" /> </p>
    </div>

    <asp:ObjectDataSource 
                runat="server" 
                ID="odsOrderStateList"
                TypeName="ChocoPlanet.Business.Product_Category.OrderStateController"
                SelectMethod="GetOrderStateList"> 
    </asp:ObjectDataSource>

</asp:Content>
