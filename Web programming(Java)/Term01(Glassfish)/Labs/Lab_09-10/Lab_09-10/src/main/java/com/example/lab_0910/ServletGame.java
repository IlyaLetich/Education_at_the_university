package com.example.lab_0910;

import DAO.ConnectorDB;
import jakarta.servlet.*;
import jakarta.servlet.http.*;
import jakarta.servlet.annotation.*;

import java.io.IOException;
import java.sql.SQLException;

@WebServlet(name = "ServletGame", value = "/ServletGame")
public class ServletGame extends HttpServlet {
    @Override
    protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
    }

    @Override
    protected void doPost(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
        try {
            ConnectorDB connectorDB = new ConnectorDB();
            connectorDB.createGame(request.getParameter("nameGame"),request.getParameter("typeGame"));

            getServletContext().getRequestDispatcher("/LoginSuccessfully.jsp").forward(request, response);
        } catch (SQLException e) {
            throw new RuntimeException(e);
        } catch (ClassNotFoundException e) {
            throw new RuntimeException(e);
        }
    }
}
