<%-- 
    Document   : registerBook
    Created on : 20-Sep-2016, 00:06:01
    Author     : root
--%>

<%@page contentType="text/html" pageEncoding="UTF-8"%>
<!DOCTYPE html>
<html>
    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
        <title>Register Book Page</title>
    </head>
    <body>
        <h1>Registro de Livro</h1>
        <form action="register">
            <input type="text" name="name"/>
            <input type="checkbox" name="didactic" value="Didactic"> Didático<br>
            <input type="submit" name="registrar"/>
        </form>
    </body>
</html>
