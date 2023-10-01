"use strict"

alert(writeString("lalala"));

function writeString(str_02, str_03 = prompt("Введите третий параметр",''), str_01 = "третий параметр не задан # "){
    return String(str_01) + String(str_02) + String(str_03);
}