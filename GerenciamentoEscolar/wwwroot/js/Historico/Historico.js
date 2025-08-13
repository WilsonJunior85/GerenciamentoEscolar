



$(document).ready(function () {

    $(document).on('blur', '.matricula', function () {
        var matricula = $(this).val(); /*Pegando o valor do input*/
        var row = $(this).closest('tr');   /*Pegando a linha e todos o elementos "tr"*/

        if (matricula) {
            $.ajax({
                url: '/Aluno/BuscarAlunoPorMatricula',
                method: 'GET',
                data: { matricula: matricula },
                success: function (response) {
                    if (response.dados) {
                        row.find('.nome-aluno').text(response.dados.nome)
                    } else
                    {
                        row.find('.nome-aluno').text('Aluno não encontrado!')
                    }
                }
            })
        }
        else {
            row.find('.nome-aluno').text('');
        }
    })
})