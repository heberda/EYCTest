$(document).ready(function () {
    $("#Go").bind("click", function () {
        var supplierId = $("#supplierToFind").prop("value");

        if (supplierId > 0) {
            $("#invoice").hide();
            var jqxhr = $.ajax("/Invoice/Get/" + supplierId)
            .done(function (data) {
                $("#ajaxError").hide();
                $('#invoice').html(data);
                $("#invoice").fadeIn();
            })
            .fail(function () {
                $("#ajaxError").show();
            })
            .always(function () {
                $('#supplierToFind').val(0);
            });
        }
        else
        {
            alert("If I'm not mistaken, you haven't selected a supplier...");
        }
    });
});