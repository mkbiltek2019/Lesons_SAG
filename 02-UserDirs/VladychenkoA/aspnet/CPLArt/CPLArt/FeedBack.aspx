<%@ Page Title="" Language="C#" MasterPageFile="~/design/MasterPage.master" AutoEventWireup="true"
    CodeBehind="FeedBack.aspx.cs" Inherits="CPLArt.FeedBack" %>

<%@ Register TagPrefix="artisteer" Namespace="Artisteer" %>
<%@ Register TagPrefix="art" TagName="DefaultMenu" Src="DefaultMenu.ascx" %>
<%@ Register TagPrefix="art" TagName="DefaultHeader" Src="DefaultHeader.ascx" %>
<%@ Register TagPrefix="art" TagName="DefaultSidebar1" Src="DefaultSidebar1.ascx" %>
<asp:Content ID="PageTitle" ContentPlaceHolderID="TitleContentPlaceHolder" runat="Server">
    ChocoPlanet - Оставить отзыв
</asp:Content>
<asp:Content ID="HeaderContent" ContentPlaceHolderID="HeaderContentPlaceHolder" runat="Server">
    <art:DefaultHeader ID="DefaultHeader" runat="server" />
</asp:Content>
<asp:Content ID="MenuContent" ContentPlaceHolderID="MenuContentPlaceHolder" runat="Server">
    <art:DefaultMenu ID="DefaultMenuContent" runat="server" />
</asp:Content>
<asp:Content ID="SideBar1" ContentPlaceHolderID="Sidebar1ContentPlaceHolder" runat="Server">
    <art:DefaultSidebar1 ID="DefaultSidebar1Content" runat="server" />
</asp:Content>
<asp:Content ID="SheetContent" ContentPlaceHolderID="SheetContentPlaceHolder" runat="Server">
    <artisteer:Article ID="Article1" Caption="Оставить отзыв о компании ChocoPlanet!"
        runat="server">
        <ContentTemplate>
            <div>
                <h5>
                    Обраная связь</h5>
            </div>
            <%--<script type="text/javascript" language="javascript">
                function Validate_Email(sender, eventargs) {
                    //debugger;
                    if (eventargs.Value == "")
                        eventargs.IsValid = false;
                    else
                        eventargs.IsValid = true;
                }
                </script>--%>
            <div>
                <asp:Label ID="lbName" runat="server" Text="Ваше имя:     "></asp:Label>
                <asp:TextBox ID="tbName" runat="server" Width="240px" ToolTip="Введите Ваше имя"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ErrorMessage="Поле Имя должно быть заполнено.<br />"
                    ControlToValidate="tbName" runat="server" Display="None" ValidationGroup="NameGroup" Text="*"></asp:RequiredFieldValidator><br />
            </div>
            <br />
            <div>
                <asp:Label ID="lbEmail" runat="server" Text="Ваш Email:     "></asp:Label>
                <asp:TextBox ID="tbEmail" runat="server" Width="240px" ToolTip="Введите Ваш Email"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvEmail" ErrorMessage="Поле Email должно быть заполнено.<br />"
                    ControlToValidate="tbEmail" runat="server" Display="None" ValidationGroup="NameGroup" Text="*"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator runat="server" ID="revEmail" ValidationGroup="NameGroup"
                    Text="*" ErrorMessage="Не корректный Email" ControlToValidate="tbEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
            </div>
            <br />
            <div>
                <asp:Label ID="Label1" runat="server" Text="Ваши пожелания:" /><br />
                <asp:TextBox runat="server" ID="tbText" TextMode="MultiLine" Width="300" Height="150"
                    ToolTip="Введите текст сообщения"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Текст не должен быть пустым"
                    ControlToValidate="tbText" Display="None" ValidationGroup="NameGroup" Text="*"></asp:RequiredFieldValidator>
            </div>
            <br />
            <div>
                <asp:ValidationSummary runat="server" ID="vsName" DisplayMode="List" ShowMessageBox="false"
                    ShowSummary="true" ValidationGroup="NameGroup" />
            </div>
            <div>
                <asp:Button runat="server" ID="btnSubmit" Text="Отправить сообщение" OnClick="btnSubmit_Click"
                    ValidationGroup="NameGroup" ToolTip="Нажмите, чтобы отправить сообщение" />
            </div>
            <br />
            <div>
                <asp:Label runat="server" ID="lblThanks" Visible="false" Text="Спасибо за то, что оставили свой отзыв!" />
            </div>
        </ContentTemplate>
    </artisteer:Article>
</asp:Content>
