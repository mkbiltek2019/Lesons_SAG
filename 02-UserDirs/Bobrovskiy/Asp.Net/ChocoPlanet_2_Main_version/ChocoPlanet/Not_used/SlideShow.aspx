<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" 
CodeBehind="SlideShow.aspx.cs" Inherits="ChocoPlanet.SlideShow" %>

<%@ Register 
    Assembly="AjaxControlToolkit" 
    Namespace="AjaxControlToolkit" 
    TagPrefix="ajaxToolkit" %>

<%--<%@ Register assembly="CustomExtenders" namespace="CustomExtenders" tagprefix="cc1" %>--%>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
<%--
    Code placed here will be in <head></head> section in Site.Master Page
--%>
    <link href="../Styles/jquery-ui.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/custom-theme/jquery.ui.button.css" rel="stylesheet" type="text/css" />
	<link href="../Styles/custom-theme/jquery.ui.dialog.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/custom-theme/jquery.ui.all.css" rel="stylesheet" type="text/css" />

    <script src="../Scripts/jquery-1.4.4.js" type="text/javascript"></script>	
	<script src="../Scripts/ui/jquery.ui.core.js" type="text/javascript"></script>
	<script src="../Scripts/ui/jquery.effects.core.js" type="text/javascript"></script>	
 	<script src="../Scripts/ui/jquery.ui.widget.js" type="text/javascript"></script>
	<script src="../Scripts/ui/jquery.ui.mouse.js" type="text/javascript"></script>
	<script src="../Scripts/ui/jquery.ui.draggable.js" type="text/javascript"></script>
	<script src="../Scripts/ui/jquery.ui.position.js" type="text/javascript"></script>
	<script src="../Scripts/ui/jquery.ui.resizable.js" type="text/javascript"></script>
	<script src="../Scripts/ui/jquery.ui.dialog.js" type="text/javascript"></script>
	<script src="../Scripts/ui/jquery.ui.button.js" type="text/javascript"></script>

     <script type="text/javascript" language="javascript">
         $(function () {
             $(".slide button:first").button({
                 text:true
             }).next().button({
                 text:true
             }).next().button({
                text:true
             });

             $("#dialog").dialog({ resizable: false, position: 'top', modal: false });
         });
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
 
 <script runat="Server" type="text/C#">
     
        [System.Web.Services.WebMethod]
        [System.Web.Script.Services.ScriptMethod]
        public static AjaxControlToolkit.Slide[] GetSlides()
        {
            return new AjaxControlToolkit.Slide[] { 
            new AjaxControlToolkit.Slide("images/Brick/thumbs/svDark.jpg", "", "Чорний шоколад"),
            new AjaxControlToolkit.Slide("images/Brick/thumbs/svMolochnuj.jpg", "", "Молочний шоколад"),
            new AjaxControlToolkit.Slide("images/Brick/thumbs/svSpecDarkWithNuts.jpg", "", "Чорний шоколад з горіхами")
           };
        }
    </script>   


   <div id="dialog" title="asdfasdf">
       
   <div>
      <ajaxToolkit:ToolkitScriptManager ID="ScriptManager1"  EnablePartialRendering="true" runat="server" />	
     
        <div style="text-align:center">   

            <asp:Image ID="Image1" runat="server" 
                Height="70"
                Width="70"
                Style="border: 0px; " 
                ImageUrl="images/Brick/thumbs/svDark.jpg"
                AlternateText="Чорний шоколад" />
            
			<div class="slide">
             <button id="prevButton" >1</button>
             <button id="playButton" >2</button>
             <button id="nextButton" >3</button>             
            </div>
			
		    <%--<asp:Button runat="server" ID="prevButton" Text="Prev"  />
            <asp:Button runat="server" ID="playButton" Text="Play"  />
            <asp:Button runat="server" ID="nextButton" Text="Next" />--%>

            <ajaxToolkit:SlideShowExtender ID="slideshowextend1" runat="server" 
                PlayInterval="2000"
                TargetControlID="Image1"                
                AutoPlay="true"          
                SlideShowServiceMethod="GetSlides"       
                NextButtonID="nextButton"               
                PreviousButtonID="prevButton" 
                PlayButtonID="playButton" 
                Loop="true" />        
        </div>		
    </div> 
   </div>
	
</asp:Content>
