<%@ Page Title="" Language="C#" 
         MasterPageFile="~/Site.Master" 
         AutoEventWireup="true"
         CodeBehind="AddCategoryPage.aspx.cs" 
         Inherits="ChocoPlanet.AddCategotyPage" %>
<%@Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" tagPrefix="ajax" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <p><asp:Label runat="server" Text="Назва категорії: "/>
           <asp:TextBox runat="server" ID="tbCategoryName" OnPreRender="tbRenderText"/>
           <asp:RequiredFieldValidator runat="server" ID="rfvCategoryName"
                                        ErrorMessage="Введіть назву категорії."
                                        ControlToValidate="tbCategoryName" 
                                        Enabled="true"
                                        Visible="true"
                                        Display="Dynamic"/>
           <ajax:ValidatorCalloutExtender ID="vceCategoryName" runat="server" TargetControlID="rfvCategoryName" />

           <ajax:TextBoxWatermarkExtender ID="tbweCategoryName" runat="server" 
                TargetControlID="tbCategoryName" 
                WatermarkText="Введіть назву категорії" />
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
