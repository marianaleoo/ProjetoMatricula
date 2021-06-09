var aluno = {
    DadosDTO: undefined,

    carregarId: function () {
        aluno.DadosDTO = {
            Id: parseInt($("#idAluno").val())
        }
        aluno.buscarDados();
    },

    carregarDados: function (data) {
        console.log(data);
        var data = $(data).get(0);
            $("#idAluno").val(data.Id),
            $("#txtAluno").val(data.Aluno),
            $("#txtRa").val(data.RA),
            $("#txtDtNascimento").val(data.DataNascimento),
            $("#txtCodigo").val(data.Codigo),
            $("#txtValidade").val(data.Validade),            
            $("#txtCurso").val(data.Curso),            
            $("#txtDisciplina").val(data.Disciplina),
            $("#txtLogradouro").val(data.Logradouro),
            $("#txtNumero").val(data.Numero),
            $("#txtCep").val(data.Cep),
            $("#txtCidade").val(data.Cidade),
            $("#txtEstado").val(data.Estado),
            $("#txtTpCurso").val(data.IdTpCurso),
            $("#txtTpDocumento").val(data.IdTpDocumento),
            $("#txtTpEndereco").val(data.IdTpEndereco)
    },

    buscarDados: function () {        
        $.ajax({
            cache: false,
            method: "POST",
            url: rootPath + "Controle/Detalhar",
            data: JSON.stringify(aluno.DadosDTO),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                aluno.carregarDados(data);
            },
            error: function (error) {
                swal({
                    title: "Desculpe, erro ao buscar dados do aluno",
                    text: error.responseJSON.mensagem,
                    type: "error",
                    closeOnConfirm: true,
                }, function () {
                    close();
                });
            }
        });
    },

    buscarTipoCurso: function () {
        $.ajax({
            cache: false,
            method: "POST",
            url: rootPath + "Controle/GetTipoCurso",
            data: JSON.stringify(aluno.DadosDTO),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                var select = $("#txtTpCurso");
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

    buscarTipoDocumento: function () {
        $.ajax({
            cache: false,
            method: "POST",
            url: rootPath + "Controle/GetTipoDocumento",
            data: JSON.stringify(aluno.DadosDTO),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                var select = $("#txtTpDocumento");
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

    buscarTipoEndereco: function () {
        $.ajax({
            cache: false,
            method: "POST",
            url: rootPath + "Controle/GetTipoEndereco",
            data: JSON.stringify(aluno.DadosDTO),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                var select = $("#txtTpEndereco");
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

    buscarCursos: function () {
        $.ajax({
            cache: false,
            method: "POST",
            url: rootPath + "Controle/GetCursos",
            data: JSON.stringify(aluno.DadosDTO),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                var select = $("#txtCurso");
                $.each(data.data, function (i, d) {
                    $('<option>').val(d.id).text(d.nome).appendTo(select);
                });
                aluno.buscarDisciplinas($('#txtCurso option:selected').val());
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

    buscarDisciplinas: function (id) {
        aluno.DadosDTO = {
            IdCurso: id
        }
        $.ajax({
            cache: false,
            method: "POST",
            url: rootPath + "Controle/GetCursoDisciplinas",
            data: JSON.stringify(aluno.DadosDTO),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                $("#txtDisciplina").empty();
                var select = $("#txtDisciplina");
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

    editarDados: function () {
        aluno.DadosDTO = {
            Id: $("#idAluno").val(),
            Aluno: $("#txtAluno").val(),
            RA: $("#txtRa").val(),
            DataNascimento: $("#txtDtNascimento").val(),
            Codigo: $("#txtCodigo").val(),
            Validade: $("#txtValidade").val(),
            IdTpDocumento: $("#txtTpDocumento").val(),
            Curso: $("#txtCurso").val(),
            Modelo: $("#txtModelo").val(),
            IdTpCurso: $("#txtTpCurso").val(),
            Disciplina: $("#txtDisciplina").val(),
            Logradouro: $("#txtLogradouro").val(),
            Numero: $("#txtNumero").val(),
            Cep: $("#txtCep").val(),
            Cidade: $("#txtCidade").val(),
            Estado: $("#txtEstado").val(),
            IdTpEndereco: $("#txtTpEndereco").val()
        }        
        $.ajax({
            method: "POST",
            url: rootPath + "Controle/Atualizar",
            data: JSON.stringify(aluno.DadosDTO),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                aluno.retornoIndex();
            },
            error: function (error) {
                console.log(error.responseJSON);
                $('#mensagemErro').text(error.responseJSON.mensagem);
                $('#divAlerta').addClass('alert alert-danger');
            }
        });
    },

    retornoIndex: function () {
        window.open(rootPath + 'Controle/Index')
    }
};


$(document).ready(function () {  
    aluno.carregarId();
    aluno.buscarTipoDocumento();
    aluno.buscarTipoCurso();
    aluno.buscarTipoEndereco();
    aluno.buscarCursos();    

    //$("#txtDtNascimento").mask("99/99/9999", { reverse: true });

    $("#btnEditar").click(function () {
        aluno.editarDados();
    });

    $('#txtCurso').on('change', function (e) {
        $("#txtDisciplina").empty();
        aluno.buscarDisciplinas($('#txtCurso option:selected').val());
    });
});