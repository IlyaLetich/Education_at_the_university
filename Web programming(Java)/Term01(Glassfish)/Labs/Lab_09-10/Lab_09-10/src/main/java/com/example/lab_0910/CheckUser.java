package com.example.lab_0910;

import DAO.ConnectorDB;
import jakarta.servlet.*;
import jakarta.servlet.http.*;
import jakarta.servlet.annotation.*;

import java.io.IOException;
import java.sql.SQLException;

@WebServlet(name = "CheckUser", value = "/CheckUser")
public class CheckUser extends HttpServlet {
    @Override
    protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
        try {
            ConnectorDB connectorDB = new ConnectorDB();
            if(TempUser.NameUser == null && TempUser.PasswordUser == null){
                request.setAttribute("is_check","error no register");
                getServletContext().getRequestDispatcher("/Login.jsp").forward(request, response);
            }
            else{
                request.setAttribute("games",connectorDB.getGames());
                getServletContext().getRequestDispatcher("/LoginSuccessfully.jsp").forward(request, response);
            }
        } catch (SQLException e) {
            throw new RuntimeException(e);
        } catch (ClassNotFoundException e) {
            throw new RuntimeException(e);
        }

    }

    @Override
    protected void doPost(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {

    }
}
