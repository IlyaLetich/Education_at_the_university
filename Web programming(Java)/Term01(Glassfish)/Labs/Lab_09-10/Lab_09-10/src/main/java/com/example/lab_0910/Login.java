package com.example.lab_0910;

import DAO.ConnectorDB;
import jakarta.servlet.*;
import jakarta.servlet.http.*;
import jakarta.servlet.annotation.*;

import java.io.IOException;
import java.io.PrintWriter;
import java.sql.SQLException;
import java.time.LocalTime;
import java.time.format.DateTimeFormatter;

@WebServlet(name = "Login", value = "/Login")
public class Login extends HttpServlet {
    @Override
    protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
            getServletContext().getRequestDispatcher("/Login.jsp").forward(request, response);
    }

    @Override
    protected void doPost(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
        try {
            if(request.getParameter("name").equals("") && request.getParameter("password").equals("")) {
                request.setAttribute("is_check","error 1");
                getServletContext().getRequestDispatcher("/Login.jsp").forward(request, response);
            }
            else if(request.getParameter("name").equals("")) {
                request.setAttribute("is_check","error 2");
                getServletContext().getRequestDispatcher("/Login.jsp").forward(request, response);
            }
            else if(request.getParameter("password").equals("")) {
                request.setAttribute("is_check","error 3");
                getServletContext().getRequestDispatcher("/Login.jsp").forward(request, response);
            }
            else {
                PrintWriter printWriter = response.getWriter();
                ConnectorDB connectorDB = new ConnectorDB();
                if (connectorDB.findUsers(request.getParameter("name"), request.getParameter("password"))) {
                    TempUser.setUser(request.getParameter("name"), request.getParameter("password"));
                    WorkCookies.updateCoookies(response, request, request.getParameter("name"));
                    request.setAttribute("games",connectorDB.getGames());
                    getServletContext().getRequestDispatcher("/LoginSuccessfully.jsp").forward(request, response);
                } else
                    getServletContext().getRequestDispatcher("/Register.jsp").forward(request, response);
            }
        } catch (SQLException e) {
            throw new RuntimeException(e);
        } catch (ClassNotFoundException e) {
            throw new RuntimeException(e);
        }

    }
}
