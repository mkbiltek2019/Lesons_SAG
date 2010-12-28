<%@ Page Title="" Language="C#" 
         MasterPageFile="~/Site.Master" 
         AutoEventWireup="true"
         CodeBehind="RegistrationWebForm.aspx.cs" 
         Inherits="ChocoPlanet.RegistrationWebForm" %>
<%--<%@ Register TagPrefix="recaptcha" 
             Namespace="Recaptcha" 
             Assembly="Recaptcha" %>--%>

<asp:Content ID="Content1" 
             ContentPlaceHolderID="HeadContent" 
             runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div>
        <div id="registrationInnerFrame">
            <fieldset>
                <p>
                    <asp:Label runat="server" ID="lName" Text="Ім'я:" />                    
                    <asp:TextBox runat="server" ID="tbName" TextMode="SingleLine"/>                 
                    <asp:RequiredFieldValidator runat="server"
                                                ErrorMessage="Введіть ім'я."
                                                ControlToValidate="tbName" 
                                                Enabled="true"
                                                Visible="true"
                                                Display="Dynamic"/>
                    <asp:CustomValidator runat="server"   
                                         ControlToValidate="tbName"  
                                         Text='<%# Eval(tbName.Text) %>'                                                                           
                                         OnServerValidate="textBox_Validate"                                        
                                         Display="Dynamic"/>                     
                    <asp:Label runat="server" Text="Валерій" />                   
                </p>

                <p>
                    <asp:Label runat="server" ID="lThirdName" Text="По батькові:" />
                    <asp:TextBox runat="server" ID="tbThirdName" TextMode="SingleLine" />
                    <asp:RequiredFieldValidator runat="server" 
                                                ErrorMessage="Введіть прізвище."
                                                ControlToValidate="tbThirdName" 
                                                Enabled="true"
                                                Visible="true"
                                                Display="Dynamic"/>
                    <asp:CustomValidator runat="server"    
                                         ControlToValidate="tbThirdName"  
                                         Text='<%# tbThirdName.Text %>'                                                                          
                                         OnServerValidate="textBox_Validate"                                        
                                         Display="Dynamic"/> 
                     <asp:Label runat="server" Text="Володимирович" />
                </p>

                <p>
                    <asp:Label runat="server" ID="lSurname"  Text="Прізвище:" />
                    <asp:TextBox runat="server" ID="tbSurname" TextMode="SingleLine"/>
                    <asp:RequiredFieldValidator runat="server" 
                                                ErrorMessage="Введіть прізвище."
                                                ControlToValidate="tbSurname" 
                                                Enabled="true"
                                                Visible="true"
                                                Display="Dynamic"/>
                    <asp:CustomValidator runat="server"  
                                         ControlToValidate="tbSurname"  
                                         Text='<%# tbSurname.Text %>'                                                                                                                   
                                         OnServerValidate="textBox_Validate"                                        
                                         Display="Dynamic"/> 
                     <asp:Label runat="server" Text="Бобровський" />
                </p>

                <p>
                    <asp:Label runat="server" ID="lLogin"  Text="Логін:" />
                    <asp:TextBox runat="server" ID="tbLogin" TextMode="SingleLine" />
                    <asp:RequiredFieldValidator runat="server" 
                                                ErrorMessage="Введіть по батькові."
                                                ControlToValidate="tbLogin" 
                                                Enabled="true"
                                                Visible="true"
                                                Display="Dynamic"/>
                      <asp:CustomValidator runat="server"                                            
                                         ControlToValidate="tbLogin"  
                                         Text='<%# tbLogin.Text %>'                                                                              
                                         OnServerValidate="textBox_Validate"                                        
                                         Display="Dynamic"/> 
                     <asp:Label runat="server" Text="Some_Login123" />
                </p>

                <p>
                    <asp:Label runat="server" ID="lPassword"  Text="Пароль:" />
                    <asp:TextBox runat="server" ID="tbPassword" TextMode="Password" />
                    <asp:RequiredFieldValidator runat="server" 
                                                ErrorMessage="Введіть пароль."
                                                ControlToValidate="tbPassword" 
                                                Enabled="true"
                                                Visible="true"
                                                Display="Dynamic"/>
                    <asp:CustomValidator runat="server"     
                                         ControlToValidate="tbPassword"  
                                         Text='<%# tbPassword.Text %>'                                                                        
                                         OnServerValidate="textBox_Validate"                                          
                                         Display="Dynamic"/>
                    <asp:Label runat="server" Text="Some@_PAsswd123#" />
                </p>

                <p>
                    <asp:Label runat="server" ID="lPasswordConfirmation"  Text="Підтвердження паролю:" />
                    <asp:TextBox runat="server" ID="tbPasswordConfirmation" TextMode="Password" />
                    <asp:RequiredFieldValidator runat="server" 
                                                ErrorMessage="Введіть підтвердження паролю."
                                                ControlToValidate="tbPasswordConfirmation" 
                                                Enabled="true"
                                                Visible="true"
                                                Display="Dynamic"/>
                    <asp:CustomValidator runat="server" 
                                         ControlToValidate="tbPasswordConfirmation"  
                                         Text='<%# tbPasswordConfirmation.Text %>'                                                                              
                                         OnServerValidate="userData_Validate"                                      
                                         Display="Dynamic"/>
                    <asp:Label runat="server" Text="Some_PAsswd123" />
                </p>

                <p>
                    <asp:Label runat="server" ID="lEmail"  Text="Скринька:" />
                    <asp:TextBox runat="server" ID="tbEmail" TextMode="SingleLine" />
                    <asp:RequiredFieldValidator runat="server" 
                                                ErrorMessage="Введіть cкринькy."
                                                ControlToValidate="tbEmail" 
                                                Enabled="true"
                                                Visible="true"
                                                Display="Dynamic"  />
                     <asp:CustomValidator runat="server"      
                                        ControlToValidate="tbEmail"  
                                         Text='<%# tbEmail.Text %>'                                                                       
                                         OnServerValidate="textBox_Validate"                                         
                                         Display="Dynamic"/>  
                    <asp:Label ID="Label3" runat="server" Text="somename@gmail.com" />
                </p>

                 <p>
                    <asp:Label runat="server" ID="lPhone"  Text="Телефон:" />
                    <asp:TextBox runat="server" ID="tbPhone" TextMode="SingleLine"   />
                    <asp:RequiredFieldValidator runat="server" 
                                                ErrorMessage="Введіть Телефон."
                                                ControlToValidate="tbPhone" 
                                                Enabled="true"
                                                Visible="true"
                                                Display="Dynamic"/>
                    <asp:CustomValidator runat="server"      
                                         ControlToValidate="tbPhone"  
                                         Text='<%# tbPhone.Text %>'                                                                        
                                         OnServerValidate="textBox_Validate"                                         
                                         Display="Dynamic"/>
                    <asp:Label runat="server" Text="(097) 348 34 34" />
                </p>

                 <p>
                    <asp:HyperLink runat="server" 
                                   ID="hlRules"
                                   NavigateUrl="#" >Правила користування сайтом</asp:HyperLink>                   
                    <br/>
                    <asp:CheckBox runat="server" 
                                  ID="cbRulesConfirm"
                                  Checked="false" 
                                  Text="Погоджуюсь з правилами користування сайтом." />
                </p>

               <p>
               <%-- Capcha by google just  download: http://code.google.com/p/recaptcha/downloads/list?q=label:aspnetlib-Latest
                --%>
                  <%-- <div id="recaptcha_widget" style="display: none">
                       <div id="recaptcha_image">
                       </div>
                       <span class="recaptcha_only_if_image">Введіть слова наведені нижче:</span> 
                       <span class="recaptcha_only_if_audio">
                           Введіть число яке ви почуєте:</span>
                       <input type="text" id="recaptcha_response_field" name="recaptcha_response_field" />--%>
                       <%--<asp:Button ID="btnSubmit" runat="server" Text="Ввести" OnClick="btnSubmit_Click" />--%>
                      <%-- <div>
                           <asp:Label ID="lblResult" runat="server" /></div>
                       <div>
                           <a href="javascript:Recaptcha.reload()">Згенерувати нове зображення</a>
                       </div>
                       <div class="recaptcha_only_if_image">
                           <a href="javascript:Recaptcha.switch_type('audio')">Прослухати звукове повідомлення</a>
                        </div>
                       <div class="recaptcha_only_if_audio">
                           <a href="javascript:Recaptcha.switch_type('image')">Отримати зображення</a>
                       </div>--%>
                       <%-- Note: the custom elements apear before the RecaptchaControl --%>
                      <%-- <recaptcha:RecaptchaControl ID="recaptcha" runat="server" 
                                                   Theme="custom" CustomThemeWidget="recaptcha_widget"
                           PublicKey="6LcBAAAAAAAAAKtzVYRsIgOAAvCFge3iiMtf6hI9" 
                           PrivateKey="6LcBAAAAAAAAACQnFb_BI5tX7OxqC-C5RtROzx-S" />--%>
                      <%-- <div style="color: #C0C0C0; font-size: small;">
                           Captcha provided by 
                           <a href="http://recaptcha.net/" style="color: #C0C0C0; text-decoration: none;">reCAPTCHA</a>
                       </div>
                   </div>--%>
                </p>

                <p>
                    <asp:Button runat="server" 
                                OnClick="btnRegisterUser_Click"
                                ID="btnRegister" 
                                Text="Реєстрація" />
                </p>
            </fieldset>
        </div>
     </div>
</asp:Content>
