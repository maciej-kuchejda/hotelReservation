(function () {
    'use strict';

    angular
        .module('appHotelReservation')
        .factory('searchService', search);

    search.$inject = ['$http'];

    function search($http) {
        var _urlSearch = "api/Search/Search";
        var service = {
            search: _search
        };

        return service;

        function _search(data) {
            return $http.get(_urlSearch, { params: data });
        }
    }
})();