<%@ page import="java.io.PrintWriter" %><%--
  Created by IntelliJ IDEA.
  User: ilyac
  Date: 07.04.2023
  Time: 10:02
  To change this template use File | Settings | File Templates.
--%>
<%@ page contentType="text/html;charset=UTF-8" language="java" %>
<html>
<head>
    <title>Login</title>
</head>
<body>
    <form action="Login" method="post">
        <%
            String hello = (String) request.getAttribute("is_check");
            if(hello != null) {
                PrintWriter printWriter = response.getWriter();
                printWriter.println(hello);
            }
        %>
        <div>
            <input name="name" placeholder="Enter name"/>
        </div>
        <div>
            <input name="password" type="password" placeholder="Enter password"/>
        </div>
        <div>
            <input type="submit" value="submit">
        </div>
    </form>
</body>
</html>
