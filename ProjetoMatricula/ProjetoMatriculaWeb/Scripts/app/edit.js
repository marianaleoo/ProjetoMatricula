var idAluno;
var aluno = {
    DadosDTO: undefined,

    atualizarDados: function () {
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
        aluno.atualizarBD();
    },

    atualizarBD: function () {        
        $.ajax({
            method: "POST",
            url: rootPath + "Controle/Atualizar",
            data: JSON.stringify(idAluno, aluno.DadosDTO),
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
        aluno.atualizarDados();
    });
});