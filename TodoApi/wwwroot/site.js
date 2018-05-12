const uri = 'api/todo';
let todos = null;

$(document).ready(function () {
    getAllItems();
});

function getAllItems() {

    $.ajax({
        type: 'GET',
        accepts: 'application/json',
        url: uri,
        contentType: 'application/json',
        error: function (jqXHR, textStatus, errorThrown) {
            $("#get-all-answer").val("Failed request");
        },
        success: function (result) {
            $("#get-all-answer").val(JSON.stringify(result));
        }
    });
}

function getEspecificItem() {

    $.ajax({
        type: 'GET',
        accepts: 'application/json',
        url: uri + '/' + $('#item-search').val(),
        contentType: 'application/json',
        error: function (jqXHR, textStatus, errorThrown) {
            $("#get-especific-answer").val("Failed request");
        },
        success: function (result) {
            $("#get-especific-answer").val(JSON.stringify(result));
        }
    });
}

function addItem() {

    const item = {
        'name': $('#add-name').val()
    };

    $.ajax({
        type: 'POST',
        accepts: 'application/json',
        url: uri,
        contentType: 'application/json',
        data: JSON.stringify(item),
        error: function (jqXHR, textStatus, errorThrown) {
            $("#post-answer").val("Failed request");
        },
        success: function (result) {
            $("#post-answer").val(JSON.stringify(result));
        }
    });
}

function deleteItem(id) {
    $.ajax({
        url: uri + '/' + id,
        type: 'DELETE',
        success: function (result) {
        }
    });
}

function updateItem() {

    const item = {
        'name': $('#item-name-update').val(),
        'id': $('#item-id-update').val()
    };

    $.ajax({
        type: 'PUT',
        accepts: 'application/json',
        url: uri + '/' + $('#item-id-update').val(),
        contentType: 'application/json',
        data: JSON.stringify(item),
        error: function (jqXHR, textStatus, errorThrown) {
            $("#update-answer").val("Failed request");
        },
        success: function (result) {
            $("#update-answer").val("Item update with sucess");
        }
    });
}

function deleteItem() {
    $.ajax({
        type: 'DELETE',
        accepts: 'application/json',
        url: uri + '/' + $('#item-id-update').val(),
        contentType: 'application/json',
        error: function (jqXHR, textStatus, errorThrown) {
            $("#update-answer").val("Failed request");
        },
        success: function (result) {
            $("#update-answer").val("Item deleted with sucess");
        }
    });
}
