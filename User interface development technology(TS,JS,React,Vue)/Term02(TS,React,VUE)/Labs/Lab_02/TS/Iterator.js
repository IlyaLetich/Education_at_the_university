"use strict";
exports.__esModule = true;
var Iterator = /** @class */ (function () {
    function Iterator(collection) {
        this.index = 0;
        this.collection = collection;
    }
    Iterator.prototype.next = function () {
        if (this.index === this.collection.length) {
            this.reset();
        }
        return this.collection[this.index++];
    };
    Iterator.prototype.hasNext = function () {
        return this.index < this.collection.length;
    };
    Iterator.prototype.reset = function () {
        this.index = 0;
    };
    return Iterator;
}());
exports["default"] = Iterator;
