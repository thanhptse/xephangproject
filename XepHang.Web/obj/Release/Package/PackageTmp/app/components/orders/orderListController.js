(function (app) {

    app.controller('orderListController', orderListController);

    orderListController.$inject = ['$scope', 'apiService', '$ngBootbox'];

    function orderListController($scope, apiService, $ngBootbox) {
        $scope.orders = [];
        $scope.page = 0;
        $scope.pagesCount = 0;;
        $scope.getListOrders = getListOrders;

        $scope.deleteOrder = deleteOrder;

        function deleteOrder(id) {
            $ngBootbox.confirm('Bạn có chắc muốn xóa không?').then(function () {
                var config = {
                    params: {
                        id: id
                    }
                }
                apiService.del('api/order/delete', config, function () {
                    $ngBootbox.alert('Xóa thành công');
                    getListOrders();
                }, function () {
                    console.log('Xóa không thành công');
                })
            });
        }

        function getListOrders(page) {
            page = page || 0;
            var config = {
                params: {
                    page: page,
                    pageSize: 10
                }
            }
            apiService.get('/api/order/getall', config, function (result) {
                $scope.orders = result.data.Items;
                $scope.page = result.data.Page;
                $scope.pagesCount = result.data.TotalPages;
                $scope.totalCount = result.data.TotalCount;
            }, function (error) {
                console.log('Load order fail');
            });
        }

        $scope.getListOrders();
    }

})(angular.module('xephang.orders'));