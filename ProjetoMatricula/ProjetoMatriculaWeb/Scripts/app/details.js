var id = $("#idAluno").val();

var aluno = {

    buscarDados: function () {
        $.ajax({
            cache: false,
            type: "POST",
            url: rootPath + "Controle/Detalhes",
            data: { id: id },
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
    }
};

$(document).ready(function () {
    aluno.buscarDados();

    //$("#btnSalvar").click(function () {
    //    aluno.salvarDados();
    //});
});