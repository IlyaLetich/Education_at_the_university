package Filters;

import jakarta.servlet.*;
import jakarta.servlet.annotation.*;
import jakarta.servlet.http.HttpServletRequest;
import jakarta.servlet.http.HttpServletResponse;
import jakarta.servlet.http.HttpSession;

import java.io.IOException;
import java.io.PrintWriter;

@WebFilter(filterName = "FilterLogin", urlPatterns = "/")
public class FilterLogin implements Filter {
    public void init(FilterConfig config) throws ServletException {
    }

    public void destroy() {
    }

    @Override
    public void doFilter(ServletRequest request, ServletResponse response, FilterChain chain) throws ServletException, IOException {

        HttpServletRequest httpServletRequest = (HttpServletRequest)request;
        HttpServletResponse httpServletResponse = (HttpServletResponse)response;

        HttpSession httpSession = httpServletRequest.getSession();
        String check = (String) httpSession.getAttribute("user");

        if(check != null) {
            if (check.equals("true"))
                chain.doFilter(request, response);
        }
        else {
            ((HttpServletResponse) response).sendRedirect("Register.jsp");
        }

    }
}
