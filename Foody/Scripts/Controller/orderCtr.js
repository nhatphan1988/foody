myApp.controller('orderCtr', ['$rootScope', '$scope', function ($rootScope, $scope) {
    $scope.sumPrice = function () {
        return _.reduce($rootScope.cartItems, function (memo, cartItem) { return memo + cartItem.Price * (cartItem.Number); }, 0);
    }
}]);

myApp.factory('$cartItems', [function () {
    var cartItems = [];
    return cartItems;
}]);