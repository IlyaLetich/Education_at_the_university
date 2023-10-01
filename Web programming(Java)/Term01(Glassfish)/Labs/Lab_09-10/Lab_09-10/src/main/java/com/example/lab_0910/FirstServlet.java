package com.example.lab_0910;

import jakarta.servlet.*;
import jakarta.servlet.http.*;
import jakarta.servlet.annotation.*;

import java.io.IOException;
import java.io.PrintWriter;
import java.time.LocalTime;
import java.time.format.DateTimeFormatter;
import java.util.Enumeration;

@WebServlet(name = "FirstServlet", value = "/FirstServlet")
public class FirstServlet extends HttpServlet {
    @Override
    public void doGet(HttpServletRequest request, HttpServletResponse response) throws IOException {
        WorkCookies.updateCoookies(response,request,null);
        response.setContentType("text/html");
        response.addCookie(new Cookie("count","0"));
        response.addCookie(new Cookie("date", DateTimeFormatter.ofPattern("HH:mm").format(LocalTime.now())));
        PrintWriter out = response.getWriter();
        out.println("<html><body>");
        out.println("<h1>" + "Time: "+ DateTimeFormatter.ofPattern("HH:mm").format(LocalTime.now()) + "</h1>");
        out.println(getRequestInfo(request));
        out.println("<p><b>"+"Information from header:"+"</b></p>");
        out.println(getHeaderInfo(request));
        out.println("</body></html>");
    }

    public String getRequestInfo(HttpServletRequest request) throws IOException {
        String res = "";
        res+= "<p>"+"Method:    " +  request.getMethod()+"</p>";
        res+= "<p>"+"URL:    "+  request.getRequestURL()+"</p>";
        res+= "<p>"+"Protocol:    "+  request.getProtocol()+"</p>";
        res+= "<p>"+"IP client: "  +  request.getRemoteAddr()+"</p>";
        res += "<p>"+"Name client: " +  request.getRemoteHost() + "   " +  request.getRemoteUser()+"</p>";
        res+="<p>"+"Port number: " +  request.getRemotePort()+"</p>";
        res+="<p>"+"String HTTP-request:  " + request.getQueryString()+"</p>";
        res+="<p>"+"Server name and port:  " +  request.getServerName() +"  " +  request.getServerPort()+"</p>";
        res += "<p>"+"Path:    " +  request.getContextPath()+"</p>";
        return res;
    }

    public String getHeaderInfo(HttpServletRequest request) {
        String result = "";
        Enumeration<String> e = request.getHeaderNames();
        while (e.hasMoreElements()) {
            String name = e.nextElement();
            String value = request.getHeader(name);
            result+="<p>"+name+" = "+value+"</p>";
        }
        return result;
    }
    public void destroy() {
    }
}
