(function (app) {

    app.controller('roomAddController', roomAddController);

    roomAddController.$inject = ['apiService', '$scope', '$state'];

    function roomAddController(apiService, $scope, $state) {
        $scope.department = {
            CreatedDate: new Date(),
            Status: true
        }

        $scope.AddRoom = AddRoom;

        function AddRoom() {
            apiService.post('api/room/create', $scope.room, function (result) {
                $state.go('rooms')
            }, function (error) {
                console.log('Add room fail')
            });
        }

        function loadAllDepartment() {
            apiService.get('api/department/getalldepartment', null, function (result) {
                $scope.allDepartment = result.data;
            }, function () {
                console.log('Cannot get list parent');
            });
        }

        loadAllDepartment();
    }

})(angular.module('xephang.rooms'));