"use strict"

let answer = prompt("Найдите ошибку и введите правильный вариант: вогзал",'');
let trueAnswer = "вокзал";

let answerFalse = false;

let arrFalse = [];

let counter;
if(answer.length < trueAnswer.length) counter = trueAnswer.length;
else counter = answer.length;

for(let i = 0; i < counter; i++){
    if(answer[i] != trueAnswer[i]){
        arrFalse.push(i+1);
        if(answerFalse == false) answerFalse = true;
    }
}

answerFalse == false? alert("Вы ответили правильно"):alert(`Вы ошиблись в следующих символах: ${arrFalse}`);