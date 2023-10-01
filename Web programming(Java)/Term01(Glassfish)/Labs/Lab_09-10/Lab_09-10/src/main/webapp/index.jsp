<%@ page import="DAO.ConnectorDB" %>
<%@ page import="java.sql.Statement" %>
<%@ page contentType="text/html; charset=UTF-8" pageEncoding="UTF-8"
%>
<%@ page import="com.example.lab_0910.WorkCookies" %>
<%
    WorkCookies.updateCoookies(response,request,null);
%>
<!DOCTYPE html>
<html>
<head>
    <title>Lab_09-10</title>
</head>
<body>
<a href="Login">Login</a>
<a href="Register">Register</a>
</body>
</html>