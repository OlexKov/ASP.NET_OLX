function setModalContent(isConfirm) {
    $modalDialog = $('#infoModal .modal-dialog');
    $modalBody = $("#infoModal div .modal-body");
    $dellButton = $('#infoModal .modal-footer .btn-danger');
    $cancelButton = $('#infoModal .modal-footer .btn-secondary');
    $modalTitle = $('#infoModal .modal-title');
    $modalBody.empty();
    if (isConfirm) {
        $modalDialog.removeClass('modal-lg');
        $dellButton.removeClass('d-none');
        $cancelButton.text('���������');
        $modalTitle.text('���������');
        $modalBody.text('�� ������� �� ������ �������� ������� �������?');
    }
    else {
        $modalDialog.addClass('modal-lg');
        $dellButton.addClass('d-none');
        $cancelButton.text('�������');
        $modalTitle.text('���������� ��� ����������');
    }
}

function Func_LoadPv(item) {
    setModalContent();
    $.get("/Admin/ShowPartialView?id=" + item, function (res) {
        let $modalBody = $("#infoModal div .modal-body");
        $modalBody.append(res);
    });
}

function setId(id) {
    setModalContent(true);
    $('#infoModal a').attr('href', '/Admin/DeleteElement/' + id);
}