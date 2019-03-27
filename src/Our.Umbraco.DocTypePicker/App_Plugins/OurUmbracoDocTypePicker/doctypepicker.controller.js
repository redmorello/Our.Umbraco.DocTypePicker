angular.module("umbraco")
    .controller("OurUmbracoDocTypePicker.DocTypePicker", function ($scope, $http) {

        $scope.doctypes = [];
        $scope.model.value = $scope.model.value || [];

        $http.get("backoffice/OurUmbracoDocTypePicker/DocTypePickerApi/GetAllDocumentTypes").then(function (response) {

            $scope.doctypes = response.data;

            if ($scope.model.config.listtype == 'multi') {
                for (var i = 0; i < $scope.model.value.length; i++) {
                    for (var j = 0; j < $scope.doctypes.length; j++) {
                        if ($scope.model.value[i] === $scope.doctypes[j].id) {
                            $scope.doctypes[j].checked = true;
                            break;
                        }
                    }
                }
            } else {
                for (var j = 0; j < $scope.doctypes.length; j++) {
                    if ($scope.model.value == $scope.doctypes[j].id) {
                        $scope.doctypes[j].selected = true;
                        break;
                    }
                }
            }

            $scope.$watch("doctypes", function (newValue, oldValue) {

                if (newValue === oldValue)
                    return;

                $scope.model.value = [];

                for (var j = 0; j < $scope.doctypes.length; j++) {
                    if ($scope.doctypes[j].checked) {
                        $scope.model.value.push($scope.doctypes[j].id);
                    }
                }

            }, true);

            $scope.changedValue = function(item) {
                $scope.model.value = item;
            };

        });

    });