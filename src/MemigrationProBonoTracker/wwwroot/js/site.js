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