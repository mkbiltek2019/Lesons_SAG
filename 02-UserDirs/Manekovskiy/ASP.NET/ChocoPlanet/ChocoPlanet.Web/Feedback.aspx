<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Feedback.aspx.cs" Inherits="ChocoPlanet.Feedback" %>
<asp:Content runat="server" ID="Main" ContentPlaceHolderID="MainContent">
    <script type="text/javascript" language="javascript">
        function Validate_Email(sender, eventargs) {
            //debugger;
            if (eventargs.Value == "")
                eventargs.IsValid = false;
            else
                eventargs.IsValid = true;
        }
    </script>
    <div>
        <asp:ValidationSummary runat="server" ID="vsFeedback"
            DisplayMode="BulletList"
            ShowMessageBox="false"
            ShowSummary="true" 
            ValidationGroup="EmailGroup"/>
    </div>
    <div>
        <asp:Label runat="server" Text="Адрес эл. почты:" />
        <asp:TextBox runat="server" ID="tbEmail" ></asp:TextBox>
        <asp:RequiredFieldValidator 
            ErrorMessage="Адрес эл. почты обязателен для заполнений" 
            ControlToValidate="tbEmail" runat="server"
            Enabled="true"
            Visible="false"
            Display="None" 
            ValidationGroup="EmailGroup" />

        <%-- регулярное выражение добавляли через дизайнер --%>
        <%--<asp:RegularExpressionValidator ErrorMessage="Неверный формат эл. почты" ControlToValidate="tbEmail"
            runat="server" ID="revEmail" 
            EnableClientScript="false"
            ValidationExpression="^((?&gt;[a-zA-Z\d!#$%&amp;'*+\-/=?^_`{|}~]+\x20*|&quot;((?=[\x01-\x7f])[^&quot;\\]|\\[\x01-\x7f])*&quot;\x20*)*(?&lt;angle&gt;&lt;))?((?!\.)(?&gt;\.?[a-zA-Z\d!#$%&amp;'*+\-/=?^_`{|}~]+)+|&quot;((?=[\x01-\x7f])[^&quot;\\]|\\[\x01-\x7f])*&quot;)@(((?!-)[a-zA-Z\d\-]+(?&lt;!-)\.)+[a-zA-Z]{2,}|\[(((?(?&lt;!\[)\.)(25[0-5]|2[0-4]\d|[01]?\d?\d)){4}|[a-zA-Z\d\-]*[a-zA-Z\d]:((?=[\x01-\x7f])[^\\\[\]]|\\[\x01-\x7f])+)\])(?(angle)&gt;)$" />--%>
        
        <%--ClientValidationFunction="Validate_Email"--%>
        <asp:CustomValidator runat="server" ID="cvEmail"
            OnServerValidate="cvEmail_Validate"
            ErrorMessage="Неверный формат эл. почты"
            Display="None"
            ValidationGroup="EmailGroup" />
    </div>
    <div>
        <asp:Label runat="server" Text="Ваши пожелания:" /><br />
        <asp:TextBox runat="server" ID="tbText" TextMode="MultiLine"></asp:TextBox>
        <asp:RequiredFieldValidator runat="server" 
            ErrorMessage="Текст не должен быть пустым"
            ControlToValidate="tbText" 
            Display="None" 
            ValidationGroup="TextGroup" />

        <asp:Label runat="server" ID="lblThanks" Visible="false" Text="Спасибо что уделили время оставить такой замечательный фидбек!" />
    </div>

    <div>
        <asp:ValidationSummary runat="server"
            DisplayMode="List"
            ShowMessageBox="false"
            ShowSummary="true" 
            ValidationGroup="TextGroup"/>
    </div>

    <div>
        <asp:Button runat="server" ID="btnSubmitFeedback" 
            Text="Отправить мыло"
            OnClick="btnSubmitFeedback_Click"
            ValidationGroup="EmailGroup" />
        <asp:Button runat="server" ID="Button1" 
            Text="Отправить текст"
            OnClick="btnSubmitFeedback_Click"
            ValidationGroup="TextGroup" />
    </div>

    
</asp:Content>
