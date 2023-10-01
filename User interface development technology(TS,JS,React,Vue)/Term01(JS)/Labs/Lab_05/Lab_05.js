"use strict"

// - - - - - - - - - task_01 - - - - - - -

let Products = {
    Shoes: {
        Boots: {
            id: 7,
            size: 43,
            color: 'black',
            price: 1_000_000

        },
        Sneakers: {
            id: 8,
            size: 41,
            color: 'white',
            price: 777_777

        },
        Sandals: {
            id: 9,
            size: 36,
            color: 'red',
            price: 7_000_000
        }
    }
}


// - - - - - - - - - task_02 - - - - - - -

Products[Symbol.iterator] = function() {
    return {
        current: this.Shoes.Boots.id,
        last: this.Shoes.Sandals.id,
        next() {
            if (this.current <= this.last) {
                return { done: false, value: this.current++ };
            } else {
                return { done: true };
            }
        }
    };
};


for (let product of Products) {
   alert(product);
}

// - - - - - - - - - task_03 - - - - - - -

let choice = 1;
let checkFind = false;

while (choice) {
    choice = prompt("Enter action: \n1 = price \n2 = size \n3 = color \n0 = return");

    switch (choice) {

        case '1':

            let minPrice = prompt("Enter minimal price");
            let maxPrice = prompt("Enter maximal price");

            for (let product in Products.Shoes) {
                if (Products.Shoes[product].price >= minPrice && Products.Shoes[product].price <= maxPrice) {
                    alert(Products.shoes[product].id);
                    checkFind = true;
                }
            }
            if (!checkFind) {
                alert("Nothing found");
            }
            checkFind = false;
            break;

        case '2':

            let size = prompt('Enter size');

            for (let product in Products.Shoes) {
                if (Products.Shoes[product].size == size) {
                    alert(Products.Shoes[product].id);
                    checkFind = true;
                }
            }

            if (!checkFind) {
                alert("Nothing found");
            }

            checkFind = false;
            break;

        case '3':

            let color = prompt('Enter color');

            for (let product in Products.Shoes) {
                if (Products.Shoes[product].color == color) {
                    alert(Products.Shoes[product].id);
                    checkFind = true;
                }
            }

            if (!checkFind) {
                alert("Nothing found");
            }

            checkFind = false;
            break;

        case '0':

            choice = 0;
            break;

        default:
            alert('Incorrect input');
    }
}

// - - - - - - - - - task_04 - - - - - - -

Object.defineProperty(Products.Shoes.Boots, 'id', {
    value: 4,
    writable: false,
    configurable: false,
});

alert(Products.Shoes.Boots.id);
//delete Products.Shoes.Boots.id;
//Products.Shoes.Boots.id = 5;
alert("ID: " + Products.Shoes.Boots.id);


// - - - - - - - - - task_05 - - - - - - -

Object.defineProperty(Products.Shoes.Boots, 'discount', {
    value: 10,
    writable: false,
});
Object.defineProperty(Products.Shoes.Boots, 'finalPrice', {
    get: function () {
        return this.price - (this.price * this.discount) / 100;
    },
    set: function (value) {
        this.discount = 100 - (value / this.price) * 100;
    }
});

alert(`Discount: ${Products.Shoes.Boots.discount}`);
alert(`Final price = ${Products.Shoes.Boots.finalPrice}`);