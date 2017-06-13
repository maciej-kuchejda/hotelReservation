(function () {
    'use strict';

    angular
        .module('appHotelReservation')
        .factory('reservationService', reservation);

    reservation.$inject = ['$http'];

    function reservation($http) {
        var _urlGetDetails = "api/reservation/getDetails";
        var _urlAddReservation = "api/reservation/addReservation";
        var service = {
            getDetails: _getDetails,
            addReservation: _addReservation
        };

        return service;

        function _getDetails(data) {
            return $http.get(_urlGetDetails, { params: data });
        }
        function _addReservation(request) {
            return $http.post(_urlAddReservation, request );
        }
    }
})();