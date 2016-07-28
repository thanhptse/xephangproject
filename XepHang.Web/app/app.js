/// <reference path="D:\CN7\SWD\Git\XepHang\XepHang.Web\Assets/admin/libs/angular/angular.js" />

(function () {
    angular.module('xephang',
        ['xephang.departments',
         'xephang.rooms',
         'xephang.common'])
        .config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {
        $stateProvider
            .state('base', {
                url: '',
                templateUrl: 'app/share/views/baseView.html',
                abstract: true
            })
            .state('login', {
                url: "/login",
                templateUrl: "/app/components/login/loginView.html",
                controller: "loginController"
            })
            .state('home', {
                url: "/admin",
                parent:'base',
            templateUrl: "/app/components/home/homeView.html",
            controller: "homeController"
        });

        $urlRouterProvider.otherwise('/login');
    }
})();