$(document).ready(function () {
   
    $('.submitAjaxPost').click(function (event) {

        var actionUrl, formToPost, submitButton;
        event.preventDefault;
        submitButton = $(this);
        $(this).attr("disabled", "true");
        formToPost = $(this).parent('form');
        actionUrl = formToPost.attr('action');

      
        $.post(actionUrl, formToPost.serialize(), function (data) {
            $('.modalMessageWindow').toggle();
            setTimeout(function () { location.href = data.message }, 1000);

        }).complete(function () {
            return submitButton.removeAttr("disabled");
        });

        $(this).removeAttr("disabled");

        return false;
    });
});


$(document).ready(function () {

    $('#priceList input').change(function (event) {
        console.log(($(this).val()));
        console.log(($(this).parent().find('.id').val()));

        var priceChange = new Object();
        priceChange.ProductId = $(this).parent().find('.id').val();
        priceChange.NewPrice = $(this).val();

        $("#commandsInQueue").append('<li id="' + priceChange.ProductId + '-' + priceChange.NewPrice + '"> Product with Id ' + priceChange.ProductId + ' to new price ' + priceChange.NewPrice + ' </li>');
        q.add(priceChange);
    });

    // Create a new queue.
    var q = $.jqmq({
        delay: 3000,
        callback: function (item) {
            $.post('/Product/UpdatePrice', item, function (data) {

            }).complete(function () {
                $('#' + item.ProductId + '-' + item.NewPrice).remove();
            });
        }

    });
});

