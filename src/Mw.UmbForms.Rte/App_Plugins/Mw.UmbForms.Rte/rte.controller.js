(function () {
	"use strict";
	angular.module("umbraco").controller("mw.umbFormsRteController", ($scope, $http) => {

		$http.get("/umbraco/backoffice/FormsRte/FormsRteApi/GetDataType").then(function (res) {

			var d = res.data;

			angular.extend(this, {
				htmfield: [{
					alias: "htmfield",
					label: "Html",
					view: "rte",
					config: {
						editor: d.preValues[0].value
					},
					value: $scope.setting.value
				}]
			});

			//$scope.$watch("htmfield", function () {
			//	if ($scope.htmfield != undefined) {
			//		$scope.setting.value = $scope.htmfield[0].value;
			//	}
			//}, true);
			$scope.$watch(() => this.htmfield, function (newVal) {
				console.log(newVal, this.setting.value)
				//if (newVal != undefined) {
				//	this.setting.value = newVal[0].value;
				//}
			});
		});
	});
})();