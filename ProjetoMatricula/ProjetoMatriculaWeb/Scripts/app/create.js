//var mensagem;
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

    buscarCursos: function () {
        $.ajax({
            cache: false,
            method: "POST",
            url: rootPath + "Controle/GetCurso",
            data: JSON.stringify(aluno.DadosDTO),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                console.log(data);
                $.each(data.data, function (i, d) {
                    $('#ddlCurso').append($('<option></option>').attr('values', d.id).text(d.nome));                    
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
            url: rootPath + "Controle/GetDisciplina",
            data: JSON.stringify(aluno.DadosDTO),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                console.log(data);
                $.each(data.data, function (i, d) {
                    $('#ddlDisciplina').append($('<option></option>').attr('values', d.id).text(d.nome));
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
            TipoDocumento: $("#txtTpDocumento").val(),
            Curso: $("#ddlCurso").val(),
            Modelo: $("#ddlModelo").val(),
            TipoCurso: $("#ddlTpCurso").val(),
            Disciplina: $("#ddlDisciplina").val(),
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
    aluno.buscarCursos();
    aluno.buscarDisciplinas();

    $("#btnSalvar").click(function () {
        aluno.salvarDados();
    });
});
