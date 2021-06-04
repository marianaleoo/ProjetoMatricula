﻿using Newtonsoft.Json;
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

        // GET: Controle        
        public ActionResult Index(DadosDTO dados)
        {
            IViewHelper vh = new VhAluno();
            //AlunoDAO dao = new AlunoDAO();

            var teste = vh.GetEntidade(dados);
            List<EntidadeDominio> entidades = _commandConsultar.Exec(teste);
            List<Aluno> alunos = entidades.ConvertAll(item => (Aluno)item);
            //var data = dao.Consultar(teste);
            //List<DadosDTO> dadosDTOs = new List<DadosDTO>();
            //dadosDTOs.Add(new DadosDTO());
            //dadosDTOs.Add(new DadosDTO());
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
                //AlunoDAO dao = new AlunoDAO();

                var teste = vh.GetEntidade(dados);

                return Json(new { success = _commandCadastrar.Executar(teste) });
                //return Json(new { success = dao.Salvar(teste) });
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
                //AlunoDAO dao = new AlunoDAO();

                var teste = vh.GetEntidade(dados);
                //var teste2 = vh.GetId(dados);

                return Json(new { success = _commandAlterar.Executar(teste) });
                // return Json(new { success = dao.Alterar(teste) });
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
                //AlunoDAO dao = new AlunoDAO();

                var teste = vh.GetEntidade(dados);

                var data = _commandConsultar.Executar(teste);

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
                //AlunoDAO dao = new AlunoDAO();

                var teste = vh.GetEntidade(dados);

                
                return Json(new { success = _commandExcluir.Executar(teste) });
                //return Json(new { success = dao.Excluir(teste) });
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
                //AlunoDAO dao = new AlunoDAO();

                var teste = vh.GetEntidade(dados);

                var data = _commandConsultar.Executar(teste);

                return JsonConvert.SerializeObject(data);
            }
            catch
            {
                return JsonConvert.SerializeObject(new { success = false });
            }
        }
    }
}