(function (app) {

    app.controller('departmentListController', departmentListController);

    departmentListController.$inject = ['$scope', 'apiService'];

    function departmentListController($scope, apiService) {
        $scope.departments = [];
        $scope.page = 0;
        $scope.pagesCount = 0;;
        $scope.getListDepartments = getListDepartments;

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