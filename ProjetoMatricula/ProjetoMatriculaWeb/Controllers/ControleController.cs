using Newtonsoft.Json;
using ProjetoMatricula.Command;
using ProjetoMatricula.DAO;
using ProjetoMatricula.Model;
using ProjetoMatricula.Servico;
using ProjetoMatriculaWeb.ViewHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetoMatriculaWeb.Controllers
{
    public class ControleController : Controller
    {
        private CommandCadastrar _commandCadastrar;
        private CommandAlterar _commandAlterar;
        private CommandConsultar _commandConsultar;
        private CommandExcluir _commandExcluir;

        public ControleController()
        {
            _commandCadastrar = new CommandCadastrar();
            _commandAlterar = new CommandAlterar();
            _commandConsultar = new CommandConsultar();
            _commandExcluir = new CommandExcluir();
        }

        #region Aluno
        // GET: Controle        
        public ActionResult Index()
        {
            Aluno teste = new Aluno();

            List<EntidadeDominio> entidades = _commandConsultar.Exec(teste);
            List<Aluno> alunos = entidades.ConvertAll(item => (Aluno)item);
            
            return View(alunos);
        }        

        // GET: Controle/Details/5
        public ActionResult Details(int id)
        {
            ViewBag.Id = id;

            return View();
        }

        // GET: Controle/Create
        public ActionResult Create()
        {
            return View();
        }

        // GET: Controle/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.Id = id;

            return View();
        }

        // GET: Controle/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        // POST: Controle/Create
        [HttpPost]
        public JsonResult Salvar(DadosDTO dados)
        {
            try
            {
                IViewHelper vh = new VhAluno();                

                var teste = vh.GetEntidade(dados);

                return Json(new { success = _commandCadastrar.Executar(teste) });                
            }
            catch(Exception ex)
            {
                return Json(new { success = false });
            }
        }        

        // POST: Controle/Edit/5
        [HttpPost]
        public JsonResult Atualizar(DadosDTO dados)
        {
            try
            {
                IViewHelper vh = new VhAluno();                

                var teste = vh.GetEntidade(dados);                

                return Json(new { success = _commandAlterar.Executar(teste) });                
            }
            catch
            {
                return Json(new { success = false });
            }
        }

        [HttpGet]
        public string Consultar(DadosDTO dados)
        {
            try
            {
                IViewHelper vh = new VhAluno();                

                var teste = vh.GetEntidade(dados);

                var data = _commandConsultar.Exec(teste);

                return JsonConvert.SerializeObject(data);
            }
            catch
            {
                return JsonConvert.SerializeObject(new { success = false });
            }
        }

        public ActionResult Excluir(int id)
        {
            IViewHelper vh = new VhAluno();

            var teste = vh.GetId(id);

            return Json(new { success = _commandExcluir.Executar(teste) });
        }

        public ActionResult Delete(int id)
        {
            ViewBag.Id = id;

            IViewHelper vh = new VhAluno();

            var teste = vh.GetId(id);

            List<EntidadeDominio> entidades = _commandConsultar.Exec(teste);
            Aluno aluno = entidades.ConvertAll(item => (Aluno)item).FirstOrDefault();

            return View(aluno);
        }

        [HttpPost]
        public string Detalhar(DadosDTO dados)
        {
            try
            {
                IViewHelper vh = new VhAluno();                

                var teste = vh.GetEntidade(dados);

                var data = _commandConsultar.Exec(teste);

                return JsonConvert.SerializeObject(data);
            }
            catch
            {
                return JsonConvert.SerializeObject(new { success = false });
            }
        }



        [HttpPost]
        public JsonResult GetTipoDocumento(DadosDTO dados)
        {
            try
            {
                TipoDocumento teste = new TipoDocumento();

                List<EntidadeDominio> entidades = _commandConsultar.Exec(teste);
                List<TipoDocumento> tpDocumentos = entidades.ConvertAll(item => (TipoDocumento)item);

                return Json(new { data = tpDocumentos }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false });
            }
        }

        [HttpPost]
        public JsonResult GetTipoEndereco(DadosDTO dados)
        {
            try
            {
                TipoEndereco teste = new TipoEndereco();

                List<EntidadeDominio> entidades = _commandConsultar.Exec(teste);
                List<TipoEndereco> tpEnderecos = entidades.ConvertAll(item => (TipoEndereco)item);

                return Json(new { data = tpEnderecos }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false });
            }
        }
        #endregion

        #region Curso
        // GET: Controle        
        public ActionResult IndexCurso()
        {
            Curso teste = new Curso();

            List<EntidadeDominio> entidades = _commandConsultar.Exec(teste);
            List<Curso> cursos = entidades.ConvertAll(item => (Curso)item);           

            return View(cursos);
        }

        public ActionResult CreateCurso()
        {  
            return View();
        }

        [HttpPost]
        public JsonResult SalvarCurso(DadosDTO dados)
        {
            try
            {
                IViewHelper vh = new VhCurso();                

                var teste = vh.GetEntidade(dados);

                return Json(new { success = _commandCadastrar.Executar(teste) });                
            }
            catch (Exception ex)
            {
                return Json(new { success = false });
            }
        }

        [HttpPost]
        public string GetCurso(DadosDTO dados)
        {
            try
            {
                IViewHelper vh = new VhCurso();

                #region Convert Id
                int id = 0;
                if (!dados.IdCurso.Equals(0))
                {
                    id = dados.IdCurso;
                }
                #endregion

                var teste = vh.GetId(id);                

                List<EntidadeDominio> entidades = _commandConsultar.Exec(teste);
                List<Curso> cursos = entidades.ConvertAll(item => (Curso)item);

                return JsonConvert.SerializeObject(cursos);
            }
            catch (Exception ex)
            {
                return JsonConvert.SerializeObject(new { success = false });
            }
        }

        [HttpPost]
        public JsonResult GetCursos(DadosDTO dados)
        {
            try
            {
                Curso teste = new Curso();

                List<EntidadeDominio> entidades = _commandConsultar.Exec(teste);
                List<Curso> cursos = entidades.ConvertAll(item => (Curso)item);

                return Json(new { data = cursos }, JsonRequestBehavior.AllowGet);                
            }
            catch (Exception ex)
            {
                return Json(new { success = false });
            }
        }

        [HttpPost]
        public JsonResult GetTipoCurso(DadosDTO dados)
        {
            try
            {
                TipoCurso teste = new TipoCurso(); 
                
                List<EntidadeDominio> entidades = _commandConsultar.Exec(teste);
                List<TipoCurso> tpCursos = entidades.ConvertAll(item => (TipoCurso)item);                

                return Json(new { data = tpCursos }, JsonRequestBehavior.AllowGet);                
            }
            catch (Exception ex)
            {
                return Json(new { success = false });
            }
        }

        public ActionResult DeleteCurso(int id)
        {
            ViewBag.Id = id;

            IViewHelper vh = new VhCurso();

            var teste = vh.GetId(id);

            List<EntidadeDominio> entidades = _commandConsultar.Exec(teste);
            Curso curso = entidades.ConvertAll(item => (Curso)item).FirstOrDefault();

            return View(curso);
        }

        public ActionResult ExcluirCurso(int id)
        {
            IViewHelper vh = new VhCurso();

            var teste = vh.GetId(id);

            return Json(new { success = _commandExcluir.Executar(teste) });
        }

        public ActionResult EditCurso(int id)
        {
            ViewBag.Id = id;

            return View();
        }

        [HttpPost]
        public JsonResult AtualizarCurso(DadosDTO dados)
        {
            try
            {
                IViewHelper vh = new VhCurso();

                var teste = vh.GetEntidade(dados);

                return Json(new { success = _commandAlterar.Executar(teste) });
            }
            catch
            {
                return Json(new { success = false });
            }
        }
        #endregion

        #region Disciplina
        public ActionResult IndexDisciplina()
        {
            Disciplina teste = new Disciplina();

            List<EntidadeDominio> entidades = _commandConsultar.Exec(teste);
            List<Disciplina> disciplinas = entidades.ConvertAll(item => (Disciplina)item);

            return View(disciplinas);
        }

        public ActionResult CreateDisciplina()
        {
            return View();
        }        

        [HttpPost]
        public JsonResult SalvarDisciplina(DadosDTO dados)
        {
            try
            {
                IViewHelper vh = new VhDisciplina();

                var teste = vh.GetEntidade(dados);

                return Json(new { success = _commandCadastrar.Executar(teste) });
            }
            catch (Exception ex)
            {
                return Json(new { success = false });
            }
        }

        [HttpPost]
        public JsonResult GetDisciplinas(DadosDTO dados)
        {
            try
            {
                Disciplina teste = new Disciplina();

                List<EntidadeDominio> entidades = _commandConsultar.Exec(teste);
                List<Disciplina> disciplinas = entidades.ConvertAll(item => (Disciplina)item);

                return Json(new { data = disciplinas }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false });
            }
        }

        [HttpPost]
        public string GetDisciplina(DadosDTO dados)
        {
            try
            {
                IViewHelper vh = new VhDisciplina();

                #region Convert Id
                int id = 0;
                if (!dados.IdDisciplina.Equals(0))
                {
                    id = dados.IdDisciplina;
                }
                #endregion

                var teste = vh.GetId(id);

                List<EntidadeDominio> entidades = _commandConsultar.Exec(teste);
                List<Disciplina> disciplina = entidades.ConvertAll(item => (Disciplina)item);

                return JsonConvert.SerializeObject(disciplina);
            }
            catch (Exception ex)
            {
                return JsonConvert.SerializeObject(new { success = false });
            }
        }

        public ActionResult DeleteDisciplina(int id)
        {
            ViewBag.Id = id;

            IViewHelper vh = new VhDisciplina();

            var teste = vh.GetId(id);

            List<EntidadeDominio> entidades = _commandConsultar.Exec(teste);
            Disciplina disciplinas = entidades.ConvertAll(item => (Disciplina)item).FirstOrDefault();

            return View(disciplinas);
        }
        
        public ActionResult ExcluirDisciplina(int id)
        {   
            IViewHelper vh = new VhDisciplina();

            var teste = vh.GetId(id);

            return Json(new { success = _commandExcluir.Executar(teste) });
        }

        public ActionResult EditDisciplina(int id)
        {
            ViewBag.Id = id;

            return View();
        }

        [HttpPost]
        public JsonResult AtualizarDisciplina(DadosDTO dados)
        {
            try
            {
                IViewHelper vh = new VhDisciplina();

                var teste = vh.GetEntidade(dados);

                return Json(new { success = _commandAlterar.Executar(teste) });
            }
            catch
            {
                return Json(new { success = false });
            }
        }
        #endregion
    }
}