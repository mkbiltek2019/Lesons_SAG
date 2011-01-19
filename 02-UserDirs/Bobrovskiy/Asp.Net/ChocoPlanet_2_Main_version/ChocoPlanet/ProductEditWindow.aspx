<%@ Page Title="" 
         Language="C#" 
         MasterPageFile="~/Site.Master" 
         AutoEventWireup="true" 
         CodeBehind="ProductEditWindow.aspx.cs" 
         Inherits="ChocoPlanet.ProductEditWindow" %>
<%@Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" tagPrefix="ajax" %>

<asp:Content ID="Content1" 
             ContentPlaceHolderID="HeadContent" 
             runat="server">
</asp:Content>

<asp:Content ID="Content2" 
             ContentPlaceHolderID="MainContent"
             runat="server">

    <asp:ObjectDataSource 
            runat="server" 
            ID="odsCategoryList"
            TypeName="ChocoPlanet.Business.CategoryController"
            SelectMethod="GetCategoryList"> 
    </asp:ObjectDataSource>

    <h3>
        <asp:Label runat="server" ID="Label3">Форма для додавання нових продуктів.</asp:Label>
    </h3>
    <fieldset>
        <p><asp:Label runat="server" ID="lName">Назва Продукту:</asp:Label>
           <asp:TextBox runat="server" ID="tbName" TextMode="SingleLine"></asp:TextBox>
        </p> 
                 
        <p><asp:Label runat="server" ID="lDescription">Опис:</asp:Label>
           <asp:TextBox runat="server" ID="tbDescription" TextMode="MultiLine"></asp:TextBox>
        </p> 
                
        <p><asp:Label runat="server" ID="lPrice">Ціна:</asp:Label>
           <asp:TextBox runat="server" ID="tbPrice" TextMode="SingleLine"></asp:TextBox>

           <ajax:FilteredTextBoxExtender runat="server" ID="ftbePrice" 
                TargetControlID="tbPrice"
                FilterType="Numbers" 
                ValidChars="+-=/*()." />
        </p>

        <p><asp:Label ID="Label2" runat="server" >Дата розміщення:</asp:Label>
            <asp:DropDownList 
                EnableViewState="False"
                AutoPostBack="True"                              
                runat="server"             
                DataSourceID="odsCategoryList"          
                ID="ddlProductCategory">   
            </asp:DropDownList>
        </p>

        <p><asp:Label runat="server" >Дата розміщення:</asp:Label>
           <asp:TextBox runat="server" ID="tbPlacementDate" TextMode="SingleLine"></asp:TextBox>
        </p>        

        <p><asp:Label ID="Label1" runat="server" >Головний малюнок:</asp:Label>           
           <asp:FileUpload ID="fuImage" runat="server" ToolTip="Upload" />
           <asp:Button runat="server" Text="Завантажити" OnClick="btnLoad_Click"/> 
        </p>

        <p>
          <asp:Image runat="server" ID="imgMainImage"  Width="300" Height="300" /> 
        </p>

        <p>
            <asp:Label runat="server" >Зменшений малюнок:</asp:Label>
        </p>

        <p>
           <asp:Image runat="server" ID="imgThumbImage" />
        </p>

        <p><asp:Button 
                runat="server" 
                ID="btnSave" 
                OnClick="btnSave_Click"
                Text="Зберегти"/>  
        </p>

    </fieldset>  
</asp:Content>
