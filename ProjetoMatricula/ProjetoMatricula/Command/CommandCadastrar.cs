using ProjetoMatricula.Facade;
using ProjetoMatricula.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoMatricula.Command
{
    public class CommandCadastrar : ICommand
    {
        private readonly Fachada _fachada;

        public CommandCadastrar()
        {
            _fachada = new Fachada();
        }

        public List<EntidadeDominio> Exec(EntidadeDominio entidade)
        {
            throw new NotImplementedException();
        }

        public EntidadeDominio Executar(EntidadeDominio entidade)
        {
            return _fachada.Cadastrar(entidade);
        }
    }
}