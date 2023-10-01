"use strict";
exports.__esModule = true;
var Product = /** @class */ (function () {
    function Product(ID, Size, Color, Price, Sale) {
        if (Sale === void 0) { Sale = 0; }
        this.id = ID;
        this.size = Size;
        this.color = Color;
        this.price = Price;
        this.sale = Sale;
        this.endPrice = (100 - Sale) * Price / 100;
    }
    Object.defineProperty(Product.prototype, "ID", {
        get: function () {
            return this.id;
        },
        enumerable: false,
        configurable: true
    });
    Object.defineProperty(Product.prototype, "Size", {
        get: function () {
            return this.size;
        },
        enumerable: false,
        configurable: true
    });
    Object.defineProperty(Product.prototype, "Color", {
        get: function () {
            return this.color;
        },
        enumerable: false,
        configurable: true
    });
    Object.defineProperty(Product.prototype, "Price", {
        get: function () {
            return this.endPrice;
        },
        set: function (v) {
            this.price = v;
            this.endPrice = (100 - this.sale) * this.price / 100;
        },
        enumerable: false,
        configurable: true
    });
    Product.prototype.toString = function () {
        return "ID: ".concat(this.id, ", Size: ").concat(this.size, ", Color: ").concat(this.color, ", Price: ").concat(this.price, ", Sale: ").concat(this.sale, ", EndPrice: ").concat(this.endPrice);
    };
    return Product;
}());
var product1 = new Product(1, 23, "Red", 100, 10);
var product2 = new Product(2, 43, "Yellow", 20, 20);
var product3 = new Product(3, 53, "Black", 300, 30);
var product4 = new Product(4, 51, "Red", 400, 40);
var products = [product1, product2, product3, product4];
console.log("\n    Exesize 4\n    \u041E\u0434\u0438\u043D \u0438\u0437 \u043F\u0440\u043E\u0434\u0443\u043A\u0442\u043E\u0432: ".concat(product3.toString(), "\n    "));
