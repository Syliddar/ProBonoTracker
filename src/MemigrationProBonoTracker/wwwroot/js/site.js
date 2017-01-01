// Write your Javascript code.

$().ready(function () {
    $("#ajaxLoader").hide();
    initDatePickers();
    $(document).bind("ajaxSend", function () {
        console.log('start');
        $("#ajaxLoader").show();
    }).bind("ajaxComplete", function () {
        console.log('end');
        $("#ajaxLoader").hide();
    });
});


function initDatePickers() {
    $(".datepicker").datepicker({
        format: "mm-dd-yyyy",
        startDate: "-1d",
        todayBtn: "linked",
        autoclose: true,
        todayHighlight: true
    });
}
function PersonContactInfoModal(personId) {
    $.ajax({
        url: '/People/PersonContactPartial/?id=' + personId,
        success: function (data) {
            $('#modalWrapper').html(data);
        }
    });
}

function AttorneyContactInfoModal(attorneyId) {
    $.ajax({
        url: '/Attorney/GetAttorneyContactInfoPartial/?id=' + attorneyId,
        success: function (data) {
            $('#modalWrapper').html(data);
        }
    });
}