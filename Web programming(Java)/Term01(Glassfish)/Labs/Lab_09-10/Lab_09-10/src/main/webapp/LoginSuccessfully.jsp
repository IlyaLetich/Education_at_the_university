<%@ page import="DAO.ConnectorDB" %>
<%@ page import="java.util.ArrayList" %>
<%@ page import="DAO.Game" %>
<%@ page import="java.io.PrintWriter" %>
<%@ page import="com.example.lab_0910.TempUser" %><%--
  Created by IntelliJ IDEA.
  User: ilyac
  Date: 07.04.2023
  Time: 10:19
  To change this template use File | Settings | File Templates.
--%>
<%@ page contentType="text/html;charset=UTF-8" language="java" %>
<%
    ConnectorDB connectorDB = new ConnectorDB();

    String name = TempUser.NameUser;
    if(TempUser.NameUser == null && TempUser.PasswordUser == null);
    String status = connectorDB.getStatus(TempUser.NameUser,TempUser.PasswordUser);
    if(status == null) status = "admin";
%>
<html>
<head>
    <title>Login Successfully</title>
</head>
<body>
    <jsp:include page="Header.jsp" />
    <div>Hello</div>
    <div><%=name%></div>
    <div><%=status%></div>
    <jsp:include page="array.jsp" />
    <jsp:include page="Footer.jsp" />
</body>
</html>
