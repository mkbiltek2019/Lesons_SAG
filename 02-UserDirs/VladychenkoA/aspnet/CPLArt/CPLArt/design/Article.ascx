<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Article.ascx.cs" Inherits="design_WebUserControlArticle" %>

<div class="art-post">
    <div class="art-post-body">
<div class="art-post-inner art-article">
<h2 class="art-postheader">
    <img src="images/postheadericon.png" width="22" height="22" alt="postheadericon" />

      <asp:placeholder runat="server" id="HeaderPlaceholder"/>

</h2>
<div class="art-postcontent">
    <!-- article-content -->

      <asp:placeholder runat="server" id="ContentPlaceholder"/>

    <!-- /article-content -->
</div>
<div class="cleared"></div>

</div>

		<div class="cleared"></div>
    </div>
</div>

