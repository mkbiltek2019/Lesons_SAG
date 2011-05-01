<%-- 
    Document   : hello
    Created on : 30 квіт 2011, 11:53:25
    Author     : rasik
--%>

<%@page import="java.util.Date"%>
<%@page contentType="text/html" pageEncoding="UTF-8"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN"
   "http://www.w3.org/TR/html4/loose.dtd">

<html>
    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
        <title>JSP Page</title>

        <script type="text/javascript">
        function submitform()
        {
          document.myform.submit();
        }
        </script>
    </head>
    <body>
        <jsp:useBean id="gallery" class="gallery.GalleryController" scope="request" />
        <jsp:useBean id="sessionEnabledGallery" class="gallery.GalleryController" scope="session" />


        <h1>Hello World!</h1>
        <% String[] images = gallery.getImages(); %>
        <% for(int i = 0; i < images.length; i++) { %>
            <img src="img/<%= images[i] %>" />
        <% } %>

        <br/>
        <img src="img/<%= sessionEnabledGallery.getNextImage() %>" />

        <br />
        <% String imageIndexString = request.getParameter("imageIndex"); %>
        <% int imageIndexToShow = imageIndexString == null ? 0 : Integer.parseInt(imageIndexString); %>
        <img src="img/<%= sessionEnabledGallery.getImages()[imageIndexToShow] %>" />

        <form name="myform" action="<%= request.getContextPath() %>">
            <select name='imageIndex'>
                <option value="0">Image 0</option>
                <option value="1">Image 1</option>
                <option value="2">Image 2</option>
            </select>
            <a href="javascript: submitform()">next image!</a>
        </form>
    </body>
</html>
