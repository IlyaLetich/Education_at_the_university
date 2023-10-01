<%--
  Created by IntelliJ IDEA.
  User: ilyac
  Date: 07.04.2023
  Time: 10:30
  To change this template use File | Settings | File Templates.
--%>
<%@ page contentType="text/html;charset=UTF-8" language="java" %>
<html>
<head>
    <title>Registration</title>
</head>
<body>
<form action="Register" method="post">
    <div>
        <p>Name</p>
        <input name="name" placeholder="Enter name"/>
    </div>
    <div>
        <p>Password</p>
        <input name="password" type="password" placeholder="Enter password"/>
    </div>
    <div>
        <p>Status</p>
        <select name="status">
            <option>admin</option>
            <option>user</option>
        </select>
    </div>
    <div>
        <p>Submit</p>
        <input type="submit" value="submit">
    </div>
</form>
</body>
</html>
