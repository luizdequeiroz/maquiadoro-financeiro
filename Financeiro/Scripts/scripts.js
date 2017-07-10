var framePrincipal = null;

function resizeIframe(iframe) {
    iframe.style.height = iframe.contentWindow.document.body.scrollHeight + 'px';
    framePrincipal = iframe;
}

function abrir(val) {

    var controller = '../' + $('#' + val).data('controller') + '/';
    var action = val;
    $('#principal').attr('src', controller + action);
}

function abrirNoFrame(mId, controller, action, val) {

    $('#' + mId).attr('src', '../../' + controller + "/" + action + "/" + val);
    resizeIframe(framePrincipal);
}

function cadastrar() {

    $('#frm').attr('action', '/Administrativo/CadastrarCategoria');
    $('#Nome').val($('#NewNome').val());
    $('#Descricao').val($('#NewDescricao').val());
    $('#frm').submit();
}

var id_ant = 0;

function alterar(id) {

    $('#v1_' + id).css('display', 'none');
    $('#v2_' + id).css('display', 'none');
    $('#vb_' + id).css('display', 'none');
    $('#e1_' + id).css('display', '');
    $('#e2_' + id).css('display', '');
    $('#eb_' + id).css('display', '');

    $('#Nome').val($('#AltNome_' + id).val());
    $('#Descricao').val($('#AltDescricao_' + id).val());

    if (id_ant > 0) {
        $('#v1_' + id_ant).css('display', '');
        $('#v2_' + id_ant).css('display', '');
        $('#vb_' + id_ant).css('display', '');
        $('#e1_' + id_ant).css('display', 'none');
        $('#e2_' + id_ant).css('display', 'none');
        $('#eb_' + id_ant).css('display', 'none');
    }

    id_ant = id;
}

function submitAlt() {

    $('#NewNome').removeAttr('name');
    $('#NewDescricao').removeAttr('name');

    $('#frm').attr('action', '/Administrativo/AlterarCategoria');
    $('#Id').val($('#Id_' + id_ant).val());
    $('#Nome').val($('#AltNome_' + id_ant).val());
    $('#Descricao').val($('#AltDescricao_' + id_ant).val());
    $('#frm').submit();
}