var curso = {
    DadosDTO: undefined,

    buscarDados: function () {
        console.log(curso.DadosDTO);
        $.ajax({
            cache: false,
            method: "POST",
            url: rootPath + "Controle/GetTipoCurso",
            data: JSON.stringify(curso.DadosDTO),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                var select = $("ddlTpCurso");
                $.each(data, function (d) {
                    console.log(data);
                    $('<option>').val(d.Id).text(d.TipoCurso).appendTo(select);
                });
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

    salvarDados: function () {
        curso.DadosDTO = {            
            Curso: $("#txtCurso").val(),
            Modelo: $("#txtModelo").val(),
            TipoCurso: $("#txtTpCurso").val()            
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
                toastr.error("Erro ao salvar dados!", "Aluno");
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