$(document).ready(function () {

    $("#Go").bind("click", function () {
        var supplierId = $("#supplierToFind").prop("value");
        $("#invoice").load("/Invoice/Details/" + supplierId);
    });

});