"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.OrderState = void 0;
var OrderState;
(function (OrderState) {
    OrderState[OrderState["notOrdered"] = 0] = "notOrdered";
    OrderState[OrderState["ordered"] = 1] = "ordered";
    OrderState[OrderState["confirmed"] = 2] = "confirmed";
    OrderState[OrderState["delivered"] = 3] = "delivered";
    OrderState[OrderState["paid"] = 4] = "paid";
})(OrderState = exports.OrderState || (exports.OrderState = {}));
//# sourceMappingURL=orderState.js.map