var aluno = {
    DadosDTO: undefined,   

    //carregarTelaInicial: function () {
    //    $('#tableListaAlunos').DataTable({
    //        autoWidth: false,
    //        ordering: false,
    //        bFilter: false,
    //        bInfo: false,
    //        pageLength: 5,
    //        ajax: {
    //            type: "GET",
    //            url: rootPath + "Controle/Consultar",                
    //            dataType: "json"
    //        },
    //        columns: [
    //            { data: 'Aluno' },
    //            { data: 'RA' },
    //            { data: 'Curso' },
    //            { data: 'Disciplina' }
    //        ],
    //    });
    //},

    excluirDados: function () {
        aluno.DadosDTO = { Id: parseInt($("#idAluno").val()) }
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
    }
};



$(document).ready(function () {
    //aluno.carregarTelaInicial();

    $('#tableListaAlunos').DataTable({
        autoWidth: false,
        ordering: false,
        bFilter: false,
        bInfo: false,
        pageLength: 5,
        ajax: {
            type: "GET",
            url: rootPath + "Controle/Consultar",
            dataType: "json"
        },
        columns: [
            { data: 'Aluno' },
            { data: 'RA' },
            { data: 'Curso' },
            { data: 'Disciplina' }
        ],
    });

    $("#btnExcluir").click(function () {
        aluno.excluirDados();
    });
});