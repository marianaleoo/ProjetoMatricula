﻿using Newtonsoft.Json;
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
        public ActionResult Index(DadosDTO dados)
        {
            IViewHelper vh = new VhAluno();
            AlunoDAO dao = new AlunoDAO();

            var teste = vh.GetEntidade(dados);
            var data = dao.Consultar(teste);
            return View(data);
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
        public JsonResult Atualizar(DadosDTO dados)
        {
            try
            {
                IViewHelper vh = new VhAluno();
                AlunoDAO dao = new AlunoDAO();

                var teste = vh.GetEntidade(dados);
                //var teste2 = vh.GetId(dados);

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

        // POST: Controle/Excluir/5
        [HttpPost]
        public JsonResult Excluir(DadosDTO dados)
        {
            try
            {
                IViewHelper vh = new VhAluno();
                AlunoDAO dao = new AlunoDAO();

                var teste = vh.GetEntidade(dados);                

                return Json(new { success = dao.Excluir(teste) });
            }
            catch
            {
                return Json(new { success = false });
            }
        }

        [HttpPost]
        public string Detalhar(DadosDTO dados)
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
    }
}