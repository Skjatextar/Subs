$(document).ready(function () {
    if (!Modernizr.input.placeholder) {
        var placeholderText = $('#search').attr('placeholder');

        $('#search').attr('value', placeholderText);
        $('#search').addClass('placeholder');

        $('#search').focus(function () {
            if (($('#search').val() == placeholderText)) {
                $('#search').attr('value', '');
                $('#search').removeClass('placeholder');
            }
        });

        $('#search').blur(function () {
            if (($('#search').val() == placeholderText) || (($('#search').val() == ''))) {
                $('#search').addClass('placeholder');
                $('#search').attr('value', placeholderText);
            }
        });
    }

});

function redirect() {
    window.location = "Request/RequestSubmit"
}
$(document).ready(function () {
    $('#button').on("click", function () {
        var selected = $('#HwType').val();
        var theData = $("#userForm").serialize();


        var form = $('form')[0];
        var formData = new FormData(form);

        $.ajax({
            type: "POST",
            url: selected + "/RequestSubmit",
            data: formData,
            contentType: false,
            cache: false,
            processData: false,
            success: function (response, status, xhr) {
                $('#partialPlaceHolder').html('');
                $('#messageHolder').html("Added to database");
                $('#but').html('');
                $('#HwType').val('choice');
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                $.each(jsonReponse, function (key, error) {

                    $('input[name="' + error.key + '"]').after(' ' + error.errors);

                });

                $('#messageHolder').html('Some fields were incorrect, please fix and resubmit');

            }
        })
    })})