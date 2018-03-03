// Write your Javascript code.

$().ready(function () {
    $("#ajaxLoader").hide();
    //initDatePickers();
    $(document).bind("ajaxSend", function () {
        $("#ajaxLoader").show();
    }).bind("ajaxComplete", function () {
        $("#ajaxLoader").hide();
    });
});
function bindRemoveEventRow() {
    $(".caseEventEdit").click(function () {
        var id = this.id;
        $.ajax({
            url: '/Case/EditCaseEventPartial/',
            data: { eventId: id },
            type: 'POST',
            success: function (data) {
                $('#modalWrapper').html(data);
            }
        });
    });
    $(".caseEventRemove")
        .click(function () {
            if (confirm('Are you sure you want to delete this Case Event?')) {
                var id = this.id;
                $.ajax({
                    url: '/Case/DeleteCaseEvent/',
                    data: { id: id },
                    type: 'POST'
                });
                var tr = $(this).closest('tr');
                tr.css("background-color", "#FF3700");
                tr.fadeOut(400,
                    function () {
                        tr.remove();
                        $('#CaseEventsTable tr:last-child td:last-child button').removeAttr("disabled");
                    });
            }
        });
}

//function initDatePickers() {
//    $(".datepickerfuture").datepicker({
//        format: "mm/dd/yyyy",
//        startDate: "-1d",
//        todayBtn: "linked",
//        keyboardNavigation: "true",
//        autoclose: true,
//        todayHighlight: true
//    });
//    $(".datepickerpast").datepicker({
//        format: "mm/dd/yyyy",
//        startDate: "1/1/1900",
//        endDate: "0d",
//        todayBtn: "linked",
//        keyboardNavigation: "true",
//        autoclose: true,
//        todayHighlight: true
//    });
//    $(".datepicker").datepicker({
//        format: "mm/dd/yyyy",
//        startDate: "1/1/1900",
//        todayBtn: "linked",
//        keyboardNavigation: "true",
//        autoclose: true,
//        todayHighlight: true
//    });
//}

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
//function LaunchAssPersonSearchModal() {
//    $.ajax({
//        url: '/People/AssociatedPersonLookupPartial/',
//        success: function (data) {
//            $('#modalWrapper').html(data);
//        }
//    });
//}
/*
Rest of file copy-pasted directly from the internet, don't ask me. 
*/

//In accordance with prophecy, this allows the datatables to put empty values at the bottom when sorting columns 
(function (factory) {
    if (typeof define === "function" && define.amd) {
        define(["jquery", "moment", "datatables.net"], factory);
    } else {
        factory(jQuery, moment);
    }
}
(function ($, moment) {

    $.fn.dataTable.moment = function (format, locale) {
        var types = $.fn.dataTable.ext.type;
        types.detect.unshift(function (d) {
            if (d) {
                if (d.replace) {
                    d = d.replace(/(<.*?>)|(\r?\n|\r)/g, '');
                }
                d = $.trim(d);
            }
            if (d === '' || d === null) {
                return 'moment-' + format;
            }
            return moment(d, format, locale, true).isValid() ?
                'moment-' + format :
                null;
        });
        types.order['moment-' + format + '-pre'] = function (d) {
            if (d) {
                if (d.replace) {
                    d = d.replace(/(<.*?>)|(\r?\n|\r)/g, '');
                }
                d = $.trim(d);
            }
            return d === '' || d === null ?
                -Infinity :
                parseInt(moment(d, format, locale, true).format('x'), 10);
        };
    };
}));
jQuery.extend(jQuery.fn.dataTableExt.oSort, {
    "non-empty-string-asc": function (str1, str2) {
        if (str1 === "")
            return 1;
        if (str2 === "")
            return -1;
        return ((str1 < str2) ? -1 : ((str1 > str2) ? 1 : 0));
    },

    "non-empty-string-desc": function (str1, str2) {
        if (str1 === "")
            return 1;
        if (str2 === "")
            return -1;
        return ((str1 < str2) ? 1 : ((str1 > str2) ? -1 : 0));
    }
});
