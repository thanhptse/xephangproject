/// <reference path="D:\CN7\SWD\Git\XepHang\XepHang.Web\Assets/admin/libs/angular/angular.js" />

(function () {
    angular.module('xephang.departments', ['xephang.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {
        $stateProvider
            .state('departments', {
                url: "/departments",
                parent:'base',
                templateUrl: "/app/components/departments/departmentListView.html",
                controller: "departmentListController"
            }).state('department_add', {
                url: "/department_add",
                parent: 'base',
                templateUrl: "/app/components/departments/departmentAddView.html",
                controller: "departmentAddController"
            }).state('department_edit', {
                url: "/department_edit/:id",
                parent: 'base',
                templateUrl: "/app/components/departments/departmentEditView.html",
                controller: "departmentEditController"
            });
    }
})();