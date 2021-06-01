using ProjetoMatricula.Business;
using ProjetoMatricula.DAO;
using ProjetoMatricula.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoMatricula.Facade
{
    public class Fachada : IFachada
    {
        private Dictionary<String, IDAO> daos;
        private Dictionary<String, List<IStrategy>> rNegocio;

        public Fachada()
        {
            DefinirDAOS();
            DefinirNegocio();
        }

        private void DefinirNegocio()
        {
            //analisar 
            Aluno aluno = new Aluno();
            rNegocio = new Dictionary<string, List<IStrategy>>();

            ValidadorCpf validCpf = new ValidadorCpf();
            //ValidadorEndereco validEnd = new ValidadorEndereco();

            List<IStrategy> rNegocioAluno = new List<IStrategy>();
            rNegocioAluno.Add(validCpf);
            rNegocio[aluno.GetType().Name] = rNegocioAluno;
            rNegocioAluno = rNegocio[aluno.GetType().Name];
        }

        private void DefinirDAOS()
        {
            Aluno aluno = new Aluno();
            AlunoDAO alunoDao = new AlunoDAO();
            daos = new Dictionary<string, IDAO>();
            daos[aluno.GetType().Name] =  alunoDao;
            //alunoDao = daos[aluno.GetType().Name;
        }


    }
}