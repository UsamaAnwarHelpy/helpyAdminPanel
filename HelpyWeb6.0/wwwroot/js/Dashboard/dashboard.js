$(document).ready(function () {
    let selectedItems = [];

    $('#SelectedItems').on('click', '.option-button', function () {
        const itemId = parseInt($(this).data('id'), 10);
        if ($(this).hasClass('selected')) {
            $(this).removeClass('selected');
            selectedItems = selectedItems.filter(id => id !== itemId);
        } else {
            $(this).addClass('selected');
            selectedItems.push(itemId);
        }
    });
    $('#saveUser').on('click', function () {
        var formData = new FormData($('#registrationForm')[0]);

        $.ajax({
            url: '/Home/Register', // Change the URL if your controller route differs
            type: 'POST',
            data: formData,
            processData: false,
            contentType: false,
            success: function (response) {
                if (response.success) {
                    $('#result').html('<p style="color: green;">' + response.message + '</p>');
                } else {
                    $('#result').html('<p style="color: red;">' + response.errors.join('<br>') + '</p>');
                }
            },
            error: function (xhr) {
                $('#result').html('<p style="color: red;">An error occurred: ' + xhr.statusText + '</p>');
            }
        });
    });
});
