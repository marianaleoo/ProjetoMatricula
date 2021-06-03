//var mensagem;
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
    $("#btnSalvar").click(function () {
        aluno.salvarDados();
    });
});
