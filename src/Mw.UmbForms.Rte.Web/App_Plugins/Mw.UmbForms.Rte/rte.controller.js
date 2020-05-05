(function () {
	function mwRteController($scope, dataTypeResource) {
		"use strict";
		$scope.htmfield = [];
		dataTypeResource.getByName('Form RTE').then(function (d) {
			$scope.htmfield = [{
				alias: "htmfield",
				label: "Html",
				view: "rte",
				config: {
					editor: d.preValues[0].value
				},
				value: $scope.setting.value
			}];

			$scope.$watch("htmfield", function () {
				if (typeof $scope.htmfield !== 'undefined') {
					$scope.setting.value = $scope.htmfield[0].value;
				}
			}, true);
		});
	}
	angular.module("umbraco").controller("mw.umbFormsRteController", mwRteController);
})();