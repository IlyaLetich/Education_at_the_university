"use strict"

let userData = prompt("Введите данные:",'');
if(userData != null){
    if(isFinite(+userData) && !userData.includes('.')){
        console.log(`Вы ввели чисто(целое) = ${+userData}`);
        console.log(`В шестнадцетеричной системе счисления = ${((+userData).toString(16).toUpperCase())} `);
    }
    else if(isFinite(+userData) && +userData % 1 !== 0){
        console.log(`Вы ввели чисто(дробное) = ${+userData}`);
        console.log(`
        Набольшую сторону: ${Math.ceil(+userData)}\n
        Наименьшую: ${Math.floor(+userData)}\n
        Ближайшее целое: ${Math.round(+userData)}\n
    `);
    }
    else {
        console.log(`Вы ввели текст = (${userData})`);
        console.log(`
            Верхний регистр: ${userData.toUpperCase()}\n
            Нижний регистр: ${userData.toLowerCase()}\n
        `);
    }
}