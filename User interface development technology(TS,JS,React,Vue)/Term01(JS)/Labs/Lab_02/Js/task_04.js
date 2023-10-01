"use strict"

let numbers = 10;
let numberPassword = 3;

let letters = 26;
let lettersPassword = 5;

let timeCrackPassword = Math.pow(numbers,numberPassword) * Math.pow(letters,lettersPassword) * 3;

let timeCrackYears = Math.floor(timeCrackPassword / (60*60*24*30*12));
timeCrackPassword -= timeCrackYears * 60*60*24*30*12;
let timeCrackMounts = Math.floor(timeCrackPassword / (60*60*24*30));
timeCrackPassword -= timeCrackMounts * 60*60*24*30;
let timeCrackDays = Math.floor(timeCrackPassword / (60*60*24));
timeCrackPassword -= timeCrackDays * 60*60*24;
let timeCrackHours = Math.floor(timeCrackPassword / (60*60));
timeCrackPassword -= timeCrackHours * 60*60;
let timeCrackMinutes = Math.floor(timeCrackPassword/60);
timeCrackPassword -= timeCrackMinutes * 60;
let timeCrackSeconds = timeCrackPassword;

console.log(`${timeCrackYears} лет(год), 
${timeCrackMounts} месяцев (месяц), 
${timeCrackDays} дней(дня),
${timeCrackHours} часов, 
${timeCrackMinutes} минут,
${timeCrackSeconds} секунды(секунд)`);