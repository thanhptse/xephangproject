(function (app) {

    app.controller('orderAddController', orderAddController);

    orderAddController.$inject = ['apiService', '$scope', '$state'];

    function orderAddController(apiService, $scope, $state) {
        $scope.order = {
            CreatedDate: new Date(),
            Status: true
        }

        $scope.AddOrder = AddOrder;

        function AddOrder() {
            apiService.post('api/order/create', $scope.order, function (result) {
                $state.go('orders')
            }, function (error) {
                console.log('Add order fail')
            });
        }

        function loadAllRoom() {
            apiService.get('api/room/getallroom', null, function (result) {
                $scope.allRoom = result.data;
            }, function () {
                console.log('Cannot get list room');
            });
        }

        loadAllRoom();
    }

})(angular.module('xephang.rooms'));