var disciplina = {
    DadosDTO: undefined,

    buscarDados: function () {
        $.ajax({
            cache: false,
            method: "POST",
            url: rootPath + "Controle/GetCursos",
            data: JSON.stringify(disciplina.DadosDTO),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                var select = $("#ddlCurso");
                $.each(data.data, function (i, d) {                    
                    $('<option>').val(d.id).text(d.nome).appendTo(select);
                });
            },
            error: function (error) {
                swal({
                    title: "Desculpe, erro ao buscar dados da disciplina",
                    text: error.responseJSON.mensagem,
                    type: "error",
                    closeOnConfirm: true,
                }, function () {
                    close();
                });
            }
        });
    },

    salvarDados: function () {
        disciplina.DadosDTO = {
            IdCurso: $('#ddlCurso').val(),
            Disciplina: $('#txtDisciplina').val()            
        }
        disciplina.salvarBD();
    },

    salvarBD: function () {
        $.ajax({
            method: "POST",
            url: rootPath + "Controle/SalvarDisciplina",
            data: JSON.stringify(disciplina.DadosDTO),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                disciplina.retornoIndex();
            },
            error: function (error) {
                toastr.error("Erro ao salvar dados!", "Curso");
                location.reload();
            }
        });
    },

    retornoIndex: function () {
        window.open(rootPath + 'Controle/IndexDisciplina')
    }
};


$(document).ready(function () {
    disciplina.buscarDados();

    $("#btnSalvar").click(function () {
        disciplina.salvarDados();
    });
});