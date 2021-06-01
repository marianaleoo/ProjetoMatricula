var aluno = {
    DadosDTO: undefined,

    carregarId: function () {
        aluno.DadosDTO = {
            Id: parseInt($("#idAluno").val())
        }
        aluno.buscarDados();
    },

    carregarDados: function (data) {
        var data = $(data).get(0);
            $("#idAluno").val(data.Id),
            $("#txtAluno").val(data.Aluno),
            $("#txtRa").val(data.RA),
            $("#txtDtNascimento").val(data.DataNascimento),
            $("#txtCodigo").val(data.Codigo),
            $("#txtValidade").val(data.Validade),
            $("#txtTpDocumento").val(data.TipoDocumento),
            $("#txtCurso").val(data.Curso),
            $("#txtModelo").val(data.Modelo),
            $("#txtTpCurso").val(data.TipoCurso),
            $("#txtDisciplina").val(data.Disciplina),
            $("#txtLogradouro").val(data.Logradouro),
            $("#txtNumero").val(data.Numero),
            $("#txtCep").val(data.Cep),
            $("#txtCidade").val(data.Cidade),
            $("#txtEstado").val(data.Estado),
            $("#txtTpEndereco").val(data.TipoEndereco)
    },

    buscarDados: function () {
        console.log(aluno.DadosDTO);
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

    editarDados: function () {
        aluno.DadosDTO = {
            Id: $("#idAluno").val(),
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
        $.ajax({
            method: "POST",
            url: rootPath + "Controle/Atualizar",
            data: JSON.stringify(aluno.DadosDTO),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                toastr.success("Dados atualizados com sucesso!", "Aluno");
            },
            error: function (error) {
                toastr.error("Erro ao atualizar dados!", "Aluno");
                location.reload();
            }
        });
    }
};


$(document).ready(function () {
    aluno.carregarId();

    //$("#txtDtNascimento").mask("99/99/9999", { reverse: true });

    $("#btnEditar").click(function () {
        aluno.editarDados();
    });
});