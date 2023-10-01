var __extends = (this && this.__extends) || (function () {
    var extendStatics = function (d, b) {
        extendStatics = Object.setPrototypeOf ||
            ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
            function (d, b) { for (var p in b) if (Object.prototype.hasOwnProperty.call(b, p)) d[p] = b[p]; };
        return extendStatics(d, b);
    };
    return function (d, b) {
        if (typeof b !== "function" && b !== null)
            throw new TypeError("Class extends value " + String(b) + " is not a constructor or null");
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();
var tuple;
tuple = [1, "hello"];
var setPerson = function (name, age) {
    if (name && age) {
        return { name: name, age: age };
    }
    else {
        return { name: undefined, age: undefined };
    }
};
var doInfinitely = function () {
    while (true) {
        console.log("I am doing something");
    }
};
var company = {
    name: "Microsoft"
};
var DateTime = /** @class */ (function () {
    /**
     *
     */
    function DateTime(dd, mm, yyyy) {
        this.dd = dd;
        this.mm = mm;
        this.yyyy = yyyy;
    }
    return DateTime;
}());
var today = new DateTime(1, 1, 2020);
console.log(today.yyyy);
var questions = {
    question1: "What is your name?",
    question2: "What is your age?"
};
//==============================================================================
var Color;
(function (Color) {
    Color["Red"] = "Red";
    Color["Green"] = "Green";
    Color["Blue"] = "Blue";
})(Color || (Color = {}));
var color = Color.Red;
console.log(color);
function position(a, b) {
    if (!a && !b)
        return { x: undefined, y: undefined };
    if (a && !b)
        return { x: a, y: undefined, "default": a.toString() };
    return { x: a, y: b };
}
console.log('Empty: ', position());
console.log('One param: ', position(42));
console.log('Two params: ', position(10, 15));
//==============================================================================
var Animal = /** @class */ (function () {
    function Animal() {
    }
    Animal.prototype.move = function () {
        console.log("roaming the earth...");
    };
    return Animal;
}());
var Cow = /** @class */ (function (_super) {
    __extends(Cow, _super);
    function Cow() {
        return _super !== null && _super.apply(this, arguments) || this;
    }
    Cow.prototype.makeSound = function () {
        console.log("Moo");
    };
    Cow.prototype.move = function () {
        console.log("Walking...");
    };
    return Cow;
}(Animal));
var cow = new Cow();
cow.makeSound();
if (cow instanceof Animal) {
    cow.move();
}
var id = 1;
function checkId(id) {
    if (typeof id === "string") {
        if (isFinite(parseInt(id))) {
            return true;
        }
        return false;
    }
    return true;
}
//==============================================================================
var arrayOfNumbers = [1, 2, 3, 4, 5];
var arrayOfStrings = ['Hello', 'Frend'];
function reverse(array) {
    return array.reverse();
}
reverse(arrayOfNumbers);
reverse(arrayOfStrings);
