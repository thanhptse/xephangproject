(function (app) {

    app.controller('roomEditController', roomEditController);

    roomEditController.$inject = ['apiService', '$scope', '$state', '$stateParams'];

    function roomEditController(apiService, $scope, $state, $stateParams) {
        $scope.room = {
            CreatedDate: new Date(),
            Status: true
        }

        $scope.UpdateRoom = UpdateRoom;

        function UpdateRoom() {
            apiService.put('api/room/update', $scope.room, function (result) {
                $state.go('rooms')
            }, function (error) {
                console.log('Update room fail');;
            });
        }

        function LoadRoomDetail() {
            apiService.get('api/room/getbyid/' + $stateParams.id, null, function (result) {
                $scope.room = result.data;
            }, function (error) {
                console.log('Load room fail');
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

        LoadRoomDetail();
    }

})(angular.module('xephang.rooms'));