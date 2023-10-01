//================== Task_01 ==================
type Sudent = {
    id: number,
    name: string,
    group: number,
};
    
const array : Array<Sudent> = [
    {id: 1, name: 'Vasya', group: 10}, 
    {id: 2, name: 'Ivan', group: 11},
    {id: 3, name: 'Masha', group: 12},
    {id: 4, name: 'Petya', group: 10},
    {id: 5, name: 'Kira', group: 11},
];

//================= Task_02-03 =================

interface CarsType {
    [key: string] : string;
};

let car: CarsType = { }; //объект создан!
car.manufacturer = "manufacturer";
car.model = 'model';

type ArrayCarsType = {
    cars : Array<CarsType>;
};

const car1: CarsType = {}; //объект создан!
car1.manufacturer = "manufacturer";
car1.model = 'model';

const car2: CarsType = {}; //объект создан!
car2.manufacturer = "manufacturer";
car2.model = 'model';

const arrayCars: Array<ArrayCarsType> = [{
    cars: [car1, car2]  
}];

//================== Task_04 ==================

type MarkFilterType = 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9 | 10;
type GroupFilterType = 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9 | 10 | 11 | 12;
type DoneType = true | false;

type MarkType = {
    subject: string,
    mark: MarkFilterType, // может принимать значения от 1 до 10
    done: DoneType,
};

type StudentType = {
    id: number,
    name: string,
    group: GroupFilterType, // может принимать значения от 1 до 12
    marks: Array<MarkType>,
};

type GroupType = {
    students: Array<StudentType>                           // массив студентов типа StudentType
    studentsFilter: (group: number) => Array<StudentType>, // фильтр по группе
    marksFilter: (mark: number) => Array<StudentType>,     // фильтр по  оценке
    deleteStudent: (id: number) => void,                   // удалить студента по id из  исходного массива
    mark: MarkFilterType,
    group: GroupFilterType,
    print: () => void
};

let BSTU : GroupType = {
    students: [
        {
            id: 1,
            name: 'Lexa',
            group: 1, // может принимать значения от 1 до 12
            marks: [
                {
                    subject: "Матеша",
                    mark: 2,
                    done: false,
                }
            ],
        },
        {
            id: 2,
            name: 'Morgenstern',
            group: 2, // может принимать значения от 1 до 12
            marks: [
                {
                    subject: "Пение",
                    mark: 10,
                    done: true,
                },
                {
                    subject: "Русский язык",
                    mark: 7,
                    done: false,
                }
            ],
        },
        {
            id: 2,
            name: 'Zubenko',
            group: 2, // может принимать значения от 1 до 12
            marks: [
                {
                    subject: "Математика",
                    mark: 10,
                    done: true,
                },
                {
                    subject: "Прога",
                    mark: 9,
                    done: true,
                },
                {
                    subject: "Физика",
                    mark: 7,
                    done: true,
                },
                {
                    subject: "Основы права",
                    mark: 1,
                    done: false,
                }
            ],
        },
    ],
    group: 1,
    mark: 5,
    deleteStudent: (id : number) : void => {
        let arr : Array<StudentType> = [];
        for (let i = 0; i < BSTU.students.length; i++) {
            if (BSTU.students[i].id === id) {
                console.log(BSTU.students[i].name + " отчислен :(\n");
            }
            else arr.push(BSTU.students[i]);
        }
        BSTU.students = arr;
    },
    marksFilter: (mark : number) : Array<StudentType> => {
        let arr : Array<StudentType> = [];
        let check : boolean = false;
        for (let i = 0; i < BSTU.students.length; i++) {
            check = true;
            for (let j = 0; j < BSTU.students[i].marks.length; j++) {   
                if(BSTU.students[i].marks[j].mark < mark)
                    check = false;
            }
            if(!check) break;
            arr.push(BSTU.students[i]);
        }
        BSTU.students = arr;
        return arr;
    },
    studentsFilter: (group: number) : Array<StudentType> => {
        let arr : Array<StudentType> = [];
        for (let i = 0; i < BSTU.students.length; i++) {
            if(BSTU.students[i].group == group) {
                arr.push(BSTU.students[i]);
            }            
        }
        BSTU.students = arr;
        return arr;
    },

    print() : void{
        console.log(`================================`);
        for (let i = 0; i < BSTU.students.length; i++) {
            console.log(`Name: ${BSTU.students[i].name}`); 
        }
        console.log(`================================`);
    }
}

BSTU.print();
//BSTU.deleteStudent(1);
//BSTU.marksFilter(2);
BSTU.studentsFilter(2);
BSTU.print();

