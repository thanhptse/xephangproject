(function (app) {

    app.controller('departmentAddController', departmentAddController);

    departmentAddController.$inject = ['apiService', '$scope', '$state'];

    function departmentAddController(apiService, $scope, $state) {
        $scope.department = {
            CreatedDate: new Date(),
            Status: true
        }

        $scope.AddDepartment = AddDepartment;

        function AddDepartment() {
            apiService.post('api/department/create', $scope.department, function (result) {
                $state.go('departments')
            }, function (error) {
                console.log('Add department fail')
            });
        }

    }

})(angular.module('xephang.departments'));