let leg_01 = Number(prompt("Первый катет = ", ''));
let leg_02 = Number(prompt("Второй катет = ", ''));
let gypo = Math.sqrt(Math.pow(leg_01, 2) + Math.pow(leg_02, 2)).toFixed(2);

let Area = 0.5 * leg_01 * leg_02;
Area = +Area.toFixed(2);
let Perimetr = +leg_01 + +leg_02 + +gypo;
let Height = leg_01 * leg_02 / gypo;
Height = +Height.toFixed(2);
let cos1 = leg_01 / gypo;
cos1 = +cos1.toFixed(2);
let cos2 = leg_02 / gypo;
cos2 = +cos2.toFixed(2);
let sin1 = leg_02 / gypo;
sin1 = +sin1.toFixed(2);
let sin2 = leg_01 / gypo;
sin2 = +sin2.toFixed(2);
let tg1 = leg_02 / leg_01;
tg1 = +tg1.toFixed(2);
let tg2 = leg_01 / leg_02;
tg2 = +tg2.toFixed(2);
let ctg1 = leg_01 / leg_02;
ctg1 = +ctg1.toFixed(2);
let ctg2 = leg_02 / leg_01;
ctg2 = +ctg2.toFixed(2);

alert(`Площадь треугольника: ${Area}
       Периметр треугольника: ${Perimetr}
       Высота треугольника: ${Height}
       Косинус первого угла треугольника: ${cos1}
       Косинус второго угла треугольника: ${cos2}
       Синус первого угла треугольника: ${sin1}
       Синус второго угла треугольника: ${sin2}
       Тангенс первого угла треугольника: ${tg1}
       Тангенс второго угла треугольника: ${tg2}
       Котангенс первого угла треугольника: ${ctg1}
       Котангенс второго угла треугольника: ${ctg2}`);