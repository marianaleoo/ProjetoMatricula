﻿var curso = {
    DadosDTO: undefined,

    buscarDados: function () {        
        $.ajax({
            cache: false,
            method: "POST",
            url: rootPath + "Controle/GetTipoCurso",
            data: JSON.stringify(curso.DadosDTO),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {                
                $.each(data.data, function (i, d) {
                    $('#ddlTpCurso').append($('<option></option>').attr('values', d.id).text(d.descricao));                    
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

    salvarDados: function () {         
        curso.DadosDTO = {              
            Curso: $('#txtCurso').val(),
            Modelo: $('#txtModelo').val(),            
            TipoCurso: $('#ddlTpCurso').val()
        }
        curso.salvarBD();
    },

    salvarBD: function () {
        $.ajax({
            method: "POST",
            url: rootPath + "Controle/SalvarCurso",
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
    curso.buscarDados();

    $("#btnSalvar").click(function () {
        curso.salvarDados();
    });
});