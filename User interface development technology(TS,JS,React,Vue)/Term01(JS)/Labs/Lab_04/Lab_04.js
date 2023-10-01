"use strict"

// - - - - - - - - - task_01 - - - - - - -
function task_01(...args) {
    if (args.length <= 3) {
        return args.join(',');
    } else if (args.length > 3 && args.length <= 5) {
        return args.map(arg => typeof arg);
    } else if (args.length > 5 && args.length <= 7) {
        return args.length;
    } else {
        return "Exceeded the number of parameters";
    }
}

//alert(task_01(7, 7, 7)); 
//alert(task_01(...["Seven", "Seven", "Seven"])); 
//alert(task_01(7, "Seven", true, false)); 
//alert(task_01(1, 2, 3, 4, 5, 6)); 
//alert(task_01(1, 2, 3, 4, 5, 6, 7, 8)); 

// - - - - - - - - - task_02 - - - - - - -
// 1)
//window.a; 
//alert(a);    
//ReferenceError: a is not defined

// 2)
//alert(a);
//window.a = 2; 
//ReferenceError: a is not defined

// 3)
//alert(a); 
//window.a = 2;
//let a;   
//Cannot access 'a' before initialization

// 4)
//alert(a);
//window.a = 2;
//var a;  
//undefined

// 5)
//alert(a);
//let a = 2; 
//Cannot access 'a' before initialization

//6)
//let a = 2;
//window.a = 3;
//alert(a);
//2

// 7)
//var a = 2; 
//window.a = 3;
//alert(a); 
//3

// - - - - - - - - - task_03 - - - - - - -

/*
let s = 5;
function sum() {
    alert(s);
}
sum();
*/
//5

// - - - - - - - - - task_04 - - - - - - -

//Вариант 1
 
function makeCounter() {
    let currentCount = 1;

    return function() {  
        return currentCount++; 
    };
}

let counter_01 = makeCounter();

//alert( counter_01() ); // 1
//alert( counter_01() ); // 2
//alert( counter_01() ); // 3

let counter_02 = makeCounter();
//alert( counter_02() ); // 1

//Вариант 2 
let currentCount = 1;

function makeCounter_02() {
    return function() {
        return currentCount++;
    };
}

let counter_03 = makeCounter_02();
let counter_04 = makeCounter_02();

//alert( counter_03() ); // 1
//alert( counter_03() ); // 2

//alert( counter_04() ); // 3
//alert( counter_04() ); // 4

// - - - - - - - - - task_05 - - - - - - -
alert(`
${task_01.name}\n
${makeCounter.name}\n
${makeCounter_02.name}\n
`);

// - - - - - - - - - task_06 - - - - - - -
function CalculateVolumeFigure(edge_01) {
    return (edge_02) => {
        return (edge_03) => {
            return (+edge_01 * +edge_02 * +edge_03);
        }
    }
}

alert(`Result(1,2,3) = ${CalculateVolumeFigure(1)(2)(3)}`);

function CalculateolumeFigureOneEdge(edgeOne) {
    return (edge_02, edge_03) => {
        return  (+edgeOne * +edge_02 * +edge_03);
    }
}
let CalculateolumeFigureWithOneEdge = CalculateolumeFigureOneEdge(7);
alert(`Result(1,2) = ${CalculateolumeFigureWithOneEdge(1, 2)}`);
alert(`Result(2,3) = ${CalculateolumeFigureWithOneEdge(2, 3)}`);

// - - - - - - - - - task_07 - - - - - - -

/*7. Пользователь управляет движением объекта, вводя в модальное окно  команды left, right, up, down. Объект совершает 10 шагов в заданном направлении (т.е. высчитываются и выводятся в консоль соответствующие координаты) и запрашивает новую команду. Разработайте генератор, который возвращает координаты объекта, согласно заданному направлению движения.  */

function* ShowMoveInfo() {

    let x = 0;
    let y = 0;
    
    let check = false;

    let move;

    for (let i = 0; i < 10; i++) {
        move = prompt("Enter the step");
        switch (move.trim().toUpperCase()) {
            case "LEFT":
                check = true;
                x--;
                break;
            case "RIGHT":
                check = true;
                x++;
                break;
            case "UP":
                check = true;
                y++;
                break;
            case "DOWN":
                check = true;
                y--;
                break;
            default:
                alert("Enter again correctly");
                i--;
                check = false
                break;
        }
        if(check) yield [x, y];
    }
}

let generatorMove = ShowMoveInfo(); 

let moveUser = "";

for (let i = 0; i < 10; i++) {
    moveUser += `${i} step = `
    moveUser += generatorMove.next().value;
    moveUser += '\n';
}

alert(moveUser);