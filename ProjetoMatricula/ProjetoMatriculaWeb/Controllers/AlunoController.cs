using ProjetoMatricula.DAO;
using ProjetoMatricula.Servico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetoMatriculaWeb.Controllers
{
    public class AlunoController : Controller
    {
        // GET: Aluno        
        public ActionResult Index()
        {
            return View();
        }

        // GET: Aluno/Details/5
        public ActionResult Details()
        {
            return View();
        }

        // GET: Aluno/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Aluno/Create
        [HttpPost]
        public JsonResult Salvar(DadosAlunoDTO dados)
        {
            try
            {
                AlunoServico servico = new AlunoServico();
                AlunoDAO dao = new AlunoDAO();

                var teste = servico.Teste(dados);

                return Json(new { success = dao.Salvar(teste) });
            }
            catch
            {
                return Json(new { success = false });
            }
        }

        // GET: Aluno/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Aluno/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Aluno/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Aluno/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
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