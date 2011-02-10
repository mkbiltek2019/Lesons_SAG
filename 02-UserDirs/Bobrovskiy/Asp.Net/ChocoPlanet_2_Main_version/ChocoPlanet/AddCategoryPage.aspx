<%@ Page Title="" Language="C#" 
         MasterPageFile="~/Site.Master" 
         AutoEventWireup="true"
         CodeBehind="AddCategoryPage.aspx.cs" 
         Inherits="ChocoPlanet.AddCategotyPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <p><asp:Label runat="server" Text="Назва категорії: "/>
           <asp:TextBox runat="server" ID="tbCategoryName" OnPreRender="tbRenderText"/>
           <asp:RequiredFieldValidator runat="server"
                                        ErrorMessage="Введіть назву категорії."
                                        ControlToValidate="tbCategoryName" 
                                        Enabled="true"
                                        Visible="true"
                                        Display="Dynamic"/>
        </p>
        <p><asp:Label runat="server" Text="Опис категорії: "/>
           <asp:TextBox runat="server" ID="tbCategoryDescription" TextMode="MultiLine"/>
           <asp:RequiredFieldValidator  runat="server"
                                        ErrorMessage="Введіть опис категорії."
                                        ControlToValidate="tbCategoryDescription" 
                                        Enabled="true"
                                        Visible="true"
                                        Display="Dynamic"/>
        </p>
        <p><asp:Button runat="server" 
                       ID="btnAddCategory" 
                       OnClick="btnAddCategory_Click" 
                       Text="Додати нову категорію" /> </p>
    </div>
</asp:Content>
