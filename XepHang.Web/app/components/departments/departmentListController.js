(function (app) {

    app.controller('departmentListController', departmentListController);

    departmentListController.$inject = ['$scope', 'apiService', '$ngBootbox'];

    function departmentListController($scope, apiService, $ngBootbox) {
        $scope.departments = [];
        $scope.page = 0;
        $scope.pagesCount = 0;;
        $scope.getListDepartments = getListDepartments;

        $scope.deleteDepartment = deleteDepartment;

        function deleteDepartment(id) {
            $ngBootbox.confirm('Các phòng liên quan đến khoa này sẽ bị xóa hết. Bạn có chắc muốn xóa không?').then(function () {
                var config = {
                    params: {
                        id: id
                    }
                }
                apiService.del('api/department/delete', config, function () {
                    $ngBootbox.alert('Xóa thành công');
                    getListDepartments();
                }, function () {
                    console.log('Xóa không thành công');
                })
            });
        }

        function getListDepartments(page) {
            page = page || 0;
            var config = {
                params: {
                    page: page,
                    pageSize: 10
                }
            }
            apiService.get('/api/department/getall', config, function (result) {
                $scope.departments = result.data.Items;
                $scope.page = result.data.Page;
                $scope.pagesCount = result.data.TotalPages;
                $scope.totalCount = result.data.TotalCount;
            }, function (error) {
                console.log('Load department fail');
            });
        }


        $scope.getListDepartments();
    }

})(angular.module('xephang.departments'));