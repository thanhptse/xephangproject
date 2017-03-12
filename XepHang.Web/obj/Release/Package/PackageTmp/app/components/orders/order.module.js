/// <reference path="D:\CN7\SWD\Git\XepHang\XepHang.Web\Assets/admin/libs/angular/angular.js" />

(function () {
    angular.module('xephang.orders', ['xephang.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {
        $stateProvider.state('orders', {
            url: "/orders",
            parent: 'base',
            templateUrl: "/app/components/orders/orderListView.html",
            controller: "orderListController"
        }).state('order_add', {
            url: "/order_add",
            parent: 'base',
            templateUrl: "/app/components/orders/orderAddView.html",
            controller: "orderAddController"
        }).state('order_edit', {
            url: "/order_edit/:id",
            parent: 'base',
            templateUrl: "/app/components/orders/orderEditView.html",
            controller: "orderEditController"
        });
    }
})();