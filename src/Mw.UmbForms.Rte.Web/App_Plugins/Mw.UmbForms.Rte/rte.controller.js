(function () {
	function mwRteController($scope, $http) {
		"use strict";
		$scope.htmfield = [];
		$http.get("/umbraco/backoffice/FormsRte/FormsRteApi/GetByName/?name=Form RTE").then(function (res) {
		    var d = res.data;
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
				if ($scope.htmfield != undefined) {
					$scope.setting.value = $scope.htmfield[0].value;
				}
			}, true);
		});
	}
	angular.module("umbraco").controller("mw.umbFormsRteController", mwRteController);
})();