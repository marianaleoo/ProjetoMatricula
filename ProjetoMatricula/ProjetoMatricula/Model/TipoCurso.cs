﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoMatricula.Model
{
    public class TipoCurso : Tipo
    {
        public TipoCurso()
        {
        }

        public TipoCurso(string descricao, string nome)
        {
            this.descricao = descricao;
            this.nome = nome;
        }
    }
}