"use strict";
exports.__esModule = true;
var bootAddidas1 = {
    ID: 5,
    Size: 24,
    Color: "Red",
    Price: 123
};
var bootAddidas2 = {
    ID: 101,
    Size: 53,
    Color: "Yellow",
    Price: 900
};
var sandalNike1 = {
    ID: 142,
    Size: 24,
    Color: "Blue",
    Price: 189
};
var sneakersRunner1 = {
    ID: 11,
    Size: 23,
    Color: "Red",
    Price: 150
};
var Boots = {
    ID: 1,
    Boots: [bootAddidas1, bootAddidas2]
};
var Sandals = {
    ID: 2,
    Boots: [sandalNike1]
};
var Sneakers = {
    ID: 3,
    Boots: [sneakersRunner1]
};
var products = {
    Products: Boots.Boots.concat(Sandals.Boots, Sneakers.Boots)
};
console.log("\n    Exesize 1\n");
products.Products.forEach(function (element) {
    console.log(element.ID);
});
exports["default"] = products;
