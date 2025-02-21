function setError(id, message) {
    var fieldid = $("#" + id + "");

    //alert(id);
    var span = $("span[data-valmsg-for=\"" + id + "\"]");

    if (span && span.length > 0) {
        $(span).html(message);
        $(fieldid).addClass("is-invalid");
        if (message && message != "") {
            $(span).removeClass("field-validation-valid");
            $(span).addClass("field-validation-no-valid");
        } else {
            $(span).removeClass("field-validation-no-valid");
            $(span).addClass("field-validation-valid");
        }
    }
}




var a = ['', 'ONE ', 'TWO ', 'THREE ', 'FOUR ', 'FIVE ', 'SIX ', 'SEVEN ', 'EIGHT ', 'NINE ', 'TEN ', 'ELEVEN ', 'TWELVE ', 'THIRTEEN ', 'FOURTEEN ', 'FIFTEEN ', 'SIXTEEN ', 'SEVENTEEN ', 'EIGHTEEN ', 'NINTEEN '];
var b = ['', '', 'TWENTRY', 'THIRTY', 'FOURTY', 'FIFTY', 'SIXTY', 'SEVENTY', 'EIGHTY', 'NINETY'];

function inWordShow(trType, num) {
    //debugger;
    if ((num = num.toString()).length > 12) return 'overflow';
    n = ('000000000' + num).substr(-9).match(/^(\d{2})(\d{2})(\d{2})(\d{1})(\d{2})$/);
    if (!n) return; var str = '';
    str += (n[1] != 0) ? (a[Number(n[1])] || b[n[1][0]] + ' ' + a[n[1][1]]) + 'CRORE ' : '';
    str += (n[2] != 0) ? (a[Number(n[2])] || b[n[2][0]] + ' ' + a[n[2][1]]) + 'LAC ' : '';
    str += (n[3] != 0) ? (a[Number(n[3])] || b[n[3][0]] + ' ' + a[n[3][1]]) + 'THOUSAND ' : '';
    str += (n[4] != 0) ? (a[Number(n[4])] || b[n[4][0]] + ' ' + a[n[4][1]]) + 'HUNDRED ' : '';
    str += (n[5] != 0) ? ((str != '') ? 'AND ' : '') + (a[Number(n[5])] || b[n[5][0]] + ' ' + a[n[5][1]]) + 'TK. ONLY ' : '';

    document.getElementById('InWord').innerHTML = str;
    //document.getElementById(trType).onkeyup = function () {
        
    //};
}








function RemoveError() {
    $(".field-validation-error").text("");
    $(".field-validation-no-valid").text("");
    $("input").removeClass("is-invalid");

}

$(document).on('click', "#clear", function () {
    location.reload();
});


(function ($) {
    $.fn.characterCounter = function (params) {
        // merge default and user parameters
        params = $.extend({
            // define maximum characters
            maximumCharacters: 1000,
            // create typed character counter DOM element on the fly
            characterCounterNeeded: true,
            // create remaining character counter DOM element on the fly
            charactersRemainingNeeded: true,
            // chop text to the maximum characters
            chopText: false,
            // place character counter before input or textarea element
            positionBefore: false,
            // class for limit excess
            limitExceededClass: "character-counter-limit-exceeded",
            // suffix text for typed characters
            charactersTypedSuffix: " characters typed",
            // suffix text for remaining characters
            charactersRemainingSuffixText: " characters left",
            // whether to use the short format (e.g. 123/1000)
            shortFormat: false,
            // separator for the short format
            shortFormatSeparator: "/"
        }, params);

        // traverse all nodes
        this.each(function () {
            var $this = $(this),
                $pluginElementsWrapper,
                $characterCounterSpan,
                $charactersRemainingSpan;

            // return if the given element is not a textfield or textarea
            if (!$this.is("input[type=text]") && !$this.is("textarea")) {
                return this;
            }

            // create main parent div
            if (params.characterCounterNeeded || params.charactersRemainingNeeded) {
                // create the character counter element wrapper
                $pluginElementsWrapper = $('<div>', {
                    'class': 'character-counter-main-wrapper'
                });

                if (params.positionBefore) {
                    $pluginElementsWrapper.insertBefore($this);
                } else {
                    $pluginElementsWrapper.insertAfter($this);
                }
            }

            if (params.characterCounterNeeded) {
                $characterCounterSpan = $('<span>', {
                    'class': 'counter character-counter',
                    'text': 0
                });

                if (params.shortFormat) {
                    $characterCounterSpan.appendTo($pluginElementsWrapper);

                    var $shortFormatSeparatorSpan = $('<span>', {
                        'html': params.shortFormatSeparator
                    }).appendTo($pluginElementsWrapper);

                } else {
                    // create the character counter element wrapper
                    var $characterCounterWrapper = $('<div>', {
                        'class': 'character-counter-wrapper',
                        'html': params.charactersTypedSuffix
                    });

                    $characterCounterWrapper.prepend($characterCounterSpan);
                    $characterCounterWrapper.appendTo($pluginElementsWrapper);
                }
            }

            if (params.charactersRemainingNeeded) {

                $charactersRemainingSpan = $('<span>', {
                    'class': 'counter characters-remaining',
                    'text': params.maximumCharacters
                });

                if (params.shortFormat) {
                    $charactersRemainingSpan.appendTo($pluginElementsWrapper);
                } else {
                    // create the character counter element wrapper
                    var $charactersRemainingWrapper = $('<div>', {
                        'class': 'characters-remaining-wrapper',
                        'html': params.charactersRemainingSuffixText
                    });
                    $charactersRemainingWrapper.prepend($charactersRemainingSpan);
                    $charactersRemainingWrapper.appendTo($pluginElementsWrapper);
                }
            }

            $this.keyup(function () {

                var typedText = $this.val();
                var textLength = typedText.length;
                var charactersRemaining = params.maximumCharacters - textLength;

                // chop the text to the desired length
                if (charactersRemaining < 0 && params.chopText) {
                    $this.val(typedText.substr(0, params.maximumCharacters));
                    charactersRemaining = 0;
                    textLength = params.maximumCharacters;
                }

                if (params.characterCounterNeeded) {
                    $characterCounterSpan.text(textLength);
                }

                if (params.charactersRemainingNeeded) {
                    $charactersRemainingSpan.text(charactersRemaining);

                    if (charactersRemaining <= 0) {
                        if (!$charactersRemainingSpan.hasClass(params.limitExceededClass)) {
                            $charactersRemainingSpan.addClass(params.limitExceededClass);
                        }
                    } else {
                        $charactersRemainingSpan.removeClass(params.limitExceededClass);
                    }
                }
            });

        });

        // allow jQuery chaining
        return this;

    };
})(jQuery);


//New Date Format

$(".dateNew").focusout(function () {
    //debugger;
    var id = this.id;
    //alert(id);
    var date = $('#' + id).val();
    $('#' + id).attr('type', 'text');
    var isValid = moment(date, 'YYYY-MM-DD', true).isValid();
    if (isValid) {
        //$('#PDate').attr('type', 'text');
        var value1 = moment(date).format('DD-MMM-YYYY');
        //alert(value1);
        $('#' + id).val(value1);
    }
    else {

        $('#' + id).val('');
    }
});
$(".dateNew").focus(function () {
    //debugger;
    var id = this.id;
    var date = $('#' + id).val();

    $('#' + id).val("");
    $('#' + id).attr('type', 'date');
    var isValid = moment(date, 'DD-MMM-YYYY', true).isValid();
    if (isValid) {
        //$('#PDate').attr('type', 'text');
        var value1 = moment(date).format('YYYY-MM-DD');

        $('#' + id).val(moment(date).format('YYYY-MM-DD'));
    }
    else {

        $('#' + id).val('');
    }
});

//
