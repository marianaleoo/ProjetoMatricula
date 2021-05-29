using Newtonsoft.Json;
using ProjetoMatricula.DAO;
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
        // GET: Controle        
        public ActionResult Index()
        {
            return View();
        }

        // GET: Controle/Details/5
        public ActionResult Details(int id = 1)
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
        public ActionResult Edit(int id = 1)
        {
            return View();
        }

        // GET: Controle/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Controle/Create
        [HttpPost]
        public JsonResult Salvar(DadosDTO dados)
        {
            try
            {
                IViewHelper vh = new VhAluno();
                AlunoDAO dao = new AlunoDAO();

                var teste = vh.GetEntidade(dados);

                return Json(new { success = dao.Salvar(teste) });
            }
            catch
            {
                return Json(new { success = false });
            }
        }        

        // POST: Controle/Edit/5
        [HttpPost]
        public JsonResult Atualizar(int idAluno, DadosDTO dados)
        {
            try
            {
                IViewHelper vh = new VhAluno();
                AlunoDAO dao = new AlunoDAO();

                var teste = vh.GetEntidade(dados);

                return Json(new { success = dao.Alterar(teste) });
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
                AlunoDAO dao = new AlunoDAO();

                var teste = vh.GetEntidade(dados);

                var data = dao.Consultar(teste);

                return JsonConvert.SerializeObject(data);
            }
            catch
            {
                return JsonConvert.SerializeObject(new { success = false });
            }
        }

        // POST: Controle/Delete/5
        [HttpPost]
        public ActionResult Deletar(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}