/// <reference path="D:\CN7\SWD\Git\XepHang\XepHang.Web\Assets/admin/libs/angular/angular.js" />

(function () {
    angular.module('xephang.departments', ['xephang.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {
        $stateProvider.state('departments', {
            url: "/departments",
            templateUrl: "/app/components/departments/departmentListView.html",
            controller: "departmentListController"
        }).state('department_add', {
            url: "/department_add",
            templateUrl: "/app/components/departments/departmentAddView.html",
            controller: "departmentAddController"
        });
    }
})();