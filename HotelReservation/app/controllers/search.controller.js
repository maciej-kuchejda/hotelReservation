(function () {
    'use strict';

    angular
        .module('appHotelReservation')
        .controller('searchController', search);

    search.$inject = ['$state', '$stateParams', 'searchService'];

    function search($state, $stateParams, searchService) {
        console.log($stateParams);
        /* jshint validthis:true */
        var vm = this;
        if ($stateParams.searchData != null) {
            searchService.search($stateParams.searchData).then(_successData, _errorData);
        }
        function _successData(response) {
            vm.data = response.data.data;
        }
        function _errorData(response) {
            console.log(response)
        }
        vm.addReservation = function (item) {
            var data = $stateParams.searchData;
            data.roomId = item.roomId;
            $state.go('addReservation', {data: data});
        }
    }
})();
