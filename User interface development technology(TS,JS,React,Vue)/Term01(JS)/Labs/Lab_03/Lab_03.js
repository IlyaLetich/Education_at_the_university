function Excent()
{
    let buttons = document.getElementsByTagName("button");
    let fon = document.getElementsByTagName("html");
    let links = document.getElementsByTagName("a");

    let time;

    let ObjButtons = {
        color: "black",
        background: "red",
    }

    let ObjA = {
        color: "black",
        background: "red",
    }

    let Fon = {
        background: "lightyellow",
    }

    for (let i = 0; i < buttons.length; i++) {
        Object.assign(buttons[i].style,ObjButtons);
    }

    for (let i = 0; i < links.length; i++) {
        Object.assign(links[i].style,ObjA);
    }

    fon[0].style.background = Fon.background;
}

function WorkWithBasketOfProduct(){

    Excent();

    let basketProduct = new Map();

    let check = true;

    while (check) {

        let sum = 0;

        let product = {
            id: 0,
            Count: 0,
            Price: 0
        }

        switch (+prompt(`Выберите операцию:
        1 - Добавить товар 
        2 - Удалить товар 
        3 - Изменить количество товара 
        4 - Сумма и количество товаров 
        5 - Завершить`)) {
            case 1:
                product.id = +prompt("Введите ID-товара: ");
                product.Count = +prompt("Введите количество товара: ");
                product.Price = +prompt("Введите цену товара: ");
                basketProduct.set(product.id, product);
                break;
            case 2:
                basketProduct.delete(+prompt("Введите ID-товара, который хотите удалить: "));
                break;
            case 3:
                let timeProduct = {
                    id: product.id,
                    Count: +prompt("Введите новое количество товара: "),
                    Price: +prompt("Введите новую цену товара: ")
                }
                basketProduct.set(+prompt("Введите ID-товара: "), timeProduct);
                break;
            case 4:
                for (let product of basketProduct.values()) {
                    sum += product.Price;
                }
                alert("Сумма товаров = " + sum + " ,Количество позиций = " + basketProduct.size);
                break;
            case 5:
                check = false;
                break;
            default:
                return;
        }
    }
}

function  WorkWithListOfProduct () {

    Excent();

    let listOfProduct = new Set();

    let check = true;

    while (check) {

        switch (+prompt(`Выберите операцию:
         1 - Добавить товар 
         2 - Удалить товар 
         3 - Найти товар 
         4 - Количество товаров 
         5 - Завершить`)) {

            case 1:
                listOfProduct.add(prompt("Введите товар: "));
                break;
            case 2:
                listOfProduct.delete(prompt("Введите товар: "));
                break;
            case 3:
                if (listOfProduct.has(prompt("Введите товар, который Вы хотите найти: ")))
                    alert("Товар есть в списке");
                else
                    alert("Быстрее за товаром, пока его не раскупили");
                break;
            case 4:
                alert(listOfProduct.size);
                break;
            case 5:
                check = false;
                break;
            default:
                return;
        }
    }
}

function ShowNameDay () {
    let Days = {
        1: "Понедельник",
        2: "Вторник",
        3: "Среда",
        4: "Четверг",
        5: "Пятница",
        6: "Суббота",
        7: "Воскресенье"
    }
    alert(Days[+prompt("Введите пожалуйста день недели: ")]);
}

function EditComment (message = prompt("Напишите комментарий"), n = +prompt("Введите максимальную длину комментария")) {

    Excent();

    if (message.length > n) {
        alert("Длина комментария первышена!");
        return;
    }
    if (message.indexOf("кот") !== -1) {
        message = message.replaceAll("кот", "*");
    }
        if (message.indexOf("пес") !== -1) {
            let count = message.indexOf("пес");
            message = message.substr(0, count) + " многоуважемый " + message.substr(count);
        }
        if (message.indexOf("собак") !== -1) {
            let count = message.indexOf("собак");
            message = message.slice(0, count) + message[count].toUpperCase() + message.slice(count + 1);

       }
    alert(message);
}