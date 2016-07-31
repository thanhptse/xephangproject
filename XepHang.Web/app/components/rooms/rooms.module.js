/// <reference path="D:\CN7\SWD\Git\XepHang\XepHang.Web\Assets/admin/libs/angular/angular.js" />

(function () {
    angular.module('xephang.rooms', ['xephang.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {
        $stateProvider.state('rooms', {
            url: "/rooms",
            parent: 'base',
            templateUrl: "/app/components/rooms/roomListView.html",
            controller: "roomListController"
        }).state('room_add', {
            url: "/room_add",
            parent: 'base',
            templateUrl: "/app/components/rooms/roomAddView.html",
            controller: "roomAddController"
        }).state('room_edit', {
            url: "/room_edit/:id",
            parent: 'base',
            templateUrl: "/app/components/rooms/roomEditView.html",
            controller: "roomEditController"
        });
    }
})();