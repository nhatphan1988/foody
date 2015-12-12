myApp.controller('menuCtr', ['$rootScope', '$cartItems', '$scope', function ($rootScope,$cartItems, $scope) {

    $rootScope.cartItems = $cartItems;

    $rootScope.addCartItem = function (cartItem)
    {
        if (typeof cartItem != 'object') {
            cartItem = JSON.parse(cartItem);
        }
        var check = _.some($rootScope.cartItems, function (el) {
            if (el.Name === cartItem.Name && el.Number<99 && el.Number>=1)
            {
                el.Number++;
            }

            return (el.Name === cartItem.Name)
        });

        if (!check)
        {
            cartItem.Number = 1;
            $rootScope.cartItems.push(cartItem);
        }
        
    }

    $rootScope.removeCartItem = function (cartItem) {
        if (typeof cartItem != 'object') {
            cartItem = JSON.parse(cartItem);
        }
        $rootScope.cartItems = _.reject($rootScope.cartItems, function (el) {
            if (el.Name === cartItem.Name && el.Number > 0) {
                el.Number--;
            }
            if (el.Name === cartItem.Name && el.Number <= 0)
                return true;
        });
    }
}]);
