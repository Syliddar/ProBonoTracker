// Write your Javascript code.

$().ready(function () {
    initDatePickers();

});


function initDatePickers() {
    $(".datepicker")
            .datepicker({
                format: "dd-M-yyyy",
                startDate: "-1d",
                todayBtn: "linked",
                autoclose: true,
                todayHighlight: true
            });
}