using ProjetoMatricula.Facade;
using ProjetoMatricula.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoMatricula.Command
{
    public class CommandConsultar : ICommand
    {
        private readonly Fachada _fachada;

        public CommandConsultar()
        {
            _fachada = new Fachada();
        }        

        public List<EntidadeDominio> Exec(EntidadeDominio entidade)
        {
            return _fachada.Consultar(entidade);
        }

        public EntidadeDominio Executar(EntidadeDominio entidade)
        {
            throw new NotImplementedException();
        }
    }
}