var aluno = {
    DadosDTO: undefined,

    carregarId: function () {
        aluno.DadosDTO = {
            Id: parseInt($("#idAluno").val())
        }
        aluno.buscarDados();
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


    carregarDados: function (data) {
        var data = $(data).get(0);
            $("#idAluno").html(data.Id),
            $("#txtAluno").html(data.Aluno),
            $("#txtRa").html(data.RA),
            $("#txtDtNascimento").html(data.DataNascimento),
            $("#txtCodigo").html(data.Codigo),
            $("#txtValidade").html(data.Validade),
            $("#txtTpDocumento").html(data.TipoDocumento),
            $("#txtCurso").html(data.Curso),
            $("#txtModelo").html(data.Modelo),
            $("#txtTpCurso").html(data.TipoCurso),
            $("#txtDisciplina").html(data.Disciplina),
            $("#txtLogradouro").html(data.Logradouro),
            $("#txtNumero").html(data.Numero),
            $("#txtCep").html(data.Cep),
            $("#txtCidade").html(data.Cidade),
            $("#txtEstado").html(data.Estado),
            $("#txtTpEndereco").html(data.TipoEndereco)     
    },

    excluirDados: function () {
        console.log(aluno.DadosDTO);
        $.ajax({
            cache: false,
            method: "POST",
            url: rootPath + "Controle/Excluir",
            data: JSON.stringify(aluno.DadosDTO),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                location.href(rootPath + "Controle/Index");
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
};

$(document).ready(function () {
    aluno.carregarId();

    $("#btnExcluir").click(function () {
        aluno.excluirDados();
    });
});