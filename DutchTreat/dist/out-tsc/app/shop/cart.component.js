import { __decorate } from "tslib";
import { Component } from '@angular/core';
let Cart = class Cart {
    constructor(data, router) {
        this.data = data;
        this.router = router;
    }
    onCheckout() {
        if (this.data.loginRequired) {
            this.router.navigate(["login"]);
        }
        else {
            this.router.navigate(["checkout"]);
        }
    }
};
Cart = __decorate([
    Component({
        selector: 'the-cart',
        templateUrl: 'cart.component.html',
        styleUrls: []
    })
], Cart);
export { Cart };
//# sourceMappingURL=cart.component.js.map