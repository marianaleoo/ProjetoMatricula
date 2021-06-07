var curso = {
    DadosDTO: undefined,

    carregarId: function () {
        curso.DadosDTO = {
            IdCurso: parseInt($("#idCurso").val())
        }
        curso.buscarCurso();
    },

    buscarTipoCurso: function () {
        $.ajax({
            cache: false,
            method: "POST",
            url: rootPath + "Controle/GetTipoCurso",
            data: JSON.stringify(curso.DadosDTO),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                var select = $("#ddlTpCurso");
                $.each(data.data, function (i, d) {
                    $('<option>').val(d.id).text(d.descricao).appendTo(select);
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

    buscarCurso: function () {
        $.ajax({
            cache: false,
            method: "POST",
            url: rootPath + "Controle/GetCurso",
            data: JSON.stringify(curso.DadosDTO),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {                
                curso.carregarDados(data);
                curso.buscarTipoCurso();
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
        $("#txtCurso").val(data.nome),
        $("#txtModelo").val(data.modeloCurso)
    },

    salvarDados: function () {
        curso.DadosDTO = {      
            IdCurso: $("#idCurso").val(),
            Curso: $('#txtCurso').val(),
            Modelo: $('#txtModelo').val(),
            IdTpCurso: $('#ddlTpCurso').val()            
        }
        curso.salvarBD();
    },

    salvarBD: function () {
        $.ajax({
            method: "POST",
            url: rootPath + "Controle/AtualizarCurso",
            data: JSON.stringify(curso.DadosDTO),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                curso.retornoIndex();
            },
            error: function (error) {
                toastr.error("Erro ao salvar dados!", "Curso");
                location.reload();
            }
        });
    },

    retornoIndex: function () {
        window.open(rootPath + 'Controle/IndexCurso')
    }
};


$(document).ready(function () {
    curso.carregarId();    

    $("#btnEditar").click(function () {
        curso.salvarDados();
    });
});