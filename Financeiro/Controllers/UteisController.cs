using Financeiro.Models.DAOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Financeiro.Controllers
{
    public class UteisController : Controller
    {
        public ActionResult EmailUnico(string email)
        {
            var emails = new List<string>();
            var todos = new UsuarioDao().Selecionar();
            foreach (var u in todos)
                emails.Add(u.Email);

            return Json(emails.All(e => e.ToLower() != email.ToLower()), JsonRequestBehavior.AllowGet);
        }
    }
}