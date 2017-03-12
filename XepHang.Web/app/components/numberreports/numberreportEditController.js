(function (app) {

    app.controller('numberreportEditController', numberreportEditController);

    numberreportEditController.$inject = ['apiService', '$scope', '$state', '$stateParams'];

    function numberreportEditController(apiService, $scope, $state, $stateParams) {
        $scope.numberreport = {
            CreatedDate: new Date(),
            Status: true
        }

        $scope.UpdateNumberreport = UpdateNumberreport;

        function UpdateNumberreport() {
            apiService.put('api/numberreport/update', $scope.numberreport, function (result) {
                $state.go('numberreports')
            }, function (error) {
                console.log('Update report fail');;
            });
        }

        function LoadNumberreportDetail() {
            apiService.get('api/numberreport/getbyid/' + $stateParams.id, null, function (result) {
                $scope.numberreport = result.data;
            }, function (error) {
                console.log('Load report fail');
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

        LoadNumberreportDetail();
    }

})(angular.module('xephang.numberreports'));