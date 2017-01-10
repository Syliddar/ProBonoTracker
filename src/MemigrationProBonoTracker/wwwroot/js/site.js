// Write your Javascript code.

$().ready(function () {
    $("#ajaxLoader").hide();
    initDatePickers();
    $(document).bind("ajaxSend", function () {
        $("#ajaxLoader").show();
    }).bind("ajaxComplete", function () {
        $("#ajaxLoader").hide();
    });
});


function initDatePickers() {
    $(".datepicker").datepicker({
        format: "mm/dd/yyyy",
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


/*
Rest of file copy-pasted directly from the internet, don't even ask me. 
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
        if (str1 == "")
            return 1;
        if (str2 == "")
            return -1;
        return ((str1 < str2) ? -1 : ((str1 > str2) ? 1 : 0));
    },

    "non-empty-string-desc": function (str1, str2) {
        if (str1 == "")
            return 1;
        if (str2 == "")
            return -1;
        return ((str1 < str2) ? 1 : ((str1 > str2) ? -1 : 0));
    }
});
