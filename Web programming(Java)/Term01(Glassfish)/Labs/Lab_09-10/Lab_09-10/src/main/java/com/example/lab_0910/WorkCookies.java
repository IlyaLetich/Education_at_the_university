package com.example.lab_0910;

import jakarta.servlet.http.Cookie;
import jakarta.servlet.http.HttpServletRequest;
import jakarta.servlet.http.HttpServletResponse;

import java.time.LocalTime;
import java.time.format.DateTimeFormatter;

public class WorkCookies {
    public static void updateCoookies(HttpServletResponse response, HttpServletRequest request, String name){

        Cookie[] cookies = request.getCookies();
        String cookie_01 = "user";
        String cookie_02 = "date";
        String cookie_03 = "count";
        Cookie cookie_01_c = null;
        Cookie cookie_02_c = null;
        Cookie cookie_03_c = null;
        if(cookies !=null) {
            for(Cookie c: cookies) {
                if(cookie_01.equals(c.getName())) {
                    cookie_01_c = c;
                    break;
                }
                if(cookie_02.equals(c.getName())) {
                    cookie_02_c = c;
                    break;
                }
                if(cookie_03.equals(c.getName())) {
                    cookie_03_c = c;
                    break;
                }
            }
        }
        if(cookie_01_c == null){
            if(name == null) {
                response.addCookie(new Cookie("user", "null"));
            }
            else response.addCookie(new Cookie("user", name));
        }
        else {
            if(name != null)
                cookie_01_c.setValue(name);
        }
        if(cookie_02_c == null){
            response.addCookie(new Cookie("date",DateTimeFormatter.ofPattern("HH:mm").format(LocalTime.now())));
        }
        else{
            cookie_02_c.setValue(DateTimeFormatter.ofPattern("HH:mm").format(LocalTime.now()));
        }
        if(cookie_03_c == null){
            Cookie cook = new Cookie("count","0");
            cook.setMaxAge(1000);
            response.addCookie(cook);
        }
        else cookie_03_c.setValue(Integer.toString(Integer.parseInt(cookie_03_c.getValue()) + 1));
    }
}
