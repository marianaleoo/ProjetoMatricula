using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoMatricula.Model
{
    public abstract class Pessoa : EntidadeDominio
    {        
        public List<Documento> documentos;

        public Pessoa()
        {
        }

        public Pessoa(List<Documento> documentos) 
        {
            this.documentos = documentos;            
        }

        public List<Documento> getDocumentos()
        {
            return documentos;
        }

        public void setDocumentos(List<Documento> documentos)
        {
            this.documentos = documentos;
        }

        public void addDocumento(Documento documento)
        {
            if (documentos == null)
            {
                documentos = new List<Documento>();
            }
            documentos.Add(documento);
        }
    }
}
