$('#modal-from-dom-ocultar').on('show', function() {
    var id = $(this).data('id'),
        removeBtn = $(this).find('.btn-danger');

    removeBtn.attr('href', removeBtn.attr('href').replace(/Ocultar\/(.*|\d*)/, "Ocultar/" + id));
});

$('.confirm-ocultar').on('click', function(e) {
    e.preventDefault();

    var id = $(this).data('id');
    $('#modal-from-dom-ocultar').data('id', id).modal('show');
});

$('#modal-from-dom-publicar').on('show', function() {
    var id = $(this).data('id'),
        removeBtn = $(this).find('.btn-danger');

    removeBtn.attr('href', removeBtn.attr('href').replace(/Publicar\/(.*|\d*)/, "Publicar/" + id));
});

$('.confirm-publicar').on('click', function(e) {
    e.preventDefault();

    var id = $(this).data('id');
    $('#modal-from-dom-publicar').data('id', id).modal('show');
});

$('#modal-from-dom-remover').on('show', function() {
    var id = $(this).data('id'),
        removeBtn = $(this).find('.btn-danger');

    removeBtn.attr('href', removeBtn.attr('href').replace(/Remover\/(.*|\d*)/, "Remover/" + id));
});

$('.confirm-remover').on('click', function(e) {
    e.preventDefault();

    var id = $(this).data('id');
    $('#modal-from-dom-remover').data('id', id).modal('show');
});

$('#modal-from-dom-activar').on('show', function() {
    var id = $(this).data('id'),
        removeBtn = $(this).find('.btn-danger');

    removeBtn.attr('href', removeBtn.attr('href').replace(/Activar\/(.*|\d*)/, "Activar/" + id));
});

$('.confirm-activar').on('click', function(e) {
    e.preventDefault();

    var id = $(this).data('id');
    $('#modal-from-dom-activar').data('id', id).modal('show');
});

$('#modal-from-dom-desactivar').on('show', function() {
    var id = $(this).data('id'),
        removeBtn = $(this).find('.btn-danger');

    removeBtn.attr('href', removeBtn.attr('href').replace(/Desactivar\/(.*|\d*)/, "Desactivar/" + id));
});

$('.confirm-desactivar').on('click', function(e) {
    e.preventDefault();

    var id = $(this).data('id');
    $('#modal-from-dom-desactivar').data('id', id).modal('show');
});
