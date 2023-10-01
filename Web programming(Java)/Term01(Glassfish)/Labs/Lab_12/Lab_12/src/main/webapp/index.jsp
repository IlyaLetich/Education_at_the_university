<%@ page contentType="text/html; charset=UTF-8" pageEncoding="UTF-8" language="java"%>
<%@ taglib prefix="my" uri="/WEB-INF/mytags.tld" %>
<!DOCTYPE html>
<html>
<head>
    <title>JSP - Hello World</title>
</head>
<body>
<h1><%= "Hello my frend!" %>
</h1>
<br/>
    <p><a href="core">core</a></p>
    <p><a href="formatting">formatting</a></p>
    <p><a href="sql">sql</a></p>
    <p><a href="xml">xml</a></p>
    <p><a href="functions">functions</a></p>
    <my:PIETable/>
</body>
</html>