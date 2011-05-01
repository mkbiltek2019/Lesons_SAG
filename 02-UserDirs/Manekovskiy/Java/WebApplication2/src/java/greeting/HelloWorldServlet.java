package greeting;

/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */


import java.io.IOException;
import java.io.PrintWriter;
import javax.servlet.ServletException;
import javax.servlet.http.*;
import org.apache.catalina.Session;

/**
 *
 * @author rasik
 */
public class HelloWorldServlet extends HttpServlet {
    public static final String LASTBGCOLOR_PARAMETER_NAME = "lastBgColor";
    public static final String TEXTCOLOR_COOKIE_NAME = "textcolor";
   int requestCounter = 0;
    /** 
     * Processes requests for both HTTP <code>GET</code> and <code>POST</code> methods.
     * @param request servlet request
     * @param response servlet response
     * @throws ServletException if a servlet-specific error occurs
     * @throws IOException if an I/O error occurs
     */
    protected void processRequest(HttpServletRequest request, HttpServletResponse response)
    throws ServletException, IOException {
        response.setContentType("text/html;charset=UTF-8");
        String color = request.getParameter("bgcolor");

        HttpSession session = request.getSession(true);
        if(color != null)
            session.setAttribute(LASTBGCOLOR_PARAMETER_NAME, color);
        else
            color = (String)session.getAttribute(LASTBGCOLOR_PARAMETER_NAME);

        String textcolor = request.getParameter(TEXTCOLOR_COOKIE_NAME);
        Cookie[] cookies = request.getCookies();
        if(cookies.length == 0) {
            textcolor = setDefaultTextColor(textcolor, response);
        }
        else
        {
            for(int i = 0; i < cookies.length; i++)
            {
                if(cookies[i].getName().equals(TEXTCOLOR_COOKIE_NAME))
                    textcolor = cookies[i].getValue();
            }
            textcolor = setDefaultTextColor(textcolor, response);
        }

        PrintWriter out = response.getWriter();
        try {
            requestCounter++;
            out.println("<html>");
            out.println("<head>");
            out.println("<title>Hello world!</title>");
            out.println("</head>");
            if(color != null)
                out.println("<body style=\"background-color: #" + color + "\">");
            else
                out.println("<body>");
            
            out.println("<body style=\"background-color: #" + color + "\">");
            out.println("<h1>Hello world from " + request.getContextPath() + "</h1>");
            out.println("<h2> Request #: " + requestCounter + "</h2>");
            out.println("<h3> bgcolor : " + color + "</h3>");
            out.println("<h3> textcolor: " + textcolor + "</h3>");
            out.println("</body>");
            out.println("</html>");
        } finally { 
            out.close();
        }
    }

    public String setDefaultTextColor(String textcolor, HttpServletResponse response) {
        if (textcolor == null) {
            textcolor = "FFFFFF";
        }
        Cookie newCookie = new Cookie( TEXTCOLOR_COOKIE_NAME, textcolor);
        newCookie.setMaxAge(60);
        response.addCookie(newCookie);
        return textcolor;
    }

    // <editor-fold defaultstate="collapsed" desc="HttpServlet methods. Click on the + sign on the left to edit the code.">
    /** 
     * Handles the HTTP <code>GET</code> method.
     * @param request servlet request
     * @param response servlet response
     * @throws ServletException if a servlet-specific error occurs
     * @throws IOException if an I/O error occurs
     */
    @Override
    protected void doGet(HttpServletRequest request, HttpServletResponse response)
    throws ServletException, IOException {
        processRequest(request, response);
    } 

    /** 
     * Handles the HTTP <code>POST</code> method.
     * @param request servlet request
     * @param response servlet response
     * @throws ServletException if a servlet-specific error occurs
     * @throws IOException if an I/O error occurs
     */
    @Override
    protected void doPost(HttpServletRequest request, HttpServletResponse response)
    throws ServletException, IOException {
        processRequest(request, response);
    }

    /** 
     * Returns a short description of the servlet.
     * @return a String containing servlet description
     */
    @Override
    public String getServletInfo() {
        return "This is our first servlet!!";
    }// </editor-fold>

}
