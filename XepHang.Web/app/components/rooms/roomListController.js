(function (app) {

    app.controller('roomListController', roomListController);

    roomListController.$inject = ['$scope', 'apiService', '$ngBootbox'];

    function roomListController($scope, apiService, $ngBootbox) {
        $scope.rooms = [];
        $scope.page = 0;
        $scope.pagesCount = 0;;
        $scope.getListRooms = getListRooms;

        $scope.deleteRoom = deleteRoom;

        function deleteRoom(id) {
            $ngBootbox.confirm('Bạn có chắc muốn xóa không?').then(function () {
                var config = {
                    params: {
                        id: id
                    }
                }
                apiService.del('api/room/delete', config, function () {
                    $ngBootbox.alert('Xóa thành công');
                    getListRooms();
                }, function () {
                    console.log('Xóa không thành công');
                })
            });
        }

        function getListRooms(page) {
            page = page || 0;
            var config = {
                params: {
                    page: page,
                    pageSize: 10
                }
            }
            apiService.get('/api/room/getall', config, function (result) {
                $scope.rooms = result.data.Items;
                $scope.page = result.data.Page;
                $scope.pagesCount = result.data.TotalPages;
                $scope.totalCount = result.data.TotalCount;
            }, function (error) {
                console.log('Load room fail');
            });
        }

        $scope.getListRooms();
    }

})(angular.module('xephang.rooms'));