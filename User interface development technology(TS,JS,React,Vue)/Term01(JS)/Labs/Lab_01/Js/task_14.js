"use strict"

let arrNum = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];

for(let i = 0;i<10;i++){
    (arrNum[i] % 2 == 0)? arrNum[i] += 2 : arrNum[i] += "мм";
}

alert(arrNum);

