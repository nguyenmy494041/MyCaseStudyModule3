themoi = (function (value) {
    if (value == 1) {
        $("#quathoinuoc").show();
        $("#maylocnuoc").hide();
        $("#binhnonglanh").hide();
    } else if (value == 2) {
        $("#quathoinuoc").hide();
        $("#maylocnuoc").show();
        $("#binhnonglanh").hide();
    } else if (value == 3) {
        $("#quathoinuoc").hide();
        $("#binhnonglanh").show();
        $("#maylocnuoc").hide();
    } else {
        $("#quathoinuoc").hide();
        $("#binhnonglanh").hide();
        $("#maylocnuoc").hide();
    }
})

$(document).ready(function () {
    $("#quathoinuoc").hide();
    $("#binhnonglanh").hide();
    $("#maylocnuoc").hide();
})