let estimation_01 = writeExam(1);

let estimation_02 = writeExam(2);

let estimation_03 = writeExam(3);

trySession(estimation_01,estimation_02,estimation_03);

function writeExam(i){

    let tryE = false;
    let estimation = +prompt(`На что Вы сдали ${i} экзамен?`,"");
    
    while(!tryE){
        if(estimation <= 10 && estimation >=0) tryE = true;
        else{
            alert("Такой оценки нет( Введите пожалуйста ещё раз..");
            estimation = +prompt(`На что Вы сдали ${i} экзамен?`,"");
        }
    }

    return estimation;
}

function trySession(estimation01,estimation02,estimation03){
    
    let count = 0;
    if(estimation01 >= 4) count++;
    if(estimation02 >= 4) count++;
    if(estimation02 >= 4) count++;

    switch(count){
        case 0:
            alert("Вы отчислены :(");
            break;
        case 1:
            alert("Вас ждёт 2 пересдачи, желаю Вам удачи)");
            break;
        case 2:
            alert("Одна пересдача и всё будет хорошо!");
            break;
        case 3:
            alert("Урааа!!! Вы переведены на следующий курс!");
            break;
        default:
            alert("Что-то пошло не так(");
            break;
    }
}