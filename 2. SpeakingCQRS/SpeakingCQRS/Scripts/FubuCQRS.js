$(document).ready(function () {
    alert('document ready')

    $('.submitAjaxPost').click(function (event) {

        var actionUrl, formToPost, submitButton;
        event.preventDefault;
        submitButton = $(this);
        $(this).attr("disabled", "true");
        formToPost = $(this).parent('form');
        actionUrl = formToPost.attr('action');

        alert(actionUrl);

        $.post(actionUrl, formToPost.serialize(), function (data) {
           
            $('.modalMessageWindow').toggle();
            setTimeout(function () { location.href = data.message }, 5000);

        }).complete(function () {
            return submitButton.removeAttr("disabled");
        });

        $(this).removeAttr("disabled");

        return false;
    });


});

