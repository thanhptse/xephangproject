(function (app) {

    app.controller('numberreportListController', numberreportListController);

    numberreportListController.$inject = ['$scope', 'apiService', '$ngBootbox'];

    function numberreportListController($scope, apiService, $ngBootbox) {
        $scope.orders = [];
        $scope.page = 0;
        $scope.pagesCount = 0;;
        $scope.getListNumberreports = getListNumberreports;

        $scope.deleteNumberreport = deleteNumberreport;

        function deleteNumberreport(id) {
            $ngBootbox.confirm('Bạn có chắc muốn xóa không?').then(function () {
                var config = {
                    params: {
                        id: id
                    }
                }
                apiService.del('api/numberreport/delete', config, function () {
                    $ngBootbox.alert('Xóa thành công');
                    getListNumberreports();
                }, function () {
                    console.log('Xóa không thành công');
                })
            });
        }

        function getListNumberreports(page) {
            page = page || 0;
            var config = {
                params: {
                    page: page,
                    pageSize: 10
                }
            }
            apiService.get('/api/numberreport/getall', config, function (result) {
                $scope.numberreports = result.data.Items;
                $scope.page = result.data.Page;
                $scope.pagesCount = result.data.TotalPages;
                $scope.totalCount = result.data.TotalCount;
            }, function (error) {
                console.log('Load number report fail');
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
        $scope.getListNumberreports();
    }

})(angular.module('xephang.numberreports'));