<%@ page import="DAO.ConnectorDB" %>
<%@ page import="java.io.PrintWriter" %>
<%@ page import="DAO.Game" %>
<%@ page import="java.util.ArrayList" %>
<%@ page import="com.example.lab_0910.TempUser" %>
<%@ page contentType="text/html;charset=UTF-8" language="java" %>
<%
    ConnectorDB connectorDB = new ConnectorDB();

    String name = TempUser.NameUser;
    String status = connectorDB.getStatus(TempUser.NameUser,TempUser.PasswordUser);

    PrintWriter printWriter = response.getWriter();
    if(status.equals("admin")){
        ArrayList<Game> games = connectorDB.getGames();
        printWriter.println("<ul>");
        for (Game item: games) {
            printWriter.println("<li>");
            printWriter.println(item.name + " " + item.type);
            printWriter.println("</li>");
        }
        printWriter.println("</ul>");
    }

    if(status.equals("admin")){
        printWriter.println("<form method=\"post\" action=\"ServletGame\">\n" +
                "    <p>Name</p>\n" +
                "    <input name=\"nameGame\">\n" +
                "    <p>Type</p>\n" +
                "    <input name=\"typeGame\">\n" +
                "    <p>Added</p>\n" +
                "    <input type=\"submit\" value=\"submit\">\n" +
                "</form>\n" +
                "\n" +
                "<form method=\"post\" action=\"ServletDelGame\">\n" +
                "    <p>Delete top</p>\n" +
                "    <input type=\"submit\" value=\"submit\">\n" +
                "</form>");
    }

%>

