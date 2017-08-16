using Financeiro.Models.Dao;
using Financeiro.Models.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Financeiro.Controllers
{
    public class UteisController : Controller
    {
        public ActionResult EmailUnico(string usuario)
        {
            var usuarios = new List<string>();
            var todos = new List<Funcionario>().Selecionar();
            foreach (var f in todos)
                usuarios.Add(f.Usuario);

            return Json(usuarios.All(e => e.ToLower() != usuario.ToLower()), JsonRequestBehavior.AllowGet);
        }
    }
}