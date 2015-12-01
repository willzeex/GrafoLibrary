using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GrafoLibary.Libary.Models;
using GrafoLibary.Libary.Algoritimos;
using GrafoLibary.UI.Models;
using System.Web.Script.Serialization;

namespace GrafoLibary.UI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult FileUpload()
        {
            ViewData["isUploaded"] = "none";
            try
            {
                HttpPostedFileBase file;
                var uploadPath = Server.MapPath("~/Content/Upload");
                string pathArquivo;
                for (int i = 0; i < Request.Files.Count; i++)
                {
                    file = Request.Files[i];
                    if (file.ContentLength > 0)
                    {
                        pathArquivo = Path.Combine(@uploadPath, Path.GetFileName("grafo-teste-1.txt"));
                        if (System.IO.File.Exists(pathArquivo))
                        {
                            System.IO.File.Delete(pathArquivo);
                        }
                        file.SaveAs(pathArquivo);
                        ViewData["isUploaded"] = "visible";
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return View("Index");
        }

        public ActionResult Api()
        {
            return View();
        }

        public JsonResult ExecutaGrafo()
        {
            List<Resposta> respostas = Algoritimos.ExecutaComandos(Server.MapPath("~/Content/Upload/grafo-teste-1.txt"));
            return Json(respostas, JsonRequestBehavior.AllowGet);
        }
    }
}