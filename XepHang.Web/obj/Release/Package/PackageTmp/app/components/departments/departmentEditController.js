(function (app) {

    app.controller('departmentEditController', departmentEditController);

    departmentEditController.$inject = ['apiService', '$scope', '$state', '$stateParams'];

    function departmentEditController(apiService, $scope, $state, $stateParams) {
        $scope.department = {
            CreatedDate: new Date(),
            Status: true
        }

        $scope.UpdateDepartment = UpdateDepartment;

        function UpdateDepartment() {
            apiService.put('api/department/update', $scope.department, function (result) {
                $state.go('departments')
            }, function (error) {
                console.log('Update department fail');;
            });
        }

        function LoadDepartmentDetail() {
            apiService.get('api/department/getbyid/' + $stateParams.id, null, function (result) {
                $scope.department = result.data;
            }, function (error) {
                console.log('Load department fail');
            });
        }

        LoadDepartmentDetail();
    }

})(angular.module('xephang.departments'));