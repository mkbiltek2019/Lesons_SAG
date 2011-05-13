<%@ Control Language="C#" AutoEventWireup="true" CodeFile="DefaultMenu.ascx.cs" Inherits="Menu" %>
<ul class="art-menu">
    <li><a href="Default.aspx" class=" active"><span class="l"></span><span class="r"></span><span class="t">Главная</span></a></li>
    <li><a href="Products.aspx"><span class="l"></span><span class="r"></span><span class="t">Продукция</span></a>
        <ul>
		    <li><a href="Chocolate.aspx">Шоколад</a></li>
		    <li><a href="ChocolateSets.aspx">Шоколадные наборы</a></li>
		    <li><a href="ChocolateLogo.aspx">Шоколад с логотипом</a></li>
	    </ul>
    </li>
    <li><a href="About.aspx"><span class="l"></span><span class="r"></span><span class="t">О компании</span></a></li>
    <li><a href="Contacts.aspx"><span class="l"></span><span class="r"></span><span class="t">Контакты</span></a></li>
</ul>
