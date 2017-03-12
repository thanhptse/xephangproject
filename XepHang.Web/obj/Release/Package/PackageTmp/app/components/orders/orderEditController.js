(function (app) {

    app.controller('orderEditController', orderEditController);

    orderEditController.$inject = ['apiService', '$scope', '$state', '$stateParams'];

    function orderEditController(apiService, $scope, $state, $stateParams) {
        $scope.order = {
            CreatedDate: new Date(),
            Status: true
        }

        $scope.UpdateOrder = UpdateOrder;

        function UpdateOrder() {
            apiService.put('api/order/update', $scope.order, function (result) {
                $state.go('orders')
            }, function (error) {
                console.log('Update order fail');;
            });
        }

        function LoadOrderDetail() {
            apiService.get('api/order/getbyid/' + $stateParams.id, null, function (result) {
                $scope.order = result.data;
            }, function (error) {
                console.log('Load order fail');
            });
        }

        function loadAllRoom() {
            apiService.get('api/room/getallroom', null, function (result) {
                $scope.allRoom = result.data;
            }, function () {
                console.log('Cannot get list parent');
            });
        }

        loadAllRoom();

        LoadOrderDetail();
    }

})(angular.module('xephang.orders'));