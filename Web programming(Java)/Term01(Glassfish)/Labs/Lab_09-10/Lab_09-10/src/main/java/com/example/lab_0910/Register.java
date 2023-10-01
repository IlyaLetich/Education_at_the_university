package com.example.lab_0910;

import DAO.ConnectorDB;
import jakarta.servlet.*;
import jakarta.servlet.http.*;
import jakarta.servlet.annotation.*;

import java.io.IOException;
import java.sql.Date;
import java.sql.SQLException;
import java.time.LocalTime;
import java.time.format.DateTimeFormatter;

@WebServlet(name = "Register", value = "/Register")
public class Register extends HttpServlet {
    @Override
    protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
        WorkCookies.updateCoookies(response,request,null);
        getServletContext().getRequestDispatcher("/Register.jsp").forward(request, response);
    }

    @Override
    protected void doPost(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
        try {
            HttpSession httpSession = request.getSession();
            httpSession.setAttribute("user","true");

            ConnectorDB connectorDB = new ConnectorDB();
            TempUser.setUser(request.getParameter("name"), request.getParameter("password"));
            connectorDB.createUser(request.getParameter("name"),request.getParameter("password"),request.getParameter("status"));
            WorkCookies.updateCoookies(response,request,request.getParameter("name"));
            getServletContext().getRequestDispatcher("/LoginSuccessfully.jsp").forward(request, response);
        } catch (SQLException e) {
            throw new RuntimeException(e);
        } catch (ClassNotFoundException e) {
            throw new RuntimeException(e);
        }

    }
}
