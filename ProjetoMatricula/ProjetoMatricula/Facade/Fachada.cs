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
            rNegocio[aluno.GetType().Name + "Salvar"] = rNegocioAluno;
            rNegocio[aluno.GetType().Name + "Atualizar"] = rNegocioAluno;
            //rNegocioAluno = rNegocio[aluno.GetType().Name];
        }

        private void DefinirDAOS()
        {
            Aluno aluno = new Aluno();
            AlunoDAO alunoDao = new AlunoDAO();
            daos = new Dictionary<string, IDAO>();
            daos[aluno.GetType().Name] = alunoDao;
            //alunoDao = daos[aluno.GetType().Name;            
        }

        public EntidadeDominio Salvar(EntidadeDominio entidade)
        {
            if (rNegocio.ContainsKey(entidade.GetType().Name + "Salvar"))
            {
                List<IStrategy> validacoes = this.rNegocio[entidade.GetType().Name + "Salvar"];
                string resultado = "";
                foreach (var item in validacoes)
                {
                    resultado += item.Processar(entidade);
                }
                if (!string.IsNullOrEmpty(resultado))
                {
                    throw new Exception(resultado);
                }
            }
            try
            {
                IDAO dao = this.daos[entidade.GetType().Name];
                dao.Salvar(entidade);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return entidade;
        }

        public EntidadeDominio Deletar(EntidadeDominio entidade)
        {
            if (rNegocio.ContainsKey(entidade.GetType().Name + "Excluir"))
            {
                List<IStrategy> validacoes = this.rNegocio[entidade.GetType().Name + "Excluir"];
                string resultado = "";
                foreach (var item in validacoes)
                {
                    resultado += item.Processar(entidade);
                }
                if (!string.IsNullOrEmpty(resultado))
                {
                    throw new Exception(resultado);
                }
            }
            try
            {
                IDAO dao = this.daos[entidade.GetType().Name];
                dao.Excluir(entidade);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return entidade;
        }
    }
}