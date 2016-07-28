(function (app) {

    app.controller('departmentAddController', departmentAddController);

    departmentAddController.$inject = ['apiService', '$scope', '$state'];

    $scope.AddDepartment = AddDepartment;

    function departmentAddController(apiService, $scope, $state) {
        $scope.department = {
            CreatedDate: new Date(),
            Status: true
        }
    }

    function AddDepartment() {
        apiService.post('api/department/post', $scope.department, function (result) {
            $state.go('departments')
        }, function (error) {
            
        });
    }

})(angular.module('xephang.departments'));