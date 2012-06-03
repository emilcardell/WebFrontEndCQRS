$(document).ready(function () {
    
    $('.submitAjaxPost').click(function (event) {

        var actionUrl, formToPost, submitButton;
        event.preventDefault;
        submitButton = $(this);
        $(this).attr("disabled", "true");
        formToPost = $(this).parent('form');
        actionUrl = formToPost.attr('action');



        $.post(actionUrl, formToPost.serialize(), function (data) {

            //Success
            $('.modalMessageWindow').toggle();

            setInterval(function (dataTo) {
                    console.log('doing post on ' + data.exists);
                    $.get(dataTo.exists, function (existsData) {
                        if (existsData.success) {
                            location.href = data.message;
                        }
                    });
                }, 500, data);

        }).complete(function () {

           
                
            

            return submitButton.removeAttr("disabled");
        });

        $(this).removeAttr("disabled");

        return false;
    });


});

