"use strict"

// Function Expression

let calculateDiameter = function (radius) {
    return radius*2;
}

let calculateLength = (radius) => 2 * 3.14 * radius;

// test
let radius = +prompt("Введите пожалуйста радиус окружности",'');

alert(`Диаметр окружности равен = ${calculateDiameter(radius)}`)
alert(`Длина окружности равна = ${calculateLength(radius)}`)
alert(`Площадь окружности равна = ${calculateSquare(radius)}`)

// Function Declaration

function calculateSquare(radius){
    return 3.14*(radius)**2;
}

