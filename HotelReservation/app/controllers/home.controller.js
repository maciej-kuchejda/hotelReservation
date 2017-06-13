(function () {
    'use strict';

    angular
        .module('appHotelReservation')
        .controller('homeController', home);

    home.$inject = ['$state']; 

    function home($state) {
        var vm = this;

        vm.searchData = {};

        vm.navigateToSearch = function () {
            $state.go('searchState', { searchData: vm.searchData });
        }

        vm.options = {
            minDate: new Date(),
            showWeeks: true
        };
    }
})();
