var aluno = {
    carregarTelaInicial: function () {
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
    }
};



$(document).ready(function () {
    aluno.carregarTelaInicial();
    //$("#btnSalvar").click(function () {
    //    aluno.salvarDados();
    //});
});