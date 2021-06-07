var disciplina = {
    DadosDTO: undefined,

    carregarId: function () {
        disciplina.DadosDTO = {
            IdDisciplina: parseInt($("#idDisciplina").val())
        }
        disciplina.buscarDisciplina();
    },

    buscarCurso: function () {
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
                    title: "Desculpe, erro ao buscar dados do curso",
                    text: error.responseJSON.mensagem,
                    type: "error",
                    closeOnConfirm: true,
                }, function () {
                    close();
                });
            }
        });
    },

    buscarDisciplina: function () {
        $.ajax({
            cache: false,
            method: "POST",
            url: rootPath + "Controle/GetDisciplina",
            data: JSON.stringify(disciplina.DadosDTO),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                disciplina.carregarDados(data);
                disciplina.buscarCurso();
            },
            error: function (error) {
                swal({
                    title: "Desculpe, erro ao buscar dados do curso",
                    text: error.responseJSON.mensagem,
                    type: "error",
                    closeOnConfirm: true,
                }, function () {
                    close();
                });
            }
        });
    },

    carregarDados: function (data) {
        var data = $(data).get(0);
        $("#txtDisciplina").val(data.nome)           
    },

    salvarDados: function () {
        disciplina.DadosDTO = {
            IdDisciplina: $("#idDisciplina").val(),
            Disciplina: $("#txtDisciplina").val(),
            IdCurso: $("#ddlCurso").val()
        }
        disciplina.salvarBD();
    },

    salvarBD: function () {
        $.ajax({
            method: "POST",
            url: rootPath + "Controle/AtualizarDisciplina",
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
    disciplina.carregarId();

    $("#btnEditar").click(function () {
        disciplina.salvarDados();
    });
});