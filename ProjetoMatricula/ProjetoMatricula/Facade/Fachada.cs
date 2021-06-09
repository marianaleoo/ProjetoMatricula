using ProjetoMatricula.Business;
using ProjetoMatricula.DAO;
using ProjetoMatricula.Model;
using ProjetoMatricula.Servico;
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
            rNegocio = new Dictionary<string, List<IStrategy>>();

            List<IStrategy> rNegocioAluno = new List<IStrategy>();
            List<IStrategy> rNegocioCurso = new List<IStrategy>();
            List<IStrategy> rNegocioAlunoAtualizar = new List<IStrategy>();
            ValidadorCpf validCpf = new ValidadorCpf();
            ValidadorEndereco validEnd = new ValidadorEndereco();
            ValidadorRA validRA = new ValidadorRA();            
            ValidadorExcluirCurso validExcluirCurso = new ValidadorExcluirCurso();
            rNegocioAluno.Add(validCpf);
            rNegocioAluno.Add(validEnd);
            rNegocioAluno.Add(validRA);            
            rNegocioCurso.Add(validExcluirCurso);
            rNegocioAlunoAtualizar.Add(validEnd);
            rNegocioAlunoAtualizar.Add(validCpf);
            rNegocioAlunoAtualizar.Add(validRA);
            rNegocio["Aluno" + "Salvar"] = rNegocioAluno;            
            rNegocio["Curso" + "Excluir"] = rNegocioCurso;
            rNegocio["Aluno" + "Alterar"] = rNegocioAlunoAtualizar;
        }

        private void DefinirDAOS()
        {
            daos = new Dictionary<string, IDAO>();
            AlunoDAO alunoDao = new AlunoDAO();
            daos["Aluno"] = alunoDao;

            CursoDAO cursoDao = new CursoDAO();
            daos["Curso"] = cursoDao;

            DisciplinaDAO disciplinaDao = new DisciplinaDAO();
            daos["Disciplina"] = disciplinaDao;

            TipoDAO tipoDao = new TipoDAO();
            daos["TipoCurso"] = tipoDao;            
            daos["TipoEndereco"] = tipoDao;
            daos["TipoDocumento"] = tipoDao;
        }

        public EntidadeDominio Cadastrar(EntidadeDominio entidade)
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

        public EntidadeDominio Excluir(EntidadeDominio entidade)
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

        public EntidadeDominio Alterar(EntidadeDominio entidade)
        {
            if (rNegocio.ContainsKey(entidade.GetType().Name + "Alterar"))
            {
                List<IStrategy> validacoes = this.rNegocio[entidade.GetType().Name + "Alterar"];
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
                dao.Alterar(entidade);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return entidade;
        }

        public List<EntidadeDominio> Consultar(EntidadeDominio entidade)
        {
            if (rNegocio.ContainsKey(entidade.GetType().Name + "Consultar"))
            {
                List<IStrategy> validacoes = this.rNegocio[entidade.GetType().Name + "Consultar"];
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
                return  dao.Consultar(entidade);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        
    }
}