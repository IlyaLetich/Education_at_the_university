"use strict";
exports.__esModule = true;
var Iterator_js_1 = require("./Iterator.js");
var Ex1_js_1 = require("./Ex1.js");
var iterator = new Iterator_js_1["default"](Ex1_js_1["default"].Products);
var filterByCost = function (iterator, costStart, costEnd) {
    var result = [];
    var current;
    iterator.reset();
    while (iterator.hasNext()) {
        current = iterator.next();
        if (current.Price >= costStart && current.Price <= costEnd) {
            result.push(current);
        }
    }
    return result;
};
var filterBySize = function (iterator, size) {
    var result = [];
    iterator.reset();
    while (iterator.hasNext()) {
        var current = iterator.next();
        if (current.Size === size) {
            result.push(current);
        }
    }
    return result;
};
var filterByColor = function (iterator, color) {
    var result = [];
    iterator.reset();
    while (iterator.hasNext()) {
        var current = iterator.next();
        if (current.Color === color) {
            result.push(current);
        }
    }
    return result;
};
var prods1 = filterByCost(iterator, 100, 200);
console.log("\n    Exesize 2\n    \u041E\u0442\u0444\u0438\u043B\u044C\u0442\u0440\u043E\u0432\u0430\u043D\u043D\u044B\u0435 \u043F\u043E \u0446\u0435\u043D\u0435 \u043E\u0442 100 \u0434\u043E 200\n");
prods1.forEach(function (element) {
    console.log(element.ID);
});
var prods2 = filterBySize(iterator, 23);
console.log("\n    \u041E\u0442\u0444\u0438\u043B\u044C\u0442\u0440\u043E\u0432\u0430\u043D\u043D\u044B\u0435 \u043F\u043E \u0440\u0430\u0437\u043C\u0435\u0440\u0443 23\n    ");
prods2.forEach(function (element) {
    console.log(element.ID);
});
var prods3 = filterByColor(iterator, "Red");
console.log("\n    \u041E\u0442\u0444\u0438\u043B\u044C\u0442\u0440\u043E\u0432\u0430\u043D\u043D\u044B\u0435 \u043F\u043E \u0446\u0432\u0435\u0442\u0443 Red\n    ");
prods3.forEach(function (element) {
    console.log(element.ID);
});
