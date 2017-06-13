(function () {
    'use strict';

    angular
        .module('appHotelReservation')
        .controller('reservationController', reservation);

    reservation.$inject = ['$state','$stateParams', 'reservationService'];

    function reservation($state, $stateParams, reservationService) {
        /* jshint validthis:true */
        var vm = this;
        vm.title = 'reservation';
        vm.reservationData = $stateParams.data;
        reservationService.getDetails($stateParams.data).then(_successData,_errorData);

        vm.addReservation = function () {
            vm.reservationData.phase = 1;
            reservationService.addReservation(vm.reservationData).then(_success, _error);
            $state.go('home');
        }
        vm.cancelReservation = function () {
            $state.go('home');
        }
        function _success(response) {
            console.log(response);
        }
        function _error(response) {
            console.log(response);
        }
        function _successData(response) {
            vm.data = response.data.data;
        }
        function _errorData(response) {
            console.log(response)
        }

    }
})();
