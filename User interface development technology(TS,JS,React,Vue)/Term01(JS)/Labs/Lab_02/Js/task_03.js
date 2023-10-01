"use strict"

let arrStudent = [];

let tryRead = false;

while(!tryRead){
    let timeP = prompt("Введите имя студента",'');
    (timeP == null || timeP == "") ? tryRead = true : arrStudent.push(timeP);
}

alert(`Количество студентов = ${calculateStudent(arrStudent)}`);

function calculateStudent(arr){
    return arr.length;
}