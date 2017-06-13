(function () {
    'use-strict';

    var app = angular.module('appHotelReservation', ['ngAnimate', 'ngSanitize', 'ui.router', 'ui.bootstrap']);

    angular.element(document).ready(function () {
        angular.bootstrap(document, ['appHotelReservation']);
    });
})();