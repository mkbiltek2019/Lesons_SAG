<%@ Page Title="" 
    Language="C#" 
    MasterPageFile="~/Site.Master"
    AutoEventWireup="true" 
    CodeBehind="History.aspx.cs" 
    Inherits="ChocoPlanet.History" %>

<%@ Register assembly="CustomExtenders" 
             namespace="CustomExtenders" 
             tagprefix="cc1" %>

<%@ Register 
    Assembly="AjaxControlToolkit" 
    Namespace="AjaxControlToolkit" 
    TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

 <ajaxToolkit:ToolkitScriptManager ID="ScriptManager2"  EnablePartialRendering="true" runat="server" />	
       <cc1:DisabledButtonExtender 
                    ID="TextBox1_DisabledButtonExtender" 
                    runat="server" 
                    DisabledText="Save" 
                    Enabled="True" 
                    TargetButtonID="btnSave" 
                    TargetControlID="tbText">
      </cc1:DisabledButtonExtender>
  <div>
                <asp:TextBox ID="tbText" runat="server" TextMode="SingleLine" Text=""></asp:TextBox> 
             <%-- <button id="btnSave" runat="server"> sdfsdf</button>--%>
                <asp:Button ID="btnSave" runat="server" Text="Save*" />
    </div>

        <h2>
            Chocolate history.
        </h2>
        <p style="text-align:justify">
            <div color="#800000" face="Arial, Helvetica, sans-serif" ><b>2000 BC, Amazon:</b></div>
            <div face="Arial, Helvetica, sans-serif">Cocoa, from which chocolate is created,
                is said to have originated in the Amazon at least 4,000 years ago. 
            </div>
        </p>
        <p style="text-align:justify">
            <div color="#800000" face="Arial, Helvetica, sans-serif" ><b>Sixth Century AD :</b></div>
            <div face="Arial, Helvetica, sans-serif"> Chocolate, derived from the seed
                    of the cocoa tree, was used by the Maya Culture, as early as the Sixth Century AD.
                    Maya called the cocoa tree <i>cacahuaquchtl… </i>"tree," and the word chocolate
                    comes from the Maya word <i>xocoatl</i> which means bitter water. 
            </div>
        </p>
        <p style="text-align:justify">
            <div color="#800000" face="Arial, Helvetica, sans-serif"><b>300 AD, Maya Culture:</b></div>            
            <div face="Arial, Helvetica, sans-serif">
                    To the Mayas, cocoa pods symbolized life and fertility... nothing could be more
                    important! Stones from their palaces and temples revealed many carved pictures of
                    cocoa pods. 
           </div>
        </p>
        <p style="text-align:justify">
            <div color="#800000" face="Arial, Helvetica, sans-serif"><b>600 AD, Maya Culture:</b></div>
            <div face="Arial, Helvetica, sans-serif"> Moving from Central America to the northern
                portions of South America, the Mayan territory stretched from the Yucatán Peninsula
                to the Pacific Coast of Guatemala. In the Yucatán, the Mayas cultivated the earliest
                know cocoa plantations. The cocoa pod was often represented in religious rituals,
                and the texts their literature refer to cocoa as the god’s food
            </div>
        </p>

</asp:Content>
