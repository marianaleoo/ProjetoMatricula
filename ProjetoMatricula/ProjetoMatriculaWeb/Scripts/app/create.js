var aluno = {
    DadosDTO: undefined,

    buscarTipoCurso: function () {
        $.ajax({
            cache: false,
            method: "POST",
            url: rootPath + "Controle/GetTipoCurso",
            data: JSON.stringify(aluno.DadosDTO),
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

    buscarTipoDocumento: function () {
        $.ajax({
            cache: false,
            method: "POST",
            url: rootPath + "Controle/GetTipoDocumento",
            data: JSON.stringify(aluno.DadosDTO),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                var select = $("#ddlTpDocumento");
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
                var select = $("#ddlTpEndereco");
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

    buscarDisciplinas: function () {
        $.ajax({
            cache: false,
            method: "POST",
            url: rootPath + "Controle/GetDisciplinas",
            data: JSON.stringify(aluno.DadosDTO),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {                
                var select = $("#ddlDisciplina");
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
        aluno.DadosDTO = {
            Aluno: $("#txtAluno").val(),
            RA: $("#txtRa").val(),
            DataNascimento: $("#txtDtNascimento").val(),
            Codigo: $("#txtCodigo").val(),
            Validade: $("#txtValidade").val(),
            IdTpDocumento: $("#ddlTpDocumento").val(),
            IdCurso: $("#ddlCurso").val(),
            Modelo: $("#ddlModelo").val(),
            IdTpCurso: $("#ddlTpCurso").val(),
            IdDisciplina: $("#ddlDisciplina").val(),
            Logradouro: $("#txtLogradouro").val(),
            Numero: $("#txtNumero").val(),
            Cep: $("#txtCep").val(),
            Cidade: $("#txtCidade").val(),
            Estado: $("#txtEstado").val(),
            IdTpEndereco: $("#ddlTpEndereco").val()            
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
                aluno.retornoIndex();
            },
            error: function (error) {
                toastr.error("Erro ao salvar dados!", "Aluno");
                location.reload();
            }
        });
    },

    retornoIndex: function () {
        window.open(rootPath + 'Controle/Index')
    }
};


$(document).ready(function () {
    aluno.buscarTipoCurso();
    aluno.buscarTipoDocumento();
    aluno.buscarCursos();
    aluno.buscarDisciplinas(); 
    aluno.buscarTipoEndereco();

    $("#btnSalvar").click(function () {
        aluno.salvarDados();
    });
});
