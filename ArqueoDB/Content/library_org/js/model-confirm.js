$('#modal-from-dom-ocultar').on('show', function() {
    var id = $(this).data('id'),
        removeBtn = $(this).find('.btn-danger');

    removeBtn.attr('href', removeBtn.attr('href').replace(/Ocultar\/(.*|\d)/, "Ocultar/" + id));
})

$('.confirm-ocultar').on('click', function(e) {
    e.preventDefault();

    var id = $(this).data('id');
    $('#modal-from-dom-ocultar').data('id', id).modal('show');
});

$('#modal-from-dom-publicar').on('show', function() {
    var id = $(this).data('id'),
        removeBtn = $(this).find('.btn-danger');

    removeBtn.attr('href', removeBtn.attr('href').replace(/Publicar\/(.*|\d*)/, "Publicar/" + id, id));
})

$('.confirm-publicar').on('click', function(e) {
    e.preventDefault();

    var id = $(this).data('id');
    $('#modal-from-dom-publicar').data('id', id).modal('show');
});

$('#modal-from-dom-remover').on('show', function() {
    var id = $(this).data('id'),
        removeBtn = $(this).find('.btn-danger');

    removeBtn.attr('href', removeBtn.attr('href').replace(/ID/, id));
})

$('.confirm-remover').on('click', function(e) {
    e.preventDefault();

    var id = $(this).data('id');
    $('#modal-from-dom-remover').data('id', id).modal('show');
});
