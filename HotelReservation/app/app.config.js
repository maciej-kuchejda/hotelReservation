(function () {
    'use strict';

    angular
        .module('appHotelReservation')
        .config(['$stateProvider', '$urlRouterProvider', stateProviderConfig])
        .config(['$httpProvider', httpProviderConfig])

    function stateProviderConfig($stateProvider, $urlRouterProvider) {
        var homeState = {
            name: 'home',
            url: '/home',
            templateUrl: "Home/Index",
            controller: "homeController",
            controllerAs: "homeCtrl"
        };
        var searchState = {
            name: 'searchState',
            url: '/search/{searchData:json}',
            templateUrl: "Search/Index",
            controller: "searchController",
            controllerAs: "searchCtrl",
        };
        var addReservationState = {
            name: 'addReservation',
            url: '/reservation/addReservation/{data:json}',
            templateUrl: "Reservation/Index",
            controller: "reservationController",
            controllerAs: "ctrl",
            
        };

        $stateProvider.state(homeState);
        $stateProvider.state(searchState);
        $stateProvider.state(addReservationState);

        $urlRouterProvider.otherwise('/home');

    }
    function httpProviderConfig($httpProvider) {
        $httpProvider.defaults.withCredentials = true;
    }
})();