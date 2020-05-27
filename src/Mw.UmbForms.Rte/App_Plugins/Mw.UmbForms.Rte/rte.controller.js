(function () {
    "use strict";
    angular.module("umbraco").controller("mw.umbFormsRteController", function (
        $scope,
        $http) {
        $http.get("backoffice/FormsRte/FormsRteApi/GetDataType").then(function (res) {
            var d = res.data;
            $scope.htmfield = [
                {
                    alias: "htmfield",
                    label: "Html",
                    view: "rte",
                    editor: "Umbraco.TinyMCE",
                    config: {
                        editor: d.preValues[0].value,
                    },
                    value: $scope.setting.value,
                }
            ];

            $scope.$watch(
                "htmfield",
                function () {
                    if (typeof $scope.htmfield !== 'undefined') {
                        $scope.setting.value = $scope.htmfield[0].value;
                    }
                }, true);
        });
    });
})();
