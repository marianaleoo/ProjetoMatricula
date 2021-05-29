﻿//var mensagem;
var aluno = {
    DadosDTO: undefined,

    salvarDados: function () {
        aluno.DadosDTO = {
            Aluno: $("#txtAluno").val(),
            RA: $("#txtRa").val(),
            DataNascimento: $("#txtDtNascimento").val(),
            Codigo: $("#txtCodigo").val(),
            Validade: $("#txtValidade").val(),
            TipoDocumento: $("#txtTpDocumento").val(),
            Curso: $("#txtCurso").val(),
            Modelo: $("#txtModelo").val(),
            TipoCurso: $("#txtTpCurso").val(),
            Disciplina: $("#txtDisciplina").val(),
            Logradouro: $("#txtLogradouro").val(),
            Numero: $("#txtNumero").val(),
            Cep: $("#txtCep").val(),
            Cidade: $("#txtCidade").val(),
            Estado: $("#txtEstado").val(),
            TipoEndereco: $("#txtTpEndereco").val()            
        }
        aluno.salvarBD();
    },

    salvarBD: function () {
        $.ajax({
            method: "POST",
            url: rootPath + "Controle/Salvar",
            data: JSON.stringify(aluno.DadosDTO),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                toastr.success("Dados salvos com sucesso!", "Aluno");
            },
            error: function (error) {
                toastr.error("Erro ao salvar dados!", "Aluno");
                location.reload();
            }
        });
    }
};


$(document).ready(function () {
    $("#btnSalvar").click(function () {
        aluno.salvarDados();
    });
});
