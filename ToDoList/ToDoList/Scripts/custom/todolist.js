angular.module("todolist", [])
    /*.directive("oneIce", function () {
        return {
            restrict: "E",
            template: "<span>just smile {{mysrc}}</span>",
            scope: { mysrc: "=" }
        };
    })*/
    .controller("todoforms", [
        "$scope", "$http",
        function ($scope, $http) {

            $scope.todoforms = [];

            /*$scope.postData = function () {
                $http.post('/Home/SaveImage/', $scope.imagesWithCommentaries);
            };*/

            $scope.removeTask = function (parentIndex, index) {
                $scope.todoforms[parentIndex].Tasks.splice(index, 1);
            };

            $scope.deleteForm = function (index) {
                alert(index);
            };

            $scope.addTask = function (currentFormIndex) {
                $scope.todoforms[currentFormIndex].Tasks.push({
                    Content: ""
                })
            };

            function init() {
                $http.get("/api/todolist/").then(function (response) {
                    $scope.todoforms = response.data;
                    console.dir($scope.todoforms);
                });
            };

            init();
        }
    ])