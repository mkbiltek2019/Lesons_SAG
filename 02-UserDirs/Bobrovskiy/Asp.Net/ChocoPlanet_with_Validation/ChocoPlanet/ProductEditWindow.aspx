<%@ Page Title="" 
         Language="C#" 
         MasterPageFile="~/Site.Master" 
         AutoEventWireup="true" 
         CodeBehind="ProductEditWindow.aspx.cs" 
         Inherits="ChocoPlanet.ProductEditWindow" %>
<asp:Content ID="Content1" 
             ContentPlaceHolderID="HeadContent" 
             runat="server">
</asp:Content>

<asp:Content ID="Content2" 
             ContentPlaceHolderID="MainContent"
             runat="server">
    <div>
        <table border="1" >

            <tr>
                <td><div>
                    <asp:Label runat="server" ID="lName">Назва</asp:Label>
                    </div>
                </td>

                <td colspan="2"><div>
                    <asp:TextBox runat="server" ID="tbName" MaxLength="200"></asp:TextBox>
                    </div>
                </td>                
            </tr>            
                
            <tr>
                <td><div>
                    <asp:Label runat="server" ID="lDescription">Опис</asp:Label>
                    </div>
                </td>

                <td colspan="2"><div>
                    <asp:TextBox runat="server" ID="tbDescription" MaxLength="1000"></asp:TextBox>
                    </div>
                </td>   
               
            </tr>
              
            <tr>
                <td><div>
                    <asp:Label runat="server" ID="lPrice">Ціна</asp:Label>
                    </div>
                </td>

                <td colspan="2"><div>
                    <asp:TextBox runat="server" ID="tbPrice" MaxLength="1000"></asp:TextBox>
                    </div>
                </td> 
            </tr>

            <tr>
                <td colspan="2"><div>
                        <asp:Label runat="server" ID="lPhoto">Фото</asp:Label>
                    </div>
                    <div>
                        <asp:RadioButton 
                                runat="server" 
                                ID="rbLoad" 
                                GroupName="PhotoSelectOrLoad" 
                                Text="Завантажити нове фото"/>
                    </div>
                    <div>
                     <asp:RadioButton 
                                runat="server" 
                                ID="rbSelect" 
                                GroupName="PhotoSelectOrLoad" 
                                Text="Обрати з існуючих"/>
                    </div>
                </td>

                <td colspan="3" class="normal">
                    <div>
                        <asp:Label runat="server" ID="Label1">Завантажені фото</asp:Label>
                    </div>
                  
	                    <div class="demo">	
                       
                            <asp:RadioButtonList 
                                CssClass="ui-widget-content" 
                                ID="rblImages" 
                                runat="server">
                            </asp:RadioButtonList>
                     
                        </div>

                </td>
                
            </tr>

            <tr>
                <td colspan="2">
                    <div>
                        <asp:Button 
                            runat="server" 
                            ID="btnSave" 
                            Text="Зберегти"/>
                        <asp:Button 
                            runat="server" 
                            ID="btnCancel" 
                            Text="Відмінити"/>
                    </div>                   
                </td>
            </tr>

        </table>
    </div>

</asp:Content>
