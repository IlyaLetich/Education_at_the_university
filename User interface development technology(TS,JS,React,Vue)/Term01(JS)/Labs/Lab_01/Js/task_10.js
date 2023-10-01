"use strict"

let loginUser = "Ilya";
let passwordUser = "1234"

let userLogin = prompt(`Введите логин`,"");
let userPassword = prompt(`Введите пароль`,"");
    
if(userLogin === loginUser && userPassword === passwordUser){
    alert("Вы успешно вошли в аккаунт");
}
else alert("Данные введены не верно");