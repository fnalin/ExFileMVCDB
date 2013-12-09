using ExFileMVCDB.Models;
using System.IO;
using System.Web.Mvc;
using System.Linq;
using System;

namespace ExFileMVCDB.Controllers
{
    public class HomeController : Controller
    {
        private ExFileMVCDBContext _ctx;

        public HomeController()
        {
            _ctx = new ExFileMVCDBContext();
        }

        public ActionResult Index()
        {
            var dados = _ctx.Arquivos;
            return View(dados);
        }

        public ActionResult ReceberArquivo(int id)
        {
            ActionResult result;

            var obj = _ctx.Arquivos.FirstOrDefault(a => a.ID == id);

            result = obj == null
                ? (ActionResult)View("Error")
                //: new FileContentResult(obj.Bytes.ToArray(), obj.Tipo); //Caso queira abrir o arquivo
                : File(obj.AnexoBytes.ToArray(), obj.AnexoTipo, obj.Nome);

            return result;
        }
       
        [HttpPost]
        public ActionResult EnviarArquivo(FormCollection form)
        {
            if (Request.Files.Count != 1)
            {
                return View();
            }

            var post = Request.Files[0];

            if (post == null)
            {
                return View();
            }

            var obj = new Arquivo();

            var file = new FileInfo(post.FileName);
            obj.Nome = file.Name;
            obj.AnexoExtensao = file.Extension;
            obj.AnexoTipo = post.ContentType;

            using (var reader = new BinaryReader(post.InputStream))
                obj.AnexoBytes = reader.ReadBytes(post.ContentLength);


            _ctx.Arquivos.Add(obj);
            _ctx.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult ExcluirArquivo(int id)
        {
            if (id == 1)
            {
                throw new Exception("Operação não permitida");
            }

            var arquivo = _ctx.Arquivos.Find(id);
            _ctx.Arquivos.Remove(arquivo);
            _ctx.SaveChanges();

            return RedirectToAction("Index");

        }

        public ActionResult About()
        {
            ViewBag.Message = "Aplicação criada para teste";
            return View();
        }
       
        protected override void Dispose(bool disposing)
        {
            _ctx.Dispose();
            base.Dispose(disposing);
        }
    }
}