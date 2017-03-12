/// <reference path="D:\CN7\SWD\Git\XepHang\XepHang.Web\Assets/admin/libs/angular/angular.js" />

(function () {
    angular.module('xephang.numberreports', ['xephang.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {
        $stateProvider.state('numberreports', {
            url: "/numberreports",
            parent: 'base',
            templateUrl: "/app/components/numberreports/numberreportListView.html",
            controller: "numberreportListController"
        }).state('numberreport_edit', {
            url: "/numberreport_edit/:id",
            parent: 'base',
            templateUrl: "/app/components/numberreports/numberreportEditView.html",
            controller: "numberreportEditController"
        });
    }
})();