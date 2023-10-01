var array = [
    { id: 1, name: 'Vasya', group: 10 },
    { id: 2, name: 'Ivan', group: 11 },
    { id: 3, name: 'Masha', group: 12 },
    { id: 4, name: 'Petya', group: 10 },
    { id: 5, name: 'Kira', group: 11 },
];
;
var car = {}; //объект создан!
car.manufacturer = "manufacturer";
car.model = 'model';
var car1 = {}; //объект создан!
car1.manufacturer = "manufacturer";
car1.model = 'model';
var car2 = {}; //объект создан!
car2.manufacturer = "manufacturer";
car2.model = 'model';
var arrayCars = [{
        cars: [car1, car2]
    }];
var BSTU = {
    students: [
        {
            id: 1,
            name: 'Lexa',
            group: 1,
            marks: [
                {
                    subject: "Матеша",
                    mark: 2,
                    done: false
                }
            ]
        },
        {
            id: 2,
            name: 'Morgenstern',
            group: 2,
            marks: [
                {
                    subject: "Пение",
                    mark: 10,
                    done: true
                },
                {
                    subject: "Русский язык",
                    mark: 7,
                    done: false
                }
            ]
        },
        {
            id: 2,
            name: 'Zubenko',
            group: 2,
            marks: [
                {
                    subject: "Математика",
                    mark: 10,
                    done: true
                },
                {
                    subject: "Прога",
                    mark: 9,
                    done: true
                },
                {
                    subject: "Физика",
                    mark: 7,
                    done: true
                },
                {
                    subject: "Основы права",
                    mark: 1,
                    done: false
                }
            ]
        },
    ],
    group: 1,
    mark: 5,
    deleteStudent: function (id) {
        var arr = [];
        for (var i = 0; i < BSTU.students.length; i++) {
            if (BSTU.students[i].id === id) {
                console.log(BSTU.students[i].name + " отчислен :(\n");
            }
            else
                arr.push(BSTU.students[i]);
        }
        BSTU.students = arr;
    },
    marksFilter: function (mark) {
        var arr = [];
        var check = false;
        for (var i = 0; i < BSTU.students.length; i++) {
            check = true;
            for (var j = 0; j < BSTU.students[i].marks.length; j++) {
                if (BSTU.students[i].marks[j].mark < mark)
                    check = false;
            }
            if (!check)
                break;
            arr.push(BSTU.students[i]);
        }
        BSTU.students = arr;
        return arr;
    },
    studentsFilter: function (group) {
        var arr = [];
        for (var i = 0; i < BSTU.students.length; i++) {
            if (BSTU.students[i].group == group) {
                arr.push(BSTU.students[i]);
            }
        }
        BSTU.students = arr;
        return arr;
    },
    print: function () {
        console.log("================================");
        for (var i = 0; i < BSTU.students.length; i++) {
            console.log("Name: ".concat(BSTU.students[i].name));
        }
        console.log("================================");
    }
};
BSTU.print();
//BSTU.deleteStudent(1);
//BSTU.marksFilter(2);
BSTU.studentsFilter(2);
BSTU.print();
